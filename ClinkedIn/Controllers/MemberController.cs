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

        //Add A Friend
        [HttpPut("{id}/add-friend-{friendId}")]
        public IActionResult AddFriend(int id, int friendId)
        {
            var clinker = _memberRepo.GetAMember(id);
            var friend = _memberRepo.GetAMember(friendId);
            clinker.Friends.Add(friend);
            friend.Friends.Add(clinker);
            return Ok($"You have added {friend.Name} as a friend");
        }

        //Get friends of a member
        [HttpGet("{id}/friends")]
        public IActionResult GetFriends(int id)
        {
            var clinker = _memberRepo.GetAMember(id);
            if (clinker == null) return NotFound($"There is no clinker with an id of: {id}");
            if (clinker.Friends.Count == 0) return NotFound($"{clinker.Name} has no friends... What a loser!");
            return Ok(clinker.Friends);
        }
    }
}

