using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Dotsafe.Domain
{
    public class Contribution
    {
        public int Id { get; set; }
        public string name { get; set; }

        public User User { get; set; }

        public Techno Techno { get; set; }

        public Project Project { get; set; }
    }
}
