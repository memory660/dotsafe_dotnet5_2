using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Com.Core.Dotsafe.Domain
{
    public class Contribution : BaseEntity
    {
        public int Id { get; set; }

        public string name { get; set; }

        //[JsonIgnore]
        public User User { get; set; }

        public Techno Techno { get; set; }

        public Project Project { get; set; }
    }
}
