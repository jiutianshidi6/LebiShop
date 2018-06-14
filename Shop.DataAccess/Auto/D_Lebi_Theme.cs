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

	public interface Lebi_Theme_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Theme model);
		void Update(Lebi_Theme model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Theme GetModel(int id);
		Lebi_Theme GetModel(string strWhere);
		Lebi_Theme GetModel(SQLPara para);
		List<Lebi_Theme> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Theme> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Theme> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Theme> GetList(SQLPara para);
		Lebi_Theme BindForm(Lebi_Theme model);
		Lebi_Theme SafeBindForm(Lebi_Theme model);
		Lebi_Theme ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Theme。
	/// </summary>
	public class D_Lebi_Theme
	{
		static Lebi_Theme_interface _Instance;
		public static Lebi_Theme_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Theme();
		            else
		                _Instance = new sqlserver_Lebi_Theme();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Theme()
		{}
		#region  成员方法
	class sqlserver_Lebi_Theme : Lebi_Theme_interface
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
				strSql.Append("select " + colName + " from [Lebi_Theme]");
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
			strSql.Append("select  "+colName+" from [Lebi_Theme]");
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
			strSql.Append("select count(1) from [Lebi_Theme]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Theme]");
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
			strSql.Append("select max(id) from [Lebi_Theme]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Theme]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Theme model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Theme](");
			strSql.Append("Name,Code,Language,Path_Create,Path_Files,Path_JS,Path_CSS,Path_Image,Sort,ImageUrl,Time_Add,Time_Update,ImageSmall_Width,ImageSmall_Height,ImageMedium_Width,ImageMedium_Height,ImageBig_Width,ImageBig_Height,ImageSmallUrl,Description,LebiUser_id,LebiUser,IsNew,Version,Path_Advert,IsUpdate)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Code,@Language,@Path_Create,@Path_Files,@Path_JS,@Path_CSS,@Path_Image,@Sort,@ImageUrl,@Time_Add,@Time_Update,@ImageSmall_Width,@ImageSmall_Height,@ImageMedium_Width,@ImageMedium_Height,@ImageBig_Width,@ImageBig_Height,@ImageSmallUrl,@Description,@LebiUser_id,@LebiUser,@IsNew,@Version,@Path_Advert,@IsUpdate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@Language", model.Language),
					new SqlParameter("@Path_Create", model.Path_Create),
					new SqlParameter("@Path_Files", model.Path_Files),
					new SqlParameter("@Path_JS", model.Path_JS),
					new SqlParameter("@Path_CSS", model.Path_CSS),
					new SqlParameter("@Path_Image", model.Path_Image),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@ImageUrl", model.ImageUrl),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Update", model.Time_Update),
					new SqlParameter("@ImageSmall_Width", model.ImageSmall_Width),
					new SqlParameter("@ImageSmall_Height", model.ImageSmall_Height),
					new SqlParameter("@ImageMedium_Width", model.ImageMedium_Width),
					new SqlParameter("@ImageMedium_Height", model.ImageMedium_Height),
					new SqlParameter("@ImageBig_Width", model.ImageBig_Width),
					new SqlParameter("@ImageBig_Height", model.ImageBig_Height),
					new SqlParameter("@ImageSmallUrl", model.ImageSmallUrl),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@LebiUser_id", model.LebiUser_id),
					new SqlParameter("@LebiUser", model.LebiUser),
					new SqlParameter("@IsNew", model.IsNew),
					new SqlParameter("@Version", model.Version),
					new SqlParameter("@Path_Advert", model.Path_Advert),
					new SqlParameter("@IsUpdate", model.IsUpdate)};

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
		public void Update(Lebi_Theme model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Theme] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("Code= @Code,");
			strSql.Append("Language= @Language,");
			strSql.Append("Path_Create= @Path_Create,");
			strSql.Append("Path_Files= @Path_Files,");
			strSql.Append("Path_JS= @Path_JS,");
			strSql.Append("Path_CSS= @Path_CSS,");
			strSql.Append("Path_Image= @Path_Image,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("ImageUrl= @ImageUrl,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Update= @Time_Update,");
			strSql.Append("ImageSmall_Width= @ImageSmall_Width,");
			strSql.Append("ImageSmall_Height= @ImageSmall_Height,");
			strSql.Append("ImageMedium_Width= @ImageMedium_Width,");
			strSql.Append("ImageMedium_Height= @ImageMedium_Height,");
			strSql.Append("ImageBig_Width= @ImageBig_Width,");
			strSql.Append("ImageBig_Height= @ImageBig_Height,");
			strSql.Append("ImageSmallUrl= @ImageSmallUrl,");
			strSql.Append("Description= @Description,");
			strSql.Append("LebiUser_id= @LebiUser_id,");
			strSql.Append("LebiUser= @LebiUser,");
			strSql.Append("IsNew= @IsNew,");
			strSql.Append("Version= @Version,");
			strSql.Append("Path_Advert= @Path_Advert,");
			strSql.Append("IsUpdate= @IsUpdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Language", SqlDbType.NVarChar,200),
					new SqlParameter("@Path_Create", SqlDbType.NVarChar,50),
					new SqlParameter("@Path_Files", SqlDbType.NVarChar,50),
					new SqlParameter("@Path_JS", SqlDbType.NVarChar,50),
					new SqlParameter("@Path_CSS", SqlDbType.NVarChar,50),
					new SqlParameter("@Path_Image", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Update", SqlDbType.DateTime),
					new SqlParameter("@ImageSmall_Width", SqlDbType.Int,4),
					new SqlParameter("@ImageSmall_Height", SqlDbType.Int,4),
					new SqlParameter("@ImageMedium_Width", SqlDbType.Int,4),
					new SqlParameter("@ImageMedium_Height", SqlDbType.Int,4),
					new SqlParameter("@ImageBig_Width", SqlDbType.Int,4),
					new SqlParameter("@ImageBig_Height", SqlDbType.Int,4),
					new SqlParameter("@ImageSmallUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@Description", SqlDbType.NVarChar,4000),
					new SqlParameter("@LebiUser_id", SqlDbType.Int,4),
					new SqlParameter("@LebiUser", SqlDbType.NVarChar,50),
					new SqlParameter("@IsNew", SqlDbType.Int,4),
					new SqlParameter("@Version", SqlDbType.Int,4),
					new SqlParameter("@Path_Advert", SqlDbType.NVarChar,50),
					new SqlParameter("@IsUpdate", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Code;
			parameters[3].Value = model.Language;
			parameters[4].Value = model.Path_Create;
			parameters[5].Value = model.Path_Files;
			parameters[6].Value = model.Path_JS;
			parameters[7].Value = model.Path_CSS;
			parameters[8].Value = model.Path_Image;
			parameters[9].Value = model.Sort;
			parameters[10].Value = model.ImageUrl;
			parameters[11].Value = model.Time_Add;
			parameters[12].Value = model.Time_Update;
			parameters[13].Value = model.ImageSmall_Width;
			parameters[14].Value = model.ImageSmall_Height;
			parameters[15].Value = model.ImageMedium_Width;
			parameters[16].Value = model.ImageMedium_Height;
			parameters[17].Value = model.ImageBig_Width;
			parameters[18].Value = model.ImageBig_Height;
			parameters[19].Value = model.ImageSmallUrl;
			parameters[20].Value = model.Description;
			parameters[21].Value = model.LebiUser_id;
			parameters[22].Value = model.LebiUser;
			parameters[23].Value = model.IsNew;
			parameters[24].Value = model.Version;
			parameters[25].Value = model.Path_Advert;
			parameters[26].Value = model.IsUpdate;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme] ");
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
			strSql.Append("delete from [Lebi_Theme] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Theme GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Theme model=new Lebi_Theme();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Path_Create=ds.Tables[0].Rows[0]["Path_Create"].ToString();
				model.Path_Files=ds.Tables[0].Rows[0]["Path_Files"].ToString();
				model.Path_JS=ds.Tables[0].Rows[0]["Path_JS"].ToString();
				model.Path_CSS=ds.Tables[0].Rows[0]["Path_CSS"].ToString();
				model.Path_Image=ds.Tables[0].Rows[0]["Path_Image"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageSmall_Width"].ToString()!="")
				{
					model.ImageSmall_Width=int.Parse(ds.Tables[0].Rows[0]["ImageSmall_Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageSmall_Height"].ToString()!="")
				{
					model.ImageSmall_Height=int.Parse(ds.Tables[0].Rows[0]["ImageSmall_Height"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageMedium_Width"].ToString()!="")
				{
					model.ImageMedium_Width=int.Parse(ds.Tables[0].Rows[0]["ImageMedium_Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageMedium_Height"].ToString()!="")
				{
					model.ImageMedium_Height=int.Parse(ds.Tables[0].Rows[0]["ImageMedium_Height"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageBig_Width"].ToString()!="")
				{
					model.ImageBig_Width=int.Parse(ds.Tables[0].Rows[0]["ImageBig_Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageBig_Height"].ToString()!="")
				{
					model.ImageBig_Height=int.Parse(ds.Tables[0].Rows[0]["ImageBig_Height"].ToString());
				}
				model.ImageSmallUrl=ds.Tables[0].Rows[0]["ImageSmallUrl"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["LebiUser_id"].ToString()!="")
				{
					model.LebiUser_id=int.Parse(ds.Tables[0].Rows[0]["LebiUser_id"].ToString());
				}
				model.LebiUser=ds.Tables[0].Rows[0]["LebiUser"].ToString();
				if(ds.Tables[0].Rows[0]["IsNew"].ToString()!="")
				{
					model.IsNew=int.Parse(ds.Tables[0].Rows[0]["IsNew"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Version"].ToString()!="")
				{
					model.Version=int.Parse(ds.Tables[0].Rows[0]["Version"].ToString());
				}
				model.Path_Advert=ds.Tables[0].Rows[0]["Path_Advert"].ToString();
				if(ds.Tables[0].Rows[0]["IsUpdate"].ToString()!="")
				{
					model.IsUpdate=int.Parse(ds.Tables[0].Rows[0]["IsUpdate"].ToString());
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
		public Lebi_Theme GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Theme model=new Lebi_Theme();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Path_Create=ds.Tables[0].Rows[0]["Path_Create"].ToString();
				model.Path_Files=ds.Tables[0].Rows[0]["Path_Files"].ToString();
				model.Path_JS=ds.Tables[0].Rows[0]["Path_JS"].ToString();
				model.Path_CSS=ds.Tables[0].Rows[0]["Path_CSS"].ToString();
				model.Path_Image=ds.Tables[0].Rows[0]["Path_Image"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageSmall_Width"].ToString()!="")
				{
					model.ImageSmall_Width=int.Parse(ds.Tables[0].Rows[0]["ImageSmall_Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageSmall_Height"].ToString()!="")
				{
					model.ImageSmall_Height=int.Parse(ds.Tables[0].Rows[0]["ImageSmall_Height"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageMedium_Width"].ToString()!="")
				{
					model.ImageMedium_Width=int.Parse(ds.Tables[0].Rows[0]["ImageMedium_Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageMedium_Height"].ToString()!="")
				{
					model.ImageMedium_Height=int.Parse(ds.Tables[0].Rows[0]["ImageMedium_Height"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageBig_Width"].ToString()!="")
				{
					model.ImageBig_Width=int.Parse(ds.Tables[0].Rows[0]["ImageBig_Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageBig_Height"].ToString()!="")
				{
					model.ImageBig_Height=int.Parse(ds.Tables[0].Rows[0]["ImageBig_Height"].ToString());
				}
				model.ImageSmallUrl=ds.Tables[0].Rows[0]["ImageSmallUrl"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["LebiUser_id"].ToString()!="")
				{
					model.LebiUser_id=int.Parse(ds.Tables[0].Rows[0]["LebiUser_id"].ToString());
				}
				model.LebiUser=ds.Tables[0].Rows[0]["LebiUser"].ToString();
				if(ds.Tables[0].Rows[0]["IsNew"].ToString()!="")
				{
					model.IsNew=int.Parse(ds.Tables[0].Rows[0]["IsNew"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Version"].ToString()!="")
				{
					model.Version=int.Parse(ds.Tables[0].Rows[0]["Version"].ToString());
				}
				model.Path_Advert=ds.Tables[0].Rows[0]["Path_Advert"].ToString();
				if(ds.Tables[0].Rows[0]["IsUpdate"].ToString()!="")
				{
					model.IsUpdate=int.Parse(ds.Tables[0].Rows[0]["IsUpdate"].ToString());
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
		public Lebi_Theme GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Theme] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Theme model=new Lebi_Theme();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Path_Create=ds.Tables[0].Rows[0]["Path_Create"].ToString();
				model.Path_Files=ds.Tables[0].Rows[0]["Path_Files"].ToString();
				model.Path_JS=ds.Tables[0].Rows[0]["Path_JS"].ToString();
				model.Path_CSS=ds.Tables[0].Rows[0]["Path_CSS"].ToString();
				model.Path_Image=ds.Tables[0].Rows[0]["Path_Image"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageSmall_Width"].ToString()!="")
				{
					model.ImageSmall_Width=int.Parse(ds.Tables[0].Rows[0]["ImageSmall_Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageSmall_Height"].ToString()!="")
				{
					model.ImageSmall_Height=int.Parse(ds.Tables[0].Rows[0]["ImageSmall_Height"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageMedium_Width"].ToString()!="")
				{
					model.ImageMedium_Width=int.Parse(ds.Tables[0].Rows[0]["ImageMedium_Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageMedium_Height"].ToString()!="")
				{
					model.ImageMedium_Height=int.Parse(ds.Tables[0].Rows[0]["ImageMedium_Height"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageBig_Width"].ToString()!="")
				{
					model.ImageBig_Width=int.Parse(ds.Tables[0].Rows[0]["ImageBig_Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageBig_Height"].ToString()!="")
				{
					model.ImageBig_Height=int.Parse(ds.Tables[0].Rows[0]["ImageBig_Height"].ToString());
				}
				model.ImageSmallUrl=ds.Tables[0].Rows[0]["ImageSmallUrl"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["LebiUser_id"].ToString()!="")
				{
					model.LebiUser_id=int.Parse(ds.Tables[0].Rows[0]["LebiUser_id"].ToString());
				}
				model.LebiUser=ds.Tables[0].Rows[0]["LebiUser"].ToString();
				if(ds.Tables[0].Rows[0]["IsNew"].ToString()!="")
				{
					model.IsNew=int.Parse(ds.Tables[0].Rows[0]["IsNew"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Version"].ToString()!="")
				{
					model.Version=int.Parse(ds.Tables[0].Rows[0]["Version"].ToString());
				}
				model.Path_Advert=ds.Tables[0].Rows[0]["Path_Advert"].ToString();
				if(ds.Tables[0].Rows[0]["IsUpdate"].ToString()!="")
				{
					model.IsUpdate=int.Parse(ds.Tables[0].Rows[0]["IsUpdate"].ToString());
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
		public List<Lebi_Theme> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Theme]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Theme> list = new List<Lebi_Theme>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Theme> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Theme]";
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
			List<Lebi_Theme> list = new List<Lebi_Theme>();
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
		public List<Lebi_Theme> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Theme] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Theme> list = new List<Lebi_Theme>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Theme> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Theme]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Theme> list = new List<Lebi_Theme>();
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
		public Lebi_Theme BindForm(Lebi_Theme model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Path_Create"] != null)
				model.Path_Create=Shop.Tools.RequestTool.RequestString("Path_Create");
			if (HttpContext.Current.Request["Path_Files"] != null)
				model.Path_Files=Shop.Tools.RequestTool.RequestString("Path_Files");
			if (HttpContext.Current.Request["Path_JS"] != null)
				model.Path_JS=Shop.Tools.RequestTool.RequestString("Path_JS");
			if (HttpContext.Current.Request["Path_CSS"] != null)
				model.Path_CSS=Shop.Tools.RequestTool.RequestString("Path_CSS");
			if (HttpContext.Current.Request["Path_Image"] != null)
				model.Path_Image=Shop.Tools.RequestTool.RequestString("Path_Image");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["ImageSmall_Width"] != null)
				model.ImageSmall_Width=Shop.Tools.RequestTool.RequestInt("ImageSmall_Width",0);
			if (HttpContext.Current.Request["ImageSmall_Height"] != null)
				model.ImageSmall_Height=Shop.Tools.RequestTool.RequestInt("ImageSmall_Height",0);
			if (HttpContext.Current.Request["ImageMedium_Width"] != null)
				model.ImageMedium_Width=Shop.Tools.RequestTool.RequestInt("ImageMedium_Width",0);
			if (HttpContext.Current.Request["ImageMedium_Height"] != null)
				model.ImageMedium_Height=Shop.Tools.RequestTool.RequestInt("ImageMedium_Height",0);
			if (HttpContext.Current.Request["ImageBig_Width"] != null)
				model.ImageBig_Width=Shop.Tools.RequestTool.RequestInt("ImageBig_Width",0);
			if (HttpContext.Current.Request["ImageBig_Height"] != null)
				model.ImageBig_Height=Shop.Tools.RequestTool.RequestInt("ImageBig_Height",0);
			if (HttpContext.Current.Request["ImageSmallUrl"] != null)
				model.ImageSmallUrl=Shop.Tools.RequestTool.RequestString("ImageSmallUrl");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["LebiUser_id"] != null)
				model.LebiUser_id=Shop.Tools.RequestTool.RequestInt("LebiUser_id",0);
			if (HttpContext.Current.Request["LebiUser"] != null)
				model.LebiUser=Shop.Tools.RequestTool.RequestString("LebiUser");
			if (HttpContext.Current.Request["IsNew"] != null)
				model.IsNew=Shop.Tools.RequestTool.RequestInt("IsNew",0);
			if (HttpContext.Current.Request["Version"] != null)
				model.Version=Shop.Tools.RequestTool.RequestInt("Version",0);
			if (HttpContext.Current.Request["Path_Advert"] != null)
				model.Path_Advert=Shop.Tools.RequestTool.RequestString("Path_Advert");
			if (HttpContext.Current.Request["IsUpdate"] != null)
				model.IsUpdate=Shop.Tools.RequestTool.RequestInt("IsUpdate",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Theme SafeBindForm(Lebi_Theme model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Path_Create"] != null)
				model.Path_Create=Shop.Tools.RequestTool.RequestSafeString("Path_Create");
			if (HttpContext.Current.Request["Path_Files"] != null)
				model.Path_Files=Shop.Tools.RequestTool.RequestSafeString("Path_Files");
			if (HttpContext.Current.Request["Path_JS"] != null)
				model.Path_JS=Shop.Tools.RequestTool.RequestSafeString("Path_JS");
			if (HttpContext.Current.Request["Path_CSS"] != null)
				model.Path_CSS=Shop.Tools.RequestTool.RequestSafeString("Path_CSS");
			if (HttpContext.Current.Request["Path_Image"] != null)
				model.Path_Image=Shop.Tools.RequestTool.RequestSafeString("Path_Image");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["ImageSmall_Width"] != null)
				model.ImageSmall_Width=Shop.Tools.RequestTool.RequestInt("ImageSmall_Width",0);
			if (HttpContext.Current.Request["ImageSmall_Height"] != null)
				model.ImageSmall_Height=Shop.Tools.RequestTool.RequestInt("ImageSmall_Height",0);
			if (HttpContext.Current.Request["ImageMedium_Width"] != null)
				model.ImageMedium_Width=Shop.Tools.RequestTool.RequestInt("ImageMedium_Width",0);
			if (HttpContext.Current.Request["ImageMedium_Height"] != null)
				model.ImageMedium_Height=Shop.Tools.RequestTool.RequestInt("ImageMedium_Height",0);
			if (HttpContext.Current.Request["ImageBig_Width"] != null)
				model.ImageBig_Width=Shop.Tools.RequestTool.RequestInt("ImageBig_Width",0);
			if (HttpContext.Current.Request["ImageBig_Height"] != null)
				model.ImageBig_Height=Shop.Tools.RequestTool.RequestInt("ImageBig_Height",0);
			if (HttpContext.Current.Request["ImageSmallUrl"] != null)
				model.ImageSmallUrl=Shop.Tools.RequestTool.RequestSafeString("ImageSmallUrl");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["LebiUser_id"] != null)
				model.LebiUser_id=Shop.Tools.RequestTool.RequestInt("LebiUser_id",0);
			if (HttpContext.Current.Request["LebiUser"] != null)
				model.LebiUser=Shop.Tools.RequestTool.RequestSafeString("LebiUser");
			if (HttpContext.Current.Request["IsNew"] != null)
				model.IsNew=Shop.Tools.RequestTool.RequestInt("IsNew",0);
			if (HttpContext.Current.Request["Version"] != null)
				model.Version=Shop.Tools.RequestTool.RequestInt("Version",0);
			if (HttpContext.Current.Request["Path_Advert"] != null)
				model.Path_Advert=Shop.Tools.RequestTool.RequestSafeString("Path_Advert");
			if (HttpContext.Current.Request["IsUpdate"] != null)
				model.IsUpdate=Shop.Tools.RequestTool.RequestInt("IsUpdate",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Theme ReaderBind(IDataReader dataReader)
		{
			Lebi_Theme model=new Lebi_Theme();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.Code=dataReader["Code"].ToString();
			model.Language=dataReader["Language"].ToString();
			model.Path_Create=dataReader["Path_Create"].ToString();
			model.Path_Files=dataReader["Path_Files"].ToString();
			model.Path_JS=dataReader["Path_JS"].ToString();
			model.Path_CSS=dataReader["Path_CSS"].ToString();
			model.Path_Image=dataReader["Path_Image"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			model.ImageUrl=dataReader["ImageUrl"].ToString();
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
			ojb = dataReader["ImageSmall_Width"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageSmall_Width=(int)ojb;
			}
			ojb = dataReader["ImageSmall_Height"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageSmall_Height=(int)ojb;
			}
			ojb = dataReader["ImageMedium_Width"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageMedium_Width=(int)ojb;
			}
			ojb = dataReader["ImageMedium_Height"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageMedium_Height=(int)ojb;
			}
			ojb = dataReader["ImageBig_Width"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageBig_Width=(int)ojb;
			}
			ojb = dataReader["ImageBig_Height"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageBig_Height=(int)ojb;
			}
			model.ImageSmallUrl=dataReader["ImageSmallUrl"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["LebiUser_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LebiUser_id=(int)ojb;
			}
			model.LebiUser=dataReader["LebiUser"].ToString();
			ojb = dataReader["IsNew"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsNew=(int)ojb;
			}
			ojb = dataReader["Version"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Version=(int)ojb;
			}
			model.Path_Advert=dataReader["Path_Advert"].ToString();
			ojb = dataReader["IsUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUpdate=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Theme : Lebi_Theme_interface
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
				strSql.Append("select " + colName + " from [Lebi_Theme]");
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
			strSql.Append("select  "+colName+" from [Lebi_Theme]");
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
			strSql.Append("select count(*) from [Lebi_Theme]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Theme]");
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
			strSql.Append("select max(id) from [Lebi_Theme]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Theme]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Theme model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Theme](");
			strSql.Append("[Name],[Code],[Language],[Path_Create],[Path_Files],[Path_JS],[Path_CSS],[Path_Image],[Sort],[ImageUrl],[Time_Add],[Time_Update],[ImageSmall_Width],[ImageSmall_Height],[ImageMedium_Width],[ImageMedium_Height],[ImageBig_Width],[ImageBig_Height],[ImageSmallUrl],[Description],[LebiUser_id],[LebiUser],[IsNew],[Version],[Path_Advert],[IsUpdate])");
			strSql.Append(" values (");
			strSql.Append("@Name,@Code,@Language,@Path_Create,@Path_Files,@Path_JS,@Path_CSS,@Path_Image,@Sort,@ImageUrl,@Time_Add,@Time_Update,@ImageSmall_Width,@ImageSmall_Height,@ImageMedium_Width,@ImageMedium_Height,@ImageBig_Width,@ImageBig_Height,@ImageSmallUrl,@Description,@LebiUser_id,@LebiUser,@IsNew,@Version,@Path_Advert,@IsUpdate)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Path_Create", model.Path_Create),
					new OleDbParameter("@Path_Files", model.Path_Files),
					new OleDbParameter("@Path_JS", model.Path_JS),
					new OleDbParameter("@Path_CSS", model.Path_CSS),
					new OleDbParameter("@Path_Image", model.Path_Image),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@ImageSmall_Width", model.ImageSmall_Width),
					new OleDbParameter("@ImageSmall_Height", model.ImageSmall_Height),
					new OleDbParameter("@ImageMedium_Width", model.ImageMedium_Width),
					new OleDbParameter("@ImageMedium_Height", model.ImageMedium_Height),
					new OleDbParameter("@ImageBig_Width", model.ImageBig_Width),
					new OleDbParameter("@ImageBig_Height", model.ImageBig_Height),
					new OleDbParameter("@ImageSmallUrl", model.ImageSmallUrl),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@LebiUser_id", model.LebiUser_id),
					new OleDbParameter("@LebiUser", model.LebiUser),
					new OleDbParameter("@IsNew", model.IsNew),
					new OleDbParameter("@Version", model.Version),
					new OleDbParameter("@Path_Advert", model.Path_Advert),
					new OleDbParameter("@IsUpdate", model.IsUpdate)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Theme model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Theme] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[Language]=@Language,");
			strSql.Append("[Path_Create]=@Path_Create,");
			strSql.Append("[Path_Files]=@Path_Files,");
			strSql.Append("[Path_JS]=@Path_JS,");
			strSql.Append("[Path_CSS]=@Path_CSS,");
			strSql.Append("[Path_Image]=@Path_Image,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[ImageUrl]=@ImageUrl,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Update]=@Time_Update,");
			strSql.Append("[ImageSmall_Width]=@ImageSmall_Width,");
			strSql.Append("[ImageSmall_Height]=@ImageSmall_Height,");
			strSql.Append("[ImageMedium_Width]=@ImageMedium_Width,");
			strSql.Append("[ImageMedium_Height]=@ImageMedium_Height,");
			strSql.Append("[ImageBig_Width]=@ImageBig_Width,");
			strSql.Append("[ImageBig_Height]=@ImageBig_Height,");
			strSql.Append("[ImageSmallUrl]=@ImageSmallUrl,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[LebiUser_id]=@LebiUser_id,");
			strSql.Append("[LebiUser]=@LebiUser,");
			strSql.Append("[IsNew]=@IsNew,");
			strSql.Append("[Version]=@Version,");
			strSql.Append("[Path_Advert]=@Path_Advert,");
			strSql.Append("[IsUpdate]=@IsUpdate");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Path_Create", model.Path_Create),
					new OleDbParameter("@Path_Files", model.Path_Files),
					new OleDbParameter("@Path_JS", model.Path_JS),
					new OleDbParameter("@Path_CSS", model.Path_CSS),
					new OleDbParameter("@Path_Image", model.Path_Image),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@ImageSmall_Width", model.ImageSmall_Width),
					new OleDbParameter("@ImageSmall_Height", model.ImageSmall_Height),
					new OleDbParameter("@ImageMedium_Width", model.ImageMedium_Width),
					new OleDbParameter("@ImageMedium_Height", model.ImageMedium_Height),
					new OleDbParameter("@ImageBig_Width", model.ImageBig_Width),
					new OleDbParameter("@ImageBig_Height", model.ImageBig_Height),
					new OleDbParameter("@ImageSmallUrl", model.ImageSmallUrl),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@LebiUser_id", model.LebiUser_id),
					new OleDbParameter("@LebiUser", model.LebiUser),
					new OleDbParameter("@IsNew", model.IsNew),
					new OleDbParameter("@Version", model.Version),
					new OleDbParameter("@Path_Advert", model.Path_Advert),
					new OleDbParameter("@IsUpdate", model.IsUpdate)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme] ");
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
			strSql.Append("delete from [Lebi_Theme] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Theme] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Theme GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Theme model;
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
		public Lebi_Theme GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Theme] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Theme model;
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
		public Lebi_Theme GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Theme] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Theme model;
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
		public List<Lebi_Theme> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Theme]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Theme> list = new List<Lebi_Theme>();
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
		public List<Lebi_Theme> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Theme]";
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
			List<Lebi_Theme> list = new List<Lebi_Theme>();
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
		public List<Lebi_Theme> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Theme] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Theme> list = new List<Lebi_Theme>();
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
		public List<Lebi_Theme> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Theme]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Theme> list = new List<Lebi_Theme>();
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
		public Lebi_Theme BindForm(Lebi_Theme model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Path_Create"] != null)
				model.Path_Create=Shop.Tools.RequestTool.RequestString("Path_Create");
			if (HttpContext.Current.Request["Path_Files"] != null)
				model.Path_Files=Shop.Tools.RequestTool.RequestString("Path_Files");
			if (HttpContext.Current.Request["Path_JS"] != null)
				model.Path_JS=Shop.Tools.RequestTool.RequestString("Path_JS");
			if (HttpContext.Current.Request["Path_CSS"] != null)
				model.Path_CSS=Shop.Tools.RequestTool.RequestString("Path_CSS");
			if (HttpContext.Current.Request["Path_Image"] != null)
				model.Path_Image=Shop.Tools.RequestTool.RequestString("Path_Image");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["ImageSmall_Width"] != null)
				model.ImageSmall_Width=Shop.Tools.RequestTool.RequestInt("ImageSmall_Width",0);
			if (HttpContext.Current.Request["ImageSmall_Height"] != null)
				model.ImageSmall_Height=Shop.Tools.RequestTool.RequestInt("ImageSmall_Height",0);
			if (HttpContext.Current.Request["ImageMedium_Width"] != null)
				model.ImageMedium_Width=Shop.Tools.RequestTool.RequestInt("ImageMedium_Width",0);
			if (HttpContext.Current.Request["ImageMedium_Height"] != null)
				model.ImageMedium_Height=Shop.Tools.RequestTool.RequestInt("ImageMedium_Height",0);
			if (HttpContext.Current.Request["ImageBig_Width"] != null)
				model.ImageBig_Width=Shop.Tools.RequestTool.RequestInt("ImageBig_Width",0);
			if (HttpContext.Current.Request["ImageBig_Height"] != null)
				model.ImageBig_Height=Shop.Tools.RequestTool.RequestInt("ImageBig_Height",0);
			if (HttpContext.Current.Request["ImageSmallUrl"] != null)
				model.ImageSmallUrl=Shop.Tools.RequestTool.RequestString("ImageSmallUrl");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["LebiUser_id"] != null)
				model.LebiUser_id=Shop.Tools.RequestTool.RequestInt("LebiUser_id",0);
			if (HttpContext.Current.Request["LebiUser"] != null)
				model.LebiUser=Shop.Tools.RequestTool.RequestString("LebiUser");
			if (HttpContext.Current.Request["IsNew"] != null)
				model.IsNew=Shop.Tools.RequestTool.RequestInt("IsNew",0);
			if (HttpContext.Current.Request["Version"] != null)
				model.Version=Shop.Tools.RequestTool.RequestInt("Version",0);
			if (HttpContext.Current.Request["Path_Advert"] != null)
				model.Path_Advert=Shop.Tools.RequestTool.RequestString("Path_Advert");
			if (HttpContext.Current.Request["IsUpdate"] != null)
				model.IsUpdate=Shop.Tools.RequestTool.RequestInt("IsUpdate",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Theme SafeBindForm(Lebi_Theme model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Path_Create"] != null)
				model.Path_Create=Shop.Tools.RequestTool.RequestSafeString("Path_Create");
			if (HttpContext.Current.Request["Path_Files"] != null)
				model.Path_Files=Shop.Tools.RequestTool.RequestSafeString("Path_Files");
			if (HttpContext.Current.Request["Path_JS"] != null)
				model.Path_JS=Shop.Tools.RequestTool.RequestSafeString("Path_JS");
			if (HttpContext.Current.Request["Path_CSS"] != null)
				model.Path_CSS=Shop.Tools.RequestTool.RequestSafeString("Path_CSS");
			if (HttpContext.Current.Request["Path_Image"] != null)
				model.Path_Image=Shop.Tools.RequestTool.RequestSafeString("Path_Image");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["ImageSmall_Width"] != null)
				model.ImageSmall_Width=Shop.Tools.RequestTool.RequestInt("ImageSmall_Width",0);
			if (HttpContext.Current.Request["ImageSmall_Height"] != null)
				model.ImageSmall_Height=Shop.Tools.RequestTool.RequestInt("ImageSmall_Height",0);
			if (HttpContext.Current.Request["ImageMedium_Width"] != null)
				model.ImageMedium_Width=Shop.Tools.RequestTool.RequestInt("ImageMedium_Width",0);
			if (HttpContext.Current.Request["ImageMedium_Height"] != null)
				model.ImageMedium_Height=Shop.Tools.RequestTool.RequestInt("ImageMedium_Height",0);
			if (HttpContext.Current.Request["ImageBig_Width"] != null)
				model.ImageBig_Width=Shop.Tools.RequestTool.RequestInt("ImageBig_Width",0);
			if (HttpContext.Current.Request["ImageBig_Height"] != null)
				model.ImageBig_Height=Shop.Tools.RequestTool.RequestInt("ImageBig_Height",0);
			if (HttpContext.Current.Request["ImageSmallUrl"] != null)
				model.ImageSmallUrl=Shop.Tools.RequestTool.RequestSafeString("ImageSmallUrl");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["LebiUser_id"] != null)
				model.LebiUser_id=Shop.Tools.RequestTool.RequestInt("LebiUser_id",0);
			if (HttpContext.Current.Request["LebiUser"] != null)
				model.LebiUser=Shop.Tools.RequestTool.RequestSafeString("LebiUser");
			if (HttpContext.Current.Request["IsNew"] != null)
				model.IsNew=Shop.Tools.RequestTool.RequestInt("IsNew",0);
			if (HttpContext.Current.Request["Version"] != null)
				model.Version=Shop.Tools.RequestTool.RequestInt("Version",0);
			if (HttpContext.Current.Request["Path_Advert"] != null)
				model.Path_Advert=Shop.Tools.RequestTool.RequestSafeString("Path_Advert");
			if (HttpContext.Current.Request["IsUpdate"] != null)
				model.IsUpdate=Shop.Tools.RequestTool.RequestInt("IsUpdate",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Theme ReaderBind(IDataReader dataReader)
		{
			Lebi_Theme model=new Lebi_Theme();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.Code=dataReader["Code"].ToString();
			model.Language=dataReader["Language"].ToString();
			model.Path_Create=dataReader["Path_Create"].ToString();
			model.Path_Files=dataReader["Path_Files"].ToString();
			model.Path_JS=dataReader["Path_JS"].ToString();
			model.Path_CSS=dataReader["Path_CSS"].ToString();
			model.Path_Image=dataReader["Path_Image"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			model.ImageUrl=dataReader["ImageUrl"].ToString();
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
			ojb = dataReader["ImageSmall_Width"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageSmall_Width=(int)ojb;
			}
			ojb = dataReader["ImageSmall_Height"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageSmall_Height=(int)ojb;
			}
			ojb = dataReader["ImageMedium_Width"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageMedium_Width=(int)ojb;
			}
			ojb = dataReader["ImageMedium_Height"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageMedium_Height=(int)ojb;
			}
			ojb = dataReader["ImageBig_Width"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageBig_Width=(int)ojb;
			}
			ojb = dataReader["ImageBig_Height"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImageBig_Height=(int)ojb;
			}
			model.ImageSmallUrl=dataReader["ImageSmallUrl"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["LebiUser_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LebiUser_id=(int)ojb;
			}
			model.LebiUser=dataReader["LebiUser"].ToString();
			ojb = dataReader["IsNew"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsNew=(int)ojb;
			}
			ojb = dataReader["Version"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Version=(int)ojb;
			}
			model.Path_Advert=dataReader["Path_Advert"].ToString();
			ojb = dataReader["IsUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUpdate=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

