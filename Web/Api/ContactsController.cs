using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.ApplicationCore.Services;
using ContactManagement.Web.Models;
using ContactManagement.ApplicationCore.Entities;
using System.Collections.Generic;

namespace ContactManagement.Web.Api
{
    [ApiVersionNeutral]
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpPut("{contactId:int}", Name = nameof(ModifyContact))]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ModifyContact([FromRoute] long contactId, [FromBody] ContactViewModel contact)
        {
            await _contactService.ModifyAsync(contactId, _mapper.Map<Contact>(contact));
            return Ok();
        }

        [HttpPost("", Name = nameof(CreateContact))]
        [ProducesResponseType(typeof(long), 201)]
        [ProducesResponseType(typeof(long), 204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateContact(ContactViewModel contact)
        {
            var contactId = await _contactService.CreateAsync(_mapper.Map<Contact>(contact));
            return Created(contactId.ToString(), contact);
        }

        [HttpDelete("{contactId:int}", Name = nameof(DeleteContactById))]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteContactById([FromRoute] long contactId)
        {
            await _contactService.DeleteByIdAsync(contactId);
            return Ok();
        }

        [HttpGet("", Name = nameof(GetAllContact))]
        [ProducesResponseType(typeof(IEnumerable<ContactViewModel>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllContact() => Ok(_mapper.Map<IEnumerable<ContactViewModel>>(await _contactService.GetAllAsync()));

        [HttpGet("{contactId:int}", Name = nameof(GetContactById))]
        [ProducesResponseType(typeof(ContactViewModel), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetContactById([FromRoute] long contactId) => Ok(await _contactService.GetByIdAsync(contactId));

    }
}
