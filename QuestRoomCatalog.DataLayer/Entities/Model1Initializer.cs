using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoomCatalog.DataLayer.Entities
{
    public class Model1Initializer: DropCreateDatabaseAlways<Model1>
    {
        protected override void Seed(Model1 db)
        {
            db.Roles.Add(new Roles() { RoleName = "Administrator" });
            db.Roles.Add(new Roles() { RoleName = "User" });
            db.Users.Add(new Users() { UserName = "Admin", RoleId = 1 });
            db.Users.Add(new Users() { UserName = "User", RoleId = 2 });
        }
    }
}
