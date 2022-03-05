#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Player.API.Domain.Entities;
using Player.API.Infrastructure;

namespace Player.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerDbContext _context;

        public PlayersController(PlayerDbContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerInfo>>> GetPlayerInfos()
        {
            return await _context.PlayerInfos.ToListAsync();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerInfo>> GetPlayerInfo(int id)
        {
            var playerInfo = await _context.PlayerInfos.FindAsync(id);

            if (playerInfo == null)
            {
                return NotFound();
            }

            return playerInfo;
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerInfo(int id, PlayerInfo playerInfo)
        {
            if (id != playerInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(playerInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerInfoExists(id))
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

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerInfo>> PostPlayerInfo(PlayerInfo playerInfo)
        {
            _context.PlayerInfos.Add(playerInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerInfo", new { id = playerInfo.Id }, playerInfo);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerInfo(int id)
        {
            var playerInfo = await _context.PlayerInfos.FindAsync(id);
            if (playerInfo == null)
            {
                return NotFound();
            }

            _context.PlayerInfos.Remove(playerInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerInfoExists(int id)
        {
            return _context.PlayerInfos.Any(e => e.Id == id);
        }
    }
}
