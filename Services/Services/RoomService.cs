using System.Collections.Generic;
using System.Threading.Tasks;
using trialmidterm.Data.Interfaces;
using trialmidterm.Services.DTOs;

namespace trialmidterm.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllRoomsAsync();
        }

        public async Task<RoomDto> GetRoomByIdAsync(int id)
        {
            return await _roomRepository.GetRoomByIdAsync(id);
        }

        public async Task CreateRoomAsync(RoomDto roomDto)
        {
            await _roomRepository.CreateRoomAsync(roomDto);
        }

        public async Task UpdateRoomAsync(int id, RoomDto roomDto)
        {
            await _roomRepository.UpdateRoomAsync(id, roomDto);
        }

        public async Task DeleteRoomAsync(int id)
        {
            await _roomRepository.DeleteRoomAsync(id);
        }
    }
}
