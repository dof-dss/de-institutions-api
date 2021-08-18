using System;

namespace de_institutions_infrastructure.Features.Common
{
    public interface IUriService
    {
        Uri CreateNextPageUri(PaginationDetails paginationDetails);
        Uri CreatePreviousPageUri(PaginationDetails paginationDetails);
    }
}