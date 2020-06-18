using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWeb.AccesoDatos.Data.Repository;
using BookWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class EmpleadosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public EmpleadosController(IContenedorTrabajo contenedorTrabajo)
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
            EmpleadoVM empvm = new EmpleadoVM()
            {
                Empleados = new Models.Empleados(),
                ListaPerfiles = _contenedorTrabajo.Perfiles.GetListaPerfiles()
            };

            return View(empvm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmpleadoVM empvm)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Empleado.Add(empvm.Empleados);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(empvm);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            EmpleadoVM empvm = new EmpleadoVM()
            {
                Empleados = new Models.Empleados(),
                ListaPerfiles = _contenedorTrabajo.Perfiles.GetListaPerfiles()
            };

            if (id != null)
            {
                empvm.Empleados = _contenedorTrabajo.Empleado.Get(id.GetValueOrDefault());
            }
            return View(empvm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmpleadoVM empvm)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Empleado.Update(empvm.Empleados);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(empvm);
        }






        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Empleado.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Empleado.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Inventario" });
            }

            _contenedorTrabajo.Empleado.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Inventario borrado exitosamente" });
        }

        #endregion

    }
}