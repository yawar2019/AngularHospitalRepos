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
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DoctorApiController : ApiController
    {
        private HostpitalManagementEntities db = new HostpitalManagementEntities();

        // GET: api/DoctorApi
        public IQueryable<tbl_Doctor> Gettbl_Doctor()
        {
            return db.tbl_Doctor;
        }

        // GET: api/DoctorApi/5
        [ResponseType(typeof(tbl_Doctor))]
        public IHttpActionResult Gettbl_Doctor(int id)
        {
            tbl_Doctor tbl_Doctor = db.tbl_Doctor.Find(id);
            if (tbl_Doctor == null)
            {
                return NotFound();
            }

            return Ok(tbl_Doctor);
        }

        // PUT: api/DoctorApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Doctor(int id, tbl_Doctor tbl_Doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Doctor.DocId)
            {
                return BadRequest();
            }

            db.Entry(tbl_Doctor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_DoctorExists(id))
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

        // POST: api/DoctorApi
        [ResponseType(typeof(tbl_Doctor))]
        public IHttpActionResult Posttbl_Doctor(tbl_Doctor tbl_Doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Doctor.Add(tbl_Doctor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Doctor.DocId }, tbl_Doctor);
        }

        // DELETE: api/DoctorApi/5
        [ResponseType(typeof(tbl_Doctor))]
        public IHttpActionResult Deletetbl_Doctor(int id)
        {
            tbl_Doctor tbl_Doctor = db.tbl_Doctor.Find(id);
            if (tbl_Doctor == null)
            {
                return NotFound();
            }

            db.tbl_Doctor.Remove(tbl_Doctor);
            db.SaveChanges();

            return Ok(tbl_Doctor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_DoctorExists(int id)
        {
            return db.tbl_Doctor.Count(e => e.DocId == id) > 0;
        }
    }
}