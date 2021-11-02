using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.DataAccessLayer.Daos
{
    ///<typeparam name="TDataContext"></typeparam>
    class BaseDao<TDataContext> : IDataContext
    {
        public TDataContext DataContext { get; }

        public BaseDao(TDataContext dataContext)
        {
            DataContext = dataContext;
        }

        //public abstract IEnumerable<TModel> ReadAll();
        //public abstract TModel ReadById(int id);
        //public abstract int Create(TModel model);
        //public abstract int Update(TModel model);
        //public abstract int Delete(TModel model);
    }
}
