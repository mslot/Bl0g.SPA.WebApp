using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Bl0g.SPA.WebApp
{
    public class ViewModel
    {
        private readonly HttpClient client;

        public ViewModel(HttpClient client)
        {
            this.client = client;
        }

        public async Task<string> Text()
        {
            ApiReference config;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("config.json"))
            using (var reader = new StreamReader(stream))
            {
                config = JsonConvert.DeserializeObject<ApiReference>(reader.ReadToEnd());
            }

            var response = await client.GetAsync($"{config.Apis.First().Url}/api/languages");
            string text = await response.Content.ReadAsStringAsync();

            return await Task.FromResult<string>(text);
        }
    }
}
