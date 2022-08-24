namespace Lapka.Pet.Application.Dto;

public class PagedResult<T>
{
    public List<T> Items { get; protected set; }
    public int TotalPages { get; protected set; }
    public int ItemFrom { get; protected set; }
    public int ItemsTo { get; protected set; }
    public int TotalItemsCount { get; protected set; }

    public PagedResult(List<T> items, int totalCount, int pageSize, int pageNumber)
    {
        Items = items;
        TotalItemsCount = totalCount;
        ItemFrom = pageSize * (pageNumber - 1) + 1;
        ItemsTo = ItemFrom + pageSize - 1;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    }
}