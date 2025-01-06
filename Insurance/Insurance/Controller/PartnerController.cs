using Insurance.Model;
using Insurance.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Partner>>> GetAllPartners()
        {
            var partners = await _partnerService.GetAllPartners();
            if (partners == null) return NotFound();

            return Ok(partners);
        }

        [HttpGet("{number}")]
        public async Task<ActionResult<Partner>> GetPartnerByNumber(string number)
        {
            var partner = await _partnerService.GetPartnerByNumber(number);
            if (partner == null) return NotFound();

            return Ok(partner);
        }

        [HttpGet("{number}/Policies")]
        public async Task<ActionResult<Partner>> GetPartnerPolicies(string number)
        {
            var partner = await _partnerService.GetPartnerPolicies(number);
            if (partner == null) return NotFound();

            return Ok(partner);
        }

        [HttpPost]
        public async Task<ActionResult<Partner>> AddPartner(Partner partner)
        {
            var inserted = await _partnerService.AddPartner(partner);
            return Ok(inserted);
        }
    }
}
