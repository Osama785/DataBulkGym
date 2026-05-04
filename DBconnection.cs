using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Gym_Management
{
        internal class DBconnection
        {
                public static string ConnectionString = @"Server=localhost\SQLEXPRESS; Database=GymManagementDB; Integrated Security=True; TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            return con;
        }
    }
    }

