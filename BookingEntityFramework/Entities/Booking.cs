namespace BookingEntityFramework.Entities
{
    internal class Booking
    {
        public long Id { get; set; }

        public DateTime BookingDate { get; set; }

        public long CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public long RoomId { get; set; }

        public Room? Room { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
