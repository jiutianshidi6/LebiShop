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

	public interface Lebi_Order_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Order model);
		void Update(Lebi_Order model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Order GetModel(int id);
		Lebi_Order GetModel(string strWhere);
		Lebi_Order GetModel(SQLPara para);
		List<Lebi_Order> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Order> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Order> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Order> GetList(SQLPara para);
		Lebi_Order BindForm(Lebi_Order model);
		Lebi_Order SafeBindForm(Lebi_Order model);
		Lebi_Order ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Order。
	/// </summary>
	public class D_Lebi_Order
	{
		static Lebi_Order_interface _Instance;
		public static Lebi_Order_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Order();
		            else
		                _Instance = new sqlserver_Lebi_Order();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Order()
		{}
		#region  成员方法
	class sqlserver_Lebi_Order : Lebi_Order_interface
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
				strSql.Append("select " + colName + " from [Lebi_Order]");
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
			strSql.Append("select  "+colName+" from [Lebi_Order]");
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
			strSql.Append("select count(1) from [Lebi_Order]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Order]");
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
			strSql.Append("select max(id) from [Lebi_Order]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Order]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Order](");
			strSql.Append("Code,User_id,User_UserName,T_Name,T_Area_id,T_Address,T_Phone,T_MobilePhone,T_Postalcode,T_Email,Remark_User,Pay_id,Pay,OnlinePay_id,OnlinePay,OnlinePay_Code,Money_Order,Money_Pay,Money_Product,Money_Transport,Money_Transport_Cut,Money_Bill,Money_Market,Money_Give,Money_Cut,Money_UserCut,Money_Cost,Money_Property,Money_UseCard311,Money_UseCard312,Money_fromorder,UseCardCode311,UseCardCode312,Weight,Volume,Point,Point_Buy,Point_Product,Point_Free,Transport_Name,Transport_id,Transport_Price_id,Transport_Code,Transport_Mark,EditMoney_Order,EditMoney_Transport,EditMoney_Discount,IsVerified,IsPaid,IsShipped,IsShipped_All,IsReceived,IsReceived_All,IsCompleted,IsInvalid,IsCreateCash,IsCreateNewOrder,Time_Add,Time_Verified,Time_Paid,Time_Shipped,Time_Received,Time_Completed,Time_CreateCash,Time_CreateNewOrder,Remark_Admin,BillType_Name,BillType_id,BillType_TaxRate,Type_id_OrderType,Order_id,IsPrintExpress,Promotion_Type_ids,Mark,Currency_id,Currency_Code,Currency_ExchangeRate,Currency_Msige,Supplier_id,Flag,Site_id,BLNo,ContainerNo,SealNo,weixin_prepay_id,IsSupplierCash,Money_OnlinepayFee,Site_id_pay,PickUp_id,PickUp_Name,PickUp_Date,Refund_VAT,Refund_Fee,Language_id,Supplier_Delivery_id,IsRefund,Time_Refund,Promotion_Type_Name,User_NickName,Money_Paid,IsReserve,Money_fanxianpay,Money_Tax,DT_id,DT_Money,IsDel)");
			strSql.Append(" values (");
			strSql.Append("@Code,@User_id,@User_UserName,@T_Name,@T_Area_id,@T_Address,@T_Phone,@T_MobilePhone,@T_Postalcode,@T_Email,@Remark_User,@Pay_id,@Pay,@OnlinePay_id,@OnlinePay,@OnlinePay_Code,@Money_Order,@Money_Pay,@Money_Product,@Money_Transport,@Money_Transport_Cut,@Money_Bill,@Money_Market,@Money_Give,@Money_Cut,@Money_UserCut,@Money_Cost,@Money_Property,@Money_UseCard311,@Money_UseCard312,@Money_fromorder,@UseCardCode311,@UseCardCode312,@Weight,@Volume,@Point,@Point_Buy,@Point_Product,@Point_Free,@Transport_Name,@Transport_id,@Transport_Price_id,@Transport_Code,@Transport_Mark,@EditMoney_Order,@EditMoney_Transport,@EditMoney_Discount,@IsVerified,@IsPaid,@IsShipped,@IsShipped_All,@IsReceived,@IsReceived_All,@IsCompleted,@IsInvalid,@IsCreateCash,@IsCreateNewOrder,@Time_Add,@Time_Verified,@Time_Paid,@Time_Shipped,@Time_Received,@Time_Completed,@Time_CreateCash,@Time_CreateNewOrder,@Remark_Admin,@BillType_Name,@BillType_id,@BillType_TaxRate,@Type_id_OrderType,@Order_id,@IsPrintExpress,@Promotion_Type_ids,@Mark,@Currency_id,@Currency_Code,@Currency_ExchangeRate,@Currency_Msige,@Supplier_id,@Flag,@Site_id,@BLNo,@ContainerNo,@SealNo,@weixin_prepay_id,@IsSupplierCash,@Money_OnlinepayFee,@Site_id_pay,@PickUp_id,@PickUp_Name,@PickUp_Date,@Refund_VAT,@Refund_Fee,@Language_id,@Supplier_Delivery_id,@IsRefund,@Time_Refund,@Promotion_Type_Name,@User_NickName,@Money_Paid,@IsReserve,@Money_fanxianpay,@Money_Tax,@DT_id,@DT_Money,@IsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@User_UserName", model.User_UserName),
					new SqlParameter("@T_Name", model.T_Name),
					new SqlParameter("@T_Area_id", model.T_Area_id),
					new SqlParameter("@T_Address", model.T_Address),
					new SqlParameter("@T_Phone", model.T_Phone),
					new SqlParameter("@T_MobilePhone", model.T_MobilePhone),
					new SqlParameter("@T_Postalcode", model.T_Postalcode),
					new SqlParameter("@T_Email", model.T_Email),
					new SqlParameter("@Remark_User", model.Remark_User),
					new SqlParameter("@Pay_id", model.Pay_id),
					new SqlParameter("@Pay", model.Pay),
					new SqlParameter("@OnlinePay_id", model.OnlinePay_id),
					new SqlParameter("@OnlinePay", model.OnlinePay),
					new SqlParameter("@OnlinePay_Code", model.OnlinePay_Code),
					new SqlParameter("@Money_Order", model.Money_Order),
					new SqlParameter("@Money_Pay", model.Money_Pay),
					new SqlParameter("@Money_Product", model.Money_Product),
					new SqlParameter("@Money_Transport", model.Money_Transport),
					new SqlParameter("@Money_Transport_Cut", model.Money_Transport_Cut),
					new SqlParameter("@Money_Bill", model.Money_Bill),
					new SqlParameter("@Money_Market", model.Money_Market),
					new SqlParameter("@Money_Give", model.Money_Give),
					new SqlParameter("@Money_Cut", model.Money_Cut),
					new SqlParameter("@Money_UserCut", model.Money_UserCut),
					new SqlParameter("@Money_Cost", model.Money_Cost),
					new SqlParameter("@Money_Property", model.Money_Property),
					new SqlParameter("@Money_UseCard311", model.Money_UseCard311),
					new SqlParameter("@Money_UseCard312", model.Money_UseCard312),
					new SqlParameter("@Money_fromorder", model.Money_fromorder),
					new SqlParameter("@UseCardCode311", model.UseCardCode311),
					new SqlParameter("@UseCardCode312", model.UseCardCode312),
					new SqlParameter("@Weight", model.Weight),
					new SqlParameter("@Volume", model.Volume),
					new SqlParameter("@Point", model.Point),
					new SqlParameter("@Point_Buy", model.Point_Buy),
					new SqlParameter("@Point_Product", model.Point_Product),
					new SqlParameter("@Point_Free", model.Point_Free),
					new SqlParameter("@Transport_Name", model.Transport_Name),
					new SqlParameter("@Transport_id", model.Transport_id),
					new SqlParameter("@Transport_Price_id", model.Transport_Price_id),
					new SqlParameter("@Transport_Code", model.Transport_Code),
					new SqlParameter("@Transport_Mark", model.Transport_Mark),
					new SqlParameter("@EditMoney_Order", model.EditMoney_Order),
					new SqlParameter("@EditMoney_Transport", model.EditMoney_Transport),
					new SqlParameter("@EditMoney_Discount", model.EditMoney_Discount),
					new SqlParameter("@IsVerified", model.IsVerified),
					new SqlParameter("@IsPaid", model.IsPaid),
					new SqlParameter("@IsShipped", model.IsShipped),
					new SqlParameter("@IsShipped_All", model.IsShipped_All),
					new SqlParameter("@IsReceived", model.IsReceived),
					new SqlParameter("@IsReceived_All", model.IsReceived_All),
					new SqlParameter("@IsCompleted", model.IsCompleted),
					new SqlParameter("@IsInvalid", model.IsInvalid),
					new SqlParameter("@IsCreateCash", model.IsCreateCash),
					new SqlParameter("@IsCreateNewOrder", model.IsCreateNewOrder),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Verified", model.Time_Verified),
					new SqlParameter("@Time_Paid", model.Time_Paid),
					new SqlParameter("@Time_Shipped", model.Time_Shipped),
					new SqlParameter("@Time_Received", model.Time_Received),
					new SqlParameter("@Time_Completed", model.Time_Completed),
					new SqlParameter("@Time_CreateCash", model.Time_CreateCash),
					new SqlParameter("@Time_CreateNewOrder", model.Time_CreateNewOrder),
					new SqlParameter("@Remark_Admin", model.Remark_Admin),
					new SqlParameter("@BillType_Name", model.BillType_Name),
					new SqlParameter("@BillType_id", model.BillType_id),
					new SqlParameter("@BillType_TaxRate", model.BillType_TaxRate),
					new SqlParameter("@Type_id_OrderType", model.Type_id_OrderType),
					new SqlParameter("@Order_id", model.Order_id),
					new SqlParameter("@IsPrintExpress", model.IsPrintExpress),
					new SqlParameter("@Promotion_Type_ids", model.Promotion_Type_ids),
					new SqlParameter("@Mark", model.Mark),
					new SqlParameter("@Currency_id", model.Currency_id),
					new SqlParameter("@Currency_Code", model.Currency_Code),
					new SqlParameter("@Currency_ExchangeRate", model.Currency_ExchangeRate),
					new SqlParameter("@Currency_Msige", model.Currency_Msige),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Flag", model.Flag),
					new SqlParameter("@Site_id", model.Site_id),
					new SqlParameter("@BLNo", model.BLNo),
					new SqlParameter("@ContainerNo", model.ContainerNo),
					new SqlParameter("@SealNo", model.SealNo),
					new SqlParameter("@weixin_prepay_id", model.weixin_prepay_id),
					new SqlParameter("@IsSupplierCash", model.IsSupplierCash),
					new SqlParameter("@Money_OnlinepayFee", model.Money_OnlinepayFee),
					new SqlParameter("@Site_id_pay", model.Site_id_pay),
					new SqlParameter("@PickUp_id", model.PickUp_id),
					new SqlParameter("@PickUp_Name", model.PickUp_Name),
					new SqlParameter("@PickUp_Date", model.PickUp_Date),
					new SqlParameter("@Refund_VAT", model.Refund_VAT),
					new SqlParameter("@Refund_Fee", model.Refund_Fee),
					new SqlParameter("@Language_id", model.Language_id),
					new SqlParameter("@Supplier_Delivery_id", model.Supplier_Delivery_id),
					new SqlParameter("@IsRefund", model.IsRefund),
					new SqlParameter("@Time_Refund", model.Time_Refund),
					new SqlParameter("@Promotion_Type_Name", model.Promotion_Type_Name),
					new SqlParameter("@User_NickName", model.User_NickName),
					new SqlParameter("@Money_Paid", model.Money_Paid),
					new SqlParameter("@IsReserve", model.IsReserve),
					new SqlParameter("@Money_fanxianpay", model.Money_fanxianpay),
					new SqlParameter("@Money_Tax", model.Money_Tax),
					new SqlParameter("@DT_id", model.DT_id),
					new SqlParameter("@DT_Money", model.DT_Money),
					new SqlParameter("@IsDel", model.IsDel)};

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
		public void Update(Lebi_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Order] set ");
			strSql.Append("Code= @Code,");
			strSql.Append("User_id= @User_id,");
			strSql.Append("User_UserName= @User_UserName,");
			strSql.Append("T_Name= @T_Name,");
			strSql.Append("T_Area_id= @T_Area_id,");
			strSql.Append("T_Address= @T_Address,");
			strSql.Append("T_Phone= @T_Phone,");
			strSql.Append("T_MobilePhone= @T_MobilePhone,");
			strSql.Append("T_Postalcode= @T_Postalcode,");
			strSql.Append("T_Email= @T_Email,");
			strSql.Append("Remark_User= @Remark_User,");
			strSql.Append("Pay_id= @Pay_id,");
			strSql.Append("Pay= @Pay,");
			strSql.Append("OnlinePay_id= @OnlinePay_id,");
			strSql.Append("OnlinePay= @OnlinePay,");
			strSql.Append("OnlinePay_Code= @OnlinePay_Code,");
			strSql.Append("Money_Order= @Money_Order,");
			strSql.Append("Money_Pay= @Money_Pay,");
			strSql.Append("Money_Product= @Money_Product,");
			strSql.Append("Money_Transport= @Money_Transport,");
			strSql.Append("Money_Transport_Cut= @Money_Transport_Cut,");
			strSql.Append("Money_Bill= @Money_Bill,");
			strSql.Append("Money_Market= @Money_Market,");
			strSql.Append("Money_Give= @Money_Give,");
			strSql.Append("Money_Cut= @Money_Cut,");
			strSql.Append("Money_UserCut= @Money_UserCut,");
			strSql.Append("Money_Cost= @Money_Cost,");
			strSql.Append("Money_Property= @Money_Property,");
			strSql.Append("Money_UseCard311= @Money_UseCard311,");
			strSql.Append("Money_UseCard312= @Money_UseCard312,");
			strSql.Append("Money_fromorder= @Money_fromorder,");
			strSql.Append("UseCardCode311= @UseCardCode311,");
			strSql.Append("UseCardCode312= @UseCardCode312,");
			strSql.Append("Weight= @Weight,");
			strSql.Append("Volume= @Volume,");
			strSql.Append("Point= @Point,");
			strSql.Append("Point_Buy= @Point_Buy,");
			strSql.Append("Point_Product= @Point_Product,");
			strSql.Append("Point_Free= @Point_Free,");
			strSql.Append("Transport_Name= @Transport_Name,");
			strSql.Append("Transport_id= @Transport_id,");
			strSql.Append("Transport_Price_id= @Transport_Price_id,");
			strSql.Append("Transport_Code= @Transport_Code,");
			strSql.Append("Transport_Mark= @Transport_Mark,");
			strSql.Append("EditMoney_Order= @EditMoney_Order,");
			strSql.Append("EditMoney_Transport= @EditMoney_Transport,");
			strSql.Append("EditMoney_Discount= @EditMoney_Discount,");
			strSql.Append("IsVerified= @IsVerified,");
			strSql.Append("IsPaid= @IsPaid,");
			strSql.Append("IsShipped= @IsShipped,");
			strSql.Append("IsShipped_All= @IsShipped_All,");
			strSql.Append("IsReceived= @IsReceived,");
			strSql.Append("IsReceived_All= @IsReceived_All,");
			strSql.Append("IsCompleted= @IsCompleted,");
			strSql.Append("IsInvalid= @IsInvalid,");
			strSql.Append("IsCreateCash= @IsCreateCash,");
			strSql.Append("IsCreateNewOrder= @IsCreateNewOrder,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Verified= @Time_Verified,");
			strSql.Append("Time_Paid= @Time_Paid,");
			strSql.Append("Time_Shipped= @Time_Shipped,");
			strSql.Append("Time_Received= @Time_Received,");
			strSql.Append("Time_Completed= @Time_Completed,");
			strSql.Append("Time_CreateCash= @Time_CreateCash,");
			strSql.Append("Time_CreateNewOrder= @Time_CreateNewOrder,");
			strSql.Append("Remark_Admin= @Remark_Admin,");
			strSql.Append("BillType_Name= @BillType_Name,");
			strSql.Append("BillType_id= @BillType_id,");
			strSql.Append("BillType_TaxRate= @BillType_TaxRate,");
			strSql.Append("Type_id_OrderType= @Type_id_OrderType,");
			strSql.Append("Order_id= @Order_id,");
			strSql.Append("IsPrintExpress= @IsPrintExpress,");
			strSql.Append("Promotion_Type_ids= @Promotion_Type_ids,");
			strSql.Append("Mark= @Mark,");
			strSql.Append("Currency_id= @Currency_id,");
			strSql.Append("Currency_Code= @Currency_Code,");
			strSql.Append("Currency_ExchangeRate= @Currency_ExchangeRate,");
			strSql.Append("Currency_Msige= @Currency_Msige,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Flag= @Flag,");
			strSql.Append("Site_id= @Site_id,");
			strSql.Append("BLNo= @BLNo,");
			strSql.Append("ContainerNo= @ContainerNo,");
			strSql.Append("SealNo= @SealNo,");
			strSql.Append("weixin_prepay_id= @weixin_prepay_id,");
			strSql.Append("IsSupplierCash= @IsSupplierCash,");
			strSql.Append("Money_OnlinepayFee= @Money_OnlinepayFee,");
			strSql.Append("Site_id_pay= @Site_id_pay,");
			strSql.Append("PickUp_id= @PickUp_id,");
			strSql.Append("PickUp_Name= @PickUp_Name,");
			strSql.Append("PickUp_Date= @PickUp_Date,");
			strSql.Append("Refund_VAT= @Refund_VAT,");
			strSql.Append("Refund_Fee= @Refund_Fee,");
			strSql.Append("Language_id= @Language_id,");
			strSql.Append("Supplier_Delivery_id= @Supplier_Delivery_id,");
			strSql.Append("IsRefund= @IsRefund,");
			strSql.Append("Time_Refund= @Time_Refund,");
			strSql.Append("Promotion_Type_Name= @Promotion_Type_Name,");
			strSql.Append("User_NickName= @User_NickName,");
			strSql.Append("Money_Paid= @Money_Paid,");
			strSql.Append("IsReserve= @IsReserve,");
			strSql.Append("Money_fanxianpay= @Money_fanxianpay,");
			strSql.Append("Money_Tax= @Money_Tax,");
			strSql.Append("DT_id= @DT_id,");
			strSql.Append("DT_Money= @DT_Money,");
			strSql.Append("IsDel= @IsDel");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@T_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@T_Area_id", SqlDbType.Int,4),
					new SqlParameter("@T_Address", SqlDbType.NVarChar,200),
					new SqlParameter("@T_Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@T_MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@T_Postalcode", SqlDbType.NVarChar,50),
					new SqlParameter("@T_Email", SqlDbType.NVarChar,255),
					new SqlParameter("@Remark_User", SqlDbType.NVarChar,500),
					new SqlParameter("@Pay_id", SqlDbType.Int,4),
					new SqlParameter("@Pay", SqlDbType.NVarChar,2000),
					new SqlParameter("@OnlinePay_id", SqlDbType.Int,4),
					new SqlParameter("@OnlinePay", SqlDbType.NVarChar,2000),
					new SqlParameter("@OnlinePay_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Money_Order", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Pay", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Product", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Transport", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Transport_Cut", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Bill", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Market", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Give", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Cut", SqlDbType.Decimal,9),
					new SqlParameter("@Money_UserCut", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Cost", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Property", SqlDbType.Decimal,9),
					new SqlParameter("@Money_UseCard311", SqlDbType.Decimal,9),
					new SqlParameter("@Money_UseCard312", SqlDbType.Decimal,9),
					new SqlParameter("@Money_fromorder", SqlDbType.Decimal,9),
					new SqlParameter("@UseCardCode311", SqlDbType.NVarChar,100),
					new SqlParameter("@UseCardCode312", SqlDbType.NVarChar,100),
					new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@Volume", SqlDbType.Decimal,9),
					new SqlParameter("@Point", SqlDbType.Decimal,9),
					new SqlParameter("@Point_Buy", SqlDbType.Decimal,9),
					new SqlParameter("@Point_Product", SqlDbType.Decimal,9),
					new SqlParameter("@Point_Free", SqlDbType.Decimal,9),
					new SqlParameter("@Transport_Name", SqlDbType.NVarChar,200),
					new SqlParameter("@Transport_id", SqlDbType.Int,4),
					new SqlParameter("@Transport_Price_id", SqlDbType.Int,4),
					new SqlParameter("@Transport_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Transport_Mark", SqlDbType.NVarChar,500),
					new SqlParameter("@EditMoney_Order", SqlDbType.Decimal,9),
					new SqlParameter("@EditMoney_Transport", SqlDbType.Decimal,9),
					new SqlParameter("@EditMoney_Discount", SqlDbType.Decimal,9),
					new SqlParameter("@IsVerified", SqlDbType.Int,4),
					new SqlParameter("@IsPaid", SqlDbType.Int,4),
					new SqlParameter("@IsShipped", SqlDbType.Int,4),
					new SqlParameter("@IsShipped_All", SqlDbType.Int,4),
					new SqlParameter("@IsReceived", SqlDbType.Int,4),
					new SqlParameter("@IsReceived_All", SqlDbType.Int,4),
					new SqlParameter("@IsCompleted", SqlDbType.Int,4),
					new SqlParameter("@IsInvalid", SqlDbType.Int,4),
					new SqlParameter("@IsCreateCash", SqlDbType.Int,4),
					new SqlParameter("@IsCreateNewOrder", SqlDbType.Int,4),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Verified", SqlDbType.DateTime),
					new SqlParameter("@Time_Paid", SqlDbType.DateTime),
					new SqlParameter("@Time_Shipped", SqlDbType.DateTime),
					new SqlParameter("@Time_Received", SqlDbType.DateTime),
					new SqlParameter("@Time_Completed", SqlDbType.DateTime),
					new SqlParameter("@Time_CreateCash", SqlDbType.DateTime),
					new SqlParameter("@Time_CreateNewOrder", SqlDbType.DateTime),
					new SqlParameter("@Remark_Admin", SqlDbType.NVarChar,500),
					new SqlParameter("@BillType_Name", SqlDbType.NVarChar,2000),
					new SqlParameter("@BillType_id", SqlDbType.Int,4),
					new SqlParameter("@BillType_TaxRate", SqlDbType.Decimal,9),
					new SqlParameter("@Type_id_OrderType", SqlDbType.Int,4),
					new SqlParameter("@Order_id", SqlDbType.Int,4),
					new SqlParameter("@IsPrintExpress", SqlDbType.Int,4),
					new SqlParameter("@Promotion_Type_ids", SqlDbType.NVarChar,50),
					new SqlParameter("@Mark", SqlDbType.Int,4),
					new SqlParameter("@Currency_id", SqlDbType.Int,4),
					new SqlParameter("@Currency_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency_ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@Currency_Msige", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@Site_id", SqlDbType.Int,4),
					new SqlParameter("@BLNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContainerNo", SqlDbType.NVarChar,50),
					new SqlParameter("@SealNo", SqlDbType.NVarChar,50),
					new SqlParameter("@weixin_prepay_id", SqlDbType.NVarChar,50),
					new SqlParameter("@IsSupplierCash", SqlDbType.Int,4),
					new SqlParameter("@Money_OnlinepayFee", SqlDbType.Decimal,9),
					new SqlParameter("@Site_id_pay", SqlDbType.Int,4),
					new SqlParameter("@PickUp_id", SqlDbType.Int,4),
					new SqlParameter("@PickUp_Name", SqlDbType.NVarChar,500),
					new SqlParameter("@PickUp_Date", SqlDbType.DateTime),
					new SqlParameter("@Refund_VAT", SqlDbType.Decimal,9),
					new SqlParameter("@Refund_Fee", SqlDbType.Decimal,9),
					new SqlParameter("@Language_id", SqlDbType.Int,4),
					new SqlParameter("@Supplier_Delivery_id", SqlDbType.Int,4),
					new SqlParameter("@IsRefund", SqlDbType.Int,4),
					new SqlParameter("@Time_Refund", SqlDbType.DateTime),
					new SqlParameter("@Promotion_Type_Name", SqlDbType.NVarChar,500),
					new SqlParameter("@User_NickName", SqlDbType.NVarChar,50),
					new SqlParameter("@Money_Paid", SqlDbType.Decimal,9),
					new SqlParameter("@IsReserve", SqlDbType.Int,4),
					new SqlParameter("@Money_fanxianpay", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Tax", SqlDbType.Decimal,9),
					new SqlParameter("@DT_id", SqlDbType.Int,4),
					new SqlParameter("@DT_Money", SqlDbType.Decimal,9),
					new SqlParameter("@IsDel", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.User_id;
			parameters[3].Value = model.User_UserName;
			parameters[4].Value = model.T_Name;
			parameters[5].Value = model.T_Area_id;
			parameters[6].Value = model.T_Address;
			parameters[7].Value = model.T_Phone;
			parameters[8].Value = model.T_MobilePhone;
			parameters[9].Value = model.T_Postalcode;
			parameters[10].Value = model.T_Email;
			parameters[11].Value = model.Remark_User;
			parameters[12].Value = model.Pay_id;
			parameters[13].Value = model.Pay;
			parameters[14].Value = model.OnlinePay_id;
			parameters[15].Value = model.OnlinePay;
			parameters[16].Value = model.OnlinePay_Code;
			parameters[17].Value = model.Money_Order;
			parameters[18].Value = model.Money_Pay;
			parameters[19].Value = model.Money_Product;
			parameters[20].Value = model.Money_Transport;
			parameters[21].Value = model.Money_Transport_Cut;
			parameters[22].Value = model.Money_Bill;
			parameters[23].Value = model.Money_Market;
			parameters[24].Value = model.Money_Give;
			parameters[25].Value = model.Money_Cut;
			parameters[26].Value = model.Money_UserCut;
			parameters[27].Value = model.Money_Cost;
			parameters[28].Value = model.Money_Property;
			parameters[29].Value = model.Money_UseCard311;
			parameters[30].Value = model.Money_UseCard312;
			parameters[31].Value = model.Money_fromorder;
			parameters[32].Value = model.UseCardCode311;
			parameters[33].Value = model.UseCardCode312;
			parameters[34].Value = model.Weight;
			parameters[35].Value = model.Volume;
			parameters[36].Value = model.Point;
			parameters[37].Value = model.Point_Buy;
			parameters[38].Value = model.Point_Product;
			parameters[39].Value = model.Point_Free;
			parameters[40].Value = model.Transport_Name;
			parameters[41].Value = model.Transport_id;
			parameters[42].Value = model.Transport_Price_id;
			parameters[43].Value = model.Transport_Code;
			parameters[44].Value = model.Transport_Mark;
			parameters[45].Value = model.EditMoney_Order;
			parameters[46].Value = model.EditMoney_Transport;
			parameters[47].Value = model.EditMoney_Discount;
			parameters[48].Value = model.IsVerified;
			parameters[49].Value = model.IsPaid;
			parameters[50].Value = model.IsShipped;
			parameters[51].Value = model.IsShipped_All;
			parameters[52].Value = model.IsReceived;
			parameters[53].Value = model.IsReceived_All;
			parameters[54].Value = model.IsCompleted;
			parameters[55].Value = model.IsInvalid;
			parameters[56].Value = model.IsCreateCash;
			parameters[57].Value = model.IsCreateNewOrder;
			parameters[58].Value = model.Time_Add;
			parameters[59].Value = model.Time_Verified;
			parameters[60].Value = model.Time_Paid;
			parameters[61].Value = model.Time_Shipped;
			parameters[62].Value = model.Time_Received;
			parameters[63].Value = model.Time_Completed;
			parameters[64].Value = model.Time_CreateCash;
			parameters[65].Value = model.Time_CreateNewOrder;
			parameters[66].Value = model.Remark_Admin;
			parameters[67].Value = model.BillType_Name;
			parameters[68].Value = model.BillType_id;
			parameters[69].Value = model.BillType_TaxRate;
			parameters[70].Value = model.Type_id_OrderType;
			parameters[71].Value = model.Order_id;
			parameters[72].Value = model.IsPrintExpress;
			parameters[73].Value = model.Promotion_Type_ids;
			parameters[74].Value = model.Mark;
			parameters[75].Value = model.Currency_id;
			parameters[76].Value = model.Currency_Code;
			parameters[77].Value = model.Currency_ExchangeRate;
			parameters[78].Value = model.Currency_Msige;
			parameters[79].Value = model.Supplier_id;
			parameters[80].Value = model.Flag;
			parameters[81].Value = model.Site_id;
			parameters[82].Value = model.BLNo;
			parameters[83].Value = model.ContainerNo;
			parameters[84].Value = model.SealNo;
			parameters[85].Value = model.weixin_prepay_id;
			parameters[86].Value = model.IsSupplierCash;
			parameters[87].Value = model.Money_OnlinepayFee;
			parameters[88].Value = model.Site_id_pay;
			parameters[89].Value = model.PickUp_id;
			parameters[90].Value = model.PickUp_Name;
			parameters[91].Value = model.PickUp_Date;
			parameters[92].Value = model.Refund_VAT;
			parameters[93].Value = model.Refund_Fee;
			parameters[94].Value = model.Language_id;
			parameters[95].Value = model.Supplier_Delivery_id;
			parameters[96].Value = model.IsRefund;
			parameters[97].Value = model.Time_Refund;
			parameters[98].Value = model.Promotion_Type_Name;
			parameters[99].Value = model.User_NickName;
			parameters[100].Value = model.Money_Paid;
			parameters[101].Value = model.IsReserve;
			parameters[102].Value = model.Money_fanxianpay;
			parameters[103].Value = model.Money_Tax;
			parameters[104].Value = model.DT_id;
			parameters[105].Value = model.DT_Money;
			parameters[106].Value = model.IsDel;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order] ");
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
			strSql.Append("delete from [Lebi_Order] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Order GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Order model=new Lebi_Order();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.T_Name=ds.Tables[0].Rows[0]["T_Name"].ToString();
				if(ds.Tables[0].Rows[0]["T_Area_id"].ToString()!="")
				{
					model.T_Area_id=int.Parse(ds.Tables[0].Rows[0]["T_Area_id"].ToString());
				}
				model.T_Address=ds.Tables[0].Rows[0]["T_Address"].ToString();
				model.T_Phone=ds.Tables[0].Rows[0]["T_Phone"].ToString();
				model.T_MobilePhone=ds.Tables[0].Rows[0]["T_MobilePhone"].ToString();
				model.T_Postalcode=ds.Tables[0].Rows[0]["T_Postalcode"].ToString();
				model.T_Email=ds.Tables[0].Rows[0]["T_Email"].ToString();
				model.Remark_User=ds.Tables[0].Rows[0]["Remark_User"].ToString();
				if(ds.Tables[0].Rows[0]["Pay_id"].ToString()!="")
				{
					model.Pay_id=int.Parse(ds.Tables[0].Rows[0]["Pay_id"].ToString());
				}
				model.Pay=ds.Tables[0].Rows[0]["Pay"].ToString();
				if(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString()!="")
				{
					model.OnlinePay_id=int.Parse(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString());
				}
				model.OnlinePay=ds.Tables[0].Rows[0]["OnlinePay"].ToString();
				model.OnlinePay_Code=ds.Tables[0].Rows[0]["OnlinePay_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Order"].ToString()!="")
				{
					model.Money_Order=decimal.Parse(ds.Tables[0].Rows[0]["Money_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Pay"].ToString()!="")
				{
					model.Money_Pay=decimal.Parse(ds.Tables[0].Rows[0]["Money_Pay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Product"].ToString()!="")
				{
					model.Money_Product=decimal.Parse(ds.Tables[0].Rows[0]["Money_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Transport"].ToString()!="")
				{
					model.Money_Transport=decimal.Parse(ds.Tables[0].Rows[0]["Money_Transport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Transport_Cut"].ToString()!="")
				{
					model.Money_Transport_Cut=decimal.Parse(ds.Tables[0].Rows[0]["Money_Transport_Cut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Bill"].ToString()!="")
				{
					model.Money_Bill=decimal.Parse(ds.Tables[0].Rows[0]["Money_Bill"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Market"].ToString()!="")
				{
					model.Money_Market=decimal.Parse(ds.Tables[0].Rows[0]["Money_Market"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Give"].ToString()!="")
				{
					model.Money_Give=decimal.Parse(ds.Tables[0].Rows[0]["Money_Give"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Cut"].ToString()!="")
				{
					model.Money_Cut=decimal.Parse(ds.Tables[0].Rows[0]["Money_Cut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_UserCut"].ToString()!="")
				{
					model.Money_UserCut=decimal.Parse(ds.Tables[0].Rows[0]["Money_UserCut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Cost"].ToString()!="")
				{
					model.Money_Cost=decimal.Parse(ds.Tables[0].Rows[0]["Money_Cost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Property"].ToString()!="")
				{
					model.Money_Property=decimal.Parse(ds.Tables[0].Rows[0]["Money_Property"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_UseCard311"].ToString()!="")
				{
					model.Money_UseCard311=decimal.Parse(ds.Tables[0].Rows[0]["Money_UseCard311"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_UseCard312"].ToString()!="")
				{
					model.Money_UseCard312=decimal.Parse(ds.Tables[0].Rows[0]["Money_UseCard312"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_fromorder"].ToString()!="")
				{
					model.Money_fromorder=decimal.Parse(ds.Tables[0].Rows[0]["Money_fromorder"].ToString());
				}
				model.UseCardCode311=ds.Tables[0].Rows[0]["UseCardCode311"].ToString();
				model.UseCardCode312=ds.Tables[0].Rows[0]["UseCardCode312"].ToString();
				if(ds.Tables[0].Rows[0]["Weight"].ToString()!="")
				{
					model.Weight=decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Volume"].ToString()!="")
				{
					model.Volume=decimal.Parse(ds.Tables[0].Rows[0]["Volume"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point"].ToString()!="")
				{
					model.Point=decimal.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Buy"].ToString()!="")
				{
					model.Point_Buy=decimal.Parse(ds.Tables[0].Rows[0]["Point_Buy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Product"].ToString()!="")
				{
					model.Point_Product=decimal.Parse(ds.Tables[0].Rows[0]["Point_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Free"].ToString()!="")
				{
					model.Point_Free=decimal.Parse(ds.Tables[0].Rows[0]["Point_Free"].ToString());
				}
				model.Transport_Name=ds.Tables[0].Rows[0]["Transport_Name"].ToString();
				if(ds.Tables[0].Rows[0]["Transport_id"].ToString()!="")
				{
					model.Transport_id=int.Parse(ds.Tables[0].Rows[0]["Transport_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Transport_Price_id"].ToString()!="")
				{
					model.Transport_Price_id=int.Parse(ds.Tables[0].Rows[0]["Transport_Price_id"].ToString());
				}
				model.Transport_Code=ds.Tables[0].Rows[0]["Transport_Code"].ToString();
				model.Transport_Mark=ds.Tables[0].Rows[0]["Transport_Mark"].ToString();
				if(ds.Tables[0].Rows[0]["EditMoney_Order"].ToString()!="")
				{
					model.EditMoney_Order=decimal.Parse(ds.Tables[0].Rows[0]["EditMoney_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EditMoney_Transport"].ToString()!="")
				{
					model.EditMoney_Transport=decimal.Parse(ds.Tables[0].Rows[0]["EditMoney_Transport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EditMoney_Discount"].ToString()!="")
				{
					model.EditMoney_Discount=decimal.Parse(ds.Tables[0].Rows[0]["EditMoney_Discount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsVerified"].ToString()!="")
				{
					model.IsVerified=int.Parse(ds.Tables[0].Rows[0]["IsVerified"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPaid"].ToString()!="")
				{
					model.IsPaid=int.Parse(ds.Tables[0].Rows[0]["IsPaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsShipped"].ToString()!="")
				{
					model.IsShipped=int.Parse(ds.Tables[0].Rows[0]["IsShipped"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsShipped_All"].ToString()!="")
				{
					model.IsShipped_All=int.Parse(ds.Tables[0].Rows[0]["IsShipped_All"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReceived"].ToString()!="")
				{
					model.IsReceived=int.Parse(ds.Tables[0].Rows[0]["IsReceived"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReceived_All"].ToString()!="")
				{
					model.IsReceived_All=int.Parse(ds.Tables[0].Rows[0]["IsReceived_All"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCompleted"].ToString()!="")
				{
					model.IsCompleted=int.Parse(ds.Tables[0].Rows[0]["IsCompleted"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsInvalid"].ToString()!="")
				{
					model.IsInvalid=int.Parse(ds.Tables[0].Rows[0]["IsInvalid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCreateCash"].ToString()!="")
				{
					model.IsCreateCash=int.Parse(ds.Tables[0].Rows[0]["IsCreateCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCreateNewOrder"].ToString()!="")
				{
					model.IsCreateNewOrder=int.Parse(ds.Tables[0].Rows[0]["IsCreateNewOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Verified"].ToString()!="")
				{
					model.Time_Verified=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Verified"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Paid"].ToString()!="")
				{
					model.Time_Paid=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Paid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Shipped"].ToString()!="")
				{
					model.Time_Shipped=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Shipped"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Received"].ToString()!="")
				{
					model.Time_Received=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Received"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Completed"].ToString()!="")
				{
					model.Time_Completed=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Completed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_CreateCash"].ToString()!="")
				{
					model.Time_CreateCash=DateTime.Parse(ds.Tables[0].Rows[0]["Time_CreateCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_CreateNewOrder"].ToString()!="")
				{
					model.Time_CreateNewOrder=DateTime.Parse(ds.Tables[0].Rows[0]["Time_CreateNewOrder"].ToString());
				}
				model.Remark_Admin=ds.Tables[0].Rows[0]["Remark_Admin"].ToString();
				model.BillType_Name=ds.Tables[0].Rows[0]["BillType_Name"].ToString();
				if(ds.Tables[0].Rows[0]["BillType_id"].ToString()!="")
				{
					model.BillType_id=int.Parse(ds.Tables[0].Rows[0]["BillType_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BillType_TaxRate"].ToString()!="")
				{
					model.BillType_TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["BillType_TaxRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_OrderType"].ToString()!="")
				{
					model.Type_id_OrderType=int.Parse(ds.Tables[0].Rows[0]["Type_id_OrderType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPrintExpress"].ToString()!="")
				{
					model.IsPrintExpress=int.Parse(ds.Tables[0].Rows[0]["IsPrintExpress"].ToString());
				}
				model.Promotion_Type_ids=ds.Tables[0].Rows[0]["Promotion_Type_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Mark"].ToString()!="")
				{
					model.Mark=int.Parse(ds.Tables[0].Rows[0]["Mark"].ToString());
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
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag"].ToString()!="")
				{
					model.Flag=int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Site_id"].ToString()!="")
				{
					model.Site_id=int.Parse(ds.Tables[0].Rows[0]["Site_id"].ToString());
				}
				model.BLNo=ds.Tables[0].Rows[0]["BLNo"].ToString();
				model.ContainerNo=ds.Tables[0].Rows[0]["ContainerNo"].ToString();
				model.SealNo=ds.Tables[0].Rows[0]["SealNo"].ToString();
				model.weixin_prepay_id=ds.Tables[0].Rows[0]["weixin_prepay_id"].ToString();
				if(ds.Tables[0].Rows[0]["IsSupplierCash"].ToString()!="")
				{
					model.IsSupplierCash=int.Parse(ds.Tables[0].Rows[0]["IsSupplierCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_OnlinepayFee"].ToString()!="")
				{
					model.Money_OnlinepayFee=decimal.Parse(ds.Tables[0].Rows[0]["Money_OnlinepayFee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Site_id_pay"].ToString()!="")
				{
					model.Site_id_pay=int.Parse(ds.Tables[0].Rows[0]["Site_id_pay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PickUp_id"].ToString()!="")
				{
					model.PickUp_id=int.Parse(ds.Tables[0].Rows[0]["PickUp_id"].ToString());
				}
				model.PickUp_Name=ds.Tables[0].Rows[0]["PickUp_Name"].ToString();
				if(ds.Tables[0].Rows[0]["PickUp_Date"].ToString()!="")
				{
					model.PickUp_Date=DateTime.Parse(ds.Tables[0].Rows[0]["PickUp_Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Refund_VAT"].ToString()!="")
				{
					model.Refund_VAT=decimal.Parse(ds.Tables[0].Rows[0]["Refund_VAT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Refund_Fee"].ToString()!="")
				{
					model.Refund_Fee=decimal.Parse(ds.Tables[0].Rows[0]["Refund_Fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Language_id"].ToString()!="")
				{
					model.Language_id=int.Parse(ds.Tables[0].Rows[0]["Language_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Delivery_id"].ToString()!="")
				{
					model.Supplier_Delivery_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Delivery_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRefund"].ToString()!="")
				{
					model.IsRefund=int.Parse(ds.Tables[0].Rows[0]["IsRefund"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Refund"].ToString()!="")
				{
					model.Time_Refund=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Refund"].ToString());
				}
				model.Promotion_Type_Name=ds.Tables[0].Rows[0]["Promotion_Type_Name"].ToString();
				model.User_NickName=ds.Tables[0].Rows[0]["User_NickName"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Paid"].ToString()!="")
				{
					model.Money_Paid=decimal.Parse(ds.Tables[0].Rows[0]["Money_Paid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReserve"].ToString()!="")
				{
					model.IsReserve=int.Parse(ds.Tables[0].Rows[0]["IsReserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_fanxianpay"].ToString()!="")
				{
					model.Money_fanxianpay=decimal.Parse(ds.Tables[0].Rows[0]["Money_fanxianpay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Tax"].ToString()!="")
				{
					model.Money_Tax=decimal.Parse(ds.Tables[0].Rows[0]["Money_Tax"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_Money"].ToString()!="")
				{
					model.DT_Money=decimal.Parse(ds.Tables[0].Rows[0]["DT_Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsDel"].ToString()!="")
				{
					model.IsDel=int.Parse(ds.Tables[0].Rows[0]["IsDel"].ToString());
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
		public Lebi_Order GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Order model=new Lebi_Order();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.T_Name=ds.Tables[0].Rows[0]["T_Name"].ToString();
				if(ds.Tables[0].Rows[0]["T_Area_id"].ToString()!="")
				{
					model.T_Area_id=int.Parse(ds.Tables[0].Rows[0]["T_Area_id"].ToString());
				}
				model.T_Address=ds.Tables[0].Rows[0]["T_Address"].ToString();
				model.T_Phone=ds.Tables[0].Rows[0]["T_Phone"].ToString();
				model.T_MobilePhone=ds.Tables[0].Rows[0]["T_MobilePhone"].ToString();
				model.T_Postalcode=ds.Tables[0].Rows[0]["T_Postalcode"].ToString();
				model.T_Email=ds.Tables[0].Rows[0]["T_Email"].ToString();
				model.Remark_User=ds.Tables[0].Rows[0]["Remark_User"].ToString();
				if(ds.Tables[0].Rows[0]["Pay_id"].ToString()!="")
				{
					model.Pay_id=int.Parse(ds.Tables[0].Rows[0]["Pay_id"].ToString());
				}
				model.Pay=ds.Tables[0].Rows[0]["Pay"].ToString();
				if(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString()!="")
				{
					model.OnlinePay_id=int.Parse(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString());
				}
				model.OnlinePay=ds.Tables[0].Rows[0]["OnlinePay"].ToString();
				model.OnlinePay_Code=ds.Tables[0].Rows[0]["OnlinePay_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Order"].ToString()!="")
				{
					model.Money_Order=decimal.Parse(ds.Tables[0].Rows[0]["Money_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Pay"].ToString()!="")
				{
					model.Money_Pay=decimal.Parse(ds.Tables[0].Rows[0]["Money_Pay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Product"].ToString()!="")
				{
					model.Money_Product=decimal.Parse(ds.Tables[0].Rows[0]["Money_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Transport"].ToString()!="")
				{
					model.Money_Transport=decimal.Parse(ds.Tables[0].Rows[0]["Money_Transport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Transport_Cut"].ToString()!="")
				{
					model.Money_Transport_Cut=decimal.Parse(ds.Tables[0].Rows[0]["Money_Transport_Cut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Bill"].ToString()!="")
				{
					model.Money_Bill=decimal.Parse(ds.Tables[0].Rows[0]["Money_Bill"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Market"].ToString()!="")
				{
					model.Money_Market=decimal.Parse(ds.Tables[0].Rows[0]["Money_Market"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Give"].ToString()!="")
				{
					model.Money_Give=decimal.Parse(ds.Tables[0].Rows[0]["Money_Give"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Cut"].ToString()!="")
				{
					model.Money_Cut=decimal.Parse(ds.Tables[0].Rows[0]["Money_Cut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_UserCut"].ToString()!="")
				{
					model.Money_UserCut=decimal.Parse(ds.Tables[0].Rows[0]["Money_UserCut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Cost"].ToString()!="")
				{
					model.Money_Cost=decimal.Parse(ds.Tables[0].Rows[0]["Money_Cost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Property"].ToString()!="")
				{
					model.Money_Property=decimal.Parse(ds.Tables[0].Rows[0]["Money_Property"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_UseCard311"].ToString()!="")
				{
					model.Money_UseCard311=decimal.Parse(ds.Tables[0].Rows[0]["Money_UseCard311"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_UseCard312"].ToString()!="")
				{
					model.Money_UseCard312=decimal.Parse(ds.Tables[0].Rows[0]["Money_UseCard312"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_fromorder"].ToString()!="")
				{
					model.Money_fromorder=decimal.Parse(ds.Tables[0].Rows[0]["Money_fromorder"].ToString());
				}
				model.UseCardCode311=ds.Tables[0].Rows[0]["UseCardCode311"].ToString();
				model.UseCardCode312=ds.Tables[0].Rows[0]["UseCardCode312"].ToString();
				if(ds.Tables[0].Rows[0]["Weight"].ToString()!="")
				{
					model.Weight=decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Volume"].ToString()!="")
				{
					model.Volume=decimal.Parse(ds.Tables[0].Rows[0]["Volume"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point"].ToString()!="")
				{
					model.Point=decimal.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Buy"].ToString()!="")
				{
					model.Point_Buy=decimal.Parse(ds.Tables[0].Rows[0]["Point_Buy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Product"].ToString()!="")
				{
					model.Point_Product=decimal.Parse(ds.Tables[0].Rows[0]["Point_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Free"].ToString()!="")
				{
					model.Point_Free=decimal.Parse(ds.Tables[0].Rows[0]["Point_Free"].ToString());
				}
				model.Transport_Name=ds.Tables[0].Rows[0]["Transport_Name"].ToString();
				if(ds.Tables[0].Rows[0]["Transport_id"].ToString()!="")
				{
					model.Transport_id=int.Parse(ds.Tables[0].Rows[0]["Transport_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Transport_Price_id"].ToString()!="")
				{
					model.Transport_Price_id=int.Parse(ds.Tables[0].Rows[0]["Transport_Price_id"].ToString());
				}
				model.Transport_Code=ds.Tables[0].Rows[0]["Transport_Code"].ToString();
				model.Transport_Mark=ds.Tables[0].Rows[0]["Transport_Mark"].ToString();
				if(ds.Tables[0].Rows[0]["EditMoney_Order"].ToString()!="")
				{
					model.EditMoney_Order=decimal.Parse(ds.Tables[0].Rows[0]["EditMoney_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EditMoney_Transport"].ToString()!="")
				{
					model.EditMoney_Transport=decimal.Parse(ds.Tables[0].Rows[0]["EditMoney_Transport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EditMoney_Discount"].ToString()!="")
				{
					model.EditMoney_Discount=decimal.Parse(ds.Tables[0].Rows[0]["EditMoney_Discount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsVerified"].ToString()!="")
				{
					model.IsVerified=int.Parse(ds.Tables[0].Rows[0]["IsVerified"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPaid"].ToString()!="")
				{
					model.IsPaid=int.Parse(ds.Tables[0].Rows[0]["IsPaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsShipped"].ToString()!="")
				{
					model.IsShipped=int.Parse(ds.Tables[0].Rows[0]["IsShipped"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsShipped_All"].ToString()!="")
				{
					model.IsShipped_All=int.Parse(ds.Tables[0].Rows[0]["IsShipped_All"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReceived"].ToString()!="")
				{
					model.IsReceived=int.Parse(ds.Tables[0].Rows[0]["IsReceived"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReceived_All"].ToString()!="")
				{
					model.IsReceived_All=int.Parse(ds.Tables[0].Rows[0]["IsReceived_All"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCompleted"].ToString()!="")
				{
					model.IsCompleted=int.Parse(ds.Tables[0].Rows[0]["IsCompleted"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsInvalid"].ToString()!="")
				{
					model.IsInvalid=int.Parse(ds.Tables[0].Rows[0]["IsInvalid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCreateCash"].ToString()!="")
				{
					model.IsCreateCash=int.Parse(ds.Tables[0].Rows[0]["IsCreateCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCreateNewOrder"].ToString()!="")
				{
					model.IsCreateNewOrder=int.Parse(ds.Tables[0].Rows[0]["IsCreateNewOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Verified"].ToString()!="")
				{
					model.Time_Verified=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Verified"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Paid"].ToString()!="")
				{
					model.Time_Paid=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Paid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Shipped"].ToString()!="")
				{
					model.Time_Shipped=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Shipped"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Received"].ToString()!="")
				{
					model.Time_Received=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Received"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Completed"].ToString()!="")
				{
					model.Time_Completed=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Completed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_CreateCash"].ToString()!="")
				{
					model.Time_CreateCash=DateTime.Parse(ds.Tables[0].Rows[0]["Time_CreateCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_CreateNewOrder"].ToString()!="")
				{
					model.Time_CreateNewOrder=DateTime.Parse(ds.Tables[0].Rows[0]["Time_CreateNewOrder"].ToString());
				}
				model.Remark_Admin=ds.Tables[0].Rows[0]["Remark_Admin"].ToString();
				model.BillType_Name=ds.Tables[0].Rows[0]["BillType_Name"].ToString();
				if(ds.Tables[0].Rows[0]["BillType_id"].ToString()!="")
				{
					model.BillType_id=int.Parse(ds.Tables[0].Rows[0]["BillType_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BillType_TaxRate"].ToString()!="")
				{
					model.BillType_TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["BillType_TaxRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_OrderType"].ToString()!="")
				{
					model.Type_id_OrderType=int.Parse(ds.Tables[0].Rows[0]["Type_id_OrderType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPrintExpress"].ToString()!="")
				{
					model.IsPrintExpress=int.Parse(ds.Tables[0].Rows[0]["IsPrintExpress"].ToString());
				}
				model.Promotion_Type_ids=ds.Tables[0].Rows[0]["Promotion_Type_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Mark"].ToString()!="")
				{
					model.Mark=int.Parse(ds.Tables[0].Rows[0]["Mark"].ToString());
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
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag"].ToString()!="")
				{
					model.Flag=int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Site_id"].ToString()!="")
				{
					model.Site_id=int.Parse(ds.Tables[0].Rows[0]["Site_id"].ToString());
				}
				model.BLNo=ds.Tables[0].Rows[0]["BLNo"].ToString();
				model.ContainerNo=ds.Tables[0].Rows[0]["ContainerNo"].ToString();
				model.SealNo=ds.Tables[0].Rows[0]["SealNo"].ToString();
				model.weixin_prepay_id=ds.Tables[0].Rows[0]["weixin_prepay_id"].ToString();
				if(ds.Tables[0].Rows[0]["IsSupplierCash"].ToString()!="")
				{
					model.IsSupplierCash=int.Parse(ds.Tables[0].Rows[0]["IsSupplierCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_OnlinepayFee"].ToString()!="")
				{
					model.Money_OnlinepayFee=decimal.Parse(ds.Tables[0].Rows[0]["Money_OnlinepayFee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Site_id_pay"].ToString()!="")
				{
					model.Site_id_pay=int.Parse(ds.Tables[0].Rows[0]["Site_id_pay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PickUp_id"].ToString()!="")
				{
					model.PickUp_id=int.Parse(ds.Tables[0].Rows[0]["PickUp_id"].ToString());
				}
				model.PickUp_Name=ds.Tables[0].Rows[0]["PickUp_Name"].ToString();
				if(ds.Tables[0].Rows[0]["PickUp_Date"].ToString()!="")
				{
					model.PickUp_Date=DateTime.Parse(ds.Tables[0].Rows[0]["PickUp_Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Refund_VAT"].ToString()!="")
				{
					model.Refund_VAT=decimal.Parse(ds.Tables[0].Rows[0]["Refund_VAT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Refund_Fee"].ToString()!="")
				{
					model.Refund_Fee=decimal.Parse(ds.Tables[0].Rows[0]["Refund_Fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Language_id"].ToString()!="")
				{
					model.Language_id=int.Parse(ds.Tables[0].Rows[0]["Language_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Delivery_id"].ToString()!="")
				{
					model.Supplier_Delivery_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Delivery_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRefund"].ToString()!="")
				{
					model.IsRefund=int.Parse(ds.Tables[0].Rows[0]["IsRefund"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Refund"].ToString()!="")
				{
					model.Time_Refund=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Refund"].ToString());
				}
				model.Promotion_Type_Name=ds.Tables[0].Rows[0]["Promotion_Type_Name"].ToString();
				model.User_NickName=ds.Tables[0].Rows[0]["User_NickName"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Paid"].ToString()!="")
				{
					model.Money_Paid=decimal.Parse(ds.Tables[0].Rows[0]["Money_Paid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReserve"].ToString()!="")
				{
					model.IsReserve=int.Parse(ds.Tables[0].Rows[0]["IsReserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_fanxianpay"].ToString()!="")
				{
					model.Money_fanxianpay=decimal.Parse(ds.Tables[0].Rows[0]["Money_fanxianpay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Tax"].ToString()!="")
				{
					model.Money_Tax=decimal.Parse(ds.Tables[0].Rows[0]["Money_Tax"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_Money"].ToString()!="")
				{
					model.DT_Money=decimal.Parse(ds.Tables[0].Rows[0]["DT_Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsDel"].ToString()!="")
				{
					model.IsDel=int.Parse(ds.Tables[0].Rows[0]["IsDel"].ToString());
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
		public Lebi_Order GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Order] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Order model=new Lebi_Order();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.T_Name=ds.Tables[0].Rows[0]["T_Name"].ToString();
				if(ds.Tables[0].Rows[0]["T_Area_id"].ToString()!="")
				{
					model.T_Area_id=int.Parse(ds.Tables[0].Rows[0]["T_Area_id"].ToString());
				}
				model.T_Address=ds.Tables[0].Rows[0]["T_Address"].ToString();
				model.T_Phone=ds.Tables[0].Rows[0]["T_Phone"].ToString();
				model.T_MobilePhone=ds.Tables[0].Rows[0]["T_MobilePhone"].ToString();
				model.T_Postalcode=ds.Tables[0].Rows[0]["T_Postalcode"].ToString();
				model.T_Email=ds.Tables[0].Rows[0]["T_Email"].ToString();
				model.Remark_User=ds.Tables[0].Rows[0]["Remark_User"].ToString();
				if(ds.Tables[0].Rows[0]["Pay_id"].ToString()!="")
				{
					model.Pay_id=int.Parse(ds.Tables[0].Rows[0]["Pay_id"].ToString());
				}
				model.Pay=ds.Tables[0].Rows[0]["Pay"].ToString();
				if(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString()!="")
				{
					model.OnlinePay_id=int.Parse(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString());
				}
				model.OnlinePay=ds.Tables[0].Rows[0]["OnlinePay"].ToString();
				model.OnlinePay_Code=ds.Tables[0].Rows[0]["OnlinePay_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Order"].ToString()!="")
				{
					model.Money_Order=decimal.Parse(ds.Tables[0].Rows[0]["Money_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Pay"].ToString()!="")
				{
					model.Money_Pay=decimal.Parse(ds.Tables[0].Rows[0]["Money_Pay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Product"].ToString()!="")
				{
					model.Money_Product=decimal.Parse(ds.Tables[0].Rows[0]["Money_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Transport"].ToString()!="")
				{
					model.Money_Transport=decimal.Parse(ds.Tables[0].Rows[0]["Money_Transport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Transport_Cut"].ToString()!="")
				{
					model.Money_Transport_Cut=decimal.Parse(ds.Tables[0].Rows[0]["Money_Transport_Cut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Bill"].ToString()!="")
				{
					model.Money_Bill=decimal.Parse(ds.Tables[0].Rows[0]["Money_Bill"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Market"].ToString()!="")
				{
					model.Money_Market=decimal.Parse(ds.Tables[0].Rows[0]["Money_Market"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Give"].ToString()!="")
				{
					model.Money_Give=decimal.Parse(ds.Tables[0].Rows[0]["Money_Give"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Cut"].ToString()!="")
				{
					model.Money_Cut=decimal.Parse(ds.Tables[0].Rows[0]["Money_Cut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_UserCut"].ToString()!="")
				{
					model.Money_UserCut=decimal.Parse(ds.Tables[0].Rows[0]["Money_UserCut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Cost"].ToString()!="")
				{
					model.Money_Cost=decimal.Parse(ds.Tables[0].Rows[0]["Money_Cost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Property"].ToString()!="")
				{
					model.Money_Property=decimal.Parse(ds.Tables[0].Rows[0]["Money_Property"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_UseCard311"].ToString()!="")
				{
					model.Money_UseCard311=decimal.Parse(ds.Tables[0].Rows[0]["Money_UseCard311"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_UseCard312"].ToString()!="")
				{
					model.Money_UseCard312=decimal.Parse(ds.Tables[0].Rows[0]["Money_UseCard312"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_fromorder"].ToString()!="")
				{
					model.Money_fromorder=decimal.Parse(ds.Tables[0].Rows[0]["Money_fromorder"].ToString());
				}
				model.UseCardCode311=ds.Tables[0].Rows[0]["UseCardCode311"].ToString();
				model.UseCardCode312=ds.Tables[0].Rows[0]["UseCardCode312"].ToString();
				if(ds.Tables[0].Rows[0]["Weight"].ToString()!="")
				{
					model.Weight=decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Volume"].ToString()!="")
				{
					model.Volume=decimal.Parse(ds.Tables[0].Rows[0]["Volume"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point"].ToString()!="")
				{
					model.Point=decimal.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Buy"].ToString()!="")
				{
					model.Point_Buy=decimal.Parse(ds.Tables[0].Rows[0]["Point_Buy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Product"].ToString()!="")
				{
					model.Point_Product=decimal.Parse(ds.Tables[0].Rows[0]["Point_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Free"].ToString()!="")
				{
					model.Point_Free=decimal.Parse(ds.Tables[0].Rows[0]["Point_Free"].ToString());
				}
				model.Transport_Name=ds.Tables[0].Rows[0]["Transport_Name"].ToString();
				if(ds.Tables[0].Rows[0]["Transport_id"].ToString()!="")
				{
					model.Transport_id=int.Parse(ds.Tables[0].Rows[0]["Transport_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Transport_Price_id"].ToString()!="")
				{
					model.Transport_Price_id=int.Parse(ds.Tables[0].Rows[0]["Transport_Price_id"].ToString());
				}
				model.Transport_Code=ds.Tables[0].Rows[0]["Transport_Code"].ToString();
				model.Transport_Mark=ds.Tables[0].Rows[0]["Transport_Mark"].ToString();
				if(ds.Tables[0].Rows[0]["EditMoney_Order"].ToString()!="")
				{
					model.EditMoney_Order=decimal.Parse(ds.Tables[0].Rows[0]["EditMoney_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EditMoney_Transport"].ToString()!="")
				{
					model.EditMoney_Transport=decimal.Parse(ds.Tables[0].Rows[0]["EditMoney_Transport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EditMoney_Discount"].ToString()!="")
				{
					model.EditMoney_Discount=decimal.Parse(ds.Tables[0].Rows[0]["EditMoney_Discount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsVerified"].ToString()!="")
				{
					model.IsVerified=int.Parse(ds.Tables[0].Rows[0]["IsVerified"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPaid"].ToString()!="")
				{
					model.IsPaid=int.Parse(ds.Tables[0].Rows[0]["IsPaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsShipped"].ToString()!="")
				{
					model.IsShipped=int.Parse(ds.Tables[0].Rows[0]["IsShipped"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsShipped_All"].ToString()!="")
				{
					model.IsShipped_All=int.Parse(ds.Tables[0].Rows[0]["IsShipped_All"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReceived"].ToString()!="")
				{
					model.IsReceived=int.Parse(ds.Tables[0].Rows[0]["IsReceived"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReceived_All"].ToString()!="")
				{
					model.IsReceived_All=int.Parse(ds.Tables[0].Rows[0]["IsReceived_All"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCompleted"].ToString()!="")
				{
					model.IsCompleted=int.Parse(ds.Tables[0].Rows[0]["IsCompleted"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsInvalid"].ToString()!="")
				{
					model.IsInvalid=int.Parse(ds.Tables[0].Rows[0]["IsInvalid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCreateCash"].ToString()!="")
				{
					model.IsCreateCash=int.Parse(ds.Tables[0].Rows[0]["IsCreateCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCreateNewOrder"].ToString()!="")
				{
					model.IsCreateNewOrder=int.Parse(ds.Tables[0].Rows[0]["IsCreateNewOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Verified"].ToString()!="")
				{
					model.Time_Verified=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Verified"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Paid"].ToString()!="")
				{
					model.Time_Paid=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Paid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Shipped"].ToString()!="")
				{
					model.Time_Shipped=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Shipped"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Received"].ToString()!="")
				{
					model.Time_Received=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Received"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Completed"].ToString()!="")
				{
					model.Time_Completed=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Completed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_CreateCash"].ToString()!="")
				{
					model.Time_CreateCash=DateTime.Parse(ds.Tables[0].Rows[0]["Time_CreateCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_CreateNewOrder"].ToString()!="")
				{
					model.Time_CreateNewOrder=DateTime.Parse(ds.Tables[0].Rows[0]["Time_CreateNewOrder"].ToString());
				}
				model.Remark_Admin=ds.Tables[0].Rows[0]["Remark_Admin"].ToString();
				model.BillType_Name=ds.Tables[0].Rows[0]["BillType_Name"].ToString();
				if(ds.Tables[0].Rows[0]["BillType_id"].ToString()!="")
				{
					model.BillType_id=int.Parse(ds.Tables[0].Rows[0]["BillType_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BillType_TaxRate"].ToString()!="")
				{
					model.BillType_TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["BillType_TaxRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_OrderType"].ToString()!="")
				{
					model.Type_id_OrderType=int.Parse(ds.Tables[0].Rows[0]["Type_id_OrderType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPrintExpress"].ToString()!="")
				{
					model.IsPrintExpress=int.Parse(ds.Tables[0].Rows[0]["IsPrintExpress"].ToString());
				}
				model.Promotion_Type_ids=ds.Tables[0].Rows[0]["Promotion_Type_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Mark"].ToString()!="")
				{
					model.Mark=int.Parse(ds.Tables[0].Rows[0]["Mark"].ToString());
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
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag"].ToString()!="")
				{
					model.Flag=int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Site_id"].ToString()!="")
				{
					model.Site_id=int.Parse(ds.Tables[0].Rows[0]["Site_id"].ToString());
				}
				model.BLNo=ds.Tables[0].Rows[0]["BLNo"].ToString();
				model.ContainerNo=ds.Tables[0].Rows[0]["ContainerNo"].ToString();
				model.SealNo=ds.Tables[0].Rows[0]["SealNo"].ToString();
				model.weixin_prepay_id=ds.Tables[0].Rows[0]["weixin_prepay_id"].ToString();
				if(ds.Tables[0].Rows[0]["IsSupplierCash"].ToString()!="")
				{
					model.IsSupplierCash=int.Parse(ds.Tables[0].Rows[0]["IsSupplierCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_OnlinepayFee"].ToString()!="")
				{
					model.Money_OnlinepayFee=decimal.Parse(ds.Tables[0].Rows[0]["Money_OnlinepayFee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Site_id_pay"].ToString()!="")
				{
					model.Site_id_pay=int.Parse(ds.Tables[0].Rows[0]["Site_id_pay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PickUp_id"].ToString()!="")
				{
					model.PickUp_id=int.Parse(ds.Tables[0].Rows[0]["PickUp_id"].ToString());
				}
				model.PickUp_Name=ds.Tables[0].Rows[0]["PickUp_Name"].ToString();
				if(ds.Tables[0].Rows[0]["PickUp_Date"].ToString()!="")
				{
					model.PickUp_Date=DateTime.Parse(ds.Tables[0].Rows[0]["PickUp_Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Refund_VAT"].ToString()!="")
				{
					model.Refund_VAT=decimal.Parse(ds.Tables[0].Rows[0]["Refund_VAT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Refund_Fee"].ToString()!="")
				{
					model.Refund_Fee=decimal.Parse(ds.Tables[0].Rows[0]["Refund_Fee"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Language_id"].ToString()!="")
				{
					model.Language_id=int.Parse(ds.Tables[0].Rows[0]["Language_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Delivery_id"].ToString()!="")
				{
					model.Supplier_Delivery_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Delivery_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRefund"].ToString()!="")
				{
					model.IsRefund=int.Parse(ds.Tables[0].Rows[0]["IsRefund"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Refund"].ToString()!="")
				{
					model.Time_Refund=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Refund"].ToString());
				}
				model.Promotion_Type_Name=ds.Tables[0].Rows[0]["Promotion_Type_Name"].ToString();
				model.User_NickName=ds.Tables[0].Rows[0]["User_NickName"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Paid"].ToString()!="")
				{
					model.Money_Paid=decimal.Parse(ds.Tables[0].Rows[0]["Money_Paid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReserve"].ToString()!="")
				{
					model.IsReserve=int.Parse(ds.Tables[0].Rows[0]["IsReserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_fanxianpay"].ToString()!="")
				{
					model.Money_fanxianpay=decimal.Parse(ds.Tables[0].Rows[0]["Money_fanxianpay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Tax"].ToString()!="")
				{
					model.Money_Tax=decimal.Parse(ds.Tables[0].Rows[0]["Money_Tax"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_Money"].ToString()!="")
				{
					model.DT_Money=decimal.Parse(ds.Tables[0].Rows[0]["DT_Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsDel"].ToString()!="")
				{
					model.IsDel=int.Parse(ds.Tables[0].Rows[0]["IsDel"].ToString());
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
		public List<Lebi_Order> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Order]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Order> list = new List<Lebi_Order>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Order> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Order]";
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
			List<Lebi_Order> list = new List<Lebi_Order>();
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
		public List<Lebi_Order> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Order] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Order> list = new List<Lebi_Order>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Order> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Order]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Order> list = new List<Lebi_Order>();
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
		public Lebi_Order BindForm(Lebi_Order model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["T_Name"] != null)
				model.T_Name=Shop.Tools.RequestTool.RequestString("T_Name");
			if (HttpContext.Current.Request["T_Area_id"] != null)
				model.T_Area_id=Shop.Tools.RequestTool.RequestInt("T_Area_id",0);
			if (HttpContext.Current.Request["T_Address"] != null)
				model.T_Address=Shop.Tools.RequestTool.RequestString("T_Address");
			if (HttpContext.Current.Request["T_Phone"] != null)
				model.T_Phone=Shop.Tools.RequestTool.RequestString("T_Phone");
			if (HttpContext.Current.Request["T_MobilePhone"] != null)
				model.T_MobilePhone=Shop.Tools.RequestTool.RequestString("T_MobilePhone");
			if (HttpContext.Current.Request["T_Postalcode"] != null)
				model.T_Postalcode=Shop.Tools.RequestTool.RequestString("T_Postalcode");
			if (HttpContext.Current.Request["T_Email"] != null)
				model.T_Email=Shop.Tools.RequestTool.RequestString("T_Email");
			if (HttpContext.Current.Request["Remark_User"] != null)
				model.Remark_User=Shop.Tools.RequestTool.RequestString("Remark_User");
			if (HttpContext.Current.Request["Pay_id"] != null)
				model.Pay_id=Shop.Tools.RequestTool.RequestInt("Pay_id",0);
			if (HttpContext.Current.Request["Pay"] != null)
				model.Pay=Shop.Tools.RequestTool.RequestString("Pay");
			if (HttpContext.Current.Request["OnlinePay_id"] != null)
				model.OnlinePay_id=Shop.Tools.RequestTool.RequestInt("OnlinePay_id",0);
			if (HttpContext.Current.Request["OnlinePay"] != null)
				model.OnlinePay=Shop.Tools.RequestTool.RequestString("OnlinePay");
			if (HttpContext.Current.Request["OnlinePay_Code"] != null)
				model.OnlinePay_Code=Shop.Tools.RequestTool.RequestString("OnlinePay_Code");
			if (HttpContext.Current.Request["Money_Order"] != null)
				model.Money_Order=Shop.Tools.RequestTool.RequestDecimal("Money_Order",0);
			if (HttpContext.Current.Request["Money_Pay"] != null)
				model.Money_Pay=Shop.Tools.RequestTool.RequestDecimal("Money_Pay",0);
			if (HttpContext.Current.Request["Money_Product"] != null)
				model.Money_Product=Shop.Tools.RequestTool.RequestDecimal("Money_Product",0);
			if (HttpContext.Current.Request["Money_Transport"] != null)
				model.Money_Transport=Shop.Tools.RequestTool.RequestDecimal("Money_Transport",0);
			if (HttpContext.Current.Request["Money_Transport_Cut"] != null)
				model.Money_Transport_Cut=Shop.Tools.RequestTool.RequestDecimal("Money_Transport_Cut",0);
			if (HttpContext.Current.Request["Money_Bill"] != null)
				model.Money_Bill=Shop.Tools.RequestTool.RequestDecimal("Money_Bill",0);
			if (HttpContext.Current.Request["Money_Market"] != null)
				model.Money_Market=Shop.Tools.RequestTool.RequestDecimal("Money_Market",0);
			if (HttpContext.Current.Request["Money_Give"] != null)
				model.Money_Give=Shop.Tools.RequestTool.RequestDecimal("Money_Give",0);
			if (HttpContext.Current.Request["Money_Cut"] != null)
				model.Money_Cut=Shop.Tools.RequestTool.RequestDecimal("Money_Cut",0);
			if (HttpContext.Current.Request["Money_UserCut"] != null)
				model.Money_UserCut=Shop.Tools.RequestTool.RequestDecimal("Money_UserCut",0);
			if (HttpContext.Current.Request["Money_Cost"] != null)
				model.Money_Cost=Shop.Tools.RequestTool.RequestDecimal("Money_Cost",0);
			if (HttpContext.Current.Request["Money_Property"] != null)
				model.Money_Property=Shop.Tools.RequestTool.RequestDecimal("Money_Property",0);
			if (HttpContext.Current.Request["Money_UseCard311"] != null)
				model.Money_UseCard311=Shop.Tools.RequestTool.RequestDecimal("Money_UseCard311",0);
			if (HttpContext.Current.Request["Money_UseCard312"] != null)
				model.Money_UseCard312=Shop.Tools.RequestTool.RequestDecimal("Money_UseCard312",0);
			if (HttpContext.Current.Request["Money_fromorder"] != null)
				model.Money_fromorder=Shop.Tools.RequestTool.RequestDecimal("Money_fromorder",0);
			if (HttpContext.Current.Request["UseCardCode311"] != null)
				model.UseCardCode311=Shop.Tools.RequestTool.RequestString("UseCardCode311");
			if (HttpContext.Current.Request["UseCardCode312"] != null)
				model.UseCardCode312=Shop.Tools.RequestTool.RequestString("UseCardCode312");
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["Volume"] != null)
				model.Volume=Shop.Tools.RequestTool.RequestDecimal("Volume",0);
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["Point_Buy"] != null)
				model.Point_Buy=Shop.Tools.RequestTool.RequestDecimal("Point_Buy",0);
			if (HttpContext.Current.Request["Point_Product"] != null)
				model.Point_Product=Shop.Tools.RequestTool.RequestDecimal("Point_Product",0);
			if (HttpContext.Current.Request["Point_Free"] != null)
				model.Point_Free=Shop.Tools.RequestTool.RequestDecimal("Point_Free",0);
			if (HttpContext.Current.Request["Transport_Name"] != null)
				model.Transport_Name=Shop.Tools.RequestTool.RequestString("Transport_Name");
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Transport_Price_id"] != null)
				model.Transport_Price_id=Shop.Tools.RequestTool.RequestInt("Transport_Price_id",0);
			if (HttpContext.Current.Request["Transport_Code"] != null)
				model.Transport_Code=Shop.Tools.RequestTool.RequestString("Transport_Code");
			if (HttpContext.Current.Request["Transport_Mark"] != null)
				model.Transport_Mark=Shop.Tools.RequestTool.RequestString("Transport_Mark");
			if (HttpContext.Current.Request["EditMoney_Order"] != null)
				model.EditMoney_Order=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Order",0);
			if (HttpContext.Current.Request["EditMoney_Transport"] != null)
				model.EditMoney_Transport=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Transport",0);
			if (HttpContext.Current.Request["EditMoney_Discount"] != null)
				model.EditMoney_Discount=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Discount",0);
			if (HttpContext.Current.Request["IsVerified"] != null)
				model.IsVerified=Shop.Tools.RequestTool.RequestInt("IsVerified",0);
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["IsShipped"] != null)
				model.IsShipped=Shop.Tools.RequestTool.RequestInt("IsShipped",0);
			if (HttpContext.Current.Request["IsShipped_All"] != null)
				model.IsShipped_All=Shop.Tools.RequestTool.RequestInt("IsShipped_All",0);
			if (HttpContext.Current.Request["IsReceived"] != null)
				model.IsReceived=Shop.Tools.RequestTool.RequestInt("IsReceived",0);
			if (HttpContext.Current.Request["IsReceived_All"] != null)
				model.IsReceived_All=Shop.Tools.RequestTool.RequestInt("IsReceived_All",0);
			if (HttpContext.Current.Request["IsCompleted"] != null)
				model.IsCompleted=Shop.Tools.RequestTool.RequestInt("IsCompleted",0);
			if (HttpContext.Current.Request["IsInvalid"] != null)
				model.IsInvalid=Shop.Tools.RequestTool.RequestInt("IsInvalid",0);
			if (HttpContext.Current.Request["IsCreateCash"] != null)
				model.IsCreateCash=Shop.Tools.RequestTool.RequestInt("IsCreateCash",0);
			if (HttpContext.Current.Request["IsCreateNewOrder"] != null)
				model.IsCreateNewOrder=Shop.Tools.RequestTool.RequestInt("IsCreateNewOrder",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Verified"] != null)
				model.Time_Verified=Shop.Tools.RequestTool.RequestTime("Time_Verified", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Shipped"] != null)
				model.Time_Shipped=Shop.Tools.RequestTool.RequestTime("Time_Shipped", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Received"] != null)
				model.Time_Received=Shop.Tools.RequestTool.RequestTime("Time_Received", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Completed"] != null)
				model.Time_Completed=Shop.Tools.RequestTool.RequestTime("Time_Completed", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_CreateCash"] != null)
				model.Time_CreateCash=Shop.Tools.RequestTool.RequestTime("Time_CreateCash", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_CreateNewOrder"] != null)
				model.Time_CreateNewOrder=Shop.Tools.RequestTool.RequestTime("Time_CreateNewOrder", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark_Admin"] != null)
				model.Remark_Admin=Shop.Tools.RequestTool.RequestString("Remark_Admin");
			if (HttpContext.Current.Request["BillType_Name"] != null)
				model.BillType_Name=Shop.Tools.RequestTool.RequestString("BillType_Name");
			if (HttpContext.Current.Request["BillType_id"] != null)
				model.BillType_id=Shop.Tools.RequestTool.RequestInt("BillType_id",0);
			if (HttpContext.Current.Request["BillType_TaxRate"] != null)
				model.BillType_TaxRate=Shop.Tools.RequestTool.RequestDecimal("BillType_TaxRate",0);
			if (HttpContext.Current.Request["Type_id_OrderType"] != null)
				model.Type_id_OrderType=Shop.Tools.RequestTool.RequestInt("Type_id_OrderType",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["IsPrintExpress"] != null)
				model.IsPrintExpress=Shop.Tools.RequestTool.RequestInt("IsPrintExpress",0);
			if (HttpContext.Current.Request["Promotion_Type_ids"] != null)
				model.Promotion_Type_ids=Shop.Tools.RequestTool.RequestString("Promotion_Type_ids");
			if (HttpContext.Current.Request["Mark"] != null)
				model.Mark=Shop.Tools.RequestTool.RequestInt("Mark",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestString("Currency_Code");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestString("Currency_Msige");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Flag"] != null)
				model.Flag=Shop.Tools.RequestTool.RequestInt("Flag",0);
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["BLNo"] != null)
				model.BLNo=Shop.Tools.RequestTool.RequestString("BLNo");
			if (HttpContext.Current.Request["ContainerNo"] != null)
				model.ContainerNo=Shop.Tools.RequestTool.RequestString("ContainerNo");
			if (HttpContext.Current.Request["SealNo"] != null)
				model.SealNo=Shop.Tools.RequestTool.RequestString("SealNo");
			if (HttpContext.Current.Request["weixin_prepay_id"] != null)
				model.weixin_prepay_id=Shop.Tools.RequestTool.RequestString("weixin_prepay_id");
			if (HttpContext.Current.Request["IsSupplierCash"] != null)
				model.IsSupplierCash=Shop.Tools.RequestTool.RequestInt("IsSupplierCash",0);
			if (HttpContext.Current.Request["Money_OnlinepayFee"] != null)
				model.Money_OnlinepayFee=Shop.Tools.RequestTool.RequestDecimal("Money_OnlinepayFee",0);
			if (HttpContext.Current.Request["Site_id_pay"] != null)
				model.Site_id_pay=Shop.Tools.RequestTool.RequestInt("Site_id_pay",0);
			if (HttpContext.Current.Request["PickUp_id"] != null)
				model.PickUp_id=Shop.Tools.RequestTool.RequestInt("PickUp_id",0);
			if (HttpContext.Current.Request["PickUp_Name"] != null)
				model.PickUp_Name=Shop.Tools.RequestTool.RequestString("PickUp_Name");
			if (HttpContext.Current.Request["PickUp_Date"] != null)
				model.PickUp_Date=Shop.Tools.RequestTool.RequestTime("PickUp_Date", System.DateTime.Now);
			if (HttpContext.Current.Request["Refund_VAT"] != null)
				model.Refund_VAT=Shop.Tools.RequestTool.RequestDecimal("Refund_VAT",0);
			if (HttpContext.Current.Request["Refund_Fee"] != null)
				model.Refund_Fee=Shop.Tools.RequestTool.RequestDecimal("Refund_Fee",0);
			if (HttpContext.Current.Request["Language_id"] != null)
				model.Language_id=Shop.Tools.RequestTool.RequestInt("Language_id",0);
			if (HttpContext.Current.Request["Supplier_Delivery_id"] != null)
				model.Supplier_Delivery_id=Shop.Tools.RequestTool.RequestInt("Supplier_Delivery_id",0);
			if (HttpContext.Current.Request["IsRefund"] != null)
				model.IsRefund=Shop.Tools.RequestTool.RequestInt("IsRefund",0);
			if (HttpContext.Current.Request["Time_Refund"] != null)
				model.Time_Refund=Shop.Tools.RequestTool.RequestTime("Time_Refund", System.DateTime.Now);
			if (HttpContext.Current.Request["Promotion_Type_Name"] != null)
				model.Promotion_Type_Name=Shop.Tools.RequestTool.RequestString("Promotion_Type_Name");
			if (HttpContext.Current.Request["User_NickName"] != null)
				model.User_NickName=Shop.Tools.RequestTool.RequestString("User_NickName");
			if (HttpContext.Current.Request["Money_Paid"] != null)
				model.Money_Paid=Shop.Tools.RequestTool.RequestDecimal("Money_Paid",0);
			if (HttpContext.Current.Request["IsReserve"] != null)
				model.IsReserve=Shop.Tools.RequestTool.RequestInt("IsReserve",0);
			if (HttpContext.Current.Request["Money_fanxianpay"] != null)
				model.Money_fanxianpay=Shop.Tools.RequestTool.RequestDecimal("Money_fanxianpay",0);
			if (HttpContext.Current.Request["Money_Tax"] != null)
				model.Money_Tax=Shop.Tools.RequestTool.RequestDecimal("Money_Tax",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["DT_Money"] != null)
				model.DT_Money=Shop.Tools.RequestTool.RequestDecimal("DT_Money",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Order SafeBindForm(Lebi_Order model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["T_Name"] != null)
				model.T_Name=Shop.Tools.RequestTool.RequestSafeString("T_Name");
			if (HttpContext.Current.Request["T_Area_id"] != null)
				model.T_Area_id=Shop.Tools.RequestTool.RequestInt("T_Area_id",0);
			if (HttpContext.Current.Request["T_Address"] != null)
				model.T_Address=Shop.Tools.RequestTool.RequestSafeString("T_Address");
			if (HttpContext.Current.Request["T_Phone"] != null)
				model.T_Phone=Shop.Tools.RequestTool.RequestSafeString("T_Phone");
			if (HttpContext.Current.Request["T_MobilePhone"] != null)
				model.T_MobilePhone=Shop.Tools.RequestTool.RequestSafeString("T_MobilePhone");
			if (HttpContext.Current.Request["T_Postalcode"] != null)
				model.T_Postalcode=Shop.Tools.RequestTool.RequestSafeString("T_Postalcode");
			if (HttpContext.Current.Request["T_Email"] != null)
				model.T_Email=Shop.Tools.RequestTool.RequestSafeString("T_Email");
			if (HttpContext.Current.Request["Remark_User"] != null)
				model.Remark_User=Shop.Tools.RequestTool.RequestSafeString("Remark_User");
			if (HttpContext.Current.Request["Pay_id"] != null)
				model.Pay_id=Shop.Tools.RequestTool.RequestInt("Pay_id",0);
			if (HttpContext.Current.Request["Pay"] != null)
				model.Pay=Shop.Tools.RequestTool.RequestSafeString("Pay");
			if (HttpContext.Current.Request["OnlinePay_id"] != null)
				model.OnlinePay_id=Shop.Tools.RequestTool.RequestInt("OnlinePay_id",0);
			if (HttpContext.Current.Request["OnlinePay"] != null)
				model.OnlinePay=Shop.Tools.RequestTool.RequestSafeString("OnlinePay");
			if (HttpContext.Current.Request["OnlinePay_Code"] != null)
				model.OnlinePay_Code=Shop.Tools.RequestTool.RequestSafeString("OnlinePay_Code");
			if (HttpContext.Current.Request["Money_Order"] != null)
				model.Money_Order=Shop.Tools.RequestTool.RequestDecimal("Money_Order",0);
			if (HttpContext.Current.Request["Money_Pay"] != null)
				model.Money_Pay=Shop.Tools.RequestTool.RequestDecimal("Money_Pay",0);
			if (HttpContext.Current.Request["Money_Product"] != null)
				model.Money_Product=Shop.Tools.RequestTool.RequestDecimal("Money_Product",0);
			if (HttpContext.Current.Request["Money_Transport"] != null)
				model.Money_Transport=Shop.Tools.RequestTool.RequestDecimal("Money_Transport",0);
			if (HttpContext.Current.Request["Money_Transport_Cut"] != null)
				model.Money_Transport_Cut=Shop.Tools.RequestTool.RequestDecimal("Money_Transport_Cut",0);
			if (HttpContext.Current.Request["Money_Bill"] != null)
				model.Money_Bill=Shop.Tools.RequestTool.RequestDecimal("Money_Bill",0);
			if (HttpContext.Current.Request["Money_Market"] != null)
				model.Money_Market=Shop.Tools.RequestTool.RequestDecimal("Money_Market",0);
			if (HttpContext.Current.Request["Money_Give"] != null)
				model.Money_Give=Shop.Tools.RequestTool.RequestDecimal("Money_Give",0);
			if (HttpContext.Current.Request["Money_Cut"] != null)
				model.Money_Cut=Shop.Tools.RequestTool.RequestDecimal("Money_Cut",0);
			if (HttpContext.Current.Request["Money_UserCut"] != null)
				model.Money_UserCut=Shop.Tools.RequestTool.RequestDecimal("Money_UserCut",0);
			if (HttpContext.Current.Request["Money_Cost"] != null)
				model.Money_Cost=Shop.Tools.RequestTool.RequestDecimal("Money_Cost",0);
			if (HttpContext.Current.Request["Money_Property"] != null)
				model.Money_Property=Shop.Tools.RequestTool.RequestDecimal("Money_Property",0);
			if (HttpContext.Current.Request["Money_UseCard311"] != null)
				model.Money_UseCard311=Shop.Tools.RequestTool.RequestDecimal("Money_UseCard311",0);
			if (HttpContext.Current.Request["Money_UseCard312"] != null)
				model.Money_UseCard312=Shop.Tools.RequestTool.RequestDecimal("Money_UseCard312",0);
			if (HttpContext.Current.Request["Money_fromorder"] != null)
				model.Money_fromorder=Shop.Tools.RequestTool.RequestDecimal("Money_fromorder",0);
			if (HttpContext.Current.Request["UseCardCode311"] != null)
				model.UseCardCode311=Shop.Tools.RequestTool.RequestSafeString("UseCardCode311");
			if (HttpContext.Current.Request["UseCardCode312"] != null)
				model.UseCardCode312=Shop.Tools.RequestTool.RequestSafeString("UseCardCode312");
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["Volume"] != null)
				model.Volume=Shop.Tools.RequestTool.RequestDecimal("Volume",0);
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["Point_Buy"] != null)
				model.Point_Buy=Shop.Tools.RequestTool.RequestDecimal("Point_Buy",0);
			if (HttpContext.Current.Request["Point_Product"] != null)
				model.Point_Product=Shop.Tools.RequestTool.RequestDecimal("Point_Product",0);
			if (HttpContext.Current.Request["Point_Free"] != null)
				model.Point_Free=Shop.Tools.RequestTool.RequestDecimal("Point_Free",0);
			if (HttpContext.Current.Request["Transport_Name"] != null)
				model.Transport_Name=Shop.Tools.RequestTool.RequestSafeString("Transport_Name");
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Transport_Price_id"] != null)
				model.Transport_Price_id=Shop.Tools.RequestTool.RequestInt("Transport_Price_id",0);
			if (HttpContext.Current.Request["Transport_Code"] != null)
				model.Transport_Code=Shop.Tools.RequestTool.RequestSafeString("Transport_Code");
			if (HttpContext.Current.Request["Transport_Mark"] != null)
				model.Transport_Mark=Shop.Tools.RequestTool.RequestSafeString("Transport_Mark");
			if (HttpContext.Current.Request["EditMoney_Order"] != null)
				model.EditMoney_Order=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Order",0);
			if (HttpContext.Current.Request["EditMoney_Transport"] != null)
				model.EditMoney_Transport=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Transport",0);
			if (HttpContext.Current.Request["EditMoney_Discount"] != null)
				model.EditMoney_Discount=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Discount",0);
			if (HttpContext.Current.Request["IsVerified"] != null)
				model.IsVerified=Shop.Tools.RequestTool.RequestInt("IsVerified",0);
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["IsShipped"] != null)
				model.IsShipped=Shop.Tools.RequestTool.RequestInt("IsShipped",0);
			if (HttpContext.Current.Request["IsShipped_All"] != null)
				model.IsShipped_All=Shop.Tools.RequestTool.RequestInt("IsShipped_All",0);
			if (HttpContext.Current.Request["IsReceived"] != null)
				model.IsReceived=Shop.Tools.RequestTool.RequestInt("IsReceived",0);
			if (HttpContext.Current.Request["IsReceived_All"] != null)
				model.IsReceived_All=Shop.Tools.RequestTool.RequestInt("IsReceived_All",0);
			if (HttpContext.Current.Request["IsCompleted"] != null)
				model.IsCompleted=Shop.Tools.RequestTool.RequestInt("IsCompleted",0);
			if (HttpContext.Current.Request["IsInvalid"] != null)
				model.IsInvalid=Shop.Tools.RequestTool.RequestInt("IsInvalid",0);
			if (HttpContext.Current.Request["IsCreateCash"] != null)
				model.IsCreateCash=Shop.Tools.RequestTool.RequestInt("IsCreateCash",0);
			if (HttpContext.Current.Request["IsCreateNewOrder"] != null)
				model.IsCreateNewOrder=Shop.Tools.RequestTool.RequestInt("IsCreateNewOrder",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Verified"] != null)
				model.Time_Verified=Shop.Tools.RequestTool.RequestTime("Time_Verified", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Shipped"] != null)
				model.Time_Shipped=Shop.Tools.RequestTool.RequestTime("Time_Shipped", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Received"] != null)
				model.Time_Received=Shop.Tools.RequestTool.RequestTime("Time_Received", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Completed"] != null)
				model.Time_Completed=Shop.Tools.RequestTool.RequestTime("Time_Completed", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_CreateCash"] != null)
				model.Time_CreateCash=Shop.Tools.RequestTool.RequestTime("Time_CreateCash", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_CreateNewOrder"] != null)
				model.Time_CreateNewOrder=Shop.Tools.RequestTool.RequestTime("Time_CreateNewOrder", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark_Admin"] != null)
				model.Remark_Admin=Shop.Tools.RequestTool.RequestSafeString("Remark_Admin");
			if (HttpContext.Current.Request["BillType_Name"] != null)
				model.BillType_Name=Shop.Tools.RequestTool.RequestSafeString("BillType_Name");
			if (HttpContext.Current.Request["BillType_id"] != null)
				model.BillType_id=Shop.Tools.RequestTool.RequestInt("BillType_id",0);
			if (HttpContext.Current.Request["BillType_TaxRate"] != null)
				model.BillType_TaxRate=Shop.Tools.RequestTool.RequestDecimal("BillType_TaxRate",0);
			if (HttpContext.Current.Request["Type_id_OrderType"] != null)
				model.Type_id_OrderType=Shop.Tools.RequestTool.RequestInt("Type_id_OrderType",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["IsPrintExpress"] != null)
				model.IsPrintExpress=Shop.Tools.RequestTool.RequestInt("IsPrintExpress",0);
			if (HttpContext.Current.Request["Promotion_Type_ids"] != null)
				model.Promotion_Type_ids=Shop.Tools.RequestTool.RequestSafeString("Promotion_Type_ids");
			if (HttpContext.Current.Request["Mark"] != null)
				model.Mark=Shop.Tools.RequestTool.RequestInt("Mark",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestSafeString("Currency_Code");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestSafeString("Currency_Msige");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Flag"] != null)
				model.Flag=Shop.Tools.RequestTool.RequestInt("Flag",0);
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["BLNo"] != null)
				model.BLNo=Shop.Tools.RequestTool.RequestSafeString("BLNo");
			if (HttpContext.Current.Request["ContainerNo"] != null)
				model.ContainerNo=Shop.Tools.RequestTool.RequestSafeString("ContainerNo");
			if (HttpContext.Current.Request["SealNo"] != null)
				model.SealNo=Shop.Tools.RequestTool.RequestSafeString("SealNo");
			if (HttpContext.Current.Request["weixin_prepay_id"] != null)
				model.weixin_prepay_id=Shop.Tools.RequestTool.RequestSafeString("weixin_prepay_id");
			if (HttpContext.Current.Request["IsSupplierCash"] != null)
				model.IsSupplierCash=Shop.Tools.RequestTool.RequestInt("IsSupplierCash",0);
			if (HttpContext.Current.Request["Money_OnlinepayFee"] != null)
				model.Money_OnlinepayFee=Shop.Tools.RequestTool.RequestDecimal("Money_OnlinepayFee",0);
			if (HttpContext.Current.Request["Site_id_pay"] != null)
				model.Site_id_pay=Shop.Tools.RequestTool.RequestInt("Site_id_pay",0);
			if (HttpContext.Current.Request["PickUp_id"] != null)
				model.PickUp_id=Shop.Tools.RequestTool.RequestInt("PickUp_id",0);
			if (HttpContext.Current.Request["PickUp_Name"] != null)
				model.PickUp_Name=Shop.Tools.RequestTool.RequestSafeString("PickUp_Name");
			if (HttpContext.Current.Request["PickUp_Date"] != null)
				model.PickUp_Date=Shop.Tools.RequestTool.RequestTime("PickUp_Date", System.DateTime.Now);
			if (HttpContext.Current.Request["Refund_VAT"] != null)
				model.Refund_VAT=Shop.Tools.RequestTool.RequestDecimal("Refund_VAT",0);
			if (HttpContext.Current.Request["Refund_Fee"] != null)
				model.Refund_Fee=Shop.Tools.RequestTool.RequestDecimal("Refund_Fee",0);
			if (HttpContext.Current.Request["Language_id"] != null)
				model.Language_id=Shop.Tools.RequestTool.RequestInt("Language_id",0);
			if (HttpContext.Current.Request["Supplier_Delivery_id"] != null)
				model.Supplier_Delivery_id=Shop.Tools.RequestTool.RequestInt("Supplier_Delivery_id",0);
			if (HttpContext.Current.Request["IsRefund"] != null)
				model.IsRefund=Shop.Tools.RequestTool.RequestInt("IsRefund",0);
			if (HttpContext.Current.Request["Time_Refund"] != null)
				model.Time_Refund=Shop.Tools.RequestTool.RequestTime("Time_Refund", System.DateTime.Now);
			if (HttpContext.Current.Request["Promotion_Type_Name"] != null)
				model.Promotion_Type_Name=Shop.Tools.RequestTool.RequestSafeString("Promotion_Type_Name");
			if (HttpContext.Current.Request["User_NickName"] != null)
				model.User_NickName=Shop.Tools.RequestTool.RequestSafeString("User_NickName");
			if (HttpContext.Current.Request["Money_Paid"] != null)
				model.Money_Paid=Shop.Tools.RequestTool.RequestDecimal("Money_Paid",0);
			if (HttpContext.Current.Request["IsReserve"] != null)
				model.IsReserve=Shop.Tools.RequestTool.RequestInt("IsReserve",0);
			if (HttpContext.Current.Request["Money_fanxianpay"] != null)
				model.Money_fanxianpay=Shop.Tools.RequestTool.RequestDecimal("Money_fanxianpay",0);
			if (HttpContext.Current.Request["Money_Tax"] != null)
				model.Money_Tax=Shop.Tools.RequestTool.RequestDecimal("Money_Tax",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["DT_Money"] != null)
				model.DT_Money=Shop.Tools.RequestTool.RequestDecimal("DT_Money",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Order ReaderBind(IDataReader dataReader)
		{
			Lebi_Order model=new Lebi_Order();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			model.T_Name=dataReader["T_Name"].ToString();
			ojb = dataReader["T_Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.T_Area_id=(int)ojb;
			}
			model.T_Address=dataReader["T_Address"].ToString();
			model.T_Phone=dataReader["T_Phone"].ToString();
			model.T_MobilePhone=dataReader["T_MobilePhone"].ToString();
			model.T_Postalcode=dataReader["T_Postalcode"].ToString();
			model.T_Email=dataReader["T_Email"].ToString();
			model.Remark_User=dataReader["Remark_User"].ToString();
			ojb = dataReader["Pay_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pay_id=(int)ojb;
			}
			model.Pay=dataReader["Pay"].ToString();
			ojb = dataReader["OnlinePay_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OnlinePay_id=(int)ojb;
			}
			model.OnlinePay=dataReader["OnlinePay"].ToString();
			model.OnlinePay_Code=dataReader["OnlinePay_Code"].ToString();
			ojb = dataReader["Money_Order"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Order=(decimal)ojb;
			}
			ojb = dataReader["Money_Pay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Pay=(decimal)ojb;
			}
			ojb = dataReader["Money_Product"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Product=(decimal)ojb;
			}
			ojb = dataReader["Money_Transport"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Transport=(decimal)ojb;
			}
			ojb = dataReader["Money_Transport_Cut"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Transport_Cut=(decimal)ojb;
			}
			ojb = dataReader["Money_Bill"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Bill=(decimal)ojb;
			}
			ojb = dataReader["Money_Market"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Market=(decimal)ojb;
			}
			ojb = dataReader["Money_Give"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Give=(decimal)ojb;
			}
			ojb = dataReader["Money_Cut"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Cut=(decimal)ojb;
			}
			ojb = dataReader["Money_UserCut"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_UserCut=(decimal)ojb;
			}
			ojb = dataReader["Money_Cost"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Cost=(decimal)ojb;
			}
			ojb = dataReader["Money_Property"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Property=(decimal)ojb;
			}
			ojb = dataReader["Money_UseCard311"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_UseCard311=(decimal)ojb;
			}
			ojb = dataReader["Money_UseCard312"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_UseCard312=(decimal)ojb;
			}
			ojb = dataReader["Money_fromorder"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_fromorder=(decimal)ojb;
			}
			model.UseCardCode311=dataReader["UseCardCode311"].ToString();
			model.UseCardCode312=dataReader["UseCardCode312"].ToString();
			ojb = dataReader["Weight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight=(decimal)ojb;
			}
			ojb = dataReader["Volume"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Volume=(decimal)ojb;
			}
			ojb = dataReader["Point"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point=(decimal)ojb;
			}
			ojb = dataReader["Point_Buy"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Buy=(decimal)ojb;
			}
			ojb = dataReader["Point_Product"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Product=(decimal)ojb;
			}
			ojb = dataReader["Point_Free"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Free=(decimal)ojb;
			}
			model.Transport_Name=dataReader["Transport_Name"].ToString();
			ojb = dataReader["Transport_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Transport_id=(int)ojb;
			}
			ojb = dataReader["Transport_Price_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Transport_Price_id=(int)ojb;
			}
			model.Transport_Code=dataReader["Transport_Code"].ToString();
			model.Transport_Mark=dataReader["Transport_Mark"].ToString();
			ojb = dataReader["EditMoney_Order"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EditMoney_Order=(decimal)ojb;
			}
			ojb = dataReader["EditMoney_Transport"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EditMoney_Transport=(decimal)ojb;
			}
			ojb = dataReader["EditMoney_Discount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EditMoney_Discount=(decimal)ojb;
			}
			ojb = dataReader["IsVerified"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsVerified=(int)ojb;
			}
			ojb = dataReader["IsPaid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPaid=(int)ojb;
			}
			ojb = dataReader["IsShipped"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShipped=(int)ojb;
			}
			ojb = dataReader["IsShipped_All"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShipped_All=(int)ojb;
			}
			ojb = dataReader["IsReceived"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsReceived=(int)ojb;
			}
			ojb = dataReader["IsReceived_All"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsReceived_All=(int)ojb;
			}
			ojb = dataReader["IsCompleted"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCompleted=(int)ojb;
			}
			ojb = dataReader["IsInvalid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsInvalid=(int)ojb;
			}
			ojb = dataReader["IsCreateCash"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCreateCash=(int)ojb;
			}
			ojb = dataReader["IsCreateNewOrder"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCreateNewOrder=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Verified"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Verified=(DateTime)ojb;
			}
			ojb = dataReader["Time_Paid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Paid=(DateTime)ojb;
			}
			ojb = dataReader["Time_Shipped"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Shipped=(DateTime)ojb;
			}
			ojb = dataReader["Time_Received"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Received=(DateTime)ojb;
			}
			ojb = dataReader["Time_Completed"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Completed=(DateTime)ojb;
			}
			ojb = dataReader["Time_CreateCash"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_CreateCash=(DateTime)ojb;
			}
			ojb = dataReader["Time_CreateNewOrder"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_CreateNewOrder=(DateTime)ojb;
			}
			model.Remark_Admin=dataReader["Remark_Admin"].ToString();
			model.BillType_Name=dataReader["BillType_Name"].ToString();
			ojb = dataReader["BillType_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BillType_id=(int)ojb;
			}
			ojb = dataReader["BillType_TaxRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BillType_TaxRate=(decimal)ojb;
			}
			ojb = dataReader["Type_id_OrderType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_OrderType=(int)ojb;
			}
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			ojb = dataReader["IsPrintExpress"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPrintExpress=(int)ojb;
			}
			model.Promotion_Type_ids=dataReader["Promotion_Type_ids"].ToString();
			ojb = dataReader["Mark"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Mark=(int)ojb;
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
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["Flag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Flag=(int)ojb;
			}
			ojb = dataReader["Site_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Site_id=(int)ojb;
			}
			model.BLNo=dataReader["BLNo"].ToString();
			model.ContainerNo=dataReader["ContainerNo"].ToString();
			model.SealNo=dataReader["SealNo"].ToString();
			model.weixin_prepay_id=dataReader["weixin_prepay_id"].ToString();
			ojb = dataReader["IsSupplierCash"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSupplierCash=(int)ojb;
			}
			ojb = dataReader["Money_OnlinepayFee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_OnlinepayFee=(decimal)ojb;
			}
			ojb = dataReader["Site_id_pay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Site_id_pay=(int)ojb;
			}
			ojb = dataReader["PickUp_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PickUp_id=(int)ojb;
			}
			model.PickUp_Name=dataReader["PickUp_Name"].ToString();
			ojb = dataReader["PickUp_Date"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PickUp_Date=(DateTime)ojb;
			}
			ojb = dataReader["Refund_VAT"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Refund_VAT=(decimal)ojb;
			}
			ojb = dataReader["Refund_Fee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Refund_Fee=(decimal)ojb;
			}
			ojb = dataReader["Language_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Language_id=(int)ojb;
			}
			ojb = dataReader["Supplier_Delivery_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_Delivery_id=(int)ojb;
			}
			ojb = dataReader["IsRefund"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRefund=(int)ojb;
			}
			ojb = dataReader["Time_Refund"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Refund=(DateTime)ojb;
			}
			model.Promotion_Type_Name=dataReader["Promotion_Type_Name"].ToString();
			model.User_NickName=dataReader["User_NickName"].ToString();
			ojb = dataReader["Money_Paid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Paid=(decimal)ojb;
			}
			ojb = dataReader["IsReserve"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsReserve=(int)ojb;
			}
			ojb = dataReader["Money_fanxianpay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_fanxianpay=(decimal)ojb;
			}
			ojb = dataReader["Money_Tax"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Tax=(decimal)ojb;
			}
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			ojb = dataReader["DT_Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_Money=(decimal)ojb;
			}
			ojb = dataReader["IsDel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDel=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Order : Lebi_Order_interface
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
				strSql.Append("select " + colName + " from [Lebi_Order]");
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
			strSql.Append("select  "+colName+" from [Lebi_Order]");
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
			strSql.Append("select count(*) from [Lebi_Order]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Order]");
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
			strSql.Append("select max(id) from [Lebi_Order]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Order]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Order](");
			strSql.Append("[Code],[User_id],[User_UserName],[T_Name],[T_Area_id],[T_Address],[T_Phone],[T_MobilePhone],[T_Postalcode],[T_Email],[Remark_User],[Pay_id],[Pay],[OnlinePay_id],[OnlinePay],[OnlinePay_Code],[Money_Order],[Money_Pay],[Money_Product],[Money_Transport],[Money_Transport_Cut],[Money_Bill],[Money_Market],[Money_Give],[Money_Cut],[Money_UserCut],[Money_Cost],[Money_Property],[Money_UseCard311],[Money_UseCard312],[Money_fromorder],[UseCardCode311],[UseCardCode312],[Weight],[Volume],[Point],[Point_Buy],[Point_Product],[Point_Free],[Transport_Name],[Transport_id],[Transport_Price_id],[Transport_Code],[Transport_Mark],[EditMoney_Order],[EditMoney_Transport],[EditMoney_Discount],[IsVerified],[IsPaid],[IsShipped],[IsShipped_All],[IsReceived],[IsReceived_All],[IsCompleted],[IsInvalid],[IsCreateCash],[IsCreateNewOrder],[Time_Add],[Time_Verified],[Time_Paid],[Time_Shipped],[Time_Received],[Time_Completed],[Time_CreateCash],[Time_CreateNewOrder],[Remark_Admin],[BillType_Name],[BillType_id],[BillType_TaxRate],[Type_id_OrderType],[Order_id],[IsPrintExpress],[Promotion_Type_ids],[Mark],[Currency_id],[Currency_Code],[Currency_ExchangeRate],[Currency_Msige],[Supplier_id],[Flag],[Site_id],[BLNo],[ContainerNo],[SealNo],[weixin_prepay_id],[IsSupplierCash],[Money_OnlinepayFee],[Site_id_pay],[PickUp_id],[PickUp_Name],[PickUp_Date],[Refund_VAT],[Refund_Fee],[Language_id],[Supplier_Delivery_id],[IsRefund],[Time_Refund],[Promotion_Type_Name],[User_NickName],[Money_Paid],[IsReserve],[Money_fanxianpay],[Money_Tax],[DT_id],[DT_Money],[IsDel])");
			strSql.Append(" values (");
			strSql.Append("@Code,@User_id,@User_UserName,@T_Name,@T_Area_id,@T_Address,@T_Phone,@T_MobilePhone,@T_Postalcode,@T_Email,@Remark_User,@Pay_id,@Pay,@OnlinePay_id,@OnlinePay,@OnlinePay_Code,@Money_Order,@Money_Pay,@Money_Product,@Money_Transport,@Money_Transport_Cut,@Money_Bill,@Money_Market,@Money_Give,@Money_Cut,@Money_UserCut,@Money_Cost,@Money_Property,@Money_UseCard311,@Money_UseCard312,@Money_fromorder,@UseCardCode311,@UseCardCode312,@Weight,@Volume,@Point,@Point_Buy,@Point_Product,@Point_Free,@Transport_Name,@Transport_id,@Transport_Price_id,@Transport_Code,@Transport_Mark,@EditMoney_Order,@EditMoney_Transport,@EditMoney_Discount,@IsVerified,@IsPaid,@IsShipped,@IsShipped_All,@IsReceived,@IsReceived_All,@IsCompleted,@IsInvalid,@IsCreateCash,@IsCreateNewOrder,@Time_Add,@Time_Verified,@Time_Paid,@Time_Shipped,@Time_Received,@Time_Completed,@Time_CreateCash,@Time_CreateNewOrder,@Remark_Admin,@BillType_Name,@BillType_id,@BillType_TaxRate,@Type_id_OrderType,@Order_id,@IsPrintExpress,@Promotion_Type_ids,@Mark,@Currency_id,@Currency_Code,@Currency_ExchangeRate,@Currency_Msige,@Supplier_id,@Flag,@Site_id,@BLNo,@ContainerNo,@SealNo,@weixin_prepay_id,@IsSupplierCash,@Money_OnlinepayFee,@Site_id_pay,@PickUp_id,@PickUp_Name,@PickUp_Date,@Refund_VAT,@Refund_Fee,@Language_id,@Supplier_Delivery_id,@IsRefund,@Time_Refund,@Promotion_Type_Name,@User_NickName,@Money_Paid,@IsReserve,@Money_fanxianpay,@Money_Tax,@DT_id,@DT_Money,@IsDel)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@T_Name", model.T_Name),
					new OleDbParameter("@T_Area_id", model.T_Area_id),
					new OleDbParameter("@T_Address", model.T_Address),
					new OleDbParameter("@T_Phone", model.T_Phone),
					new OleDbParameter("@T_MobilePhone", model.T_MobilePhone),
					new OleDbParameter("@T_Postalcode", model.T_Postalcode),
					new OleDbParameter("@T_Email", model.T_Email),
					new OleDbParameter("@Remark_User", model.Remark_User),
					new OleDbParameter("@Pay_id", model.Pay_id),
					new OleDbParameter("@Pay", model.Pay),
					new OleDbParameter("@OnlinePay_id", model.OnlinePay_id),
					new OleDbParameter("@OnlinePay", model.OnlinePay),
					new OleDbParameter("@OnlinePay_Code", model.OnlinePay_Code),
					new OleDbParameter("@Money_Order", model.Money_Order),
					new OleDbParameter("@Money_Pay", model.Money_Pay),
					new OleDbParameter("@Money_Product", model.Money_Product),
					new OleDbParameter("@Money_Transport", model.Money_Transport),
					new OleDbParameter("@Money_Transport_Cut", model.Money_Transport_Cut),
					new OleDbParameter("@Money_Bill", model.Money_Bill),
					new OleDbParameter("@Money_Market", model.Money_Market),
					new OleDbParameter("@Money_Give", model.Money_Give),
					new OleDbParameter("@Money_Cut", model.Money_Cut),
					new OleDbParameter("@Money_UserCut", model.Money_UserCut),
					new OleDbParameter("@Money_Cost", model.Money_Cost),
					new OleDbParameter("@Money_Property", model.Money_Property),
					new OleDbParameter("@Money_UseCard311", model.Money_UseCard311),
					new OleDbParameter("@Money_UseCard312", model.Money_UseCard312),
					new OleDbParameter("@Money_fromorder", model.Money_fromorder),
					new OleDbParameter("@UseCardCode311", model.UseCardCode311),
					new OleDbParameter("@UseCardCode312", model.UseCardCode312),
					new OleDbParameter("@Weight", model.Weight),
					new OleDbParameter("@Volume", model.Volume),
					new OleDbParameter("@Point", model.Point),
					new OleDbParameter("@Point_Buy", model.Point_Buy),
					new OleDbParameter("@Point_Product", model.Point_Product),
					new OleDbParameter("@Point_Free", model.Point_Free),
					new OleDbParameter("@Transport_Name", model.Transport_Name),
					new OleDbParameter("@Transport_id", model.Transport_id),
					new OleDbParameter("@Transport_Price_id", model.Transport_Price_id),
					new OleDbParameter("@Transport_Code", model.Transport_Code),
					new OleDbParameter("@Transport_Mark", model.Transport_Mark),
					new OleDbParameter("@EditMoney_Order", model.EditMoney_Order),
					new OleDbParameter("@EditMoney_Transport", model.EditMoney_Transport),
					new OleDbParameter("@EditMoney_Discount", model.EditMoney_Discount),
					new OleDbParameter("@IsVerified", model.IsVerified),
					new OleDbParameter("@IsPaid", model.IsPaid),
					new OleDbParameter("@IsShipped", model.IsShipped),
					new OleDbParameter("@IsShipped_All", model.IsShipped_All),
					new OleDbParameter("@IsReceived", model.IsReceived),
					new OleDbParameter("@IsReceived_All", model.IsReceived_All),
					new OleDbParameter("@IsCompleted", model.IsCompleted),
					new OleDbParameter("@IsInvalid", model.IsInvalid),
					new OleDbParameter("@IsCreateCash", model.IsCreateCash),
					new OleDbParameter("@IsCreateNewOrder", model.IsCreateNewOrder),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Verified", model.Time_Verified.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Paid", model.Time_Paid.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Shipped", model.Time_Shipped.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Received", model.Time_Received.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Completed", model.Time_Completed.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_CreateCash", model.Time_CreateCash.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_CreateNewOrder", model.Time_CreateNewOrder.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Remark_Admin", model.Remark_Admin),
					new OleDbParameter("@BillType_Name", model.BillType_Name),
					new OleDbParameter("@BillType_id", model.BillType_id),
					new OleDbParameter("@BillType_TaxRate", model.BillType_TaxRate),
					new OleDbParameter("@Type_id_OrderType", model.Type_id_OrderType),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@IsPrintExpress", model.IsPrintExpress),
					new OleDbParameter("@Promotion_Type_ids", model.Promotion_Type_ids),
					new OleDbParameter("@Mark", model.Mark),
					new OleDbParameter("@Currency_id", model.Currency_id),
					new OleDbParameter("@Currency_Code", model.Currency_Code),
					new OleDbParameter("@Currency_ExchangeRate", model.Currency_ExchangeRate),
					new OleDbParameter("@Currency_Msige", model.Currency_Msige),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Flag", model.Flag),
					new OleDbParameter("@Site_id", model.Site_id),
					new OleDbParameter("@BLNo", model.BLNo),
					new OleDbParameter("@ContainerNo", model.ContainerNo),
					new OleDbParameter("@SealNo", model.SealNo),
					new OleDbParameter("@weixin_prepay_id", model.weixin_prepay_id),
					new OleDbParameter("@IsSupplierCash", model.IsSupplierCash),
					new OleDbParameter("@Money_OnlinepayFee", model.Money_OnlinepayFee),
					new OleDbParameter("@Site_id_pay", model.Site_id_pay),
					new OleDbParameter("@PickUp_id", model.PickUp_id),
					new OleDbParameter("@PickUp_Name", model.PickUp_Name),
					new OleDbParameter("@PickUp_Date", model.PickUp_Date.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Refund_VAT", model.Refund_VAT),
					new OleDbParameter("@Refund_Fee", model.Refund_Fee),
					new OleDbParameter("@Language_id", model.Language_id),
					new OleDbParameter("@Supplier_Delivery_id", model.Supplier_Delivery_id),
					new OleDbParameter("@IsRefund", model.IsRefund),
					new OleDbParameter("@Time_Refund", model.Time_Refund.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Promotion_Type_Name", model.Promotion_Type_Name),
					new OleDbParameter("@User_NickName", model.User_NickName),
					new OleDbParameter("@Money_Paid", model.Money_Paid),
					new OleDbParameter("@IsReserve", model.IsReserve),
					new OleDbParameter("@Money_fanxianpay", model.Money_fanxianpay),
					new OleDbParameter("@Money_Tax", model.Money_Tax),
					new OleDbParameter("@DT_id", model.DT_id),
					new OleDbParameter("@DT_Money", model.DT_Money),
					new OleDbParameter("@IsDel", model.IsDel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Order] set ");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[User_UserName]=@User_UserName,");
			strSql.Append("[T_Name]=@T_Name,");
			strSql.Append("[T_Area_id]=@T_Area_id,");
			strSql.Append("[T_Address]=@T_Address,");
			strSql.Append("[T_Phone]=@T_Phone,");
			strSql.Append("[T_MobilePhone]=@T_MobilePhone,");
			strSql.Append("[T_Postalcode]=@T_Postalcode,");
			strSql.Append("[T_Email]=@T_Email,");
			strSql.Append("[Remark_User]=@Remark_User,");
			strSql.Append("[Pay_id]=@Pay_id,");
			strSql.Append("[Pay]=@Pay,");
			strSql.Append("[OnlinePay_id]=@OnlinePay_id,");
			strSql.Append("[OnlinePay]=@OnlinePay,");
			strSql.Append("[OnlinePay_Code]=@OnlinePay_Code,");
			strSql.Append("[Money_Order]=@Money_Order,");
			strSql.Append("[Money_Pay]=@Money_Pay,");
			strSql.Append("[Money_Product]=@Money_Product,");
			strSql.Append("[Money_Transport]=@Money_Transport,");
			strSql.Append("[Money_Transport_Cut]=@Money_Transport_Cut,");
			strSql.Append("[Money_Bill]=@Money_Bill,");
			strSql.Append("[Money_Market]=@Money_Market,");
			strSql.Append("[Money_Give]=@Money_Give,");
			strSql.Append("[Money_Cut]=@Money_Cut,");
			strSql.Append("[Money_UserCut]=@Money_UserCut,");
			strSql.Append("[Money_Cost]=@Money_Cost,");
			strSql.Append("[Money_Property]=@Money_Property,");
			strSql.Append("[Money_UseCard311]=@Money_UseCard311,");
			strSql.Append("[Money_UseCard312]=@Money_UseCard312,");
			strSql.Append("[Money_fromorder]=@Money_fromorder,");
			strSql.Append("[UseCardCode311]=@UseCardCode311,");
			strSql.Append("[UseCardCode312]=@UseCardCode312,");
			strSql.Append("[Weight]=@Weight,");
			strSql.Append("[Volume]=@Volume,");
			strSql.Append("[Point]=@Point,");
			strSql.Append("[Point_Buy]=@Point_Buy,");
			strSql.Append("[Point_Product]=@Point_Product,");
			strSql.Append("[Point_Free]=@Point_Free,");
			strSql.Append("[Transport_Name]=@Transport_Name,");
			strSql.Append("[Transport_id]=@Transport_id,");
			strSql.Append("[Transport_Price_id]=@Transport_Price_id,");
			strSql.Append("[Transport_Code]=@Transport_Code,");
			strSql.Append("[Transport_Mark]=@Transport_Mark,");
			strSql.Append("[EditMoney_Order]=@EditMoney_Order,");
			strSql.Append("[EditMoney_Transport]=@EditMoney_Transport,");
			strSql.Append("[EditMoney_Discount]=@EditMoney_Discount,");
			strSql.Append("[IsVerified]=@IsVerified,");
			strSql.Append("[IsPaid]=@IsPaid,");
			strSql.Append("[IsShipped]=@IsShipped,");
			strSql.Append("[IsShipped_All]=@IsShipped_All,");
			strSql.Append("[IsReceived]=@IsReceived,");
			strSql.Append("[IsReceived_All]=@IsReceived_All,");
			strSql.Append("[IsCompleted]=@IsCompleted,");
			strSql.Append("[IsInvalid]=@IsInvalid,");
			strSql.Append("[IsCreateCash]=@IsCreateCash,");
			strSql.Append("[IsCreateNewOrder]=@IsCreateNewOrder,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Verified]=@Time_Verified,");
			strSql.Append("[Time_Paid]=@Time_Paid,");
			strSql.Append("[Time_Shipped]=@Time_Shipped,");
			strSql.Append("[Time_Received]=@Time_Received,");
			strSql.Append("[Time_Completed]=@Time_Completed,");
			strSql.Append("[Time_CreateCash]=@Time_CreateCash,");
			strSql.Append("[Time_CreateNewOrder]=@Time_CreateNewOrder,");
			strSql.Append("[Remark_Admin]=@Remark_Admin,");
			strSql.Append("[BillType_Name]=@BillType_Name,");
			strSql.Append("[BillType_id]=@BillType_id,");
			strSql.Append("[BillType_TaxRate]=@BillType_TaxRate,");
			strSql.Append("[Type_id_OrderType]=@Type_id_OrderType,");
			strSql.Append("[Order_id]=@Order_id,");
			strSql.Append("[IsPrintExpress]=@IsPrintExpress,");
			strSql.Append("[Promotion_Type_ids]=@Promotion_Type_ids,");
			strSql.Append("[Mark]=@Mark,");
			strSql.Append("[Currency_id]=@Currency_id,");
			strSql.Append("[Currency_Code]=@Currency_Code,");
			strSql.Append("[Currency_ExchangeRate]=@Currency_ExchangeRate,");
			strSql.Append("[Currency_Msige]=@Currency_Msige,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Flag]=@Flag,");
			strSql.Append("[Site_id]=@Site_id,");
			strSql.Append("[BLNo]=@BLNo,");
			strSql.Append("[ContainerNo]=@ContainerNo,");
			strSql.Append("[SealNo]=@SealNo,");
			strSql.Append("[weixin_prepay_id]=@weixin_prepay_id,");
			strSql.Append("[IsSupplierCash]=@IsSupplierCash,");
			strSql.Append("[Money_OnlinepayFee]=@Money_OnlinepayFee,");
			strSql.Append("[Site_id_pay]=@Site_id_pay,");
			strSql.Append("[PickUp_id]=@PickUp_id,");
			strSql.Append("[PickUp_Name]=@PickUp_Name,");
			strSql.Append("[PickUp_Date]=@PickUp_Date,");
			strSql.Append("[Refund_VAT]=@Refund_VAT,");
			strSql.Append("[Refund_Fee]=@Refund_Fee,");
			strSql.Append("[Language_id]=@Language_id,");
			strSql.Append("[Supplier_Delivery_id]=@Supplier_Delivery_id,");
			strSql.Append("[IsRefund]=@IsRefund,");
			strSql.Append("[Time_Refund]=@Time_Refund,");
			strSql.Append("[Promotion_Type_Name]=@Promotion_Type_Name,");
			strSql.Append("[User_NickName]=@User_NickName,");
			strSql.Append("[Money_Paid]=@Money_Paid,");
			strSql.Append("[IsReserve]=@IsReserve,");
			strSql.Append("[Money_fanxianpay]=@Money_fanxianpay,");
			strSql.Append("[Money_Tax]=@Money_Tax,");
			strSql.Append("[DT_id]=@DT_id,");
			strSql.Append("[DT_Money]=@DT_Money,");
			strSql.Append("[IsDel]=@IsDel");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@T_Name", model.T_Name),
					new OleDbParameter("@T_Area_id", model.T_Area_id),
					new OleDbParameter("@T_Address", model.T_Address),
					new OleDbParameter("@T_Phone", model.T_Phone),
					new OleDbParameter("@T_MobilePhone", model.T_MobilePhone),
					new OleDbParameter("@T_Postalcode", model.T_Postalcode),
					new OleDbParameter("@T_Email", model.T_Email),
					new OleDbParameter("@Remark_User", model.Remark_User),
					new OleDbParameter("@Pay_id", model.Pay_id),
					new OleDbParameter("@Pay", model.Pay),
					new OleDbParameter("@OnlinePay_id", model.OnlinePay_id),
					new OleDbParameter("@OnlinePay", model.OnlinePay),
					new OleDbParameter("@OnlinePay_Code", model.OnlinePay_Code),
					new OleDbParameter("@Money_Order", model.Money_Order),
					new OleDbParameter("@Money_Pay", model.Money_Pay),
					new OleDbParameter("@Money_Product", model.Money_Product),
					new OleDbParameter("@Money_Transport", model.Money_Transport),
					new OleDbParameter("@Money_Transport_Cut", model.Money_Transport_Cut),
					new OleDbParameter("@Money_Bill", model.Money_Bill),
					new OleDbParameter("@Money_Market", model.Money_Market),
					new OleDbParameter("@Money_Give", model.Money_Give),
					new OleDbParameter("@Money_Cut", model.Money_Cut),
					new OleDbParameter("@Money_UserCut", model.Money_UserCut),
					new OleDbParameter("@Money_Cost", model.Money_Cost),
					new OleDbParameter("@Money_Property", model.Money_Property),
					new OleDbParameter("@Money_UseCard311", model.Money_UseCard311),
					new OleDbParameter("@Money_UseCard312", model.Money_UseCard312),
					new OleDbParameter("@Money_fromorder", model.Money_fromorder),
					new OleDbParameter("@UseCardCode311", model.UseCardCode311),
					new OleDbParameter("@UseCardCode312", model.UseCardCode312),
					new OleDbParameter("@Weight", model.Weight),
					new OleDbParameter("@Volume", model.Volume),
					new OleDbParameter("@Point", model.Point),
					new OleDbParameter("@Point_Buy", model.Point_Buy),
					new OleDbParameter("@Point_Product", model.Point_Product),
					new OleDbParameter("@Point_Free", model.Point_Free),
					new OleDbParameter("@Transport_Name", model.Transport_Name),
					new OleDbParameter("@Transport_id", model.Transport_id),
					new OleDbParameter("@Transport_Price_id", model.Transport_Price_id),
					new OleDbParameter("@Transport_Code", model.Transport_Code),
					new OleDbParameter("@Transport_Mark", model.Transport_Mark),
					new OleDbParameter("@EditMoney_Order", model.EditMoney_Order),
					new OleDbParameter("@EditMoney_Transport", model.EditMoney_Transport),
					new OleDbParameter("@EditMoney_Discount", model.EditMoney_Discount),
					new OleDbParameter("@IsVerified", model.IsVerified),
					new OleDbParameter("@IsPaid", model.IsPaid),
					new OleDbParameter("@IsShipped", model.IsShipped),
					new OleDbParameter("@IsShipped_All", model.IsShipped_All),
					new OleDbParameter("@IsReceived", model.IsReceived),
					new OleDbParameter("@IsReceived_All", model.IsReceived_All),
					new OleDbParameter("@IsCompleted", model.IsCompleted),
					new OleDbParameter("@IsInvalid", model.IsInvalid),
					new OleDbParameter("@IsCreateCash", model.IsCreateCash),
					new OleDbParameter("@IsCreateNewOrder", model.IsCreateNewOrder),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Verified", model.Time_Verified.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Paid", model.Time_Paid.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Shipped", model.Time_Shipped.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Received", model.Time_Received.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Completed", model.Time_Completed.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_CreateCash", model.Time_CreateCash.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_CreateNewOrder", model.Time_CreateNewOrder.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Remark_Admin", model.Remark_Admin),
					new OleDbParameter("@BillType_Name", model.BillType_Name),
					new OleDbParameter("@BillType_id", model.BillType_id),
					new OleDbParameter("@BillType_TaxRate", model.BillType_TaxRate),
					new OleDbParameter("@Type_id_OrderType", model.Type_id_OrderType),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@IsPrintExpress", model.IsPrintExpress),
					new OleDbParameter("@Promotion_Type_ids", model.Promotion_Type_ids),
					new OleDbParameter("@Mark", model.Mark),
					new OleDbParameter("@Currency_id", model.Currency_id),
					new OleDbParameter("@Currency_Code", model.Currency_Code),
					new OleDbParameter("@Currency_ExchangeRate", model.Currency_ExchangeRate),
					new OleDbParameter("@Currency_Msige", model.Currency_Msige),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Flag", model.Flag),
					new OleDbParameter("@Site_id", model.Site_id),
					new OleDbParameter("@BLNo", model.BLNo),
					new OleDbParameter("@ContainerNo", model.ContainerNo),
					new OleDbParameter("@SealNo", model.SealNo),
					new OleDbParameter("@weixin_prepay_id", model.weixin_prepay_id),
					new OleDbParameter("@IsSupplierCash", model.IsSupplierCash),
					new OleDbParameter("@Money_OnlinepayFee", model.Money_OnlinepayFee),
					new OleDbParameter("@Site_id_pay", model.Site_id_pay),
					new OleDbParameter("@PickUp_id", model.PickUp_id),
					new OleDbParameter("@PickUp_Name", model.PickUp_Name),
					new OleDbParameter("@PickUp_Date", model.PickUp_Date.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Refund_VAT", model.Refund_VAT),
					new OleDbParameter("@Refund_Fee", model.Refund_Fee),
					new OleDbParameter("@Language_id", model.Language_id),
					new OleDbParameter("@Supplier_Delivery_id", model.Supplier_Delivery_id),
					new OleDbParameter("@IsRefund", model.IsRefund),
					new OleDbParameter("@Time_Refund", model.Time_Refund.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Promotion_Type_Name", model.Promotion_Type_Name),
					new OleDbParameter("@User_NickName", model.User_NickName),
					new OleDbParameter("@Money_Paid", model.Money_Paid),
					new OleDbParameter("@IsReserve", model.IsReserve),
					new OleDbParameter("@Money_fanxianpay", model.Money_fanxianpay),
					new OleDbParameter("@Money_Tax", model.Money_Tax),
					new OleDbParameter("@DT_id", model.DT_id),
					new OleDbParameter("@DT_Money", model.DT_Money),
					new OleDbParameter("@IsDel", model.IsDel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order] ");
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
			strSql.Append("delete from [Lebi_Order] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Order GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Order model;
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
		public Lebi_Order GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Order model;
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
		public Lebi_Order GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Order] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Order model;
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
		public List<Lebi_Order> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Order]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Order> list = new List<Lebi_Order>();
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
		public List<Lebi_Order> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Order]";
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
			List<Lebi_Order> list = new List<Lebi_Order>();
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
		public List<Lebi_Order> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Order] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Order> list = new List<Lebi_Order>();
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
		public List<Lebi_Order> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Order]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Order> list = new List<Lebi_Order>();
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
		public Lebi_Order BindForm(Lebi_Order model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["T_Name"] != null)
				model.T_Name=Shop.Tools.RequestTool.RequestString("T_Name");
			if (HttpContext.Current.Request["T_Area_id"] != null)
				model.T_Area_id=Shop.Tools.RequestTool.RequestInt("T_Area_id",0);
			if (HttpContext.Current.Request["T_Address"] != null)
				model.T_Address=Shop.Tools.RequestTool.RequestString("T_Address");
			if (HttpContext.Current.Request["T_Phone"] != null)
				model.T_Phone=Shop.Tools.RequestTool.RequestString("T_Phone");
			if (HttpContext.Current.Request["T_MobilePhone"] != null)
				model.T_MobilePhone=Shop.Tools.RequestTool.RequestString("T_MobilePhone");
			if (HttpContext.Current.Request["T_Postalcode"] != null)
				model.T_Postalcode=Shop.Tools.RequestTool.RequestString("T_Postalcode");
			if (HttpContext.Current.Request["T_Email"] != null)
				model.T_Email=Shop.Tools.RequestTool.RequestString("T_Email");
			if (HttpContext.Current.Request["Remark_User"] != null)
				model.Remark_User=Shop.Tools.RequestTool.RequestString("Remark_User");
			if (HttpContext.Current.Request["Pay_id"] != null)
				model.Pay_id=Shop.Tools.RequestTool.RequestInt("Pay_id",0);
			if (HttpContext.Current.Request["Pay"] != null)
				model.Pay=Shop.Tools.RequestTool.RequestString("Pay");
			if (HttpContext.Current.Request["OnlinePay_id"] != null)
				model.OnlinePay_id=Shop.Tools.RequestTool.RequestInt("OnlinePay_id",0);
			if (HttpContext.Current.Request["OnlinePay"] != null)
				model.OnlinePay=Shop.Tools.RequestTool.RequestString("OnlinePay");
			if (HttpContext.Current.Request["OnlinePay_Code"] != null)
				model.OnlinePay_Code=Shop.Tools.RequestTool.RequestString("OnlinePay_Code");
			if (HttpContext.Current.Request["Money_Order"] != null)
				model.Money_Order=Shop.Tools.RequestTool.RequestDecimal("Money_Order",0);
			if (HttpContext.Current.Request["Money_Pay"] != null)
				model.Money_Pay=Shop.Tools.RequestTool.RequestDecimal("Money_Pay",0);
			if (HttpContext.Current.Request["Money_Product"] != null)
				model.Money_Product=Shop.Tools.RequestTool.RequestDecimal("Money_Product",0);
			if (HttpContext.Current.Request["Money_Transport"] != null)
				model.Money_Transport=Shop.Tools.RequestTool.RequestDecimal("Money_Transport",0);
			if (HttpContext.Current.Request["Money_Transport_Cut"] != null)
				model.Money_Transport_Cut=Shop.Tools.RequestTool.RequestDecimal("Money_Transport_Cut",0);
			if (HttpContext.Current.Request["Money_Bill"] != null)
				model.Money_Bill=Shop.Tools.RequestTool.RequestDecimal("Money_Bill",0);
			if (HttpContext.Current.Request["Money_Market"] != null)
				model.Money_Market=Shop.Tools.RequestTool.RequestDecimal("Money_Market",0);
			if (HttpContext.Current.Request["Money_Give"] != null)
				model.Money_Give=Shop.Tools.RequestTool.RequestDecimal("Money_Give",0);
			if (HttpContext.Current.Request["Money_Cut"] != null)
				model.Money_Cut=Shop.Tools.RequestTool.RequestDecimal("Money_Cut",0);
			if (HttpContext.Current.Request["Money_UserCut"] != null)
				model.Money_UserCut=Shop.Tools.RequestTool.RequestDecimal("Money_UserCut",0);
			if (HttpContext.Current.Request["Money_Cost"] != null)
				model.Money_Cost=Shop.Tools.RequestTool.RequestDecimal("Money_Cost",0);
			if (HttpContext.Current.Request["Money_Property"] != null)
				model.Money_Property=Shop.Tools.RequestTool.RequestDecimal("Money_Property",0);
			if (HttpContext.Current.Request["Money_UseCard311"] != null)
				model.Money_UseCard311=Shop.Tools.RequestTool.RequestDecimal("Money_UseCard311",0);
			if (HttpContext.Current.Request["Money_UseCard312"] != null)
				model.Money_UseCard312=Shop.Tools.RequestTool.RequestDecimal("Money_UseCard312",0);
			if (HttpContext.Current.Request["Money_fromorder"] != null)
				model.Money_fromorder=Shop.Tools.RequestTool.RequestDecimal("Money_fromorder",0);
			if (HttpContext.Current.Request["UseCardCode311"] != null)
				model.UseCardCode311=Shop.Tools.RequestTool.RequestString("UseCardCode311");
			if (HttpContext.Current.Request["UseCardCode312"] != null)
				model.UseCardCode312=Shop.Tools.RequestTool.RequestString("UseCardCode312");
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["Volume"] != null)
				model.Volume=Shop.Tools.RequestTool.RequestDecimal("Volume",0);
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["Point_Buy"] != null)
				model.Point_Buy=Shop.Tools.RequestTool.RequestDecimal("Point_Buy",0);
			if (HttpContext.Current.Request["Point_Product"] != null)
				model.Point_Product=Shop.Tools.RequestTool.RequestDecimal("Point_Product",0);
			if (HttpContext.Current.Request["Point_Free"] != null)
				model.Point_Free=Shop.Tools.RequestTool.RequestDecimal("Point_Free",0);
			if (HttpContext.Current.Request["Transport_Name"] != null)
				model.Transport_Name=Shop.Tools.RequestTool.RequestString("Transport_Name");
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Transport_Price_id"] != null)
				model.Transport_Price_id=Shop.Tools.RequestTool.RequestInt("Transport_Price_id",0);
			if (HttpContext.Current.Request["Transport_Code"] != null)
				model.Transport_Code=Shop.Tools.RequestTool.RequestString("Transport_Code");
			if (HttpContext.Current.Request["Transport_Mark"] != null)
				model.Transport_Mark=Shop.Tools.RequestTool.RequestString("Transport_Mark");
			if (HttpContext.Current.Request["EditMoney_Order"] != null)
				model.EditMoney_Order=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Order",0);
			if (HttpContext.Current.Request["EditMoney_Transport"] != null)
				model.EditMoney_Transport=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Transport",0);
			if (HttpContext.Current.Request["EditMoney_Discount"] != null)
				model.EditMoney_Discount=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Discount",0);
			if (HttpContext.Current.Request["IsVerified"] != null)
				model.IsVerified=Shop.Tools.RequestTool.RequestInt("IsVerified",0);
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["IsShipped"] != null)
				model.IsShipped=Shop.Tools.RequestTool.RequestInt("IsShipped",0);
			if (HttpContext.Current.Request["IsShipped_All"] != null)
				model.IsShipped_All=Shop.Tools.RequestTool.RequestInt("IsShipped_All",0);
			if (HttpContext.Current.Request["IsReceived"] != null)
				model.IsReceived=Shop.Tools.RequestTool.RequestInt("IsReceived",0);
			if (HttpContext.Current.Request["IsReceived_All"] != null)
				model.IsReceived_All=Shop.Tools.RequestTool.RequestInt("IsReceived_All",0);
			if (HttpContext.Current.Request["IsCompleted"] != null)
				model.IsCompleted=Shop.Tools.RequestTool.RequestInt("IsCompleted",0);
			if (HttpContext.Current.Request["IsInvalid"] != null)
				model.IsInvalid=Shop.Tools.RequestTool.RequestInt("IsInvalid",0);
			if (HttpContext.Current.Request["IsCreateCash"] != null)
				model.IsCreateCash=Shop.Tools.RequestTool.RequestInt("IsCreateCash",0);
			if (HttpContext.Current.Request["IsCreateNewOrder"] != null)
				model.IsCreateNewOrder=Shop.Tools.RequestTool.RequestInt("IsCreateNewOrder",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Verified"] != null)
				model.Time_Verified=Shop.Tools.RequestTool.RequestTime("Time_Verified", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Shipped"] != null)
				model.Time_Shipped=Shop.Tools.RequestTool.RequestTime("Time_Shipped", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Received"] != null)
				model.Time_Received=Shop.Tools.RequestTool.RequestTime("Time_Received", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Completed"] != null)
				model.Time_Completed=Shop.Tools.RequestTool.RequestTime("Time_Completed", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_CreateCash"] != null)
				model.Time_CreateCash=Shop.Tools.RequestTool.RequestTime("Time_CreateCash", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_CreateNewOrder"] != null)
				model.Time_CreateNewOrder=Shop.Tools.RequestTool.RequestTime("Time_CreateNewOrder", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark_Admin"] != null)
				model.Remark_Admin=Shop.Tools.RequestTool.RequestString("Remark_Admin");
			if (HttpContext.Current.Request["BillType_Name"] != null)
				model.BillType_Name=Shop.Tools.RequestTool.RequestString("BillType_Name");
			if (HttpContext.Current.Request["BillType_id"] != null)
				model.BillType_id=Shop.Tools.RequestTool.RequestInt("BillType_id",0);
			if (HttpContext.Current.Request["BillType_TaxRate"] != null)
				model.BillType_TaxRate=Shop.Tools.RequestTool.RequestDecimal("BillType_TaxRate",0);
			if (HttpContext.Current.Request["Type_id_OrderType"] != null)
				model.Type_id_OrderType=Shop.Tools.RequestTool.RequestInt("Type_id_OrderType",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["IsPrintExpress"] != null)
				model.IsPrintExpress=Shop.Tools.RequestTool.RequestInt("IsPrintExpress",0);
			if (HttpContext.Current.Request["Promotion_Type_ids"] != null)
				model.Promotion_Type_ids=Shop.Tools.RequestTool.RequestString("Promotion_Type_ids");
			if (HttpContext.Current.Request["Mark"] != null)
				model.Mark=Shop.Tools.RequestTool.RequestInt("Mark",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestString("Currency_Code");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestString("Currency_Msige");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Flag"] != null)
				model.Flag=Shop.Tools.RequestTool.RequestInt("Flag",0);
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["BLNo"] != null)
				model.BLNo=Shop.Tools.RequestTool.RequestString("BLNo");
			if (HttpContext.Current.Request["ContainerNo"] != null)
				model.ContainerNo=Shop.Tools.RequestTool.RequestString("ContainerNo");
			if (HttpContext.Current.Request["SealNo"] != null)
				model.SealNo=Shop.Tools.RequestTool.RequestString("SealNo");
			if (HttpContext.Current.Request["weixin_prepay_id"] != null)
				model.weixin_prepay_id=Shop.Tools.RequestTool.RequestString("weixin_prepay_id");
			if (HttpContext.Current.Request["IsSupplierCash"] != null)
				model.IsSupplierCash=Shop.Tools.RequestTool.RequestInt("IsSupplierCash",0);
			if (HttpContext.Current.Request["Money_OnlinepayFee"] != null)
				model.Money_OnlinepayFee=Shop.Tools.RequestTool.RequestDecimal("Money_OnlinepayFee",0);
			if (HttpContext.Current.Request["Site_id_pay"] != null)
				model.Site_id_pay=Shop.Tools.RequestTool.RequestInt("Site_id_pay",0);
			if (HttpContext.Current.Request["PickUp_id"] != null)
				model.PickUp_id=Shop.Tools.RequestTool.RequestInt("PickUp_id",0);
			if (HttpContext.Current.Request["PickUp_Name"] != null)
				model.PickUp_Name=Shop.Tools.RequestTool.RequestString("PickUp_Name");
			if (HttpContext.Current.Request["PickUp_Date"] != null)
				model.PickUp_Date=Shop.Tools.RequestTool.RequestTime("PickUp_Date", System.DateTime.Now);
			if (HttpContext.Current.Request["Refund_VAT"] != null)
				model.Refund_VAT=Shop.Tools.RequestTool.RequestDecimal("Refund_VAT",0);
			if (HttpContext.Current.Request["Refund_Fee"] != null)
				model.Refund_Fee=Shop.Tools.RequestTool.RequestDecimal("Refund_Fee",0);
			if (HttpContext.Current.Request["Language_id"] != null)
				model.Language_id=Shop.Tools.RequestTool.RequestInt("Language_id",0);
			if (HttpContext.Current.Request["Supplier_Delivery_id"] != null)
				model.Supplier_Delivery_id=Shop.Tools.RequestTool.RequestInt("Supplier_Delivery_id",0);
			if (HttpContext.Current.Request["IsRefund"] != null)
				model.IsRefund=Shop.Tools.RequestTool.RequestInt("IsRefund",0);
			if (HttpContext.Current.Request["Time_Refund"] != null)
				model.Time_Refund=Shop.Tools.RequestTool.RequestTime("Time_Refund", System.DateTime.Now);
			if (HttpContext.Current.Request["Promotion_Type_Name"] != null)
				model.Promotion_Type_Name=Shop.Tools.RequestTool.RequestString("Promotion_Type_Name");
			if (HttpContext.Current.Request["User_NickName"] != null)
				model.User_NickName=Shop.Tools.RequestTool.RequestString("User_NickName");
			if (HttpContext.Current.Request["Money_Paid"] != null)
				model.Money_Paid=Shop.Tools.RequestTool.RequestDecimal("Money_Paid",0);
			if (HttpContext.Current.Request["IsReserve"] != null)
				model.IsReserve=Shop.Tools.RequestTool.RequestInt("IsReserve",0);
			if (HttpContext.Current.Request["Money_fanxianpay"] != null)
				model.Money_fanxianpay=Shop.Tools.RequestTool.RequestDecimal("Money_fanxianpay",0);
			if (HttpContext.Current.Request["Money_Tax"] != null)
				model.Money_Tax=Shop.Tools.RequestTool.RequestDecimal("Money_Tax",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["DT_Money"] != null)
				model.DT_Money=Shop.Tools.RequestTool.RequestDecimal("DT_Money",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Order SafeBindForm(Lebi_Order model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["T_Name"] != null)
				model.T_Name=Shop.Tools.RequestTool.RequestSafeString("T_Name");
			if (HttpContext.Current.Request["T_Area_id"] != null)
				model.T_Area_id=Shop.Tools.RequestTool.RequestInt("T_Area_id",0);
			if (HttpContext.Current.Request["T_Address"] != null)
				model.T_Address=Shop.Tools.RequestTool.RequestSafeString("T_Address");
			if (HttpContext.Current.Request["T_Phone"] != null)
				model.T_Phone=Shop.Tools.RequestTool.RequestSafeString("T_Phone");
			if (HttpContext.Current.Request["T_MobilePhone"] != null)
				model.T_MobilePhone=Shop.Tools.RequestTool.RequestSafeString("T_MobilePhone");
			if (HttpContext.Current.Request["T_Postalcode"] != null)
				model.T_Postalcode=Shop.Tools.RequestTool.RequestSafeString("T_Postalcode");
			if (HttpContext.Current.Request["T_Email"] != null)
				model.T_Email=Shop.Tools.RequestTool.RequestSafeString("T_Email");
			if (HttpContext.Current.Request["Remark_User"] != null)
				model.Remark_User=Shop.Tools.RequestTool.RequestSafeString("Remark_User");
			if (HttpContext.Current.Request["Pay_id"] != null)
				model.Pay_id=Shop.Tools.RequestTool.RequestInt("Pay_id",0);
			if (HttpContext.Current.Request["Pay"] != null)
				model.Pay=Shop.Tools.RequestTool.RequestSafeString("Pay");
			if (HttpContext.Current.Request["OnlinePay_id"] != null)
				model.OnlinePay_id=Shop.Tools.RequestTool.RequestInt("OnlinePay_id",0);
			if (HttpContext.Current.Request["OnlinePay"] != null)
				model.OnlinePay=Shop.Tools.RequestTool.RequestSafeString("OnlinePay");
			if (HttpContext.Current.Request["OnlinePay_Code"] != null)
				model.OnlinePay_Code=Shop.Tools.RequestTool.RequestSafeString("OnlinePay_Code");
			if (HttpContext.Current.Request["Money_Order"] != null)
				model.Money_Order=Shop.Tools.RequestTool.RequestDecimal("Money_Order",0);
			if (HttpContext.Current.Request["Money_Pay"] != null)
				model.Money_Pay=Shop.Tools.RequestTool.RequestDecimal("Money_Pay",0);
			if (HttpContext.Current.Request["Money_Product"] != null)
				model.Money_Product=Shop.Tools.RequestTool.RequestDecimal("Money_Product",0);
			if (HttpContext.Current.Request["Money_Transport"] != null)
				model.Money_Transport=Shop.Tools.RequestTool.RequestDecimal("Money_Transport",0);
			if (HttpContext.Current.Request["Money_Transport_Cut"] != null)
				model.Money_Transport_Cut=Shop.Tools.RequestTool.RequestDecimal("Money_Transport_Cut",0);
			if (HttpContext.Current.Request["Money_Bill"] != null)
				model.Money_Bill=Shop.Tools.RequestTool.RequestDecimal("Money_Bill",0);
			if (HttpContext.Current.Request["Money_Market"] != null)
				model.Money_Market=Shop.Tools.RequestTool.RequestDecimal("Money_Market",0);
			if (HttpContext.Current.Request["Money_Give"] != null)
				model.Money_Give=Shop.Tools.RequestTool.RequestDecimal("Money_Give",0);
			if (HttpContext.Current.Request["Money_Cut"] != null)
				model.Money_Cut=Shop.Tools.RequestTool.RequestDecimal("Money_Cut",0);
			if (HttpContext.Current.Request["Money_UserCut"] != null)
				model.Money_UserCut=Shop.Tools.RequestTool.RequestDecimal("Money_UserCut",0);
			if (HttpContext.Current.Request["Money_Cost"] != null)
				model.Money_Cost=Shop.Tools.RequestTool.RequestDecimal("Money_Cost",0);
			if (HttpContext.Current.Request["Money_Property"] != null)
				model.Money_Property=Shop.Tools.RequestTool.RequestDecimal("Money_Property",0);
			if (HttpContext.Current.Request["Money_UseCard311"] != null)
				model.Money_UseCard311=Shop.Tools.RequestTool.RequestDecimal("Money_UseCard311",0);
			if (HttpContext.Current.Request["Money_UseCard312"] != null)
				model.Money_UseCard312=Shop.Tools.RequestTool.RequestDecimal("Money_UseCard312",0);
			if (HttpContext.Current.Request["Money_fromorder"] != null)
				model.Money_fromorder=Shop.Tools.RequestTool.RequestDecimal("Money_fromorder",0);
			if (HttpContext.Current.Request["UseCardCode311"] != null)
				model.UseCardCode311=Shop.Tools.RequestTool.RequestSafeString("UseCardCode311");
			if (HttpContext.Current.Request["UseCardCode312"] != null)
				model.UseCardCode312=Shop.Tools.RequestTool.RequestSafeString("UseCardCode312");
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["Volume"] != null)
				model.Volume=Shop.Tools.RequestTool.RequestDecimal("Volume",0);
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["Point_Buy"] != null)
				model.Point_Buy=Shop.Tools.RequestTool.RequestDecimal("Point_Buy",0);
			if (HttpContext.Current.Request["Point_Product"] != null)
				model.Point_Product=Shop.Tools.RequestTool.RequestDecimal("Point_Product",0);
			if (HttpContext.Current.Request["Point_Free"] != null)
				model.Point_Free=Shop.Tools.RequestTool.RequestDecimal("Point_Free",0);
			if (HttpContext.Current.Request["Transport_Name"] != null)
				model.Transport_Name=Shop.Tools.RequestTool.RequestSafeString("Transport_Name");
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Transport_Price_id"] != null)
				model.Transport_Price_id=Shop.Tools.RequestTool.RequestInt("Transport_Price_id",0);
			if (HttpContext.Current.Request["Transport_Code"] != null)
				model.Transport_Code=Shop.Tools.RequestTool.RequestSafeString("Transport_Code");
			if (HttpContext.Current.Request["Transport_Mark"] != null)
				model.Transport_Mark=Shop.Tools.RequestTool.RequestSafeString("Transport_Mark");
			if (HttpContext.Current.Request["EditMoney_Order"] != null)
				model.EditMoney_Order=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Order",0);
			if (HttpContext.Current.Request["EditMoney_Transport"] != null)
				model.EditMoney_Transport=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Transport",0);
			if (HttpContext.Current.Request["EditMoney_Discount"] != null)
				model.EditMoney_Discount=Shop.Tools.RequestTool.RequestDecimal("EditMoney_Discount",0);
			if (HttpContext.Current.Request["IsVerified"] != null)
				model.IsVerified=Shop.Tools.RequestTool.RequestInt("IsVerified",0);
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["IsShipped"] != null)
				model.IsShipped=Shop.Tools.RequestTool.RequestInt("IsShipped",0);
			if (HttpContext.Current.Request["IsShipped_All"] != null)
				model.IsShipped_All=Shop.Tools.RequestTool.RequestInt("IsShipped_All",0);
			if (HttpContext.Current.Request["IsReceived"] != null)
				model.IsReceived=Shop.Tools.RequestTool.RequestInt("IsReceived",0);
			if (HttpContext.Current.Request["IsReceived_All"] != null)
				model.IsReceived_All=Shop.Tools.RequestTool.RequestInt("IsReceived_All",0);
			if (HttpContext.Current.Request["IsCompleted"] != null)
				model.IsCompleted=Shop.Tools.RequestTool.RequestInt("IsCompleted",0);
			if (HttpContext.Current.Request["IsInvalid"] != null)
				model.IsInvalid=Shop.Tools.RequestTool.RequestInt("IsInvalid",0);
			if (HttpContext.Current.Request["IsCreateCash"] != null)
				model.IsCreateCash=Shop.Tools.RequestTool.RequestInt("IsCreateCash",0);
			if (HttpContext.Current.Request["IsCreateNewOrder"] != null)
				model.IsCreateNewOrder=Shop.Tools.RequestTool.RequestInt("IsCreateNewOrder",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Verified"] != null)
				model.Time_Verified=Shop.Tools.RequestTool.RequestTime("Time_Verified", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Shipped"] != null)
				model.Time_Shipped=Shop.Tools.RequestTool.RequestTime("Time_Shipped", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Received"] != null)
				model.Time_Received=Shop.Tools.RequestTool.RequestTime("Time_Received", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Completed"] != null)
				model.Time_Completed=Shop.Tools.RequestTool.RequestTime("Time_Completed", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_CreateCash"] != null)
				model.Time_CreateCash=Shop.Tools.RequestTool.RequestTime("Time_CreateCash", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_CreateNewOrder"] != null)
				model.Time_CreateNewOrder=Shop.Tools.RequestTool.RequestTime("Time_CreateNewOrder", System.DateTime.Now);
			if (HttpContext.Current.Request["Remark_Admin"] != null)
				model.Remark_Admin=Shop.Tools.RequestTool.RequestSafeString("Remark_Admin");
			if (HttpContext.Current.Request["BillType_Name"] != null)
				model.BillType_Name=Shop.Tools.RequestTool.RequestSafeString("BillType_Name");
			if (HttpContext.Current.Request["BillType_id"] != null)
				model.BillType_id=Shop.Tools.RequestTool.RequestInt("BillType_id",0);
			if (HttpContext.Current.Request["BillType_TaxRate"] != null)
				model.BillType_TaxRate=Shop.Tools.RequestTool.RequestDecimal("BillType_TaxRate",0);
			if (HttpContext.Current.Request["Type_id_OrderType"] != null)
				model.Type_id_OrderType=Shop.Tools.RequestTool.RequestInt("Type_id_OrderType",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["IsPrintExpress"] != null)
				model.IsPrintExpress=Shop.Tools.RequestTool.RequestInt("IsPrintExpress",0);
			if (HttpContext.Current.Request["Promotion_Type_ids"] != null)
				model.Promotion_Type_ids=Shop.Tools.RequestTool.RequestSafeString("Promotion_Type_ids");
			if (HttpContext.Current.Request["Mark"] != null)
				model.Mark=Shop.Tools.RequestTool.RequestInt("Mark",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestSafeString("Currency_Code");
			if (HttpContext.Current.Request["Currency_ExchangeRate"] != null)
				model.Currency_ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("Currency_ExchangeRate",0);
			if (HttpContext.Current.Request["Currency_Msige"] != null)
				model.Currency_Msige=Shop.Tools.RequestTool.RequestSafeString("Currency_Msige");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Flag"] != null)
				model.Flag=Shop.Tools.RequestTool.RequestInt("Flag",0);
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["BLNo"] != null)
				model.BLNo=Shop.Tools.RequestTool.RequestSafeString("BLNo");
			if (HttpContext.Current.Request["ContainerNo"] != null)
				model.ContainerNo=Shop.Tools.RequestTool.RequestSafeString("ContainerNo");
			if (HttpContext.Current.Request["SealNo"] != null)
				model.SealNo=Shop.Tools.RequestTool.RequestSafeString("SealNo");
			if (HttpContext.Current.Request["weixin_prepay_id"] != null)
				model.weixin_prepay_id=Shop.Tools.RequestTool.RequestSafeString("weixin_prepay_id");
			if (HttpContext.Current.Request["IsSupplierCash"] != null)
				model.IsSupplierCash=Shop.Tools.RequestTool.RequestInt("IsSupplierCash",0);
			if (HttpContext.Current.Request["Money_OnlinepayFee"] != null)
				model.Money_OnlinepayFee=Shop.Tools.RequestTool.RequestDecimal("Money_OnlinepayFee",0);
			if (HttpContext.Current.Request["Site_id_pay"] != null)
				model.Site_id_pay=Shop.Tools.RequestTool.RequestInt("Site_id_pay",0);
			if (HttpContext.Current.Request["PickUp_id"] != null)
				model.PickUp_id=Shop.Tools.RequestTool.RequestInt("PickUp_id",0);
			if (HttpContext.Current.Request["PickUp_Name"] != null)
				model.PickUp_Name=Shop.Tools.RequestTool.RequestSafeString("PickUp_Name");
			if (HttpContext.Current.Request["PickUp_Date"] != null)
				model.PickUp_Date=Shop.Tools.RequestTool.RequestTime("PickUp_Date", System.DateTime.Now);
			if (HttpContext.Current.Request["Refund_VAT"] != null)
				model.Refund_VAT=Shop.Tools.RequestTool.RequestDecimal("Refund_VAT",0);
			if (HttpContext.Current.Request["Refund_Fee"] != null)
				model.Refund_Fee=Shop.Tools.RequestTool.RequestDecimal("Refund_Fee",0);
			if (HttpContext.Current.Request["Language_id"] != null)
				model.Language_id=Shop.Tools.RequestTool.RequestInt("Language_id",0);
			if (HttpContext.Current.Request["Supplier_Delivery_id"] != null)
				model.Supplier_Delivery_id=Shop.Tools.RequestTool.RequestInt("Supplier_Delivery_id",0);
			if (HttpContext.Current.Request["IsRefund"] != null)
				model.IsRefund=Shop.Tools.RequestTool.RequestInt("IsRefund",0);
			if (HttpContext.Current.Request["Time_Refund"] != null)
				model.Time_Refund=Shop.Tools.RequestTool.RequestTime("Time_Refund", System.DateTime.Now);
			if (HttpContext.Current.Request["Promotion_Type_Name"] != null)
				model.Promotion_Type_Name=Shop.Tools.RequestTool.RequestSafeString("Promotion_Type_Name");
			if (HttpContext.Current.Request["User_NickName"] != null)
				model.User_NickName=Shop.Tools.RequestTool.RequestSafeString("User_NickName");
			if (HttpContext.Current.Request["Money_Paid"] != null)
				model.Money_Paid=Shop.Tools.RequestTool.RequestDecimal("Money_Paid",0);
			if (HttpContext.Current.Request["IsReserve"] != null)
				model.IsReserve=Shop.Tools.RequestTool.RequestInt("IsReserve",0);
			if (HttpContext.Current.Request["Money_fanxianpay"] != null)
				model.Money_fanxianpay=Shop.Tools.RequestTool.RequestDecimal("Money_fanxianpay",0);
			if (HttpContext.Current.Request["Money_Tax"] != null)
				model.Money_Tax=Shop.Tools.RequestTool.RequestDecimal("Money_Tax",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["DT_Money"] != null)
				model.DT_Money=Shop.Tools.RequestTool.RequestDecimal("DT_Money",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Order ReaderBind(IDataReader dataReader)
		{
			Lebi_Order model=new Lebi_Order();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			model.T_Name=dataReader["T_Name"].ToString();
			ojb = dataReader["T_Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.T_Area_id=(int)ojb;
			}
			model.T_Address=dataReader["T_Address"].ToString();
			model.T_Phone=dataReader["T_Phone"].ToString();
			model.T_MobilePhone=dataReader["T_MobilePhone"].ToString();
			model.T_Postalcode=dataReader["T_Postalcode"].ToString();
			model.T_Email=dataReader["T_Email"].ToString();
			model.Remark_User=dataReader["Remark_User"].ToString();
			ojb = dataReader["Pay_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pay_id=(int)ojb;
			}
			model.Pay=dataReader["Pay"].ToString();
			ojb = dataReader["OnlinePay_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OnlinePay_id=(int)ojb;
			}
			model.OnlinePay=dataReader["OnlinePay"].ToString();
			model.OnlinePay_Code=dataReader["OnlinePay_Code"].ToString();
			ojb = dataReader["Money_Order"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Order=(decimal)ojb;
			}
			ojb = dataReader["Money_Pay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Pay=(decimal)ojb;
			}
			ojb = dataReader["Money_Product"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Product=(decimal)ojb;
			}
			ojb = dataReader["Money_Transport"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Transport=(decimal)ojb;
			}
			ojb = dataReader["Money_Transport_Cut"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Transport_Cut=(decimal)ojb;
			}
			ojb = dataReader["Money_Bill"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Bill=(decimal)ojb;
			}
			ojb = dataReader["Money_Market"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Market=(decimal)ojb;
			}
			ojb = dataReader["Money_Give"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Give=(decimal)ojb;
			}
			ojb = dataReader["Money_Cut"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Cut=(decimal)ojb;
			}
			ojb = dataReader["Money_UserCut"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_UserCut=(decimal)ojb;
			}
			ojb = dataReader["Money_Cost"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Cost=(decimal)ojb;
			}
			ojb = dataReader["Money_Property"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Property=(decimal)ojb;
			}
			ojb = dataReader["Money_UseCard311"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_UseCard311=(decimal)ojb;
			}
			ojb = dataReader["Money_UseCard312"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_UseCard312=(decimal)ojb;
			}
			ojb = dataReader["Money_fromorder"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_fromorder=(decimal)ojb;
			}
			model.UseCardCode311=dataReader["UseCardCode311"].ToString();
			model.UseCardCode312=dataReader["UseCardCode312"].ToString();
			ojb = dataReader["Weight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight=(decimal)ojb;
			}
			ojb = dataReader["Volume"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Volume=(decimal)ojb;
			}
			ojb = dataReader["Point"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point=(decimal)ojb;
			}
			ojb = dataReader["Point_Buy"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Buy=(decimal)ojb;
			}
			ojb = dataReader["Point_Product"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Product=(decimal)ojb;
			}
			ojb = dataReader["Point_Free"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Free=(decimal)ojb;
			}
			model.Transport_Name=dataReader["Transport_Name"].ToString();
			ojb = dataReader["Transport_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Transport_id=(int)ojb;
			}
			ojb = dataReader["Transport_Price_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Transport_Price_id=(int)ojb;
			}
			model.Transport_Code=dataReader["Transport_Code"].ToString();
			model.Transport_Mark=dataReader["Transport_Mark"].ToString();
			ojb = dataReader["EditMoney_Order"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EditMoney_Order=(decimal)ojb;
			}
			ojb = dataReader["EditMoney_Transport"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EditMoney_Transport=(decimal)ojb;
			}
			ojb = dataReader["EditMoney_Discount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EditMoney_Discount=(decimal)ojb;
			}
			ojb = dataReader["IsVerified"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsVerified=(int)ojb;
			}
			ojb = dataReader["IsPaid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPaid=(int)ojb;
			}
			ojb = dataReader["IsShipped"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShipped=(int)ojb;
			}
			ojb = dataReader["IsShipped_All"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShipped_All=(int)ojb;
			}
			ojb = dataReader["IsReceived"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsReceived=(int)ojb;
			}
			ojb = dataReader["IsReceived_All"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsReceived_All=(int)ojb;
			}
			ojb = dataReader["IsCompleted"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCompleted=(int)ojb;
			}
			ojb = dataReader["IsInvalid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsInvalid=(int)ojb;
			}
			ojb = dataReader["IsCreateCash"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCreateCash=(int)ojb;
			}
			ojb = dataReader["IsCreateNewOrder"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCreateNewOrder=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Verified"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Verified=(DateTime)ojb;
			}
			ojb = dataReader["Time_Paid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Paid=(DateTime)ojb;
			}
			ojb = dataReader["Time_Shipped"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Shipped=(DateTime)ojb;
			}
			ojb = dataReader["Time_Received"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Received=(DateTime)ojb;
			}
			ojb = dataReader["Time_Completed"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Completed=(DateTime)ojb;
			}
			ojb = dataReader["Time_CreateCash"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_CreateCash=(DateTime)ojb;
			}
			ojb = dataReader["Time_CreateNewOrder"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_CreateNewOrder=(DateTime)ojb;
			}
			model.Remark_Admin=dataReader["Remark_Admin"].ToString();
			model.BillType_Name=dataReader["BillType_Name"].ToString();
			ojb = dataReader["BillType_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BillType_id=(int)ojb;
			}
			ojb = dataReader["BillType_TaxRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BillType_TaxRate=(decimal)ojb;
			}
			ojb = dataReader["Type_id_OrderType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_OrderType=(int)ojb;
			}
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			ojb = dataReader["IsPrintExpress"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPrintExpress=(int)ojb;
			}
			model.Promotion_Type_ids=dataReader["Promotion_Type_ids"].ToString();
			ojb = dataReader["Mark"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Mark=(int)ojb;
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
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["Flag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Flag=(int)ojb;
			}
			ojb = dataReader["Site_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Site_id=(int)ojb;
			}
			model.BLNo=dataReader["BLNo"].ToString();
			model.ContainerNo=dataReader["ContainerNo"].ToString();
			model.SealNo=dataReader["SealNo"].ToString();
			model.weixin_prepay_id=dataReader["weixin_prepay_id"].ToString();
			ojb = dataReader["IsSupplierCash"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSupplierCash=(int)ojb;
			}
			ojb = dataReader["Money_OnlinepayFee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_OnlinepayFee=(decimal)ojb;
			}
			ojb = dataReader["Site_id_pay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Site_id_pay=(int)ojb;
			}
			ojb = dataReader["PickUp_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PickUp_id=(int)ojb;
			}
			model.PickUp_Name=dataReader["PickUp_Name"].ToString();
			ojb = dataReader["PickUp_Date"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PickUp_Date=(DateTime)ojb;
			}
			ojb = dataReader["Refund_VAT"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Refund_VAT=(decimal)ojb;
			}
			ojb = dataReader["Refund_Fee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Refund_Fee=(decimal)ojb;
			}
			ojb = dataReader["Language_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Language_id=(int)ojb;
			}
			ojb = dataReader["Supplier_Delivery_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_Delivery_id=(int)ojb;
			}
			ojb = dataReader["IsRefund"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRefund=(int)ojb;
			}
			ojb = dataReader["Time_Refund"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Refund=(DateTime)ojb;
			}
			model.Promotion_Type_Name=dataReader["Promotion_Type_Name"].ToString();
			model.User_NickName=dataReader["User_NickName"].ToString();
			ojb = dataReader["Money_Paid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Paid=(decimal)ojb;
			}
			ojb = dataReader["IsReserve"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsReserve=(int)ojb;
			}
			ojb = dataReader["Money_fanxianpay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_fanxianpay=(decimal)ojb;
			}
			ojb = dataReader["Money_Tax"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Tax=(decimal)ojb;
			}
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			ojb = dataReader["DT_Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_Money=(decimal)ojb;
			}
			ojb = dataReader["IsDel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDel=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

