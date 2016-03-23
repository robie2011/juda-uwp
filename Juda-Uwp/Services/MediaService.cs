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
        private IReadOnlyList<Song> songs;

        public MediaService(IMediaRepository repository)
        {
            this.repository = repository;
            InitSongsMetaData();
        }

        public Mastersheet GetMastersheet(int songId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Song> GetAllSongs() => songs;

        public void SyncRepositoryWithInternet()
        {

        }


        private void InitSongsMetaData()
        {
            var jsonAllSongsMetaString = repository.GetAllSongsMetaAsString();
            var jsonSongs = JsonConvert.DeserializeObject<List<JsonSongMetaRepresentation>>(jsonAllSongsMetaString);

            var songs = new List<Song>(jsonSongs.Count);
            foreach (var jsonSong in jsonSongs)
            {
                var artist = new Artist
                {
                    Id = jsonSong.artistId,
                    Name = jsonSong.artistName
                };

                Album album = null;
                if (jsonSong.albumId.HasValue)
                {
                    album = new Album
                    {
                        Id = jsonSong.albumId.Value,
                        Name = jsonSong.albumName
                    };
                }

                songs.Add(new Song
                {
                    Id = jsonSong.id,
                    Name = jsonSong.name,
                    Artist = artist,
                    Album = album,
                    SongSpeed = (SongSpeed)jsonSong.songTypeId,
                    Language = (Languages)jsonSong.mainLanguageId
                });
            }

            this.songs = songs.AsReadOnly();
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
