using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.DataAccess
{
    public class MemberRepository
    {
        static List<Member> _allMembers = new List<Member>
            {
                new Member {InmateId = 1, Name="Prison Mike" }
               
            };

        public List<Member> GetAll()
        {
            return _allMembers;
        }

        public void AddAMember(Member member)
        {
            var biggestExistingId = _allMembers.Max(memb => memb.InmateId);
            member.InmateId = biggestExistingId + 1;
            _allMembers.Add(member);
        }
        public Member Get(int id)
        {
            var member = _allMembers.FirstOrDefault(memb => memb.InmateId == id);
            return member;
        }

        public void Remove(int id)
        {
            var memberToRemove = Get(id);
            _allMembers.Remove(memberToRemove);
        }
    }
}
