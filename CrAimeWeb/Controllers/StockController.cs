using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrAime;

namespace CrAimeWeb.Controllers
{
    [ApiController]
    [Route("api/stocks")]
    public class StockController : Controller
    {
        [HttpGet]
        public IActionResult GetAllStocks()
        {
            List<CrAime.Stock> stocks = Services.GetAllStocks();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetStock(string id)
        {
            var stockData = Services.GetStock(id);
            if (stockData != null)
            {
                return Ok(stockData);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddStock([FromBody] StockViewModel stock)
        {
            try
            {
                Services.AddStock(stock.Name, Convert.ToInt32(stock.Quantity), Convert.ToInt32(stock.Min_Quantity), Convert.ToInt32(stock.Max_Quantity), stock.Measure_Unit);
                return Ok("allgood");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult UpdateStock([FromBody] StockViewModel stock)
        {
            Services.UpdateStock(stock.Id, stock.Name, Convert.ToInt32(stock.Quantity), Convert.ToInt32(stock.Min_Quantity), Convert.ToInt32(stock.Max_Quantity), stock.Measure_Unit);
            return Ok("allgood");
        }

        [HttpPut("{id}")]
        public IActionResult DeleteStock(string id)
        {
            Services.DeleteStock(id);
            return Ok("allgood");
        }
    }
}
