﻿namespace WorldOfFootball.Entities
{
    public class Footballer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public int Price { get; set; }

        public int FootballClubId { get; set; }
        public virtual FootballClub FootballClub { get; set;}
    }
}
