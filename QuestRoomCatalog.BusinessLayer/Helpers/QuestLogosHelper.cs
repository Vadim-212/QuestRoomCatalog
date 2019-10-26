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
    public class QuestLogosHelper : ICrud<QuestsLogosBO>
    {
        UnitOfWork Db { get; set; }

        public QuestLogosHelper(UnitOfWork uow)
        {
            Db = uow;
        }

        public void CreateOrUpdate(QuestsLogosBO bo)
        {
            if (bo.Id == 0)
            {

                QuestsLogos ql = new QuestsLogos() { QuestRoomId = bo.QuestRoomId, Image = bo.Image, IsLogo = bo.IsLogo };
                Db.QuestsLogosUowRepository.Add(ql);
            }
            else
            {
                QuestsLogos editQl = AutoMapper<QuestsLogosBO, QuestsLogos>.Map(bo);
                Db.QuestsLogosUowRepository.Update(editQl);
            }
            Db.Save();
        }

        public void Delete(int id)
        {
            Db.QuestsLogosUowRepository.Delete(id);
            Db.Save();
        }

        public QuestsLogosBO Get(int id)
        {
            if (id != 0)
            {
                return AutoMapper<QuestsLogos, QuestsLogosBO>.Map(Db.QuestsLogosUowRepository.Get(id));
            }
            return new QuestsLogosBO();
        }

        public IEnumerable<QuestsLogosBO> GetAll()
        {
            return AutoMapper<IEnumerable<QuestsLogos>, List<QuestsLogosBO>>.Map(Db.QuestsLogosUowRepository.GetAll);
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
