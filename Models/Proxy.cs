using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
