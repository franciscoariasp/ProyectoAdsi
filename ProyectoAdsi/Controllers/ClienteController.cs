using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoAdsi.Models;

namespace ProyectoAdsi.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
                return View(db.cliente.ToList());
        }
    }
}