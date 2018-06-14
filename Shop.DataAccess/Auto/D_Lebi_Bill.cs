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

	public interface Lebi_Bill_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Bill model);
		void Update(Lebi_Bill model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Bill GetModel(int id);
		Lebi_Bill GetModel(string strWhere);
		Lebi_Bill GetModel(SQLPara para);
		List<Lebi_Bill> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Bill> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Bill> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Bill> GetList(SQLPara para);
		Lebi_Bill BindForm(Lebi_Bill model);
		Lebi_Bill SafeBindForm(Lebi_Bill model);
		Lebi_Bill ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Bill。
	/// </summary>
	public class D_Lebi_Bill
	{
		static Lebi_Bill_interface _Instance;
		public static Lebi_Bill_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Bill();
		            else
		                _Instance = new sqlserver_Lebi_Bill();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Bill()
		{}
		#region  成员方法
	class sqlserver_Lebi_Bill : Lebi_Bill_interface
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
				strSql.Append("select " + colName + " from [Lebi_Bill]");
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
			strSql.Append("select  "+colName+" from [Lebi_Bill]");
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
			strSql.Append("select count(1) from [Lebi_Bill]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Bill]");
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
			strSql.Append("select max(id) from [Lebi_Bill]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Bill]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Bill model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Bill](");
			strSql.Append("User_id,BillType_id,Type_id_BillType,User_UserName,Title,Order_id,Order_Code,Content,Money,TaxRate,Company_Name,Company_Code,Company_Address,Company_Phone,Company_Bank,Company_Bank_User,Type_id_BillStatus,Currency_id,Currency_Code,Currency_ExchangeRate,Currency_Msige,Time_Add,Time_Finish,Admin_id,Admin_UserName,BillNo)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@BillType_id,@Type_id_BillType,@User_UserName,@Title,@Order_id,@Order_Code,@Content,@Money,@TaxRate,@Company_Name,@Company_Code,@Company_Address,@Company_Phone,@Company_Bank,@Company_Bank_User,@Type_id_BillStatus,@Currency_id,@Currency_Code,@Currency_ExchangeRate,@Currency_Msige,@Time_Add,@Time_Finish,@Admin_id,@Admin_UserName,@BillNo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@BillType_id", model.BillType_id),
					new SqlParameter("@Type_id_BillType", model.Type_id_BillType),
					new SqlParameter("@User_UserName", model.User_UserName),
					new SqlParameter("@Title", model.Title),
					new SqlParameter("@Order_id", model.Order_id),
					new SqlParameter("@Order_Code", model.Order_Code),
					new SqlParameter("@Content", model.Content),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@TaxRate", model.TaxRate),
					new SqlParameter("@Company_Name", model.Company_Name),
					new SqlParameter("@Company_Code", model.Company_Code),
					new SqlParameter("@Company_Address", model.Company_Address),
					new SqlParameter("@Company_Phone", model.Company_Phone),
					new SqlParameter("@Company_Bank", model.Company_Bank),
					new SqlParameter("@Company_Bank_User", model.Company_Bank_User),
					new SqlParameter("@Type_id_BillStatus", model.Type_id_BillStatus),
					new SqlParameter("@Currency_id", model.Currency_id),
					new SqlParameter("@Currency_Code", model.Currency_Code),
					new SqlParameter("@Currency_ExchangeRate", model.Currency_ExchangeRate),
					new SqlParameter("@Currency_Msige", model.Currency_Msige),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Finish", model.Time_Finish),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@Admin_UserName", model.Admin_UserName),
					new SqlParameter("@BillNo", model.BillNo)};

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
		public void Update(Lebi_Bill model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Bill] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("BillType_id= @BillType_id,");
			strSql.Append("Type_id_BillType= @Type_id_BillType,");
			strSql.Append("User_UserName= @User_UserName,");
			strSql.Append("Title= @Title,");
			strSql.Append("Order_id= @Order_id,");
			strSql.Append("Order_Code= @Order_Code,");
			strSql.Append("Content= @Content,");
			strSql.Append("Money= @Money,");
			strSql.Append("TaxRate= @TaxRate,");
			strSql.Append("Company_Name= @Company_Name,");
			strSql.Append("Company_Code= @Company_Code,");
			strSql.Append("Company_Address= @Company_Address,");
			strSql.Append("Company_Phone= @Company_Phone,");
			strSql.Append("Company_Bank= @Company_Bank,");
			strSql.Append("Company_Bank_User= @Company_Bank_User,");
			strSql.Append("Type_id_BillStatus= @Type_id_BillStatus,");
			strSql.Append("Currency_id= @Currency_id,");
			strSql.Append("Currency_Code= @Currency_Code,");
			strSql.Append("Currency_ExchangeRate= @Currency_ExchangeRate,");
			strSql.Append("Currency_Msige= @Currency_Msige,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Finish= @Time_Finish,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("Admin_UserName= @Admin_UserName,");
			strSql.Append("BillNo= @BillNo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@BillType_id", SqlDbType.Int,4),
					new SqlParameter("@Type_id_BillType", SqlDbType.Int,4),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Order_id", SqlDbType.Int,4),
					new SqlParameter("@Order_Code", SqlDbType.NVarChar,200),
					new SqlParameter("@Content", SqlDbType.NVarChar,200),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@TaxRate", SqlDbType.Decimal,9),
					new SqlParameter("@Company_Name", SqlDbType.NVarChar,200),
					new SqlParameter("@Company_Code", SqlDbType.NVarChar,200),
					new SqlParameter("@Company_Address", SqlDbType.NVarChar,200),
					new SqlParameter("@Company_Phone", SqlDbType.NVarChar,200),
					new SqlParameter("@Company_Bank", SqlDbType.NVarChar,200),
					new SqlParameter("@Company_Bank_User", SqlDbType.NVarChar,200),
					new SqlParameter("@Type_id_BillStatus", SqlDbType.Int,4),
					new SqlParameter("@Currency_id", SqlDbType.Int,4),
					new SqlParameter("@Currency_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency_ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@Currency_Msige", SqlDbType.NVarChar,50),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Finish", SqlDbType.DateTime),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@Admin_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@BillNo", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.BillType_id;
			parameters[3].Value = model.Type_id_BillType;
			parameters[4].Value = model.User_UserName;
			parameters[5].Value = model.Title;
			parameters[6].Value = model.Order_id;
			parameters[7].Value = model.Order_Code;
			parameters[8].Value = model.Content;
			parameters[9].Value = model.Money;
			parameters[10].Value = model.TaxRate;
			parameters[11].Value = model.Company_Name;
			parameters[12].Value = model.Company_Code;
			parameters[13].Value = model.Company_Address;
			parameters[14].Value = model.Company_Phone;
			parameters[15].Value = model.Company_Bank;
			parameters[16].Value = model.Company_Bank_User;
			parameters[17].Value = model.Type_id_BillStatus;
			parameters[18].Value = model.Currency_id;
			parameters[19].Value = model.Currency_Code;
			parameters[20].Value = model.Currency_ExchangeRate;
			parameters[21].Value = model.Currency_Msige;
			parameters[22].Value = model.Time_Add;
			parameters[23].Value = model.Time_Finish;
			parameters[24].Value = model.Admin_id;
			parameters[25].Value = model.Admin_UserName;
			parameters[26].Value = model.BillNo;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Bill] ");
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
			strSql.Append("delete from [Lebi_Bill] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Bill] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Bill GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Bill] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Bill model=new Lebi_Bill();
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
				if(ds.Tables[0].Rows[0]["BillType_id"].ToString()!="")
				{
					model.BillType_id=int.Parse(ds.Tables[0].Rows[0]["BillType_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString()!="")
				{
					model.Type_id_BillType=int.Parse(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TaxRate"].ToString()!="")
				{
					model.TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
				}
				model.Company_Name=ds.Tables[0].Rows[0]["Company_Name"].ToString();
				model.Company_Code=ds.Tables[0].Rows[0]["Company_Code"].ToString();
				model.Company_Address=ds.Tables[0].Rows[0]["Company_Address"].ToString();
				model.Company_Phone=ds.Tables[0].Rows[0]["Company_Phone"].ToString();
				model.Company_Bank=ds.Tables[0].Rows[0]["Company_Bank"].ToString();
				model.Company_Bank_User=ds.Tables[0].Rows[0]["Company_Bank_User"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_BillStatus"].ToString()!="")
				{
					model.Type_id_BillStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_BillStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Currency_Code=ds.Tables[0].Rows[0]["Currency_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString()!="")
				{
					model.Currency_ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString());
				}
				model.Currency_Msige=ds.Tables[0].Rows[0]["Currency_Msige"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Finish"].ToString()!="")
				{
					model.Time_Finish=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Finish"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.BillNo=ds.Tables[0].Rows[0]["BillNo"].ToString();
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
		public Lebi_Bill GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Bill] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Bill model=new Lebi_Bill();
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
				if(ds.Tables[0].Rows[0]["BillType_id"].ToString()!="")
				{
					model.BillType_id=int.Parse(ds.Tables[0].Rows[0]["BillType_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString()!="")
				{
					model.Type_id_BillType=int.Parse(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TaxRate"].ToString()!="")
				{
					model.TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
				}
				model.Company_Name=ds.Tables[0].Rows[0]["Company_Name"].ToString();
				model.Company_Code=ds.Tables[0].Rows[0]["Company_Code"].ToString();
				model.Company_Address=ds.Tables[0].Rows[0]["Company_Address"].ToString();
				model.Company_Phone=ds.Tables[0].Rows[0]["Company_Phone"].ToString();
				model.Company_Bank=ds.Tables[0].Rows[0]["Company_Bank"].ToString();
				model.Company_Bank_User=ds.Tables[0].Rows[0]["Company_Bank_User"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_BillStatus"].ToString()!="")
				{
					model.Type_id_BillStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_BillStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Currency_Code=ds.Tables[0].Rows[0]["Currency_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString()!="")
				{
					model.Currency_ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString());
				}
				model.Currency_Msige=ds.Tables[0].Rows[0]["Currency_Msige"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Finish"].ToString()!="")
				{
					model.Time_Finish=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Finish"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.BillNo=ds.Tables[0].Rows[0]["BillNo"].ToString();
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
		public Lebi_Bill GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Bill] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Bill model=new Lebi_Bill();
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
				if(ds.Tables[0].Rows[0]["BillType_id"].ToString()!="")
				{
					model.BillType_id=int.Parse(ds.Tables[0].Rows[0]["BillType_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString()!="")
				{
					model.Type_id_BillType=int.Parse(ds.Tables[0].Rows[0]["Type_id_BillType"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TaxRate"].ToString()!="")
				{
					model.TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
				}
				model.Company_Name=ds.Tables[0].Rows[0]["Company_Name"].ToString();
				model.Company_Code=ds.Tables[0].Rows[0]["Company_Code"].ToString();
				model.Company_Address=ds.Tables[0].Rows[0]["Company_Address"].ToString();
				model.Company_Phone=ds.Tables[0].Rows[0]["Company_Phone"].ToString();
				model.Company_Bank=ds.Tables[0].Rows[0]["Company_Bank"].ToString();
				model.Company_Bank_User=ds.Tables[0].Rows[0]["Company_Bank_User"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_BillStatus"].ToString()!="")
				{
					model.Type_id_BillStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_BillStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Currency_Code=ds.Tables[0].Rows[0]["Currency_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString()!="")
				{
					model.Currency_ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["Currency_ExchangeRate"].ToString());
				}
				model.Currency_Msige=ds.Tables[0].Rows[0]["Currency_Msige"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Finish"].ToString()!="")
				{
					model.Time_Finish=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Finish"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.BillNo=ds.Tables[0].Rows[0]["BillNo"].ToString();
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
		public List<Lebi_Bill> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Bill]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Bill> list = new List<Lebi_Bill>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Bill> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Bill]";
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
			List<Lebi_Bill> list = new List<Lebi_Bill>();
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
		public List<Lebi_Bill> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Bill] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Bill> list = new List<Lebi_Bill>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Bill> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Bill]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Bill> list = new List<Lebi_Bill>();
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
		public Lebi_Bill BindForm(Lebi_Bill model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["BillType_id"] != null)
				model.BillType_id=Shop.Tools.RequestTool.RequestInt("BillType_id",0);
			if (HttpContext.Current.Request["Type_id_BillType"] != null)
				model.Type_id_BillType=Shop.Tools.RequestTool.RequestInt("Type_id_BillType",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["TaxRate"] != null)
				model.TaxRate=Shop.Tools.RequestTool.RequestDecimal("TaxRate",0);
			if (HttpContext.Current.Request["Company_Name"] != null)
				model.Company_Name=Shop.Tools.RequestTool.RequestString("Company_Name");
			if (HttpContext.Current.Request["Company_Code"] != null)
				model.Company_Code=Shop.Tools.RequestTool.RequestString("Company_Code");
			if (HttpContext.Current.Request["Company_Address"] != null)
				model.Company_Address=Shop.Tools.RequestTool.RequestString("Company_Address");
			if (HttpContext.Current.Request["Company_Phone"] != null)
				model.Company_Phone=Shop.Tools.RequestTool.RequestString("Company_Phone");
			if (HttpContext.Current.Request["Company_Bank"] != null)
				model.Company_Bank=Shop.Tools.RequestTool.RequestString("Company_Bank");
			if (HttpContext.Current.Request["Company_Bank_User"] != null)
				model.Company_Bank_User=Shop.Tools.RequestTool.RequestString("Company_Bank_User");
			if (HttpContext.Current.Request["Type_id_BillStatus"] != null)
				model.Type_id_BillStatus=Shop.Tools.RequestTool.RequestInt("Type_id_BillStatus",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestString("Currency_Code");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestString("Currency_Msige");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Finish"] != null)
				model.Time_Finish=Shop.Tools.RequestTool.RequestTime("Time_Finish", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["BillNo"] != null)
				model.BillNo=Shop.Tools.RequestTool.RequestString("BillNo");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Bill SafeBindForm(Lebi_Bill model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["BillType_id"] != null)
				model.BillType_id=Shop.Tools.RequestTool.RequestInt("BillType_id",0);
			if (HttpContext.Current.Request["Type_id_BillType"] != null)
				model.Type_id_BillType=Shop.Tools.RequestTool.RequestInt("Type_id_BillType",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["TaxRate"] != null)
				model.TaxRate=Shop.Tools.RequestTool.RequestDecimal("TaxRate",0);
			if (HttpContext.Current.Request["Company_Name"] != null)
				model.Company_Name=Shop.Tools.RequestTool.RequestSafeString("Company_Name");
			if (HttpContext.Current.Request["Company_Code"] != null)
				model.Company_Code=Shop.Tools.RequestTool.RequestSafeString("Company_Code");
			if (HttpContext.Current.Request["Company_Address"] != null)
				model.Company_Address=Shop.Tools.RequestTool.RequestSafeString("Company_Address");
			if (HttpContext.Current.Request["Company_Phone"] != null)
				model.Company_Phone=Shop.Tools.RequestTool.RequestSafeString("Company_Phone");
			if (HttpContext.Current.Request["Company_Bank"] != null)
				model.Company_Bank=Shop.Tools.RequestTool.RequestSafeString("Company_Bank");
			if (HttpContext.Current.Request["Company_Bank_User"] != null)
				model.Company_Bank_User=Shop.Tools.RequestTool.RequestSafeString("Company_Bank_User");
			if (HttpContext.Current.Request["Type_id_BillStatus"] != null)
				model.Type_id_BillStatus=Shop.Tools.RequestTool.RequestInt("Type_id_BillStatus",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestSafeString("Currency_Code");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestSafeString("Currency_Msige");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Finish"] != null)
				model.Time_Finish=Shop.Tools.RequestTool.RequestTime("Time_Finish", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["BillNo"] != null)
				model.BillNo=Shop.Tools.RequestTool.RequestSafeString("BillNo");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Bill ReaderBind(IDataReader dataReader)
		{
			Lebi_Bill model=new Lebi_Bill();
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
			ojb = dataReader["BillType_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BillType_id=(int)ojb;
			}
			ojb = dataReader["Type_id_BillType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_BillType=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			model.Title=dataReader["Title"].ToString();
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["TaxRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TaxRate=(decimal)ojb;
			}
			model.Company_Name=dataReader["Company_Name"].ToString();
			model.Company_Code=dataReader["Company_Code"].ToString();
			model.Company_Address=dataReader["Company_Address"].ToString();
			model.Company_Phone=dataReader["Company_Phone"].ToString();
			model.Company_Bank=dataReader["Company_Bank"].ToString();
			model.Company_Bank_User=dataReader["Company_Bank_User"].ToString();
			ojb = dataReader["Type_id_BillStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_BillStatus=(int)ojb;
			}
			ojb = dataReader["Currency_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_id=(int)ojb;
			}
			model.Currency_Code=dataReader["Currency_Code"].ToString();
			ojb = dataReader["Currency_ExchangeRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_ExchangeRate=(decimal)ojb;
			}
			model.Currency_Msige=dataReader["Currency_Msige"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Finish"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Finish=(DateTime)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.BillNo=dataReader["BillNo"].ToString();
			return model;
		}

	}
	class access_Lebi_Bill : Lebi_Bill_interface
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
				strSql.Append("select " + colName + " from [Lebi_Bill]");
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
			strSql.Append("select  "+colName+" from [Lebi_Bill]");
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
			strSql.Append("select count(*) from [Lebi_Bill]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Bill]");
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
			strSql.Append("select max(id) from [Lebi_Bill]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Bill]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Bill model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Bill](");
			strSql.Append("[User_id],[BillType_id],[Type_id_BillType],[User_UserName],[Title],[Order_id],[Order_Code],[Content],[Money],[TaxRate],[Company_Name],[Company_Code],[Company_Address],[Company_Phone],[Company_Bank],[Company_Bank_User],[Type_id_BillStatus],[Currency_id],[Currency_Code],[Currency_ExchangeRate],[Currency_Msige],[Time_Add],[Time_Finish],[Admin_id],[Admin_UserName],[BillNo])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@BillType_id,@Type_id_BillType,@User_UserName,@Title,@Order_id,@Order_Code,@Content,@Money,@TaxRate,@Company_Name,@Company_Code,@Company_Address,@Company_Phone,@Company_Bank,@Company_Bank_User,@Type_id_BillStatus,@Currency_id,@Currency_Code,@Currency_ExchangeRate,@Currency_Msige,@Time_Add,@Time_Finish,@Admin_id,@Admin_UserName,@BillNo)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@BillType_id", model.BillType_id),
					new OleDbParameter("@Type_id_BillType", model.Type_id_BillType),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@TaxRate", model.TaxRate),
					new OleDbParameter("@Company_Name", model.Company_Name),
					new OleDbParameter("@Company_Code", model.Company_Code),
					new OleDbParameter("@Company_Address", model.Company_Address),
					new OleDbParameter("@Company_Phone", model.Company_Phone),
					new OleDbParameter("@Company_Bank", model.Company_Bank),
					new OleDbParameter("@Company_Bank_User", model.Company_Bank_User),
					new OleDbParameter("@Type_id_BillStatus", model.Type_id_BillStatus),
					new OleDbParameter("@Currency_id", model.Currency_id),
					new OleDbParameter("@Currency_Code", model.Currency_Code),
					new OleDbParameter("@Currency_ExchangeRate", model.Currency_ExchangeRate),
					new OleDbParameter("@Currency_Msige", model.Currency_Msige),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Finish", model.Time_Finish.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@BillNo", model.BillNo)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Bill model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Bill] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[BillType_id]=@BillType_id,");
			strSql.Append("[Type_id_BillType]=@Type_id_BillType,");
			strSql.Append("[User_UserName]=@User_UserName,");
			strSql.Append("[Title]=@Title,");
			strSql.Append("[Order_id]=@Order_id,");
			strSql.Append("[Order_Code]=@Order_Code,");
			strSql.Append("[Content]=@Content,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[TaxRate]=@TaxRate,");
			strSql.Append("[Company_Name]=@Company_Name,");
			strSql.Append("[Company_Code]=@Company_Code,");
			strSql.Append("[Company_Address]=@Company_Address,");
			strSql.Append("[Company_Phone]=@Company_Phone,");
			strSql.Append("[Company_Bank]=@Company_Bank,");
			strSql.Append("[Company_Bank_User]=@Company_Bank_User,");
			strSql.Append("[Type_id_BillStatus]=@Type_id_BillStatus,");
			strSql.Append("[Currency_id]=@Currency_id,");
			strSql.Append("[Currency_Code]=@Currency_Code,");
			strSql.Append("[Currency_ExchangeRate]=@Currency_ExchangeRate,");
			strSql.Append("[Currency_Msige]=@Currency_Msige,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Finish]=@Time_Finish,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[Admin_UserName]=@Admin_UserName,");
			strSql.Append("[BillNo]=@BillNo");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@BillType_id", model.BillType_id),
					new OleDbParameter("@Type_id_BillType", model.Type_id_BillType),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@TaxRate", model.TaxRate),
					new OleDbParameter("@Company_Name", model.Company_Name),
					new OleDbParameter("@Company_Code", model.Company_Code),
					new OleDbParameter("@Company_Address", model.Company_Address),
					new OleDbParameter("@Company_Phone", model.Company_Phone),
					new OleDbParameter("@Company_Bank", model.Company_Bank),
					new OleDbParameter("@Company_Bank_User", model.Company_Bank_User),
					new OleDbParameter("@Type_id_BillStatus", model.Type_id_BillStatus),
					new OleDbParameter("@Currency_id", model.Currency_id),
					new OleDbParameter("@Currency_Code", model.Currency_Code),
					new OleDbParameter("@Currency_ExchangeRate", model.Currency_ExchangeRate),
					new OleDbParameter("@Currency_Msige", model.Currency_Msige),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Finish", model.Time_Finish.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@BillNo", model.BillNo)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Bill] ");
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
			strSql.Append("delete from [Lebi_Bill] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Bill] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Bill GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Bill] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Bill model;
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
		public Lebi_Bill GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Bill] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Bill model;
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
		public Lebi_Bill GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Bill] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Bill model;
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
		public List<Lebi_Bill> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Bill]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Bill> list = new List<Lebi_Bill>();
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
		public List<Lebi_Bill> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Bill]";
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
			List<Lebi_Bill> list = new List<Lebi_Bill>();
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
		public List<Lebi_Bill> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Bill] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Bill> list = new List<Lebi_Bill>();
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
		public List<Lebi_Bill> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Bill]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Bill> list = new List<Lebi_Bill>();
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
		public Lebi_Bill BindForm(Lebi_Bill model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["BillType_id"] != null)
				model.BillType_id=Shop.Tools.RequestTool.RequestInt("BillType_id",0);
			if (HttpContext.Current.Request["Type_id_BillType"] != null)
				model.Type_id_BillType=Shop.Tools.RequestTool.RequestInt("Type_id_BillType",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["TaxRate"] != null)
				model.TaxRate=Shop.Tools.RequestTool.RequestDecimal("TaxRate",0);
			if (HttpContext.Current.Request["Company_Name"] != null)
				model.Company_Name=Shop.Tools.RequestTool.RequestString("Company_Name");
			if (HttpContext.Current.Request["Company_Code"] != null)
				model.Company_Code=Shop.Tools.RequestTool.RequestString("Company_Code");
			if (HttpContext.Current.Request["Company_Address"] != null)
				model.Company_Address=Shop.Tools.RequestTool.RequestString("Company_Address");
			if (HttpContext.Current.Request["Company_Phone"] != null)
				model.Company_Phone=Shop.Tools.RequestTool.RequestString("Company_Phone");
			if (HttpContext.Current.Request["Company_Bank"] != null)
				model.Company_Bank=Shop.Tools.RequestTool.RequestString("Company_Bank");
			if (HttpContext.Current.Request["Company_Bank_User"] != null)
				model.Company_Bank_User=Shop.Tools.RequestTool.RequestString("Company_Bank_User");
			if (HttpContext.Current.Request["Type_id_BillStatus"] != null)
				model.Type_id_BillStatus=Shop.Tools.RequestTool.RequestInt("Type_id_BillStatus",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestString("Currency_Code");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestString("Currency_Msige");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Finish"] != null)
				model.Time_Finish=Shop.Tools.RequestTool.RequestTime("Time_Finish", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["BillNo"] != null)
				model.BillNo=Shop.Tools.RequestTool.RequestString("BillNo");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Bill SafeBindForm(Lebi_Bill model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["BillType_id"] != null)
				model.BillType_id=Shop.Tools.RequestTool.RequestInt("BillType_id",0);
			if (HttpContext.Current.Request["Type_id_BillType"] != null)
				model.Type_id_BillType=Shop.Tools.RequestTool.RequestInt("Type_id_BillType",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["TaxRate"] != null)
				model.TaxRate=Shop.Tools.RequestTool.RequestDecimal("TaxRate",0);
			if (HttpContext.Current.Request["Company_Name"] != null)
				model.Company_Name=Shop.Tools.RequestTool.RequestSafeString("Company_Name");
			if (HttpContext.Current.Request["Company_Code"] != null)
				model.Company_Code=Shop.Tools.RequestTool.RequestSafeString("Company_Code");
			if (HttpContext.Current.Request["Company_Address"] != null)
				model.Company_Address=Shop.Tools.RequestTool.RequestSafeString("Company_Address");
			if (HttpContext.Current.Request["Company_Phone"] != null)
				model.Company_Phone=Shop.Tools.RequestTool.RequestSafeString("Company_Phone");
			if (HttpContext.Current.Request["Company_Bank"] != null)
				model.Company_Bank=Shop.Tools.RequestTool.RequestSafeString("Company_Bank");
			if (HttpContext.Current.Request["Company_Bank_User"] != null)
				model.Company_Bank_User=Shop.Tools.RequestTool.RequestSafeString("Company_Bank_User");
			if (HttpContext.Current.Request["Type_id_BillStatus"] != null)
				model.Type_id_BillStatus=Shop.Tools.RequestTool.RequestInt("Type_id_BillStatus",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestSafeString("Currency_Code");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestSafeString("Currency_Msige");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Finish"] != null)
				model.Time_Finish=Shop.Tools.RequestTool.RequestTime("Time_Finish", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["BillNo"] != null)
				model.BillNo=Shop.Tools.RequestTool.RequestSafeString("BillNo");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Bill ReaderBind(IDataReader dataReader)
		{
			Lebi_Bill model=new Lebi_Bill();
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
			ojb = dataReader["BillType_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BillType_id=(int)ojb;
			}
			ojb = dataReader["Type_id_BillType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_BillType=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			model.Title=dataReader["Title"].ToString();
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["TaxRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TaxRate=(decimal)ojb;
			}
			model.Company_Name=dataReader["Company_Name"].ToString();
			model.Company_Code=dataReader["Company_Code"].ToString();
			model.Company_Address=dataReader["Company_Address"].ToString();
			model.Company_Phone=dataReader["Company_Phone"].ToString();
			model.Company_Bank=dataReader["Company_Bank"].ToString();
			model.Company_Bank_User=dataReader["Company_Bank_User"].ToString();
			ojb = dataReader["Type_id_BillStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_BillStatus=(int)ojb;
			}
			ojb = dataReader["Currency_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_id=(int)ojb;
			}
			model.Currency_Code=dataReader["Currency_Code"].ToString();
			ojb = dataReader["Currency_ExchangeRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_ExchangeRate=(decimal)ojb;
			}
			model.Currency_Msige=dataReader["Currency_Msige"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Finish"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Finish=(DateTime)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.BillNo=dataReader["BillNo"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

