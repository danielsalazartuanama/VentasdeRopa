using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VASTQuickShoping.UI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdministratorController : Controller
    {
        // GET: Admin/Administrator
        public ActionResult Index()
        {
            return View();
        }
    }
}