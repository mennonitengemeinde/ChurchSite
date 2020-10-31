using ChurchSite.Data.Data;
using ChurchSite.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSite.Data.Repositories
{
    public class ChurchRepository : IChurchRepository
    {
        private readonly ChurchContext _context;
        private readonly ILogger _logger;

        public ChurchRepository(ILogger<ChurchRepository> logger, ChurchContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> ChurchExists(int id)
        {
            return await _context.Churches.AnyAsync(e => e.Id == id);
        }

        public async Task CreateChurch(Church church)
        {
            _context.Churches.Add(church);
            await _context.SaveChangesAsync();
        }

        public async Task<Church> DeleteChurch(int churchId)
        {
            var church = await _context.Churches.FindAsync(churchId);
            if (church == null)
            {
                var message = $"There was no Church found with Id: {churchId}";
                _logger.LogInformation(message);

                throw new ArgumentException(message);
            }

            _context.Churches.Remove(church);
            await _context.SaveChangesAsync();

            return church;
        }

        public async Task<List<Church>> GetChurchesAsync()
        {
            return await _context.Churches.ToListAsync();
        }

        public async Task<Church> GetChurchByIdAsync(int churchId)
        {
            return await _context.Churches.FindAsync(churchId);
        }

        public async Task UpdateChurch(Church church)
        {
            _context.Entry(church).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogWarning(ex, $"Updating Church with churchId {church.Id} failed");

                throw;
            }

        }
    }
}
