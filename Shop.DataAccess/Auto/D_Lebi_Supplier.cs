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

	public interface Lebi_Supplier_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Supplier model);
		void Update(Lebi_Supplier model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Supplier GetModel(int id);
		Lebi_Supplier GetModel(string strWhere);
		Lebi_Supplier GetModel(SQLPara para);
		List<Lebi_Supplier> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Supplier> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Supplier> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Supplier> GetList(SQLPara para);
		Lebi_Supplier BindForm(Lebi_Supplier model);
		Lebi_Supplier SafeBindForm(Lebi_Supplier model);
		Lebi_Supplier ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Supplier。
	/// </summary>
	public class D_Lebi_Supplier
	{
		static Lebi_Supplier_interface _Instance;
		public static Lebi_Supplier_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Supplier();
		            else
		                _Instance = new sqlserver_Lebi_Supplier();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Supplier()
		{}
		#region  成员方法
	class sqlserver_Lebi_Supplier : Lebi_Supplier_interface
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
				strSql.Append("select " + colName + " from [Lebi_Supplier]");
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
			strSql.Append("select  "+colName+" from [Lebi_Supplier]");
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
			strSql.Append("select count(1) from [Lebi_Supplier]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier]");
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
			strSql.Append("select max(id) from [Lebi_Supplier]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier](");
			strSql.Append("UserName,Password,Email,RealName,Company,SubName,Sex,Area_id,MobilePhone,Phone,Address,QQ,Fax,Postalcode,Msn,Count_Login,IP_Last,IP_This,Time_This,Time_Last,Time_Reg,Status,Language,Supplier_Group_id,Remark,Money_Margin,Money_Margin_pay,Money_Service,Money,Time_Begin,Time_End,BillingDays,Level_id,Type_id_SupplierStatus,ProductTop,Name,ClassName,SEO_Title,SEO_Description,SEO_Keywords,Description,User_id,IsSupplierTransport,ServicePanel,UserTop,UserLow,Days_checkuserlow,IsCash,Supplier_Skin_id,head,shortbar,longbar,Logo,Domain,FreezeRemark,IsSpread,SupplierNumber,PointToMoney)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Password,@Email,@RealName,@Company,@SubName,@Sex,@Area_id,@MobilePhone,@Phone,@Address,@QQ,@Fax,@Postalcode,@Msn,@Count_Login,@IP_Last,@IP_This,@Time_This,@Time_Last,@Time_Reg,@Status,@Language,@Supplier_Group_id,@Remark,@Money_Margin,@Money_Margin_pay,@Money_Service,@Money,@Time_Begin,@Time_End,@BillingDays,@Level_id,@Type_id_SupplierStatus,@ProductTop,@Name,@ClassName,@SEO_Title,@SEO_Description,@SEO_Keywords,@Description,@User_id,@IsSupplierTransport,@ServicePanel,@UserTop,@UserLow,@Days_checkuserlow,@IsCash,@Supplier_Skin_id,@head,@shortbar,@longbar,@Logo,@Domain,@FreezeRemark,@IsSpread,@SupplierNumber,@PointToMoney)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", model.UserName),
					new SqlParameter("@Password", model.Password),
					new SqlParameter("@Email", model.Email),
					new SqlParameter("@RealName", model.RealName),
					new SqlParameter("@Company", model.Company),
					new SqlParameter("@SubName", model.SubName),
					new SqlParameter("@Sex", model.Sex),
					new SqlParameter("@Area_id", model.Area_id),
					new SqlParameter("@MobilePhone", model.MobilePhone),
					new SqlParameter("@Phone", model.Phone),
					new SqlParameter("@Address", model.Address),
					new SqlParameter("@QQ", model.QQ),
					new SqlParameter("@Fax", model.Fax),
					new SqlParameter("@Postalcode", model.Postalcode),
					new SqlParameter("@Msn", model.Msn),
					new SqlParameter("@Count_Login", model.Count_Login),
					new SqlParameter("@IP_Last", model.IP_Last),
					new SqlParameter("@IP_This", model.IP_This),
					new SqlParameter("@Time_This", model.Time_This),
					new SqlParameter("@Time_Last", model.Time_Last),
					new SqlParameter("@Time_Reg", model.Time_Reg),
					new SqlParameter("@Status", model.Status),
					new SqlParameter("@Language", model.Language),
					new SqlParameter("@Supplier_Group_id", model.Supplier_Group_id),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Money_Margin", model.Money_Margin),
					new SqlParameter("@Money_Margin_pay", model.Money_Margin_pay),
					new SqlParameter("@Money_Service", model.Money_Service),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@Time_Begin", model.Time_Begin),
					new SqlParameter("@Time_End", model.Time_End),
					new SqlParameter("@BillingDays", model.BillingDays),
					new SqlParameter("@Level_id", model.Level_id),
					new SqlParameter("@Type_id_SupplierStatus", model.Type_id_SupplierStatus),
					new SqlParameter("@ProductTop", model.ProductTop),
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@ClassName", model.ClassName),
					new SqlParameter("@SEO_Title", model.SEO_Title),
					new SqlParameter("@SEO_Description", model.SEO_Description),
					new SqlParameter("@SEO_Keywords", model.SEO_Keywords),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@IsSupplierTransport", model.IsSupplierTransport),
					new SqlParameter("@ServicePanel", model.ServicePanel),
					new SqlParameter("@UserTop", model.UserTop),
					new SqlParameter("@UserLow", model.UserLow),
					new SqlParameter("@Days_checkuserlow", model.Days_checkuserlow),
					new SqlParameter("@IsCash", model.IsCash),
					new SqlParameter("@Supplier_Skin_id", model.Supplier_Skin_id),
					new SqlParameter("@head", model.head),
					new SqlParameter("@shortbar", model.shortbar),
					new SqlParameter("@longbar", model.longbar),
					new SqlParameter("@Logo", model.Logo),
					new SqlParameter("@Domain", model.Domain),
					new SqlParameter("@FreezeRemark", model.FreezeRemark),
					new SqlParameter("@IsSpread", model.IsSpread),
					new SqlParameter("@SupplierNumber", model.SupplierNumber),
					new SqlParameter("@PointToMoney", model.PointToMoney)};

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
		public void Update(Lebi_Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier] set ");
			strSql.Append("UserName= @UserName,");
			strSql.Append("Password= @Password,");
			strSql.Append("Email= @Email,");
			strSql.Append("RealName= @RealName,");
			strSql.Append("Company= @Company,");
			strSql.Append("SubName= @SubName,");
			strSql.Append("Sex= @Sex,");
			strSql.Append("Area_id= @Area_id,");
			strSql.Append("MobilePhone= @MobilePhone,");
			strSql.Append("Phone= @Phone,");
			strSql.Append("Address= @Address,");
			strSql.Append("QQ= @QQ,");
			strSql.Append("Fax= @Fax,");
			strSql.Append("Postalcode= @Postalcode,");
			strSql.Append("Msn= @Msn,");
			strSql.Append("Count_Login= @Count_Login,");
			strSql.Append("IP_Last= @IP_Last,");
			strSql.Append("IP_This= @IP_This,");
			strSql.Append("Time_This= @Time_This,");
			strSql.Append("Time_Last= @Time_Last,");
			strSql.Append("Time_Reg= @Time_Reg,");
			strSql.Append("Status= @Status,");
			strSql.Append("Language= @Language,");
			strSql.Append("Supplier_Group_id= @Supplier_Group_id,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Money_Margin= @Money_Margin,");
			strSql.Append("Money_Margin_pay= @Money_Margin_pay,");
			strSql.Append("Money_Service= @Money_Service,");
			strSql.Append("Money= @Money,");
			strSql.Append("Time_Begin= @Time_Begin,");
			strSql.Append("Time_End= @Time_End,");
			strSql.Append("BillingDays= @BillingDays,");
			strSql.Append("Level_id= @Level_id,");
			strSql.Append("Type_id_SupplierStatus= @Type_id_SupplierStatus,");
			strSql.Append("ProductTop= @ProductTop,");
			strSql.Append("Name= @Name,");
			strSql.Append("ClassName= @ClassName,");
			strSql.Append("SEO_Title= @SEO_Title,");
			strSql.Append("SEO_Description= @SEO_Description,");
			strSql.Append("SEO_Keywords= @SEO_Keywords,");
			strSql.Append("Description= @Description,");
			strSql.Append("User_id= @User_id,");
			strSql.Append("IsSupplierTransport= @IsSupplierTransport,");
			strSql.Append("ServicePanel= @ServicePanel,");
			strSql.Append("UserTop= @UserTop,");
			strSql.Append("UserLow= @UserLow,");
			strSql.Append("Days_checkuserlow= @Days_checkuserlow,");
			strSql.Append("IsCash= @IsCash,");
			strSql.Append("Supplier_Skin_id= @Supplier_Skin_id,");
			strSql.Append("head= @head,");
			strSql.Append("shortbar= @shortbar,");
			strSql.Append("longbar= @longbar,");
			strSql.Append("Logo= @Logo,");
			strSql.Append("Domain= @Domain,");
			strSql.Append("FreezeRemark= @FreezeRemark,");
			strSql.Append("IsSpread= @IsSpread,");
			strSql.Append("SupplierNumber= @SupplierNumber,");
			strSql.Append("PointToMoney= @PointToMoney");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Company", SqlDbType.NVarChar,2000),
					new SqlParameter("@SubName", SqlDbType.NVarChar,100),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Area_id", SqlDbType.Int,4),
					new SqlParameter("@MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Postalcode", SqlDbType.NVarChar,20),
					new SqlParameter("@Msn", SqlDbType.NVarChar,100),
					new SqlParameter("@Count_Login", SqlDbType.Int,4),
					new SqlParameter("@IP_Last", SqlDbType.NVarChar,20),
					new SqlParameter("@IP_This", SqlDbType.NVarChar,20),
					new SqlParameter("@Time_This", SqlDbType.DateTime),
					new SqlParameter("@Time_Last", SqlDbType.DateTime),
					new SqlParameter("@Time_Reg", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Language", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier_Group_id", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,255),
					new SqlParameter("@Money_Margin", SqlDbType.Decimal,5),
					new SqlParameter("@Money_Margin_pay", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Service", SqlDbType.Decimal,5),
					new SqlParameter("@Money", SqlDbType.Decimal,5),
					new SqlParameter("@Time_Begin", SqlDbType.DateTime),
					new SqlParameter("@Time_End", SqlDbType.DateTime),
					new SqlParameter("@BillingDays", SqlDbType.Int,4),
					new SqlParameter("@Level_id", SqlDbType.Int,4),
					new SqlParameter("@Type_id_SupplierStatus", SqlDbType.Int,4),
					new SqlParameter("@ProductTop", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,2000),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Title", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@SEO_Keywords", SqlDbType.NVarChar,2000),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@IsSupplierTransport", SqlDbType.Int,4),
					new SqlParameter("@ServicePanel", SqlDbType.NVarChar,255),
					new SqlParameter("@UserTop", SqlDbType.Int,4),
					new SqlParameter("@UserLow", SqlDbType.Int,4),
					new SqlParameter("@Days_checkuserlow", SqlDbType.Int,4),
					new SqlParameter("@IsCash", SqlDbType.Int,4),
					new SqlParameter("@Supplier_Skin_id", SqlDbType.Int,4),
					new SqlParameter("@head", SqlDbType.NText),
					new SqlParameter("@shortbar", SqlDbType.NVarChar,2000),
					new SqlParameter("@longbar", SqlDbType.NVarChar,2000),
					new SqlParameter("@Logo", SqlDbType.NVarChar,200),
					new SqlParameter("@Domain", SqlDbType.NVarChar,500),
					new SqlParameter("@FreezeRemark", SqlDbType.NVarChar,255),
					new SqlParameter("@IsSpread", SqlDbType.Int,4),
					new SqlParameter("@SupplierNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@PointToMoney", SqlDbType.Decimal,9)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.Email;
			parameters[4].Value = model.RealName;
			parameters[5].Value = model.Company;
			parameters[6].Value = model.SubName;
			parameters[7].Value = model.Sex;
			parameters[8].Value = model.Area_id;
			parameters[9].Value = model.MobilePhone;
			parameters[10].Value = model.Phone;
			parameters[11].Value = model.Address;
			parameters[12].Value = model.QQ;
			parameters[13].Value = model.Fax;
			parameters[14].Value = model.Postalcode;
			parameters[15].Value = model.Msn;
			parameters[16].Value = model.Count_Login;
			parameters[17].Value = model.IP_Last;
			parameters[18].Value = model.IP_This;
			parameters[19].Value = model.Time_This;
			parameters[20].Value = model.Time_Last;
			parameters[21].Value = model.Time_Reg;
			parameters[22].Value = model.Status;
			parameters[23].Value = model.Language;
			parameters[24].Value = model.Supplier_Group_id;
			parameters[25].Value = model.Remark;
			parameters[26].Value = model.Money_Margin;
			parameters[27].Value = model.Money_Margin_pay;
			parameters[28].Value = model.Money_Service;
			parameters[29].Value = model.Money;
			parameters[30].Value = model.Time_Begin;
			parameters[31].Value = model.Time_End;
			parameters[32].Value = model.BillingDays;
			parameters[33].Value = model.Level_id;
			parameters[34].Value = model.Type_id_SupplierStatus;
			parameters[35].Value = model.ProductTop;
			parameters[36].Value = model.Name;
			parameters[37].Value = model.ClassName;
			parameters[38].Value = model.SEO_Title;
			parameters[39].Value = model.SEO_Description;
			parameters[40].Value = model.SEO_Keywords;
			parameters[41].Value = model.Description;
			parameters[42].Value = model.User_id;
			parameters[43].Value = model.IsSupplierTransport;
			parameters[44].Value = model.ServicePanel;
			parameters[45].Value = model.UserTop;
			parameters[46].Value = model.UserLow;
			parameters[47].Value = model.Days_checkuserlow;
			parameters[48].Value = model.IsCash;
			parameters[49].Value = model.Supplier_Skin_id;
			parameters[50].Value = model.head;
			parameters[51].Value = model.shortbar;
			parameters[52].Value = model.longbar;
			parameters[53].Value = model.Logo;
			parameters[54].Value = model.Domain;
			parameters[55].Value = model.FreezeRemark;
			parameters[56].Value = model.IsSpread;
			parameters[57].Value = model.SupplierNumber;
			parameters[58].Value = model.PointToMoney;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier] ");
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
			strSql.Append("delete from [Lebi_Supplier] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Supplier model=new Lebi_Supplier();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				model.Company=ds.Tables[0].Rows[0]["Company"].ToString();
				model.SubName=ds.Tables[0].Rows[0]["SubName"].ToString();
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.Postalcode=ds.Tables[0].Rows[0]["Postalcode"].ToString();
				model.Msn=ds.Tables[0].Rows[0]["Msn"].ToString();
				if(ds.Tables[0].Rows[0]["Count_Login"].ToString()!="")
				{
					model.Count_Login=int.Parse(ds.Tables[0].Rows[0]["Count_Login"].ToString());
				}
				model.IP_Last=ds.Tables[0].Rows[0]["IP_Last"].ToString();
				model.IP_This=ds.Tables[0].Rows[0]["IP_This"].ToString();
				if(ds.Tables[0].Rows[0]["Time_This"].ToString()!="")
				{
					model.Time_This=DateTime.Parse(ds.Tables[0].Rows[0]["Time_This"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Last"].ToString()!="")
				{
					model.Time_Last=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Last"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Reg"].ToString()!="")
				{
					model.Time_Reg=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Reg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString()!="")
				{
					model.Supplier_Group_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Margin"].ToString()!="")
				{
					model.Money_Margin=decimal.Parse(ds.Tables[0].Rows[0]["Money_Margin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Margin_pay"].ToString()!="")
				{
					model.Money_Margin_pay=decimal.Parse(ds.Tables[0].Rows[0]["Money_Margin_pay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Service"].ToString()!="")
				{
					model.Money_Service=decimal.Parse(ds.Tables[0].Rows[0]["Money_Service"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Begin"].ToString()!="")
				{
					model.Time_Begin=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Begin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BillingDays"].ToString()!="")
				{
					model.BillingDays=int.Parse(ds.Tables[0].Rows[0]["BillingDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Level_id"].ToString()!="")
				{
					model.Level_id=int.Parse(ds.Tables[0].Rows[0]["Level_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_SupplierStatus"].ToString()!="")
				{
					model.Type_id_SupplierStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_SupplierStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductTop"].ToString()!="")
				{
					model.ProductTop=int.Parse(ds.Tables[0].Rows[0]["ProductTop"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.ClassName=ds.Tables[0].Rows[0]["ClassName"].ToString();
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString()!="")
				{
					model.IsSupplierTransport=int.Parse(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString());
				}
				model.ServicePanel=ds.Tables[0].Rows[0]["ServicePanel"].ToString();
				if(ds.Tables[0].Rows[0]["UserTop"].ToString()!="")
				{
					model.UserTop=int.Parse(ds.Tables[0].Rows[0]["UserTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLow"].ToString()!="")
				{
					model.UserLow=int.Parse(ds.Tables[0].Rows[0]["UserLow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString()!="")
				{
					model.Days_checkuserlow=int.Parse(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCash"].ToString()!="")
				{
					model.IsCash=int.Parse(ds.Tables[0].Rows[0]["IsCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Skin_id"].ToString()!="")
				{
					model.Supplier_Skin_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Skin_id"].ToString());
				}
				model.head=ds.Tables[0].Rows[0]["head"].ToString();
				model.shortbar=ds.Tables[0].Rows[0]["shortbar"].ToString();
				model.longbar=ds.Tables[0].Rows[0]["longbar"].ToString();
				model.Logo=ds.Tables[0].Rows[0]["Logo"].ToString();
				model.Domain=ds.Tables[0].Rows[0]["Domain"].ToString();
				model.FreezeRemark=ds.Tables[0].Rows[0]["FreezeRemark"].ToString();
				if(ds.Tables[0].Rows[0]["IsSpread"].ToString()!="")
				{
					model.IsSpread=int.Parse(ds.Tables[0].Rows[0]["IsSpread"].ToString());
				}
				model.SupplierNumber=ds.Tables[0].Rows[0]["SupplierNumber"].ToString();
				if(ds.Tables[0].Rows[0]["PointToMoney"].ToString()!="")
				{
					model.PointToMoney=decimal.Parse(ds.Tables[0].Rows[0]["PointToMoney"].ToString());
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
		public Lebi_Supplier GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier model=new Lebi_Supplier();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				model.Company=ds.Tables[0].Rows[0]["Company"].ToString();
				model.SubName=ds.Tables[0].Rows[0]["SubName"].ToString();
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.Postalcode=ds.Tables[0].Rows[0]["Postalcode"].ToString();
				model.Msn=ds.Tables[0].Rows[0]["Msn"].ToString();
				if(ds.Tables[0].Rows[0]["Count_Login"].ToString()!="")
				{
					model.Count_Login=int.Parse(ds.Tables[0].Rows[0]["Count_Login"].ToString());
				}
				model.IP_Last=ds.Tables[0].Rows[0]["IP_Last"].ToString();
				model.IP_This=ds.Tables[0].Rows[0]["IP_This"].ToString();
				if(ds.Tables[0].Rows[0]["Time_This"].ToString()!="")
				{
					model.Time_This=DateTime.Parse(ds.Tables[0].Rows[0]["Time_This"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Last"].ToString()!="")
				{
					model.Time_Last=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Last"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Reg"].ToString()!="")
				{
					model.Time_Reg=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Reg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString()!="")
				{
					model.Supplier_Group_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Margin"].ToString()!="")
				{
					model.Money_Margin=decimal.Parse(ds.Tables[0].Rows[0]["Money_Margin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Margin_pay"].ToString()!="")
				{
					model.Money_Margin_pay=decimal.Parse(ds.Tables[0].Rows[0]["Money_Margin_pay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Service"].ToString()!="")
				{
					model.Money_Service=decimal.Parse(ds.Tables[0].Rows[0]["Money_Service"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Begin"].ToString()!="")
				{
					model.Time_Begin=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Begin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BillingDays"].ToString()!="")
				{
					model.BillingDays=int.Parse(ds.Tables[0].Rows[0]["BillingDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Level_id"].ToString()!="")
				{
					model.Level_id=int.Parse(ds.Tables[0].Rows[0]["Level_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_SupplierStatus"].ToString()!="")
				{
					model.Type_id_SupplierStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_SupplierStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductTop"].ToString()!="")
				{
					model.ProductTop=int.Parse(ds.Tables[0].Rows[0]["ProductTop"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.ClassName=ds.Tables[0].Rows[0]["ClassName"].ToString();
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString()!="")
				{
					model.IsSupplierTransport=int.Parse(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString());
				}
				model.ServicePanel=ds.Tables[0].Rows[0]["ServicePanel"].ToString();
				if(ds.Tables[0].Rows[0]["UserTop"].ToString()!="")
				{
					model.UserTop=int.Parse(ds.Tables[0].Rows[0]["UserTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLow"].ToString()!="")
				{
					model.UserLow=int.Parse(ds.Tables[0].Rows[0]["UserLow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString()!="")
				{
					model.Days_checkuserlow=int.Parse(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCash"].ToString()!="")
				{
					model.IsCash=int.Parse(ds.Tables[0].Rows[0]["IsCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Skin_id"].ToString()!="")
				{
					model.Supplier_Skin_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Skin_id"].ToString());
				}
				model.head=ds.Tables[0].Rows[0]["head"].ToString();
				model.shortbar=ds.Tables[0].Rows[0]["shortbar"].ToString();
				model.longbar=ds.Tables[0].Rows[0]["longbar"].ToString();
				model.Logo=ds.Tables[0].Rows[0]["Logo"].ToString();
				model.Domain=ds.Tables[0].Rows[0]["Domain"].ToString();
				model.FreezeRemark=ds.Tables[0].Rows[0]["FreezeRemark"].ToString();
				if(ds.Tables[0].Rows[0]["IsSpread"].ToString()!="")
				{
					model.IsSpread=int.Parse(ds.Tables[0].Rows[0]["IsSpread"].ToString());
				}
				model.SupplierNumber=ds.Tables[0].Rows[0]["SupplierNumber"].ToString();
				if(ds.Tables[0].Rows[0]["PointToMoney"].ToString()!="")
				{
					model.PointToMoney=decimal.Parse(ds.Tables[0].Rows[0]["PointToMoney"].ToString());
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
		public Lebi_Supplier GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier model=new Lebi_Supplier();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				model.Company=ds.Tables[0].Rows[0]["Company"].ToString();
				model.SubName=ds.Tables[0].Rows[0]["SubName"].ToString();
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.Postalcode=ds.Tables[0].Rows[0]["Postalcode"].ToString();
				model.Msn=ds.Tables[0].Rows[0]["Msn"].ToString();
				if(ds.Tables[0].Rows[0]["Count_Login"].ToString()!="")
				{
					model.Count_Login=int.Parse(ds.Tables[0].Rows[0]["Count_Login"].ToString());
				}
				model.IP_Last=ds.Tables[0].Rows[0]["IP_Last"].ToString();
				model.IP_This=ds.Tables[0].Rows[0]["IP_This"].ToString();
				if(ds.Tables[0].Rows[0]["Time_This"].ToString()!="")
				{
					model.Time_This=DateTime.Parse(ds.Tables[0].Rows[0]["Time_This"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Last"].ToString()!="")
				{
					model.Time_Last=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Last"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Reg"].ToString()!="")
				{
					model.Time_Reg=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Reg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString()!="")
				{
					model.Supplier_Group_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Group_id"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Margin"].ToString()!="")
				{
					model.Money_Margin=decimal.Parse(ds.Tables[0].Rows[0]["Money_Margin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Margin_pay"].ToString()!="")
				{
					model.Money_Margin_pay=decimal.Parse(ds.Tables[0].Rows[0]["Money_Margin_pay"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Service"].ToString()!="")
				{
					model.Money_Service=decimal.Parse(ds.Tables[0].Rows[0]["Money_Service"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Begin"].ToString()!="")
				{
					model.Time_Begin=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Begin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BillingDays"].ToString()!="")
				{
					model.BillingDays=int.Parse(ds.Tables[0].Rows[0]["BillingDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Level_id"].ToString()!="")
				{
					model.Level_id=int.Parse(ds.Tables[0].Rows[0]["Level_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_SupplierStatus"].ToString()!="")
				{
					model.Type_id_SupplierStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_SupplierStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductTop"].ToString()!="")
				{
					model.ProductTop=int.Parse(ds.Tables[0].Rows[0]["ProductTop"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.ClassName=ds.Tables[0].Rows[0]["ClassName"].ToString();
				model.SEO_Title=ds.Tables[0].Rows[0]["SEO_Title"].ToString();
				model.SEO_Description=ds.Tables[0].Rows[0]["SEO_Description"].ToString();
				model.SEO_Keywords=ds.Tables[0].Rows[0]["SEO_Keywords"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString()!="")
				{
					model.IsSupplierTransport=int.Parse(ds.Tables[0].Rows[0]["IsSupplierTransport"].ToString());
				}
				model.ServicePanel=ds.Tables[0].Rows[0]["ServicePanel"].ToString();
				if(ds.Tables[0].Rows[0]["UserTop"].ToString()!="")
				{
					model.UserTop=int.Parse(ds.Tables[0].Rows[0]["UserTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLow"].ToString()!="")
				{
					model.UserLow=int.Parse(ds.Tables[0].Rows[0]["UserLow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString()!="")
				{
					model.Days_checkuserlow=int.Parse(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCash"].ToString()!="")
				{
					model.IsCash=int.Parse(ds.Tables[0].Rows[0]["IsCash"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_Skin_id"].ToString()!="")
				{
					model.Supplier_Skin_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_Skin_id"].ToString());
				}
				model.head=ds.Tables[0].Rows[0]["head"].ToString();
				model.shortbar=ds.Tables[0].Rows[0]["shortbar"].ToString();
				model.longbar=ds.Tables[0].Rows[0]["longbar"].ToString();
				model.Logo=ds.Tables[0].Rows[0]["Logo"].ToString();
				model.Domain=ds.Tables[0].Rows[0]["Domain"].ToString();
				model.FreezeRemark=ds.Tables[0].Rows[0]["FreezeRemark"].ToString();
				if(ds.Tables[0].Rows[0]["IsSpread"].ToString()!="")
				{
					model.IsSpread=int.Parse(ds.Tables[0].Rows[0]["IsSpread"].ToString());
				}
				model.SupplierNumber=ds.Tables[0].Rows[0]["SupplierNumber"].ToString();
				if(ds.Tables[0].Rows[0]["PointToMoney"].ToString()!="")
				{
					model.PointToMoney=decimal.Parse(ds.Tables[0].Rows[0]["PointToMoney"].ToString());
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
		public List<Lebi_Supplier> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier> list = new List<Lebi_Supplier>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Supplier> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier]";
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
			List<Lebi_Supplier> list = new List<Lebi_Supplier>();
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
		public List<Lebi_Supplier> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier> list = new List<Lebi_Supplier>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Supplier> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier> list = new List<Lebi_Supplier>();
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
		public Lebi_Supplier BindForm(Lebi_Supplier model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestString("Password");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestString("RealName");
			if (HttpContext.Current.Request["Company"] != null)
				model.Company=Shop.Tools.RequestTool.RequestString("Company");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestString("SubName");
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestString("Sex");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestString("QQ");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestString("Fax");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestString("Postalcode");
			if (HttpContext.Current.Request["Msn"] != null)
				model.Msn=Shop.Tools.RequestTool.RequestString("Msn");
			if (HttpContext.Current.Request["Count_Login"] != null)
				model.Count_Login=Shop.Tools.RequestTool.RequestInt("Count_Login",0);
			if (HttpContext.Current.Request["IP_Last"] != null)
				model.IP_Last=Shop.Tools.RequestTool.RequestString("IP_Last");
			if (HttpContext.Current.Request["IP_This"] != null)
				model.IP_This=Shop.Tools.RequestTool.RequestString("IP_This");
			if (HttpContext.Current.Request["Time_This"] != null)
				model.Time_This=Shop.Tools.RequestTool.RequestTime("Time_This", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Last"] != null)
				model.Time_Last=Shop.Tools.RequestTool.RequestTime("Time_Last", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Reg"] != null)
				model.Time_Reg=Shop.Tools.RequestTool.RequestTime("Time_Reg", System.DateTime.Now);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Supplier_Group_id"] != null)
				model.Supplier_Group_id=Shop.Tools.RequestTool.RequestInt("Supplier_Group_id",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Money_Margin"] != null)
				model.Money_Margin=Shop.Tools.RequestTool.RequestDecimal("Money_Margin",0);
			if (HttpContext.Current.Request["Money_Margin_pay"] != null)
				model.Money_Margin_pay=Shop.Tools.RequestTool.RequestDecimal("Money_Margin_pay",0);
			if (HttpContext.Current.Request["Money_Service"] != null)
				model.Money_Service=Shop.Tools.RequestTool.RequestDecimal("Money_Service",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["BillingDays"] != null)
				model.BillingDays=Shop.Tools.RequestTool.RequestInt("BillingDays",0);
			if (HttpContext.Current.Request["Level_id"] != null)
				model.Level_id=Shop.Tools.RequestTool.RequestInt("Level_id",0);
			if (HttpContext.Current.Request["Type_id_SupplierStatus"] != null)
				model.Type_id_SupplierStatus=Shop.Tools.RequestTool.RequestInt("Type_id_SupplierStatus",0);
			if (HttpContext.Current.Request["ProductTop"] != null)
				model.ProductTop=Shop.Tools.RequestTool.RequestInt("ProductTop",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["ClassName"] != null)
				model.ClassName=Shop.Tools.RequestTool.RequestString("ClassName");
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["ServicePanel"] != null)
				model.ServicePanel=Shop.Tools.RequestTool.RequestString("ServicePanel");
			if (HttpContext.Current.Request["UserTop"] != null)
				model.UserTop=Shop.Tools.RequestTool.RequestInt("UserTop",0);
			if (HttpContext.Current.Request["UserLow"] != null)
				model.UserLow=Shop.Tools.RequestTool.RequestInt("UserLow",0);
			if (HttpContext.Current.Request["Days_checkuserlow"] != null)
				model.Days_checkuserlow=Shop.Tools.RequestTool.RequestInt("Days_checkuserlow",0);
			if (HttpContext.Current.Request["IsCash"] != null)
				model.IsCash=Shop.Tools.RequestTool.RequestInt("IsCash",0);
			if (HttpContext.Current.Request["Supplier_Skin_id"] != null)
				model.Supplier_Skin_id=Shop.Tools.RequestTool.RequestInt("Supplier_Skin_id",0);
			if (HttpContext.Current.Request["head"] != null)
				model.head=Shop.Tools.RequestTool.RequestString("head");
			if (HttpContext.Current.Request["shortbar"] != null)
				model.shortbar=Shop.Tools.RequestTool.RequestString("shortbar");
			if (HttpContext.Current.Request["longbar"] != null)
				model.longbar=Shop.Tools.RequestTool.RequestString("longbar");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestString("Logo");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestString("Domain");
			if (HttpContext.Current.Request["FreezeRemark"] != null)
				model.FreezeRemark=Shop.Tools.RequestTool.RequestString("FreezeRemark");
			if (HttpContext.Current.Request["IsSpread"] != null)
				model.IsSpread=Shop.Tools.RequestTool.RequestInt("IsSpread",0);
			if (HttpContext.Current.Request["SupplierNumber"] != null)
				model.SupplierNumber=Shop.Tools.RequestTool.RequestString("SupplierNumber");
			if (HttpContext.Current.Request["PointToMoney"] != null)
				model.PointToMoney=Shop.Tools.RequestTool.RequestDecimal("PointToMoney",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier SafeBindForm(Lebi_Supplier model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestSafeString("Password");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestSafeString("RealName");
			if (HttpContext.Current.Request["Company"] != null)
				model.Company=Shop.Tools.RequestTool.RequestSafeString("Company");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestSafeString("SubName");
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestSafeString("Sex");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestSafeString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestSafeString("QQ");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestSafeString("Fax");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestSafeString("Postalcode");
			if (HttpContext.Current.Request["Msn"] != null)
				model.Msn=Shop.Tools.RequestTool.RequestSafeString("Msn");
			if (HttpContext.Current.Request["Count_Login"] != null)
				model.Count_Login=Shop.Tools.RequestTool.RequestInt("Count_Login",0);
			if (HttpContext.Current.Request["IP_Last"] != null)
				model.IP_Last=Shop.Tools.RequestTool.RequestSafeString("IP_Last");
			if (HttpContext.Current.Request["IP_This"] != null)
				model.IP_This=Shop.Tools.RequestTool.RequestSafeString("IP_This");
			if (HttpContext.Current.Request["Time_This"] != null)
				model.Time_This=Shop.Tools.RequestTool.RequestTime("Time_This", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Last"] != null)
				model.Time_Last=Shop.Tools.RequestTool.RequestTime("Time_Last", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Reg"] != null)
				model.Time_Reg=Shop.Tools.RequestTool.RequestTime("Time_Reg", System.DateTime.Now);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Supplier_Group_id"] != null)
				model.Supplier_Group_id=Shop.Tools.RequestTool.RequestInt("Supplier_Group_id",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Money_Margin"] != null)
				model.Money_Margin=Shop.Tools.RequestTool.RequestDecimal("Money_Margin",0);
			if (HttpContext.Current.Request["Money_Margin_pay"] != null)
				model.Money_Margin_pay=Shop.Tools.RequestTool.RequestDecimal("Money_Margin_pay",0);
			if (HttpContext.Current.Request["Money_Service"] != null)
				model.Money_Service=Shop.Tools.RequestTool.RequestDecimal("Money_Service",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["BillingDays"] != null)
				model.BillingDays=Shop.Tools.RequestTool.RequestInt("BillingDays",0);
			if (HttpContext.Current.Request["Level_id"] != null)
				model.Level_id=Shop.Tools.RequestTool.RequestInt("Level_id",0);
			if (HttpContext.Current.Request["Type_id_SupplierStatus"] != null)
				model.Type_id_SupplierStatus=Shop.Tools.RequestTool.RequestInt("Type_id_SupplierStatus",0);
			if (HttpContext.Current.Request["ProductTop"] != null)
				model.ProductTop=Shop.Tools.RequestTool.RequestInt("ProductTop",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["ClassName"] != null)
				model.ClassName=Shop.Tools.RequestTool.RequestSafeString("ClassName");
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["ServicePanel"] != null)
				model.ServicePanel=Shop.Tools.RequestTool.RequestSafeString("ServicePanel");
			if (HttpContext.Current.Request["UserTop"] != null)
				model.UserTop=Shop.Tools.RequestTool.RequestInt("UserTop",0);
			if (HttpContext.Current.Request["UserLow"] != null)
				model.UserLow=Shop.Tools.RequestTool.RequestInt("UserLow",0);
			if (HttpContext.Current.Request["Days_checkuserlow"] != null)
				model.Days_checkuserlow=Shop.Tools.RequestTool.RequestInt("Days_checkuserlow",0);
			if (HttpContext.Current.Request["IsCash"] != null)
				model.IsCash=Shop.Tools.RequestTool.RequestInt("IsCash",0);
			if (HttpContext.Current.Request["Supplier_Skin_id"] != null)
				model.Supplier_Skin_id=Shop.Tools.RequestTool.RequestInt("Supplier_Skin_id",0);
			if (HttpContext.Current.Request["head"] != null)
				model.head=Shop.Tools.RequestTool.RequestSafeString("head");
			if (HttpContext.Current.Request["shortbar"] != null)
				model.shortbar=Shop.Tools.RequestTool.RequestSafeString("shortbar");
			if (HttpContext.Current.Request["longbar"] != null)
				model.longbar=Shop.Tools.RequestTool.RequestSafeString("longbar");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestSafeString("Logo");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestSafeString("Domain");
			if (HttpContext.Current.Request["FreezeRemark"] != null)
				model.FreezeRemark=Shop.Tools.RequestTool.RequestSafeString("FreezeRemark");
			if (HttpContext.Current.Request["IsSpread"] != null)
				model.IsSpread=Shop.Tools.RequestTool.RequestInt("IsSpread",0);
			if (HttpContext.Current.Request["SupplierNumber"] != null)
				model.SupplierNumber=Shop.Tools.RequestTool.RequestSafeString("SupplierNumber");
			if (HttpContext.Current.Request["PointToMoney"] != null)
				model.PointToMoney=Shop.Tools.RequestTool.RequestDecimal("PointToMoney",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier model=new Lebi_Supplier();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.Password=dataReader["Password"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.RealName=dataReader["RealName"].ToString();
			model.Company=dataReader["Company"].ToString();
			model.SubName=dataReader["SubName"].ToString();
			model.Sex=dataReader["Sex"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			model.MobilePhone=dataReader["MobilePhone"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			model.Address=dataReader["Address"].ToString();
			model.QQ=dataReader["QQ"].ToString();
			model.Fax=dataReader["Fax"].ToString();
			model.Postalcode=dataReader["Postalcode"].ToString();
			model.Msn=dataReader["Msn"].ToString();
			ojb = dataReader["Count_Login"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Login=(int)ojb;
			}
			model.IP_Last=dataReader["IP_Last"].ToString();
			model.IP_This=dataReader["IP_This"].ToString();
			ojb = dataReader["Time_This"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_This=(DateTime)ojb;
			}
			ojb = dataReader["Time_Last"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Last=(DateTime)ojb;
			}
			ojb = dataReader["Time_Reg"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Reg=(DateTime)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			ojb = dataReader["Supplier_Group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_Group_id=(int)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Money_Margin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Margin=(decimal)ojb;
			}
			ojb = dataReader["Money_Margin_pay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Margin_pay=(decimal)ojb;
			}
			ojb = dataReader["Money_Service"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Service=(decimal)ojb;
			}
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Time_Begin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Begin=(DateTime)ojb;
			}
			ojb = dataReader["Time_End"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_End=(DateTime)ojb;
			}
			ojb = dataReader["BillingDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BillingDays=(int)ojb;
			}
			ojb = dataReader["Level_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Level_id=(int)ojb;
			}
			ojb = dataReader["Type_id_SupplierStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_SupplierStatus=(int)ojb;
			}
			ojb = dataReader["ProductTop"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductTop=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.ClassName=dataReader["ClassName"].ToString();
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["IsSupplierTransport"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSupplierTransport=(int)ojb;
			}
			model.ServicePanel=dataReader["ServicePanel"].ToString();
			ojb = dataReader["UserTop"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserTop=(int)ojb;
			}
			ojb = dataReader["UserLow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLow=(int)ojb;
			}
			ojb = dataReader["Days_checkuserlow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Days_checkuserlow=(int)ojb;
			}
			ojb = dataReader["IsCash"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCash=(int)ojb;
			}
			ojb = dataReader["Supplier_Skin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_Skin_id=(int)ojb;
			}
			model.head=dataReader["head"].ToString();
			model.shortbar=dataReader["shortbar"].ToString();
			model.longbar=dataReader["longbar"].ToString();
			model.Logo=dataReader["Logo"].ToString();
			model.Domain=dataReader["Domain"].ToString();
			model.FreezeRemark=dataReader["FreezeRemark"].ToString();
			ojb = dataReader["IsSpread"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSpread=(int)ojb;
			}
			model.SupplierNumber=dataReader["SupplierNumber"].ToString();
			ojb = dataReader["PointToMoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PointToMoney=(decimal)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Supplier : Lebi_Supplier_interface
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
				strSql.Append("select " + colName + " from [Lebi_Supplier]");
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
			strSql.Append("select  "+colName+" from [Lebi_Supplier]");
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
			strSql.Append("select count(*) from [Lebi_Supplier]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Supplier]");
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
			strSql.Append("select max(id) from [Lebi_Supplier]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier](");
			strSql.Append("[UserName],[Password],[Email],[RealName],[Company],[SubName],[Sex],[Area_id],[MobilePhone],[Phone],[Address],[QQ],[Fax],[Postalcode],[Msn],[Count_Login],[IP_Last],[IP_This],[Time_This],[Time_Last],[Time_Reg],[Status],[Language],[Supplier_Group_id],[Remark],[Money_Margin],[Money_Margin_pay],[Money_Service],[Money],[Time_Begin],[Time_End],[BillingDays],[Level_id],[Type_id_SupplierStatus],[ProductTop],[Name],[ClassName],[SEO_Title],[SEO_Description],[SEO_Keywords],[Description],[User_id],[IsSupplierTransport],[ServicePanel],[UserTop],[UserLow],[Days_checkuserlow],[IsCash],[Supplier_Skin_id],[head],[shortbar],[longbar],[Logo],[Domain],[FreezeRemark],[IsSpread],[SupplierNumber],[PointToMoney])");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Password,@Email,@RealName,@Company,@SubName,@Sex,@Area_id,@MobilePhone,@Phone,@Address,@QQ,@Fax,@Postalcode,@Msn,@Count_Login,@IP_Last,@IP_This,@Time_This,@Time_Last,@Time_Reg,@Status,@Language,@Supplier_Group_id,@Remark,@Money_Margin,@Money_Margin_pay,@Money_Service,@Money,@Time_Begin,@Time_End,@BillingDays,@Level_id,@Type_id_SupplierStatus,@ProductTop,@Name,@ClassName,@SEO_Title,@SEO_Description,@SEO_Keywords,@Description,@User_id,@IsSupplierTransport,@ServicePanel,@UserTop,@UserLow,@Days_checkuserlow,@IsCash,@Supplier_Skin_id,@head,@shortbar,@longbar,@Logo,@Domain,@FreezeRemark,@IsSpread,@SupplierNumber,@PointToMoney)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Password", model.Password),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@RealName", model.RealName),
					new OleDbParameter("@Company", model.Company),
					new OleDbParameter("@SubName", model.SubName),
					new OleDbParameter("@Sex", model.Sex),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@MobilePhone", model.MobilePhone),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@QQ", model.QQ),
					new OleDbParameter("@Fax", model.Fax),
					new OleDbParameter("@Postalcode", model.Postalcode),
					new OleDbParameter("@Msn", model.Msn),
					new OleDbParameter("@Count_Login", model.Count_Login),
					new OleDbParameter("@IP_Last", model.IP_Last),
					new OleDbParameter("@IP_This", model.IP_This),
					new OleDbParameter("@Time_This", model.Time_This.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Last", model.Time_Last.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Reg", model.Time_Reg.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Status", model.Status),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Supplier_Group_id", model.Supplier_Group_id),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Money_Margin", model.Money_Margin),
					new OleDbParameter("@Money_Margin_pay", model.Money_Margin_pay),
					new OleDbParameter("@Money_Service", model.Money_Service),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Time_Begin", model.Time_Begin.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@BillingDays", model.BillingDays),
					new OleDbParameter("@Level_id", model.Level_id),
					new OleDbParameter("@Type_id_SupplierStatus", model.Type_id_SupplierStatus),
					new OleDbParameter("@ProductTop", model.ProductTop),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@ClassName", model.ClassName),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@IsSupplierTransport", model.IsSupplierTransport),
					new OleDbParameter("@ServicePanel", model.ServicePanel),
					new OleDbParameter("@UserTop", model.UserTop),
					new OleDbParameter("@UserLow", model.UserLow),
					new OleDbParameter("@Days_checkuserlow", model.Days_checkuserlow),
					new OleDbParameter("@IsCash", model.IsCash),
					new OleDbParameter("@Supplier_Skin_id", model.Supplier_Skin_id),
					new OleDbParameter("@head", model.head),
					new OleDbParameter("@shortbar", model.shortbar),
					new OleDbParameter("@longbar", model.longbar),
					new OleDbParameter("@Logo", model.Logo),
					new OleDbParameter("@Domain", model.Domain),
					new OleDbParameter("@FreezeRemark", model.FreezeRemark),
					new OleDbParameter("@IsSpread", model.IsSpread),
					new OleDbParameter("@SupplierNumber", model.SupplierNumber),
					new OleDbParameter("@PointToMoney", model.PointToMoney)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier] set ");
			strSql.Append("[UserName]=@UserName,");
			strSql.Append("[Password]=@Password,");
			strSql.Append("[Email]=@Email,");
			strSql.Append("[RealName]=@RealName,");
			strSql.Append("[Company]=@Company,");
			strSql.Append("[SubName]=@SubName,");
			strSql.Append("[Sex]=@Sex,");
			strSql.Append("[Area_id]=@Area_id,");
			strSql.Append("[MobilePhone]=@MobilePhone,");
			strSql.Append("[Phone]=@Phone,");
			strSql.Append("[Address]=@Address,");
			strSql.Append("[QQ]=@QQ,");
			strSql.Append("[Fax]=@Fax,");
			strSql.Append("[Postalcode]=@Postalcode,");
			strSql.Append("[Msn]=@Msn,");
			strSql.Append("[Count_Login]=@Count_Login,");
			strSql.Append("[IP_Last]=@IP_Last,");
			strSql.Append("[IP_This]=@IP_This,");
			strSql.Append("[Time_This]=@Time_This,");
			strSql.Append("[Time_Last]=@Time_Last,");
			strSql.Append("[Time_Reg]=@Time_Reg,");
			strSql.Append("[Status]=@Status,");
			strSql.Append("[Language]=@Language,");
			strSql.Append("[Supplier_Group_id]=@Supplier_Group_id,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Money_Margin]=@Money_Margin,");
			strSql.Append("[Money_Margin_pay]=@Money_Margin_pay,");
			strSql.Append("[Money_Service]=@Money_Service,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[Time_Begin]=@Time_Begin,");
			strSql.Append("[Time_End]=@Time_End,");
			strSql.Append("[BillingDays]=@BillingDays,");
			strSql.Append("[Level_id]=@Level_id,");
			strSql.Append("[Type_id_SupplierStatus]=@Type_id_SupplierStatus,");
			strSql.Append("[ProductTop]=@ProductTop,");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[ClassName]=@ClassName,");
			strSql.Append("[SEO_Title]=@SEO_Title,");
			strSql.Append("[SEO_Description]=@SEO_Description,");
			strSql.Append("[SEO_Keywords]=@SEO_Keywords,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[IsSupplierTransport]=@IsSupplierTransport,");
			strSql.Append("[ServicePanel]=@ServicePanel,");
			strSql.Append("[UserTop]=@UserTop,");
			strSql.Append("[UserLow]=@UserLow,");
			strSql.Append("[Days_checkuserlow]=@Days_checkuserlow,");
			strSql.Append("[IsCash]=@IsCash,");
			strSql.Append("[Supplier_Skin_id]=@Supplier_Skin_id,");
			strSql.Append("[head]=@head,");
			strSql.Append("[shortbar]=@shortbar,");
			strSql.Append("[longbar]=@longbar,");
			strSql.Append("[Logo]=@Logo,");
			strSql.Append("[Domain]=@Domain,");
			strSql.Append("[FreezeRemark]=@FreezeRemark,");
			strSql.Append("[IsSpread]=@IsSpread,");
			strSql.Append("[SupplierNumber]=@SupplierNumber,");
			strSql.Append("[PointToMoney]=@PointToMoney");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Password", model.Password),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@RealName", model.RealName),
					new OleDbParameter("@Company", model.Company),
					new OleDbParameter("@SubName", model.SubName),
					new OleDbParameter("@Sex", model.Sex),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@MobilePhone", model.MobilePhone),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@QQ", model.QQ),
					new OleDbParameter("@Fax", model.Fax),
					new OleDbParameter("@Postalcode", model.Postalcode),
					new OleDbParameter("@Msn", model.Msn),
					new OleDbParameter("@Count_Login", model.Count_Login),
					new OleDbParameter("@IP_Last", model.IP_Last),
					new OleDbParameter("@IP_This", model.IP_This),
					new OleDbParameter("@Time_This", model.Time_This.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Last", model.Time_Last.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Reg", model.Time_Reg.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Status", model.Status),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Supplier_Group_id", model.Supplier_Group_id),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Money_Margin", model.Money_Margin),
					new OleDbParameter("@Money_Margin_pay", model.Money_Margin_pay),
					new OleDbParameter("@Money_Service", model.Money_Service),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Time_Begin", model.Time_Begin.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@BillingDays", model.BillingDays),
					new OleDbParameter("@Level_id", model.Level_id),
					new OleDbParameter("@Type_id_SupplierStatus", model.Type_id_SupplierStatus),
					new OleDbParameter("@ProductTop", model.ProductTop),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@ClassName", model.ClassName),
					new OleDbParameter("@SEO_Title", model.SEO_Title),
					new OleDbParameter("@SEO_Description", model.SEO_Description),
					new OleDbParameter("@SEO_Keywords", model.SEO_Keywords),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@IsSupplierTransport", model.IsSupplierTransport),
					new OleDbParameter("@ServicePanel", model.ServicePanel),
					new OleDbParameter("@UserTop", model.UserTop),
					new OleDbParameter("@UserLow", model.UserLow),
					new OleDbParameter("@Days_checkuserlow", model.Days_checkuserlow),
					new OleDbParameter("@IsCash", model.IsCash),
					new OleDbParameter("@Supplier_Skin_id", model.Supplier_Skin_id),
					new OleDbParameter("@head", model.head),
					new OleDbParameter("@shortbar", model.shortbar),
					new OleDbParameter("@longbar", model.longbar),
					new OleDbParameter("@Logo", model.Logo),
					new OleDbParameter("@Domain", model.Domain),
					new OleDbParameter("@FreezeRemark", model.FreezeRemark),
					new OleDbParameter("@IsSpread", model.IsSpread),
					new OleDbParameter("@SupplierNumber", model.SupplierNumber),
					new OleDbParameter("@PointToMoney", model.PointToMoney)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier] ");
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
			strSql.Append("delete from [Lebi_Supplier] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Supplier model;
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
		public Lebi_Supplier GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier model;
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
		public Lebi_Supplier GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier model;
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
		public List<Lebi_Supplier> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier> list = new List<Lebi_Supplier>();
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
		public List<Lebi_Supplier> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier]";
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
			List<Lebi_Supplier> list = new List<Lebi_Supplier>();
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
		public List<Lebi_Supplier> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier> list = new List<Lebi_Supplier>();
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
		public List<Lebi_Supplier> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier> list = new List<Lebi_Supplier>();
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
		public Lebi_Supplier BindForm(Lebi_Supplier model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestString("Password");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestString("RealName");
			if (HttpContext.Current.Request["Company"] != null)
				model.Company=Shop.Tools.RequestTool.RequestString("Company");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestString("SubName");
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestString("Sex");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestString("QQ");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestString("Fax");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestString("Postalcode");
			if (HttpContext.Current.Request["Msn"] != null)
				model.Msn=Shop.Tools.RequestTool.RequestString("Msn");
			if (HttpContext.Current.Request["Count_Login"] != null)
				model.Count_Login=Shop.Tools.RequestTool.RequestInt("Count_Login",0);
			if (HttpContext.Current.Request["IP_Last"] != null)
				model.IP_Last=Shop.Tools.RequestTool.RequestString("IP_Last");
			if (HttpContext.Current.Request["IP_This"] != null)
				model.IP_This=Shop.Tools.RequestTool.RequestString("IP_This");
			if (HttpContext.Current.Request["Time_This"] != null)
				model.Time_This=Shop.Tools.RequestTool.RequestTime("Time_This", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Last"] != null)
				model.Time_Last=Shop.Tools.RequestTool.RequestTime("Time_Last", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Reg"] != null)
				model.Time_Reg=Shop.Tools.RequestTool.RequestTime("Time_Reg", System.DateTime.Now);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Supplier_Group_id"] != null)
				model.Supplier_Group_id=Shop.Tools.RequestTool.RequestInt("Supplier_Group_id",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Money_Margin"] != null)
				model.Money_Margin=Shop.Tools.RequestTool.RequestDecimal("Money_Margin",0);
			if (HttpContext.Current.Request["Money_Margin_pay"] != null)
				model.Money_Margin_pay=Shop.Tools.RequestTool.RequestDecimal("Money_Margin_pay",0);
			if (HttpContext.Current.Request["Money_Service"] != null)
				model.Money_Service=Shop.Tools.RequestTool.RequestDecimal("Money_Service",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["BillingDays"] != null)
				model.BillingDays=Shop.Tools.RequestTool.RequestInt("BillingDays",0);
			if (HttpContext.Current.Request["Level_id"] != null)
				model.Level_id=Shop.Tools.RequestTool.RequestInt("Level_id",0);
			if (HttpContext.Current.Request["Type_id_SupplierStatus"] != null)
				model.Type_id_SupplierStatus=Shop.Tools.RequestTool.RequestInt("Type_id_SupplierStatus",0);
			if (HttpContext.Current.Request["ProductTop"] != null)
				model.ProductTop=Shop.Tools.RequestTool.RequestInt("ProductTop",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["ClassName"] != null)
				model.ClassName=Shop.Tools.RequestTool.RequestString("ClassName");
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestString("SEO_Description");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestString("SEO_Keywords");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["ServicePanel"] != null)
				model.ServicePanel=Shop.Tools.RequestTool.RequestString("ServicePanel");
			if (HttpContext.Current.Request["UserTop"] != null)
				model.UserTop=Shop.Tools.RequestTool.RequestInt("UserTop",0);
			if (HttpContext.Current.Request["UserLow"] != null)
				model.UserLow=Shop.Tools.RequestTool.RequestInt("UserLow",0);
			if (HttpContext.Current.Request["Days_checkuserlow"] != null)
				model.Days_checkuserlow=Shop.Tools.RequestTool.RequestInt("Days_checkuserlow",0);
			if (HttpContext.Current.Request["IsCash"] != null)
				model.IsCash=Shop.Tools.RequestTool.RequestInt("IsCash",0);
			if (HttpContext.Current.Request["Supplier_Skin_id"] != null)
				model.Supplier_Skin_id=Shop.Tools.RequestTool.RequestInt("Supplier_Skin_id",0);
			if (HttpContext.Current.Request["head"] != null)
				model.head=Shop.Tools.RequestTool.RequestString("head");
			if (HttpContext.Current.Request["shortbar"] != null)
				model.shortbar=Shop.Tools.RequestTool.RequestString("shortbar");
			if (HttpContext.Current.Request["longbar"] != null)
				model.longbar=Shop.Tools.RequestTool.RequestString("longbar");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestString("Logo");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestString("Domain");
			if (HttpContext.Current.Request["FreezeRemark"] != null)
				model.FreezeRemark=Shop.Tools.RequestTool.RequestString("FreezeRemark");
			if (HttpContext.Current.Request["IsSpread"] != null)
				model.IsSpread=Shop.Tools.RequestTool.RequestInt("IsSpread",0);
			if (HttpContext.Current.Request["SupplierNumber"] != null)
				model.SupplierNumber=Shop.Tools.RequestTool.RequestString("SupplierNumber");
			if (HttpContext.Current.Request["PointToMoney"] != null)
				model.PointToMoney=Shop.Tools.RequestTool.RequestDecimal("PointToMoney",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier SafeBindForm(Lebi_Supplier model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestSafeString("Password");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestSafeString("RealName");
			if (HttpContext.Current.Request["Company"] != null)
				model.Company=Shop.Tools.RequestTool.RequestSafeString("Company");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestSafeString("SubName");
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestSafeString("Sex");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestSafeString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestSafeString("QQ");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestSafeString("Fax");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestSafeString("Postalcode");
			if (HttpContext.Current.Request["Msn"] != null)
				model.Msn=Shop.Tools.RequestTool.RequestSafeString("Msn");
			if (HttpContext.Current.Request["Count_Login"] != null)
				model.Count_Login=Shop.Tools.RequestTool.RequestInt("Count_Login",0);
			if (HttpContext.Current.Request["IP_Last"] != null)
				model.IP_Last=Shop.Tools.RequestTool.RequestSafeString("IP_Last");
			if (HttpContext.Current.Request["IP_This"] != null)
				model.IP_This=Shop.Tools.RequestTool.RequestSafeString("IP_This");
			if (HttpContext.Current.Request["Time_This"] != null)
				model.Time_This=Shop.Tools.RequestTool.RequestTime("Time_This", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Last"] != null)
				model.Time_Last=Shop.Tools.RequestTool.RequestTime("Time_Last", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Reg"] != null)
				model.Time_Reg=Shop.Tools.RequestTool.RequestTime("Time_Reg", System.DateTime.Now);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Supplier_Group_id"] != null)
				model.Supplier_Group_id=Shop.Tools.RequestTool.RequestInt("Supplier_Group_id",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Money_Margin"] != null)
				model.Money_Margin=Shop.Tools.RequestTool.RequestDecimal("Money_Margin",0);
			if (HttpContext.Current.Request["Money_Margin_pay"] != null)
				model.Money_Margin_pay=Shop.Tools.RequestTool.RequestDecimal("Money_Margin_pay",0);
			if (HttpContext.Current.Request["Money_Service"] != null)
				model.Money_Service=Shop.Tools.RequestTool.RequestDecimal("Money_Service",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["BillingDays"] != null)
				model.BillingDays=Shop.Tools.RequestTool.RequestInt("BillingDays",0);
			if (HttpContext.Current.Request["Level_id"] != null)
				model.Level_id=Shop.Tools.RequestTool.RequestInt("Level_id",0);
			if (HttpContext.Current.Request["Type_id_SupplierStatus"] != null)
				model.Type_id_SupplierStatus=Shop.Tools.RequestTool.RequestInt("Type_id_SupplierStatus",0);
			if (HttpContext.Current.Request["ProductTop"] != null)
				model.ProductTop=Shop.Tools.RequestTool.RequestInt("ProductTop",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["ClassName"] != null)
				model.ClassName=Shop.Tools.RequestTool.RequestSafeString("ClassName");
			if (HttpContext.Current.Request["SEO_Title"] != null)
				model.SEO_Title=Shop.Tools.RequestTool.RequestSafeString("SEO_Title");
			if (HttpContext.Current.Request["SEO_Description"] != null)
				model.SEO_Description=Shop.Tools.RequestTool.RequestSafeString("SEO_Description");
			if (HttpContext.Current.Request["SEO_Keywords"] != null)
				model.SEO_Keywords=Shop.Tools.RequestTool.RequestSafeString("SEO_Keywords");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["IsSupplierTransport"] != null)
				model.IsSupplierTransport=Shop.Tools.RequestTool.RequestInt("IsSupplierTransport",0);
			if (HttpContext.Current.Request["ServicePanel"] != null)
				model.ServicePanel=Shop.Tools.RequestTool.RequestSafeString("ServicePanel");
			if (HttpContext.Current.Request["UserTop"] != null)
				model.UserTop=Shop.Tools.RequestTool.RequestInt("UserTop",0);
			if (HttpContext.Current.Request["UserLow"] != null)
				model.UserLow=Shop.Tools.RequestTool.RequestInt("UserLow",0);
			if (HttpContext.Current.Request["Days_checkuserlow"] != null)
				model.Days_checkuserlow=Shop.Tools.RequestTool.RequestInt("Days_checkuserlow",0);
			if (HttpContext.Current.Request["IsCash"] != null)
				model.IsCash=Shop.Tools.RequestTool.RequestInt("IsCash",0);
			if (HttpContext.Current.Request["Supplier_Skin_id"] != null)
				model.Supplier_Skin_id=Shop.Tools.RequestTool.RequestInt("Supplier_Skin_id",0);
			if (HttpContext.Current.Request["head"] != null)
				model.head=Shop.Tools.RequestTool.RequestSafeString("head");
			if (HttpContext.Current.Request["shortbar"] != null)
				model.shortbar=Shop.Tools.RequestTool.RequestSafeString("shortbar");
			if (HttpContext.Current.Request["longbar"] != null)
				model.longbar=Shop.Tools.RequestTool.RequestSafeString("longbar");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestSafeString("Logo");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestSafeString("Domain");
			if (HttpContext.Current.Request["FreezeRemark"] != null)
				model.FreezeRemark=Shop.Tools.RequestTool.RequestSafeString("FreezeRemark");
			if (HttpContext.Current.Request["IsSpread"] != null)
				model.IsSpread=Shop.Tools.RequestTool.RequestInt("IsSpread",0);
			if (HttpContext.Current.Request["SupplierNumber"] != null)
				model.SupplierNumber=Shop.Tools.RequestTool.RequestSafeString("SupplierNumber");
			if (HttpContext.Current.Request["PointToMoney"] != null)
				model.PointToMoney=Shop.Tools.RequestTool.RequestDecimal("PointToMoney",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier model=new Lebi_Supplier();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.Password=dataReader["Password"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.RealName=dataReader["RealName"].ToString();
			model.Company=dataReader["Company"].ToString();
			model.SubName=dataReader["SubName"].ToString();
			model.Sex=dataReader["Sex"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			model.MobilePhone=dataReader["MobilePhone"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			model.Address=dataReader["Address"].ToString();
			model.QQ=dataReader["QQ"].ToString();
			model.Fax=dataReader["Fax"].ToString();
			model.Postalcode=dataReader["Postalcode"].ToString();
			model.Msn=dataReader["Msn"].ToString();
			ojb = dataReader["Count_Login"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Login=(int)ojb;
			}
			model.IP_Last=dataReader["IP_Last"].ToString();
			model.IP_This=dataReader["IP_This"].ToString();
			ojb = dataReader["Time_This"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_This=(DateTime)ojb;
			}
			ojb = dataReader["Time_Last"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Last=(DateTime)ojb;
			}
			ojb = dataReader["Time_Reg"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Reg=(DateTime)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			ojb = dataReader["Supplier_Group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_Group_id=(int)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Money_Margin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Margin=(decimal)ojb;
			}
			ojb = dataReader["Money_Margin_pay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Margin_pay=(decimal)ojb;
			}
			ojb = dataReader["Money_Service"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Service=(decimal)ojb;
			}
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Time_Begin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Begin=(DateTime)ojb;
			}
			ojb = dataReader["Time_End"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_End=(DateTime)ojb;
			}
			ojb = dataReader["BillingDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BillingDays=(int)ojb;
			}
			ojb = dataReader["Level_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Level_id=(int)ojb;
			}
			ojb = dataReader["Type_id_SupplierStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_SupplierStatus=(int)ojb;
			}
			ojb = dataReader["ProductTop"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductTop=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.ClassName=dataReader["ClassName"].ToString();
			model.SEO_Title=dataReader["SEO_Title"].ToString();
			model.SEO_Description=dataReader["SEO_Description"].ToString();
			model.SEO_Keywords=dataReader["SEO_Keywords"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["IsSupplierTransport"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSupplierTransport=(int)ojb;
			}
			model.ServicePanel=dataReader["ServicePanel"].ToString();
			ojb = dataReader["UserTop"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserTop=(int)ojb;
			}
			ojb = dataReader["UserLow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLow=(int)ojb;
			}
			ojb = dataReader["Days_checkuserlow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Days_checkuserlow=(int)ojb;
			}
			ojb = dataReader["IsCash"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCash=(int)ojb;
			}
			ojb = dataReader["Supplier_Skin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_Skin_id=(int)ojb;
			}
			model.head=dataReader["head"].ToString();
			model.shortbar=dataReader["shortbar"].ToString();
			model.longbar=dataReader["longbar"].ToString();
			model.Logo=dataReader["Logo"].ToString();
			model.Domain=dataReader["Domain"].ToString();
			model.FreezeRemark=dataReader["FreezeRemark"].ToString();
			ojb = dataReader["IsSpread"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSpread=(int)ojb;
			}
			model.SupplierNumber=dataReader["SupplierNumber"].ToString();
			ojb = dataReader["PointToMoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PointToMoney=(decimal)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

