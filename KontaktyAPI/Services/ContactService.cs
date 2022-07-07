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
    public class ContactService : IContactService
    {
        private readonly ContactDB _dbContext;
        private readonly IMapper _mapper;
        public ContactService(ContactDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
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

        public IEnumerable<ContactDTO> GetAll()
        {
            var contacts = _dbContext
                .Contacts
                .Include(r => r.Category)
                .ToList();

            var contactDTOs = _mapper.Map<List<ContactDTO>>(contacts);

            return contactDTOs;
        }

        public int Create(CreateContactDTO dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();

            return contact.Id;
        }

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
