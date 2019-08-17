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
using CBTWebAPI.Models;
using rating.Data;

namespace CBTWebAPI.Controllers
{
    public class UserAnswersController : ApiController
    {
        private CBTWebAPIContext db = new CBTWebAPIContext();

        // GET: api/UserAnswers
        public IQueryable<UserAnswers> GetUserAnswers()
        {
            return db.UserAnswers;
        }

        // GET: api/UserAnswers/5
        [ResponseType(typeof(UserAnswers))]
        public IHttpActionResult GetUserAnswers(int id)
        {
            UserAnswers userAnswers = db.UserAnswers.Find(id);
            if (userAnswers == null)
            {
                return NotFound();
            }

            return Ok(userAnswers);
        }

        // PUT: api/UserAnswers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAnswers(int id, UserAnswers userAnswers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAnswers.Id)
            {
                return BadRequest();
            }

            db.Entry(userAnswers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAnswersExists(id))
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

        // POST: api/UserAnswers
        [ResponseType(typeof(UserAnswers))]
        public IHttpActionResult PostUserAnswers(UserAnswers userAnswers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserAnswers.Add(userAnswers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userAnswers.Id }, userAnswers);
        }

        // DELETE: api/UserAnswers/5
        [ResponseType(typeof(UserAnswers))]
        public IHttpActionResult DeleteUserAnswers(int id)
        {
            UserAnswers userAnswers = db.UserAnswers.Find(id);
            if (userAnswers == null)
            {
                return NotFound();
            }

            db.UserAnswers.Remove(userAnswers);
            db.SaveChanges();

            return Ok(userAnswers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAnswersExists(int id)
        {
            return db.UserAnswers.Count(e => e.Id == id) > 0;
        }
    }
}