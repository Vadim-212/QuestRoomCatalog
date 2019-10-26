using QuestRoomCatalog.BusinessLayer;
using QuestRoomCatalog.BusinessLayer.BusinessObjects;
using QuestRoomCatalog.BusinessLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRoomCatalog.Controllers
{
    public class QuestLogosController : Controller
    {
        ICrud<QuestsLogosBO> questLogosBO;

        public QuestLogosController(ICrud<QuestsLogosBO> questLogosBO)
        {
            this.questLogosBO = questLogosBO;
        }
        public ActionResult Index()
        {
            List<QuestsLogosViewModel> logos = AutoMapper<IEnumerable<QuestsLogosBO>, List<QuestsLogosViewModel>>.Map(questLogosBO.GetAll);
            return View(logos);
        }

        public ActionResult CreateEdit(int? id = 0)
        {
            QuestsLogosViewModel logo = AutoMapper<QuestsLogosBO, QuestsLogosViewModel>.Map(questLogosBO.Get, (int)id);
            return View(logo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(QuestsLogosViewModel questLogo)
        {
            QuestsLogosBO oldLogo = AutoMapper<QuestsLogosViewModel, QuestsLogosBO>.Map(questLogo);
            questLogosBO.CreateOrUpdate(oldLogo);
            return RedirectToAction("Index", "QuestLogos");
        }

        public ActionResult Delete(int id)
        {
            questLogosBO.Delete(id);
            return RedirectToAction("Index", "QuestLogos");
        }
    }
}
