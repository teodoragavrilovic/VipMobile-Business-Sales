using DataAccessLayer.Implementation;
using DataAccessLayer.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly VipContext context;

        public UnitOfWork(VipContext context)
        {
            this.context = context;
            ClientRepository = new RepositoryClient(context);
            EmployeeRepository = new RepositoryEmployee(context);
            OfferItemRepository = new RepositoryOfferItem(context);
            PackageTypeRepository = new RepositoryPackageType(context); 
            ServiceTypeRepository = new RepositoryServiceType(context); 
            TariffPackageRepository = new RepositoryTariffPackage(context); 
            THOfferRepository = new RepositoryTHOffer(context); 
            THServiceRepository = new RepositoryTHService(context); 
            THServiceRequestRepository = new RepositoryTHServiceRequest(context);   
        }
        public IRepositoryClient ClientRepository { get; set; }
        public IRepositoryEmployee EmployeeRepository { get; set; }
        public IRepositoryOfferItem OfferItemRepository { get; set; }
        public IRepositoryPackageType PackageTypeRepository { get; set; }
        public IRepositoryServiceType ServiceTypeRepository { get; set; }
        public IRepositoryTariffPackage TariffPackageRepository { get; set; }
        public IRepositoryTHOffer THOfferRepository { get; set; }
        public IRepositoryTHService THServiceRepository { get; set; }
        public IRepositoryTHServiceRequest THServiceRequestRepository { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
