using System.Collections.Generic;
using System.Threading.Tasks;
using trialmidterm.Data.Interfaces;
using trialmidterm.Services.DTOs;


namespace trialmidterm.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<IEnumerable<GuestDto>> GetAllGuestsAsync()
        {
            return await _guestRepository.GetAllGuestsAsync();
        }

        public async Task<GuestDto> GetGuestByIdAsync(int id)
        {
            return await _guestRepository.GetGuestByIdAsync(id);
        }

        public async Task CreateGuestAsync(GuestDto guestDto)
        {
            await _guestRepository.CreateGuestAsync(guestDto);
        }

        public async Task UpdateGuestAsync(int id, GuestDto guestDto)
        {
            await _guestRepository.UpdateGuestAsync(id, guestDto);
        }

        public async Task DeleteGuestAsync(int id)
        {
            await _guestRepository.DeleteGuestAsync(id);
        }
    }
}
