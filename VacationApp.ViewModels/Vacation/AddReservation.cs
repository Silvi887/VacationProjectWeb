using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationApp.ViewModels.Vacation
{
    public class AddReservation
    {

        //public int IdReservation { get; set; }

       

        [Required]
        public string StartDate { get; set; } = null!;

        [Required]
        public string EndDate { get; set; } = null!;

        [Required]
        public int AdultsCount { get; set; } = 0;


        [Required]
        public int ChildrenCount { get; set; } = 0;


        [Required]
        public string GuestFirstName { get; set; } = "";


        [Required]
        public string LastNameG { get; set; } = "";

        [Required]
        public string DateofBirth { get; set; } = null!;

        public string? GuestAddress { get; set; }

        public string? GuestPhoneNumber { get; set; }



        [Required]
        public string GuestEmail { get; set; } = "";


        [Required]
        public string RoomId { get; set; }

        [Required]
        public string HotelId { get; set; }

        [Required]
        public string HotelName { get; set; } = "";

        public IEnumerable<RoomViewModel> roodrp = null!;

    }

}
