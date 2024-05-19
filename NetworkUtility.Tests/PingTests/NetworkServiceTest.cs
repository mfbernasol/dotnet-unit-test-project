using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
namespace NetworkUtility.Tests.PingTests
{
    /// <summary>
    /// 
    /// </summary>
    public class NetworkServiceTest
    {
        private readonly NetworkService _pingService;
        private readonly IDNS _dNS; 
        public  NetworkServiceTest()
        {
           
            //Depedencies
            _dNS = A.Fake<IDNS>();
            
            //SUT 
            _pingService = new NetworkService(_dNS);
            
        }
        
        [Fact] 
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange - variables, classes, mocks
            // var pingService = new NetworkService();
            A.CallTo(() => _dNS.SendDNS()).Returns(true);
            // Act
            var result = _pingService.SendPing();
        
            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }


        [Theory]  // think inline data
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange 
            // var pingService = new NetworkService();

            // Act 
            var result = _pingService.PingTimeout(a,b);


            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }
        
        
        [Fact] 
        public void NetworkService_LastPingDate_ReturnDate()
        {
            // Arrange - variables, classes, mocks
            // var pingService = new NetworkService();
            
            // Act
            var result = _pingService.LastPingDate();
        
            // Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsObject()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl =  1
            };
            //Act
            var result = _pingService.GetPingOptions();
            
            //Assert WARNING: "Be" careful
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);

        }


        [Fact]
        public void NetworkService_MostRecentPings_ReturnsObject()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl =  1
            };
            //Act
            var  result = _pingService.MostRecentPings();
            
            //Assert WARNING: "Be" careful
            result.Should().BeOfType<PingOptions[]>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
        
        
    }
}
