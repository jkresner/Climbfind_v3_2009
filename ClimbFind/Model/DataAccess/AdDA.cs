using System.Collections.Generic;
using System.Linq;
using ClimbFind.Model.Objects;
using LinqToSql_Ad = ClimbFind.Model.LinqToSqlMapping.Ad;
using System;
using System.Data.SqlClient;
using ClimbFind.Controller;
using System.Configuration;
using System.Data;

namespace ClimbFind.Model.DataAccess
{
    public class AdDA : AbstractBaseDA<Ad, LinqToSql_Ad, int>
    {
        public string ConnectionStriong { get { return ConfigurationManager.ConnectionStrings["ClimbFindDB"].ToString(); }}

        public void AddOneImpression(int adID)
        {
            using (SqlConnection dbCon = new SqlConnection(ConnectionStriong))
            {
                using (SqlCommand cmd = new SqlCommand("SiteAds.AddOneAdImpression", dbCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = dbCon;
                    cmd.Parameters.Add("@AdId", SqlDbType.Int).Value = adID;

                    dbCon.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<Ad> GetClientsAds(int clientID)
        {
            return MapList((from c in EntityTable where c.ClientID == clientID select c).ToList());
        }

        
        
    }

}
