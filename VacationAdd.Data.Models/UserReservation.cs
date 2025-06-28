using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationAdd.Data.Models
{
    public class UserReservation
    {


        [Key]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        [Required]
        public int ReservationID { get; set; }

        [ForeignKey(nameof(ReservationID))]
        public Reservation Reservation { get; set; } = null!;
    }
}

