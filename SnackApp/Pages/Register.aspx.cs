using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SnackApp.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;
            string confirmPassword = txt_confirmPassword.Text;
            string email = txt_email.Text;
            int salt = (new Random()).Next(100, 1000);

            if (Page.IsValid)
            {
                Utilities utils = new Utilities();

                if (utils.checkIfUserExists(username) == true)
                {
                    string result = "This user already exists!";
                    Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                }
                else
                {
                    if (password != confirmPassword)
                    {
                        string result = "The passwords do not match!";
                        Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                    }
                    else
                    {
                        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(conStr))
                        {
                            SqlCommand sqlInsertUser = new SqlCommand(@"SET IDENTITY_INSERT users ON;
                                                                        INSERT INTO users(user_name, email, password, verified, is_admin, salt) VALUES (@username, @email, @password, @verified, @is_admin, @salt);
                                                                        SET IDENTITY_INSERT users OFF;", con);

                            string hashedPassword = Utilities.getHashSha256(password + salt);

                            sqlInsertUser.Parameters.AddWithValue("@username", username);
                            sqlInsertUser.Parameters.AddWithValue("@email", email);
                            sqlInsertUser.Parameters.AddWithValue("@password", hashedPassword);
                            sqlInsertUser.Parameters.AddWithValue("@verified", 0);
                            sqlInsertUser.Parameters.AddWithValue("@is_admin", 0);
                            sqlInsertUser.Parameters.AddWithValue("@salt", salt);
                            con.Open();
                            sqlInsertUser.ExecuteNonQuery();

                            Response.Redirect("RegVerification.aspx");
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}