using HttpClientDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Program p = new Program();
            await p.GetAPIList();
            Console.ReadLine();
        }

        private async Task GetAPIList()
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(
                @"https://nova.bitcambio.com.br/api/v3/public/getassets");
            //string response = await client.GetStringAsync(
            //    @"https://jsonplaceholder.typicode.com/todos");

            //Console.WriteLine(response);

            Currentprice cp = JsonConvert.DeserializeObject<Currentprice>(response);

            foreach (var item in cp.result)
            {
                Console.WriteLine(item.Asset);
            }
        }
    }
}
