using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookWeb.AccesoDatos.Data.Repository;
using BookWeb.Models;
using BookWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class EmpresasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmpresasController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            //return View();

            EmpresaVM empvm = new EmpresaVM()
            {
                Empresas = new Models.Empresas(),
                ListaRubros = _contenedorTrabajo.Rubro.GetListaRubros()
            };

            return View(empvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empresas empresas)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                //Nuevo artículo
                string nombreArchivo = Guid.NewGuid().ToString();
                var subidas = Path.Combine(rutaPrincipal, @"imagenes\empresas");
                var extension = Path.GetExtension(archivos[0].FileName);

                using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                {
                    archivos[0].CopyTo(fileStreams);
                }

                empresas.Urlimagen = @"\imagenes\empresas\" + nombreArchivo + extension;

                _contenedorTrabajo.Empresa.Add(empresas);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var empresa = _contenedorTrabajo.Empresa.Get(id.GetValueOrDefault());
                return View(empresa);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empresas empresas)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var empresaDesdeDb = _contenedorTrabajo.Empresa.Get(empresas.idempresa);

                if (archivos.Count() > 0)
                {
                    //Nuevo artículo
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\empresas");
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, empresaDesdeDb.Urlimagen.TrimStart('\\'));
                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    //Aquí subimos nuevamente el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    empresas.Urlimagen = @"\imagenes\empresas\" + nombreArchivo + nuevaExtension;

                    _contenedorTrabajo.Empresa.Update(empresas);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Aquí es cuando la imagen ya existe se conserva la misma
                    empresas.Urlimagen = empresaDesdeDb.Urlimagen;
                }

                _contenedorTrabajo.Empresa.Update(empresas);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }






        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Empresa.GetAll() });
        }



        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Empresa.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando empresa" });
            }
            _contenedorTrabajo.Empresa.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "empresa borrado correctamente" });
        }
        #endregion



    }
}