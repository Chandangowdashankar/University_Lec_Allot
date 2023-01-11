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
    public partial class valfee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            data.Visible = false;
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
            data.Visible = true;

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);
            try
            {
                con.Open();
                string query = "select * from Challan where USN='" + usn.Value + "'; ";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        usn1.Text = dr.GetValue(1).ToString();
                        course.Text = dr.GetValue(2).ToString();
                        sem.Text = dr.GetValue(3).ToString();
                        scount.Text = dr.GetValue(4).ToString();
                        amt.Text = dr.GetValue(5).ToString();
                        stat.Text = dr.GetValue(6).ToString();

                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid USN!!!');</script>");
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