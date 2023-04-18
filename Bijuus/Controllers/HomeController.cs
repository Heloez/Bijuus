using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bijuus.Models;
using Bijuus.Services;

namespace Bijuus.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBijuusService _BijuusService;
     public HomeController(ILogger<HomeController> logger, IBijuusService)
    {
        _logger = logger;
        _BijuusService = _BijuusService;
    }

    public IActionResult Index(string caracteristicas)
    {
      var Bijuus = _BijuusService.BijuusDto();
        ViewData["filter"] = string.IsNullOrEmpty(caracteristicas) ? "all" : caracteristicas;
        return View(Bijuus);
    }
    public IActionResult Details(int Numero)
    {
        var Bijuus = _BijuusService.GetDetailedBijuus(Numero);
        return View(Bijuus);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
