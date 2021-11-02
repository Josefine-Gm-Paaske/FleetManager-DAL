using FleetManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.DataAccessLayer.Daos.Rest.Model
{
   static class MapperExtension
    {
        public static Car Map(this CarDto carDto)
        {
            return new Car
            {
                Id = int.Parse(carDto.Href[(carDto.Href.LastIndexOf("/") + 1)..]),
                Location = null,
                Brand = carDto.Brand,
                Mileage = carDto.Mileage
            };
        }

        public static Location Map(this LocationDto locationDto)
        {
            return new Location
            {
                Id = int.Parse(locationDto.Href[(locationDto.Href.LastIndexOf("/") + 1)..]),
                Name = null
            };
        }
    }
}
