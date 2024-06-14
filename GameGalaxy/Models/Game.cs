namespace GameGalaxy.Models
{
    public class Game
    {
        public required string ImageUrl { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Rating { get; set; }
        public required string Producer { get; set; }
        public decimal Price { get; set; }
        
        public int ReleaseDate { get; set; }
    }

}
