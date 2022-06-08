using System.ComponentModel.DataAnnotations;

namespace WorldOfFootball.Models
{
    public class CreateFootballClubDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string StadiumName { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }
        public string Description { get; set; }
    }
}
