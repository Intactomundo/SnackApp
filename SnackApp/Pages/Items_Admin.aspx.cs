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
            int itemid = Int32.Parse(tbl_items.Rows[e.RowIndex].Cells[0].Text);
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlDeleteUser = new SqlCommand(@"DELETE FROM items WHERE itemID = " + itemid + ";", con);
                con.Open();
                sqlDeleteUser.ExecuteNonQuery();
                tbl_items.DataBind();
                con.Close();
                Response.Redirect("Items_Admin.aspx");
            }
        }

        protected void btn_addItem_Click(object sender, EventArgs e)
        {
            if (fileUploaderAdd.HasFile)
            {
                string itemname = txt_itemNameAdd.Text;
                string imageExtension = System.IO.Path.GetExtension(fileUploaderAdd.FileName);
                fileUploaderAdd.SaveAs(Server.MapPath("~/item_images/" + itemname + imageExtension));

                string itempath = @"~\item_images\" + itemname + imageExtension;
                string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand sqlInsertItem = new SqlCommand(@"SET IDENTITY_INSERT users OFF; INSERT INTO items(item_name, item_path) VALUES (@item_name, @item_path);", con);

                    sqlInsertItem.Parameters.AddWithValue("@item_name", itemname);
                    sqlInsertItem.Parameters.AddWithValue("@item_path", itempath);
                    con.Open();
                    sqlInsertItem.ExecuteNonQuery();

                    Response.Redirect("Items_Admin.aspx");
                }
            }
            else
            {
                string result = "There is currently no image selected for the item!";
                Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
            }
        }

        protected void btn_editItem_Click(object sender, EventArgs e)
        {
            if (fileUploaderEdit.HasFile)
            {
                string itemname = txt_itemNameEdit.Text;
                string itemid = txt_itemID.Text;
                string imageExtension = System.IO.Path.GetExtension(fileUploaderEdit.FileName);
                fileUploaderEdit.SaveAs(Server.MapPath("~/item_images/" + itemname + imageExtension));

                string itempath = @"~\item_images\" + itemname + imageExtension;
                string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand sqlInsertItem = new SqlCommand(@"UPDATE ITEMS SET item_name = @item_name, item_path = @item_path WHERE itemID = @itemID", con);

                    sqlInsertItem.Parameters.AddWithValue("@item_name", itemname);
                    sqlInsertItem.Parameters.AddWithValue("@item_path", itempath);
                    sqlInsertItem.Parameters.AddWithValue("@itemID", itemid);
                    con.Open();
                    sqlInsertItem.ExecuteNonQuery();

                    Response.Redirect("Items_Admin.aspx");
                }
            }
            else
            {
                string result = "There is currently no image selected for the item!";
                Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
            }
        }
    }
}