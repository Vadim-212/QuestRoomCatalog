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
    public class RolesHelper : ICrud<RolesBO>
    {
        UnitOfWork Db { get; set; }

        public RolesHelper(UnitOfWork uow)
        {
            Db = uow;
        }

        public void CreateOrUpdate(RolesBO bo)
        {
            if (bo.Id == 0)
            {
                Roles r = new Roles() { RoleName = bo.RoleName };
                Db.RolesUowRepository.Add(r);
            }
            else
            {
                Roles editR = AutoMapper<RolesBO, Roles>.Map(bo);
                Db.RolesUowRepository.Update(editR);
            }
            Db.Save();
        }

        public void Delete(int id)
        {
            Db.RolesUowRepository.Delete(id);
            Db.Save();
        }

        public RolesBO Get(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Roles, RolesBO>.Map(Db.RolesUowRepository.Get(id));
            }
            return new RolesBO();
        }

        public IEnumerable<RolesBO> GetAll()
        {
            return AutoMapper<IEnumerable<Roles>, List<RolesBO>>.Map(Db.RolesUowRepository.GetAll);
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
