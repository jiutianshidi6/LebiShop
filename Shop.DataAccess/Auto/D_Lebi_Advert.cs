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

	public interface Lebi_Advert_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Advert model);
		void Update(Lebi_Advert model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Advert GetModel(int id);
		Lebi_Advert GetModel(string strWhere);
		Lebi_Advert GetModel(SQLPara para);
		List<Lebi_Advert> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Advert> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Advert> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Advert> GetList(SQLPara para);
		Lebi_Advert BindForm(Lebi_Advert model);
		Lebi_Advert SafeBindForm(Lebi_Advert model);
		Lebi_Advert ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Advert。
	/// </summary>
	public class D_Lebi_Advert
	{
		static Lebi_Advert_interface _Instance;
		public static Lebi_Advert_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Advert();
		            else
		                _Instance = new sqlserver_Lebi_Advert();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Advert()
		{}
		#region  成员方法
	class sqlserver_Lebi_Advert : Lebi_Advert_interface
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
				strSql.Append("select " + colName + " from [Lebi_Advert]");
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
			strSql.Append("select  "+colName+" from [Lebi_Advert]");
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
			strSql.Append("select count(1) from [Lebi_Advert]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Advert]");
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
			strSql.Append("select max(id) from [Lebi_Advert]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Advert]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Advert model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Advert](");
			strSql.Append("Theme_id,Language_Codes,Language_ids,Theme_Advert_id,Theme_Advert_Code,Image,Width,Height,Time_Add,URL,Tatget,Sort,Title,ImageSmall,Description)");
			strSql.Append(" values (");
			strSql.Append("@Theme_id,@Language_Codes,@Language_ids,@Theme_Advert_id,@Theme_Advert_Code,@Image,@Width,@Height,@Time_Add,@URL,@Tatget,@Sort,@Title,@ImageSmall,@Description)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Theme_id", model.Theme_id),
					new SqlParameter("@Language_Codes", model.Language_Codes),
					new SqlParameter("@Language_ids", model.Language_ids),
					new SqlParameter("@Theme_Advert_id", model.Theme_Advert_id),
					new SqlParameter("@Theme_Advert_Code", model.Theme_Advert_Code),
					new SqlParameter("@Image", model.Image),
					new SqlParameter("@Width", model.Width),
					new SqlParameter("@Height", model.Height),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@URL", model.URL),
					new SqlParameter("@Tatget", model.Tatget),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Title", model.Title),
					new SqlParameter("@ImageSmall", model.ImageSmall),
					new SqlParameter("@Description", model.Description)};

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
		public void Update(Lebi_Advert model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Advert] set ");
			strSql.Append("Theme_id= @Theme_id,");
			strSql.Append("Language_Codes= @Language_Codes,");
			strSql.Append("Language_ids= @Language_ids,");
			strSql.Append("Theme_Advert_id= @Theme_Advert_id,");
			strSql.Append("Theme_Advert_Code= @Theme_Advert_Code,");
			strSql.Append("Image= @Image,");
			strSql.Append("Width= @Width,");
			strSql.Append("Height= @Height,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("URL= @URL,");
			strSql.Append("Tatget= @Tatget,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Title= @Title,");
			strSql.Append("ImageSmall= @ImageSmall,");
			strSql.Append("Description= @Description");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Theme_id", SqlDbType.Int,4),
					new SqlParameter("@Language_Codes", SqlDbType.NVarChar,200),
					new SqlParameter("@Language_ids", SqlDbType.NVarChar,100),
					new SqlParameter("@Theme_Advert_id", SqlDbType.Int,4),
					new SqlParameter("@Theme_Advert_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Image", SqlDbType.NVarChar,200),
					new SqlParameter("@Width", SqlDbType.Int,4),
					new SqlParameter("@Height", SqlDbType.Int,4),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@URL", SqlDbType.NVarChar,500),
					new SqlParameter("@Tatget", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageSmall", SqlDbType.NVarChar,100),
					new SqlParameter("@Description", SqlDbType.NText)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Theme_id;
			parameters[2].Value = model.Language_Codes;
			parameters[3].Value = model.Language_ids;
			parameters[4].Value = model.Theme_Advert_id;
			parameters[5].Value = model.Theme_Advert_Code;
			parameters[6].Value = model.Image;
			parameters[7].Value = model.Width;
			parameters[8].Value = model.Height;
			parameters[9].Value = model.Time_Add;
			parameters[10].Value = model.URL;
			parameters[11].Value = model.Tatget;
			parameters[12].Value = model.Sort;
			parameters[13].Value = model.Title;
			parameters[14].Value = model.ImageSmall;
			parameters[15].Value = model.Description;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Advert] ");
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
			strSql.Append("delete from [Lebi_Advert] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Advert] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Advert GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Advert] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Advert model=new Lebi_Advert();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Theme_id"].ToString()!="")
				{
					model.Theme_id=int.Parse(ds.Tables[0].Rows[0]["Theme_id"].ToString());
				}
				model.Language_Codes=ds.Tables[0].Rows[0]["Language_Codes"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Theme_Advert_id"].ToString()!="")
				{
					model.Theme_Advert_id=int.Parse(ds.Tables[0].Rows[0]["Theme_Advert_id"].ToString());
				}
				model.Theme_Advert_Code=ds.Tables[0].Rows[0]["Theme_Advert_Code"].ToString();
				model.Image=ds.Tables[0].Rows[0]["Image"].ToString();
				if(ds.Tables[0].Rows[0]["Width"].ToString()!="")
				{
					model.Width=int.Parse(ds.Tables[0].Rows[0]["Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Height"].ToString()!="")
				{
					model.Height=int.Parse(ds.Tables[0].Rows[0]["Height"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				model.Tatget=ds.Tables[0].Rows[0]["Tatget"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
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
		public Lebi_Advert GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Advert] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Advert model=new Lebi_Advert();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Theme_id"].ToString()!="")
				{
					model.Theme_id=int.Parse(ds.Tables[0].Rows[0]["Theme_id"].ToString());
				}
				model.Language_Codes=ds.Tables[0].Rows[0]["Language_Codes"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Theme_Advert_id"].ToString()!="")
				{
					model.Theme_Advert_id=int.Parse(ds.Tables[0].Rows[0]["Theme_Advert_id"].ToString());
				}
				model.Theme_Advert_Code=ds.Tables[0].Rows[0]["Theme_Advert_Code"].ToString();
				model.Image=ds.Tables[0].Rows[0]["Image"].ToString();
				if(ds.Tables[0].Rows[0]["Width"].ToString()!="")
				{
					model.Width=int.Parse(ds.Tables[0].Rows[0]["Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Height"].ToString()!="")
				{
					model.Height=int.Parse(ds.Tables[0].Rows[0]["Height"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				model.Tatget=ds.Tables[0].Rows[0]["Tatget"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
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
		public Lebi_Advert GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Advert] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Advert model=new Lebi_Advert();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Theme_id"].ToString()!="")
				{
					model.Theme_id=int.Parse(ds.Tables[0].Rows[0]["Theme_id"].ToString());
				}
				model.Language_Codes=ds.Tables[0].Rows[0]["Language_Codes"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Theme_Advert_id"].ToString()!="")
				{
					model.Theme_Advert_id=int.Parse(ds.Tables[0].Rows[0]["Theme_Advert_id"].ToString());
				}
				model.Theme_Advert_Code=ds.Tables[0].Rows[0]["Theme_Advert_Code"].ToString();
				model.Image=ds.Tables[0].Rows[0]["Image"].ToString();
				if(ds.Tables[0].Rows[0]["Width"].ToString()!="")
				{
					model.Width=int.Parse(ds.Tables[0].Rows[0]["Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Height"].ToString()!="")
				{
					model.Height=int.Parse(ds.Tables[0].Rows[0]["Height"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				model.Tatget=ds.Tables[0].Rows[0]["Tatget"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
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
		public List<Lebi_Advert> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Advert]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Advert> list = new List<Lebi_Advert>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Advert> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Advert]";
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
			List<Lebi_Advert> list = new List<Lebi_Advert>();
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
		public List<Lebi_Advert> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Advert] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Advert> list = new List<Lebi_Advert>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Advert> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Advert]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Advert> list = new List<Lebi_Advert>();
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
		public Lebi_Advert BindForm(Lebi_Advert model)
		{
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["Language_Codes"] != null)
				model.Language_Codes=Shop.Tools.RequestTool.RequestString("Language_Codes");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
			if (HttpContext.Current.Request["Theme_Advert_id"] != null)
				model.Theme_Advert_id=Shop.Tools.RequestTool.RequestInt("Theme_Advert_id",0);
			if (HttpContext.Current.Request["Theme_Advert_Code"] != null)
				model.Theme_Advert_Code=Shop.Tools.RequestTool.RequestString("Theme_Advert_Code");
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestString("Image");
			if (HttpContext.Current.Request["Width"] != null)
				model.Width=Shop.Tools.RequestTool.RequestInt("Width",0);
			if (HttpContext.Current.Request["Height"] != null)
				model.Height=Shop.Tools.RequestTool.RequestInt("Height",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestString("URL");
			if (HttpContext.Current.Request["Tatget"] != null)
				model.Tatget=Shop.Tools.RequestTool.RequestString("Tatget");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Advert SafeBindForm(Lebi_Advert model)
		{
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["Language_Codes"] != null)
				model.Language_Codes=Shop.Tools.RequestTool.RequestSafeString("Language_Codes");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
			if (HttpContext.Current.Request["Theme_Advert_id"] != null)
				model.Theme_Advert_id=Shop.Tools.RequestTool.RequestInt("Theme_Advert_id",0);
			if (HttpContext.Current.Request["Theme_Advert_Code"] != null)
				model.Theme_Advert_Code=Shop.Tools.RequestTool.RequestSafeString("Theme_Advert_Code");
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestSafeString("Image");
			if (HttpContext.Current.Request["Width"] != null)
				model.Width=Shop.Tools.RequestTool.RequestInt("Width",0);
			if (HttpContext.Current.Request["Height"] != null)
				model.Height=Shop.Tools.RequestTool.RequestInt("Height",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestSafeString("URL");
			if (HttpContext.Current.Request["Tatget"] != null)
				model.Tatget=Shop.Tools.RequestTool.RequestSafeString("Tatget");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Advert ReaderBind(IDataReader dataReader)
		{
			Lebi_Advert model=new Lebi_Advert();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Theme_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Theme_id=(int)ojb;
			}
			model.Language_Codes=dataReader["Language_Codes"].ToString();
			model.Language_ids=dataReader["Language_ids"].ToString();
			ojb = dataReader["Theme_Advert_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Theme_Advert_id=(int)ojb;
			}
			model.Theme_Advert_Code=dataReader["Theme_Advert_Code"].ToString();
			model.Image=dataReader["Image"].ToString();
			ojb = dataReader["Width"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Width=(int)ojb;
			}
			ojb = dataReader["Height"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Height=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			model.URL=dataReader["URL"].ToString();
			model.Tatget=dataReader["Tatget"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			model.Title=dataReader["Title"].ToString();
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.Description=dataReader["Description"].ToString();
			return model;
		}

	}
	class access_Lebi_Advert : Lebi_Advert_interface
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
				strSql.Append("select " + colName + " from [Lebi_Advert]");
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
			strSql.Append("select  "+colName+" from [Lebi_Advert]");
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
			strSql.Append("select count(*) from [Lebi_Advert]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Advert]");
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
			strSql.Append("select max(id) from [Lebi_Advert]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Advert]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Advert model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Advert](");
			strSql.Append("[Theme_id],[Language_Codes],[Language_ids],[Theme_Advert_id],[Theme_Advert_Code],[Image],[Width],[Height],[Time_Add],[URL],[Tatget],[Sort],[Title],[ImageSmall],[Description])");
			strSql.Append(" values (");
			strSql.Append("@Theme_id,@Language_Codes,@Language_ids,@Theme_Advert_id,@Theme_Advert_Code,@Image,@Width,@Height,@Time_Add,@URL,@Tatget,@Sort,@Title,@ImageSmall,@Description)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Theme_id", model.Theme_id),
					new OleDbParameter("@Language_Codes", model.Language_Codes),
					new OleDbParameter("@Language_ids", model.Language_ids),
					new OleDbParameter("@Theme_Advert_id", model.Theme_Advert_id),
					new OleDbParameter("@Theme_Advert_Code", model.Theme_Advert_Code),
					new OleDbParameter("@Image", model.Image),
					new OleDbParameter("@Width", model.Width),
					new OleDbParameter("@Height", model.Height),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@URL", model.URL),
					new OleDbParameter("@Tatget", model.Tatget),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@Description", model.Description)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Advert model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Advert] set ");
			strSql.Append("[Theme_id]=@Theme_id,");
			strSql.Append("[Language_Codes]=@Language_Codes,");
			strSql.Append("[Language_ids]=@Language_ids,");
			strSql.Append("[Theme_Advert_id]=@Theme_Advert_id,");
			strSql.Append("[Theme_Advert_Code]=@Theme_Advert_Code,");
			strSql.Append("[Image]=@Image,");
			strSql.Append("[Width]=@Width,");
			strSql.Append("[Height]=@Height,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[URL]=@URL,");
			strSql.Append("[Tatget]=@Tatget,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Title]=@Title,");
			strSql.Append("[ImageSmall]=@ImageSmall,");
			strSql.Append("[Description]=@Description");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Theme_id", model.Theme_id),
					new OleDbParameter("@Language_Codes", model.Language_Codes),
					new OleDbParameter("@Language_ids", model.Language_ids),
					new OleDbParameter("@Theme_Advert_id", model.Theme_Advert_id),
					new OleDbParameter("@Theme_Advert_Code", model.Theme_Advert_Code),
					new OleDbParameter("@Image", model.Image),
					new OleDbParameter("@Width", model.Width),
					new OleDbParameter("@Height", model.Height),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@URL", model.URL),
					new OleDbParameter("@Tatget", model.Tatget),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@Description", model.Description)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Advert] ");
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
			strSql.Append("delete from [Lebi_Advert] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Advert] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Advert GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Advert] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Advert model;
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
		public Lebi_Advert GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Advert] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Advert model;
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
		public Lebi_Advert GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Advert] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Advert model;
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
		public List<Lebi_Advert> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Advert]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Advert> list = new List<Lebi_Advert>();
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
		public List<Lebi_Advert> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Advert]";
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
			List<Lebi_Advert> list = new List<Lebi_Advert>();
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
		public List<Lebi_Advert> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Advert] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Advert> list = new List<Lebi_Advert>();
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
		public List<Lebi_Advert> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Advert]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Advert> list = new List<Lebi_Advert>();
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
		public Lebi_Advert BindForm(Lebi_Advert model)
		{
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["Language_Codes"] != null)
				model.Language_Codes=Shop.Tools.RequestTool.RequestString("Language_Codes");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
			if (HttpContext.Current.Request["Theme_Advert_id"] != null)
				model.Theme_Advert_id=Shop.Tools.RequestTool.RequestInt("Theme_Advert_id",0);
			if (HttpContext.Current.Request["Theme_Advert_Code"] != null)
				model.Theme_Advert_Code=Shop.Tools.RequestTool.RequestString("Theme_Advert_Code");
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestString("Image");
			if (HttpContext.Current.Request["Width"] != null)
				model.Width=Shop.Tools.RequestTool.RequestInt("Width",0);
			if (HttpContext.Current.Request["Height"] != null)
				model.Height=Shop.Tools.RequestTool.RequestInt("Height",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestString("URL");
			if (HttpContext.Current.Request["Tatget"] != null)
				model.Tatget=Shop.Tools.RequestTool.RequestString("Tatget");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Advert SafeBindForm(Lebi_Advert model)
		{
			if (HttpContext.Current.Request["Theme_id"] != null)
				model.Theme_id=Shop.Tools.RequestTool.RequestInt("Theme_id",0);
			if (HttpContext.Current.Request["Language_Codes"] != null)
				model.Language_Codes=Shop.Tools.RequestTool.RequestSafeString("Language_Codes");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
			if (HttpContext.Current.Request["Theme_Advert_id"] != null)
				model.Theme_Advert_id=Shop.Tools.RequestTool.RequestInt("Theme_Advert_id",0);
			if (HttpContext.Current.Request["Theme_Advert_Code"] != null)
				model.Theme_Advert_Code=Shop.Tools.RequestTool.RequestSafeString("Theme_Advert_Code");
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestSafeString("Image");
			if (HttpContext.Current.Request["Width"] != null)
				model.Width=Shop.Tools.RequestTool.RequestInt("Width",0);
			if (HttpContext.Current.Request["Height"] != null)
				model.Height=Shop.Tools.RequestTool.RequestInt("Height",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestSafeString("URL");
			if (HttpContext.Current.Request["Tatget"] != null)
				model.Tatget=Shop.Tools.RequestTool.RequestSafeString("Tatget");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Advert ReaderBind(IDataReader dataReader)
		{
			Lebi_Advert model=new Lebi_Advert();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Theme_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Theme_id=(int)ojb;
			}
			model.Language_Codes=dataReader["Language_Codes"].ToString();
			model.Language_ids=dataReader["Language_ids"].ToString();
			ojb = dataReader["Theme_Advert_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Theme_Advert_id=(int)ojb;
			}
			model.Theme_Advert_Code=dataReader["Theme_Advert_Code"].ToString();
			model.Image=dataReader["Image"].ToString();
			ojb = dataReader["Width"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Width=(int)ojb;
			}
			ojb = dataReader["Height"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Height=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			model.URL=dataReader["URL"].ToString();
			model.Tatget=dataReader["Tatget"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			model.Title=dataReader["Title"].ToString();
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.Description=dataReader["Description"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

