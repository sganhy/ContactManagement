using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.ApplicationCore.Services;
using System.Collections.Generic;
using ContactManagement.Web.Models;
using ContactManagement.ApplicationCore.Entities;

namespace ContactManagement.Web.Api
{
    [ApiVersionNeutral]
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService organizationService, IMapper mapper)
        {
            _companyService = organizationService;
            _mapper = mapper;
        }

        [HttpPut("{companyId:int}", Name = nameof(ModifyOrganization))]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> ModifyOrganization([FromRoute] long companyId, [FromBody] CompanyViewModel company)
        {
            await _companyService.ModifyAsync(companyId, _mapper.Map<Company>(company));
            return Ok();
        }

        [HttpPost("", Name = nameof(CreateOrganization))]
        [ProducesResponseType(typeof(long), 201)]
        [ProducesResponseType(typeof(long), 204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateOrganization([FromRoute] CompanyViewModel company) 
        {
            return Ok(await _companyService.CreateAsync(_mapper.Map<Company>(company)));
        }


        [HttpGet("", Name = nameof(GetAllOrganization))]
        [ProducesResponseType(typeof(IEnumerable<CompanyViewModel>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllOrganization() => Ok(await _companyService.GetAllAsync());

        [HttpGet("{companyId:int}", Name = nameof(GetCompanyById))]
        [ProducesResponseType(typeof(ContactViewModel), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCompanyById([FromRoute] long companyId) => Ok(await _companyService.GetByIdAsync(companyId));

    }
}
