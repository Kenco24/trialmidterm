using trialmidterm.Data.Models;
using trialmidterm.Services.DTOs;

namespace trialmidterm.Data.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
        Task<RoomDto> GetRoomByIdAsync(int id);
        Task CreateRoomAsync(RoomDto roomDto);
        Task UpdateRoomAsync(int id, RoomDto roomDto);
        Task DeleteRoomAsync(int id);
    }

}
