using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebScrapperProxy.Process;

namespace Teste_WebSrapperProxy.Testes
{
    public class Teste_Extrator
    {

        [Fact]
        public void ResultadoNaoEVazio()
        {
            Extrator extrator = new Extrator();

            extrator.ExtratorHtml();
           
        }
    }
}