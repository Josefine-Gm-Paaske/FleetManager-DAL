using System;
using System.Collections.Generic;

namespace FleetManager.DataAccessLayer
{
    public interface IDao<TModel>
    {
        TModel Create(TModel model);

        IEnumerable<TModel> ReadAll();

        IEnumerable<TModel> ReadbyId(Func<TModel, bool> predicate);

        bool Update(TModel model);

        bool Delete(TModel model);
    }
}
