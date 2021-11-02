using FleetManager.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.DataAccessLayer
{
    public interface IDataContext<TConnection> : IDataContext
    {
        TConnection Open();
    }
    public interface IDataContext
    {
        
    }

    public interface ITypedDataContext : IDataContext
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Location> Locations { get; }
        Car Add(Car car);
        Location Add(Location location);

        bool Remove(Car car);
        bool Remove(Location location);
    }
}
