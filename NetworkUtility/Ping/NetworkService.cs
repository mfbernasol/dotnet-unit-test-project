using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using NetworkUtility.DNS;

namespace NetworkUtility.Ping
{
    /// <summary>
    /// 
    /// </summary>
    public class NetworkService
    {
        private readonly IDNS _dNs;

        public NetworkService(IDNS dNS)
        {
            _dNs = dNS;
        }
        
        public string SendPing()
        {
            var dnsSuccess = _dNs.SendDNS();
            if (dnsSuccess)
            {
                return "Success: Ping Sent!";
            }
            else
            {
                return "Failed: Ping not send!";
            }
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }


        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
            };
            return pingOptions;
        }

    }
}
