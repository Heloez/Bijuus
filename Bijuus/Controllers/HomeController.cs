using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bijuus.Models;
using Bijuus.Services;

namespace Pokedex.Controllers;

public class HomeController : Controller
    {
    private readonly ILogger<HomeController> _logger;
    private readonly IBijuService _bijuService;
    public HomeController(ILogger<HomeController> logger, IBijuService bijuService)
    {
        _logger = logger;
        _bijuService = bijuService;
    }
    public IActionResult Index(string tipo)
    {
        var biju = _bijuService.GetBijuusDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(biju);
    }
    public IActionResult Details(int Numero)
    {
        var personagem = _bijuService.GetDetailedPersonagem(Numero);
        return View(personagem);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current.Id
                    ?? HttpContext.TraceIdentifier });
    }
}
