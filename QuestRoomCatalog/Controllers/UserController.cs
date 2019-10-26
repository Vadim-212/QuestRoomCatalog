using QuestRoomCatalog.BusinessLayer;
using QuestRoomCatalog.BusinessLayer.BusinessObjects;
using QuestRoomCatalog.BusinessLayer.Helpers;
using QuestRoomCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRoomCatalog.Controllers
{
    public class UserController : Controller
    {
        ICrud<UsersBO> usersBO;

        public UserController(ICrud<UsersBO> usersBO)
        {
            this.usersBO = usersBO;
        }

        public ActionResult Index()
        {
            List<UsersModel> users = AutoMapper<IEnumerable<UsersBO>, List<UsersModel>>.Map(usersBO.GetAll);
            return View(users);
        }

        public ActionResult CreateEdit(int? id = 0)
        {
            UsersModel users = AutoMapper<UsersBO, UsersModel>.Map(usersBO.Get, (int)id);
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(UsersModel user)
        {
            UsersBO oldUser = AutoMapper<UsersModel, UsersBO>.Map(user);
            usersBO.CreateOrUpdate(oldUser);
            return RedirectToAction("Index", "User");
        }

        public ActionResult Delete(int id)
        {
            usersBO.Delete(id);
            return RedirectToAction("Index", "User");
        }
    }
}