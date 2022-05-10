namespace WorldOfFootball.Models
{
    public class CreateFootballClubDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StadiumName { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }
        public string Description { get; set; }
    }
}
