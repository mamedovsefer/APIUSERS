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
using APIUSERS.Models;

namespace APIUSERS.Controllers
{
    public class USERSController : ApiController
    {
        private FUNCTIONEntities db = new FUNCTIONEntities();

        // GET: api/USERS
        public IQueryable<USERS> GetUSERS()
        {
            return db.USERS;
        }

        // GET: api/USERS/5
        [ResponseType(typeof(USERS))]
        public IHttpActionResult GetUSERS(int id)
        {
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return NotFound();
            }

            return Ok(uSERS);
        }

        // PUT: api/USERS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSERS(int id, USERS uSERS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSERS.ID)
            {
                return BadRequest();
            }

            db.Entry(uSERS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USERSExists(id))
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

        // POST: api/USERS
        [ResponseType(typeof(USERS))]
        public IHttpActionResult PostUSERS(USERS uSERS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USERS.Add(uSERS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uSERS.ID }, uSERS);
        }

        // DELETE: api/USERS/5
        [ResponseType(typeof(USERS))]
        public IHttpActionResult DeleteUSERS(int id)
        {
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return NotFound();
            }

            db.USERS.Remove(uSERS);
            db.SaveChanges();

            return Ok(uSERS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USERSExists(int id)
        {
            return db.USERS.Count(e => e.ID == id) > 0;
        }
    }
}