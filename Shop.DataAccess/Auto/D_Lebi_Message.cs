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

	public interface Lebi_Message_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Message model);
		void Update(Lebi_Message model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Message GetModel(int id);
		Lebi_Message GetModel(string strWhere);
		Lebi_Message GetModel(SQLPara para);
		List<Lebi_Message> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Message> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Message> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Message> GetList(SQLPara para);
		Lebi_Message BindForm(Lebi_Message model);
		Lebi_Message SafeBindForm(Lebi_Message model);
		Lebi_Message ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Message。
	/// </summary>
	public class D_Lebi_Message
	{
		static Lebi_Message_interface _Instance;
		public static Lebi_Message_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Message();
		            else
		                _Instance = new sqlserver_Lebi_Message();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Message()
		{}
		#region  成员方法
	class sqlserver_Lebi_Message : Lebi_Message_interface
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
				strSql.Append("select " + colName + " from [Lebi_Message]");
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
			strSql.Append("select  "+colName+" from [Lebi_Message]");
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
			strSql.Append("select count(1) from [Lebi_Message]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Message]");
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
			strSql.Append("select max(id) from [Lebi_Message]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Message]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Message](");
			strSql.Append("Title,Content,Time_Add,User_id_From,User_id_To,IsRead,Language,Message_Type_id,User_Name_From,User_Name_To,IsSystem,IP,Supplier_id,Parentid,DT_id)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Content,@Time_Add,@User_id_From,@User_id_To,@IsRead,@Language,@Message_Type_id,@User_Name_From,@User_Name_To,@IsSystem,@IP,@Supplier_id,@Parentid,@DT_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", model.Title),
					new SqlParameter("@Content", model.Content),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@User_id_From", model.User_id_From),
					new SqlParameter("@User_id_To", model.User_id_To),
					new SqlParameter("@IsRead", model.IsRead),
					new SqlParameter("@Language", model.Language),
					new SqlParameter("@Message_Type_id", model.Message_Type_id),
					new SqlParameter("@User_Name_From", model.User_Name_From),
					new SqlParameter("@User_Name_To", model.User_Name_To),
					new SqlParameter("@IsSystem", model.IsSystem),
					new SqlParameter("@IP", model.IP),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Parentid", model.Parentid),
					new SqlParameter("@DT_id", model.DT_id)};

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
		public void Update(Lebi_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Message] set ");
			strSql.Append("Title= @Title,");
			strSql.Append("Content= @Content,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("User_id_From= @User_id_From,");
			strSql.Append("User_id_To= @User_id_To,");
			strSql.Append("IsRead= @IsRead,");
			strSql.Append("Language= @Language,");
			strSql.Append("Message_Type_id= @Message_Type_id,");
			strSql.Append("User_Name_From= @User_Name_From,");
			strSql.Append("User_Name_To= @User_Name_To,");
			strSql.Append("IsSystem= @IsSystem,");
			strSql.Append("IP= @IP,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Parentid= @Parentid,");
			strSql.Append("DT_id= @DT_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@User_id_From", SqlDbType.Int,4),
					new SqlParameter("@User_id_To", SqlDbType.Int,4),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@Language", SqlDbType.NVarChar,50),
					new SqlParameter("@Message_Type_id", SqlDbType.Int,4),
					new SqlParameter("@User_Name_From", SqlDbType.NVarChar,100),
					new SqlParameter("@User_Name_To", SqlDbType.NVarChar,100),
					new SqlParameter("@IsSystem", SqlDbType.Int,4),
					new SqlParameter("@IP", SqlDbType.NVarChar,30),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Parentid", SqlDbType.Int,4),
					new SqlParameter("@DT_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.Time_Add;
			parameters[4].Value = model.User_id_From;
			parameters[5].Value = model.User_id_To;
			parameters[6].Value = model.IsRead;
			parameters[7].Value = model.Language;
			parameters[8].Value = model.Message_Type_id;
			parameters[9].Value = model.User_Name_From;
			parameters[10].Value = model.User_Name_To;
			parameters[11].Value = model.IsSystem;
			parameters[12].Value = model.IP;
			parameters[13].Value = model.Supplier_id;
			parameters[14].Value = model.Parentid;
			parameters[15].Value = model.DT_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Message] ");
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
			strSql.Append("delete from [Lebi_Message] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Message] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Message GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Message] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Message model=new Lebi_Message();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_From"].ToString()!="")
				{
					model.User_id_From=int.Parse(ds.Tables[0].Rows[0]["User_id_From"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_To"].ToString()!="")
				{
					model.User_id_To=int.Parse(ds.Tables[0].Rows[0]["User_id_To"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				if(ds.Tables[0].Rows[0]["Message_Type_id"].ToString()!="")
				{
					model.Message_Type_id=int.Parse(ds.Tables[0].Rows[0]["Message_Type_id"].ToString());
				}
				model.User_Name_From=ds.Tables[0].Rows[0]["User_Name_From"].ToString();
				model.User_Name_To=ds.Tables[0].Rows[0]["User_Name_To"].ToString();
				if(ds.Tables[0].Rows[0]["IsSystem"].ToString()!="")
				{
					model.IsSystem=int.Parse(ds.Tables[0].Rows[0]["IsSystem"].ToString());
				}
				model.IP=ds.Tables[0].Rows[0]["IP"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
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
		public Lebi_Message GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Message] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Message model=new Lebi_Message();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_From"].ToString()!="")
				{
					model.User_id_From=int.Parse(ds.Tables[0].Rows[0]["User_id_From"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_To"].ToString()!="")
				{
					model.User_id_To=int.Parse(ds.Tables[0].Rows[0]["User_id_To"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				if(ds.Tables[0].Rows[0]["Message_Type_id"].ToString()!="")
				{
					model.Message_Type_id=int.Parse(ds.Tables[0].Rows[0]["Message_Type_id"].ToString());
				}
				model.User_Name_From=ds.Tables[0].Rows[0]["User_Name_From"].ToString();
				model.User_Name_To=ds.Tables[0].Rows[0]["User_Name_To"].ToString();
				if(ds.Tables[0].Rows[0]["IsSystem"].ToString()!="")
				{
					model.IsSystem=int.Parse(ds.Tables[0].Rows[0]["IsSystem"].ToString());
				}
				model.IP=ds.Tables[0].Rows[0]["IP"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
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
		public Lebi_Message GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Message] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Message model=new Lebi_Message();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_From"].ToString()!="")
				{
					model.User_id_From=int.Parse(ds.Tables[0].Rows[0]["User_id_From"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_To"].ToString()!="")
				{
					model.User_id_To=int.Parse(ds.Tables[0].Rows[0]["User_id_To"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				if(ds.Tables[0].Rows[0]["Message_Type_id"].ToString()!="")
				{
					model.Message_Type_id=int.Parse(ds.Tables[0].Rows[0]["Message_Type_id"].ToString());
				}
				model.User_Name_From=ds.Tables[0].Rows[0]["User_Name_From"].ToString();
				model.User_Name_To=ds.Tables[0].Rows[0]["User_Name_To"].ToString();
				if(ds.Tables[0].Rows[0]["IsSystem"].ToString()!="")
				{
					model.IsSystem=int.Parse(ds.Tables[0].Rows[0]["IsSystem"].ToString());
				}
				model.IP=ds.Tables[0].Rows[0]["IP"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
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
		public List<Lebi_Message> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Message]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Message> list = new List<Lebi_Message>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Message> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Message]";
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
			List<Lebi_Message> list = new List<Lebi_Message>();
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
		public List<Lebi_Message> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Message] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Message> list = new List<Lebi_Message>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Message> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Message]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Message> list = new List<Lebi_Message>();
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
		public Lebi_Message BindForm(Lebi_Message model)
		{
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id_From"] != null)
				model.User_id_From=Shop.Tools.RequestTool.RequestInt("User_id_From",0);
			if (HttpContext.Current.Request["User_id_To"] != null)
				model.User_id_To=Shop.Tools.RequestTool.RequestInt("User_id_To",0);
			if (HttpContext.Current.Request["IsRead"] != null)
				model.IsRead=Shop.Tools.RequestTool.RequestInt("IsRead",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Message_Type_id"] != null)
				model.Message_Type_id=Shop.Tools.RequestTool.RequestInt("Message_Type_id",0);
			if (HttpContext.Current.Request["User_Name_From"] != null)
				model.User_Name_From=Shop.Tools.RequestTool.RequestString("User_Name_From");
			if (HttpContext.Current.Request["User_Name_To"] != null)
				model.User_Name_To=Shop.Tools.RequestTool.RequestString("User_Name_To");
			if (HttpContext.Current.Request["IsSystem"] != null)
				model.IsSystem=Shop.Tools.RequestTool.RequestInt("IsSystem",0);
			if (HttpContext.Current.Request["IP"] != null)
				model.IP=Shop.Tools.RequestTool.RequestString("IP");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Message SafeBindForm(Lebi_Message model)
		{
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id_From"] != null)
				model.User_id_From=Shop.Tools.RequestTool.RequestInt("User_id_From",0);
			if (HttpContext.Current.Request["User_id_To"] != null)
				model.User_id_To=Shop.Tools.RequestTool.RequestInt("User_id_To",0);
			if (HttpContext.Current.Request["IsRead"] != null)
				model.IsRead=Shop.Tools.RequestTool.RequestInt("IsRead",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Message_Type_id"] != null)
				model.Message_Type_id=Shop.Tools.RequestTool.RequestInt("Message_Type_id",0);
			if (HttpContext.Current.Request["User_Name_From"] != null)
				model.User_Name_From=Shop.Tools.RequestTool.RequestSafeString("User_Name_From");
			if (HttpContext.Current.Request["User_Name_To"] != null)
				model.User_Name_To=Shop.Tools.RequestTool.RequestSafeString("User_Name_To");
			if (HttpContext.Current.Request["IsSystem"] != null)
				model.IsSystem=Shop.Tools.RequestTool.RequestInt("IsSystem",0);
			if (HttpContext.Current.Request["IP"] != null)
				model.IP=Shop.Tools.RequestTool.RequestSafeString("IP");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Message ReaderBind(IDataReader dataReader)
		{
			Lebi_Message model=new Lebi_Message();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Title=dataReader["Title"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["User_id_From"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id_From=(int)ojb;
			}
			ojb = dataReader["User_id_To"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id_To=(int)ojb;
			}
			ojb = dataReader["IsRead"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRead=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			ojb = dataReader["Message_Type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Message_Type_id=(int)ojb;
			}
			model.User_Name_From=dataReader["User_Name_From"].ToString();
			model.User_Name_To=dataReader["User_Name_To"].ToString();
			ojb = dataReader["IsSystem"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSystem=(int)ojb;
			}
			model.IP=dataReader["IP"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["Parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Parentid=(int)ojb;
			}
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Message : Lebi_Message_interface
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
				strSql.Append("select " + colName + " from [Lebi_Message]");
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
			strSql.Append("select  "+colName+" from [Lebi_Message]");
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
			strSql.Append("select count(*) from [Lebi_Message]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Message]");
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
			strSql.Append("select max(id) from [Lebi_Message]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Message]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Message](");
			strSql.Append("[Title],[Content],[Time_Add],[User_id_From],[User_id_To],[IsRead],[Language],[Message_Type_id],[User_Name_From],[User_Name_To],[IsSystem],[IP],[Supplier_id],[Parentid],[DT_id])");
			strSql.Append(" values (");
			strSql.Append("@Title,@Content,@Time_Add,@User_id_From,@User_id_To,@IsRead,@Language,@Message_Type_id,@User_Name_From,@User_Name_To,@IsSystem,@IP,@Supplier_id,@Parentid,@DT_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@User_id_From", model.User_id_From),
					new OleDbParameter("@User_id_To", model.User_id_To),
					new OleDbParameter("@IsRead", model.IsRead),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Message_Type_id", model.Message_Type_id),
					new OleDbParameter("@User_Name_From", model.User_Name_From),
					new OleDbParameter("@User_Name_To", model.User_Name_To),
					new OleDbParameter("@IsSystem", model.IsSystem),
					new OleDbParameter("@IP", model.IP),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Parentid", model.Parentid),
					new OleDbParameter("@DT_id", model.DT_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Message] set ");
			strSql.Append("[Title]=@Title,");
			strSql.Append("[Content]=@Content,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[User_id_From]=@User_id_From,");
			strSql.Append("[User_id_To]=@User_id_To,");
			strSql.Append("[IsRead]=@IsRead,");
			strSql.Append("[Language]=@Language,");
			strSql.Append("[Message_Type_id]=@Message_Type_id,");
			strSql.Append("[User_Name_From]=@User_Name_From,");
			strSql.Append("[User_Name_To]=@User_Name_To,");
			strSql.Append("[IsSystem]=@IsSystem,");
			strSql.Append("[IP]=@IP,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Parentid]=@Parentid,");
			strSql.Append("[DT_id]=@DT_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@User_id_From", model.User_id_From),
					new OleDbParameter("@User_id_To", model.User_id_To),
					new OleDbParameter("@IsRead", model.IsRead),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Message_Type_id", model.Message_Type_id),
					new OleDbParameter("@User_Name_From", model.User_Name_From),
					new OleDbParameter("@User_Name_To", model.User_Name_To),
					new OleDbParameter("@IsSystem", model.IsSystem),
					new OleDbParameter("@IP", model.IP),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Parentid", model.Parentid),
					new OleDbParameter("@DT_id", model.DT_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Message] ");
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
			strSql.Append("delete from [Lebi_Message] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Message] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Message GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Message] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Message model;
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
		public Lebi_Message GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Message] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Message model;
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
		public Lebi_Message GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Message] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Message model;
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
		public List<Lebi_Message> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Message]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Message> list = new List<Lebi_Message>();
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
		public List<Lebi_Message> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Message]";
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
			List<Lebi_Message> list = new List<Lebi_Message>();
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
		public List<Lebi_Message> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Message] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Message> list = new List<Lebi_Message>();
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
		public List<Lebi_Message> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Message]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Message> list = new List<Lebi_Message>();
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
		public Lebi_Message BindForm(Lebi_Message model)
		{
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id_From"] != null)
				model.User_id_From=Shop.Tools.RequestTool.RequestInt("User_id_From",0);
			if (HttpContext.Current.Request["User_id_To"] != null)
				model.User_id_To=Shop.Tools.RequestTool.RequestInt("User_id_To",0);
			if (HttpContext.Current.Request["IsRead"] != null)
				model.IsRead=Shop.Tools.RequestTool.RequestInt("IsRead",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Message_Type_id"] != null)
				model.Message_Type_id=Shop.Tools.RequestTool.RequestInt("Message_Type_id",0);
			if (HttpContext.Current.Request["User_Name_From"] != null)
				model.User_Name_From=Shop.Tools.RequestTool.RequestString("User_Name_From");
			if (HttpContext.Current.Request["User_Name_To"] != null)
				model.User_Name_To=Shop.Tools.RequestTool.RequestString("User_Name_To");
			if (HttpContext.Current.Request["IsSystem"] != null)
				model.IsSystem=Shop.Tools.RequestTool.RequestInt("IsSystem",0);
			if (HttpContext.Current.Request["IP"] != null)
				model.IP=Shop.Tools.RequestTool.RequestString("IP");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Message SafeBindForm(Lebi_Message model)
		{
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id_From"] != null)
				model.User_id_From=Shop.Tools.RequestTool.RequestInt("User_id_From",0);
			if (HttpContext.Current.Request["User_id_To"] != null)
				model.User_id_To=Shop.Tools.RequestTool.RequestInt("User_id_To",0);
			if (HttpContext.Current.Request["IsRead"] != null)
				model.IsRead=Shop.Tools.RequestTool.RequestInt("IsRead",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Message_Type_id"] != null)
				model.Message_Type_id=Shop.Tools.RequestTool.RequestInt("Message_Type_id",0);
			if (HttpContext.Current.Request["User_Name_From"] != null)
				model.User_Name_From=Shop.Tools.RequestTool.RequestSafeString("User_Name_From");
			if (HttpContext.Current.Request["User_Name_To"] != null)
				model.User_Name_To=Shop.Tools.RequestTool.RequestSafeString("User_Name_To");
			if (HttpContext.Current.Request["IsSystem"] != null)
				model.IsSystem=Shop.Tools.RequestTool.RequestInt("IsSystem",0);
			if (HttpContext.Current.Request["IP"] != null)
				model.IP=Shop.Tools.RequestTool.RequestSafeString("IP");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Message ReaderBind(IDataReader dataReader)
		{
			Lebi_Message model=new Lebi_Message();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Title=dataReader["Title"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["User_id_From"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id_From=(int)ojb;
			}
			ojb = dataReader["User_id_To"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id_To=(int)ojb;
			}
			ojb = dataReader["IsRead"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRead=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			ojb = dataReader["Message_Type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Message_Type_id=(int)ojb;
			}
			model.User_Name_From=dataReader["User_Name_From"].ToString();
			model.User_Name_To=dataReader["User_Name_To"].ToString();
			ojb = dataReader["IsSystem"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSystem=(int)ojb;
			}
			model.IP=dataReader["IP"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["Parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Parentid=(int)ojb;
			}
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

