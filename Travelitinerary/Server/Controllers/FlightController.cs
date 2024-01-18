using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travelitinerary.Server.IRepository;
using Travelitinerary.Shared.Domain;

namespace Travelitinerary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlightsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _unitOfWork.Flights.GetAll();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlight(int id)
        {
            var flight = await _unitOfWork.Flights.Get(q => q.Id == id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Flights.Update(flight);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await FlightExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
            if (_unitOfWork.Flights == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Flights' is null.");
            }

            await _unitOfWork.Flights.Insert(flight);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            if (_unitOfWork.Flights == null)
            {
                return NotFound();
            }

            var flight = await _unitOfWork.Flights.Get(q => q.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            await _unitOfWork.Flights.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        public async Task<bool> FlightExists(int id)
        {
            var flight = await _unitOfWork.Flights.Get(q => q.Id == id);
            return flight != null;
        }
    }
}
