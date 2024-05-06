
using Microsoft.AspNetCore.Mvc;

namespace Health_Insurance.Api.Controllers.WebCore
{
    public class AppResult : ActionResult
    {
        private MessageInfo _messageInfo;
        public object Data { get; set; }
        public bool Success { get; set; }
        public string ContentType { get; set; }

        
        public override Task ExecuteResultAsync(ActionContext context)
        {
            var value = new
            {
                Data,
                Success,
                Message =  _messageInfo
            };

            var jsonResult = new JsonResult(value);
            return jsonResult.ExecuteResultAsync(context);
        }


        public void SetSuccessMessage(params string[] messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = MessageType.Success,
                Messages = messages.Select(x => new MessageItem { Message = x }).ToList()
            };
        }

        public void SetInfoMessage(params string[] messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = MessageType.Info,
                Messages = messages.Select(x => new MessageItem { Message = x }).ToList()
            };
        }

        public void SetWarningMessage(params string[] messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = MessageType.Warning,
                Messages = messages.Select(x => new MessageItem { Message = x }).ToList()
            };
        }

        public void SetDangerMessage(params string[] messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = MessageType.Danger,
                Messages = messages.Select(x => new MessageItem { Message = x }).ToList()
            };
        }

        public void SetMessage(MessageType messageType, IEnumerable<string> messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = messageType,
                Messages = messages.Select(x => new MessageItem { Message = x }).ToList()
            };
        }

        public void SetMessage(MessageType messageType, IEnumerable<MessageItem> messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = messageType,
                Messages = messages.ToList()
            };
        }
    }



    [Serializable]
    public class MessageInfo
    {
        public MessageInfo()
        {
            Messages = new List<MessageItem>();
        }

        public List<MessageItem> Messages { get; set; }
        public MessageType MessageType { get; set; }
    }

    [Serializable]
    public class MessageItem
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }

    public enum MessageType
    {
        Success = 0,
        Info = 1,
        Warning = 2,
        Danger = 3
    }

}