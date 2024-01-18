using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelitinerary.Server.IRepository;
using Travelitinerary.Shared.Domain;

namespace Travelitinerary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _unitOfWork.Hotels.GetAll();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Hotels.Update(hotel);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            if (_unitOfWork.Hotels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Hotels' is null.");
            }

            await _unitOfWork.Hotels.Insert(hotel);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (_unitOfWork.Hotels == null)
            {
                return NotFound();
            }

            var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            await _unitOfWork.Hotels.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        public async Task<bool> HotelExists(int id)
        {
            var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id);
            return hotel != null;
        }
    }
}
