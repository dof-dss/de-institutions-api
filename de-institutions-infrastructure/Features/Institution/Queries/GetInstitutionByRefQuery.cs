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
    public class GetInstitutionByRefQuery : IRequest<Result<InstitutionDto>>
    {
        public string InstitutionReference { get; set; }
    }

    public class GetInstitutionByRefQueryHandler : AbstractBaseHandler<GetInstitutionByRefQuery, Result<InstitutionDto>>
    {
        public GetInstitutionByRefQueryHandler(InstituitonContext instituitonContext, IMapper mapper, IValidator<GetInstitutionByRefQuery> validator)
            : base(instituitonContext, mapper, validator)
        {

        }

        public override async Task<Result<InstitutionDto>> Handle(GetInstitutionByRefQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await Validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail<InstitutionDto>(validationResult.ToString());

            var maybeInstitution = (await InstituitonContext.Institution.AsNoTracking()
                .Include(a => a.Address)
                .SingleOrDefaultAsync(a => a.ReferenceNumber == request.InstitutionReference))
                .ToMaybe();

            if (!maybeInstitution.HasValue)
                return Result.Fail<InstitutionDto>("Institution not found");

            var institution = Mapper.Map<InstitutionDto>(maybeInstitution.Value);

            return Result.Ok(institution);
        }
    }
}