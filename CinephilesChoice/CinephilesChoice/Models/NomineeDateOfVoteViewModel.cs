namespace CinephilesChoice.Models
{
    public class NomineeDateOfVoteViewModel
    {
        public NomineeDateOfVoteViewModel(int yearOfVote, string nominee)
        {
            YearOfVote = yearOfVote;
            Nominee = nominee;
        }
        public int YearOfVote { get; }
        public string Nominee { get; }
    }
}
