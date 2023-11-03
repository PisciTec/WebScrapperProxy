// See https://aka.ms/new-console-template for more information
using WebScrapperProxy.Database;
using WebScrapperProxy.Models;
using WebScrapperProxy.Process;

int extracaoId = 0;
using (var dbContext = new ApplicationContext())
{
    Extracao extracaoIniciada = new Extracao();
    dbContext.Extracoes.Add(extracaoIniciada);
    dbContext.SaveChanges();
    extracaoId = extracaoIniciada.Id;
}
RetornoScrapping retorno = GerenciadorDaExtracao.IniciarScrapping(extracaoId);
using (var dbContext = new ApplicationContext())
{
    Extracao extracaoFinalizada = dbContext.Extracoes.First(x=> x.Id == extracaoId);
    extracaoFinalizada.DataFinal = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    extracaoFinalizada.QuantidadeLinhas = retorno.QuantidadeLinhas;
    extracaoFinalizada.QuantidadePaginas = retorno.PaginasProcessadas;
    extracaoFinalizada.CaminhoArquivoJson = retorno.CaminhoArquivo;
    dbContext.Extracoes.Update(extracaoFinalizada);
    dbContext.SaveChanges();
}

Console.ReadLine();