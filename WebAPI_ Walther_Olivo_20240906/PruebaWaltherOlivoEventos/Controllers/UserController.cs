using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaWaltherOlivoEventos.Context;
using PruebaWaltherOlivoEventos.Dtos;
using PruebaWaltherOlivoEventos.Enum;
using PruebaWaltherOlivoEventos.Models;

namespace PruebaWaltherOlivoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<GenericResponseDto<IEnumerable<User>>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            if (users == null || !users.Any())
            {
                var response = new GenericResponseDto<IEnumerable<User>>
                {
                    Status = 200,
                    Title = "No users found",
                    Message = "The request was successful, but no users were found in the system.",
                    Data = null
                };
                return NotFound(response);
            }
            var Users = users.Select(u => new User
            {
                UserId = u.UserId,
                Username = u.Username,
                Email = u.Email,
                Estado = u.Estado,
                Role = u.Role
            });

            var successResponse = new GenericResponseDto<IEnumerable<User>>
            {
                Status = 200,
                Title = "Users retrieved successfully",
                Message = $"{users.Count} user(s) found.",
                Data = Users
            };

            return Ok(successResponse);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenericResponseDto<User>>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new GenericResponseDto<User>
                {
                    Status = 404,
                    Title = "User not found",
                    Message = $"No user found with ID {id}.",
                    Data = null
                });
            }

            var User = new User
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Estado = user.Estado,
                Role = user.Role
            };

            return Ok(new GenericResponseDto<User>
            {
                Status = 200,
                Title = "User retrieved",
                Message = "User found successfully.",
                Data = User
            });
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<GenericResponseDto<User>>> CreateUser([FromBody] User user)
        {
            // Lista de roles permitidos
            var allowedRoles = new List<string> { "Role_Cliente", "Role_Admin" };

            // Si el rol es null o vacío, asignar el rol por defecto
            if (string.IsNullOrEmpty(user.Role))
            {
                user.Role = "Role_Cliente"; // Rol por defecto
            }
            else
            {
                // Validar si el rol proporcionado está en la lista de roles permitidos
                if (!allowedRoles.Contains(user.Role))
                {
                    return BadRequest(new GenericResponseDto<string>
                    {
                        Status = 400,
                        Title = "Invalid Role",
                        Message = "The provided role is not valid.",
                        Data = null
                    });
                }
            }

            // Guardar el usuario en la base de datos
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Respuesta exitosa
            var response = new GenericResponseDto<User>
            {
                Status = 201,
                Title = "User created",
                Message = "User created successfully.",
                Data = user
            };

            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, response);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GenericResponseDto<User>>> UpdateUser(int id, [FromBody] User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound(new GenericResponseDto<string>
                {
                    Status = 404,
                    Title = "User not found",
                    Message = $"No user found with ID {id}.",
                    Data = null
                });
            }

            // Lista de roles permitidos
            var allowedRoles = new List<string> { "Role_Cliente", "Role_Admin" };

            // Validar si el rol proporcionado está en la lista de roles permitidos
            if (!string.IsNullOrEmpty(user.Role) && !allowedRoles.Contains(user.Role))
            {
                return BadRequest(new GenericResponseDto<string>
                {
                    Status = 400,
                    Title = "Invalid Role",
                    Message = "The provided role is not valid.",
                    Data = null
                });
            }

            // Actualizar los campos restantes
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Estado = user.Estado;

            // Si el rol no es null o vacío, actualizar el rol; si no, mantener el rol actual
            if (!string.IsNullOrEmpty(user.Role))
            {
                existingUser.Role = user.Role;
            }

            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Respuesta exitosa
            var response = new GenericResponseDto<User>
            {
                Status = 200,
                Title = "User updated",
                Message = "User updated successfully.",
                Data = existingUser
            };

            return Ok(response);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericResponseDto<string>>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new GenericResponseDto<string>
                {
                    Status = 404,
                    Title = "User not found",
                    Message = $"No user found with ID {id}.",
                    Data = null
                });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new GenericResponseDto<string>
            {
                Status = 200,
                Title = "User deleted",
                Message = $"User with ID {id} was deleted successfully.",
                Data = "User deleted"
            });
        }

        [HttpPost("Login")]
        public async Task<ActionResult<GenericResponseDto<string>>> Login([FromBody] LoginDto loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.UsernameOrEmail) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest(new GenericResponseDto<string>
                {
                    Status = 400,
                    Title = "Invalid Input",
                    Message = "Username or email and password are required.",
                    Data = null
                });
            }

            var user = await _context.Users
                .Where(u => (u.Username == loginDto.UsernameOrEmail || u.Email == loginDto.UsernameOrEmail) && u.Password == loginDto.Password)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return BadRequest(new GenericResponseDto<string>
                {
                    Status = 400,
                    Title = "Login failed",
                    Message = "Username or email and password do not match.",
                    Data = null
                });
            }

            return Ok(new GenericResponseDto<string>
            {
                Status = 200,
                Title = "Login successful",
                Message = "User logged in successfully.",
                Data = "Login successful"
            });
        }

    }
}
