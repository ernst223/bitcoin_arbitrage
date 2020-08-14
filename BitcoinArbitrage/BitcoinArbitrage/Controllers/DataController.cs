using BitcoinArbitrage.Entities;
using BitcoinArbitrage.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinArbitrage.Controllers
{
    public class DataController: Controller
    {
        private DataRepository dataRepository;
        public DataController(MyContext T)
        {
            dataRepository = new DataRepository(T);
        }

        [HttpGet("getLatest100")]
        public async Task<IActionResult> getLatest100()
        {
            return Ok(dataRepository.getLatest100());
        }

        [HttpGet("getLatest1000")]
        public async Task<IActionResult> getLatest1000()
        {
            return Ok(dataRepository.getLatest1000());
        }

        [HttpGet("getLatest10000")]
        public async Task<IActionResult> getLatest10000()
        {
            return Ok(dataRepository.getLatest10000());
        }

        [HttpGet("getLatest100000")]
        public async Task<IActionResult> getLatest100000()
        {
            return Ok(dataRepository.getLatest100000());
        }

        [HttpGet("getLatestResult")]
        public async Task<IActionResult> getLatestResult()
        {
            return Ok(dataRepository.getLatestResult());
        }
    }
}
