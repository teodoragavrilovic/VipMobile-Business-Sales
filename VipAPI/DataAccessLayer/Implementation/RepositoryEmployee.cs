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
    public class RepositoryEmployee : IRepositoryEmployee
    {
        private readonly VipContext context;

        public RepositoryEmployee(VipContext context)
        {
            this.context = context;
        }
        public void Add(Employee enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee enthity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAll()
        {
            var result = await context.Employees.ToListAsync();
            return result;
        }

        public void Update(Employee enthity)
        {
            throw new NotImplementedException();
        }
    }
}
