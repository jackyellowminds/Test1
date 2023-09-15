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
    public class MenuController : Controller
    {
        private readonly IDatabaseService database;

        public MenuController(IDatabaseService database)
        {
            this.database = database;
        }

        // TODO: Get All Menu
        [HttpGet]
        [Route("MenuItems")]
        public IActionResult MenuItems()
        {         
            return null;
        }

        // TODO: Get Menu by Id
        [HttpGet]
        [Route("MenuItems/{id}")]
        public IActionResult MenuItems(int id)
        {
            return null;
        }

        // TODO: Add New Menu
        [HttpPost]
        [Route("AddMenu")]
        public IActionResult AddMenu(MenuMD value)
        { 
            return null;
        }

        // TODO: Update New Menu
        [HttpPost]
        [Route("UpdateMenu")]
        public IActionResult UpdateMenu(MenuMD value)
        {
           return null;
        }

        // TODO: Delete Menu
        [HttpDelete]
        [Route("DeleteMenu")]
        public IActionResult DeleteMenu(int id)
        {
            return null;
        }
    }
}
