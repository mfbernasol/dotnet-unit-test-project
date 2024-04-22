using System;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    /// <summary>
    /// 
    /// </summary>
    public class NetworkService
    {

        public string SendPing()
        {
            // SearchDNS()
            // BuildPacket()
            return "Success: Ping Sent!";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

    }
}
