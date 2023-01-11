using SqlConnectionValidator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Code
{
    public partial class delsub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("login.aspx");
            else
            {
                SqlDataSource1.SelectCommand = "SELECT * FROM SubjectsList where CreatedBy='"+Session["Username"].ToString()+"'";
            }

        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Delete")
            {
                int x = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[x];
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);
                try
                {
                    con.Open();
                    string query = "delete from SubjectsList where Subid='" + row.Cells[0].Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                    Response.Redirect("delsub.aspx");
                }
            }
        }

        protected void RowDelete(Object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                GridView1.EmptyDataText = "Row deleted successfully.";
            }

        }
    }
}