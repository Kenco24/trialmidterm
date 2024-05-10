using Microsoft.EntityFrameworkCore;
using AutoMapper;
using trialmidterm.Data.Interfaces;
using trialmidterm.Data.Models;
using trialmidterm.Services.DTOs;

namespace trialmidterm.Data.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly AppDbContext _context;

        public GuestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GuestDto>> GetAllGuestsAsync()
        {
            var guests = await _context.Guest.ToListAsync();
            return guests.Select(guest => new GuestDto
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                DOB = guest.DOB,
                Address = guest.Address,
                Nationality = guest.Nationality,
                CheckInDate = guest.CheckInDate,
                CheckOutDate = guest.CheckOutDate,
                RoomId = guest.RoomId
            });
        }

        public async Task<GuestDto> GetGuestByIdAsync(int id)
        {
            var guest = await _context.Guest.FindAsync(id);
            return new GuestDto
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                DOB = guest.DOB,
                Address = guest.Address,
                Nationality = guest.Nationality,
                CheckInDate = guest.CheckInDate,
                CheckOutDate = guest.CheckOutDate,
                RoomId = guest.RoomId
            };
        }

        public async Task CreateGuestAsync(GuestDto guestDto)
        {
            var guest = new Guest
            {
                FirstName = guestDto.FirstName,
                LastName = guestDto.LastName,
                DOB = guestDto.DOB,
                Address = guestDto.Address,
                Nationality = guestDto.Nationality,
                CheckInDate = guestDto.CheckInDate,
                CheckOutDate = guestDto.CheckOutDate,
                RoomId = guestDto.RoomId
            };
            _context.Guest.Add(guest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGuestAsync(int id, GuestDto guestDto)
        {
            var existingGuest = await _context.Guest.FindAsync(id);
            if (existingGuest == null)
            {
                return;
            }

            existingGuest.FirstName = guestDto.FirstName;
            existingGuest.LastName = guestDto.LastName;
            existingGuest.DOB = guestDto.DOB;
            existingGuest.Address = guestDto.Address;
            existingGuest.Nationality = guestDto.Nationality;
            existingGuest.CheckInDate = guestDto.CheckInDate;
            existingGuest.CheckOutDate = guestDto.CheckOutDate;
            existingGuest.RoomId = guestDto.RoomId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuestAsync(int id)
        {
            var guest = await _context.Guest.FindAsync(id);
            if (guest == null)
            {
                return;
            }

            _context.Guest.Remove(guest);
            await _context.SaveChangesAsync();
        }
    }
}
