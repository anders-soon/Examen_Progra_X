using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Dollar.Models;

namespace Dollar.Controllers
{
    public class reportesApiController : ApiController
    {
        private DollarEntities db = new DollarEntities();

        // GET: api/reportesApi
        public IQueryable<reportes> Getreportes()
        {
            return db.reportes;
        }

        // GET: api/reportesApi/5
        [ResponseType(typeof(reportes))]
        public IHttpActionResult Getreportes(int id)
        {
            reportes reportes = db.reportes.Find(id);
            if (reportes == null)
            {
                return NotFound();
            }

            return Ok(reportes);
        }

        // PUT: api/reportesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putreportes(int id, reportes reportes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reportes.id_reporte)
            {
                return BadRequest();
            }

            db.Entry(reportes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reportesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/reportesApi
        [ResponseType(typeof(reportes))]
        public IHttpActionResult Postreportes(reportes reportes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.reportes.Add(reportes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reportes.id_reporte }, reportes);
        }

        // DELETE: api/reportesApi/5
        [ResponseType(typeof(reportes))]
        public IHttpActionResult Deletereportes(int id)
        {
            reportes reportes = db.reportes.Find(id);
            if (reportes == null)
            {
                return NotFound();
            }

            db.reportes.Remove(reportes);
            db.SaveChanges();

            return Ok(reportes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool reportesExists(int id)
        {
            return db.reportes.Count(e => e.id_reporte == id) > 0;
        }
    }
}