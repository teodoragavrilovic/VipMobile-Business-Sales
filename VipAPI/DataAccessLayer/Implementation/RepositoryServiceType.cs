using DataAccessLayer.Interfaces;
using Model;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class RepositoryServiceType : IRepositoryServiceType
    {
        private readonly VipContext context;

        public RepositoryServiceType(VipContext context)
        {
            this.context = context;
        }

        public void Add(ServiceType enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ServiceType enthity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceType> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceType>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ServiceType enthity)
        {
            throw new NotImplementedException();
        }
    }
}
