using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserApiController : ApiController
    {
        private HostpitalManagementEntities db = new HostpitalManagementEntities();

        // GET: api/UserApi
        public IQueryable<tble_User> Gettble_User()
        {
            return db.tble_User;
        }

        // GET: api/UserApi/5
        [ResponseType(typeof(tble_User))]
        public IHttpActionResult Gettble_User(int id)
        {
            tble_User tble_User = db.tble_User.Find(id);
            if (tble_User == null)
            {
                return NotFound();
            }

            return Ok(tble_User);
        }

        // PUT: api/UserApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttble_User(int id, tble_User tble_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tble_User.UserId)
            {
                return BadRequest();
            }

            db.Entry(tble_User).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tble_UserExists(id))
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

        // POST: api/UserApi
        [ResponseType(typeof(tble_User))]
        public IHttpActionResult Posttble_User(tble_User tble_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tble_User.Add(tble_User);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tble_User.UserId }, tble_User);
        }

        // DELETE: api/UserApi/5
        [ResponseType(typeof(tble_User))]
        public IHttpActionResult Deletetble_User(int id)
        {
            tble_User tble_User = db.tble_User.Find(id);
            if (tble_User == null)
            {
                return NotFound();
            }

            db.tble_User.Remove(tble_User);
            db.SaveChanges();

            return Ok(tble_User);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tble_UserExists(int id)
        {
            return db.tble_User.Count(e => e.UserId == id) > 0;
        }
    }
}