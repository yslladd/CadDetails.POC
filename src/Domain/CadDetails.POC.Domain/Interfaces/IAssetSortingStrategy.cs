using CadDetails.POC.Domain.Entities;

namespace CadDetails.POC.Domain.Interfaces
{
    public interface IAssetSortingStrategy
    {
        IEnumerable<Asset> Sort(IEnumerable<Asset> assets);
    }

}
