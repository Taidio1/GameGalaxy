namespace GameGalaxy.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Rating { get; set; } = default!;
        public string? Producer { get; set; }
        public decimal Price { get; set; }
        public int ReleaseDate { get; set; }
    }
}
