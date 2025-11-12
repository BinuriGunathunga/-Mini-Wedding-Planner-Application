using GuestService.Models;

namespace GuestService.Data
{
    public class GuestDbContext0021
    {
        private readonly List<Guest0021> _guests = new();
        private int _nextId = 1;

        public List<Guest0021> GetAllGuests0021()
        {
            return _guests;
        }

        public List<Guest0021> GetGuestsByEventId0021(int eventId)
        {
            return _guests.Where(g => g.EventId == eventId).ToList();
        }

        public Guest0021? GetGuestById0021(int id)
        {
            return _guests.FirstOrDefault(g => g.GuestId == id);
        }

        public Guest0021 AddGuest0021(Guest0021 guest)
        {
            guest.GuestId = _nextId++;
            _guests.Add(guest);
            return guest;
        }

        public bool UpdateGuest0021(int id, Guest0021 updatedGuest)
        {
            var guest = GetGuestById0021(id);
            if (guest == null) return false;

            guest.Name = updatedGuest.Name;
            guest.Email = updatedGuest.Email;
            guest.RSVP = updatedGuest.RSVP;
            return true;
        }

        public bool DeleteGuest0021(int id)
        {
            var guest = GetGuestById0021(id);
            if (guest == null) return false;
            _guests.Remove(guest);
            return true;
        }
    }
}