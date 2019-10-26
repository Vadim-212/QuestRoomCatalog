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
    public class RolesController : Controller
    {
        ICrud<RolesBO> rolesBO;

        public RolesController(ICrud<RolesBO> rolesBO)
        {
            this.rolesBO = rolesBO;
        }

        public ActionResult Index()
        {
            List<RolesModel> roles = AutoMapper<IEnumerable<RolesBO>, List<RolesModel>>.Map(rolesBO.GetAll);
            return View(roles);
        }

        public ActionResult CreateEdit(int? id = 0)
        {
            RolesModel roles = AutoMapper<RolesBO, RolesModel>.Map(rolesBO.Get, (int)id);
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(RolesModel roles)
        {
            RolesBO oldRole = AutoMapper<RolesModel, RolesBO>.Map(roles);
            rolesBO.CreateOrUpdate(oldRole);
            return RedirectToAction("Index", "Roles");
        }

        public ActionResult Delete(int id)
        {
            rolesBO.Delete(id);
            return RedirectToAction("Index", "Roles");
        }
    }
}