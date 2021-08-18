using AutoMapper;
using de_institutions_api_core.DTOs;
using de_institutions_infrastructure.Data;
using de_institutions_infrastructure.Features.Common;
using dss_common.Extensions;
using dss_common.Functional;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace de_institutions_infrastructure.Features.Institution.Queries
{
    public class GetSchoolByNameQuery : IRequest<Result<List<InstitutionDto>>>
    {
        public string Name { get; set; }
    }

    public class GetSchoolByNameQueryHandler : AbstractBaseHandler<GetSchoolByNameQuery, Result<List<InstitutionDto>>>
    {
        public GetSchoolByNameQueryHandler(InstituitonContext instituitonContext, IMapper mapper, IValidator<GetSchoolByNameQuery> validator)
            : base(instituitonContext, mapper, validator)
        {

        }

        public override async Task<Result<List<InstitutionDto>>> Handle(GetSchoolByNameQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await Validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail<List<InstitutionDto>>(validationResult.ToString());

            var maybeInstitution = InstituitonContext.Institution.AsNoTracking()
                .Where(a => a.Name.Contains(request.Name) && (a.InstitutionType == "Primary school" ||
                a.InstitutionType == "Preparatory Schools"
                || a.InstitutionType == "Secondary (non-grammar) school"
                || a.InstitutionType == "Secondary (grammar) school"
                || a.InstitutionType == "Special school"))
                .Include(a => a.Address)
                .ToMaybe();

            if (!maybeInstitution.HasValue)
                return Result.Fail<List<InstitutionDto>>("School not found");

            var institution = Mapper.Map<List<InstitutionDto>>(maybeInstitution.Value);

            return Result.Ok(institution);
        }
    }
}