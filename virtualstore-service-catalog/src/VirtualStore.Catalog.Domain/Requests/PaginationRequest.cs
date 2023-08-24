using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Catalog.Domain.Requests;

public class PaginationRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Page number should be greater than or equal to 1.")]
    public int PageNumber { get; set; }


    public int PageSize { get; set; }
}