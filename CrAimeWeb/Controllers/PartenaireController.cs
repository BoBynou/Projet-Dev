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
    [Route("api/partenaires")]
    public class PartenaireController : Controller
    {
        [HttpGet]
        public IActionResult GetAllPartenaires()
        {
            List<CrAime.Partenaire> partenaires = Services.GetAllPartenaire();
            return Ok(partenaires);
        }

        [HttpGet("{id}")]
        public IActionResult GetPartenaire(string id)
        {
            var userData = Services.GetPartenaire(id);
            if (userData != null)
            {
                return Ok(userData);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddPartenaire([FromBody] PartenaireViewModel user)
        {
            try
            {
                Services.AddPartenaire(user.Name, user.Type, user.Contact_phone, user.Contact_email);
                return Ok("allgood");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult UpdatePartenaire([FromBody] PartenaireViewModel user)
        {
            Services.UpdatePartenaire(user.Id, user.Name, user.Type, user.Contact_phone, user.Contact_email);
            return Ok("allgood");
        }

        [HttpPut("{id}")]
        public IActionResult DeletePartenaire(string id)
        {
            Services.DeletePartenaire(id);
            return Ok("allgood");
        }
    }
}
