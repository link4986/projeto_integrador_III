using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Domain.Classes
{
    public class Reclamacao
    {
        public Guid? CodReclamacao { get; set; }
        public string SiglaCategoria { get; set; }
        public int CodTipoReclamacao { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public bool FlagNotificado { get; set; }
        public string Contato { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime? DataResposta { get; set; }
        public int? CodUsuarioResposta { get; set; }

        public int CodStatus { get; set; }
        public int CodPrioridade { get; set; }
        public int CodUsuario { get; set; }

    }
}
