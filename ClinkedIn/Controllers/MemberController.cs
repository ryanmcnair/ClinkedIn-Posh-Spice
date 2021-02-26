using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.DataAccess;
using ClinkedIn.Models;


namespace ClinkedIn.Controllers
{
    [Route("api/Members")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        MemberRepository _memberRepo;
        public MemberController()
        {
            _memberRepo = new MemberRepository();
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            return Ok(_memberRepo.GetAllMembers());
        }
        [HttpPost]
        public IActionResult AddANewMember(Member member)
        {
            _memberRepo.AddAMember(member);
            return Created($"api/Members/{member.InmateId}", member);
        }

        // api/Members/{inmateId}
        [HttpGet("{inmateId}")]
        public IActionResult GetASingleMember(int inmateId)
        {

            return Ok(_memberRepo.GetAMember(inmateId));
        }

        //PUT enemies
        [HttpPut("{inmateId}/enemies/add/{enemyId}")]
        public IActionResult AddEnemy(int inmateId, int enemyId)
        {
            var member = _memberRepo.GetAMember(inmateId);
            _memberRepo.AddEnemy(inmateId, enemyId);
            return Ok(member.Enemies);
        }

        // GET enemies
        [HttpGet("{inmateId}/enemies")]
        public IActionResult GetEnemies(int inmateId)
        {
            var member = _memberRepo.GetAMember(inmateId);
            if(member == null)
            { 
              return NotFound("Not found");
            }
            else if(member.Enemies.Count == 0)
            {
                return NotFound("Not found");
            }
            return Ok(member.Enemies);
        }

        //
    }
}

