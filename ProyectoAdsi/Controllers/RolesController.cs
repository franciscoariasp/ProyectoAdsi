using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoAdsi.Models;

namespace ProyectoAdsi.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.roles.ToList());
            }
        }
    }
}