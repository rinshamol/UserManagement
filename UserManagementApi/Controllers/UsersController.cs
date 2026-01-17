using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;
using UserManagementApi.Dtos;
using UserManagementApi.Mapping;
using UserManagementApi.Models;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAll()
        {
            var users = await _db.Users
                .AsNoTracking()
                .OrderByDescending(u => u.CreatedAtUtc)
                .Select(u => u.ToResponseDto())
                .ToListAsync();

            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserResponseDto>> GetById(Guid id)
        {
            var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if (user is null) return NotFound(new { message = "User not found." });

            return Ok(user.ToResponseDto());
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Create([FromBody] UserCreateDto dto)
        {
            // Model validation happens automatically because of [ApiController].
            // Extra validation: unique email
            var email = dto.Email.Trim().ToLowerInvariant();
            var exists = await _db.Users.AnyAsync(u => u.Email == email);
            if (exists) return Conflict(new { message = "Email already exists." });

            var user = dto.ToEntity();
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user.ToResponseDto());
        }

        // PUT: api/users/{id}
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UserResponseDto>> Update(Guid id, [FromBody] UserUpdateDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null) return NotFound(new { message = "User not found." });

            var email = dto.Email.Trim().ToLowerInvariant();

            var emailTakenByAnother = await _db.Users
                .AnyAsync(u => u.Email == email && u.Id != id);

            if (emailTakenByAnother)
                return Conflict(new { message = "Email already exists." });

            user.ApplyUpdate(dto);
            await _db.SaveChangesAsync();

            return Ok(user.ToResponseDto());
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null) return NotFound(new { message = "User not found." });

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
