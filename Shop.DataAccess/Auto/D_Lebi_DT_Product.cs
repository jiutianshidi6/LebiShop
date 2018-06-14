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

	public interface Lebi_DT_Product_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_DT_Product model);
		void Update(Lebi_DT_Product model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_DT_Product GetModel(int id);
		Lebi_DT_Product GetModel(string strWhere);
		Lebi_DT_Product GetModel(SQLPara para);
		List<Lebi_DT_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_DT_Product> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_DT_Product> GetList(string strWhere, string strFieldOrder);
		List<Lebi_DT_Product> GetList(SQLPara para);
		Lebi_DT_Product BindForm(Lebi_DT_Product model);
		Lebi_DT_Product SafeBindForm(Lebi_DT_Product model);
		Lebi_DT_Product ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_DT_Product。
	/// </summary>
	public class D_Lebi_DT_Product
	{
		static Lebi_DT_Product_interface _Instance;
		public static Lebi_DT_Product_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_DT_Product();
		            else
		                _Instance = new sqlserver_Lebi_DT_Product();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_DT_Product()
		{}
		#region  成员方法
	class sqlserver_Lebi_DT_Product : Lebi_DT_Product_interface
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
				strSql.Append("select " + colName + " from [Lebi_DT_Product]");
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
			strSql.Append("select  "+colName+" from [Lebi_DT_Product]");
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
			strSql.Append("select count(1) from [Lebi_DT_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_DT_Product]");
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
			strSql.Append("select max(id) from [Lebi_DT_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_DT_Product]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_DT_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_DT_Product](");
			strSql.Append("User_id,UserName,DT_id,Product_id,Price,Parentid,Count_Sales,Count_Views,Price_Market)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@UserName,@DT_id,@Product_id,@Price,@Parentid,@Count_Sales,@Count_Views,@Price_Market)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@UserName", model.UserName),
					new SqlParameter("@DT_id", model.DT_id),
					new SqlParameter("@Product_id", model.Product_id),
					new SqlParameter("@Price", model.Price),
					new SqlParameter("@Parentid", model.Parentid),
					new SqlParameter("@Count_Sales", model.Count_Sales),
					new SqlParameter("@Count_Views", model.Count_Views),
					new SqlParameter("@Price_Market", model.Price_Market)};

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
		public void Update(Lebi_DT_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_DT_Product] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("UserName= @UserName,");
			strSql.Append("DT_id= @DT_id,");
			strSql.Append("Product_id= @Product_id,");
			strSql.Append("Price= @Price,");
			strSql.Append("Parentid= @Parentid,");
			strSql.Append("Count_Sales= @Count_Sales,");
			strSql.Append("Count_Views= @Count_Views,");
			strSql.Append("Price_Market= @Price_Market");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@DT_id", SqlDbType.Int,4),
					new SqlParameter("@Product_id", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Parentid", SqlDbType.Int,4),
					new SqlParameter("@Count_Sales", SqlDbType.Int,4),
					new SqlParameter("@Count_Views", SqlDbType.Int,4),
					new SqlParameter("@Price_Market", SqlDbType.Decimal,9)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.DT_id;
			parameters[4].Value = model.Product_id;
			parameters[5].Value = model.Price;
			parameters[6].Value = model.Parentid;
			parameters[7].Value = model.Count_Sales;
			parameters[8].Value = model.Count_Views;
			parameters[9].Value = model.Price_Market;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT_Product] ");
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
			strSql.Append("delete from [Lebi_DT_Product] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_DT_Product GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT_Product] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_DT_Product model=new Lebi_DT_Product();
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
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Sales"].ToString()!="")
				{
					model.Count_Sales=int.Parse(ds.Tables[0].Rows[0]["Count_Sales"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views"].ToString()!="")
				{
					model.Count_Views=int.Parse(ds.Tables[0].Rows[0]["Count_Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Market"].ToString()!="")
				{
					model.Price_Market=decimal.Parse(ds.Tables[0].Rows[0]["Price_Market"].ToString());
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
		public Lebi_DT_Product GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT_Product] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_DT_Product model=new Lebi_DT_Product();
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
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Sales"].ToString()!="")
				{
					model.Count_Sales=int.Parse(ds.Tables[0].Rows[0]["Count_Sales"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views"].ToString()!="")
				{
					model.Count_Views=int.Parse(ds.Tables[0].Rows[0]["Count_Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Market"].ToString()!="")
				{
					model.Price_Market=decimal.Parse(ds.Tables[0].Rows[0]["Price_Market"].ToString());
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
		public Lebi_DT_Product GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_DT_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_DT_Product model=new Lebi_DT_Product();
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
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Sales"].ToString()!="")
				{
					model.Count_Sales=int.Parse(ds.Tables[0].Rows[0]["Count_Sales"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views"].ToString()!="")
				{
					model.Count_Views=int.Parse(ds.Tables[0].Rows[0]["Count_Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Market"].ToString()!="")
				{
					model.Price_Market=decimal.Parse(ds.Tables[0].Rows[0]["Price_Market"].ToString());
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
		public List<Lebi_DT_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_DT_Product]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_DT_Product> list = new List<Lebi_DT_Product>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_DT_Product> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_DT_Product]";
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
			List<Lebi_DT_Product> list = new List<Lebi_DT_Product>();
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
		public List<Lebi_DT_Product> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_DT_Product] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_DT_Product> list = new List<Lebi_DT_Product>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_DT_Product> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_DT_Product]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_DT_Product> list = new List<Lebi_DT_Product>();
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
		public Lebi_DT_Product BindForm(Lebi_DT_Product model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["Count_Sales"] != null)
				model.Count_Sales=Shop.Tools.RequestTool.RequestInt("Count_Sales",0);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Price_Market"] != null)
				model.Price_Market=Shop.Tools.RequestTool.RequestDecimal("Price_Market",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_DT_Product SafeBindForm(Lebi_DT_Product model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["Count_Sales"] != null)
				model.Count_Sales=Shop.Tools.RequestTool.RequestInt("Count_Sales",0);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Price_Market"] != null)
				model.Price_Market=Shop.Tools.RequestTool.RequestDecimal("Price_Market",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_DT_Product ReaderBind(IDataReader dataReader)
		{
			Lebi_DT_Product model=new Lebi_DT_Product();
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
			model.UserName=dataReader["UserName"].ToString();
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			ojb = dataReader["Parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Parentid=(int)ojb;
			}
			ojb = dataReader["Count_Sales"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Sales=(int)ojb;
			}
			ojb = dataReader["Count_Views"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Views=(int)ojb;
			}
			ojb = dataReader["Price_Market"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Market=(decimal)ojb;
			}
			return model;
		}

	}
	class access_Lebi_DT_Product : Lebi_DT_Product_interface
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
				strSql.Append("select " + colName + " from [Lebi_DT_Product]");
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
			strSql.Append("select  "+colName+" from [Lebi_DT_Product]");
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
			strSql.Append("select count(*) from [Lebi_DT_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_DT_Product]");
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
			strSql.Append("select max(id) from [Lebi_DT_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_DT_Product]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_DT_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_DT_Product](");
			strSql.Append("[User_id],[UserName],[DT_id],[Product_id],[Price],[Parentid],[Count_Sales],[Count_Views],[Price_Market])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@UserName,@DT_id,@Product_id,@Price,@Parentid,@Count_Sales,@Count_Views,@Price_Market)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@DT_id", model.DT_id),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Parentid", model.Parentid),
					new OleDbParameter("@Count_Sales", model.Count_Sales),
					new OleDbParameter("@Count_Views", model.Count_Views),
					new OleDbParameter("@Price_Market", model.Price_Market)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_DT_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_DT_Product] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[UserName]=@UserName,");
			strSql.Append("[DT_id]=@DT_id,");
			strSql.Append("[Product_id]=@Product_id,");
			strSql.Append("[Price]=@Price,");
			strSql.Append("[Parentid]=@Parentid,");
			strSql.Append("[Count_Sales]=@Count_Sales,");
			strSql.Append("[Count_Views]=@Count_Views,");
			strSql.Append("[Price_Market]=@Price_Market");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@DT_id", model.DT_id),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Parentid", model.Parentid),
					new OleDbParameter("@Count_Sales", model.Count_Sales),
					new OleDbParameter("@Count_Views", model.Count_Views),
					new OleDbParameter("@Price_Market", model.Price_Market)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT_Product] ");
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
			strSql.Append("delete from [Lebi_DT_Product] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_DT_Product GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT_Product] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_DT_Product model;
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
		public Lebi_DT_Product GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT_Product] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_DT_Product model;
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
		public Lebi_DT_Product GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_DT_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_DT_Product model;
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
		public List<Lebi_DT_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_DT_Product]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_DT_Product> list = new List<Lebi_DT_Product>();
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
		public List<Lebi_DT_Product> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_DT_Product]";
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
			List<Lebi_DT_Product> list = new List<Lebi_DT_Product>();
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
		public List<Lebi_DT_Product> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_DT_Product] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_DT_Product> list = new List<Lebi_DT_Product>();
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
		public List<Lebi_DT_Product> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_DT_Product]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_DT_Product> list = new List<Lebi_DT_Product>();
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
		public Lebi_DT_Product BindForm(Lebi_DT_Product model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["Count_Sales"] != null)
				model.Count_Sales=Shop.Tools.RequestTool.RequestInt("Count_Sales",0);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Price_Market"] != null)
				model.Price_Market=Shop.Tools.RequestTool.RequestDecimal("Price_Market",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_DT_Product SafeBindForm(Lebi_DT_Product model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["Count_Sales"] != null)
				model.Count_Sales=Shop.Tools.RequestTool.RequestInt("Count_Sales",0);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Price_Market"] != null)
				model.Price_Market=Shop.Tools.RequestTool.RequestDecimal("Price_Market",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_DT_Product ReaderBind(IDataReader dataReader)
		{
			Lebi_DT_Product model=new Lebi_DT_Product();
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
			model.UserName=dataReader["UserName"].ToString();
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			ojb = dataReader["Parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Parentid=(int)ojb;
			}
			ojb = dataReader["Count_Sales"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Sales=(int)ojb;
			}
			ojb = dataReader["Count_Views"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Views=(int)ojb;
			}
			ojb = dataReader["Price_Market"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Market=(decimal)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

