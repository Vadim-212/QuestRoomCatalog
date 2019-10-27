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
    public class RatingController : Controller
    {
        ICrud<RatingBO> ratingBO;
        ICrud<QuestsRoomsBO> questRoomsBO;

        public RatingController(ICrud<RatingBO> ratingBO, ICrud<QuestsRoomsBO> questRoomsBO)
        {
            this.ratingBO = ratingBO;
            this.questRoomsBO = questRoomsBO;
        }

        public ActionResult Index()
        {
            List<RatingModel> ratings = AutoMapper<IEnumerable<RatingBO>, List<RatingModel>>.Map(ratingBO.GetAll);
            return View(ratings);
        }

        public ActionResult CreateEdit(int? id = 0)
        {
            RatingModel rating = AutoMapper<RatingBO, RatingModel>.Map(ratingBO.Get, (int)id);

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

            return View(rating);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(RatingModel rating)
        {
            RatingBO oldRating = AutoMapper<RatingModel, RatingBO>.Map(rating);
            oldRating.QuestRoomId = int.Parse(Request.Form["QuestRoomId"]);
            ratingBO.CreateOrUpdate(oldRating);
            return RedirectToAction("Index", "Rating");
        }

        public ActionResult Delete(int id)
        {
            ratingBO.Delete(id);
            return RedirectToAction("Index", "Rating");
        }
    }
}