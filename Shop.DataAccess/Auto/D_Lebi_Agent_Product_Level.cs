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

	public interface Lebi_Agent_Product_Level_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Agent_Product_Level model);
		void Update(Lebi_Agent_Product_Level model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Agent_Product_Level GetModel(int id);
		Lebi_Agent_Product_Level GetModel(string strWhere);
		Lebi_Agent_Product_Level GetModel(SQLPara para);
		List<Lebi_Agent_Product_Level> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Agent_Product_Level> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Agent_Product_Level> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Agent_Product_Level> GetList(SQLPara para);
		Lebi_Agent_Product_Level BindForm(Lebi_Agent_Product_Level model);
		Lebi_Agent_Product_Level SafeBindForm(Lebi_Agent_Product_Level model);
		Lebi_Agent_Product_Level ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Agent_Product_Level。
	/// </summary>
	public class D_Lebi_Agent_Product_Level
	{
		static Lebi_Agent_Product_Level_interface _Instance;
		public static Lebi_Agent_Product_Level_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Agent_Product_Level();
		            else
		                _Instance = new sqlserver_Lebi_Agent_Product_Level();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Agent_Product_Level()
		{}
		#region  成员方法
	class sqlserver_Lebi_Agent_Product_Level : Lebi_Agent_Product_Level_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_Product_Level]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_Product_Level]");
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
			strSql.Append("select count(1) from [Lebi_Agent_Product_Level]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Product_Level]");
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
			strSql.Append("select max(id) from [Lebi_Agent_Product_Level]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Product_Level]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_Product_Level model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_Product_Level](");
			strSql.Append("Name,Sort,Price,Count_Product,Count_product_change,Years,Content,Commission,CardOrder_id)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Sort,@Price,@Count_Product,@Count_product_change,@Years,@Content,@Commission,@CardOrder_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Price", model.Price),
					new SqlParameter("@Count_Product", model.Count_Product),
					new SqlParameter("@Count_product_change", model.Count_product_change),
					new SqlParameter("@Years", model.Years),
					new SqlParameter("@Content", model.Content),
					new SqlParameter("@Commission", model.Commission),
					new SqlParameter("@CardOrder_id", model.CardOrder_id)};

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
		public void Update(Lebi_Agent_Product_Level model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_Product_Level] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Price= @Price,");
			strSql.Append("Count_Product= @Count_Product,");
			strSql.Append("Count_product_change= @Count_product_change,");
			strSql.Append("Years= @Years,");
			strSql.Append("Content= @Content,");
			strSql.Append("Commission= @Commission,");
			strSql.Append("CardOrder_id= @CardOrder_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Count_Product", SqlDbType.Int,4),
					new SqlParameter("@Count_product_change", SqlDbType.Int,4),
					new SqlParameter("@Years", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Commission", SqlDbType.Decimal,9),
					new SqlParameter("@CardOrder_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Sort;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.Count_Product;
			parameters[5].Value = model.Count_product_change;
			parameters[6].Value = model.Years;
			parameters[7].Value = model.Content;
			parameters[8].Value = model.Commission;
			parameters[9].Value = model.CardOrder_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_Level] ");
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
			strSql.Append("delete from [Lebi_Agent_Product_Level] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_Level] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_Product_Level GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_Level] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Agent_Product_Level model=new Lebi_Agent_Product_Level();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Product"].ToString()!="")
				{
					model.Count_Product=int.Parse(ds.Tables[0].Rows[0]["Count_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_product_change"].ToString()!="")
				{
					model.Count_product_change=int.Parse(ds.Tables[0].Rows[0]["Count_product_change"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Years"].ToString()!="")
				{
					model.Years=int.Parse(ds.Tables[0].Rows[0]["Years"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Commission"].ToString()!="")
				{
					model.Commission=decimal.Parse(ds.Tables[0].Rows[0]["Commission"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardOrder_id"].ToString()!="")
				{
					model.CardOrder_id=int.Parse(ds.Tables[0].Rows[0]["CardOrder_id"].ToString());
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
		public Lebi_Agent_Product_Level GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_Level] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_Product_Level model=new Lebi_Agent_Product_Level();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Product"].ToString()!="")
				{
					model.Count_Product=int.Parse(ds.Tables[0].Rows[0]["Count_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_product_change"].ToString()!="")
				{
					model.Count_product_change=int.Parse(ds.Tables[0].Rows[0]["Count_product_change"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Years"].ToString()!="")
				{
					model.Years=int.Parse(ds.Tables[0].Rows[0]["Years"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Commission"].ToString()!="")
				{
					model.Commission=decimal.Parse(ds.Tables[0].Rows[0]["Commission"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardOrder_id"].ToString()!="")
				{
					model.CardOrder_id=int.Parse(ds.Tables[0].Rows[0]["CardOrder_id"].ToString());
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
		public Lebi_Agent_Product_Level GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_Product_Level] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_Product_Level model=new Lebi_Agent_Product_Level();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Product"].ToString()!="")
				{
					model.Count_Product=int.Parse(ds.Tables[0].Rows[0]["Count_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_product_change"].ToString()!="")
				{
					model.Count_product_change=int.Parse(ds.Tables[0].Rows[0]["Count_product_change"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Years"].ToString()!="")
				{
					model.Years=int.Parse(ds.Tables[0].Rows[0]["Years"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Commission"].ToString()!="")
				{
					model.Commission=decimal.Parse(ds.Tables[0].Rows[0]["Commission"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardOrder_id"].ToString()!="")
				{
					model.CardOrder_id=int.Parse(ds.Tables[0].Rows[0]["CardOrder_id"].ToString());
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
		public List<Lebi_Agent_Product_Level> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_Product_Level]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_Product_Level> list = new List<Lebi_Agent_Product_Level>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Agent_Product_Level> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_Product_Level]";
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
			List<Lebi_Agent_Product_Level> list = new List<Lebi_Agent_Product_Level>();
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
		public List<Lebi_Agent_Product_Level> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_Product_Level] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_Product_Level> list = new List<Lebi_Agent_Product_Level>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Agent_Product_Level> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_Product_Level]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_Product_Level> list = new List<Lebi_Agent_Product_Level>();
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
		public Lebi_Agent_Product_Level BindForm(Lebi_Agent_Product_Level model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Count_Product"] != null)
				model.Count_Product=Shop.Tools.RequestTool.RequestInt("Count_Product",0);
			if (HttpContext.Current.Request["Count_product_change"] != null)
				model.Count_product_change=Shop.Tools.RequestTool.RequestInt("Count_product_change",0);
			if (HttpContext.Current.Request["Years"] != null)
				model.Years=Shop.Tools.RequestTool.RequestInt("Years",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Commission"] != null)
				model.Commission=Shop.Tools.RequestTool.RequestDecimal("Commission",0);
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Agent_Product_Level SafeBindForm(Lebi_Agent_Product_Level model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Count_Product"] != null)
				model.Count_Product=Shop.Tools.RequestTool.RequestInt("Count_Product",0);
			if (HttpContext.Current.Request["Count_product_change"] != null)
				model.Count_product_change=Shop.Tools.RequestTool.RequestInt("Count_product_change",0);
			if (HttpContext.Current.Request["Years"] != null)
				model.Years=Shop.Tools.RequestTool.RequestInt("Years",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Commission"] != null)
				model.Commission=Shop.Tools.RequestTool.RequestDecimal("Commission",0);
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Agent_Product_Level ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_Product_Level model=new Lebi_Agent_Product_Level();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
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
			ojb = dataReader["Years"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Years=(int)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Commission"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Commission=(decimal)ojb;
			}
			ojb = dataReader["CardOrder_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CardOrder_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Agent_Product_Level : Lebi_Agent_Product_Level_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_Product_Level]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_Product_Level]");
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
			strSql.Append("select count(*) from [Lebi_Agent_Product_Level]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Agent_Product_Level]");
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
			strSql.Append("select max(id) from [Lebi_Agent_Product_Level]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Product_Level]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_Product_Level model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_Product_Level](");
			strSql.Append("[Name],[Sort],[Price],[Count_Product],[Count_product_change],[Years],[Content],[Commission],[CardOrder_id])");
			strSql.Append(" values (");
			strSql.Append("@Name,@Sort,@Price,@Count_Product,@Count_product_change,@Years,@Content,@Commission,@CardOrder_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Count_Product", model.Count_Product),
					new OleDbParameter("@Count_product_change", model.Count_product_change),
					new OleDbParameter("@Years", model.Years),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Commission", model.Commission),
					new OleDbParameter("@CardOrder_id", model.CardOrder_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Agent_Product_Level model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_Product_Level] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Price]=@Price,");
			strSql.Append("[Count_Product]=@Count_Product,");
			strSql.Append("[Count_product_change]=@Count_product_change,");
			strSql.Append("[Years]=@Years,");
			strSql.Append("[Content]=@Content,");
			strSql.Append("[Commission]=@Commission,");
			strSql.Append("[CardOrder_id]=@CardOrder_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Count_Product", model.Count_Product),
					new OleDbParameter("@Count_product_change", model.Count_product_change),
					new OleDbParameter("@Years", model.Years),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Commission", model.Commission),
					new OleDbParameter("@CardOrder_id", model.CardOrder_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_Level] ");
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
			strSql.Append("delete from [Lebi_Agent_Product_Level] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Product_Level] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_Product_Level GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_Level] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Agent_Product_Level model;
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
		public Lebi_Agent_Product_Level GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Product_Level] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_Product_Level model;
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
		public Lebi_Agent_Product_Level GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_Product_Level] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_Product_Level model;
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
		public List<Lebi_Agent_Product_Level> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_Product_Level]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_Product_Level> list = new List<Lebi_Agent_Product_Level>();
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
		public List<Lebi_Agent_Product_Level> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_Product_Level]";
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
			List<Lebi_Agent_Product_Level> list = new List<Lebi_Agent_Product_Level>();
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
		public List<Lebi_Agent_Product_Level> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_Product_Level] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_Product_Level> list = new List<Lebi_Agent_Product_Level>();
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
		public List<Lebi_Agent_Product_Level> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_Product_Level]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_Product_Level> list = new List<Lebi_Agent_Product_Level>();
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
		public Lebi_Agent_Product_Level BindForm(Lebi_Agent_Product_Level model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Count_Product"] != null)
				model.Count_Product=Shop.Tools.RequestTool.RequestInt("Count_Product",0);
			if (HttpContext.Current.Request["Count_product_change"] != null)
				model.Count_product_change=Shop.Tools.RequestTool.RequestInt("Count_product_change",0);
			if (HttpContext.Current.Request["Years"] != null)
				model.Years=Shop.Tools.RequestTool.RequestInt("Years",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Commission"] != null)
				model.Commission=Shop.Tools.RequestTool.RequestDecimal("Commission",0);
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Agent_Product_Level SafeBindForm(Lebi_Agent_Product_Level model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Count_Product"] != null)
				model.Count_Product=Shop.Tools.RequestTool.RequestInt("Count_Product",0);
			if (HttpContext.Current.Request["Count_product_change"] != null)
				model.Count_product_change=Shop.Tools.RequestTool.RequestInt("Count_product_change",0);
			if (HttpContext.Current.Request["Years"] != null)
				model.Years=Shop.Tools.RequestTool.RequestInt("Years",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Commission"] != null)
				model.Commission=Shop.Tools.RequestTool.RequestDecimal("Commission",0);
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Agent_Product_Level ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_Product_Level model=new Lebi_Agent_Product_Level();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
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
			ojb = dataReader["Years"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Years=(int)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Commission"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Commission=(decimal)ojb;
			}
			ojb = dataReader["CardOrder_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CardOrder_id=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

