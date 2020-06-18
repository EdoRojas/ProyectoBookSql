using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookWeb.AccesoDatos.Data.Repository;
using BookWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class InventariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public InventariosController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
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
            InventarioVM inventvm = new InventarioVM()
            {
                Inventario = new Models.Inventario(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };

            return View(inventvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InventarioVM inventvm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (inventvm.Inventario.id == 0)
                {
                    //Nuevo Producto
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\inventarios");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    inventvm.Inventario.Urlimagen = @"\imagenes\inventarios\" + nombreArchivo + extension;
                    //inventvm.Articulo.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.Inventario.Add(inventvm.Inventario);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
            }

            inventvm.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            return View(inventvm);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            InventarioVM invetvm = new InventarioVM()
            {
                Inventario = new Models.Inventario(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };

            if (id != null)
            {
                invetvm.Inventario = _contenedorTrabajo.Inventario.Get(id.GetValueOrDefault());
            }
            return View(invetvm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InventarioVM inventvm)
        {

            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var articuloDesdeDb = _contenedorTrabajo.Inventario.Get(inventvm.Inventario.id);

                if (archivos.Count() > 0)
                {
                    //Editamos imagen
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\inventarios");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, articuloDesdeDb.Urlimagen.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    //subimos nuevamente el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    inventvm.Inventario.Urlimagen = @"\imagenes\inventarios\" + nombreArchivo + nuevaExtension;
                    //inventvm.Inventario.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.Inventario.Update(inventvm.Inventario);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Aquí es cuando la imagen ya existe y no se reemplaza
                    //Debe conservar la que ya esta en la base de datos
                    inventvm.Inventario.Urlimagen = articuloDesdeDb.Urlimagen;
                }

                _contenedorTrabajo.Inventario.Update(inventvm.Inventario);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }



        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //var articuloDesdeDb = _contenedorTrabajo.Inventario.Get(id);
            var inventarioDesdeDb = _contenedorTrabajo.Inventario.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, inventarioDesdeDb.Urlimagen.TrimStart('\\'));

            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if (inventarioDesdeDb == null)
            {
                return Json(new { success = false, message = "Error borrando artículo" });
            }

            _contenedorTrabajo.Inventario.Remove(inventarioDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Artículo borrado con éxito" });
        }



        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Inventario.GetAll() });
        }

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var objFromDb = _contenedorTrabajo.Inventario.Get(id);
        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error borrando Inventario"});
        //    }

        //    _contenedorTrabajo.Inventario.Remove(objFromDb);
        //    _contenedorTrabajo.Save();
        //    return Json(new { success = true, message = "Inventario borrado exitosamente" });
        //}

        #endregion

    }
}