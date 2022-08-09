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

        public Task<List<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee enthity)
        {
            throw new NotImplementedException();
        }
    }
}
