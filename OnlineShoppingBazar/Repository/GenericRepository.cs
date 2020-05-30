using Microsoft.Ajax.Utilities;
using OnlineShoppingBazar.DAL_Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace OnlineShoppingBazar.Repository
{
    public class GenericRepository<tbl_Entity> : IRepository<tbl_Entity> where tbl_Entity : class
    {
        DbSet<tbl_Entity> _dbset;
        private  dbMyOnlineStoreEntities _DBEntity;
        public GenericRepository(dbMyOnlineStoreEntities DBEntity)
        {
            _DBEntity = DBEntity;
            _dbset = _DBEntity.Set<tbl_Entity>();
        }
        public void Add(tbl_Entity entity)
        {
            _dbset.Add(entity);
            _DBEntity.SaveChanges();
        }

        public int GetAllRecordCount()
        {
            return _dbset.Count();
        }

        public IEnumerable<tbl_Entity> GetAllRecords()
        {
            return _dbset.ToList();
        }

        public IQueryable<tbl_Entity> GetAllRecordsIQueryable()
        {
            return _dbset;
        }

        public tbl_Entity GetFirstorDefault(int recordId)
        {
            return _dbset.Find(recordId);
        }

        public tbl_Entity GetFirstorDefaultByParameter(Expression<Func<tbl_Entity, bool>> wherePredict)
        {
            return _dbset.Where(wherePredict).FirstOrDefault();
        }

        public IEnumerable<tbl_Entity> GetListParameter(Expression<Func<tbl_Entity, bool>> wherePredict)
        {
            return _dbset.Where(wherePredict).ToList();
        }

        public IEnumerable<tbl_Entity> GetRecordsToShow(int PageNo, int PageSize, int CurrentPage, Expression<Func<tbl_Entity, bool>> wherePredict, Expression<Func<tbl_Entity, int>> OrderByPredict)
        {
            if (wherePredict!=null)
            {
                return _dbset.OrderBy(OrderByPredict).Where(wherePredict).ToList();
            }
            else
            {
                return _dbset.OrderBy(OrderByPredict).ToList();
                    
            }
        }

        public IEnumerable<tbl_Entity> GetResultBySqlProcedure(string query, params object[] parameters)
        {
            if (parameters!=null)
            {
                return _DBEntity.Database.SqlQuery<tbl_Entity>(query, parameters).ToList();
            }
            else
            {
                return _DBEntity.Database.SqlQuery<tbl_Entity>(query).ToList();
            }
        }

        public void InactiveAndDeleteBywhereClause(Expression<Func<tbl_Entity, bool>> wherePredict, Action<tbl_Entity> ForEachPredict)
        {
            _dbset.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }

        public void Remove(tbl_Entity entity)
        {
            if (_DBEntity.Entry(entity).State == EntityState.Detached)
                _dbset.Attach(entity);
            _dbset.Remove(entity);
        }

        public void RemoveBywhereClause(Expression<Func<tbl_Entity, bool>> wherePredict)
        {
            tbl_Entity entity = _dbset.Where(wherePredict).FirstOrDefault();
            Remove(entity);
        }

        public void RemoveRangeByWhereClause(Expression<Func<tbl_Entity, bool>> wherePredict)
        {
            List<tbl_Entity> entity = _dbset.Where(wherePredict).ToList();
            foreach (var ent in entity)
            {
                Remove(ent);
            }
        }

        public void Update(tbl_Entity entity)
        {
            _dbset.Attach(entity);
            _DBEntity.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateByWhereClause(Expression<Func<tbl_Entity, bool>> wherePredict, Action<tbl_Entity> ForEachPredict)
        {
            _dbset.Where(wherePredict).ToList().ForEach(ForEachPredict);
        }
    }
}