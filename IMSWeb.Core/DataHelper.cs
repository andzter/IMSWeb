using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Text;


namespace IMSWeb.Core
{
    public class DataHelper
    {
        private string _conn = "";

        private string _providername = "System.Data.SqlClient";

        private const int _timeout = 1200;

        public string DBConnection()
        {
            try
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ToString();

            }
            catch (Exception ce)
            {

                throw new ApplicationException("Unable to get DB Connection string from Config File. Contact Administrator" + ce);
            }
        }

        public DataHelper()
        {
            //
            // TODO: Add constructor logic here
            //
            // get connection string from webconfig
            _conn = DBConnection();

        }

        public DataHelper(string strConnection)
        {
            _conn = strConnection;
        }

        public void SetProvider(string dbprovider)
        {
            _providername = dbprovider;
        }

        public string ConnectionString
        {
            get
            {
                return _conn;
            }
            set
            {
                _conn = value;
            }

        }




        public object ExecSQLScalarSP(string storedProc, params object[] args)
        {
            object result;
            SqlDatabase sqlDb;
            DbCommand dbCommand = null;

            sqlDb = new SqlDatabase(_conn);

            try
            {
                dbCommand = sqlDb.GetStoredProcCommand(storedProc, args);
                dbCommand.CommandTimeout = _timeout;
                result = sqlDb.ExecuteScalar(dbCommand);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in  ExecSQLScalarSP :" + storedProc + "\nError Message:" + ex.Message);
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection.State == ConnectionState.Open)
                        dbCommand.Connection.Close();
                }
            }
            return result;
        }

        public object ExecSQLScalar(string CommandText)
        {

            object obj;

            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(_providername);

                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = _conn;
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = CommandText;
                        command.CommandTimeout = _timeout;
                        connection.Open();
                        obj = command.ExecuteScalar();
                    }
                }

            }
            catch
            {
                return null;
            }
            return obj;
        }






        public int ExecuteSql(string commandText)
        {
            int i;

            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(_providername);

                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = _conn;
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = commandText;
                        connection.Open();
                        command.CommandTimeout = _timeout;
                        i = command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteSql error : " + ex.Message + "\nSQL:" + commandText);
            }
            return i;

        }


        public DataRow GetDataRow(string strSQL)
        {
            DataRow dr = null;
            DataSet ds = GetDataSet(strSQL);
            if (ds != null)
                if (ds.Tables[0].Rows.Count > 0) dr = ds.Tables[0].Rows[0];
            return dr;
        }

        public DataTable GetDataTable(string sql)
        {
            try
            {
                return GetDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                return null;
                //throw new Exception("GetDataTable(sql) error : " + ex.Message + "\nSQL:" + sql);
            }
        }



        public DataSet GetDataSet(string sql)
        {

            try
            {
                DataSet ds = new DataSet();


                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

                using (DbConnection conn = factory.CreateConnection())
                {
                    conn.ConnectionString = _conn;

                    using (DbDataAdapter adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = conn.CreateCommand();
                        adapter.SelectCommand.CommandTimeout = 1200;
                        adapter.SelectCommand.CommandText = sql;
                        adapter.Fill(ds);
                    }
                }
                factory = null;

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("GetDataSet error : " + ex.Message + "\nSQL:" + sql);
            }




        }

        public DataSet GetDataSetbyTable(string strSQL, string srcTable)
        {
            DataSet ds = null;
            DbProviderFactory factory = DbProviderFactories.GetFactory(_providername);

            try
            {

                using (DbConnection conn = factory.CreateConnection())
                {
                    conn.ConnectionString = _conn;
                    using (DbDataAdapter adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = conn.CreateCommand();
                        adapter.SelectCommand.CommandTimeout = 1200;
                        adapter.SelectCommand.CommandText = strSQL;
                        // ReSharper disable AssignNullToNotNullAttribute
                        adapter.Fill(ds, srcTable);
                        // ReSharper restore AssignNullToNotNullAttribute
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetDataSet(string strSQL, string srcTable) error : " + ex.Message + "\nSQL:" + strSQL);
            }

            return ds;
        }

        public DataSet GetDataSet(string storedProc, params object[] args)
        {
            DataSet result;
            SqlDatabase sqlDb;
            DbCommand dbCommand = null;

            sqlDb = new SqlDatabase(_conn);

            try
            {
                dbCommand = sqlDb.GetStoredProcCommand(storedProc, args);
                dbCommand.CommandTimeout = _timeout;
                result = sqlDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in  GetDataSet(string storedProc, params object[] args) :" + ex.Message + "\nSP:" + storedProc);
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection.State == ConnectionState.Open)
                        dbCommand.Connection.Close();
                }
            }
            return result;
        }


        public DataTable GetDataTable(string storedProc, params object[] args)
        {
            return GetDataSet(storedProc, args).Tables[0];
        }

        public DataRow GetDataRow(string storedProc, params object[] args)
        {
            DataTable dt = GetDataSet(storedProc, args).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        public int ExecuteNonQuery(string storedProc, params object[] args)
        {
            int result;
            SqlDatabase sqlDb;
            DbCommand dbCommand = null;

            sqlDb = new SqlDatabase(_conn);

            try
            {
                dbCommand = sqlDb.GetStoredProcCommand(storedProc, args);
                dbCommand.CommandTimeout = _timeout;
                result = sqlDb.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in  ExecuteNonQuery :" + ex.Message);
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection.State == ConnectionState.Open)
                        dbCommand.Connection.Close();
                }
            }
            return result;
        }


        public void CopyData(DataTable sourceTable, string desttablename, string mappingFrom, string mappingTo)
        {

            SqlConnection destConnection = new SqlConnection(_conn);
            destConnection.Open();
            CopyData(sourceTable, destConnection, desttablename, mappingFrom, mappingTo);
            destConnection.Close();

        }
        public void CopyData(DataTable sourceTable, SqlConnection destConnection, string desttablename, string mappingFrom, string mappingTo)
        {
            // new method: SQLBulkCopy:
            using (SqlBulkCopy s = new SqlBulkCopy(destConnection))
            {
                s.DestinationTableName = desttablename;
                s.BulkCopyTimeout = _timeout;
                //s.NotifyAfter = 10000;
                //s.SqlRowsCopied += new SqlRowsCopiedEventHandler(s_SqlRowsCopied);



                string[] cols = Getcols(mappingFrom, mappingTo, sourceTable).Split('\n');

                string[] colFrom = cols[0].Split(',');
                string[] colTo = cols[1].Split(',');


                // StringBuilder sb = new StringBuilder();
                //for (int i = 0; i < colTo.Length; i++)


                for (int i = 0; i < colTo.Length; i++)
                {
                    s.ColumnMappings.Add(colFrom[i].Replace("|", ","), colTo[i].Replace("~", ","));
                    //sb.AppendLine(colFrom[i] + "=" + colTo[i]);
                    //s.ColumnMappings.Add("CarrierTrackingNumber", "TrackingNumber");
                }

                s.WriteToServer(sourceTable);
                //s.Close();
            }
        }

        private string Getcols(string colfrom, string colto, DataTable dt)
        {
            try
            {
                string[] colsFrom = colfrom.Split(',');
                string[] colsTo = colto.Split(',');

                if (colsTo.Length != colsFrom.Length) return "";

                List<string> lstfrom = new List<string>();
                List<string> lstto = new List<string>();
                for (int i = 0; i < colsTo.Length; i++)
                {
                    if (chkfieldname(colsFrom[i], dt))
                    {
                        lstfrom.Add(colsFrom[i]);
                        lstto.Add(colsTo[i]);
                    }

                }
                return ListTostring(lstfrom) + "\n" + ListTostring(lstto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading mapping file. " + ex.Message);
            }
        }

        private bool chkfieldname(string fld, DataTable dt)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName.ToLower().Equals(fld.ToLower()))
                    return true;
            }
            return false;
        }

        private string ListTostring(List<string> lst)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in lst) sb.Append(s + ",");
            sb.Append(",");
            return sb.ToString().Replace(",,", "");
        }
    }
}
