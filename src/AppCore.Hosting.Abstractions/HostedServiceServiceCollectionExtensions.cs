// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System;
using AppCore.DependencyInjection;
using AppCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extensions methods to register hosted services with a <see cref="IServiceCollection"/>.
    /// </summary>
    public static class HostedServiceServiceCollectionExtensions
    {
        /// <summary>
        /// Adds hosted services to the container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configure">The configuration delegate.</param>
        /// <returns>The passed <see cref="IServiceCollection"/> to allow chaining.</returns>
        public static IServiceCollection AddHostedServicesFrom(this IServiceCollection services, Action<IServiceDescriptorReflectionBuilder> configure)
        {
            Ensure.Arg.NotNull(configure, nameof(configure));

            var builder = new ServiceDescriptorReflectionBuilder(typeof(IHostedService));
            configure(builder);
            services.TryAddEnumerable(builder.Resolve());
            return services;
        }
    }
}