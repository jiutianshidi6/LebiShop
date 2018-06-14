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

	public interface Lebi_Pro_Type_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Pro_Type model);
		void Update(Lebi_Pro_Type model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Pro_Type GetModel(int id);
		Lebi_Pro_Type GetModel(string strWhere);
		Lebi_Pro_Type GetModel(SQLPara para);
		List<Lebi_Pro_Type> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Pro_Type> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Pro_Type> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Pro_Type> GetList(SQLPara para);
		Lebi_Pro_Type BindForm(Lebi_Pro_Type model);
		Lebi_Pro_Type SafeBindForm(Lebi_Pro_Type model);
		Lebi_Pro_Type ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Pro_Type。
	/// </summary>
	public class D_Lebi_Pro_Type
	{
		static Lebi_Pro_Type_interface _Instance;
		public static Lebi_Pro_Type_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Pro_Type();
		            else
		                _Instance = new sqlserver_Lebi_Pro_Type();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Pro_Type()
		{}
		#region  成员方法
	class sqlserver_Lebi_Pro_Type : Lebi_Pro_Type_interface
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
				strSql.Append("select " + colName + " from [Lebi_Pro_Type]");
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
			strSql.Append("select  "+colName+" from [Lebi_Pro_Type]");
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
			strSql.Append("select count(1) from [Lebi_Pro_Type]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Pro_Type]");
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
			strSql.Append("select max(id) from [Lebi_Pro_Type]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Pro_Type]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Pro_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Pro_Type](");
			strSql.Append("Name,Parentid,Path,IsIndexShow,Sort,Level,SEO_Title,SEO_Keywords,SEO_Description,IsShow,ProPerty132,ProPerty131,ProPerty133,ImageUrl,ImageSmall,taobaoid,Url,Site_ids,ProPerty134,IsUrlrewrite,IsDel)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Parentid,@Path,@IsIndexShow,@Sort,@Level,@SEO_Title,@SEO_Keywords,@SEO_Description,@IsShow,@ProPerty132,@ProPerty131,@ProPerty133,@ImageUrl,@ImageSmall,@taobaoid,@Url,@Site_ids,@ProPerty134,@IsUrlrewrite,@IsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Parentid", model.Parentid),
					new SqlParameter("@Path", model.Path),
					new SqlParameter("@IsIndexShow", model.IsIndexShow),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Level", model.Level),
					new SqlParameter("@SEO_Title", model.SEO_Title),
					new SqlParameter("@SEO_Keywords", model.SEO_Keywords),
					new SqlParameter("@SEO_Description", model.SEO_Description),
					new SqlParameter("@IsShow", model.IsShow),
					new SqlParameter("@ProPerty132", model.ProPerty132),
					new SqlParameter("@ProPerty131", model.ProPerty131),
					new SqlParameter("@ProPerty133", model.ProPerty133),
					new SqlParameter("@ImageUrl", model.ImageUrl),
					new SqlParameter("@ImageSmall", model.ImageSmall),
					new SqlParameter("@taobaoid", model.taobaoid),
					new SqlParameter("@Url", model.Url),
					new SqlParameter("@Site_ids", model.Site_ids),
					new SqlParameter("@ProPerty134", model.ProPerty134),
					new SqlParameter("@IsUrlrewrite", model.IsUrlrewrite),
					new SqlParameter("@IsDel", model.IsDel)};

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
		public void Update(Lebi_Pro_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Pro_Type] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("Parentid= @Parentid,");
			strSql.Append("Path= @Path,");
			strSql.Append("IsIndexShow= @IsIndexShow,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Level= @Level,");
			strSql.Append("SEO_Title= @SEO_Title,");
			strSql.Append("SEO_Keywords= @SEO_Keywords,");
			strSql.Append("SEO_Description= @SEO_Description,");
			strSql.Append("IsShow= @IsShow,");
			strSql.Append("ProPerty132= @ProPerty132,");
			strSql.Append("ProPerty131= @ProPerty131,");
			strSql.Append("ProPerty133= @ProPerty133,");
			strSql.Append("ImageUrl= @ImageUrl,");
			strSql.Append("ImageSmall= @ImageSmall,");
			strSql.Append("taobaoid= @taobaoid,");
			strSql.Append("Url= @Url,");
			strSql.Append("Site_ids= @Site_ids,");
			strSql.Append("ProPerty134= @ProPerty134,");
			strSql.Append("IsUrlrewrite= @IsUrlrewrite,");
			strSql.Append("IsDel= @IsDel");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,1000),
					new SqlParameter("@Parentid", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.NVarChar,200),
					new SqlParameter("@IsIndexShow", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@SEO_Title", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Keywords", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@ProPerty132", SqlDbType.NVarChar,2000),
					new SqlParameter("@ProPerty131", SqlDbType.NVarChar,2000),
					new SqlParameter("@ProPerty133", SqlDbType.NVarChar,2000),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@ImageSmall", SqlDbType.NVarChar,100),
					new SqlParameter("@taobaoid", SqlDbType.NVarChar,50),
					new SqlParameter("@Url", SqlDbType.NVarChar,2000),
					new SqlParameter("@Site_ids", SqlDbType.NVarChar,200),
					new SqlParameter("@ProPerty134", SqlDbType.NVarChar,2000),
					new SqlParameter("@IsUrlrewrite", SqlDbType.NVarChar,500),
					new SqlParameter("@IsDel", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Parentid;
			parameters[3].Value = model.Path;
			parameters[4].Value = model.IsIndexShow;
			parameters[5].Value = model.Sort;
			parameters[6].Value = model.Level;
			parameters[7].Value = model.SEO_Title;
			parameters[8].Value = model.SEO_Keywords;
			parameters[9].Value = model.SEO_Description;
			parameters[10].Value = model.IsShow;
			parameters[11].Value = model.ProPerty132;
			parameters[12].Value = model.ProPerty131;
			parameters[13].Value = model.ProPerty133;
			parameters[14].Value = model.ImageUrl;
			parameters[15].Value = model.ImageSmall;
			parameters[16].Value = model.taobaoid;
			parameters[17].Value = model.Url;
			parameters[18].Value = model.Site_ids;
			parameters[19].Value = model.ProPerty134;
			parameters[20].Value = model.IsUrlrewrite;
			parameters[21].Value = model.IsDel;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Pro_Type] ");
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
			strSql.Append("delete from [Lebi_Pro_Type] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Pro_Type] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Pro_Type GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Pro_Type] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Pro_Type model=new Lebi_Pro_Type();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["IsIndexShow"].ToString()!="")
				{
					model.IsIndexShow=int.Parse(ds.Tables[0].Rows[0]["IsIndexShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Level"].ToString()!="")
				{
					model.Level=int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				model.ProPerty132=ds.Tables[0].Rows[0]["ProPerty132"].ToString();
				model.ProPerty131=ds.Tables[0].Rows[0]["ProPerty131"].ToString();
				model.ProPerty133=ds.Tables[0].Rows[0]["ProPerty133"].ToString();
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.taobaoid=ds.Tables[0].Rows[0]["taobaoid"].ToString();
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				model.Site_ids=ds.Tables[0].Rows[0]["Site_ids"].ToString();
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				model.IsUrlrewrite=ds.Tables[0].Rows[0]["IsUrlrewrite"].ToString();
				if(ds.Tables[0].Rows[0]["IsDel"].ToString()!="")
				{
					model.IsDel=int.Parse(ds.Tables[0].Rows[0]["IsDel"].ToString());
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
		public Lebi_Pro_Type GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Pro_Type] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Pro_Type model=new Lebi_Pro_Type();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["IsIndexShow"].ToString()!="")
				{
					model.IsIndexShow=int.Parse(ds.Tables[0].Rows[0]["IsIndexShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Level"].ToString()!="")
				{
					model.Level=int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				model.ProPerty132=ds.Tables[0].Rows[0]["ProPerty132"].ToString();
				model.ProPerty131=ds.Tables[0].Rows[0]["ProPerty131"].ToString();
				model.ProPerty133=ds.Tables[0].Rows[0]["ProPerty133"].ToString();
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.taobaoid=ds.Tables[0].Rows[0]["taobaoid"].ToString();
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				model.Site_ids=ds.Tables[0].Rows[0]["Site_ids"].ToString();
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				model.IsUrlrewrite=ds.Tables[0].Rows[0]["IsUrlrewrite"].ToString();
				if(ds.Tables[0].Rows[0]["IsDel"].ToString()!="")
				{
					model.IsDel=int.Parse(ds.Tables[0].Rows[0]["IsDel"].ToString());
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
		public Lebi_Pro_Type GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Pro_Type] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Pro_Type model=new Lebi_Pro_Type();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["IsIndexShow"].ToString()!="")
				{
					model.IsIndexShow=int.Parse(ds.Tables[0].Rows[0]["IsIndexShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Level"].ToString()!="")
				{
					model.Level=int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				model.ProPerty132=ds.Tables[0].Rows[0]["ProPerty132"].ToString();
				model.ProPerty131=ds.Tables[0].Rows[0]["ProPerty131"].ToString();
				model.ProPerty133=ds.Tables[0].Rows[0]["ProPerty133"].ToString();
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.taobaoid=ds.Tables[0].Rows[0]["taobaoid"].ToString();
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				model.Site_ids=ds.Tables[0].Rows[0]["Site_ids"].ToString();
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				model.IsUrlrewrite=ds.Tables[0].Rows[0]["IsUrlrewrite"].ToString();
				if(ds.Tables[0].Rows[0]["IsDel"].ToString()!="")
				{
					model.IsDel=int.Parse(ds.Tables[0].Rows[0]["IsDel"].ToString());
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
		public List<Lebi_Pro_Type> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Pro_Type]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Pro_Type> list = new List<Lebi_Pro_Type>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Pro_Type> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Pro_Type]";
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
			List<Lebi_Pro_Type> list = new List<Lebi_Pro_Type>();
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
		public List<Lebi_Pro_Type> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Pro_Type] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Pro_Type> list = new List<Lebi_Pro_Type>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Pro_Type> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Pro_Type]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Pro_Type> list = new List<Lebi_Pro_Type>();
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
		public Lebi_Pro_Type BindForm(Lebi_Pro_Type model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestString("Path");
			if (HttpContext.Current.Request["IsIndexShow"] != null)
				model.IsIndexShow=Shop.Tools.RequestTool.RequestInt("IsIndexShow",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Level"] != null)
				model.Level=Shop.Tools.RequestTool.RequestInt("Level",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["ProPerty132"] != null)
				model.ProPerty132=Shop.Tools.RequestTool.RequestString("ProPerty132");
			if (HttpContext.Current.Request["ProPerty131"] != null)
				model.ProPerty131=Shop.Tools.RequestTool.RequestString("ProPerty131");
			if (HttpContext.Current.Request["ProPerty133"] != null)
				model.ProPerty133=Shop.Tools.RequestTool.RequestString("ProPerty133");
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestString("taobaoid");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestString("Url");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestString("Site_ids");
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestString("ProPerty134");
			if (HttpContext.Current.Request["IsUrlrewrite"] != null)
				model.IsUrlrewrite=Shop.Tools.RequestTool.RequestString("IsUrlrewrite");
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Pro_Type SafeBindForm(Lebi_Pro_Type model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestSafeString("Path");
			if (HttpContext.Current.Request["IsIndexShow"] != null)
				model.IsIndexShow=Shop.Tools.RequestTool.RequestInt("IsIndexShow",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Level"] != null)
				model.Level=Shop.Tools.RequestTool.RequestInt("Level",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["ProPerty132"] != null)
				model.ProPerty132=Shop.Tools.RequestTool.RequestSafeString("ProPerty132");
			if (HttpContext.Current.Request["ProPerty131"] != null)
				model.ProPerty131=Shop.Tools.RequestTool.RequestSafeString("ProPerty131");
			if (HttpContext.Current.Request["ProPerty133"] != null)
				model.ProPerty133=Shop.Tools.RequestTool.RequestSafeString("ProPerty133");
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestSafeString("taobaoid");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestSafeString("Url");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestSafeString("Site_ids");
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestSafeString("ProPerty134");
			if (HttpContext.Current.Request["IsUrlrewrite"] != null)
				model.IsUrlrewrite=Shop.Tools.RequestTool.RequestSafeString("IsUrlrewrite");
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Pro_Type ReaderBind(IDataReader dataReader)
		{
			Lebi_Pro_Type model=new Lebi_Pro_Type();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Parentid=(int)ojb;
			}
			model.Path=dataReader["Path"].ToString();
			ojb = dataReader["IsIndexShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsIndexShow=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Level"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Level=(int)ojb;
			}
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(int)ojb;
			}
			model.ProPerty132=dataReader["ProPerty132"].ToString();
			model.ProPerty131=dataReader["ProPerty131"].ToString();
			model.ProPerty133=dataReader["ProPerty133"].ToString();
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.taobaoid=dataReader["taobaoid"].ToString();
			model.Url=dataReader["Url"].ToString();
			model.Site_ids=dataReader["Site_ids"].ToString();
			model.ProPerty134=dataReader["ProPerty134"].ToString();
			model.IsUrlrewrite=dataReader["IsUrlrewrite"].ToString();
			ojb = dataReader["IsDel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDel=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Pro_Type : Lebi_Pro_Type_interface
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
				strSql.Append("select " + colName + " from [Lebi_Pro_Type]");
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
			strSql.Append("select  "+colName+" from [Lebi_Pro_Type]");
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
			strSql.Append("select count(*) from [Lebi_Pro_Type]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Pro_Type]");
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
			strSql.Append("select max(id) from [Lebi_Pro_Type]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Pro_Type]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Pro_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Pro_Type](");
			strSql.Append("[Name],[Parentid],[Path],[IsIndexShow],[Sort],[Level],[SEO_Title],[SEO_Keywords],[SEO_Description],[IsShow],[ProPerty132],[ProPerty131],[ProPerty133],[ImageUrl],[ImageSmall],[taobaoid],[Url],[Site_ids],[ProPerty134],[IsUrlrewrite],[IsDel])");
			strSql.Append(" values (");
			strSql.Append("@Name,@Parentid,@Path,@IsIndexShow,@Sort,@Level,@SEO_Title,@SEO_Keywords,@SEO_Description,@IsShow,@ProPerty132,@ProPerty131,@ProPerty133,@ImageUrl,@ImageSmall,@taobaoid,@Url,@Site_ids,@ProPerty134,@IsUrlrewrite,@IsDel)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Parentid", model.Parentid),
					new OleDbParameter("@Path", model.Path),
					new OleDbParameter("@IsIndexShow", model.IsIndexShow),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Level", model.Level),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@IsShow", model.IsShow),
					new OleDbParameter("@ProPerty132", model.ProPerty132),
					new OleDbParameter("@ProPerty131", model.ProPerty131),
					new OleDbParameter("@ProPerty133", model.ProPerty133),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@taobaoid", model.taobaoid),
					new OleDbParameter("@Url", model.Url),
					new OleDbParameter("@Site_ids", model.Site_ids),
					new OleDbParameter("@ProPerty134", model.ProPerty134),
					new OleDbParameter("@IsUrlrewrite", model.IsUrlrewrite),
					new OleDbParameter("@IsDel", model.IsDel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Pro_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Pro_Type] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Parentid]=@Parentid,");
			strSql.Append("[Path]=@Path,");
			strSql.Append("[IsIndexShow]=@IsIndexShow,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Level]=@Level,");
			strSql.Append("[SEO_Title]=@SEO_Title,");
			strSql.Append("[SEO_Keywords]=@SEO_Keywords,");
			strSql.Append("[SEO_Description]=@SEO_Description,");
			strSql.Append("[IsShow]=@IsShow,");
			strSql.Append("[ProPerty132]=@ProPerty132,");
			strSql.Append("[ProPerty131]=@ProPerty131,");
			strSql.Append("[ProPerty133]=@ProPerty133,");
			strSql.Append("[ImageUrl]=@ImageUrl,");
			strSql.Append("[ImageSmall]=@ImageSmall,");
			strSql.Append("[taobaoid]=@taobaoid,");
			strSql.Append("[Url]=@Url,");
			strSql.Append("[Site_ids]=@Site_ids,");
			strSql.Append("[ProPerty134]=@ProPerty134,");
			strSql.Append("[IsUrlrewrite]=@IsUrlrewrite,");
			strSql.Append("[IsDel]=@IsDel");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Parentid", model.Parentid),
					new OleDbParameter("@Path", model.Path),
					new OleDbParameter("@IsIndexShow", model.IsIndexShow),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Level", model.Level),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@IsShow", model.IsShow),
					new OleDbParameter("@ProPerty132", model.ProPerty132),
					new OleDbParameter("@ProPerty131", model.ProPerty131),
					new OleDbParameter("@ProPerty133", model.ProPerty133),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@taobaoid", model.taobaoid),
					new OleDbParameter("@Url", model.Url),
					new OleDbParameter("@Site_ids", model.Site_ids),
					new OleDbParameter("@ProPerty134", model.ProPerty134),
					new OleDbParameter("@IsUrlrewrite", model.IsUrlrewrite),
					new OleDbParameter("@IsDel", model.IsDel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Pro_Type] ");
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
			strSql.Append("delete from [Lebi_Pro_Type] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Pro_Type] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Pro_Type GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Pro_Type] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Pro_Type model;
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
		public Lebi_Pro_Type GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Pro_Type] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Pro_Type model;
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
		public Lebi_Pro_Type GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Pro_Type] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Pro_Type model;
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
		public List<Lebi_Pro_Type> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Pro_Type]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Pro_Type> list = new List<Lebi_Pro_Type>();
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
		public List<Lebi_Pro_Type> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Pro_Type]";
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
			List<Lebi_Pro_Type> list = new List<Lebi_Pro_Type>();
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
		public List<Lebi_Pro_Type> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Pro_Type] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Pro_Type> list = new List<Lebi_Pro_Type>();
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
		public List<Lebi_Pro_Type> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Pro_Type]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Pro_Type> list = new List<Lebi_Pro_Type>();
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
		public Lebi_Pro_Type BindForm(Lebi_Pro_Type model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestString("Path");
			if (HttpContext.Current.Request["IsIndexShow"] != null)
				model.IsIndexShow=Shop.Tools.RequestTool.RequestInt("IsIndexShow",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Level"] != null)
				model.Level=Shop.Tools.RequestTool.RequestInt("Level",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["ProPerty132"] != null)
				model.ProPerty132=Shop.Tools.RequestTool.RequestString("ProPerty132");
			if (HttpContext.Current.Request["ProPerty131"] != null)
				model.ProPerty131=Shop.Tools.RequestTool.RequestString("ProPerty131");
			if (HttpContext.Current.Request["ProPerty133"] != null)
				model.ProPerty133=Shop.Tools.RequestTool.RequestString("ProPerty133");
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestString("taobaoid");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestString("Url");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestString("Site_ids");
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestString("ProPerty134");
			if (HttpContext.Current.Request["IsUrlrewrite"] != null)
				model.IsUrlrewrite=Shop.Tools.RequestTool.RequestString("IsUrlrewrite");
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Pro_Type SafeBindForm(Lebi_Pro_Type model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestSafeString("Path");
			if (HttpContext.Current.Request["IsIndexShow"] != null)
				model.IsIndexShow=Shop.Tools.RequestTool.RequestInt("IsIndexShow",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Level"] != null)
				model.Level=Shop.Tools.RequestTool.RequestInt("Level",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["ProPerty132"] != null)
				model.ProPerty132=Shop.Tools.RequestTool.RequestSafeString("ProPerty132");
			if (HttpContext.Current.Request["ProPerty131"] != null)
				model.ProPerty131=Shop.Tools.RequestTool.RequestSafeString("ProPerty131");
			if (HttpContext.Current.Request["ProPerty133"] != null)
				model.ProPerty133=Shop.Tools.RequestTool.RequestSafeString("ProPerty133");
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestSafeString("taobaoid");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestSafeString("Url");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestSafeString("Site_ids");
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestSafeString("ProPerty134");
			if (HttpContext.Current.Request["IsUrlrewrite"] != null)
				model.IsUrlrewrite=Shop.Tools.RequestTool.RequestSafeString("IsUrlrewrite");
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Pro_Type ReaderBind(IDataReader dataReader)
		{
			Lebi_Pro_Type model=new Lebi_Pro_Type();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Parentid=(int)ojb;
			}
			model.Path=dataReader["Path"].ToString();
			ojb = dataReader["IsIndexShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsIndexShow=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Level"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Level=(int)ojb;
			}
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(int)ojb;
			}
			model.ProPerty132=dataReader["ProPerty132"].ToString();
			model.ProPerty131=dataReader["ProPerty131"].ToString();
			model.ProPerty133=dataReader["ProPerty133"].ToString();
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.taobaoid=dataReader["taobaoid"].ToString();
			model.Url=dataReader["Url"].ToString();
			model.Site_ids=dataReader["Site_ids"].ToString();
			model.ProPerty134=dataReader["ProPerty134"].ToString();
			model.IsUrlrewrite=dataReader["IsUrlrewrite"].ToString();
			ojb = dataReader["IsDel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDel=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

