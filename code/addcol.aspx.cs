using SqlConnectionValidator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Code
{
    public partial class addcol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void subcode_TextChanged(object sender, EventArgs e)
        {

        }


        protected void Reset(object sender, EventArgs e)
        {
            Resetter();
        }

        void Resetter()
        {
            Response.Redirect("addcol.aspx");

        }

        protected void Submit(object sender, EventArgs e)
        {
                Connection connector = new Connection();
            Random r = new Random();
            string cid = "Col" + r.Next(123, 9999);
                string query = "insert into CollegeList values('"+cid+"','" + cname.Text + "','" + coladdr.Text + "','" + cemail.Text + "','" + cphone.Text+ "');";

                bool flag = connector.MSSQLDataStore(ConfigurationManager.AppSettings["ConStr"], query);
                if (flag)
                {
                    Response.Write("<script>alert('Lecturer Account has been created!!!');</script>");
                    Response.Write("<script>window.location='addcol.aspx';</script>");

                }
        }

    }
}