using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trialmidterm.Services;
using trialmidterm.Services.DTOs;

namespace trialmidterm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoom(RoomDto roomDto)
        {
            await _roomService.CreateRoomAsync(roomDto);
            return CreatedAtAction(nameof(GetRoom), new { id = roomDto.Id }, roomDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoom(int id, RoomDto roomDto)
        {
            await _roomService.UpdateRoomAsync(id, roomDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return NoContent();
        }
    }
}
