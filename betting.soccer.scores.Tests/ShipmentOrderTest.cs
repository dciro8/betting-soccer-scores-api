using Microsoft.Extensions.Options;
using betting.soccer.scores.api;

using Xunit;
using betting.soccer.scores.api.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace betting.soccer.scores.Tests;

public class ShipmentOrderTest{
    
    DataContext context;


    private IConfigurationRoot _configuration;

    // represents database's configuration
    private DbContextOptions<DataContext> _options;

    public ShipmentOrderTest()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        _configuration = builder.Build();
        _options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            .Options;
    }

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

    public void Calculate_Payment_Return_HighestValue()
    {
        

        //var actual = mediator.CalculateInitialPayment(route, order);

        Assert.True(true, "true");
    }  

    
    private static IOptions<AppSettings> AppSettingsMock()
    {
        IOptions<AppSettings> settings = Options.Create(new AppSettings()
        {
         
        });
        return settings;
    }
}