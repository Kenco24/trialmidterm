using System.Collections.Generic;
using System.Threading.Tasks;
using trialmidterm.Services.DTOs;

namespace trialmidterm.Data.Interfaces
{
    public interface IGuestRepository
    {
        Task<IEnumerable<GuestDto>> GetAllGuestsAsync();
        Task<GuestDto> GetGuestByIdAsync(int id);
        Task CreateGuestAsync(GuestDto guestDto);
        Task UpdateGuestAsync(int id, GuestDto guestDto);
        Task DeleteGuestAsync(int id);
    }

  
}
