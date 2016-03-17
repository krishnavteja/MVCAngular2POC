using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using MVCAngular2POC.Models;
using System;

namespace MVCAngular2POC.Controllers
{
    [Produces("application/json")]
    [Route("api/Hotels")]
    public class HotelsController : Controller
    {
        private ApplicationDbContext _context;

        public HotelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public IEnumerable<Hotel> GetHotels()
        {
            return _context.Hotels;
        }

        // GET: api/Hotels/5
        [HttpGet("{id}", Name = "GetHotel")]
        public IActionResult GetHotel([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Hotel hotel = _context.Hotels.Single(m => m.Id == id);

            if (hotel == null)
            {
                return HttpNotFound();
            }

            return Ok(hotel);
        }

        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public IActionResult PutHotel(Guid id, [FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != hotel.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Hotels
        [HttpPost]
        public IActionResult PostHotel([FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Hotels.Add(hotel);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HotelExists(hotel.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Hotel hotel = _context.Hotels.Single(m => m.Id == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            _context.Hotels.Remove(hotel);
            _context.SaveChanges();

            return Ok(hotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelExists(Guid id)
        {
            return _context.Hotels.Count(e => e.Id == id) > 0;
        }
    }
}