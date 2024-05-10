using System.Collections.Generic;
using System.Threading.Tasks;
using trialmidterm.Services.DTOs;

namespace trialmidterm.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
        Task<RoomDto> GetRoomByIdAsync(int id);
        Task CreateRoomAsync(RoomDto roomDto);
        Task UpdateRoomAsync(int id, RoomDto roomDto);
        Task DeleteRoomAsync(int id);
    }
}
