using SqlConnectionValidator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
namespace Code
{
    public partial class examsch : System.Web.UI.Page
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
                SqlDataSource1.SelectCommand = "SELECT * FROM ExamData where CName='"+Session["Clg"].ToString()+"'";
            }

        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Delete")
            {
                int x = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[x];
                string clgAddress = string.Empty;
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConStr"]);
                try
                {
                    con.Open();
                    string query = "select CAddress from CollegeList where CName='" + row.Cells[1].Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    clgAddress = (string)cmd.ExecuteScalar();


                    query = "Select Count(*) from CollegeList";
                    cmd = new SqlCommand(query, con);
                    int clgcount = (int)cmd.ExecuteScalar();

                    Dictionary<string, double> distances = new Dictionary<string, double>();


                    query = "Select CName,CAddress from CollegeList where CName<>'" + row.Cells[1].Text + "';";
                    cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            double val = GetDistance(dr.GetValue(1).ToString(), clgAddress);
                            distances.Add(dr.GetValue(0).ToString(), val);
                        }
                    }
                    dr.Close();


                    var myList = distances.ToList();
                    myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));


                    //var list = distances.Values.ToList();
                  //  list.Sort();

                    string nearestclg = string.Empty;

                    int incrementor = 0;
                    // Loop through keys.
                    foreach (var key in myList)
                    {
                        nearestclg = key.Key;
                        break;
                        //Console.WriteLine("{0}: {1}", key, distances[key]);
                    }

                    query = "Select SelBy from Prefereances where CName='"+ nearestclg + "'";
                    cmd = new SqlCommand(query, con);
                    string slec =(string) cmd.ExecuteScalar();


                    query = "Update ExamData set AllotLec='"+slec+"' where Eid='" + row.Cells[0].Text + "'";
                    cmd = new SqlCommand(query, con);
                   cmd.ExecuteNonQuery();



                }
                catch
                {
                }
                finally
                {
                    con.Close();
                    Response.Redirect("examsch.aspx");
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