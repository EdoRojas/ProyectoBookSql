using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWeb.AccesoDatos.Data.Repository;
using BookWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class RubrosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public RubrosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rubros rubros)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Rubro.Add(rubros);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(rubros);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            Rubros rubros = new Rubros();
            rubros = _contenedorTrabajo.Rubro.Get(id);
            if (rubros == null)
            {
                return NotFound();
            }

            return View(rubros);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Rubros rubros)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Rubro.Update(rubros);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(rubros);
        }



        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Rubro.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Rubro.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando categoria" });
            }

            _contenedorTrabajo.Rubro.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoría borrada correctamente" });
        }

        #endregion





    }
}