using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RBookingWebApi.DataContext;
using RBookingWebApi.DBL;
using RBookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.Controllers
{
    
    [ApiController]
    [Route("api/")]
    public class TableController : Controller
    {
        private readonly IDatabaseService database;

        public TableController(IDatabaseService database)
        {
            this.database = database;
        }

        // TODO: Get All Tables
        [EnableCors("foo")]
        [HttpGet]
        [Route("Tables")]
        public IActionResult Tables()
        {
           return null;
        }

        // TODO: Get Table by Id
        [HttpGet]
        [Route("Tables/{id}")]
        public IActionResult Tables(int id)
        {  
            return null;
        }
         
        // TODO: Add New Table
        [HttpPost]
        [Route("AddTable")]
        public IActionResult AddTable([FromBody] TableMD value)
        {
           return null;
        }

        // TODO: Update New Table
        [HttpPost]
        [Route("UpdateTable")]
        public IActionResult UpdateTable([FromBody] TableMD value)
        {      
            return null;
        }

        // TODO: Delete Table
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            return null;
        }
        
        [HttpGet]
        [Route("GetTableStatus")]
        public IActionResult GetTableStatus()
        {
            var response = database.GetTableStatus();
            return Ok(response);
        }
    }
}
