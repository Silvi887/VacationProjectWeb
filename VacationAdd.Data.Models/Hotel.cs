using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.GConstants;

namespace VacationAdd.Data.Models
{
    public class Hotel
    {

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHotel { get; set; }


        [Required]
        [MaxLength(ValidationConstants.HotelMaxLenght)]
        [MinLength(ValidationConstants.HotelMinLenght)]
        public string HotelName { get; set; } = null!;

        [Required]
        public int Stars { get; set; }


        [Required]
        public int NumberofRooms { get; set; }


        public string? ImageUrl { get; set; }


        [Required]
        [MaxLength(ValidationConstants.DescriptionMaxLenght)]
        [MinLength(ValidationConstants.DescriptionMinLenght)]
        public string HotelInfo { get; set; } = null!;

        [Required]
        public int TownId { get; set; }

        [ForeignKey(nameof(TownId))]
        public virtual Town Town { get; set; } = null!;

        public virtual ICollection<Reservation>  Reservations {get;set;}=new HashSet<Reservation>();

    



    }
}
