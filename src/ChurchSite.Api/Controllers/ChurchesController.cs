using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChurchSite.Data.Data;
using ChurchSite.Data.Models;
using ChurchSite.Data.Repositories;

namespace ChurchSite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChurchesController : ControllerBase
    {
        public IChurchRepository _churchRepo { get; }

        public ChurchesController(IChurchRepository churchRepo)
        {
            _churchRepo = churchRepo;
        }

        // GET: api/Churches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Church>>> GetChurches()
        {
            return await _churchRepo.GetChurchesAsync();
        }

        // GET: api/Churches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Church>> GetChurch(int id)
        {
            var church = await _churchRepo.GetChurchByIdAsync(id);

            if (church == null)
            {
                return NotFound();
            }

            return church;
        }

        // PUT: api/Churches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChurch(int id, Church church)
        {
            if (id != church.Id)
            {
                return BadRequest();
            }

            try
            {
                await _churchRepo.UpdateChurch(church);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _churchRepo.ChurchExists(id) == false)
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

        // POST: api/Churches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Church>> PostChurch(Church church)
        {
            await _churchRepo.CreateChurch(church);

            return CreatedAtAction("GetChurch", new { id = church.Id }, church);
        }

        // DELETE: api/Churches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Church>> DeleteChurch(int id)
        {
            Church church;
            try
            {
                church = await _churchRepo.DeleteChurch(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return church;
        }
    }
}
