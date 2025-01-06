using Insurance.Model;
using Insurance.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Policy>>> GetAllPolicies()
        {
            var policies = await _policyService.GetAllPolicies();
            if (policies == null) return NotFound();

            return Ok(policies);
        }

        [HttpGet("{number}")]
        public async Task<ActionResult<Policy>> GetPolicyByNumber(string number)
        {
            var policy = await _policyService.GetPolicyByNumber(number);
            if (policy == null) return NotFound();

            return Ok(policy);
        }

        [HttpPost]
        public async Task<ActionResult> AddPolicy(Policy policy)
        {
            var insertedId = await _policyService.AddPolicy(policy);
            return Ok(insertedId);
        }
    }
}
