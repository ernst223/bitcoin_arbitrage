using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BitcoinArbitrage;
using ExecutorApp.DTO;

namespace ExecutorApp
{
    class Executioner
    {
        private BitcoinArbitrage.Entities.ArbitrageData myResult { get; set; }
        public Executioner(double lunoValue, double krakenValue, double exchangeValue)
        {
            myResult = new BitcoinArbitrage.Entities.ArbitrageData();
            myResult.EURZAR = exchangeValue;
            myResult.DateCaptured = DateTime.Now;
            myResult.LunoXBTZAR = lunoValue;
            myResult.KrakenXBTEUR = krakenValue;
        }

        public BitcoinArbitrage.Entities.ArbitrageData getResults()
        {
            var EuroEquivalentOfZar = 100000 / myResult.EURZAR;
            var BitcoinsEquivalent = EuroEquivalentOfZar / myResult.KrakenXBTEUR;
            var ZarAmountOnSale = myResult.LunoXBTZAR * BitcoinsEquivalent;
            var ZarProfitBeforeCost = ZarAmountOnSale - 100000;
            myResult.PercentageProfitBeforeCost = ZarProfitBeforeCost / 100000;
            return myResult;
        }
    }
}
