using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VacationAdd.Data;
using VacationAdd.Data.Models;
using VacationApp.Services.Core.Interface;
using VacationApp.ViewModels.Vacation;

namespace VacationApp.Services.Core
{
    public class VacationService : IVacationService
    {
        private readonly VacationAddDbContext Dbcontext;
        private readonly UserManager<IdentityUser> userManager;

        public VacationService(VacationAddDbContext pDbcontext, UserManager<IdentityUser> usermanager)
        {
            this.Dbcontext = pDbcontext;
            this.userManager = usermanager;
        }

        public async Task<bool> AddReservationModel(string Userid, AddReservation reservationmodel)
        {

            try
            {


                bool operationResult = false;

                IdentityUser? user1 = await this.userManager.FindByIdAsync(Userid);

                //string? UserId = this.GetUserId();
                int idroom = int.Parse(reservationmodel.RoomId);
                var Room = this.Dbcontext.Rooms.FindAsync(idroom);

                if (user1 != null)
                {
                    Reservation reservation1 = new Reservation()
                    {
                        StartDate = DateTime.ParseExact(reservationmodel.StartDate,"yyyy-MM-dd", CultureInfo.InvariantCulture ,DateTimeStyles.None),

                        EndDate = DateTime.ParseExact(reservationmodel.EndDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None),
                        AdultsCount = reservationmodel.AdultsCount,

                        ChildrenCount = reservationmodel.ChildrenCount,
                        GuestId = Userid,

                        //Guest { get; set; } = null!;

                        RoomId = int.Parse(reservationmodel.RoomId),
                        HotelId = int.Parse(reservationmodel.HotelId),
                        FirstName = reservationmodel.GuestFirstName,
                        LastName = reservationmodel.LastNameG,
                        DateOfBirth = DateTime.ParseExact(reservationmodel.DateofBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None),
                        Address = reservationmodel.GuestAddress,
                        Email = reservationmodel.GuestEmail,
                        NumberOfPhone = reservationmodel.GuestPhoneNumber
                      
                    };

                    //Guest guest = new Guest()
                    //{
                    //    IdGuest= Userid,
                    //    FirstName = reservationmodel.GuestFirstName,
                    //    LastName = reservationmodel.LastNameG,
                    //    DateOfBirth = DateTime.ParseExact(reservationmodel.DateofBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None),
                    //    Address = reservationmodel.GuestAddress,
                    //    Email = reservationmodel.GuestEmail,
                    //    NumberOfPhone = reservationmodel.GuestPhoneNumber


                    //};

                    //UserReservation reservation = new UserReservation()
                    //{
                    //    Reservation= reservation1,
                    //    User=guest
                    //}


                    await this.Dbcontext.Reservations.AddAsync(reservation1);
                   // await this.Dbcontext.Guests.AddAsync(guest);

                    await this.Dbcontext.SaveChangesAsync();
                    operationResult = true;

                };
            



                return operationResult;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<IEnumerable<AllHotelsIndexViewModel>> GetAllHotelsAsync(string? UserId)
        {
            IEnumerable<AllHotelsIndexViewModel> allhotels = await Dbcontext.Hotels
                .AsNoTracking()
                .Select
                (h => new AllHotelsIndexViewModel()
                {
                    IdHotel = h.IdHotel,
                    HotelName = h.HotelName,
                    Stars = h.Stars,
                    HotelInfo = h.HotelInfo,
                    NumberofRooms = h.NumberofRooms,
                    ImageUrl = h.ImageUrl
                }).ToListAsync();

            return allhotels;
            
          //  throw new NotImplementedException();
        }

        public async Task<DetailsHotelIndexViewModel?> GetHotelDetailsAsync(int? id, string? UserId)
        {

            DetailsHotelIndexViewModel? hoteldetails = null;
            Hotel? CurrentDetailshotel = await Dbcontext.Hotels
                .Include(h=> h.Town)
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.IdHotel == id.Value);


            if (CurrentDetailshotel !=null)
            {
                 hoteldetails = new DetailsHotelIndexViewModel()
                {
                    IdHotel= CurrentDetailshotel.IdHotel,
                    HotelName = CurrentDetailshotel.HotelName,
                    Stars = CurrentDetailshotel.Stars,
                    NumberofRooms = CurrentDetailshotel.NumberofRooms,
                    ImageUrl = CurrentDetailshotel.ImageUrl,
                    HotelInfo = CurrentDetailshotel.HotelInfo,
                    TownName = CurrentDetailshotel.Town.NameTown

                };

            }

            return hoteldetails;

            //throw new NotImplementedException();
        }

        //public async Task<IEnumerable<RoomViewModel>> RoomViewDataAsync()
        //{

        //    var allrooms = await Dbcontext.Rooms.AsNoTracking()
        //         .Select(r => new RoomViewModel()
        //         {
        //             Id = r.IdRoom,
        //             RoomType = r.NameRoom
        //         }
        //       ).ToListAsync();


        //    return allrooms;
        //  //  throw new NotImplementedException();
        //}

       public async Task<IEnumerable<RoomViewModel>> RoomViewDataAsync()
        {

            IEnumerable<RoomViewModel> allrooms = await Dbcontext.Rooms
             .AsNoTracking()
             .Select(r => new RoomViewModel()
             {
                 Id = r.IdRoom,
                 RoomType = r.NameRoom
             }
           ).ToListAsync();


            return allrooms;
        }

      



        //public async Task<IEnumerable<AllVacationsIndexViewModel>> GetAllVacationaAsync()
        //   {

        //     IEnumerable<AllVacationsIndexViewModel> allMovies = await this.Dbcontext
        //       .Vacations
        //       .AsNoTracking()
        //       .Select(m => new AllVacationsIndexViewModel()
        //       {
        //           Id = m.Id.ToString(),                                         
        //           Title = m.Title,
        //           ImgUrl = m.ImgUrl,
        //           Info = m.Info,
        //           Details = m.Details,
        //           StartDate = m.StartDate.ToString("yyyy-MM-dd"),
        //           EnddDate = m.EnddDate.ToString("yyyy-MM-dd")

        //       })
        //       .ToListAsync();


        //     return allMovies;
        //   }
    }
}
