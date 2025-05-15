using Ouvidoria.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Usuario Autenticar(string login, string senha);       

    }
}
