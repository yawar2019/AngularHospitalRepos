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
    public class AccountsApiController : ApiController
    {
        private HostpitalManagementEntities db = new HostpitalManagementEntities();

        // GET: api/AccountsApi
        public IQueryable<tbl_Accounts> Gettbl_Accounts()
        {
            return db.tbl_Accounts;
        }

        // GET: api/AccountsApi/5
        [ResponseType(typeof(tbl_Accounts))]
        public IHttpActionResult Gettbl_Accounts(int id)
        {
            tbl_Accounts tbl_Accounts = db.tbl_Accounts.Find(id);
            if (tbl_Accounts == null)
            {
                return NotFound();
            }

            return Ok(tbl_Accounts);
        }

        // PUT: api/AccountsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Accounts(int id, tbl_Accounts tbl_Accounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Accounts.AccId)
            {
                return BadRequest();
            }

            db.Entry(tbl_Accounts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_AccountsExists(id))
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

        // POST: api/AccountsApi
        [ResponseType(typeof(tbl_Accounts))]
        public IHttpActionResult Posttbl_Accounts(tbl_Accounts tbl_Accounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Accounts.Add(tbl_Accounts);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Accounts.AccId }, tbl_Accounts);
        }

        // DELETE: api/AccountsApi/5
        [ResponseType(typeof(tbl_Accounts))]
        public IHttpActionResult Deletetbl_Accounts(int id)
        {
            tbl_Accounts tbl_Accounts = db.tbl_Accounts.Find(id);
            if (tbl_Accounts == null)
            {
                return NotFound();
            }

            db.tbl_Accounts.Remove(tbl_Accounts);
            db.SaveChanges();

            return Ok(tbl_Accounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_AccountsExists(int id)
        {
            return db.tbl_Accounts.Count(e => e.AccId == id) > 0;
        }
    }
}