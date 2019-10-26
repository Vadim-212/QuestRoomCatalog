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
    public class QuestRoomsHelper : ICrud<QuestsRoomsBO>
    {
        UnitOfWork Db { get; set; }

        public QuestRoomsHelper(UnitOfWork uow)
        {
            Db = uow;
        }

        public void CreateOrUpdate(QuestsRoomsBO bo)
        {
            if (bo.Id == 0)
            {
                QuestsRooms qr = new QuestsRooms()
                {
                    Name = bo.Name,
                    Description = bo.Description,
                    TimeForQuest = bo.TimeForQuest,
                    MaxGamer = bo.MaxGamer,
                    MinGamer = bo.MinGamer,
                    MinAgeGamer = bo.MinAgeGamer,
                    FearLevel = bo.FearLevel,
                    ComplexityLevel = bo.ComplexityLevel
                };
                Db.QuestsRoomsUowRepository.Add(qr);
            }
            else
            {
                QuestsRooms editQr = AutoMapper<QuestsRoomsBO, QuestsRooms>.Map(bo);
                Db.QuestsRoomsUowRepository.Update(editQr);
            }
            Db.Save();
        }

        public void Delete(int id)
        {
            Db.QuestsRoomsUowRepository.Delete(id);
            Db.Save();
        }

        public QuestsRoomsBO Get(int id)
        {
            if (id != 0)
            {
                return AutoMapper<QuestsRooms, QuestsRoomsBO>.Map(Db.QuestsRoomsUowRepository.Get(id));
            }
            return new QuestsRoomsBO();
        }

        public IEnumerable<QuestsRoomsBO> GetAll()
        {
            return AutoMapper<IEnumerable<QuestsRooms>, List<QuestsRoomsBO>>.Map(Db.QuestsRoomsUowRepository.GetAll);
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
