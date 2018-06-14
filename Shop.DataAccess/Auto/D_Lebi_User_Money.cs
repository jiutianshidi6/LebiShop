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

	public interface Lebi_User_Money_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_User_Money model);
		void Update(Lebi_User_Money model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_User_Money GetModel(int id);
		Lebi_User_Money GetModel(string strWhere);
		Lebi_User_Money GetModel(SQLPara para);
		List<Lebi_User_Money> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_User_Money> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_User_Money> GetList(string strWhere, string strFieldOrder);
		List<Lebi_User_Money> GetList(SQLPara para);
		Lebi_User_Money BindForm(Lebi_User_Money model);
		Lebi_User_Money SafeBindForm(Lebi_User_Money model);
		Lebi_User_Money ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_User_Money。
	/// </summary>
	public class D_Lebi_User_Money
	{
		static Lebi_User_Money_interface _Instance;
		public static Lebi_User_Money_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_User_Money();
		            else
		                _Instance = new sqlserver_Lebi_User_Money();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_User_Money()
		{}
		#region  成员方法
	class sqlserver_Lebi_User_Money : Lebi_User_Money_interface
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
				strSql.Append("select " + colName + " from [Lebi_User_Money]");
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
			strSql.Append("select  "+colName+" from [Lebi_User_Money]");
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
			strSql.Append("select count(1) from [Lebi_User_Money]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User_Money]");
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
			strSql.Append("select max(id) from [Lebi_User_Money]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User_Money]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_User_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_User_Money](");
			strSql.Append("User_id,Money,Time_Add,Type_id_MoneyStatus,Type_id_MoneyType,Admin_id,Description,Order_id,Order_Code,Time_Update,User_UserName,Admin_UserName,User_RealName,Remark,Money_after,Money_fanxian_after,DT_id)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Money,@Time_Add,@Type_id_MoneyStatus,@Type_id_MoneyType,@Admin_id,@Description,@Order_id,@Order_Code,@Time_Update,@User_UserName,@Admin_UserName,@User_RealName,@Remark,@Money_after,@Money_fanxian_after,@DT_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Type_id_MoneyStatus", model.Type_id_MoneyStatus),
					new SqlParameter("@Type_id_MoneyType", model.Type_id_MoneyType),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@Order_id", model.Order_id),
					new SqlParameter("@Order_Code", model.Order_Code),
					new SqlParameter("@Time_Update", model.Time_Update),
					new SqlParameter("@User_UserName", model.User_UserName),
					new SqlParameter("@Admin_UserName", model.Admin_UserName),
					new SqlParameter("@User_RealName", model.User_RealName),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Money_after", model.Money_after),
					new SqlParameter("@Money_fanxian_after", model.Money_fanxian_after),
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
		public void Update(Lebi_User_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_User_Money] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("Money= @Money,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Type_id_MoneyStatus= @Type_id_MoneyStatus,");
			strSql.Append("Type_id_MoneyType= @Type_id_MoneyType,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("Description= @Description,");
			strSql.Append("Order_id= @Order_id,");
			strSql.Append("Order_Code= @Order_Code,");
			strSql.Append("Time_Update= @Time_Update,");
			strSql.Append("User_UserName= @User_UserName,");
			strSql.Append("Admin_UserName= @Admin_UserName,");
			strSql.Append("User_RealName= @User_RealName,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Money_after= @Money_after,");
			strSql.Append("Money_fanxian_after= @Money_fanxian_after,");
			strSql.Append("DT_id= @DT_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Type_id_MoneyStatus", SqlDbType.Int,4),
					new SqlParameter("@Type_id_MoneyType", SqlDbType.Int,4),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,200),
					new SqlParameter("@Order_id", SqlDbType.Int,4),
					new SqlParameter("@Order_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Time_Update", SqlDbType.DateTime),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Admin_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@User_RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@Money_after", SqlDbType.Decimal,9),
					new SqlParameter("@Money_fanxian_after", SqlDbType.Decimal,9),
					new SqlParameter("@DT_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.Money;
			parameters[3].Value = model.Time_Add;
			parameters[4].Value = model.Type_id_MoneyStatus;
			parameters[5].Value = model.Type_id_MoneyType;
			parameters[6].Value = model.Admin_id;
			parameters[7].Value = model.Description;
			parameters[8].Value = model.Order_id;
			parameters[9].Value = model.Order_Code;
			parameters[10].Value = model.Time_Update;
			parameters[11].Value = model.User_UserName;
			parameters[12].Value = model.Admin_UserName;
			parameters[13].Value = model.User_RealName;
			parameters[14].Value = model.Remark;
			parameters[15].Value = model.Money_after;
			parameters[16].Value = model.Money_fanxian_after;
			parameters[17].Value = model.DT_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Money] ");
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
			strSql.Append("delete from [Lebi_User_Money] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Money] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_User_Money GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Money] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_User_Money model=new Lebi_User_Money();
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
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_MoneyStatus"].ToString()!="")
				{
					model.Type_id_MoneyStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_MoneyStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_MoneyType"].ToString()!="")
				{
					model.Type_id_MoneyType=int.Parse(ds.Tables[0].Rows[0]["Type_id_MoneyType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.User_RealName=ds.Tables[0].Rows[0]["User_RealName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Money_after"].ToString()!="")
				{
					model.Money_after=decimal.Parse(ds.Tables[0].Rows[0]["Money_after"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_fanxian_after"].ToString()!="")
				{
					model.Money_fanxian_after=decimal.Parse(ds.Tables[0].Rows[0]["Money_fanxian_after"].ToString());
				}
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
		public Lebi_User_Money GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Money] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_User_Money model=new Lebi_User_Money();
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
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_MoneyStatus"].ToString()!="")
				{
					model.Type_id_MoneyStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_MoneyStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_MoneyType"].ToString()!="")
				{
					model.Type_id_MoneyType=int.Parse(ds.Tables[0].Rows[0]["Type_id_MoneyType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.User_RealName=ds.Tables[0].Rows[0]["User_RealName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Money_after"].ToString()!="")
				{
					model.Money_after=decimal.Parse(ds.Tables[0].Rows[0]["Money_after"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_fanxian_after"].ToString()!="")
				{
					model.Money_fanxian_after=decimal.Parse(ds.Tables[0].Rows[0]["Money_fanxian_after"].ToString());
				}
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
		public Lebi_User_Money GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_User_Money] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_User_Money model=new Lebi_User_Money();
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
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_MoneyStatus"].ToString()!="")
				{
					model.Type_id_MoneyStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_MoneyStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_MoneyType"].ToString()!="")
				{
					model.Type_id_MoneyType=int.Parse(ds.Tables[0].Rows[0]["Type_id_MoneyType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.User_RealName=ds.Tables[0].Rows[0]["User_RealName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Money_after"].ToString()!="")
				{
					model.Money_after=decimal.Parse(ds.Tables[0].Rows[0]["Money_after"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_fanxian_after"].ToString()!="")
				{
					model.Money_fanxian_after=decimal.Parse(ds.Tables[0].Rows[0]["Money_fanxian_after"].ToString());
				}
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
		public List<Lebi_User_Money> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_User_Money]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_User_Money> list = new List<Lebi_User_Money>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_User_Money> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_User_Money]";
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
			List<Lebi_User_Money> list = new List<Lebi_User_Money>();
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
		public List<Lebi_User_Money> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_User_Money] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_User_Money> list = new List<Lebi_User_Money>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_User_Money> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_User_Money]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_User_Money> list = new List<Lebi_User_Money>();
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
		public Lebi_User_Money BindForm(Lebi_User_Money model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_MoneyStatus"] != null)
				model.Type_id_MoneyStatus=Shop.Tools.RequestTool.RequestInt("Type_id_MoneyStatus",0);
			if (HttpContext.Current.Request["Type_id_MoneyType"] != null)
				model.Type_id_MoneyType=Shop.Tools.RequestTool.RequestInt("Type_id_MoneyType",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["User_RealName"] != null)
				model.User_RealName=Shop.Tools.RequestTool.RequestString("User_RealName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Money_after"] != null)
				model.Money_after=Shop.Tools.RequestTool.RequestDecimal("Money_after",0);
			if (HttpContext.Current.Request["Money_fanxian_after"] != null)
				model.Money_fanxian_after=Shop.Tools.RequestTool.RequestDecimal("Money_fanxian_after",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_User_Money SafeBindForm(Lebi_User_Money model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_MoneyStatus"] != null)
				model.Type_id_MoneyStatus=Shop.Tools.RequestTool.RequestInt("Type_id_MoneyStatus",0);
			if (HttpContext.Current.Request["Type_id_MoneyType"] != null)
				model.Type_id_MoneyType=Shop.Tools.RequestTool.RequestInt("Type_id_MoneyType",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["User_RealName"] != null)
				model.User_RealName=Shop.Tools.RequestTool.RequestSafeString("User_RealName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Money_after"] != null)
				model.Money_after=Shop.Tools.RequestTool.RequestDecimal("Money_after",0);
			if (HttpContext.Current.Request["Money_fanxian_after"] != null)
				model.Money_fanxian_after=Shop.Tools.RequestTool.RequestDecimal("Money_fanxian_after",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_User_Money ReaderBind(IDataReader dataReader)
		{
			Lebi_User_Money model=new Lebi_User_Money();
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
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Type_id_MoneyStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_MoneyStatus=(int)ojb;
			}
			ojb = dataReader["Type_id_MoneyType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_MoneyType=(int)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			ojb = dataReader["Time_Update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Update=(DateTime)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.User_RealName=dataReader["User_RealName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Money_after"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_after=(decimal)ojb;
			}
			ojb = dataReader["Money_fanxian_after"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_fanxian_after=(decimal)ojb;
			}
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_User_Money : Lebi_User_Money_interface
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
				strSql.Append("select " + colName + " from [Lebi_User_Money]");
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
			strSql.Append("select  "+colName+" from [Lebi_User_Money]");
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
			strSql.Append("select count(*) from [Lebi_User_Money]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_User_Money]");
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
			strSql.Append("select max(id) from [Lebi_User_Money]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User_Money]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_User_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_User_Money](");
			strSql.Append("[User_id],[Money],[Time_Add],[Type_id_MoneyStatus],[Type_id_MoneyType],[Admin_id],[Description],[Order_id],[Order_Code],[Time_Update],[User_UserName],[Admin_UserName],[User_RealName],[Remark],[Money_after],[Money_fanxian_after],[DT_id])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Money,@Time_Add,@Type_id_MoneyStatus,@Type_id_MoneyType,@Admin_id,@Description,@Order_id,@Order_Code,@Time_Update,@User_UserName,@Admin_UserName,@User_RealName,@Remark,@Money_after,@Money_fanxian_after,@DT_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Type_id_MoneyStatus", model.Type_id_MoneyStatus),
					new OleDbParameter("@Type_id_MoneyType", model.Type_id_MoneyType),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@User_RealName", model.User_RealName),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Money_after", model.Money_after),
					new OleDbParameter("@Money_fanxian_after", model.Money_fanxian_after),
					new OleDbParameter("@DT_id", model.DT_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_User_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_User_Money] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Type_id_MoneyStatus]=@Type_id_MoneyStatus,");
			strSql.Append("[Type_id_MoneyType]=@Type_id_MoneyType,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[Order_id]=@Order_id,");
			strSql.Append("[Order_Code]=@Order_Code,");
			strSql.Append("[Time_Update]=@Time_Update,");
			strSql.Append("[User_UserName]=@User_UserName,");
			strSql.Append("[Admin_UserName]=@Admin_UserName,");
			strSql.Append("[User_RealName]=@User_RealName,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Money_after]=@Money_after,");
			strSql.Append("[Money_fanxian_after]=@Money_fanxian_after,");
			strSql.Append("[DT_id]=@DT_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Type_id_MoneyStatus", model.Type_id_MoneyStatus),
					new OleDbParameter("@Type_id_MoneyType", model.Type_id_MoneyType),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@User_RealName", model.User_RealName),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Money_after", model.Money_after),
					new OleDbParameter("@Money_fanxian_after", model.Money_fanxian_after),
					new OleDbParameter("@DT_id", model.DT_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Money] ");
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
			strSql.Append("delete from [Lebi_User_Money] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Money] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_User_Money GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Money] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_User_Money model;
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
		public Lebi_User_Money GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Money] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_User_Money model;
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
		public Lebi_User_Money GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_User_Money] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_User_Money model;
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
		public List<Lebi_User_Money> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_User_Money]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_User_Money> list = new List<Lebi_User_Money>();
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
		public List<Lebi_User_Money> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_User_Money]";
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
			List<Lebi_User_Money> list = new List<Lebi_User_Money>();
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
		public List<Lebi_User_Money> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_User_Money] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_User_Money> list = new List<Lebi_User_Money>();
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
		public List<Lebi_User_Money> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_User_Money]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_User_Money> list = new List<Lebi_User_Money>();
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
		public Lebi_User_Money BindForm(Lebi_User_Money model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_MoneyStatus"] != null)
				model.Type_id_MoneyStatus=Shop.Tools.RequestTool.RequestInt("Type_id_MoneyStatus",0);
			if (HttpContext.Current.Request["Type_id_MoneyType"] != null)
				model.Type_id_MoneyType=Shop.Tools.RequestTool.RequestInt("Type_id_MoneyType",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["User_RealName"] != null)
				model.User_RealName=Shop.Tools.RequestTool.RequestString("User_RealName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Money_after"] != null)
				model.Money_after=Shop.Tools.RequestTool.RequestDecimal("Money_after",0);
			if (HttpContext.Current.Request["Money_fanxian_after"] != null)
				model.Money_fanxian_after=Shop.Tools.RequestTool.RequestDecimal("Money_fanxian_after",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_User_Money SafeBindForm(Lebi_User_Money model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_MoneyStatus"] != null)
				model.Type_id_MoneyStatus=Shop.Tools.RequestTool.RequestInt("Type_id_MoneyStatus",0);
			if (HttpContext.Current.Request["Type_id_MoneyType"] != null)
				model.Type_id_MoneyType=Shop.Tools.RequestTool.RequestInt("Type_id_MoneyType",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["User_RealName"] != null)
				model.User_RealName=Shop.Tools.RequestTool.RequestSafeString("User_RealName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Money_after"] != null)
				model.Money_after=Shop.Tools.RequestTool.RequestDecimal("Money_after",0);
			if (HttpContext.Current.Request["Money_fanxian_after"] != null)
				model.Money_fanxian_after=Shop.Tools.RequestTool.RequestDecimal("Money_fanxian_after",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_User_Money ReaderBind(IDataReader dataReader)
		{
			Lebi_User_Money model=new Lebi_User_Money();
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
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Type_id_MoneyStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_MoneyStatus=(int)ojb;
			}
			ojb = dataReader["Type_id_MoneyType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_MoneyType=(int)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			ojb = dataReader["Time_Update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Update=(DateTime)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.User_RealName=dataReader["User_RealName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Money_after"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_after=(decimal)ojb;
			}
			ojb = dataReader["Money_fanxian_after"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_fanxian_after=(decimal)ojb;
			}
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

