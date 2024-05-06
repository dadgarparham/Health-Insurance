using Health_Insurance.Domain.Entities.File;

namespace Health_Insurance.Api.Controllers.WebCore;
public class ApiResult<TResult>
{
    public ApiResult(ReturnResult<TResult> returnResult)
    {
        if (returnResult.Success)
        {
            Success = true;
            Data = returnResult.Result;
        }
        else
        {
            Success = false;
            if (!string.IsNullOrEmpty(returnResult.Message))
            {
                Message = new MessageInfo
                {
                    MessageType = MessageType.Warning,

                };
                Message.Messages.Add(new MessageItem { Message = returnResult.Message });
            }
        }
    }
    private MessageInfo _messageInfo;
    public TResult Data { get; set; }
    public bool Success { get; set; }
    public MessageInfo Message { get; set; }

}

public class ApiResult
{
    public ApiResult(ReturnResult returnResult)
    {
        if (returnResult.Success)
        {
            Success = true;
        }
        else
        {
            Success = false;
            if (!string.IsNullOrEmpty(returnResult.Message))
            {
                Message = new MessageInfo
                {
                    MessageType = MessageType.Warning,

                };
                Message.Messages.Add(new MessageItem { Message = returnResult.Message });
            }
        }


    }
    private MessageInfo _messageInfo;
    public bool Success { get; set; }
    public MessageInfo Message { get; set; }

}