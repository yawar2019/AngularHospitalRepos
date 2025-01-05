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
    public class RoleApiController : ApiController
    {
        private HostpitalManagementEntities db = new HostpitalManagementEntities();

        // GET: api/RoleApi
        public IQueryable<tble_Role> Gettble_Role()
        {
            return db.tble_Role;
        }

        // GET: api/RoleApi/5
        [ResponseType(typeof(tble_Role))]
        public IHttpActionResult Gettble_Role(int id)
        {
            tble_Role tble_Role = db.tble_Role.Find(id);
            if (tble_Role == null)
            {
                return NotFound();
            }

            return Ok(tble_Role);
        }

        // PUT: api/RoleApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttble_Role(int id, tble_Role tble_Role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tble_Role.RoleId)
            {
                return BadRequest();
            }

            db.Entry(tble_Role).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tble_RoleExists(id))
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

        // POST: api/RoleApi
        [ResponseType(typeof(tble_Role))]
        public IHttpActionResult Posttble_Role(tble_Role tble_Role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tble_Role.Add(tble_Role);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tble_Role.RoleId }, tble_Role);
        }

        // DELETE: api/RoleApi/5
        [ResponseType(typeof(tble_Role))]
        public IHttpActionResult Deletetble_Role(int id)
        {
            tble_Role tble_Role = db.tble_Role.Find(id);
            if (tble_Role == null)
            {
                return NotFound();
            }

            db.tble_Role.Remove(tble_Role);
            db.SaveChanges();

            return Ok(tble_Role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tble_RoleExists(int id)
        {
            return db.tble_Role.Count(e => e.RoleId == id) > 0;
        }
    }
}