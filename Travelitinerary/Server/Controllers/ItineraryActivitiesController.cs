
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelitinerary.Server.IRepository;
using Travelitinerary.Shared.Domain;

namespace Travelitinerary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItineraryActivitiesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ItineraryActivitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ItineraryActivities
        [HttpGet]
        public async Task<IActionResult> GetItineraryActivities()
        {
            var itineraryActivities = await _unitOfWork.ItineraryActivities.GetAll(includes: q => q.Include(x => x.Itinerary).Include(x => x.Activity));
            return Ok(itineraryActivities);
        }

        // GET: api/ItineraryActivities/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetItineraryActivity(int id)
        {
            var itineraryActivity = await _unitOfWork.ItineraryActivities.Get(q => q.Id == id);

            if (itineraryActivity == null)
            {
                return NotFound();
            }
            return Ok(itineraryActivity);
        }


        // PUT: api/ItineraryActivities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItineraryActivity(int id, ItineraryActivity itineraryActivity)
        {
            if (id != itineraryActivity.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ItineraryActivities.Update(itineraryActivity);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!await ItineraryActivityExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/ItineraryActivities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItineraryActivity>> PostItineraryActivity(ItineraryActivity itineraryActivity)
        {
            if (_unitOfWork.ItineraryActivities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ItineraryActivities'  is null.");
            }


            await _unitOfWork.ItineraryActivities.Insert(itineraryActivity);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetItineraryActivity", new { id = itineraryActivity.Id }, itineraryActivity);

        }

        // DELETE: api/ItineraryActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItineraryActivity(int id)
        {
            if (_unitOfWork.ItineraryActivities == null)
            {
                return NotFound();
            }
            var itineraryActivity = await _unitOfWork.ItineraryActivities.Get(q => q.Id == id);
            if (itineraryActivity == null)
            {
                return NotFound();
            }

            await _unitOfWork.ItineraryActivities.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        public async Task<bool> ItineraryActivityExists(int id)

        {
            var itineraryActivity = await _unitOfWork.ItineraryActivities.Get(q => q.Id == id);
            return itineraryActivity != null;
        }
    }

}
