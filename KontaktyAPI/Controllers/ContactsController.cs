using AutoMapper;
using KontaktyAPI.Entities;
using KontaktyAPI.Models;
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
        private readonly ContactDB _dbContext;
        private readonly IMapper _mapper;

        public ContactsController(ContactDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ContactDTO>> GetAll()
        {
            var contacts = _dbContext
                .Contacts
                .Include(r => r.Category)
                .ToList();

            var contactsDTOs = _mapper.Map<List<ContactDTO>>(contacts);

            return Ok(contactsDTOs);
        }
        
        [HttpGet("{id}")]
        public ActionResult<ContactDTO> Get([FromRoute]int id)
        {
            var contact = _dbContext
                .Contacts
                .Include(r => r.Category)
                .FirstOrDefault(r => r.Id == id);

            if(contact is null)
            {
                return NotFound();
            }

            var contactDTO = _mapper.Map<ContactDTO>(contact);
            return Ok(contactDTO);
        }

        [HttpPost]
        public ActionResult CreateContact([FromBody]CreateContactDTO dto)
        {
            return null;
        }
    }
}
