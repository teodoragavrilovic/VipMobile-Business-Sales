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
    public class RepositoryTHOffer : IRepositoryTHOffer
    {
        private readonly VipContext context;

        public RepositoryTHOffer(VipContext context)
        {
            this.context = context;
        }

        public void Add(THOffer entity)
        {
       
            try
            {

                context.THOffers.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(THOffer enthity)
        {
            context.Remove(enthity);
        }

        public Task<THOffer> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<THOffer>> GetAll()
        {
            var result = await context.THOffers.Include(e => e.OfferItems).ToListAsync();
            foreach (var offer in result)
            {
                offer.Employee = context.Employees.Find(offer.EmployeeId);
                offer.THServiceRequest = context.THServiceRequests.Find(offer.THServiceRequestId);
                offer.THServiceRequest.Client = context.Clients.Find(offer.THServiceRequest.ClientId);
                offer.THServiceRequest.Employee = context.Employees.Find(offer.THServiceRequest.EmployeeId);
              
                foreach (var item in offer.OfferItems)
                {
                    item.THService = context.THServices.Find(item.THServiceId);
                    item.THService.ServiceType = context.ServiceTypes.Find(item.THService.ServiceTypeId);
                }
            }
            return result;


        }

        public int GetIndex(int id, List<OfferItem> list)
        {
            if (list == null || list.Count == 0)
            {
                return -1;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].OfferItemId == id)
                {
                    return i;
                }
            }
            return -1;
        }


        public void Update(THOffer entity)
        {
            var thOfferFromDb = context.THOffers.Include(e => e.Employee).Include(th => th.THServiceRequest).Include(of => of.OfferItems).ThenInclude(s => s.THService).FirstOrDefault(e => e.THOfferId == entity.THOfferId);
            //VipContext context1 = new VipContext();
            ////List<OfferItem> list = context.THOffers.Where(e => e.THOfferId == entity.THOfferId).FirstOrDefault().OfferItems;
            List<OfferItem> list = thOfferFromDb.OfferItems;

            foreach (var item in list)
            {
                bool delete = true;
                foreach (var i in entity.OfferItems)
                {
                    if (item.OfferItemId == i.OfferItemId)
                    {
                        delete = false;
                    }


                }
                if (delete)
                {
                    context.Entry(item).State = EntityState.Deleted;
                }
            }

            context.SaveChanges();

            thOfferFromDb.Employee = context.Employees.Find(entity.EmployeeId);
            thOfferFromDb.THServiceRequest = context.THServiceRequests.Find(entity.THServiceRequestId);
            thOfferFromDb.ConfirmationDeadline = entity.ConfirmationDeadline;
            thOfferFromDb.OfferDate = entity.OfferDate;

            foreach (var item in entity.OfferItems)
            {
                item.THService = context.THServices.Find(item.THServiceId);

                bool contains = false;
               
                foreach (var offerItem in list)
                {
                    if (offerItem.OfferItemId == item.OfferItemId)
                    {
                        contains = true;
                    }

                }
                if (!contains)
                {
                    thOfferFromDb.OfferItems.Add(item);
                }
                else
                {
                    int id = GetIndex(item.OfferItemId, thOfferFromDb.OfferItems);
                    thOfferFromDb.OfferItems[id] = item;
                }

            }
            context.Update(thOfferFromDb);
            context.SaveChanges();
        }
    }
}
