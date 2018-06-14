using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using Shop.Model;
using Shop.Bussiness;
using Shop.Tools;
using System.Reflection;
using System.Web.Script.Serialization;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Shop.SQLDataAccess;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
namespace Shop.Admin
{
    public partial class db : System.Web.UI.Page
    {
        protected DataTable tables_;
        protected SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
            conn = new SqlConnection(connectionString);
            conn.Open();
            tables_ = conn.GetSchema(SqlClientMetaDataCollectionNames.Tables, new string[] { null, null, null, "BASE TABLE" });

            DataTable cols_;
            string col_name = "";
            string col_defaultval = "";
            string col_isnullable = "";
            string col_char_length = "";
            string col_type = "";
            string col_numeric_length = "";
            string col_numeric_scale = "";
            string col_remark = "";

            for (int i = 0; i < tables_.Rows.Count; i++)
            {
                string tablename = tables_.Rows[i]["TABLE_NAME"].ToString();
                cols_ = GetCols(tablename);
                Lebi_Table parentmodel = B_Lebi_Table.GetModel("name='" + tablename + "' and parentid=0");
                if (parentmodel == null)
                {
                    parentmodel = new Lebi_Table();
                    parentmodel.name = tablename;
                    parentmodel.remark = "";
                    B_Lebi_Table.Add(parentmodel);
                    parentmodel.id = B_Lebi_Table.GetMaxId();
                }
                for (int j = 0; j < cols_.Rows.Count; j++)
                {


                    col_name = cols_.Rows[j]["COLUMN_NAME"].ToString();
                    col_defaultval = cols_.Rows[j]["COLUMN_DEFAULT"].ToString();
                    col_isnullable = cols_.Rows[j]["IS_NULLABLE"].ToString();
                    col_char_length = cols_.Rows[j]["CHARACTER_MAXIMUM_LENGTH"].ToString();
                    col_type = cols_.Rows[j]["DATA_TYPE"].ToString();
                    col_numeric_length = cols_.Rows[j]["NUMERIC_PRECISION"].ToString();
                    col_numeric_scale = cols_.Rows[j]["NUMERIC_SCALE"].ToString();
                    col_remark = "";
                    if (col_name.Contains("Type_id_"))
                    {
                        string des = "";
                        List<Lebi_Type> ts = B_Lebi_Type.GetList("Class='" + col_name.Replace("Type_id_", "") + "'", "");
                        foreach (Lebi_Type ty in ts)
                        {
                            if (des == "")
                                des = ty.id + ty.Name;
                            else
                                des += "," + ty.id + ty.Name;
                        }
                        col_remark = des;
                    }
                    Lebi_Table model = B_Lebi_Table.GetModel("name='" + col_name + "' and parentid=" + parentmodel.id);
                    if (model == null)
                    {
                        model = new Lebi_Table();
                    }
                    model.name = col_name;
                    model.type = col_type;
                    model.remark = col_remark;
                    model.defaultval = col_defaultval;
                    model.isnullable = col_isnullable == "YES" ? 1 : 0;
                    model.isidentity = col_name == "id" ? 1 : 0;
                    model.ispk = col_name == "id" ? 1 : 0;
                    try
                    {
                        model.char_length = Convert.ToInt32(col_char_length);
                    }
                    catch
                    {
                    }
                    try
                    {
                        model.numeric_scale = Convert.ToInt32(col_numeric_scale);
                    }
                    catch
                    {
                    }
                    try
                    {
                        model.numeric_length = Convert.ToInt32(col_numeric_length);
                    }
                    catch
                    {
                    }
                    model.parentid = parentmodel.id;
                    model.parentname = parentmodel.name;
                    if (model.id == 0)
                        B_Lebi_Table.Add(model);
                    else
                        B_Lebi_Table.Update(model);
                }

            }
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //string json = jss.Serialize(tables);
            //Response.Write(json);
            Response.Write("OK");
        }

        public void UpdateTable(string sql)
        {
            try
            {
                Common.ExecuteSql(sql);
            }
            catch { }
        }
        /// <summary>
        /// 获取一个表的字段
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetCols(string name)
        {
            DataTable dt = conn.GetSchema(SqlClientMetaDataCollectionNames.Columns, new string[] { null, null, name, null });
            return dt;
        }
        /// <summary>
        /// 检查一个表是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsHaveTable(string name)
        {
            for (int i = 0; i < tables_.Rows.Count; i++)
            {
                if (tables_.Rows[i]["TABLE_NAME"].ToString() == name)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 检查一个表的字段是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsHaveCol(string name, string datatype, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["COLUMN_NAME"].ToString() == name)
                {
                    return true;
                }
            }
            return false;
        }

    }
}