using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Shop.Tools;
namespace Shop.DataAccess
{
    public class BaseUtils
    {
        string connectionString;
        string dbtype;
        public BaseUtils()
        {
            connectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
            if (connectionString.ToLower().Contains("oledb"))
            {
                dbtype = "access";
                string p = System.Web.HttpContext.Current.Server.MapPath("~/");
                connectionString = connectionString.Replace("~/", p);
            }
            else
                dbtype = "sqlserver";
        }
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }
        public string DBType
        {
            get
            {
                return dbtype;
            }
            set
            {
                dbtype = value;
            }
        }
        private static BaseUtils _Instance;
        public static BaseUtils BaseUtilsInstance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BaseUtils();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }


        public string SetWhere(string where)
        {
            if (dbtype == "access")
            {
                where = where.Replace("!=", "<>");
                where = where.Replace(" Language ", " [Language] ");
                where = where.Replace(" Language=", " [Language]=");
                where = where.Replace("datediff(d", "datediff('d'");
                //where = where.Replace("%", "*");
            }
            return where;
        }
    }
}
