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
    public class RepositoryTariffPackage : IRepositoryTariffPackage
    {
        private readonly VipContext context;

        public RepositoryTariffPackage(VipContext context)
        {
            this.context = context;
        }

        public void Add(TariffPackage enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TariffPackage enthity)
        {
            throw new NotImplementedException();
        }

        public Task<TariffPackage> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TariffPackage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TariffPackage enthity)
        {
            throw new NotImplementedException();
        }
    }
}
