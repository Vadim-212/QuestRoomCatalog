using QuestRoomCatalog.BusinessLayer;
using QuestRoomCatalog.BusinessLayer.BusinessObjects;
using QuestRoomCatalog.BusinessLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRoomCatalog.Controllers
{
    public class QuestLogosController : Controller
    {
        ICrud<QuestsLogosBO> questLogosBO;
        ICrud<QuestsRoomsBO> questRoomsBO;

        public QuestLogosController(ICrud<QuestsLogosBO> questLogosBO, ICrud<QuestsRoomsBO> questRoomsBO)
        {
            this.questLogosBO = questLogosBO;
            this.questRoomsBO = questRoomsBO;
        }
        public ActionResult Index()
        {
            List<QuestsLogosViewModel> logos = AutoMapper<IEnumerable<QuestsLogosBO>, List<QuestsLogosViewModel>>.Map(questLogosBO.GetAll);
            foreach (var item in logos)
            {
                using (var ms = new MemoryStream(item.Image))
                {
                    item.Img = Image.FromStream(ms);
                }
            }
            return View(logos);
        }

        public ActionResult CreateEdit(int? id = 0)
        {
            QuestsLogosViewModel logo = AutoMapper<QuestsLogosBO, QuestsLogosViewModel>.Map(questLogosBO.Get, (int)id);
            List<QuestsRoomsBO> rooms = questRoomsBO.GetAll().ToList();
            List<SelectListItem> sli = new List<SelectListItem>();
            foreach (var item in rooms)
            {
                sli.Add(new SelectListItem()
                {
                    Selected = false,
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            sli[0].Selected = true;
            ViewBag.QuestRoomId = sli;
            return View(logo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(QuestsLogosViewModel questLogo, HttpPostedFileBase Img = null)
        {
            QuestsLogosBO oldLogo = AutoMapper<QuestsLogosViewModel, QuestsLogosBO>.Map(questLogo);
            oldLogo.QuestRoomId = int.Parse(Request.Form["QuestRoomId"]);
            byte[] imgData = null;
            if(Img != null)
            {
                using (var binaryReader = new BinaryReader(Img.InputStream))
                {
                    imgData = binaryReader.ReadBytes(Img.ContentLength);
                }
                oldLogo.Image = imgData;
            }
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
