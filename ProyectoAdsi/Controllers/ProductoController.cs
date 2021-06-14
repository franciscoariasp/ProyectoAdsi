using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoAdsi.Models;

namespace ProyectoAdsi.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {

                return View(db.producto.ToList());
            }
        }


        public static string NombreProveedor(int idProveedor)
        {
            using (var db = new inventario2021Entities())
            {
                return db.proveedor.Find(idProveedor).nombre;
            }
        }

        public ActionResult ListarProveedores()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.proveedor.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(producto newProducto)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {

                    db.producto.Add(newProducto);
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
                producto productoDetalle = db.producto.Where(a => a.id == id).FirstOrDefault();
                return View(productoDetalle);
            }

        }

        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var productDelete = db.producto.Find(id);
                db.producto.Remove(productDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit (int id)
           
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    producto producto = db.producto.Where(a => a.id == id).FirstOrDefault();
                    return View(producto);
                }
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
    }
}
    

