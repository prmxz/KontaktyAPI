using KontaktyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI
{
    public class ContactSeeder
    {
        private readonly ContactDB _dbContext;
        public ContactSeeder(ContactDB dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())                //if connection to database is successful
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);                       //if respective tables are empty, fill them with corresponding values
                    _dbContext.SaveChanges();
                }
                if(!_dbContext.Contacts.Any())
                {
                    var contacts = GetContacts();
                    _dbContext.Contacts.AddRange(contacts);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Private"                            // Initial filling Roles Table
                },
                new Role()
                {
                    Name = "Work"
                }
            };
            return roles;
        }
        private IEnumerable<Contact> GetContacts()                  //Initial filling Contacts Table
        {
            var contacts = new List<Contact>()
            {
                new Contact()
                {
                    Name = "Luke",
                    Surname = "Dembowskee",
                    Email = "lukdembo@mail.com",
                    Password = "pAssword123@",
                    PhoneNumber = "123456789",
                    BirthDate = "10-10-1996",
                    Category = new Category()
                    {
                        Role = "Boss"
                    }                                                           
                },
                new Contact()
                {
                    Name = "Jacob",
                    Surname = "Nowak",
                    Email = "jnow@mail.com",
                    Password = "PASSWORd321!",
                    PhoneNumber = "987654321",
                    BirthDate = "20-09-1984",
                    Category = new Category()
                    {
                        Role = "Employee"
                    }
                }


            };

            return contacts;
        }
    }
}
