using BookingEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingEntityFramework.Infrastructure
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Room> Room { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //if(!Database.CanConnect())
            //{
                Database.EnsureDeleted();
                Database.EnsureCreated();
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasData(
                [
                    new() { Id = 1, Capacity = 2, IsAvailable = true, PricePerNight = 100, RoomNumber = "0001"},
                    new() { Id = 2, Capacity = 3, IsAvailable = false, PricePerNight = 400, RoomNumber = "0002"},
                    new() { Id = 3, Capacity = 1, IsAvailable = false, PricePerNight = 500, RoomNumber = "0003"},
                    new() { Id = 4, Capacity = 1, IsAvailable = false, PricePerNight = 700, RoomNumber = "0004"},
                    new() { Id = 5, Capacity = 4, IsAvailable = true, PricePerNight = 1200, RoomNumber = "0005"}
                ]);

            modelBuilder.Entity<Customer>().HasData(
                [
                    new() { Id = 1, Name = "Arnold", Surname = "Schwarzenegger", Email = "Terminator800@gmail.com", Phone = "9110903", Birthday = new DateOnly(1947, 7, 30) },
                    new() { Id = 2, Name = "Johnny", Surname = "Depp", Email = "CaptainJack@gmail.com", Phone = "9111204", Birthday = new DateOnly(1963, 6, 9) },
                    new() { Id = 3, Name = "Jason", Surname = "Statham", Email = "Transporter@gmail.com", Phone = "9111315", Birthday = new DateOnly(1967, 7, 26) }
                ]);

            modelBuilder.Entity<Booking>().HasData(
                [
                    new() { Id = 1, TotalPrice = 5400,
                            BookingDate = new DateTime(2024, 10, 20),
                            CheckInDate = new DateTime(2024, 10, 23),
                            CheckOutDate = new DateTime(2024, 10, 27),
                            RoomId = 1,
                            CustomerId = 1
                        },
                    new() { Id = 2, TotalPrice = 3200,
                            BookingDate = new DateTime(2024, 11, 1),
                            CheckInDate = new DateTime(2024, 11, 3),
                            CheckOutDate = new DateTime(2024, 11, 6),
                            RoomId = 2,
                            CustomerId = 2
                        },
                    new() { Id = 3, TotalPrice = 4500,
                            BookingDate = new DateTime(2024, 11, 5),
                            CheckInDate = new DateTime(2024, 11, 7),
                            CheckOutDate = new DateTime(2024, 11, 10),
                            RoomId = 3,
                            CustomerId = 3
                        },
                    new() { Id = 4, TotalPrice = 6100,
                            BookingDate = new DateTime(2024, 12, 10),
                            CheckInDate = new DateTime(2024, 12, 15),
                            CheckOutDate = new DateTime(2024, 12, 20),
                            RoomId = 4,
                            CustomerId = 1
                        },
                    new() { Id = 5, TotalPrice = 2750,
                            BookingDate = new DateTime(2024, 12, 20),
                            CheckInDate = new DateTime(2024, 12, 22),
                            CheckOutDate = new DateTime(2024, 12, 24),
                            RoomId = 5,
                            CustomerId = 2
                        },
                    new() { Id = 6, TotalPrice = 3900,
                            BookingDate = new DateTime(2025, 1, 2),
                            CheckInDate = new DateTime(2025, 1, 5),
                            CheckOutDate = new DateTime(2025, 1, 8),
                            RoomId = 1,
                            CustomerId = 3
                        }
                ]);
        }
    }
}
