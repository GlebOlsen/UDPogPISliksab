using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using ModelLibSlikskab;

namespace UDPSlikskab
{
    class Post
    {
        public async void PostItemHttpTask(SensorData sensordata)
        {
            string EventWebApi = "https://slikskabdata.azurewebsites.net/";

            using (HttpClient client = new HttpClient())
            {
                string newItemJson = JsonConvert.SerializeObject(sensordata);
                Console.WriteLine("Serialized object: " + newItemJson);
                var content = new StringContent(newItemJson, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(EventWebApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                IEnumerable<string> headers;
                headers = client.DefaultRequestHeaders.GetValues("Accept");
                foreach (var VARIABLE in headers)
                {
                    Console.WriteLine(VARIABLE);
                }
                var response = client.PostAsync("api/reading", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseEvent = client.GetAsync("api/reading" + sensordata).Result;
                    //if (responseEvent.IsSuccessStatusCode)
                    {
                        //var Event = responseEvent.Content.ReadAsStreamAsync<Event>().Result;
                        //   string saveEvent = await responseEvent.Content.ReadAsStringAsync<Event>().Result;

                    }
                }
            }

            //return await GetItemsHttpTask();
        }
    }
}
