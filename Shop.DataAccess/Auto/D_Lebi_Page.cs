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

	public interface Lebi_Page_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Page model);
		void Update(Lebi_Page model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Page GetModel(int id);
		Lebi_Page GetModel(string strWhere);
		Lebi_Page GetModel(SQLPara para);
		List<Lebi_Page> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Page> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Page> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Page> GetList(SQLPara para);
		Lebi_Page BindForm(Lebi_Page model);
		Lebi_Page SafeBindForm(Lebi_Page model);
		Lebi_Page ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Page。
	/// </summary>
	public class D_Lebi_Page
	{
		static Lebi_Page_interface _Instance;
		public static Lebi_Page_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Page();
		            else
		                _Instance = new sqlserver_Lebi_Page();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Page()
		{}
		#region  成员方法
	class sqlserver_Lebi_Page : Lebi_Page_interface
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
				strSql.Append("select " + colName + " from [Lebi_Page]");
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
			strSql.Append("select  "+colName+" from [Lebi_Page]");
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
			strSql.Append("select count(1) from [Lebi_Page]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Page]");
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
			strSql.Append("select max(id) from [Lebi_Page]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Page]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Page model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Page](");
			strSql.Append("Name,SubName,NameColor,Content,Description,Node_id,SEO_Title,SEO_Keywords,SEO_Description,target,url,Language_ids,Language,sourceurl,source,Author,Editor,Email,Sort,user_id,admin_id,Time_Add,Time_Update,Count_Views,Count_Comment,ImageSmall,ImageMedium,ImageBig,ImageOriginal,Supplier_id)");
			strSql.Append(" values (");
			strSql.Append("@Name,@SubName,@NameColor,@Content,@Description,@Node_id,@SEO_Title,@SEO_Keywords,@SEO_Description,@target,@url,@Language_ids,@Language,@sourceurl,@source,@Author,@Editor,@Email,@Sort,@user_id,@admin_id,@Time_Add,@Time_Update,@Count_Views,@Count_Comment,@ImageSmall,@ImageMedium,@ImageBig,@ImageOriginal,@Supplier_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@SubName", model.SubName),
					new SqlParameter("@NameColor", model.NameColor),
					new SqlParameter("@Content", model.Content),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@Node_id", model.Node_id),
					new SqlParameter("@SEO_Title", model.SEO_Title),
					new SqlParameter("@SEO_Keywords", model.SEO_Keywords),
					new SqlParameter("@SEO_Description", model.SEO_Description),
					new SqlParameter("@target", model.target),
					new SqlParameter("@url", model.url),
					new SqlParameter("@Language_ids", model.Language_ids),
					new SqlParameter("@Language", model.Language),
					new SqlParameter("@sourceurl", model.sourceurl),
					new SqlParameter("@source", model.source),
					new SqlParameter("@Author", model.Author),
					new SqlParameter("@Editor", model.Editor),
					new SqlParameter("@Email", model.Email),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@user_id", model.user_id),
					new SqlParameter("@admin_id", model.admin_id),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Update", model.Time_Update),
					new SqlParameter("@Count_Views", model.Count_Views),
					new SqlParameter("@Count_Comment", model.Count_Comment),
					new SqlParameter("@ImageSmall", model.ImageSmall),
					new SqlParameter("@ImageMedium", model.ImageMedium),
					new SqlParameter("@ImageBig", model.ImageBig),
					new SqlParameter("@ImageOriginal", model.ImageOriginal),
					new SqlParameter("@Supplier_id", model.Supplier_id)};

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
		public void Update(Lebi_Page model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Page] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("SubName= @SubName,");
			strSql.Append("NameColor= @NameColor,");
			strSql.Append("Content= @Content,");
			strSql.Append("Description= @Description,");
			strSql.Append("Node_id= @Node_id,");
			strSql.Append("SEO_Title= @SEO_Title,");
			strSql.Append("SEO_Keywords= @SEO_Keywords,");
			strSql.Append("SEO_Description= @SEO_Description,");
			strSql.Append("target= @target,");
			strSql.Append("url= @url,");
			strSql.Append("Language_ids= @Language_ids,");
			strSql.Append("Language= @Language,");
			strSql.Append("sourceurl= @sourceurl,");
			strSql.Append("source= @source,");
			strSql.Append("Author= @Author,");
			strSql.Append("Editor= @Editor,");
			strSql.Append("Email= @Email,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("user_id= @user_id,");
			strSql.Append("admin_id= @admin_id,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Update= @Time_Update,");
			strSql.Append("Count_Views= @Count_Views,");
			strSql.Append("Count_Comment= @Count_Comment,");
			strSql.Append("ImageSmall= @ImageSmall,");
			strSql.Append("ImageMedium= @ImageMedium,");
			strSql.Append("ImageBig= @ImageBig,");
			strSql.Append("ImageOriginal= @ImageOriginal,");
			strSql.Append("Supplier_id= @Supplier_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@SubName", SqlDbType.NVarChar,100),
					new SqlParameter("@NameColor", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Description", SqlDbType.NVarChar,4000),
					new SqlParameter("@Node_id", SqlDbType.Int,4),
					new SqlParameter("@SEO_Title", SqlDbType.NVarChar,200),
					new SqlParameter("@SEO_Keywords", SqlDbType.NVarChar,200),
					new SqlParameter("@SEO_Description", SqlDbType.NVarChar,300),
					new SqlParameter("@target", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,500),
					new SqlParameter("@Language_ids", SqlDbType.NVarChar,100),
					new SqlParameter("@Language", SqlDbType.NVarChar,100),
					new SqlParameter("@sourceurl", SqlDbType.NVarChar,500),
					new SqlParameter("@source", SqlDbType.NVarChar,50),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Editor", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@admin_id", SqlDbType.Int,4),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Update", SqlDbType.DateTime),
					new SqlParameter("@Count_Views", SqlDbType.Int,4),
					new SqlParameter("@Count_Comment", SqlDbType.Int,4),
					new SqlParameter("@ImageSmall", SqlDbType.NVarChar,100),
					new SqlParameter("@ImageMedium", SqlDbType.NVarChar,100),
					new SqlParameter("@ImageBig", SqlDbType.NVarChar,100),
					new SqlParameter("@ImageOriginal", SqlDbType.NVarChar,100),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.SubName;
			parameters[3].Value = model.NameColor;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.Node_id;
			parameters[7].Value = model.SEO_Title;
			parameters[8].Value = model.SEO_Keywords;
			parameters[9].Value = model.SEO_Description;
			parameters[10].Value = model.target;
			parameters[11].Value = model.url;
			parameters[12].Value = model.Language_ids;
			parameters[13].Value = model.Language;
			parameters[14].Value = model.sourceurl;
			parameters[15].Value = model.source;
			parameters[16].Value = model.Author;
			parameters[17].Value = model.Editor;
			parameters[18].Value = model.Email;
			parameters[19].Value = model.Sort;
			parameters[20].Value = model.user_id;
			parameters[21].Value = model.admin_id;
			parameters[22].Value = model.Time_Add;
			parameters[23].Value = model.Time_Update;
			parameters[24].Value = model.Count_Views;
			parameters[25].Value = model.Count_Comment;
			parameters[26].Value = model.ImageSmall;
			parameters[27].Value = model.ImageMedium;
			parameters[28].Value = model.ImageBig;
			parameters[29].Value = model.ImageOriginal;
			parameters[30].Value = model.Supplier_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Page] ");
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
			strSql.Append("delete from [Lebi_Page] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Page] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Page GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Page] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Page model=new Lebi_Page();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.SubName=ds.Tables[0].Rows[0]["SubName"].ToString();
				model.NameColor=ds.Tables[0].Rows[0]["NameColor"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["Node_id"].ToString()!="")
				{
					model.Node_id=int.Parse(ds.Tables[0].Rows[0]["Node_id"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.target=ds.Tables[0].Rows[0]["target"].ToString();
				model.url=ds.Tables[0].Rows[0]["url"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.sourceurl=ds.Tables[0].Rows[0]["sourceurl"].ToString();
				model.source=ds.Tables[0].Rows[0]["source"].ToString();
				model.Author=ds.Tables[0].Rows[0]["Author"].ToString();
				model.Editor=ds.Tables[0].Rows[0]["Editor"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["admin_id"].ToString()!="")
				{
					model.admin_id=int.Parse(ds.Tables[0].Rows[0]["admin_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views"].ToString()!="")
				{
					model.Count_Views=int.Parse(ds.Tables[0].Rows[0]["Count_Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Comment"].ToString()!="")
				{
					model.Count_Comment=int.Parse(ds.Tables[0].Rows[0]["Count_Comment"].ToString());
				}
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
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
		public Lebi_Page GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Page] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Page model=new Lebi_Page();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.SubName=ds.Tables[0].Rows[0]["SubName"].ToString();
				model.NameColor=ds.Tables[0].Rows[0]["NameColor"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["Node_id"].ToString()!="")
				{
					model.Node_id=int.Parse(ds.Tables[0].Rows[0]["Node_id"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.target=ds.Tables[0].Rows[0]["target"].ToString();
				model.url=ds.Tables[0].Rows[0]["url"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.sourceurl=ds.Tables[0].Rows[0]["sourceurl"].ToString();
				model.source=ds.Tables[0].Rows[0]["source"].ToString();
				model.Author=ds.Tables[0].Rows[0]["Author"].ToString();
				model.Editor=ds.Tables[0].Rows[0]["Editor"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["admin_id"].ToString()!="")
				{
					model.admin_id=int.Parse(ds.Tables[0].Rows[0]["admin_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views"].ToString()!="")
				{
					model.Count_Views=int.Parse(ds.Tables[0].Rows[0]["Count_Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Comment"].ToString()!="")
				{
					model.Count_Comment=int.Parse(ds.Tables[0].Rows[0]["Count_Comment"].ToString());
				}
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
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
		public Lebi_Page GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Page] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Page model=new Lebi_Page();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.SubName=ds.Tables[0].Rows[0]["SubName"].ToString();
				model.NameColor=ds.Tables[0].Rows[0]["NameColor"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["Node_id"].ToString()!="")
				{
					model.Node_id=int.Parse(ds.Tables[0].Rows[0]["Node_id"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.target=ds.Tables[0].Rows[0]["target"].ToString();
				model.url=ds.Tables[0].Rows[0]["url"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.sourceurl=ds.Tables[0].Rows[0]["sourceurl"].ToString();
				model.source=ds.Tables[0].Rows[0]["source"].ToString();
				model.Author=ds.Tables[0].Rows[0]["Author"].ToString();
				model.Editor=ds.Tables[0].Rows[0]["Editor"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["admin_id"].ToString()!="")
				{
					model.admin_id=int.Parse(ds.Tables[0].Rows[0]["admin_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views"].ToString()!="")
				{
					model.Count_Views=int.Parse(ds.Tables[0].Rows[0]["Count_Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Comment"].ToString()!="")
				{
					model.Count_Comment=int.Parse(ds.Tables[0].Rows[0]["Count_Comment"].ToString());
				}
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
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
		public List<Lebi_Page> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Page]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Page> list = new List<Lebi_Page>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Page> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Page]";
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
			List<Lebi_Page> list = new List<Lebi_Page>();
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
		public List<Lebi_Page> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Page] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Page> list = new List<Lebi_Page>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Page> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Page]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Page> list = new List<Lebi_Page>();
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
		public Lebi_Page BindForm(Lebi_Page model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestString("SubName");
			if (HttpContext.Current.Request["NameColor"] != null)
				model.NameColor=Shop.Tools.RequestTool.RequestString("NameColor");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Node_id"] != null)
				model.Node_id=Shop.Tools.RequestTool.RequestInt("Node_id",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["target"] != null)
				model.target=Shop.Tools.RequestTool.RequestString("target");
			if (HttpContext.Current.Request["url"] != null)
				model.url=Shop.Tools.RequestTool.RequestString("url");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["sourceurl"] != null)
				model.sourceurl=Shop.Tools.RequestTool.RequestString("sourceurl");
			if (HttpContext.Current.Request["source"] != null)
				model.source=Shop.Tools.RequestTool.RequestString("source");
			if (HttpContext.Current.Request["Author"] != null)
				model.Author=Shop.Tools.RequestTool.RequestString("Author");
			if (HttpContext.Current.Request["Editor"] != null)
				model.Editor=Shop.Tools.RequestTool.RequestString("Editor");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["user_id"] != null)
				model.user_id=Shop.Tools.RequestTool.RequestInt("user_id",0);
			if (HttpContext.Current.Request["admin_id"] != null)
				model.admin_id=Shop.Tools.RequestTool.RequestInt("admin_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Count_Comment"] != null)
				model.Count_Comment=Shop.Tools.RequestTool.RequestInt("Count_Comment",0);
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestString("ImageOriginal");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Page SafeBindForm(Lebi_Page model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestSafeString("SubName");
			if (HttpContext.Current.Request["NameColor"] != null)
				model.NameColor=Shop.Tools.RequestTool.RequestSafeString("NameColor");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Node_id"] != null)
				model.Node_id=Shop.Tools.RequestTool.RequestInt("Node_id",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["target"] != null)
				model.target=Shop.Tools.RequestTool.RequestSafeString("target");
			if (HttpContext.Current.Request["url"] != null)
				model.url=Shop.Tools.RequestTool.RequestSafeString("url");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["sourceurl"] != null)
				model.sourceurl=Shop.Tools.RequestTool.RequestSafeString("sourceurl");
			if (HttpContext.Current.Request["source"] != null)
				model.source=Shop.Tools.RequestTool.RequestSafeString("source");
			if (HttpContext.Current.Request["Author"] != null)
				model.Author=Shop.Tools.RequestTool.RequestSafeString("Author");
			if (HttpContext.Current.Request["Editor"] != null)
				model.Editor=Shop.Tools.RequestTool.RequestSafeString("Editor");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["user_id"] != null)
				model.user_id=Shop.Tools.RequestTool.RequestInt("user_id",0);
			if (HttpContext.Current.Request["admin_id"] != null)
				model.admin_id=Shop.Tools.RequestTool.RequestInt("admin_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Count_Comment"] != null)
				model.Count_Comment=Shop.Tools.RequestTool.RequestInt("Count_Comment",0);
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestSafeString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestSafeString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestSafeString("ImageOriginal");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Page ReaderBind(IDataReader dataReader)
		{
			Lebi_Page model=new Lebi_Page();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.SubName=dataReader["SubName"].ToString();
			model.NameColor=dataReader["NameColor"].ToString();
			model.Content=dataReader["Content"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["Node_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Node_id=(int)ojb;
			}
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			model.target=dataReader["target"].ToString();
			model.url=dataReader["url"].ToString();
			model.Language_ids=dataReader["Language_ids"].ToString();
			model.Language=dataReader["Language"].ToString();
			model.sourceurl=dataReader["sourceurl"].ToString();
			model.source=dataReader["source"].ToString();
			model.Author=dataReader["Author"].ToString();
			model.Editor=dataReader["Editor"].ToString();
			model.Email=dataReader["Email"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["user_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.user_id=(int)ojb;
			}
			ojb = dataReader["admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.admin_id=(int)ojb;
			}
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
			ojb = dataReader["Count_Views"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Views=(int)ojb;
			}
			ojb = dataReader["Count_Comment"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Comment=(int)ojb;
			}
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.ImageMedium=dataReader["ImageMedium"].ToString();
			model.ImageBig=dataReader["ImageBig"].ToString();
			model.ImageOriginal=dataReader["ImageOriginal"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Page : Lebi_Page_interface
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
				strSql.Append("select " + colName + " from [Lebi_Page]");
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
			strSql.Append("select  "+colName+" from [Lebi_Page]");
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
			strSql.Append("select count(*) from [Lebi_Page]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Page]");
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
			strSql.Append("select max(id) from [Lebi_Page]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Page]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Page model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Page](");
			strSql.Append("[Name],[SubName],[NameColor],[Content],[Description],[Node_id],[SEO_Title],[SEO_Keywords],[SEO_Description],[target],[url],[Language_ids],[Language],[sourceurl],[source],[Author],[Editor],[Email],[Sort],[user_id],[admin_id],[Time_Add],[Time_Update],[Count_Views],[Count_Comment],[ImageSmall],[ImageMedium],[ImageBig],[ImageOriginal],[Supplier_id])");
			strSql.Append(" values (");
			strSql.Append("@Name,@SubName,@NameColor,@Content,@Description,@Node_id,@SEO_Title,@SEO_Keywords,@SEO_Description,@target,@url,@Language_ids,@Language,@sourceurl,@source,@Author,@Editor,@Email,@Sort,@user_id,@admin_id,@Time_Add,@Time_Update,@Count_Views,@Count_Comment,@ImageSmall,@ImageMedium,@ImageBig,@ImageOriginal,@Supplier_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@SubName", model.SubName),
					new OleDbParameter("@NameColor", model.NameColor),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Node_id", model.Node_id),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@target", model.target),
					new OleDbParameter("@url", model.url),
					new OleDbParameter("@Language_ids", model.Language_ids),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@sourceurl", model.sourceurl),
					new OleDbParameter("@source", model.source),
					new OleDbParameter("@Author", model.Author),
					new OleDbParameter("@Editor", model.Editor),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@user_id", model.user_id),
					new OleDbParameter("@admin_id", model.admin_id),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Count_Views", model.Count_Views),
					new OleDbParameter("@Count_Comment", model.Count_Comment),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@ImageMedium", model.ImageMedium),
					new OleDbParameter("@ImageBig", model.ImageBig),
					new OleDbParameter("@ImageOriginal", model.ImageOriginal),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Page model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Page] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[SubName]=@SubName,");
			strSql.Append("[NameColor]=@NameColor,");
			strSql.Append("[Content]=@Content,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[Node_id]=@Node_id,");
			strSql.Append("[SEO_Title]=@SEO_Title,");
			strSql.Append("[SEO_Keywords]=@SEO_Keywords,");
			strSql.Append("[SEO_Description]=@SEO_Description,");
			strSql.Append("[target]=@target,");
			strSql.Append("[url]=@url,");
			strSql.Append("[Language_ids]=@Language_ids,");
			strSql.Append("[Language]=@Language,");
			strSql.Append("[sourceurl]=@sourceurl,");
			strSql.Append("[source]=@source,");
			strSql.Append("[Author]=@Author,");
			strSql.Append("[Editor]=@Editor,");
			strSql.Append("[Email]=@Email,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[user_id]=@user_id,");
			strSql.Append("[admin_id]=@admin_id,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Update]=@Time_Update,");
			strSql.Append("[Count_Views]=@Count_Views,");
			strSql.Append("[Count_Comment]=@Count_Comment,");
			strSql.Append("[ImageSmall]=@ImageSmall,");
			strSql.Append("[ImageMedium]=@ImageMedium,");
			strSql.Append("[ImageBig]=@ImageBig,");
			strSql.Append("[ImageOriginal]=@ImageOriginal,");
			strSql.Append("[Supplier_id]=@Supplier_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@SubName", model.SubName),
					new OleDbParameter("@NameColor", model.NameColor),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Node_id", model.Node_id),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@target", model.target),
					new OleDbParameter("@url", model.url),
					new OleDbParameter("@Language_ids", model.Language_ids),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@sourceurl", model.sourceurl),
					new OleDbParameter("@source", model.source),
					new OleDbParameter("@Author", model.Author),
					new OleDbParameter("@Editor", model.Editor),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@user_id", model.user_id),
					new OleDbParameter("@admin_id", model.admin_id),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Count_Views", model.Count_Views),
					new OleDbParameter("@Count_Comment", model.Count_Comment),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@ImageMedium", model.ImageMedium),
					new OleDbParameter("@ImageBig", model.ImageBig),
					new OleDbParameter("@ImageOriginal", model.ImageOriginal),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Page] ");
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
			strSql.Append("delete from [Lebi_Page] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Page] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Page GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Page] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Page model;
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
		public Lebi_Page GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Page] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Page model;
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
		public Lebi_Page GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Page] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Page model;
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
		public List<Lebi_Page> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Page]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Page> list = new List<Lebi_Page>();
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
		public List<Lebi_Page> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Page]";
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
			List<Lebi_Page> list = new List<Lebi_Page>();
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
		public List<Lebi_Page> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Page] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Page> list = new List<Lebi_Page>();
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
		public List<Lebi_Page> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Page]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Page> list = new List<Lebi_Page>();
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
		public Lebi_Page BindForm(Lebi_Page model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestString("SubName");
			if (HttpContext.Current.Request["NameColor"] != null)
				model.NameColor=Shop.Tools.RequestTool.RequestString("NameColor");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Node_id"] != null)
				model.Node_id=Shop.Tools.RequestTool.RequestInt("Node_id",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["target"] != null)
				model.target=Shop.Tools.RequestTool.RequestString("target");
			if (HttpContext.Current.Request["url"] != null)
				model.url=Shop.Tools.RequestTool.RequestString("url");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["sourceurl"] != null)
				model.sourceurl=Shop.Tools.RequestTool.RequestString("sourceurl");
			if (HttpContext.Current.Request["source"] != null)
				model.source=Shop.Tools.RequestTool.RequestString("source");
			if (HttpContext.Current.Request["Author"] != null)
				model.Author=Shop.Tools.RequestTool.RequestString("Author");
			if (HttpContext.Current.Request["Editor"] != null)
				model.Editor=Shop.Tools.RequestTool.RequestString("Editor");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["user_id"] != null)
				model.user_id=Shop.Tools.RequestTool.RequestInt("user_id",0);
			if (HttpContext.Current.Request["admin_id"] != null)
				model.admin_id=Shop.Tools.RequestTool.RequestInt("admin_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Count_Comment"] != null)
				model.Count_Comment=Shop.Tools.RequestTool.RequestInt("Count_Comment",0);
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestString("ImageOriginal");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Page SafeBindForm(Lebi_Page model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestSafeString("SubName");
			if (HttpContext.Current.Request["NameColor"] != null)
				model.NameColor=Shop.Tools.RequestTool.RequestSafeString("NameColor");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Node_id"] != null)
				model.Node_id=Shop.Tools.RequestTool.RequestInt("Node_id",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["target"] != null)
				model.target=Shop.Tools.RequestTool.RequestSafeString("target");
			if (HttpContext.Current.Request["url"] != null)
				model.url=Shop.Tools.RequestTool.RequestSafeString("url");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["sourceurl"] != null)
				model.sourceurl=Shop.Tools.RequestTool.RequestSafeString("sourceurl");
			if (HttpContext.Current.Request["source"] != null)
				model.source=Shop.Tools.RequestTool.RequestSafeString("source");
			if (HttpContext.Current.Request["Author"] != null)
				model.Author=Shop.Tools.RequestTool.RequestSafeString("Author");
			if (HttpContext.Current.Request["Editor"] != null)
				model.Editor=Shop.Tools.RequestTool.RequestSafeString("Editor");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["user_id"] != null)
				model.user_id=Shop.Tools.RequestTool.RequestInt("user_id",0);
			if (HttpContext.Current.Request["admin_id"] != null)
				model.admin_id=Shop.Tools.RequestTool.RequestInt("admin_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Count_Comment"] != null)
				model.Count_Comment=Shop.Tools.RequestTool.RequestInt("Count_Comment",0);
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestSafeString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestSafeString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestSafeString("ImageOriginal");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Page ReaderBind(IDataReader dataReader)
		{
			Lebi_Page model=new Lebi_Page();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.SubName=dataReader["SubName"].ToString();
			model.NameColor=dataReader["NameColor"].ToString();
			model.Content=dataReader["Content"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["Node_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Node_id=(int)ojb;
			}
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			model.target=dataReader["target"].ToString();
			model.url=dataReader["url"].ToString();
			model.Language_ids=dataReader["Language_ids"].ToString();
			model.Language=dataReader["Language"].ToString();
			model.sourceurl=dataReader["sourceurl"].ToString();
			model.source=dataReader["source"].ToString();
			model.Author=dataReader["Author"].ToString();
			model.Editor=dataReader["Editor"].ToString();
			model.Email=dataReader["Email"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["user_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.user_id=(int)ojb;
			}
			ojb = dataReader["admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.admin_id=(int)ojb;
			}
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
			ojb = dataReader["Count_Views"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Views=(int)ojb;
			}
			ojb = dataReader["Count_Comment"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Comment=(int)ojb;
			}
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.ImageMedium=dataReader["ImageMedium"].ToString();
			model.ImageBig=dataReader["ImageBig"].ToString();
			model.ImageOriginal=dataReader["ImageOriginal"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

