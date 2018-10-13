﻿using System.Linq;
using Xunit;
using Autofac;
using Autofac.Core;
using DotNetRu.MeetupManagement.Infrastructure.DependencyInjection;
using DotNetRu.ServiceHost.Autofac;
using Microsoft.Extensions.Configuration;

namespace DotNetRu.ServiceHost.Tests.AutofacModules
{
    public class AutofacModulesTest
    {
        [Fact]
#pragma warning disable CA1822 // Mark members as static
        public void AllComponentsRegisteredInModuleMustBeResolved()
#pragma warning restore CA1822 // Mark members as static
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            ResolveComponents(new ConfigurationModule(configuration), new DataLayerModule());
        }

        private static void ResolveComponents(params Module[] modules)
        {
            var builder = new ContainerBuilder();
            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }

            using (var container = builder.Build())
            {
                var registrations = container.ComponentRegistry.Registrations.ToList();

                foreach (var registration in registrations)
                {
                    foreach (var service in registration.Services.OfType<TypedService>())
                    {
                        container.Resolve(service.ServiceType);
                    }
                }
            }
        }
    }
}