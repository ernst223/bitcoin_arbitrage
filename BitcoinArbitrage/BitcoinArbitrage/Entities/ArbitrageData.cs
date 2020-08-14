using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinArbitrage.Entities
{
    public class ArbitrageData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateCaptured { get; set; }
        public double KrakenXBTEUR { get; set; }
        public double EURZAR { get; set; }
        public double LunoXBTZAR { get; set; }
        public double PercentageProfitBeforeCost { get; set; }
    }
}
