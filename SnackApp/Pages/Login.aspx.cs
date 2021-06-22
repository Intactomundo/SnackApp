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
                
            }
        }
    }
}