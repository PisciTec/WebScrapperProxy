using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperProxy.Models
{
    public class RetornoScrapping
    {
        public RetornoScrapping()
        {
            
        }
        public RetornoScrapping(string caminhoArquivo, int quantidadeLinhas)
        {
            CaminhoArquivo = caminhoArquivo;
            QuantidadeLinhas = quantidadeLinhas;
        }
        public int IdExtracao { get; set; }
        public int QuantidadeLinhas { get; set; }
        public string CaminhoArquivo { get; set; }
        public int PaginasProcessadas { get; set; }
    }
}
