using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebScrapperProxy.Models;

namespace WebScrapperProxy.Process
{
    public class GerenciadorDaExtracao
    {
        public static RetornoScrapping IniciarScrapping(int id)
        {
            IWebDriver driver = new ChromeDriver("C:/SeleniumDrivers");
            var timeout = 3000; // in milliseconds
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            driver.Url = $"https://proxyservers.pro/proxy/list/order/updated/order_dir/desc/page/1";

            int paginaFinal = int.Parse(driver.FindElement(By.CssSelector("li.page-item:last-of-type a.page-link")).Text);
            driver.Close();
            driver.Quit();


            var paginas = Enumerable.Range(1, paginaFinal).ToList();

            Parallel.ForEach(paginas,
                new ParallelOptions { MaxDegreeOfParallelism = 3 },
                Extrator.ScrappyProxyPorPagina);

            RetornoScrapping retorno = Helper.JuntarArquivosJson(paginaFinal);
            retorno.IdExtracao = id;
            retorno.PaginasProcessadas = paginaFinal;
            return retorno;
        }

    }

}
