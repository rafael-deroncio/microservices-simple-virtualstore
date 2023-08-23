namespace VirtualStore.Catalog.Domain.Requests;

public class PaginationRequest
{
    private int pageNumber = 1;
    private int pagesize = 5;

    public int PageNumber
    {
        get { return pageNumber; }
        set { pageNumber = value < 1 ? 1 : value; }
    }

    public int PageSize
    {
        get { return pagesize; }
        set { pagesize = value > 10 ? 10 : value; }
    }
}