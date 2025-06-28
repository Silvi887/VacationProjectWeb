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
    public class Guest
    {

        [Key]
        [MaxLength(ValidationConstants.MaxLenghtGuest)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdGuest { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.GuestMaxLenght)]
        [MinLength(ValidationConstants.GuestMinLenght)]
        public string FirstName { get; set; } = null!;


        [Required]
        [MaxLength(ValidationConstants.GuestMaxLenght)]
        [MinLength(ValidationConstants.GuestMinLenght)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; } 

        
        public string? Address { get; set; }

        public string? Email { get; set; }


        [Required]
        public string NumberOfPhone { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
