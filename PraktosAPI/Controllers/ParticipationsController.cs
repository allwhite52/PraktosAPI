using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraktosAPI.Models;

namespace PraktosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipationsController : ControllerBase
    {
        private readonly SpirtContext _context;

        public ParticipationsController(SpirtContext context)
        {
            _context = context;
        }

        // GET: api/Participations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetParticipations()
        {
            var participations = await _context.Participations
                .Include(p => p.Sport)           // Подключение таблицы Sport
                .Include(p => p.Athlete)         // Подключение таблицы Athlete
                .Include(p => p.Competition)     // Подключение таблицы Competition
                .Select(p => new
                {
                    p.ParticipationsId,
                    SportName = p.Sport.SportName, // Имя вида спорта
                    LastName = p.Athlete.LastName, // Фамилия спортсмена
                    CompetitionName = p.Competition.CompetitionName, // Название соревнования
                    SportLocation = p.Competition.SportLocation,
                    p.Result,
                    p.Place
                })
                .ToListAsync();

            return Ok(participations);
        }

        // GET: api/Participations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetParticipation(int id)
        {
            var participation = await _context.Participations
                .Include(p => p.Sport)
                .Include(p => p.Athlete)
                .Include(p => p.Competition)
                .Select(p => new
                {
                    p.ParticipationsId,
                    SportName = p.Sport.SportName,
                    LastName = p.Athlete.LastName,
                    CompetitionName = p.Competition.CompetitionName,
                    SportLocation = p.Competition.SportLocation,
                    p.Result,
                    p.Place
                })
                .FirstOrDefaultAsync(p => p.ParticipationsId == id);

            if (participation == null)
            {
                return NotFound();
            }

            return Ok(participation);
        }
        // PUT: api/Participations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipation(int id, Participation participation)
        {
            if (id != participation.ParticipationsId)
            {
                return BadRequest();
            }

            _context.Entry(participation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipationExists(id))
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

        // POST: api/Participations
        [HttpPost]
        public async Task<ActionResult<Participation>> PostParticipation(Participation participation)
        {
            _context.Participations.Add(participation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipation", new { id = participation.ParticipationsId }, participation);
        }

        // DELETE: api/Participations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipation(int id)
        {
            var participation = await _context.Participations.FindAsync(id);
            if (participation == null)
            {
                return NotFound();
            }

            _context.Participations.Remove(participation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipationExists(int id)
        {
            return _context.Participations.Any(e => e.ParticipationsId == id);
        }
    }
}