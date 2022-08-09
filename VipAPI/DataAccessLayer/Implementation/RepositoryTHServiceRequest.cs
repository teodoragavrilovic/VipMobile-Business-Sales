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
    public class RepositoryTHServiceRequest : IRepositoryTHServiceRequest
    {
        private readonly VipContext context;

        public RepositoryTHServiceRequest(VipContext context)
        {
            this.context = context;
        }
        public void Add(THServiceRequest enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(THServiceRequest enthity)
        {
            throw new NotImplementedException();
        }

        public Task<THServiceRequest> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<THServiceRequest>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(THServiceRequest enthity)
        {
            throw new NotImplementedException();
        }
    }
}
