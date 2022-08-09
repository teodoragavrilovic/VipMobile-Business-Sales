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
    public class RepositoryTHOffer: IRepositoryTHOffer
    {
        private readonly VipContext context;

        public RepositoryTHOffer(VipContext context)
        {
            this.context = context;
        }

        public void Add(THOffer enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(THOffer enthity)
        {
            throw new NotImplementedException();
        }

        public Task<THOffer> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<THOffer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(THOffer enthity)
        {
            throw new NotImplementedException();
        }
    }
}
