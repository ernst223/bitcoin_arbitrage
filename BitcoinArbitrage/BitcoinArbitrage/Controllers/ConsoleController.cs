using BitcoinArbitrage.Entities;
using BitcoinArbitrage.Repository;
using Microsoft.EntityFrameworkCore;
using PostmarkDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinArbitrage.Controllers
{
    public class ConsoleController
    {
        private DataRepository dataRepository;

        public ConsoleController()
        {
            var connectionString = "server=localhost;user id=root;Password=Ernst123?;database=ArbitrageDB";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseMySQL(connectionString);
            var context = new MyContext(optionBuilder.Options);
            dataRepository = new DataRepository(context);
        }

        public async Task<bool> addResults(ArbitrageData T)
        {
            if(T.PercentageProfitBeforeCost > 0.04)
            {
                await notify(T, "peter@vanurk.co.za");
                await notify(T, "fietsryersa@yahoo.co.uk");
            }
            return dataRepository.addResults(T);
        }

        public async Task notify(ArbitrageData T, string pEmail)
        {
            try
            {
                var message = new TemplatedPostmarkMessage
                {
                    From = "potchefstroom@welwyn.co.za",
                    To = pEmail,
                    TemplateAlias = "bitcoinArbitrage",
                    TemplateModel = new Dictionary<string, object> {
                            { "percent", Convert.ToString(T.PercentageProfitBeforeCost * 100) },
                            { "date", Convert.ToString(T.DateCaptured) },
                            { "krakenprice", Convert.ToString(T.KrakenXBTEUR) },
                            { "lunoprice", Convert.ToString(T.LunoXBTZAR) },
                            { "eurotozar", Convert.ToString(T.EURZAR) }
                          },
                };

                var client = new PostmarkClient("ba0d1e9f-0b0b-442f-a350-9504a5015caf");

                var response = await client.SendMessageAsync(message);

                if (response.Status != PostmarkStatus.Success)
                {
                    Console.WriteLine("Response was: " + response.Message);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Email fail: " + e.Message);
            }
        }
    }
}
