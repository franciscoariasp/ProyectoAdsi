using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(roles roles)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {

                using (var db = new inventario2021Entities())
                {
                    roles.password = RolesController.HashSHA1(roles.password);
                    db.roles.Add(roles);
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
                    roles findUser = db.roles.Where(a => a.id == id).FirstOrDefault();
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
        public ActionResult Edit(roles rolesEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    roles  user = db.roles.Find(rolesEdit.id);

                    user.nombre = rolesEdit.nombre;
                    user.apellido = rolesEdit.apellido;
                    user.email = rolesEdit.email;
                    user.fecha_nacimiento = rolesEdit.fecha_nacimiento;
                    user.password = rolesEdit.password;

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
                roles user = db.roles.Find(id);
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var roles = db.roles.Find(id);
                {
                    db.roles.Remove(roles);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
        }
    }
}