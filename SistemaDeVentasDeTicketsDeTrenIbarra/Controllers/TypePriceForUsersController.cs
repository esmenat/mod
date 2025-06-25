using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaTickets.Modelos;


namespace SistemaDeVentasDeTicketsDeTrenIbarra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePriceForUsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TypePriceForUsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TypePriceForUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypePriceForUser>>> GetTypePriceForUser()
        {
            return await _context.TypePriceForUser.ToListAsync();
        }

        // GET: api/TypePriceForUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypePriceForUser>> GetTypePriceForUser(int id)
        {
            var typePriceForUser = await _context.TypePriceForUser.FindAsync(id);

            if (typePriceForUser == null)
            {
                return NotFound();
            }

            return typePriceForUser;
        }

        // PUT: api/TypePriceForUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypePriceForUser(int id, TypePriceForUser typePriceForUser)
        {
            if (id != typePriceForUser.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(typePriceForUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePriceForUserExists(id))
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

        // POST: api/TypePriceForUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypePriceForUser>> PostTypePriceForUser(TypePriceForUser typePriceForUser)
        {
            _context.TypePriceForUser.Add(typePriceForUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypePriceForUser", new { id = typePriceForUser.Codigo }, typePriceForUser);
        }

        // DELETE: api/TypePriceForUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypePriceForUser(int id)
        {
            var typePriceForUser = await _context.TypePriceForUser.FindAsync(id);
            if (typePriceForUser == null)
            {
                return NotFound();
            }

            _context.TypePriceForUser.Remove(typePriceForUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypePriceForUserExists(int id)
        {
            return _context.TypePriceForUser.Any(e => e.Codigo == id);
        }
    }
}
