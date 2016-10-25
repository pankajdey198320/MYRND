using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace Ma.Executor
{
    public interface IExecutor
    {
        DataSet Execute(string data);
    }
    public class SqlExecutor : IExecutor
    {
        public DataSet Execute(string commandText)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["SHAREDDB"].ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandType =  System.Data.CommandType.Text;

                    

                    cmd.CommandText = commandText;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    sda.Dispose();

                    return ds;
                }
            }
        }
    }
}
