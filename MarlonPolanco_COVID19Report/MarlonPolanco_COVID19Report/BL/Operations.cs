using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using MarlonPolanco_COVID19Report.Models;

namespace MarlonPolanco_COVID19Report.BL
{
    public class Operations
    {
        public async Task<RootRegion> GetRegios()
        {
            RootRegion pRegiones = new RootRegion();

            try
            {
                pRegiones = await GenericAPIConsume<RootRegion>("regions");
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            return pRegiones;
        }

        public async Task<Root> GetCOVIDReport()
        {
            Root pRoot = new Root();

            try
            {
                pRoot = await GenericAPIConsume<Root>("reports");
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            return pRoot;
        }

        public async Task<T> GenericAPIConsume<T>(string pMethod)
        {
            T pT = default(T);

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(string.Concat(ConfigurationManager.AppSettings["urlAPI"], "/", pMethod)),
                    Headers =

                {
                    { "x-rapidapi-key", ConfigurationManager.AppSettings["token"] },
                    { "x-rapidapi-host", ConfigurationManager.AppSettings["host"] },
                },
                };

                //Validate if data is empty or null for deserialization process
                JsonSerializerSettings options = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                };

                //Get Regions
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = response.Content.ReadAsStringAsync().Result;
                    pT = JsonConvert.DeserializeObject<T>(body, options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return (T)Convert.ChangeType(pT, typeof(T));
        }
    }
}