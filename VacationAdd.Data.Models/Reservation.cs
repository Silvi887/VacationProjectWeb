using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationAdd.Data.Models
{
    public class Reservation
    {

        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReservation { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int AdultsCount { get; set; }


        [Required]
        public int ChildrenCount { get; set; }


        [Required]
        public string GuestId { get; set; }

        [ForeignKey(nameof(GuestId))]
        public virtual Guest Guest { get; set; } = null!;

        [Required]
        public int RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public virtual Room Room { get; set; } = null!;

        [Required]
        public int HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public virtual Hotel Hotel { get; set; } = null!;

        public virtual ICollection<UserReservation> UsersReservations { get; set; } = new HashSet<UserReservation>();
    }
}
