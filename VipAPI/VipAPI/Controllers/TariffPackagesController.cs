using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.UnitOfWork;
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
    public class TariffPackagesController : ControllerBase
    {
        private readonly VipContext _context;
        private readonly IUnitOfWork unitOfWork;
        private IMapper mapper;

        public TariffPackagesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        // GET: api/TariffPackages
        [HttpGet]
        public async Task<ActionResult<List<TariffPackageDTO>>>GetTariffPackages()
        {
            var TariffPackages = await unitOfWork.TariffPackageRepository.GetAll();
            var tariffPackageDTOs = mapper.Map<List<TariffPackageDTO>>(TariffPackages);

            return Ok(tariffPackageDTOs);
        }

        // GET: api/TariffPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TariffPackage>> GetTariffPackage(int id)
        {
          if (_context.TariffPackages == null)
          {
              return NotFound();
          }
            var tariffPackage = await _context.TariffPackages.FindAsync(id);

            if (tariffPackage == null)
            {
                return NotFound();
            }

            return tariffPackage;
        }

        // PUT: api/TariffPackages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTariffPackage(int id, TariffPackage tariffPackage)
        {
            if (id != tariffPackage.TariffPackageId)
            {
                return BadRequest();
            }

            _context.Entry(tariffPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TariffPackageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPut]
        public void Put([FromBody] TariffPackageDTO tariffPackage)
        {
             TariffPackage tp = new TariffPackage
            {
                TariffPackageId = tariffPackage.TariffPackageId,
                TariffPackageName = tariffPackage.TariffPackageName,
                AvlbMinutes = tariffPackage.AvlbMinutes,
                AvlbSMS = tariffPackage.AvlbSMS,
                AvlbMB = tariffPackage.AvlbMB,
                Price = tariffPackage.Price,
                PackageType = new PackageType
                { PackageTypeId = tariffPackage.PackageType.PackageTypeId,
                  TypeName = tariffPackage.PackageType.TypeName }

            };

            unitOfWork.TariffPackageRepository.Update(tp);
            unitOfWork.Commit();
        }
        // POST: api/TariffPackages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /* [HttpPost]
         public async Task<ActionResult<TariffPackage>> PostTariffPackage(TariffPackage tariffPackage)
         {
           if (_context.TariffPackages == null)
           {
               return Problem("Entity set 'VipContext.TariffPackages'  is null.");
           }
             _context.TariffPackages.Add(tariffPackage);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetTariffPackage", new { id = tariffPackage.TariffPackageId }, tariffPackage);
         }*/
        [HttpPost]
        public void PostTariffPackage(TariffPackageDTO tariffPackage)
        {
            TariffPackage tp = new TariffPackage
            {
                TariffPackageId = tariffPackage.TariffPackageId,
                TariffPackageName = tariffPackage.TariffPackageName,
                AvlbMinutes = tariffPackage.AvlbMinutes,
                AvlbSMS = tariffPackage.AvlbSMS,
                AvlbMB = tariffPackage.AvlbMB,
                Price = tariffPackage.Price,
                PackageType = new PackageType 
                { PackageTypeId = tariffPackage.PackageType.PackageTypeId, 
                  TypeName = tariffPackage.PackageType.TypeName }

            };

            unitOfWork.TariffPackageRepository.Add(tp);
            unitOfWork.Commit();
        }

        // DELETE: api/TariffPackages/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.TariffPackageRepository.Delete(new TariffPackage { TariffPackageId = id });
            unitOfWork.Commit();
        }
        /*public async Task<IActionResult> DeleteTariffPackage(int id)
        {
            if (_context.TariffPackages == null)
            {
                return NotFound();
            }
            var tariffPackage = await _context.TariffPackages.FindAsync(id);
            if (tariffPackage == null)
            {
                return NotFound();
            }

            _context.TariffPackages.Remove(tariffPackage);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool TariffPackageExists(int id)
        {
            return (_context.TariffPackages?.Any(e => e.TariffPackageId == id)).GetValueOrDefault();
        }
    }
}
