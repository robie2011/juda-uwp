using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juda_Uwp.Model
{
    public class Song
    {
        //todo: removing setter?
        public int Id { get; set; }
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public Languages Language { get; set; }
        public SongSpeed SongSpeed { get; set; }
    }
}
