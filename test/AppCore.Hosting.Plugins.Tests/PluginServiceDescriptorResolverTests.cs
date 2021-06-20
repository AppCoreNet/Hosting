// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AppCore.Hosting.Plugins
{
    public class PluginServiceDescriptorResolverTests
    {
        private class ServiceCollection : List<ServiceDescriptor>, IServiceCollection
        {
        }

        [Fact]
        public void RegistersServices()
        {
            PluginFacility.PluginManager = null;

            var services = new ServiceCollection();
            services.AddPlugins(
                p =>
                {
                    p.Configure(o =>
                    {
                        o.Assemblies.Add(PluginPaths.TestPlugin);
                        o.Assemblies.Add(PluginPaths.TestPlugin2);
                    });
                });

            services.TryAddEnumerableFrom(
                s =>
                    s.Plugins(
                        p =>
                            p.WithServiceType<IStartupTask>()));

            services.Should()
                    .Contain(
                        r =>
                            r.ServiceType.FullName == "AppCore.Hosting.IStartupTask"
                            && r.ImplementationType.FullName == "AppCore.Hosting.Plugins.TestPlugin.PublicStartupTask"
                    );

            services.Should()
                    .Contain(
                        r =>
                            r.ServiceType.FullName == "AppCore.Hosting.IStartupTask"
                            && r.ImplementationType.FullName == "AppCore.Hosting.Plugins.TestPlugin2.PublicStartupTask"
                    );
        }
    }
}