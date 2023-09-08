using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Solid1.Models.TablaViewModels
{
    public class UserTableViewModel : Controller
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Profesion { get; set; }
        public int Edad { get; set; }
    }
}