using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetAllPersonAsync();
        Task<PersonDTO> GetPersonByIdAsync(Guid id);
        Task<PersonDTO> AddPersonAsync(PersonCreateDTO entity);
        Task UpdatePersonAsync(Guid id, PersonUpdateDTO entity);
        Task DeletePersonAsync(Guid id);
    }
}
