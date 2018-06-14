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

	public interface Lebi_Order_Product_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Order_Product model);
		void Update(Lebi_Order_Product model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Order_Product GetModel(int id);
		Lebi_Order_Product GetModel(string strWhere);
		Lebi_Order_Product GetModel(SQLPara para);
		List<Lebi_Order_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Order_Product> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Order_Product> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Order_Product> GetList(SQLPara para);
		Lebi_Order_Product BindForm(Lebi_Order_Product model);
		Lebi_Order_Product SafeBindForm(Lebi_Order_Product model);
		Lebi_Order_Product ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Order_Product。
	/// </summary>
	public class D_Lebi_Order_Product
	{
		static Lebi_Order_Product_interface _Instance;
		public static Lebi_Order_Product_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Order_Product();
		            else
		                _Instance = new sqlserver_Lebi_Order_Product();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Order_Product()
		{}
		#region  成员方法
	class sqlserver_Lebi_Order_Product : Lebi_Order_Product_interface
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
				strSql.Append("select " + colName + " from [Lebi_Order_Product]");
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
			strSql.Append("select  "+colName+" from [Lebi_Order_Product]");
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
			strSql.Append("select count(1) from [Lebi_Order_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Order_Product]");
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
			strSql.Append("select max(id) from [Lebi_Order_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Order_Product]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Order_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Order_Product](");
			strSql.Append("Product_id,Order_id,Order_Code,Product_Name,Product_Number,Count,Count_Shipped,Count_Received,Count_Return,Price,Money,Remark,Weight,ImageSmall,ImageMedium,ImageBig,ImageOriginal,Type_id_OrderProductType,Discount,Point,IsCommented,User_id,Time_Add,Price_Cost,Supplier_id,IsSupplierTransport,Volume,NetWeight,PackageRate,Units_id,Money_Card312_one,Point_Give_one,Money_Give_one,Point_Product,Pointagain,ProPerty134,Point_Buy_one,ProPerty_Price,IsPaid,IsStockOK,Time_Paid,Time_StockOK,Price_Reserve,IsPaidReserve,IsReserve,IsDel)");
			strSql.Append(" values (");
			strSql.Append("@Product_id,@Order_id,@Order_Code,@Product_Name,@Product_Number,@Count,@Count_Shipped,@Count_Received,@Count_Return,@Price,@Money,@Remark,@Weight,@ImageSmall,@ImageMedium,@ImageBig,@ImageOriginal,@Type_id_OrderProductType,@Discount,@Point,@IsCommented,@User_id,@Time_Add,@Price_Cost,@Supplier_id,@IsSupplierTransport,@Volume,@NetWeight,@PackageRate,@Units_id,@Money_Card312_one,@Point_Give_one,@Money_Give_one,@Point_Product,@Pointagain,@ProPerty134,@Point_Buy_one,@ProPerty_Price,@IsPaid,@IsStockOK,@Time_Paid,@Time_StockOK,@Price_Reserve,@IsPaidReserve,@IsReserve,@IsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@Product_id", model.Product_id),
					new SqlParameter("@Order_id", model.Order_id),
					new SqlParameter("@Order_Code", model.Order_Code),
					new SqlParameter("@Product_Name", model.Product_Name),
					new SqlParameter("@Product_Number", model.Product_Number),
					new SqlParameter("@Count", model.Count),
					new SqlParameter("@Count_Shipped", model.Count_Shipped),
					new SqlParameter("@Count_Received", model.Count_Received),
					new SqlParameter("@Count_Return", model.Count_Return),
					new SqlParameter("@Price", model.Price),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Weight", model.Weight),
					new SqlParameter("@ImageSmall", model.ImageSmall),
					new SqlParameter("@ImageMedium", model.ImageMedium),
					new SqlParameter("@ImageBig", model.ImageBig),
					new SqlParameter("@ImageOriginal", model.ImageOriginal),
					new SqlParameter("@Type_id_OrderProductType", model.Type_id_OrderProductType),
					new SqlParameter("@Discount", model.Discount),
					new SqlParameter("@Point", model.Point),
					new SqlParameter("@IsCommented", model.IsCommented),
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Price_Cost", model.Price_Cost),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@IsSupplierTransport", model.IsSupplierTransport),
					new SqlParameter("@Volume", model.Volume),
					new SqlParameter("@NetWeight", model.NetWeight),
					new SqlParameter("@PackageRate", model.PackageRate),
					new SqlParameter("@Units_id", model.Units_id),
					new SqlParameter("@Money_Card312_one", model.Money_Card312_one),
					new SqlParameter("@Point_Give_one", model.Point_Give_one),
					new SqlParameter("@Money_Give_one", model.Money_Give_one),
					new SqlParameter("@Point_Product", model.Point_Product),
					new SqlParameter("@Pointagain", model.Pointagain),
					new SqlParameter("@ProPerty134", model.ProPerty134),
					new SqlParameter("@Point_Buy_one", model.Point_Buy_one),
					new SqlParameter("@ProPerty_Price", model.ProPerty_Price),
					new SqlParameter("@IsPaid", model.IsPaid),
					new SqlParameter("@IsStockOK", model.IsStockOK),
					new SqlParameter("@Time_Paid", model.Time_Paid),
					new SqlParameter("@Time_StockOK", model.Time_StockOK),
					new SqlParameter("@Price_Reserve", model.Price_Reserve),
					new SqlParameter("@IsPaidReserve", model.IsPaidReserve),
					new SqlParameter("@IsReserve", model.IsReserve),
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
		public void Update(Lebi_Order_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Order_Product] set ");
			strSql.Append("Product_id= @Product_id,");
			strSql.Append("Order_id= @Order_id,");
			strSql.Append("Order_Code= @Order_Code,");
			strSql.Append("Product_Name= @Product_Name,");
			strSql.Append("Product_Number= @Product_Number,");
			strSql.Append("Count= @Count,");
			strSql.Append("Count_Shipped= @Count_Shipped,");
			strSql.Append("Count_Received= @Count_Received,");
			strSql.Append("Count_Return= @Count_Return,");
			strSql.Append("Price= @Price,");
			strSql.Append("Money= @Money,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Weight= @Weight,");
			strSql.Append("ImageSmall= @ImageSmall,");
			strSql.Append("ImageMedium= @ImageMedium,");
			strSql.Append("ImageBig= @ImageBig,");
			strSql.Append("ImageOriginal= @ImageOriginal,");
			strSql.Append("Type_id_OrderProductType= @Type_id_OrderProductType,");
			strSql.Append("Discount= @Discount,");
			strSql.Append("Point= @Point,");
			strSql.Append("IsCommented= @IsCommented,");
			strSql.Append("User_id= @User_id,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Price_Cost= @Price_Cost,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("IsSupplierTransport= @IsSupplierTransport,");
			strSql.Append("Volume= @Volume,");
			strSql.Append("NetWeight= @NetWeight,");
			strSql.Append("PackageRate= @PackageRate,");
			strSql.Append("Units_id= @Units_id,");
			strSql.Append("Money_Card312_one= @Money_Card312_one,");
			strSql.Append("Point_Give_one= @Point_Give_one,");
			strSql.Append("Money_Give_one= @Money_Give_one,");
			strSql.Append("Point_Product= @Point_Product,");
			strSql.Append("Pointagain= @Pointagain,");
			strSql.Append("ProPerty134= @ProPerty134,");
			strSql.Append("Point_Buy_one= @Point_Buy_one,");
			strSql.Append("ProPerty_Price= @ProPerty_Price,");
			strSql.Append("IsPaid= @IsPaid,");
			strSql.Append("IsStockOK= @IsStockOK,");
			strSql.Append("Time_Paid= @Time_Paid,");
			strSql.Append("Time_StockOK= @Time_StockOK,");
			strSql.Append("Price_Reserve= @Price_Reserve,");
			strSql.Append("IsPaidReserve= @IsPaidReserve,");
			strSql.Append("IsReserve= @IsReserve,");
			strSql.Append("IsDel= @IsDel");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Product_id", SqlDbType.Int,4),
					new SqlParameter("@Order_id", SqlDbType.Int,4),
					new SqlParameter("@Order_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Product_Name", SqlDbType.NVarChar,2000),
					new SqlParameter("@Product_Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@Count_Shipped", SqlDbType.Int,4),
					new SqlParameter("@Count_Received", SqlDbType.Int,4),
					new SqlParameter("@Count_Return", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@Remark", SqlDbType.NVarChar,2000),
					new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@ImageSmall", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageMedium", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageBig", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageOriginal", SqlDbType.NVarChar,200),
					new SqlParameter("@Type_id_OrderProductType", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Int,4),
					new SqlParameter("@Point", SqlDbType.Decimal,9),
					new SqlParameter("@IsCommented", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Price_Cost", SqlDbType.Decimal,9),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@IsSupplierTransport", SqlDbType.Int,4),
					new SqlParameter("@Volume", SqlDbType.Decimal,9),
					new SqlParameter("@NetWeight", SqlDbType.Decimal,9),
					new SqlParameter("@PackageRate", SqlDbType.Int,4),
					new SqlParameter("@Units_id", SqlDbType.Int,4),
					new SqlParameter("@Money_Card312_one", SqlDbType.Decimal,9),
					new SqlParameter("@Point_Give_one", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Give_one", SqlDbType.Decimal,9),
					new SqlParameter("@Point_Product", SqlDbType.Decimal,9),
					new SqlParameter("@Pointagain", SqlDbType.Int,4),
					new SqlParameter("@ProPerty134", SqlDbType.NVarChar,2000),
					new SqlParameter("@Point_Buy_one", SqlDbType.Decimal,9),
					new SqlParameter("@ProPerty_Price", SqlDbType.Decimal,9),
					new SqlParameter("@IsPaid", SqlDbType.Int,4),
					new SqlParameter("@IsStockOK", SqlDbType.Int,4),
					new SqlParameter("@Time_Paid", SqlDbType.DateTime),
					new SqlParameter("@Time_StockOK", SqlDbType.DateTime),
					new SqlParameter("@Price_Reserve", SqlDbType.Decimal,9),
					new SqlParameter("@IsPaidReserve", SqlDbType.Int,4),
					new SqlParameter("@IsReserve", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Product_id;
			parameters[2].Value = model.Order_id;
			parameters[3].Value = model.Order_Code;
			parameters[4].Value = model.Product_Name;
			parameters[5].Value = model.Product_Number;
			parameters[6].Value = model.Count;
			parameters[7].Value = model.Count_Shipped;
			parameters[8].Value = model.Count_Received;
			parameters[9].Value = model.Count_Return;
			parameters[10].Value = model.Price;
			parameters[11].Value = model.Money;
			parameters[12].Value = model.Remark;
			parameters[13].Value = model.Weight;
			parameters[14].Value = model.ImageSmall;
			parameters[15].Value = model.ImageMedium;
			parameters[16].Value = model.ImageBig;
			parameters[17].Value = model.ImageOriginal;
			parameters[18].Value = model.Type_id_OrderProductType;
			parameters[19].Value = model.Discount;
			parameters[20].Value = model.Point;
			parameters[21].Value = model.IsCommented;
			parameters[22].Value = model.User_id;
			parameters[23].Value = model.Time_Add;
			parameters[24].Value = model.Price_Cost;
			parameters[25].Value = model.Supplier_id;
			parameters[26].Value = model.IsSupplierTransport;
			parameters[27].Value = model.Volume;
			parameters[28].Value = model.NetWeight;
			parameters[29].Value = model.PackageRate;
			parameters[30].Value = model.Units_id;
			parameters[31].Value = model.Money_Card312_one;
			parameters[32].Value = model.Point_Give_one;
			parameters[33].Value = model.Money_Give_one;
			parameters[34].Value = model.Point_Product;
			parameters[35].Value = model.Pointagain;
			parameters[36].Value = model.ProPerty134;
			parameters[37].Value = model.Point_Buy_one;
			parameters[38].Value = model.ProPerty_Price;
			parameters[39].Value = model.IsPaid;
			parameters[40].Value = model.IsStockOK;
			parameters[41].Value = model.Time_Paid;
			parameters[42].Value = model.Time_StockOK;
			parameters[43].Value = model.Price_Reserve;
			parameters[44].Value = model.IsPaidReserve;
			parameters[45].Value = model.IsReserve;
			parameters[46].Value = model.IsDel;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order_Product] ");
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
			strSql.Append("delete from [Lebi_Order_Product] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Order_Product GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order_Product] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Order_Product model=new Lebi_Order_Product();
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
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				model.Product_Name=ds.Tables[0].Rows[0]["Product_Name"].ToString();
				model.Product_Number=ds.Tables[0].Rows[0]["Product_Number"].ToString();
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Shipped"].ToString()!="")
				{
					model.Count_Shipped=int.Parse(ds.Tables[0].Rows[0]["Count_Shipped"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Received"].ToString()!="")
				{
					model.Count_Received=int.Parse(ds.Tables[0].Rows[0]["Count_Received"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Return"].ToString()!="")
				{
					model.Count_Return=int.Parse(ds.Tables[0].Rows[0]["Count_Return"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Weight"].ToString()!="")
				{
					model.Weight=decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
				}
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_OrderProductType"].ToString()!="")
				{
					model.Type_id_OrderProductType=int.Parse(ds.Tables[0].Rows[0]["Type_id_OrderProductType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Discount"].ToString()!="")
				{
					model.Discount=int.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point"].ToString()!="")
				{
					model.Point=decimal.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCommented"].ToString()!="")
				{
					model.IsCommented=int.Parse(ds.Tables[0].Rows[0]["IsCommented"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Cost"].ToString()!="")
				{
					model.Price_Cost=decimal.Parse(ds.Tables[0].Rows[0]["Price_Cost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString()!="")
				{
					model.IsSupplierTransport=int.Parse(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Volume"].ToString()!="")
				{
					model.Volume=decimal.Parse(ds.Tables[0].Rows[0]["Volume"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NetWeight"].ToString()!="")
				{
					model.NetWeight=decimal.Parse(ds.Tables[0].Rows[0]["NetWeight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PackageRate"].ToString()!="")
				{
					model.PackageRate=int.Parse(ds.Tables[0].Rows[0]["PackageRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Units_id"].ToString()!="")
				{
					model.Units_id=int.Parse(ds.Tables[0].Rows[0]["Units_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Card312_one"].ToString()!="")
				{
					model.Money_Card312_one=decimal.Parse(ds.Tables[0].Rows[0]["Money_Card312_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Give_one"].ToString()!="")
				{
					model.Point_Give_one=decimal.Parse(ds.Tables[0].Rows[0]["Point_Give_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Give_one"].ToString()!="")
				{
					model.Money_Give_one=decimal.Parse(ds.Tables[0].Rows[0]["Money_Give_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Product"].ToString()!="")
				{
					model.Point_Product=decimal.Parse(ds.Tables[0].Rows[0]["Point_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pointagain"].ToString()!="")
				{
					model.Pointagain=int.Parse(ds.Tables[0].Rows[0]["Pointagain"].ToString());
				}
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				if(ds.Tables[0].Rows[0]["Point_Buy_one"].ToString()!="")
				{
					model.Point_Buy_one=decimal.Parse(ds.Tables[0].Rows[0]["Point_Buy_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString()!="")
				{
					model.ProPerty_Price=decimal.Parse(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPaid"].ToString()!="")
				{
					model.IsPaid=int.Parse(ds.Tables[0].Rows[0]["IsPaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsStockOK"].ToString()!="")
				{
					model.IsStockOK=int.Parse(ds.Tables[0].Rows[0]["IsStockOK"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Paid"].ToString()!="")
				{
					model.Time_Paid=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Paid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_StockOK"].ToString()!="")
				{
					model.Time_StockOK=DateTime.Parse(ds.Tables[0].Rows[0]["Time_StockOK"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Reserve"].ToString()!="")
				{
					model.Price_Reserve=decimal.Parse(ds.Tables[0].Rows[0]["Price_Reserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPaidReserve"].ToString()!="")
				{
					model.IsPaidReserve=int.Parse(ds.Tables[0].Rows[0]["IsPaidReserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReserve"].ToString()!="")
				{
					model.IsReserve=int.Parse(ds.Tables[0].Rows[0]["IsReserve"].ToString());
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
		public Lebi_Order_Product GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order_Product] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Order_Product model=new Lebi_Order_Product();
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
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				model.Product_Name=ds.Tables[0].Rows[0]["Product_Name"].ToString();
				model.Product_Number=ds.Tables[0].Rows[0]["Product_Number"].ToString();
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Shipped"].ToString()!="")
				{
					model.Count_Shipped=int.Parse(ds.Tables[0].Rows[0]["Count_Shipped"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Received"].ToString()!="")
				{
					model.Count_Received=int.Parse(ds.Tables[0].Rows[0]["Count_Received"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Return"].ToString()!="")
				{
					model.Count_Return=int.Parse(ds.Tables[0].Rows[0]["Count_Return"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Weight"].ToString()!="")
				{
					model.Weight=decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
				}
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_OrderProductType"].ToString()!="")
				{
					model.Type_id_OrderProductType=int.Parse(ds.Tables[0].Rows[0]["Type_id_OrderProductType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Discount"].ToString()!="")
				{
					model.Discount=int.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point"].ToString()!="")
				{
					model.Point=decimal.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCommented"].ToString()!="")
				{
					model.IsCommented=int.Parse(ds.Tables[0].Rows[0]["IsCommented"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Cost"].ToString()!="")
				{
					model.Price_Cost=decimal.Parse(ds.Tables[0].Rows[0]["Price_Cost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString()!="")
				{
					model.IsSupplierTransport=int.Parse(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Volume"].ToString()!="")
				{
					model.Volume=decimal.Parse(ds.Tables[0].Rows[0]["Volume"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NetWeight"].ToString()!="")
				{
					model.NetWeight=decimal.Parse(ds.Tables[0].Rows[0]["NetWeight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PackageRate"].ToString()!="")
				{
					model.PackageRate=int.Parse(ds.Tables[0].Rows[0]["PackageRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Units_id"].ToString()!="")
				{
					model.Units_id=int.Parse(ds.Tables[0].Rows[0]["Units_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Card312_one"].ToString()!="")
				{
					model.Money_Card312_one=decimal.Parse(ds.Tables[0].Rows[0]["Money_Card312_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Give_one"].ToString()!="")
				{
					model.Point_Give_one=decimal.Parse(ds.Tables[0].Rows[0]["Point_Give_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Give_one"].ToString()!="")
				{
					model.Money_Give_one=decimal.Parse(ds.Tables[0].Rows[0]["Money_Give_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Product"].ToString()!="")
				{
					model.Point_Product=decimal.Parse(ds.Tables[0].Rows[0]["Point_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pointagain"].ToString()!="")
				{
					model.Pointagain=int.Parse(ds.Tables[0].Rows[0]["Pointagain"].ToString());
				}
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				if(ds.Tables[0].Rows[0]["Point_Buy_one"].ToString()!="")
				{
					model.Point_Buy_one=decimal.Parse(ds.Tables[0].Rows[0]["Point_Buy_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString()!="")
				{
					model.ProPerty_Price=decimal.Parse(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPaid"].ToString()!="")
				{
					model.IsPaid=int.Parse(ds.Tables[0].Rows[0]["IsPaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsStockOK"].ToString()!="")
				{
					model.IsStockOK=int.Parse(ds.Tables[0].Rows[0]["IsStockOK"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Paid"].ToString()!="")
				{
					model.Time_Paid=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Paid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_StockOK"].ToString()!="")
				{
					model.Time_StockOK=DateTime.Parse(ds.Tables[0].Rows[0]["Time_StockOK"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Reserve"].ToString()!="")
				{
					model.Price_Reserve=decimal.Parse(ds.Tables[0].Rows[0]["Price_Reserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPaidReserve"].ToString()!="")
				{
					model.IsPaidReserve=int.Parse(ds.Tables[0].Rows[0]["IsPaidReserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReserve"].ToString()!="")
				{
					model.IsReserve=int.Parse(ds.Tables[0].Rows[0]["IsReserve"].ToString());
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
		public Lebi_Order_Product GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Order_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Order_Product model=new Lebi_Order_Product();
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
				if(ds.Tables[0].Rows[0]["Order_id"].ToString()!="")
				{
					model.Order_id=int.Parse(ds.Tables[0].Rows[0]["Order_id"].ToString());
				}
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
				model.Product_Name=ds.Tables[0].Rows[0]["Product_Name"].ToString();
				model.Product_Number=ds.Tables[0].Rows[0]["Product_Number"].ToString();
				if(ds.Tables[0].Rows[0]["Count"].ToString()!="")
				{
					model.Count=int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Shipped"].ToString()!="")
				{
					model.Count_Shipped=int.Parse(ds.Tables[0].Rows[0]["Count_Shipped"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Received"].ToString()!="")
				{
					model.Count_Received=int.Parse(ds.Tables[0].Rows[0]["Count_Received"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Return"].ToString()!="")
				{
					model.Count_Return=int.Parse(ds.Tables[0].Rows[0]["Count_Return"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Weight"].ToString()!="")
				{
					model.Weight=decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
				}
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_OrderProductType"].ToString()!="")
				{
					model.Type_id_OrderProductType=int.Parse(ds.Tables[0].Rows[0]["Type_id_OrderProductType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Discount"].ToString()!="")
				{
					model.Discount=int.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point"].ToString()!="")
				{
					model.Point=decimal.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCommented"].ToString()!="")
				{
					model.IsCommented=int.Parse(ds.Tables[0].Rows[0]["IsCommented"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Cost"].ToString()!="")
				{
					model.Price_Cost=decimal.Parse(ds.Tables[0].Rows[0]["Price_Cost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString()!="")
				{
					model.IsSupplierTransport=int.Parse(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Volume"].ToString()!="")
				{
					model.Volume=decimal.Parse(ds.Tables[0].Rows[0]["Volume"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NetWeight"].ToString()!="")
				{
					model.NetWeight=decimal.Parse(ds.Tables[0].Rows[0]["NetWeight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PackageRate"].ToString()!="")
				{
					model.PackageRate=int.Parse(ds.Tables[0].Rows[0]["PackageRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Units_id"].ToString()!="")
				{
					model.Units_id=int.Parse(ds.Tables[0].Rows[0]["Units_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Card312_one"].ToString()!="")
				{
					model.Money_Card312_one=decimal.Parse(ds.Tables[0].Rows[0]["Money_Card312_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Give_one"].ToString()!="")
				{
					model.Point_Give_one=decimal.Parse(ds.Tables[0].Rows[0]["Point_Give_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Give_one"].ToString()!="")
				{
					model.Money_Give_one=decimal.Parse(ds.Tables[0].Rows[0]["Money_Give_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Point_Product"].ToString()!="")
				{
					model.Point_Product=decimal.Parse(ds.Tables[0].Rows[0]["Point_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pointagain"].ToString()!="")
				{
					model.Pointagain=int.Parse(ds.Tables[0].Rows[0]["Pointagain"].ToString());
				}
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				if(ds.Tables[0].Rows[0]["Point_Buy_one"].ToString()!="")
				{
					model.Point_Buy_one=decimal.Parse(ds.Tables[0].Rows[0]["Point_Buy_one"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString()!="")
				{
					model.ProPerty_Price=decimal.Parse(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPaid"].ToString()!="")
				{
					model.IsPaid=int.Parse(ds.Tables[0].Rows[0]["IsPaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsStockOK"].ToString()!="")
				{
					model.IsStockOK=int.Parse(ds.Tables[0].Rows[0]["IsStockOK"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Paid"].ToString()!="")
				{
					model.Time_Paid=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Paid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_StockOK"].ToString()!="")
				{
					model.Time_StockOK=DateTime.Parse(ds.Tables[0].Rows[0]["Time_StockOK"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Reserve"].ToString()!="")
				{
					model.Price_Reserve=decimal.Parse(ds.Tables[0].Rows[0]["Price_Reserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPaidReserve"].ToString()!="")
				{
					model.IsPaidReserve=int.Parse(ds.Tables[0].Rows[0]["IsPaidReserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReserve"].ToString()!="")
				{
					model.IsReserve=int.Parse(ds.Tables[0].Rows[0]["IsReserve"].ToString());
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
		public List<Lebi_Order_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Order_Product]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Order_Product> list = new List<Lebi_Order_Product>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Order_Product> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Order_Product]";
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
			List<Lebi_Order_Product> list = new List<Lebi_Order_Product>();
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
		public List<Lebi_Order_Product> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Order_Product] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Order_Product> list = new List<Lebi_Order_Product>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Order_Product> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Order_Product]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Order_Product> list = new List<Lebi_Order_Product>();
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
		public Lebi_Order_Product BindForm(Lebi_Order_Product model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["Product_Name"] != null)
				model.Product_Name=Shop.Tools.RequestTool.RequestString("Product_Name");
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestString("Product_Number");
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["Count_Shipped"] != null)
				model.Count_Shipped=Shop.Tools.RequestTool.RequestInt("Count_Shipped",0);
			if (HttpContext.Current.Request["Count_Received"] != null)
				model.Count_Received=Shop.Tools.RequestTool.RequestInt("Count_Received",0);
			if (HttpContext.Current.Request["Count_Return"] != null)
				model.Count_Return=Shop.Tools.RequestTool.RequestInt("Count_Return",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestString("ImageOriginal");
			if (HttpContext.Current.Request["Type_id_OrderProductType"] != null)
				model.Type_id_OrderProductType=Shop.Tools.RequestTool.RequestInt("Type_id_OrderProductType",0);
			if (HttpContext.Current.Request["Discount"] != null)
				model.Discount=Shop.Tools.RequestTool.RequestInt("Discount",0);
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["IsCommented"] != null)
				model.IsCommented=Shop.Tools.RequestTool.RequestInt("IsCommented",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Price_Cost"] != null)
				model.Price_Cost=Shop.Tools.RequestTool.RequestDecimal("Price_Cost",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["Volume"] != null)
				model.Volume=Shop.Tools.RequestTool.RequestDecimal("Volume",0);
			if (HttpContext.Current.Request["NetWeight"] != null)
				model.NetWeight=Shop.Tools.RequestTool.RequestDecimal("NetWeight",0);
			if (HttpContext.Current.Request["PackageRate"] != null)
				model.PackageRate=Shop.Tools.RequestTool.RequestInt("PackageRate",0);
			if (HttpContext.Current.Request["Units_id"] != null)
				model.Units_id=Shop.Tools.RequestTool.RequestInt("Units_id",0);
			if (HttpContext.Current.Request["Money_Card312_one"] != null)
				model.Money_Card312_one=Shop.Tools.RequestTool.RequestDecimal("Money_Card312_one",0);
			if (HttpContext.Current.Request["Point_Give_one"] != null)
				model.Point_Give_one=Shop.Tools.RequestTool.RequestDecimal("Point_Give_one",0);
			if (HttpContext.Current.Request["Money_Give_one"] != null)
				model.Money_Give_one=Shop.Tools.RequestTool.RequestDecimal("Money_Give_one",0);
			if (HttpContext.Current.Request["Point_Product"] != null)
				model.Point_Product=Shop.Tools.RequestTool.RequestDecimal("Point_Product",0);
			if (HttpContext.Current.Request["Pointagain"] != null)
				model.Pointagain=Shop.Tools.RequestTool.RequestInt("Pointagain",0);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestString("ProPerty134");
			if (HttpContext.Current.Request["Point_Buy_one"] != null)
				model.Point_Buy_one=Shop.Tools.RequestTool.RequestDecimal("Point_Buy_one",0);
			if (HttpContext.Current.Request["ProPerty_Price"] != null)
				model.ProPerty_Price=Shop.Tools.RequestTool.RequestDecimal("ProPerty_Price",0);
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["IsStockOK"] != null)
				model.IsStockOK=Shop.Tools.RequestTool.RequestInt("IsStockOK",0);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_StockOK"] != null)
				model.Time_StockOK=Shop.Tools.RequestTool.RequestTime("Time_StockOK", System.DateTime.Now);
			if (HttpContext.Current.Request["Price_Reserve"] != null)
				model.Price_Reserve=Shop.Tools.RequestTool.RequestDecimal("Price_Reserve",0);
			if (HttpContext.Current.Request["IsPaidReserve"] != null)
				model.IsPaidReserve=Shop.Tools.RequestTool.RequestInt("IsPaidReserve",0);
			if (HttpContext.Current.Request["IsReserve"] != null)
				model.IsReserve=Shop.Tools.RequestTool.RequestInt("IsReserve",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Order_Product SafeBindForm(Lebi_Order_Product model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["Product_Name"] != null)
				model.Product_Name=Shop.Tools.RequestTool.RequestSafeString("Product_Name");
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestSafeString("Product_Number");
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["Count_Shipped"] != null)
				model.Count_Shipped=Shop.Tools.RequestTool.RequestInt("Count_Shipped",0);
			if (HttpContext.Current.Request["Count_Received"] != null)
				model.Count_Received=Shop.Tools.RequestTool.RequestInt("Count_Received",0);
			if (HttpContext.Current.Request["Count_Return"] != null)
				model.Count_Return=Shop.Tools.RequestTool.RequestInt("Count_Return",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestSafeString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestSafeString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestSafeString("ImageOriginal");
			if (HttpContext.Current.Request["Type_id_OrderProductType"] != null)
				model.Type_id_OrderProductType=Shop.Tools.RequestTool.RequestInt("Type_id_OrderProductType",0);
			if (HttpContext.Current.Request["Discount"] != null)
				model.Discount=Shop.Tools.RequestTool.RequestInt("Discount",0);
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["IsCommented"] != null)
				model.IsCommented=Shop.Tools.RequestTool.RequestInt("IsCommented",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Price_Cost"] != null)
				model.Price_Cost=Shop.Tools.RequestTool.RequestDecimal("Price_Cost",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["Volume"] != null)
				model.Volume=Shop.Tools.RequestTool.RequestDecimal("Volume",0);
			if (HttpContext.Current.Request["NetWeight"] != null)
				model.NetWeight=Shop.Tools.RequestTool.RequestDecimal("NetWeight",0);
			if (HttpContext.Current.Request["PackageRate"] != null)
				model.PackageRate=Shop.Tools.RequestTool.RequestInt("PackageRate",0);
			if (HttpContext.Current.Request["Units_id"] != null)
				model.Units_id=Shop.Tools.RequestTool.RequestInt("Units_id",0);
			if (HttpContext.Current.Request["Money_Card312_one"] != null)
				model.Money_Card312_one=Shop.Tools.RequestTool.RequestDecimal("Money_Card312_one",0);
			if (HttpContext.Current.Request["Point_Give_one"] != null)
				model.Point_Give_one=Shop.Tools.RequestTool.RequestDecimal("Point_Give_one",0);
			if (HttpContext.Current.Request["Money_Give_one"] != null)
				model.Money_Give_one=Shop.Tools.RequestTool.RequestDecimal("Money_Give_one",0);
			if (HttpContext.Current.Request["Point_Product"] != null)
				model.Point_Product=Shop.Tools.RequestTool.RequestDecimal("Point_Product",0);
			if (HttpContext.Current.Request["Pointagain"] != null)
				model.Pointagain=Shop.Tools.RequestTool.RequestInt("Pointagain",0);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestSafeString("ProPerty134");
			if (HttpContext.Current.Request["Point_Buy_one"] != null)
				model.Point_Buy_one=Shop.Tools.RequestTool.RequestDecimal("Point_Buy_one",0);
			if (HttpContext.Current.Request["ProPerty_Price"] != null)
				model.ProPerty_Price=Shop.Tools.RequestTool.RequestDecimal("ProPerty_Price",0);
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["IsStockOK"] != null)
				model.IsStockOK=Shop.Tools.RequestTool.RequestInt("IsStockOK",0);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_StockOK"] != null)
				model.Time_StockOK=Shop.Tools.RequestTool.RequestTime("Time_StockOK", System.DateTime.Now);
			if (HttpContext.Current.Request["Price_Reserve"] != null)
				model.Price_Reserve=Shop.Tools.RequestTool.RequestDecimal("Price_Reserve",0);
			if (HttpContext.Current.Request["IsPaidReserve"] != null)
				model.IsPaidReserve=Shop.Tools.RequestTool.RequestInt("IsPaidReserve",0);
			if (HttpContext.Current.Request["IsReserve"] != null)
				model.IsReserve=Shop.Tools.RequestTool.RequestInt("IsReserve",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Order_Product ReaderBind(IDataReader dataReader)
		{
			Lebi_Order_Product model=new Lebi_Order_Product();
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
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			model.Product_Name=dataReader["Product_Name"].ToString();
			model.Product_Number=dataReader["Product_Number"].ToString();
			ojb = dataReader["Count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count=(int)ojb;
			}
			ojb = dataReader["Count_Shipped"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Shipped=(int)ojb;
			}
			ojb = dataReader["Count_Received"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Received=(int)ojb;
			}
			ojb = dataReader["Count_Return"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Return=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Weight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight=(decimal)ojb;
			}
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.ImageMedium=dataReader["ImageMedium"].ToString();
			model.ImageBig=dataReader["ImageBig"].ToString();
			model.ImageOriginal=dataReader["ImageOriginal"].ToString();
			ojb = dataReader["Type_id_OrderProductType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_OrderProductType=(int)ojb;
			}
			ojb = dataReader["Discount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Discount=(int)ojb;
			}
			ojb = dataReader["Point"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point=(decimal)ojb;
			}
			ojb = dataReader["IsCommented"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCommented=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Price_Cost"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Cost=(decimal)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["IsSupplierTransport"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSupplierTransport=(int)ojb;
			}
			ojb = dataReader["Volume"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Volume=(decimal)ojb;
			}
			ojb = dataReader["NetWeight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NetWeight=(decimal)ojb;
			}
			ojb = dataReader["PackageRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PackageRate=(int)ojb;
			}
			ojb = dataReader["Units_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Units_id=(int)ojb;
			}
			ojb = dataReader["Money_Card312_one"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Card312_one=(decimal)ojb;
			}
			ojb = dataReader["Point_Give_one"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Give_one=(decimal)ojb;
			}
			ojb = dataReader["Money_Give_one"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Give_one=(decimal)ojb;
			}
			ojb = dataReader["Point_Product"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Product=(decimal)ojb;
			}
			ojb = dataReader["Pointagain"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pointagain=(int)ojb;
			}
			model.ProPerty134=dataReader["ProPerty134"].ToString();
			ojb = dataReader["Point_Buy_one"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Buy_one=(decimal)ojb;
			}
			ojb = dataReader["ProPerty_Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProPerty_Price=(decimal)ojb;
			}
			ojb = dataReader["IsPaid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPaid=(int)ojb;
			}
			ojb = dataReader["IsStockOK"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsStockOK=(int)ojb;
			}
			ojb = dataReader["Time_Paid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Paid=(DateTime)ojb;
			}
			ojb = dataReader["Time_StockOK"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_StockOK=(DateTime)ojb;
			}
			ojb = dataReader["Price_Reserve"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Reserve=(decimal)ojb;
			}
			ojb = dataReader["IsPaidReserve"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPaidReserve=(int)ojb;
			}
			ojb = dataReader["IsReserve"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsReserve=(int)ojb;
			}
			ojb = dataReader["IsDel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDel=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Order_Product : Lebi_Order_Product_interface
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
				strSql.Append("select " + colName + " from [Lebi_Order_Product]");
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
			strSql.Append("select  "+colName+" from [Lebi_Order_Product]");
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
			strSql.Append("select count(*) from [Lebi_Order_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Order_Product]");
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
			strSql.Append("select max(id) from [Lebi_Order_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Order_Product]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Order_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Order_Product](");
			strSql.Append("[Product_id],[Order_id],[Order_Code],[Product_Name],[Product_Number],[Count],[Count_Shipped],[Count_Received],[Count_Return],[Price],[Money],[Remark],[Weight],[ImageSmall],[ImageMedium],[ImageBig],[ImageOriginal],[Type_id_OrderProductType],[Discount],[Point],[IsCommented],[User_id],[Time_Add],[Price_Cost],[Supplier_id],[IsSupplierTransport],[Volume],[NetWeight],[PackageRate],[Units_id],[Money_Card312_one],[Point_Give_one],[Money_Give_one],[Point_Product],[Pointagain],[ProPerty134],[Point_Buy_one],[ProPerty_Price],[IsPaid],[IsStockOK],[Time_Paid],[Time_StockOK],[Price_Reserve],[IsPaidReserve],[IsReserve],[IsDel])");
			strSql.Append(" values (");
			strSql.Append("@Product_id,@Order_id,@Order_Code,@Product_Name,@Product_Number,@Count,@Count_Shipped,@Count_Received,@Count_Return,@Price,@Money,@Remark,@Weight,@ImageSmall,@ImageMedium,@ImageBig,@ImageOriginal,@Type_id_OrderProductType,@Discount,@Point,@IsCommented,@User_id,@Time_Add,@Price_Cost,@Supplier_id,@IsSupplierTransport,@Volume,@NetWeight,@PackageRate,@Units_id,@Money_Card312_one,@Point_Give_one,@Money_Give_one,@Point_Product,@Pointagain,@ProPerty134,@Point_Buy_one,@ProPerty_Price,@IsPaid,@IsStockOK,@Time_Paid,@Time_StockOK,@Price_Reserve,@IsPaidReserve,@IsReserve,@IsDel)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@Product_Name", model.Product_Name),
					new OleDbParameter("@Product_Number", model.Product_Number),
					new OleDbParameter("@Count", model.Count),
					new OleDbParameter("@Count_Shipped", model.Count_Shipped),
					new OleDbParameter("@Count_Received", model.Count_Received),
					new OleDbParameter("@Count_Return", model.Count_Return),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Weight", model.Weight),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@ImageMedium", model.ImageMedium),
					new OleDbParameter("@ImageBig", model.ImageBig),
					new OleDbParameter("@ImageOriginal", model.ImageOriginal),
					new OleDbParameter("@Type_id_OrderProductType", model.Type_id_OrderProductType),
					new OleDbParameter("@Discount", model.Discount),
					new OleDbParameter("@Point", model.Point),
					new OleDbParameter("@IsCommented", model.IsCommented),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Price_Cost", model.Price_Cost),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@IsSupplierTransport", model.IsSupplierTransport),
					new OleDbParameter("@Volume", model.Volume),
					new OleDbParameter("@NetWeight", model.NetWeight),
					new OleDbParameter("@PackageRate", model.PackageRate),
					new OleDbParameter("@Units_id", model.Units_id),
					new OleDbParameter("@Money_Card312_one", model.Money_Card312_one),
					new OleDbParameter("@Point_Give_one", model.Point_Give_one),
					new OleDbParameter("@Money_Give_one", model.Money_Give_one),
					new OleDbParameter("@Point_Product", model.Point_Product),
					new OleDbParameter("@Pointagain", model.Pointagain),
					new OleDbParameter("@ProPerty134", model.ProPerty134),
					new OleDbParameter("@Point_Buy_one", model.Point_Buy_one),
					new OleDbParameter("@ProPerty_Price", model.ProPerty_Price),
					new OleDbParameter("@IsPaid", model.IsPaid),
					new OleDbParameter("@IsStockOK", model.IsStockOK),
					new OleDbParameter("@Time_Paid", model.Time_Paid.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_StockOK", model.Time_StockOK.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Price_Reserve", model.Price_Reserve),
					new OleDbParameter("@IsPaidReserve", model.IsPaidReserve),
					new OleDbParameter("@IsReserve", model.IsReserve),
					new OleDbParameter("@IsDel", model.IsDel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Order_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Order_Product] set ");
			strSql.Append("[Product_id]=@Product_id,");
			strSql.Append("[Order_id]=@Order_id,");
			strSql.Append("[Order_Code]=@Order_Code,");
			strSql.Append("[Product_Name]=@Product_Name,");
			strSql.Append("[Product_Number]=@Product_Number,");
			strSql.Append("[Count]=@Count,");
			strSql.Append("[Count_Shipped]=@Count_Shipped,");
			strSql.Append("[Count_Received]=@Count_Received,");
			strSql.Append("[Count_Return]=@Count_Return,");
			strSql.Append("[Price]=@Price,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Weight]=@Weight,");
			strSql.Append("[ImageSmall]=@ImageSmall,");
			strSql.Append("[ImageMedium]=@ImageMedium,");
			strSql.Append("[ImageBig]=@ImageBig,");
			strSql.Append("[ImageOriginal]=@ImageOriginal,");
			strSql.Append("[Type_id_OrderProductType]=@Type_id_OrderProductType,");
			strSql.Append("[Discount]=@Discount,");
			strSql.Append("[Point]=@Point,");
			strSql.Append("[IsCommented]=@IsCommented,");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Price_Cost]=@Price_Cost,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[IsSupplierTransport]=@IsSupplierTransport,");
			strSql.Append("[Volume]=@Volume,");
			strSql.Append("[NetWeight]=@NetWeight,");
			strSql.Append("[PackageRate]=@PackageRate,");
			strSql.Append("[Units_id]=@Units_id,");
			strSql.Append("[Money_Card312_one]=@Money_Card312_one,");
			strSql.Append("[Point_Give_one]=@Point_Give_one,");
			strSql.Append("[Money_Give_one]=@Money_Give_one,");
			strSql.Append("[Point_Product]=@Point_Product,");
			strSql.Append("[Pointagain]=@Pointagain,");
			strSql.Append("[ProPerty134]=@ProPerty134,");
			strSql.Append("[Point_Buy_one]=@Point_Buy_one,");
			strSql.Append("[ProPerty_Price]=@ProPerty_Price,");
			strSql.Append("[IsPaid]=@IsPaid,");
			strSql.Append("[IsStockOK]=@IsStockOK,");
			strSql.Append("[Time_Paid]=@Time_Paid,");
			strSql.Append("[Time_StockOK]=@Time_StockOK,");
			strSql.Append("[Price_Reserve]=@Price_Reserve,");
			strSql.Append("[IsPaidReserve]=@IsPaidReserve,");
			strSql.Append("[IsReserve]=@IsReserve,");
			strSql.Append("[IsDel]=@IsDel");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code),
					new OleDbParameter("@Product_Name", model.Product_Name),
					new OleDbParameter("@Product_Number", model.Product_Number),
					new OleDbParameter("@Count", model.Count),
					new OleDbParameter("@Count_Shipped", model.Count_Shipped),
					new OleDbParameter("@Count_Received", model.Count_Received),
					new OleDbParameter("@Count_Return", model.Count_Return),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Weight", model.Weight),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@ImageMedium", model.ImageMedium),
					new OleDbParameter("@ImageBig", model.ImageBig),
					new OleDbParameter("@ImageOriginal", model.ImageOriginal),
					new OleDbParameter("@Type_id_OrderProductType", model.Type_id_OrderProductType),
					new OleDbParameter("@Discount", model.Discount),
					new OleDbParameter("@Point", model.Point),
					new OleDbParameter("@IsCommented", model.IsCommented),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Price_Cost", model.Price_Cost),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@IsSupplierTransport", model.IsSupplierTransport),
					new OleDbParameter("@Volume", model.Volume),
					new OleDbParameter("@NetWeight", model.NetWeight),
					new OleDbParameter("@PackageRate", model.PackageRate),
					new OleDbParameter("@Units_id", model.Units_id),
					new OleDbParameter("@Money_Card312_one", model.Money_Card312_one),
					new OleDbParameter("@Point_Give_one", model.Point_Give_one),
					new OleDbParameter("@Money_Give_one", model.Money_Give_one),
					new OleDbParameter("@Point_Product", model.Point_Product),
					new OleDbParameter("@Pointagain", model.Pointagain),
					new OleDbParameter("@ProPerty134", model.ProPerty134),
					new OleDbParameter("@Point_Buy_one", model.Point_Buy_one),
					new OleDbParameter("@ProPerty_Price", model.ProPerty_Price),
					new OleDbParameter("@IsPaid", model.IsPaid),
					new OleDbParameter("@IsStockOK", model.IsStockOK),
					new OleDbParameter("@Time_Paid", model.Time_Paid.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_StockOK", model.Time_StockOK.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Price_Reserve", model.Price_Reserve),
					new OleDbParameter("@IsPaidReserve", model.IsPaidReserve),
					new OleDbParameter("@IsReserve", model.IsReserve),
					new OleDbParameter("@IsDel", model.IsDel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order_Product] ");
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
			strSql.Append("delete from [Lebi_Order_Product] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Order_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Order_Product GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order_Product] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Order_Product model;
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
		public Lebi_Order_Product GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Order_Product] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Order_Product model;
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
		public Lebi_Order_Product GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Order_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Order_Product model;
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
		public List<Lebi_Order_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Order_Product]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Order_Product> list = new List<Lebi_Order_Product>();
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
		public List<Lebi_Order_Product> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Order_Product]";
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
			List<Lebi_Order_Product> list = new List<Lebi_Order_Product>();
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
		public List<Lebi_Order_Product> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Order_Product] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Order_Product> list = new List<Lebi_Order_Product>();
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
		public List<Lebi_Order_Product> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Order_Product]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Order_Product> list = new List<Lebi_Order_Product>();
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
		public Lebi_Order_Product BindForm(Lebi_Order_Product model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
			if (HttpContext.Current.Request["Product_Name"] != null)
				model.Product_Name=Shop.Tools.RequestTool.RequestString("Product_Name");
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestString("Product_Number");
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["Count_Shipped"] != null)
				model.Count_Shipped=Shop.Tools.RequestTool.RequestInt("Count_Shipped",0);
			if (HttpContext.Current.Request["Count_Received"] != null)
				model.Count_Received=Shop.Tools.RequestTool.RequestInt("Count_Received",0);
			if (HttpContext.Current.Request["Count_Return"] != null)
				model.Count_Return=Shop.Tools.RequestTool.RequestInt("Count_Return",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestString("ImageOriginal");
			if (HttpContext.Current.Request["Type_id_OrderProductType"] != null)
				model.Type_id_OrderProductType=Shop.Tools.RequestTool.RequestInt("Type_id_OrderProductType",0);
			if (HttpContext.Current.Request["Discount"] != null)
				model.Discount=Shop.Tools.RequestTool.RequestInt("Discount",0);
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["IsCommented"] != null)
				model.IsCommented=Shop.Tools.RequestTool.RequestInt("IsCommented",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Price_Cost"] != null)
				model.Price_Cost=Shop.Tools.RequestTool.RequestDecimal("Price_Cost",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["Volume"] != null)
				model.Volume=Shop.Tools.RequestTool.RequestDecimal("Volume",0);
			if (HttpContext.Current.Request["NetWeight"] != null)
				model.NetWeight=Shop.Tools.RequestTool.RequestDecimal("NetWeight",0);
			if (HttpContext.Current.Request["PackageRate"] != null)
				model.PackageRate=Shop.Tools.RequestTool.RequestInt("PackageRate",0);
			if (HttpContext.Current.Request["Units_id"] != null)
				model.Units_id=Shop.Tools.RequestTool.RequestInt("Units_id",0);
			if (HttpContext.Current.Request["Money_Card312_one"] != null)
				model.Money_Card312_one=Shop.Tools.RequestTool.RequestDecimal("Money_Card312_one",0);
			if (HttpContext.Current.Request["Point_Give_one"] != null)
				model.Point_Give_one=Shop.Tools.RequestTool.RequestDecimal("Point_Give_one",0);
			if (HttpContext.Current.Request["Money_Give_one"] != null)
				model.Money_Give_one=Shop.Tools.RequestTool.RequestDecimal("Money_Give_one",0);
			if (HttpContext.Current.Request["Point_Product"] != null)
				model.Point_Product=Shop.Tools.RequestTool.RequestDecimal("Point_Product",0);
			if (HttpContext.Current.Request["Pointagain"] != null)
				model.Pointagain=Shop.Tools.RequestTool.RequestInt("Pointagain",0);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestString("ProPerty134");
			if (HttpContext.Current.Request["Point_Buy_one"] != null)
				model.Point_Buy_one=Shop.Tools.RequestTool.RequestDecimal("Point_Buy_one",0);
			if (HttpContext.Current.Request["ProPerty_Price"] != null)
				model.ProPerty_Price=Shop.Tools.RequestTool.RequestDecimal("ProPerty_Price",0);
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["IsStockOK"] != null)
				model.IsStockOK=Shop.Tools.RequestTool.RequestInt("IsStockOK",0);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_StockOK"] != null)
				model.Time_StockOK=Shop.Tools.RequestTool.RequestTime("Time_StockOK", System.DateTime.Now);
			if (HttpContext.Current.Request["Price_Reserve"] != null)
				model.Price_Reserve=Shop.Tools.RequestTool.RequestDecimal("Price_Reserve",0);
			if (HttpContext.Current.Request["IsPaidReserve"] != null)
				model.IsPaidReserve=Shop.Tools.RequestTool.RequestInt("IsPaidReserve",0);
			if (HttpContext.Current.Request["IsReserve"] != null)
				model.IsReserve=Shop.Tools.RequestTool.RequestInt("IsReserve",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Order_Product SafeBindForm(Lebi_Order_Product model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestInt("Order_id",0);
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
			if (HttpContext.Current.Request["Product_Name"] != null)
				model.Product_Name=Shop.Tools.RequestTool.RequestSafeString("Product_Name");
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestSafeString("Product_Number");
			if (HttpContext.Current.Request["Count"] != null)
				model.Count=Shop.Tools.RequestTool.RequestInt("Count",0);
			if (HttpContext.Current.Request["Count_Shipped"] != null)
				model.Count_Shipped=Shop.Tools.RequestTool.RequestInt("Count_Shipped",0);
			if (HttpContext.Current.Request["Count_Received"] != null)
				model.Count_Received=Shop.Tools.RequestTool.RequestInt("Count_Received",0);
			if (HttpContext.Current.Request["Count_Return"] != null)
				model.Count_Return=Shop.Tools.RequestTool.RequestInt("Count_Return",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestSafeString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestSafeString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestSafeString("ImageOriginal");
			if (HttpContext.Current.Request["Type_id_OrderProductType"] != null)
				model.Type_id_OrderProductType=Shop.Tools.RequestTool.RequestInt("Type_id_OrderProductType",0);
			if (HttpContext.Current.Request["Discount"] != null)
				model.Discount=Shop.Tools.RequestTool.RequestInt("Discount",0);
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["IsCommented"] != null)
				model.IsCommented=Shop.Tools.RequestTool.RequestInt("IsCommented",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Price_Cost"] != null)
				model.Price_Cost=Shop.Tools.RequestTool.RequestDecimal("Price_Cost",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["Volume"] != null)
				model.Volume=Shop.Tools.RequestTool.RequestDecimal("Volume",0);
			if (HttpContext.Current.Request["NetWeight"] != null)
				model.NetWeight=Shop.Tools.RequestTool.RequestDecimal("NetWeight",0);
			if (HttpContext.Current.Request["PackageRate"] != null)
				model.PackageRate=Shop.Tools.RequestTool.RequestInt("PackageRate",0);
			if (HttpContext.Current.Request["Units_id"] != null)
				model.Units_id=Shop.Tools.RequestTool.RequestInt("Units_id",0);
			if (HttpContext.Current.Request["Money_Card312_one"] != null)
				model.Money_Card312_one=Shop.Tools.RequestTool.RequestDecimal("Money_Card312_one",0);
			if (HttpContext.Current.Request["Point_Give_one"] != null)
				model.Point_Give_one=Shop.Tools.RequestTool.RequestDecimal("Point_Give_one",0);
			if (HttpContext.Current.Request["Money_Give_one"] != null)
				model.Money_Give_one=Shop.Tools.RequestTool.RequestDecimal("Money_Give_one",0);
			if (HttpContext.Current.Request["Point_Product"] != null)
				model.Point_Product=Shop.Tools.RequestTool.RequestDecimal("Point_Product",0);
			if (HttpContext.Current.Request["Pointagain"] != null)
				model.Pointagain=Shop.Tools.RequestTool.RequestInt("Pointagain",0);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestSafeString("ProPerty134");
			if (HttpContext.Current.Request["Point_Buy_one"] != null)
				model.Point_Buy_one=Shop.Tools.RequestTool.RequestDecimal("Point_Buy_one",0);
			if (HttpContext.Current.Request["ProPerty_Price"] != null)
				model.ProPerty_Price=Shop.Tools.RequestTool.RequestDecimal("ProPerty_Price",0);
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["IsStockOK"] != null)
				model.IsStockOK=Shop.Tools.RequestTool.RequestInt("IsStockOK",0);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_StockOK"] != null)
				model.Time_StockOK=Shop.Tools.RequestTool.RequestTime("Time_StockOK", System.DateTime.Now);
			if (HttpContext.Current.Request["Price_Reserve"] != null)
				model.Price_Reserve=Shop.Tools.RequestTool.RequestDecimal("Price_Reserve",0);
			if (HttpContext.Current.Request["IsPaidReserve"] != null)
				model.IsPaidReserve=Shop.Tools.RequestTool.RequestInt("IsPaidReserve",0);
			if (HttpContext.Current.Request["IsReserve"] != null)
				model.IsReserve=Shop.Tools.RequestTool.RequestInt("IsReserve",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Order_Product ReaderBind(IDataReader dataReader)
		{
			Lebi_Order_Product model=new Lebi_Order_Product();
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
			ojb = dataReader["Order_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Order_id=(int)ojb;
			}
			model.Order_Code=dataReader["Order_Code"].ToString();
			model.Product_Name=dataReader["Product_Name"].ToString();
			model.Product_Number=dataReader["Product_Number"].ToString();
			ojb = dataReader["Count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count=(int)ojb;
			}
			ojb = dataReader["Count_Shipped"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Shipped=(int)ojb;
			}
			ojb = dataReader["Count_Received"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Received=(int)ojb;
			}
			ojb = dataReader["Count_Return"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Return=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Weight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight=(decimal)ojb;
			}
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.ImageMedium=dataReader["ImageMedium"].ToString();
			model.ImageBig=dataReader["ImageBig"].ToString();
			model.ImageOriginal=dataReader["ImageOriginal"].ToString();
			ojb = dataReader["Type_id_OrderProductType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_OrderProductType=(int)ojb;
			}
			ojb = dataReader["Discount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Discount=(int)ojb;
			}
			ojb = dataReader["Point"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point=(decimal)ojb;
			}
			ojb = dataReader["IsCommented"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCommented=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Price_Cost"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Cost=(decimal)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["IsSupplierTransport"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSupplierTransport=(int)ojb;
			}
			ojb = dataReader["Volume"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Volume=(decimal)ojb;
			}
			ojb = dataReader["NetWeight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NetWeight=(decimal)ojb;
			}
			ojb = dataReader["PackageRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PackageRate=(int)ojb;
			}
			ojb = dataReader["Units_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Units_id=(int)ojb;
			}
			ojb = dataReader["Money_Card312_one"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Card312_one=(decimal)ojb;
			}
			ojb = dataReader["Point_Give_one"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Give_one=(decimal)ojb;
			}
			ojb = dataReader["Money_Give_one"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Give_one=(decimal)ojb;
			}
			ojb = dataReader["Point_Product"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Product=(decimal)ojb;
			}
			ojb = dataReader["Pointagain"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pointagain=(int)ojb;
			}
			model.ProPerty134=dataReader["ProPerty134"].ToString();
			ojb = dataReader["Point_Buy_one"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point_Buy_one=(decimal)ojb;
			}
			ojb = dataReader["ProPerty_Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProPerty_Price=(decimal)ojb;
			}
			ojb = dataReader["IsPaid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPaid=(int)ojb;
			}
			ojb = dataReader["IsStockOK"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsStockOK=(int)ojb;
			}
			ojb = dataReader["Time_Paid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Paid=(DateTime)ojb;
			}
			ojb = dataReader["Time_StockOK"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_StockOK=(DateTime)ojb;
			}
			ojb = dataReader["Price_Reserve"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Reserve=(decimal)ojb;
			}
			ojb = dataReader["IsPaidReserve"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPaidReserve=(int)ojb;
			}
			ojb = dataReader["IsReserve"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsReserve=(int)ojb;
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

