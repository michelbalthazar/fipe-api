using MBTech.Domain;
using MBTech.Domain.Common;
using MBTech.Infraestructure;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Client
{
    public class SmallCarsUtilitiesClientTests
    {
        private readonly string _smallCarsBrands;
        private readonly string _test;

        public SmallCarsUtilitiesClientTests()
        {
            _smallCarsBrands = File.ReadAllText(@"..\..\..\..\..\tests\FileToTests\smallCar\brands-2018.json");

            _test = GenerateObjectToTest.SmallCarsBrands().ToJson<SmallCarsBrands>();
        }

        [Trait("Unit Tests", "SmallCarsUtilitiesClient - GetBrandsAsync")]
        [Fact(DisplayName = "GetOneAsync when send invoiceId valid return OK")]
        public async Task GetBrandsAsync_WhenRequestIsValid_ReturnsOk()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Post, _smallCarsBrands);

            var smallCarsUtilitiesClient = new SmallCarsUtilitiesClient(mockHttp);
            File.WriteAllTextAsync(@"D://test.json", _test);
            // Act
            var result = await smallCarsUtilitiesClient.GetBrandsAsync(CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.OK, result.Status);
            //ValidateHelper.ValidateInvoice(_invoiceToAssert, result.ValueAsSuccess);
        }

        [Trait("Unit Tests", "SmallCarsUtilitiesClient - GetBrandsAsync")]
        [Fact(DisplayName = "GetOneAsync test about exception")]
        public async Task GetBrandsAsync_WhenRequestResponseReturnNull_ReturnsError()
        {
            // Arrange
            var mockHttp = TestHelper.CreateMockHttp(HttpMethod.Get, _smallCarsBrands);

            var smallCarsUtilitiesClient = new SmallCarsUtilitiesClient(mockHttp);

            // Act
            var result = await smallCarsUtilitiesClient.GetBrandsAsync(CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultStatusCode.Error, result.Status);
            Assert.Equal("String reference not set to an instance of a String.\r\nParameter name: s", result.Value.ToString());
        }
    }
}
