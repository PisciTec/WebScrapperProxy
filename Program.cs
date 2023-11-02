// See https://aka.ms/new-console-template for more information
using WebScrapperProxy.Database;
using WebScrapperProxy.Models;
using WebScrapperProxy.Process;

using (var dbContext = new ApplicationContext())
{
    dbContext.Extracoes.Add(new Extracao());
}
Extrator extrator = new Extrator();

extrator.ScrappyProxyPorPagina(1, 3);

Console.ReadLine();