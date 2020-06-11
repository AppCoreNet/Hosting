// Licensed under the MIT License.
// Copyright (c) 2020 the AppCore .NET project.

using System.Threading.Tasks;
using AppCore.Diagnostics;
using FrameworkLifetime = Microsoft.Extensions.Hosting.IApplicationLifetime;

namespace AppCore.Hosting.Microsoft.Extensions
{
    /// <summary>
    /// Provides implementation of <see cref="IApplicationLifetime"/>.
    /// </summary>
    public class MicrosoftHostingApplicationLifetime : IApplicationLifetime
    {
        private readonly FrameworkLifetime _lifetime;
        private readonly TaskCompletionSource<bool> _started = new TaskCompletionSource<bool>();
        private readonly TaskCompletionSource<bool> _stopping = new TaskCompletionSource<bool>();
        private readonly TaskCompletionSource<bool> _stopped = new TaskCompletionSource<bool>();

        /// <inheritdoc />
        public Task Started => _started.Task;

        /// <inheritdoc />
        public Task Stopping => _stopping.Task;

        /// <inheritdoc />
        public Task Stopped => _stopped.Task;

        /// <summary>
        /// Initializes a new instance of the <see cref="MicrosoftHostingApplicationLifetime"/> class.
        /// </summary>
        /// <param name="lifetime">The application lifetime.</param>
        public MicrosoftHostingApplicationLifetime(FrameworkLifetime lifetime)
        {
            Ensure.Arg.NotNull(lifetime, nameof(lifetime));

            lifetime.ApplicationStarted.Register(() => _started.SetResult(true));
            lifetime.ApplicationStopping.Register(() => _stopping.SetResult(true));
            lifetime.ApplicationStopped.Register(() => _stopped.SetResult(true));

            _lifetime = lifetime;
        }

        /// <inheritdoc />
        public void Stop()
        {
            _lifetime.StopApplication();
        }
    }
}