using Microsoft.EntityFrameworkCore;
using ConcertBooking_Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConcertBooking_Repository.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):base(option)
        {

        }
        public DbSet<Concert>? concertTbl { get; set; }
        public DbSet<Booking> bookingTbl { get; set; }
        public DbSet<Artist>? artistTbl { get; set; }
        public DbSet<Ticket>? ticketTbl { get; set; }
        public DbSet<Venue>? VenueTbl { get; set; }
    }
}
