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

	public interface Lebi_Agent_UserLevel_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Agent_UserLevel model);
		void Update(Lebi_Agent_UserLevel model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Agent_UserLevel GetModel(int id);
		Lebi_Agent_UserLevel GetModel(string strWhere);
		Lebi_Agent_UserLevel GetModel(SQLPara para);
		List<Lebi_Agent_UserLevel> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Agent_UserLevel> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Agent_UserLevel> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Agent_UserLevel> GetList(SQLPara para);
		Lebi_Agent_UserLevel BindForm(Lebi_Agent_UserLevel model);
		Lebi_Agent_UserLevel SafeBindForm(Lebi_Agent_UserLevel model);
		Lebi_Agent_UserLevel ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Agent_UserLevel。
	/// </summary>
	public class D_Lebi_Agent_UserLevel
	{
		static Lebi_Agent_UserLevel_interface _Instance;
		public static Lebi_Agent_UserLevel_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Agent_UserLevel();
		            else
		                _Instance = new sqlserver_Lebi_Agent_UserLevel();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Agent_UserLevel()
		{}
		#region  成员方法
	class sqlserver_Lebi_Agent_UserLevel : Lebi_Agent_UserLevel_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_UserLevel]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_UserLevel]");
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
			strSql.Append("select count(1) from [Lebi_Agent_UserLevel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_UserLevel]");
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
			strSql.Append("select max(id) from [Lebi_Agent_UserLevel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_UserLevel]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_UserLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_UserLevel](");
			strSql.Append("UserLevel_id,Angent1_Commission,Angent2_Commission,Angent3_Commission)");
			strSql.Append(" values (");
			strSql.Append("@UserLevel_id,@Angent1_Commission,@Angent2_Commission,@Angent3_Commission)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserLevel_id", model.UserLevel_id),
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
		public void Update(Lebi_Agent_UserLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_UserLevel] set ");
			strSql.Append("UserLevel_id= @UserLevel_id,");
			strSql.Append("Angent1_Commission= @Angent1_Commission,");
			strSql.Append("Angent2_Commission= @Angent2_Commission,");
			strSql.Append("Angent3_Commission= @Angent3_Commission");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@UserLevel_id", SqlDbType.Int,4),
					new SqlParameter("@Angent1_Commission", SqlDbType.Decimal,9),
					new SqlParameter("@Angent2_Commission", SqlDbType.Decimal,9),
					new SqlParameter("@Angent3_Commission", SqlDbType.Decimal,9)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.UserLevel_id;
			parameters[2].Value = model.Angent1_Commission;
			parameters[3].Value = model.Angent2_Commission;
			parameters[4].Value = model.Angent3_Commission;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_UserLevel] ");
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
			strSql.Append("delete from [Lebi_Agent_UserLevel] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_UserLevel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_UserLevel GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_UserLevel] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Agent_UserLevel model=new Lebi_Agent_UserLevel();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
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
		public Lebi_Agent_UserLevel GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_UserLevel] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_UserLevel model=new Lebi_Agent_UserLevel();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
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
		public Lebi_Agent_UserLevel GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_UserLevel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_UserLevel model=new Lebi_Agent_UserLevel();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
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
		public List<Lebi_Agent_UserLevel> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_UserLevel]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_UserLevel> list = new List<Lebi_Agent_UserLevel>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Agent_UserLevel> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_UserLevel]";
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
			List<Lebi_Agent_UserLevel> list = new List<Lebi_Agent_UserLevel>();
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
		public List<Lebi_Agent_UserLevel> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_UserLevel] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_UserLevel> list = new List<Lebi_Agent_UserLevel>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Agent_UserLevel> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_UserLevel]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_UserLevel> list = new List<Lebi_Agent_UserLevel>();
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
		public Lebi_Agent_UserLevel BindForm(Lebi_Agent_UserLevel model)
		{
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
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
		public Lebi_Agent_UserLevel SafeBindForm(Lebi_Agent_UserLevel model)
		{
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
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
		public Lebi_Agent_UserLevel ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_UserLevel model=new Lebi_Agent_UserLevel();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["UserLevel_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLevel_id=(int)ojb;
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
	class access_Lebi_Agent_UserLevel : Lebi_Agent_UserLevel_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_UserLevel]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_UserLevel]");
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
			strSql.Append("select count(*) from [Lebi_Agent_UserLevel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Agent_UserLevel]");
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
			strSql.Append("select max(id) from [Lebi_Agent_UserLevel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_UserLevel]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_UserLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_UserLevel](");
			strSql.Append("[UserLevel_id],[Angent1_Commission],[Angent2_Commission],[Angent3_Commission])");
			strSql.Append(" values (");
			strSql.Append("@UserLevel_id,@Angent1_Commission,@Angent2_Commission,@Angent3_Commission)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@UserLevel_id", model.UserLevel_id),
					new OleDbParameter("@Angent1_Commission", model.Angent1_Commission),
					new OleDbParameter("@Angent2_Commission", model.Angent2_Commission),
					new OleDbParameter("@Angent3_Commission", model.Angent3_Commission)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Agent_UserLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_UserLevel] set ");
			strSql.Append("[UserLevel_id]=@UserLevel_id,");
			strSql.Append("[Angent1_Commission]=@Angent1_Commission,");
			strSql.Append("[Angent2_Commission]=@Angent2_Commission,");
			strSql.Append("[Angent3_Commission]=@Angent3_Commission");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@UserLevel_id", model.UserLevel_id),
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
			strSql.Append("delete from [Lebi_Agent_UserLevel] ");
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
			strSql.Append("delete from [Lebi_Agent_UserLevel] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_UserLevel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_UserLevel GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_UserLevel] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Agent_UserLevel model;
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
		public Lebi_Agent_UserLevel GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_UserLevel] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_UserLevel model;
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
		public Lebi_Agent_UserLevel GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_UserLevel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_UserLevel model;
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
		public List<Lebi_Agent_UserLevel> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_UserLevel]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_UserLevel> list = new List<Lebi_Agent_UserLevel>();
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
		public List<Lebi_Agent_UserLevel> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_UserLevel]";
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
			List<Lebi_Agent_UserLevel> list = new List<Lebi_Agent_UserLevel>();
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
		public List<Lebi_Agent_UserLevel> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_UserLevel] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_UserLevel> list = new List<Lebi_Agent_UserLevel>();
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
		public List<Lebi_Agent_UserLevel> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_UserLevel]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_UserLevel> list = new List<Lebi_Agent_UserLevel>();
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
		public Lebi_Agent_UserLevel BindForm(Lebi_Agent_UserLevel model)
		{
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
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
		public Lebi_Agent_UserLevel SafeBindForm(Lebi_Agent_UserLevel model)
		{
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
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
		public Lebi_Agent_UserLevel ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_UserLevel model=new Lebi_Agent_UserLevel();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["UserLevel_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLevel_id=(int)ojb;
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

