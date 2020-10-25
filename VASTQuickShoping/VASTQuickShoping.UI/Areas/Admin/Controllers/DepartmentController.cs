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
    public class DepartmentController : Controller
    {
        // GET: Admin/Department
        public ActionResult Index()
        {
            var data = new DepartmentManager().GetAll(true);
            return View(data);
        }


        [HttpGet]
        public ActionResult Insertar()
        {
            ViewBag.op = CRUD.Insertar.ToString();
            return View("Formulario4", new Department());//un objeto categorua para que el objeto no quede nulo
        }
        [HttpPost]
        public ActionResult Insertar(Department obj)
        {
            if (ModelState.IsValid)
            {
                int rpta = new DepartmentManager().Insert(obj);//despues de ingreesar el dato nos dirija al index
                return RedirectToAction("Index");
            }
            else
            {
                return View("Formulario4", obj);//que lo muestre los datos que el usuario mismo a ingresado
            }
        }


        [HttpGet]
        public ActionResult Modificar(int id)
        {
            ViewBag.op = CRUD.Modificar.ToString();
            return View("Formulario4", new DepartmentManager().Get(id));//un objeto categorua para que el objeto no quede nulo
        }
        [HttpPost]
        public ActionResult Modificar(Department obj)
        {
            if (ModelState.IsValid)
            {
                int rpta = new DepartmentManager().Update(obj);//despues de ingreesar el dato nos dirija al index
                return RedirectToAction("Index");
            }
            else
            {
                return View("Formulario4", obj);//que lo muestre los datos que el usuario mismo a ingresado
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            //un objeto categorua para que el objeto no quede nulo
            _ = new DepartmentManager().Delete(id);
            return RedirectToAction("index");

        }


    }

        }