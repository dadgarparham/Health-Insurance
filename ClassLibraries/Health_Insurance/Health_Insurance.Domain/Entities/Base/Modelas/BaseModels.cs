namespace Health_Insurance.Domain.Entities.File
{
    public class ReturnResult
    {
        public ReturnResult UnSuccessResult(string message)
        {
            return new ReturnResult
            {
                Message = message,
                Success = false,
            };
        }

        public ReturnResult SuccessResult(string message)
        {
            return new ReturnResult
            {
                Success = true,
                Message = message
            };
        }

        public ReturnResult SuccessResult()
        {
            return new ReturnResult
            {
                Success = true,
            };
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    public class ReturnResult<TResult>
    {
        public ReturnResult<TResult> UnSuccessResult(string message)
        {
            return new ReturnResult<TResult>
            {
                Message = message,
                Success = false,
            };
        }

        public ReturnResult<TResult> SuccessResult(TResult result, string message)
        {
            return new ReturnResult<TResult>
            {
                Success = true,
                Result = result,
                Message = message
            };
        }

        public ReturnResult<TResult> SuccessResult(TResult result)
        {
            return new ReturnResult<TResult>
            {
                Success = true,
                Result = result
            };
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public TResult Result { get; set; }
    }
    public class PagedListModel<T>
    {
        public PagedListModel()
        {
            Results = new List<T>();
        }

        public IEnumerable<T> Results { get; set; }
        public int? TotalRow { get; set; }
    }

    public class KeyValueModel<T> where T : struct
    {
        public T Id { get; set; }
        public string Title { get; set; }
    }

    public class KeyValueModel : KeyValueModel<long>
    {
    }
}
