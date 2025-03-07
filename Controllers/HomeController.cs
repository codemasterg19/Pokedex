using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Pokedex.Services;
using Pokedex.ViewModels;

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

    public async Task<IActionResult> Index(int page = 1)
    {
        int pageSize = 25;
        var species = await _speciesService.GetPokemonSpeciesAsync();
        int totalSpecies = species.Count;

        var speciesToDisplay = species
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var viewModel = new PokemonSpeciesListViewModel
        {
            Species = speciesToDisplay,
            PageNumber = page,
            TotalPages = (int)Math.Ceiling(totalSpecies / (double)pageSize)
        };

        return View(viewModel);
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