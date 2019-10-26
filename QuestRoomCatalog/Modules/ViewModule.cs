using Ninject.Modules;
using QuestRoomCatalog.BusinessLayer.BusinessObjects;
using QuestRoomCatalog.BusinessLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestRoomCatalog.Modules
{
    public class ViewModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICrud<QuestsLogosBO>>().To<QuestLogosHelper>();
            Bind<ICrud<QuestsRoomsBO>>().To<QuestRoomsHelper>();
            Bind<ICrud<RatingBO>>().To<RatingHelper>();
            Bind<ICrud<RolesBO>>().To<RolesHelper>();
            Bind<ICrud<UsersBO>>().To<UsersHelper>();
        }
    }
}