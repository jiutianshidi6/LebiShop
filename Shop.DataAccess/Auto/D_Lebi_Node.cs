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

	public interface Lebi_Node_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Node model);
		void Update(Lebi_Node model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Node GetModel(int id);
		Lebi_Node GetModel(string strWhere);
		Lebi_Node GetModel(SQLPara para);
		List<Lebi_Node> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Node> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Node> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Node> GetList(SQLPara para);
		Lebi_Node BindForm(Lebi_Node model);
		Lebi_Node SafeBindForm(Lebi_Node model);
		Lebi_Node ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Node。
	/// </summary>
	public class D_Lebi_Node
	{
		static Lebi_Node_interface _Instance;
		public static Lebi_Node_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Node();
		            else
		                _Instance = new sqlserver_Lebi_Node();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Node()
		{}
		#region  成员方法
	class sqlserver_Lebi_Node : Lebi_Node_interface
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
				strSql.Append("select " + colName + " from [Lebi_Node]");
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
			strSql.Append("select  "+colName+" from [Lebi_Node]");
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
			strSql.Append("select count(1) from [Lebi_Node]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Node]");
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
			strSql.Append("select max(id) from [Lebi_Node]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Node]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Node model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Node](");
			strSql.Append("Name,Sort,Code,parentid,SEO_Title,SEO_Keywords,SEO_Description,target,url,haveson,AdminPage_Index,AdminPage,TypeFlag,Type_id_PublishType,Language,Language_ids,ShowMode,IsLanguages,Supplier_id)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Sort,@Code,@parentid,@SEO_Title,@SEO_Keywords,@SEO_Description,@target,@url,@haveson,@AdminPage_Index,@AdminPage,@TypeFlag,@Type_id_PublishType,@Language,@Language_ids,@ShowMode,@IsLanguages,@Supplier_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@parentid", model.parentid),
					new SqlParameter("@SEO_Title", model.SEO_Title),
					new SqlParameter("@SEO_Keywords", model.SEO_Keywords),
					new SqlParameter("@SEO_Description", model.SEO_Description),
					new SqlParameter("@target", model.target),
					new SqlParameter("@url", model.url),
					new SqlParameter("@haveson", model.haveson),
					new SqlParameter("@AdminPage_Index", model.AdminPage_Index),
					new SqlParameter("@AdminPage", model.AdminPage),
					new SqlParameter("@TypeFlag", model.TypeFlag),
					new SqlParameter("@Type_id_PublishType", model.Type_id_PublishType),
					new SqlParameter("@Language", model.Language),
					new SqlParameter("@Language_ids", model.Language_ids),
					new SqlParameter("@ShowMode", model.ShowMode),
					new SqlParameter("@IsLanguages", model.IsLanguages),
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
		public void Update(Lebi_Node model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Node] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Code= @Code,");
			strSql.Append("parentid= @parentid,");
			strSql.Append("SEO_Title= @SEO_Title,");
			strSql.Append("SEO_Keywords= @SEO_Keywords,");
			strSql.Append("SEO_Description= @SEO_Description,");
			strSql.Append("target= @target,");
			strSql.Append("url= @url,");
			strSql.Append("haveson= @haveson,");
			strSql.Append("AdminPage_Index= @AdminPage_Index,");
			strSql.Append("AdminPage= @AdminPage,");
			strSql.Append("TypeFlag= @TypeFlag,");
			strSql.Append("Type_id_PublishType= @Type_id_PublishType,");
			strSql.Append("Language= @Language,");
			strSql.Append("Language_ids= @Language_ids,");
			strSql.Append("ShowMode= @ShowMode,");
			strSql.Append("IsLanguages= @IsLanguages,");
			strSql.Append("Supplier_id= @Supplier_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,2000),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@SEO_Title", SqlDbType.NVarChar,4000),
					new SqlParameter("@SEO_Keywords", SqlDbType.NVarChar,4000),
					new SqlParameter("@SEO_Description", SqlDbType.NVarChar,4000),
					new SqlParameter("@target", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,200),
					new SqlParameter("@haveson", SqlDbType.Int,4),
					new SqlParameter("@AdminPage_Index", SqlDbType.NVarChar,200),
					new SqlParameter("@AdminPage", SqlDbType.NVarChar,200),
					new SqlParameter("@TypeFlag", SqlDbType.Int,4),
					new SqlParameter("@Type_id_PublishType", SqlDbType.Int,4),
					new SqlParameter("@Language", SqlDbType.NVarChar,100),
					new SqlParameter("@Language_ids", SqlDbType.NVarChar,100),
					new SqlParameter("@ShowMode", SqlDbType.NVarChar,50),
					new SqlParameter("@IsLanguages", SqlDbType.Int,4),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Sort;
			parameters[3].Value = model.Code;
			parameters[4].Value = model.parentid;
			parameters[5].Value = model.SEO_Title;
			parameters[6].Value = model.SEO_Keywords;
			parameters[7].Value = model.SEO_Description;
			parameters[8].Value = model.target;
			parameters[9].Value = model.url;
			parameters[10].Value = model.haveson;
			parameters[11].Value = model.AdminPage_Index;
			parameters[12].Value = model.AdminPage;
			parameters[13].Value = model.TypeFlag;
			parameters[14].Value = model.Type_id_PublishType;
			parameters[15].Value = model.Language;
			parameters[16].Value = model.Language_ids;
			parameters[17].Value = model.ShowMode;
			parameters[18].Value = model.IsLanguages;
			parameters[19].Value = model.Supplier_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Node] ");
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
			strSql.Append("delete from [Lebi_Node] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Node] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Node GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Node] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Node model=new Lebi_Node();
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
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.target=ds.Tables[0].Rows[0]["target"].ToString();
				model.url=ds.Tables[0].Rows[0]["url"].ToString();
				if(ds.Tables[0].Rows[0]["haveson"].ToString()!="")
				{
					model.haveson=int.Parse(ds.Tables[0].Rows[0]["haveson"].ToString());
				}
				model.AdminPage_Index=ds.Tables[0].Rows[0]["AdminPage_Index"].ToString();
				model.AdminPage=ds.Tables[0].Rows[0]["AdminPage"].ToString();
				if(ds.Tables[0].Rows[0]["TypeFlag"].ToString()!="")
				{
					model.TypeFlag=int.Parse(ds.Tables[0].Rows[0]["TypeFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString()!="")
				{
					model.Type_id_PublishType=int.Parse(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				model.ShowMode=ds.Tables[0].Rows[0]["ShowMode"].ToString();
				if(ds.Tables[0].Rows[0]["IsLanguages"].ToString()!="")
				{
					model.IsLanguages=int.Parse(ds.Tables[0].Rows[0]["IsLanguages"].ToString());
				}
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
		public Lebi_Node GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Node] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Node model=new Lebi_Node();
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
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.target=ds.Tables[0].Rows[0]["target"].ToString();
				model.url=ds.Tables[0].Rows[0]["url"].ToString();
				if(ds.Tables[0].Rows[0]["haveson"].ToString()!="")
				{
					model.haveson=int.Parse(ds.Tables[0].Rows[0]["haveson"].ToString());
				}
				model.AdminPage_Index=ds.Tables[0].Rows[0]["AdminPage_Index"].ToString();
				model.AdminPage=ds.Tables[0].Rows[0]["AdminPage"].ToString();
				if(ds.Tables[0].Rows[0]["TypeFlag"].ToString()!="")
				{
					model.TypeFlag=int.Parse(ds.Tables[0].Rows[0]["TypeFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString()!="")
				{
					model.Type_id_PublishType=int.Parse(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				model.ShowMode=ds.Tables[0].Rows[0]["ShowMode"].ToString();
				if(ds.Tables[0].Rows[0]["IsLanguages"].ToString()!="")
				{
					model.IsLanguages=int.Parse(ds.Tables[0].Rows[0]["IsLanguages"].ToString());
				}
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
		public Lebi_Node GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Node] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Node model=new Lebi_Node();
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
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.target=ds.Tables[0].Rows[0]["target"].ToString();
				model.url=ds.Tables[0].Rows[0]["url"].ToString();
				if(ds.Tables[0].Rows[0]["haveson"].ToString()!="")
				{
					model.haveson=int.Parse(ds.Tables[0].Rows[0]["haveson"].ToString());
				}
				model.AdminPage_Index=ds.Tables[0].Rows[0]["AdminPage_Index"].ToString();
				model.AdminPage=ds.Tables[0].Rows[0]["AdminPage"].ToString();
				if(ds.Tables[0].Rows[0]["TypeFlag"].ToString()!="")
				{
					model.TypeFlag=int.Parse(ds.Tables[0].Rows[0]["TypeFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString()!="")
				{
					model.Type_id_PublishType=int.Parse(ds.Tables[0].Rows[0]["Type_id_PublishType"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				model.ShowMode=ds.Tables[0].Rows[0]["ShowMode"].ToString();
				if(ds.Tables[0].Rows[0]["IsLanguages"].ToString()!="")
				{
					model.IsLanguages=int.Parse(ds.Tables[0].Rows[0]["IsLanguages"].ToString());
				}
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
		public List<Lebi_Node> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Node]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Node> list = new List<Lebi_Node>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Node> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Node]";
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
			List<Lebi_Node> list = new List<Lebi_Node>();
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
		public List<Lebi_Node> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Node] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Node> list = new List<Lebi_Node>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Node> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Node]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Node> list = new List<Lebi_Node>();
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
		public Lebi_Node BindForm(Lebi_Node model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
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
			if (HttpContext.Current.Request["haveson"] != null)
				model.haveson=Shop.Tools.RequestTool.RequestInt("haveson",0);
			if (HttpContext.Current.Request["AdminPage_Index"] != null)
				model.AdminPage_Index=Shop.Tools.RequestTool.RequestString("AdminPage_Index");
			if (HttpContext.Current.Request["AdminPage"] != null)
				model.AdminPage=Shop.Tools.RequestTool.RequestString("AdminPage");
			if (HttpContext.Current.Request["TypeFlag"] != null)
				model.TypeFlag=Shop.Tools.RequestTool.RequestInt("TypeFlag",0);
			if (HttpContext.Current.Request["Type_id_PublishType"] != null)
				model.Type_id_PublishType=Shop.Tools.RequestTool.RequestInt("Type_id_PublishType",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
			if (HttpContext.Current.Request["ShowMode"] != null)
				model.ShowMode=Shop.Tools.RequestTool.RequestString("ShowMode");
			if (HttpContext.Current.Request["IsLanguages"] != null)
				model.IsLanguages=Shop.Tools.RequestTool.RequestInt("IsLanguages",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Node SafeBindForm(Lebi_Node model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
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
			if (HttpContext.Current.Request["haveson"] != null)
				model.haveson=Shop.Tools.RequestTool.RequestInt("haveson",0);
			if (HttpContext.Current.Request["AdminPage_Index"] != null)
				model.AdminPage_Index=Shop.Tools.RequestTool.RequestSafeString("AdminPage_Index");
			if (HttpContext.Current.Request["AdminPage"] != null)
				model.AdminPage=Shop.Tools.RequestTool.RequestSafeString("AdminPage");
			if (HttpContext.Current.Request["TypeFlag"] != null)
				model.TypeFlag=Shop.Tools.RequestTool.RequestInt("TypeFlag",0);
			if (HttpContext.Current.Request["Type_id_PublishType"] != null)
				model.Type_id_PublishType=Shop.Tools.RequestTool.RequestInt("Type_id_PublishType",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
			if (HttpContext.Current.Request["ShowMode"] != null)
				model.ShowMode=Shop.Tools.RequestTool.RequestSafeString("ShowMode");
			if (HttpContext.Current.Request["IsLanguages"] != null)
				model.IsLanguages=Shop.Tools.RequestTool.RequestInt("IsLanguages",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Node ReaderBind(IDataReader dataReader)
		{
			Lebi_Node model=new Lebi_Node();
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
			ojb = dataReader["parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentid=(int)ojb;
			}
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			model.target=dataReader["target"].ToString();
			model.url=dataReader["url"].ToString();
			ojb = dataReader["haveson"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.haveson=(int)ojb;
			}
			model.AdminPage_Index=dataReader["AdminPage_Index"].ToString();
			model.AdminPage=dataReader["AdminPage"].ToString();
			ojb = dataReader["TypeFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TypeFlag=(int)ojb;
			}
			ojb = dataReader["Type_id_PublishType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_PublishType=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			model.Language_ids=dataReader["Language_ids"].ToString();
			model.ShowMode=dataReader["ShowMode"].ToString();
			ojb = dataReader["IsLanguages"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsLanguages=(int)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Node : Lebi_Node_interface
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
				strSql.Append("select " + colName + " from [Lebi_Node]");
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
			strSql.Append("select  "+colName+" from [Lebi_Node]");
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
			strSql.Append("select count(*) from [Lebi_Node]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Node]");
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
			strSql.Append("select max(id) from [Lebi_Node]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Node]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Node model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Node](");
			strSql.Append("[Name],[Sort],[Code],[parentid],[SEO_Title],[SEO_Keywords],[SEO_Description],[target],[url],[haveson],[AdminPage_Index],[AdminPage],[TypeFlag],[Type_id_PublishType],[Language],[Language_ids],[ShowMode],[IsLanguages],[Supplier_id])");
			strSql.Append(" values (");
			strSql.Append("@Name,@Sort,@Code,@parentid,@SEO_Title,@SEO_Keywords,@SEO_Description,@target,@url,@haveson,@AdminPage_Index,@AdminPage,@TypeFlag,@Type_id_PublishType,@Language,@Language_ids,@ShowMode,@IsLanguages,@Supplier_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@parentid", model.parentid),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@target", model.target),
					new OleDbParameter("@url", model.url),
					new OleDbParameter("@haveson", model.haveson),
					new OleDbParameter("@AdminPage_Index", model.AdminPage_Index),
					new OleDbParameter("@AdminPage", model.AdminPage),
					new OleDbParameter("@TypeFlag", model.TypeFlag),
					new OleDbParameter("@Type_id_PublishType", model.Type_id_PublishType),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Language_ids", model.Language_ids),
					new OleDbParameter("@ShowMode", model.ShowMode),
					new OleDbParameter("@IsLanguages", model.IsLanguages),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Node model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Node] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[parentid]=@parentid,");
			strSql.Append("[SEO_Title]=@SEO_Title,");
			strSql.Append("[SEO_Keywords]=@SEO_Keywords,");
			strSql.Append("[SEO_Description]=@SEO_Description,");
			strSql.Append("[target]=@target,");
			strSql.Append("[url]=@url,");
			strSql.Append("[haveson]=@haveson,");
			strSql.Append("[AdminPage_Index]=@AdminPage_Index,");
			strSql.Append("[AdminPage]=@AdminPage,");
			strSql.Append("[TypeFlag]=@TypeFlag,");
			strSql.Append("[Type_id_PublishType]=@Type_id_PublishType,");
			strSql.Append("[Language]=@Language,");
			strSql.Append("[Language_ids]=@Language_ids,");
			strSql.Append("[ShowMode]=@ShowMode,");
			strSql.Append("[IsLanguages]=@IsLanguages,");
			strSql.Append("[Supplier_id]=@Supplier_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@parentid", model.parentid),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@target", model.target),
					new OleDbParameter("@url", model.url),
					new OleDbParameter("@haveson", model.haveson),
					new OleDbParameter("@AdminPage_Index", model.AdminPage_Index),
					new OleDbParameter("@AdminPage", model.AdminPage),
					new OleDbParameter("@TypeFlag", model.TypeFlag),
					new OleDbParameter("@Type_id_PublishType", model.Type_id_PublishType),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Language_ids", model.Language_ids),
					new OleDbParameter("@ShowMode", model.ShowMode),
					new OleDbParameter("@IsLanguages", model.IsLanguages),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Node] ");
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
			strSql.Append("delete from [Lebi_Node] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Node] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Node GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Node] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Node model;
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
		public Lebi_Node GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Node] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Node model;
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
		public Lebi_Node GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Node] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Node model;
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
		public List<Lebi_Node> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Node]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Node> list = new List<Lebi_Node>();
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
		public List<Lebi_Node> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Node]";
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
			List<Lebi_Node> list = new List<Lebi_Node>();
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
		public List<Lebi_Node> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Node] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Node> list = new List<Lebi_Node>();
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
		public List<Lebi_Node> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Node]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Node> list = new List<Lebi_Node>();
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
		public Lebi_Node BindForm(Lebi_Node model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
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
			if (HttpContext.Current.Request["haveson"] != null)
				model.haveson=Shop.Tools.RequestTool.RequestInt("haveson",0);
			if (HttpContext.Current.Request["AdminPage_Index"] != null)
				model.AdminPage_Index=Shop.Tools.RequestTool.RequestString("AdminPage_Index");
			if (HttpContext.Current.Request["AdminPage"] != null)
				model.AdminPage=Shop.Tools.RequestTool.RequestString("AdminPage");
			if (HttpContext.Current.Request["TypeFlag"] != null)
				model.TypeFlag=Shop.Tools.RequestTool.RequestInt("TypeFlag",0);
			if (HttpContext.Current.Request["Type_id_PublishType"] != null)
				model.Type_id_PublishType=Shop.Tools.RequestTool.RequestInt("Type_id_PublishType",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
			if (HttpContext.Current.Request["ShowMode"] != null)
				model.ShowMode=Shop.Tools.RequestTool.RequestString("ShowMode");
			if (HttpContext.Current.Request["IsLanguages"] != null)
				model.IsLanguages=Shop.Tools.RequestTool.RequestInt("IsLanguages",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Node SafeBindForm(Lebi_Node model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
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
			if (HttpContext.Current.Request["haveson"] != null)
				model.haveson=Shop.Tools.RequestTool.RequestInt("haveson",0);
			if (HttpContext.Current.Request["AdminPage_Index"] != null)
				model.AdminPage_Index=Shop.Tools.RequestTool.RequestSafeString("AdminPage_Index");
			if (HttpContext.Current.Request["AdminPage"] != null)
				model.AdminPage=Shop.Tools.RequestTool.RequestSafeString("AdminPage");
			if (HttpContext.Current.Request["TypeFlag"] != null)
				model.TypeFlag=Shop.Tools.RequestTool.RequestInt("TypeFlag",0);
			if (HttpContext.Current.Request["Type_id_PublishType"] != null)
				model.Type_id_PublishType=Shop.Tools.RequestTool.RequestInt("Type_id_PublishType",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
			if (HttpContext.Current.Request["ShowMode"] != null)
				model.ShowMode=Shop.Tools.RequestTool.RequestSafeString("ShowMode");
			if (HttpContext.Current.Request["IsLanguages"] != null)
				model.IsLanguages=Shop.Tools.RequestTool.RequestInt("IsLanguages",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Node ReaderBind(IDataReader dataReader)
		{
			Lebi_Node model=new Lebi_Node();
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
			ojb = dataReader["parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentid=(int)ojb;
			}
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			model.target=dataReader["target"].ToString();
			model.url=dataReader["url"].ToString();
			ojb = dataReader["haveson"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.haveson=(int)ojb;
			}
			model.AdminPage_Index=dataReader["AdminPage_Index"].ToString();
			model.AdminPage=dataReader["AdminPage"].ToString();
			ojb = dataReader["TypeFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TypeFlag=(int)ojb;
			}
			ojb = dataReader["Type_id_PublishType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_PublishType=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			model.Language_ids=dataReader["Language_ids"].ToString();
			model.ShowMode=dataReader["ShowMode"].ToString();
			ojb = dataReader["IsLanguages"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsLanguages=(int)ojb;
			}
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

