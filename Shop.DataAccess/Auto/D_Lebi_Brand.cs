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

	public interface Lebi_Brand_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Brand model);
		void Update(Lebi_Brand model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Brand GetModel(int id);
		Lebi_Brand GetModel(string strWhere);
		Lebi_Brand GetModel(SQLPara para);
		List<Lebi_Brand> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Brand> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Brand> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Brand> GetList(SQLPara para);
		Lebi_Brand BindForm(Lebi_Brand model);
		Lebi_Brand SafeBindForm(Lebi_Brand model);
		Lebi_Brand ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Brand。
	/// </summary>
	public class D_Lebi_Brand
	{
		static Lebi_Brand_interface _Instance;
		public static Lebi_Brand_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Brand();
		            else
		                _Instance = new sqlserver_Lebi_Brand();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Brand()
		{}
		#region  成员方法
	class sqlserver_Lebi_Brand : Lebi_Brand_interface
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
				strSql.Append("select " + colName + " from [Lebi_Brand]");
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
			strSql.Append("select  "+colName+" from [Lebi_Brand]");
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
			strSql.Append("select count(1) from [Lebi_Brand]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Brand]");
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
			strSql.Append("select max(id) from [Lebi_Brand]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Brand]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Brand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Brand](");
			strSql.Append("Name,ImageUrl,Sort,IsRecommend,FirstLetter,Pro_Type_id,Count,Description,SEO_Title,SEO_Keywords,SEO_Description,Supplier_id,Type_id_BrandStatus,IsVAT)");
			strSql.Append(" values (");
			strSql.Append("@Name,@ImageUrl,@Sort,@IsRecommend,@FirstLetter,@Pro_Type_id,@Count,@Description,@SEO_Title,@SEO_Keywords,@SEO_Description,@Supplier_id,@Type_id_BrandStatus,@IsVAT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@ImageUrl", model.ImageUrl),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@IsRecommend", model.IsRecommend),
					new SqlParameter("@FirstLetter", model.FirstLetter),
					new SqlParameter("@Pro_Type_id", model.Pro_Type_id),
					new SqlParameter("@Count", model.Count),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@SEO_Title", model.SEO_Title),
					new SqlParameter("@SEO_Keywords", model.SEO_Keywords),
					new SqlParameter("@SEO_Description", model.SEO_Description),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Type_id_BrandStatus", model.Type_id_BrandStatus),
					new SqlParameter("@IsVAT", model.IsVAT)};

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
		public void Update(Lebi_Brand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Brand] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("ImageUrl= @ImageUrl,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("IsRecommend= @IsRecommend,");
			strSql.Append("FirstLetter= @FirstLetter,");
			strSql.Append("Pro_Type_id= @Pro_Type_id,");
			strSql.Append("Count= @Count,");
			strSql.Append("Description= @Description,");
			strSql.Append("SEO_Title= @SEO_Title,");
			strSql.Append("SEO_Keywords= @SEO_Keywords,");
			strSql.Append("SEO_Description= @SEO_Description,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Type_id_BrandStatus= @Type_id_BrandStatus,");
			strSql.Append("IsVAT= @IsVAT");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@IsRecommend", SqlDbType.Int,4),
					new SqlParameter("@FirstLetter", SqlDbType.NVarChar,50),
					new SqlParameter("@Pro_Type_id", SqlDbType.VarChar,500),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@SEO_Title", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Keywords", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Type_id_BrandStatus", SqlDbType.Int,4),
					new SqlParameter("@IsVAT", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.ImageUrl;
			parameters[3].Value = model.Sort;
			parameters[4].Value = model.IsRecommend;
			parameters[5].Value = model.FirstLetter;
			parameters[6].Value = model.Pro_Type_id;
			parameters[7].Value = model.Count;
			parameters[8].Value = model.Description;
			parameters[9].Value = model.SEO_Title;
			parameters[10].Value = model.SEO_Keywords;
			parameters[11].Value = model.SEO_Description;
			parameters[12].Value = model.Supplier_id;
			parameters[13].Value = model.Type_id_BrandStatus;
			parameters[14].Value = model.IsVAT;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Brand] ");
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
			strSql.Append("delete from [Lebi_Brand] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Brand] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Brand GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Brand] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Brand model=new Lebi_Brand();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRecommend"].ToString()!="")
				{
					model.IsRecommend=int.Parse(ds.Tables[0].Rows[0]["IsRecommend"].ToString());
				}
				model.FirstLetter=ds.Tables[0].Rows[0]["FirstLetter"].ToString();
				model.Pro_Type_id=ds.Tables[0].Rows[0]["Pro_Type_id"].ToString();
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_BrandStatus"].ToString()!="")
				{
					model.Type_id_BrandStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_BrandStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsVAT"].ToString()!="")
				{
					model.IsVAT=int.Parse(ds.Tables[0].Rows[0]["IsVAT"].ToString());
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
		public Lebi_Brand GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Brand] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Brand model=new Lebi_Brand();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRecommend"].ToString()!="")
				{
					model.IsRecommend=int.Parse(ds.Tables[0].Rows[0]["IsRecommend"].ToString());
				}
				model.FirstLetter=ds.Tables[0].Rows[0]["FirstLetter"].ToString();
				model.Pro_Type_id=ds.Tables[0].Rows[0]["Pro_Type_id"].ToString();
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_BrandStatus"].ToString()!="")
				{
					model.Type_id_BrandStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_BrandStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsVAT"].ToString()!="")
				{
					model.IsVAT=int.Parse(ds.Tables[0].Rows[0]["IsVAT"].ToString());
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
		public Lebi_Brand GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Brand] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Brand model=new Lebi_Brand();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRecommend"].ToString()!="")
				{
					model.IsRecommend=int.Parse(ds.Tables[0].Rows[0]["IsRecommend"].ToString());
				}
				model.FirstLetter=ds.Tables[0].Rows[0]["FirstLetter"].ToString();
				model.Pro_Type_id=ds.Tables[0].Rows[0]["Pro_Type_id"].ToString();
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_BrandStatus"].ToString()!="")
				{
					model.Type_id_BrandStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_BrandStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsVAT"].ToString()!="")
				{
					model.IsVAT=int.Parse(ds.Tables[0].Rows[0]["IsVAT"].ToString());
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
		public List<Lebi_Brand> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Brand]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Brand> list = new List<Lebi_Brand>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Brand> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Brand]";
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
			List<Lebi_Brand> list = new List<Lebi_Brand>();
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
		public List<Lebi_Brand> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Brand] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Brand> list = new List<Lebi_Brand>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Brand> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Brand]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Brand> list = new List<Lebi_Brand>();
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
		public Lebi_Brand BindForm(Lebi_Brand model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsRecommend"] != null)
				model.IsRecommend=Shop.Tools.RequestTool.RequestInt("IsRecommend",0);
			if (HttpContext.Current.Request["FirstLetter"] != null)
				model.FirstLetter=Shop.Tools.RequestTool.RequestString("FirstLetter");
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestString("Pro_Type_id");
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Type_id_BrandStatus"] != null)
				model.Type_id_BrandStatus=Shop.Tools.RequestTool.RequestInt("Type_id_BrandStatus",0);
			if (HttpContext.Current.Request["IsVAT"] != null)
				model.IsVAT=Shop.Tools.RequestTool.RequestInt("IsVAT",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Brand SafeBindForm(Lebi_Brand model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsRecommend"] != null)
				model.IsRecommend=Shop.Tools.RequestTool.RequestInt("IsRecommend",0);
			if (HttpContext.Current.Request["FirstLetter"] != null)
				model.FirstLetter=Shop.Tools.RequestTool.RequestSafeString("FirstLetter");
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestSafeString("Pro_Type_id");
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Type_id_BrandStatus"] != null)
				model.Type_id_BrandStatus=Shop.Tools.RequestTool.RequestInt("Type_id_BrandStatus",0);
			if (HttpContext.Current.Request["IsVAT"] != null)
				model.IsVAT=Shop.Tools.RequestTool.RequestInt("IsVAT",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Brand ReaderBind(IDataReader dataReader)
		{
			Lebi_Brand model=new Lebi_Brand();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["IsRecommend"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRecommend=(int)ojb;
			}
			model.FirstLetter=dataReader["FirstLetter"].ToString();
			model.Pro_Type_id=dataReader["Pro_Type_id"].ToString();
			ojb = dataReader["Count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count=(int)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["Type_id_BrandStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_BrandStatus=(int)ojb;
			}
			ojb = dataReader["IsVAT"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsVAT=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Brand : Lebi_Brand_interface
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
				strSql.Append("select " + colName + " from [Lebi_Brand]");
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
			strSql.Append("select  "+colName+" from [Lebi_Brand]");
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
			strSql.Append("select count(*) from [Lebi_Brand]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Brand]");
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
			strSql.Append("select max(id) from [Lebi_Brand]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Brand]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Brand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Brand](");
			strSql.Append("[Name],[ImageUrl],[Sort],[IsRecommend],[FirstLetter],[Pro_Type_id],[Count],[Description],[SEO_Title],[SEO_Keywords],[SEO_Description],[Supplier_id],[Type_id_BrandStatus],[IsVAT])");
			strSql.Append(" values (");
			strSql.Append("@Name,@ImageUrl,@Sort,@IsRecommend,@FirstLetter,@Pro_Type_id,@Count,@Description,@SEO_Title,@SEO_Keywords,@SEO_Description,@Supplier_id,@Type_id_BrandStatus,@IsVAT)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@IsRecommend", model.IsRecommend),
					new OleDbParameter("@FirstLetter", model.FirstLetter),
					new OleDbParameter("@Pro_Type_id", model.Pro_Type_id),
					new OleDbParameter("@Count", model.Count),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Type_id_BrandStatus", model.Type_id_BrandStatus),
					new OleDbParameter("@IsVAT", model.IsVAT)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Brand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Brand] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[ImageUrl]=@ImageUrl,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[IsRecommend]=@IsRecommend,");
			strSql.Append("[FirstLetter]=@FirstLetter,");
			strSql.Append("[Pro_Type_id]=@Pro_Type_id,");
			strSql.Append("[Count]=@Count,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[SEO_Title]=@SEO_Title,");
			strSql.Append("[SEO_Keywords]=@SEO_Keywords,");
			strSql.Append("[SEO_Description]=@SEO_Description,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Type_id_BrandStatus]=@Type_id_BrandStatus,");
			strSql.Append("[IsVAT]=@IsVAT");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@IsRecommend", model.IsRecommend),
					new OleDbParameter("@FirstLetter", model.FirstLetter),
					new OleDbParameter("@Pro_Type_id", model.Pro_Type_id),
					new OleDbParameter("@Count", model.Count),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Type_id_BrandStatus", model.Type_id_BrandStatus),
					new OleDbParameter("@IsVAT", model.IsVAT)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Brand] ");
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
			strSql.Append("delete from [Lebi_Brand] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Brand] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Brand GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Brand] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Brand model;
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
		public Lebi_Brand GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Brand] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Brand model;
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
		public Lebi_Brand GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Brand] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Brand model;
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
		public List<Lebi_Brand> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Brand]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Brand> list = new List<Lebi_Brand>();
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
		public List<Lebi_Brand> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Brand]";
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
			List<Lebi_Brand> list = new List<Lebi_Brand>();
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
		public List<Lebi_Brand> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Brand] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Brand> list = new List<Lebi_Brand>();
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
		public List<Lebi_Brand> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Brand]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Brand> list = new List<Lebi_Brand>();
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
		public Lebi_Brand BindForm(Lebi_Brand model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsRecommend"] != null)
				model.IsRecommend=Shop.Tools.RequestTool.RequestInt("IsRecommend",0);
			if (HttpContext.Current.Request["FirstLetter"] != null)
				model.FirstLetter=Shop.Tools.RequestTool.RequestString("FirstLetter");
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestString("Pro_Type_id");
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Type_id_BrandStatus"] != null)
				model.Type_id_BrandStatus=Shop.Tools.RequestTool.RequestInt("Type_id_BrandStatus",0);
			if (HttpContext.Current.Request["IsVAT"] != null)
				model.IsVAT=Shop.Tools.RequestTool.RequestInt("IsVAT",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Brand SafeBindForm(Lebi_Brand model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsRecommend"] != null)
				model.IsRecommend=Shop.Tools.RequestTool.RequestInt("IsRecommend",0);
			if (HttpContext.Current.Request["FirstLetter"] != null)
				model.FirstLetter=Shop.Tools.RequestTool.RequestSafeString("FirstLetter");
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestSafeString("Pro_Type_id");
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Type_id_BrandStatus"] != null)
				model.Type_id_BrandStatus=Shop.Tools.RequestTool.RequestInt("Type_id_BrandStatus",0);
			if (HttpContext.Current.Request["IsVAT"] != null)
				model.IsVAT=Shop.Tools.RequestTool.RequestInt("IsVAT",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Brand ReaderBind(IDataReader dataReader)
		{
			Lebi_Brand model=new Lebi_Brand();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["IsRecommend"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRecommend=(int)ojb;
			}
			model.FirstLetter=dataReader["FirstLetter"].ToString();
			model.Pro_Type_id=dataReader["Pro_Type_id"].ToString();
			ojb = dataReader["Count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count=(int)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["Type_id_BrandStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_BrandStatus=(int)ojb;
			}
			ojb = dataReader["IsVAT"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsVAT=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

