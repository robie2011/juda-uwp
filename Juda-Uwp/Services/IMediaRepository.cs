using System.Threading.Tasks;

namespace Juda_Uwp.Services
{
    public interface IMediaRepository
    {
        Task<string> GetAllSongsMetaAsStringAsync();
        Task<string> GetMastersheetAsStringAsync(int songId);
    }
}
