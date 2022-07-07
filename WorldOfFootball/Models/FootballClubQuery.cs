namespace WorldOfFootball.Models
{
    public class FootballClubQuery
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
