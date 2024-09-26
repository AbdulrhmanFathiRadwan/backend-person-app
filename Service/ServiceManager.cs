using AutoMapper;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPersonService> _studentService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _studentService = new Lazy<IPersonService>(() => new PersonService(repositoryManager, mapper));
        }

        public IPersonService PersonService => _studentService.Value;
    }
}
