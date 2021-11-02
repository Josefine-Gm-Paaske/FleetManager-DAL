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
    class CarDao : BaseDao<IDataContext<IRestClient>>, IDao<Car>
    {
        public CarDao(IDataContext<IRestClient> dataContext) : base(dataContext)
        {
        }

        public Car Create(Car model)

        {
            IRestClient client = DataContext.Open();

            IRestRequest request = new RestRequest("/api/Cars", Method.POST);
            request.AddParameter("Brand", model.Brand);
            request.AddParameter("Mileage", model.Mileage);

            IRestResponse<IEnumerable<CarDto>> response = client.Post<IEnumerable<CarDto>>(request);

            return model;
        }

        public bool Delete(Car model)
        {
            IRestClient client = DataContext.Open();
            IRestRequest request = new RestRequest("/api/Cars/{id}", Method.DELETE);
            request.AddUrlSegment("id", model.Id);
            IRestResponse<IEnumerable<CarDto>> response = client.Post<IEnumerable<CarDto>>(request);

            return false;
        }

        public IEnumerable<Car> ReadAll()
        {
            IRestClient client = DataContext.Open();
            IRestRequest request = new RestRequest("/api/Cars", Method.GET);
            IRestResponse<IEnumerable<CarDto>> response = client.Get<IEnumerable<CarDto>>(request);
            List<Car> result = new();
            foreach (CarDto car in response.Data)
            {
                result.Add(car.Map());
            }
            return result;
        }


        public IEnumerable<Car> ReadbyId(Func<Car, bool> predicate)
        {
            IRestClient client = DataContext.Open();
            IRestRequest request = new RestRequest("/api/Cars", Method.GET);
            IRestResponse<IEnumerable<CarDto>> response = client.Get<IEnumerable<CarDto>>(request);
            List<Car> result = new();
            foreach (CarDto car in response.Data)
            {
                result.Add(car.Map());
            }
            return result.Where(predicate);
        }

        public bool Update(Car model)
        {
            IRestClient client = DataContext.Open();
            IRestRequest request = new RestRequest("/api/Cars/{id}", Method.PUT);
            request.AddUrlSegment("id", model.Id);
            client.Put<Car>(request);
            return true;
        }
    }
}

