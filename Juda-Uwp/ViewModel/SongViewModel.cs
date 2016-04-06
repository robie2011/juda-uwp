using Juda_Uwp.Model;
using Juda_Uwp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juda_Uwp.ViewModel
{
    class SongViewModel
    {
        private ObservableCollection<Song> songs = new ObservableCollection<Song>();
        public ObservableCollection<Song> Songs { get { return this.songs; } }

        public SongViewModel(MediaService mediaService)
        {
            foreach (var song in mediaService.GetAllSongs())
            {
                songs.Add(song);
            }

            //for (int i = 1; i <= 5; i++)
            //{
            //    var song = new Song();
            //    song.Name = "Song " + i;
            //    songs.Add(song);
            //}
        }
    }
}
