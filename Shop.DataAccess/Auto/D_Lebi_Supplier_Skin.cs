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

	public interface Lebi_Supplier_Skin_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Supplier_Skin model);
		void Update(Lebi_Supplier_Skin model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Supplier_Skin GetModel(int id);
		Lebi_Supplier_Skin GetModel(string strWhere);
		Lebi_Supplier_Skin GetModel(SQLPara para);
		List<Lebi_Supplier_Skin> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Supplier_Skin> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Supplier_Skin> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Supplier_Skin> GetList(SQLPara para);
		Lebi_Supplier_Skin BindForm(Lebi_Supplier_Skin model);
		Lebi_Supplier_Skin SafeBindForm(Lebi_Supplier_Skin model);
		Lebi_Supplier_Skin ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Supplier_Skin。
	/// </summary>
	public class D_Lebi_Supplier_Skin
	{
		static Lebi_Supplier_Skin_interface _Instance;
		public static Lebi_Supplier_Skin_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Supplier_Skin();
		            else
		                _Instance = new sqlserver_Lebi_Supplier_Skin();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Supplier_Skin()
		{}
		#region  成员方法
	class sqlserver_Lebi_Supplier_Skin : Lebi_Supplier_Skin_interface
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
				strSql.Append("select " + colName + " from [Lebi_Supplier_Skin]");
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
			strSql.Append("select  "+colName+" from [Lebi_Supplier_Skin]");
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
			strSql.Append("select count(1) from [Lebi_Supplier_Skin]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_Skin]");
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
			strSql.Append("select max(id) from [Lebi_Supplier_Skin]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_Skin]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier_Skin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier_Skin](");
			strSql.Append("type,Path,Sort,head,shortbar,longbar,Image,Name,IsShow,IsPublic)");
			strSql.Append(" values (");
			strSql.Append("@type,@Path,@Sort,@head,@shortbar,@longbar,@Image,@Name,@IsShow,@IsPublic)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@type", model.type),
					new SqlParameter("@Path", model.Path),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@head", model.head),
					new SqlParameter("@shortbar", model.shortbar),
					new SqlParameter("@longbar", model.longbar),
					new SqlParameter("@Image", model.Image),
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@IsShow", model.IsShow),
					new SqlParameter("@IsPublic", model.IsPublic)};

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
		public void Update(Lebi_Supplier_Skin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier_Skin] set ");
			strSql.Append("type= @type,");
			strSql.Append("Path= @Path,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("head= @head,");
			strSql.Append("shortbar= @shortbar,");
			strSql.Append("longbar= @longbar,");
			strSql.Append("Image= @Image,");
			strSql.Append("Name= @Name,");
			strSql.Append("IsShow= @IsShow,");
			strSql.Append("IsPublic= @IsPublic");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@Path", SqlDbType.NVarChar,200),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@head", SqlDbType.NText),
					new SqlParameter("@shortbar", SqlDbType.NVarChar,2000),
					new SqlParameter("@longbar", SqlDbType.NVarChar,2000),
					new SqlParameter("@Image", SqlDbType.NVarChar,200),
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@IsPublic", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.type;
			parameters[2].Value = model.Path;
			parameters[3].Value = model.Sort;
			parameters[4].Value = model.head;
			parameters[5].Value = model.shortbar;
			parameters[6].Value = model.longbar;
			parameters[7].Value = model.Image;
			parameters[8].Value = model.Name;
			parameters[9].Value = model.IsShow;
			parameters[10].Value = model.IsPublic;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Skin] ");
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
			strSql.Append("delete from [Lebi_Supplier_Skin] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Skin] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier_Skin GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Skin] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Supplier_Skin model=new Lebi_Supplier_Skin();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.head=ds.Tables[0].Rows[0]["head"].ToString();
				model.shortbar=ds.Tables[0].Rows[0]["shortbar"].ToString();
				model.longbar=ds.Tables[0].Rows[0]["longbar"].ToString();
				model.Image=ds.Tables[0].Rows[0]["Image"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPublic"].ToString()!="")
				{
					model.IsPublic=int.Parse(ds.Tables[0].Rows[0]["IsPublic"].ToString());
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
		public Lebi_Supplier_Skin GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Skin] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier_Skin model=new Lebi_Supplier_Skin();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.head=ds.Tables[0].Rows[0]["head"].ToString();
				model.shortbar=ds.Tables[0].Rows[0]["shortbar"].ToString();
				model.longbar=ds.Tables[0].Rows[0]["longbar"].ToString();
				model.Image=ds.Tables[0].Rows[0]["Image"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPublic"].ToString()!="")
				{
					model.IsPublic=int.Parse(ds.Tables[0].Rows[0]["IsPublic"].ToString());
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
		public Lebi_Supplier_Skin GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier_Skin] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier_Skin model=new Lebi_Supplier_Skin();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.head=ds.Tables[0].Rows[0]["head"].ToString();
				model.shortbar=ds.Tables[0].Rows[0]["shortbar"].ToString();
				model.longbar=ds.Tables[0].Rows[0]["longbar"].ToString();
				model.Image=ds.Tables[0].Rows[0]["Image"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPublic"].ToString()!="")
				{
					model.IsPublic=int.Parse(ds.Tables[0].Rows[0]["IsPublic"].ToString());
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
		public List<Lebi_Supplier_Skin> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier_Skin]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier_Skin> list = new List<Lebi_Supplier_Skin>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Supplier_Skin> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier_Skin]";
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
			List<Lebi_Supplier_Skin> list = new List<Lebi_Supplier_Skin>();
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
		public List<Lebi_Supplier_Skin> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier_Skin] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier_Skin> list = new List<Lebi_Supplier_Skin>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Supplier_Skin> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier_Skin]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_Skin> list = new List<Lebi_Supplier_Skin>();
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
		public Lebi_Supplier_Skin BindForm(Lebi_Supplier_Skin model)
		{
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestString("type");
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestString("Path");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["head"] != null)
				model.head=Shop.Tools.RequestTool.RequestString("head");
			if (HttpContext.Current.Request["shortbar"] != null)
				model.shortbar=Shop.Tools.RequestTool.RequestString("shortbar");
			if (HttpContext.Current.Request["longbar"] != null)
				model.longbar=Shop.Tools.RequestTool.RequestString("longbar");
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestString("Image");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["IsPublic"] != null)
				model.IsPublic=Shop.Tools.RequestTool.RequestInt("IsPublic",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier_Skin SafeBindForm(Lebi_Supplier_Skin model)
		{
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestSafeString("type");
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestSafeString("Path");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["head"] != null)
				model.head=Shop.Tools.RequestTool.RequestSafeString("head");
			if (HttpContext.Current.Request["shortbar"] != null)
				model.shortbar=Shop.Tools.RequestTool.RequestSafeString("shortbar");
			if (HttpContext.Current.Request["longbar"] != null)
				model.longbar=Shop.Tools.RequestTool.RequestSafeString("longbar");
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestSafeString("Image");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["IsPublic"] != null)
				model.IsPublic=Shop.Tools.RequestTool.RequestInt("IsPublic",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier_Skin ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier_Skin model=new Lebi_Supplier_Skin();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.type=dataReader["type"].ToString();
			model.Path=dataReader["Path"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			model.head=dataReader["head"].ToString();
			model.shortbar=dataReader["shortbar"].ToString();
			model.longbar=dataReader["longbar"].ToString();
			model.Image=dataReader["Image"].ToString();
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(int)ojb;
			}
			ojb = dataReader["IsPublic"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPublic=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Supplier_Skin : Lebi_Supplier_Skin_interface
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
				strSql.Append("select " + colName + " from [Lebi_Supplier_Skin]");
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
			strSql.Append("select  "+colName+" from [Lebi_Supplier_Skin]");
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
			strSql.Append("select count(*) from [Lebi_Supplier_Skin]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Supplier_Skin]");
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
			strSql.Append("select max(id) from [Lebi_Supplier_Skin]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_Skin]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier_Skin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier_Skin](");
			strSql.Append("[type],[Path],[Sort],[head],[shortbar],[longbar],[Image],[Name],[IsShow],[IsPublic])");
			strSql.Append(" values (");
			strSql.Append("@type,@Path,@Sort,@head,@shortbar,@longbar,@Image,@Name,@IsShow,@IsPublic)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@type", model.type),
					new OleDbParameter("@Path", model.Path),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@head", model.head),
					new OleDbParameter("@shortbar", model.shortbar),
					new OleDbParameter("@longbar", model.longbar),
					new OleDbParameter("@Image", model.Image),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@IsShow", model.IsShow),
					new OleDbParameter("@IsPublic", model.IsPublic)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Supplier_Skin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier_Skin] set ");
			strSql.Append("[type]=@type,");
			strSql.Append("[Path]=@Path,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[head]=@head,");
			strSql.Append("[shortbar]=@shortbar,");
			strSql.Append("[longbar]=@longbar,");
			strSql.Append("[Image]=@Image,");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[IsShow]=@IsShow,");
			strSql.Append("[IsPublic]=@IsPublic");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@type", model.type),
					new OleDbParameter("@Path", model.Path),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@head", model.head),
					new OleDbParameter("@shortbar", model.shortbar),
					new OleDbParameter("@longbar", model.longbar),
					new OleDbParameter("@Image", model.Image),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@IsShow", model.IsShow),
					new OleDbParameter("@IsPublic", model.IsPublic)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Skin] ");
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
			strSql.Append("delete from [Lebi_Supplier_Skin] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Skin] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier_Skin GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Skin] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Supplier_Skin model;
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
		public Lebi_Supplier_Skin GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Skin] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier_Skin model;
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
		public Lebi_Supplier_Skin GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier_Skin] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier_Skin model;
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
		public List<Lebi_Supplier_Skin> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier_Skin]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier_Skin> list = new List<Lebi_Supplier_Skin>();
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
		public List<Lebi_Supplier_Skin> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier_Skin]";
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
			List<Lebi_Supplier_Skin> list = new List<Lebi_Supplier_Skin>();
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
		public List<Lebi_Supplier_Skin> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier_Skin] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier_Skin> list = new List<Lebi_Supplier_Skin>();
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
		public List<Lebi_Supplier_Skin> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier_Skin]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_Skin> list = new List<Lebi_Supplier_Skin>();
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
		public Lebi_Supplier_Skin BindForm(Lebi_Supplier_Skin model)
		{
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestString("type");
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestString("Path");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["head"] != null)
				model.head=Shop.Tools.RequestTool.RequestString("head");
			if (HttpContext.Current.Request["shortbar"] != null)
				model.shortbar=Shop.Tools.RequestTool.RequestString("shortbar");
			if (HttpContext.Current.Request["longbar"] != null)
				model.longbar=Shop.Tools.RequestTool.RequestString("longbar");
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestString("Image");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["IsPublic"] != null)
				model.IsPublic=Shop.Tools.RequestTool.RequestInt("IsPublic",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier_Skin SafeBindForm(Lebi_Supplier_Skin model)
		{
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestSafeString("type");
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestSafeString("Path");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["head"] != null)
				model.head=Shop.Tools.RequestTool.RequestSafeString("head");
			if (HttpContext.Current.Request["shortbar"] != null)
				model.shortbar=Shop.Tools.RequestTool.RequestSafeString("shortbar");
			if (HttpContext.Current.Request["longbar"] != null)
				model.longbar=Shop.Tools.RequestTool.RequestSafeString("longbar");
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestSafeString("Image");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["IsPublic"] != null)
				model.IsPublic=Shop.Tools.RequestTool.RequestInt("IsPublic",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier_Skin ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier_Skin model=new Lebi_Supplier_Skin();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.type=dataReader["type"].ToString();
			model.Path=dataReader["Path"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			model.head=dataReader["head"].ToString();
			model.shortbar=dataReader["shortbar"].ToString();
			model.longbar=dataReader["longbar"].ToString();
			model.Image=dataReader["Image"].ToString();
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(int)ojb;
			}
			ojb = dataReader["IsPublic"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPublic=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

