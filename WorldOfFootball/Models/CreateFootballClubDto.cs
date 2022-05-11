using System.ComponentModel.DataAnnotations;

namespace WorldOfFootball.Models
{
    public class CreateFootballClubDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public string StadiumName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Nationality { get; set; }
        public string Description { get; set; }
    }
}
