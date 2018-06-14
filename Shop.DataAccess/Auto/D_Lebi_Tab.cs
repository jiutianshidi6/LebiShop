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

	public interface Lebi_Tab_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Tab model);
		void Update(Lebi_Tab model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Tab GetModel(int id);
		Lebi_Tab GetModel(string strWhere);
		Lebi_Tab GetModel(SQLPara para);
		List<Lebi_Tab> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Tab> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Tab> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Tab> GetList(SQLPara para);
		Lebi_Tab BindForm(Lebi_Tab model);
		Lebi_Tab SafeBindForm(Lebi_Tab model);
		Lebi_Tab ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Tab。
	/// </summary>
	public class D_Lebi_Tab
	{
		static Lebi_Tab_interface _Instance;
		public static Lebi_Tab_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Tab();
		            else
		                _Instance = new sqlserver_Lebi_Tab();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Tab()
		{}
		#region  成员方法
	class sqlserver_Lebi_Tab : Lebi_Tab_interface
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
				strSql.Append("select " + colName + " from [Lebi_Tab]");
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
			strSql.Append("select  "+colName+" from [Lebi_Tab]");
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
			strSql.Append("select count(1) from [Lebi_Tab]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Tab]");
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
			strSql.Append("select max(id) from [Lebi_Tab]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Tab]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Tab model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Tab](");
			strSql.Append("Tname,Title,Tkey,Tdes,Tdirname,Tsort,Mode,Url,Description,Position)");
			strSql.Append(" values (");
			strSql.Append("@Tname,@Title,@Tkey,@Tdes,@Tdirname,@Tsort,@Mode,@Url,@Description,@Position)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Tname", model.Tname),
					new SqlParameter("@Title", model.Title),
					new SqlParameter("@Tkey", model.Tkey),
					new SqlParameter("@Tdes", model.Tdes),
					new SqlParameter("@Tdirname", model.Tdirname),
					new SqlParameter("@Tsort", model.Tsort),
					new SqlParameter("@Mode", model.Mode),
					new SqlParameter("@Url", model.Url),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@Position", model.Position)};

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
		public void Update(Lebi_Tab model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Tab] set ");
			strSql.Append("Tname= @Tname,");
			strSql.Append("Title= @Title,");
			strSql.Append("Tkey= @Tkey,");
			strSql.Append("Tdes= @Tdes,");
			strSql.Append("Tdirname= @Tdirname,");
			strSql.Append("Tsort= @Tsort,");
			strSql.Append("Mode= @Mode,");
			strSql.Append("Url= @Url,");
			strSql.Append("Description= @Description,");
			strSql.Append("Position= @Position");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Tname", SqlDbType.VarChar,1000),
					new SqlParameter("@Title", SqlDbType.VarChar,2000),
					new SqlParameter("@Tkey", SqlDbType.VarChar,4000),
					new SqlParameter("@Tdes", SqlDbType.VarChar,4000),
					new SqlParameter("@Tdirname", SqlDbType.VarChar,50),
					new SqlParameter("@Tsort", SqlDbType.Int,4),
					new SqlParameter("@Mode", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,2000),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@Position", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Tname;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Tkey;
			parameters[4].Value = model.Tdes;
			parameters[5].Value = model.Tdirname;
			parameters[6].Value = model.Tsort;
			parameters[7].Value = model.Mode;
			parameters[8].Value = model.Url;
			parameters[9].Value = model.Description;
			parameters[10].Value = model.Position;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Tab] ");
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
			strSql.Append("delete from [Lebi_Tab] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Tab] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Tab GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Tab] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Tab model=new Lebi_Tab();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Tname=ds.Tables[0].Rows[0]["Tname"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Tkey=ds.Tables[0].Rows[0]["Tkey"].ToString();
				model.Tdes=ds.Tables[0].Rows[0]["Tdes"].ToString();
				model.Tdirname=ds.Tables[0].Rows[0]["Tdirname"].ToString();
				if(ds.Tables[0].Rows[0]["Tsort"].ToString()!="")
				{
					model.Tsort=int.Parse(ds.Tables[0].Rows[0]["Tsort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Mode"].ToString()!="")
				{
					model.Mode=int.Parse(ds.Tables[0].Rows[0]["Mode"].ToString());
				}
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["Position"].ToString()!="")
				{
					model.Position=int.Parse(ds.Tables[0].Rows[0]["Position"].ToString());
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
		public Lebi_Tab GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Tab] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Tab model=new Lebi_Tab();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Tname=ds.Tables[0].Rows[0]["Tname"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Tkey=ds.Tables[0].Rows[0]["Tkey"].ToString();
				model.Tdes=ds.Tables[0].Rows[0]["Tdes"].ToString();
				model.Tdirname=ds.Tables[0].Rows[0]["Tdirname"].ToString();
				if(ds.Tables[0].Rows[0]["Tsort"].ToString()!="")
				{
					model.Tsort=int.Parse(ds.Tables[0].Rows[0]["Tsort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Mode"].ToString()!="")
				{
					model.Mode=int.Parse(ds.Tables[0].Rows[0]["Mode"].ToString());
				}
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["Position"].ToString()!="")
				{
					model.Position=int.Parse(ds.Tables[0].Rows[0]["Position"].ToString());
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
		public Lebi_Tab GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Tab] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Tab model=new Lebi_Tab();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Tname=ds.Tables[0].Rows[0]["Tname"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Tkey=ds.Tables[0].Rows[0]["Tkey"].ToString();
				model.Tdes=ds.Tables[0].Rows[0]["Tdes"].ToString();
				model.Tdirname=ds.Tables[0].Rows[0]["Tdirname"].ToString();
				if(ds.Tables[0].Rows[0]["Tsort"].ToString()!="")
				{
					model.Tsort=int.Parse(ds.Tables[0].Rows[0]["Tsort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Mode"].ToString()!="")
				{
					model.Mode=int.Parse(ds.Tables[0].Rows[0]["Mode"].ToString());
				}
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["Position"].ToString()!="")
				{
					model.Position=int.Parse(ds.Tables[0].Rows[0]["Position"].ToString());
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
		public List<Lebi_Tab> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Tab]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Tab> list = new List<Lebi_Tab>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Tab> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Tab]";
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
			List<Lebi_Tab> list = new List<Lebi_Tab>();
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
		public List<Lebi_Tab> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Tab] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Tab> list = new List<Lebi_Tab>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Tab> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Tab]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Tab> list = new List<Lebi_Tab>();
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
		public Lebi_Tab BindForm(Lebi_Tab model)
		{
			if (HttpContext.Current.Request["Tname"] != null)
				model.Tname=Shop.Tools.RequestTool.RequestString("Tname");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["Tkey"] != null)
				model.Tkey=Shop.Tools.RequestTool.RequestString("Tkey");
			if (HttpContext.Current.Request["Tdes"] != null)
				model.Tdes=Shop.Tools.RequestTool.RequestString("Tdes");
			if (HttpContext.Current.Request["Tdirname"] != null)
				model.Tdirname=Shop.Tools.RequestTool.RequestString("Tdirname");
			if (HttpContext.Current.Request["Tsort"] != null)
				model.Tsort=Shop.Tools.RequestTool.RequestInt("Tsort",0);
			if (HttpContext.Current.Request["Mode"] != null)
				model.Mode=Shop.Tools.RequestTool.RequestInt("Mode",0);
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestString("Url");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Position"] != null)
				model.Position=Shop.Tools.RequestTool.RequestInt("Position",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Tab SafeBindForm(Lebi_Tab model)
		{
			if (HttpContext.Current.Request["Tname"] != null)
				model.Tname=Shop.Tools.RequestTool.RequestSafeString("Tname");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["Tkey"] != null)
				model.Tkey=Shop.Tools.RequestTool.RequestSafeString("Tkey");
			if (HttpContext.Current.Request["Tdes"] != null)
				model.Tdes=Shop.Tools.RequestTool.RequestSafeString("Tdes");
			if (HttpContext.Current.Request["Tdirname"] != null)
				model.Tdirname=Shop.Tools.RequestTool.RequestSafeString("Tdirname");
			if (HttpContext.Current.Request["Tsort"] != null)
				model.Tsort=Shop.Tools.RequestTool.RequestInt("Tsort",0);
			if (HttpContext.Current.Request["Mode"] != null)
				model.Mode=Shop.Tools.RequestTool.RequestInt("Mode",0);
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestSafeString("Url");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Position"] != null)
				model.Position=Shop.Tools.RequestTool.RequestInt("Position",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Tab ReaderBind(IDataReader dataReader)
		{
			Lebi_Tab model=new Lebi_Tab();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Tname=dataReader["Tname"].ToString();
			model.Title=dataReader["Title"].ToString();
			model.Tkey=dataReader["Tkey"].ToString();
			model.Tdes=dataReader["Tdes"].ToString();
			model.Tdirname=dataReader["Tdirname"].ToString();
			ojb = dataReader["Tsort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Tsort=(int)ojb;
			}
			ojb = dataReader["Mode"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Mode=(int)ojb;
			}
			model.Url=dataReader["Url"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["Position"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Position=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Tab : Lebi_Tab_interface
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
				strSql.Append("select " + colName + " from [Lebi_Tab]");
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
			strSql.Append("select  "+colName+" from [Lebi_Tab]");
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
			strSql.Append("select count(*) from [Lebi_Tab]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Tab]");
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
			strSql.Append("select max(id) from [Lebi_Tab]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Tab]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Tab model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Tab](");
			strSql.Append("[Tname],[Title],[Tkey],[Tdes],[Tdirname],[Tsort],[Mode],[Url],[Description],[Position])");
			strSql.Append(" values (");
			strSql.Append("@Tname,@Title,@Tkey,@Tdes,@Tdirname,@Tsort,@Mode,@Url,@Description,@Position)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Tname", model.Tname),
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@Tkey", model.Tkey),
					new OleDbParameter("@Tdes", model.Tdes),
					new OleDbParameter("@Tdirname", model.Tdirname),
					new OleDbParameter("@Tsort", model.Tsort),
					new OleDbParameter("@Mode", model.Mode),
					new OleDbParameter("@Url", model.Url),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Position", model.Position)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Tab model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Tab] set ");
			strSql.Append("[Tname]=@Tname,");
			strSql.Append("[Title]=@Title,");
			strSql.Append("[Tkey]=@Tkey,");
			strSql.Append("[Tdes]=@Tdes,");
			strSql.Append("[Tdirname]=@Tdirname,");
			strSql.Append("[Tsort]=@Tsort,");
			strSql.Append("[Mode]=@Mode,");
			strSql.Append("[Url]=@Url,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[Position]=@Position");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Tname", model.Tname),
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@Tkey", model.Tkey),
					new OleDbParameter("@Tdes", model.Tdes),
					new OleDbParameter("@Tdirname", model.Tdirname),
					new OleDbParameter("@Tsort", model.Tsort),
					new OleDbParameter("@Mode", model.Mode),
					new OleDbParameter("@Url", model.Url),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Position", model.Position)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Tab] ");
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
			strSql.Append("delete from [Lebi_Tab] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Tab] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Tab GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Tab] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Tab model;
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
		public Lebi_Tab GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Tab] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Tab model;
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
		public Lebi_Tab GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Tab] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Tab model;
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
		public List<Lebi_Tab> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Tab]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Tab> list = new List<Lebi_Tab>();
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
		public List<Lebi_Tab> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Tab]";
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
			List<Lebi_Tab> list = new List<Lebi_Tab>();
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
		public List<Lebi_Tab> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Tab] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Tab> list = new List<Lebi_Tab>();
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
		public List<Lebi_Tab> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Tab]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Tab> list = new List<Lebi_Tab>();
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
		public Lebi_Tab BindForm(Lebi_Tab model)
		{
			if (HttpContext.Current.Request["Tname"] != null)
				model.Tname=Shop.Tools.RequestTool.RequestString("Tname");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["Tkey"] != null)
				model.Tkey=Shop.Tools.RequestTool.RequestString("Tkey");
			if (HttpContext.Current.Request["Tdes"] != null)
				model.Tdes=Shop.Tools.RequestTool.RequestString("Tdes");
			if (HttpContext.Current.Request["Tdirname"] != null)
				model.Tdirname=Shop.Tools.RequestTool.RequestString("Tdirname");
			if (HttpContext.Current.Request["Tsort"] != null)
				model.Tsort=Shop.Tools.RequestTool.RequestInt("Tsort",0);
			if (HttpContext.Current.Request["Mode"] != null)
				model.Mode=Shop.Tools.RequestTool.RequestInt("Mode",0);
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestString("Url");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Position"] != null)
				model.Position=Shop.Tools.RequestTool.RequestInt("Position",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Tab SafeBindForm(Lebi_Tab model)
		{
			if (HttpContext.Current.Request["Tname"] != null)
				model.Tname=Shop.Tools.RequestTool.RequestSafeString("Tname");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["Tkey"] != null)
				model.Tkey=Shop.Tools.RequestTool.RequestSafeString("Tkey");
			if (HttpContext.Current.Request["Tdes"] != null)
				model.Tdes=Shop.Tools.RequestTool.RequestSafeString("Tdes");
			if (HttpContext.Current.Request["Tdirname"] != null)
				model.Tdirname=Shop.Tools.RequestTool.RequestSafeString("Tdirname");
			if (HttpContext.Current.Request["Tsort"] != null)
				model.Tsort=Shop.Tools.RequestTool.RequestInt("Tsort",0);
			if (HttpContext.Current.Request["Mode"] != null)
				model.Mode=Shop.Tools.RequestTool.RequestInt("Mode",0);
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestSafeString("Url");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Position"] != null)
				model.Position=Shop.Tools.RequestTool.RequestInt("Position",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Tab ReaderBind(IDataReader dataReader)
		{
			Lebi_Tab model=new Lebi_Tab();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Tname=dataReader["Tname"].ToString();
			model.Title=dataReader["Title"].ToString();
			model.Tkey=dataReader["Tkey"].ToString();
			model.Tdes=dataReader["Tdes"].ToString();
			model.Tdirname=dataReader["Tdirname"].ToString();
			ojb = dataReader["Tsort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Tsort=(int)ojb;
			}
			ojb = dataReader["Mode"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Mode=(int)ojb;
			}
			model.Url=dataReader["Url"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["Position"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Position=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

