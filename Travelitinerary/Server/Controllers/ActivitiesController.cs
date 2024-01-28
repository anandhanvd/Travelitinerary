using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelitinerary.Server.IRepository;
using Travelitinerary.Shared.Domain;

namespace Travelitinerary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _unitOfWork.Activities.GetAll();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(int id)
        {
            var activity = await _unitOfWork.Activities.Get(q => q.Id == id);

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity(int id, Activity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Activities.Update(activity);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ActivityExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity(Activity activity)
        {
            if (_unitOfWork.Activities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Activities' is null.");
            }

            await _unitOfWork.Activities.Insert(activity);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetActivity", new { id = activity.Id }, activity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            if (_unitOfWork.Activities == null)
            {
                return NotFound();
            }

            var activity = await _unitOfWork.Activities.Get(q => q.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            await _unitOfWork.Activities.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        public async Task<bool> ActivityExists(int id)
        {
            var activity = await _unitOfWork.Activities.Get(q => q.Id == id);
            return activity != null;
        }
    }
}
