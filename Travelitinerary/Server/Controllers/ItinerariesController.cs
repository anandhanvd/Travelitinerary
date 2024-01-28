
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelitinerary.Server.IRepository;
using Travelitinerary.Shared.Domain;

namespace Travelitinerary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItinerariesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ItinerariesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Itineraries
        [HttpGet]
        public async Task<IActionResult> GetItineraries()
        {
            var itineraries = await _unitOfWork.Itineraries.GetAll(includes: q => q.Include(x => x.Flight).Include(x => x.Hotel).Include(x => x.Staff));
            return Ok(itineraries);
        }

        // GET: api/Itineraries/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetItinerary(int id)
        {
            var itinerary = await _unitOfWork.Itineraries.Get(q => q.Id == id);

            if (itinerary == null)
            {
                return NotFound();
            }
            return Ok(itinerary);
        }


        // PUT: api/Itineraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerary(int id, Itinerary itinerary)
        {
            if (id != itinerary.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Itineraries.Update(itinerary);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!await ItineraryExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Itineraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itinerary>> PostItinerary(Itinerary itinerary)
        {
            if (_unitOfWork.Itineraries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Itineraries'  is null.");
            }


            await _unitOfWork.Itineraries.Insert(itinerary);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetItinerary", new { id = itinerary.Id }, itinerary);

        }

        // DELETE: api/Itineraries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItinerary(int id)
        {
            if (_unitOfWork.Itineraries == null)
            {
                return NotFound();
            }
            var itinerary = await _unitOfWork.Itineraries.Get(q => q.Id == id);
            if (itinerary == null)
            {
                return NotFound();
            }

            await _unitOfWork.Itineraries.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        public async Task<bool> ItineraryExists(int id)

        {
            var itinerary = await _unitOfWork.Itineraries.Get(q => q.Id == id);
            return itinerary != null;
        }
    }

}
