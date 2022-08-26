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
    public class RepositoryPackageType : IRepositoryPackageType
    {
        private readonly VipContext context;

        public RepositoryPackageType(VipContext context)
        {
            this.context = context; 
        }
        public void Add(PackageType enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PackageType enthity)
        {
            throw new NotImplementedException();
        }

        public Task<PackageType> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PackageType>> GetAll()
        {
            var result = await context.PackageTypes.ToListAsync();
            return result;
        }

        public void Update(PackageType enthity)
        {
            throw new NotImplementedException();
        }
    }
}
