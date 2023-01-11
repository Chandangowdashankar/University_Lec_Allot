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
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Reset(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            Session.Clear();
            if (uname.Value.Equals(string.Empty) | pswd.Value.Equals(string.Empty))
            {
                Response.Write("<script>alert('Please enter the details!!!');</script>");
            }
            else
            {
                if (uname.Value.Equals("admin") & pswd.Value.Equals("admin"))
                {
                    Session["Username"] = uname.Value;
                    Response.Redirect("adminhome.aspx");
                }
                else
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);
                    try
                    {
                        con.Open();
                        string query = "select * from Userdata where Username='" + uname.Value + "' and Password='" + pswd.Value + "' and UStatus='Approved'; ";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                string un = dr.GetValue(0).ToString();
                                string pd = dr.GetValue(1).ToString();
                                string tou = dr.GetValue(7).ToString();
                                string us = dr.GetValue(8).ToString();
                                if(uname.Value.Equals(un)& pswd.Value.Equals(pd)&us.Equals("Approved") & tou=="Student")
                                {
                                    Session["Username"] = uname.Value;
                                    Response.Redirect("stuhome.aspx");
                                }
                                if (uname.Value.Equals(un) & pswd.Value.Equals(pd) & us.Equals("Approved") & tou== "HOD")
                                {
                                    Session["Clg"] = dr.GetValue(10).ToString(); ;
                                    Session["Username"] = uname.Value;
                                    Response.Redirect("hodhome.aspx");
                                }
                                if (uname.Value.Equals(un) & pswd.Value.Equals(pd) & us.Equals("Approved") & tou == "Lecturer")
                                {
                                    Session["Clg"] = dr.GetValue(10).ToString(); ;
                                    Session["Username"] = uname.Value;
                                    Response.Redirect("lechome.aspx");
                                }
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid User!!!');</script>");
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}