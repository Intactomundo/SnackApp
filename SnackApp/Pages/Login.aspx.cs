using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SnackApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            Utilities utils = new Utilities();

            if(utils.checkIfUserExists(username) == false)
            {
                string result = "This user does not exist!";
                Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
            }
            else
            {
                int salt = utils.getUserSalt(username);

                string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand sqlCheckPassword = new SqlCommand(@"SELECT password FROM users WHERE user_name = @username;", con);

                    string hashedPassword = Utilities.getHashSha256(password + salt);

                    sqlCheckPassword.Parameters.AddWithValue("@username", username);
                    con.Open();
                    string pw = (string)sqlCheckPassword.ExecuteScalar();

                    if(pw == hashedPassword)
                    {
                        bool is_verified = utils.checkIfUserIsVerified(username);
                        if(is_verified == true)
                        {
                            Session["username"] = username;
                            bool is_admin = utils.checkIfUserIsAdmin(username);
                            if (is_admin == true)
                            {
                                Response.Redirect("Main_Admin.aspx");
                            }
                            else
                            {
                                Response.Redirect("Main.aspx");
                            }
                        }
                        else
                        {
                            string result = "You aren't verified currently!";
                            Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                        }
                    }
                    else
                    {
                        string result = "The password is incorrect!";
                        Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                    }
                }
            }
        }
    }
}