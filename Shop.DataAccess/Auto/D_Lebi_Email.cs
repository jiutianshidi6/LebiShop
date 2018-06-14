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

	public interface Lebi_Email_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Email model);
		void Update(Lebi_Email model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Email GetModel(int id);
		Lebi_Email GetModel(string strWhere);
		Lebi_Email GetModel(SQLPara para);
		List<Lebi_Email> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Email> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Email> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Email> GetList(SQLPara para);
		Lebi_Email BindForm(Lebi_Email model);
		Lebi_Email SafeBindForm(Lebi_Email model);
		Lebi_Email ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Email。
	/// </summary>
	public class D_Lebi_Email
	{
		static Lebi_Email_interface _Instance;
		public static Lebi_Email_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Email();
		            else
		                _Instance = new sqlserver_Lebi_Email();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Email()
		{}
		#region  成员方法
	class sqlserver_Lebi_Email : Lebi_Email_interface
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
				strSql.Append("select " + colName + " from [Lebi_Email]");
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
			strSql.Append("select  "+colName+" from [Lebi_Email]");
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
			strSql.Append("select count(1) from [Lebi_Email]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Email]");
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
			strSql.Append("select max(id) from [Lebi_Email]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Email]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Email model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Email](");
			strSql.Append("Email,User_id,User_Name,Title,Content,Count_send,Time_Add,Time_Task,Time_Send,Type_id_EmailStatus,EmailTask_id,TableName,Keyid)");
			strSql.Append(" values (");
			strSql.Append("@Email,@User_id,@User_Name,@Title,@Content,@Count_send,@Time_Add,@Time_Task,@Time_Send,@Type_id_EmailStatus,@EmailTask_id,@TableName,@Keyid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Email", model.Email),
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@User_Name", model.User_Name),
					new SqlParameter("@Title", model.Title),
					new SqlParameter("@Content", model.Content),
					new SqlParameter("@Count_send", model.Count_send),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Task", model.Time_Task),
					new SqlParameter("@Time_Send", model.Time_Send),
					new SqlParameter("@Type_id_EmailStatus", model.Type_id_EmailStatus),
					new SqlParameter("@EmailTask_id", model.EmailTask_id),
					new SqlParameter("@TableName", model.TableName),
					new SqlParameter("@Keyid", model.Keyid)};

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
		public void Update(Lebi_Email model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Email] set ");
			strSql.Append("Email= @Email,");
			strSql.Append("User_id= @User_id,");
			strSql.Append("User_Name= @User_Name,");
			strSql.Append("Title= @Title,");
			strSql.Append("Content= @Content,");
			strSql.Append("Count_send= @Count_send,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Task= @Time_Task,");
			strSql.Append("Time_Send= @Time_Send,");
			strSql.Append("Type_id_EmailStatus= @Type_id_EmailStatus,");
			strSql.Append("EmailTask_id= @EmailTask_id,");
			strSql.Append("TableName= @TableName,");
			strSql.Append("Keyid= @Keyid");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Email", SqlDbType.NVarChar,255),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@User_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,500),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Count_send", SqlDbType.Int,4),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Task", SqlDbType.DateTime),
					new SqlParameter("@Time_Send", SqlDbType.DateTime),
					new SqlParameter("@Type_id_EmailStatus", SqlDbType.Int,4),
					new SqlParameter("@EmailTask_id", SqlDbType.Int,4),
					new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@Keyid", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Email;
			parameters[2].Value = model.User_id;
			parameters[3].Value = model.User_Name;
			parameters[4].Value = model.Title;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.Count_send;
			parameters[7].Value = model.Time_Add;
			parameters[8].Value = model.Time_Task;
			parameters[9].Value = model.Time_Send;
			parameters[10].Value = model.Type_id_EmailStatus;
			parameters[11].Value = model.EmailTask_id;
			parameters[12].Value = model.TableName;
			parameters[13].Value = model.Keyid;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Email] ");
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
			strSql.Append("delete from [Lebi_Email] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Email] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Email GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Email] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Email model=new Lebi_Email();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_Name=ds.Tables[0].Rows[0]["User_Name"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Count_send"].ToString()!="")
				{
					model.Count_send=int.Parse(ds.Tables[0].Rows[0]["Count_send"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Task"].ToString()!="")
				{
					model.Time_Task=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Task"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Send"].ToString()!="")
				{
					model.Time_Send=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Send"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_EmailStatus"].ToString()!="")
				{
					model.Type_id_EmailStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_EmailStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EmailTask_id"].ToString()!="")
				{
					model.EmailTask_id=int.Parse(ds.Tables[0].Rows[0]["EmailTask_id"].ToString());
				}
				model.TableName=ds.Tables[0].Rows[0]["TableName"].ToString();
				if(ds.Tables[0].Rows[0]["Keyid"].ToString()!="")
				{
					model.Keyid=int.Parse(ds.Tables[0].Rows[0]["Keyid"].ToString());
				}
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
		public Lebi_Email GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Email] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Email model=new Lebi_Email();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_Name=ds.Tables[0].Rows[0]["User_Name"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Count_send"].ToString()!="")
				{
					model.Count_send=int.Parse(ds.Tables[0].Rows[0]["Count_send"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Task"].ToString()!="")
				{
					model.Time_Task=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Task"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Send"].ToString()!="")
				{
					model.Time_Send=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Send"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_EmailStatus"].ToString()!="")
				{
					model.Type_id_EmailStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_EmailStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EmailTask_id"].ToString()!="")
				{
					model.EmailTask_id=int.Parse(ds.Tables[0].Rows[0]["EmailTask_id"].ToString());
				}
				model.TableName=ds.Tables[0].Rows[0]["TableName"].ToString();
				if(ds.Tables[0].Rows[0]["Keyid"].ToString()!="")
				{
					model.Keyid=int.Parse(ds.Tables[0].Rows[0]["Keyid"].ToString());
				}
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
		public Lebi_Email GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Email] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Email model=new Lebi_Email();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_Name=ds.Tables[0].Rows[0]["User_Name"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Count_send"].ToString()!="")
				{
					model.Count_send=int.Parse(ds.Tables[0].Rows[0]["Count_send"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Task"].ToString()!="")
				{
					model.Time_Task=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Task"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Send"].ToString()!="")
				{
					model.Time_Send=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Send"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_EmailStatus"].ToString()!="")
				{
					model.Type_id_EmailStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_EmailStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EmailTask_id"].ToString()!="")
				{
					model.EmailTask_id=int.Parse(ds.Tables[0].Rows[0]["EmailTask_id"].ToString());
				}
				model.TableName=ds.Tables[0].Rows[0]["TableName"].ToString();
				if(ds.Tables[0].Rows[0]["Keyid"].ToString()!="")
				{
					model.Keyid=int.Parse(ds.Tables[0].Rows[0]["Keyid"].ToString());
				}
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
		public List<Lebi_Email> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Email]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Email> list = new List<Lebi_Email>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Email> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Email]";
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
			List<Lebi_Email> list = new List<Lebi_Email>();
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
		public List<Lebi_Email> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Email] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Email> list = new List<Lebi_Email>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Email> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Email]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Email> list = new List<Lebi_Email>();
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
		public Lebi_Email BindForm(Lebi_Email model)
		{
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_Name"] != null)
				model.User_Name=Shop.Tools.RequestTool.RequestString("User_Name");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Count_send"] != null)
				model.Count_send=Shop.Tools.RequestTool.RequestInt("Count_send",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Task"] != null)
				model.Time_Task=Shop.Tools.RequestTool.RequestTime("Time_Task", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Send"] != null)
				model.Time_Send=Shop.Tools.RequestTool.RequestTime("Time_Send", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_EmailStatus"] != null)
				model.Type_id_EmailStatus=Shop.Tools.RequestTool.RequestInt("Type_id_EmailStatus",0);
			if (HttpContext.Current.Request["EmailTask_id"] != null)
				model.EmailTask_id=Shop.Tools.RequestTool.RequestInt("EmailTask_id",0);
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestInt("Keyid",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Email SafeBindForm(Lebi_Email model)
		{
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_Name"] != null)
				model.User_Name=Shop.Tools.RequestTool.RequestSafeString("User_Name");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Count_send"] != null)
				model.Count_send=Shop.Tools.RequestTool.RequestInt("Count_send",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Task"] != null)
				model.Time_Task=Shop.Tools.RequestTool.RequestTime("Time_Task", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Send"] != null)
				model.Time_Send=Shop.Tools.RequestTool.RequestTime("Time_Send", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_EmailStatus"] != null)
				model.Type_id_EmailStatus=Shop.Tools.RequestTool.RequestInt("Type_id_EmailStatus",0);
			if (HttpContext.Current.Request["EmailTask_id"] != null)
				model.EmailTask_id=Shop.Tools.RequestTool.RequestInt("EmailTask_id",0);
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestSafeString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestInt("Keyid",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Email ReaderBind(IDataReader dataReader)
		{
			Lebi_Email model=new Lebi_Email();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Email=dataReader["Email"].ToString();
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.User_Name=dataReader["User_Name"].ToString();
			model.Title=dataReader["Title"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Count_send"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_send=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Task"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Task=(DateTime)ojb;
			}
			ojb = dataReader["Time_Send"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Send=(DateTime)ojb;
			}
			ojb = dataReader["Type_id_EmailStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_EmailStatus=(int)ojb;
			}
			ojb = dataReader["EmailTask_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmailTask_id=(int)ojb;
			}
			model.TableName=dataReader["TableName"].ToString();
			ojb = dataReader["Keyid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Keyid=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Email : Lebi_Email_interface
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
				strSql.Append("select " + colName + " from [Lebi_Email]");
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
			strSql.Append("select  "+colName+" from [Lebi_Email]");
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
			strSql.Append("select count(*) from [Lebi_Email]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Email]");
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
			strSql.Append("select max(id) from [Lebi_Email]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Email]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Email model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Email](");
			strSql.Append("[Email],[User_id],[User_Name],[Title],[Content],[Count_send],[Time_Add],[Time_Task],[Time_Send],[Type_id_EmailStatus],[EmailTask_id],[TableName],[Keyid])");
			strSql.Append(" values (");
			strSql.Append("@Email,@User_id,@User_Name,@Title,@Content,@Count_send,@Time_Add,@Time_Task,@Time_Send,@Type_id_EmailStatus,@EmailTask_id,@TableName,@Keyid)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_Name", model.User_Name),
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Count_send", model.Count_send),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Task", model.Time_Task.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Send", model.Time_Send.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Type_id_EmailStatus", model.Type_id_EmailStatus),
					new OleDbParameter("@EmailTask_id", model.EmailTask_id),
					new OleDbParameter("@TableName", model.TableName),
					new OleDbParameter("@Keyid", model.Keyid)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Email model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Email] set ");
			strSql.Append("[Email]=@Email,");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[User_Name]=@User_Name,");
			strSql.Append("[Title]=@Title,");
			strSql.Append("[Content]=@Content,");
			strSql.Append("[Count_send]=@Count_send,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Task]=@Time_Task,");
			strSql.Append("[Time_Send]=@Time_Send,");
			strSql.Append("[Type_id_EmailStatus]=@Type_id_EmailStatus,");
			strSql.Append("[EmailTask_id]=@EmailTask_id,");
			strSql.Append("[TableName]=@TableName,");
			strSql.Append("[Keyid]=@Keyid");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_Name", model.User_Name),
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Count_send", model.Count_send),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Task", model.Time_Task.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Send", model.Time_Send.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Type_id_EmailStatus", model.Type_id_EmailStatus),
					new OleDbParameter("@EmailTask_id", model.EmailTask_id),
					new OleDbParameter("@TableName", model.TableName),
					new OleDbParameter("@Keyid", model.Keyid)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Email] ");
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
			strSql.Append("delete from [Lebi_Email] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Email] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Email GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Email] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Email model;
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
		public Lebi_Email GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Email] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Email model;
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
		public Lebi_Email GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Email] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Email model;
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
		public List<Lebi_Email> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Email]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Email> list = new List<Lebi_Email>();
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
		public List<Lebi_Email> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Email]";
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
			List<Lebi_Email> list = new List<Lebi_Email>();
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
		public List<Lebi_Email> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Email] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Email> list = new List<Lebi_Email>();
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
		public List<Lebi_Email> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Email]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Email> list = new List<Lebi_Email>();
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
		public Lebi_Email BindForm(Lebi_Email model)
		{
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_Name"] != null)
				model.User_Name=Shop.Tools.RequestTool.RequestString("User_Name");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Count_send"] != null)
				model.Count_send=Shop.Tools.RequestTool.RequestInt("Count_send",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Task"] != null)
				model.Time_Task=Shop.Tools.RequestTool.RequestTime("Time_Task", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Send"] != null)
				model.Time_Send=Shop.Tools.RequestTool.RequestTime("Time_Send", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_EmailStatus"] != null)
				model.Type_id_EmailStatus=Shop.Tools.RequestTool.RequestInt("Type_id_EmailStatus",0);
			if (HttpContext.Current.Request["EmailTask_id"] != null)
				model.EmailTask_id=Shop.Tools.RequestTool.RequestInt("EmailTask_id",0);
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestInt("Keyid",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Email SafeBindForm(Lebi_Email model)
		{
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_Name"] != null)
				model.User_Name=Shop.Tools.RequestTool.RequestSafeString("User_Name");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Count_send"] != null)
				model.Count_send=Shop.Tools.RequestTool.RequestInt("Count_send",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Task"] != null)
				model.Time_Task=Shop.Tools.RequestTool.RequestTime("Time_Task", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Send"] != null)
				model.Time_Send=Shop.Tools.RequestTool.RequestTime("Time_Send", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_EmailStatus"] != null)
				model.Type_id_EmailStatus=Shop.Tools.RequestTool.RequestInt("Type_id_EmailStatus",0);
			if (HttpContext.Current.Request["EmailTask_id"] != null)
				model.EmailTask_id=Shop.Tools.RequestTool.RequestInt("EmailTask_id",0);
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestSafeString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestInt("Keyid",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Email ReaderBind(IDataReader dataReader)
		{
			Lebi_Email model=new Lebi_Email();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Email=dataReader["Email"].ToString();
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.User_Name=dataReader["User_Name"].ToString();
			model.Title=dataReader["Title"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Count_send"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_send=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Task"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Task=(DateTime)ojb;
			}
			ojb = dataReader["Time_Send"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Send=(DateTime)ojb;
			}
			ojb = dataReader["Type_id_EmailStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_EmailStatus=(int)ojb;
			}
			ojb = dataReader["EmailTask_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmailTask_id=(int)ojb;
			}
			model.TableName=dataReader["TableName"].ToString();
			ojb = dataReader["Keyid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Keyid=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

