using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapperProxy.Models;

namespace WebScrapperProxy.Process
{
    public class Extrator
    {
        public int ScrappyProxyPorPagina(int paginaAtual, int paginaFinal)
        {
            List<ProxyExtracted> proxyExtracteds = new List<ProxyExtracted>();
            IWebDriver driver = new ChromeDriver("C:/SeleniumDrivers");
            driver.Navigate().GoToUrl($"https://proxyservers.pro/proxy/list/order/updated/order_dir/desc/page/{paginaAtual}");

            var title = driver.Title;

            Console.WriteLine($"Página {paginaAtual} de {paginaFinal}: {title}");

            return proxyExtracteds.Count;
        }

        internal List<ProxyExtracted> ExtratorHtml()
        {
            return new List<ProxyExtracted>();
        }
    }
}
