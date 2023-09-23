using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTApplication.Repository
{
    public  static class DbUtils
    {
        public static SqlConnectionStringBuilder getConnectionBuilder(string originalConnectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(originalConnectionString);

            // Add Column Encryption Setting
            builder.ColumnEncryptionSetting = SqlConnectionColumnEncryptionSetting.Enabled;

            return builder;
        }
    }
}
