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
    public class RepositoryOfferItem : IRepositoryOfferItem
    {
        private readonly VipContext context;

        public RepositoryOfferItem(VipContext context)
        {
            this.context = context;
        }
        public void Add(OfferItem enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(OfferItem enthity)
        {
            throw new NotImplementedException();
        }

        public Task<OfferItem> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OfferItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(OfferItem enthity)
        {
            throw new NotImplementedException();
        }
    }
}
