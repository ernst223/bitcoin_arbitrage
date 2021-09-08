using System;
using System.Net.Http;
using System.Threading.Tasks;
using BitcoinArbitrage;
using Newtonsoft.Json.Linq;

namespace ExecutorApp
{
    class Program
    {
        static BitcoinArbitrage.Controllers.ConsoleController consoleController;

        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            consoleController = new BitcoinArbitrage.Controllers.ConsoleController();

            Console.WriteLine("Fetching Kraken Data...");
            string krakenResult = await getRequest("https://api.kraken.com/0/public/Ticker?pair=XBTEUR");

            Console.WriteLine("Fetching Luno Data...");
            string lunoResult = await getRequest("https://api.mybitx.com/api/1/ticker?pair=XBTZAR");

            Console.WriteLine("Fetching Exchange Data...");
            // string exchangeResult = await getRequest("http://data.fixer.io/api/latest?access_key=b76b6d51b65a6627ae850776179a779e&format=1");
            //string exchangeResult = await getRequest("https://api.exchangeratesapi.io/latest?base=EUR");
            string exchangeResult = await getRequest("http://api.exchangeratesapi.io/v1/latest?access_key=6730765c40fcd4060764c46655b0b0c8");

            var tempKraken = JObject.Parse(krakenResult)["result"]["XXBTZEUR"]["a"];
            var myKraken = Convert.ToDouble(JArray.Parse(tempKraken.ToString())[0].ToString().Replace('.',','));

            var myLuno = Convert.ToDouble(JObject.Parse(lunoResult)["bid"].ToString().Replace('.', ','));

            var myExchange = Convert.ToDouble(JObject.Parse(exchangeResult)["rates"]["ZAR"].ToString().Replace('.', ','));

            Console.WriteLine("Calculating...");
            Executioner executioner = new Executioner(myLuno, myKraken, myExchange);

            var ObjectResult = executioner.getResults();

            Console.WriteLine("Storing Data...");
            var result = await consoleController.addResults(ObjectResult);
            if (result)
            {
                Console.WriteLine("/nSuccess");
            }
            else
            {
                Console.WriteLine("/nError on API side");
            }
        }
        static async Task<string> getRequest(string myUrl)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(myUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                string k = Console.ReadLine();
                return "Failure";
            }
        }
    }
}
