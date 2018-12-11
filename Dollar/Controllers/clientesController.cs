using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dollar.Models;

namespace Dollar.Controllers
{
    public class clientesController : Controller
    {
        private DollarEntities db = new DollarEntities();

        // GET: clientes
        public ActionResult Index()
        {
            var cliente = db.cliente.Include(c => c.producto1).Include(c => c.ubicacion1);
            return View(cliente.ToList());
        }

        // GET: clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: clientes/Create
        public ActionResult Create()
        {
            ViewBag.producto = new SelectList(db.producto, "id_producto", "nombre");
            ViewBag.ubicacion = new SelectList(db.ubicacion, "id_ubicacion", "id_ubicacion");
            return View();
        }

        // POST: clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cliente,nombre,apellido,telefono,producto,ubicacion")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.producto = new SelectList(db.producto, "id_producto", "nombre", cliente.producto);
            ViewBag.ubicacion = new SelectList(db.ubicacion, "id_ubicacion", "id_ubicacion", cliente.ubicacion);
            return View(cliente);
        }

        // GET: clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.producto = new SelectList(db.producto, "id_producto", "nombre", cliente.producto);
            ViewBag.ubicacion = new SelectList(db.ubicacion, "id_ubicacion", "id_ubicacion", cliente.ubicacion);
            return View(cliente);
        }

        // POST: clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cliente,nombre,apellido,telefono,producto,ubicacion")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.producto = new SelectList(db.producto, "id_producto", "nombre", cliente.producto);
            ViewBag.ubicacion = new SelectList(db.ubicacion, "id_ubicacion", "id_ubicacion", cliente.ubicacion);
            return View(cliente);
        }

        // GET: clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cliente cliente = db.cliente.Find(id);
            db.cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
