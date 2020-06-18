using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookWeb.Models;
using BookWeb.AccesoDatos.Data.Repository;
using BookWeb.Models.ViewModels;

namespace BookWeb.Controllers
{
    [Area("client")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            HomeVM homeVm = new HomeVM()
            {
                Slider = _contenedorTrabajo.Slider.GetAll(),
                ListaInventarios = _contenedorTrabajo.Inventario.GetAll()
            };
            return View(homeVm);
        }

        public IActionResult Details(int id)
        {
            var articuloDesdeDb = _contenedorTrabajo.Inventario.GetFirsOrDefault(a => a.id == id);
            return View(articuloDesdeDb);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
