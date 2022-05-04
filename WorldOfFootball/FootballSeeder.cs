using WorldOfFootball.Entities;

namespace WorldOfFootball
{
    public class FootballSeeder
    {
        private FootballDbContext _dbContext;

        public FootballSeeder(FootballDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if (_dbContext.FootballClubs.Any())
                {
                    var footballClubs = GetFootballClubs();
                    _dbContext.FootballClubs.AddRange(footballClubs);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<FootballClub> GetFootballClubs()
        {
            var footballClubs = new List<FootballClub>()
            {
                new FootballClub()
                {
                    Name = "Chelsea",
                    StadiumName = "Stamford Bridge",
                    City = "London",
                    Nationality = "England",
                    Description = "One of the biggest english club.",
                    Footballers = new List<Footballer>()
                    {
                        new Footballer()
                        {
                            FirstName = "Kai",
                            LastName = "Havertz",
                            Age = 22,
                            Position = "Ofensywny pomocnik",
                            Nationality = "German",
                            Price = 70000000
                        },
                        new Footballer()
                        {
                            FirstName = "Mason",
                            LastName = "Mount",
                            Age = 23,
                            Position = "Ofensywny pomocnik",
                            Nationality = "England",
                            Price = 75000000
                        }
                    }
                },
                new FootballClub()
                {
                    Name = "Arsenal",
                    StadiumName = "Emirates Stadium",
                    City = "London",
                    Nationality = "England",
                    Description = "One of the biggest english club.",
                    Footballers = new List<Footballer>()
                    {
                        new Footballer()
                        {
                            FirstName = "Bukayo",
                            LastName = "Saka",
                            Age = 20,
                            Position = "Prawy pomocnik",
                            Nationality = "England",
                            Price = 65000000
                        },
                        new Footballer()
                        {
                            FirstName = "Emile",
                            LastName = "Smith Rowe",
                            Age = 21,
                            Position = "Ofensywny pomocnik",
                            Nationality = "England",
                            Price = 40000000
                        }
                    }
                }
            };

            return footballClubs;
        }
    }
}
