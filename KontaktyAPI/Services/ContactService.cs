using AutoMapper;
using KontaktyAPI.Entities;
using KontaktyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Services
{
    public interface IContactService
    {
        ContactDTO GetById(int id);
        IEnumerable<ContactDTO> GetAll();
        int Create(CreateContactDTO dto);
        bool Delete(int id);
        bool Update(UpdateContactDTO dto, int id);
    }

    /// <summary>
    /// //class holding ContactController's methods' logic
    /// </summary>
    public class ContactService : IContactService           
    {
        private readonly ContactDB _dbContext;
        private readonly IMapper _mapper;


        public ContactService(ContactDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Displays contact with chosen id parameter, includes Mapping ContactDTO to Contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Contact from Contacts table with matching id parameter</returns>
        public ContactDTO GetById(int id)
        {
            var contact = _dbContext
            .Contacts
            .Include(r => r.Category)
            .FirstOrDefault(r => r.Id == id);

            if (contact is null) return null;

            var result = _mapper.Map<ContactDTO>(contact);
            return result;
        }

        /// <summary>
        /// Displays all data from Contacts table from given database
        /// </summary>
        /// <returns>Displays all Contacts</returns>
        public IEnumerable<ContactDTO> GetAll()
        {
            var contacts = _dbContext
                .Contacts
                .Include(r => r.Category)
                .ToList();

            var contactDTOs = _mapper.Map<List<ContactDTO>>(contacts);

            return contactDTOs;
        }

        /// <summary>
        /// Create new Contact in Contacts table with attributes stated in dto parameter
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Create new Contact</returns>
        public int Create(CreateContactDTO dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();

            return contact.Id;
        }

        /// <summary>
        /// Removes Contact (chosen with id parameter) from Contacts table 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Removes Contact with matching id parameter</returns>
        public bool Delete(int id)
        {
            var contact = _dbContext
                .Contacts
                .FirstOrDefault(r => r.Id == id);
            if (contact is null) return false;

            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();

            return true;

        }

        /// <summary>
        /// Modifies Contact chosen with id parameter with data provided in dto parameter
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns>Updated Contact in Contacts table</returns>
        public bool Update(UpdateContactDTO dto, int id)
        {
            var contact = _dbContext
                .Contacts
                .FirstOrDefault(r => r.Id == id);
            if (contact is null) return false;

            contact.Name = dto.Name;
            contact.Surname = dto.Surname;
            contact.Email = dto.Email;
            contact.Password = dto.Password;
            contact.BirthDate = dto.BirthDate;
            contact.PhoneNumber = dto.PhoneNumber;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
