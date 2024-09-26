using AutoMapper;
using Entities.Models;
using Repository.Contracts;
using Service.Contracts;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PersonService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonDTO> AddPersonAsync(PersonCreateDTO personDTO)
        {
            var person = _mapper.Map<Person>(personDTO);

            await _repository.Person.AddPersonAsync(person);
            await _repository.SaveAsync();

            var personDTOReturn = _mapper.Map<PersonDTO>(person);

            return personDTOReturn;
        }

        public async Task DeletePersonAsync(Guid id)
        {
            var person = await _repository.Person.GetPersonByIdAsync(id);
            if (person is null)
                throw new FileNotFoundException();
            await _repository.Person.DeletePersonAsync(id);
            await _repository.SaveAsync();

        }

        public async Task<IEnumerable<PersonDTO>> GetAllPersonAsync()
        {
            var persons = await _repository.Person.GetAllPersonAsync();
            var personsDto = _mapper.Map<IEnumerable<PersonDTO>>(persons);
            return personsDto;
        }

        public async Task<PersonDTO> GetPersonByIdAsync(Guid id)
        {
            var person = await _repository.Person.GetPersonByIdAsync(id) ?? throw new FileNotFoundException();
            var personDto = _mapper.Map<PersonDTO>(person);
            return personDto;
        }

        public async Task UpdatePersonAsync(Guid id, PersonUpdateDTO personDTO)
        {
            var person = await _repository.Person.GetPersonByIdAsync(id);
            if (person is null)
                throw new FileNotFoundException();
            _mapper.Map(personDTO, person);
            await _repository.SaveAsync();
        }
    }
}
