using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trialmidterm.Services;
using trialmidterm.Services.DTOs;

namespace trialmidterm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDto>>> GetGuests()
        {
            var guests = await _guestService.GetAllGuestsAsync();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDto>> GetGuest(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGuest(GuestDto guestDto)
        {
            await _guestService.CreateGuestAsync(guestDto);
            return CreatedAtAction(nameof(GetGuest), new { id = guestDto.Id }, guestDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGuest(int id, GuestDto guestDto)
        {
            await _guestService.UpdateGuestAsync(id, guestDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            await _guestService.DeleteGuestAsync(id);
            return NoContent();
        }
    }
}
