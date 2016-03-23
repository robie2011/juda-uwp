using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Juda_Uwp.Services;

namespace UnitTestProject
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void CheckInternetRepositoryAllSongs()
        {
            var repo = new InternetMediaRepository();
            var result = repo.GetAllSongs();
        }

        [TestMethod]
        public void CheckInternetRepositoryMastersheet()
        {            
            var repo = new InternetMediaRepository();
            var result = repo.GetMastersheet(99);
        }

        [TestMethod]
        public void TestConversion()
        {
            var mediaService = new MediaService(new InternetMediaRepository());
            mediaService.GetAllSongs();
        }
    }
}
