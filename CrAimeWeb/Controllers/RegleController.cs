using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrAime;

namespace CrAimeWeb.Controllers
{
    [ApiController]
    [Route("api/regles")]
    public class RegleController : Controller
    {
        [HttpGet]
        public IActionResult GetAllRegle()
        {
            List<CrAime.Regle> regles = Services.GetAllRegle();
            return Ok(regles);
        }

        [HttpGet("{id}")]
        public IActionResult GetRegle(string id)
        {
            var regleData = Services.GetRegle(id);
            if (regleData != null)
            {
                return Ok(regleData);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddRegle([FromBody] RegleViewModel regle)
        {
            try
            {
                Services.AddRegle(regle.Description);
                return Ok("allgood");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult UpdateRegle([FromBody] RegleViewModel regle)
        {
            Services.UpdateRegle(regle.Id, regle.Description);
            return Ok("allgood");
        }

        [HttpPut("{id}")]
        public IActionResult DeleteRegle(string id)
        {
            Services.DeleteRegle(id);
            return Ok("allgood");
        }
    }
}

