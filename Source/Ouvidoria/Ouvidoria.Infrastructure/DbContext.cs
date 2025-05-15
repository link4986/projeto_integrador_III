using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ouvidoria.Infrastructure
{
    public class DbContext
    {

        public DbContext()
        {
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConfigurationManager.GetSection("Ouvidoria").ToString());
        }
    }
}
