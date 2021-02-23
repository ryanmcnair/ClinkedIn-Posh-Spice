﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Member
    {
        public string Name { get; set; }
        public List<Interest> MemberInterests { get; set; } = new List<Interest>();
        public List<Service> MemberServices { get; set; } = new List<Service>();
        public int InmateId { get; set; }
    }
}
