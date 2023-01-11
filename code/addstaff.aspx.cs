using SqlConnectionValidator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Code
{
    public partial class addstaff : System.Web.UI.Page
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
            Response.Redirect("register.aspx");

        }

        protected void Submit(object sender, EventArgs e)
        {
            if (uname.Value == "" || name.Value == "" || age.Value == "" || gender.Value == "--Select--" || mailid.Value == "" || phone.Value == "")
            {
                Response.Write("<script>alert('Please fill all details!!!');</script>");
            }
            else
            {
                    Connection connector = new Connection();
                    string ustatus = "Approved";
                    string password = CreatePassword(6);

                    string query = "insert into Userdata values('" + uname.Value + "','" + password + "','" + name.Value + "','" + age.Value + "','" + mailid.Value + "','" + gender.Value + "','" + phone.Value + "','Lecturer','" + ustatus + "','" + Session["Username"].ToString() + "','" + DropDownList1.SelectedValue + "');";

                bool flag = connector.MSSQLDataStore(ConfigurationManager.AppSettings["ConStr"], query);
                    if (flag)
                    {
                    try
                    {
                        MailMessage m = new MailMessage("myprojectmandya@gmail.com", mailid.Value, "Account Creation Mail !!!", "​Account Creation page!!!\n Your Username is: " + uname.Value + "\n Your Password is: " + password + "");
                        SmtpClient s = new SmtpClient("smtp.gmail.com", 587);
                        s.Credentials = new System.Net.NetworkCredential("myprojectmandya@gmail.com", "mandyamandya");
                        s.EnableSsl = true;
                        s.Send(m);
                    }
                    catch(Exception ex)
                    {
                    }
                    Response.Write("<script>alert('Lecturer Account has been created!!!');</script>");
                        Response.Write("<script>window.location='addstaff.aspx';</script>");

                    }
            }
        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }


    }
}