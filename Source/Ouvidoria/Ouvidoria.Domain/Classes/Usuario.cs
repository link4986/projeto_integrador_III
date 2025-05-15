using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Domain.Classes
{
    public class Usuario
    {
        public int? CodUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int CodPerfil { get; set; }
        public bool Ativo { get; set; }
    }
}
