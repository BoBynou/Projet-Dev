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
    [Route("api/associations")]
    public class AssociationController : Controller
    {
        
        [HttpGet]
        public IActionResult GetAllAsso()
        {
            List<CrAime.Associations> assos = Services.GetAllAsso();
            return Ok(assos);
        }

        [HttpGet("{id}")]
        public IActionResult GetAsso(int id)
        {
            var assoData = Services.GetAnAsso(id);
            if (assoData != null)
            {
                return Ok(assoData);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddAsso([FromBody] AssociationViewModel asso)
        {
            try
            {
                Services.AddAnAsso(asso.Name);
                return Ok("allgood");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult UpdateAsso([FromBody] AssociationViewModel asso)
        {
            Services.UpdateAnAsso(asso.Id, asso.Name);
            return Ok("allgood");
        }

        [HttpPut("{id}")]
        public IActionResult DeleteAsso(string id)
        {
            Services.DeleteAnAsso(id);
            return Ok("allgood");
        }
    }
}
