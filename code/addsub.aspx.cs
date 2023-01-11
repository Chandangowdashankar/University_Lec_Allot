using SqlConnectionValidator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Code
{
    public partial class addsub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("login.aspx");
        }


        protected void Reset(object sender, EventArgs e)
        {
            Resetter();
        }

        void Resetter()
        {
            Response.Redirect("addsub.aspx");

        }

        protected void Submit(object sender, EventArgs e)
        {
            {
                    Connection connector = new Connection();
                Random r = new Random();
                String sid = "S" + r.Next(111, 6854);

                    string query = "insert into SubjectsList values('"+sid+"','" + sname.Text + "','" + subcode.Text + "','" + course.Value + "','" + sem.Value + "','"+Session["Username"].ToString()+"');";

                    bool flag = connector.MSSQLDataStore(ConfigurationManager.AppSettings["ConStr"], query);
                    if (flag)
                    {
                        Response.Write("<script>alert('Subject has been created!!!');</script>");
                        Response.Write("<script>window.location='addsub.aspx';</script>");

                    }
            }
        }
        

        protected void sname_TextChanged(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                Random r = new Random();

                subcode.Text = "Sub" + r.Next(123, 99999).ToString();
            }
        }
    }
}