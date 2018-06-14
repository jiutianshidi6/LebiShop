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

	public interface Lebi_Agent_Area_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Agent_Area model);
		void Update(Lebi_Agent_Area model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Agent_Area GetModel(int id);
		Lebi_Agent_Area GetModel(string strWhere);
		Lebi_Agent_Area GetModel(SQLPara para);
		List<Lebi_Agent_Area> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Agent_Area> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Agent_Area> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Agent_Area> GetList(SQLPara para);
		Lebi_Agent_Area BindForm(Lebi_Agent_Area model);
		Lebi_Agent_Area SafeBindForm(Lebi_Agent_Area model);
		Lebi_Agent_Area ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Agent_Area。
	/// </summary>
	public class D_Lebi_Agent_Area
	{
		static Lebi_Agent_Area_interface _Instance;
		public static Lebi_Agent_Area_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Agent_Area();
		            else
		                _Instance = new sqlserver_Lebi_Agent_Area();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Agent_Area()
		{}
		#region  成员方法
	class sqlserver_Lebi_Agent_Area : Lebi_Agent_Area_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_Area]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_Area]");
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
			strSql.Append("select count(1) from [Lebi_Agent_Area]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Area]");
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
			strSql.Append("select max(id) from [Lebi_Agent_Area]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Area]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_Area model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_Area](");
			strSql.Append("User_id,User_UserName,Area_id,Time_add,Time_end,Commission_1,Commission_2,Admin_id,Admin_UserName,Remark,IsFailure,Price,CardOrder_id)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_UserName,@Area_id,@Time_add,@Time_end,@Commission_1,@Commission_2,@Admin_id,@Admin_UserName,@Remark,@IsFailure,@Price,@CardOrder_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@User_UserName", model.User_UserName),
					new SqlParameter("@Area_id", model.Area_id),
					new SqlParameter("@Time_add", model.Time_add),
					new SqlParameter("@Time_end", model.Time_end),
					new SqlParameter("@Commission_1", model.Commission_1),
					new SqlParameter("@Commission_2", model.Commission_2),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@Admin_UserName", model.Admin_UserName),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@IsFailure", model.IsFailure),
					new SqlParameter("@Price", model.Price),
					new SqlParameter("@CardOrder_id", model.CardOrder_id)};

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
		public void Update(Lebi_Agent_Area model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_Area] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("User_UserName= @User_UserName,");
			strSql.Append("Area_id= @Area_id,");
			strSql.Append("Time_add= @Time_add,");
			strSql.Append("Time_end= @Time_end,");
			strSql.Append("Commission_1= @Commission_1,");
			strSql.Append("Commission_2= @Commission_2,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("Admin_UserName= @Admin_UserName,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("IsFailure= @IsFailure,");
			strSql.Append("Price= @Price,");
			strSql.Append("CardOrder_id= @CardOrder_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Area_id", SqlDbType.Int,4),
					new SqlParameter("@Time_add", SqlDbType.DateTime),
					new SqlParameter("@Time_end", SqlDbType.DateTime),
					new SqlParameter("@Commission_1", SqlDbType.Decimal,9),
					new SqlParameter("@Commission_2", SqlDbType.Decimal,9),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@Admin_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					new SqlParameter("@IsFailure", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@CardOrder_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.User_UserName;
			parameters[3].Value = model.Area_id;
			parameters[4].Value = model.Time_add;
			parameters[5].Value = model.Time_end;
			parameters[6].Value = model.Commission_1;
			parameters[7].Value = model.Commission_2;
			parameters[8].Value = model.Admin_id;
			parameters[9].Value = model.Admin_UserName;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.IsFailure;
			parameters[12].Value = model.Price;
			parameters[13].Value = model.CardOrder_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Area] ");
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
			strSql.Append("delete from [Lebi_Agent_Area] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Area] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_Area GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Area] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Agent_Area model=new Lebi_Agent_Area();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_end"].ToString()!="")
				{
					model.Time_end=DateTime.Parse(ds.Tables[0].Rows[0]["Time_end"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Commission_1"].ToString()!="")
				{
					model.Commission_1=decimal.Parse(ds.Tables[0].Rows[0]["Commission_1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Commission_2"].ToString()!="")
				{
					model.Commission_2=decimal.Parse(ds.Tables[0].Rows[0]["Commission_2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["IsFailure"].ToString()!="")
				{
					model.IsFailure=int.Parse(ds.Tables[0].Rows[0]["IsFailure"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardOrder_id"].ToString()!="")
				{
					model.CardOrder_id=int.Parse(ds.Tables[0].Rows[0]["CardOrder_id"].ToString());
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
		public Lebi_Agent_Area GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Area] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_Area model=new Lebi_Agent_Area();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_end"].ToString()!="")
				{
					model.Time_end=DateTime.Parse(ds.Tables[0].Rows[0]["Time_end"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Commission_1"].ToString()!="")
				{
					model.Commission_1=decimal.Parse(ds.Tables[0].Rows[0]["Commission_1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Commission_2"].ToString()!="")
				{
					model.Commission_2=decimal.Parse(ds.Tables[0].Rows[0]["Commission_2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["IsFailure"].ToString()!="")
				{
					model.IsFailure=int.Parse(ds.Tables[0].Rows[0]["IsFailure"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardOrder_id"].ToString()!="")
				{
					model.CardOrder_id=int.Parse(ds.Tables[0].Rows[0]["CardOrder_id"].ToString());
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
		public Lebi_Agent_Area GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_Area] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_Area model=new Lebi_Agent_Area();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_end"].ToString()!="")
				{
					model.Time_end=DateTime.Parse(ds.Tables[0].Rows[0]["Time_end"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Commission_1"].ToString()!="")
				{
					model.Commission_1=decimal.Parse(ds.Tables[0].Rows[0]["Commission_1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Commission_2"].ToString()!="")
				{
					model.Commission_2=decimal.Parse(ds.Tables[0].Rows[0]["Commission_2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["IsFailure"].ToString()!="")
				{
					model.IsFailure=int.Parse(ds.Tables[0].Rows[0]["IsFailure"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardOrder_id"].ToString()!="")
				{
					model.CardOrder_id=int.Parse(ds.Tables[0].Rows[0]["CardOrder_id"].ToString());
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
		public List<Lebi_Agent_Area> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_Area]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_Area> list = new List<Lebi_Agent_Area>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Agent_Area> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_Area]";
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
			List<Lebi_Agent_Area> list = new List<Lebi_Agent_Area>();
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
		public List<Lebi_Agent_Area> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_Area] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_Area> list = new List<Lebi_Agent_Area>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Agent_Area> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_Area]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_Area> list = new List<Lebi_Agent_Area>();
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
		public Lebi_Agent_Area BindForm(Lebi_Agent_Area model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_end"] != null)
				model.Time_end=Shop.Tools.RequestTool.RequestTime("Time_end", System.DateTime.Now);
			if (HttpContext.Current.Request["Commission_1"] != null)
				model.Commission_1=Shop.Tools.RequestTool.RequestDecimal("Commission_1",0);
			if (HttpContext.Current.Request["Commission_2"] != null)
				model.Commission_2=Shop.Tools.RequestTool.RequestDecimal("Commission_2",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["IsFailure"] != null)
				model.IsFailure=Shop.Tools.RequestTool.RequestInt("IsFailure",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Agent_Area SafeBindForm(Lebi_Agent_Area model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_end"] != null)
				model.Time_end=Shop.Tools.RequestTool.RequestTime("Time_end", System.DateTime.Now);
			if (HttpContext.Current.Request["Commission_1"] != null)
				model.Commission_1=Shop.Tools.RequestTool.RequestDecimal("Commission_1",0);
			if (HttpContext.Current.Request["Commission_2"] != null)
				model.Commission_2=Shop.Tools.RequestTool.RequestDecimal("Commission_2",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["IsFailure"] != null)
				model.IsFailure=Shop.Tools.RequestTool.RequestInt("IsFailure",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Agent_Area ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_Area model=new Lebi_Agent_Area();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_end"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_end=(DateTime)ojb;
			}
			ojb = dataReader["Commission_1"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Commission_1=(decimal)ojb;
			}
			ojb = dataReader["Commission_2"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Commission_2=(decimal)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["IsFailure"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsFailure=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			ojb = dataReader["CardOrder_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CardOrder_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Agent_Area : Lebi_Agent_Area_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_Area]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_Area]");
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
			strSql.Append("select count(*) from [Lebi_Agent_Area]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Agent_Area]");
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
			strSql.Append("select max(id) from [Lebi_Agent_Area]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Area]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_Area model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_Area](");
			strSql.Append("[User_id],[User_UserName],[Area_id],[Time_add],[Time_end],[Commission_1],[Commission_2],[Admin_id],[Admin_UserName],[Remark],[IsFailure],[Price],[CardOrder_id])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_UserName,@Area_id,@Time_add,@Time_end,@Commission_1,@Commission_2,@Admin_id,@Admin_UserName,@Remark,@IsFailure,@Price,@CardOrder_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_end", model.Time_end.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Commission_1", model.Commission_1),
					new OleDbParameter("@Commission_2", model.Commission_2),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@IsFailure", model.IsFailure),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@CardOrder_id", model.CardOrder_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Agent_Area model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_Area] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[User_UserName]=@User_UserName,");
			strSql.Append("[Area_id]=@Area_id,");
			strSql.Append("[Time_add]=@Time_add,");
			strSql.Append("[Time_end]=@Time_end,");
			strSql.Append("[Commission_1]=@Commission_1,");
			strSql.Append("[Commission_2]=@Commission_2,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[Admin_UserName]=@Admin_UserName,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[IsFailure]=@IsFailure,");
			strSql.Append("[Price]=@Price,");
			strSql.Append("[CardOrder_id]=@CardOrder_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_end", model.Time_end.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Commission_1", model.Commission_1),
					new OleDbParameter("@Commission_2", model.Commission_2),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@IsFailure", model.IsFailure),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@CardOrder_id", model.CardOrder_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Area] ");
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
			strSql.Append("delete from [Lebi_Agent_Area] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Area] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_Area GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Area] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Agent_Area model;
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
		public Lebi_Agent_Area GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Area] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_Area model;
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
		public Lebi_Agent_Area GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_Area] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_Area model;
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
		public List<Lebi_Agent_Area> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_Area]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_Area> list = new List<Lebi_Agent_Area>();
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
		public List<Lebi_Agent_Area> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_Area]";
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
			List<Lebi_Agent_Area> list = new List<Lebi_Agent_Area>();
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
		public List<Lebi_Agent_Area> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_Area] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_Area> list = new List<Lebi_Agent_Area>();
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
		public List<Lebi_Agent_Area> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_Area]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_Area> list = new List<Lebi_Agent_Area>();
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
		public Lebi_Agent_Area BindForm(Lebi_Agent_Area model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_end"] != null)
				model.Time_end=Shop.Tools.RequestTool.RequestTime("Time_end", System.DateTime.Now);
			if (HttpContext.Current.Request["Commission_1"] != null)
				model.Commission_1=Shop.Tools.RequestTool.RequestDecimal("Commission_1",0);
			if (HttpContext.Current.Request["Commission_2"] != null)
				model.Commission_2=Shop.Tools.RequestTool.RequestDecimal("Commission_2",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["IsFailure"] != null)
				model.IsFailure=Shop.Tools.RequestTool.RequestInt("IsFailure",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Agent_Area SafeBindForm(Lebi_Agent_Area model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_end"] != null)
				model.Time_end=Shop.Tools.RequestTool.RequestTime("Time_end", System.DateTime.Now);
			if (HttpContext.Current.Request["Commission_1"] != null)
				model.Commission_1=Shop.Tools.RequestTool.RequestDecimal("Commission_1",0);
			if (HttpContext.Current.Request["Commission_2"] != null)
				model.Commission_2=Shop.Tools.RequestTool.RequestDecimal("Commission_2",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["IsFailure"] != null)
				model.IsFailure=Shop.Tools.RequestTool.RequestInt("IsFailure",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Agent_Area ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_Area model=new Lebi_Agent_Area();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_end"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_end=(DateTime)ojb;
			}
			ojb = dataReader["Commission_1"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Commission_1=(decimal)ojb;
			}
			ojb = dataReader["Commission_2"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Commission_2=(decimal)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["IsFailure"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsFailure=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			ojb = dataReader["CardOrder_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CardOrder_id=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

