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

	public interface Lebi_Agent_Product_User_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Agent_Product_User model);
		void Update(Lebi_Agent_Product_User model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Agent_Product_User GetModel(int id);
		Lebi_Agent_Product_User GetModel(string strWhere);
		Lebi_Agent_Product_User GetModel(SQLPara para);
		List<Lebi_Agent_Product_User> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Agent_Product_User> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Agent_Product_User> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Agent_Product_User> GetList(SQLPara para);
		Lebi_Agent_Product_User BindForm(Lebi_Agent_Product_User model);
		Lebi_Agent_Product_User SafeBindForm(Lebi_Agent_Product_User model);
		Lebi_Agent_Product_User ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Agent_Product_User。
	/// </summary>
	public class D_Lebi_Agent_Product_User
	{
		static Lebi_Agent_Product_User_interface _Instance;
		public static Lebi_Agent_Product_User_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Agent_Product_User();
		            else
		                _Instance = new sqlserver_Lebi_Agent_Product_User();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Agent_Product_User()
		{}
		#region  成员方法
	class sqlserver_Lebi_Agent_Product_User : Lebi_Agent_Product_User_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_Product_User]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_Product_User]");
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
			strSql.Append("select count(1) from [Lebi_Agent_Product_User]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Product_User]");
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
			strSql.Append("select max(id) from [Lebi_Agent_Product_User]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Product_User]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_Product_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_Product_User](");
			strSql.Append("User_id,User_UserName,Agent_Product_Level_id,Time_add,Time_end,Count_Product,Count_product_change,Count_product_change_used,Commission,Remark,IsFailure)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_UserName,@Agent_Product_Level_id,@Time_add,@Time_end,@Count_Product,@Count_product_change,@Count_product_change_used,@Commission,@Remark,@IsFailure)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@User_UserName", model.User_UserName),
					new SqlParameter("@Agent_Product_Level_id", model.Agent_Product_Level_id),
					new SqlParameter("@Time_add", model.Time_add),
					new SqlParameter("@Time_end", model.Time_end),
					new SqlParameter("@Count_Product", model.Count_Product),
					new SqlParameter("@Count_product_change", model.Count_product_change),
					new SqlParameter("@Count_product_change_used", model.Count_product_change_used),
					new SqlParameter("@Commission", model.Commission),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@IsFailure", model.IsFailure)};

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
		public void Update(Lebi_Agent_Product_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_Product_User] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("User_UserName= @User_UserName,");
			strSql.Append("Agent_Product_Level_id= @Agent_Product_Level_id,");
			strSql.Append("Time_add= @Time_add,");
			strSql.Append("Time_end= @Time_end,");
			strSql.Append("Count_Product= @Count_Product,");
			strSql.Append("Count_product_change= @Count_product_change,");
			strSql.Append("Count_product_change_used= @Count_product_change_used,");
			strSql.Append("Commission= @Commission,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("IsFailure= @IsFailure");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Agent_Product_Level_id", SqlDbType.Int,4),
					new SqlParameter("@Time_add", SqlDbType.DateTime),
					new SqlParameter("@Time_end", SqlDbType.DateTime),
					new SqlParameter("@Count_Product", SqlDbType.Int,4),
					new SqlParameter("@Count_product_change", SqlDbType.Int,4),
					new SqlParameter("@Count_product_change_used", SqlDbType.Int,4),
					new SqlParameter("@Commission", SqlDbType.Decimal,9),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					new SqlParameter("@IsFailure", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.User_UserName;
			parameters[3].Value = model.Agent_Product_Level_id;
			parameters[4].Value = model.Time_add;
			parameters[5].Value = model.Time_end;
			parameters[6].Value = model.Count_Product;
			parameters[7].Value = model.Count_product_change;
			parameters[8].Value = model.Count_product_change_used;
			parameters[9].Value = model.Commission;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.IsFailure;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_User] ");
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
			strSql.Append("delete from [Lebi_Agent_Product_User] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_User] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_Product_User GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_User] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Agent_Product_User model=new Lebi_Agent_Product_User();
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
				if(ds.Tables[0].Rows[0]["Agent_Product_Level_id"].ToString()!="")
				{
					model.Agent_Product_Level_id=int.Parse(ds.Tables[0].Rows[0]["Agent_Product_Level_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_end"].ToString()!="")
				{
					model.Time_end=DateTime.Parse(ds.Tables[0].Rows[0]["Time_end"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Product"].ToString()!="")
				{
					model.Count_Product=int.Parse(ds.Tables[0].Rows[0]["Count_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_product_change"].ToString()!="")
				{
					model.Count_product_change=int.Parse(ds.Tables[0].Rows[0]["Count_product_change"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_product_change_used"].ToString()!="")
				{
					model.Count_product_change_used=int.Parse(ds.Tables[0].Rows[0]["Count_product_change_used"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Commission"].ToString()!="")
				{
					model.Commission=decimal.Parse(ds.Tables[0].Rows[0]["Commission"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["IsFailure"].ToString()!="")
				{
					model.IsFailure=int.Parse(ds.Tables[0].Rows[0]["IsFailure"].ToString());
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
		public Lebi_Agent_Product_User GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_User] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_Product_User model=new Lebi_Agent_Product_User();
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
				if(ds.Tables[0].Rows[0]["Agent_Product_Level_id"].ToString()!="")
				{
					model.Agent_Product_Level_id=int.Parse(ds.Tables[0].Rows[0]["Agent_Product_Level_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_end"].ToString()!="")
				{
					model.Time_end=DateTime.Parse(ds.Tables[0].Rows[0]["Time_end"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Product"].ToString()!="")
				{
					model.Count_Product=int.Parse(ds.Tables[0].Rows[0]["Count_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_product_change"].ToString()!="")
				{
					model.Count_product_change=int.Parse(ds.Tables[0].Rows[0]["Count_product_change"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_product_change_used"].ToString()!="")
				{
					model.Count_product_change_used=int.Parse(ds.Tables[0].Rows[0]["Count_product_change_used"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Commission"].ToString()!="")
				{
					model.Commission=decimal.Parse(ds.Tables[0].Rows[0]["Commission"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["IsFailure"].ToString()!="")
				{
					model.IsFailure=int.Parse(ds.Tables[0].Rows[0]["IsFailure"].ToString());
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
		public Lebi_Agent_Product_User GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_Product_User] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_Product_User model=new Lebi_Agent_Product_User();
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
				if(ds.Tables[0].Rows[0]["Agent_Product_Level_id"].ToString()!="")
				{
					model.Agent_Product_Level_id=int.Parse(ds.Tables[0].Rows[0]["Agent_Product_Level_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_end"].ToString()!="")
				{
					model.Time_end=DateTime.Parse(ds.Tables[0].Rows[0]["Time_end"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Product"].ToString()!="")
				{
					model.Count_Product=int.Parse(ds.Tables[0].Rows[0]["Count_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_product_change"].ToString()!="")
				{
					model.Count_product_change=int.Parse(ds.Tables[0].Rows[0]["Count_product_change"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_product_change_used"].ToString()!="")
				{
					model.Count_product_change_used=int.Parse(ds.Tables[0].Rows[0]["Count_product_change_used"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Commission"].ToString()!="")
				{
					model.Commission=decimal.Parse(ds.Tables[0].Rows[0]["Commission"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["IsFailure"].ToString()!="")
				{
					model.IsFailure=int.Parse(ds.Tables[0].Rows[0]["IsFailure"].ToString());
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
		public List<Lebi_Agent_Product_User> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_Product_User]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_Product_User> list = new List<Lebi_Agent_Product_User>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Agent_Product_User> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_Product_User]";
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
			List<Lebi_Agent_Product_User> list = new List<Lebi_Agent_Product_User>();
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
		public List<Lebi_Agent_Product_User> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_Product_User] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_Product_User> list = new List<Lebi_Agent_Product_User>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Agent_Product_User> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_Product_User]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_Product_User> list = new List<Lebi_Agent_Product_User>();
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
		public Lebi_Agent_Product_User BindForm(Lebi_Agent_Product_User model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Agent_Product_Level_id"] != null)
				model.Agent_Product_Level_id=Shop.Tools.RequestTool.RequestInt("Agent_Product_Level_id",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_end"] != null)
				model.Time_end=Shop.Tools.RequestTool.RequestTime("Time_end", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Product"] != null)
				model.Count_Product=Shop.Tools.RequestTool.RequestInt("Count_Product",0);
			if (HttpContext.Current.Request["Count_product_change"] != null)
				model.Count_product_change=Shop.Tools.RequestTool.RequestInt("Count_product_change",0);
			if (HttpContext.Current.Request["Count_product_change_used"] != null)
				model.Count_product_change_used=Shop.Tools.RequestTool.RequestInt("Count_product_change_used",0);
			if (HttpContext.Current.Request["Commission"] != null)
				model.Commission=Shop.Tools.RequestTool.RequestDecimal("Commission",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["IsFailure"] != null)
				model.IsFailure=Shop.Tools.RequestTool.RequestInt("IsFailure",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Agent_Product_User SafeBindForm(Lebi_Agent_Product_User model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Agent_Product_Level_id"] != null)
				model.Agent_Product_Level_id=Shop.Tools.RequestTool.RequestInt("Agent_Product_Level_id",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_end"] != null)
				model.Time_end=Shop.Tools.RequestTool.RequestTime("Time_end", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Product"] != null)
				model.Count_Product=Shop.Tools.RequestTool.RequestInt("Count_Product",0);
			if (HttpContext.Current.Request["Count_product_change"] != null)
				model.Count_product_change=Shop.Tools.RequestTool.RequestInt("Count_product_change",0);
			if (HttpContext.Current.Request["Count_product_change_used"] != null)
				model.Count_product_change_used=Shop.Tools.RequestTool.RequestInt("Count_product_change_used",0);
			if (HttpContext.Current.Request["Commission"] != null)
				model.Commission=Shop.Tools.RequestTool.RequestDecimal("Commission",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["IsFailure"] != null)
				model.IsFailure=Shop.Tools.RequestTool.RequestInt("IsFailure",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Agent_Product_User ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_Product_User model=new Lebi_Agent_Product_User();
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
			ojb = dataReader["Agent_Product_Level_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Agent_Product_Level_id=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_end"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_end=(DateTime)ojb;
			}
			ojb = dataReader["Count_Product"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Product=(int)ojb;
			}
			ojb = dataReader["Count_product_change"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_product_change=(int)ojb;
			}
			ojb = dataReader["Count_product_change_used"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_product_change_used=(int)ojb;
			}
			ojb = dataReader["Commission"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Commission=(decimal)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["IsFailure"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsFailure=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Agent_Product_User : Lebi_Agent_Product_User_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_Product_User]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_Product_User]");
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
			strSql.Append("select count(*) from [Lebi_Agent_Product_User]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Agent_Product_User]");
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
			strSql.Append("select max(id) from [Lebi_Agent_Product_User]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Product_User]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_Product_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_Product_User](");
			strSql.Append("[User_id],[User_UserName],[Agent_Product_Level_id],[Time_add],[Time_end],[Count_Product],[Count_product_change],[Count_product_change_used],[Commission],[Remark],[IsFailure])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_UserName,@Agent_Product_Level_id,@Time_add,@Time_end,@Count_Product,@Count_product_change,@Count_product_change_used,@Commission,@Remark,@IsFailure)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Agent_Product_Level_id", model.Agent_Product_Level_id),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_end", model.Time_end.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Count_Product", model.Count_Product),
					new OleDbParameter("@Count_product_change", model.Count_product_change),
					new OleDbParameter("@Count_product_change_used", model.Count_product_change_used),
					new OleDbParameter("@Commission", model.Commission),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@IsFailure", model.IsFailure)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Agent_Product_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_Product_User] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[User_UserName]=@User_UserName,");
			strSql.Append("[Agent_Product_Level_id]=@Agent_Product_Level_id,");
			strSql.Append("[Time_add]=@Time_add,");
			strSql.Append("[Time_end]=@Time_end,");
			strSql.Append("[Count_Product]=@Count_Product,");
			strSql.Append("[Count_product_change]=@Count_product_change,");
			strSql.Append("[Count_product_change_used]=@Count_product_change_used,");
			strSql.Append("[Commission]=@Commission,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[IsFailure]=@IsFailure");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Agent_Product_Level_id", model.Agent_Product_Level_id),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_end", model.Time_end.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Count_Product", model.Count_Product),
					new OleDbParameter("@Count_product_change", model.Count_product_change),
					new OleDbParameter("@Count_product_change_used", model.Count_product_change_used),
					new OleDbParameter("@Commission", model.Commission),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@IsFailure", model.IsFailure)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_User] ");
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
			strSql.Append("delete from [Lebi_Agent_Product_User] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_User] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_Product_User GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_User] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Agent_Product_User model;
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
		public Lebi_Agent_Product_User GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_User] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_Product_User model;
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
		public Lebi_Agent_Product_User GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_Product_User] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_Product_User model;
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
		public List<Lebi_Agent_Product_User> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_Product_User]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_Product_User> list = new List<Lebi_Agent_Product_User>();
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
		public List<Lebi_Agent_Product_User> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_Product_User]";
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
			List<Lebi_Agent_Product_User> list = new List<Lebi_Agent_Product_User>();
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
		public List<Lebi_Agent_Product_User> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_Product_User] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_Product_User> list = new List<Lebi_Agent_Product_User>();
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
		public List<Lebi_Agent_Product_User> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_Product_User]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_Product_User> list = new List<Lebi_Agent_Product_User>();
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
		public Lebi_Agent_Product_User BindForm(Lebi_Agent_Product_User model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Agent_Product_Level_id"] != null)
				model.Agent_Product_Level_id=Shop.Tools.RequestTool.RequestInt("Agent_Product_Level_id",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_end"] != null)
				model.Time_end=Shop.Tools.RequestTool.RequestTime("Time_end", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Product"] != null)
				model.Count_Product=Shop.Tools.RequestTool.RequestInt("Count_Product",0);
			if (HttpContext.Current.Request["Count_product_change"] != null)
				model.Count_product_change=Shop.Tools.RequestTool.RequestInt("Count_product_change",0);
			if (HttpContext.Current.Request["Count_product_change_used"] != null)
				model.Count_product_change_used=Shop.Tools.RequestTool.RequestInt("Count_product_change_used",0);
			if (HttpContext.Current.Request["Commission"] != null)
				model.Commission=Shop.Tools.RequestTool.RequestDecimal("Commission",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["IsFailure"] != null)
				model.IsFailure=Shop.Tools.RequestTool.RequestInt("IsFailure",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Agent_Product_User SafeBindForm(Lebi_Agent_Product_User model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Agent_Product_Level_id"] != null)
				model.Agent_Product_Level_id=Shop.Tools.RequestTool.RequestInt("Agent_Product_Level_id",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_end"] != null)
				model.Time_end=Shop.Tools.RequestTool.RequestTime("Time_end", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Product"] != null)
				model.Count_Product=Shop.Tools.RequestTool.RequestInt("Count_Product",0);
			if (HttpContext.Current.Request["Count_product_change"] != null)
				model.Count_product_change=Shop.Tools.RequestTool.RequestInt("Count_product_change",0);
			if (HttpContext.Current.Request["Count_product_change_used"] != null)
				model.Count_product_change_used=Shop.Tools.RequestTool.RequestInt("Count_product_change_used",0);
			if (HttpContext.Current.Request["Commission"] != null)
				model.Commission=Shop.Tools.RequestTool.RequestDecimal("Commission",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["IsFailure"] != null)
				model.IsFailure=Shop.Tools.RequestTool.RequestInt("IsFailure",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Agent_Product_User ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_Product_User model=new Lebi_Agent_Product_User();
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
			ojb = dataReader["Agent_Product_Level_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Agent_Product_Level_id=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_end"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_end=(DateTime)ojb;
			}
			ojb = dataReader["Count_Product"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Product=(int)ojb;
			}
			ojb = dataReader["Count_product_change"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_product_change=(int)ojb;
			}
			ojb = dataReader["Count_product_change_used"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_product_change_used=(int)ojb;
			}
			ojb = dataReader["Commission"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Commission=(decimal)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["IsFailure"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsFailure=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

