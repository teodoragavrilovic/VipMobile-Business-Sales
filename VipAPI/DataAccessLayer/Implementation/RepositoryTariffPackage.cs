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
    public class RepositoryTariffPackage : IRepositoryTariffPackage
    {
        private readonly VipContext context;

        public RepositoryTariffPackage(VipContext context)
        {
            this.context = context;
        }

        public void Add(TariffPackage enthity)
        {
            enthity.PackageType = context.PackageTypes.Find(enthity.PackageType.PackageTypeId);
            try
            {
                context.Add(enthity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(TariffPackage enthity)
        {
            context.Remove(enthity);
        }

        public Task<TariffPackage> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TariffPackage>> GetAll()
        {
            var result = await context.TariffPackages.ToListAsync();
            foreach(var package in result)
            {
                package.PackageType = context.PackageTypes.Find(package.PackageTypeId);
            }
            return result;
        }

        public void Update(TariffPackage enthity)
        {
            enthity.PackageType = context.PackageTypes.Find(enthity.PackageType.PackageTypeId);
            context.Update(enthity);
        }
    }
}
