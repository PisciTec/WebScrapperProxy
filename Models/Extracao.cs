using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapperProxy.Models
{
    public class Extracao
    {
        public Extracao()
        {
            DataInicio = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            QuantidadeLinhas = 0;
            QuantidadePaginas = 0;
        }
        [Key]
        public int Id { get; set; }
        public string? DataInicio { get; set; }
        public string? DataFinal { get; set; }
        public int QuantidadePaginas { get; set; }
        public int QuantidadeLinhas { get; set; }
        public string? CaminhoArquivoJson { get; set; }
    }
}
