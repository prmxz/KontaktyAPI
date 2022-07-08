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
    /// <summary>
    /// controller managing Contacts table, methods logic in ContactService class
    /// </summary>
    [Route("api/contact")]
    [Authorize]
    public class ContactsController : ControllerBase            
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// deleting Contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>deletes contact with matching id parameter</returns>
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

        /// <summary>
        ///  displaying all Contacts
        /// </summary>
        /// <returns>displays all Contacts</returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ContactDTO>> GetAll()                       
        {

            var contactsDTOs = _contactService.GetAll();


            return Ok(contactsDTOs);
        }

        /// <summary>
        ///  displaying chosen Contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>display Contact with matching id parameter</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]                                                             
        public ActionResult<ContactDTO> Get([FromRoute]int id)
        {
            var contact = _contactService.GetById(id);

            if(contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        /// <summary>
        /// Creating new Contact
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Creates new Contact at the end of list Contacts</returns>
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
        /// <summary>
        /// Modifying/Updating Contact chosen by id parameter
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns>Modifies contact with matching id with new attributes(if such is given)</returns>
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
