using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        // [JsonIgnore]  // méthode 1 pour bloquer le cycle : les contributions qui recupere l'user qui recupere les contributions qui recupere l'user ....
        [JsonIgnore]
        public List<Contribution> Contributions { get; set; }
    }
}
