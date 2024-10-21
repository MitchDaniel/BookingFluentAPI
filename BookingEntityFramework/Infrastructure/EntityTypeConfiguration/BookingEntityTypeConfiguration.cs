using BookingEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingEntityFramework.Infrastructure.EntityTypeConfiguration
{
    internal class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings", modelBuilder =>
            {
                modelBuilder.HasCheckConstraint(
                    name: "CK_Booking_Total_Price_Range",
                    sql: $"{nameof(Booking.TotalPrice)} >= 0 AND {nameof(Booking.TotalPrice)} <= 100000");
            });

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.BookingDate).HasColumnType("datetime");
            builder.Property(b => b.CheckInDate).HasColumnType("datetime");
            builder.Property(b => b.CheckOutDate).HasColumnType("datetime");
            builder.Property(b => b.TotalPrice).HasColumnType("money");
            builder.Property(b => b.Id).HasColumnType("bigint");
            

            builder
                .HasOne(b => b.Room)
                .WithMany(b => b.Bookings)
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
