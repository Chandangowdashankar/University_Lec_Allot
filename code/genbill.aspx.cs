using ceTe.DynamicPDF;
using SqlConnectionValidator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Device.Location;

namespace Code
{
    public partial class genbill : System.Web.UI.Page
    {
        string Latitude = string.Empty;
        string Longitude = string.Empty;
        double sLatitude = 0, eLatitude = 0, sLongitude = 0, eLongitude = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("login.aspx");
            else
            {
                SqlDataSource1.SelectCommand = "SELECT * FROM ExamData where AllotLec='"+Session["Username"].ToString()+"'";
            }

        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Gen")
            {
                int x = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[x];



                string fullfilename = "ExamClaim.pdf";
                Document document = new Document();

                string clgAddress = string.Empty;
                string clgAddress1 = string.Empty;
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);
                try
                {
                    con.Open();
                    string query = "select CAddress from CollegeList where CName='" + Session["Clg"].ToString() + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    clgAddress = (string)cmd.ExecuteScalar();

                    query = "select CAddress from CollegeList where CName='" + row.Cells[2].Text + "';";
                    cmd = new SqlCommand(query, con);
                    clgAddress1 = (string)cmd.ExecuteScalar();


                }
                catch
                {
                }
                finally
                {
                    con.Close();
                    //Response.Redirect("delsub.aspx");
                }

                ceTe.DynamicPDF.Page page = new ceTe.DynamicPDF.Page();
                document.Pages.Add(page);

                ceTe.DynamicPDF.PageElements.Label Heading = new ceTe.DynamicPDF.PageElements.Label("Challan Generate", 120, 50, 300, 250, ceTe.DynamicPDF.Font.HelveticaBold, 25);
                Heading.TextColor = RgbColor.Blue;
                Heading.Underline = true;
                page.Elements.Add(Heading);
                ceTe.DynamicPDF.PageElements.Label l = new ceTe.DynamicPDF.PageElements.Label("Name:", 150, 100, 100, 50, ceTe.DynamicPDF.Font.HelveticaBold, 15);

                ceTe.DynamicPDF.PageElements.Label lname = new ceTe.DynamicPDF.PageElements.Label(Session["Username"].ToString(), 250, 100, 100, 50);
                page.Elements.Add(lname);
                ceTe.DynamicPDF.PageElements.Label l1 = new ceTe.DynamicPDF.PageElements.Label("College:", 150, 150, 100, 50, ceTe.DynamicPDF.Font.HelveticaBold, 15);
                ceTe.DynamicPDF.PageElements.Label ldob = new ceTe.DynamicPDF.PageElements.Label(Session["Clg"].ToString(), 250, 150, 100, 50);
                page.Elements.Add(ldob);
                ceTe.DynamicPDF.PageElements.Label l2 = new ceTe.DynamicPDF.PageElements.Label("Convenience:", 150, 200, 100, 50, ceTe.DynamicPDF.Font.HelveticaBold, 15);
                ceTe.DynamicPDF.PageElements.Label lpid = new ceTe.DynamicPDF.PageElements.Label("300 Rs", 250, 200, 100, 50);
                page.Elements.Add(lpid);
                ceTe.DynamicPDF.PageElements.Label l3 = new ceTe.DynamicPDF.PageElements.Label("Distance Travelled:", 150, 250, 100, 50, ceTe.DynamicPDF.Font.HelveticaBold, 15);
                double val = GetDistance(clgAddress1, clgAddress);
                
                string val1=String.Format("{0:0.##}", val);
                ceTe.DynamicPDF.PageElements.Label ladmit = new ceTe.DynamicPDF.PageElements.Label(val1.ToString(), 250, 250, 100, 50);
                page.Elements.Add(ladmit);

                double taAmount = 0.0F;
                if(val>25)
                    taAmount = val*6;
                ceTe.DynamicPDF.PageElements.Label l4 = new ceTe.DynamicPDF.PageElements.Label("TA & DA:", 150, 300, 100, 50, ceTe.DynamicPDF.Font.HelveticaBold, 15);
                ceTe.DynamicPDF.PageElements.Label ltype = new ceTe.DynamicPDF.PageElements.Label(taAmount.ToString() +" Rs", 250, 300, 100, 50);
                page.Elements.Add(ltype);
                ceTe.DynamicPDF.PageElements.Label l5 = new ceTe.DynamicPDF.PageElements.Label("Type:", 150, 350, 500, 50, ceTe.DynamicPDF.Font.HelveticaBold, 15);
                ceTe.DynamicPDF.PageElements.Label lcontaminant = new ceTe.DynamicPDF.PageElements.Label(row.Cells[4].Text, 250, 350, 500, 50);
                page.Elements.Add(lcontaminant);

                ceTe.DynamicPDF.PageElements.Label l6 = new ceTe.DynamicPDF.PageElements.Label("Students #:", 150, 400, 500, 50, ceTe.DynamicPDF.Font.HelveticaBold, 15);
                ceTe.DynamicPDF.PageElements.Label l6dat = new ceTe.DynamicPDF.PageElements.Label(row.Cells[5].Text, 250, 400, 500, 50);
                page.Elements.Add(l6dat);
                page.Elements.Add(l6);

