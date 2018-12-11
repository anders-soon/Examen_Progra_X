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
    public class UbicacionsController : Controller
    {
        private DollarEntities db = new DollarEntities();

        // GET: ubicacions
        public ActionResult Index()
        {
            var ubicacion = db.ubicacion.Include(u => u.ciudad1).Include(u => u.continente1).Include(u => u.pais1);
            return View(ubicacion.ToList());
        }

        // GET: ubicacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ubicacion ubicacion = db.ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            return View(ubicacion);
        }

        // GET: ubicacions/Create
        public ActionResult Create()
        {
            ViewBag.ciudad = new SelectList(db.ciudad, "id_ciudad", "descripcion");
            ViewBag.continente = new SelectList(db.continente, "id_continente", "descripcion");
            ViewBag.pais = new SelectList(db.pais, "id_pais", "descripcion");
            return View();
        }

        // POST: ubicacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ubicacion,continente,pais,ciudad")] ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                db.ubicacion.Add(ubicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ciudad = new SelectList(db.ciudad, "id_ciudad", "descripcion", ubicacion.ciudad);
            ViewBag.continente = new SelectList(db.continente, "id_continente", "descripcion", ubicacion.continente);
            ViewBag.pais = new SelectList(db.pais, "id_pais", "descripcion", ubicacion.pais);
            return View(ubicacion);
        }

        // GET: ubicacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ubicacion ubicacion = db.ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ciudad = new SelectList(db.ciudad, "id_ciudad", "descripcion", ubicacion.ciudad);
            ViewBag.continente = new SelectList(db.continente, "id_continente", "descripcion", ubicacion.continente);
            ViewBag.pais = new SelectList(db.pais, "id_pais", "descripcion", ubicacion.pais);
            return View(ubicacion);
        }

        // POST: ubicacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ubicacion,continente,pais,ciudad")] ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ubicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ciudad = new SelectList(db.ciudad, "id_ciudad", "descripcion", ubicacion.ciudad);
            ViewBag.continente = new SelectList(db.continente, "id_continente", "descripcion", ubicacion.continente);
            ViewBag.pais = new SelectList(db.pais, "id_pais", "descripcion", ubicacion.pais);
            return View(ubicacion);
        }

        // GET: ubicacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ubicacion ubicacion = db.ubicacion.Find(id);
            if (ubicacion == null)
            {
                return HttpNotFound();
            }
            return View(ubicacion);
        }

        // POST: ubicacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ubicacion ubicacion = db.ubicacion.Find(id);
            db.ubicacion.Remove(ubicacion);
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
