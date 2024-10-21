using BookingEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BookingEntityFramework.Infrastructure.EntityTypeConfiguration
{
    internal class RoomEntityTypeConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms", modelBuilder =>
            {
                modelBuilder.HasCheckConstraint(
                    name: "CK_Room_Price_Range",
                    sql: $"{nameof(Room.PricePerNight)} >= 0 AND {nameof(Room.PricePerNight)} <= 10000");
            });

            builder.HasKey(r =>  r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Id).HasColumnType("bigint");
            builder.Property(r => r.PricePerNight).HasColumnType("money");
            builder.Property(r => r.IsAvailable).HasColumnType("bit");
            builder.Property(r => r.RoomNumber).HasMaxLength(7);
            builder.HasIndex(r => r.RoomNumber).IsUnique();


            builder
                .HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
