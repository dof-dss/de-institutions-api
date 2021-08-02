using AutoMapper;
using de_institutions_api_core.DTOs;
using de_institutions_infrastructure.Data;
using de_institutions_infrastructure.Features.Common;
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
    public class GetAllInstitutionsQuery : IRequest<Result<List<InstitutionDto>>>
    {
    }

    public class GetAllInstitutionsQueryHandler : AbstractBaseHandler<GetAllInstitutionsQuery, Result<List<InstitutionDto>>>
    {
        public GetAllInstitutionsQueryHandler(InstituitonContext instituitonContext, IMapper mapper, IValidator<GetAllInstitutionsQuery> validator) : base(instituitonContext, mapper, validator)
        {

        }

        public override async Task<Result<List<InstitutionDto>>> Handle(GetAllInstitutionsQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await Validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Fail<List<InstitutionDto>>(validationResult.ToString());

            var applications = InstituitonContext.Institution
                .AsNoTracking()
                .Include(d => d.Address)
                .ToList();

            var applicationHeaders = Mapper.Map<List<InstitutionDto>>(applications);

            return Result.Ok(applicationHeaders);
        }
    }
}