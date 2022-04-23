using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Dotsafe.Domain
{
    public class Techno
    {
        public int Id { get; set; }
        public string name { get; set; }
        public List<Contribution> Contributions { get; set; }

    }
}
