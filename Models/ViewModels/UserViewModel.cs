using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Solid1.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }

        [Required]
        [Display(Name = "Profesion")]
        public string Profesion { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
    }
}