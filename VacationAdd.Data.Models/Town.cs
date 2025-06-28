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
    public class Town
    {
        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTown { get; set; }


        [Required]
        [MaxLength(ValidationConstants.TownMaxLenght)]
        [MinLength(ValidationConstants.TownMinLenght)]
        public string NameTown { get; set; } = null!;

        public virtual ICollection<Hotel> Hotels { get; set; } = new HashSet<Hotel>();
    }
}
