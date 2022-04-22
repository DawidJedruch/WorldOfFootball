namespace WorldOfFootball.Entities
{
    public class FootballClub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StadiumName { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }
        public string Description { get; set; }

        public virtual List<Footballer> Footballers { get; set; }
    }
}
