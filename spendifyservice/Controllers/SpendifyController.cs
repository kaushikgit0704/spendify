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

        [HttpPost]
        [Route("api/addSpends")]
        public void addNewSpend(List<spenddetails> spends)
        {
            if (spends.Count > 0)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["spendifyconnection"].ConnectionString);
                foreach (spenddetails spend in spends)
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[addNewSpend]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@spenderName", spend.spenderName);
                    cmd.Parameters.AddWithValue("@spendDesc", spend.spendDescription);
                    cmd.Parameters.AddWithValue("@spendAmount", Convert.ToDecimal(spend.spendAmount));
                    cmd.Parameters.AddWithValue("@spendDate", Convert.ToDateTime(spend.spenddate));
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception exp)
                    {
                    }
                    finally
                    {
                        conn.Close();
                    }
                }                
            }
        }
    }    
}
