using Microsoft.AspNetCore.WebUtilities;
using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Catalog.Core.Helpers;

public static class PaginationHelpers<T>
{
    public static PaginationResponse<T> CreateResponse(IUriService service, T data, int page, int size, int count)
    {
        PaginationResponse<T> response = new();
        Uri endpoint = GetEndpoint(service);

        response.PageNumber = page;
        response.PageSize = size;

        response.TotalRecords = count;
        response.TotalPages = GetTotalPages(count, size);

        response.FirstPage = GetFirstPage(endpoint, size);
        response.LastPage = GetLastPage(endpoint, size, response.TotalPages);

        response.NextPage = GetNextPage(endpoint, response.PageNumber, size, response.TotalRecords);
        response.PreviousPage = GetPreviousPage(endpoint, response.PageNumber, size, response.TotalRecords);

        response.Data = data;

        return response;
    }

    private static int GetTotalPages(int count, int size) => Convert.ToInt32((double)count / (double)size);

    private static Uri GetUriAddedQuery(string endpoint, string name, string value) => new(QueryHelpers.AddQueryString(endpoint, name, value));

    private static Uri GetEndpoint(IUriService service) => service.GetEndpoint();

    private static Uri GetFirstPage(Uri endpoint, int size, int page = 1)
    {
        Uri uriFistPage = GetUriAddedQuery(endpoint.ToString(), nameof(page), page.ToString());
        return GetUriAddedQuery(uriFistPage.ToString(), nameof(size), size.ToString());
    }

    private static Uri GetLastPage(Uri endpoint, int size, int page = 1)
    {
        Uri uriFistPage = GetUriAddedQuery(endpoint.ToString(), nameof(page), page.ToString());
        return GetUriAddedQuery(uriFistPage.ToString(), nameof(size), size.ToString());
    }

    private static Uri GetNextPage(Uri endpoint, int page, int size, int totalRecords)
    {
        if (page - 1 >= 0 && page <= totalRecords)
        {
            Uri uriNextPage = GetUriAddedQuery(endpoint.ToString(), nameof(page), (page + 1).ToString());
            return GetUriAddedQuery(uriNextPage.ToString(), nameof(size), size.ToString());
        }

        return null;

    }

    private static Uri GetPreviousPage(Uri endpoint, int page, int size, int totalRecords)
    {
        if (page >= 1 && page < totalRecords)
        {
            Uri uriNextPage = GetUriAddedQuery(endpoint.ToString(), nameof(page), (page - 1).ToString());
            return GetUriAddedQuery(uriNextPage.ToString(), nameof(size), size.ToString());
        }

        return null;

    }
}