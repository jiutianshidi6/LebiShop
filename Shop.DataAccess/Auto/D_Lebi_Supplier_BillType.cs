﻿using System;
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

	public interface Lebi_Supplier_BillType_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Supplier_BillType model);
		void Update(Lebi_Supplier_BillType model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Supplier_BillType GetModel(int id);
		Lebi_Supplier_BillType GetModel(string strWhere);
		Lebi_Supplier_BillType GetModel(SQLPara para);
		List<Lebi_Supplier_BillType> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Supplier_BillType> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Supplier_BillType> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Supplier_BillType> GetList(SQLPara para);
		Lebi_Supplier_BillType BindForm(Lebi_Supplier_BillType model);
		Lebi_Supplier_BillType SafeBindForm(Lebi_Supplier_BillType model);
		Lebi_Supplier_BillType ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Supplier_BillType。
	/// </summary>
	public class D_Lebi_Supplier_BillType
	{
		static Lebi_Supplier_BillType_interface _Instance;
		public static Lebi_Supplier_BillType_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Supplier_BillType();
		            else
		                _Instance = new sqlserver_Lebi_Supplier_BillType();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Supplier_BillType()
		{}
		#region  成员方法
	class sqlserver_Lebi_Supplier_BillType : Lebi_Supplier_BillType_interface
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
				strSql.Append("select " + colName + " from [Lebi_Supplier_BillType]");
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
			strSql.Append("select  "+colName+" from [Lebi_Supplier_BillType]");
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
			strSql.Append("select count(1) from [Lebi_Supplier_BillType]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_BillType]");
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
			strSql.Append("select max(id) from [Lebi_Supplier_BillType]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_BillType]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier_BillType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier_BillType](");
			strSql.Append("TaxRate,Type_id_BillType,Supplier_id)");
			strSql.Append(" values (");
			strSql.Append("@TaxRate,@Type_id_BillType,@Supplier_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TaxRate", model.TaxRate),
					new SqlParameter("@Type_id_BillType", model.Type_id_BillType),
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
		public void Update(Lebi_Supplier_BillType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier_BillType] set ");
			strSql.Append("TaxRate= @TaxRate,");
			strSql.Append("Type_id_BillType= @Type_id_BillType,");
			strSql.Append("Supplier_id= @Supplier_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@TaxRate", SqlDbType.Decimal,9),
					new SqlParameter("@Type_id_BillType", SqlDbType.Int,4),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.TaxRate;
			parameters[2].Value = model.Type_id_BillType;
			parameters[3].Value = model.Supplier_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_BillType] ");
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
			strSql.Append("delete from [Lebi_Supplier_BillType] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_BillType] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier_BillType GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_BillType] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Supplier_BillType model=new Lebi_Supplier_BillType();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TaxRate"].ToString()!="")
				{
					model.TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString()!="")
				{
					model.Type_id_BillType=int.Parse(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString());
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
		public Lebi_Supplier_BillType GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_BillType] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier_BillType model=new Lebi_Supplier_BillType();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TaxRate"].ToString()!="")
				{
					model.TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString()!="")
				{
					model.Type_id_BillType=int.Parse(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString());
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
		public Lebi_Supplier_BillType GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier_BillType] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier_BillType model=new Lebi_Supplier_BillType();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TaxRate"].ToString()!="")
				{
					model.TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString()!="")
				{
					model.Type_id_BillType=int.Parse(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString());
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
		public List<Lebi_Supplier_BillType> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier_BillType]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier_BillType> list = new List<Lebi_Supplier_BillType>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Supplier_BillType> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier_BillType]";
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
			List<Lebi_Supplier_BillType> list = new List<Lebi_Supplier_BillType>();
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
		public List<Lebi_Supplier_BillType> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier_BillType] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier_BillType> list = new List<Lebi_Supplier_BillType>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Supplier_BillType> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier_BillType]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_BillType> list = new List<Lebi_Supplier_BillType>();
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
		public Lebi_Supplier_BillType BindForm(Lebi_Supplier_BillType model)
		{
			if (HttpContext.Current.Request["TaxRate"] != null)
				model.TaxRate=Shop.Tools.RequestTool.RequestDecimal("TaxRate",0);
			if (HttpContext.Current.Request["Type_id_BillType"] != null)
				model.Type_id_BillType=Shop.Tools.RequestTool.RequestInt("Type_id_BillType",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier_BillType SafeBindForm(Lebi_Supplier_BillType model)
		{
			if (HttpContext.Current.Request["TaxRate"] != null)
				model.TaxRate=Shop.Tools.RequestTool.RequestDecimal("TaxRate",0);
			if (HttpContext.Current.Request["Type_id_BillType"] != null)
				model.Type_id_BillType=Shop.Tools.RequestTool.RequestInt("Type_id_BillType",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier_BillType ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier_BillType model=new Lebi_Supplier_BillType();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["TaxRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TaxRate=(decimal)ojb;
			}
			ojb = dataReader["Type_id_BillType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_BillType=(int)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Supplier_BillType : Lebi_Supplier_BillType_interface
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
				strSql.Append("select " + colName + " from [Lebi_Supplier_BillType]");
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
			strSql.Append("select  "+colName+" from [Lebi_Supplier_BillType]");
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
			strSql.Append("select count(*) from [Lebi_Supplier_BillType]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Supplier_BillType]");
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
			strSql.Append("select max(id) from [Lebi_Supplier_BillType]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_BillType]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier_BillType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier_BillType](");
			strSql.Append("[TaxRate],[Type_id_BillType],[Supplier_id])");
			strSql.Append(" values (");
			strSql.Append("@TaxRate,@Type_id_BillType,@Supplier_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@TaxRate", model.TaxRate),
					new OleDbParameter("@Type_id_BillType", model.Type_id_BillType),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Supplier_BillType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier_BillType] set ");
			strSql.Append("[TaxRate]=@TaxRate,");
			strSql.Append("[Type_id_BillType]=@Type_id_BillType,");
			strSql.Append("[Supplier_id]=@Supplier_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@TaxRate", model.TaxRate),
					new OleDbParameter("@Type_id_BillType", model.Type_id_BillType),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_BillType] ");
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
			strSql.Append("delete from [Lebi_Supplier_BillType] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_BillType] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier_BillType GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_BillType] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Supplier_BillType model;
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
		public Lebi_Supplier_BillType GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_BillType] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier_BillType model;
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
		public Lebi_Supplier_BillType GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier_BillType] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier_BillType model;
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
		public List<Lebi_Supplier_BillType> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier_BillType]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier_BillType> list = new List<Lebi_Supplier_BillType>();
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
		public List<Lebi_Supplier_BillType> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier_BillType]";
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
			List<Lebi_Supplier_BillType> list = new List<Lebi_Supplier_BillType>();
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
		public List<Lebi_Supplier_BillType> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier_BillType] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier_BillType> list = new List<Lebi_Supplier_BillType>();
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
		public List<Lebi_Supplier_BillType> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier_BillType]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_BillType> list = new List<Lebi_Supplier_BillType>();
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
		public Lebi_Supplier_BillType BindForm(Lebi_Supplier_BillType model)
		{
			if (HttpContext.Current.Request["TaxRate"] != null)
				model.TaxRate=Shop.Tools.RequestTool.RequestDecimal("TaxRate",0);
			if (HttpContext.Current.Request["Type_id_BillType"] != null)
				model.Type_id_BillType=Shop.Tools.RequestTool.RequestInt("Type_id_BillType",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier_BillType SafeBindForm(Lebi_Supplier_BillType model)
		{
			if (HttpContext.Current.Request["TaxRate"] != null)
				model.TaxRate=Shop.Tools.RequestTool.RequestDecimal("TaxRate",0);
			if (HttpContext.Current.Request["Type_id_BillType"] != null)
				model.Type_id_BillType=Shop.Tools.RequestTool.RequestInt("Type_id_BillType",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier_BillType ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier_BillType model=new Lebi_Supplier_BillType();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["TaxRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TaxRate=(decimal)ojb;
			}
			ojb = dataReader["Type_id_BillType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_BillType=(int)ojb;
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

