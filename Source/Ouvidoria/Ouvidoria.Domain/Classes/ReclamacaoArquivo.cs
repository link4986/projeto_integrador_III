using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Domain.Classes
{
    public class ReclamacaoArquivo
    {
        public Guid? CodReclamacaoArquivo { get; set; }
        public Guid CodReclamacao { get; set; }
        public string NomeArquivo { get; set; }
        public string Extensao { get; set; }        
    }
}
