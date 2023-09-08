using Crud_Solid1.Models.ViewModels;
using Crud_Solid1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Crud_Solid1.Models.Db;

namespace Crud_Solid1.Service
{
    public class DatosService
    {
        public Datos Create(UserViewModel model)
        {
            Datos oDatos = new Datos
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Telefono = model.Telefono,
                Profesion = model.Profesion,
                Edad = model.Edad
            };

            return oDatos;
        }

        public UserViewModel GetUpdate(int Id)
        {
            UserViewModel model = new UserViewModel();

            using (var db = new Crud_solid1Entities())
            {
                var oDatos = db.Datos.Find(Id);
                model.Nombre = oDatos.Nombre;
                model.Apellido = oDatos.Apellido;
                model.Telefono = oDatos.Telefono;
                model.Profesion = oDatos.Profesion;
                model.Edad = oDatos.Edad;
            }

            return model;
        }

    }
}