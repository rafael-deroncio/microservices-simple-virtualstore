using VirtualStore.Catalog.Domain.Requests;
using VirtualStore.Catalog.Domain.Responses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VirtualStore.Catalog.Core.Helpers;

public static class PaginationHelper<T>
{
    public static PaginationResponse<T> CreateResponse(T data, int page, int size, int count)
    {
        return new PaginationResponse<T>()
        {
            PageNumber = page,
            PageSize = size,

            FirstPage = new Uri(""),
            LastPage = new Uri(""),

            TotalRecords = count,
            TotalPages = Convert.ToInt32((double)count / (double)size),

            NextPage = new Uri(""),
            PreviousPage = new Uri(""),

            Data = data,
        };
    }
}