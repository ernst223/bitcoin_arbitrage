using BitcoinArbitrage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinArbitrage.Repository
{
    public class DataRepository
    {
        private MyContext dc;
        public DataRepository(MyContext context)
        {
            dc = context;
        }

        public List<ArbitrageData> getLatest100()
        {
            return dc.arbitrageData.Take(100).OrderByDescending(a => a.Id).ToList();
        }

        public List<ArbitrageData> getLatest1000()
        {
            return dc.arbitrageData.OrderByDescending(a => a.Id).Take(1000).ToList();
        }

        public List<ArbitrageData> getLatest10000()
        {
            return dc.arbitrageData.OrderByDescending(a => a.Id).Take(10000).ToList();
        }

        public List<ArbitrageData> getLatest100000()
        {
            return dc.arbitrageData.OrderByDescending(a => a.Id).Take(100000).ToList();
        }

        public ArbitrageData getLatestResult()
        {
            return dc.arbitrageData.OrderByDescending(a => a.Id).OrderByDescending(a => a.Id).FirstOrDefault();
        }

        public bool addResults(ArbitrageData T)
        {
            try
            {
                dc.arbitrageData.Add(T);
                dc.SaveChanges();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
