using AutoMapper;
using Entities.Models;
using Shared.DataTransferObject;
using System.Security.Principal;

namespace backend_person_app
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonCreateDTO, Person>();
            CreateMap<PersonUpdateDTO, Person>();

        }
    }
}
