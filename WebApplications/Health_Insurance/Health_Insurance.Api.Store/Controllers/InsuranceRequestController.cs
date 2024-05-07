using Health_Insurance.Api.Controllers.WebCore;
using Health_Insurance.Domain.Entities;
using Health_Insurance.Domain.Entities.File;
using Health_Insurance.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Health_Insurance.Api.Controllers
{
    /// <summary>
    /// Insurance Request
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceRequestController : BaseApiController
    {
        private readonly IInsuranceRequestEntityService _insuranceRequestEntityService;
        /// <summary>
        /// دسته بندی درخواست های حق بیمه
        /// </summary>
        /// <param name="insuranceRequestEntityService"></param>
        public InsuranceRequestController(IInsuranceRequestEntityService insuranceRequestEntityService)
        {
            _insuranceRequestEntityService = insuranceRequestEntityService;
        }
        /// <summary>
        /// ثبت درخواست
        /// </summary>
        /// <param name="insuranceRequest"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ApiResult<bool>>> AddInsuranceRequest(InsuranceRequestDto insuranceRequest, 
            CancellationToken cancellation = default)
        {
            var result = await _insuranceRequestEntityService.AddInsuranceRequestAsync(insuranceRequest, cancellation);
        
            return new ApiResult<bool>(result);
        }

        /// <summary>
        ///  دریافت لیست درخواستها
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ActionResult<ApiResult<GetInsuranceRequestPagedListModel>>> GetInsuranceRequestList([FromQuery] GetInsuranceRequestParameters parameters,
            CancellationToken cancellation = default)
        {
            var data = await _insuranceRequestEntityService.GetInsuranceRequestListAsync(parameters, cancellation);
            return new ApiResult<GetInsuranceRequestPagedListModel>(data);
        }
    }
}
