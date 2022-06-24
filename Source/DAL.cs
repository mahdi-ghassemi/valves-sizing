using System;
using System.Data;
using System.Data.SqlClient;

namespace Radman
{
    public class DAL
    {
        
        private string _storedProcedureName;
        private string _query;

        public string StoredProcedureName
        {
            get
            {
                return _storedProcedureName;
            }
            set
            {
                _storedProcedureName = value;
            }
        }

        public string Query
        {
            get
            {
                return _query;
            }
            set
            {
                _query = value;
            }
        }

        public DAL()
        {
            _storedProcedureName = "";
            _query = "";
        }       

        public DataTable ExcecuteStoredProcedureToDataTable()
        {
            try
            {
                SqlConnection _sqlc8 = new SqlConnection();
                _sqlc8.ConnectionString = Program.ConnectionString;
                SqlCommand _sqlCommand8 = new SqlCommand(_storedProcedureName, _sqlc8);
                _sqlCommand8.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(_sqlCommand8);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Table");
                DataTable dt = ds.Tables["Table"];
                sda.Dispose();
                _sqlCommand8.Dispose();
                _sqlc8.Close();
                _sqlc8.Dispose();
                return dt;
            }
            catch (Exception e)
            {                
                return null;
            }
        }

        public DataTable ExcecuteSelectQueryToDataTable()
        {
            try
            {
                SqlConnection _msqlc = new SqlConnection();
                _msqlc.ConnectionString = Program.ConnectionString;
                SqlCommand _msqlCommand = new SqlCommand(_query, _msqlc);
                SqlDataAdapter msda = new SqlDataAdapter(_msqlCommand);
                DataSet mds = new DataSet();
                msda.Fill(mds, "mTable");
                DataTable mdt = mds.Tables["mTable"];
                msda.Dispose();
                _msqlCommand.Dispose();
                _msqlc.Close();
                _msqlc.Dispose();
                return mdt;
            }
            catch (Exception e)
            {               
                return null;
            }
        }

        /// <summary>
        /// This method execute a stored procedure and return a int type value
        /// </summary>
        /// <param name="SpParams">Parametrs to send in store procedure</param>
        /// <returns>Int type return value</returns>
        public int IntExcuteSP(string[,] SpParams)
        {
            try
            {
                int _result = 0;
                SqlConnection _sqlc2 = new SqlConnection();
                _sqlc2.ConnectionString = Program.ConnectionString;
                SqlCommand _sqlCommand2 = new SqlCommand(_storedProcedureName, _sqlc2);
                _sqlCommand2.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCommand2.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCommand2.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                _sqlCommand2.Parameters.Add("@Result", SqlDbType.Int);
                _sqlCommand2.Parameters["@Result"].Direction = ParameterDirection.Output;

                _sqlc2.Open();
                _sqlCommand2.ExecuteReader();
                _sqlc2.Close();
                _sqlc2.Dispose();

                _result = Convert.ToInt32(_sqlCommand2.Parameters["@Result"].Value.ToString());

                return _result;
            }
            catch (Exception e)
            {                
                return -1;
            }
        }

        /// <summary>
        ///This method execute a stored procedure and return a int type value 
        /// </summary>
        /// <returns>Int type return value</returns>
        public int IntExcuteSP()
        {
            try
            {
                int _result = 0;
                SqlConnection _sqlc6 = new SqlConnection();
                _sqlc6.ConnectionString = Program.ConnectionString;
                SqlCommand _sqlCommand6 = new SqlCommand(_storedProcedureName, _sqlc6);
                _sqlCommand6.CommandType = CommandType.StoredProcedure;

                _sqlCommand6.Parameters.Add("@Result", SqlDbType.Int);
                _sqlCommand6.Parameters["@Result"].Direction = ParameterDirection.Output;

                _sqlc6.Open();
                _sqlCommand6.ExecuteReader();
                _sqlc6.Close();
                _sqlc6.Dispose();


                _result = Convert.ToInt32(_sqlCommand6.Parameters["@Result"].Value.ToString());

                return _result;
            }
            catch (Exception)
            {              
                return -1;
            }
        }

