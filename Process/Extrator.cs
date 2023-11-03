using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebScrapperProxy.Models;

namespace WebScrapperProxy.Process
{
    public class Extrator
    {

        public static void ScrappyProxyPorPagina(int paginaAtual)
        {
            Console.WriteLine($"Thread {paginaAtual} iniciou... Hora: {DateTime.Now.ToShortTimeString()}");

            IWebDriver driver = new ChromeDriver("C:/SeleniumDrivers");
            var timeout = 3000; // in milliseconds
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            driver.Url = $"https://proxyservers.pro/proxy/list/order/updated/order_dir/desc/page/{paginaAtual}";
            string caminhoArquivoHtml = $"pagina_html/pagina-{paginaAtual}.html";
            string proxyExtraidoJson = $"json_extraidos/pagina-{paginaAtual}.json";

            Helper.SalvarHtml(caminhoArquivoHtml, driver.PageSource);

            List<ProxyExtracted> proxyExtracteds = ExtratorHtml(ref driver);

            Helper.SalvarParaJsonProxies(proxyExtraidoJson, proxyExtracteds);

            Console.WriteLine($"Processada página {paginaAtual} Hora Fim: {DateTime.Now.ToShortTimeString()}");
            Thread.Sleep(500);
        }

        internal static List<ProxyExtracted> ExtratorHtml(ref IWebDriver driver)
        {
            List<ProxyExtracted> proxies = new List<ProxyExtracted>();
            List<IWebElement> linhasProxy = driver.FindElements(By.CssSelector("tr[valign=\"top\"]")).ToList();
            Console.WriteLine(linhasProxy);
            foreach (IWebElement linha in linhasProxy)
            {
                ProxyExtracted proxy = new ProxyExtracted()
                {
                    IpAdress = linha.FindElement(By.CssSelector("a.action-modal-ajax-inact")).Text,
                    Port = int.Parse(linha.FindElement(By.CssSelector("span.port")).Text),
                    Country = linha.FindElement(By.CssSelector("td:nth-of-type(4)")).Text,
                    Protocol = linha.FindElement(By.CssSelector("td:nth-of-type(7)")).Text,
                };
                proxies.Add(proxy);
            }
            driver.Close();
            driver.Quit();
            return proxies;
        }
    }
}
