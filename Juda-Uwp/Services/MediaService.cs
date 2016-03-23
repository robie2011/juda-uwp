using Juda_Uwp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juda_Uwp.Services
{
    public class MediaService
    {        
        private readonly IMediaRepository repository;

        public MediaService(IMediaRepository repository)
        {
            this.repository = repository;
        }

        public Mastersheet GetMastersheet(int songId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Song> GetAllSongs()
        {
            // liefert daten aus den lokalen datenbank/file (caching)
            var jsonAllSongs = repository.GetAllSongs();
            var songs = JsonConvert.DeserializeObject<List<JsonSongMetaRepresentation>>(jsonAllSongs);

            throw new NotImplementedException();
        }

        public void SyncRepositoryWithInternet()
        {
            // ladet das komplete repo von internet
            throw new NotImplementedException();
        }


        private class JsonSongMetaRepresentation
        {
            public int id { get; set; }
            public string name { get; set; }
            public int artistId { get; set; }
            public string artistName { get; set; }
            public int? albumId { get; set; }
            public string albumName { get; set; }
            public int mainLanguageId { get; set; }
            public int songTypeId { get; set; }
        }
    }
}
