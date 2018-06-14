using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Shop.Tools;
namespace Shop.DataAccess
{
    public class SqlUtils:BaseUtils
    {
        #region 构造函数
        public SqlUtils()
        {
         
            databaseSchema = RequestTool.GetConfigKey("DBower");
            if (databaseSchema == "")
                databaseSchema = "dbo";
        }
        #endregion

        #region 数据库连接
        protected string databaseSchema = "dbo";
        //protected SqlConnection GetSqlConnection()
        //{

        //    try
        //    {
        //        return new SqlConnection(ConnectionString);
        //    }
        //    catch
        //    {
        //        throw new Exception("SQL Connection String is invalid.");
        //    }

        //}

       
        #endregion

        #region Static Instance
        private static SqlUtils _SqlUtilsInstance;
        public static SqlUtils SqlUtilsInstance
        {
            get
            {
                if (_SqlUtilsInstance == null)
                {

                    _SqlUtilsInstance = new SqlUtils();
                }
                return _SqlUtilsInstance;
            }
            set
            {
                _SqlUtilsInstance = value;
            }
        }
        #endregion

        #region SQL语句--数据库操作
        public int TextExecuteNonQuery(string commandText, params SqlParameter[] commandParameters)
        {

            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, commandText, commandParameters);

        }
        public int TextExecuteNonQuery(string commandText)
        {

            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, commandText);

        }
        public DataSet TextExecuteDataset(string commandText)
        {

            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, commandText);

        }
        public DataSet TextExecuteDataset(string commandText, params SqlParameter[] commandParameters)
        {

            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, commandText, commandParameters);

        }
        public SqlDataReader TextExecuteReader(string commandText)
        {

            return SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, commandText);

        }
        public SqlDataReader TextExecuteReader(string commandText, params SqlParameter[] commandParameters)
        {

            return SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, commandText, commandParameters);

        }
        public object TextExecuteScalar(string commandText, params SqlParameter[] commandParameters)
        {

            return SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, commandText, commandParameters);

        }
        public int TextExecuteScalarInt(string commandText, params SqlParameter[] commandParameters)
        {
            int count = 0;
            object obj = TextExecuteScalar(commandText, commandParameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                count = 0;
            }
            else
            {
                try
                {
                    count = Convert.ToInt32(obj);
                }
                catch
                {

                    count = 0;
                }
            }
            return count;

        }
        public object TextExecuteScalar(string commandText)
        {

            return SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, commandText);

        }
        #endregion

        #region 存储过程--数据库操作功能封装
        public int StoredProcedureExecuteNonQuery(string commandText, params SqlParameter[] commandParameters)
        {

            return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, string.Format("{0}.{1}", databaseSchema, commandText), commandParameters);

        }
        public int StoredProcedureExecuteNonQuery(string commandText, params object[] commandParameters)
        {

            return SqlHelper.ExecuteNonQuery(ConnectionString, string.Format("{0}.{1}", databaseSchema, commandText), commandParameters);

        }
        public DataSet StoredProcedureExecuteDataset(string commandText)
        {

            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, string.Format("{0}.{1}", databaseSchema, commandText));

        }
        public DataSet StoredProcedureExecuteDataset(string commandText, params SqlParameter[] commandParameters)
        {

            return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, string.Format("{0}.{1}", databaseSchema, commandText), commandParameters);

        }
        public DataSet StoredProcedureExecuteDataset(string commandText, params object[] commandParameters)
        {

            return SqlHelper.ExecuteDataset(ConnectionString, string.Format("{0}.{1}", databaseSchema, commandText), commandParameters);

        }
        public SqlDataReader StoredProcedureExecuteReader(string commandText, params SqlParameter[] commandParameters)
        {

            return SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, string.Format("{0}.{1}", databaseSchema, commandText), commandParameters);

        }
        public SqlDataReader StoredProcedureExecuteReader(string commandText, params object[] commandParameters)
        {

            return SqlHelper.ExecuteReader(ConnectionString, string.Format("{0}.{1}", databaseSchema, commandText), commandParameters);

        }
        public object StoredProcedureExecuteScalar(string commandText, params SqlParameter[] commandParameters)
        {

            return SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, string.Format("{0}.{1}", databaseSchema, commandText), commandParameters);

        }
        public object StoredProcedureExecuteScalar(string commandText, params object[] commandParameters)
        {

            return SqlHelper.ExecuteScalar(ConnectionString, string.Format("{0}.{1}", databaseSchema, commandText), commandParameters);

        }

        public int StoredProcedureExecuteScalarInt(string commandText, params object[] commandParameters)
        {

            int count = 0;
            object obj = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteScalar(commandText, commandParameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                count = 0;
            }
            else
            {
                try
                {
                    count = Convert.ToInt32(obj);
                }
                catch
                {

                    count = 0;
                }
            }
            return count;
        }
        #endregion
    }
}
