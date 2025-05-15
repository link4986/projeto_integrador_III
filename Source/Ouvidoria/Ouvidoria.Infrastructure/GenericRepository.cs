using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(string id);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;


        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                return await connection.QueryAsync<T>($"SELECT * FROM {typeof(T).Name}");
            }
        }

        public async Task<T> GetByIdAsync(string id)
        {
            using (var connection = _dbContext.CreateConnection())
            {

                var parameters = new DynamicParameters();
                parameters.Add($"@Cod{typeof(T).Name}", id, DbType.String);


                return await connection.QueryFirstOrDefaultAsync<T>($"SELECT * FROM {typeof(T).Name} WHERE Cod{typeof(T).Name} = @Cod{typeof(T).Name}", parameters);
            }
        }

        public async Task<int> AddAsync(T entity)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var query = $"INSERT INTO {typeof(T).Name} ({string.Join(",", typeof(T).GetProperties().Select(p => p.Name))}) VALUES ({string.Join(",", typeof(T).GetProperties().Select(p => "@" + p.Name))})";
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(T entity)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var query = $"UPDATE {typeof(T).Name} SET {string.Join(",", typeof(T).GetProperties().Select(p => p.Name + " = @" + p.Name))} WHERE Cod{typeof(T).Name} = @Cod{typeof(T).Name}";
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> DeleteAsync(string id)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add($"@Cod{typeof(T).Name}", id, DbType.String);

                return await connection.ExecuteAsync($"DELETE FROM {typeof(T).Name} WHERE Cod{typeof(T).Name} = @Cod{typeof(T).Name}", parameters);
            }
        }
    }
}
