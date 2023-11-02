
namespace WebScrapperProxy.Models
{
    public class ProxyExtracted
    {
        public required string IpAdress { get; set; }
        public int Port { get; set; }
        public required string Country { get; set; }
        public required string Protocol { get; set; }
    }
}
