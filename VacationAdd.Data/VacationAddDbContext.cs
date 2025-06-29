using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VacationAdd.Data.Models;

namespace VacationAdd.Data
{
    public class VacationAddDbContext: IdentityDbContext
    {
        public VacationAddDbContext(DbContextOptions<VacationAddDbContext> options)
         : base(options)
        {
        }


        public DbSet<Town> Towns { get; set; } = null!;
        public DbSet<Hotel> Hotels { get; set; } = null!;

        public DbSet<Room> Rooms { get; set; } = null!;

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<UserReservation> UserReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<Hotel>(entity =>
            {

                entity.HasKey(h => h.IdHotel);

                entity
                .HasOne(e => e.Town)
                .WithMany(e => e.Hotels)
                .HasForeignKey(e => e.TownId)
                .OnDelete(DeleteBehavior.Restrict);
               
                

            });

            builder.Entity<UserReservation>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.ReservationID });

                entity
             .HasOne(e => e.Reservation)
             .WithMany(e => e.UsersReservations)
             .HasForeignKey(e => e.ReservationID)
             .OnDelete(DeleteBehavior.Restrict);

                entity
             .HasOne(e => e.User)
             .WithMany()
             .HasForeignKey(e => e.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<Reservation>(entityres =>
            {

                entityres.HasKey(r => r.IdReservation);

                entityres.HasOne(g => g.Guest)
                        .WithMany()
                        .HasForeignKey(g => g.GuestId);

                entityres.HasOne(r => r.Room)
                      .WithMany(r => r.Reservations)
                      .HasForeignKey(r => r.RoomId);

                entityres.HasOne(h => h.Hotel)
                      .WithMany(h => h.Reservations)
                      .HasForeignKey(h => h.HotelId);


            });



            //builder.Entity<Vacation>().HasData(
            //   new Vacation {Title = "Bodrum", ImgUrl = "https://content.tui.co.uk/adamtui/2023_8/11_9/8731a3c8-4b27-4fc8-9dfb-b05b00a3b5c2/ACC_040057_TUR_01WebOriginalCompressed.jpg?i10c=img.resize(width:1080);img.resize(height:608);img.crop(width:1080%2Cheight:608)", Info = "Phasellus quam turpis, feugiat sit amet in, hendrerit in lectus. ", Details = "", StartDate = null, EnddDate = null },
            //   new Vacation {  Title = "Corfu",ImgUrl= "https://content.tui.co.uk/adamtui/2019_12/17_11/61d6945a-4392-4994-9d5c-ab2600be5197/LOC_000450_TUR_GUM_09_GUMBET_BEACHWebOriginalCompressed.jpg?i10c=img.resize(width:1080);img.crop(width:1080%2Cheight:608)", Info= "Phasellus quam turpis, feugiat sit amet in, hendrerit in lectus. ", Details = "", StartDate = null, EnddDate = null },
            //   new Vacation {  Title = "Greece", ImgUrl = "https://content.tui.co.uk/adamtui/2023_8/11_9/aacea1c8-bf73-4207-8f31-b05b00a3c879/ACC_040057_TUR_08WebOriginalCompressed.jpg?i10c=img.resize(width:488);img.crop(width:488%2Cheight:274)", Info = "Phasellus quam turpis, feugiat sit amet in, hendrerit in lectus. ", Details = "", StartDate = null, EnddDate = null }
            //   );
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
