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

	public interface Lebi_Product_Stock_Log_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Product_Stock_Log model);
		void Update(Lebi_Product_Stock_Log model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Product_Stock_Log GetModel(int id);
		Lebi_Product_Stock_Log GetModel(string strWhere);
		Lebi_Product_Stock_Log GetModel(SQLPara para);
		List<Lebi_Product_Stock_Log> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Product_Stock_Log> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Product_Stock_Log> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Product_Stock_Log> GetList(SQLPara para);
		Lebi_Product_Stock_Log BindForm(Lebi_Product_Stock_Log model);
		Lebi_Product_Stock_Log SafeBindForm(Lebi_Product_Stock_Log model);
		Lebi_Product_Stock_Log ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Product_Stock_Log。
	/// </summary>
	public class D_Lebi_Product_Stock_Log
	{
		static Lebi_Product_Stock_Log_interface _Instance;
		public static Lebi_Product_Stock_Log_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Product_Stock_Log();
		            else
		                _Instance = new sqlserver_Lebi_Product_Stock_Log();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Product_Stock_Log()
		{}
		#region  成员方法
	class sqlserver_Lebi_Product_Stock_Log : Lebi_Product_Stock_Log_interface
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
				strSql.Append("select " + colName + " from [Lebi_Product_Stock_Log]");
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
			strSql.Append("select  "+colName+" from [Lebi_Product_Stock_Log]");
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
			strSql.Append("select count(1) from [Lebi_Product_Stock_Log]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Product_Stock_Log]");
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
			strSql.Append("select max(id) from [Lebi_Product_Stock_Log]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Product_Stock_Log]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Product_Stock_Log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Product_Stock_Log](");
			strSql.Append("Product_id,Count,Type_id_Stock,Time_Add,Order_Code,Order_id,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Product_id,@Count,@Type_id_Stock,@Time_Add,@Order_Code,@Order_id,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Product_id", model.Product_id),
					new SqlParameter("@Count", model.Count),
					new SqlParameter("@Type_id_Stock", model.Type_id_Stock),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Order_Code", model.Order_Code),
					new SqlParameter("@Order_id", model.Order_id),
					new SqlParameter("@Remark", model.Remark)};

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
		public void Update(Lebi_Product_Stock_Log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Product_Stock_Log] set ");
			strSql.Append("Product_id= @Product_id,");
			strSql.Append("Count= @Count,");
			strSql.Append("Type_id_Stock= @Type_id_Stock,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Order_Code= @Order_Code,");
			strSql.Append("Order_id= @Order_id,");
			strSql.Append("Remark= @Remark");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Product_id", SqlDbType.Int,4),
					new SqlParameter("@Count", SqlDbType.Decimal,9),
					new SqlParameter("@Type_id_Stock", SqlDbType.Int,4),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Order_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Order_id", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Product_id;
			parameters[2].Value = model.Count;
			parameters[3].Value = model.Type_id_Stock;
			parameters[4].Value = model.Time_Add;
			parameters[5].Value = model.Order_Code;
			parameters[6].Value = model.Order_id;
			parameters[7].Value = model.Remark;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product_Stock_Log] ");
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
			strSql.Append("delete from [Lebi_Product_Stock_Log] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product_Stock_Log] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Product_Stock_Log GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product_Stock_Log] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Product_Stock_Log model=new Lebi_Product_Stock_Log();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_Stock"].ToString()!="")
				{
					model.Type_id_Stock=int.Parse(ds.Tables[0].Rows[0]["Type_id_Stock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
		public Lebi_Product_Stock_Log GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product_Stock_Log] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Product_Stock_Log model=new Lebi_Product_Stock_Log();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_Stock"].ToString()!="")
				{
					model.Type_id_Stock=int.Parse(ds.Tables[0].Rows[0]["Type_id_Stock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
		public Lebi_Product_Stock_Log GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Product_Stock_Log] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Product_Stock_Log model=new Lebi_Product_Stock_Log();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=decimal.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_Stock"].ToString()!="")
				{
					model.Type_id_Stock=int.Parse(ds.Tables[0].Rows[0]["Type_id_Stock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
		public List<Lebi_Product_Stock_Log> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Product_Stock_Log]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Product_Stock_Log> list = new List<Lebi_Product_Stock_Log>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Product_Stock_Log> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Product_Stock_Log]";
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
			List<Lebi_Product_Stock_Log> list = new List<Lebi_Product_Stock_Log>();
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
		public List<Lebi_Product_Stock_Log> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Product_Stock_Log] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Product_Stock_Log> list = new List<Lebi_Product_Stock_Log>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Product_Stock_Log> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Product_Stock_Log]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Product_Stock_Log> list = new List<Lebi_Product_Stock_Log>();
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
		public Lebi_Product_Stock_Log BindForm(Lebi_Product_Stock_Log model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestDecimal("Count",0);
			if (HttpContext.Current.Request["Type_id_Stock"] != null)
				model.Type_id_Stock=Shop.Tools.RequestTool.RequestInt("Type_id_Stock",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Product_Stock_Log SafeBindForm(Lebi_Product_Stock_Log model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestDecimal("Count",0);
			if (HttpContext.Current.Request["Type_id_Stock"] != null)
				model.Type_id_Stock=Shop.Tools.RequestTool.RequestInt("Type_id_Stock",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Product_Stock_Log ReaderBind(IDataReader dataReader)
		{
			Lebi_Product_Stock_Log model=new Lebi_Product_Stock_Log();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["Count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count=(decimal)ojb;
			}
			ojb = dataReader["Type_id_Stock"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_Stock=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			return model;
		}

	}
	class access_Lebi_Product_Stock_Log : Lebi_Product_Stock_Log_interface
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
				strSql.Append("select " + colName + " from [Lebi_Product_Stock_Log]");
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
			strSql.Append("select  "+colName+" from [Lebi_Product_Stock_Log]");
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
			strSql.Append("select count(*) from [Lebi_Product_Stock_Log]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Product_Stock_Log]");
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
			strSql.Append("select max(id) from [Lebi_Product_Stock_Log]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Product_Stock_Log]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Product_Stock_Log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Product_Stock_Log](");
			strSql.Append("[Product_id],[Count],[Type_id_Stock],[Time_Add],[Order_Code],[Order_id],[Remark])");
			strSql.Append(" values (");
			strSql.Append("@Product_id,@Count,@Type_id_Stock,@Time_Add,@Order_Code,@Order_id,@Remark)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Count", model.Count),
					new OleDbParameter("@Type_id_Stock", model.Type_id_Stock),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Remark", model.Remark)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Product_Stock_Log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Product_Stock_Log] set ");
			strSql.Append("[Product_id]=@Product_id,");
			strSql.Append("[Count]=@Count,");
			strSql.Append("[Type_id_Stock]=@Type_id_Stock,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Order_Code]=@Order_Code,");
			strSql.Append("[Order_id]=@Order_id,");
			strSql.Append("[Remark]=@Remark");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Count", model.Count),
					new OleDbParameter("@Type_id_Stock", model.Type_id_Stock),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Remark", model.Remark)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product_Stock_Log] ");
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
			strSql.Append("delete from [Lebi_Product_Stock_Log] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product_Stock_Log] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Product_Stock_Log GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product_Stock_Log] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Product_Stock_Log model;
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
		public Lebi_Product_Stock_Log GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product_Stock_Log] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Product_Stock_Log model;
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
		public Lebi_Product_Stock_Log GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Product_Stock_Log] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Product_Stock_Log model;
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
		public List<Lebi_Product_Stock_Log> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Product_Stock_Log]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Product_Stock_Log> list = new List<Lebi_Product_Stock_Log>();
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
		public List<Lebi_Product_Stock_Log> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Product_Stock_Log]";
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
			List<Lebi_Product_Stock_Log> list = new List<Lebi_Product_Stock_Log>();
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
		public List<Lebi_Product_Stock_Log> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Product_Stock_Log] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Product_Stock_Log> list = new List<Lebi_Product_Stock_Log>();
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
		public List<Lebi_Product_Stock_Log> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Product_Stock_Log]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Product_Stock_Log> list = new List<Lebi_Product_Stock_Log>();
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
		public Lebi_Product_Stock_Log BindForm(Lebi_Product_Stock_Log model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestDecimal("Count",0);
			if (HttpContext.Current.Request["Type_id_Stock"] != null)
				model.Type_id_Stock=Shop.Tools.RequestTool.RequestInt("Type_id_Stock",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Product_Stock_Log SafeBindForm(Lebi_Product_Stock_Log model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestDecimal("Count",0);
			if (HttpContext.Current.Request["Type_id_Stock"] != null)
				model.Type_id_Stock=Shop.Tools.RequestTool.RequestInt("Type_id_Stock",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Product_Stock_Log ReaderBind(IDataReader dataReader)
		{
			Lebi_Product_Stock_Log model=new Lebi_Product_Stock_Log();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["Count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count=(decimal)ojb;
			}
			ojb = dataReader["Type_id_Stock"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_Stock=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

