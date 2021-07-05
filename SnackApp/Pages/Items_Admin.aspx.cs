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
    public partial class Items_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (Session["admin"] != null)
                //{
                    string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(@"SELECT itemID, item_name, item_path FROM items", con);
                        DataTable data = new DataTable();
                        con.Open();
                        da.Fill(data);

                        tbl_items.DataSource = data;
                        tbl_items.DataBind();

                        if (data.Rows.Count == 0)
                        {
                            string result = "There are currently no users in the database!";
                            Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                        }
                    }
                //}
                //else
                //{
                //    string result = "Current user isn't an Admin.";
                //    Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                //    Response.Redirect("Main.aspx");
                //}
            }
        }

        protected void tbl_items_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btn_addItem_Click(object sender, EventArgs e)
        {

        }

        protected void btn_editItem_Click(object sender, EventArgs e)
        {

        }

        protected void btn_report_Click(object sender, EventArgs e)
        {

        }
    }
}