using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationApp.ViewModels.Vacation
{
    public class RoomViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoomType { get; set; } = null!;
    }
}
