using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        public IRepositoryClient ClientRepository { get; set; }
        public IRepositoryEmployee EmployeeRepository { get; set; }
        public IRepositoryOfferItem OfferItemRepository { get; set; }
        public IRepositoryPackageType PackageTypeRepository { get; set; }
        public IRepositoryServiceType ServiceTypeRepository { get; set; }
        public IRepositoryTariffPackage TariffPackageRepository { get; set; }
        public IRepositoryTHOffer THOfferRepository { get; set; }
        public IRepositoryTHService THServiceRepository { get; set; }
        public IRepositoryTHServiceRequest THServiceRequestRepository { get; set; }

    }
}
