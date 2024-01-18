using AutoMapper;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager

    {
        private readonly Lazy<IBookServices> _bookservices;
             
        public ServiceManager(IRepositoryManager  repositoryManager,
            ILoggerService logger, IMapper mapper)
        {
            _bookservices = new Lazy<IBookServices>(()=>new BookManager(
                repositoryManager, logger,mapper )  );
        }

        public IBookServices BookServices =>  _bookservices.Value;
    }
}
