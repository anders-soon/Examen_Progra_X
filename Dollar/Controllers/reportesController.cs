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
    public class reportesController : Controller
    {
        private DollarEntities db = new DollarEntities();

        // GET: reportes
        public ActionResult Index()
        {
            var reportes = db.reportes.Include(r => r.cliente).Include(r => r.servicios1);
            return View(reportes.ToList());
        }

        // GET: reportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reportes reportes = db.reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // GET: reportes/Create
        public ActionResult Create()
        {
            ViewBag.clientes = new SelectList(db.cliente, "id_cliente", "nombre");
            ViewBag.servicios = new SelectList(db.servicios, "id_servicios", "tipo_servicio");
            return View();
        }

        // POST: reportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reporte,clientes,servicios")] reportes reportes)
        {
            if (ModelState.IsValid)
            {
                db.reportes.Add(reportes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clientes = new SelectList(db.cliente, "id_cliente", "nombre", reportes.clientes);
            ViewBag.servicios = new SelectList(db.servicios, "id_servicios", "tipo_servicio", reportes.servicios);
            return View(reportes);
        }

        // GET: reportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reportes reportes = db.reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientes = new SelectList(db.cliente, "id_cliente", "nombre", reportes.clientes);
            ViewBag.servicios = new SelectList(db.servicios, "id_servicios", "tipo_servicio", reportes.servicios);
            return View(reportes);
        }

        // POST: reportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reporte,clientes,servicios")] reportes reportes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clientes = new SelectList(db.cliente, "id_cliente", "nombre", reportes.clientes);
            ViewBag.servicios = new SelectList(db.servicios, "id_servicios", "tipo_servicio", reportes.servicios);
            return View(reportes);
        }

        // GET: reportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reportes reportes = db.reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // POST: reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reportes reportes = db.reportes.Find(id);
            db.reportes.Remove(reportes);
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
