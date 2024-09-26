using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonAsync();
        Task<Person> GetPersonByIdAsync(Guid id);
        Task AddPersonAsync(Person entity);
        Task UpdatePersonAsync(Person entity);
        Task DeletePersonAsync(Guid id);
    }
}
