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

	public interface Lebi_Transport_Order_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Transport_Order model);
		void Update(Lebi_Transport_Order model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Transport_Order GetModel(int id);
		Lebi_Transport_Order GetModel(string strWhere);
		Lebi_Transport_Order GetModel(SQLPara para);
		List<Lebi_Transport_Order> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Transport_Order> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Transport_Order> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Transport_Order> GetList(SQLPara para);
		Lebi_Transport_Order BindForm(Lebi_Transport_Order model);
		Lebi_Transport_Order SafeBindForm(Lebi_Transport_Order model);
		Lebi_Transport_Order ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Transport_Order。
	/// </summary>
	public class D_Lebi_Transport_Order
	{
		static Lebi_Transport_Order_interface _Instance;
		public static Lebi_Transport_Order_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Transport_Order();
		            else
		                _Instance = new sqlserver_Lebi_Transport_Order();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Transport_Order()
		{}
		#region  成员方法
	class sqlserver_Lebi_Transport_Order : Lebi_Transport_Order_interface
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
				strSql.Append("select " + colName + " from [Lebi_Transport_Order]");
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
			strSql.Append("select  "+colName+" from [Lebi_Transport_Order]");
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
			strSql.Append("select count(1) from [Lebi_Transport_Order]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Transport_Order]");
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
			strSql.Append("select max(id) from [Lebi_Transport_Order]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Transport_Order]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Transport_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Transport_Order](");
			strSql.Append("Transport_id,Transport_Name,Code,Transport_Code,Time_Add,Time_Received,T_Name,T_Address,T_Email,T_MobilePhone,T_Phone,Order_id,User_id,Type_id_TransportOrderStatus,IsHaveNewLog,Money,Admin_id,AdminName,Supplier_id,Supplier_SubName,Product,Log,HtmlLog)");
			strSql.Append(" values (");
			strSql.Append("@Transport_id,@Transport_Name,@Code,@Transport_Code,@Time_Add,@Time_Received,@T_Name,@T_Address,@T_Email,@T_MobilePhone,@T_Phone,@Order_id,@User_id,@Type_id_TransportOrderStatus,@IsHaveNewLog,@Money,@Admin_id,@AdminName,@Supplier_id,@Supplier_SubName,@Product,@Log,@HtmlLog)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Transport_id", model.Transport_id),
					new SqlParameter("@Transport_Name", model.Transport_Name),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@Transport_Code", model.Transport_Code),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Received", model.Time_Received),
					new SqlParameter("@T_Name", model.T_Name),
					new SqlParameter("@T_Address", model.T_Address),
					new SqlParameter("@T_Email", model.T_Email),
					new SqlParameter("@T_MobilePhone", model.T_MobilePhone),
					new SqlParameter("@T_Phone", model.T_Phone),
					new SqlParameter("@Order_id", model.Order_id),
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@Type_id_TransportOrderStatus", model.Type_id_TransportOrderStatus),
					new SqlParameter("@IsHaveNewLog", model.IsHaveNewLog),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@AdminName", model.AdminName),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Supplier_SubName", model.Supplier_SubName),
					new SqlParameter("@Product", model.Product),
					new SqlParameter("@Log", model.Log),
					new SqlParameter("@HtmlLog", model.HtmlLog)};

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
		public void Update(Lebi_Transport_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Transport_Order] set ");
			strSql.Append("Transport_id= @Transport_id,");
			strSql.Append("Transport_Name= @Transport_Name,");
			strSql.Append("Code= @Code,");
			strSql.Append("Transport_Code= @Transport_Code,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Received= @Time_Received,");
			strSql.Append("T_Name= @T_Name,");
			strSql.Append("T_Address= @T_Address,");
			strSql.Append("T_Email= @T_Email,");
			strSql.Append("T_MobilePhone= @T_MobilePhone,");
			strSql.Append("T_Phone= @T_Phone,");
			strSql.Append("Order_id= @Order_id,");
			strSql.Append("User_id= @User_id,");
			strSql.Append("Type_id_TransportOrderStatus= @Type_id_TransportOrderStatus,");
			strSql.Append("IsHaveNewLog= @IsHaveNewLog,");
			strSql.Append("Money= @Money,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("AdminName= @AdminName,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Supplier_SubName= @Supplier_SubName,");
			strSql.Append("Product= @Product,");
			strSql.Append("Log= @Log,");
			strSql.Append("HtmlLog= @HtmlLog");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Transport_id", SqlDbType.Int,4),
					new SqlParameter("@Transport_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Transport_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Received", SqlDbType.DateTime),
					new SqlParameter("@T_Name", SqlDbType.NVarChar,255),
					new SqlParameter("@T_Address", SqlDbType.NVarChar,500),
					new SqlParameter("@T_Email", SqlDbType.NVarChar,50),
					new SqlParameter("@T_MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@T_Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Order_id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@Type_id_TransportOrderStatus", SqlDbType.Int,4),
					new SqlParameter("@IsHaveNewLog", SqlDbType.Int,4),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@AdminName", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Supplier_SubName", SqlDbType.NVarChar,100),
					new SqlParameter("@Product", SqlDbType.NText),
					new SqlParameter("@Log", SqlDbType.NText),
					new SqlParameter("@HtmlLog", SqlDbType.NText)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Transport_id;
			parameters[2].Value = model.Transport_Name;
			parameters[3].Value = model.Code;
			parameters[4].Value = model.Transport_Code;
			parameters[5].Value = model.Time_Add;
			parameters[6].Value = model.Time_Received;
			parameters[7].Value = model.T_Name;
			parameters[8].Value = model.T_Address;
			parameters[9].Value = model.T_Email;
			parameters[10].Value = model.T_MobilePhone;
			parameters[11].Value = model.T_Phone;
			parameters[12].Value = model.Order_id;
			parameters[13].Value = model.User_id;
			parameters[14].Value = model.Type_id_TransportOrderStatus;
			parameters[15].Value = model.IsHaveNewLog;
			parameters[16].Value = model.Money;
			parameters[17].Value = model.Admin_id;
			parameters[18].Value = model.AdminName;
			parameters[19].Value = model.Supplier_id;
			parameters[20].Value = model.Supplier_SubName;
			parameters[21].Value = model.Product;
			parameters[22].Value = model.Log;
			parameters[23].Value = model.HtmlLog;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Transport_Order] ");
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
			strSql.Append("delete from [Lebi_Transport_Order] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Transport_Order] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Transport_Order GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Transport_Order] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Transport_Order model=new Lebi_Transport_Order();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Transport_id"].ToString()!="")
				{
					model.Transport_id=int.Parse(ds.Tables[0].Rows[0]["Transport_id"].ToString());
				}
				model.Transport_Name=ds.Tables[0].Rows[0]["Transport_Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Transport_Code=ds.Tables[0].Rows[0]["Transport_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Received"].ToString()!="")
				{
					model.Time_Received=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Received"].ToString());
				}
				model.T_Name=ds.Tables[0].Rows[0]["T_Name"].ToString();
				model.T_Address=ds.Tables[0].Rows[0]["T_Address"].ToString();
				model.T_Email=ds.Tables[0].Rows[0]["T_Email"].ToString();
				model.T_MobilePhone=ds.Tables[0].Rows[0]["T_MobilePhone"].ToString();
				model.T_Phone=ds.Tables[0].Rows[0]["T_Phone"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_TransportOrderStatus"].ToString()!="")
				{
					model.Type_id_TransportOrderStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_TransportOrderStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsHaveNewLog"].ToString()!="")
				{
					model.IsHaveNewLog=int.Parse(ds.Tables[0].Rows[0]["IsHaveNewLog"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.AdminName=ds.Tables[0].Rows[0]["AdminName"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				model.Product=ds.Tables[0].Rows[0]["Product"].ToString();
				model.Log=ds.Tables[0].Rows[0]["Log"].ToString();
				model.HtmlLog=ds.Tables[0].Rows[0]["HtmlLog"].ToString();
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
		public Lebi_Transport_Order GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Transport_Order] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Transport_Order model=new Lebi_Transport_Order();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Transport_id"].ToString()!="")
				{
					model.Transport_id=int.Parse(ds.Tables[0].Rows[0]["Transport_id"].ToString());
				}
				model.Transport_Name=ds.Tables[0].Rows[0]["Transport_Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Transport_Code=ds.Tables[0].Rows[0]["Transport_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Received"].ToString()!="")
				{
					model.Time_Received=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Received"].ToString());
				}
				model.T_Name=ds.Tables[0].Rows[0]["T_Name"].ToString();
				model.T_Address=ds.Tables[0].Rows[0]["T_Address"].ToString();
				model.T_Email=ds.Tables[0].Rows[0]["T_Email"].ToString();
				model.T_MobilePhone=ds.Tables[0].Rows[0]["T_MobilePhone"].ToString();
				model.T_Phone=ds.Tables[0].Rows[0]["T_Phone"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_TransportOrderStatus"].ToString()!="")
				{
					model.Type_id_TransportOrderStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_TransportOrderStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsHaveNewLog"].ToString()!="")
				{
					model.IsHaveNewLog=int.Parse(ds.Tables[0].Rows[0]["IsHaveNewLog"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.AdminName=ds.Tables[0].Rows[0]["AdminName"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				model.Product=ds.Tables[0].Rows[0]["Product"].ToString();
				model.Log=ds.Tables[0].Rows[0]["Log"].ToString();
				model.HtmlLog=ds.Tables[0].Rows[0]["HtmlLog"].ToString();
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
		public Lebi_Transport_Order GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Transport_Order] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Transport_Order model=new Lebi_Transport_Order();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Transport_id"].ToString()!="")
				{
					model.Transport_id=int.Parse(ds.Tables[0].Rows[0]["Transport_id"].ToString());
				}
				model.Transport_Name=ds.Tables[0].Rows[0]["Transport_Name"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Transport_Code=ds.Tables[0].Rows[0]["Transport_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Received"].ToString()!="")
				{
					model.Time_Received=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Received"].ToString());
				}
				model.T_Name=ds.Tables[0].Rows[0]["T_Name"].ToString();
				model.T_Address=ds.Tables[0].Rows[0]["T_Address"].ToString();
				model.T_Email=ds.Tables[0].Rows[0]["T_Email"].ToString();
				model.T_MobilePhone=ds.Tables[0].Rows[0]["T_MobilePhone"].ToString();
				model.T_Phone=ds.Tables[0].Rows[0]["T_Phone"].ToString();
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_TransportOrderStatus"].ToString()!="")
				{
					model.Type_id_TransportOrderStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_TransportOrderStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsHaveNewLog"].ToString()!="")
				{
					model.IsHaveNewLog=int.Parse(ds.Tables[0].Rows[0]["IsHaveNewLog"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.AdminName=ds.Tables[0].Rows[0]["AdminName"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				model.Product=ds.Tables[0].Rows[0]["Product"].ToString();
				model.Log=ds.Tables[0].Rows[0]["Log"].ToString();
				model.HtmlLog=ds.Tables[0].Rows[0]["HtmlLog"].ToString();
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
		public List<Lebi_Transport_Order> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Transport_Order]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Transport_Order> list = new List<Lebi_Transport_Order>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Transport_Order> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Transport_Order]";
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
			List<Lebi_Transport_Order> list = new List<Lebi_Transport_Order>();
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
		public List<Lebi_Transport_Order> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Transport_Order] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Transport_Order> list = new List<Lebi_Transport_Order>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Transport_Order> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Transport_Order]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Transport_Order> list = new List<Lebi_Transport_Order>();
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
		public Lebi_Transport_Order BindForm(Lebi_Transport_Order model)
		{
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Transport_Name"] != null)
				model.Transport_Name=Shop.Tools.RequestTool.RequestString("Transport_Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Transport_Code"] != null)
				model.Transport_Code=Shop.Tools.RequestTool.RequestString("Transport_Code");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Received"] != null)
				model.Time_Received=Shop.Tools.RequestTool.RequestTime("Time_Received", System.DateTime.Now);
			if (HttpContext.Current.Request["T_Name"] != null)
				model.T_Name=Shop.Tools.RequestTool.RequestString("T_Name");
			if (HttpContext.Current.Request["T_Address"] != null)
				model.T_Address=Shop.Tools.RequestTool.RequestString("T_Address");
			if (HttpContext.Current.Request["T_Email"] != null)
				model.T_Email=Shop.Tools.RequestTool.RequestString("T_Email");
			if (HttpContext.Current.Request["T_MobilePhone"] != null)
				model.T_MobilePhone=Shop.Tools.RequestTool.RequestString("T_MobilePhone");
			if (HttpContext.Current.Request["T_Phone"] != null)
				model.T_Phone=Shop.Tools.RequestTool.RequestString("T_Phone");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Type_id_TransportOrderStatus"] != null)
				model.Type_id_TransportOrderStatus=Shop.Tools.RequestTool.RequestInt("Type_id_TransportOrderStatus",0);
			if (HttpContext.Current.Request["IsHaveNewLog"] != null)
				model.IsHaveNewLog=Shop.Tools.RequestTool.RequestInt("IsHaveNewLog",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["AdminName"] != null)
				model.AdminName=Shop.Tools.RequestTool.RequestString("AdminName");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestString("Supplier_SubName");
			if (HttpContext.Current.Request["Product"] != null)
				model.Product=Shop.Tools.RequestTool.RequestString("Product");
			if (HttpContext.Current.Request["Log"] != null)
				model.Log=Shop.Tools.RequestTool.RequestString("Log");
			if (HttpContext.Current.Request["HtmlLog"] != null)
				model.HtmlLog=Shop.Tools.RequestTool.RequestString("HtmlLog");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Transport_Order SafeBindForm(Lebi_Transport_Order model)
		{
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Transport_Name"] != null)
				model.Transport_Name=Shop.Tools.RequestTool.RequestSafeString("Transport_Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Transport_Code"] != null)
				model.Transport_Code=Shop.Tools.RequestTool.RequestSafeString("Transport_Code");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Received"] != null)
				model.Time_Received=Shop.Tools.RequestTool.RequestTime("Time_Received", System.DateTime.Now);
			if (HttpContext.Current.Request["T_Name"] != null)
				model.T_Name=Shop.Tools.RequestTool.RequestSafeString("T_Name");
			if (HttpContext.Current.Request["T_Address"] != null)
				model.T_Address=Shop.Tools.RequestTool.RequestSafeString("T_Address");
			if (HttpContext.Current.Request["T_Email"] != null)
				model.T_Email=Shop.Tools.RequestTool.RequestSafeString("T_Email");
			if (HttpContext.Current.Request["T_MobilePhone"] != null)
				model.T_MobilePhone=Shop.Tools.RequestTool.RequestSafeString("T_MobilePhone");
			if (HttpContext.Current.Request["T_Phone"] != null)
				model.T_Phone=Shop.Tools.RequestTool.RequestSafeString("T_Phone");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Type_id_TransportOrderStatus"] != null)
				model.Type_id_TransportOrderStatus=Shop.Tools.RequestTool.RequestInt("Type_id_TransportOrderStatus",0);
			if (HttpContext.Current.Request["IsHaveNewLog"] != null)
				model.IsHaveNewLog=Shop.Tools.RequestTool.RequestInt("IsHaveNewLog",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["AdminName"] != null)
				model.AdminName=Shop.Tools.RequestTool.RequestSafeString("AdminName");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestSafeString("Supplier_SubName");
			if (HttpContext.Current.Request["Product"] != null)
				model.Product=Shop.Tools.RequestTool.RequestSafeString("Product");
			if (HttpContext.Current.Request["Log"] != null)
				model.Log=Shop.Tools.RequestTool.RequestSafeString("Log");
			if (HttpContext.Current.Request["HtmlLog"] != null)
				model.HtmlLog=Shop.Tools.RequestTool.RequestSafeString("HtmlLog");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Transport_Order ReaderBind(IDataReader dataReader)
		{
			Lebi_Transport_Order model=new Lebi_Transport_Order();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Transport_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Transport_id=(int)ojb;
			}
			model.Transport_Name=dataReader["Transport_Name"].ToString();
			model.Code=dataReader["Code"].ToString();
			model.Transport_Code=dataReader["Transport_Code"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Received"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Received=(DateTime)ojb;
			}
			model.T_Name=dataReader["T_Name"].ToString();
			model.T_Address=dataReader["T_Address"].ToString();
			model.T_Email=dataReader["T_Email"].ToString();
			model.T_MobilePhone=dataReader["T_MobilePhone"].ToString();
			model.T_Phone=dataReader["T_Phone"].ToString();
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["Type_id_TransportOrderStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_TransportOrderStatus=(int)ojb;
			}
			ojb = dataReader["IsHaveNewLog"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsHaveNewLog=(int)ojb;
			}
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.AdminName=dataReader["AdminName"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			model.Supplier_SubName=dataReader["Supplier_SubName"].ToString();
			model.Product=dataReader["Product"].ToString();
			model.Log=dataReader["Log"].ToString();
			model.HtmlLog=dataReader["HtmlLog"].ToString();
			return model;
		}

	}
	class access_Lebi_Transport_Order : Lebi_Transport_Order_interface
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
				strSql.Append("select " + colName + " from [Lebi_Transport_Order]");
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
			strSql.Append("select  "+colName+" from [Lebi_Transport_Order]");
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
			strSql.Append("select count(*) from [Lebi_Transport_Order]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Transport_Order]");
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
			strSql.Append("select max(id) from [Lebi_Transport_Order]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Transport_Order]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Transport_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Transport_Order](");
			strSql.Append("[Transport_id],[Transport_Name],[Code],[Transport_Code],[Time_Add],[Time_Received],[T_Name],[T_Address],[T_Email],[T_MobilePhone],[T_Phone],[Order_id],[User_id],[Type_id_TransportOrderStatus],[IsHaveNewLog],[Money],[Admin_id],[AdminName],[Supplier_id],[Supplier_SubName],[Product],[Log],[HtmlLog])");
			strSql.Append(" values (");
			strSql.Append("@Transport_id,@Transport_Name,@Code,@Transport_Code,@Time_Add,@Time_Received,@T_Name,@T_Address,@T_Email,@T_MobilePhone,@T_Phone,@Order_id,@User_id,@Type_id_TransportOrderStatus,@IsHaveNewLog,@Money,@Admin_id,@AdminName,@Supplier_id,@Supplier_SubName,@Product,@Log,@HtmlLog)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Transport_id", model.Transport_id),
					new OleDbParameter("@Transport_Name", model.Transport_Name),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Transport_Code", model.Transport_Code),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Received", model.Time_Received.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@T_Name", model.T_Name),
					new OleDbParameter("@T_Address", model.T_Address),
					new OleDbParameter("@T_Email", model.T_Email),
					new OleDbParameter("@T_MobilePhone", model.T_MobilePhone),
					new OleDbParameter("@T_Phone", model.T_Phone),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Type_id_TransportOrderStatus", model.Type_id_TransportOrderStatus),
					new OleDbParameter("@IsHaveNewLog", model.IsHaveNewLog),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@AdminName", model.AdminName),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Supplier_SubName", model.Supplier_SubName),
					new OleDbParameter("@Product", model.Product),
					new OleDbParameter("@Log", model.Log),
					new OleDbParameter("@HtmlLog", model.HtmlLog)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Transport_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Transport_Order] set ");
			strSql.Append("[Transport_id]=@Transport_id,");
			strSql.Append("[Transport_Name]=@Transport_Name,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[Transport_Code]=@Transport_Code,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Received]=@Time_Received,");
			strSql.Append("[T_Name]=@T_Name,");
			strSql.Append("[T_Address]=@T_Address,");
			strSql.Append("[T_Email]=@T_Email,");
			strSql.Append("[T_MobilePhone]=@T_MobilePhone,");
			strSql.Append("[T_Phone]=@T_Phone,");
			strSql.Append("[Order_id]=@Order_id,");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[Type_id_TransportOrderStatus]=@Type_id_TransportOrderStatus,");
			strSql.Append("[IsHaveNewLog]=@IsHaveNewLog,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[AdminName]=@AdminName,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Supplier_SubName]=@Supplier_SubName,");
			strSql.Append("[Product]=@Product,");
			strSql.Append("[Log]=@Log,");
			strSql.Append("[HtmlLog]=@HtmlLog");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Transport_id", model.Transport_id),
					new OleDbParameter("@Transport_Name", model.Transport_Name),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Transport_Code", model.Transport_Code),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Received", model.Time_Received.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@T_Name", model.T_Name),
					new OleDbParameter("@T_Address", model.T_Address),
					new OleDbParameter("@T_Email", model.T_Email),
					new OleDbParameter("@T_MobilePhone", model.T_MobilePhone),
					new OleDbParameter("@T_Phone", model.T_Phone),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Type_id_TransportOrderStatus", model.Type_id_TransportOrderStatus),
					new OleDbParameter("@IsHaveNewLog", model.IsHaveNewLog),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@AdminName", model.AdminName),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Supplier_SubName", model.Supplier_SubName),
					new OleDbParameter("@Product", model.Product),
					new OleDbParameter("@Log", model.Log),
					new OleDbParameter("@HtmlLog", model.HtmlLog)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Transport_Order] ");
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
			strSql.Append("delete from [Lebi_Transport_Order] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Transport_Order] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Transport_Order GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Transport_Order] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Transport_Order model;
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
		public Lebi_Transport_Order GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Transport_Order] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Transport_Order model;
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
		public Lebi_Transport_Order GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Transport_Order] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Transport_Order model;
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
		public List<Lebi_Transport_Order> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Transport_Order]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Transport_Order> list = new List<Lebi_Transport_Order>();
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
		public List<Lebi_Transport_Order> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Transport_Order]";
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
			List<Lebi_Transport_Order> list = new List<Lebi_Transport_Order>();
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
		public List<Lebi_Transport_Order> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Transport_Order] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Transport_Order> list = new List<Lebi_Transport_Order>();
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
		public List<Lebi_Transport_Order> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Transport_Order]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Transport_Order> list = new List<Lebi_Transport_Order>();
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
		public Lebi_Transport_Order BindForm(Lebi_Transport_Order model)
		{
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Transport_Name"] != null)
				model.Transport_Name=Shop.Tools.RequestTool.RequestString("Transport_Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Transport_Code"] != null)
				model.Transport_Code=Shop.Tools.RequestTool.RequestString("Transport_Code");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Received"] != null)
				model.Time_Received=Shop.Tools.RequestTool.RequestTime("Time_Received", System.DateTime.Now);
			if (HttpContext.Current.Request["T_Name"] != null)
				model.T_Name=Shop.Tools.RequestTool.RequestString("T_Name");
			if (HttpContext.Current.Request["T_Address"] != null)
				model.T_Address=Shop.Tools.RequestTool.RequestString("T_Address");
			if (HttpContext.Current.Request["T_Email"] != null)
				model.T_Email=Shop.Tools.RequestTool.RequestString("T_Email");
			if (HttpContext.Current.Request["T_MobilePhone"] != null)
				model.T_MobilePhone=Shop.Tools.RequestTool.RequestString("T_MobilePhone");
			if (HttpContext.Current.Request["T_Phone"] != null)
				model.T_Phone=Shop.Tools.RequestTool.RequestString("T_Phone");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Type_id_TransportOrderStatus"] != null)
				model.Type_id_TransportOrderStatus=Shop.Tools.RequestTool.RequestInt("Type_id_TransportOrderStatus",0);
			if (HttpContext.Current.Request["IsHaveNewLog"] != null)
				model.IsHaveNewLog=Shop.Tools.RequestTool.RequestInt("IsHaveNewLog",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["AdminName"] != null)
				model.AdminName=Shop.Tools.RequestTool.RequestString("AdminName");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestString("Supplier_SubName");
			if (HttpContext.Current.Request["Product"] != null)
				model.Product=Shop.Tools.RequestTool.RequestString("Product");
			if (HttpContext.Current.Request["Log"] != null)
				model.Log=Shop.Tools.RequestTool.RequestString("Log");
			if (HttpContext.Current.Request["HtmlLog"] != null)
				model.HtmlLog=Shop.Tools.RequestTool.RequestString("HtmlLog");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Transport_Order SafeBindForm(Lebi_Transport_Order model)
		{
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Transport_Name"] != null)
				model.Transport_Name=Shop.Tools.RequestTool.RequestSafeString("Transport_Name");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Transport_Code"] != null)
				model.Transport_Code=Shop.Tools.RequestTool.RequestSafeString("Transport_Code");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Received"] != null)
				model.Time_Received=Shop.Tools.RequestTool.RequestTime("Time_Received", System.DateTime.Now);
			if (HttpContext.Current.Request["T_Name"] != null)
				model.T_Name=Shop.Tools.RequestTool.RequestSafeString("T_Name");
			if (HttpContext.Current.Request["T_Address"] != null)
				model.T_Address=Shop.Tools.RequestTool.RequestSafeString("T_Address");
			if (HttpContext.Current.Request["T_Email"] != null)
				model.T_Email=Shop.Tools.RequestTool.RequestSafeString("T_Email");
			if (HttpContext.Current.Request["T_MobilePhone"] != null)
				model.T_MobilePhone=Shop.Tools.RequestTool.RequestSafeString("T_MobilePhone");
			if (HttpContext.Current.Request["T_Phone"] != null)
				model.T_Phone=Shop.Tools.RequestTool.RequestSafeString("T_Phone");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Type_id_TransportOrderStatus"] != null)
				model.Type_id_TransportOrderStatus=Shop.Tools.RequestTool.RequestInt("Type_id_TransportOrderStatus",0);
			if (HttpContext.Current.Request["IsHaveNewLog"] != null)
				model.IsHaveNewLog=Shop.Tools.RequestTool.RequestInt("IsHaveNewLog",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["AdminName"] != null)
				model.AdminName=Shop.Tools.RequestTool.RequestSafeString("AdminName");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestSafeString("Supplier_SubName");
			if (HttpContext.Current.Request["Product"] != null)
				model.Product=Shop.Tools.RequestTool.RequestSafeString("Product");
			if (HttpContext.Current.Request["Log"] != null)
				model.Log=Shop.Tools.RequestTool.RequestSafeString("Log");
			if (HttpContext.Current.Request["HtmlLog"] != null)
				model.HtmlLog=Shop.Tools.RequestTool.RequestSafeString("HtmlLog");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Transport_Order ReaderBind(IDataReader dataReader)
		{
			Lebi_Transport_Order model=new Lebi_Transport_Order();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Transport_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Transport_id=(int)ojb;
			}
			model.Transport_Name=dataReader["Transport_Name"].ToString();
			model.Code=dataReader["Code"].ToString();
			model.Transport_Code=dataReader["Transport_Code"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Received"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Received=(DateTime)ojb;
			}
			model.T_Name=dataReader["T_Name"].ToString();
			model.T_Address=dataReader["T_Address"].ToString();
			model.T_Email=dataReader["T_Email"].ToString();
			model.T_MobilePhone=dataReader["T_MobilePhone"].ToString();
			model.T_Phone=dataReader["T_Phone"].ToString();
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["Type_id_TransportOrderStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_TransportOrderStatus=(int)ojb;
			}
			ojb = dataReader["IsHaveNewLog"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsHaveNewLog=(int)ojb;
			}
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.AdminName=dataReader["AdminName"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			model.Supplier_SubName=dataReader["Supplier_SubName"].ToString();
			model.Product=dataReader["Product"].ToString();
			model.Log=dataReader["Log"].ToString();
			model.HtmlLog=dataReader["HtmlLog"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

