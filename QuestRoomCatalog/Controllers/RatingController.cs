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

        public RatingController(ICrud<RatingBO> ratingBO)
        {
            this.ratingBO = ratingBO;
        }

        public ActionResult Index()
        {
            List<RatingModel> ratings = AutoMapper<IEnumerable<RatingBO>, List<RatingModel>>.Map(ratingBO.GetAll);
            return View(ratings);
        }

        public ActionResult CreateEdit(int? id = 0)
        {
            RatingModel rating = AutoMapper<RatingBO, RatingModel>.Map(ratingBO.Get, (int)id);
            return View(rating);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(RatingModel rating)
        {
            RatingBO oldRating = AutoMapper<RatingModel, RatingBO>.Map(rating);
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