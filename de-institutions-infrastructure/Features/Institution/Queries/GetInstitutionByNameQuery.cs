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
    public class GetInstitutionByNameQuery : IRequest<Result<List<InstitutionDto>>>
    {
        public string Name { get; set; }
    }

    public class GetInstitutionByNameQueryHandler : AbstractBaseHandler<GetInstitutionByNameQuery, Result<List<InstitutionDto>>>
    {
        public GetInstitutionByNameQueryHandler(InstituitonContext instituitonContext, IMapper mapper, IValidator<GetInstitutionByNameQuery> validator)
            : base(instituitonContext, mapper, validator)
        {

        }

        public override async Task<Result<List<InstitutionDto>>> Handle(GetInstitutionByNameQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await Validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Fail<List<InstitutionDto>>(validationResult.ToString());

            var maybeInstitution = InstituitonContext.Institution.AsNoTracking()
                .Where(a => a.Name.Contains(request.Name))
                .Include(a => a.Address)
                .ToMaybe();

            if (!maybeInstitution.HasValue)
                return Result.Fail<List<InstitutionDto>>("Institutions not found");

            var institution = Mapper.Map<List<InstitutionDto>>(maybeInstitution.Value);

            return Result.Ok(institution);
        }
    }
}