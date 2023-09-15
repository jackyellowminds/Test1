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
    public class ReservationController : Controller
    {
        private readonly IDatabaseService database;

        public ReservationController(IDatabaseService database)
        {
            this.database = database;
        }
        // TODO: Get All Reservations
        [HttpGet]
        [Route("Reservations")]
        public IActionResult Reservations()
        {
          return null;
        }

        // TODO: Get Recent Reservations
        [HttpGet]
        [Route("GetRecentReservations")]
        public IActionResult GetRecentReservations()
        {
           return null;
        }

        // TODO: Get Reservations with tables
        [HttpGet]
        [Route("GetReservationWithTable")]
        public IActionResult GetReservationWithTable(int Id)
        {
           return null;
        }
        
        [HttpGet]
        [Route("Reservations/{id}")]
        public IActionResult Reservations(int id)
        {
            var response = database.GetReservationById(id);
            return Ok(response);
        }
        
        // TODO: Add New Reservations
        [HttpPost]
        [Route("AddReservations")]
        public IActionResult AddReservations([FromBody] ReservationMD value)
        {
            return null;
        }

        // TODO: Update Reservations
        [HttpPost]
        [Route("UpdateReservations")]
        public IActionResult UpdateReservations(ReservationMD value)
        { 
           return null;
        }

        // TODO: Delete Reservations
        [HttpDelete]
        [Route("DeleteReservation")]
        public IActionResult DeleteReservation(int id)
        {   
            return null;
        }

        [HttpDelete]
        [Route("CancelReservation")]
        public IActionResult CancelReservation(int id,int UserNo)
        {
            var response = database.CancelReservation(id, UserNo);
            return Ok(Json(response));
        }

        [HttpDelete]
        [Route("CancelReservationAdmin")]
        public IActionResult DeleteReservationAdmin(int id)
        {
            var response = database.CancelReservationAdmin(id);
            return Ok(Json(response));
        }

        [HttpPost]
        [Route("BookReservation")]
        public IActionResult BookReservation([FromBody] ReservationMD value)
        {
            var response = database.BookReservation(value);
            return Ok(Json(response));
        }
    }
}
