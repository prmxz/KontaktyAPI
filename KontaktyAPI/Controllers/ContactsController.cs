using KontaktyAPI.Entities;
using Microsoft.AspNetCore.Mvc;
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

        public ContactsController(ContactDB dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAll()
        {
            var contacts = _dbContext
                .Contacts
                .ToList();

            return Ok(contacts);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Contact> Get([FromRoute]int id)
        {
            var contact = _dbContext
                .Contacts
                .FirstOrDefault(r => r.Id == id);
        }
    }
}
