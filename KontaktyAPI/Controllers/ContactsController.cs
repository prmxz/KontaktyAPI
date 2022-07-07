using AutoMapper;
using KontaktyAPI.Entities;
using KontaktyAPI.Models;
using KontaktyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Controllers
{
    [Route("api/contact")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            var isDeleted = _contactService.Delete(id);

            if(isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContactDTO>> GetAll()
        {

            var contactsDTOs = _contactService.GetAll();


            return Ok(contactsDTOs);
        }
        
        [HttpGet("{id}")]
        public ActionResult<ContactDTO> Get([FromRoute]int id)
        {
            var contact = _contactService.GetById(id);

            if(contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public ActionResult CreateContact([FromBody]CreateContactDTO dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _contactService.Create(dto);

            return Created($"/api/contact/{id}", null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateContactDTO dto, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _contactService.Update(dto, id);

            if (!isUpdated) return NotFound();

            return Ok();
        }
    }
}
