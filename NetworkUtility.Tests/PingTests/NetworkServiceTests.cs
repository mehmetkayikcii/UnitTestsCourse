using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;
        private readonly IDNS _dNS;
        public NetworkServiceTests()
        {
            //dependencies - bağımlılıklar
            _dNS = A.Fake<IDNS>();
            //SUT
            _pingService = new NetworkService(_dNS);
        }
        [Fact]
        public void NetworkService_SendPing_ReturnStirng()
        {
            //Arrange - variable, classes, mocks
            A.CallTo(() => _dNS.SendDNS()).Returns(true);

            //Act
            var result = _pingService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();      //Fluent Assertions
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]  // bunun gibi bir çoğunu yazabilirsin.
        public void NetworkService_PingTimeOut_ReturnInt(int a, int b, int expected)
        {
            //Arrange

            //var pingService = new NetworkService(); *her fonksıyonun testinde tekrar tekrar yazmamak için en yukarıda çağırdık.

            //Act
            var result = _pingService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()
        {
            //Arrange - variable, classes, mocks
            
          

            //Act
            var result = _pingService.LastPingDate();

            //Assert
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
                Ttl = 1  //yaşam süresi 
            };
            //Act
            var result = _pingService.GetPingOptions();

            //Assert
            //WARNING: "Be" careful -> iki sayıyı karşılaştırmak için "Be" kullanabilirsin
            //ancak referans türleri veya nesneleri(object) karşılaştırıyorsan "BeEquilebalent" kullanmalısın.

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
                Ttl = 1
            };
            //Act
            var result = _pingService.MostRecentPings();

            //Assert WARNING: "Be" careful
            //result.Should().BeOfType<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);   // "be değil koleksiyon olduğu için"
            result.Should().Contain(x => x.DontFragment == true);

        }
    }
}
