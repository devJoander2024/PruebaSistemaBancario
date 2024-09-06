using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaWaltherOlivoEventos.Context;
using PruebaWaltherOlivoEventos.Dtos;
using PruebaWaltherOlivoEventos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWaltherOlivoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPrestamoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoPrestamoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoPrestamo
        [HttpGet]
        public async Task<ActionResult<GenericResponseDto<IEnumerable<TipoPrestamo>>>> GetAllTipoPrestamos()
        {
            var tipoPrestamos = await _context.TipoPrestamos.ToListAsync();

            if (tipoPrestamos == null || !tipoPrestamos.Any())
            {
                return NotFound(new GenericResponseDto<IEnumerable<TipoPrestamo>>
                {
                    Status = 404,
                    Title = "No loans found",
                    Message = "No loan types found in the system.",
                    Data = null
                });
            }

            return Ok(new GenericResponseDto<IEnumerable<TipoPrestamo>>
            {
                Status = 200,
                Title = "Loan types retrieved successfully",
                Message = $"{tipoPrestamos.Count} loan type(s) found.",
                Data = tipoPrestamos
            });
        }

        // GET: api/TipoPrestamo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenericResponseDto<TipoPrestamo>>> GetTipoPrestamoById(int id)
        {
            var tipoPrestamo = await _context.TipoPrestamos.FindAsync(id);

            if (tipoPrestamo == null)
            {
                return NotFound(new GenericResponseDto<TipoPrestamo>
                {
                    Status = 404,
                    Title = "Loan type not found",
                    Message = $"No loan type found with ID {id}.",
                    Data = null
                });
            }

            return Ok(new GenericResponseDto<TipoPrestamo>
            {
                Status = 200,
                Title = "Loan type retrieved",
                Message = "Loan type found successfully.",
                Data = tipoPrestamo
            });
        }

        // POST: api/TipoPrestamo
        [HttpPost]
        public async Task<ActionResult<GenericResponseDto<TipoPrestamo>>> CreateTipoPrestamo([FromBody] TipoPrestamo tipoPrestamo)
        {
            if (string.IsNullOrEmpty(tipoPrestamo.Descripcion))
            {
                return BadRequest(new GenericResponseDto<string>
                {
                    Status = 400,
                    Title = "Invalid input",
                    Message = "Description is required.",
                    Data = null
                });
            }

            _context.TipoPrestamos.Add(tipoPrestamo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoPrestamoById), new { id = tipoPrestamo.TipoPrestamoId }, new GenericResponseDto<TipoPrestamo>
            {
                Status = 201,
                Title = "Loan type created",
                Message = "Loan type created successfully.",
                Data = tipoPrestamo
            });
        }

        // PUT: api/TipoPrestamo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GenericResponseDto<TipoPrestamo>>> UpdateTipoPrestamo(int id, [FromBody] TipoPrestamo tipoPrestamo)
        {
            var existingTipoPrestamo = await _context.TipoPrestamos.FindAsync(id);

            if (existingTipoPrestamo == null)
            {
                return NotFound(new GenericResponseDto<string>
                {
                    Status = 404,
                    Title = "Loan type not found",
                    Message = $"No loan type found with ID {id}.",
                    Data = null
                });
            }

            if (string.IsNullOrEmpty(tipoPrestamo.Descripcion))
            {
                return BadRequest(new GenericResponseDto<string>
                {
                    Status = 400,
                    Title = "Invalid input",
                    Message = "Description is required.",
                    Data = null
                });
            }

            existingTipoPrestamo.Descripcion = tipoPrestamo.Descripcion;
            existingTipoPrestamo.Estado = tipoPrestamo.Estado;

            _context.Entry(existingTipoPrestamo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new GenericResponseDto<TipoPrestamo>
            {
                Status = 200,
                Title = "Loan type updated",
                Message = "Loan type updated successfully.",
                Data = existingTipoPrestamo
            });
        }

        // DELETE: api/TipoPrestamo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericResponseDto<string>>> DeleteTipoPrestamo(int id)
        {
            var tipoPrestamo = await _context.TipoPrestamos.FindAsync(id);

            if (tipoPrestamo == null)
            {
                return NotFound(new GenericResponseDto<string>
                {
                    Status = 404,
                    Title = "Loan type not found",
                    Message = $"No loan type found with ID {id}.",
                    Data = null
                });
            }

            _context.TipoPrestamos.Remove(tipoPrestamo);
            await _context.SaveChangesAsync();

            return Ok(new GenericResponseDto<string>
            {
                Status = 200,
                Title = "Loan type deleted",
                Message = $"Loan type with ID {id} was deleted successfully.",
                Data = "Loan type deleted"
            });
        }
    }
}
