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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Reset(object sender, EventArgs e)
        {
            Resetter();
        }

        void Resetter()
        {
            Response.Redirect("register.aspx");

        }

        protected void Submit(object sender, EventArgs e)
        {
            if (uname.Value == "" || cpswd.Value == "" || name.Value == "" || age.Value == "" || gender.Value == "--Select--" || mailid.Value == "" || phone.Value == "")
            {
                Response.Write("<script>alert('Please fill all details!!!');</script>");
            }
            else
            {
                if (pswd.Value.Equals(cpswd.Value))
                {



                    Connection connector = new Connection();
                    string ustatus = "Approved";

                    string query = "insert into Userdata values('" + uname.Value + "','" + pswd.Value + "','" + name.Value + "','" + age.Value + "','" + mailid.Value + "','" + gender.Value + "','" + phone.Value + "','HOD','" + ustatus + "','Self','" + DropDownList1.SelectedValue + "');";

                    bool flag = connector.MSSQLDataStore(ConfigurationManager.AppSettings["ConStr"], query);
                    if (flag)
                    {
                        Response.Write("<script>alert('Thank you for registering with us!!!');</script>");
                        Response.Write("<script>window.location='register.aspx';</script>");

                    }
                }
                else
                {
                    Response.Write("<script>alert('Password is not matching with confirm password !!!');</script>");
                }
            }
        }
    }
}