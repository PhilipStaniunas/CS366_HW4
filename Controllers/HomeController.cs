using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HW4Project.Models;

namespace HW4Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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

    [HttpGet]
    public IActionResult RGBColor(int? red, int? green, int? blue)
    {
        if (red is null || green is null || blue is null)
            return View();

        red = Math.Clamp(red.Value, 0, 255);
        green = Math.Clamp(green.Value, 0, 255);
        blue = Math.Clamp(blue.Value, 0, 255);

        string hex = $"#{red:X2}{green:X2}{blue:X2}";

        ViewData["HexColor"] = hex;
        ViewData["RGB"] = $"RGB({red}, {green}, {blue})";
        return View();
    }

    [HttpGet]
public IActionResult ColorInterpolator()
{
    return View(new ColorInterpolation());
}

[HttpPost]
public IActionResult ColorInterpolator(ColorInterpolation model)
{
    if (string.IsNullOrWhiteSpace(model.StartColor) || string.IsNullOrWhiteSpace(model.EndColor) || model.Steps <= 0)
    {
        ViewData["Message"] = "Please enter valid colors and a positive step count.";
        return View(model);
    }

    model.Interpolate();
    return View(model);
}

}
