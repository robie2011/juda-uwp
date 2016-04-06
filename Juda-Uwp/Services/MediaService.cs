using Juda_Uwp.Model;
using JudaMastersheetLib;
using JudaMastersheetLib.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
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

        public async Task<Mastersheet> GetMastersheet(int songId)
        {
            var songText = await GetSongTextOnly(songId);
            return MastersheetConverter.Converter(songId, songText);
        }

        public async Task<string> GetSongTextOnly(int songId)
        {
            var text = await repository.GetMastersheetAsStringAsync(songId);
            var jsonMasterSheetRepresentation = JsonConvert.DeserializeObject<JsonMastersheetRepresentation>(text);
            return jsonMasterSheetRepresentation.text;
        }

        public IReadOnlyList<Song> GetAllSongs() => songs;

        private void InitSongsMetaData()
        {
            var jsonAllSongsMetaString = repository.GetAllSongsMetaAsStringAsync().Result;
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

        private class JsonMastersheetRepresentation
        {
            public int songId { get; set; }
            public string text { get; set; }
        }
    }
}
