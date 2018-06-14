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

	public interface Lebi_Cash_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Cash model);
		void Update(Lebi_Cash model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Cash GetModel(int id);
		Lebi_Cash GetModel(string strWhere);
		Lebi_Cash GetModel(SQLPara para);
		List<Lebi_Cash> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Cash> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Cash> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Cash> GetList(SQLPara para);
		Lebi_Cash BindForm(Lebi_Cash model);
		Lebi_Cash SafeBindForm(Lebi_Cash model);
		Lebi_Cash ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Cash。
	/// </summary>
	public class D_Lebi_Cash
	{
		static Lebi_Cash_interface _Instance;
		public static Lebi_Cash_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Cash();
		            else
		                _Instance = new sqlserver_Lebi_Cash();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Cash()
		{}
		#region  成员方法
	class sqlserver_Lebi_Cash : Lebi_Cash_interface
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
				strSql.Append("select " + colName + " from [Lebi_Cash]");
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
			strSql.Append("select  "+colName+" from [Lebi_Cash]");
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
			strSql.Append("select count(1) from [Lebi_Cash]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Cash]");
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
			strSql.Append("select max(id) from [Lebi_Cash]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Cash]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Cash model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Cash](");
			strSql.Append("User_id,User_UserName,Bank,AccountCode,AccountName,Money,Type_id_CashStatus,Time_add,Time_update,Remark,Admin_UserName,Admin_id,Supplier_id,Supplier_SubName,Fee,PayType,DT_id)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_UserName,@Bank,@AccountCode,@AccountName,@Money,@Type_id_CashStatus,@Time_add,@Time_update,@Remark,@Admin_UserName,@Admin_id,@Supplier_id,@Supplier_SubName,@Fee,@PayType,@DT_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@User_UserName", model.User_UserName),
					new SqlParameter("@Bank", model.Bank),
					new SqlParameter("@AccountCode", model.AccountCode),
					new SqlParameter("@AccountName", model.AccountName),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@Type_id_CashStatus", model.Type_id_CashStatus),
					new SqlParameter("@Time_add", model.Time_add),
					new SqlParameter("@Time_update", model.Time_update),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Admin_UserName", model.Admin_UserName),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Supplier_SubName", model.Supplier_SubName),
					new SqlParameter("@Fee", model.Fee),
					new SqlParameter("@PayType", model.PayType),
					new SqlParameter("@DT_id", model.DT_id)};

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
		public void Update(Lebi_Cash model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Cash] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("User_UserName= @User_UserName,");
			strSql.Append("Bank= @Bank,");
			strSql.Append("AccountCode= @AccountCode,");
			strSql.Append("AccountName= @AccountName,");
			strSql.Append("Money= @Money,");
			strSql.Append("Type_id_CashStatus= @Type_id_CashStatus,");
			strSql.Append("Time_add= @Time_add,");
			strSql.Append("Time_update= @Time_update,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Admin_UserName= @Admin_UserName,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Supplier_SubName= @Supplier_SubName,");
			strSql.Append("Fee= @Fee,");
			strSql.Append("PayType= @PayType,");
			strSql.Append("DT_id= @DT_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,200),
					new SqlParameter("@Bank", SqlDbType.NVarChar,200),
					new SqlParameter("@AccountCode", SqlDbType.NVarChar,200),
					new SqlParameter("@AccountName", SqlDbType.NVarChar,200),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@Type_id_CashStatus", SqlDbType.Int,4),
					new SqlParameter("@Time_add", SqlDbType.DateTime),
					new SqlParameter("@Time_update", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@Admin_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Supplier_SubName", SqlDbType.NVarChar,100),
					new SqlParameter("@Fee", SqlDbType.Decimal,9),
					new SqlParameter("@PayType", SqlDbType.NVarChar,50),
					new SqlParameter("@DT_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.User_UserName;
			parameters[3].Value = model.Bank;
			parameters[4].Value = model.AccountCode;
			parameters[5].Value = model.AccountName;
			parameters[6].Value = model.Money;
			parameters[7].Value = model.Type_id_CashStatus;
			parameters[8].Value = model.Time_add;
			parameters[9].Value = model.Time_update;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.Admin_UserName;
			parameters[12].Value = model.Admin_id;
			parameters[13].Value = model.Supplier_id;
			parameters[14].Value = model.Supplier_SubName;
			parameters[15].Value = model.Fee;
			parameters[16].Value = model.PayType;
			parameters[17].Value = model.DT_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Cash] ");
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
			strSql.Append("delete from [Lebi_Cash] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Cash] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Cash GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Cash] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Cash model=new Lebi_Cash();
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
				model.Bank=ds.Tables[0].Rows[0]["Bank"].ToString();
				model.AccountCode=ds.Tables[0].Rows[0]["AccountCode"].ToString();
				model.AccountName=ds.Tables[0].Rows[0]["AccountName"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CashStatus"].ToString()!="")
				{
					model.Type_id_CashStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_CashStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_update"].ToString()!="")
				{
					model.Time_update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_update"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				if(ds.Tables[0].Rows[0]["Fee"].ToString()!="")
				{
					model.Fee=decimal.Parse(ds.Tables[0].Rows[0]["Fee"].ToString());
				}
				model.PayType=ds.Tables[0].Rows[0]["PayType"].ToString();
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
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
		public Lebi_Cash GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Cash] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Cash model=new Lebi_Cash();
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
				model.Bank=ds.Tables[0].Rows[0]["Bank"].ToString();
				model.AccountCode=ds.Tables[0].Rows[0]["AccountCode"].ToString();
				model.AccountName=ds.Tables[0].Rows[0]["AccountName"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CashStatus"].ToString()!="")
				{
					model.Type_id_CashStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_CashStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_update"].ToString()!="")
				{
					model.Time_update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_update"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				if(ds.Tables[0].Rows[0]["Fee"].ToString()!="")
				{
					model.Fee=decimal.Parse(ds.Tables[0].Rows[0]["Fee"].ToString());
				}
				model.PayType=ds.Tables[0].Rows[0]["PayType"].ToString();
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
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
		public Lebi_Cash GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Cash] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Cash model=new Lebi_Cash();
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
				model.Bank=ds.Tables[0].Rows[0]["Bank"].ToString();
				model.AccountCode=ds.Tables[0].Rows[0]["AccountCode"].ToString();
				model.AccountName=ds.Tables[0].Rows[0]["AccountName"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CashStatus"].ToString()!="")
				{
					model.Type_id_CashStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_CashStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_update"].ToString()!="")
				{
					model.Time_update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_update"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				if(ds.Tables[0].Rows[0]["Fee"].ToString()!="")
				{
					model.Fee=decimal.Parse(ds.Tables[0].Rows[0]["Fee"].ToString());
				}
				model.PayType=ds.Tables[0].Rows[0]["PayType"].ToString();
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
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
		public List<Lebi_Cash> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Cash]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Cash> list = new List<Lebi_Cash>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Cash> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Cash]";
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
			List<Lebi_Cash> list = new List<Lebi_Cash>();
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
		public List<Lebi_Cash> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Cash] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Cash> list = new List<Lebi_Cash>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Cash> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Cash]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Cash> list = new List<Lebi_Cash>();
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
		public Lebi_Cash BindForm(Lebi_Cash model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Bank"] != null)
				model.Bank=Shop.Tools.RequestTool.RequestString("Bank");
			if (HttpContext.Current.Request["AccountCode"] != null)
				model.AccountCode=Shop.Tools.RequestTool.RequestString("AccountCode");
			if (HttpContext.Current.Request["AccountName"] != null)
				model.AccountName=Shop.Tools.RequestTool.RequestString("AccountName");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Type_id_CashStatus"] != null)
				model.Type_id_CashStatus=Shop.Tools.RequestTool.RequestInt("Type_id_CashStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_update"] != null)
				model.Time_update=Shop.Tools.RequestTool.RequestTime("Time_update", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestString("Supplier_SubName");
			if (HttpContext.Current.Request["Fee"] != null)
				model.Fee=Shop.Tools.RequestTool.RequestDecimal("Fee",0);
			if (HttpContext.Current.Request["PayType"] != null)
				model.PayType=Shop.Tools.RequestTool.RequestString("PayType");
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Cash SafeBindForm(Lebi_Cash model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Bank"] != null)
				model.Bank=Shop.Tools.RequestTool.RequestSafeString("Bank");
			if (HttpContext.Current.Request["AccountCode"] != null)
				model.AccountCode=Shop.Tools.RequestTool.RequestSafeString("AccountCode");
			if (HttpContext.Current.Request["AccountName"] != null)
				model.AccountName=Shop.Tools.RequestTool.RequestSafeString("AccountName");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Type_id_CashStatus"] != null)
				model.Type_id_CashStatus=Shop.Tools.RequestTool.RequestInt("Type_id_CashStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_update"] != null)
				model.Time_update=Shop.Tools.RequestTool.RequestTime("Time_update", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestSafeString("Supplier_SubName");
			if (HttpContext.Current.Request["Fee"] != null)
				model.Fee=Shop.Tools.RequestTool.RequestDecimal("Fee",0);
			if (HttpContext.Current.Request["PayType"] != null)
				model.PayType=Shop.Tools.RequestTool.RequestSafeString("PayType");
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Cash ReaderBind(IDataReader dataReader)
		{
			Lebi_Cash model=new Lebi_Cash();
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
			model.Bank=dataReader["Bank"].ToString();
			model.AccountCode=dataReader["AccountCode"].ToString();
			model.AccountName=dataReader["AccountName"].ToString();
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Type_id_CashStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_CashStatus=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_update=(DateTime)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			model.Supplier_SubName=dataReader["Supplier_SubName"].ToString();
			ojb = dataReader["Fee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Fee=(decimal)ojb;
			}
			model.PayType=dataReader["PayType"].ToString();
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Cash : Lebi_Cash_interface
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
				strSql.Append("select " + colName + " from [Lebi_Cash]");
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
			strSql.Append("select  "+colName+" from [Lebi_Cash]");
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
			strSql.Append("select count(*) from [Lebi_Cash]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Cash]");
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
			strSql.Append("select max(id) from [Lebi_Cash]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Cash]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Cash model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Cash](");
			strSql.Append("[User_id],[User_UserName],[Bank],[AccountCode],[AccountName],[Money],[Type_id_CashStatus],[Time_add],[Time_update],[Remark],[Admin_UserName],[Admin_id],[Supplier_id],[Supplier_SubName],[Fee],[PayType],[DT_id])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_UserName,@Bank,@AccountCode,@AccountName,@Money,@Type_id_CashStatus,@Time_add,@Time_update,@Remark,@Admin_UserName,@Admin_id,@Supplier_id,@Supplier_SubName,@Fee,@PayType,@DT_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Bank", model.Bank),
					new OleDbParameter("@AccountCode", model.AccountCode),
					new OleDbParameter("@AccountName", model.AccountName),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Type_id_CashStatus", model.Type_id_CashStatus),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_update", model.Time_update.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Supplier_SubName", model.Supplier_SubName),
					new OleDbParameter("@Fee", model.Fee),
					new OleDbParameter("@PayType", model.PayType),
					new OleDbParameter("@DT_id", model.DT_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Cash model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Cash] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[User_UserName]=@User_UserName,");
			strSql.Append("[Bank]=@Bank,");
			strSql.Append("[AccountCode]=@AccountCode,");
			strSql.Append("[AccountName]=@AccountName,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[Type_id_CashStatus]=@Type_id_CashStatus,");
			strSql.Append("[Time_add]=@Time_add,");
			strSql.Append("[Time_update]=@Time_update,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Admin_UserName]=@Admin_UserName,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Supplier_SubName]=@Supplier_SubName,");
			strSql.Append("[Fee]=@Fee,");
			strSql.Append("[PayType]=@PayType,");
			strSql.Append("[DT_id]=@DT_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Bank", model.Bank),
					new OleDbParameter("@AccountCode", model.AccountCode),
					new OleDbParameter("@AccountName", model.AccountName),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Type_id_CashStatus", model.Type_id_CashStatus),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_update", model.Time_update.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Supplier_SubName", model.Supplier_SubName),
					new OleDbParameter("@Fee", model.Fee),
					new OleDbParameter("@PayType", model.PayType),
					new OleDbParameter("@DT_id", model.DT_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Cash] ");
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
			strSql.Append("delete from [Lebi_Cash] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Cash] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Cash GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Cash] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Cash model;
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
		public Lebi_Cash GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Cash] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Cash model;
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
		public Lebi_Cash GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Cash] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Cash model;
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
		public List<Lebi_Cash> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Cash]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Cash> list = new List<Lebi_Cash>();
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
		public List<Lebi_Cash> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Cash]";
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
			List<Lebi_Cash> list = new List<Lebi_Cash>();
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
		public List<Lebi_Cash> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Cash] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Cash> list = new List<Lebi_Cash>();
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
		public List<Lebi_Cash> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Cash]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Cash> list = new List<Lebi_Cash>();
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
		public Lebi_Cash BindForm(Lebi_Cash model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Bank"] != null)
				model.Bank=Shop.Tools.RequestTool.RequestString("Bank");
			if (HttpContext.Current.Request["AccountCode"] != null)
				model.AccountCode=Shop.Tools.RequestTool.RequestString("AccountCode");
			if (HttpContext.Current.Request["AccountName"] != null)
				model.AccountName=Shop.Tools.RequestTool.RequestString("AccountName");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Type_id_CashStatus"] != null)
				model.Type_id_CashStatus=Shop.Tools.RequestTool.RequestInt("Type_id_CashStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_update"] != null)
				model.Time_update=Shop.Tools.RequestTool.RequestTime("Time_update", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestString("Supplier_SubName");
			if (HttpContext.Current.Request["Fee"] != null)
				model.Fee=Shop.Tools.RequestTool.RequestDecimal("Fee",0);
			if (HttpContext.Current.Request["PayType"] != null)
				model.PayType=Shop.Tools.RequestTool.RequestString("PayType");
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Cash SafeBindForm(Lebi_Cash model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Bank"] != null)
				model.Bank=Shop.Tools.RequestTool.RequestSafeString("Bank");
			if (HttpContext.Current.Request["AccountCode"] != null)
				model.AccountCode=Shop.Tools.RequestTool.RequestSafeString("AccountCode");
			if (HttpContext.Current.Request["AccountName"] != null)
				model.AccountName=Shop.Tools.RequestTool.RequestSafeString("AccountName");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Type_id_CashStatus"] != null)
				model.Type_id_CashStatus=Shop.Tools.RequestTool.RequestInt("Type_id_CashStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_update"] != null)
				model.Time_update=Shop.Tools.RequestTool.RequestTime("Time_update", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestSafeString("Supplier_SubName");
			if (HttpContext.Current.Request["Fee"] != null)
				model.Fee=Shop.Tools.RequestTool.RequestDecimal("Fee",0);
			if (HttpContext.Current.Request["PayType"] != null)
				model.PayType=Shop.Tools.RequestTool.RequestSafeString("PayType");
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Cash ReaderBind(IDataReader dataReader)
		{
			Lebi_Cash model=new Lebi_Cash();
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
			model.Bank=dataReader["Bank"].ToString();
			model.AccountCode=dataReader["AccountCode"].ToString();
			model.AccountName=dataReader["AccountName"].ToString();
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Type_id_CashStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_CashStatus=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_update=(DateTime)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			model.Supplier_SubName=dataReader["Supplier_SubName"].ToString();
			ojb = dataReader["Fee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Fee=(decimal)ojb;
			}
			model.PayType=dataReader["PayType"].ToString();
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

