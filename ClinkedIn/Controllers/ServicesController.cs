using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.DataAccess;

namespace ClinkedIn.Controllers
{
    [Route("api/Members")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        ServiceRepository _repo;
        public ServicesController()
        {
            _repo = new ServiceRepository();
        }

        [HttpGet("{id}/services")]
        public IActionResult GetServices(int id)
        {
            var clinker = _repo.ListServices(id);
            //if (clinker == null) return NotFound($"No Clinker with an ID of:{id} exists");
            //if ( == 0) return NotFound($"{clinker.Name} doesn't have any services available");
            return Ok(clinker);
        }
    }
}
