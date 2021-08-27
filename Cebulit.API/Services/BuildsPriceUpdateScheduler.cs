using System;
using System.Threading;
using System.Threading.Tasks;
using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cebulit.API.Services
{
    public class BuildsPriceUpdateScheduler : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public BuildsPriceUpdateScheduler(ILogger<BuildsPriceUpdateScheduler> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var registry = new Registry();
            registry.Schedule(() =>
            {
                using var scope = _serviceProvider.CreateScope();
                try
                {
                    var priceUpdater = scope.ServiceProvider.GetService<IPriceUpdater>();
                    priceUpdater.UpdateAllBuildsPrices().GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    _logger.LogError($"Couldn't initialize builds price update scheduler\n{e}");
                }
            }).ToRunEvery(1).Days().At(1, 15);
            JobManager.Initialize(registry);
            _logger.LogDebug($"Initialized builds price update scheduler");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            JobManager.StopAndBlock();
            return Task.CompletedTask;
        }
    }
}