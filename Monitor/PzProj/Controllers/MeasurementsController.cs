using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using PzProj.Models;

namespace PzProj.Controllers
{
    public class MeasurementsController
     : ApiController
    {
        private PzProjContext db = new PzProjContext();

        // GET api/Measurements     
        public IQueryable<Measurements> GetMeasurements()
        {
            return db.Measurements;
        }

        // GET api/Hosts/5
        [ResponseType(typeof(Measurements))]
        public IHttpActionResult GetMeasurements(int id)
        {
            Measurements ms = db.Measurements.Find(id);
            if (ms == null)
            {
                return NotFound();
            }

            return Ok(ms);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HostsExists(int id)
        {
            return db.Hosts.Count(e => e.id == id) > 0;
        }
    }
}