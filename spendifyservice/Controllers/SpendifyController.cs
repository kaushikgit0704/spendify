using System;
using System.Collections.Generic;
using System.Web.Http;
using spendifyservice.Objects;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace spendifyservice.Controllers
{
    public class SpendifyController : ApiController
    {
        [HttpGet]
        [Route("api/getAllSpends")]
        public List<spenddetails> getAllSpendDetails()
        {
            List<spenddetails> spenddetailscollection = new List<spenddetails>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["spendifyconnection"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("[dbo].[getAllSpendDetails]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dtrdr = cmd.ExecuteReader();
                while (dtrdr.Read())
                {
                    spenddetails objSpendDetails = new spenddetails();

                    objSpendDetails.id = Convert.ToInt32(dtrdr["id"].ToString());
                    objSpendDetails.spenderName = dtrdr["spender_name"].ToString();
                    objSpendDetails.spendDescription = dtrdr["spend_description"].ToString();
                    objSpendDetails.spendAmount = Convert.ToDecimal(dtrdr["spend_amount"].ToString());
                    objSpendDetails.spenddate = Convert.ToDateTime(dtrdr["spend_date"].ToString());

                    spenddetailscollection.Add(objSpendDetails);
                }
            }
            catch (Exception exp)
            {
            }
            finally
            {
                conn.Close();
            }
            return spenddetailscollection;
        }
    }
}
