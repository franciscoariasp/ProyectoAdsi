using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ProyectoAdsi.Models;

namespace ProyectoAdsi.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            { 
                return View(db.proveedor.ToList());
        }
    }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        public static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor findUser = db.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(findUser);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(proveedor proveedorEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor user = db.proveedor.Find(proveedorEdit.id);

                    user.nombre = proveedorEdit.nombre;
                    user.apellido = proveedorEdit.apellido;
                    user.email = proveedorEdit.email;
                    user.fecha_nacimiento = proveedorEdit.fecha_nacimiento;
                    user.password = proveedorEdit.password;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                proveedor user = db.proveedor.Find(id);
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var proveedor = db.proveedor.Find(id);
                {
                    db.proveedor.Remove(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
        }
    }
}

