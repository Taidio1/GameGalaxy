using GameGalaxy.Models;
using GameGalaxy.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GameGalaxy.Controllers
{
    public class GamesController : Controller
    {
        private readonly JsonFileContext _context;

        public GamesController(JsonFileContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
        return View();
        }
     public IActionResult Details(int id)
        {
            var game = _context.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
    public IActionResult GameList()
        {
        var games = _context.GetGames();
        if (games == null)
        {
            return Problem("Nie udało się załadować danych o grach.");
        }
        return View(games);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Producer,Price,Rating,ReleaseDate,ImageUrl")] Game game)
        {
            if (ModelState.IsValid)
            {
                var games = _context.GetGames();
                game.Id = games.Count > 0 ? games.Max(g => g.Id) + 1 : 1;
                games.Add(game);
                _context.SaveGames(games);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _context.GetGameById(id.Value);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Producer,Price,Rating,ReleaseDate,ImageUrl")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var games = _context.GetGames();
                var gameIndex = games.FindIndex(g => g.Id == id);
                if (gameIndex == -1)
                {
                    return NotFound();
                }

                games[gameIndex] = game;
                _context.SaveGames(games);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }
        public IActionResult Delete(int? id)
            {
                if (id == null)
                {
                     return NotFound();
                }

        var game = _context.GetGameById(id.Value);
                if (game == null)
                {
                    return NotFound();
                }
            return View(game);
            }

        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult DeleteConfirmed(int id)
{
    var games = _context.GetGames();
    var game = games.FirstOrDefault(g => g.Id == id);
    if (game == null)
    {
        return NotFound();
    }

    games.Remove(game);
    _context.SaveGames(games);
    return RedirectToAction(nameof(GameList));
}
    }
}