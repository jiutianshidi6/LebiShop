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

	public interface Lebi_Agent_Money_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Agent_Money model);
		void Update(Lebi_Agent_Money model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Agent_Money GetModel(int id);
		Lebi_Agent_Money GetModel(string strWhere);
		Lebi_Agent_Money GetModel(SQLPara para);
		List<Lebi_Agent_Money> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Agent_Money> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Agent_Money> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Agent_Money> GetList(SQLPara para);
		Lebi_Agent_Money BindForm(Lebi_Agent_Money model);
		Lebi_Agent_Money SafeBindForm(Lebi_Agent_Money model);
		Lebi_Agent_Money ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Agent_Money。
	/// </summary>
	public class D_Lebi_Agent_Money
	{
		static Lebi_Agent_Money_interface _Instance;
		public static Lebi_Agent_Money_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Agent_Money();
		            else
		                _Instance = new sqlserver_Lebi_Agent_Money();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Agent_Money()
		{}
		#region  成员方法
	class sqlserver_Lebi_Agent_Money : Lebi_Agent_Money_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_Money]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_Money]");
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
			strSql.Append("select count(1) from [Lebi_Agent_Money]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Money]");
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
			strSql.Append("select max(id) from [Lebi_Agent_Money]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Money]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_Money](");
			strSql.Append("User_id,User_UserName,Money,Type_id_AgentMoneyType,Type_id_AgentMoneyStatus,Time_add,Remark,Order_id,Order_Code,Area_id,Product_id,Product_id_parent,Product_Number,Supplier_id,DT_id)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_UserName,@Money,@Type_id_AgentMoneyType,@Type_id_AgentMoneyStatus,@Time_add,@Remark,@Order_id,@Order_Code,@Area_id,@Product_id,@Product_id_parent,@Product_Number,@Supplier_id,@DT_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@User_UserName", model.User_UserName),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@Type_id_AgentMoneyType", model.Type_id_AgentMoneyType),
					new SqlParameter("@Type_id_AgentMoneyStatus", model.Type_id_AgentMoneyStatus),
					new SqlParameter("@Time_add", model.Time_add),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Order_id", model.Order_id),
					new SqlParameter("@Order_Code", model.Order_Code),
					new SqlParameter("@Area_id", model.Area_id),
					new SqlParameter("@Product_id", model.Product_id),
					new SqlParameter("@Product_id_parent", model.Product_id_parent),
					new SqlParameter("@Product_Number", model.Product_Number),
					new SqlParameter("@Supplier_id", model.Supplier_id),
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
		public void Update(Lebi_Agent_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_Money] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("User_UserName= @User_UserName,");
			strSql.Append("Money= @Money,");
			strSql.Append("Type_id_AgentMoneyType= @Type_id_AgentMoneyType,");
			strSql.Append("Type_id_AgentMoneyStatus= @Type_id_AgentMoneyStatus,");
			strSql.Append("Time_add= @Time_add,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Order_id= @Order_id,");
			strSql.Append("Order_Code= @Order_Code,");
			strSql.Append("Area_id= @Area_id,");
			strSql.Append("Product_id= @Product_id,");
			strSql.Append("Product_id_parent= @Product_id_parent,");
			strSql.Append("Product_Number= @Product_Number,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("DT_id= @DT_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@Type_id_AgentMoneyType", SqlDbType.Int,4),
					new SqlParameter("@Type_id_AgentMoneyStatus", SqlDbType.Int,4),
					new SqlParameter("@Time_add", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					new SqlParameter("@Order_id", SqlDbType.Int,4),
					new SqlParameter("@Order_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Area_id", SqlDbType.Int,4),
					new SqlParameter("@Product_id", SqlDbType.Int,4),
					new SqlParameter("@Product_id_parent", SqlDbType.Int,4),
					new SqlParameter("@Product_Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@DT_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.User_UserName;
			parameters[3].Value = model.Money;
			parameters[4].Value = model.Type_id_AgentMoneyType;
			parameters[5].Value = model.Type_id_AgentMoneyStatus;
			parameters[6].Value = model.Time_add;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.Order_id;
			parameters[9].Value = model.Order_Code;
			parameters[10].Value = model.Area_id;
			parameters[11].Value = model.Product_id;
			parameters[12].Value = model.Product_id_parent;
			parameters[13].Value = model.Product_Number;
			parameters[14].Value = model.Supplier_id;
			parameters[15].Value = model.DT_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Money] ");
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
			strSql.Append("delete from [Lebi_Agent_Money] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Money] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_Money GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Money] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Agent_Money model=new Lebi_Agent_Money();
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
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AgentMoneyType"].ToString()!="")
				{
					model.Type_id_AgentMoneyType=int.Parse(ds.Tables[0].Rows[0]["Type_id_AgentMoneyType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AgentMoneyStatus"].ToString()!="")
				{
					model.Type_id_AgentMoneyStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_AgentMoneyStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id_parent"].ToString()!="")
				{
					model.Product_id_parent=int.Parse(ds.Tables[0].Rows[0]["Product_id_parent"].ToString());
				}
				model.Product_Number=ds.Tables[0].Rows[0]["Product_Number"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
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
		public Lebi_Agent_Money GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Money] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_Money model=new Lebi_Agent_Money();
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
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AgentMoneyType"].ToString()!="")
				{
					model.Type_id_AgentMoneyType=int.Parse(ds.Tables[0].Rows[0]["Type_id_AgentMoneyType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AgentMoneyStatus"].ToString()!="")
				{
					model.Type_id_AgentMoneyStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_AgentMoneyStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id_parent"].ToString()!="")
				{
					model.Product_id_parent=int.Parse(ds.Tables[0].Rows[0]["Product_id_parent"].ToString());
				}
				model.Product_Number=ds.Tables[0].Rows[0]["Product_Number"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
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
		public Lebi_Agent_Money GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_Money] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_Money model=new Lebi_Agent_Money();
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
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AgentMoneyType"].ToString()!="")
				{
					model.Type_id_AgentMoneyType=int.Parse(ds.Tables[0].Rows[0]["Type_id_AgentMoneyType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AgentMoneyStatus"].ToString()!="")
				{
					model.Type_id_AgentMoneyStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_AgentMoneyStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id_parent"].ToString()!="")
				{
					model.Product_id_parent=int.Parse(ds.Tables[0].Rows[0]["Product_id_parent"].ToString());
				}
				model.Product_Number=ds.Tables[0].Rows[0]["Product_Number"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
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
		public List<Lebi_Agent_Money> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_Money]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_Money> list = new List<Lebi_Agent_Money>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Agent_Money> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_Money]";
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
			List<Lebi_Agent_Money> list = new List<Lebi_Agent_Money>();
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
		public List<Lebi_Agent_Money> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_Money] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_Money> list = new List<Lebi_Agent_Money>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Agent_Money> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_Money]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_Money> list = new List<Lebi_Agent_Money>();
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
		public Lebi_Agent_Money BindForm(Lebi_Agent_Money model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Type_id_AgentMoneyType"] != null)
				model.Type_id_AgentMoneyType=Shop.Tools.RequestTool.RequestInt("Type_id_AgentMoneyType",0);
			if (HttpContext.Current.Request["Type_id_AgentMoneyStatus"] != null)
				model.Type_id_AgentMoneyStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AgentMoneyStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Product_id_parent"] != null)
				model.Product_id_parent=Shop.Tools.RequestTool.RequestInt("Product_id_parent",0);
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestString("Product_Number");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Agent_Money SafeBindForm(Lebi_Agent_Money model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Type_id_AgentMoneyType"] != null)
				model.Type_id_AgentMoneyType=Shop.Tools.RequestTool.RequestInt("Type_id_AgentMoneyType",0);
			if (HttpContext.Current.Request["Type_id_AgentMoneyStatus"] != null)
				model.Type_id_AgentMoneyStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AgentMoneyStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Product_id_parent"] != null)
				model.Product_id_parent=Shop.Tools.RequestTool.RequestInt("Product_id_parent",0);
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestSafeString("Product_Number");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Agent_Money ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_Money model=new Lebi_Agent_Money();
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
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Type_id_AgentMoneyType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_AgentMoneyType=(int)ojb;
			}
			ojb = dataReader["Type_id_AgentMoneyStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_AgentMoneyStatus=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["Product_id_parent"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id_parent=(int)ojb;
			}
			model.Product_Number=dataReader["Product_Number"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Agent_Money : Lebi_Agent_Money_interface
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
				strSql.Append("select " + colName + " from [Lebi_Agent_Money]");
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
			strSql.Append("select  "+colName+" from [Lebi_Agent_Money]");
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
			strSql.Append("select count(*) from [Lebi_Agent_Money]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Agent_Money]");
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
			strSql.Append("select max(id) from [Lebi_Agent_Money]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Agent_Money]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Agent_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Agent_Money](");
			strSql.Append("[User_id],[User_UserName],[Money],[Type_id_AgentMoneyType],[Type_id_AgentMoneyStatus],[Time_add],[Remark],[Order_id],[Order_Code],[Area_id],[Product_id],[Product_id_parent],[Product_Number],[Supplier_id],[DT_id])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@User_UserName,@Money,@Type_id_AgentMoneyType,@Type_id_AgentMoneyStatus,@Time_add,@Remark,@Order_id,@Order_Code,@Area_id,@Product_id,@Product_id_parent,@Product_Number,@Supplier_id,@DT_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Type_id_AgentMoneyType", model.Type_id_AgentMoneyType),
					new OleDbParameter("@Type_id_AgentMoneyStatus", model.Type_id_AgentMoneyStatus),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Product_id_parent", model.Product_id_parent),
					new OleDbParameter("@Product_Number", model.Product_Number),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@DT_id", model.DT_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Agent_Money model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Agent_Money] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[User_UserName]=@User_UserName,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[Type_id_AgentMoneyType]=@Type_id_AgentMoneyType,");
			strSql.Append("[Type_id_AgentMoneyStatus]=@Type_id_AgentMoneyStatus,");
			strSql.Append("[Time_add]=@Time_add,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Order_id]=@Order_id,");
			strSql.Append("[Order_Code]=@Order_Code,");
			strSql.Append("[Area_id]=@Area_id,");
			strSql.Append("[Product_id]=@Product_id,");
			strSql.Append("[Product_id_parent]=@Product_id_parent,");
			strSql.Append("[Product_Number]=@Product_Number,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[DT_id]=@DT_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Type_id_AgentMoneyType", model.Type_id_AgentMoneyType),
					new OleDbParameter("@Type_id_AgentMoneyStatus", model.Type_id_AgentMoneyStatus),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Product_id_parent", model.Product_id_parent),
					new OleDbParameter("@Product_Number", model.Product_Number),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@DT_id", model.DT_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Money] ");
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
			strSql.Append("delete from [Lebi_Agent_Money] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Agent_Money] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Agent_Money GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Money] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Agent_Money model;
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
		public Lebi_Agent_Money GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Agent_Money] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Agent_Money model;
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
		public Lebi_Agent_Money GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Agent_Money] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Agent_Money model;
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
		public List<Lebi_Agent_Money> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Agent_Money]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Agent_Money> list = new List<Lebi_Agent_Money>();
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
		public List<Lebi_Agent_Money> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Agent_Money]";
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
			List<Lebi_Agent_Money> list = new List<Lebi_Agent_Money>();
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
		public List<Lebi_Agent_Money> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Agent_Money] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Agent_Money> list = new List<Lebi_Agent_Money>();
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
		public List<Lebi_Agent_Money> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Agent_Money]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Agent_Money> list = new List<Lebi_Agent_Money>();
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
		public Lebi_Agent_Money BindForm(Lebi_Agent_Money model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Type_id_AgentMoneyType"] != null)
				model.Type_id_AgentMoneyType=Shop.Tools.RequestTool.RequestInt("Type_id_AgentMoneyType",0);
			if (HttpContext.Current.Request["Type_id_AgentMoneyStatus"] != null)
				model.Type_id_AgentMoneyStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AgentMoneyStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Product_id_parent"] != null)
				model.Product_id_parent=Shop.Tools.RequestTool.RequestInt("Product_id_parent",0);
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestString("Product_Number");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Agent_Money SafeBindForm(Lebi_Agent_Money model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Type_id_AgentMoneyType"] != null)
				model.Type_id_AgentMoneyType=Shop.Tools.RequestTool.RequestInt("Type_id_AgentMoneyType",0);
			if (HttpContext.Current.Request["Type_id_AgentMoneyStatus"] != null)
				model.Type_id_AgentMoneyStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AgentMoneyStatus",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Product_id_parent"] != null)
				model.Product_id_parent=Shop.Tools.RequestTool.RequestInt("Product_id_parent",0);
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestSafeString("Product_Number");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Agent_Money ReaderBind(IDataReader dataReader)
		{
			Lebi_Agent_Money model=new Lebi_Agent_Money();
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
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Type_id_AgentMoneyType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_AgentMoneyType=(int)ojb;
			}
			ojb = dataReader["Type_id_AgentMoneyStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_AgentMoneyStatus=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["Product_id_parent"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id_parent=(int)ojb;
			}
			model.Product_Number=dataReader["Product_Number"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
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

