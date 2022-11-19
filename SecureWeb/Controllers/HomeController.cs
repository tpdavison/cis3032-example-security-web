using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SecureWeb.Models;
using SecureWeb.Services.Values;

namespace SecureWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IValuesService _values;

    public HomeController(ILogger<HomeController> logger,
                          IValuesService values)
    {
        _logger = logger;
        _values = values;
    }

    public async Task<IActionResult> Index()
    {
        var values = await _values.Get();
        return View(values);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