                double tot = 0.0;
                if(row.Cells[4].Text=="Fresher")
                tot=300 + taAmount + Convert.ToInt32(row.Cells[5].Text) * 40;
                else
                    tot = 300 + taAmount + Convert.ToInt32(row.Cells[5].Text) * 80;

                ceTe.DynamicPDF.PageElements.Label l7 = new ceTe.DynamicPDF.PageElements.Label("Total Amount:", 150, 450, 500, 50, ceTe.DynamicPDF.Font.HelveticaBold, 15);
                ceTe.DynamicPDF.PageElements.Label l6dat1 = new ceTe.DynamicPDF.PageElements.Label(tot.ToString(), 250, 450, 500, 50);
                page.Elements.Add(l6dat1);
                page.Elements.Add(l7);

                string src = Server.MapPath(@"./") + "sign.png";

                ceTe.DynamicPDF.PageElements.Image image = new ceTe.DynamicPDF.PageElements.Image(src, 380, 550);
                // Set the dpi of the image
                image.SetDpi(600);
                page.Elements.Add(image);// new ceTe.DynamicPDF.PageElements.Image(src, 350, 250,200));
                ceTe.DynamicPDF.PageElements.Label signl = new ceTe.DynamicPDF.PageElements.Label("Authorized Signatory", 340, 580, 200, 50, ceTe.DynamicPDF.Font.TimesBold, 14, ceTe.DynamicPDF.TextAlign.Left);
                signl.Underline = true;
                page.Elements.Add(signl);

                page.Elements.Add(l);
                page.Elements.Add(l1);
                page.Elements.Add(l2);
                page.Elements.Add(l3);
                page.Elements.Add(l4);
                page.Elements.Add(l5);

                con = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);
                try
                {
                    con.Open();
                    String Bid = "Bi";
                    Random rrz = new Random();
                    Bid = Bid + rrz.Next(111111,999999).ToString();
                    string query = "insert into Bill values ('"+Bid+"','"+row.Cells[0].Text+ "','" + row.Cells[1].Text + "','" + row.Cells[2].Text + "','" + row.Cells[3].Text + "','" + row.Cells[5].Text + "','" + row.Cells[4].Text + "','" + tot + "','Pending');";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                    //Response.Redirect("delsub.aspx");
                }



                try
                {
                    // Save the PDF
                    document.Draw(@"D:\" + fullfilename);
                   // con = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);
                    //try
                    //{
                    //    con.Open();
                    //    string query = "Insert into ReportData values ('" + rid + "','" + pid + "','" + name + "','" + fullfilename + "');";
                    //    SqlCommand cmd = new SqlCommand(query, con);
                    //    cmd.ExecuteNonQuery();

                    //}
                    //catch
                    //{
                    //}
                    //finally
                    //{
                    //    con.Close();
                    //}
                }
                catch
                {
                    if (File.Exists(@"D:\" + fullfilename))
                    {
                        string filename = "Bill";
                        Random r = new Random();
                        int a = r.Next(1, 999999);
                        filename += a.ToString();
                        fullfilename = filename + ".pdf";
                        document.Draw(@"D:\" + fullfilename);
                        //con = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);
                        //try
                        //{
                        //    con.Open();
                        //    string query = "Insert into ReportData values ('" + rid + "','" + pid + "','" + name + "','" + fullfilename + "');";
                        //    SqlCommand cmd = new SqlCommand(query, con);
                        //    cmd.ExecuteNonQuery();

                        //}
                        //catch
                        //{
                        //}
                        //finally
                        //{
                        //    con.Close();
                        //}
                    }
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


        public double GetDistance(string location, string pickup)
        {
            string start = pickup;
            GeoCode(start);
            sLatitude = Convert.ToDouble(Latitude);
            sLongitude = Convert.ToDouble(Longitude);

            var sCoord = new GeoCoordinate(sLatitude, sLongitude);

            GeoCode(location);
            eLatitude = Convert.ToDouble(Latitude);
            eLongitude = Convert.ToDouble(Longitude);
            var eCoord = new GeoCoordinate(eLatitude, eLongitude);

            return sCoord.GetDistanceTo(eCoord) / 1000;
        }

        protected void GeoCode(string Address)
        {
            //to Read the Stream
            StreamReader sr = null;

            //The Google Maps API Either return JSON or XML. We are using XML Here
            //Saving the url of the Google API 
            string url = String.Format("https://maps.googleapis.com/maps/api/geocode/xml?address=" + Address + "&key=AIzaSyD55Oyyz-3NOPPHbX1YNnSoAqCYdQSFLTE");

            //to Send the request to Web Client 
            WebClient wc = new WebClient();
            try
            {
                sr = new StreamReader(wc.OpenRead(url));
            }
            catch (Exception ex)
            {
                throw new Exception("The Error Occured" + ex.Message);
            }

            try
            {
                XmlTextReader xmlReader = new XmlTextReader(sr);
                bool latread = false;
                bool longread = false;

                while (xmlReader.Read())
                {
                    xmlReader.MoveToElement();
                    switch (xmlReader.Name)
                    {
                        case "lat":

                            if (!latread)
                            {
                                xmlReader.Read();
                                Latitude = xmlReader.Value.ToString();
                                latread = true;

                            }
                            break;
                        case "lng":
                            if (!longread)
                            {
                                xmlReader.Read();
                                Longitude = xmlReader.Value.ToString();
                                longread = true;
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Error Occured" + ex.Message);
            }
        }
    }
}