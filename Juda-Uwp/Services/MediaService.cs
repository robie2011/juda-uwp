using Juda_Uwp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juda_Uwp.Services
{
    public class MediaService
    {
        private const string songApiUrl = "http://juda.uf.to/api/Songs";
        public Mastersheet GetMastersheet(int songId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Song> GetAllSongs()
        {
            // liefert daten aus den lokalen datenbank/file (caching)
            throw new NotImplementedException();
        }

        public void SyncRepositoryWithInternet()
        {
            // ladet das komplete repo von internet
            throw new NotImplementedException();
        }
    }
}
