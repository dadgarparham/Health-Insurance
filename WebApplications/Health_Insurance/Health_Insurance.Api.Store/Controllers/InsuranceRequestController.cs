using Health_Insurance.Api.Controllers.WebCore;
using Health_Insurance.Domain.Entities;
using IdentityModel.OidcClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Threading;

namespace Health_Insurance.Api.Controllers
{
    /// <summary>
    /// File Manager
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceRequestController : BaseApiController
    {
        private readonly IInsuranceRequestEntityService _insuranceRequestEntityService;
        /// <inheritdoc />
        public InsuranceRequestController(IInsuranceRequestEntityService insuranceRequestEntityService)
        {
            _insuranceRequestEntityService = insuranceRequestEntityService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult<bool>>> AddInsuranceRequest(InsuranceRequestDto insuranceRequest, CancellationToken cancellation = default)
        {
            var result = await _insuranceRequestEntityService.AddInsuranceRequestAsync(insuranceRequest, cancellation);
        
            return new ApiResult<bool>(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ApiResult<bool>>> GetInsuranceRequest(long id)
        {
            var data = await _insuranceRequestEntityService.GetInsuranceRequestAsync(id);
            return new ApiResult<bool>(data);
        }


    }
}
