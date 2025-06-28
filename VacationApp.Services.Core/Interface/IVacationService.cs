using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationApp.ViewModels.Vacation;

namespace VacationApp.Services.Core.Interface
{
    public interface IVacationService
    {

        Task<IEnumerable<AllHotelsIndexViewModel>> GetAllHotelsAsync(string? UserId);


        Task<DetailsHotelIndexViewModel> GetHotelDetailsAsync(int? id, string? UserId);


        Task<IEnumerable<RoomViewModel>> RoomViewDataAsync();

        Task<bool> AddReservationModel(string Userid, AddReservation reservationmodel);
    }
}
