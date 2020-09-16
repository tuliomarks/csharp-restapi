using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Api.Models.Mappings
{
    public static class OrderMap
    {
        /// <summary>
        /// Map to service model from database model
        /// </summary>
        /// <param name="from"></param>
        /// <param name="includeDeps"></param>
        /// <returns></returns>
        public static Order Map(Data.Models.Order from, bool includeDeps = true)
        {
            if (from == null)
            {
                return null;
            }

            var dto = new Order()
            {
                Id = from.Id,
                CustomerId = from.CustomerId,
                CreatedDate = from.CreatedDate,
                Price = from.Price,
                Customer = includeDeps ? CustomerMap.Map(from.Customer, false) : null
            };

            return dto;
        }

        /// <summary>
        /// Map to database model from Service model
        /// </summary>
        /// <param name="from"></param>
        /// <param name="includeDeps"></param>
        /// <returns></returns>
        public static Data.Models.Order MapBack(Order from, bool includeDeps = true)
        {
            if (from == null)
            {
                return null;
            }

            var dto = new Data.Models.Order()
            {
                Id = from.Id,
                CustomerId = from.CustomerId,
                CreatedDate = from.CreatedDate,
                Price = from.Price,
                Customer = includeDeps ? CustomerMap.MapBack(from.Customer, false) : null
            };

            return dto;
        }
    }
}
