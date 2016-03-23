using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juda_Uwp.Services
{
    public interface IMediaRepository
    {
        string GetAllSongsMetaAsString();
        string GetMastersheetAsString(int songId);
    }
}
