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
        ViewBag.palabraActual = Partida.palabraActual; 
        ViewBag.letrasFallidas = Partida.letrasFallidas;
        if(ViewBag.palabraActual.Count == 0){
            Partida.crearPartida("arboleada");
             ViewBag.palabraActual = Partida.palabraActual;
            
        }
        ViewBag.intentosRestante = Partida.cantIntentos;
        return View();
    }

    
    public IActionResult arriesgarLetra(char letraNueva)
    {
        if(Partida.cantIntentos == 0){
            return RedirectToAction("resultado");
        }else{
            if(!Partida.siSeUso(letraNueva)){
                 Partida.esCorrecta(letraNueva);
            }
           
        }
        return RedirectToAction("PartidaActual");
    }
   
    public IActionResult arriesgarPalabra(string palabra)
    {
        Partida.encontroLaPalabra(palabra);

         return RedirectToAction("resultado");
    }
      public IActionResult resultado()
    {
            if(Partida.partidaGanada){
                ViewBag.resultadoPartida = "Ganaste!";
            }else{
                ViewBag.resultadoPartida = "Perdiste!";
            }
            ViewBag.intentos = 6-Partida.cantIntentos;
              ViewBag.palabra = Partida.palabra;
              return View();
    }

}
