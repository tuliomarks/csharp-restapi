using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Api.Models.Mappings
{
    public static class CustomerMap
    {
        /// <summary>
        /// Map to service model from database model
        /// </summary>
        /// <param name="from"></param>
        /// <param name="includeDeps"></param>
        /// <returns></returns>
        public static Customer Map(Data.Models.Customer from, bool includeDeps = true)
        {
            if (from == null)
            {
                return null;
            }

            var dto = new Customer()
            {
                Id = from.Id,
                Name = from.Name,
                Email = from.Email,
            };

            if (includeDeps)
            {
                if (from.Orders != null)
                {
                    dto.Orders = from.Orders.Select(x => OrderMap.Map(x, false));
                }
            }

            return dto;
        }

        /// <summary>
        /// Map to database model from service model 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="includeDeps"></param>
        /// <returns></returns>
        public static Data.Models.Customer MapBack(Customer from, bool includeDeps = true)
        {
            if (from == null)
            {
                return null;
            }

            var dto = new Data.Models.Customer()
            {
                Id = from.Id,
                Name = from.Name,
                Email = from.Email,
            };

            if (includeDeps)
            {
                if (from.Orders != null)
                {
                    dto.Orders = from.Orders.Select(x => OrderMap.MapBack(x, false)).ToArray();
                }
            }

            return dto;
        }
    }
}
