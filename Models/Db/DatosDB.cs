using Crud_Solid1.Models.TablaViewModels;
using Crud_Solid1.Models.ViewModels;
using Crud_Solid1.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Crud_Solid1.Models.Db
{
    public interface IRead<T>
    {
        List<T> GetDB();
        UserViewModel GetUserById(int id);
    }

    public interface ICreate<T>
    {
        void SaveDB(T model);
    }

    public interface IUpdate<T>
    {
        void UpdateDB(T model);
    }

    public interface IDelete
    {
        void DeleteDB(int userId);
    }

    public class DatosDB : IRead<UserTableViewModel>, ICreate<UserViewModel>, IUpdate<UserViewModel>, IDelete
    {
        private readonly DatosService datosService;

        public UserViewModel GetUserById(int userId)
        {
            using (var db = new Crud_solid1Entities())
            {
                var userData = db.Datos.Find(userId);

                // Mapea los datos de userData y devuelve el objeto UserViewModel
                UserViewModel userViewModel = new UserViewModel
                {
                    Id = userData.id,
                    Nombre = userData.Nombre,
                    Apellido = userData.Apellido,
                    Telefono = userData.Telefono,
                    Profesion = userData.Profesion,
                    Edad = userData.Edad
                };

                return userViewModel;
            }
        }


        public DatosDB()
        {
            datosService = new DatosService();
        }

        public List<UserTableViewModel> GetDB()
        {
            List<UserTableViewModel> lst = null;
            using (Crud_solid1Entities db = new Crud_solid1Entities())
            {
                lst = (from d in db.Datos
                       select new UserTableViewModel
                       {
                           id = d.id,
                           Nombre = d.Nombre,
                           Apellido = d.Apellido,
                           Telefono = d.Telefono,
                           Profesion = d.Profesion,
                           Edad = d.Edad
                       }).ToList();
            }

            return lst;
        }

        public void SaveDB(UserViewModel model)
        {
            using (var db = new Crud_solid1Entities())
            {
                Datos oDatos = datosService.Create(model);

                db.Datos.Add(oDatos);
                db.SaveChanges();
            }
        }

        public void UpdateDB(UserViewModel model)
        {
            using (var db = new Crud_solid1Entities())
            {
                var oDatos = db.Datos.Find(model.Id);

                oDatos.Nombre = model.Nombre;
                oDatos.Apellido = model.Apellido;
                oDatos.Telefono = model.Telefono;
                oDatos.Profesion = model.Profesion;
                oDatos.Edad = model.Edad;

                db.Entry(oDatos).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteDB(int userId)
        {
            using (var db = new Crud_solid1Entities())
            {
                var oDatos = db.Datos.Find(userId);

                db.Datos.Remove(oDatos);
                db.SaveChanges();
            }
        }
    }
}