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

	public interface Lebi_Agent_Product_request_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Agent_Product_request model);
		void Update(Lebi_Agent_Product_request model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Agent_Product_request GetModel(int id);
		Lebi_Agent_Product_request GetModel(string strWhere);
		Lebi_Agent_Product_request GetModel(SQLPara para);
		List<Lebi_Agent_Product_request> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Agent_Product_request> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Agent_Product_request> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Agent_Product_request> GetList(SQLPara para);
		Lebi_Agent_Product_request BindForm(Lebi_Agent_Product_request model);
		Lebi_Agent_Product_request SafeBindForm(Lebi_Agent_Product_request model);
		Lebi_Agent_Product_request ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Agent_Product_request。
	/// </summary>
	public class D_Lebi_Agent_Product_request
	{
		static Lebi_Agent_Product_request_interface _Instance;
		public static Lebi_Agent_Product_request_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Agent_Product_request();
		            else
		                _Instance = new sqlserver_Lebi_Agent_Product_request();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Agent_Product_request()
		{}
		#region  成员方法
	class sqlserver_Lebi_Agent_Product_request : Lebi_Agent_Product_request_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_Product_request]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_Product_request]");
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
			strSql.Append("select count(1) from [Lebi_Agent_Product_request]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Product_request]");
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
			strSql.Append("select max(id) from [Lebi_Agent_Product_request]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Product_request]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_Product_request model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_Product_request](");
			strSql.Append("User_id,User_UserName,Product_id_old,Product_id,Type_id_AgentProductRequestStatus,Time_add,Time_manage,Admin_id,Admin_UserName,Remark)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_UserName,@Product_id_old,@Product_id,@Type_id_AgentProductRequestStatus,@Time_add,@Time_manage,@Admin_id,@Admin_UserName,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@User_UserName", model.User_UserName),
					new SqlParameter("@Product_id_old", model.Product_id_old),
					new SqlParameter("@Product_id", model.Product_id),
					new SqlParameter("@Type_id_AgentProductRequestStatus", model.Type_id_AgentProductRequestStatus),
					new SqlParameter("@Time_add", model.Time_add),
					new SqlParameter("@Time_manage", model.Time_manage),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@Admin_UserName", model.Admin_UserName),
					new SqlParameter("@Remark", model.Remark)};

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
		public void Update(Lebi_Agent_Product_request model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_Product_request] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("User_UserName= @User_UserName,");
			strSql.Append("Product_id_old= @Product_id_old,");
			strSql.Append("Product_id= @Product_id,");
			strSql.Append("Type_id_AgentProductRequestStatus= @Type_id_AgentProductRequestStatus,");
			strSql.Append("Time_add= @Time_add,");
			strSql.Append("Time_manage= @Time_manage,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("Admin_UserName= @Admin_UserName,");
			strSql.Append("Remark= @Remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Product_id_old", SqlDbType.Int,4),
					new SqlParameter("@Product_id", SqlDbType.Int,4),
					new SqlParameter("@Type_id_AgentProductRequestStatus", SqlDbType.Int,4),
					new SqlParameter("@Time_add", SqlDbType.DateTime),
					new SqlParameter("@Time_manage", SqlDbType.DateTime),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@Admin_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.User_UserName;
			parameters[3].Value = model.Product_id_old;
			parameters[4].Value = model.Product_id;
			parameters[5].Value = model.Type_id_AgentProductRequestStatus;
			parameters[6].Value = model.Time_add;
			parameters[7].Value = model.Time_manage;
			parameters[8].Value = model.Admin_id;
			parameters[9].Value = model.Admin_UserName;
			parameters[10].Value = model.Remark;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_request] ");
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
			strSql.Append("delete from [Lebi_Agent_Product_request] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_request] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_Product_request GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_request] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Agent_Product_request model=new Lebi_Agent_Product_request();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Product_id_old"].ToString()!="")
				{
					model.Product_id_old=int.Parse(ds.Tables[0].Rows[0]["Product_id_old"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AgentProductRequestStatus"].ToString()!="")
				{
					model.Type_id_AgentProductRequestStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_AgentProductRequestStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_manage"].ToString()!="")
				{
					model.Time_manage=DateTime.Parse(ds.Tables[0].Rows[0]["Time_manage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
		public Lebi_Agent_Product_request GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_request] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_Product_request model=new Lebi_Agent_Product_request();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Product_id_old"].ToString()!="")
				{
					model.Product_id_old=int.Parse(ds.Tables[0].Rows[0]["Product_id_old"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AgentProductRequestStatus"].ToString()!="")
				{
					model.Type_id_AgentProductRequestStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_AgentProductRequestStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_manage"].ToString()!="")
				{
					model.Time_manage=DateTime.Parse(ds.Tables[0].Rows[0]["Time_manage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
		public Lebi_Agent_Product_request GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_Product_request] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_Product_request model=new Lebi_Agent_Product_request();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Product_id_old"].ToString()!="")
				{
					model.Product_id_old=int.Parse(ds.Tables[0].Rows[0]["Product_id_old"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AgentProductRequestStatus"].ToString()!="")
				{
					model.Type_id_AgentProductRequestStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_AgentProductRequestStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_manage"].ToString()!="")
				{
					model.Time_manage=DateTime.Parse(ds.Tables[0].Rows[0]["Time_manage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
		public List<Lebi_Agent_Product_request> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_Product_request]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_Product_request> list = new List<Lebi_Agent_Product_request>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Agent_Product_request> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_Product_request]";
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
			List<Lebi_Agent_Product_request> list = new List<Lebi_Agent_Product_request>();
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
		public List<Lebi_Agent_Product_request> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_Product_request] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_Product_request> list = new List<Lebi_Agent_Product_request>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Agent_Product_request> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_Product_request]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_Product_request> list = new List<Lebi_Agent_Product_request>();
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
		public Lebi_Agent_Product_request BindForm(Lebi_Agent_Product_request model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Product_id_old"] != null)
				model.Product_id_old=Shop.Tools.RequestTool.RequestInt("Product_id_old",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Type_id_AgentProductRequestStatus"] != null)
				model.Type_id_AgentProductRequestStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AgentProductRequestStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_manage"] != null)
				model.Time_manage=Shop.Tools.RequestTool.RequestTime("Time_manage", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Agent_Product_request SafeBindForm(Lebi_Agent_Product_request model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Product_id_old"] != null)
				model.Product_id_old=Shop.Tools.RequestTool.RequestInt("Product_id_old",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Type_id_AgentProductRequestStatus"] != null)
				model.Type_id_AgentProductRequestStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AgentProductRequestStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_manage"] != null)
				model.Time_manage=Shop.Tools.RequestTool.RequestTime("Time_manage", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Agent_Product_request ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_Product_request model=new Lebi_Agent_Product_request();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			ojb = dataReader["Product_id_old"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id_old=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["Type_id_AgentProductRequestStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_AgentProductRequestStatus=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_manage"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_manage=(DateTime)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			return model;
		}

	}
	class access_Lebi_Agent_Product_request : Lebi_Agent_Product_request_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_Product_request]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_Product_request]");
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
			strSql.Append("select count(*) from [Lebi_Agent_Product_request]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Agent_Product_request]");
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
			strSql.Append("select max(id) from [Lebi_Agent_Product_request]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Product_request]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_Product_request model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_Product_request](");
			strSql.Append("[User_id],[User_UserName],[Product_id_old],[Product_id],[Type_id_AgentProductRequestStatus],[Time_add],[Time_manage],[Admin_id],[Admin_UserName],[Remark])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_UserName,@Product_id_old,@Product_id,@Type_id_AgentProductRequestStatus,@Time_add,@Time_manage,@Admin_id,@Admin_UserName,@Remark)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Product_id_old", model.Product_id_old),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Type_id_AgentProductRequestStatus", model.Type_id_AgentProductRequestStatus),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_manage", model.Time_manage.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Remark", model.Remark)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Agent_Product_request model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_Product_request] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[User_UserName]=@User_UserName,");
			strSql.Append("[Product_id_old]=@Product_id_old,");
			strSql.Append("[Product_id]=@Product_id,");
			strSql.Append("[Type_id_AgentProductRequestStatus]=@Type_id_AgentProductRequestStatus,");
			strSql.Append("[Time_add]=@Time_add,");
			strSql.Append("[Time_manage]=@Time_manage,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[Admin_UserName]=@Admin_UserName,");
			strSql.Append("[Remark]=@Remark");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Product_id_old", model.Product_id_old),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Type_id_AgentProductRequestStatus", model.Type_id_AgentProductRequestStatus),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_manage", model.Time_manage.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Remark", model.Remark)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_request] ");
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
			strSql.Append("delete from [Lebi_Agent_Product_request] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_request] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_Product_request GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_request] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Agent_Product_request model;
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
		public Lebi_Agent_Product_request GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_request] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_Product_request model;
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
		public Lebi_Agent_Product_request GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_Product_request] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_Product_request model;
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
		public List<Lebi_Agent_Product_request> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_Product_request]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_Product_request> list = new List<Lebi_Agent_Product_request>();
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
		public List<Lebi_Agent_Product_request> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_Product_request]";
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
			List<Lebi_Agent_Product_request> list = new List<Lebi_Agent_Product_request>();
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
		public List<Lebi_Agent_Product_request> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_Product_request] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_Product_request> list = new List<Lebi_Agent_Product_request>();
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
		public List<Lebi_Agent_Product_request> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_Product_request]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_Product_request> list = new List<Lebi_Agent_Product_request>();
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
		public Lebi_Agent_Product_request BindForm(Lebi_Agent_Product_request model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Product_id_old"] != null)
				model.Product_id_old=Shop.Tools.RequestTool.RequestInt("Product_id_old",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Type_id_AgentProductRequestStatus"] != null)
				model.Type_id_AgentProductRequestStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AgentProductRequestStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_manage"] != null)
				model.Time_manage=Shop.Tools.RequestTool.RequestTime("Time_manage", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Agent_Product_request SafeBindForm(Lebi_Agent_Product_request model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Product_id_old"] != null)
				model.Product_id_old=Shop.Tools.RequestTool.RequestInt("Product_id_old",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Type_id_AgentProductRequestStatus"] != null)
				model.Type_id_AgentProductRequestStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AgentProductRequestStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_manage"] != null)
				model.Time_manage=Shop.Tools.RequestTool.RequestTime("Time_manage", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Agent_Product_request ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_Product_request model=new Lebi_Agent_Product_request();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			ojb = dataReader["Product_id_old"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id_old=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["Type_id_AgentProductRequestStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_AgentProductRequestStatus=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_manage"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_manage=(DateTime)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

