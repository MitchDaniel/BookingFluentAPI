namespace BookingEntityFramework.Entities
{
    internal class Customer
    {
        public long Id { get; set; }    

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!; 

        public string Phone { get; set; } = null!;

        public DateOnly Birthday { get; set; }

        public ICollection<Booking> Bookings { get; set; } = [];
    }
}
