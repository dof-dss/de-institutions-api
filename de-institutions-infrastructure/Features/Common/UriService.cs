using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace de_institutions_infrastructure.Features.Common
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(IHttpContextAccessor httpContextAccessor)
        {
            _baseUri = string.Concat(httpContextAccessor.HttpContext.Request.Scheme, "://", httpContextAccessor.HttpContext.Request.Host.ToUriComponent(), "/");
        }

        public Uri CreateNextPageUri(PaginationDetails paginationDetails) =>
            CreateUriFor(paginationDetails.ApiRoute, paginationDetails.NextPageNumber,
                paginationDetails.PageSize);

        public Uri CreatePreviousPageUri(PaginationDetails paginationDetails) =>
            CreateUriFor(paginationDetails.ApiRoute, paginationDetails.PreviousPageNumber,
                paginationDetails.PageSize);

        private Uri CreateUriFor(string route, int pageNumber, int pageSize)
        {
            var modifiedUri = QueryHelpers.AddQueryString(_baseUri + route, "pageNumber", pageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pageSize.ToString());

            return new Uri(modifiedUri);
        }
    }
}