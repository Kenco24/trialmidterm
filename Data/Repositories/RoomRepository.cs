using Microsoft.EntityFrameworkCore;

using trialmidterm.Data.Interfaces;
using trialmidterm.Data.Models;

using trialmidterm.Services.DTOs;

namespace trialmidterm.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
        {
            var rooms = await _context.Room.ToListAsync();
            return rooms.Select(room => new RoomDto
            {
                Id = room.Id,
                Number = room.Number,
                Floor = room.Floor,
                Type = room.Type
            });
        }

        public async Task<RoomDto> GetRoomByIdAsync(int id)
        {
            var room = await _context.Room.FindAsync(id);
            return new RoomDto
            {
                Id = room.Id,
                Number = room.Number,
                Floor = room.Floor,
                Type = room.Type
            };
        }

        public async Task CreateRoomAsync(RoomDto roomDto)
        {
            var room = new Room
            {
                Number = roomDto.Number,
                Floor = roomDto.Floor,
                Type = roomDto.Type
            };
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomAsync(int id, RoomDto roomDto)
        {
            var existingRoom = await _context.Room.FindAsync(id);
            if (existingRoom == null)
            {
                // Handle not found
                return;
            }

            existingRoom.Number = roomDto.Number;
            existingRoom.Floor = roomDto.Floor;
            existingRoom.Type = roomDto.Type;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                // Handle not found
                return;
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
