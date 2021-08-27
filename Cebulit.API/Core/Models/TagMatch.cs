namespace Cebulit.API.Core.Models
{
    public abstract class TagMatch
    {
        public int Id { get; set; }
        public Tag Tag { get; set; }
        public double MatchLevel { get; set; }
    }
}