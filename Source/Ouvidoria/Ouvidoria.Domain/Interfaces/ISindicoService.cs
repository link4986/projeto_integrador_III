using Ouvidoria.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Domain.Interfaces
{
    public interface ISindicoService
    {
        public List<Reclamacao> ListarReclamacao();
        public bool AtualizarReclamacao(Reclamacao item);
    }
}
