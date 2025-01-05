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
    public class PatientApiController : ApiController
    {
        private HostpitalManagementEntities db = new HostpitalManagementEntities();

        // GET: api/PatientApi
        public IQueryable<tbl_Patient> Gettbl_Patient()
        {
            return db.tbl_Patient;
        }

        // GET: api/PatientApi/5
        [ResponseType(typeof(tbl_Patient))]
        public IHttpActionResult Gettbl_Patient(int id)
        {
            tbl_Patient tbl_Patient = db.tbl_Patient.Find(id);
            if (tbl_Patient == null)
            {
                return NotFound();
            }

            return Ok(tbl_Patient);
        }

        // PUT: api/PatientApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Patient(int id, tbl_Patient tbl_Patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Patient.PId)
            {
                return BadRequest();
            }

            db.Entry(tbl_Patient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PatientExists(id))
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

        // POST: api/PatientApi
        [ResponseType(typeof(tbl_Patient))]
        public IHttpActionResult Posttbl_Patient(tbl_Patient tbl_Patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Patient.Add(tbl_Patient);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_PatientExists(tbl_Patient.PId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_Patient.PId }, tbl_Patient);
        }

        // DELETE: api/PatientApi/5
        [ResponseType(typeof(tbl_Patient))]
        public IHttpActionResult Deletetbl_Patient(int id)
        {
            tbl_Patient tbl_Patient = db.tbl_Patient.Find(id);
            if (tbl_Patient == null)
            {
                return NotFound();
            }

            db.tbl_Patient.Remove(tbl_Patient);
            db.SaveChanges();

            return Ok(tbl_Patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_PatientExists(int id)
        {
            return db.tbl_Patient.Count(e => e.PId == id) > 0;
        }
    }
}