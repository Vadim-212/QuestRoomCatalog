using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoomCatalog.BusinessLayer.Helpers
{
    public interface ICrud<T> where T : class
    {
        void CreateOrUpdate(T obj);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Save();
        void Dispose();
    }
}
