using System.ComponentModel.DataAnnotations;

namespace Com.Core.Dotsafe.UI.Dtos
{
    public class ContributionDto
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; }
        public string test { get; set; }
    }
}
