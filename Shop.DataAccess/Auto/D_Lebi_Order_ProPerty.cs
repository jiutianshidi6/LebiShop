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

	public interface Lebi_Order_ProPerty_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Order_ProPerty model);
		void Update(Lebi_Order_ProPerty model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Order_ProPerty GetModel(int id);
		Lebi_Order_ProPerty GetModel(string strWhere);
		Lebi_Order_ProPerty GetModel(SQLPara para);
		List<Lebi_Order_ProPerty> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Order_ProPerty> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Order_ProPerty> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Order_ProPerty> GetList(SQLPara para);
		Lebi_Order_ProPerty BindForm(Lebi_Order_ProPerty model);
		Lebi_Order_ProPerty SafeBindForm(Lebi_Order_ProPerty model);
		Lebi_Order_ProPerty ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Order_ProPerty。
	/// </summary>
	public class D_Lebi_Order_ProPerty
	{
		static Lebi_Order_ProPerty_interface _Instance;
		public static Lebi_Order_ProPerty_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Order_ProPerty();
		            else
		                _Instance = new sqlserver_Lebi_Order_ProPerty();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Order_ProPerty()
		{}
		#region  成员方法
	class sqlserver_Lebi_Order_ProPerty : Lebi_Order_ProPerty_interface
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
				strSql.Append("select " + colName + " from [Lebi_Order_ProPerty]");
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
			strSql.Append("select  "+colName+" from [Lebi_Order_ProPerty]");
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
			strSql.Append("select count(1) from [Lebi_Order_ProPerty]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Order_ProPerty]");
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
			strSql.Append("select max(id) from [Lebi_Order_ProPerty]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Order_ProPerty]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Order_ProPerty model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Order_ProPerty](");
			strSql.Append("ProPertyid,ProPertyName,ProPertyValue,ProPertyParentid,Order_id,Order_Code,User_id,Time_Add,User_UserName)");
			strSql.Append(" values (");
			strSql.Append("@ProPertyid,@ProPertyName,@ProPertyValue,@ProPertyParentid,@Order_id,@Order_Code,@User_id,@Time_Add,@User_UserName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProPertyid", model.ProPertyid),
					new SqlParameter("@ProPertyName", model.ProPertyName),
					new SqlParameter("@ProPertyValue", model.ProPertyValue),
					new SqlParameter("@ProPertyParentid", model.ProPertyParentid),
					new SqlParameter("@Order_id", model.Order_id),
					new SqlParameter("@Order_Code", model.Order_Code),
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@User_UserName", model.User_UserName)};

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
		public void Update(Lebi_Order_ProPerty model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Order_ProPerty] set ");
			strSql.Append("ProPertyid= @ProPertyid,");
			strSql.Append("ProPertyName= @ProPertyName,");
			strSql.Append("ProPertyValue= @ProPertyValue,");
			strSql.Append("ProPertyParentid= @ProPertyParentid,");
			strSql.Append("Order_id= @Order_id,");
			strSql.Append("Order_Code= @Order_Code,");
			strSql.Append("User_id= @User_id,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("User_UserName= @User_UserName");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ProPertyid", SqlDbType.Int,4),
					new SqlParameter("@ProPertyName", SqlDbType.NVarChar,100),
					new SqlParameter("@ProPertyValue", SqlDbType.NVarChar,100),
					new SqlParameter("@ProPertyParentid", SqlDbType.Int,4),
					new SqlParameter("@Order_id", SqlDbType.Int,4),
					new SqlParameter("@Order_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProPertyid;
			parameters[2].Value = model.ProPertyName;
			parameters[3].Value = model.ProPertyValue;
			parameters[4].Value = model.ProPertyParentid;
			parameters[5].Value = model.Order_id;
			parameters[6].Value = model.Order_Code;
			parameters[7].Value = model.User_id;
			parameters[8].Value = model.Time_Add;
			parameters[9].Value = model.User_UserName;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order_ProPerty] ");
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
			strSql.Append("delete from [Lebi_Order_ProPerty] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order_ProPerty] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Order_ProPerty GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order_ProPerty] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Order_ProPerty model=new Lebi_Order_ProPerty();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPertyid"].ToString()!="")
				{
					model.ProPertyid=int.Parse(ds.Tables[0].Rows[0]["ProPertyid"].ToString());
				}
				model.ProPertyName=ds.Tables[0].Rows[0]["ProPertyName"].ToString();
				model.ProPertyValue=ds.Tables[0].Rows[0]["ProPertyValue"].ToString();
				if(ds.Tables[0].Rows[0]["ProPertyParentid"].ToString()!="")
				{
					model.ProPertyParentid=int.Parse(ds.Tables[0].Rows[0]["ProPertyParentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
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
		public Lebi_Order_ProPerty GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order_ProPerty] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Order_ProPerty model=new Lebi_Order_ProPerty();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPertyid"].ToString()!="")
				{
					model.ProPertyid=int.Parse(ds.Tables[0].Rows[0]["ProPertyid"].ToString());
				}
				model.ProPertyName=ds.Tables[0].Rows[0]["ProPertyName"].ToString();
				model.ProPertyValue=ds.Tables[0].Rows[0]["ProPertyValue"].ToString();
				if(ds.Tables[0].Rows[0]["ProPertyParentid"].ToString()!="")
				{
					model.ProPertyParentid=int.Parse(ds.Tables[0].Rows[0]["ProPertyParentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
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
		public Lebi_Order_ProPerty GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Order_ProPerty] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Order_ProPerty model=new Lebi_Order_ProPerty();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPertyid"].ToString()!="")
				{
					model.ProPertyid=int.Parse(ds.Tables[0].Rows[0]["ProPertyid"].ToString());
				}
				model.ProPertyName=ds.Tables[0].Rows[0]["ProPertyName"].ToString();
				model.ProPertyValue=ds.Tables[0].Rows[0]["ProPertyValue"].ToString();
				if(ds.Tables[0].Rows[0]["ProPertyParentid"].ToString()!="")
				{
					model.ProPertyParentid=int.Parse(ds.Tables[0].Rows[0]["ProPertyParentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
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
		public List<Lebi_Order_ProPerty> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Order_ProPerty]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Order_ProPerty> list = new List<Lebi_Order_ProPerty>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Order_ProPerty> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Order_ProPerty]";
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
			List<Lebi_Order_ProPerty> list = new List<Lebi_Order_ProPerty>();
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
		public List<Lebi_Order_ProPerty> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Order_ProPerty] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Order_ProPerty> list = new List<Lebi_Order_ProPerty>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Order_ProPerty> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Order_ProPerty]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Order_ProPerty> list = new List<Lebi_Order_ProPerty>();
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
		public Lebi_Order_ProPerty BindForm(Lebi_Order_ProPerty model)
		{
			if (HttpContext.Current.Request["ProPertyid"] != null)
				model.ProPertyid=Shop.Tools.RequestTool.RequestInt("ProPertyid",0);
			if (HttpContext.Current.Request["ProPertyName"] != null)
				model.ProPertyName=Shop.Tools.RequestTool.RequestString("ProPertyName");
			if (HttpContext.Current.Request["ProPertyValue"] != null)
				model.ProPertyValue=Shop.Tools.RequestTool.RequestString("ProPertyValue");
			if (HttpContext.Current.Request["ProPertyParentid"] != null)
				model.ProPertyParentid=Shop.Tools.RequestTool.RequestInt("ProPertyParentid",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Order_ProPerty SafeBindForm(Lebi_Order_ProPerty model)
		{
			if (HttpContext.Current.Request["ProPertyid"] != null)
				model.ProPertyid=Shop.Tools.RequestTool.RequestInt("ProPertyid",0);
			if (HttpContext.Current.Request["ProPertyName"] != null)
				model.ProPertyName=Shop.Tools.RequestTool.RequestSafeString("ProPertyName");
			if (HttpContext.Current.Request["ProPertyValue"] != null)
				model.ProPertyValue=Shop.Tools.RequestTool.RequestSafeString("ProPertyValue");
			if (HttpContext.Current.Request["ProPertyParentid"] != null)
				model.ProPertyParentid=Shop.Tools.RequestTool.RequestInt("ProPertyParentid",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Order_ProPerty ReaderBind(IDataReader dataReader)
		{
			Lebi_Order_ProPerty model=new Lebi_Order_ProPerty();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProPertyid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProPertyid=(int)ojb;
			}
			model.ProPertyName=dataReader["ProPertyName"].ToString();
			model.ProPertyValue=dataReader["ProPertyValue"].ToString();
			ojb = dataReader["ProPertyParentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProPertyParentid=(int)ojb;
			}
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			return model;
		}

	}
	class access_Lebi_Order_ProPerty : Lebi_Order_ProPerty_interface
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
				strSql.Append("select " + colName + " from [Lebi_Order_ProPerty]");
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
			strSql.Append("select  "+colName+" from [Lebi_Order_ProPerty]");
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
			strSql.Append("select count(*) from [Lebi_Order_ProPerty]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Order_ProPerty]");
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
			strSql.Append("select max(id) from [Lebi_Order_ProPerty]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Order_ProPerty]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Order_ProPerty model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Order_ProPerty](");
			strSql.Append("[ProPertyid],[ProPertyName],[ProPertyValue],[ProPertyParentid],[Order_id],[Order_Code],[User_id],[Time_Add],[User_UserName])");
			strSql.Append(" values (");
			strSql.Append("@ProPertyid,@ProPertyName,@ProPertyValue,@ProPertyParentid,@Order_id,@Order_Code,@User_id,@Time_Add,@User_UserName)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ProPertyid", model.ProPertyid),
					new OleDbParameter("@ProPertyName", model.ProPertyName),
					new OleDbParameter("@ProPertyValue", model.ProPertyValue),
					new OleDbParameter("@ProPertyParentid", model.ProPertyParentid),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@User_UserName", model.User_UserName)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Order_ProPerty model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Order_ProPerty] set ");
			strSql.Append("[ProPertyid]=@ProPertyid,");
			strSql.Append("[ProPertyName]=@ProPertyName,");
			strSql.Append("[ProPertyValue]=@ProPertyValue,");
			strSql.Append("[ProPertyParentid]=@ProPertyParentid,");
			strSql.Append("[Order_id]=@Order_id,");
			strSql.Append("[Order_Code]=@Order_Code,");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[User_UserName]=@User_UserName");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@ProPertyid", model.ProPertyid),
					new OleDbParameter("@ProPertyName", model.ProPertyName),
					new OleDbParameter("@ProPertyValue", model.ProPertyValue),
					new OleDbParameter("@ProPertyParentid", model.ProPertyParentid),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@User_UserName", model.User_UserName)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order_ProPerty] ");
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
			strSql.Append("delete from [Lebi_Order_ProPerty] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order_ProPerty] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Order_ProPerty GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order_ProPerty] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Order_ProPerty model;
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
		public Lebi_Order_ProPerty GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order_ProPerty] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Order_ProPerty model;
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
		public Lebi_Order_ProPerty GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Order_ProPerty] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Order_ProPerty model;
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
		public List<Lebi_Order_ProPerty> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Order_ProPerty]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Order_ProPerty> list = new List<Lebi_Order_ProPerty>();
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
		public List<Lebi_Order_ProPerty> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Order_ProPerty]";
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
			List<Lebi_Order_ProPerty> list = new List<Lebi_Order_ProPerty>();
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
		public List<Lebi_Order_ProPerty> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Order_ProPerty] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Order_ProPerty> list = new List<Lebi_Order_ProPerty>();
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
		public List<Lebi_Order_ProPerty> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Order_ProPerty]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Order_ProPerty> list = new List<Lebi_Order_ProPerty>();
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
		public Lebi_Order_ProPerty BindForm(Lebi_Order_ProPerty model)
		{
			if (HttpContext.Current.Request["ProPertyid"] != null)
				model.ProPertyid=Shop.Tools.RequestTool.RequestInt("ProPertyid",0);
			if (HttpContext.Current.Request["ProPertyName"] != null)
				model.ProPertyName=Shop.Tools.RequestTool.RequestString("ProPertyName");
			if (HttpContext.Current.Request["ProPertyValue"] != null)
				model.ProPertyValue=Shop.Tools.RequestTool.RequestString("ProPertyValue");
			if (HttpContext.Current.Request["ProPertyParentid"] != null)
				model.ProPertyParentid=Shop.Tools.RequestTool.RequestInt("ProPertyParentid",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Order_ProPerty SafeBindForm(Lebi_Order_ProPerty model)
		{
			if (HttpContext.Current.Request["ProPertyid"] != null)
				model.ProPertyid=Shop.Tools.RequestTool.RequestInt("ProPertyid",0);
			if (HttpContext.Current.Request["ProPertyName"] != null)
				model.ProPertyName=Shop.Tools.RequestTool.RequestSafeString("ProPertyName");
			if (HttpContext.Current.Request["ProPertyValue"] != null)
				model.ProPertyValue=Shop.Tools.RequestTool.RequestSafeString("ProPertyValue");
			if (HttpContext.Current.Request["ProPertyParentid"] != null)
				model.ProPertyParentid=Shop.Tools.RequestTool.RequestInt("ProPertyParentid",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Order_ProPerty ReaderBind(IDataReader dataReader)
		{
			Lebi_Order_ProPerty model=new Lebi_Order_ProPerty();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProPertyid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProPertyid=(int)ojb;
			}
			model.ProPertyName=dataReader["ProPertyName"].ToString();
			model.ProPertyValue=dataReader["ProPertyValue"].ToString();
			ojb = dataReader["ProPertyParentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProPertyParentid=(int)ojb;
			}
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

