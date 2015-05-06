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
using PzProj.Models;

namespace PzProj.Controllers
{
    public class HostsController : ApiController
    {
        private PzProjContext db = new PzProjContext();

        // GET api/Hosts
        public IQueryable<Hosts> GetHosts()
        {
            return db.Hosts;
        }

        // GET api/Hosts/5
        [ResponseType(typeof(Hosts))]
        public IHttpActionResult GetHosts(int id)
        {
            Hosts hosts = db.Hosts.Find(id);
            if (hosts == null)
            {
                return NotFound();
            }

            return Ok(hosts);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}