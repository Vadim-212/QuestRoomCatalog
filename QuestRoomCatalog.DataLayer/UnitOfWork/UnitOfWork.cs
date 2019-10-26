using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Repositories;
using QuestRoomCatalog.DataLayer;

namespace QuestRoomCatalog.DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Model1 db;
        private bool disposed = false;
        Repository<QuestsLogos> _questsLogosUowRepository;
        Repository<Roles> _rolesUowRepository;
        Repository<Rating> _ratingUowRepository;
        Repository<Users> _usersUowRepository;
        Repository<QuestsRooms> _questsRoomsUowRepository;
        //Repository<T> _genericRepository;

        public UnitOfWork()
        {
            db = new Model1();
        }


        public Repository<QuestsLogos> QuestsLogosUowRepository
        {
            get
            {
                if (this._questsLogosUowRepository == null)
                    _questsLogosUowRepository = new Repository<QuestsLogos>(db);
                return _questsLogosUowRepository;
            }
        }

        public Repository<Roles> RolesUowRepository
        {
            get
            {
                if (this._rolesUowRepository == null)
                    _rolesUowRepository = new Repository<Roles>(db);
                return _rolesUowRepository;
            }
        }

        public Repository<Rating> RatingUowRepository
        {
            get
            {
                if (this._ratingUowRepository == null)
                    _ratingUowRepository = new Repository<Rating>(db);
                return _ratingUowRepository;
            }
        }

        public Repository<Users> UsersUowRepository
        {
            get
            {
                if (this._usersUowRepository == null)
                    _usersUowRepository = new Repository<Users>(db);
                return _usersUowRepository;
            }
        }

        public Repository<QuestsRooms> QuestsRoomsUowRepository
        {
            get
            {
                if (this._questsRoomsUowRepository == null)
                    _questsRoomsUowRepository = new Repository<QuestsRooms>(db);
                return _questsRoomsUowRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }


        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}