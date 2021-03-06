namespace RestApi.Infrastructure.Data.Service.Paging
{
    public class PagedList<T> : List<T>
    {
        public int TotalCount { get; set; }
        public PagedList(IEnumerable<T> items, int totalCount)
        {
            AddRange(items);
            TotalCount = totalCount;
        }
    }
}
