using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WEBURL.Models;

namespace WEBURL.Controllers
{
    public class WebUrlViewController : Controller
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStrWebUrl"].ConnectionString);
        // GET: WebUrlView
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WebUrlView()
        {
            try
            {
                WebUrlModelFireFighters masterTableData = new WebUrlModelFireFighters();
                masterTableData.WUVTabledatafromdbFireFighters = this.TimelineviewFirstfighters();
                masterTableData.WUVTabledatafromdbFireAiders = this.TimelineviewFirstaiders();


                return View(masterTableData);

            }
            catch (Exception)
            {
                return RedirectToAction("WebUrlView", "WebUrlView");
            }
        }


        public IList<WebUrlModelFireAiders> TimelineviewFirstaiders()
        {
            List<WebUrlModelFireAiders> Fireaidertable = new List<WebUrlModelFireAiders>();
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("WebUrlDataFetch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pool", "FireAiders");
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    WebUrlModelFireAiders rowAidersFromDB = new WebUrlModelFireAiders();
                    rowAidersFromDB.FAsno = Convert.ToInt32( read[0].ToString());
                    rowAidersFromDB.FAname= read[2].ToString();
                    rowAidersFromDB.FAdepartment = read[3].ToString();
                    rowAidersFromDB.FApunchcount = read[5].ToString();
                    Fireaidertable.Add(rowAidersFromDB);
                }
                read.Close();
                conn.Close();
            }
            catch (Exception e1)
            {
                throw;
            }
            return Fireaidertable;
        }

        public IList<WebUrlModelFireFighters> TimelineviewFirstfighters()
        {
            List<WebUrlModelFireFighters> FireFightertable = new List<WebUrlModelFireFighters>();
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("WebUrlDataFetch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pool", "FireFighters");
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    WebUrlModelFireFighters rowFightersFromDB = new WebUrlModelFireFighters();
                    rowFightersFromDB.FFsno = Convert.ToInt32(read[0].ToString());
                    rowFightersFromDB.FFname = read[2].ToString();
                    rowFightersFromDB.FFdepartment = read[3].ToString();
                    rowFightersFromDB.FFpunchcount = read[5].ToString();
                    FireFightertable.Add(rowFightersFromDB);
                }
                read.Close();
                conn.Close();
            }
            catch (Exception e1)
            {
                throw;
            }
            return FireFightertable;
        }




    }
}