using CadDetails.POC.Domain.Entities;
using CadDetails.POC.Domain.Interfaces;

namespace CadDetails.POC.Domain.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetSortingStrategy _sortingStrategy;

        public AssetService(IAssetSortingStrategy sortingStrategy)
        {
            _sortingStrategy = sortingStrategy;
        }

        public IEnumerable<Asset> GetSortedAssets(IEnumerable<Asset> assets)
        {
            return _sortingStrategy.Sort(assets);
        }
    }
}
