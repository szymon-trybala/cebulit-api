using System.Threading.Tasks;

namespace Cebulit.API.Services
{
    public interface IPriceUpdater
    {
        Task UpdateAllBuildsPrices();
    }
}