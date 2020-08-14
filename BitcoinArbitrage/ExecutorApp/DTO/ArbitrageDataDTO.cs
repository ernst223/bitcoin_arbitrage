using System;
using System.Collections.Generic;
using System.Text;

namespace ExecutorApp.DTO
{
    public class ArbitrageDataDTO
    {
        public int Id { get; set; }
        public DateTime DateCaptured { get; set; }
        public double KrakenXBTEUR { get; set; }
        public double EURZAR { get; set; }
        public double LunoXBTZAR { get; set; }
        public double PercentageProfitBeforeCost { get; set; }
    }
}
