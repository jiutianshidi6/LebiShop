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

	public interface Lebi_Theme_Skin_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Theme_Skin model);
		void Update(Lebi_Theme_Skin model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Theme_Skin GetModel(int id);
		Lebi_Theme_Skin GetModel(string strWhere);
		Lebi_Theme_Skin GetModel(SQLPara para);
		List<Lebi_Theme_Skin> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Theme_Skin> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Theme_Skin> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Theme_Skin> GetList(SQLPara para);
		Lebi_Theme_Skin BindForm(Lebi_Theme_Skin model);
		Lebi_Theme_Skin SafeBindForm(Lebi_Theme_Skin model);
		Lebi_Theme_Skin ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Theme_Skin。
	/// </summary>
	public class D_Lebi_Theme_Skin
	{
		static Lebi_Theme_Skin_interface _Instance;
		public static Lebi_Theme_Skin_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Theme_Skin();
		            else
		                _Instance = new sqlserver_Lebi_Theme_Skin();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Theme_Skin()
		{}
		#region  成员方法
	class sqlserver_Lebi_Theme_Skin : Lebi_Theme_Skin_interface
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
				strSql.Append("select " + colName + " from [Lebi_Theme_Skin]");
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
			strSql.Append("select  "+colName+" from [Lebi_Theme_Skin]");
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
			strSql.Append("select count(1) from [Lebi_Theme_Skin]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Theme_Skin]");
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
			strSql.Append("select max(id) from [Lebi_Theme_Skin]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Theme_Skin]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Theme_Skin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Theme_Skin](");
			strSql.Append("Code,Name,IsPage,Path_Skin,PageName,PageParameter,StaticPageName,Time_Add,Time_Update,Theme_id,Sort,PageSize)");
			strSql.Append(" values (");
			strSql.Append("@Code,@Name,@IsPage,@Path_Skin,@PageName,@PageParameter,@StaticPageName,@Time_Add,@Time_Update,@Theme_id,@Sort,@PageSize)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@IsPage", model.IsPage),
					new SqlParameter("@Path_Skin", model.Path_Skin),
					new SqlParameter("@PageName", model.PageName),
					new SqlParameter("@PageParameter", model.PageParameter),
					new SqlParameter("@StaticPageName", model.StaticPageName),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Update", model.Time_Update),
					new SqlParameter("@Theme_id", model.Theme_id),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@PageSize", model.PageSize)};

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
		public void Update(Lebi_Theme_Skin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Theme_Skin] set ");
			strSql.Append("Code= @Code,");
			strSql.Append("Name= @Name,");
			strSql.Append("IsPage= @IsPage,");
			strSql.Append("Path_Skin= @Path_Skin,");
			strSql.Append("PageName= @PageName,");
			strSql.Append("PageParameter= @PageParameter,");
			strSql.Append("StaticPageName= @StaticPageName,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Update= @Time_Update,");
			strSql.Append("Theme_id= @Theme_id,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("PageSize= @PageSize");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@IsPage", SqlDbType.Int,4),
					new SqlParameter("@Path_Skin", SqlDbType.NVarChar,50),
					new SqlParameter("@PageName", SqlDbType.NVarChar,50),
					new SqlParameter("@PageParameter", SqlDbType.NVarChar,200),
					new SqlParameter("@StaticPageName", SqlDbType.NVarChar,200),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Update", SqlDbType.DateTime),
					new SqlParameter("@Theme_id", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@PageSize", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.IsPage;
			parameters[4].Value = model.Path_Skin;
			parameters[5].Value = model.PageName;
			parameters[6].Value = model.PageParameter;
			parameters[7].Value = model.StaticPageName;
			parameters[8].Value = model.Time_Add;
			parameters[9].Value = model.Time_Update;
			parameters[10].Value = model.Theme_id;
			parameters[11].Value = model.Sort;
			parameters[12].Value = model.PageSize;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme_Skin] ");
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
			strSql.Append("delete from [Lebi_Theme_Skin] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme_Skin] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Theme_Skin GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme_Skin] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Theme_Skin model=new Lebi_Theme_Skin();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["IsPage"].ToString()!="")
				{
					model.IsPage=int.Parse(ds.Tables[0].Rows[0]["IsPage"].ToString());
				}
				model.Path_Skin=ds.Tables[0].Rows[0]["Path_Skin"].ToString();
				model.PageName=ds.Tables[0].Rows[0]["PageName"].ToString();
				model.PageParameter=ds.Tables[0].Rows[0]["PageParameter"].ToString();
				model.StaticPageName=ds.Tables[0].Rows[0]["StaticPageName"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Theme_id"].ToString()!="")
				{
					model.Theme_id=int.Parse(ds.Tables[0].Rows[0]["Theme_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PageSize"].ToString()!="")
				{
					model.PageSize=int.Parse(ds.Tables[0].Rows[0]["PageSize"].ToString());
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
		public Lebi_Theme_Skin GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme_Skin] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Theme_Skin model=new Lebi_Theme_Skin();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["IsPage"].ToString()!="")
				{
					model.IsPage=int.Parse(ds.Tables[0].Rows[0]["IsPage"].ToString());
				}
				model.Path_Skin=ds.Tables[0].Rows[0]["Path_Skin"].ToString();
				model.PageName=ds.Tables[0].Rows[0]["PageName"].ToString();
				model.PageParameter=ds.Tables[0].Rows[0]["PageParameter"].ToString();
				model.StaticPageName=ds.Tables[0].Rows[0]["StaticPageName"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Theme_id"].ToString()!="")
				{
					model.Theme_id=int.Parse(ds.Tables[0].Rows[0]["Theme_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PageSize"].ToString()!="")
				{
					model.PageSize=int.Parse(ds.Tables[0].Rows[0]["PageSize"].ToString());
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
		public Lebi_Theme_Skin GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Theme_Skin] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Theme_Skin model=new Lebi_Theme_Skin();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["IsPage"].ToString()!="")
				{
					model.IsPage=int.Parse(ds.Tables[0].Rows[0]["IsPage"].ToString());
				}
				model.Path_Skin=ds.Tables[0].Rows[0]["Path_Skin"].ToString();
				model.PageName=ds.Tables[0].Rows[0]["PageName"].ToString();
				model.PageParameter=ds.Tables[0].Rows[0]["PageParameter"].ToString();
				model.StaticPageName=ds.Tables[0].Rows[0]["StaticPageName"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Theme_id"].ToString()!="")
				{
					model.Theme_id=int.Parse(ds.Tables[0].Rows[0]["Theme_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PageSize"].ToString()!="")
				{
					model.PageSize=int.Parse(ds.Tables[0].Rows[0]["PageSize"].ToString());
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
		public List<Lebi_Theme_Skin> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Theme_Skin]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Theme_Skin> list = new List<Lebi_Theme_Skin>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Theme_Skin> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Theme_Skin]";
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
			List<Lebi_Theme_Skin> list = new List<Lebi_Theme_Skin>();
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
		public List<Lebi_Theme_Skin> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Theme_Skin] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Theme_Skin> list = new List<Lebi_Theme_Skin>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Theme_Skin> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Theme_Skin]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Theme_Skin> list = new List<Lebi_Theme_Skin>();
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
		public Lebi_Theme_Skin BindForm(Lebi_Theme_Skin model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["IsPage"] != null)
				model.IsPage=Shop.Tools.RequestTool.RequestInt("IsPage",0);
			if (HttpContext.Current.Request["Path_Skin"] != null)
				model.Path_Skin=Shop.Tools.RequestTool.RequestString("Path_Skin");
			if (HttpContext.Current.Request["PageName"] != null)
				model.PageName=Shop.Tools.RequestTool.RequestString("PageName");
			if (HttpContext.Current.Request["PageParameter"] != null)
				model.PageParameter=Shop.Tools.RequestTool.RequestString("PageParameter");
			if (HttpContext.Current.Request["StaticPageName"] != null)
				model.StaticPageName=Shop.Tools.RequestTool.RequestString("StaticPageName");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["PageSize"] != null)
				model.PageSize=Shop.Tools.RequestTool.RequestInt("PageSize",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Theme_Skin SafeBindForm(Lebi_Theme_Skin model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["IsPage"] != null)
				model.IsPage=Shop.Tools.RequestTool.RequestInt("IsPage",0);
			if (HttpContext.Current.Request["Path_Skin"] != null)
				model.Path_Skin=Shop.Tools.RequestTool.RequestSafeString("Path_Skin");
			if (HttpContext.Current.Request["PageName"] != null)
				model.PageName=Shop.Tools.RequestTool.RequestSafeString("PageName");
			if (HttpContext.Current.Request["PageParameter"] != null)
				model.PageParameter=Shop.Tools.RequestTool.RequestSafeString("PageParameter");
			if (HttpContext.Current.Request["StaticPageName"] != null)
				model.StaticPageName=Shop.Tools.RequestTool.RequestSafeString("StaticPageName");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["PageSize"] != null)
				model.PageSize=Shop.Tools.RequestTool.RequestInt("PageSize",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Theme_Skin ReaderBind(IDataReader dataReader)
		{
			Lebi_Theme_Skin model=new Lebi_Theme_Skin();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Code=dataReader["Code"].ToString();
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["IsPage"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPage=(int)ojb;
			}
			model.Path_Skin=dataReader["Path_Skin"].ToString();
			model.PageName=dataReader["PageName"].ToString();
			model.PageParameter=dataReader["PageParameter"].ToString();
			model.StaticPageName=dataReader["StaticPageName"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Update=(DateTime)ojb;
			}
			ojb = dataReader["Theme_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Theme_id=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["PageSize"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PageSize=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Theme_Skin : Lebi_Theme_Skin_interface
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
				strSql.Append("select " + colName + " from [Lebi_Theme_Skin]");
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
			strSql.Append("select  "+colName+" from [Lebi_Theme_Skin]");
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
			strSql.Append("select count(*) from [Lebi_Theme_Skin]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Theme_Skin]");
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
			strSql.Append("select max(id) from [Lebi_Theme_Skin]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Theme_Skin]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Theme_Skin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Theme_Skin](");
			strSql.Append("[Code],[Name],[IsPage],[Path_Skin],[PageName],[PageParameter],[StaticPageName],[Time_Add],[Time_Update],[Theme_id],[Sort],[PageSize])");
			strSql.Append(" values (");
			strSql.Append("@Code,@Name,@IsPage,@Path_Skin,@PageName,@PageParameter,@StaticPageName,@Time_Add,@Time_Update,@Theme_id,@Sort,@PageSize)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@IsPage", model.IsPage),
					new OleDbParameter("@Path_Skin", model.Path_Skin),
					new OleDbParameter("@PageName", model.PageName),
					new OleDbParameter("@PageParameter", model.PageParameter),
					new OleDbParameter("@StaticPageName", model.StaticPageName),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Theme_id", model.Theme_id),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@PageSize", model.PageSize)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Theme_Skin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Theme_Skin] set ");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[IsPage]=@IsPage,");
			strSql.Append("[Path_Skin]=@Path_Skin,");
			strSql.Append("[PageName]=@PageName,");
			strSql.Append("[PageParameter]=@PageParameter,");
			strSql.Append("[StaticPageName]=@StaticPageName,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Update]=@Time_Update,");
			strSql.Append("[Theme_id]=@Theme_id,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[PageSize]=@PageSize");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@IsPage", model.IsPage),
					new OleDbParameter("@Path_Skin", model.Path_Skin),
					new OleDbParameter("@PageName", model.PageName),
					new OleDbParameter("@PageParameter", model.PageParameter),
					new OleDbParameter("@StaticPageName", model.StaticPageName),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Theme_id", model.Theme_id),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@PageSize", model.PageSize)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme_Skin] ");
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
			strSql.Append("delete from [Lebi_Theme_Skin] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme_Skin] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Theme_Skin GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme_Skin] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Theme_Skin model;
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
		public Lebi_Theme_Skin GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme_Skin] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Theme_Skin model;
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
		public Lebi_Theme_Skin GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Theme_Skin] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Theme_Skin model;
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
		public List<Lebi_Theme_Skin> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Theme_Skin]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Theme_Skin> list = new List<Lebi_Theme_Skin>();
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
		public List<Lebi_Theme_Skin> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Theme_Skin]";
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
			List<Lebi_Theme_Skin> list = new List<Lebi_Theme_Skin>();
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
		public List<Lebi_Theme_Skin> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Theme_Skin] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Theme_Skin> list = new List<Lebi_Theme_Skin>();
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
		public List<Lebi_Theme_Skin> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Theme_Skin]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Theme_Skin> list = new List<Lebi_Theme_Skin>();
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
		public Lebi_Theme_Skin BindForm(Lebi_Theme_Skin model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["IsPage"] != null)
				model.IsPage=Shop.Tools.RequestTool.RequestInt("IsPage",0);
			if (HttpContext.Current.Request["Path_Skin"] != null)
				model.Path_Skin=Shop.Tools.RequestTool.RequestString("Path_Skin");
			if (HttpContext.Current.Request["PageName"] != null)
				model.PageName=Shop.Tools.RequestTool.RequestString("PageName");
			if (HttpContext.Current.Request["PageParameter"] != null)
				model.PageParameter=Shop.Tools.RequestTool.RequestString("PageParameter");
			if (HttpContext.Current.Request["StaticPageName"] != null)
				model.StaticPageName=Shop.Tools.RequestTool.RequestString("StaticPageName");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["PageSize"] != null)
				model.PageSize=Shop.Tools.RequestTool.RequestInt("PageSize",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Theme_Skin SafeBindForm(Lebi_Theme_Skin model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["IsPage"] != null)
				model.IsPage=Shop.Tools.RequestTool.RequestInt("IsPage",0);
			if (HttpContext.Current.Request["Path_Skin"] != null)
				model.Path_Skin=Shop.Tools.RequestTool.RequestSafeString("Path_Skin");
			if (HttpContext.Current.Request["PageName"] != null)
				model.PageName=Shop.Tools.RequestTool.RequestSafeString("PageName");
			if (HttpContext.Current.Request["PageParameter"] != null)
				model.PageParameter=Shop.Tools.RequestTool.RequestSafeString("PageParameter");
			if (HttpContext.Current.Request["StaticPageName"] != null)
				model.StaticPageName=Shop.Tools.RequestTool.RequestSafeString("StaticPageName");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["PageSize"] != null)
				model.PageSize=Shop.Tools.RequestTool.RequestInt("PageSize",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Theme_Skin ReaderBind(IDataReader dataReader)
		{
			Lebi_Theme_Skin model=new Lebi_Theme_Skin();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Code=dataReader["Code"].ToString();
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["IsPage"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPage=(int)ojb;
			}
			model.Path_Skin=dataReader["Path_Skin"].ToString();
			model.PageName=dataReader["PageName"].ToString();
			model.PageParameter=dataReader["PageParameter"].ToString();
			model.StaticPageName=dataReader["StaticPageName"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Update=(DateTime)ojb;
			}
			ojb = dataReader["Theme_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Theme_id=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["PageSize"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PageSize=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

