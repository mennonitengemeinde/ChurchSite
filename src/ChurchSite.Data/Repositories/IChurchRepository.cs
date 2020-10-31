using ChurchSite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurchSite.Data.Repositories
{
    public interface IChurchRepository
    {
        Task CreateChurch(Church church);
        Task<Church> DeleteChurch(int churchId);
        Task<Church> GetChurchByIdAsync(int churchId);
        Task<List<Church>> GetChurchesAsync();
        Task UpdateChurch(Church church);
        Task<bool> ChurchExists(int id);
    }
}