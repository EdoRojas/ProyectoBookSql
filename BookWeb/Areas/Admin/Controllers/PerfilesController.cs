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
    public class PerfilesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public PerfilesController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(Perfiles perfiles)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Perfiles.Add(perfiles);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(perfiles);
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            Perfiles perfiles = new Perfiles();
            perfiles = _contenedorTrabajo.Perfiles.Get(id);
            if (perfiles == null)
            {
                return NotFound();
            }

            return View(perfiles);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Perfiles perfiles)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Perfiles.Update(perfiles);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(perfiles);
        }



        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Perfiles.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Perfiles.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando categoria" });
            }

            _contenedorTrabajo.Perfiles.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoría borrada correctamente" });
        }

        #endregion


    }
}