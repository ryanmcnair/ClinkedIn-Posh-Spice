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
    public class MemberController : ControllerBase
    {
        MemberRepository _memberRepo;

        public MemberController()
        {
            _memberRepo = new MemberRepository();
        }

        public IActionResult GetAllMembers()
        {
            return Ok(_memberRepo.GetAllMembers());
        }
    }
}

