using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Cebulit.API.Dto.Core;
using Cebulit.API.Models.Products.PcParts;
using Cebulit.API.Repositories;
using Microsoft.Extensions.Logging;

namespace Cebulit.API.Services
{
    public class InflationGeneratorPriceUpdater : IPriceUpdater
    {
        private static string inflationGeneratorUrl = "http://localhost:5005/api/price/productSet";
        
        private readonly ILogger _logger;
        private readonly HttpClient _client;
        private readonly IBuildsRepository _repository;

        public InflationGeneratorPriceUpdater(ILogger<InflationGeneratorPriceUpdater> logger, IBuildsRepository repository)
        {
            _logger = logger;
            _repository = repository;
            _client = new HttpClient();
        }
        
        public async Task UpdateAllBuildsPrices()
        {
            try
            {
                var allBuilds = await _repository.GetAllAsync();
                foreach (var build in allBuilds)
                {
                    try
                    {
                        await UpdateSingleBuildPrice(build);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError($"Error while updating price of build with id {build.Id}, skipping\n{e}");
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Critical error while updating builds prices\n{e}");
            }
        }

        private async Task UpdateSingleBuildPrice(Build build)
        {
            var httpResponse = await _client.PostAsJsonAsync(inflationGeneratorUrl, build);
            httpResponse.EnsureSuccessStatusCode();
            var responseDto = await httpResponse.Content.ReadFromJsonAsync<PriceResponse>();
            if (responseDto == null)
                throw new NoNullAllowedException(typeof(PriceResponse).FullName);
                
            build.Price = responseDto.Price;
            await _repository.UpdateAsync(build);
        }
    }
}