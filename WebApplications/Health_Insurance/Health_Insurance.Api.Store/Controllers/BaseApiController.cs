using Health_Insurance.Api.Controllers.WebCore;
using Health_Insurance.Domain.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Health_Insurance.Api.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {        
        protected AppResult Message(MessageType messageType, params string[] messages)
        {
            var result = new AppResult();
            result.SetMessage(messageType, messages);

            return result;
        }

        protected AppResult AppResult(bool success, object data = null)
        {
            var result = new AppResult { Success = success, Data = data };
            return result;
        }

        protected AppResult SuccessfullResult(object data = null)
        {
            var result = new AppResult { Success = true, Data = data };
            return result;
        }

        protected AppResult UnSuccessfullResult(object data = null)
        {
            var result = new AppResult { Success = false, Data = data };
            return result;
        }

        protected AppResult SuccessfullMessage(object data = null)
        {
            var result = new AppResult
            {
                Success = true,
                Data = data
            };

            result.SetSuccessMessage(GlobalMessage.SuccessfullMessage);

            return result;
        }

        protected AppResult ExceptionMessage(System.Exception ex)
        {
            var result = new AppResult
            {
                Success = false
            };

            result.SetDangerMessage(GlobalMessage.GlobalErrorMessage + ex.Message);

            return result;
        }

        protected AppResult ErrorMessage(string message, object data = null)
        {
            var result = new AppResult { Success = false, Data = data };

            result.SetDangerMessage(message);
            return result;
        }

        protected AppResult ErrorMessage(ModelStateDictionary modelState)
        {
            var errors = modelState.Where(x => x.Value.Errors.Any())
                .SelectMany(y => y.Value.Errors.Select(e => e.ErrorMessage))
                .Select(x => new MessageItem { Message = x });

            var result = new AppResult { Success = false };
            result.SetMessage(MessageType.Danger, errors);

            return result;
        }

    }

}