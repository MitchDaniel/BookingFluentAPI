namespace BookingEntityFramework.Entities
{
    internal class Room
    {
        public long Id { get; set; } 

        public string RoomNumber { get; set; } = null!;

        public int Capacity { get; set; }

        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; }

        public ICollection<Booking> Bookings { get; set; } = [];
    }
}
