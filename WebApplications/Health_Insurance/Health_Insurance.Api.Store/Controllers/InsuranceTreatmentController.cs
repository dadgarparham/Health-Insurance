using Health_Insurance.Domain.Entities.Base;
using Microsoft.AspNetCore.Mvc;

namespace Health_Insurance.Api.Controllers
{
    /// <summary>
    /// File Manager
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceTreatmentController : BaseApiController
    {
        private readonly IInsuranceEntityService _insuranceEntityService;
        /// <inheritdoc />
        public InsuranceTreatmentController(IInsuranceEntityService insuranceEntityService)
        {
            _insuranceEntityService = insuranceEntityService;
        }
    }
}
