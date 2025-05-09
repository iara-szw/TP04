using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

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
    public IActionResult PartidaActual()
    {
        Partida.crearPartida("perro");
        ViewBag.palabraActual = Partida.devolverPalabraActual();
        ViewBag.intentosRestante = Partida.cantIntentos;
        return View();
    }
    public IActionResult arriesgarLetra(char letra)
    {
        if(Partida.cantIntentos == 0){
            return RedirectToAction("resultado");
        }else{
            if(!Partida.siSeUso(letra)){
                 Partida.esCorrecta(letra);
            }
            ViewBag.palabraActual = Partida.devolverPalabraActual();
        }
       
        return View();
    }
    public IActionResult arriesgarPalabra(string palabra)
    {
        Partida.encontroLaPalabra(palabra);
         return View("RedirectToAction");
    }
      public IActionResult resultado()
    {
            if(Partida.partidaGanada){
                ViewBag.resultadoPartida = "Ganaste";
            }else{
                ViewBag.resultadoPartida = "Perdiste";
            }
            ViewBag.intentos = 6-Partida.cantIntentos;
              ViewBag.palabraActual = Partida.devolverPalabraActual();
              return View();
    }

}
