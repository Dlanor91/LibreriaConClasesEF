using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.DTOs;
using System.Net.Http;
using Newtonsoft.Json;

namespace Libreria.MVC.Controllers
{
    public class PublicacionesController : Controller
    {
        // GET: PublicacionesController
        public ActionResult Index()
        {
            List<DTOPublicacion> dtos = new List<DTOPublicacion>();
            
            HttpClient cliente = new HttpClient();
            //PONEMOS EL ID DE AUTOR EN DURO PARA SIMPLIFICAR LA IMPLEMENTACIÓN
            //DEBERíA EXISTIR UNA VISTA PARA SELECCIONAR EL AUTOR Y ESTO HACERLO EN EL POST
            Task<HttpResponseMessage> respuesta = 
                cliente.GetAsync("http://localhost:32585/api/publicaciones/autor/1");

            respuesta.Wait();

            if (respuesta.Result.IsSuccessStatusCode)
            {
                Task<string> contenido = respuesta.Result.Content.ReadAsStringAsync();
                contenido.Wait();

                string json = contenido.Result;
                dtos = JsonConvert.DeserializeObject<List<DTOPublicacion>>(json);                
            }
            else
            {
                ViewBag.Error = "No se pudo traer las publicaciones";
            }

            return View(dtos);
        }

        // GET: PublicacionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublicacionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicacionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PublicacionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PublicacionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PublicacionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PublicacionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
