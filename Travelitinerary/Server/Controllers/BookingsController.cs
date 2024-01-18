
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelitinerary.Server.IRepository;
using Travelitinerary.Shared.Domain;

namespace Travelitinerary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public BookingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _unitOfWork.Bookings.GetAll(includes: q => q.Include(x => x.Itinerary).Include(x => x.Customer));
            return Ok(bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetBooking(int id)
        {
            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);

            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }


        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Bookings.Update(booking);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!await BookingExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            if (_unitOfWork.Bookings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bookings'  is null.");
            }


            await _unitOfWork.Bookings.Insert(booking);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);

        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (_unitOfWork.Bookings == null)
            {
                return NotFound();
            }
            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            await _unitOfWork.Bookings.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        public async Task<bool> BookingExists(int id)

        {
            var booking = await _unitOfWork.Bookings.GetAll(includes: q => q.Include(x =>x.Itinerary).Include(x => x.Customer));
            return booking != null;
        }
    }

}
