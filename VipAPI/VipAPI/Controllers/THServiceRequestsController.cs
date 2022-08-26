using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Domain;

namespace VipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class THServiceRequestsController : ControllerBase
    {
        private readonly VipContext _context;

        public THServiceRequestsController(VipContext context)
        {
            _context = context;
        }

        // GET: api/THServiceRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<THServiceRequest>>> GetTHServiceRequests()
        {
          if (_context.THServiceRequests == null)
          {
              return NotFound();
          }
            return await _context.THServiceRequests.ToListAsync();
        }

        // GET: api/THServiceRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<THServiceRequest>> GetTHServiceRequest(int id)
        {
          if (_context.THServiceRequests == null)
          {
              return NotFound();
          }
            var tHServiceRequest = await _context.THServiceRequests.FindAsync(id);

            if (tHServiceRequest == null)
            {
                return NotFound();
            }

            return tHServiceRequest;
        }

        // PUT: api/THServiceRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTHServiceRequest(int id, THServiceRequest tHServiceRequest)
        {
            if (id != tHServiceRequest.THServiceRequestId)
            {
                return BadRequest();
            }

            _context.Entry(tHServiceRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!THServiceRequestExists(id))
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

        // POST: api/THServiceRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<THServiceRequest>> PostTHServiceRequest(THServiceRequest tHServiceRequest)
        {
          if (_context.THServiceRequests == null)
          {
              return Problem("Entity set 'VipContext.THServiceRequests'  is null.");
          }
            _context.THServiceRequests.Add(tHServiceRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTHServiceRequest", new { id = tHServiceRequest.THServiceRequestId }, tHServiceRequest);
        }

        // DELETE: api/THServiceRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTHServiceRequest(int id)
        {
            if (_context.THServiceRequests == null)
            {
                return NotFound();
            }
            var tHServiceRequest = await _context.THServiceRequests.FindAsync(id);
            if (tHServiceRequest == null)
            {
                return NotFound();
            }

            _context.THServiceRequests.Remove(tHServiceRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool THServiceRequestExists(int id)
        {
            return (_context.THServiceRequests?.Any(e => e.THServiceRequestId == id)).GetValueOrDefault();
        }
    }
}
