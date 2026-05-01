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
                public static string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GymManagementDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            return con;
        }
    }
    }

