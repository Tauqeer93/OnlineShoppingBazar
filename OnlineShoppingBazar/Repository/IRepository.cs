using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI.HtmlControls;

namespace OnlineShoppingBazar.Repository
{
    public interface IRepository<tbl_Entity> where tbl_Entity:class
    {
        IEnumerable<tbl_Entity> GetAllRecords();
        IQueryable<tbl_Entity> GetAllRecordsIQueryable();
        int GetAllRecordCount();
        void Add(tbl_Entity entity);
        void Update(tbl_Entity entity);
        void UpdateByWhereClause(Expression<Func<tbl_Entity,bool>> wherePredict,Action<tbl_Entity> ForEachPredict);
        tbl_Entity GetFirstorDefault(int recordId);
        void Remove(tbl_Entity entity);
        void RemoveBywhereClause(Expression<Func<tbl_Entity,bool>> wherePredict);
        void RemoveRangeByWhereClause(Expression<Func<tbl_Entity,bool>> wherePredict);
        void InactiveAndDeleteBywhereClause(Expression<Func<tbl_Entity,bool>> wherePredict,Action<tbl_Entity> ForEachPredict);
        tbl_Entity GetFirstorDefaultByParameter(Expression<Func<tbl_Entity,bool>> wherePredict);
        IEnumerable<tbl_Entity> GetListParameter(Expression<Func<tbl_Entity,bool>> wherePredict);
        IEnumerable<tbl_Entity> GetResultBySqlProcedure(string query, params object[] parameters);
        IEnumerable<tbl_Entity> GetRecordsToShow(int PageNo, int PageSize, int CurrentPage, Expression<System.Func<tbl_Entity, bool>> wherePredict, Expression<Func<tbl_Entity, int>> OrderByPredict);

    }
}