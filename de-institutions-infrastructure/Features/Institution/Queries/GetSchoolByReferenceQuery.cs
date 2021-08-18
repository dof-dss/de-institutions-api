using AutoMapper;
using de_institutions_api_core.DTOs;
using de_institutions_infrastructure.Data;
using de_institutions_infrastructure.Features.Common;
using dss_common.Extensions;
using dss_common.Functional;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace de_institutions_infrastructure.Features.Institution.Queries
{
    public class GetSchoolByReferenceQuery : IRequest<Result<InstitutionDto>>
    {
        public string InstitutionReference { get; set; }
    }

    public class GetSchoolByReferenceQueryHandler : AbstractBaseHandler<GetSchoolByReferenceQuery, Result<InstitutionDto>>
    {
        public GetSchoolByReferenceQueryHandler(InstituitonContext instituitonContext, IMapper mapper, IValidator<GetSchoolByReferenceQuery> validator)
            : base(instituitonContext, mapper, validator)
        {

        }

        public override async Task<Result<InstitutionDto>> Handle(GetSchoolByReferenceQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await Validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail<InstitutionDto>(validationResult.ToString());

            var maybeInstitution = (await InstituitonContext.Institution.AsNoTracking()
                .Include(a => a.Address)
                .SingleOrDefaultAsync(a => a.ReferenceNumber == request.InstitutionReference
                && (a.InstitutionType == "Primary school" ||
                a.InstitutionType == "Preparatory Schools"
                || a.InstitutionType == "Secondary (non-grammar) school"
                || a.InstitutionType == "Secondary (grammar) school"
                || a.InstitutionType == "Special school")))
                .ToMaybe();

            if (!maybeInstitution.HasValue)
                return Result.Fail<InstitutionDto>("School not found");

            var institution = Mapper.Map<InstitutionDto>(maybeInstitution.Value);

            return Result.Ok(institution);
        }
    }
}