using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebScrapperProxy.Models;

namespace WebScrapperProxy.Process
{
    internal class Helper
    {
        public static void SalvarParaJsonProxies(string caminhoArquivo, List<ProxyExtracted> proxies)
        {
            File.WriteAllText(caminhoArquivo, JsonSerializer.Serialize(proxies));
        }

        public static void SalvarHtml(string caminhoArquivo, string paginaFonte)
        {
            File.WriteAllText(caminhoArquivo, paginaFonte);
        }
    }
}
