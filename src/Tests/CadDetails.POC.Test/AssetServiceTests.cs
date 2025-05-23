using CadDetails.POC.Domain.Entities;
using CadDetails.POC.Domain.Interfaces;
using CadDetails.POC.Domain.Services;

namespace CadDetails.POC.Test
{
    public class AssetServiceTests
    {
        private readonly IAssetService _service;

        public AssetServiceTests()
        {
            _service = new AssetService(new DefaultAssetSortingStrategy());
        }

        [Fact]
        public void ShouldSortAssets_ByLastUpdatedThenPopularityThenName()
        {
            var assets = new List<Asset>
        {
            new() { Name = "Alpha", LastUpdated = DateTime.Now.AddDays(-1), PopularityScore = 5 },
            new() { Name = "Beta", LastUpdated = DateTime.Now, PopularityScore = 3 },
            new() { Name = "Gamma", LastUpdated = DateTime.Now, PopularityScore = 9 }
        };

            var result = _service.GetSortedAssets(assets).ToList();

            Assert.Equal("Gamma", result[0].Name);
            Assert.Equal("Beta", result[1].Name);
            Assert.Equal("Alpha", result[2].Name);
        }

        [Fact]
        public void ShouldHandleNullValues()
        {
            var assets = new List<Asset>
        {
            null,
            new() { Name = "Zeta", LastUpdated = null, PopularityScore = 1 },
            new() { Name = "", LastUpdated = DateTime.Now, PopularityScore = 2 }
        };

            var result = _service.GetSortedAssets(assets).ToList();

            Assert.Single(result);
            Assert.Equal("Zeta", result[0].Name);
        }
    }

}
