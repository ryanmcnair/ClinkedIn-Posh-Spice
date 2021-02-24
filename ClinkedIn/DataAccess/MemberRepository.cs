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
                new Member {
                    InmateId = 1,
                    Name="Prison Mike",
                    MemberInterests = new List<Interest>
                    {
                       new Interest{ Id = 1, Interests = "Playing Spades", Type= "Cards"},
                       new Interest{ Id = 2, Interests = "Playing Solitare", Type= "Cards"},
                       new Interest{ Id = 3, Interests = "Lifting Weights", Type= "Exercise"},
                    }
                },
                new Member {
                    InmateId = 2,
                    Name="Big Billy Bruno",
                    MemberInterests = new List<Interest>
                    {
                       new Interest{ Id = 4, Interests = "Slam Poetry", Type= "Art"},
                       new Interest{ Id = 2, Interests = "Playing Solitare", Type= "Cards"},
                       new Interest{ Id = 6, Interests = "Doing Push-ups", Type= "Exercise"},
                    }
                },
                new Member {
                    InmateId = 3,
                    Name="Ghosteface Killa",
                    MemberInterests = new List<Interest>
                    {
                       new Interest{ Id = 4, Interests = "Slam Poetry", Type= "Art"},
                       new Interest{ Id = 7, Interests = "Juggling Shanks", Type= "Entertainment"},
                       new Interest{ Id = 8, Interests = "Community Puppet Shows", Type= "Entertainment"},
                    }
                }
            };

        public List<Member> GetAllMembers()
        {
            return _allMembers;
        }

        public void AddAMember(Member member)
        {
            var biggestExistingId = _allMembers.Max(memb => memb.InmateId);
            member.InmateId = biggestExistingId + 1;
            _allMembers.Add(member);
        }
        public Member GetAMember(int id)
        {
            var member = _allMembers.FirstOrDefault(memb => memb.InmateId == id);
            return member;
        }

        public void RemoveAMember(int id)
        {
            var memberToRemove = GetAMember(id);
            _allMembers.Remove(memberToRemove);
        }
    }
}
