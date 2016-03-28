using JudaMastersheetLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JudaMastersheetLib
{
    public class MastersheetConverter
    {
        private static readonly Dictionary<string, LanguageType> knownLanguageByTag = new Dictionary<string, LanguageType>()
        {
            { "#english", LanguageType.English },
            { "#german", LanguageType.German },
            { "#tamil", LanguageType.Tamil },
            { "#tamilpronounced", LanguageType.TamilPronounced }
        };

        //todo: better method for vers taggig -> Exception if vers > 6
        private static readonly Dictionary<string, SongPartType> knownSongPartTypeByTag = new Dictionary<string, SongPartType>()
        {
            { "#vers1", SongPartType.Vers1 },
            { "#vers2", SongPartType.Vers2 },
            { "#vers3", SongPartType.Vers3 },
            { "#vers4", SongPartType.Vers4 },
            { "#vers5", SongPartType.Vers5 },
            { "#vers6", SongPartType.Vers6 },
            { "#vers7", SongPartType.Vers7 },
            { "#vers8", SongPartType.Vers8 },
            { "#vers9", SongPartType.Vers9 },
            { "#vers10", SongPartType.Vers10 },
            { "#vers11", SongPartType.Vers11 },
            { "#vers12", SongPartType.Vers12 },
            { "#chorus", SongPartType.Chorus },
            { "#prechorus", SongPartType.PreChorus },
            { "#bridge", SongPartType.Bridge },
            { "#intro", SongPartType.Intro }
        };

        public static Mastersheet Converter(int id, string text)
        {
            var songLines = ExtractPartsWithLines(text);
            var parserSongPartsWithoutDefaults = ExtractParts(songLines);
            var parserSongPartsWithDefaults = GetParserSongPartsWithDefaults(parserSongPartsWithoutDefaults);
            var parserSongPartsByLanguage = parserSongPartsWithDefaults.ToLookup(sp => sp.Language);

            var languageVersions = new List<LanguageVersion>();
            foreach (var parserSongParts in parserSongPartsByLanguage)
            {
                var songParts = parserSongParts
                    .Select(s => new SongPart(s.SongPartType, s.Lines))
                    .ToList();
                var languageVersion = new LanguageVersion(parserSongParts.Key, songParts);
                languageVersions.Add(languageVersion);
            }

            return new Mastersheet(id, languageVersions);
        }

        private static IReadOnlyList<ParserSongLines> ExtractPartsWithLines(string text)
        {
            var lines = text.Split('\n')
                .ToList()
                .Select(s => s.Trim());

            var partCollection = new List<ParserSongLines>();
            var lastPart = new List<string>();
            var lastLineWasEmpty = true;

            foreach (var line in lines)
            {
                var emptyLineDetected = line == string.Empty;
                var pageBreakDetected = emptyLineDetected && !lastLineWasEmpty;

                if (pageBreakDetected)
                {
                    partCollection.Add(new ParserSongLines(lastPart));
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
                partCollection.Add(new ParserSongLines(lastPart));
            }

            return partCollection;
        }

        private static IReadOnlyList<ParserSongPart> ExtractParts(IReadOnlyList<ParserSongLines> listOfSongLines)
        {
            return listOfSongLines
            .Select(s => GetParserSongPart(s))
            .ToList();
        }

        private static ParserSongPart GetParserSongPart(ParserSongLines songLines)
        {
            var songPart = SongPartType.Undefined;
            var songLanguage = LanguageType.Undefined;

            var lines = new List<string>();

            foreach (var line in songLines.Lines)
            {
                var tagNames = ExtractTags(line);
                var lineIsUsedToForTagging = tagNames.Any();
                if (lineIsUsedToForTagging)
                {
                    foreach (var tagname in tagNames)
                    {
                        if (knownLanguageByTag.ContainsKey(tagname))
                        {
                            songLanguage = knownLanguageByTag[tagname];
                        }
                        else if (knownSongPartTypeByTag.ContainsKey(tagname))
                        {
                            songPart = knownSongPartTypeByTag[tagname];
                        }
                        else
                        {
                            // todo: inform about invalid tag
                        }
                    }
                }
                else
                {
                    lines.Add(line);
                }
            }

            return new ParserSongPart(songLanguage, songPart, lines);
        }

        private static IReadOnlyList<ParserSongPart> GetParserSongPartsWithDefaults(IReadOnlyList<ParserSongPart> songParts)
        {
            var fallbackVersCounter = 1;
            var modifiedSongParts = new List<ParserSongPart>(songParts.Count);
            var firstSongPart = songParts.First();
            var lastLanguage = firstSongPart.Language != LanguageType.Undefined
                ? firstSongPart.Language
                : DetectLanguage(firstSongPart.Lines, LanguageType.English); 

            foreach (var songPart in songParts)
            {
                var modifiedLanguage = songPart.Language != LanguageType.Undefined
                    ? songPart.Language
                    : DetectLanguage(songPart.Lines, lastLanguage);

                if (lastLanguage != modifiedLanguage)
                {
                    fallbackVersCounter = 1;
                    lastLanguage = modifiedLanguage;
                }

                var modifiedSongPartType = songPart.SongPartType != SongPartType.Undefined
                    ? songPart.SongPartType
                    : knownSongPartTypeByTag["#vers" + fallbackVersCounter++];

                modifiedSongParts.Add(new ParserSongPart(modifiedLanguage, modifiedSongPartType, songPart.Lines));
            }
            return modifiedSongParts;
        }

        private const char TamilUnicodeStart = '\u0B80';
        private const char TamilUnicodeEnd = '\u0BFF';

        private static LanguageType DetectLanguage(IReadOnlyList<string> lines, LanguageType fallBackLanguage)
        {
            var firstChar = lines.First()[0];
            if (firstChar >= TamilUnicodeStart && firstChar <= TamilUnicodeEnd)
            {
                return LanguageType.Tamil;
            }

            return fallBackLanguage;
        }

        private static IReadOnlyList<string> ExtractTags(string line)
        {
            var tags = new List<string>();
            var lineStartWithTags = line != null && line.Length > 1 && line[0] == '#';
            if (lineStartWithTags)
            {
                tags = line.Split(' ')
                    .Select(s => s.Trim().ToLower())
                    .Where(s => s.Length > 1 && s[0] == '#')
                    .ToList();
            }

            return tags;
        }

        private class ParserSongPart
        {
            public readonly LanguageType Language;
            public readonly SongPartType SongPartType;
            public readonly IReadOnlyList<string> Lines;
            public ParserSongPart(LanguageType language, SongPartType songPartType, IReadOnlyList<string> lines)
            {
                this.Language = language;
                this.SongPartType = songPartType;
                this.Lines = lines;
            }
        }

        private class ParserSongLines
        {
            public readonly IReadOnlyList<string> Lines;
            public ParserSongLines(IReadOnlyList<string> lines)
            {
                this.Lines = lines;
            }
        }
    }
}
