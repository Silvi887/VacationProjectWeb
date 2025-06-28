using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationApp.ViewModels.Vacation
{
    public class AllVacationsIndexViewModel
    {
       
        public string Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImgUrl { get; set; } = null!;
        public string Info { get; set; } = null!;
        public string? Details { get; set; } = "";
        public string StartDate { get; set; } = null!;
        public string EnddDate { get; set; } = null!;

    }
}
