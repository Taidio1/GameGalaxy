using GameGalaxy.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameGalaxy.Controllers
{
    public class JsonFileContext
    {
        private readonly string _filePath;

        public JsonFileContext(string filePath)
        {
            _filePath = filePath;
        }

        public void SeedData()
        {
            var games = new List<Game>
        {
            new Game { Id = 1, Name = "Game 1", Genre = "Genre 1", ReleaseDate = DateTime.Now },
            new Game { Id = 2, Name = "Game 2", Genre = "Genre 2", ReleaseDate = DateTime.Now.AddYears(-1) },
            // Dodaj więcej przykładowych gier...
        };

            // Zakładamy, że masz metodę do dodawania gier
            foreach (var game in games)
            {
                AddGame(game);
            }
        }

        public List<Game> GetGames()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Game>();
            }

            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Game>>(jsonData) ?? new List<Game>();
        }

        public void SaveGames(List<Game> games)
        {
            var jsonData = JsonConvert.SerializeObject(games, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }

        public Game GetGameById(int id)
        {
            return GetGames().FirstOrDefault(g => g.Id == id);
        }

        public void AddGame(Game game)
        {
            var games = GetGames();
            games.Add(game);
            SaveGames(games);
        }

        public void DeleteGame(int id)
        {
            var games = GetGames();
            var gameToRemove = games.FirstOrDefault(g => g.Id == id);
            if (gameToRemove != null)
            {
                games.Remove(gameToRemove);
                SaveGames(games);
            }
        }
    }
}
