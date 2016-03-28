using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudaMastersheetLib.Model
{
    enum Tags { }

    public enum SongPartType : Tags
    {
        Vers1,
        Vers2,
        Vers3,
        Vers4,
        Vers5,
        Vers6,
        Chorus,
        PreChorus,
        Bridge,
        Intro
    }

    public class SongPart
    {
        public SongPartType SongPartType { get; set; }
        public string[] Lines { get; set; }
    }

    public class LanguageVersion
    {
        public Languages Language { get; set; }
        public SongPart[] SongParts { get; set; }
    }

    public class Mastersheet
    {
        public int SongId { get; set; }
        public LanguageVersion[] LanguageVersions { get; set; }
    }
}
