using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationApp.ViewModels.Vacation
{
    public class AllHotelsIndexViewModel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHotel { get; set; }


        public string HotelName { get; set; } = null!;

        public int Stars { get; set; }

        public string HotelInfo { get; set; } = null!;

        public int NumberofRooms { get; set; }


        public string? ImageUrl { get; set; }

     
    }
}
