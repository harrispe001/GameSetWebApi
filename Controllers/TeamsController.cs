﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameSetWebApi.Models;

namespace GameSetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly GameSetContext _context;

        public TeamsController(GameSetContext context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet("GetTeams")]
        public async Task<ActionResult<IEnumerable<Team>>> Getteam()
        {
          if (_context.team == null)
          {
              return NotFound();
          }
            return await _context.team.ToListAsync();
        }

        // GET: api/Teams/5
        [HttpGet("GetTeam/{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
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

            return team;
        }

        // PUT: api/Teams/5
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

        // POST: api/Teams
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

        // DELETE: api/Teams/5
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
    }
}
