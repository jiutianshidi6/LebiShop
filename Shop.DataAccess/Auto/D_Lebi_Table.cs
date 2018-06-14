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

	public interface Lebi_Table_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Table model);
		void Update(Lebi_Table model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Table GetModel(int id);
		Lebi_Table GetModel(string strWhere);
		Lebi_Table GetModel(SQLPara para);
		List<Lebi_Table> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Table> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Table> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Table> GetList(SQLPara para);
		Lebi_Table BindForm(Lebi_Table model);
		Lebi_Table SafeBindForm(Lebi_Table model);
		Lebi_Table ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Table。
	/// </summary>
	public class D_Lebi_Table
	{
		static Lebi_Table_interface _Instance;
		public static Lebi_Table_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Table();
		            else
		                _Instance = new sqlserver_Lebi_Table();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Table()
		{}
		#region  成员方法
	class sqlserver_Lebi_Table : Lebi_Table_interface
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
				strSql.Append("select " + colName + " from [Lebi_Table]");
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
			strSql.Append("select  "+colName+" from [Lebi_Table]");
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
			strSql.Append("select count(1) from [Lebi_Table]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Table]");
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
			strSql.Append("select max(id) from [Lebi_Table]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Table]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Table model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Table](");
			strSql.Append("name,type,char_length,numeric_length,numeric_scale,isidentity,ispk,defaultval,isnullable,parentid,parentname,remark)");
			strSql.Append(" values (");
			strSql.Append("@name,@type,@char_length,@numeric_length,@numeric_scale,@isidentity,@ispk,@defaultval,@isnullable,@parentid,@parentname,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", model.name),
					new SqlParameter("@type", model.type),
					new SqlParameter("@char_length", model.char_length),
					new SqlParameter("@numeric_length", model.numeric_length),
					new SqlParameter("@numeric_scale", model.numeric_scale),
					new SqlParameter("@isidentity", model.isidentity),
					new SqlParameter("@ispk", model.ispk),
					new SqlParameter("@defaultval", model.defaultval),
					new SqlParameter("@isnullable", model.isnullable),
					new SqlParameter("@parentid", model.parentid),
					new SqlParameter("@parentname", model.parentname),
					new SqlParameter("@remark", model.remark)};

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
		public void Update(Lebi_Table model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Table] set ");
			strSql.Append("name= @name,");
			strSql.Append("type= @type,");
			strSql.Append("char_length= @char_length,");
			strSql.Append("numeric_length= @numeric_length,");
			strSql.Append("numeric_scale= @numeric_scale,");
			strSql.Append("isidentity= @isidentity,");
			strSql.Append("ispk= @ispk,");
			strSql.Append("defaultval= @defaultval,");
			strSql.Append("isnullable= @isnullable,");
			strSql.Append("parentid= @parentid,");
			strSql.Append("parentname= @parentname,");
			strSql.Append("remark= @remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@char_length", SqlDbType.Int,4),
					new SqlParameter("@numeric_length", SqlDbType.Int,4),
					new SqlParameter("@numeric_scale", SqlDbType.Int,4),
					new SqlParameter("@isidentity", SqlDbType.Int,4),
					new SqlParameter("@ispk", SqlDbType.Int,4),
					new SqlParameter("@defaultval", SqlDbType.NVarChar,50),
					new SqlParameter("@isnullable", SqlDbType.Int,4),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@parentname", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.name;
			parameters[2].Value = model.type;
			parameters[3].Value = model.char_length;
			parameters[4].Value = model.numeric_length;
			parameters[5].Value = model.numeric_scale;
			parameters[6].Value = model.isidentity;
			parameters[7].Value = model.ispk;
			parameters[8].Value = model.defaultval;
			parameters[9].Value = model.isnullable;
			parameters[10].Value = model.parentid;
			parameters[11].Value = model.parentname;
			parameters[12].Value = model.remark;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Table] ");
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
			strSql.Append("delete from [Lebi_Table] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Table] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Table GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Table] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Table model=new Lebi_Table();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				if(ds.Tables[0].Rows[0]["char_length"].ToString()!="")
				{
					model.char_length=int.Parse(ds.Tables[0].Rows[0]["char_length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["numeric_length"].ToString()!="")
				{
					model.numeric_length=int.Parse(ds.Tables[0].Rows[0]["numeric_length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["numeric_scale"].ToString()!="")
				{
					model.numeric_scale=int.Parse(ds.Tables[0].Rows[0]["numeric_scale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isidentity"].ToString()!="")
				{
					model.isidentity=int.Parse(ds.Tables[0].Rows[0]["isidentity"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ispk"].ToString()!="")
				{
					model.ispk=int.Parse(ds.Tables[0].Rows[0]["ispk"].ToString());
				}
				model.defaultval=ds.Tables[0].Rows[0]["defaultval"].ToString();
				if(ds.Tables[0].Rows[0]["isnullable"].ToString()!="")
				{
					model.isnullable=int.Parse(ds.Tables[0].Rows[0]["isnullable"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				model.parentname=ds.Tables[0].Rows[0]["parentname"].ToString();
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
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
		public Lebi_Table GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Table] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Table model=new Lebi_Table();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				if(ds.Tables[0].Rows[0]["char_length"].ToString()!="")
				{
					model.char_length=int.Parse(ds.Tables[0].Rows[0]["char_length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["numeric_length"].ToString()!="")
				{
					model.numeric_length=int.Parse(ds.Tables[0].Rows[0]["numeric_length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["numeric_scale"].ToString()!="")
				{
					model.numeric_scale=int.Parse(ds.Tables[0].Rows[0]["numeric_scale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isidentity"].ToString()!="")
				{
					model.isidentity=int.Parse(ds.Tables[0].Rows[0]["isidentity"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ispk"].ToString()!="")
				{
					model.ispk=int.Parse(ds.Tables[0].Rows[0]["ispk"].ToString());
				}
				model.defaultval=ds.Tables[0].Rows[0]["defaultval"].ToString();
				if(ds.Tables[0].Rows[0]["isnullable"].ToString()!="")
				{
					model.isnullable=int.Parse(ds.Tables[0].Rows[0]["isnullable"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				model.parentname=ds.Tables[0].Rows[0]["parentname"].ToString();
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
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
		public Lebi_Table GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Table] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Table model=new Lebi_Table();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				if(ds.Tables[0].Rows[0]["char_length"].ToString()!="")
				{
					model.char_length=int.Parse(ds.Tables[0].Rows[0]["char_length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["numeric_length"].ToString()!="")
				{
					model.numeric_length=int.Parse(ds.Tables[0].Rows[0]["numeric_length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["numeric_scale"].ToString()!="")
				{
					model.numeric_scale=int.Parse(ds.Tables[0].Rows[0]["numeric_scale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isidentity"].ToString()!="")
				{
					model.isidentity=int.Parse(ds.Tables[0].Rows[0]["isidentity"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ispk"].ToString()!="")
				{
					model.ispk=int.Parse(ds.Tables[0].Rows[0]["ispk"].ToString());
				}
				model.defaultval=ds.Tables[0].Rows[0]["defaultval"].ToString();
				if(ds.Tables[0].Rows[0]["isnullable"].ToString()!="")
				{
					model.isnullable=int.Parse(ds.Tables[0].Rows[0]["isnullable"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				model.parentname=ds.Tables[0].Rows[0]["parentname"].ToString();
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
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
		public List<Lebi_Table> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Table]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Table> list = new List<Lebi_Table>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Table> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Table]";
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
			List<Lebi_Table> list = new List<Lebi_Table>();
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
		public List<Lebi_Table> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Table] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Table> list = new List<Lebi_Table>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Table> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Table]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Table> list = new List<Lebi_Table>();
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
		public Lebi_Table BindForm(Lebi_Table model)
		{
			if (HttpContext.Current.Request["name"] != null)
				model.name=Shop.Tools.RequestTool.RequestString("name");
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestString("type");
			if (HttpContext.Current.Request["char_length"] != null)
				model.char_length=Shop.Tools.RequestTool.RequestInt("char_length",0);
			if (HttpContext.Current.Request["numeric_length"] != null)
				model.numeric_length=Shop.Tools.RequestTool.RequestInt("numeric_length",0);
			if (HttpContext.Current.Request["numeric_scale"] != null)
				model.numeric_scale=Shop.Tools.RequestTool.RequestInt("numeric_scale",0);
			if (HttpContext.Current.Request["isidentity"] != null)
				model.isidentity=Shop.Tools.RequestTool.RequestInt("isidentity",0);
			if (HttpContext.Current.Request["ispk"] != null)
				model.ispk=Shop.Tools.RequestTool.RequestInt("ispk",0);
			if (HttpContext.Current.Request["defaultval"] != null)
				model.defaultval=Shop.Tools.RequestTool.RequestString("defaultval");
			if (HttpContext.Current.Request["isnullable"] != null)
				model.isnullable=Shop.Tools.RequestTool.RequestInt("isnullable",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["parentname"] != null)
				model.parentname=Shop.Tools.RequestTool.RequestString("parentname");
			if (HttpContext.Current.Request["remark"] != null)
				model.remark=Shop.Tools.RequestTool.RequestString("remark");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Table SafeBindForm(Lebi_Table model)
		{
			if (HttpContext.Current.Request["name"] != null)
				model.name=Shop.Tools.RequestTool.RequestSafeString("name");
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestSafeString("type");
			if (HttpContext.Current.Request["char_length"] != null)
				model.char_length=Shop.Tools.RequestTool.RequestInt("char_length",0);
			if (HttpContext.Current.Request["numeric_length"] != null)
				model.numeric_length=Shop.Tools.RequestTool.RequestInt("numeric_length",0);
			if (HttpContext.Current.Request["numeric_scale"] != null)
				model.numeric_scale=Shop.Tools.RequestTool.RequestInt("numeric_scale",0);
			if (HttpContext.Current.Request["isidentity"] != null)
				model.isidentity=Shop.Tools.RequestTool.RequestInt("isidentity",0);
			if (HttpContext.Current.Request["ispk"] != null)
				model.ispk=Shop.Tools.RequestTool.RequestInt("ispk",0);
			if (HttpContext.Current.Request["defaultval"] != null)
				model.defaultval=Shop.Tools.RequestTool.RequestSafeString("defaultval");
			if (HttpContext.Current.Request["isnullable"] != null)
				model.isnullable=Shop.Tools.RequestTool.RequestInt("isnullable",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["parentname"] != null)
				model.parentname=Shop.Tools.RequestTool.RequestSafeString("parentname");
			if (HttpContext.Current.Request["remark"] != null)
				model.remark=Shop.Tools.RequestTool.RequestSafeString("remark");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Table ReaderBind(IDataReader dataReader)
		{
			Lebi_Table model=new Lebi_Table();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.name=dataReader["name"].ToString();
			model.type=dataReader["type"].ToString();
			ojb = dataReader["char_length"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.char_length=(int)ojb;
			}
			ojb = dataReader["numeric_length"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.numeric_length=(int)ojb;
			}
			ojb = dataReader["numeric_scale"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.numeric_scale=(int)ojb;
			}
			ojb = dataReader["isidentity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.isidentity=(int)ojb;
			}
			ojb = dataReader["ispk"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ispk=(int)ojb;
			}
			model.defaultval=dataReader["defaultval"].ToString();
			ojb = dataReader["isnullable"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.isnullable=(int)ojb;
			}
			ojb = dataReader["parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentid=(int)ojb;
			}
			model.parentname=dataReader["parentname"].ToString();
			model.remark=dataReader["remark"].ToString();
			return model;
		}

	}
	class access_Lebi_Table : Lebi_Table_interface
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
				strSql.Append("select " + colName + " from [Lebi_Table]");
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
			strSql.Append("select  "+colName+" from [Lebi_Table]");
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
			strSql.Append("select count(*) from [Lebi_Table]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Table]");
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
			strSql.Append("select max(id) from [Lebi_Table]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Table]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Table model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Table](");
			strSql.Append("[name],[type],[char_length],[numeric_length],[numeric_scale],[isidentity],[ispk],[defaultval],[isnullable],[parentid],[parentname],[remark])");
			strSql.Append(" values (");
			strSql.Append("@name,@type,@char_length,@numeric_length,@numeric_scale,@isidentity,@ispk,@defaultval,@isnullable,@parentid,@parentname,@remark)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@name", model.name),
					new OleDbParameter("@type", model.type),
					new OleDbParameter("@char_length", model.char_length),
					new OleDbParameter("@numeric_length", model.numeric_length),
					new OleDbParameter("@numeric_scale", model.numeric_scale),
					new OleDbParameter("@isidentity", model.isidentity),
					new OleDbParameter("@ispk", model.ispk),
					new OleDbParameter("@defaultval", model.defaultval),
					new OleDbParameter("@isnullable", model.isnullable),
					new OleDbParameter("@parentid", model.parentid),
					new OleDbParameter("@parentname", model.parentname),
					new OleDbParameter("@remark", model.remark)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Table model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Table] set ");
			strSql.Append("[name]=@name,");
			strSql.Append("[type]=@type,");
			strSql.Append("[char_length]=@char_length,");
			strSql.Append("[numeric_length]=@numeric_length,");
			strSql.Append("[numeric_scale]=@numeric_scale,");
			strSql.Append("[isidentity]=@isidentity,");
			strSql.Append("[ispk]=@ispk,");
			strSql.Append("[defaultval]=@defaultval,");
			strSql.Append("[isnullable]=@isnullable,");
			strSql.Append("[parentid]=@parentid,");
			strSql.Append("[parentname]=@parentname,");
			strSql.Append("[remark]=@remark");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@name", model.name),
					new OleDbParameter("@type", model.type),
					new OleDbParameter("@char_length", model.char_length),
					new OleDbParameter("@numeric_length", model.numeric_length),
					new OleDbParameter("@numeric_scale", model.numeric_scale),
					new OleDbParameter("@isidentity", model.isidentity),
					new OleDbParameter("@ispk", model.ispk),
					new OleDbParameter("@defaultval", model.defaultval),
					new OleDbParameter("@isnullable", model.isnullable),
					new OleDbParameter("@parentid", model.parentid),
					new OleDbParameter("@parentname", model.parentname),
					new OleDbParameter("@remark", model.remark)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Table] ");
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
			strSql.Append("delete from [Lebi_Table] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Table] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Table GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Table] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Table model;
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
		public Lebi_Table GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Table] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Table model;
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
		public Lebi_Table GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Table] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Table model;
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
		public List<Lebi_Table> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Table]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Table> list = new List<Lebi_Table>();
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
		public List<Lebi_Table> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Table]";
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
			List<Lebi_Table> list = new List<Lebi_Table>();
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
		public List<Lebi_Table> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Table] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Table> list = new List<Lebi_Table>();
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
		public List<Lebi_Table> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Table]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Table> list = new List<Lebi_Table>();
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
		public Lebi_Table BindForm(Lebi_Table model)
		{
			if (HttpContext.Current.Request["name"] != null)
				model.name=Shop.Tools.RequestTool.RequestString("name");
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestString("type");
			if (HttpContext.Current.Request["char_length"] != null)
				model.char_length=Shop.Tools.RequestTool.RequestInt("char_length",0);
			if (HttpContext.Current.Request["numeric_length"] != null)
				model.numeric_length=Shop.Tools.RequestTool.RequestInt("numeric_length",0);
			if (HttpContext.Current.Request["numeric_scale"] != null)
				model.numeric_scale=Shop.Tools.RequestTool.RequestInt("numeric_scale",0);
			if (HttpContext.Current.Request["isidentity"] != null)
				model.isidentity=Shop.Tools.RequestTool.RequestInt("isidentity",0);
			if (HttpContext.Current.Request["ispk"] != null)
				model.ispk=Shop.Tools.RequestTool.RequestInt("ispk",0);
			if (HttpContext.Current.Request["defaultval"] != null)
				model.defaultval=Shop.Tools.RequestTool.RequestString("defaultval");
			if (HttpContext.Current.Request["isnullable"] != null)
				model.isnullable=Shop.Tools.RequestTool.RequestInt("isnullable",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["parentname"] != null)
				model.parentname=Shop.Tools.RequestTool.RequestString("parentname");
			if (HttpContext.Current.Request["remark"] != null)
				model.remark=Shop.Tools.RequestTool.RequestString("remark");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Table SafeBindForm(Lebi_Table model)
		{
			if (HttpContext.Current.Request["name"] != null)
				model.name=Shop.Tools.RequestTool.RequestSafeString("name");
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestSafeString("type");
			if (HttpContext.Current.Request["char_length"] != null)
				model.char_length=Shop.Tools.RequestTool.RequestInt("char_length",0);
			if (HttpContext.Current.Request["numeric_length"] != null)
				model.numeric_length=Shop.Tools.RequestTool.RequestInt("numeric_length",0);
			if (HttpContext.Current.Request["numeric_scale"] != null)
				model.numeric_scale=Shop.Tools.RequestTool.RequestInt("numeric_scale",0);
			if (HttpContext.Current.Request["isidentity"] != null)
				model.isidentity=Shop.Tools.RequestTool.RequestInt("isidentity",0);
			if (HttpContext.Current.Request["ispk"] != null)
				model.ispk=Shop.Tools.RequestTool.RequestInt("ispk",0);
			if (HttpContext.Current.Request["defaultval"] != null)
				model.defaultval=Shop.Tools.RequestTool.RequestSafeString("defaultval");
			if (HttpContext.Current.Request["isnullable"] != null)
				model.isnullable=Shop.Tools.RequestTool.RequestInt("isnullable",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["parentname"] != null)
				model.parentname=Shop.Tools.RequestTool.RequestSafeString("parentname");
			if (HttpContext.Current.Request["remark"] != null)
				model.remark=Shop.Tools.RequestTool.RequestSafeString("remark");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Table ReaderBind(IDataReader dataReader)
		{
			Lebi_Table model=new Lebi_Table();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.name=dataReader["name"].ToString();
			model.type=dataReader["type"].ToString();
			ojb = dataReader["char_length"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.char_length=(int)ojb;
			}
			ojb = dataReader["numeric_length"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.numeric_length=(int)ojb;
			}
			ojb = dataReader["numeric_scale"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.numeric_scale=(int)ojb;
			}
			ojb = dataReader["isidentity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.isidentity=(int)ojb;
			}
			ojb = dataReader["ispk"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ispk=(int)ojb;
			}
			model.defaultval=dataReader["defaultval"].ToString();
			ojb = dataReader["isnullable"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.isnullable=(int)ojb;
			}
			ojb = dataReader["parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentid=(int)ojb;
			}
			model.parentname=dataReader["parentname"].ToString();
			model.remark=dataReader["remark"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

