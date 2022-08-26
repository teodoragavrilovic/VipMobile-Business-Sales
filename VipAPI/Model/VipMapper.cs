using AutoMapper;
using Model.DataTransferObject;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VipMapper: Profile
    {

        public VipMapper()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<TariffPackage, TariffPackageDTO>();
            CreateMap<PackageType, PackageTypeDTO>();
            CreateMap<TariffPackage, TariffPackageDTO>().ForMember(dest => dest.PackageType, opt => opt.MapFrom(MapTariffPackagePackageType)).ReverseMap();
            CreateMap<THService, THServiceDTO>();
            CreateMap<ServiceType, ServiceTypeDTO>();
            CreateMap<THServiceRequest, THServiceRequestDTO>().ReverseMap();
            CreateMap<THOffer, THOfferDTO>().ReverseMap();
            CreateMap<OfferItem, OfferItemDTO>().ForMember(dest => dest.THService, opt => opt.MapFrom(MapOfferItemTHService)).ReverseMap();
            CreateMap<THService, THServiceDTO>().ForMember(dest => dest.ServiceType, opt => opt.MapFrom(MapTHServiceServiceType)).ReverseMap();
            CreateMap<THOffer, THOfferDTO>().ForMember(dest => dest.Employee, opt => opt.MapFrom(MapTHOfferEmployee)).ReverseMap();
            CreateMap<THOffer, THOfferDTO>().ForMember(dest => dest.THServiceRequest, opt => opt.MapFrom(MapTHOfferTHServiceRequest)).ReverseMap();
            CreateMap<THOffer, THOfferDTO>().ForMember(dest => dest.OfferItems, opt => opt.MapFrom(MapTHOfferOfferItems)).ReverseMap();

           
        }

        private List<OfferItemDTO> MapTHOfferOfferItems(THOffer tHOffer, THOfferDTO tHOfferDTO)
        {
            var result = new List<OfferItemDTO>();
            if (tHOffer.OfferItems != null)
            {
                foreach(var item in tHOffer.OfferItems)
                {
                    result.Add(new OfferItemDTO
                    {
                        OfferItemId = item.OfferItemId,
                        ActivationDate = item.ActivationDate,
                        //THOfferId = item.THOfferId,
                        THServiceId = item.THServiceId,
                        THService = new THServiceDTO
                        {
                            THServiceId = item.THServiceId,
                            ServiceName = item.THService.ServiceName,
                            ServicePrice = item.THService.ServicePrice,
                            ServiceTypeId = item.THService.ServiceTypeId,
                            ServiceType = new ServiceTypeDTO
                            {
                                ServiceTypeId = item.THService.ServiceType.ServiceTypeId,
                                ServiceTypeName = item.THService.ServiceType.ServiceTypeName,
                                Description = item.THService.ServiceType.Description
                            }
                        }
                    });
                }
           
            }
            return result;
        }

        private THServiceRequestDTO MapTHOfferTHServiceRequest(THOffer tHOffer, THOfferDTO tHOfferDTO)
        {
            THServiceRequestDTO result = null;
            if(tHOffer.THServiceRequest != null)
            {
                result = new THServiceRequestDTO
                {
                    THServiceRequestId = tHOffer.THServiceRequestId,
                    RequestDate = tHOffer.THServiceRequest.RequestDate,
                    Approved = tHOffer.THServiceRequest.Approved,
                    EmployeeId = tHOffer.THServiceRequest.EmployeeId,
                    Employee = new EmployeeDTO 
                    { 
                        EmployeeId = tHOffer.THServiceRequest.EmployeeId,
                        DateOfBirth = tHOffer.THServiceRequest.Employee.DateOfBirth,
                        Name = tHOffer.THServiceRequest.Employee.Name,
                        Surname = tHOffer.THServiceRequest.Employee.Surname
                    },
                    ClientId = tHOffer.THServiceRequest.ClientId,
                    Client = new ClientDTO
                    { 
                        ClientId = tHOffer.THServiceRequest.ClientId,
                        PIB = tHOffer.THServiceRequest.Client.PIB,
                        ClientName = tHOffer.THServiceRequest.Client.ClientName,
                        Email = tHOffer.THServiceRequest.Client.Email,
                        WebPage = tHOffer.THServiceRequest.Client.WebPage,
                        YearOfFaundation = tHOffer.THServiceRequest.Client.YearOfFaundation,
                        PhoneNumber = tHOffer.THServiceRequest.Client.PhoneNumber
                    }
                };
            }
            return result;
        }

        private EmployeeDTO MapTHOfferEmployee(THOffer tHOffer, THOfferDTO tHOfferDTO)
        {
            EmployeeDTO result = null;
            if (tHOffer.Employee != null)
            {
                result = new EmployeeDTO
                {
                    EmployeeId = tHOffer.Employee.EmployeeId,
                    Name = tHOffer.Employee.Name,
                    Surname = tHOffer.Employee.Surname,
                    DateOfBirth = tHOffer.Employee.DateOfBirth
                };
            }
            return result;
        }

        private PackageTypeDTO MapTariffPackagePackageType(TariffPackage tariffPackage, TariffPackageDTO tariffPackageDTO)
        {
            PackageTypeDTO result = null;
            if (tariffPackage.PackageType != null)
            {
                result = new PackageTypeDTO
                {
                    PackageTypeId = tariffPackage.PackageType.PackageTypeId,
                    TypeName = tariffPackage.PackageType.TypeName
                };
            }
            return result;
        }

        private ServiceTypeDTO MapTHServiceServiceType(THService tHService, THServiceDTO tHServiceDTO)
        {
            ServiceTypeDTO result = null;
            if (tHService.ServiceType != null)
            {
                result = new ServiceTypeDTO
                {
                    ServiceTypeId = tHService.ServiceType.ServiceTypeId,
                    ServiceTypeName = tHService.ServiceType.ServiceTypeName
                };
            }
            return result;
        }

        private THServiceDTO MapOfferItemTHService(OfferItem offerItem, OfferItemDTO offerItemDTO)
        {
            THServiceDTO result = null;
            if(offerItem.THService != null)
            {
                result = new THServiceDTO
                {
                    ServiceTypeId = offerItem.THService.ServiceTypeId,
                    ServiceName = offerItem.THService.ServiceName,
                    ServicePrice = offerItem.THService.ServicePrice,
                    ServiceType = new ServiceTypeDTO
                    {
                        ServiceTypeId = offerItem.THService.ServiceTypeId,
                        ServiceTypeName = offerItem.THService.ServiceType.ServiceTypeName,
                        Description = offerItem.THService.ServiceType.Description
                    },
                    THServiceId = offerItem.THServiceId
                };
            }

            return result;
        }
    }
}
