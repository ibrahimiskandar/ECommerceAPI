
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Infrastructure.Services;
using ECommerceAPI.Infrastructure.Services.Storage;
using ECommerceAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IStorageService,StorageService>();
            serviceDescriptors.AddScoped<ITokenHandler, TokenHandler>();

        }
        public static void AddStorage<T>(this IServiceCollection serviceDescriptors) where T : class, IStorage
        {
            serviceDescriptors.AddScoped<IStorage,T>();
        }
    }
}
