﻿using System;
using System.Data;
using System.Web;
using System.Web.Mvc;
using VASTQuickShoping.Manager;
using VASTQuickShoping.Manager.Contracts;
using VASTQuickShoping.Models.Domain;
using VASTQuickShoping.UI.Common;

namespace VASTQuickShoping.UI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(bool state = true)
        {
            ViewBag.state = state;
            var data = new ProductManager().GetAllDTO(state);
            return View(data);
        }

        [HttpGet]
        public ActionResult Insertar()
        {
            ViewBag.op = CRUD.Insertar.ToString();
            ViewBag.categ =new SelectList( new CategoryManager().GetAllSimple(),"CategoryID","Name");
            ViewBag.bran =new SelectList( new BrandManager().GetAllSimple(),"BrandID","Name");
            ViewBag.siz = new SelectList(new SizeManager().GetAllSimple(), "SizeID","Name" );
            ViewBag.depar = new SelectList(new DepartmentManager().GetAllSimple(), "DepartmentID", "Name");
            ViewBag.provi = new SelectList(new ProviderManager().GetAllSimple(), "ProviderID", "Name");

            return View("Formulario", new Product());
        }

        [HttpPost]
        public ActionResult Insertar(Product obj, HttpPostedFileBase[] fileImagen)
        {
            
            ViewBag.categ = new SelectList(new CategoryManager().GetAllSimple(), "CategoryID", "Name");
            ViewBag.bran = new SelectList(new BrandManager().GetAllSimple(), "BrandID", "Name");
            ViewBag.siz = new SelectList(new SizeManager().GetAllSimple(), "SizeID", "Name");
            ViewBag.depar = new SelectList(new DepartmentManager().GetAllSimple(), "DepartmentID", "Name");
            ViewBag.provi = new SelectList(new ProviderManager().GetAllSimple(), "ProviderID", "Name");

            if (ModelState.IsValid)
            {
                int rpta = new ProductManager().Insert(obj);

                if (fileImagen != null)
                {
                    for (int i = 0; i < fileImagen.Length; i++)
                    {
                        if (fileImagen[i] != null)
                        {
                            string archivo = obj.ProductID + "_Imagen_" + (i + 1) + ".png";
                            fileImagen[i].SaveAs(Server.MapPath("~/assets/images/Product/" + archivo));
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View("Formulario", obj);
            }
            
        }

        [HttpGet]
        public ActionResult Modificar(int id)
        {
            
            ViewBag.op = CRUD.Modificar.ToString();
            ViewBag.categ = new SelectList(new CategoryManager().GetAllSimple(), "CategoryID", "Name");
            ViewBag.bran = new SelectList(new BrandManager().GetAllSimple(), "BrandID", "Name");
            ViewBag.siz = new SelectList(new SizeManager().GetAllSimple(), "SizeID", "Name");
            ViewBag.depar = new SelectList(new DepartmentManager().GetAllSimple(), "DepartmentID", "Name");
            ViewBag.provi = new SelectList(new ProviderManager().GetAllSimple(), "ProviderID", "Name");
            return View("Formulario", new ProductManager().Get(id));//un objeto categorua para que el objeto no quede nulo
        }
        [HttpPost]
        public ActionResult Modificar(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                int rpta = new ProductManager().Update(obj);//despues de ingreesar el dato nos dirija al index
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.op = CRUD.Modificar.ToString();
                ViewBag.categ = new SelectList(new CategoryManager().GetAllSimple(), "CategoryID", "Name");
                ViewBag.bran = new SelectList(new BrandManager().GetAllSimple(), "BrandID", "Name");
                ViewBag.siz = new SelectList(new SizeManager().GetAllSimple(), "SizeID", "Name");
                ViewBag.depar = new SelectList(new DepartmentManager().GetAllSimple(), "DepartmentID", "Name");
                ViewBag.provi = new SelectList(new ProviderManager().GetAllSimple(), "ProviderID", "Name");
                return View("Formulario", obj);//que lo muestre los datos que el usuario mismo a ingresado
            }
        }

        [HttpGet]

        public ActionResult Eliminar(int id)
        {
            _ = new ProductManager().Delete(id);
            return RedirectToAction("Index");
        }
    }
}