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

        /// <summary>
        /// if connection to database is successful and if respective tables are empty, fill them with provided roles/contacts 
        /// </summary>
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())                
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);                       
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

        /// <summary>
        /// // Initial filling of Roles table
        /// </summary>
        /// <returns>Fills table Roles with given data</returns>
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Private"                            
                },
                new Role()
                {
                    Name = "Work"
                }
            };
            return roles;
        }

        /// <summary>
        /// //Initial filling of Contacts table
        /// </summary>
        /// <returns>Fills table Contacts with given data</returns>
        private IEnumerable<Contact> GetContacts()                  
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