        public DataTable ExcecuteQueryToDataTable(string[,] SpParams)
        {
            try
            {
                SqlConnection _sqlConnectionN = new SqlConnection();
                _sqlConnectionN.ConnectionString = Program.ConnectionString;
                SqlCommand _sqlCommandN;
                _sqlCommandN = new SqlCommand(_storedProcedureName, _sqlConnectionN);
                _sqlCommandN.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCommandN.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCommandN.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                SqlDataAdapter sda = new SqlDataAdapter(_sqlCommandN);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Table");
                DataTable dt = ds.Tables["Table"];
                sda.Dispose();
                _sqlCommandN.Dispose();
                _sqlConnectionN.Close();
                _sqlConnectionN.Dispose();
                return dt;
            }
            catch (Exception e)
            {               
                return null;
            }
        }

        public int IntExcuteSP(string[,] SpParams, byte[] ImageData)
        {
            try
            {
                int _result = 0;
                SqlConnection _sqlc = new SqlConnection();
                _sqlc.ConnectionString = Program.ConnectionString;
                SqlCommand _sqlCom = new SqlCommand(_storedProcedureName, _sqlc);
                _sqlCom.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCom.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCom.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                if (ImageData != null)
                {
                    _sqlCom.Parameters.AddWithValue("@Image", (object)ImageData);
                    _sqlCom.Parameters["@Image"].Direction = ParameterDirection.Input;
                }

                _sqlCom.Parameters.Add("@Result", SqlDbType.Int);
                _sqlCom.Parameters["@Result"].Direction = ParameterDirection.Output;

                _sqlc.Open();
                _sqlCom.ExecuteReader();
                _sqlc.Close();
                _sqlc.Dispose();

                _result = Convert.ToInt32(_sqlCom.Parameters["@Result"].Value.ToString());

                return _result;
            }
            catch (Exception e)
            {
                return -1;              
            }
        }

        public int InsertPersonnelInfo(string[,] SpParams, byte[] ImageData)
        {
            try
            {
                SqlConnection _sqlc3 = new SqlConnection();
                _sqlc3.ConnectionString = Program.ConnectionString;
                SqlCommand _sqlCommand3 = new SqlCommand(_storedProcedureName, _sqlc3);
                _sqlCommand3.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCommand3.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCommand3.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                _sqlCommand3.Parameters.AddWithValue("@Image", (object)ImageData);
                _sqlCommand3.Parameters["@Image"].Direction = ParameterDirection.Input;



                _sqlc3.Open();
                _sqlCommand3.ExecuteNonQuery();
                _sqlc3.Close();
                _sqlc3.Dispose();
                return 1;

            }
            catch (Exception e)
            {
                return 0;        
            }
        }

        public void DeletePersonnelInfo(string AgentID)
        {
            try
            {
                SqlConnection _sqlc4 = new SqlConnection();
                _sqlc4.ConnectionString = Program.ConnectionString;
                SqlCommand _sqlCommand4 = new SqlCommand(_storedProcedureName, _sqlc4);
                _sqlCommand4.CommandType = CommandType.StoredProcedure;

                _sqlCommand4.Parameters.AddWithValue("@AgentID", AgentID);
                _sqlCommand4.Parameters["@AgentID"].Direction = ParameterDirection.Input;

                _sqlc4.Open();
                _sqlCommand4.ExecuteNonQuery();
                _sqlc4.Close();
                _sqlc4.Dispose();

            }
            catch (Exception e)
            {               

            }
        }

        public int UpdatePersonnelInfo(string[,] SpParams, byte[] ImageData)
        {
            try
            {
                SqlConnection _sqlc5 = new SqlConnection();
                _sqlc5.ConnectionString = Program.ConnectionString;
                SqlCommand _sqlCommand5 = new SqlCommand(_storedProcedureName, _sqlc5);
                _sqlCommand5.CommandType = CommandType.StoredProcedure;

                int _lenght = (SpParams.Length) / 2;

                for (int i = 0; i < _lenght; i++)
                {

                    _sqlCommand5.Parameters.AddWithValue(SpParams[i, 0], SpParams[i, 1].Trim());
                    _sqlCommand5.Parameters[SpParams[i, 0]].Direction = ParameterDirection.Input;

                }

                if (ImageData != null)
                {
                    _sqlCommand5.Parameters.AddWithValue("@Image", (object)ImageData);
                    _sqlCommand5.Parameters["@Image"].Direction = ParameterDirection.Input;
                }


                _sqlc5.Open();
                _sqlCommand5.ExecuteNonQuery();
                _sqlc5.Close();
                _sqlc5.Dispose();
                return 1;

            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
