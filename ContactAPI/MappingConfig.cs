using AutoMapper;
using ModelAPI;
using ModelDTO;

namespace ContactAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();

            CreateMap<Contact, ContactCreateDTO>().ReverseMap();
            CreateMap<Contact, ContactUpdateDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
