using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SnackApp.Pages
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Utilities utils = new Utilities();
                string username = Session["user"].ToString();

                int userid = utils.getUserÌD(username);

                string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT items.item_image, user_items.numberOfItems FROM items FULL JOIN user_items ON items.itemID = user_items.user_itemsID WHERE fk_userID = @userid;", con);
                    da.SelectCommand.Parameters.AddWithValue("@userid", userid);
                    DataTable data = new DataTable();
                    con.Open();
                    da.Fill(data);

                    tbl_itemsConsumed.DataSource = data;
                    tbl_itemsConsumed.DataBind();

                    if(data.Rows.Count == 0)
                    {
                        string result = "There are currently no Snacks available!";
                        Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                    }
                }
            }
            else
            {
                string result = "No user from whom to pull the data has been found!";
                Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
            }
        }

        protected void ddl_language_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_updateUserProfile_Click(object sender, EventArgs e)
        {

        }

        protected void tbl_itemsConsumed_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}