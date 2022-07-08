using AutoMapper;
using KontaktyAPI.Entities;
using KontaktyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI
{
    public class ContactMappingProfile : Profile
    {

        /// <summary>
        /// Mapping profile for mapping Contact from CreateContactDTO or ContactDTO from Contact
        /// </summary>
        public ContactMappingProfile()
        {
            CreateMap<Contact, ContactDTO>()
                .ForMember(m => m.Category, n => n.MapFrom(o => o.Category.Role));

            CreateMap<CreateContactDTO, Contact>()
                .ForMember(a => a.Category, b => b.MapFrom(dto => new Category() { Role = dto.Category }));
        }
    }
}
