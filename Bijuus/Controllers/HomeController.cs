﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bijuus.Models;
using Bijuus.Services;

namespace Bijuus.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBijuusService _pokeService;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _pokeService
    }

    public IActionResult Index()
    {
        return View();
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
