using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameSetWebApi.Models;
using GameSetWebApi.Models.DTOs;

namespace GameSetWebApi.Controllers
{
    [Route("api/GameSet")]
    [ApiController]
    public class GameSetController : ControllerBase
    {
        private readonly GameSetContext _context;

        public GameSetController(GameSetContext context)
        {
            _context = context;
        }

        #region "Person API Actions
        // GET: api/GameSet
        [HttpGet("GetPeople")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
          if (_context.person == null)
          {
              return NotFound();
          }
            return await _context.person.ToListAsync();
        }

        // GET: api/GameSet/5
        [HttpGet("GetPerson/{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            if (_context.person == null)
            {
                return NotFound();
            }

            var person = await _context.person
                .Include(p => p.TeamPerson)
                .ThenInclude(tp => tp.Team)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        #region "DTO test"
        // GET: api/GameSet/5
        [HttpGet("GetPersonDTO/{id}")]
        public async Task<ActionResult<PersonDTO>> GetPersonDTO(int id)
        {
            if (_context.person == null)
            {
                return NotFound();
            }

            var person = await _context.person
                .Include(p => p.TeamPerson)
                .ThenInclude(tp => tp.Team)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            var personDto = ConvertToDTO(person);

            return personDto;
        }


        private PersonDTO ConvertToDTO(Person person)
        {
            var dto = new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Birthday = person.Birthday,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                Teams = person.TeamPerson.Select(tp => new TeamDTO
                {
                    TeamId = tp.Team.TeamId,
                    TeamName = tp.Team.Name
                }).ToList()
            };

            return dto;
        }
        #endregion

        // PUT: api/GameSet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutPerson/{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/GameSet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreatePerson")]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
          if (_context.person == null)
          {
              return Problem("Entity set 'GameSetContext.person'  is null.");
          }
            _context.person.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/GameSet/5
        [HttpDelete("DeletePerson/{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (_context.person == null)
            {
                return NotFound();
            }
            var person = await _context.person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.person.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return (_context.person?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion

        #region "Team API Actions
        // GET: api/GameSet
        [HttpGet("GetTeams")]
        public async Task<ActionResult<IEnumerable<Team>>> Getteam()
        {
            if (_context.team == null)
            {
                return NotFound();
            }
            return await _context.team.ToListAsync();
        }

        // GET: api/GameSet/5
        [HttpGet("GetTeam/{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            if (_context.team == null)
            {
                return NotFound();
            }
            var team = await _context.team
                .Include(t => t.TeamPerson)
                .ThenInclude(tp => tp.Team)
                .FirstOrDefaultAsync(t => t.TeamId == id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: api/GameSet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutTeam/{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.TeamId)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/GameSet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateTeam")]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            if (_context.team == null)
            {
                return Problem("Entity set 'GameSetContext.team'  is null.");
            }
            _context.team.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.TeamId }, team);
        }

        // DELETE: api/GameSet/5
        [HttpDelete("DeleteTeam/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (_context.team == null)
            {
                return NotFound();
            }
            var team = await _context.team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.team.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return (_context.team?.Any(e => e.TeamId == id)).GetValueOrDefault();
        }


        #endregion
    }
}
