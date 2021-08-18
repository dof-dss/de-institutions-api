using AutoMapper;
using de_institutions_api_core.DTOs;
using de_institutions_infrastructure.Data;
using de_institutions_infrastructure.Features.Common;
using dss_common.Functional;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace de_institutions_infrastructure.Features.Institution.Queries
{
    public class GetAllQuery : IRequest<Result<PagedResult<InstitutionDto>>>
    {
        public GetAllQuery()
        {
            PageNumber = 1;
            PageSize = 100;
        }
        public GetAllQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAuditsQueryValidator : AbstractValidator<GetAllQuery>
    {
        public GetAuditsQueryValidator()
        {
            RuleFor(m => m.PageNumber).GreaterThan(0);
        }
    }

    public class GetAllQueryHandler : RequestHandler<GetAllQuery, Result<PagedResult<InstitutionDto>>>
    {
        private readonly InstituitonContext _instituitonContext;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public GetAllQueryHandler(InstituitonContext instituitonContext, IMapper mapper, IUriService uriService)
        {
            _instituitonContext = instituitonContext;
            _mapper = mapper;
            _uriService = uriService;
        }

        protected override Result<PagedResult<InstitutionDto>> Handle(GetAllQuery request)
        {
            var pagination = _mapper.Map<PaginationDetails>(request).WithTotal(_instituitonContext.Institution.Count());

            var audits = _mapper.ProjectTo<InstitutionDto>(_instituitonContext.Institution.Include(a => a.Address)).OrderBy(a => a.Name)
                .Skip(pagination.PreviousPageNumber * pagination.PageSize)
                .Take(request.PageSize).ToList();

            var paginationResponse = PagedResult<InstitutionDto>.CreatePaginatedResponse(_uriService, pagination, audits);

            return Result.Ok(paginationResponse);
        }
    }
}