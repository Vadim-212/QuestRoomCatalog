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
    public class UsersHelper : ICrud<UsersBO>
    {
        UnitOfWork Db { get; set; }

        public UsersHelper(UnitOfWork uow)
        {
            Db = uow;
        }

        public void CreateOrUpdate(UsersBO bo)
        {
            if (bo.Id == 0)
            {
                Users u = new Users() { UserName = bo.UserName, RoleId = bo.RoleId };
                Db.UsersUowRepository.Add(u);
            }
            else
            {
                Users editU = AutoMapper<UsersBO, Users>.Map(bo);
                Db.UsersUowRepository.Update(editU);
            }
            Db.Save();
        }

        public void Delete(int id)
        {
            Db.UsersUowRepository.Delete(id);
            Db.Save();
        }

        public UsersBO Get(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Users, UsersBO>.Map(Db.UsersUowRepository.Get(id));
            }
            return new UsersBO();
        }

        public IEnumerable<UsersBO> GetAll()
        {
            return AutoMapper<IEnumerable<Users>, List<UsersBO>>.Map(Db.UsersUowRepository.GetAll);
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
