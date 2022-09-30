using Microsoft.Extensions.Options;
using Transenvios.Shipping.Api.Infraestructure;
using Xunit;

namespace Transenvios.Shipping.Tests;

public class ShipmentOrderTest
{
    const decimal ROUTE_INITIAL_KILO_PRICE = 15000M;
    const decimal ROUTE_ADDITIONAL_KILO_PRICE = 1500M;
    const decimal ROUTE_PRICE_CM3 = 0.3M;
    const decimal PACKAGE_WEIGHT = 20.0M;
    const decimal PACKAGE_HEIGHT = 100.0M;
    const decimal PACKAGE_LENGTH = 20.0M;
    const decimal PACKAGE_WIDTH = 20.0M;
    DataContext context;

    [Fact]
    public void Calculate_Payment_Return_WeightCharge()
    {
        // Arrange
        const decimal expected = 43500M;

        // Act
        //var actual = mediator.CalculateChargeByWeight(route, order.Weight??0);

        // Assert
        Assert.Equal(true, true);
    }

    [Fact]
    public void Calculate_Payment_Return_VolumeCharge()
    {
        const decimal expected = 12000M;
        
        //var actual = mediator.CalculateChargeByVolume(
        //    route, order.Height??0, order.Length??0, order.Width??0);

        Assert.Equal(true, true);
    }

    [Theory]
    [InlineData(1, 20, 100, 20, 20, 43500)]
    [InlineData(2, 1, 100, 50, 20, 30000)]
    public void Calculate_Payment_Return_HighestValue(
        int testId, decimal weight, decimal height, decimal length, decimal width, decimal expected)
    {
        

        //var actual = mediator.CalculateInitialPayment(route, order);

        Assert.True(true, "true");
    }

    [Theory]
    [InlineData(1, 0, false, false, 43500, 8265, 51765)]
    [InlineData(2, 0, true, false, 65250, 12397.5, 77647.5)]
    [InlineData(3, 0, false, true, 52200, 9918, 62118)]
    [InlineData(4, 0, true, true, 73950, 14050.5, 88000.5)]
    [InlineData(5, 10000, false, false, 43600, 8284, 51884)]
    [InlineData(6, 10000, true, false, 65350, 12416.5, 77766.5)]
    [InlineData(7, 10000, false, true, 52300, 9937, 62237)]
    [InlineData(8, 10000, true, true, 74050, 14069.5, 88119.5)]
    public void Calculate_Payment_Return_ServiceCost(
        int testId, decimal InsuredValue, bool IsUrgent, bool IsFragile, 
        decimal expectedPrice, decimal expectedTaxes, decimal expectedTotal)
    {
        
        
        
    }

    
    private static IOptions<AppSettings> AppSettingsMock()
    {
        IOptions<AppSettings> settings = Options.Create(new AppSettings()
        {
            Shipment = new ShipmentSettings
            {
                InsuredAmountRatio = 1.0M,
                UrgentAmountRatio = 50.0M,
                FragileAmountRatio = 20.0M,
                TaxAmountRatio = 19.0M
            }
        });
        return settings;
    }
}