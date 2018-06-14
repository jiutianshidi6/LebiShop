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

	public interface Lebi_Product_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Product model);
		void Update(Lebi_Product model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Product GetModel(int id);
		Lebi_Product GetModel(string strWhere);
		Lebi_Product GetModel(SQLPara para);
		List<Lebi_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Product> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Product> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Product> GetList(SQLPara para);
		Lebi_Product BindForm(Lebi_Product model);
		Lebi_Product SafeBindForm(Lebi_Product model);
		Lebi_Product ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Product。
	/// </summary>
	public class D_Lebi_Product
	{
		static Lebi_Product_interface _Instance;
		public static Lebi_Product_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Product();
		            else
		                _Instance = new sqlserver_Lebi_Product();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Product()
		{}
		#region  成员方法
	class sqlserver_Lebi_Product : Lebi_Product_interface
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
				strSql.Append("select " + colName + " from [Lebi_Product]");
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
			strSql.Append("select  "+colName+" from [Lebi_Product]");
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
			strSql.Append("select count(1) from [Lebi_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Product]");
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
			strSql.Append("select max(id) from [Lebi_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Product]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Product](");
			strSql.Append("Pro_Type_id,Brand_id,Name,Sort,Number,Code,Units_id,Weight,Introduction,Description,MobileDescription,Type_id_ProductStatus,Count_Like,Count_Sales_Show,Count_Sales,Count_Views_Show,Count_Views,Count_Stock,Count_StockCaution,SEO_Title,SEO_Description,SEO_Keywords,Price_Market,Price_Cost,Price,Images,ImageSmall,ImageMedium,ImageBig,ImageOriginal,Time_Add,Time_OnSale,Time_Edit,Tags,Pro_Tag_id,ProPerty132,ProPerty131,ProPerty133,Service,Remarks,Count_ViewsFalse,Count_SalesFalse,Product_id,Packing,Specification,Star_Comment,Count_Comment,Count_Freeze,ProPertyMain,taobaoid,taobaoid_type,Supplier_id,IsSupplierTransport,VolumeL,VolumeW,VolumeH,PackageRate,Time_Expired,Count_Limit,Price_Sale,Type_id_ProductType,NetWeight,Pro_Type_id_other,Supplier_ProductType_ids,Site_ids,Time_Start,ProPerty134,FreezeRemark,StepPrice,UserLevelPrice,UserLevel_ids_show,UserLevel_ids_priceshow,UserLevel_ids_buy,IsNullStockSale,Price_reserve,Price_reserve_per,Reserve_days,IsCombo,UserLevelCount,IsDel)");
			strSql.Append(" values (");
			strSql.Append("@Pro_Type_id,@Brand_id,@Name,@Sort,@Number,@Code,@Units_id,@Weight,@Introduction,@Description,@MobileDescription,@Type_id_ProductStatus,@Count_Like,@Count_Sales_Show,@Count_Sales,@Count_Views_Show,@Count_Views,@Count_Stock,@Count_StockCaution,@SEO_Title,@SEO_Description,@SEO_Keywords,@Price_Market,@Price_Cost,@Price,@Images,@ImageSmall,@ImageMedium,@ImageBig,@ImageOriginal,@Time_Add,@Time_OnSale,@Time_Edit,@Tags,@Pro_Tag_id,@ProPerty132,@ProPerty131,@ProPerty133,@Service,@Remarks,@Count_ViewsFalse,@Count_SalesFalse,@Product_id,@Packing,@Specification,@Star_Comment,@Count_Comment,@Count_Freeze,@ProPertyMain,@taobaoid,@taobaoid_type,@Supplier_id,@IsSupplierTransport,@VolumeL,@VolumeW,@VolumeH,@PackageRate,@Time_Expired,@Count_Limit,@Price_Sale,@Type_id_ProductType,@NetWeight,@Pro_Type_id_other,@Supplier_ProductType_ids,@Site_ids,@Time_Start,@ProPerty134,@FreezeRemark,@StepPrice,@UserLevelPrice,@UserLevel_ids_show,@UserLevel_ids_priceshow,@UserLevel_ids_buy,@IsNullStockSale,@Price_reserve,@Price_reserve_per,@Reserve_days,@IsCombo,@UserLevelCount,@IsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@Pro_Type_id", model.Pro_Type_id),
					new SqlParameter("@Brand_id", model.Brand_id),
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Number", model.Number),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@Units_id", model.Units_id),
					new SqlParameter("@Weight", model.Weight),
					new SqlParameter("@Introduction", model.Introduction),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@MobileDescription", model.MobileDescription),
					new SqlParameter("@Type_id_ProductStatus", model.Type_id_ProductStatus),
					new SqlParameter("@Count_Like", model.Count_Like),
					new SqlParameter("@Count_Sales_Show", model.Count_Sales_Show),
					new SqlParameter("@Count_Sales", model.Count_Sales),
					new SqlParameter("@Count_Views_Show", model.Count_Views_Show),
					new SqlParameter("@Count_Views", model.Count_Views),
					new SqlParameter("@Count_Stock", model.Count_Stock),
					new SqlParameter("@Count_StockCaution", model.Count_StockCaution),
					new SqlParameter("@SEO_Title", model.SEO_Title),
					new SqlParameter("@SEO_Description", model.SEO_Description),
					new SqlParameter("@SEO_Keywords", model.SEO_Keywords),
					new SqlParameter("@Price_Market", model.Price_Market),
					new SqlParameter("@Price_Cost", model.Price_Cost),
					new SqlParameter("@Price", model.Price),
					new SqlParameter("@Images", model.Images),
					new SqlParameter("@ImageSmall", model.ImageSmall),
					new SqlParameter("@ImageMedium", model.ImageMedium),
					new SqlParameter("@ImageBig", model.ImageBig),
					new SqlParameter("@ImageOriginal", model.ImageOriginal),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_OnSale", model.Time_OnSale),
					new SqlParameter("@Time_Edit", model.Time_Edit),
					new SqlParameter("@Tags", model.Tags),
					new SqlParameter("@Pro_Tag_id", model.Pro_Tag_id),
					new SqlParameter("@ProPerty132", model.ProPerty132),
					new SqlParameter("@ProPerty131", model.ProPerty131),
					new SqlParameter("@ProPerty133", model.ProPerty133),
					new SqlParameter("@Service", model.Service),
					new SqlParameter("@Remarks", model.Remarks),
					new SqlParameter("@Count_ViewsFalse", model.Count_ViewsFalse),
					new SqlParameter("@Count_SalesFalse", model.Count_SalesFalse),
					new SqlParameter("@Product_id", model.Product_id),
					new SqlParameter("@Packing", model.Packing),
					new SqlParameter("@Specification", model.Specification),
					new SqlParameter("@Star_Comment", model.Star_Comment),
					new SqlParameter("@Count_Comment", model.Count_Comment),
					new SqlParameter("@Count_Freeze", model.Count_Freeze),
					new SqlParameter("@ProPertyMain", model.ProPertyMain),
					new SqlParameter("@taobaoid", model.taobaoid),
					new SqlParameter("@taobaoid_type", model.taobaoid_type),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@IsSupplierTransport", model.IsSupplierTransport),
					new SqlParameter("@VolumeL", model.VolumeL),
					new SqlParameter("@VolumeW", model.VolumeW),
					new SqlParameter("@VolumeH", model.VolumeH),
					new SqlParameter("@PackageRate", model.PackageRate),
					new SqlParameter("@Time_Expired", model.Time_Expired),
					new SqlParameter("@Count_Limit", model.Count_Limit),
					new SqlParameter("@Price_Sale", model.Price_Sale),
					new SqlParameter("@Type_id_ProductType", model.Type_id_ProductType),
					new SqlParameter("@NetWeight", model.NetWeight),
					new SqlParameter("@Pro_Type_id_other", model.Pro_Type_id_other),
					new SqlParameter("@Supplier_ProductType_ids", model.Supplier_ProductType_ids),
					new SqlParameter("@Site_ids", model.Site_ids),
					new SqlParameter("@Time_Start", model.Time_Start),
					new SqlParameter("@ProPerty134", model.ProPerty134),
					new SqlParameter("@FreezeRemark", model.FreezeRemark),
					new SqlParameter("@StepPrice", model.StepPrice),
					new SqlParameter("@UserLevelPrice", model.UserLevelPrice),
					new SqlParameter("@UserLevel_ids_show", model.UserLevel_ids_show),
					new SqlParameter("@UserLevel_ids_priceshow", model.UserLevel_ids_priceshow),
					new SqlParameter("@UserLevel_ids_buy", model.UserLevel_ids_buy),
					new SqlParameter("@IsNullStockSale", model.IsNullStockSale),
					new SqlParameter("@Price_reserve", model.Price_reserve),
					new SqlParameter("@Price_reserve_per", model.Price_reserve_per),
					new SqlParameter("@Reserve_days", model.Reserve_days),
					new SqlParameter("@IsCombo", model.IsCombo),
					new SqlParameter("@UserLevelCount", model.UserLevelCount),
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
		public void Update(Lebi_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Product] set ");
			strSql.Append("Pro_Type_id= @Pro_Type_id,");
			strSql.Append("Brand_id= @Brand_id,");
			strSql.Append("Name= @Name,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Number= @Number,");
			strSql.Append("Code= @Code,");
			strSql.Append("Units_id= @Units_id,");
			strSql.Append("Weight= @Weight,");
			strSql.Append("Introduction= @Introduction,");
			strSql.Append("Description= @Description,");
			strSql.Append("MobileDescription= @MobileDescription,");
			strSql.Append("Type_id_ProductStatus= @Type_id_ProductStatus,");
			strSql.Append("Count_Like= @Count_Like,");
			strSql.Append("Count_Sales_Show= @Count_Sales_Show,");
			strSql.Append("Count_Sales= @Count_Sales,");
			strSql.Append("Count_Views_Show= @Count_Views_Show,");
			strSql.Append("Count_Views= @Count_Views,");
			strSql.Append("Count_Stock= @Count_Stock,");
			strSql.Append("Count_StockCaution= @Count_StockCaution,");
			strSql.Append("SEO_Title= @SEO_Title,");
			strSql.Append("SEO_Description= @SEO_Description,");
			strSql.Append("SEO_Keywords= @SEO_Keywords,");
			strSql.Append("Price_Market= @Price_Market,");
			strSql.Append("Price_Cost= @Price_Cost,");
			strSql.Append("Price= @Price,");
			strSql.Append("Images= @Images,");
			strSql.Append("ImageSmall= @ImageSmall,");
			strSql.Append("ImageMedium= @ImageMedium,");
			strSql.Append("ImageBig= @ImageBig,");
			strSql.Append("ImageOriginal= @ImageOriginal,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_OnSale= @Time_OnSale,");
			strSql.Append("Time_Edit= @Time_Edit,");
			strSql.Append("Tags= @Tags,");
			strSql.Append("Pro_Tag_id= @Pro_Tag_id,");
			strSql.Append("ProPerty132= @ProPerty132,");
			strSql.Append("ProPerty131= @ProPerty131,");
			strSql.Append("ProPerty133= @ProPerty133,");
			strSql.Append("Service= @Service,");
			strSql.Append("Remarks= @Remarks,");
			strSql.Append("Count_ViewsFalse= @Count_ViewsFalse,");
			strSql.Append("Count_SalesFalse= @Count_SalesFalse,");
			strSql.Append("Product_id= @Product_id,");
			strSql.Append("Packing= @Packing,");
			strSql.Append("Specification= @Specification,");
			strSql.Append("Star_Comment= @Star_Comment,");
			strSql.Append("Count_Comment= @Count_Comment,");
			strSql.Append("Count_Freeze= @Count_Freeze,");
			strSql.Append("ProPertyMain= @ProPertyMain,");
			strSql.Append("taobaoid= @taobaoid,");
			strSql.Append("taobaoid_type= @taobaoid_type,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("IsSupplierTransport= @IsSupplierTransport,");
			strSql.Append("VolumeL= @VolumeL,");
			strSql.Append("VolumeW= @VolumeW,");
			strSql.Append("VolumeH= @VolumeH,");
			strSql.Append("PackageRate= @PackageRate,");
			strSql.Append("Time_Expired= @Time_Expired,");
			strSql.Append("Count_Limit= @Count_Limit,");
			strSql.Append("Price_Sale= @Price_Sale,");
			strSql.Append("Type_id_ProductType= @Type_id_ProductType,");
			strSql.Append("NetWeight= @NetWeight,");
			strSql.Append("Pro_Type_id_other= @Pro_Type_id_other,");
			strSql.Append("Supplier_ProductType_ids= @Supplier_ProductType_ids,");
			strSql.Append("Site_ids= @Site_ids,");
			strSql.Append("Time_Start= @Time_Start,");
			strSql.Append("ProPerty134= @ProPerty134,");
			strSql.Append("FreezeRemark= @FreezeRemark,");
			strSql.Append("StepPrice= @StepPrice,");
			strSql.Append("UserLevelPrice= @UserLevelPrice,");
			strSql.Append("UserLevel_ids_show= @UserLevel_ids_show,");
			strSql.Append("UserLevel_ids_priceshow= @UserLevel_ids_priceshow,");
			strSql.Append("UserLevel_ids_buy= @UserLevel_ids_buy,");
			strSql.Append("IsNullStockSale= @IsNullStockSale,");
			strSql.Append("Price_reserve= @Price_reserve,");
			strSql.Append("Price_reserve_per= @Price_reserve_per,");
			strSql.Append("Reserve_days= @Reserve_days,");
			strSql.Append("IsCombo= @IsCombo,");
			strSql.Append("UserLevelCount= @UserLevelCount,");
			strSql.Append("IsDel= @IsDel");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Pro_Type_id", SqlDbType.Int,4),
					new SqlParameter("@Brand_id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,2000),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Units_id", SqlDbType.Int,4),
					new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@Introduction", SqlDbType.NVarChar,4000),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@MobileDescription", SqlDbType.NText),
					new SqlParameter("@Type_id_ProductStatus", SqlDbType.Int,4),
					new SqlParameter("@Count_Like", SqlDbType.Int,4),
					new SqlParameter("@Count_Sales_Show", SqlDbType.Int,4),
					new SqlParameter("@Count_Sales", SqlDbType.Int,4),
					new SqlParameter("@Count_Views_Show", SqlDbType.Int,4),
					new SqlParameter("@Count_Views", SqlDbType.Int,4),
					new SqlParameter("@Count_Stock", SqlDbType.Int,4),
					new SqlParameter("@Count_StockCaution", SqlDbType.Int,4),
					new SqlParameter("@SEO_Title", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Keywords", SqlDbType.NVarChar,2000),
					new SqlParameter("@Price_Market", SqlDbType.Decimal,9),
					new SqlParameter("@Price_Cost", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Images", SqlDbType.NVarChar,1000),
					new SqlParameter("@ImageSmall", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageMedium", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageBig", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageOriginal", SqlDbType.NVarChar,200),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_OnSale", SqlDbType.DateTime),
					new SqlParameter("@Time_Edit", SqlDbType.DateTime),
					new SqlParameter("@Tags", SqlDbType.NVarChar,500),
					new SqlParameter("@Pro_Tag_id", SqlDbType.NVarChar,100),
					new SqlParameter("@ProPerty132", SqlDbType.NVarChar,2000),
					new SqlParameter("@ProPerty131", SqlDbType.NVarChar,2000),
					new SqlParameter("@ProPerty133", SqlDbType.NText),
					new SqlParameter("@Service", SqlDbType.NText),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@Count_ViewsFalse", SqlDbType.Int,4),
					new SqlParameter("@Count_SalesFalse", SqlDbType.Int,4),
					new SqlParameter("@Product_id", SqlDbType.Int,4),
					new SqlParameter("@Packing", SqlDbType.NText),
					new SqlParameter("@Specification", SqlDbType.NVarChar,4000),
					new SqlParameter("@Star_Comment", SqlDbType.Decimal,9),
					new SqlParameter("@Count_Comment", SqlDbType.Int,4),
					new SqlParameter("@Count_Freeze", SqlDbType.Int,4),
					new SqlParameter("@ProPertyMain", SqlDbType.Int,4),
					new SqlParameter("@taobaoid", SqlDbType.NVarChar,50),
					new SqlParameter("@taobaoid_type", SqlDbType.NVarChar,200),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@IsSupplierTransport", SqlDbType.Int,4),
					new SqlParameter("@VolumeL", SqlDbType.Decimal,9),
					new SqlParameter("@VolumeW", SqlDbType.Decimal,9),
					new SqlParameter("@VolumeH", SqlDbType.Decimal,9),
					new SqlParameter("@PackageRate", SqlDbType.Int,4),
					new SqlParameter("@Time_Expired", SqlDbType.DateTime),
					new SqlParameter("@Count_Limit", SqlDbType.Int,4),
					new SqlParameter("@Price_Sale", SqlDbType.Decimal,9),
					new SqlParameter("@Type_id_ProductType", SqlDbType.Int,4),
					new SqlParameter("@NetWeight", SqlDbType.Decimal,9),
					new SqlParameter("@Pro_Type_id_other", SqlDbType.NVarChar,255),
					new SqlParameter("@Supplier_ProductType_ids", SqlDbType.NVarChar,255),
					new SqlParameter("@Site_ids", SqlDbType.NVarChar,200),
					new SqlParameter("@Time_Start", SqlDbType.DateTime),
					new SqlParameter("@ProPerty134", SqlDbType.NVarChar,2000),
					new SqlParameter("@FreezeRemark", SqlDbType.NVarChar,255),
					new SqlParameter("@StepPrice", SqlDbType.NVarChar,2000),
					new SqlParameter("@UserLevelPrice", SqlDbType.NVarChar,2000),
					new SqlParameter("@UserLevel_ids_show", SqlDbType.NVarChar,200),
					new SqlParameter("@UserLevel_ids_priceshow", SqlDbType.NVarChar,200),
					new SqlParameter("@UserLevel_ids_buy", SqlDbType.NVarChar,200),
					new SqlParameter("@IsNullStockSale", SqlDbType.Int,4),
					new SqlParameter("@Price_reserve", SqlDbType.Decimal,9),
					new SqlParameter("@Price_reserve_per", SqlDbType.Decimal,9),
					new SqlParameter("@Reserve_days", SqlDbType.Int,4),
					new SqlParameter("@IsCombo", SqlDbType.Int,4),
					new SqlParameter("@UserLevelCount", SqlDbType.NVarChar,2000),
					new SqlParameter("@IsDel", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Pro_Type_id;
			parameters[2].Value = model.Brand_id;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Sort;
			parameters[5].Value = model.Number;
			parameters[6].Value = model.Code;
			parameters[7].Value = model.Units_id;
			parameters[8].Value = model.Weight;
			parameters[9].Value = model.Introduction;
			parameters[10].Value = model.Description;
			parameters[11].Value = model.MobileDescription;
			parameters[12].Value = model.Type_id_ProductStatus;
			parameters[13].Value = model.Count_Like;
			parameters[14].Value = model.Count_Sales_Show;
			parameters[15].Value = model.Count_Sales;
			parameters[16].Value = model.Count_Views_Show;
			parameters[17].Value = model.Count_Views;
			parameters[18].Value = model.Count_Stock;
			parameters[19].Value = model.Count_StockCaution;
			parameters[20].Value = model.SEO_Title;
			parameters[21].Value = model.SEO_Description;
			parameters[22].Value = model.SEO_Keywords;
			parameters[23].Value = model.Price_Market;
			parameters[24].Value = model.Price_Cost;
			parameters[25].Value = model.Price;
			parameters[26].Value = model.Images;
			parameters[27].Value = model.ImageSmall;
			parameters[28].Value = model.ImageMedium;
			parameters[29].Value = model.ImageBig;
			parameters[30].Value = model.ImageOriginal;
			parameters[31].Value = model.Time_Add;
			parameters[32].Value = model.Time_OnSale;
			parameters[33].Value = model.Time_Edit;
			parameters[34].Value = model.Tags;
			parameters[35].Value = model.Pro_Tag_id;
			parameters[36].Value = model.ProPerty132;
			parameters[37].Value = model.ProPerty131;
			parameters[38].Value = model.ProPerty133;
			parameters[39].Value = model.Service;
			parameters[40].Value = model.Remarks;
			parameters[41].Value = model.Count_ViewsFalse;
			parameters[42].Value = model.Count_SalesFalse;
			parameters[43].Value = model.Product_id;
			parameters[44].Value = model.Packing;
			parameters[45].Value = model.Specification;
			parameters[46].Value = model.Star_Comment;
			parameters[47].Value = model.Count_Comment;
			parameters[48].Value = model.Count_Freeze;
			parameters[49].Value = model.ProPertyMain;
			parameters[50].Value = model.taobaoid;
			parameters[51].Value = model.taobaoid_type;
			parameters[52].Value = model.Supplier_id;
			parameters[53].Value = model.IsSupplierTransport;
			parameters[54].Value = model.VolumeL;
			parameters[55].Value = model.VolumeW;
			parameters[56].Value = model.VolumeH;
			parameters[57].Value = model.PackageRate;
			parameters[58].Value = model.Time_Expired;
			parameters[59].Value = model.Count_Limit;
			parameters[60].Value = model.Price_Sale;
			parameters[61].Value = model.Type_id_ProductType;
			parameters[62].Value = model.NetWeight;
			parameters[63].Value = model.Pro_Type_id_other;
			parameters[64].Value = model.Supplier_ProductType_ids;
			parameters[65].Value = model.Site_ids;
			parameters[66].Value = model.Time_Start;
			parameters[67].Value = model.ProPerty134;
			parameters[68].Value = model.FreezeRemark;
			parameters[69].Value = model.StepPrice;
			parameters[70].Value = model.UserLevelPrice;
			parameters[71].Value = model.UserLevel_ids_show;
			parameters[72].Value = model.UserLevel_ids_priceshow;
			parameters[73].Value = model.UserLevel_ids_buy;
			parameters[74].Value = model.IsNullStockSale;
			parameters[75].Value = model.Price_reserve;
			parameters[76].Value = model.Price_reserve_per;
			parameters[77].Value = model.Reserve_days;
			parameters[78].Value = model.IsCombo;
			parameters[79].Value = model.UserLevelCount;
			parameters[80].Value = model.IsDel;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product] ");
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
			strSql.Append("delete from [Lebi_Product] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Product GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Product model=new Lebi_Product();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString()!="")
				{
					model.Pro_Type_id=int.Parse(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Brand_id"].ToString()!="")
				{
					model.Brand_id=int.Parse(ds.Tables[0].Rows[0]["Brand_id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.Number=ds.Tables[0].Rows[0]["Number"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["Units_id"].ToString()!="")
				{
					model.Units_id=int.Parse(ds.Tables[0].Rows[0]["Units_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Weight"].ToString()!="")
				{
					model.Weight=decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
				}
				model.Introduction=ds.Tables[0].Rows[0]["Introduction"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.MobileDescription=ds.Tables[0].Rows[0]["MobileDescription"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_ProductStatus"].ToString()!="")
				{
					model.Type_id_ProductStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_ProductStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Like"].ToString()!="")
				{
					model.Count_Like=int.Parse(ds.Tables[0].Rows[0]["Count_Like"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Sales_Show"].ToString()!="")
				{
					model.Count_Sales_Show=int.Parse(ds.Tables[0].Rows[0]["Count_Sales_Show"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Sales"].ToString()!="")
				{
					model.Count_Sales=int.Parse(ds.Tables[0].Rows[0]["Count_Sales"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views_Show"].ToString()!="")
				{
					model.Count_Views_Show=int.Parse(ds.Tables[0].Rows[0]["Count_Views_Show"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views"].ToString()!="")
				{
					model.Count_Views=int.Parse(ds.Tables[0].Rows[0]["Count_Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Stock"].ToString()!="")
				{
					model.Count_Stock=int.Parse(ds.Tables[0].Rows[0]["Count_Stock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_StockCaution"].ToString()!="")
				{
					model.Count_StockCaution=int.Parse(ds.Tables[0].Rows[0]["Count_StockCaution"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				if(ds.Tables[0].Rows[0]["Price_Market"].ToString()!="")
				{
					model.Price_Market=decimal.Parse(ds.Tables[0].Rows[0]["Price_Market"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Cost"].ToString()!="")
				{
					model.Price_Cost=decimal.Parse(ds.Tables[0].Rows[0]["Price_Cost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.Images=ds.Tables[0].Rows[0]["Images"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_OnSale"].ToString()!="")
				{
					model.Time_OnSale=DateTime.Parse(ds.Tables[0].Rows[0]["Time_OnSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Edit"].ToString()!="")
				{
					model.Time_Edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Edit"].ToString());
				}
				model.Tags=ds.Tables[0].Rows[0]["Tags"].ToString();
				model.Pro_Tag_id=ds.Tables[0].Rows[0]["Pro_Tag_id"].ToString();
				model.ProPerty132=ds.Tables[0].Rows[0]["ProPerty132"].ToString();
				model.ProPerty131=ds.Tables[0].Rows[0]["ProPerty131"].ToString();
				model.ProPerty133=ds.Tables[0].Rows[0]["ProPerty133"].ToString();
				model.Service=ds.Tables[0].Rows[0]["Service"].ToString();
				model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
				if(ds.Tables[0].Rows[0]["Count_ViewsFalse"].ToString()!="")
				{
					model.Count_ViewsFalse=int.Parse(ds.Tables[0].Rows[0]["Count_ViewsFalse"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_SalesFalse"].ToString()!="")
				{
					model.Count_SalesFalse=int.Parse(ds.Tables[0].Rows[0]["Count_SalesFalse"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				model.Packing=ds.Tables[0].Rows[0]["Packing"].ToString();
				model.Specification=ds.Tables[0].Rows[0]["Specification"].ToString();
				if(ds.Tables[0].Rows[0]["Star_Comment"].ToString()!="")
				{
					model.Star_Comment=decimal.Parse(ds.Tables[0].Rows[0]["Star_Comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Comment"].ToString()!="")
				{
					model.Count_Comment=int.Parse(ds.Tables[0].Rows[0]["Count_Comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Freeze"].ToString()!="")
				{
					model.Count_Freeze=int.Parse(ds.Tables[0].Rows[0]["Count_Freeze"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPertyMain"].ToString()!="")
				{
					model.ProPertyMain=int.Parse(ds.Tables[0].Rows[0]["ProPertyMain"].ToString());
				}
				model.taobaoid=ds.Tables[0].Rows[0]["taobaoid"].ToString();
				model.taobaoid_type=ds.Tables[0].Rows[0]["taobaoid_type"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString()!="")
				{
					model.IsSupplierTransport=int.Parse(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VolumeL"].ToString()!="")
				{
					model.VolumeL=decimal.Parse(ds.Tables[0].Rows[0]["VolumeL"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VolumeW"].ToString()!="")
				{
					model.VolumeW=decimal.Parse(ds.Tables[0].Rows[0]["VolumeW"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VolumeH"].ToString()!="")
				{
					model.VolumeH=decimal.Parse(ds.Tables[0].Rows[0]["VolumeH"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PackageRate"].ToString()!="")
				{
					model.PackageRate=int.Parse(ds.Tables[0].Rows[0]["PackageRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Expired"].ToString()!="")
				{
					model.Time_Expired=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Expired"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Limit"].ToString()!="")
				{
					model.Count_Limit=int.Parse(ds.Tables[0].Rows[0]["Count_Limit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Sale"].ToString()!="")
				{
					model.Price_Sale=decimal.Parse(ds.Tables[0].Rows[0]["Price_Sale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_ProductType"].ToString()!="")
				{
					model.Type_id_ProductType=int.Parse(ds.Tables[0].Rows[0]["Type_id_ProductType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NetWeight"].ToString()!="")
				{
					model.NetWeight=decimal.Parse(ds.Tables[0].Rows[0]["NetWeight"].ToString());
				}
				model.Pro_Type_id_other=ds.Tables[0].Rows[0]["Pro_Type_id_other"].ToString();
				model.Supplier_ProductType_ids=ds.Tables[0].Rows[0]["Supplier_ProductType_ids"].ToString();
				model.Site_ids=ds.Tables[0].Rows[0]["Site_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Start"].ToString()!="")
				{
					model.Time_Start=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Start"].ToString());
				}
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				model.FreezeRemark=ds.Tables[0].Rows[0]["FreezeRemark"].ToString();
				model.StepPrice=ds.Tables[0].Rows[0]["StepPrice"].ToString();
				model.UserLevelPrice=ds.Tables[0].Rows[0]["UserLevelPrice"].ToString();
				model.UserLevel_ids_show=ds.Tables[0].Rows[0]["UserLevel_ids_show"].ToString();
				model.UserLevel_ids_priceshow=ds.Tables[0].Rows[0]["UserLevel_ids_priceshow"].ToString();
				model.UserLevel_ids_buy=ds.Tables[0].Rows[0]["UserLevel_ids_buy"].ToString();
				if(ds.Tables[0].Rows[0]["IsNullStockSale"].ToString()!="")
				{
					model.IsNullStockSale=int.Parse(ds.Tables[0].Rows[0]["IsNullStockSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_reserve"].ToString()!="")
				{
					model.Price_reserve=decimal.Parse(ds.Tables[0].Rows[0]["Price_reserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_reserve_per"].ToString()!="")
				{
					model.Price_reserve_per=decimal.Parse(ds.Tables[0].Rows[0]["Price_reserve_per"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Reserve_days"].ToString()!="")
				{
					model.Reserve_days=int.Parse(ds.Tables[0].Rows[0]["Reserve_days"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCombo"].ToString()!="")
				{
					model.IsCombo=int.Parse(ds.Tables[0].Rows[0]["IsCombo"].ToString());
				}
				model.UserLevelCount=ds.Tables[0].Rows[0]["UserLevelCount"].ToString();
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
		public Lebi_Product GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Product model=new Lebi_Product();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString()!="")
				{
					model.Pro_Type_id=int.Parse(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Brand_id"].ToString()!="")
				{
					model.Brand_id=int.Parse(ds.Tables[0].Rows[0]["Brand_id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.Number=ds.Tables[0].Rows[0]["Number"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["Units_id"].ToString()!="")
				{
					model.Units_id=int.Parse(ds.Tables[0].Rows[0]["Units_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Weight"].ToString()!="")
				{
					model.Weight=decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
				}
				model.Introduction=ds.Tables[0].Rows[0]["Introduction"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.MobileDescription=ds.Tables[0].Rows[0]["MobileDescription"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_ProductStatus"].ToString()!="")
				{
					model.Type_id_ProductStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_ProductStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Like"].ToString()!="")
				{
					model.Count_Like=int.Parse(ds.Tables[0].Rows[0]["Count_Like"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Sales_Show"].ToString()!="")
				{
					model.Count_Sales_Show=int.Parse(ds.Tables[0].Rows[0]["Count_Sales_Show"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Sales"].ToString()!="")
				{
					model.Count_Sales=int.Parse(ds.Tables[0].Rows[0]["Count_Sales"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views_Show"].ToString()!="")
				{
					model.Count_Views_Show=int.Parse(ds.Tables[0].Rows[0]["Count_Views_Show"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views"].ToString()!="")
				{
					model.Count_Views=int.Parse(ds.Tables[0].Rows[0]["Count_Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Stock"].ToString()!="")
				{
					model.Count_Stock=int.Parse(ds.Tables[0].Rows[0]["Count_Stock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_StockCaution"].ToString()!="")
				{
					model.Count_StockCaution=int.Parse(ds.Tables[0].Rows[0]["Count_StockCaution"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				if(ds.Tables[0].Rows[0]["Price_Market"].ToString()!="")
				{
					model.Price_Market=decimal.Parse(ds.Tables[0].Rows[0]["Price_Market"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Cost"].ToString()!="")
				{
					model.Price_Cost=decimal.Parse(ds.Tables[0].Rows[0]["Price_Cost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.Images=ds.Tables[0].Rows[0]["Images"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_OnSale"].ToString()!="")
				{
					model.Time_OnSale=DateTime.Parse(ds.Tables[0].Rows[0]["Time_OnSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Edit"].ToString()!="")
				{
					model.Time_Edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Edit"].ToString());
				}
				model.Tags=ds.Tables[0].Rows[0]["Tags"].ToString();
				model.Pro_Tag_id=ds.Tables[0].Rows[0]["Pro_Tag_id"].ToString();
				model.ProPerty132=ds.Tables[0].Rows[0]["ProPerty132"].ToString();
				model.ProPerty131=ds.Tables[0].Rows[0]["ProPerty131"].ToString();
				model.ProPerty133=ds.Tables[0].Rows[0]["ProPerty133"].ToString();
				model.Service=ds.Tables[0].Rows[0]["Service"].ToString();
				model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
				if(ds.Tables[0].Rows[0]["Count_ViewsFalse"].ToString()!="")
				{
					model.Count_ViewsFalse=int.Parse(ds.Tables[0].Rows[0]["Count_ViewsFalse"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_SalesFalse"].ToString()!="")
				{
					model.Count_SalesFalse=int.Parse(ds.Tables[0].Rows[0]["Count_SalesFalse"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				model.Packing=ds.Tables[0].Rows[0]["Packing"].ToString();
				model.Specification=ds.Tables[0].Rows[0]["Specification"].ToString();
				if(ds.Tables[0].Rows[0]["Star_Comment"].ToString()!="")
				{
					model.Star_Comment=decimal.Parse(ds.Tables[0].Rows[0]["Star_Comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Comment"].ToString()!="")
				{
					model.Count_Comment=int.Parse(ds.Tables[0].Rows[0]["Count_Comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Freeze"].ToString()!="")
				{
					model.Count_Freeze=int.Parse(ds.Tables[0].Rows[0]["Count_Freeze"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPertyMain"].ToString()!="")
				{
					model.ProPertyMain=int.Parse(ds.Tables[0].Rows[0]["ProPertyMain"].ToString());
				}
				model.taobaoid=ds.Tables[0].Rows[0]["taobaoid"].ToString();
				model.taobaoid_type=ds.Tables[0].Rows[0]["taobaoid_type"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString()!="")
				{
					model.IsSupplierTransport=int.Parse(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VolumeL"].ToString()!="")
				{
					model.VolumeL=decimal.Parse(ds.Tables[0].Rows[0]["VolumeL"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VolumeW"].ToString()!="")
				{
					model.VolumeW=decimal.Parse(ds.Tables[0].Rows[0]["VolumeW"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VolumeH"].ToString()!="")
				{
					model.VolumeH=decimal.Parse(ds.Tables[0].Rows[0]["VolumeH"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PackageRate"].ToString()!="")
				{
					model.PackageRate=int.Parse(ds.Tables[0].Rows[0]["PackageRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Expired"].ToString()!="")
				{
					model.Time_Expired=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Expired"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Limit"].ToString()!="")
				{
					model.Count_Limit=int.Parse(ds.Tables[0].Rows[0]["Count_Limit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Sale"].ToString()!="")
				{
					model.Price_Sale=decimal.Parse(ds.Tables[0].Rows[0]["Price_Sale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_ProductType"].ToString()!="")
				{
					model.Type_id_ProductType=int.Parse(ds.Tables[0].Rows[0]["Type_id_ProductType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NetWeight"].ToString()!="")
				{
					model.NetWeight=decimal.Parse(ds.Tables[0].Rows[0]["NetWeight"].ToString());
				}
				model.Pro_Type_id_other=ds.Tables[0].Rows[0]["Pro_Type_id_other"].ToString();
				model.Supplier_ProductType_ids=ds.Tables[0].Rows[0]["Supplier_ProductType_ids"].ToString();
				model.Site_ids=ds.Tables[0].Rows[0]["Site_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Start"].ToString()!="")
				{
					model.Time_Start=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Start"].ToString());
				}
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				model.FreezeRemark=ds.Tables[0].Rows[0]["FreezeRemark"].ToString();
				model.StepPrice=ds.Tables[0].Rows[0]["StepPrice"].ToString();
				model.UserLevelPrice=ds.Tables[0].Rows[0]["UserLevelPrice"].ToString();
				model.UserLevel_ids_show=ds.Tables[0].Rows[0]["UserLevel_ids_show"].ToString();
				model.UserLevel_ids_priceshow=ds.Tables[0].Rows[0]["UserLevel_ids_priceshow"].ToString();
				model.UserLevel_ids_buy=ds.Tables[0].Rows[0]["UserLevel_ids_buy"].ToString();
				if(ds.Tables[0].Rows[0]["IsNullStockSale"].ToString()!="")
				{
					model.IsNullStockSale=int.Parse(ds.Tables[0].Rows[0]["IsNullStockSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_reserve"].ToString()!="")
				{
					model.Price_reserve=decimal.Parse(ds.Tables[0].Rows[0]["Price_reserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_reserve_per"].ToString()!="")
				{
					model.Price_reserve_per=decimal.Parse(ds.Tables[0].Rows[0]["Price_reserve_per"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Reserve_days"].ToString()!="")
				{
					model.Reserve_days=int.Parse(ds.Tables[0].Rows[0]["Reserve_days"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCombo"].ToString()!="")
				{
					model.IsCombo=int.Parse(ds.Tables[0].Rows[0]["IsCombo"].ToString());
				}
				model.UserLevelCount=ds.Tables[0].Rows[0]["UserLevelCount"].ToString();
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
		public Lebi_Product GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Product model=new Lebi_Product();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString()!="")
				{
					model.Pro_Type_id=int.Parse(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Brand_id"].ToString()!="")
				{
					model.Brand_id=int.Parse(ds.Tables[0].Rows[0]["Brand_id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.Number=ds.Tables[0].Rows[0]["Number"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["Units_id"].ToString()!="")
				{
					model.Units_id=int.Parse(ds.Tables[0].Rows[0]["Units_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Weight"].ToString()!="")
				{
					model.Weight=decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
				}
				model.Introduction=ds.Tables[0].Rows[0]["Introduction"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.MobileDescription=ds.Tables[0].Rows[0]["MobileDescription"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_ProductStatus"].ToString()!="")
				{
					model.Type_id_ProductStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_ProductStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Like"].ToString()!="")
				{
					model.Count_Like=int.Parse(ds.Tables[0].Rows[0]["Count_Like"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Sales_Show"].ToString()!="")
				{
					model.Count_Sales_Show=int.Parse(ds.Tables[0].Rows[0]["Count_Sales_Show"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Sales"].ToString()!="")
				{
					model.Count_Sales=int.Parse(ds.Tables[0].Rows[0]["Count_Sales"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views_Show"].ToString()!="")
				{
					model.Count_Views_Show=int.Parse(ds.Tables[0].Rows[0]["Count_Views_Show"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Views"].ToString()!="")
				{
					model.Count_Views=int.Parse(ds.Tables[0].Rows[0]["Count_Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Stock"].ToString()!="")
				{
					model.Count_Stock=int.Parse(ds.Tables[0].Rows[0]["Count_Stock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_StockCaution"].ToString()!="")
				{
					model.Count_StockCaution=int.Parse(ds.Tables[0].Rows[0]["Count_StockCaution"].ToString());
				}
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				if(ds.Tables[0].Rows[0]["Price_Market"].ToString()!="")
				{
					model.Price_Market=decimal.Parse(ds.Tables[0].Rows[0]["Price_Market"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Cost"].ToString()!="")
				{
					model.Price_Cost=decimal.Parse(ds.Tables[0].Rows[0]["Price_Cost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.Images=ds.Tables[0].Rows[0]["Images"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_OnSale"].ToString()!="")
				{
					model.Time_OnSale=DateTime.Parse(ds.Tables[0].Rows[0]["Time_OnSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Edit"].ToString()!="")
				{
					model.Time_Edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Edit"].ToString());
				}
				model.Tags=ds.Tables[0].Rows[0]["Tags"].ToString();
				model.Pro_Tag_id=ds.Tables[0].Rows[0]["Pro_Tag_id"].ToString();
				model.ProPerty132=ds.Tables[0].Rows[0]["ProPerty132"].ToString();
				model.ProPerty131=ds.Tables[0].Rows[0]["ProPerty131"].ToString();
				model.ProPerty133=ds.Tables[0].Rows[0]["ProPerty133"].ToString();
				model.Service=ds.Tables[0].Rows[0]["Service"].ToString();
				model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
				if(ds.Tables[0].Rows[0]["Count_ViewsFalse"].ToString()!="")
				{
					model.Count_ViewsFalse=int.Parse(ds.Tables[0].Rows[0]["Count_ViewsFalse"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_SalesFalse"].ToString()!="")
				{
					model.Count_SalesFalse=int.Parse(ds.Tables[0].Rows[0]["Count_SalesFalse"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				model.Packing=ds.Tables[0].Rows[0]["Packing"].ToString();
				model.Specification=ds.Tables[0].Rows[0]["Specification"].ToString();
				if(ds.Tables[0].Rows[0]["Star_Comment"].ToString()!="")
				{
					model.Star_Comment=decimal.Parse(ds.Tables[0].Rows[0]["Star_Comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Comment"].ToString()!="")
				{
					model.Count_Comment=int.Parse(ds.Tables[0].Rows[0]["Count_Comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Freeze"].ToString()!="")
				{
					model.Count_Freeze=int.Parse(ds.Tables[0].Rows[0]["Count_Freeze"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPertyMain"].ToString()!="")
				{
					model.ProPertyMain=int.Parse(ds.Tables[0].Rows[0]["ProPertyMain"].ToString());
				}
				model.taobaoid=ds.Tables[0].Rows[0]["taobaoid"].ToString();
				model.taobaoid_type=ds.Tables[0].Rows[0]["taobaoid_type"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString()!="")
				{
					model.IsSupplierTransport=int.Parse(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VolumeL"].ToString()!="")
				{
					model.VolumeL=decimal.Parse(ds.Tables[0].Rows[0]["VolumeL"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VolumeW"].ToString()!="")
				{
					model.VolumeW=decimal.Parse(ds.Tables[0].Rows[0]["VolumeW"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VolumeH"].ToString()!="")
				{
					model.VolumeH=decimal.Parse(ds.Tables[0].Rows[0]["VolumeH"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PackageRate"].ToString()!="")
				{
					model.PackageRate=int.Parse(ds.Tables[0].Rows[0]["PackageRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Expired"].ToString()!="")
				{
					model.Time_Expired=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Expired"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Limit"].ToString()!="")
				{
					model.Count_Limit=int.Parse(ds.Tables[0].Rows[0]["Count_Limit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Sale"].ToString()!="")
				{
					model.Price_Sale=decimal.Parse(ds.Tables[0].Rows[0]["Price_Sale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_ProductType"].ToString()!="")
				{
					model.Type_id_ProductType=int.Parse(ds.Tables[0].Rows[0]["Type_id_ProductType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NetWeight"].ToString()!="")
				{
					model.NetWeight=decimal.Parse(ds.Tables[0].Rows[0]["NetWeight"].ToString());
				}
				model.Pro_Type_id_other=ds.Tables[0].Rows[0]["Pro_Type_id_other"].ToString();
				model.Supplier_ProductType_ids=ds.Tables[0].Rows[0]["Supplier_ProductType_ids"].ToString();
				model.Site_ids=ds.Tables[0].Rows[0]["Site_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Start"].ToString()!="")
				{
					model.Time_Start=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Start"].ToString());
				}
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				model.FreezeRemark=ds.Tables[0].Rows[0]["FreezeRemark"].ToString();
				model.StepPrice=ds.Tables[0].Rows[0]["StepPrice"].ToString();
				model.UserLevelPrice=ds.Tables[0].Rows[0]["UserLevelPrice"].ToString();
				model.UserLevel_ids_show=ds.Tables[0].Rows[0]["UserLevel_ids_show"].ToString();
				model.UserLevel_ids_priceshow=ds.Tables[0].Rows[0]["UserLevel_ids_priceshow"].ToString();
				model.UserLevel_ids_buy=ds.Tables[0].Rows[0]["UserLevel_ids_buy"].ToString();
				if(ds.Tables[0].Rows[0]["IsNullStockSale"].ToString()!="")
				{
					model.IsNullStockSale=int.Parse(ds.Tables[0].Rows[0]["IsNullStockSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_reserve"].ToString()!="")
				{
					model.Price_reserve=decimal.Parse(ds.Tables[0].Rows[0]["Price_reserve"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_reserve_per"].ToString()!="")
				{
					model.Price_reserve_per=decimal.Parse(ds.Tables[0].Rows[0]["Price_reserve_per"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Reserve_days"].ToString()!="")
				{
					model.Reserve_days=int.Parse(ds.Tables[0].Rows[0]["Reserve_days"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCombo"].ToString()!="")
				{
					model.IsCombo=int.Parse(ds.Tables[0].Rows[0]["IsCombo"].ToString());
				}
				model.UserLevelCount=ds.Tables[0].Rows[0]["UserLevelCount"].ToString();
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
		public List<Lebi_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Product]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Product> list = new List<Lebi_Product>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Product> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Product]";
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
			List<Lebi_Product> list = new List<Lebi_Product>();
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
		public List<Lebi_Product> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Product] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Product> list = new List<Lebi_Product>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Product> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Product]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Product> list = new List<Lebi_Product>();
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
		public Lebi_Product BindForm(Lebi_Product model)
		{
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestInt("Pro_Type_id",0);
			if (HttpContext.Current.Request["Brand_id"] != null)
				model.Brand_id=Shop.Tools.RequestTool.RequestInt("Brand_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Number"] != null)
				model.Number=Shop.Tools.RequestTool.RequestString("Number");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Units_id"] != null)
				model.Units_id=Shop.Tools.RequestTool.RequestInt("Units_id",0);
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["Introduction"] != null)
				model.Introduction=Shop.Tools.RequestTool.RequestString("Introduction");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["MobileDescription"] != null)
				model.MobileDescription=Shop.Tools.RequestTool.RequestString("MobileDescription");
			if (HttpContext.Current.Request["Type_id_ProductStatus"] != null)
				model.Type_id_ProductStatus=Shop.Tools.RequestTool.RequestInt("Type_id_ProductStatus",0);
			if (HttpContext.Current.Request["Count_Like"] != null)
				model.Count_Like=Shop.Tools.RequestTool.RequestInt("Count_Like",0);
			if (HttpContext.Current.Request["Count_Sales_Show"] != null)
				model.Count_Sales_Show=Shop.Tools.RequestTool.RequestInt("Count_Sales_Show",0);
			if (HttpContext.Current.Request["Count_Sales"] != null)
				model.Count_Sales=Shop.Tools.RequestTool.RequestInt("Count_Sales",0);
			if (HttpContext.Current.Request["Count_Views_Show"] != null)
				model.Count_Views_Show=Shop.Tools.RequestTool.RequestInt("Count_Views_Show",0);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Count_Stock"] != null)
				model.Count_Stock=Shop.Tools.RequestTool.RequestInt("Count_Stock",0);
			if (HttpContext.Current.Request["Count_StockCaution"] != null)
				model.Count_StockCaution=Shop.Tools.RequestTool.RequestInt("Count_StockCaution",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["Price_Market"] != null)
				model.Price_Market=Shop.Tools.RequestTool.RequestDecimal("Price_Market",0);
			if (HttpContext.Current.Request["Price_Cost"] != null)
				model.Price_Cost=Shop.Tools.RequestTool.RequestDecimal("Price_Cost",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Images"] != null)
				model.Images=Shop.Tools.RequestTool.RequestString("Images");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestString("ImageOriginal");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_OnSale"] != null)
				model.Time_OnSale=Shop.Tools.RequestTool.RequestTime("Time_OnSale", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Tags"] != null)
				model.Tags=Shop.Tools.RequestTool.RequestString("Tags");
			if (HttpContext.Current.Request["Pro_Tag_id"] != null)
				model.Pro_Tag_id=Shop.Tools.RequestTool.RequestString("Pro_Tag_id");
			if (HttpContext.Current.Request["ProPerty132"] != null)
				model.ProPerty132=Shop.Tools.RequestTool.RequestString("ProPerty132");
			if (HttpContext.Current.Request["ProPerty131"] != null)
				model.ProPerty131=Shop.Tools.RequestTool.RequestString("ProPerty131");
			if (HttpContext.Current.Request["ProPerty133"] != null)
				model.ProPerty133=Shop.Tools.RequestTool.RequestString("ProPerty133");
			if (HttpContext.Current.Request["Service"] != null)
				model.Service=Shop.Tools.RequestTool.RequestString("Service");
			if (HttpContext.Current.Request["Remarks"] != null)
				model.Remarks=Shop.Tools.RequestTool.RequestString("Remarks");
			if (HttpContext.Current.Request["Count_ViewsFalse"] != null)
				model.Count_ViewsFalse=Shop.Tools.RequestTool.RequestInt("Count_ViewsFalse",0);
			if (HttpContext.Current.Request["Count_SalesFalse"] != null)
				model.Count_SalesFalse=Shop.Tools.RequestTool.RequestInt("Count_SalesFalse",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Packing"] != null)
				model.Packing=Shop.Tools.RequestTool.RequestString("Packing");
			if (HttpContext.Current.Request["Specification"] != null)
				model.Specification=Shop.Tools.RequestTool.RequestString("Specification");
			if (HttpContext.Current.Request["Star_Comment"] != null)
				model.Star_Comment=Shop.Tools.RequestTool.RequestDecimal("Star_Comment",0);
			if (HttpContext.Current.Request["Count_Comment"] != null)
				model.Count_Comment=Shop.Tools.RequestTool.RequestInt("Count_Comment",0);
			if (HttpContext.Current.Request["Count_Freeze"] != null)
				model.Count_Freeze=Shop.Tools.RequestTool.RequestInt("Count_Freeze",0);
			if (HttpContext.Current.Request["ProPertyMain"] != null)
				model.ProPertyMain=Shop.Tools.RequestTool.RequestInt("ProPertyMain",0);
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestString("taobaoid");
			if (HttpContext.Current.Request["taobaoid_type"] != null)
				model.taobaoid_type=Shop.Tools.RequestTool.RequestString("taobaoid_type");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["VolumeL"] != null)
				model.VolumeL=Shop.Tools.RequestTool.RequestDecimal("VolumeL",0);
			if (HttpContext.Current.Request["VolumeW"] != null)
				model.VolumeW=Shop.Tools.RequestTool.RequestDecimal("VolumeW",0);
			if (HttpContext.Current.Request["VolumeH"] != null)
				model.VolumeH=Shop.Tools.RequestTool.RequestDecimal("VolumeH",0);
			if (HttpContext.Current.Request["PackageRate"] != null)
				model.PackageRate=Shop.Tools.RequestTool.RequestInt("PackageRate",0);
			if (HttpContext.Current.Request["Time_Expired"] != null)
				model.Time_Expired=Shop.Tools.RequestTool.RequestTime("Time_Expired", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Limit"] != null)
				model.Count_Limit=Shop.Tools.RequestTool.RequestInt("Count_Limit",0);
			if (HttpContext.Current.Request["Price_Sale"] != null)
				model.Price_Sale=Shop.Tools.RequestTool.RequestDecimal("Price_Sale",0);
			if (HttpContext.Current.Request["Type_id_ProductType"] != null)
				model.Type_id_ProductType=Shop.Tools.RequestTool.RequestInt("Type_id_ProductType",0);
			if (HttpContext.Current.Request["NetWeight"] != null)
				model.NetWeight=Shop.Tools.RequestTool.RequestDecimal("NetWeight",0);
			if (HttpContext.Current.Request["Pro_Type_id_other"] != null)
				model.Pro_Type_id_other=Shop.Tools.RequestTool.RequestString("Pro_Type_id_other");
			if (HttpContext.Current.Request["Supplier_ProductType_ids"] != null)
				model.Supplier_ProductType_ids=Shop.Tools.RequestTool.RequestString("Supplier_ProductType_ids");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestString("Site_ids");
			if (HttpContext.Current.Request["Time_Start"] != null)
				model.Time_Start=Shop.Tools.RequestTool.RequestTime("Time_Start", System.DateTime.Now);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestString("ProPerty134");
			if (HttpContext.Current.Request["FreezeRemark"] != null)
				model.FreezeRemark=Shop.Tools.RequestTool.RequestString("FreezeRemark");
			if (HttpContext.Current.Request["StepPrice"] != null)
				model.StepPrice=Shop.Tools.RequestTool.RequestString("StepPrice");
			if (HttpContext.Current.Request["UserLevelPrice"] != null)
				model.UserLevelPrice=Shop.Tools.RequestTool.RequestString("UserLevelPrice");
			if (HttpContext.Current.Request["UserLevel_ids_show"] != null)
				model.UserLevel_ids_show=Shop.Tools.RequestTool.RequestString("UserLevel_ids_show");
			if (HttpContext.Current.Request["UserLevel_ids_priceshow"] != null)
				model.UserLevel_ids_priceshow=Shop.Tools.RequestTool.RequestString("UserLevel_ids_priceshow");
			if (HttpContext.Current.Request["UserLevel_ids_buy"] != null)
				model.UserLevel_ids_buy=Shop.Tools.RequestTool.RequestString("UserLevel_ids_buy");
			if (HttpContext.Current.Request["IsNullStockSale"] != null)
				model.IsNullStockSale=Shop.Tools.RequestTool.RequestInt("IsNullStockSale",0);
			if (HttpContext.Current.Request["Price_reserve"] != null)
				model.Price_reserve=Shop.Tools.RequestTool.RequestDecimal("Price_reserve",0);
			if (HttpContext.Current.Request["Price_reserve_per"] != null)
				model.Price_reserve_per=Shop.Tools.RequestTool.RequestDecimal("Price_reserve_per",0);
			if (HttpContext.Current.Request["Reserve_days"] != null)
				model.Reserve_days=Shop.Tools.RequestTool.RequestInt("Reserve_days",0);
			if (HttpContext.Current.Request["IsCombo"] != null)
				model.IsCombo=Shop.Tools.RequestTool.RequestInt("IsCombo",0);
			if (HttpContext.Current.Request["UserLevelCount"] != null)
				model.UserLevelCount=Shop.Tools.RequestTool.RequestString("UserLevelCount");
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Product SafeBindForm(Lebi_Product model)
		{
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestInt("Pro_Type_id",0);
			if (HttpContext.Current.Request["Brand_id"] != null)
				model.Brand_id=Shop.Tools.RequestTool.RequestInt("Brand_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Number"] != null)
				model.Number=Shop.Tools.RequestTool.RequestSafeString("Number");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Units_id"] != null)
				model.Units_id=Shop.Tools.RequestTool.RequestInt("Units_id",0);
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["Introduction"] != null)
				model.Introduction=Shop.Tools.RequestTool.RequestSafeString("Introduction");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["MobileDescription"] != null)
				model.MobileDescription=Shop.Tools.RequestTool.RequestSafeString("MobileDescription");
			if (HttpContext.Current.Request["Type_id_ProductStatus"] != null)
				model.Type_id_ProductStatus=Shop.Tools.RequestTool.RequestInt("Type_id_ProductStatus",0);
			if (HttpContext.Current.Request["Count_Like"] != null)
				model.Count_Like=Shop.Tools.RequestTool.RequestInt("Count_Like",0);
			if (HttpContext.Current.Request["Count_Sales_Show"] != null)
				model.Count_Sales_Show=Shop.Tools.RequestTool.RequestInt("Count_Sales_Show",0);
			if (HttpContext.Current.Request["Count_Sales"] != null)
				model.Count_Sales=Shop.Tools.RequestTool.RequestInt("Count_Sales",0);
			if (HttpContext.Current.Request["Count_Views_Show"] != null)
				model.Count_Views_Show=Shop.Tools.RequestTool.RequestInt("Count_Views_Show",0);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Count_Stock"] != null)
				model.Count_Stock=Shop.Tools.RequestTool.RequestInt("Count_Stock",0);
			if (HttpContext.Current.Request["Count_StockCaution"] != null)
				model.Count_StockCaution=Shop.Tools.RequestTool.RequestInt("Count_StockCaution",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["Price_Market"] != null)
				model.Price_Market=Shop.Tools.RequestTool.RequestDecimal("Price_Market",0);
			if (HttpContext.Current.Request["Price_Cost"] != null)
				model.Price_Cost=Shop.Tools.RequestTool.RequestDecimal("Price_Cost",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Images"] != null)
				model.Images=Shop.Tools.RequestTool.RequestSafeString("Images");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestSafeString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestSafeString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestSafeString("ImageOriginal");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_OnSale"] != null)
				model.Time_OnSale=Shop.Tools.RequestTool.RequestTime("Time_OnSale", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Tags"] != null)
				model.Tags=Shop.Tools.RequestTool.RequestSafeString("Tags");
			if (HttpContext.Current.Request["Pro_Tag_id"] != null)
				model.Pro_Tag_id=Shop.Tools.RequestTool.RequestSafeString("Pro_Tag_id");
			if (HttpContext.Current.Request["ProPerty132"] != null)
				model.ProPerty132=Shop.Tools.RequestTool.RequestSafeString("ProPerty132");
			if (HttpContext.Current.Request["ProPerty131"] != null)
				model.ProPerty131=Shop.Tools.RequestTool.RequestSafeString("ProPerty131");
			if (HttpContext.Current.Request["ProPerty133"] != null)
				model.ProPerty133=Shop.Tools.RequestTool.RequestSafeString("ProPerty133");
			if (HttpContext.Current.Request["Service"] != null)
				model.Service=Shop.Tools.RequestTool.RequestSafeString("Service");
			if (HttpContext.Current.Request["Remarks"] != null)
				model.Remarks=Shop.Tools.RequestTool.RequestSafeString("Remarks");
			if (HttpContext.Current.Request["Count_ViewsFalse"] != null)
				model.Count_ViewsFalse=Shop.Tools.RequestTool.RequestInt("Count_ViewsFalse",0);
			if (HttpContext.Current.Request["Count_SalesFalse"] != null)
				model.Count_SalesFalse=Shop.Tools.RequestTool.RequestInt("Count_SalesFalse",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Packing"] != null)
				model.Packing=Shop.Tools.RequestTool.RequestSafeString("Packing");
			if (HttpContext.Current.Request["Specification"] != null)
				model.Specification=Shop.Tools.RequestTool.RequestSafeString("Specification");
			if (HttpContext.Current.Request["Star_Comment"] != null)
				model.Star_Comment=Shop.Tools.RequestTool.RequestDecimal("Star_Comment",0);
			if (HttpContext.Current.Request["Count_Comment"] != null)
				model.Count_Comment=Shop.Tools.RequestTool.RequestInt("Count_Comment",0);
			if (HttpContext.Current.Request["Count_Freeze"] != null)
				model.Count_Freeze=Shop.Tools.RequestTool.RequestInt("Count_Freeze",0);
			if (HttpContext.Current.Request["ProPertyMain"] != null)
				model.ProPertyMain=Shop.Tools.RequestTool.RequestInt("ProPertyMain",0);
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestSafeString("taobaoid");
			if (HttpContext.Current.Request["taobaoid_type"] != null)
				model.taobaoid_type=Shop.Tools.RequestTool.RequestSafeString("taobaoid_type");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["VolumeL"] != null)
				model.VolumeL=Shop.Tools.RequestTool.RequestDecimal("VolumeL",0);
			if (HttpContext.Current.Request["VolumeW"] != null)
				model.VolumeW=Shop.Tools.RequestTool.RequestDecimal("VolumeW",0);
			if (HttpContext.Current.Request["VolumeH"] != null)
				model.VolumeH=Shop.Tools.RequestTool.RequestDecimal("VolumeH",0);
			if (HttpContext.Current.Request["PackageRate"] != null)
				model.PackageRate=Shop.Tools.RequestTool.RequestInt("PackageRate",0);
			if (HttpContext.Current.Request["Time_Expired"] != null)
				model.Time_Expired=Shop.Tools.RequestTool.RequestTime("Time_Expired", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Limit"] != null)
				model.Count_Limit=Shop.Tools.RequestTool.RequestInt("Count_Limit",0);
			if (HttpContext.Current.Request["Price_Sale"] != null)
				model.Price_Sale=Shop.Tools.RequestTool.RequestDecimal("Price_Sale",0);
			if (HttpContext.Current.Request["Type_id_ProductType"] != null)
				model.Type_id_ProductType=Shop.Tools.RequestTool.RequestInt("Type_id_ProductType",0);
			if (HttpContext.Current.Request["NetWeight"] != null)
				model.NetWeight=Shop.Tools.RequestTool.RequestDecimal("NetWeight",0);
			if (HttpContext.Current.Request["Pro_Type_id_other"] != null)
				model.Pro_Type_id_other=Shop.Tools.RequestTool.RequestSafeString("Pro_Type_id_other");
			if (HttpContext.Current.Request["Supplier_ProductType_ids"] != null)
				model.Supplier_ProductType_ids=Shop.Tools.RequestTool.RequestSafeString("Supplier_ProductType_ids");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestSafeString("Site_ids");
			if (HttpContext.Current.Request["Time_Start"] != null)
				model.Time_Start=Shop.Tools.RequestTool.RequestTime("Time_Start", System.DateTime.Now);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestSafeString("ProPerty134");
			if (HttpContext.Current.Request["FreezeRemark"] != null)
				model.FreezeRemark=Shop.Tools.RequestTool.RequestSafeString("FreezeRemark");
			if (HttpContext.Current.Request["StepPrice"] != null)
				model.StepPrice=Shop.Tools.RequestTool.RequestSafeString("StepPrice");
			if (HttpContext.Current.Request["UserLevelPrice"] != null)
				model.UserLevelPrice=Shop.Tools.RequestTool.RequestSafeString("UserLevelPrice");
			if (HttpContext.Current.Request["UserLevel_ids_show"] != null)
				model.UserLevel_ids_show=Shop.Tools.RequestTool.RequestSafeString("UserLevel_ids_show");
			if (HttpContext.Current.Request["UserLevel_ids_priceshow"] != null)
				model.UserLevel_ids_priceshow=Shop.Tools.RequestTool.RequestSafeString("UserLevel_ids_priceshow");
			if (HttpContext.Current.Request["UserLevel_ids_buy"] != null)
				model.UserLevel_ids_buy=Shop.Tools.RequestTool.RequestSafeString("UserLevel_ids_buy");
			if (HttpContext.Current.Request["IsNullStockSale"] != null)
				model.IsNullStockSale=Shop.Tools.RequestTool.RequestInt("IsNullStockSale",0);
			if (HttpContext.Current.Request["Price_reserve"] != null)
				model.Price_reserve=Shop.Tools.RequestTool.RequestDecimal("Price_reserve",0);
			if (HttpContext.Current.Request["Price_reserve_per"] != null)
				model.Price_reserve_per=Shop.Tools.RequestTool.RequestDecimal("Price_reserve_per",0);
			if (HttpContext.Current.Request["Reserve_days"] != null)
				model.Reserve_days=Shop.Tools.RequestTool.RequestInt("Reserve_days",0);
			if (HttpContext.Current.Request["IsCombo"] != null)
				model.IsCombo=Shop.Tools.RequestTool.RequestInt("IsCombo",0);
			if (HttpContext.Current.Request["UserLevelCount"] != null)
				model.UserLevelCount=Shop.Tools.RequestTool.RequestSafeString("UserLevelCount");
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Product ReaderBind(IDataReader dataReader)
		{
			Lebi_Product model=new Lebi_Product();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Pro_Type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pro_Type_id=(int)ojb;
			}
			ojb = dataReader["Brand_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Brand_id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			model.Number=dataReader["Number"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["Units_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Units_id=(int)ojb;
			}
			ojb = dataReader["Weight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight=(decimal)ojb;
			}
			model.Introduction=dataReader["Introduction"].ToString();
			model.Description=dataReader["Description"].ToString();
			model.MobileDescription=dataReader["MobileDescription"].ToString();
			ojb = dataReader["Type_id_ProductStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_ProductStatus=(int)ojb;
			}
			ojb = dataReader["Count_Like"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Like=(int)ojb;
			}
			ojb = dataReader["Count_Sales_Show"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Sales_Show=(int)ojb;
			}
			ojb = dataReader["Count_Sales"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Sales=(int)ojb;
			}
			ojb = dataReader["Count_Views_Show"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Views_Show=(int)ojb;
			}
			ojb = dataReader["Count_Views"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Views=(int)ojb;
			}
			ojb = dataReader["Count_Stock"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Stock=(int)ojb;
			}
			ojb = dataReader["Count_StockCaution"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_StockCaution=(int)ojb;
			}
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			ojb = dataReader["Price_Market"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Market=(decimal)ojb;
			}
			ojb = dataReader["Price_Cost"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Cost=(decimal)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			model.Images=dataReader["Images"].ToString();
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.ImageMedium=dataReader["ImageMedium"].ToString();
			model.ImageBig=dataReader["ImageBig"].ToString();
			model.ImageOriginal=dataReader["ImageOriginal"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_OnSale"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_OnSale=(DateTime)ojb;
			}
			ojb = dataReader["Time_Edit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Edit=(DateTime)ojb;
			}
			model.Tags=dataReader["Tags"].ToString();
			model.Pro_Tag_id=dataReader["Pro_Tag_id"].ToString();
			model.ProPerty132=dataReader["ProPerty132"].ToString();
			model.ProPerty131=dataReader["ProPerty131"].ToString();
			model.ProPerty133=dataReader["ProPerty133"].ToString();
			model.Service=dataReader["Service"].ToString();
			model.Remarks=dataReader["Remarks"].ToString();
			ojb = dataReader["Count_ViewsFalse"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_ViewsFalse=(int)ojb;
			}
			ojb = dataReader["Count_SalesFalse"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_SalesFalse=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			model.Packing=dataReader["Packing"].ToString();
			model.Specification=dataReader["Specification"].ToString();
			ojb = dataReader["Star_Comment"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Star_Comment=(decimal)ojb;
			}
			ojb = dataReader["Count_Comment"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Comment=(int)ojb;
			}
			ojb = dataReader["Count_Freeze"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Freeze=(int)ojb;
			}
			ojb = dataReader["ProPertyMain"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProPertyMain=(int)ojb;
			}
			model.taobaoid=dataReader["taobaoid"].ToString();
			model.taobaoid_type=dataReader["taobaoid_type"].ToString();
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
			ojb = dataReader["VolumeL"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VolumeL=(decimal)ojb;
			}
			ojb = dataReader["VolumeW"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VolumeW=(decimal)ojb;
			}
			ojb = dataReader["VolumeH"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VolumeH=(decimal)ojb;
			}
			ojb = dataReader["PackageRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PackageRate=(int)ojb;
			}
			ojb = dataReader["Time_Expired"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Expired=(DateTime)ojb;
			}
			ojb = dataReader["Count_Limit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Limit=(int)ojb;
			}
			ojb = dataReader["Price_Sale"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Sale=(decimal)ojb;
			}
			ojb = dataReader["Type_id_ProductType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_ProductType=(int)ojb;
			}
			ojb = dataReader["NetWeight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NetWeight=(decimal)ojb;
			}
			model.Pro_Type_id_other=dataReader["Pro_Type_id_other"].ToString();
			model.Supplier_ProductType_ids=dataReader["Supplier_ProductType_ids"].ToString();
			model.Site_ids=dataReader["Site_ids"].ToString();
			ojb = dataReader["Time_Start"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Start=(DateTime)ojb;
			}
			model.ProPerty134=dataReader["ProPerty134"].ToString();
			model.FreezeRemark=dataReader["FreezeRemark"].ToString();
			model.StepPrice=dataReader["StepPrice"].ToString();
			model.UserLevelPrice=dataReader["UserLevelPrice"].ToString();
			model.UserLevel_ids_show=dataReader["UserLevel_ids_show"].ToString();
			model.UserLevel_ids_priceshow=dataReader["UserLevel_ids_priceshow"].ToString();
			model.UserLevel_ids_buy=dataReader["UserLevel_ids_buy"].ToString();
			ojb = dataReader["IsNullStockSale"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsNullStockSale=(int)ojb;
			}
			ojb = dataReader["Price_reserve"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_reserve=(decimal)ojb;
			}
			ojb = dataReader["Price_reserve_per"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_reserve_per=(decimal)ojb;
			}
			ojb = dataReader["Reserve_days"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Reserve_days=(int)ojb;
			}
			ojb = dataReader["IsCombo"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCombo=(int)ojb;
			}
			model.UserLevelCount=dataReader["UserLevelCount"].ToString();
			ojb = dataReader["IsDel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDel=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Product : Lebi_Product_interface
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
				strSql.Append("select " + colName + " from [Lebi_Product]");
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
			strSql.Append("select  "+colName+" from [Lebi_Product]");
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
			strSql.Append("select count(*) from [Lebi_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Product]");
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
			strSql.Append("select max(id) from [Lebi_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Product]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Product](");
			strSql.Append("[Pro_Type_id],[Brand_id],[Name],[Sort],[Number],[Code],[Units_id],[Weight],[Introduction],[Description],[MobileDescription],[Type_id_ProductStatus],[Count_Like],[Count_Sales_Show],[Count_Sales],[Count_Views_Show],[Count_Views],[Count_Stock],[Count_StockCaution],[SEO_Title],[SEO_Description],[SEO_Keywords],[Price_Market],[Price_Cost],[Price],[Images],[ImageSmall],[ImageMedium],[ImageBig],[ImageOriginal],[Time_Add],[Time_OnSale],[Time_Edit],[Tags],[Pro_Tag_id],[ProPerty132],[ProPerty131],[ProPerty133],[Service],[Remarks],[Count_ViewsFalse],[Count_SalesFalse],[Product_id],[Packing],[Specification],[Star_Comment],[Count_Comment],[Count_Freeze],[ProPertyMain],[taobaoid],[taobaoid_type],[Supplier_id],[IsSupplierTransport],[VolumeL],[VolumeW],[VolumeH],[PackageRate],[Time_Expired],[Count_Limit],[Price_Sale],[Type_id_ProductType],[NetWeight],[Pro_Type_id_other],[Supplier_ProductType_ids],[Site_ids],[Time_Start],[ProPerty134],[FreezeRemark],[StepPrice],[UserLevelPrice],[UserLevel_ids_show],[UserLevel_ids_priceshow],[UserLevel_ids_buy],[IsNullStockSale],[Price_reserve],[Price_reserve_per],[Reserve_days],[IsCombo],[UserLevelCount],[IsDel])");
			strSql.Append(" values (");
			strSql.Append("@Pro_Type_id,@Brand_id,@Name,@Sort,@Number,@Code,@Units_id,@Weight,@Introduction,@Description,@MobileDescription,@Type_id_ProductStatus,@Count_Like,@Count_Sales_Show,@Count_Sales,@Count_Views_Show,@Count_Views,@Count_Stock,@Count_StockCaution,@SEO_Title,@SEO_Description,@SEO_Keywords,@Price_Market,@Price_Cost,@Price,@Images,@ImageSmall,@ImageMedium,@ImageBig,@ImageOriginal,@Time_Add,@Time_OnSale,@Time_Edit,@Tags,@Pro_Tag_id,@ProPerty132,@ProPerty131,@ProPerty133,@Service,@Remarks,@Count_ViewsFalse,@Count_SalesFalse,@Product_id,@Packing,@Specification,@Star_Comment,@Count_Comment,@Count_Freeze,@ProPertyMain,@taobaoid,@taobaoid_type,@Supplier_id,@IsSupplierTransport,@VolumeL,@VolumeW,@VolumeH,@PackageRate,@Time_Expired,@Count_Limit,@Price_Sale,@Type_id_ProductType,@NetWeight,@Pro_Type_id_other,@Supplier_ProductType_ids,@Site_ids,@Time_Start,@ProPerty134,@FreezeRemark,@StepPrice,@UserLevelPrice,@UserLevel_ids_show,@UserLevel_ids_priceshow,@UserLevel_ids_buy,@IsNullStockSale,@Price_reserve,@Price_reserve_per,@Reserve_days,@IsCombo,@UserLevelCount,@IsDel)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Pro_Type_id", model.Pro_Type_id),
					new OleDbParameter("@Brand_id", model.Brand_id),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Number", model.Number),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Units_id", model.Units_id),
					new OleDbParameter("@Weight", model.Weight),
					new OleDbParameter("@Introduction", model.Introduction),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@MobileDescription", model.MobileDescription),
					new OleDbParameter("@Type_id_ProductStatus", model.Type_id_ProductStatus),
					new OleDbParameter("@Count_Like", model.Count_Like),
					new OleDbParameter("@Count_Sales_Show", model.Count_Sales_Show),
					new OleDbParameter("@Count_Sales", model.Count_Sales),
					new OleDbParameter("@Count_Views_Show", model.Count_Views_Show),
					new OleDbParameter("@Count_Views", model.Count_Views),
					new OleDbParameter("@Count_Stock", model.Count_Stock),
					new OleDbParameter("@Count_StockCaution", model.Count_StockCaution),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@Price_Market", model.Price_Market),
					new OleDbParameter("@Price_Cost", model.Price_Cost),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Images", model.Images),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@ImageMedium", model.ImageMedium),
					new OleDbParameter("@ImageBig", model.ImageBig),
					new OleDbParameter("@ImageOriginal", model.ImageOriginal),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_OnSale", model.Time_OnSale.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Edit", model.Time_Edit.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Tags", model.Tags),
					new OleDbParameter("@Pro_Tag_id", model.Pro_Tag_id),
					new OleDbParameter("@ProPerty132", model.ProPerty132),
					new OleDbParameter("@ProPerty131", model.ProPerty131),
					new OleDbParameter("@ProPerty133", model.ProPerty133),
					new OleDbParameter("@Service", model.Service),
					new OleDbParameter("@Remarks", model.Remarks),
					new OleDbParameter("@Count_ViewsFalse", model.Count_ViewsFalse),
					new OleDbParameter("@Count_SalesFalse", model.Count_SalesFalse),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Packing", model.Packing),
					new OleDbParameter("@Specification", model.Specification),
					new OleDbParameter("@Star_Comment", model.Star_Comment),
					new OleDbParameter("@Count_Comment", model.Count_Comment),
					new OleDbParameter("@Count_Freeze", model.Count_Freeze),
					new OleDbParameter("@ProPertyMain", model.ProPertyMain),
					new OleDbParameter("@taobaoid", model.taobaoid),
					new OleDbParameter("@taobaoid_type", model.taobaoid_type),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@IsSupplierTransport", model.IsSupplierTransport),
					new OleDbParameter("@VolumeL", model.VolumeL),
					new OleDbParameter("@VolumeW", model.VolumeW),
					new OleDbParameter("@VolumeH", model.VolumeH),
					new OleDbParameter("@PackageRate", model.PackageRate),
					new OleDbParameter("@Time_Expired", model.Time_Expired.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Count_Limit", model.Count_Limit),
					new OleDbParameter("@Price_Sale", model.Price_Sale),
					new OleDbParameter("@Type_id_ProductType", model.Type_id_ProductType),
					new OleDbParameter("@NetWeight", model.NetWeight),
					new OleDbParameter("@Pro_Type_id_other", model.Pro_Type_id_other),
					new OleDbParameter("@Supplier_ProductType_ids", model.Supplier_ProductType_ids),
					new OleDbParameter("@Site_ids", model.Site_ids),
					new OleDbParameter("@Time_Start", model.Time_Start.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@ProPerty134", model.ProPerty134),
					new OleDbParameter("@FreezeRemark", model.FreezeRemark),
					new OleDbParameter("@StepPrice", model.StepPrice),
					new OleDbParameter("@UserLevelPrice", model.UserLevelPrice),
					new OleDbParameter("@UserLevel_ids_show", model.UserLevel_ids_show),
					new OleDbParameter("@UserLevel_ids_priceshow", model.UserLevel_ids_priceshow),
					new OleDbParameter("@UserLevel_ids_buy", model.UserLevel_ids_buy),
					new OleDbParameter("@IsNullStockSale", model.IsNullStockSale),
					new OleDbParameter("@Price_reserve", model.Price_reserve),
					new OleDbParameter("@Price_reserve_per", model.Price_reserve_per),
					new OleDbParameter("@Reserve_days", model.Reserve_days),
					new OleDbParameter("@IsCombo", model.IsCombo),
					new OleDbParameter("@UserLevelCount", model.UserLevelCount),
					new OleDbParameter("@IsDel", model.IsDel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Product] set ");
			strSql.Append("[Pro_Type_id]=@Pro_Type_id,");
			strSql.Append("[Brand_id]=@Brand_id,");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Number]=@Number,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[Units_id]=@Units_id,");
			strSql.Append("[Weight]=@Weight,");
			strSql.Append("[Introduction]=@Introduction,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[MobileDescription]=@MobileDescription,");
			strSql.Append("[Type_id_ProductStatus]=@Type_id_ProductStatus,");
			strSql.Append("[Count_Like]=@Count_Like,");
			strSql.Append("[Count_Sales_Show]=@Count_Sales_Show,");
			strSql.Append("[Count_Sales]=@Count_Sales,");
			strSql.Append("[Count_Views_Show]=@Count_Views_Show,");
			strSql.Append("[Count_Views]=@Count_Views,");
			strSql.Append("[Count_Stock]=@Count_Stock,");
			strSql.Append("[Count_StockCaution]=@Count_StockCaution,");
			strSql.Append("[SEO_Title]=@SEO_Title,");
			strSql.Append("[SEO_Description]=@SEO_Description,");
			strSql.Append("[SEO_Keywords]=@SEO_Keywords,");
			strSql.Append("[Price_Market]=@Price_Market,");
			strSql.Append("[Price_Cost]=@Price_Cost,");
			strSql.Append("[Price]=@Price,");
			strSql.Append("[Images]=@Images,");
			strSql.Append("[ImageSmall]=@ImageSmall,");
			strSql.Append("[ImageMedium]=@ImageMedium,");
			strSql.Append("[ImageBig]=@ImageBig,");
			strSql.Append("[ImageOriginal]=@ImageOriginal,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_OnSale]=@Time_OnSale,");
			strSql.Append("[Time_Edit]=@Time_Edit,");
			strSql.Append("[Tags]=@Tags,");
			strSql.Append("[Pro_Tag_id]=@Pro_Tag_id,");
			strSql.Append("[ProPerty132]=@ProPerty132,");
			strSql.Append("[ProPerty131]=@ProPerty131,");
			strSql.Append("[ProPerty133]=@ProPerty133,");
			strSql.Append("[Service]=@Service,");
			strSql.Append("[Remarks]=@Remarks,");
			strSql.Append("[Count_ViewsFalse]=@Count_ViewsFalse,");
			strSql.Append("[Count_SalesFalse]=@Count_SalesFalse,");
			strSql.Append("[Product_id]=@Product_id,");
			strSql.Append("[Packing]=@Packing,");
			strSql.Append("[Specification]=@Specification,");
			strSql.Append("[Star_Comment]=@Star_Comment,");
			strSql.Append("[Count_Comment]=@Count_Comment,");
			strSql.Append("[Count_Freeze]=@Count_Freeze,");
			strSql.Append("[ProPertyMain]=@ProPertyMain,");
			strSql.Append("[taobaoid]=@taobaoid,");
			strSql.Append("[taobaoid_type]=@taobaoid_type,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[IsSupplierTransport]=@IsSupplierTransport,");
			strSql.Append("[VolumeL]=@VolumeL,");
			strSql.Append("[VolumeW]=@VolumeW,");
			strSql.Append("[VolumeH]=@VolumeH,");
			strSql.Append("[PackageRate]=@PackageRate,");
			strSql.Append("[Time_Expired]=@Time_Expired,");
			strSql.Append("[Count_Limit]=@Count_Limit,");
			strSql.Append("[Price_Sale]=@Price_Sale,");
			strSql.Append("[Type_id_ProductType]=@Type_id_ProductType,");
			strSql.Append("[NetWeight]=@NetWeight,");
			strSql.Append("[Pro_Type_id_other]=@Pro_Type_id_other,");
			strSql.Append("[Supplier_ProductType_ids]=@Supplier_ProductType_ids,");
			strSql.Append("[Site_ids]=@Site_ids,");
			strSql.Append("[Time_Start]=@Time_Start,");
			strSql.Append("[ProPerty134]=@ProPerty134,");
			strSql.Append("[FreezeRemark]=@FreezeRemark,");
			strSql.Append("[StepPrice]=@StepPrice,");
			strSql.Append("[UserLevelPrice]=@UserLevelPrice,");
			strSql.Append("[UserLevel_ids_show]=@UserLevel_ids_show,");
			strSql.Append("[UserLevel_ids_priceshow]=@UserLevel_ids_priceshow,");
			strSql.Append("[UserLevel_ids_buy]=@UserLevel_ids_buy,");
			strSql.Append("[IsNullStockSale]=@IsNullStockSale,");
			strSql.Append("[Price_reserve]=@Price_reserve,");
			strSql.Append("[Price_reserve_per]=@Price_reserve_per,");
			strSql.Append("[Reserve_days]=@Reserve_days,");
			strSql.Append("[IsCombo]=@IsCombo,");
			strSql.Append("[UserLevelCount]=@UserLevelCount,");
			strSql.Append("[IsDel]=@IsDel");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Pro_Type_id", model.Pro_Type_id),
					new OleDbParameter("@Brand_id", model.Brand_id),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Number", model.Number),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Units_id", model.Units_id),
					new OleDbParameter("@Weight", model.Weight),
					new OleDbParameter("@Introduction", model.Introduction),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@MobileDescription", model.MobileDescription),
					new OleDbParameter("@Type_id_ProductStatus", model.Type_id_ProductStatus),
					new OleDbParameter("@Count_Like", model.Count_Like),
					new OleDbParameter("@Count_Sales_Show", model.Count_Sales_Show),
					new OleDbParameter("@Count_Sales", model.Count_Sales),
					new OleDbParameter("@Count_Views_Show", model.Count_Views_Show),
					new OleDbParameter("@Count_Views", model.Count_Views),
					new OleDbParameter("@Count_Stock", model.Count_Stock),
					new OleDbParameter("@Count_StockCaution", model.Count_StockCaution),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@Price_Market", model.Price_Market),
					new OleDbParameter("@Price_Cost", model.Price_Cost),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Images", model.Images),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@ImageMedium", model.ImageMedium),
					new OleDbParameter("@ImageBig", model.ImageBig),
					new OleDbParameter("@ImageOriginal", model.ImageOriginal),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_OnSale", model.Time_OnSale.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Edit", model.Time_Edit.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Tags", model.Tags),
					new OleDbParameter("@Pro_Tag_id", model.Pro_Tag_id),
					new OleDbParameter("@ProPerty132", model.ProPerty132),
					new OleDbParameter("@ProPerty131", model.ProPerty131),
					new OleDbParameter("@ProPerty133", model.ProPerty133),
					new OleDbParameter("@Service", model.Service),
					new OleDbParameter("@Remarks", model.Remarks),
					new OleDbParameter("@Count_ViewsFalse", model.Count_ViewsFalse),
					new OleDbParameter("@Count_SalesFalse", model.Count_SalesFalse),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Packing", model.Packing),
					new OleDbParameter("@Specification", model.Specification),
					new OleDbParameter("@Star_Comment", model.Star_Comment),
					new OleDbParameter("@Count_Comment", model.Count_Comment),
					new OleDbParameter("@Count_Freeze", model.Count_Freeze),
					new OleDbParameter("@ProPertyMain", model.ProPertyMain),
					new OleDbParameter("@taobaoid", model.taobaoid),
					new OleDbParameter("@taobaoid_type", model.taobaoid_type),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@IsSupplierTransport", model.IsSupplierTransport),
					new OleDbParameter("@VolumeL", model.VolumeL),
					new OleDbParameter("@VolumeW", model.VolumeW),
					new OleDbParameter("@VolumeH", model.VolumeH),
					new OleDbParameter("@PackageRate", model.PackageRate),
					new OleDbParameter("@Time_Expired", model.Time_Expired.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Count_Limit", model.Count_Limit),
					new OleDbParameter("@Price_Sale", model.Price_Sale),
					new OleDbParameter("@Type_id_ProductType", model.Type_id_ProductType),
					new OleDbParameter("@NetWeight", model.NetWeight),
					new OleDbParameter("@Pro_Type_id_other", model.Pro_Type_id_other),
					new OleDbParameter("@Supplier_ProductType_ids", model.Supplier_ProductType_ids),
					new OleDbParameter("@Site_ids", model.Site_ids),
					new OleDbParameter("@Time_Start", model.Time_Start.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@ProPerty134", model.ProPerty134),
					new OleDbParameter("@FreezeRemark", model.FreezeRemark),
					new OleDbParameter("@StepPrice", model.StepPrice),
					new OleDbParameter("@UserLevelPrice", model.UserLevelPrice),
					new OleDbParameter("@UserLevel_ids_show", model.UserLevel_ids_show),
					new OleDbParameter("@UserLevel_ids_priceshow", model.UserLevel_ids_priceshow),
					new OleDbParameter("@UserLevel_ids_buy", model.UserLevel_ids_buy),
					new OleDbParameter("@IsNullStockSale", model.IsNullStockSale),
					new OleDbParameter("@Price_reserve", model.Price_reserve),
					new OleDbParameter("@Price_reserve_per", model.Price_reserve_per),
					new OleDbParameter("@Reserve_days", model.Reserve_days),
					new OleDbParameter("@IsCombo", model.IsCombo),
					new OleDbParameter("@UserLevelCount", model.UserLevelCount),
					new OleDbParameter("@IsDel", model.IsDel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product] ");
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
			strSql.Append("delete from [Lebi_Product] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Product GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Product model;
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
		public Lebi_Product GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Product model;
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
		public Lebi_Product GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Product model;
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
		public List<Lebi_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Product]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Product> list = new List<Lebi_Product>();
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
		public List<Lebi_Product> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Product]";
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
			List<Lebi_Product> list = new List<Lebi_Product>();
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
		public List<Lebi_Product> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Product] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Product> list = new List<Lebi_Product>();
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
		public List<Lebi_Product> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Product]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Product> list = new List<Lebi_Product>();
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
		public Lebi_Product BindForm(Lebi_Product model)
		{
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestInt("Pro_Type_id",0);
			if (HttpContext.Current.Request["Brand_id"] != null)
				model.Brand_id=Shop.Tools.RequestTool.RequestInt("Brand_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Number"] != null)
				model.Number=Shop.Tools.RequestTool.RequestString("Number");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Units_id"] != null)
				model.Units_id=Shop.Tools.RequestTool.RequestInt("Units_id",0);
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["Introduction"] != null)
				model.Introduction=Shop.Tools.RequestTool.RequestString("Introduction");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["MobileDescription"] != null)
				model.MobileDescription=Shop.Tools.RequestTool.RequestString("MobileDescription");
			if (HttpContext.Current.Request["Type_id_ProductStatus"] != null)
				model.Type_id_ProductStatus=Shop.Tools.RequestTool.RequestInt("Type_id_ProductStatus",0);
			if (HttpContext.Current.Request["Count_Like"] != null)
				model.Count_Like=Shop.Tools.RequestTool.RequestInt("Count_Like",0);
			if (HttpContext.Current.Request["Count_Sales_Show"] != null)
				model.Count_Sales_Show=Shop.Tools.RequestTool.RequestInt("Count_Sales_Show",0);
			if (HttpContext.Current.Request["Count_Sales"] != null)
				model.Count_Sales=Shop.Tools.RequestTool.RequestInt("Count_Sales",0);
			if (HttpContext.Current.Request["Count_Views_Show"] != null)
				model.Count_Views_Show=Shop.Tools.RequestTool.RequestInt("Count_Views_Show",0);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Count_Stock"] != null)
				model.Count_Stock=Shop.Tools.RequestTool.RequestInt("Count_Stock",0);
			if (HttpContext.Current.Request["Count_StockCaution"] != null)
				model.Count_StockCaution=Shop.Tools.RequestTool.RequestInt("Count_StockCaution",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["Price_Market"] != null)
				model.Price_Market=Shop.Tools.RequestTool.RequestDecimal("Price_Market",0);
			if (HttpContext.Current.Request["Price_Cost"] != null)
				model.Price_Cost=Shop.Tools.RequestTool.RequestDecimal("Price_Cost",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Images"] != null)
				model.Images=Shop.Tools.RequestTool.RequestString("Images");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestString("ImageOriginal");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_OnSale"] != null)
				model.Time_OnSale=Shop.Tools.RequestTool.RequestTime("Time_OnSale", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Tags"] != null)
				model.Tags=Shop.Tools.RequestTool.RequestString("Tags");
			if (HttpContext.Current.Request["Pro_Tag_id"] != null)
				model.Pro_Tag_id=Shop.Tools.RequestTool.RequestString("Pro_Tag_id");
			if (HttpContext.Current.Request["ProPerty132"] != null)
				model.ProPerty132=Shop.Tools.RequestTool.RequestString("ProPerty132");
			if (HttpContext.Current.Request["ProPerty131"] != null)
				model.ProPerty131=Shop.Tools.RequestTool.RequestString("ProPerty131");
			if (HttpContext.Current.Request["ProPerty133"] != null)
				model.ProPerty133=Shop.Tools.RequestTool.RequestString("ProPerty133");
			if (HttpContext.Current.Request["Service"] != null)
				model.Service=Shop.Tools.RequestTool.RequestString("Service");
			if (HttpContext.Current.Request["Remarks"] != null)
				model.Remarks=Shop.Tools.RequestTool.RequestString("Remarks");
			if (HttpContext.Current.Request["Count_ViewsFalse"] != null)
				model.Count_ViewsFalse=Shop.Tools.RequestTool.RequestInt("Count_ViewsFalse",0);
			if (HttpContext.Current.Request["Count_SalesFalse"] != null)
				model.Count_SalesFalse=Shop.Tools.RequestTool.RequestInt("Count_SalesFalse",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Packing"] != null)
				model.Packing=Shop.Tools.RequestTool.RequestString("Packing");
			if (HttpContext.Current.Request["Specification"] != null)
				model.Specification=Shop.Tools.RequestTool.RequestString("Specification");
			if (HttpContext.Current.Request["Star_Comment"] != null)
				model.Star_Comment=Shop.Tools.RequestTool.RequestDecimal("Star_Comment",0);
			if (HttpContext.Current.Request["Count_Comment"] != null)
				model.Count_Comment=Shop.Tools.RequestTool.RequestInt("Count_Comment",0);
			if (HttpContext.Current.Request["Count_Freeze"] != null)
				model.Count_Freeze=Shop.Tools.RequestTool.RequestInt("Count_Freeze",0);
			if (HttpContext.Current.Request["ProPertyMain"] != null)
				model.ProPertyMain=Shop.Tools.RequestTool.RequestInt("ProPertyMain",0);
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestString("taobaoid");
			if (HttpContext.Current.Request["taobaoid_type"] != null)
				model.taobaoid_type=Shop.Tools.RequestTool.RequestString("taobaoid_type");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["VolumeL"] != null)
				model.VolumeL=Shop.Tools.RequestTool.RequestDecimal("VolumeL",0);
			if (HttpContext.Current.Request["VolumeW"] != null)
				model.VolumeW=Shop.Tools.RequestTool.RequestDecimal("VolumeW",0);
			if (HttpContext.Current.Request["VolumeH"] != null)
				model.VolumeH=Shop.Tools.RequestTool.RequestDecimal("VolumeH",0);
			if (HttpContext.Current.Request["PackageRate"] != null)
				model.PackageRate=Shop.Tools.RequestTool.RequestInt("PackageRate",0);
			if (HttpContext.Current.Request["Time_Expired"] != null)
				model.Time_Expired=Shop.Tools.RequestTool.RequestTime("Time_Expired", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Limit"] != null)
				model.Count_Limit=Shop.Tools.RequestTool.RequestInt("Count_Limit",0);
			if (HttpContext.Current.Request["Price_Sale"] != null)
				model.Price_Sale=Shop.Tools.RequestTool.RequestDecimal("Price_Sale",0);
			if (HttpContext.Current.Request["Type_id_ProductType"] != null)
				model.Type_id_ProductType=Shop.Tools.RequestTool.RequestInt("Type_id_ProductType",0);
			if (HttpContext.Current.Request["NetWeight"] != null)
				model.NetWeight=Shop.Tools.RequestTool.RequestDecimal("NetWeight",0);
			if (HttpContext.Current.Request["Pro_Type_id_other"] != null)
				model.Pro_Type_id_other=Shop.Tools.RequestTool.RequestString("Pro_Type_id_other");
			if (HttpContext.Current.Request["Supplier_ProductType_ids"] != null)
				model.Supplier_ProductType_ids=Shop.Tools.RequestTool.RequestString("Supplier_ProductType_ids");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestString("Site_ids");
			if (HttpContext.Current.Request["Time_Start"] != null)
				model.Time_Start=Shop.Tools.RequestTool.RequestTime("Time_Start", System.DateTime.Now);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestString("ProPerty134");
			if (HttpContext.Current.Request["FreezeRemark"] != null)
				model.FreezeRemark=Shop.Tools.RequestTool.RequestString("FreezeRemark");
			if (HttpContext.Current.Request["StepPrice"] != null)
				model.StepPrice=Shop.Tools.RequestTool.RequestString("StepPrice");
			if (HttpContext.Current.Request["UserLevelPrice"] != null)
				model.UserLevelPrice=Shop.Tools.RequestTool.RequestString("UserLevelPrice");
			if (HttpContext.Current.Request["UserLevel_ids_show"] != null)
				model.UserLevel_ids_show=Shop.Tools.RequestTool.RequestString("UserLevel_ids_show");
			if (HttpContext.Current.Request["UserLevel_ids_priceshow"] != null)
				model.UserLevel_ids_priceshow=Shop.Tools.RequestTool.RequestString("UserLevel_ids_priceshow");
			if (HttpContext.Current.Request["UserLevel_ids_buy"] != null)
				model.UserLevel_ids_buy=Shop.Tools.RequestTool.RequestString("UserLevel_ids_buy");
			if (HttpContext.Current.Request["IsNullStockSale"] != null)
				model.IsNullStockSale=Shop.Tools.RequestTool.RequestInt("IsNullStockSale",0);
			if (HttpContext.Current.Request["Price_reserve"] != null)
				model.Price_reserve=Shop.Tools.RequestTool.RequestDecimal("Price_reserve",0);
			if (HttpContext.Current.Request["Price_reserve_per"] != null)
				model.Price_reserve_per=Shop.Tools.RequestTool.RequestDecimal("Price_reserve_per",0);
			if (HttpContext.Current.Request["Reserve_days"] != null)
				model.Reserve_days=Shop.Tools.RequestTool.RequestInt("Reserve_days",0);
			if (HttpContext.Current.Request["IsCombo"] != null)
				model.IsCombo=Shop.Tools.RequestTool.RequestInt("IsCombo",0);
			if (HttpContext.Current.Request["UserLevelCount"] != null)
				model.UserLevelCount=Shop.Tools.RequestTool.RequestString("UserLevelCount");
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Product SafeBindForm(Lebi_Product model)
		{
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestInt("Pro_Type_id",0);
			if (HttpContext.Current.Request["Brand_id"] != null)
				model.Brand_id=Shop.Tools.RequestTool.RequestInt("Brand_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Number"] != null)
				model.Number=Shop.Tools.RequestTool.RequestSafeString("Number");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Units_id"] != null)
				model.Units_id=Shop.Tools.RequestTool.RequestInt("Units_id",0);
			if (HttpContext.Current.Request["Weight"] != null)
				model.Weight=Shop.Tools.RequestTool.RequestDecimal("Weight",0);
			if (HttpContext.Current.Request["Introduction"] != null)
				model.Introduction=Shop.Tools.RequestTool.RequestSafeString("Introduction");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["MobileDescription"] != null)
				model.MobileDescription=Shop.Tools.RequestTool.RequestSafeString("MobileDescription");
			if (HttpContext.Current.Request["Type_id_ProductStatus"] != null)
				model.Type_id_ProductStatus=Shop.Tools.RequestTool.RequestInt("Type_id_ProductStatus",0);
			if (HttpContext.Current.Request["Count_Like"] != null)
				model.Count_Like=Shop.Tools.RequestTool.RequestInt("Count_Like",0);
			if (HttpContext.Current.Request["Count_Sales_Show"] != null)
				model.Count_Sales_Show=Shop.Tools.RequestTool.RequestInt("Count_Sales_Show",0);
			if (HttpContext.Current.Request["Count_Sales"] != null)
				model.Count_Sales=Shop.Tools.RequestTool.RequestInt("Count_Sales",0);
			if (HttpContext.Current.Request["Count_Views_Show"] != null)
				model.Count_Views_Show=Shop.Tools.RequestTool.RequestInt("Count_Views_Show",0);
			if (HttpContext.Current.Request["Count_Views"] != null)
				model.Count_Views=Shop.Tools.RequestTool.RequestInt("Count_Views",0);
			if (HttpContext.Current.Request["Count_Stock"] != null)
				model.Count_Stock=Shop.Tools.RequestTool.RequestInt("Count_Stock",0);
			if (HttpContext.Current.Request["Count_StockCaution"] != null)
				model.Count_StockCaution=Shop.Tools.RequestTool.RequestInt("Count_StockCaution",0);
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["Price_Market"] != null)
				model.Price_Market=Shop.Tools.RequestTool.RequestDecimal("Price_Market",0);
			if (HttpContext.Current.Request["Price_Cost"] != null)
				model.Price_Cost=Shop.Tools.RequestTool.RequestDecimal("Price_Cost",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Images"] != null)
				model.Images=Shop.Tools.RequestTool.RequestSafeString("Images");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestSafeString("ImageMedium");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestSafeString("ImageBig");
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestSafeString("ImageOriginal");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_OnSale"] != null)
				model.Time_OnSale=Shop.Tools.RequestTool.RequestTime("Time_OnSale", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Tags"] != null)
				model.Tags=Shop.Tools.RequestTool.RequestSafeString("Tags");
			if (HttpContext.Current.Request["Pro_Tag_id"] != null)
				model.Pro_Tag_id=Shop.Tools.RequestTool.RequestSafeString("Pro_Tag_id");
			if (HttpContext.Current.Request["ProPerty132"] != null)
				model.ProPerty132=Shop.Tools.RequestTool.RequestSafeString("ProPerty132");
			if (HttpContext.Current.Request["ProPerty131"] != null)
				model.ProPerty131=Shop.Tools.RequestTool.RequestSafeString("ProPerty131");
			if (HttpContext.Current.Request["ProPerty133"] != null)
				model.ProPerty133=Shop.Tools.RequestTool.RequestSafeString("ProPerty133");
			if (HttpContext.Current.Request["Service"] != null)
				model.Service=Shop.Tools.RequestTool.RequestSafeString("Service");
			if (HttpContext.Current.Request["Remarks"] != null)
				model.Remarks=Shop.Tools.RequestTool.RequestSafeString("Remarks");
			if (HttpContext.Current.Request["Count_ViewsFalse"] != null)
				model.Count_ViewsFalse=Shop.Tools.RequestTool.RequestInt("Count_ViewsFalse",0);
			if (HttpContext.Current.Request["Count_SalesFalse"] != null)
				model.Count_SalesFalse=Shop.Tools.RequestTool.RequestInt("Count_SalesFalse",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Packing"] != null)
				model.Packing=Shop.Tools.RequestTool.RequestSafeString("Packing");
			if (HttpContext.Current.Request["Specification"] != null)
				model.Specification=Shop.Tools.RequestTool.RequestSafeString("Specification");
			if (HttpContext.Current.Request["Star_Comment"] != null)
				model.Star_Comment=Shop.Tools.RequestTool.RequestDecimal("Star_Comment",0);
			if (HttpContext.Current.Request["Count_Comment"] != null)
				model.Count_Comment=Shop.Tools.RequestTool.RequestInt("Count_Comment",0);
			if (HttpContext.Current.Request["Count_Freeze"] != null)
				model.Count_Freeze=Shop.Tools.RequestTool.RequestInt("Count_Freeze",0);
			if (HttpContext.Current.Request["ProPertyMain"] != null)
				model.ProPertyMain=Shop.Tools.RequestTool.RequestInt("ProPertyMain",0);
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestSafeString("taobaoid");
			if (HttpContext.Current.Request["taobaoid_type"] != null)
				model.taobaoid_type=Shop.Tools.RequestTool.RequestSafeString("taobaoid_type");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["VolumeL"] != null)
				model.VolumeL=Shop.Tools.RequestTool.RequestDecimal("VolumeL",0);
			if (HttpContext.Current.Request["VolumeW"] != null)
				model.VolumeW=Shop.Tools.RequestTool.RequestDecimal("VolumeW",0);
			if (HttpContext.Current.Request["VolumeH"] != null)
				model.VolumeH=Shop.Tools.RequestTool.RequestDecimal("VolumeH",0);
			if (HttpContext.Current.Request["PackageRate"] != null)
				model.PackageRate=Shop.Tools.RequestTool.RequestInt("PackageRate",0);
			if (HttpContext.Current.Request["Time_Expired"] != null)
				model.Time_Expired=Shop.Tools.RequestTool.RequestTime("Time_Expired", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Limit"] != null)
				model.Count_Limit=Shop.Tools.RequestTool.RequestInt("Count_Limit",0);
			if (HttpContext.Current.Request["Price_Sale"] != null)
				model.Price_Sale=Shop.Tools.RequestTool.RequestDecimal("Price_Sale",0);
			if (HttpContext.Current.Request["Type_id_ProductType"] != null)
				model.Type_id_ProductType=Shop.Tools.RequestTool.RequestInt("Type_id_ProductType",0);
			if (HttpContext.Current.Request["NetWeight"] != null)
				model.NetWeight=Shop.Tools.RequestTool.RequestDecimal("NetWeight",0);
			if (HttpContext.Current.Request["Pro_Type_id_other"] != null)
				model.Pro_Type_id_other=Shop.Tools.RequestTool.RequestSafeString("Pro_Type_id_other");
			if (HttpContext.Current.Request["Supplier_ProductType_ids"] != null)
				model.Supplier_ProductType_ids=Shop.Tools.RequestTool.RequestSafeString("Supplier_ProductType_ids");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestSafeString("Site_ids");
			if (HttpContext.Current.Request["Time_Start"] != null)
				model.Time_Start=Shop.Tools.RequestTool.RequestTime("Time_Start", System.DateTime.Now);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestSafeString("ProPerty134");
			if (HttpContext.Current.Request["FreezeRemark"] != null)
				model.FreezeRemark=Shop.Tools.RequestTool.RequestSafeString("FreezeRemark");
			if (HttpContext.Current.Request["StepPrice"] != null)
				model.StepPrice=Shop.Tools.RequestTool.RequestSafeString("StepPrice");
			if (HttpContext.Current.Request["UserLevelPrice"] != null)
				model.UserLevelPrice=Shop.Tools.RequestTool.RequestSafeString("UserLevelPrice");
			if (HttpContext.Current.Request["UserLevel_ids_show"] != null)
				model.UserLevel_ids_show=Shop.Tools.RequestTool.RequestSafeString("UserLevel_ids_show");
			if (HttpContext.Current.Request["UserLevel_ids_priceshow"] != null)
				model.UserLevel_ids_priceshow=Shop.Tools.RequestTool.RequestSafeString("UserLevel_ids_priceshow");
			if (HttpContext.Current.Request["UserLevel_ids_buy"] != null)
				model.UserLevel_ids_buy=Shop.Tools.RequestTool.RequestSafeString("UserLevel_ids_buy");
			if (HttpContext.Current.Request["IsNullStockSale"] != null)
				model.IsNullStockSale=Shop.Tools.RequestTool.RequestInt("IsNullStockSale",0);
			if (HttpContext.Current.Request["Price_reserve"] != null)
				model.Price_reserve=Shop.Tools.RequestTool.RequestDecimal("Price_reserve",0);
			if (HttpContext.Current.Request["Price_reserve_per"] != null)
				model.Price_reserve_per=Shop.Tools.RequestTool.RequestDecimal("Price_reserve_per",0);
			if (HttpContext.Current.Request["Reserve_days"] != null)
				model.Reserve_days=Shop.Tools.RequestTool.RequestInt("Reserve_days",0);
			if (HttpContext.Current.Request["IsCombo"] != null)
				model.IsCombo=Shop.Tools.RequestTool.RequestInt("IsCombo",0);
			if (HttpContext.Current.Request["UserLevelCount"] != null)
				model.UserLevelCount=Shop.Tools.RequestTool.RequestSafeString("UserLevelCount");
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Product ReaderBind(IDataReader dataReader)
		{
			Lebi_Product model=new Lebi_Product();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Pro_Type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pro_Type_id=(int)ojb;
			}
			ojb = dataReader["Brand_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Brand_id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			model.Number=dataReader["Number"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["Units_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Units_id=(int)ojb;
			}
			ojb = dataReader["Weight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight=(decimal)ojb;
			}
			model.Introduction=dataReader["Introduction"].ToString();
			model.Description=dataReader["Description"].ToString();
			model.MobileDescription=dataReader["MobileDescription"].ToString();
			ojb = dataReader["Type_id_ProductStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_ProductStatus=(int)ojb;
			}
			ojb = dataReader["Count_Like"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Like=(int)ojb;
			}
			ojb = dataReader["Count_Sales_Show"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Sales_Show=(int)ojb;
			}
			ojb = dataReader["Count_Sales"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Sales=(int)ojb;
			}
			ojb = dataReader["Count_Views_Show"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Views_Show=(int)ojb;
			}
			ojb = dataReader["Count_Views"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Views=(int)ojb;
			}
			ojb = dataReader["Count_Stock"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Stock=(int)ojb;
			}
			ojb = dataReader["Count_StockCaution"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_StockCaution=(int)ojb;
			}
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			ojb = dataReader["Price_Market"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Market=(decimal)ojb;
			}
			ojb = dataReader["Price_Cost"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Cost=(decimal)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			model.Images=dataReader["Images"].ToString();
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.ImageMedium=dataReader["ImageMedium"].ToString();
			model.ImageBig=dataReader["ImageBig"].ToString();
			model.ImageOriginal=dataReader["ImageOriginal"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_OnSale"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_OnSale=(DateTime)ojb;
			}
			ojb = dataReader["Time_Edit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Edit=(DateTime)ojb;
			}
			model.Tags=dataReader["Tags"].ToString();
			model.Pro_Tag_id=dataReader["Pro_Tag_id"].ToString();
			model.ProPerty132=dataReader["ProPerty132"].ToString();
			model.ProPerty131=dataReader["ProPerty131"].ToString();
			model.ProPerty133=dataReader["ProPerty133"].ToString();
			model.Service=dataReader["Service"].ToString();
			model.Remarks=dataReader["Remarks"].ToString();
			ojb = dataReader["Count_ViewsFalse"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_ViewsFalse=(int)ojb;
			}
			ojb = dataReader["Count_SalesFalse"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_SalesFalse=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			model.Packing=dataReader["Packing"].ToString();
			model.Specification=dataReader["Specification"].ToString();
			ojb = dataReader["Star_Comment"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Star_Comment=(decimal)ojb;
			}
			ojb = dataReader["Count_Comment"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Comment=(int)ojb;
			}
			ojb = dataReader["Count_Freeze"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Freeze=(int)ojb;
			}
			ojb = dataReader["ProPertyMain"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProPertyMain=(int)ojb;
			}
			model.taobaoid=dataReader["taobaoid"].ToString();
			model.taobaoid_type=dataReader["taobaoid_type"].ToString();
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
			ojb = dataReader["VolumeL"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VolumeL=(decimal)ojb;
			}
			ojb = dataReader["VolumeW"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VolumeW=(decimal)ojb;
			}
			ojb = dataReader["VolumeH"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VolumeH=(decimal)ojb;
			}
			ojb = dataReader["PackageRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PackageRate=(int)ojb;
			}
			ojb = dataReader["Time_Expired"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Expired=(DateTime)ojb;
			}
			ojb = dataReader["Count_Limit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Limit=(int)ojb;
			}
			ojb = dataReader["Price_Sale"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Sale=(decimal)ojb;
			}
			ojb = dataReader["Type_id_ProductType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_ProductType=(int)ojb;
			}
			ojb = dataReader["NetWeight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NetWeight=(decimal)ojb;
			}
			model.Pro_Type_id_other=dataReader["Pro_Type_id_other"].ToString();
			model.Supplier_ProductType_ids=dataReader["Supplier_ProductType_ids"].ToString();
			model.Site_ids=dataReader["Site_ids"].ToString();
			ojb = dataReader["Time_Start"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Start=(DateTime)ojb;
			}
			model.ProPerty134=dataReader["ProPerty134"].ToString();
			model.FreezeRemark=dataReader["FreezeRemark"].ToString();
			model.StepPrice=dataReader["StepPrice"].ToString();
			model.UserLevelPrice=dataReader["UserLevelPrice"].ToString();
			model.UserLevel_ids_show=dataReader["UserLevel_ids_show"].ToString();
			model.UserLevel_ids_priceshow=dataReader["UserLevel_ids_priceshow"].ToString();
			model.UserLevel_ids_buy=dataReader["UserLevel_ids_buy"].ToString();
			ojb = dataReader["IsNullStockSale"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsNullStockSale=(int)ojb;
			}
			ojb = dataReader["Price_reserve"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_reserve=(decimal)ojb;
			}
			ojb = dataReader["Price_reserve_per"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_reserve_per=(decimal)ojb;
			}
			ojb = dataReader["Reserve_days"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Reserve_days=(int)ojb;
			}
			ojb = dataReader["IsCombo"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCombo=(int)ojb;
			}
			model.UserLevelCount=dataReader["UserLevelCount"].ToString();
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

