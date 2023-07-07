using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrAime;

namespace CrAimeWeb.Controllers
{
    [ApiController]
    [Route("api/evenements")]
    public class EvenementController : Controller
    {
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            List<CrAime.Evenement> events = Services.GetAllEvent();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(string id)
        {
            var eventData = Services.GetAnEvent(id);
            if (eventData != null)
            {
                return Ok(eventData);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddEvent([FromBody] EvenementViewModel events)
        {
            try
            {
                Services.AddAnEvent(events.Title, events.Type, events.Description, events.Start_date, events.End_date);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult UpdateEvent([FromBody] EvenementViewModel events)
        {
            Services.UpdateAnEvent(events.Id, events.Title, events.Type, events.Description, events.Start_date, events.End_date);
            return Ok("allgood");
        }

        [HttpPut("{id}")]
        public IActionResult DeleteEvent(string id)
        {
            Services.DeleteAnEvent(id);
            return Ok("allgood");
        }
    }
}
