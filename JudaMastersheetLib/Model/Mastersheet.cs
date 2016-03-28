using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudaMastersheetLib.Model
{
    public enum SongPartType
    {
        Vers1,
        Vers2,
        Vers3,
        Vers4,
        Vers5,
        Vers6,
        Vers7,
        Vers8,
        Vers9,
        Vers10,
        Vers11,
        Vers12,
        Chorus,
        PreChorus,
        Bridge,
        Intro,
        Undefined
    }

    public class SongPart
    {
        public SongPartType SongPartType;
        public IReadOnlyList<string> Lines;

        public SongPart(SongPartType songPartType, IReadOnlyList<string> lines)
        {
            this.SongPartType = songPartType;
            this.Lines = lines;
        }
    }

    public class LanguageVersion
    {
        public LanguageType LanguageType;
        public IReadOnlyList<SongPart> SongParts;

        public LanguageVersion(LanguageType languageType, IReadOnlyList<SongPart> songParts)
        {
            this.LanguageType = languageType;
            this.SongParts = songParts;
        }
    }

    public class Mastersheet
    {
        public int SongId;
        public IReadOnlyList<LanguageVersion> LanguageVersions;

        public Mastersheet(int songId, IReadOnlyList<LanguageVersion> languageVersions)
        {
            this.SongId = songId;
            this.LanguageVersions = languageVersions;
        }
    }
}
