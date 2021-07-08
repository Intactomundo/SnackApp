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
    public partial class Main_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"] != null)
                {
                    string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(@"SELECT userID, user_name, email, verified FROM users WHERE is_admin = 0", con);
                        DataTable data = new DataTable();
                        con.Open();
                        da.Fill(data);

                        tbl_users.DataSource = data;
                        tbl_users.DataBind();

                        if (data.Rows.Count == 0)
                        {
                            string result = "There are currently no users in the database!";
                            Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                        }
                    }
                }
                else
                {
                    string result = "Current user isn't an Admin.";
                    Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                    Response.Redirect("Main.aspx");
                }
            }
        }

        protected void tbl_users_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (tbl_users.Rows[e.RowIndex].Cells[3].Text == "False")
                {
                    SqlCommand sqlVerifyUser = new SqlCommand(@"UPDATE users SET verified = 1 WHERE userID = @userid", con);
                    sqlVerifyUser.Parameters.AddWithValue("@userid", tbl_users.Rows[e.RowIndex].Cells[0].Text);
                    con.Open();
                    sqlVerifyUser.ExecuteNonQuery();
                    Response.Redirect("Main_admin.aspx");
                }
                else
                {
                    SqlCommand sqlVerifyUser = new SqlCommand(@"UPDATE users SET verified = 0 WHERE userID = @userid", con);
                    sqlVerifyUser.Parameters.AddWithValue("@userid", tbl_users.Rows[e.RowIndex].Cells[0].Text);
                    con.Open();
                    sqlVerifyUser.ExecuteNonQuery();
                    Response.Redirect("Main_admin.aspx");
                }
            }
        }

        protected void tbl_users_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userid = Int32.Parse(tbl_users.Rows[e.RowIndex].Cells[0].Text);
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlDeleteUserItemsFromUser = new SqlCommand(@"DELETE FROM user_items WHERE fk_userid = " + userid + ";", con);
                SqlCommand sqlDeleteUser = new SqlCommand(@"DELETE FROM users WHERE userID = " + userid + ";", con);
                con.Open();
                sqlDeleteUserItemsFromUser.ExecuteNonQuery();
                sqlDeleteUser.ExecuteNonQuery();
                tbl_users.DataBind();
                con.Close();
                Response.Redirect("Main_admin.aspx");
            }
        }
    }
}