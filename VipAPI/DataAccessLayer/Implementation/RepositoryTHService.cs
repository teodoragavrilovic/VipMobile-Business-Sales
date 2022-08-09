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
    public class RepositoryTHService : IRepositoryTHService
    {
        private readonly VipContext context;

        public RepositoryTHService(VipContext context)
        {
            this.context = context;
        }
        public void Add(THService enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(THService enthity)
        {
            throw new NotImplementedException();
        }

        public Task<THService> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<THService>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(THService enthity)
        {
            throw new NotImplementedException();
        }
    }
}
