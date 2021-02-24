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
    }
}

