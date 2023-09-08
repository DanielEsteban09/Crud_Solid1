using Crud_Solid1.Models;
using Crud_Solid1.Models.Db;
using Crud_Solid1.Models.TablaViewModels;
using Crud_Solid1.Models.ViewModels;
using Crud_Solid1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Crud_Solid1.Controllers
{
    public class UserController : Controller
    {
        private readonly ICreate<UserViewModel> userDbCreate;
        private readonly IRead<UserTableViewModel> userDbRead;
        private readonly IUpdate<UserViewModel> userDbUpdate;
        private readonly IDelete userDbDelete;

        public UserController(ICreate<UserViewModel> userDbCreate, IRead<UserTableViewModel> userDbRead, IUpdate<UserViewModel> userDbUpdate, IDelete userDbDelete)
        {
            this.userDbCreate = userDbCreate;
            this.userDbRead = userDbRead;
            this.userDbUpdate = userDbUpdate;
            this.userDbDelete = userDbDelete;
        }

        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = userDbRead.GetDB();
            return View(lst);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            userDbCreate.SaveDB(model);

            return Redirect(Url.Content("~/User/"));
        }


        public ActionResult Edit(int id)
        {
            // Aqui se obtiene el modelo UserViewModel para editar
            UserViewModel userViewModel = userDbRead.GetUserById(id);

            if (userViewModel == null)
            {
                return HttpNotFound();
            }

            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                userDbUpdate.UpdateDB(model);

                return RedirectToAction("Index");
            }

            // Si el modelo no es válido, se regresa a la vista de edición con los errores
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            userDbDelete.DeleteDB(Id);

            return Redirect(Url.Content("~/User/"));
        }
    }
}