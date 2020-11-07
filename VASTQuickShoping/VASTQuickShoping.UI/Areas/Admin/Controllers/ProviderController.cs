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
    [Authorize(Roles = "Admin,Gerente")]
    public class ProviderController : Controller
    {
        // GET: Admin/Provider
        public ActionResult Index()
        {
            var data = new ProviderManager().GetAll(true);
            return View(data);
        }


        [HttpGet]
        public ActionResult Insertar()
        {
            ViewBag.op = CRUD.Insertar.ToString();
            return View("Formulario3", new Provider());
        }


        [HttpPost]
        public ActionResult Insertar(Provider obj)
        {
            if (ModelState.IsValid)
            {
                int rpta = new ProviderManager().Insert(obj);
                return RedirectToAction("Index");

            }
            else
            {
                return View("Formulario3", obj);
            }
        }


        [HttpGet]
        public ActionResult Modificar(int id)
        {
            ViewBag.op = CRUD.Modificar.ToString();
            return View("Formulario3", new ProviderManager().Get(id));//un objeto categorua para que el objeto no quede nulo
        }
        [HttpPost]
        public ActionResult Modificar(Provider obj)
        {
            if (ModelState.IsValid)
            {
                int rpta = new ProviderManager().Update(obj);//despues de ingreesar el dato nos dirija al index
                return RedirectToAction("Index");
            }
            else
            {
                return View("Formulario3", obj);//que lo muestre los datos que el usuario mismo a ingresado
            }



        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            //un objeto categorua para que el objeto no quede nulo
            _ = new ProviderManager().Delete(id);
            return RedirectToAction("index");

        }
    }
}