using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace SnackApp.Pages
{
    public partial class Reports_Admin : System.Web.UI.Page
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
                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT users.user_name, user_items.numberOfItems, items.item_name FROM ((Users INNER JOIN user_items ON users.userID = user_items.fk_userID) INNER JOIN items ON items.itemID = user_items.fk_itemID);", con);
                    DataTable data = new DataTable();
                    con.Open();
                    da.Fill(data);

                    tbl_reports.DataSource = data;
                    tbl_reports.DataBind();

                    if (data.Rows.Count == 0)
                    {
                        string result = "There are currently no reports available!";
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

        protected void btn_createSingleUserReport_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            bindGridForSingleUserReport(username);
            if (rd_singleReportUser_outputTypePDF.Checked)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + username + "Report.pdf");
                Response.Charset = "";
                Response.ContentType = "application/pdf";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                tbl_reports.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.Write(pdfDoc);
                tbl_reports.AllowPaging = false;
                tbl_reports.DataBind();
            }
            else if (rd_singleReportUser_outputTypeTXT.Checked)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename="+ username + "Report.txt");
                Response.Charset = "";
                Response.ContentType = "application/text";
                tbl_reports.AllowPaging = false;
                tbl_reports.DataBind();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < tbl_reports.Columns.Count; i++)
                {
                    sb.Append(tbl_reports.Columns[i].HeaderText + ';');
                }
                sb.Append("\r\n");
                for (int i = 0; i < tbl_reports.Rows.Count; i++)
                {
                    for (int j = 0; j < tbl_reports.Columns.Count; j++)
                    {
                        sb.Append(tbl_reports.Rows[i].Cells[j].Text + ';');
                    }
                    sb.Append("\r\n");
                }
                Response.Output.WriteLine(sb.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                string result = "There is currently no Output Type selected!";
                Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
            }
        }

        protected void btn_createTotalUserReport_Click(object sender, EventArgs e)
        {
            bindGridForTotalReport();
            if (rd_totalUserReport_outputTypePDF.Checked)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=TotalReport.pdf");
                Response.Charset = "";
                Response.ContentType = "application/pdf";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                tbl_reports.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.Write(pdfDoc);
                tbl_reports.AllowPaging = false;
                tbl_reports.DataBind();
            }
            else if (rd_totalUserReport_outputTypeTXT.Checked)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=TotalReport.txt");
                Response.Charset = "";
                Response.ContentType = "application/text";
                tbl_reports.AllowPaging = false;
                tbl_reports.DataBind();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < tbl_reports.Columns.Count; i++)
                {
                    sb.Append(tbl_reports.Columns[i].HeaderText + ';');
                }
                sb.Append("\r\n");
                for (int i = 0; i < tbl_reports.Rows.Count; i++)
                {
                    for (int j = 0; j < tbl_reports.Columns.Count; j++)
                    {
                        sb.Append(tbl_reports.Rows[i].Cells[j].Text + ';');
                    }
                    sb.Append("\r\n");
                }
                Response.Output.WriteLine(sb.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                string result = "There is currently no Output Type selected!";
                Response.Write("<script type='text/javascript'>alert('" + result + "')</script>");
            }
        }

        protected void bindGridForTotalReport()
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT users.user_name, user_items.numberOfItems, items.item_name FROM ((Users INNER JOIN user_items ON users.userID = user_items.fk_userID) INNER JOIN items ON items.itemID = user_items.fk_itemID);", con);
                DataTable data = new DataTable();
                con.Open();
                da.Fill(data);

                tbl_reports.DataSource = data;
                tbl_reports.DataBind();
            }
        }

        protected void bindGridForSingleUserReport(string username)
        {
            Utilities utils = new Utilities();
            int userid = utils.getUserÌD(username);

            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT users.user_name, user_items.numberOfItems, items.item_name FROM ((Users INNER JOIN user_items ON users.userID = user_items.fk_userID) INNER JOIN items ON items.itemID = user_items.fk_itemID) WHERE users.userid = @userid;", con);
                da.SelectCommand.Parameters.AddWithValue("@userid", userid);
                DataTable data = new DataTable();
                con.Open();
                da.Fill(data);

                tbl_reports.DataSource = data;
                tbl_reports.DataBind();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error
        }
    }
}