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
    public partial class addpre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] == null)
                Response.Redirect("login.aspx");
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);
                
                    con.Open();
                    string query = "select Username from Userdata where College='" + Session["Clg"].ToString() + "' and TOU='HOD'; ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    string hod = (string)cmd.ExecuteScalar();
                con.Close();
                    SqlDataSource1.SelectCommand = "SELECT * FROM SubjectsList where CreatedBy='"+hod+"' and Subid not in (Select Subid from Prefereances where SelBy='"+Session["Username"].ToString()+"')";
            }

        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Pre")
            {
                int x = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[x];
                Connection connector = new Connection();
                Random r = new Random();
                string pid = "Pre" + r.Next(123, 99999);
                string query = "insert into Prefereances values('"+pid+"','" + row.Cells[0].Text + "','" + row.Cells[1].Text + "','" + Session["Username"].ToString() + "','" + Session["Clg"].ToString() + "');";

                bool flag = connector.MSSQLDataStore(ConfigurationManager.AppSettings["ConStr"], query);
                if (flag)
                {
                    Response.Write("<script>alert('Added!!!');</script>");
                    Response.Write("<script>window.location='addpre.aspx';</script>");

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