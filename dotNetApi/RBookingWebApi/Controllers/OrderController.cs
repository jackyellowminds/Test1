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
    public class OrderController : Controller
    {
        private readonly IDatabaseService database;

        public OrderController(IDatabaseService database)
        {
            this.database = database;
        }

        // TODO: Get All Orders
        [HttpGet]
        [Route("Orders")]
        public IActionResult Orders()
        {
           return null;
        }

        // TODO: Get Reservations by Id
        [HttpGet]
        [Route("OrderById")]
        public IActionResult OrderById(int id)
        {   
            return null;
        }

        // TODO: Add New Orders
        [HttpPost]
        [Route("SaveOrders")]
        public IActionResult SaveOrders([FromBody]  OrderMD value)
        {
           return null;
        }

        // TODO: Update Orders
        [HttpPost]
        [Route("UpdateOrders")]
        public IActionResult UpdateOrders([FromBody]  OrderMD value)
        {  
           return null;
        }

        // TODO: Delete Orders
        [HttpDelete]
        [Route("DeleteOrder")]
        public IActionResult DeleteOrder(int id)
        {  
            return null;
        }
    }
}
