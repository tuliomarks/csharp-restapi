using CSharp.Data.Services;
using CSharp.Data.Services.Abstractions;
using CSharp.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Data.Dependencies
{
    public static class ServiceDependency
    {
        public static void AddServicesDependencies(this IServiceCollection collection)
        {
            collection.AddTransient<ICustomerService, CustomerService>();
            collection.AddTransient<IOrderService, OrderService>();
        }

        public static void AddRepositoriesDependencies(this IServiceCollection collection)
        {
            collection.AddScoped<IOrderRepository, OrderRepository>();
            collection.AddScoped<ICustomerRepository, CustomerRepository>();
        }

    }
}
