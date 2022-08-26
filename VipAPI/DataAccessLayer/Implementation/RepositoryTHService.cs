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

        public async Task<List<THService>> GetAll()
        {
            var result = await context.THServices.ToListAsync();
            foreach (var service in result)
            {
                service.ServiceType = context.ServiceTypes.Find(service.ServiceTypeId);
            }
            return result;
        }

        public void Update(THService enthity)
        {
            throw new NotImplementedException();
        }
    }
}
