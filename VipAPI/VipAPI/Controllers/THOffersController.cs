using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DataTransferObject;
using Model.Domain;

namespace VipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class THOffersController : ControllerBase
    {
        private readonly VipContext _context;
        private readonly IUnitOfWork unitOfWork;
        private IMapper mapper;

        public THOffersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }


       //GET: api/THOffers
       [HttpGet]
       [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<THOfferDTO>>>GetTHOffers()
        {
            var THOffers = await unitOfWork.THOfferRepository.GetAll();
            var thOfferDTOs = mapper.Map<List<THOfferDTO>>(THOffers);

            return Ok(thOfferDTOs);
        }

       

        // PUT: api/THOffers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void PutTHOffer(THOfferDTO tHOfferDTO)
        {
            THOffer entity = new THOffer();
            entity.THOfferId = tHOfferDTO.THOfferId;
            entity.OfferDate = tHOfferDTO.OfferDate;
            entity.ConfirmationDeadline = tHOfferDTO.ConfirmationDeadline;
            entity.EmployeeId = tHOfferDTO.EmployeeId;
            entity.THServiceRequestId = tHOfferDTO.THServiceRequestId;
            entity.OfferItems = new List<OfferItem>();
            foreach (var item in tHOfferDTO.OfferItems)
            {
                OfferItem offerItem = new OfferItem();
                offerItem.OfferItemId = item.OfferItemId;
                offerItem.ActivationDate = item.ActivationDate;
                offerItem.THServiceId = item.THServiceId;

                entity.OfferItems.Add(offerItem);
            }



            unitOfWork.THOfferRepository.Update(entity);
            unitOfWork.Commit();
        }

        // POST: api/THOffers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void PostTHOffer(THOfferDTO tHOfferDTO)
        {

            THOffer entity = new THOffer();
           // entity.THOfferId = tHOfferDTO.THOfferId;
            entity.OfferDate = tHOfferDTO.OfferDate;
            entity.ConfirmationDeadline = tHOfferDTO.ConfirmationDeadline;
            entity.EmployeeId = tHOfferDTO.EmployeeId;
            entity.THServiceRequestId = tHOfferDTO.THServiceRequestId;
            entity.OfferItems = new List<OfferItem>();
            foreach (var item in tHOfferDTO.OfferItems)
            {
                OfferItem offerItem = new OfferItem();
               // offerItem.OfferItemId = item.OfferItemId;
                offerItem.ActivationDate = item.ActivationDate;
                offerItem.THServiceId = item.THServiceId;

                entity.OfferItems.Add(offerItem);
            }


            // entity = mapper.Map<THOffer>(tHOfferDTO);

            unitOfWork.THOfferRepository.Add(entity);
            unitOfWork.Commit();
        }

        // DELETE: api/THOffers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.THOfferRepository.Delete(new THOffer { THOfferId = id });
            unitOfWork.Commit();
        }

        private bool THOfferExists(int id)
        {
            return (_context.THOffers?.Any(e => e.THOfferId == id)).GetValueOrDefault();
        }
    }
}
