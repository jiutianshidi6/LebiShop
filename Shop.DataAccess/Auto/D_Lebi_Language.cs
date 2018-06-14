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

	public interface Lebi_Language_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Language model);
		void Update(Lebi_Language model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Language GetModel(int id);
		Lebi_Language GetModel(string strWhere);
		Lebi_Language GetModel(SQLPara para);
		List<Lebi_Language> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Language> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Language> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Language> GetList(SQLPara para);
		Lebi_Language BindForm(Lebi_Language model);
		Lebi_Language SafeBindForm(Lebi_Language model);
		Lebi_Language ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Language。
	/// </summary>
	public class D_Lebi_Language
	{
		static Lebi_Language_interface _Instance;
		public static Lebi_Language_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Language();
		            else
		                _Instance = new sqlserver_Lebi_Language();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Language()
		{}
		#region  成员方法
	class sqlserver_Lebi_Language : Lebi_Language_interface
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
				strSql.Append("select " + colName + " from [Lebi_Language]");
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
			strSql.Append("select  "+colName+" from [Lebi_Language]");
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
			strSql.Append("select count(1) from [Lebi_Language]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Language]");
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
			strSql.Append("select max(id) from [Lebi_Language]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Language]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Language model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Language](");
			strSql.Append("Name,Code,Sort,Theme_id,ImageUrl,Currency_Msige,Currency_ExchangeRate,Currency_id,Path,Site_id,TopAreaid,IsLazyLoad)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Code,@Sort,@Theme_id,@ImageUrl,@Currency_Msige,@Currency_ExchangeRate,@Currency_id,@Path,@Site_id,@TopAreaid,@IsLazyLoad)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Theme_id", model.Theme_id),
					new SqlParameter("@ImageUrl", model.ImageUrl),
					new SqlParameter("@Currency_Msige", model.Currency_Msige),
					new SqlParameter("@Currency_ExchangeRate", model.Currency_ExchangeRate),
					new SqlParameter("@Currency_id", model.Currency_id),
					new SqlParameter("@Path", model.Path),
					new SqlParameter("@Site_id", model.Site_id),
					new SqlParameter("@TopAreaid", model.TopAreaid),
					new SqlParameter("@IsLazyLoad", model.IsLazyLoad)};

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
		public void Update(Lebi_Language model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Language] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("Code= @Code,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Theme_id= @Theme_id,");
			strSql.Append("ImageUrl= @ImageUrl,");
			strSql.Append("Currency_Msige= @Currency_Msige,");
			strSql.Append("Currency_ExchangeRate= @Currency_ExchangeRate,");
			strSql.Append("Currency_id= @Currency_id,");
			strSql.Append("Path= @Path,");
			strSql.Append("Site_id= @Site_id,");
			strSql.Append("TopAreaid= @TopAreaid,");
			strSql.Append("IsLazyLoad= @IsLazyLoad");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Theme_id", SqlDbType.Int,4),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency_Msige", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency_ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@Currency_id", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.NVarChar,50),
					new SqlParameter("@Site_id", SqlDbType.Int,4),
					new SqlParameter("@TopAreaid", SqlDbType.Int,4),
					new SqlParameter("@IsLazyLoad", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Code;
			parameters[3].Value = model.Sort;
			parameters[4].Value = model.Theme_id;
			parameters[5].Value = model.ImageUrl;
			parameters[6].Value = model.Currency_Msige;
			parameters[7].Value = model.Currency_ExchangeRate;
			parameters[8].Value = model.Currency_id;
			parameters[9].Value = model.Path;
			parameters[10].Value = model.Site_id;
			parameters[11].Value = model.TopAreaid;
			parameters[12].Value = model.IsLazyLoad;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Language] ");
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
			strSql.Append("delete from [Lebi_Language] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Language] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Language GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Language] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Language model=new Lebi_Language();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Theme_id"].ToString()!="")
				{
					model.Theme_id=int.Parse(ds.Tables[0].Rows[0]["Theme_id"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				model.Currency_Msige=ds.Tables[0].Rows[0]["Currency_Msige"].ToString();
				if(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString()!="")
				{
					model.Currency_ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["Site_id"].ToString()!="")
				{
					model.Site_id=int.Parse(ds.Tables[0].Rows[0]["Site_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TopAreaid"].ToString()!="")
				{
					model.TopAreaid=int.Parse(ds.Tables[0].Rows[0]["TopAreaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsLazyLoad"].ToString()!="")
				{
					model.IsLazyLoad=int.Parse(ds.Tables[0].Rows[0]["IsLazyLoad"].ToString());
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
		public Lebi_Language GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Language] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Language model=new Lebi_Language();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Theme_id"].ToString()!="")
				{
					model.Theme_id=int.Parse(ds.Tables[0].Rows[0]["Theme_id"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				model.Currency_Msige=ds.Tables[0].Rows[0]["Currency_Msige"].ToString();
				if(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString()!="")
				{
					model.Currency_ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["Site_id"].ToString()!="")
				{
					model.Site_id=int.Parse(ds.Tables[0].Rows[0]["Site_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TopAreaid"].ToString()!="")
				{
					model.TopAreaid=int.Parse(ds.Tables[0].Rows[0]["TopAreaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsLazyLoad"].ToString()!="")
				{
					model.IsLazyLoad=int.Parse(ds.Tables[0].Rows[0]["IsLazyLoad"].ToString());
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
		public Lebi_Language GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Language] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Language model=new Lebi_Language();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Theme_id"].ToString()!="")
				{
					model.Theme_id=int.Parse(ds.Tables[0].Rows[0]["Theme_id"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				model.Currency_Msige=ds.Tables[0].Rows[0]["Currency_Msige"].ToString();
				if(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString()!="")
				{
					model.Currency_ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["Site_id"].ToString()!="")
				{
					model.Site_id=int.Parse(ds.Tables[0].Rows[0]["Site_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TopAreaid"].ToString()!="")
				{
					model.TopAreaid=int.Parse(ds.Tables[0].Rows[0]["TopAreaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsLazyLoad"].ToString()!="")
				{
					model.IsLazyLoad=int.Parse(ds.Tables[0].Rows[0]["IsLazyLoad"].ToString());
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
		public List<Lebi_Language> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Language]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Language> list = new List<Lebi_Language>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Language> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Language]";
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
			List<Lebi_Language> list = new List<Lebi_Language>();
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
		public List<Lebi_Language> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Language] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Language> list = new List<Lebi_Language>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Language> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Language]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Language> list = new List<Lebi_Language>();
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
		public Lebi_Language BindForm(Lebi_Language model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestString("Currency_Msige");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestString("Path");
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["TopAreaid"] != null)
				model.TopAreaid=Shop.Tools.RequestTool.RequestInt("TopAreaid",0);
			if (HttpContext.Current.Request["IsLazyLoad"] != null)
				model.IsLazyLoad=Shop.Tools.RequestTool.RequestInt("IsLazyLoad",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Language SafeBindForm(Lebi_Language model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestSafeString("Currency_Msige");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestSafeString("Path");
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["TopAreaid"] != null)
				model.TopAreaid=Shop.Tools.RequestTool.RequestInt("TopAreaid",0);
			if (HttpContext.Current.Request["IsLazyLoad"] != null)
				model.IsLazyLoad=Shop.Tools.RequestTool.RequestInt("IsLazyLoad",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Language ReaderBind(IDataReader dataReader)
		{
			Lebi_Language model=new Lebi_Language();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Theme_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Theme_id=(int)ojb;
			}
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			model.Currency_Msige=dataReader["Currency_Msige"].ToString();
			ojb = dataReader["Currency_ExchangeRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_ExchangeRate=(decimal)ojb;
			}
			ojb = dataReader["Currency_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_id=(int)ojb;
			}
			model.Path=dataReader["Path"].ToString();
			ojb = dataReader["Site_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Site_id=(int)ojb;
			}
			ojb = dataReader["TopAreaid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TopAreaid=(int)ojb;
			}
			ojb = dataReader["IsLazyLoad"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsLazyLoad=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Language : Lebi_Language_interface
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
				strSql.Append("select " + colName + " from [Lebi_Language]");
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
			strSql.Append("select  "+colName+" from [Lebi_Language]");
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
			strSql.Append("select count(*) from [Lebi_Language]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Language]");
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
			strSql.Append("select max(id) from [Lebi_Language]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Language]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Language model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Language](");
			strSql.Append("[Name],[Code],[Sort],[Theme_id],[ImageUrl],[Currency_Msige],[Currency_ExchangeRate],[Currency_id],[Path],[Site_id],[TopAreaid],[IsLazyLoad])");
			strSql.Append(" values (");
			strSql.Append("@Name,@Code,@Sort,@Theme_id,@ImageUrl,@Currency_Msige,@Currency_ExchangeRate,@Currency_id,@Path,@Site_id,@TopAreaid,@IsLazyLoad)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Theme_id", model.Theme_id),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@Currency_Msige", model.Currency_Msige),
					new OleDbParameter("@Currency_ExchangeRate", model.Currency_ExchangeRate),
					new OleDbParameter("@Currency_id", model.Currency_id),
					new OleDbParameter("@Path", model.Path),
					new OleDbParameter("@Site_id", model.Site_id),
					new OleDbParameter("@TopAreaid", model.TopAreaid),
					new OleDbParameter("@IsLazyLoad", model.IsLazyLoad)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Language model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Language] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Theme_id]=@Theme_id,");
			strSql.Append("[ImageUrl]=@ImageUrl,");
			strSql.Append("[Currency_Msige]=@Currency_Msige,");
			strSql.Append("[Currency_ExchangeRate]=@Currency_ExchangeRate,");
			strSql.Append("[Currency_id]=@Currency_id,");
			strSql.Append("[Path]=@Path,");
			strSql.Append("[Site_id]=@Site_id,");
			strSql.Append("[TopAreaid]=@TopAreaid,");
			strSql.Append("[IsLazyLoad]=@IsLazyLoad");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Theme_id", model.Theme_id),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@Currency_Msige", model.Currency_Msige),
					new OleDbParameter("@Currency_ExchangeRate", model.Currency_ExchangeRate),
					new OleDbParameter("@Currency_id", model.Currency_id),
					new OleDbParameter("@Path", model.Path),
					new OleDbParameter("@Site_id", model.Site_id),
					new OleDbParameter("@TopAreaid", model.TopAreaid),
					new OleDbParameter("@IsLazyLoad", model.IsLazyLoad)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Language] ");
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
			strSql.Append("delete from [Lebi_Language] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Language] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Language GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Language] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Language model;
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
		public Lebi_Language GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Language] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Language model;
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
		public Lebi_Language GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Language] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Language model;
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
		public List<Lebi_Language> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Language]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Language> list = new List<Lebi_Language>();
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
		public List<Lebi_Language> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Language]";
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
			List<Lebi_Language> list = new List<Lebi_Language>();
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
		public List<Lebi_Language> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Language] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Language> list = new List<Lebi_Language>();
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
		public List<Lebi_Language> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Language]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Language> list = new List<Lebi_Language>();
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
		public Lebi_Language BindForm(Lebi_Language model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestString("Currency_Msige");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestString("Path");
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["TopAreaid"] != null)
				model.TopAreaid=Shop.Tools.RequestTool.RequestInt("TopAreaid",0);
			if (HttpContext.Current.Request["IsLazyLoad"] != null)
				model.IsLazyLoad=Shop.Tools.RequestTool.RequestInt("IsLazyLoad",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Language SafeBindForm(Lebi_Language model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestSafeString("Currency_Msige");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestSafeString("Path");
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["TopAreaid"] != null)
				model.TopAreaid=Shop.Tools.RequestTool.RequestInt("TopAreaid",0);
			if (HttpContext.Current.Request["IsLazyLoad"] != null)
				model.IsLazyLoad=Shop.Tools.RequestTool.RequestInt("IsLazyLoad",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Language ReaderBind(IDataReader dataReader)
		{
			Lebi_Language model=new Lebi_Language();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Theme_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Theme_id=(int)ojb;
			}
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			model.Currency_Msige=dataReader["Currency_Msige"].ToString();
			ojb = dataReader["Currency_ExchangeRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_ExchangeRate=(decimal)ojb;
			}
			ojb = dataReader["Currency_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_id=(int)ojb;
			}
			model.Path=dataReader["Path"].ToString();
			ojb = dataReader["Site_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Site_id=(int)ojb;
			}
			ojb = dataReader["TopAreaid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TopAreaid=(int)ojb;
			}
			ojb = dataReader["IsLazyLoad"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsLazyLoad=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

