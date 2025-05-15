using Dapper;
using Microsoft.Extensions.Configuration;
using Ouvidoria.Domain.Classes;
using Ouvidoria.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Infrastructure.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Usuario> Autenticar(string login, string senha)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Usuario>($"SELECT * FROM Usuario WHERE Login = @login AND Senha = @senha", new { @login, @senha });
            }
        }
    }
}
