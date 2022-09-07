using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.IO;
using System;
using Amazon_Store.Models;
using System.Linq;

namespace Amazon_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        private readonly StoreContext _context;

        public StoreController(StoreContext context)
        {
            _context = context;
        }
        // GET: api/<StoreController>
        [HttpGet]
        public IActionResult Get()
        {
            var QueryResult = _context.Items.Select(que =>
            new {
                que.NameItem,
                que.Subcategory.NameSubcategory,
                que.Subcategory.Category.Name
            }).ToList();


            return Ok(QueryResult);

        }

        [HttpGet]
        [Route("ExportByCSV")]
        public IActionResult ExportCSV()
        {
            var PathFile = Path.Combine(Environment.CurrentDirectory, $"StoreCategory.csv");
            using (var streamWriter = new StreamWriter(PathFile))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    var Query = _context.Items.Select(que =>
            new
            {
                que.Id,
                que.NameItem,
                que.Subcategory ,
                que.Subcategory.Category 
            }).ToList();
                    csvWriter.WriteRecords(Query);
                }
            }
            return Ok("Will Be Done!");
        }
    }
}
