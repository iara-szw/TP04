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


    bool DeDos = false;
    public IActionResult PartidaActual()
    {
  
        ViewBag.palabraActual = Partida.palabraActual;
        ViewBag.letrasFallidas = Partida.letrasFallidas;
        if (ViewBag.palabraActual.Count == 0 && !DeDos)
        {
            Partida.crearPartida(Partida.elegirPalabra());
            ViewBag.palabraActual = Partida.palabraActual;

        }
        ViewBag.intentosRestante = Partida.cantIntentos;
        ViewBag.fotoAhorcado = Partida.fotoAhorcado;
        return View();
    }
     public IActionResult ModoDos()
    {
        DeDos = true;
        return View();
    }
    public IActionResult IngresarPalabra(string palabraNueva){
                Partida.crearPartida(palabraNueva);
        
        return RedirectToAction("PartidaActual");
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
        if (Partida.partidaGanada)
        {
            return RedirectToAction("resultado");
        } else {
            return RedirectToAction("PartidaActual");
        }
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
            Partida.ReiniciarJuego();
              return View();
    }

}
