using CadDetails.POC.Domain.Entities;

namespace CadDetails.POC.Domain.Interfaces
{
    public interface IAssetService
    {
        IEnumerable<Asset> GetSortedAssets(IEnumerable<Asset> assets);
    }
}
