using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Enalyzer_App
{
    public class RestService
    {
        HttpClient _client;
        public RestService()
        {
            _client = new HttpClient();
        }

        public List<string> Items { get; private set; }

        public async Task<List<string>> RefreshDataAsync()
        {
            var uri = new Uri("https://localhost:44313/api/taglist");
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<string>>(content);
            }
            return Items;
        }
    }
}
