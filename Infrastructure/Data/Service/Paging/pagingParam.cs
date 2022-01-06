namespace RestApi.Infrastructure.Data.Service.Paging
{
    public class PagingParam
    {
        const int DefaultPageSize = 10;
        const int MaxPageSize = 50;
        public int PageIndex { get; set; }
        private int _pageSize;
        public int PageSize { 
            get => _pageSize;
            set => _pageSize =  value > MaxPageSize ? MaxPageSize : value;
        }

        public PagingParam()
        {
            PageIndex = 1;
            PageSize = DefaultPageSize;
        }
    }
}
