using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuestRoomCatalog.BusinessLayer;
using QuestRoomCatalog.BusinessLayer.BusinessObjects;
using QuestRoomCatalog.BusinessLayer.Helpers;
using QuestRoomCatalog.DataLayer;
using QuestRoomCatalog.Models;

namespace QuestRoomCatalog.Controllers
{
    public class QuestRoomsController : Controller
    {
        ICrud<QuestsRoomsBO> questRoomsBO;

        public QuestRoomsController(ICrud<QuestsRoomsBO> questRoomsBO)
        {
            this.questRoomsBO = questRoomsBO;
        }

        public ActionResult Index()
        {
            List<QuestsRoomsModel> rooms = AutoMapper<IEnumerable<QuestsRoomsBO>, List<QuestsRoomsModel>>.Map(questRoomsBO.GetAll);
            return View(rooms);
        }
        
        public ActionResult CreateEdit(int? id = 0)
        {
            QuestsRoomsModel room = AutoMapper<QuestsRoomsBO, QuestsRoomsModel>.Map(questRoomsBO.Get, (int)id);
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(QuestsRoomsModel questRoom)
        {
            QuestsRoomsBO oldRoom = AutoMapper<QuestsRoomsModel, QuestsRoomsBO>.Map(questRoom);
            questRoomsBO.CreateOrUpdate(oldRoom);
            return RedirectToAction("Index", "QuestRooms");
        }
        
        public ActionResult Delete(int id)
        {
            questRoomsBO.Delete(id);
            return RedirectToAction("Index", "QuestRooms");
        }
    }
}
