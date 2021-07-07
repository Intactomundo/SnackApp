using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;

namespace SnackApp.Pages
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilities utils = new Utilities();
            if (Session["user"] != null)
            {
                string username = Session["user"].ToString();

                if (Session["language"] != null)
                {
                    string language = Session["language"].ToString();
                    setUIToSelectedLanguage(language);

                    int userid = utils.getUserÌD(username);

                    string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(@"SELECT items.item_path, user_items.numberOfItems, user_items.user_itemsID FROM items FULL JOIN user_items ON items.itemID = user_items.fk_itemID WHERE user_items.fk_userID = @userid;", con);
                        da.SelectCommand.Parameters.AddWithValue("@userid", userid);
                        DataTable data = new DataTable();
                        con.Open();
                        da.Fill(data);

                        tbl_itemsConsumed.DataSource = data;
                        tbl_itemsConsumed.DataBind();

                        if (data.Rows.Count == 0)
                        {
                            string result = "There are currently no Snacks available!";
                            Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                        }
                    }
                }
                else
                {
                    Session["language"] = Request.UserLanguages[0];
                }
            }
            else
            {
                string result = "No user from whom to pull the data has been found!";
                Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
                Response.Redirect("Login.aspx");
            }
        }

        protected void tbl_itemsConsumed_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                // Get Current Number of Items Consumed by User
                SqlCommand sqlGetNumberOfItemsConsumed = new SqlCommand(@"SELECT numberOfItems FROM user_items WHERE user_itemsID = @user_itemsID;", con);
                sqlGetNumberOfItemsConsumed.Parameters.AddWithValue("@user_itemsID", tbl_itemsConsumed.Rows[e.RowIndex].Cells[0].Text);
                con.Open();
                Int32 numberOfItems = (Int32)sqlGetNumberOfItemsConsumed.ExecuteScalar();

                // Update Number of Item Consumed by User
                SqlCommand sqlAddItemConsumed = new SqlCommand(@"UPDATE user_items SET numberOfItems = @numberOfItems WHERE user_itemsID = @user_itemsID", con);
                sqlAddItemConsumed.Parameters.AddWithValue("@user_itemsID", tbl_itemsConsumed.Rows[e.RowIndex].Cells[0].Text);
                sqlAddItemConsumed.Parameters.AddWithValue("@numberOfItems", numberOfItems + 1);
                sqlAddItemConsumed.ExecuteNonQuery();
                Response.Redirect("Main.aspx");
            }
        }

        protected void setUIToSelectedLanguage(string language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            ResourceManager rm = new ResourceManager("SnackApp.App_GlobalResources.language", Assembly.GetExecutingAssembly());
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;

            nav_home.InnerHtml = rm.GetString("Home", ci);
            ddl_language_selector.InnerHtml = rm.GetString("Language", ci);
            tbl_itemsConsumed.Columns[0].HeaderText = rm.GetString("Snack Number", ci);
            tbl_itemsConsumed.Columns[1].HeaderText = rm.GetString("Snack Image", ci);
            tbl_itemsConsumed.Columns[2].HeaderText = rm.GetString("Number of Snack Consumed", ci);
            tbl_itemsConsumed.Columns[3].HeaderText = rm.GetString("Add 1 Item Consumed", ci);
        }

        protected void btn_languageEnglish_ServerClick(object sender, EventArgs e)
        {
            string language = "en-US";
            Session["language"] = language;
            string username = Session["user"].ToString();

            Utilities utils = new Utilities();
            utils.updateUserLanguage(username, language);
            Response.Redirect("Main.aspx");
        }

        protected void btn_languageGêrman_ServerClick(object sender, EventArgs e)
        {
            string language = "de-DE";
            Session["language"] = language;
            string username = Session["user"].ToString();

            Utilities utils = new Utilities();
            utils.updateUserLanguage(username, language);
            Response.Redirect("Main.aspx");
        }

        protected void btn_languageFrench_ServerClick(object sender, EventArgs e)
        {
            string language = "fr-FR";
            Session["language"] = language;
            string username = Session["user"].ToString();

            Utilities utils = new Utilities();
            utils.updateUserLanguage(username, language);
            Response.Redirect("Main.aspx");
        }
    }
}