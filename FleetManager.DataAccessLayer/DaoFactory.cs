using FleetManager.DataAccessLayer.Daos;
using FleetManager.DataAccessLayer.Daos.Rest;
using FleetManager.Entities;
using RestSharp;
using System;

namespace FleetManager.DataAccessLayer
{
    public static class DaoFactory
    {
        public static IDao<TModel> Create<TModel>(IDataContext dataContext)
        {
            Type dataContextType = dataContext.GetType();
                        
            if (typeof(IDataContext<IRestClient>).IsAssignableFrom(dataContextType))
            {
                return typeof(TModel) switch
                {
                    var dao when dao == typeof(Car) => new Daos.Rest.CarDao(dataContext as IDataContext<IRestClient>) as IDao<TModel>,
                    var dao when dao == typeof(Location) => new Daos.Rest.LocationDao(dataContext as IDataContext<IRestClient>) as IDao<TModel>,
                    _ => throw new DaoFactoryException($"Model [{typeof(TModel).Name}] not supported"),
                };
            }
            throw new DaoFactoryException($"DataContext [{dataContext}] not supported");
        }
    }
}
    
