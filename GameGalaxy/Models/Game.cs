namespace GameGalaxy.Models
{
    public class Game
    {
        public string ImageUrl { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Rating { get; set; }
        public string Producer { get; set; }
        public decimal Price { get; set; }
        
        public int ReleaseDate { get; set; }
    }

}
