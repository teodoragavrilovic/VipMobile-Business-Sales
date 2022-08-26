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
    public class THServicesController : ControllerBase
    {
        private readonly VipContext _context;
        private readonly IUnitOfWork unitOfWork;
        private IMapper mapper;

        public THServicesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET: api/THServices
        [HttpGet]
        public async Task<ActionResult<List<THServiceDTO>>> GetTHServices()
        {
            var THServices = await unitOfWork.THServiceRepository.GetAll();
            var tHServiceDTOs = mapper.Map<List<THServiceDTO>>(THServices);

            return Ok(tHServiceDTOs);
        }

        // GET: api/THServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<THService>> GetTHService(int id)
        {
          if (_context.THServices == null)
          {
              return NotFound();
          }
            var tHService = await _context.THServices.FindAsync(id);

            if (tHService == null)
            {
                return NotFound();
            }

            return tHService;
        }

        // PUT: api/THServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTHService(int id, THService tHService)
        {
            if (id != tHService.THServiceId)
            {
                return BadRequest();
            }

            _context.Entry(tHService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!THServiceExists(id))
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

        // POST: api/THServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<THService>> PostTHService(THService tHService)
        {
          if (_context.THServices == null)
          {
              return Problem("Entity set 'VipContext.THServices'  is null.");
          }
            _context.THServices.Add(tHService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTHService", new { id = tHService.THServiceId }, tHService);
        }

        // DELETE: api/THServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTHService(int id)
        {
            if (_context.THServices == null)
            {
                return NotFound();
            }
            var tHService = await _context.THServices.FindAsync(id);
            if (tHService == null)
            {
                return NotFound();
            }

            _context.THServices.Remove(tHService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool THServiceExists(int id)
        {
            return (_context.THServices?.Any(e => e.THServiceId == id)).GetValueOrDefault();
        }
    }
}
