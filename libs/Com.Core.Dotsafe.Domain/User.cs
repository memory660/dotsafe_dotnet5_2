﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Dotsafe.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string roles { get; set; }
        public string password { get; set; }
        
        public List<Contribution> Contributions { get; set; }
    }
}
