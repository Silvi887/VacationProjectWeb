using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationApp.ViewModels.Vacation
{
    public class DetailsHotelIndexViewModel
    {

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHotel { get; set; }


        [Required]
        public string HotelName { get; set; } = null!;

        [Required]
        public int Stars { get; set; }


        [Required]
        public int NumberofRooms { get; set; }


        public string? ImageUrl { get; set; }


        [Required]
        public string HotelInfo { get; set; } = null!;

        [Required]
        public string TownName { get; set; }

      
    }
}
