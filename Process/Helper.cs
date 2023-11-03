using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebScrapperProxy.Models;

namespace WebScrapperProxy.Process
{
    internal class Helper
    {
        public static async void SalvarParaJsonProxies(string caminhoArquivo, List<ProxyExtracted> proxies)
        {
            {
                var fi = new FileInfo(caminhoArquivo);
                if (!Directory.Exists(fi.DirectoryName))
                {
                    Directory.CreateDirectory(fi.DirectoryName);
                }
                string proxySerializado = JsonSerializer.Serialize(proxies);

                File.WriteAllText(caminhoArquivo, proxySerializado);
            }
        }

        public static void SalvarHtml(string caminhoArquivo, string paginaFonte)
        {
            var fi = new FileInfo(caminhoArquivo);
            if (!Directory.Exists(fi.DirectoryName))
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }

            File.WriteAllText(caminhoArquivo, paginaFonte);
        }

        public static RetornoScrapping JuntarArquivosJson(int paginaFinal)
        {
            string output_timestamp = DateTime.Now.ToString("yyMMddhhmmss");

            HashSet<ProxyExtracted> ipsUnicos = new HashSet<ProxyExtracted>();

            List<ProxyExtracted> ipsResultado = new List<ProxyExtracted>();

            string nomeArquivo = $"paginasConcatenadas-{output_timestamp}.json";

            for (int i = 1; i < paginaFinal + 1; i++)
            {
                string jsonString = File.ReadAllText($"json_extraidos/pagina-{i}.json");
                List<ProxyExtracted> ipsExtraídos = JsonSerializer.Deserialize<List<ProxyExtracted>>(jsonString)!;
                foreach (ProxyExtracted ip in ipsExtraídos)
                {
                    if (!ipsUnicos.Contains(ip))
                    {
                        ipsUnicos.Add(ip);
                        ipsResultado.Add(ip);
                    }
                }

            }

            SalvarParaJsonProxies(nomeArquivo, ipsResultado);

            return new RetornoScrapping(nomeArquivo, ipsResultado.Count);
        }
    }
}
