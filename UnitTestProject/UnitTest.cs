using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Juda_Uwp.Services;
using JudaMastersheetLib;
using JudaMastersheetLib.Model;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class IntegrationTest
    {
        MediaService mediaService = new MediaService(new InternetMediaRepository());

        [TestMethod]
        public void CheckInternetRepositoryAllSongs()
        {
            var repo = new InternetMediaRepository();
            var result = repo.GetAllSongsMetaAsString();
        }

        [TestMethod]
        public void CheckInternetRepositoryMastersheet()
        {            
            var repo = new InternetMediaRepository();
            var result = repo.GetMastersheetAsString(99);
        }

        [TestMethod]
        public void TestConversion()
        {
            AssertLanguagesAndSongPartType(101,
                new[] { LanguageType.Tamil, LanguageType.English }.ToList(),
                new[] { SongPartType.Vers1, SongPartType.Vers5}
                );
        }


        private void AssertLanguagesAndSongPartType(int mastersheetId, IReadOnlyList<LanguageType> languages, IReadOnlyList<SongPartType> songPartTypes)
        {
            var sheet = mediaService.GetSongTextOnly(mastersheetId);
            var mastersheet = MastersheetConverter.Converter(mastersheetId, sheet);
            var sheetLanguages = new HashSet<LanguageType>(mastersheet.LanguageVersions.Select(l => l.LanguageType));
            var sheetSongPartTypes = new HashSet<SongPartType>(mastersheet.LanguageVersions.SelectMany(l => l.SongParts).Select(s => s.SongPartType));
            Assert.IsTrue(languages.All(l => sheetLanguages.Contains(l)));
            Assert.IsTrue(songPartTypes.All(s => sheetSongPartTypes.Contains(s)));
        }
    }
}
