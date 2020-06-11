// Licensed under the MIT License.
// Copyright (c) 2020 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Hosting;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Represents the facility for the application host.
    /// </summary>
    public class HostingFacility : Facility, IHostingFacility
    {
        /// <inheritdoc />
        protected override void RegisterComponents(IComponentRegistry registry)
        {
            registry.RegisterFacility<LoggingFacility>();

            registry.Register<IBackgroundServiceHost>()
                    .Add<BackgroundServiceHost>()
                    .IfNoneRegistered()
                    .PerDependency();

            registry.Register<IStartupTaskExecutor>()
                    .Add<StartupTaskExecutor>()
                    .IfNoneRegistered()
                    .PerDependency();
        }
    }
}
