using OnlineShoppingBazar.DAL_Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingBazar.Repository
{
    public class GenericUnitOfWork:IDisposable
    {
        private dbMyOnlineStoreEntities DbEntity = new dbMyOnlineStoreEntities();        

        public IRepository<tbl_EntityType> GetRepositoryInstance<tbl_EntityType>() where tbl_EntityType : class
        {
            return new GenericRepository<tbl_EntityType>(DbEntity);
        }

        public void SaveChanges()
        {
            DbEntity.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbEntity.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        private bool disposed = false;
    }
}