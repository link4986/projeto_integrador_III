using Ouvidoria.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Domain.Interfaces
{
    public interface IMoradorService
    {
        List<Reclamacao> Listar(string CodUsuario);
        bool Criar(Reclamacao item);
    }
}
