using System.ComponentModel.DataAnnotations;

namespace WorldOfFootball.Models
{
    public class CreateFootballerDto
    {
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public int Price { get; set; }

        public int FootballClubId { get; set; }
    }
}
