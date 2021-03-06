﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Juda_Uwp.Services
{
    public class InternetMediaRepository : IMediaRepository
    {
        private readonly string baseUrl = "http://juda.uf.to/api/Songs";

        public Task<string> GetAllSongsMetaAsStringAsync() => MakeGetRequest(baseUrl);

        public Task<string> GetMastersheetAsStringAsync(int songId) => MakeGetRequest($"{baseUrl}/{songId}/Mastersheet");

        private async Task<string> MakeGetRequest(string Url)
        {
            var result = "";

            using (var client = new HttpClient())
            {
                var httpResonseMessage = await client.GetAsync(new Uri(Url));
                result = await httpResonseMessage.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
