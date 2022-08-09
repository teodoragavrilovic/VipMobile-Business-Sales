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
    public class RepositoryClient : IRepositoryClient
    {
        private readonly VipContext context;

        public RepositoryClient(VipContext context)
        {
            this.context = context;
        }
        public void Add(Client enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Client enthity)
        {
            throw new NotImplementedException();
        }

        public Task<Client> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Client enthity)
        {
            throw new NotImplementedException();
        }
    }
}
