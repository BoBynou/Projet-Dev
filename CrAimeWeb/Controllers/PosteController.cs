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
    [Route("api/postes")]
    public class PosteController : Controller
    {
        [HttpGet]
        public IActionResult GetAllPoste()
        {
            List<CrAime.Poste> poste = Services.GetAllPoste();
            return Ok(poste);
        }

        [HttpGet("{id}")]
        public IActionResult GetPoste(int id)
        {
            var posteData = Services.GetPoste(id);
            if (posteData != null)
            {
                return Ok(posteData);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddPoste([FromBody] PosteViewModel poste)
        {
            try
            {
                Services.AddPoste(poste.Name, poste.Description);
                return Ok("allgood");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult UpdatePoste([FromBody] PosteViewModel poste)
        {
            Services.UpdatePoste(poste.Id, poste.Name, poste.Description);
            return Ok("allgood");
        }

        [HttpPut("{id}")]
        public IActionResult DeletePoste(string id)
        {
            Services.DeletePoste(id);
            return Ok("allgood");
        }
    }
}
