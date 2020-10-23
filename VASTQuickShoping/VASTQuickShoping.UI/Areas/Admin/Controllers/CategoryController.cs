using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using VASTQuickShoping.Manager;
using VASTQuickShoping.Models.Domain;
using VASTQuickShoping.UI.Common;

namespace VASTQuickShoping.UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var data = new CategoryManager().GetAll(true);
            return View(data);
        }

        [HttpGet]
        public ActionResult Insertar()
        {
            ViewBag.op =CRUD.Insertar.ToString();
            return View("Formulario", new Category());//un objeto categorua para que el objeto no quede nulo
        }
        [HttpPost]
        public ActionResult Insertar(Category obj)
        {
            if (ModelState.IsValid)
            {
                int rpta = new CategoryManager().Insert(obj);//despues de ingreesar el dato nos dirija al index
                return RedirectToAction("Index");
            }
            else
            {
                return View("Formulario", obj);//que lo muestre los datos que el usuario mismo a ingresado
            }
        }


        [HttpGet]
        public ActionResult Modificar(int id)
        {
            ViewBag.op = CRUD.Modificar.ToString();
            return View("Formulario", new  CategoryManager().GetT(id));//un objeto categorua para que el objeto no quede nulo
        }
        [HttpPost]
        public ActionResult Modificar(Category obj)
        {
            if (ModelState.IsValid)
            {
                int rpta = new CategoryManager().Update(obj);//despues de ingreesar el dato nos dirija al index
                return RedirectToAction("Index");
            }
            else
            {
                return View("Formulario", obj);//que lo muestre los datos que el usuario mismo a ingresado
            }
        }



        [HttpGet]
        public ActionResult Eliminar(int id)
        {
           //un objeto categorua para que el objeto no quede nulo
            _ = new CategoryManager().Delete(id);
            return RedirectToAction("index");

        }

    }
}