using CadDetails.POC.Domain.Entities;
using CadDetails.POC.Domain.Interfaces;

namespace CadDetails.POC.Domain.Services
{
    public class DefaultAssetSortingStrategy : IAssetSortingStrategy
    {
        public IEnumerable<Asset> Sort(IEnumerable<Asset> assets)
        {
            return assets
                .Where(a => a != null && a.IsValid())
                .OrderByDescending(a => a.LastUpdated ?? DateTime.MinValue)
                .ThenByDescending(a => a.PopularityScore)
                .ThenBy(a => a.Name);
        }
    }

}
