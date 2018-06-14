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

	public interface Lebi_EmailTask_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_EmailTask model);
		void Update(Lebi_EmailTask model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_EmailTask GetModel(int id);
		Lebi_EmailTask GetModel(string strWhere);
		Lebi_EmailTask GetModel(SQLPara para);
		List<Lebi_EmailTask> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_EmailTask> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_EmailTask> GetList(string strWhere, string strFieldOrder);
		List<Lebi_EmailTask> GetList(SQLPara para);
		Lebi_EmailTask BindForm(Lebi_EmailTask model);
		Lebi_EmailTask SafeBindForm(Lebi_EmailTask model);
		Lebi_EmailTask ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_EmailTask。
	/// </summary>
	public class D_Lebi_EmailTask
	{
		static Lebi_EmailTask_interface _Instance;
		public static Lebi_EmailTask_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_EmailTask();
		            else
		                _Instance = new sqlserver_Lebi_EmailTask();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_EmailTask()
		{}
		#region  成员方法
	class sqlserver_Lebi_EmailTask : Lebi_EmailTask_interface
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
				strSql.Append("select " + colName + " from [Lebi_EmailTask]");
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
			strSql.Append("select  "+colName+" from [Lebi_EmailTask]");
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
			strSql.Append("select count(1) from [Lebi_EmailTask]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_EmailTask]");
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
			strSql.Append("select max(id) from [Lebi_EmailTask]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_EmailTask]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_EmailTask model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_EmailTask](");
			strSql.Append("EmailTitle,User_ids,UserLevel_ids,Admin_id,Admin_UserName,Time_add,Time_edit,Time_task,IsSubmit,Count_send,Count,EmailContent)");
			strSql.Append(" values (");
			strSql.Append("@EmailTitle,@User_ids,@UserLevel_ids,@Admin_id,@Admin_UserName,@Time_add,@Time_edit,@Time_task,@IsSubmit,@Count_send,@Count,@EmailContent)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@EmailTitle", model.EmailTitle),
					new SqlParameter("@User_ids", model.User_ids),
					new SqlParameter("@UserLevel_ids", model.UserLevel_ids),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@Admin_UserName", model.Admin_UserName),
					new SqlParameter("@Time_add", model.Time_add),
					new SqlParameter("@Time_edit", model.Time_edit),
					new SqlParameter("@Time_task", model.Time_task),
					new SqlParameter("@IsSubmit", model.IsSubmit),
					new SqlParameter("@Count_send", model.Count_send),
					new SqlParameter("@Count", model.Count),
					new SqlParameter("@EmailContent", model.EmailContent)};

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
		public void Update(Lebi_EmailTask model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_EmailTask] set ");
			strSql.Append("EmailTitle= @EmailTitle,");
			strSql.Append("User_ids= @User_ids,");
			strSql.Append("UserLevel_ids= @UserLevel_ids,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("Admin_UserName= @Admin_UserName,");
			strSql.Append("Time_add= @Time_add,");
			strSql.Append("Time_edit= @Time_edit,");
			strSql.Append("Time_task= @Time_task,");
			strSql.Append("IsSubmit= @IsSubmit,");
			strSql.Append("Count_send= @Count_send,");
			strSql.Append("Count= @Count,");
			strSql.Append("EmailContent= @EmailContent");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@EmailTitle", SqlDbType.NVarChar,500),
					new SqlParameter("@User_ids", SqlDbType.Text),
					new SqlParameter("@UserLevel_ids", SqlDbType.NVarChar,50),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@Admin_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Time_add", SqlDbType.DateTime),
					new SqlParameter("@Time_edit", SqlDbType.DateTime),
					new SqlParameter("@Time_task", SqlDbType.DateTime),
					new SqlParameter("@IsSubmit", SqlDbType.Int,4),
					new SqlParameter("@Count_send", SqlDbType.Int,4),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@EmailContent", SqlDbType.NText)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.EmailTitle;
			parameters[2].Value = model.User_ids;
			parameters[3].Value = model.UserLevel_ids;
			parameters[4].Value = model.Admin_id;
			parameters[5].Value = model.Admin_UserName;
			parameters[6].Value = model.Time_add;
			parameters[7].Value = model.Time_edit;
			parameters[8].Value = model.Time_task;
			parameters[9].Value = model.IsSubmit;
			parameters[10].Value = model.Count_send;
			parameters[11].Value = model.Count;
			parameters[12].Value = model.EmailContent;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_EmailTask] ");
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
			strSql.Append("delete from [Lebi_EmailTask] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_EmailTask] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_EmailTask GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_EmailTask] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_EmailTask model=new Lebi_EmailTask();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.EmailTitle=ds.Tables[0].Rows[0]["EmailTitle"].ToString();
				model.User_ids=ds.Tables[0].Rows[0]["User_ids"].ToString();
				model.UserLevel_ids=ds.Tables[0].Rows[0]["UserLevel_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_edit"].ToString()!="")
				{
					model.Time_edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_edit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_task"].ToString()!="")
				{
					model.Time_task=DateTime.Parse(ds.Tables[0].Rows[0]["Time_task"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSubmit"].ToString()!="")
				{
					model.IsSubmit=int.Parse(ds.Tables[0].Rows[0]["IsSubmit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_send"].ToString()!="")
				{
					model.Count_send=int.Parse(ds.Tables[0].Rows[0]["Count_send"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				model.EmailContent=ds.Tables[0].Rows[0]["EmailContent"].ToString();
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
		public Lebi_EmailTask GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_EmailTask] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_EmailTask model=new Lebi_EmailTask();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.EmailTitle=ds.Tables[0].Rows[0]["EmailTitle"].ToString();
				model.User_ids=ds.Tables[0].Rows[0]["User_ids"].ToString();
				model.UserLevel_ids=ds.Tables[0].Rows[0]["UserLevel_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_edit"].ToString()!="")
				{
					model.Time_edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_edit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_task"].ToString()!="")
				{
					model.Time_task=DateTime.Parse(ds.Tables[0].Rows[0]["Time_task"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSubmit"].ToString()!="")
				{
					model.IsSubmit=int.Parse(ds.Tables[0].Rows[0]["IsSubmit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_send"].ToString()!="")
				{
					model.Count_send=int.Parse(ds.Tables[0].Rows[0]["Count_send"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				model.EmailContent=ds.Tables[0].Rows[0]["EmailContent"].ToString();
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
		public Lebi_EmailTask GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_EmailTask] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_EmailTask model=new Lebi_EmailTask();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.EmailTitle=ds.Tables[0].Rows[0]["EmailTitle"].ToString();
				model.User_ids=ds.Tables[0].Rows[0]["User_ids"].ToString();
				model.UserLevel_ids=ds.Tables[0].Rows[0]["UserLevel_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_edit"].ToString()!="")
				{
					model.Time_edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_edit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_task"].ToString()!="")
				{
					model.Time_task=DateTime.Parse(ds.Tables[0].Rows[0]["Time_task"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSubmit"].ToString()!="")
				{
					model.IsSubmit=int.Parse(ds.Tables[0].Rows[0]["IsSubmit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_send"].ToString()!="")
				{
					model.Count_send=int.Parse(ds.Tables[0].Rows[0]["Count_send"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				model.EmailContent=ds.Tables[0].Rows[0]["EmailContent"].ToString();
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
		public List<Lebi_EmailTask> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_EmailTask]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_EmailTask> list = new List<Lebi_EmailTask>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_EmailTask> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_EmailTask]";
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
			List<Lebi_EmailTask> list = new List<Lebi_EmailTask>();
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
		public List<Lebi_EmailTask> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_EmailTask] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_EmailTask> list = new List<Lebi_EmailTask>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_EmailTask> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_EmailTask]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_EmailTask> list = new List<Lebi_EmailTask>();
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
		public Lebi_EmailTask BindForm(Lebi_EmailTask model)
		{
			if (HttpContext.Current.Request["EmailTitle"] != null)
				model.EmailTitle=Shop.Tools.RequestTool.RequestString("EmailTitle");
			if (HttpContext.Current.Request["User_ids"] != null)
				model.User_ids=Shop.Tools.RequestTool.RequestString("User_ids");
			if (HttpContext.Current.Request["UserLevel_ids"] != null)
				model.UserLevel_ids=Shop.Tools.RequestTool.RequestString("UserLevel_ids");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_edit"] != null)
				model.Time_edit=Shop.Tools.RequestTool.RequestTime("Time_edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_task"] != null)
				model.Time_task=Shop.Tools.RequestTool.RequestTime("Time_task", System.DateTime.Now);
			if (HttpContext.Current.Request["IsSubmit"] != null)
				model.IsSubmit=Shop.Tools.RequestTool.RequestInt("IsSubmit",0);
			if (HttpContext.Current.Request["Count_send"] != null)
				model.Count_send=Shop.Tools.RequestTool.RequestInt("Count_send",0);
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["EmailContent"] != null)
				model.EmailContent=Shop.Tools.RequestTool.RequestString("EmailContent");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_EmailTask SafeBindForm(Lebi_EmailTask model)
		{
			if (HttpContext.Current.Request["EmailTitle"] != null)
				model.EmailTitle=Shop.Tools.RequestTool.RequestSafeString("EmailTitle");
			if (HttpContext.Current.Request["User_ids"] != null)
				model.User_ids=Shop.Tools.RequestTool.RequestSafeString("User_ids");
			if (HttpContext.Current.Request["UserLevel_ids"] != null)
				model.UserLevel_ids=Shop.Tools.RequestTool.RequestSafeString("UserLevel_ids");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_edit"] != null)
				model.Time_edit=Shop.Tools.RequestTool.RequestTime("Time_edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_task"] != null)
				model.Time_task=Shop.Tools.RequestTool.RequestTime("Time_task", System.DateTime.Now);
			if (HttpContext.Current.Request["IsSubmit"] != null)
				model.IsSubmit=Shop.Tools.RequestTool.RequestInt("IsSubmit",0);
			if (HttpContext.Current.Request["Count_send"] != null)
				model.Count_send=Shop.Tools.RequestTool.RequestInt("Count_send",0);
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["EmailContent"] != null)
				model.EmailContent=Shop.Tools.RequestTool.RequestSafeString("EmailContent");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_EmailTask ReaderBind(IDataReader dataReader)
		{
			Lebi_EmailTask model=new Lebi_EmailTask();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.EmailTitle=dataReader["EmailTitle"].ToString();
			model.User_ids=dataReader["User_ids"].ToString();
			model.UserLevel_ids=dataReader["UserLevel_ids"].ToString();
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_edit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_edit=(DateTime)ojb;
			}
			ojb = dataReader["Time_task"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_task=(DateTime)ojb;
			}
			ojb = dataReader["IsSubmit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSubmit=(int)ojb;
			}
			ojb = dataReader["Count_send"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_send=(int)ojb;
			}
			ojb = dataReader["Count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count=(int)ojb;
			}
			model.EmailContent=dataReader["EmailContent"].ToString();
			return model;
		}

	}
	class access_Lebi_EmailTask : Lebi_EmailTask_interface
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
				strSql.Append("select " + colName + " from [Lebi_EmailTask]");
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
			strSql.Append("select  "+colName+" from [Lebi_EmailTask]");
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
			strSql.Append("select count(*) from [Lebi_EmailTask]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_EmailTask]");
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
			strSql.Append("select max(id) from [Lebi_EmailTask]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_EmailTask]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_EmailTask model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_EmailTask](");
			strSql.Append("[EmailTitle],[User_ids],[UserLevel_ids],[Admin_id],[Admin_UserName],[Time_add],[Time_edit],[Time_task],[IsSubmit],[Count_send],[Count],[EmailContent])");
			strSql.Append(" values (");
			strSql.Append("@EmailTitle,@User_ids,@UserLevel_ids,@Admin_id,@Admin_UserName,@Time_add,@Time_edit,@Time_task,@IsSubmit,@Count_send,@Count,@EmailContent)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@EmailTitle", model.EmailTitle),
					new OleDbParameter("@User_ids", model.User_ids),
					new OleDbParameter("@UserLevel_ids", model.UserLevel_ids),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_edit", model.Time_edit.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_task", model.Time_task.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@IsSubmit", model.IsSubmit),
					new OleDbParameter("@Count_send", model.Count_send),
					new OleDbParameter("@Count", model.Count),
					new OleDbParameter("@EmailContent", model.EmailContent)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_EmailTask model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_EmailTask] set ");
			strSql.Append("[EmailTitle]=@EmailTitle,");
			strSql.Append("[User_ids]=@User_ids,");
			strSql.Append("[UserLevel_ids]=@UserLevel_ids,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[Admin_UserName]=@Admin_UserName,");
			strSql.Append("[Time_add]=@Time_add,");
			strSql.Append("[Time_edit]=@Time_edit,");
			strSql.Append("[Time_task]=@Time_task,");
			strSql.Append("[IsSubmit]=@IsSubmit,");
			strSql.Append("[Count_send]=@Count_send,");
			strSql.Append("[Count]=@Count,");
			strSql.Append("[EmailContent]=@EmailContent");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@EmailTitle", model.EmailTitle),
					new OleDbParameter("@User_ids", model.User_ids),
					new OleDbParameter("@UserLevel_ids", model.UserLevel_ids),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_edit", model.Time_edit.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_task", model.Time_task.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@IsSubmit", model.IsSubmit),
					new OleDbParameter("@Count_send", model.Count_send),
					new OleDbParameter("@Count", model.Count),
					new OleDbParameter("@EmailContent", model.EmailContent)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_EmailTask] ");
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
			strSql.Append("delete from [Lebi_EmailTask] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_EmailTask] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_EmailTask GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_EmailTask] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_EmailTask model;
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
		public Lebi_EmailTask GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_EmailTask] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_EmailTask model;
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
		public Lebi_EmailTask GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_EmailTask] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_EmailTask model;
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
		public List<Lebi_EmailTask> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_EmailTask]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_EmailTask> list = new List<Lebi_EmailTask>();
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
		public List<Lebi_EmailTask> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_EmailTask]";
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
			List<Lebi_EmailTask> list = new List<Lebi_EmailTask>();
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
		public List<Lebi_EmailTask> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_EmailTask] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_EmailTask> list = new List<Lebi_EmailTask>();
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
		public List<Lebi_EmailTask> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_EmailTask]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_EmailTask> list = new List<Lebi_EmailTask>();
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
		public Lebi_EmailTask BindForm(Lebi_EmailTask model)
		{
			if (HttpContext.Current.Request["EmailTitle"] != null)
				model.EmailTitle=Shop.Tools.RequestTool.RequestString("EmailTitle");
			if (HttpContext.Current.Request["User_ids"] != null)
				model.User_ids=Shop.Tools.RequestTool.RequestString("User_ids");
			if (HttpContext.Current.Request["UserLevel_ids"] != null)
				model.UserLevel_ids=Shop.Tools.RequestTool.RequestString("UserLevel_ids");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_edit"] != null)
				model.Time_edit=Shop.Tools.RequestTool.RequestTime("Time_edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_task"] != null)
				model.Time_task=Shop.Tools.RequestTool.RequestTime("Time_task", System.DateTime.Now);
			if (HttpContext.Current.Request["IsSubmit"] != null)
				model.IsSubmit=Shop.Tools.RequestTool.RequestInt("IsSubmit",0);
			if (HttpContext.Current.Request["Count_send"] != null)
				model.Count_send=Shop.Tools.RequestTool.RequestInt("Count_send",0);
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["EmailContent"] != null)
				model.EmailContent=Shop.Tools.RequestTool.RequestString("EmailContent");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_EmailTask SafeBindForm(Lebi_EmailTask model)
		{
			if (HttpContext.Current.Request["EmailTitle"] != null)
				model.EmailTitle=Shop.Tools.RequestTool.RequestSafeString("EmailTitle");
			if (HttpContext.Current.Request["User_ids"] != null)
				model.User_ids=Shop.Tools.RequestTool.RequestSafeString("User_ids");
			if (HttpContext.Current.Request["UserLevel_ids"] != null)
				model.UserLevel_ids=Shop.Tools.RequestTool.RequestSafeString("UserLevel_ids");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_edit"] != null)
				model.Time_edit=Shop.Tools.RequestTool.RequestTime("Time_edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_task"] != null)
				model.Time_task=Shop.Tools.RequestTool.RequestTime("Time_task", System.DateTime.Now);
			if (HttpContext.Current.Request["IsSubmit"] != null)
				model.IsSubmit=Shop.Tools.RequestTool.RequestInt("IsSubmit",0);
			if (HttpContext.Current.Request["Count_send"] != null)
				model.Count_send=Shop.Tools.RequestTool.RequestInt("Count_send",0);
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["EmailContent"] != null)
				model.EmailContent=Shop.Tools.RequestTool.RequestSafeString("EmailContent");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_EmailTask ReaderBind(IDataReader dataReader)
		{
			Lebi_EmailTask model=new Lebi_EmailTask();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.EmailTitle=dataReader["EmailTitle"].ToString();
			model.User_ids=dataReader["User_ids"].ToString();
			model.UserLevel_ids=dataReader["UserLevel_ids"].ToString();
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_edit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_edit=(DateTime)ojb;
			}
			ojb = dataReader["Time_task"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_task=(DateTime)ojb;
			}
			ojb = dataReader["IsSubmit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSubmit=(int)ojb;
			}
			ojb = dataReader["Count_send"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_send=(int)ojb;
			}
			ojb = dataReader["Count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count=(int)ojb;
			}
			model.EmailContent=dataReader["EmailContent"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

