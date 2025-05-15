using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Domain.Classes
{
    public class TipoReclamacao
    {
        public int CodTipoReclamacao { get; set; }
        public string Descricao { get; set; }
        public bool FlagDenuncia { get; set; }
        public bool FlagSugestao { get; set; }
        public bool FlagReclamacao { get; set; }
    }
}
