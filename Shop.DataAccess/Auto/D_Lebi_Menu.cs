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

	public interface Lebi_Menu_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Menu model);
		void Update(Lebi_Menu model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Menu GetModel(int id);
		Lebi_Menu GetModel(string strWhere);
		Lebi_Menu GetModel(SQLPara para);
		List<Lebi_Menu> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Menu> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Menu> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Menu> GetList(SQLPara para);
		Lebi_Menu BindForm(Lebi_Menu model);
		Lebi_Menu SafeBindForm(Lebi_Menu model);
		Lebi_Menu ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Menu。
	/// </summary>
	public class D_Lebi_Menu
	{
		static Lebi_Menu_interface _Instance;
		public static Lebi_Menu_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Menu();
		            else
		                _Instance = new sqlserver_Lebi_Menu();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Menu()
		{}
		#region  成员方法
	class sqlserver_Lebi_Menu : Lebi_Menu_interface
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
				strSql.Append("select " + colName + " from [Lebi_Menu]");
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
			strSql.Append("select  "+colName+" from [Lebi_Menu]");
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
			strSql.Append("select count(1) from [Lebi_Menu]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Menu]");
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
			strSql.Append("select max(id) from [Lebi_Menu]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Menu]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Menu](");
			strSql.Append("Name,URL,Sort,parentid,Isshow,Image,Code,IsSYS,parentCode)");
			strSql.Append(" values (");
			strSql.Append("@Name,@URL,@Sort,@parentid,@Isshow,@Image,@Code,@IsSYS,@parentCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@URL", model.URL),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@parentid", model.parentid),
					new SqlParameter("@Isshow", model.Isshow),
					new SqlParameter("@Image", model.Image),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@IsSYS", model.IsSYS),
					new SqlParameter("@parentCode", model.parentCode)};

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
		public void Update(Lebi_Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Menu] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("URL= @URL,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("parentid= @parentid,");
			strSql.Append("Isshow= @Isshow,");
			strSql.Append("Image= @Image,");
			strSql.Append("Code= @Code,");
			strSql.Append("IsSYS= @IsSYS,");
			strSql.Append("parentCode= @parentCode");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@URL", SqlDbType.NVarChar,500),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@Isshow", SqlDbType.Int,4),
					new SqlParameter("@Image", SqlDbType.NVarChar,100),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@IsSYS", SqlDbType.Int,4),
					new SqlParameter("@parentCode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.URL;
			parameters[3].Value = model.Sort;
			parameters[4].Value = model.parentid;
			parameters[5].Value = model.Isshow;
			parameters[6].Value = model.Image;
			parameters[7].Value = model.Code;
			parameters[8].Value = model.IsSYS;
			parameters[9].Value = model.parentCode;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Menu] ");
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
			strSql.Append("delete from [Lebi_Menu] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Menu] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Menu GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Menu] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Menu model=new Lebi_Menu();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Isshow"].ToString()!="")
				{
					model.Isshow=int.Parse(ds.Tables[0].Rows[0]["Isshow"].ToString());
				}
				model.Image=ds.Tables[0].Rows[0]["Image"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["IsSYS"].ToString()!="")
				{
					model.IsSYS=int.Parse(ds.Tables[0].Rows[0]["IsSYS"].ToString());
				}
				model.parentCode=ds.Tables[0].Rows[0]["parentCode"].ToString();
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
		public Lebi_Menu GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Menu] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Menu model=new Lebi_Menu();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Isshow"].ToString()!="")
				{
					model.Isshow=int.Parse(ds.Tables[0].Rows[0]["Isshow"].ToString());
				}
				model.Image=ds.Tables[0].Rows[0]["Image"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["IsSYS"].ToString()!="")
				{
					model.IsSYS=int.Parse(ds.Tables[0].Rows[0]["IsSYS"].ToString());
				}
				model.parentCode=ds.Tables[0].Rows[0]["parentCode"].ToString();
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
		public Lebi_Menu GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Menu] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Menu model=new Lebi_Menu();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Isshow"].ToString()!="")
				{
					model.Isshow=int.Parse(ds.Tables[0].Rows[0]["Isshow"].ToString());
				}
				model.Image=ds.Tables[0].Rows[0]["Image"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["IsSYS"].ToString()!="")
				{
					model.IsSYS=int.Parse(ds.Tables[0].Rows[0]["IsSYS"].ToString());
				}
				model.parentCode=ds.Tables[0].Rows[0]["parentCode"].ToString();
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
		public List<Lebi_Menu> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Menu]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Menu> list = new List<Lebi_Menu>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Menu> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Menu]";
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
			List<Lebi_Menu> list = new List<Lebi_Menu>();
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
		public List<Lebi_Menu> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Menu] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Menu> list = new List<Lebi_Menu>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Menu> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Menu]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Menu> list = new List<Lebi_Menu>();
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
		public Lebi_Menu BindForm(Lebi_Menu model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestString("URL");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["Isshow"] != null)
				model.Isshow=Shop.Tools.RequestTool.RequestInt("Isshow",0);
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestString("Image");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["IsSYS"] != null)
				model.IsSYS=Shop.Tools.RequestTool.RequestInt("IsSYS",0);
			if (HttpContext.Current.Request["parentCode"] != null)
				model.parentCode=Shop.Tools.RequestTool.RequestString("parentCode");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Menu SafeBindForm(Lebi_Menu model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestSafeString("URL");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["Isshow"] != null)
				model.Isshow=Shop.Tools.RequestTool.RequestInt("Isshow",0);
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestSafeString("Image");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["IsSYS"] != null)
				model.IsSYS=Shop.Tools.RequestTool.RequestInt("IsSYS",0);
			if (HttpContext.Current.Request["parentCode"] != null)
				model.parentCode=Shop.Tools.RequestTool.RequestSafeString("parentCode");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Menu ReaderBind(IDataReader dataReader)
		{
			Lebi_Menu model=new Lebi_Menu();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.URL=dataReader["URL"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentid=(int)ojb;
			}
			ojb = dataReader["Isshow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isshow=(int)ojb;
			}
			model.Image=dataReader["Image"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["IsSYS"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSYS=(int)ojb;
			}
			model.parentCode=dataReader["parentCode"].ToString();
			return model;
		}

	}
	class access_Lebi_Menu : Lebi_Menu_interface
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
				strSql.Append("select " + colName + " from [Lebi_Menu]");
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
			strSql.Append("select  "+colName+" from [Lebi_Menu]");
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
			strSql.Append("select count(*) from [Lebi_Menu]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Menu]");
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
			strSql.Append("select max(id) from [Lebi_Menu]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Menu]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Menu](");
			strSql.Append("[Name],[URL],[Sort],[parentid],[Isshow],[Image],[Code],[IsSYS],[parentCode])");
			strSql.Append(" values (");
			strSql.Append("@Name,@URL,@Sort,@parentid,@Isshow,@Image,@Code,@IsSYS,@parentCode)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@URL", model.URL),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@parentid", model.parentid),
					new OleDbParameter("@Isshow", model.Isshow),
					new OleDbParameter("@Image", model.Image),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@IsSYS", model.IsSYS),
					new OleDbParameter("@parentCode", model.parentCode)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Menu] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[URL]=@URL,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[parentid]=@parentid,");
			strSql.Append("[Isshow]=@Isshow,");
			strSql.Append("[Image]=@Image,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[IsSYS]=@IsSYS,");
			strSql.Append("[parentCode]=@parentCode");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@URL", model.URL),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@parentid", model.parentid),
					new OleDbParameter("@Isshow", model.Isshow),
					new OleDbParameter("@Image", model.Image),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@IsSYS", model.IsSYS),
					new OleDbParameter("@parentCode", model.parentCode)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Menu] ");
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
			strSql.Append("delete from [Lebi_Menu] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Menu] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Menu GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Menu] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Menu model;
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
		public Lebi_Menu GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Menu] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Menu model;
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
		public Lebi_Menu GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Menu] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Menu model;
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
		public List<Lebi_Menu> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Menu]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Menu> list = new List<Lebi_Menu>();
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
		public List<Lebi_Menu> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Menu]";
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
			List<Lebi_Menu> list = new List<Lebi_Menu>();
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
		public List<Lebi_Menu> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Menu] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Menu> list = new List<Lebi_Menu>();
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
		public List<Lebi_Menu> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Menu]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Menu> list = new List<Lebi_Menu>();
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
		public Lebi_Menu BindForm(Lebi_Menu model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestString("URL");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["Isshow"] != null)
				model.Isshow=Shop.Tools.RequestTool.RequestInt("Isshow",0);
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestString("Image");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["IsSYS"] != null)
				model.IsSYS=Shop.Tools.RequestTool.RequestInt("IsSYS",0);
			if (HttpContext.Current.Request["parentCode"] != null)
				model.parentCode=Shop.Tools.RequestTool.RequestString("parentCode");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Menu SafeBindForm(Lebi_Menu model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["URL"] != null)
				model.URL=Shop.Tools.RequestTool.RequestSafeString("URL");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["Isshow"] != null)
				model.Isshow=Shop.Tools.RequestTool.RequestInt("Isshow",0);
			if (HttpContext.Current.Request["Image"] != null)
				model.Image=Shop.Tools.RequestTool.RequestSafeString("Image");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["IsSYS"] != null)
				model.IsSYS=Shop.Tools.RequestTool.RequestInt("IsSYS",0);
			if (HttpContext.Current.Request["parentCode"] != null)
				model.parentCode=Shop.Tools.RequestTool.RequestSafeString("parentCode");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Menu ReaderBind(IDataReader dataReader)
		{
			Lebi_Menu model=new Lebi_Menu();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.URL=dataReader["URL"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentid=(int)ojb;
			}
			ojb = dataReader["Isshow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isshow=(int)ojb;
			}
			model.Image=dataReader["Image"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["IsSYS"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSYS=(int)ojb;
			}
			model.parentCode=dataReader["parentCode"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

