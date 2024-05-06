namespace Health_Insurance.Domain.Entities.Base
{
    public class BaseSearchParameters
    {
        public BaseSearchParameters()
        {
            PageSize = 20;
            PageNumber = 1;
        }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
