using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Web;
using Shop.Model;
using Shop.DataAccess;
namespace Shop.SQLDataAccess
{

	public interface Lebi_Log_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Log model);
		void Update(Lebi_Log model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Log GetModel(int id);
		Lebi_Log GetModel(string strWhere);
		Lebi_Log GetModel(SQLPara para);
		List<Lebi_Log> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Log> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Log> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Log> GetList(SQLPara para);
		Lebi_Log BindForm(Lebi_Log model);
		Lebi_Log SafeBindForm(Lebi_Log model);
		Lebi_Log ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Log。
	/// </summary>
	public class D_Lebi_Log
	{
		static Lebi_Log_interface _Instance;
		public static Lebi_Log_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Log();
		            else
		                _Instance = new sqlserver_Lebi_Log();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Log()
		{}
		#region  成员方法
	class sqlserver_Lebi_Log : Lebi_Log_interface
	{
		/// <summary>
		/// 根据字段名，where条件获取一个值,返回字符串
		/// </summary>
		public string GetValue(string colName,string strWhere)
		{
			string val = "";
			try
			{
				StringBuilder strSql=new StringBuilder();
				strSql.Append("select " + colName + " from [Lebi_Log]");
				if(strWhere.Trim()!="")
				{
					strSql.Append(" where "+strWhere);
				}
				val = Convert.ToString(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
			}
			catch
			{
				val = "";
			}
			return val;
		}
		public string GetValue(string colName,SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  "+colName+" from [Lebi_Log]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToString( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}

		/// <summary>
		/// 计算记录条数
		/// </summary>
		public int Counts(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return Counts(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Log]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Log]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxID(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetMaxID(para);
			}
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select max(id) from [Lebi_Log]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Log]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Log](");
			strSql.Append("URL,RefererURL,Description,TableName,Keyid,Time_Add,Admin_id,AdminName,User_id,UserName,IP_Add,Supplier_id,Supplier_SubName,Content)");
			strSql.Append(" values (");
			strSql.Append("@URL,@RefererURL,@Description,@TableName,@Keyid,@Time_Add,@Admin_id,@AdminName,@User_id,@UserName,@IP_Add,@Supplier_id,@Supplier_SubName,@Content)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@URL", model.URL),
					new SqlParameter("@RefererURL", model.RefererURL),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@TableName", model.TableName),
					new SqlParameter("@Keyid", model.Keyid),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@AdminName", model.AdminName),
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@UserName", model.UserName),
					new SqlParameter("@IP_Add", model.IP_Add),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Supplier_SubName", model.Supplier_SubName),
					new SqlParameter("@Content", model.Content)};

			object obj = SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Log] set ");
			strSql.Append("URL= @URL,");
			strSql.Append("RefererURL= @RefererURL,");
			strSql.Append("Description= @Description,");
			strSql.Append("TableName= @TableName,");
			strSql.Append("Keyid= @Keyid,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("AdminName= @AdminName,");
			strSql.Append("User_id= @User_id,");
			strSql.Append("UserName= @UserName,");
			strSql.Append("IP_Add= @IP_Add,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Supplier_SubName= @Supplier_SubName,");
			strSql.Append("Content= @Content");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@URL", SqlDbType.NVarChar,400),
					new SqlParameter("@RefererURL", SqlDbType.NVarChar,400),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@Keyid", SqlDbType.NVarChar,500),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@AdminName", SqlDbType.NVarChar,50),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@IP_Add", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Supplier_SubName", SqlDbType.NVarChar,100),
					new SqlParameter("@Content", SqlDbType.NText)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.URL;
			parameters[2].Value = model.RefererURL;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.TableName;
			parameters[5].Value = model.Keyid;
			parameters[6].Value = model.Time_Add;
			parameters[7].Value = model.Admin_id;
			parameters[8].Value = model.AdminName;
			parameters[9].Value = model.User_id;
			parameters[10].Value = model.UserName;
			parameters[11].Value = model.IP_Add;
			parameters[12].Value = model.Supplier_id;
			parameters[13].Value = model.Supplier_SubName;
			parameters[14].Value = model.Content;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Log] ");
			strSql.Append(" where @id=id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 删除多条数据  by where条件
		/// </summary>
		public void Delete(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				Delete(para);
				return;
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Log] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Log] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Log GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Log] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Log model=new Lebi_Log();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				model.RefererURL=ds.Tables[0].Rows[0]["RefererURL"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.TableName=ds.Tables[0].Rows[0]["TableName"].ToString();
				model.Keyid=ds.Tables[0].Rows[0]["Keyid"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.AdminName=ds.Tables[0].Rows[0]["AdminName"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.IP_Add=ds.Tables[0].Rows[0]["IP_Add"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// 得到一个对象实体 by where条件
		/// </summary>
		public Lebi_Log GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Log] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Log model=new Lebi_Log();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				model.RefererURL=ds.Tables[0].Rows[0]["RefererURL"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.TableName=ds.Tables[0].Rows[0]["TableName"].ToString();
				model.Keyid=ds.Tables[0].Rows[0]["Keyid"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.AdminName=ds.Tables[0].Rows[0]["AdminName"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.IP_Add=ds.Tables[0].Rows[0]["IP_Add"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// 得到一个对象实体 by SQLpara
		/// </summary>
		public Lebi_Log GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Log] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Log model=new Lebi_Log();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				model.RefererURL=ds.Tables[0].Rows[0]["RefererURL"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.TableName=ds.Tables[0].Rows[0]["TableName"].ToString();
				model.Keyid=ds.Tables[0].Rows[0]["Keyid"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.AdminName=ds.Tables[0].Rows[0]["AdminName"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.IP_Add=ds.Tables[0].Rows[0]["IP_Add"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表-带分页
		/// </summary>
		public List<Lebi_Log> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Log]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Log> list = new List<Lebi_Log>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Log> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Log]";
			string strFieldKey = "id";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top " + PageSize + " " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (page > 1)
			{
				if (para != null)
					strSql.Append(" and ");
				else
					strSql.Append(" where ");
				strSql.Append(strFieldKey + " not in (select top " + (PageSize * (page - 1)) + " " + strFieldKey + " from " + strTableName + "");
				if (para != null)
					strSql.Append(" where " + para.Where + "");
				if (para.Order != "")
					strSql.Append(" order by " + para.Order + "");
				strSql.Append(")");
			}
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Log> list = new List<Lebi_Log>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString(), para.Para))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}

		/// <summary>
		/// 获得数据列表-不带分页
		/// </summary>
		public List<Lebi_Log> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Log] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Log> list = new List<Lebi_Log>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Log> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Log]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Log> list = new List<Lebi_Log>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString(), para.Para))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 绑定对象表单
		/// </summary>
		public Lebi_Log BindForm(Lebi_Log model)
		{
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestString("URL");
			if (HttpContext.Current.Request["RefererURL"] != null)
				model.RefererURL=Shop.Tools.RequestTool.RequestString("RefererURL");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestString("Keyid");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["AdminName"] != null)
				model.AdminName=Shop.Tools.RequestTool.RequestString("AdminName");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["IP_Add"] != null)
				model.IP_Add=Shop.Tools.RequestTool.RequestString("IP_Add");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestString("Supplier_SubName");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Log SafeBindForm(Lebi_Log model)
		{
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestSafeString("URL");
			if (HttpContext.Current.Request["RefererURL"] != null)
				model.RefererURL=Shop.Tools.RequestTool.RequestSafeString("RefererURL");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestSafeString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestSafeString("Keyid");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["AdminName"] != null)
				model.AdminName=Shop.Tools.RequestTool.RequestSafeString("AdminName");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["IP_Add"] != null)
				model.IP_Add=Shop.Tools.RequestTool.RequestSafeString("IP_Add");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestSafeString("Supplier_SubName");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Log ReaderBind(IDataReader dataReader)
		{
			Lebi_Log model=new Lebi_Log();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.URL=dataReader["URL"].ToString();
			model.RefererURL=dataReader["RefererURL"].ToString();
			model.Description=dataReader["Description"].ToString();
			model.TableName=dataReader["TableName"].ToString();
			model.Keyid=dataReader["Keyid"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.AdminName=dataReader["AdminName"].ToString();
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.IP_Add=dataReader["IP_Add"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			model.Supplier_SubName=dataReader["Supplier_SubName"].ToString();
			model.Content=dataReader["Content"].ToString();
			return model;
		}

	}
	class access_Lebi_Log : Lebi_Log_interface
	{
		/// <summary>
		/// 根据字段名，where条件获取一个值,返回字符串
		/// </summary>
		public string GetValue(string colName,string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			string val = "";
			try
			{
				StringBuilder strSql=new StringBuilder();
				strSql.Append("select " + colName + " from [Lebi_Log]");
				if(strWhere.Trim()!="")
				{
					strSql.Append(" where "+strWhere);
				}
				val = Convert.ToString(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
			}
			catch
			{
				val = "";
			}
			return val;
		}
		public string GetValue(string colName,SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  "+colName+" from [Lebi_Log]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToString(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}

		/// <summary>
		/// 计算记录条数
		/// </summary>
		public int Counts(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return Counts(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Log]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Log]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxID(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetMaxID(para);
			}
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select max(id) from [Lebi_Log]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Log]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Log](");
			strSql.Append("[URL],[RefererURL],[Description],[TableName],[Keyid],[Time_Add],[Admin_id],[AdminName],[User_id],[UserName],[IP_Add],[Supplier_id],[Supplier_SubName],[Content])");
			strSql.Append(" values (");
			strSql.Append("@URL,@RefererURL,@Description,@TableName,@Keyid,@Time_Add,@Admin_id,@AdminName,@User_id,@UserName,@IP_Add,@Supplier_id,@Supplier_SubName,@Content)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@URL", model.URL),
					new OleDbParameter("@RefererURL", model.RefererURL),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@TableName", model.TableName),
					new OleDbParameter("@Keyid", model.Keyid),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@AdminName", model.AdminName),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@IP_Add", model.IP_Add),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Supplier_SubName", model.Supplier_SubName),
					new OleDbParameter("@Content", model.Content)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Log] set ");
			strSql.Append("[URL]=@URL,");
			strSql.Append("[RefererURL]=@RefererURL,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[TableName]=@TableName,");
			strSql.Append("[Keyid]=@Keyid,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[AdminName]=@AdminName,");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[UserName]=@UserName,");
			strSql.Append("[IP_Add]=@IP_Add,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Supplier_SubName]=@Supplier_SubName,");
			strSql.Append("[Content]=@Content");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@URL", model.URL),
					new OleDbParameter("@RefererURL", model.RefererURL),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@TableName", model.TableName),
					new OleDbParameter("@Keyid", model.Keyid),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@AdminName", model.AdminName),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@IP_Add", model.IP_Add),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Supplier_SubName", model.Supplier_SubName),
					new OleDbParameter("@Content", model.Content)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Log] ");
			strSql.Append(" where @id=id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 删除多条数据  by where条件
		/// </summary>
		public void Delete(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				Delete(para);
				return;
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Log] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Log] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Log GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Log] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Log model;
			using (OleDbDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(), parameters))
			{
			    if (dataReader != null)
			    {
			       while (dataReader.Read())
			       {
			           model = ReaderBind(dataReader);
			           return model;
			       }
			    }
			}
			return null;
		}
		/// <summary>
		/// 得到一个对象实体 by where条件
		/// </summary>
		public Lebi_Log GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Log] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Log model;
			using (OleDbDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(), null))
			{
			    if (dataReader != null)
			    {
			       while (dataReader.Read())
			       {
			           model = ReaderBind(dataReader);
			           return model;
			       }
			    }
			}
			return null;
		}
		/// <summary>
		/// 得到一个对象实体 by SQLpara
		/// </summary>
		public Lebi_Log GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Log] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Log model;
			using (OleDbDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(), para.Para_Oledb))
			{
			    if (dataReader != null)
			    {
			       while (dataReader.Read())
			       {
			           model = ReaderBind(dataReader);
			           return model;
			       }
			    }
			}
			return null;
		}

		/// <summary>
		/// 获得数据列表-带分页
		/// </summary>
		public List<Lebi_Log> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Log]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Log> list = new List<Lebi_Log>();
			using (IDataReader dataReader = AccessUtils.Instance.DataReader(strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page,null))
			{
			   if(dataReader!=null)
			   {
			       while (dataReader.Read())
			       {
			           list.Add(ReaderBind(dataReader));
			       }
			   }
			}
				return list;
			}
		public List<Lebi_Log> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Log]";
			string strFieldKey = "id";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top " + PageSize + " " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (page > 1)
			{
				if (para != null)
					strSql.Append(" and ");
				else
					strSql.Append(" where ");
				strSql.Append(strFieldKey + " not in (select top " + (PageSize * (page - 1)) + " " + strFieldKey + " from " + strTableName + "");
				if (para != null)
					strSql.Append(" where " + para.Where + "");
				if (para.Order != "")
					strSql.Append(" order by " + para.Order + "");
				strSql.Append(")");
			}
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Log> list = new List<Lebi_Log>();
			using (IDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(), para.Para_Oledb))
			{
			   if(dataReader!=null)
			   {
			       while (dataReader.Read())
			       {
			           list.Add(ReaderBind(dataReader));
			       }
			   }
			}
			return list;
		}

		/// <summary>
		/// 获得数据列表-不带分页
		/// </summary>
		public List<Lebi_Log> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Log] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Log> list = new List<Lebi_Log>();
			using (OleDbDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(),null))
			{
			   if(dataReader!=null)
			   {
			       while (dataReader.Read())
			       {
			           list.Add(ReaderBind(dataReader));
			       }
			   }
			}
			return list;
		}
		public List<Lebi_Log> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Log]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Log> list = new List<Lebi_Log>();
			using (IDataReader dataReader = AccessUtils.Instance.DataReader(strSql.ToString(), para.Para_Oledb))
			{
			   if(dataReader!=null)
			   {
			       while (dataReader.Read())
			       {
			           list.Add(ReaderBind(dataReader));
			       }
			   }
			}
			return list;
		}


		/// <summary>
		/// 绑定对象表单
		/// </summary>
		public Lebi_Log BindForm(Lebi_Log model)
		{
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestString("URL");
			if (HttpContext.Current.Request["RefererURL"] != null)
				model.RefererURL=Shop.Tools.RequestTool.RequestString("RefererURL");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestString("Keyid");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["AdminName"] != null)
				model.AdminName=Shop.Tools.RequestTool.RequestString("AdminName");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["IP_Add"] != null)
				model.IP_Add=Shop.Tools.RequestTool.RequestString("IP_Add");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestString("Supplier_SubName");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Log SafeBindForm(Lebi_Log model)
		{
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestSafeString("URL");
			if (HttpContext.Current.Request["RefererURL"] != null)
				model.RefererURL=Shop.Tools.RequestTool.RequestSafeString("RefererURL");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestSafeString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestSafeString("Keyid");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["AdminName"] != null)
				model.AdminName=Shop.Tools.RequestTool.RequestSafeString("AdminName");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["IP_Add"] != null)
				model.IP_Add=Shop.Tools.RequestTool.RequestSafeString("IP_Add");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestSafeString("Supplier_SubName");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Log ReaderBind(IDataReader dataReader)
		{
			Lebi_Log model=new Lebi_Log();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.URL=dataReader["URL"].ToString();
			model.RefererURL=dataReader["RefererURL"].ToString();
			model.Description=dataReader["Description"].ToString();
			model.TableName=dataReader["TableName"].ToString();
			model.Keyid=dataReader["Keyid"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.AdminName=dataReader["AdminName"].ToString();
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.IP_Add=dataReader["IP_Add"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			model.Supplier_SubName=dataReader["Supplier_SubName"].ToString();
			model.Content=dataReader["Content"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

