using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DBManager : IDisposable
    {
        SqlConnection sqlConn;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;
        DataTable DT;
        DataSet DS;

        public DBManager()
        {
            try
            {
                sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["HotelConn"].ConnectionString);
                sqlCmd = new SqlCommand("", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlDA = new SqlDataAdapter(sqlCmd);
                DT = new DataTable();
                DS = new DataSet();

            }
            catch (Exception ex)
            {
               
            }
        }

        public int ExecuteNonQuery(string storedProcedure)
        {
            int R = -1;
            try
            {
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = storedProcedure;

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                R = sqlCmd.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception ex)
            {

            }
            return R;
        }

        public object ExecuteScaler(string storedProcedure, Dictionary<string, object> Parms)
        {
            object R = new object();
            try
            {
                sqlCmd.Parameters.Clear();

                foreach (var item in Parms)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = storedProcedure;

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                R = sqlCmd.ExecuteScalar();

                sqlConn.Close();
            }
            catch (Exception ex)
            {

            }
            return R;
        }


        public DataSet ExecuteDataSet(string storedProcedure)
        {
            try
            {
                DS.Clear();
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = storedProcedure;

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                sqlDA.Fill(DS);
                return DS;
            }
            catch (Exception ex)
            {

            }
            return new DataSet();
        }


        public DataSet ExecuteDataSet(string storedProcedure, Dictionary<string, object> Parms)
        {
            try
            {
                DS.Clear();
                sqlCmd.Parameters.Clear();


                foreach (var item in Parms)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));


                sqlCmd.CommandText = storedProcedure;

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                sqlDA.Fill(DS);
                return DS;
            }
            catch (Exception ex)
            {

            }
            return new DataSet();
        }



        public int ExecuteNonQuery(string storedProcedure, Dictionary<string, object> Parms)
        {
            int R = -1;
            try
            {
                sqlCmd.Parameters.Clear();

                foreach (var item in Parms)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = storedProcedure;

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                R = sqlCmd.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception ex)
            {

            }
            return R;
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
