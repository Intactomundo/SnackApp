using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SnackApp
{
    public class Utilities
    {
        public bool checkIfUserExists(string username)
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlCheckIfUserExists = new SqlCommand(@"SELECT COUNT(*) FROM users WHERE user_name = @username", con);
                sqlCheckIfUserExists.Parameters.AddWithValue("@username", username);
                con.Open();
                Int32 count = (Int32)sqlCheckIfUserExists.ExecuteScalar();

                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}