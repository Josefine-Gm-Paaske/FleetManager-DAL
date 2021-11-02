using FleetManager.DataAccessLayer.Daos.Rest.Model;
using FleetManager.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.DataAccessLayer.Daos.Rest
{
    class LocationDao : BaseDao<IDataContext<IRestClient>>, IDao<Location>
    {
        public LocationDao(IDataContext<IRestClient> dataContext) : base(dataContext)
        {
        }

        public Location Create(Location model)
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/Locations", Method.POST);
            request.AddParameter("Name", model.Name);

            IRestResponse<IEnumerable<LocationDto>> response = client.Post<IEnumerable<LocationDto>>(request);

            return model;
        }

        public bool Delete(Location model)
        {
            IRestClient client = DataContext.Open();
            IRestRequest request = new RestRequest("/api/Locations/{id}", Method.DELETE);
            request.AddUrlSegment("id", model.Id);

            //IRestResponse response = client.Delete(request);
            IRestResponse<IEnumerable<LocationDto>> response = client.Delete<IEnumerable<LocationDto>>(request);

            return false;
        }

        public IEnumerable<Location> ReadAll()
        {
            IRestClient client = DataContext.Open();
            IRestRequest request = new RestRequest("/api/Locations", Method.GET);
            IRestResponse<IEnumerable<LocationDto>> response = client.Get<IEnumerable<LocationDto>>(request);
            List<Location> result = new();
            foreach (LocationDto location in response.Data)
            {
                result.Add(location.Map());
            }
            return result;
        }

        public IEnumerable<Location> ReadbyId(Func<Location, bool> predicate)
        {
            IRestClient client = DataContext.Open();
            IRestRequest request = new RestRequest("/api/Locations", Method.GET);
            IRestResponse<IEnumerable<LocationDto>> response = client.Get<IEnumerable<LocationDto>>(request);
            List<Location> result = new();
            foreach (LocationDto location in response.Data)
            {
                result.Add(location.Map());
            }
            return result.Where(predicate);
        }

        public bool Update(Location model)
        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/location/{id}", Method.PUT);
            request.AddUrlSegment("id", model.Id);
            request.AddParameter("Name", model.Name);

            IRestResponse<IEnumerable<LocationDto>> response = client.Post<IEnumerable<LocationDto>>(request);

            return false; //TODO Should return from correct response currently only returns false
        }
    }
}

