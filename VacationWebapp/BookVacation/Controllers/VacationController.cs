using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VacationAdd.Data.Models;
using VacationApp.Services.Core;
using VacationApp.Services.Core.Interface;
using VacationApp.ViewModels.Vacation;

namespace BookVacation.Controllers
{
    public class VacationController :BaseController
    {
        private readonly IVacationService vacationService;

        public VacationController(IVacationService vacService)
        {
            this.vacationService = vacService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            string? UserId = this.GetUserId();
            IEnumerable<AllHotelsIndexViewModel> allVacations = await this.vacationService.GetAllHotelsAsync(UserId);
            return View(allVacations);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            int id1 = int.Parse(id);
            string? UserId = this.GetUserId();
            var HotelDetails = await this.vacationService.GetHotelDetailsAsync(id1,UserId);


            return View(HotelDetails);
        }


        [HttpGet]
        public async Task<IActionResult> Add(string? id)
        {
            try
            {

                string[] ArrHotelName = id.Split(',');

               // int idhotel1 = int.Parse(id);
                AddReservation inAddReservation = new AddReservation()
                {
                    HotelId= ArrHotelName[0],
                    HotelName = ArrHotelName[1],
                    // HotelName=
                    StartDate = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                    EndDate = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                    roodrp = (IEnumerable<RoomViewModel>)await this.vacationService.RoomViewDataAsync(),
                    DateofBirth = DateTime.UtcNow.ToString("yyyy-MM-dd")

                };
                return View("Views/Vacation/AddReservation.cshtml", inAddReservation);

               // return this.View()

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
                
            }
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddReservation inAddReservation)
        {
            try
            {

                //int idhotel1 = int.Parse(idhotel);
                string? UserId = this.GetUserId();
                if (!this.ModelState.IsValid)
                {
                    // return this.View(inAddReservation);

                    return this.RedirectToAction(nameof(Add));
                }

                bool isvalid = await vacationService.AddReservationModel(UserId, inAddReservation);

                if (isvalid== false)
                {

                    ModelState.AddModelError(string.Empty,"Fatal error accure while adding a reservation!");
                    return this.RedirectToAction(nameof(Add));
                }


                inAddReservation.roodrp = (IEnumerable<RoomViewModel>)await this.vacationService.RoomViewDataAsync();
                ViewBag.SuccessMessage = "Successful reservation!";
                return View("Views/Vacation/AddReservation.cshtml", inAddReservation);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));

            }
        }
    }
}
