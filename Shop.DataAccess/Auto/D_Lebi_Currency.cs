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

	public interface Lebi_Currency_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Currency model);
		void Update(Lebi_Currency model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Currency GetModel(int id);
		Lebi_Currency GetModel(string strWhere);
		Lebi_Currency GetModel(SQLPara para);
		List<Lebi_Currency> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Currency> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Currency> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Currency> GetList(SQLPara para);
		Lebi_Currency BindForm(Lebi_Currency model);
		Lebi_Currency SafeBindForm(Lebi_Currency model);
		Lebi_Currency ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Currency。
	/// </summary>
	public class D_Lebi_Currency
	{
		static Lebi_Currency_interface _Instance;
		public static Lebi_Currency_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Currency();
		            else
		                _Instance = new sqlserver_Lebi_Currency();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Currency()
		{}
		#region  成员方法
	class sqlserver_Lebi_Currency : Lebi_Currency_interface
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
				strSql.Append("select " + colName + " from [Lebi_Currency]");
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
			strSql.Append("select  "+colName+" from [Lebi_Currency]");
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
			strSql.Append("select count(1) from [Lebi_Currency]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Currency]");
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
			strSql.Append("select max(id) from [Lebi_Currency]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Currency]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Currency model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Currency](");
			strSql.Append("ExchangeRate,Msige,Name,Code,Sort,IsDefault,DecimalLength)");
			strSql.Append(" values (");
			strSql.Append("@ExchangeRate,@Msige,@Name,@Code,@Sort,@IsDefault,@DecimalLength)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ExchangeRate", model.ExchangeRate),
					new SqlParameter("@Msige", model.Msige),
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@IsDefault", model.IsDefault),
					new SqlParameter("@DecimalLength", model.DecimalLength)};

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
		public void Update(Lebi_Currency model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Currency] set ");
			strSql.Append("ExchangeRate= @ExchangeRate,");
			strSql.Append("Msige= @Msige,");
			strSql.Append("Name= @Name,");
			strSql.Append("Code= @Code,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("IsDefault= @IsDefault,");
			strSql.Append("DecimalLength= @DecimalLength");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@Msige", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@IsDefault", SqlDbType.Int,4),
					new SqlParameter("@DecimalLength", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ExchangeRate;
			parameters[2].Value = model.Msige;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Code;
			parameters[5].Value = model.Sort;
			parameters[6].Value = model.IsDefault;
			parameters[7].Value = model.DecimalLength;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Currency] ");
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
			strSql.Append("delete from [Lebi_Currency] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Currency] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Currency GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Currency] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Currency model=new Lebi_Currency();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeRate"].ToString()!="")
				{
					model.ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["ExchangeRate"].ToString());
				}
				model.Msige=ds.Tables[0].Rows[0]["Msige"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsDefault"].ToString()!="")
				{
					model.IsDefault=int.Parse(ds.Tables[0].Rows[0]["IsDefault"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DecimalLength"].ToString()!="")
				{
					model.DecimalLength=int.Parse(ds.Tables[0].Rows[0]["DecimalLength"].ToString());
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
		public Lebi_Currency GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Currency] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Currency model=new Lebi_Currency();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeRate"].ToString()!="")
				{
					model.ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["ExchangeRate"].ToString());
				}
				model.Msige=ds.Tables[0].Rows[0]["Msige"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsDefault"].ToString()!="")
				{
					model.IsDefault=int.Parse(ds.Tables[0].Rows[0]["IsDefault"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DecimalLength"].ToString()!="")
				{
					model.DecimalLength=int.Parse(ds.Tables[0].Rows[0]["DecimalLength"].ToString());
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
		public Lebi_Currency GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Currency] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Currency model=new Lebi_Currency();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeRate"].ToString()!="")
				{
					model.ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["ExchangeRate"].ToString());
				}
				model.Msige=ds.Tables[0].Rows[0]["Msige"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsDefault"].ToString()!="")
				{
					model.IsDefault=int.Parse(ds.Tables[0].Rows[0]["IsDefault"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DecimalLength"].ToString()!="")
				{
					model.DecimalLength=int.Parse(ds.Tables[0].Rows[0]["DecimalLength"].ToString());
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
		public List<Lebi_Currency> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Currency]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Currency> list = new List<Lebi_Currency>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Currency> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Currency]";
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
			List<Lebi_Currency> list = new List<Lebi_Currency>();
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
		public List<Lebi_Currency> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Currency] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Currency> list = new List<Lebi_Currency>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Currency> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Currency]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Currency> list = new List<Lebi_Currency>();
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
		public Lebi_Currency BindForm(Lebi_Currency model)
		{
			if (HttpContext.Current.Request["ExchangeRate"] != null)
				model.ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("ExchangeRate",0);
			if (HttpContext.Current.Request["Msige"] != null)
				model.Msige=Shop.Tools.RequestTool.RequestString("Msige");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsDefault"] != null)
				model.IsDefault=Shop.Tools.RequestTool.RequestInt("IsDefault",0);
			if (HttpContext.Current.Request["DecimalLength"] != null)
				model.DecimalLength=Shop.Tools.RequestTool.RequestInt("DecimalLength",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Currency SafeBindForm(Lebi_Currency model)
		{
			if (HttpContext.Current.Request["ExchangeRate"] != null)
				model.ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("ExchangeRate",0);
			if (HttpContext.Current.Request["Msige"] != null)
				model.Msige=Shop.Tools.RequestTool.RequestSafeString("Msige");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsDefault"] != null)
				model.IsDefault=Shop.Tools.RequestTool.RequestInt("IsDefault",0);
			if (HttpContext.Current.Request["DecimalLength"] != null)
				model.DecimalLength=Shop.Tools.RequestTool.RequestInt("DecimalLength",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Currency ReaderBind(IDataReader dataReader)
		{
			Lebi_Currency model=new Lebi_Currency();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ExchangeRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ExchangeRate=(decimal)ojb;
			}
			model.Msige=dataReader["Msige"].ToString();
			model.Name=dataReader["Name"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["IsDefault"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDefault=(int)ojb;
			}
			ojb = dataReader["DecimalLength"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DecimalLength=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Currency : Lebi_Currency_interface
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
				strSql.Append("select " + colName + " from [Lebi_Currency]");
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
			strSql.Append("select  "+colName+" from [Lebi_Currency]");
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
			strSql.Append("select count(*) from [Lebi_Currency]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Currency]");
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
			strSql.Append("select max(id) from [Lebi_Currency]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Currency]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Currency model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Currency](");
			strSql.Append("[ExchangeRate],[Msige],[Name],[Code],[Sort],[IsDefault],[DecimalLength])");
			strSql.Append(" values (");
			strSql.Append("@ExchangeRate,@Msige,@Name,@Code,@Sort,@IsDefault,@DecimalLength)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ExchangeRate", model.ExchangeRate),
					new OleDbParameter("@Msige", model.Msige),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@IsDefault", model.IsDefault),
					new OleDbParameter("@DecimalLength", model.DecimalLength)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Currency model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Currency] set ");
			strSql.Append("[ExchangeRate]=@ExchangeRate,");
			strSql.Append("[Msige]=@Msige,");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[IsDefault]=@IsDefault,");
			strSql.Append("[DecimalLength]=@DecimalLength");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@ExchangeRate", model.ExchangeRate),
					new OleDbParameter("@Msige", model.Msige),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@IsDefault", model.IsDefault),
					new OleDbParameter("@DecimalLength", model.DecimalLength)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Currency] ");
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
			strSql.Append("delete from [Lebi_Currency] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Currency] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Currency GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Currency] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Currency model;
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
		public Lebi_Currency GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Currency] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Currency model;
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
		public Lebi_Currency GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Currency] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Currency model;
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
		public List<Lebi_Currency> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Currency]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Currency> list = new List<Lebi_Currency>();
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
		public List<Lebi_Currency> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Currency]";
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
			List<Lebi_Currency> list = new List<Lebi_Currency>();
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
		public List<Lebi_Currency> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Currency] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Currency> list = new List<Lebi_Currency>();
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
		public List<Lebi_Currency> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Currency]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Currency> list = new List<Lebi_Currency>();
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
		public Lebi_Currency BindForm(Lebi_Currency model)
		{
			if (HttpContext.Current.Request["ExchangeRate"] != null)
				model.ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("ExchangeRate",0);
			if (HttpContext.Current.Request["Msige"] != null)
				model.Msige=Shop.Tools.RequestTool.RequestString("Msige");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsDefault"] != null)
				model.IsDefault=Shop.Tools.RequestTool.RequestInt("IsDefault",0);
			if (HttpContext.Current.Request["DecimalLength"] != null)
				model.DecimalLength=Shop.Tools.RequestTool.RequestInt("DecimalLength",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Currency SafeBindForm(Lebi_Currency model)
		{
			if (HttpContext.Current.Request["ExchangeRate"] != null)
				model.ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("ExchangeRate",0);
			if (HttpContext.Current.Request["Msige"] != null)
				model.Msige=Shop.Tools.RequestTool.RequestSafeString("Msige");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsDefault"] != null)
				model.IsDefault=Shop.Tools.RequestTool.RequestInt("IsDefault",0);
			if (HttpContext.Current.Request["DecimalLength"] != null)
				model.DecimalLength=Shop.Tools.RequestTool.RequestInt("DecimalLength",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Currency ReaderBind(IDataReader dataReader)
		{
			Lebi_Currency model=new Lebi_Currency();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ExchangeRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ExchangeRate=(decimal)ojb;
			}
			model.Msige=dataReader["Msige"].ToString();
			model.Name=dataReader["Name"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["IsDefault"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDefault=(int)ojb;
			}
			ojb = dataReader["DecimalLength"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DecimalLength=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

