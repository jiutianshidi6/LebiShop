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

	public interface Lebi_Theme_Page_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Theme_Page model);
		void Update(Lebi_Theme_Page model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Theme_Page GetModel(int id);
		Lebi_Theme_Page GetModel(string strWhere);
		Lebi_Theme_Page GetModel(SQLPara para);
		List<Lebi_Theme_Page> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Theme_Page> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Theme_Page> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Theme_Page> GetList(SQLPara para);
		Lebi_Theme_Page BindForm(Lebi_Theme_Page model);
		Lebi_Theme_Page SafeBindForm(Lebi_Theme_Page model);
		Lebi_Theme_Page ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Theme_Page。
	/// </summary>
	public class D_Lebi_Theme_Page
	{
		static Lebi_Theme_Page_interface _Instance;
		public static Lebi_Theme_Page_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Theme_Page();
		            else
		                _Instance = new sqlserver_Lebi_Theme_Page();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Theme_Page()
		{}
		#region  成员方法
	class sqlserver_Lebi_Theme_Page : Lebi_Theme_Page_interface
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
				strSql.Append("select " + colName + " from [Lebi_Theme_Page]");
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
			strSql.Append("select  "+colName+" from [Lebi_Theme_Page]");
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
			strSql.Append("select count(1) from [Lebi_Theme_Page]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Theme_Page]");
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
			strSql.Append("select max(id) from [Lebi_Theme_Page]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Theme_Page]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Theme_Page model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Theme_Page](");
			strSql.Append("Name,Sort,Code,PageName,PageParameter,StaticPageName,StaticPath,Type_id_PublishType,SEO_Title,SEO_Keywords,SEO_Description,IsAllowHtml,IsCustom)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Sort,@Code,@PageName,@PageParameter,@StaticPageName,@StaticPath,@Type_id_PublishType,@SEO_Title,@SEO_Keywords,@SEO_Description,@IsAllowHtml,@IsCustom)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@PageName", model.PageName),
					new SqlParameter("@PageParameter", model.PageParameter),
					new SqlParameter("@StaticPageName", model.StaticPageName),
					new SqlParameter("@StaticPath", model.StaticPath),
					new SqlParameter("@Type_id_PublishType", model.Type_id_PublishType),
					new SqlParameter("@SEO_Title", model.SEO_Title),
					new SqlParameter("@SEO_Keywords", model.SEO_Keywords),
					new SqlParameter("@SEO_Description", model.SEO_Description),
					new SqlParameter("@IsAllowHtml", model.IsAllowHtml),
					new SqlParameter("@IsCustom", model.IsCustom)};

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
		public void Update(Lebi_Theme_Page model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Theme_Page] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Code= @Code,");
			strSql.Append("PageName= @PageName,");
			strSql.Append("PageParameter= @PageParameter,");
			strSql.Append("StaticPageName= @StaticPageName,");
			strSql.Append("StaticPath= @StaticPath,");
			strSql.Append("Type_id_PublishType= @Type_id_PublishType,");
			strSql.Append("SEO_Title= @SEO_Title,");
			strSql.Append("SEO_Keywords= @SEO_Keywords,");
			strSql.Append("SEO_Description= @SEO_Description,");
			strSql.Append("IsAllowHtml= @IsAllowHtml,");
			strSql.Append("IsCustom= @IsCustom");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,1000),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@PageName", SqlDbType.NVarChar,100),
					new SqlParameter("@PageParameter", SqlDbType.NVarChar,200),
					new SqlParameter("@StaticPageName", SqlDbType.NVarChar,100),
					new SqlParameter("@StaticPath", SqlDbType.NVarChar,100),
					new SqlParameter("@Type_id_PublishType", SqlDbType.Int,4),
					new SqlParameter("@SEO_Title", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Keywords", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@IsAllowHtml", SqlDbType.Int,4),
					new SqlParameter("@IsCustom", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Sort;
			parameters[3].Value = model.Code;
			parameters[4].Value = model.PageName;
			parameters[5].Value = model.PageParameter;
			parameters[6].Value = model.StaticPageName;
			parameters[7].Value = model.StaticPath;
			parameters[8].Value = model.Type_id_PublishType;
			parameters[9].Value = model.SEO_Title;
			parameters[10].Value = model.SEO_Keywords;
			parameters[11].Value = model.SEO_Description;
			parameters[12].Value = model.IsAllowHtml;
			parameters[13].Value = model.IsCustom;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme_Page] ");
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
			strSql.Append("delete from [Lebi_Theme_Page] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme_Page] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Theme_Page GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme_Page] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Theme_Page model=new Lebi_Theme_Page();
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
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.PageName=ds.Tables[0].Rows[0]["PageName"].ToString();
				model.PageParameter=ds.Tables[0].Rows[0]["PageParameter"].ToString();
				model.StaticPageName=ds.Tables[0].Rows[0]["StaticPageName"].ToString();
				model.StaticPath=ds.Tables[0].Rows[0]["StaticPath"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString()!="")
				{
					model.Type_id_PublishType=int.Parse(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsAllowHtml"].ToString()!="")
				{
					model.IsAllowHtml=int.Parse(ds.Tables[0].Rows[0]["IsAllowHtml"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCustom"].ToString()!="")
				{
					model.IsCustom=int.Parse(ds.Tables[0].Rows[0]["IsCustom"].ToString());
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
		public Lebi_Theme_Page GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme_Page] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Theme_Page model=new Lebi_Theme_Page();
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
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.PageName=ds.Tables[0].Rows[0]["PageName"].ToString();
				model.PageParameter=ds.Tables[0].Rows[0]["PageParameter"].ToString();
				model.StaticPageName=ds.Tables[0].Rows[0]["StaticPageName"].ToString();
				model.StaticPath=ds.Tables[0].Rows[0]["StaticPath"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString()!="")
				{
					model.Type_id_PublishType=int.Parse(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsAllowHtml"].ToString()!="")
				{
					model.IsAllowHtml=int.Parse(ds.Tables[0].Rows[0]["IsAllowHtml"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCustom"].ToString()!="")
				{
					model.IsCustom=int.Parse(ds.Tables[0].Rows[0]["IsCustom"].ToString());
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
		public Lebi_Theme_Page GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Theme_Page] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Theme_Page model=new Lebi_Theme_Page();
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
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.PageName=ds.Tables[0].Rows[0]["PageName"].ToString();
				model.PageParameter=ds.Tables[0].Rows[0]["PageParameter"].ToString();
				model.StaticPageName=ds.Tables[0].Rows[0]["StaticPageName"].ToString();
				model.StaticPath=ds.Tables[0].Rows[0]["StaticPath"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString()!="")
				{
					model.Type_id_PublishType=int.Parse(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsAllowHtml"].ToString()!="")
				{
					model.IsAllowHtml=int.Parse(ds.Tables[0].Rows[0]["IsAllowHtml"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCustom"].ToString()!="")
				{
					model.IsCustom=int.Parse(ds.Tables[0].Rows[0]["IsCustom"].ToString());
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
		public List<Lebi_Theme_Page> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Theme_Page]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Theme_Page> list = new List<Lebi_Theme_Page>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Theme_Page> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Theme_Page]";
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
			List<Lebi_Theme_Page> list = new List<Lebi_Theme_Page>();
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
		public List<Lebi_Theme_Page> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Theme_Page] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Theme_Page> list = new List<Lebi_Theme_Page>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Theme_Page> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Theme_Page]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Theme_Page> list = new List<Lebi_Theme_Page>();
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
		public Lebi_Theme_Page BindForm(Lebi_Theme_Page model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["PageName"] != null)
				model.PageName=Shop.Tools.RequestTool.RequestString("PageName");
			if (HttpContext.Current.Request["PageParameter"] != null)
				model.PageParameter=Shop.Tools.RequestTool.RequestString("PageParameter");
			if (HttpContext.Current.Request["StaticPageName"] != null)
				model.StaticPageName=Shop.Tools.RequestTool.RequestString("StaticPageName");
			if (HttpContext.Current.Request["StaticPath"] != null)
				model.StaticPath=Shop.Tools.RequestTool.RequestString("StaticPath");
			if (HttpContext.Current.Request["Type_id_PublishType"] != null)
				model.Type_id_PublishType=Shop.Tools.RequestTool.RequestInt("Type_id_PublishType",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["IsAllowHtml"] != null)
				model.IsAllowHtml=Shop.Tools.RequestTool.RequestInt("IsAllowHtml",0);
			if (HttpContext.Current.Request["IsCustom"] != null)
				model.IsCustom=Shop.Tools.RequestTool.RequestInt("IsCustom",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Theme_Page SafeBindForm(Lebi_Theme_Page model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["PageName"] != null)
				model.PageName=Shop.Tools.RequestTool.RequestSafeString("PageName");
			if (HttpContext.Current.Request["PageParameter"] != null)
				model.PageParameter=Shop.Tools.RequestTool.RequestSafeString("PageParameter");
			if (HttpContext.Current.Request["StaticPageName"] != null)
				model.StaticPageName=Shop.Tools.RequestTool.RequestSafeString("StaticPageName");
			if (HttpContext.Current.Request["StaticPath"] != null)
				model.StaticPath=Shop.Tools.RequestTool.RequestSafeString("StaticPath");
			if (HttpContext.Current.Request["Type_id_PublishType"] != null)
				model.Type_id_PublishType=Shop.Tools.RequestTool.RequestInt("Type_id_PublishType",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["IsAllowHtml"] != null)
				model.IsAllowHtml=Shop.Tools.RequestTool.RequestInt("IsAllowHtml",0);
			if (HttpContext.Current.Request["IsCustom"] != null)
				model.IsCustom=Shop.Tools.RequestTool.RequestInt("IsCustom",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Theme_Page ReaderBind(IDataReader dataReader)
		{
			Lebi_Theme_Page model=new Lebi_Theme_Page();
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
			model.Code=dataReader["Code"].ToString();
			model.PageName=dataReader["PageName"].ToString();
			model.PageParameter=dataReader["PageParameter"].ToString();
			model.StaticPageName=dataReader["StaticPageName"].ToString();
			model.StaticPath=dataReader["StaticPath"].ToString();
			ojb = dataReader["Type_id_PublishType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_PublishType=(int)ojb;
			}
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			ojb = dataReader["IsAllowHtml"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsAllowHtml=(int)ojb;
			}
			ojb = dataReader["IsCustom"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCustom=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Theme_Page : Lebi_Theme_Page_interface
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
				strSql.Append("select " + colName + " from [Lebi_Theme_Page]");
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
			strSql.Append("select  "+colName+" from [Lebi_Theme_Page]");
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
			strSql.Append("select count(*) from [Lebi_Theme_Page]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Theme_Page]");
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
			strSql.Append("select max(id) from [Lebi_Theme_Page]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Theme_Page]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Theme_Page model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Theme_Page](");
			strSql.Append("[Name],[Sort],[Code],[PageName],[PageParameter],[StaticPageName],[StaticPath],[Type_id_PublishType],[SEO_Title],[SEO_Keywords],[SEO_Description],[IsAllowHtml],[IsCustom])");
			strSql.Append(" values (");
			strSql.Append("@Name,@Sort,@Code,@PageName,@PageParameter,@StaticPageName,@StaticPath,@Type_id_PublishType,@SEO_Title,@SEO_Keywords,@SEO_Description,@IsAllowHtml,@IsCustom)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@PageName", model.PageName),
					new OleDbParameter("@PageParameter", model.PageParameter),
					new OleDbParameter("@StaticPageName", model.StaticPageName),
					new OleDbParameter("@StaticPath", model.StaticPath),
					new OleDbParameter("@Type_id_PublishType", model.Type_id_PublishType),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@IsAllowHtml", model.IsAllowHtml),
					new OleDbParameter("@IsCustom", model.IsCustom)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Theme_Page model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Theme_Page] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[PageName]=@PageName,");
			strSql.Append("[PageParameter]=@PageParameter,");
			strSql.Append("[StaticPageName]=@StaticPageName,");
			strSql.Append("[StaticPath]=@StaticPath,");
			strSql.Append("[Type_id_PublishType]=@Type_id_PublishType,");
			strSql.Append("[SEO_Title]=@SEO_Title,");
			strSql.Append("[SEO_Keywords]=@SEO_Keywords,");
			strSql.Append("[SEO_Description]=@SEO_Description,");
			strSql.Append("[IsAllowHtml]=@IsAllowHtml,");
			strSql.Append("[IsCustom]=@IsCustom");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@PageName", model.PageName),
					new OleDbParameter("@PageParameter", model.PageParameter),
					new OleDbParameter("@StaticPageName", model.StaticPageName),
					new OleDbParameter("@StaticPath", model.StaticPath),
					new OleDbParameter("@Type_id_PublishType", model.Type_id_PublishType),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@IsAllowHtml", model.IsAllowHtml),
					new OleDbParameter("@IsCustom", model.IsCustom)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme_Page] ");
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
			strSql.Append("delete from [Lebi_Theme_Page] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme_Page] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Theme_Page GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme_Page] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Theme_Page model;
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
		public Lebi_Theme_Page GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme_Page] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Theme_Page model;
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
		public Lebi_Theme_Page GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Theme_Page] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Theme_Page model;
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
		public List<Lebi_Theme_Page> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Theme_Page]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Theme_Page> list = new List<Lebi_Theme_Page>();
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
		public List<Lebi_Theme_Page> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Theme_Page]";
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
			List<Lebi_Theme_Page> list = new List<Lebi_Theme_Page>();
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
		public List<Lebi_Theme_Page> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Theme_Page] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Theme_Page> list = new List<Lebi_Theme_Page>();
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
		public List<Lebi_Theme_Page> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Theme_Page]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Theme_Page> list = new List<Lebi_Theme_Page>();
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
		public Lebi_Theme_Page BindForm(Lebi_Theme_Page model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["PageName"] != null)
				model.PageName=Shop.Tools.RequestTool.RequestString("PageName");
			if (HttpContext.Current.Request["PageParameter"] != null)
				model.PageParameter=Shop.Tools.RequestTool.RequestString("PageParameter");
			if (HttpContext.Current.Request["StaticPageName"] != null)
				model.StaticPageName=Shop.Tools.RequestTool.RequestString("StaticPageName");
			if (HttpContext.Current.Request["StaticPath"] != null)
				model.StaticPath=Shop.Tools.RequestTool.RequestString("StaticPath");
			if (HttpContext.Current.Request["Type_id_PublishType"] != null)
				model.Type_id_PublishType=Shop.Tools.RequestTool.RequestInt("Type_id_PublishType",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["IsAllowHtml"] != null)
				model.IsAllowHtml=Shop.Tools.RequestTool.RequestInt("IsAllowHtml",0);
			if (HttpContext.Current.Request["IsCustom"] != null)
				model.IsCustom=Shop.Tools.RequestTool.RequestInt("IsCustom",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Theme_Page SafeBindForm(Lebi_Theme_Page model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["PageName"] != null)
				model.PageName=Shop.Tools.RequestTool.RequestSafeString("PageName");
			if (HttpContext.Current.Request["PageParameter"] != null)
				model.PageParameter=Shop.Tools.RequestTool.RequestSafeString("PageParameter");
			if (HttpContext.Current.Request["StaticPageName"] != null)
				model.StaticPageName=Shop.Tools.RequestTool.RequestSafeString("StaticPageName");
			if (HttpContext.Current.Request["StaticPath"] != null)
				model.StaticPath=Shop.Tools.RequestTool.RequestSafeString("StaticPath");
			if (HttpContext.Current.Request["Type_id_PublishType"] != null)
				model.Type_id_PublishType=Shop.Tools.RequestTool.RequestInt("Type_id_PublishType",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["IsAllowHtml"] != null)
				model.IsAllowHtml=Shop.Tools.RequestTool.RequestInt("IsAllowHtml",0);
			if (HttpContext.Current.Request["IsCustom"] != null)
				model.IsCustom=Shop.Tools.RequestTool.RequestInt("IsCustom",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Theme_Page ReaderBind(IDataReader dataReader)
		{
			Lebi_Theme_Page model=new Lebi_Theme_Page();
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
			model.Code=dataReader["Code"].ToString();
			model.PageName=dataReader["PageName"].ToString();
			model.PageParameter=dataReader["PageParameter"].ToString();
			model.StaticPageName=dataReader["StaticPageName"].ToString();
			model.StaticPath=dataReader["StaticPath"].ToString();
			ojb = dataReader["Type_id_PublishType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_PublishType=(int)ojb;
			}
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			ojb = dataReader["IsAllowHtml"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsAllowHtml=(int)ojb;
			}
			ojb = dataReader["IsCustom"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCustom=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

