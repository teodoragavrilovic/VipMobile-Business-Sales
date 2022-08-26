﻿using System;
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
    public class PackageTypesController : ControllerBase
    {
        private readonly VipContext _context;
        private readonly IUnitOfWork unitOfWork;
        private IMapper mapper;

        public PackageTypesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        // GET: api/PackageTypes
        [HttpGet]
        public async Task<ActionResult<List<PackageTypeDTO>>> GetPackageTypes()
        {
            var PackageTypes = await unitOfWork.PackageTypeRepository.GetAll();
            var packageTypeDTOs = mapper.Map<List<PackageTypeDTO>>(PackageTypes);

            return Ok(packageTypeDTOs);
        }

        // GET: api/PackageTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageType>> GetPackageType(int id)
        {
          if (_context.PackageTypes == null)
          {
              return NotFound();
          }
            var packageType = await _context.PackageTypes.FindAsync(id);

            if (packageType == null)
            {
                return NotFound();
            }

            return packageType;
        }

        // PUT: api/PackageTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackageType(int id, PackageType packageType)
        {
            if (id != packageType.PackageTypeId)
            {
                return BadRequest();
            }

            _context.Entry(packageType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageTypeExists(id))
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

        // POST: api/PackageTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PackageType>> PostPackageType(PackageType packageType)
        {
          if (_context.PackageTypes == null)
          {
              return Problem("Entity set 'VipContext.PackageTypes'  is null.");
          }
            _context.PackageTypes.Add(packageType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackageType", new { id = packageType.PackageTypeId }, packageType);
        }

        // DELETE: api/PackageTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageType(int id)
        {
            if (_context.PackageTypes == null)
            {
                return NotFound();
            }
            var packageType = await _context.PackageTypes.FindAsync(id);
            if (packageType == null)
            {
                return NotFound();
            }

            _context.PackageTypes.Remove(packageType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageTypeExists(int id)
        {
            return (_context.PackageTypes?.Any(e => e.PackageTypeId == id)).GetValueOrDefault();
        }
    }
}
