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
using MountainOperations.Models;

namespace MountainOperations.Controllers
{
    public class LiftAPIController : ApiController
    {
        private LiftDB db = new LiftDB();

        // GET: api/LiftAPI
        public IQueryable<Lift> GetLifts()
        {
            return db.Lifts;
        }

        // GET: api/LiftAPI/5
        [ResponseType(typeof(Lift))]
        public IHttpActionResult GetLift(int id)
        {
            Lift lift = db.Lifts.Find(id);
            if (lift == null)
            {
                return NotFound();
            }

            return Ok(lift);
        }

        // PUT: api/LiftAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLift(int id, Lift lift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lift.LiftId)
            {
                return BadRequest();
            }

            db.Entry(lift).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiftExists(id))
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

        // POST: api/LiftAPI
        [ResponseType(typeof(Lift))]
        public IHttpActionResult PostLift(Lift lift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lifts.Add(lift);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lift.LiftId }, lift);
        }

        // DELETE: api/LiftAPI/5
        [ResponseType(typeof(Lift))]
        public IHttpActionResult DeleteLift(int id)
        {
            Lift lift = db.Lifts.Find(id);
            if (lift == null)
            {
                return NotFound();
            }

            db.Lifts.Remove(lift);
            db.SaveChanges();

            return Ok(lift);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LiftExists(int id)
        {
            return db.Lifts.Count(e => e.LiftId == id) > 0;
        }
    }
}