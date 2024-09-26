using Entities.Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public async Task<IEnumerable<Person>> GetAllPersonAsync() => await GetAllAsync();
        public async Task<Person> GetPersonByIdAsync(Guid id) => await GetByIdAsync(id);
        public async Task AddPersonAsync(Person entity) => await AddAsync(entity);
        public async Task UpdatePersonAsync(Person entity) => await UpdateAsync(entity);
        public async Task DeletePersonAsync(Guid id) => await DeleteAsync(id);
    }
}
