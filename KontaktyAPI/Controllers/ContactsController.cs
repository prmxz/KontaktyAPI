using AutoMapper;
using KontaktyAPI.Entities;
using KontaktyAPI.Models;
using KontaktyAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Controllers
{
    [Route("api/contact")]
    [Authorize]
    public class ContactsController : ControllerBase            //controller managing Contacts table, methods logic in ContactService class
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)                               //deleting Contact by id 
        {
            var isDeleted = _contactService.Delete(id);

            if(isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ContactDTO>> GetAll()                       // displaying all Contacts
        {

            var contactsDTOs = _contactService.GetAll();


            return Ok(contactsDTOs);
        }
        
        [HttpGet("{id}")]
        [AllowAnonymous]                                                            // displaying chosen Contact by id 
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
        public ActionResult CreateContact([FromBody]CreateContactDTO dto)                   //Creating new Contact
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _contactService.Create(dto);

            return Created($"/api/contact/{id}", null);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateContactDTO dto, [FromRoute]int id)               //Modifying/Updating Contact chosen by id 
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
