using Ouvidoria.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<Usuario> Autenticar(string login, string senha);
    }
}
