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

	public interface Lebi_DT_Agent_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_DT_Agent model);
		void Update(Lebi_DT_Agent model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_DT_Agent GetModel(int id);
		Lebi_DT_Agent GetModel(string strWhere);
		Lebi_DT_Agent GetModel(SQLPara para);
		List<Lebi_DT_Agent> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_DT_Agent> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_DT_Agent> GetList(string strWhere, string strFieldOrder);
		List<Lebi_DT_Agent> GetList(SQLPara para);
		Lebi_DT_Agent BindForm(Lebi_DT_Agent model);
		Lebi_DT_Agent SafeBindForm(Lebi_DT_Agent model);
		Lebi_DT_Agent ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_DT_Agent。
	/// </summary>
	public class D_Lebi_DT_Agent
	{
		static Lebi_DT_Agent_interface _Instance;
		public static Lebi_DT_Agent_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_DT_Agent();
		            else
		                _Instance = new sqlserver_Lebi_DT_Agent();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_DT_Agent()
		{}
		#region  成员方法
	class sqlserver_Lebi_DT_Agent : Lebi_DT_Agent_interface
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
				strSql.Append("select " + colName + " from [Lebi_DT_Agent]");
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
			strSql.Append("select  "+colName+" from [Lebi_DT_Agent]");
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
			strSql.Append("select count(1) from [Lebi_DT_Agent]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_DT_Agent]");
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
			strSql.Append("select max(id) from [Lebi_DT_Agent]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_DT_Agent]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_DT_Agent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_DT_Agent](");
			strSql.Append("IsUsedAgent,CommissionMoneyDays,DT_id,Angent1_Commission,Angent2_Commission,Angent3_Commission)");
			strSql.Append(" values (");
			strSql.Append("@IsUsedAgent,@CommissionMoneyDays,@DT_id,@Angent1_Commission,@Angent2_Commission,@Angent3_Commission)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@IsUsedAgent", model.IsUsedAgent),
					new SqlParameter("@CommissionMoneyDays", model.CommissionMoneyDays),
					new SqlParameter("@DT_id", model.DT_id),
					new SqlParameter("@Angent1_Commission", model.Angent1_Commission),
					new SqlParameter("@Angent2_Commission", model.Angent2_Commission),
					new SqlParameter("@Angent3_Commission", model.Angent3_Commission)};

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
		public void Update(Lebi_DT_Agent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_DT_Agent] set ");
			strSql.Append("IsUsedAgent= @IsUsedAgent,");
			strSql.Append("CommissionMoneyDays= @CommissionMoneyDays,");
			strSql.Append("DT_id= @DT_id,");
			strSql.Append("Angent1_Commission= @Angent1_Commission,");
			strSql.Append("Angent2_Commission= @Angent2_Commission,");
			strSql.Append("Angent3_Commission= @Angent3_Commission");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@IsUsedAgent", SqlDbType.Int,4),
					new SqlParameter("@CommissionMoneyDays", SqlDbType.Int,4),
					new SqlParameter("@DT_id", SqlDbType.Int,4),
					new SqlParameter("@Angent1_Commission", SqlDbType.Decimal,9),
					new SqlParameter("@Angent2_Commission", SqlDbType.Decimal,9),
					new SqlParameter("@Angent3_Commission", SqlDbType.Decimal,9)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.IsUsedAgent;
			parameters[2].Value = model.CommissionMoneyDays;
			parameters[3].Value = model.DT_id;
			parameters[4].Value = model.Angent1_Commission;
			parameters[5].Value = model.Angent2_Commission;
			parameters[6].Value = model.Angent3_Commission;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT_Agent] ");
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
			strSql.Append("delete from [Lebi_DT_Agent] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT_Agent] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_DT_Agent GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT_Agent] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_DT_Agent model=new Lebi_DT_Agent();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString()!="")
				{
					model.IsUsedAgent=int.Parse(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CommissionMoneyDays"].ToString()!="")
				{
					model.CommissionMoneyDays=int.Parse(ds.Tables[0].Rows[0]["CommissionMoneyDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Angent1_Commission"].ToString()!="")
				{
					model.Angent1_Commission=decimal.Parse(ds.Tables[0].Rows[0]["Angent1_Commission"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Angent2_Commission"].ToString()!="")
				{
					model.Angent2_Commission=decimal.Parse(ds.Tables[0].Rows[0]["Angent2_Commission"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Angent3_Commission"].ToString()!="")
				{
					model.Angent3_Commission=decimal.Parse(ds.Tables[0].Rows[0]["Angent3_Commission"].ToString());
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
		public Lebi_DT_Agent GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT_Agent] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_DT_Agent model=new Lebi_DT_Agent();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString()!="")
				{
					model.IsUsedAgent=int.Parse(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CommissionMoneyDays"].ToString()!="")
				{
					model.CommissionMoneyDays=int.Parse(ds.Tables[0].Rows[0]["CommissionMoneyDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Angent1_Commission"].ToString()!="")
				{
					model.Angent1_Commission=decimal.Parse(ds.Tables[0].Rows[0]["Angent1_Commission"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Angent2_Commission"].ToString()!="")
				{
					model.Angent2_Commission=decimal.Parse(ds.Tables[0].Rows[0]["Angent2_Commission"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Angent3_Commission"].ToString()!="")
				{
					model.Angent3_Commission=decimal.Parse(ds.Tables[0].Rows[0]["Angent3_Commission"].ToString());
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
		public Lebi_DT_Agent GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_DT_Agent] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_DT_Agent model=new Lebi_DT_Agent();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString()!="")
				{
					model.IsUsedAgent=int.Parse(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CommissionMoneyDays"].ToString()!="")
				{
					model.CommissionMoneyDays=int.Parse(ds.Tables[0].Rows[0]["CommissionMoneyDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Angent1_Commission"].ToString()!="")
				{
					model.Angent1_Commission=decimal.Parse(ds.Tables[0].Rows[0]["Angent1_Commission"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Angent2_Commission"].ToString()!="")
				{
					model.Angent2_Commission=decimal.Parse(ds.Tables[0].Rows[0]["Angent2_Commission"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Angent3_Commission"].ToString()!="")
				{
					model.Angent3_Commission=decimal.Parse(ds.Tables[0].Rows[0]["Angent3_Commission"].ToString());
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
		public List<Lebi_DT_Agent> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_DT_Agent]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_DT_Agent> list = new List<Lebi_DT_Agent>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_DT_Agent> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_DT_Agent]";
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
			List<Lebi_DT_Agent> list = new List<Lebi_DT_Agent>();
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
		public List<Lebi_DT_Agent> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_DT_Agent] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_DT_Agent> list = new List<Lebi_DT_Agent>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_DT_Agent> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_DT_Agent]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_DT_Agent> list = new List<Lebi_DT_Agent>();
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
		public Lebi_DT_Agent BindForm(Lebi_DT_Agent model)
		{
			if (HttpContext.Current.Request["IsUsedAgent"] != null)
				model.IsUsedAgent=Shop.Tools.RequestTool.RequestInt("IsUsedAgent",0);
			if (HttpContext.Current.Request["CommissionMoneyDays"] != null)
				model.CommissionMoneyDays=Shop.Tools.RequestTool.RequestInt("CommissionMoneyDays",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["Angent1_Commission"] != null)
				model.Angent1_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent1_Commission",0);
			if (HttpContext.Current.Request["Angent2_Commission"] != null)
				model.Angent2_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent2_Commission",0);
			if (HttpContext.Current.Request["Angent3_Commission"] != null)
				model.Angent3_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent3_Commission",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_DT_Agent SafeBindForm(Lebi_DT_Agent model)
		{
			if (HttpContext.Current.Request["IsUsedAgent"] != null)
				model.IsUsedAgent=Shop.Tools.RequestTool.RequestInt("IsUsedAgent",0);
			if (HttpContext.Current.Request["CommissionMoneyDays"] != null)
				model.CommissionMoneyDays=Shop.Tools.RequestTool.RequestInt("CommissionMoneyDays",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["Angent1_Commission"] != null)
				model.Angent1_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent1_Commission",0);
			if (HttpContext.Current.Request["Angent2_Commission"] != null)
				model.Angent2_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent2_Commission",0);
			if (HttpContext.Current.Request["Angent3_Commission"] != null)
				model.Angent3_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent3_Commission",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_DT_Agent ReaderBind(IDataReader dataReader)
		{
			Lebi_DT_Agent model=new Lebi_DT_Agent();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["IsUsedAgent"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUsedAgent=(int)ojb;
			}
			ojb = dataReader["CommissionMoneyDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CommissionMoneyDays=(int)ojb;
			}
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			ojb = dataReader["Angent1_Commission"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Angent1_Commission=(decimal)ojb;
			}
			ojb = dataReader["Angent2_Commission"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Angent2_Commission=(decimal)ojb;
			}
			ojb = dataReader["Angent3_Commission"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Angent3_Commission=(decimal)ojb;
			}
			return model;
		}

	}
	class access_Lebi_DT_Agent : Lebi_DT_Agent_interface
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
				strSql.Append("select " + colName + " from [Lebi_DT_Agent]");
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
			strSql.Append("select  "+colName+" from [Lebi_DT_Agent]");
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
			strSql.Append("select count(*) from [Lebi_DT_Agent]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_DT_Agent]");
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
			strSql.Append("select max(id) from [Lebi_DT_Agent]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_DT_Agent]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_DT_Agent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_DT_Agent](");
			strSql.Append("[IsUsedAgent],[CommissionMoneyDays],[DT_id],[Angent1_Commission],[Angent2_Commission],[Angent3_Commission])");
			strSql.Append(" values (");
			strSql.Append("@IsUsedAgent,@CommissionMoneyDays,@DT_id,@Angent1_Commission,@Angent2_Commission,@Angent3_Commission)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@IsUsedAgent", model.IsUsedAgent),
					new OleDbParameter("@CommissionMoneyDays", model.CommissionMoneyDays),
					new OleDbParameter("@DT_id", model.DT_id),
					new OleDbParameter("@Angent1_Commission", model.Angent1_Commission),
					new OleDbParameter("@Angent2_Commission", model.Angent2_Commission),
					new OleDbParameter("@Angent3_Commission", model.Angent3_Commission)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_DT_Agent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_DT_Agent] set ");
			strSql.Append("[IsUsedAgent]=@IsUsedAgent,");
			strSql.Append("[CommissionMoneyDays]=@CommissionMoneyDays,");
			strSql.Append("[DT_id]=@DT_id,");
			strSql.Append("[Angent1_Commission]=@Angent1_Commission,");
			strSql.Append("[Angent2_Commission]=@Angent2_Commission,");
			strSql.Append("[Angent3_Commission]=@Angent3_Commission");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@IsUsedAgent", model.IsUsedAgent),
					new OleDbParameter("@CommissionMoneyDays", model.CommissionMoneyDays),
					new OleDbParameter("@DT_id", model.DT_id),
					new OleDbParameter("@Angent1_Commission", model.Angent1_Commission),
					new OleDbParameter("@Angent2_Commission", model.Angent2_Commission),
					new OleDbParameter("@Angent3_Commission", model.Angent3_Commission)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT_Agent] ");
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
			strSql.Append("delete from [Lebi_DT_Agent] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT_Agent] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_DT_Agent GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT_Agent] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_DT_Agent model;
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
		public Lebi_DT_Agent GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT_Agent] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_DT_Agent model;
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
		public Lebi_DT_Agent GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_DT_Agent] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_DT_Agent model;
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
		public List<Lebi_DT_Agent> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_DT_Agent]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_DT_Agent> list = new List<Lebi_DT_Agent>();
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
		public List<Lebi_DT_Agent> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_DT_Agent]";
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
			List<Lebi_DT_Agent> list = new List<Lebi_DT_Agent>();
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
		public List<Lebi_DT_Agent> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_DT_Agent] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_DT_Agent> list = new List<Lebi_DT_Agent>();
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
		public List<Lebi_DT_Agent> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_DT_Agent]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_DT_Agent> list = new List<Lebi_DT_Agent>();
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
		public Lebi_DT_Agent BindForm(Lebi_DT_Agent model)
		{
			if (HttpContext.Current.Request["IsUsedAgent"] != null)
				model.IsUsedAgent=Shop.Tools.RequestTool.RequestInt("IsUsedAgent",0);
			if (HttpContext.Current.Request["CommissionMoneyDays"] != null)
				model.CommissionMoneyDays=Shop.Tools.RequestTool.RequestInt("CommissionMoneyDays",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["Angent1_Commission"] != null)
				model.Angent1_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent1_Commission",0);
			if (HttpContext.Current.Request["Angent2_Commission"] != null)
				model.Angent2_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent2_Commission",0);
			if (HttpContext.Current.Request["Angent3_Commission"] != null)
				model.Angent3_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent3_Commission",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_DT_Agent SafeBindForm(Lebi_DT_Agent model)
		{
			if (HttpContext.Current.Request["IsUsedAgent"] != null)
				model.IsUsedAgent=Shop.Tools.RequestTool.RequestInt("IsUsedAgent",0);
			if (HttpContext.Current.Request["CommissionMoneyDays"] != null)
				model.CommissionMoneyDays=Shop.Tools.RequestTool.RequestInt("CommissionMoneyDays",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["Angent1_Commission"] != null)
				model.Angent1_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent1_Commission",0);
			if (HttpContext.Current.Request["Angent2_Commission"] != null)
				model.Angent2_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent2_Commission",0);
			if (HttpContext.Current.Request["Angent3_Commission"] != null)
				model.Angent3_Commission=Shop.Tools.RequestTool.RequestDecimal("Angent3_Commission",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_DT_Agent ReaderBind(IDataReader dataReader)
		{
			Lebi_DT_Agent model=new Lebi_DT_Agent();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["IsUsedAgent"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUsedAgent=(int)ojb;
			}
			ojb = dataReader["CommissionMoneyDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CommissionMoneyDays=(int)ojb;
			}
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			ojb = dataReader["Angent1_Commission"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Angent1_Commission=(decimal)ojb;
			}
			ojb = dataReader["Angent2_Commission"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Angent2_Commission=(decimal)ojb;
			}
			ojb = dataReader["Angent3_Commission"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Angent3_Commission=(decimal)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

