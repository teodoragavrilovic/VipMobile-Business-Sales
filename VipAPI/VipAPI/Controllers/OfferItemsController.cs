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
using Model.Domain;

namespace VipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferItemsController : ControllerBase
    {
        private readonly VipContext _context;
        private readonly IUnitOfWork unitOfWork;
        private IMapper mapper;

        public OfferItemsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        // GET: api/OfferItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferItem>>> GetOfferItems()
        {
          if (_context.OfferItems == null)
          {
              return NotFound();
          }
            return await _context.OfferItems.ToListAsync();
        }

        // GET: api/OfferItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferItem>> GetOfferItem(int id)
        {
          if (_context.OfferItems == null)
          {
              return NotFound();
          }
            var offerItem = await _context.OfferItems.FindAsync(id);

            if (offerItem == null)
            {
                return NotFound();
            }

            return offerItem;
        }

        // PUT: api/OfferItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferItem(int id, OfferItem offerItem)
        {
            if (id != offerItem.OfferItemId)
            {
                return BadRequest();
            }

            _context.Entry(offerItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferItemExists(id))
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

        // POST: api/OfferItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfferItem>> PostOfferItem(OfferItem offerItem)
        {
          if (_context.OfferItems == null)
          {
              return Problem("Entity set 'VipContext.OfferItems'  is null.");
          }
            _context.OfferItems.Add(offerItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OfferItemExists(offerItem.OfferItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOfferItem", new { id = offerItem.OfferItemId }, offerItem);
        }

        // DELETE: api/OfferItems/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.OfferItemRepository.Delete(new OfferItem { OfferItemId = id });
            unitOfWork.Commit();
        }

        private bool OfferItemExists(int id)
        {
            return (_context.OfferItems?.Any(e => e.OfferItemId == id)).GetValueOrDefault();
        }
    }
}
