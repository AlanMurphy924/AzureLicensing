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
using AzureLicensing.DAL;
using ColossusLicensing.Models;

namespace AzureLicensing.Controllers
{
    public class MobileDevicesController : ApiController
    {
        private LicensingContext db = new LicensingContext();

        // GET: api/MobileDevices
        public IQueryable<MobileDevice> GetMobileDevices()
        {
            return db.MobileDevices;
        }

        // GET: api/MobileDevices/5
        [ResponseType(typeof(MobileDevice))]
        public IHttpActionResult GetMobileDevice(int id)
        {
            MobileDevice mobileDevice = db.MobileDevices.Find(id);
            if (mobileDevice == null)
            {
                return NotFound();
            }

            return Ok(mobileDevice);
        }

        // PUT: api/MobileDevices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMobileDevice(int id, MobileDevice mobileDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mobileDevice.MobileDeviceId)
            {
                return BadRequest();
            }

            db.Entry(mobileDevice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileDeviceExists(id))
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

        // POST: api/MobileDevices
        [ResponseType(typeof(MobileDevice))]
        public IHttpActionResult PostMobileDevice(MobileDevice mobileDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MobileDevices.Add(mobileDevice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mobileDevice.MobileDeviceId }, mobileDevice);
        }

        // DELETE: api/MobileDevices/5
        [ResponseType(typeof(MobileDevice))]
        public IHttpActionResult DeleteMobileDevice(int id)
        {
            MobileDevice mobileDevice = db.MobileDevices.Find(id);
            if (mobileDevice == null)
            {
                return NotFound();
            }

            db.MobileDevices.Remove(mobileDevice);
            db.SaveChanges();

            return Ok(mobileDevice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MobileDeviceExists(int id)
        {
            return db.MobileDevices.Count(e => e.MobileDeviceId == id) > 0;
        }
    }
}