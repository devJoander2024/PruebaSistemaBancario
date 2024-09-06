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
    public class PrestamoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PrestamoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Prestamo
        [HttpGet]
        public async Task<ActionResult<GenericResponseDto<IEnumerable<Prestamo>>>> GetAllPrestamos()
        {
            var prestamos = await _context.Prestamos.Include(p => p.TipoPrestamo).ToListAsync();

            if (prestamos == null || !prestamos.Any())
            {
                return NotFound(new GenericResponseDto<IEnumerable<Prestamo>>
                {
                    Status = 404,
                    Title = "No loans found",
                    Message = "No loans found in the system.",
                    Data = null
                });
            }

            return Ok(new GenericResponseDto<IEnumerable<Prestamo>>
            {
                Status = 200,
                Title = "Loans retrieved successfully",
                Message = $"{prestamos.Count} loan(s) found.",
                Data = prestamos
            });
        }

        // GET: api/Prestamo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenericResponseDto<Prestamo>>> GetPrestamoById(int id)
        {
            var prestamo = await _context.Prestamos.Include(p => p.TipoPrestamo).FirstOrDefaultAsync(p => p.PrestamoId == id);

            if (prestamo == null)
            {
                return NotFound(new GenericResponseDto<Prestamo>
                {
                    Status = 404,
                    Title = "Loan not found",
                    Message = $"No loan found with ID {id}.",
                    Data = null
                });
            }

            return Ok(new GenericResponseDto<Prestamo>
            {
                Status = 200,
                Title = "Loan retrieved",
                Message = "Loan found successfully.",
                Data = prestamo
            });
        }

        // POST: api/Prestamo
        [HttpPost]
        public async Task<ActionResult<GenericResponseDto<Prestamo>>> CreatePrestamo([FromBody] CreatePrestamoDto prestamoDto)
        {
            // Verificar si el TipoPrestamoId proporcionado es válido
            var tipoPrestamo = await _context.TipoPrestamos.FindAsync(prestamoDto.TipoPrestamoId);
            if (tipoPrestamo == null)
            {
                return BadRequest(new GenericResponseDto<string>
                {
                    Status = 400,
                    Title = "Invalid TipoPrestamoId",
                    Message = $"No loan type found with ID {prestamoDto.TipoPrestamoId}.",
                    Data = null
                });
            }

            var prestamo = new Prestamo
            {
                Descripcion = prestamoDto.Descripcion,
                Cantidad = prestamoDto.Cantidad,
                Estado = prestamoDto.Estado,
                TipoPrestamoId = prestamoDto.TipoPrestamoId
            };

            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPrestamoById), new { id = prestamo.PrestamoId }, new GenericResponseDto<Prestamo>
            {
                Status = 201,
                Title = "Loan created",
                Message = "Loan created successfully.",
                Data = prestamo
            });
        }

        // PUT: api/Prestamo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GenericResponseDto<Prestamo>>> UpdatePrestamo(int id, [FromBody] CreatePrestamoDto prestamoDto)
        {
            var existingPrestamo = await _context.Prestamos.FindAsync(id);

            if (existingPrestamo == null)
            {
                return NotFound(new GenericResponseDto<string>
                {
                    Status = 404,
                    Title = "Loan not found",
                    Message = $"No loan found with ID {id}.",
                    Data = null
                });
            }

            var tipoPrestamo = await _context.TipoPrestamos.FindAsync(prestamoDto.TipoPrestamoId);
            if (tipoPrestamo == null)
            {
                return BadRequest(new GenericResponseDto<string>
                {
                    Status = 400,
                    Title = "Invalid TipoPrestamoId",
                    Message = $"No loan type found with ID {prestamoDto.TipoPrestamoId}.",
                    Data = null
                });
            }

            // Actualizar los datos
            existingPrestamo.Descripcion = prestamoDto.Descripcion;
            existingPrestamo.Cantidad = prestamoDto.Cantidad;
            existingPrestamo.Estado = prestamoDto.Estado;
            existingPrestamo.TipoPrestamoId = prestamoDto.TipoPrestamoId;

            _context.Entry(existingPrestamo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new GenericResponseDto<Prestamo>
            {
                Status = 200,
                Title = "Loan updated",
                Message = "Loan updated successfully.",
                Data = existingPrestamo
            });
        }

        // DELETE: api/Prestamo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericResponseDto<string>>> DeletePrestamo(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound(new GenericResponseDto<string>
                {
                    Status = 404,
                    Title = "Loan not found",
                    Message = $"No loan found with ID {id}.",
                    Data = null
                });
            }

            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();

            return Ok(new GenericResponseDto<string>
            {
                Status = 200,
                Title = "Loan deleted",
                Message = $"Loan with ID {id} was deleted successfully.",
                Data = "Loan deleted"
            });
        }
    }
}
