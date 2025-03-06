using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Services;

namespace Pokedex.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PokemonService _speciesService;

    public HomeController(ILogger<HomeController> logger, PokemonService speciesService)
    {
        _logger = logger;
        _speciesService = speciesService;
    }

    public async Task<IActionResult> Index()
    {
        var species = await _speciesService.GetPokemonSpeciesAsync();
        return View(species);
    }

    // Muestra el detalle de una especie (nombre e imagen)
    public async Task<IActionResult> Details(string name)
    {
        var species = await _speciesService.GetPokemonSpeciesAsync(name);
        return View(species);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}