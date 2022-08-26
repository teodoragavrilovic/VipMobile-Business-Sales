using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Client>> GetAll()
        {
            var result = await context.Clients.ToListAsync();
            return result;
        }

        public void Update(Client enthity)
        {
            throw new NotImplementedException();
        }
    }
}
