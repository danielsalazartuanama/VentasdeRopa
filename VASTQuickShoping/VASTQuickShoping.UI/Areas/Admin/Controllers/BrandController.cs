using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VASTQuickShoping.Manager;
using VASTQuickShoping.Models.Domain;
using VASTQuickShoping.UI.Common;

namespace VASTQuickShoping.UI.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        
        // GET: Admin/Brand
        public ActionResult Index()
        {
            var data = new BrandManager().GetAll(true);
            return View(data);
        }

        [HttpGet]
        public ActionResult Insertar()
        {
            ViewBag.op = CRUD.Insertar.ToString();
            return View("Formulario2", new Brand());//un objeto categorua para que el objeto no quede nulo
        }
        [HttpPost]
        public ActionResult Insertar(Brand obj)
        {
            if (ModelState.IsValid)
            {
                int rpta = new BrandManager().Insert(obj);//despues de ingreesar el dato nos dirija al index
                return RedirectToAction("Index");
            }
            else
            {
                return View("Formulario2", obj);//que lo muestre los datos que el usuario mismo a ingresado
            }
        }


        [HttpGet]
        public ActionResult Modificar(int id)
        {
            ViewBag.op = CRUD.Modificar.ToString();
            return View("Formulario2", new BrandManager().Get(id));//un objeto categorua para que el objeto no quede nulo
        }
        [HttpPost]
        public ActionResult Modificar(Brand obj)
        {
            if (ModelState.IsValid)
            {
                int rpta = new BrandManager().Update(obj);//despues de ingreesar el dato nos dirija al index
                return RedirectToAction("Index");
            }
            else
            {
                return View("Formulario2", obj);//que lo muestre los datos que el usuario mismo a ingresado
            }
        }



        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            //un objeto categorua para que el objeto no quede nulo
            _ = new BrandManager().Delete(id);
            return RedirectToAction("index");

        }
    }
}