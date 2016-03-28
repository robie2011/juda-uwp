using JudaMastersheetLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JudaMastersheetLib
{
    public class MastersheetConverter
    {
        private const Languages defaultLanguage = Languages.English;
        private readonly Dictionary<string, Languages> knownLanguageByTag = new Dictionary<string, Languages>()
        {
            { "#english", Languages.English },
            { "#german", Languages.German },
            { "#tamil", Languages.Tamil },
            { "#tamilpronounced", Languages.TamilPronounced }
        };

        private readonly Dictionary<string, SongPartType> knownSongPartTypeByTag = new Dictionary<string, SongPartType>()
        {
            { "#vers1", SongPartType.Vers1 },
            { "#vers2", SongPartType.Vers2 },
            { "#vers3", SongPartType.Vers3 },
            { "#vers4", SongPartType.Vers4 },
            { "#vers5", SongPartType.Vers5 },
            { "#vers6", SongPartType.Vers6 },
            { "#chorus", SongPartType.Chorus },
            { "#prechorus", SongPartType.PreChorus },
            { "#bridge", SongPartType.Bridge },
            { "#intro", SongPartType.Intro }
        };

        private string lastLanguage = "#english";
        private int defaultVersCounter = 1;

        public Mastersheet Converter(string text)
        {

            throw new NotImplementedException();
        }


        private IReadOnlyList<SongLines> ExtractPartsWithLines(string text)
        {
            var lines = text.Split('\n')
                .ToList()
                .Select(s => s.Trim());

            var partCollection = new List<SongLines>();
            var lastPart = new List<string>();
            var lastLineWasEmpty = true;

            foreach (var line in lines)
            {
                var emptyLineDetected = line == string.Empty;
                var pageBreakDetected = emptyLineDetected && !lastLineWasEmpty;

                if (pageBreakDetected)
                {
                    partCollection.Add(new SongLines(lastPart));
                    lastPart = new List<string>();
                }
                else if (!emptyLineDetected)
                {
                    lastPart.Add(line);
                }

                lastLineWasEmpty = emptyLineDetected;
            }

            if(lastPart.Any())
            {
                partCollection.Add(new SongLines(lastPart));
            }

            return partCollection;
        }

        private IReadOnlyList<SongPart> ExtractParts(IReadOnlyList<SongLines> listOfSongLines) =>
            listOfSongLines
            .Select(s => GetSongPart(s))
            .ToList();

        private SongPart GetSongPart(SongLines songLines)
        {
            var songPartTag = string.Empty;

            var lines = new List<string>();

            foreach (var line in songLines.Lines)
            {
                var tagDetected = line[0] == '#';
                if (tagDetected)
                {
                    var tagname = line.ToLower();
                    var languageIsKnown = knownLanguageByTag.ContainsKey(tagname);
                    var languageHasChanged = languageIsKnown & lastLanguage != tagname;
                    if (languageHasChanged)
                    {
                        defaultVersCounter = 1;
                        lastLanguage = tagname;
                    }
                    else if (knownSongPartTypeByTag.ContainsKey(tagname))
                    {
                        songPartTag = tagname;
                    }
                    else
                    {
                        // todo: inform about invalid tag
                    }
                }
                else
                {
                    lines.Add(line);
                }
            }

            if (songPartTag == string.Empty)
            {
                songPartTag = $"#vers{defaultVersCounter}";
                defaultVersCounter++;
            }

            return new SongPart(lastLanguage, songPartTag, lines);
        }

        private class SongPart
        {
            public readonly string Language;
            public readonly string Partname;
            public readonly IReadOnlyList<string> Lines;

            public SongPart(string language, string partname, IReadOnlyList<string> lines)
            {
                this.Language = language;
                this.Partname = partname;
                this.Lines = lines;
            }
        }

        private class SongLines
        {
            public readonly IReadOnlyList<string> Lines;

            public SongLines(IReadOnlyList<string> lines)
            {
                this.Lines = lines;
            }
        }
    }
}
