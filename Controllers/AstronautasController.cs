using Microsoft.AspNetCore.Mvc;
using AgenciaEspacialVelasquezX.Models;

namespace AgenciaEspacialVelasquezX.Controllers;

public class AstronautasController : Controller
{
    private static List<Astronauta> _astronautas = new();
    private static int _nextId = 1;

    public IActionResult Index()
    {
        return View(_astronautas);
    }

    public IActionResult Registrar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Registrar(Astronauta astronauta)
    {
        if (ModelState.IsValid)
        {
            astronauta.Id = _nextId++;
            _astronautas.Add(astronauta);
            TempData["Mensaje"] = $"¡Astronauta {astronauta.Nombre} registrado con éxito!";
            return RedirectToAction(nameof(Index));
        }
        return View(astronauta);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Eliminar(int id)
    {
        var astronauta = _astronautas.FirstOrDefault(a => a.Id == id);
        if (astronauta != null)
        {
            _astronautas.Remove(astronauta);
            TempData["Mensaje"] = "Astronauta eliminado correctamente.";
        }
        return RedirectToAction(nameof(Index));
    }
}