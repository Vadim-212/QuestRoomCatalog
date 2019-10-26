using QuestRoomCatalog.BusinessLayer.BusinessObjects;
using QuestRoomCatalog.DataLayer;
using QuestRoomCatalog.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoomCatalog.BusinessLayer.Helpers
{
    public class RatingHelper : ICrud<RatingBO>
    {
        UnitOfWork Db { get; set; }

        public RatingHelper(UnitOfWork uow)
        {
            Db = uow;
        }

        public void CreateOrUpdate(RatingBO bo)
        {
            if (bo.Id == 0)
            {
                Rating r = new Rating() { QuestRoomId = bo.QuestRoomId, RatingLevel = bo.RatingLevel };
                Db.RatingUowRepository.Add(r);
            }
            else
            {
                Rating editR = AutoMapper<RatingBO, Rating>.Map(bo);
                Db.RatingUowRepository.Update(editR);
            }
            Db.Save();
        }

        public void Delete(int id)
        {
            Db.RatingUowRepository.Delete(id);
            Db.Save();
        }

        public RatingBO Get(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Rating, RatingBO>.Map(Db.RatingUowRepository.Get(id));
            }
            return new RatingBO();
        }

        public IEnumerable<RatingBO> GetAll()
        {
            return AutoMapper<IEnumerable<Rating>, List<RatingBO>>.Map(Db.RatingUowRepository.GetAll);
        }

        public void Save()
        {
            Db.Save();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
