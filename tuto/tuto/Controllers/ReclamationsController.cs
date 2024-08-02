using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tuto.Data;
using tuto.Models;

namespace tuto.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReclamationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reclamation>>> GetReclamations()
        {
            return await _context.Reclamations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reclamation>> GetReclamation(int id)
        {
            var reclamation = await _context.Reclamations.FindAsync(id);

            if (reclamation == null)
            {
                return NotFound();
            }

            return reclamation;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Reclamation>> PutReclamation(int id, Reclamation reclamation)
        {
            if (id != reclamation.Id)
            {
                return BadRequest();
            }

            _context.Entry(reclamation).State = EntityState.Modified;
            await _context.SaveChangesAsync();


            return reclamation;
        }

        [HttpPost]
        public async Task<ActionResult<Reclamation>> PostReclamation(Reclamation reclamation)
        {
            _context.Reclamations.Add(reclamation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReclamation", new { id = reclamation.Id }, reclamation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteReclamation(int id)
        {
            var reclamation = await _context.Reclamations.FindAsync(id);
            if (reclamation == null)
            {
                return NotFound();
            }

            _context.Reclamations.Remove(reclamation);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}