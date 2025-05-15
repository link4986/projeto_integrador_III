using Microsoft.Extensions.Configuration;
using Ouvidoria.Domain.Classes;
using Ouvidoria.Domain.Interfaces;
using Ouvidoria.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IConfiguration _configuracao;

        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuracao) {
            _usuarioRepository = usuarioRepository;
            _configuracao = configuracao;
        }

        public Usuario Autenticar(string login, string senha)
        {
            return _usuarioRepository.Autenticar(login, senha).Result;
        }
    }
}
