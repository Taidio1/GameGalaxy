using GameGalaxy.Controllers;
using GameGalaxy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

public class GamesController : Controller
{
    private readonly JsonFileContext _context;

    public GamesController(IConfiguration configuration)
    {
        var filePath = configuration["JsonFilePath"];
        _context = new JsonFileContext(Path.Combine(Directory.GetCurrentDirectory(), filePath));
    }

    public IActionResult Index()
    {
        var games = _context.GetGames();
        return View(games);
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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Game game)
    {
        if (ModelState.IsValid)
        {
            _context.AddGame(game);
            return RedirectToAction(nameof(Index));
        }
        return View(game);
    }

    public IActionResult Edit(int id)
    {
        var game = _context.GetGameById(id);
        if (game == null)
        {
            return NotFound();
        }
        return View(game);
    }

    [HttpPost]
    public IActionResult Edit(Game game)
    {
        if (ModelState.IsValid)
        {
            _context.UpdateGame(game);
            return RedirectToAction(nameof(Index));
        }
        return View(game);
    }

    public IActionResult Delete(int id)
    {
        var game = _context.GetGameById(id);
        if (game == null)
        {
            return NotFound();
        }
        return View(game);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _context.DeleteGame(id);
        return RedirectToAction(nameof(Index));
    }
}
