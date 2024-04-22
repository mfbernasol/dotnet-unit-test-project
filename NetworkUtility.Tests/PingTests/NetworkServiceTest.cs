using System;
using System.Threading.Tasks;
using FluentAssertions;
using NetworkUtility.Ping;

namespace NetworkUtility.Tests.PingTests
{
    /// <summary>
    /// 
    /// </summary>
    
   
    public class NetworkServiceTest
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange
            var pingService = new NetworkService();
            // Act
            var result = pingService.SendPing();
        
            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }


        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange 
            var pingService = new NetworkService();

            // Act 
            var result = pingService.PingTimeout(a, b);


            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }
    }
}
