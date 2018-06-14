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

	public interface Lebi_User_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_User model);
		void Update(Lebi_User model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_User GetModel(int id);
		Lebi_User GetModel(string strWhere);
		Lebi_User GetModel(SQLPara para);
		List<Lebi_User> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_User> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_User> GetList(string strWhere, string strFieldOrder);
		List<Lebi_User> GetList(SQLPara para);
		Lebi_User BindForm(Lebi_User model);
		Lebi_User SafeBindForm(Lebi_User model);
		Lebi_User ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_User。
	/// </summary>
	public class D_Lebi_User
	{
		static Lebi_User_interface _Instance;
		public static Lebi_User_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_User();
		            else
		                _Instance = new sqlserver_Lebi_User();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_User()
		{}
		#region  成员方法
	class sqlserver_Lebi_User : Lebi_User_interface
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
				strSql.Append("select " + colName + " from [Lebi_User]");
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
			strSql.Append("select  "+colName+" from [Lebi_User]");
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
			strSql.Append("select count(1) from [Lebi_User]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User]");
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
			strSql.Append("select max(id) from [Lebi_User]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_User](");
			strSql.Append("UserName,Password,JYpwd,Email,RealName,lnum,Sex,NickName,Birthday,pwdwen,pwdda,Point,Uavatar,City,Area_id,Address,MobilePhone,Phone,QQ,Fax,Postalcode,Msn,Yfmoney,Money,Money_xiaofei,Count_Login,IP_Last,IP_This,Time_This,Time_Last,Time_Reg,Upass,IsOpen,Introduce,UserLevel_id,Time_lastorder,User_Address_id,Transport_Price_id,Pay_id,OnlinePay_id,Count_Order,Count_Order_OK,Language,CheckCode,Currency_id,Currency_Code,Face,bind_qq_id,bind_qq_token,bind_qq_nickname,bind_weibo_id,bind_weibo_token,bind_weibo_nickname,bind_taobao_id,bind_taobao_token,bind_taobao_nickname,bind_facebook_id,bind_facebook_token,bind_facebook_nickname,IsPlatformAccount,IsAnonymous,User_id_parent,Pay_Password,AgentMoney,AgentMoney_history,Count_sonuser,CashAccount_Code,CashAccount_Name,CashAccount_Bank,bind_weixin_nickname,bind_weixin_token,bind_weixin_id,Site_id,UserNumber,weixin,alipay,aliwangwang,momo,job,IDNumber,IDType,Money_Order,Money_Product,Money_Transport,Money_Bill,Time_End,IsCheckedEmail,IsCheckedMobilePhone,RandNum,PickUp_id,PickUp_Date,Device_id,Device_system,Money_fanxian,DT_id,IsDel)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Password,@JYpwd,@Email,@RealName,@lnum,@Sex,@NickName,@Birthday,@pwdwen,@pwdda,@Point,@Uavatar,@City,@Area_id,@Address,@MobilePhone,@Phone,@QQ,@Fax,@Postalcode,@Msn,@Yfmoney,@Money,@Money_xiaofei,@Count_Login,@IP_Last,@IP_This,@Time_This,@Time_Last,@Time_Reg,@Upass,@IsOpen,@Introduce,@UserLevel_id,@Time_lastorder,@User_Address_id,@Transport_Price_id,@Pay_id,@OnlinePay_id,@Count_Order,@Count_Order_OK,@Language,@CheckCode,@Currency_id,@Currency_Code,@Face,@bind_qq_id,@bind_qq_token,@bind_qq_nickname,@bind_weibo_id,@bind_weibo_token,@bind_weibo_nickname,@bind_taobao_id,@bind_taobao_token,@bind_taobao_nickname,@bind_facebook_id,@bind_facebook_token,@bind_facebook_nickname,@IsPlatformAccount,@IsAnonymous,@User_id_parent,@Pay_Password,@AgentMoney,@AgentMoney_history,@Count_sonuser,@CashAccount_Code,@CashAccount_Name,@CashAccount_Bank,@bind_weixin_nickname,@bind_weixin_token,@bind_weixin_id,@Site_id,@UserNumber,@weixin,@alipay,@aliwangwang,@momo,@job,@IDNumber,@IDType,@Money_Order,@Money_Product,@Money_Transport,@Money_Bill,@Time_End,@IsCheckedEmail,@IsCheckedMobilePhone,@RandNum,@PickUp_id,@PickUp_Date,@Device_id,@Device_system,@Money_fanxian,@DT_id,@IsDel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", model.UserName),
					new SqlParameter("@Password", model.Password),
					new SqlParameter("@JYpwd", model.JYpwd),
					new SqlParameter("@Email", model.Email),
					new SqlParameter("@RealName", model.RealName),
					new SqlParameter("@lnum", model.lnum),
					new SqlParameter("@Sex", model.Sex),
					new SqlParameter("@NickName", model.NickName),
					new SqlParameter("@Birthday", model.Birthday),
					new SqlParameter("@pwdwen", model.pwdwen),
					new SqlParameter("@pwdda", model.pwdda),
					new SqlParameter("@Point", model.Point),
					new SqlParameter("@Uavatar", model.Uavatar),
					new SqlParameter("@City", model.City),
					new SqlParameter("@Area_id", model.Area_id),
					new SqlParameter("@Address", model.Address),
					new SqlParameter("@MobilePhone", model.MobilePhone),
					new SqlParameter("@Phone", model.Phone),
					new SqlParameter("@QQ", model.QQ),
					new SqlParameter("@Fax", model.Fax),
					new SqlParameter("@Postalcode", model.Postalcode),
					new SqlParameter("@Msn", model.Msn),
					new SqlParameter("@Yfmoney", model.Yfmoney),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@Money_xiaofei", model.Money_xiaofei),
					new SqlParameter("@Count_Login", model.Count_Login),
					new SqlParameter("@IP_Last", model.IP_Last),
					new SqlParameter("@IP_This", model.IP_This),
					new SqlParameter("@Time_This", model.Time_This),
					new SqlParameter("@Time_Last", model.Time_Last),
					new SqlParameter("@Time_Reg", model.Time_Reg),
					new SqlParameter("@Upass", model.Upass),
					new SqlParameter("@IsOpen", model.IsOpen),
					new SqlParameter("@Introduce", model.Introduce),
					new SqlParameter("@UserLevel_id", model.UserLevel_id),
					new SqlParameter("@Time_lastorder", model.Time_lastorder),
					new SqlParameter("@User_Address_id", model.User_Address_id),
					new SqlParameter("@Transport_Price_id", model.Transport_Price_id),
					new SqlParameter("@Pay_id", model.Pay_id),
					new SqlParameter("@OnlinePay_id", model.OnlinePay_id),
					new SqlParameter("@Count_Order", model.Count_Order),
					new SqlParameter("@Count_Order_OK", model.Count_Order_OK),
					new SqlParameter("@Language", model.Language),
					new SqlParameter("@CheckCode", model.CheckCode),
					new SqlParameter("@Currency_id", model.Currency_id),
					new SqlParameter("@Currency_Code", model.Currency_Code),
					new SqlParameter("@Face", model.Face),
					new SqlParameter("@bind_qq_id", model.bind_qq_id),
					new SqlParameter("@bind_qq_token", model.bind_qq_token),
					new SqlParameter("@bind_qq_nickname", model.bind_qq_nickname),
					new SqlParameter("@bind_weibo_id", model.bind_weibo_id),
					new SqlParameter("@bind_weibo_token", model.bind_weibo_token),
					new SqlParameter("@bind_weibo_nickname", model.bind_weibo_nickname),
					new SqlParameter("@bind_taobao_id", model.bind_taobao_id),
					new SqlParameter("@bind_taobao_token", model.bind_taobao_token),
					new SqlParameter("@bind_taobao_nickname", model.bind_taobao_nickname),
					new SqlParameter("@bind_facebook_id", model.bind_facebook_id),
					new SqlParameter("@bind_facebook_token", model.bind_facebook_token),
					new SqlParameter("@bind_facebook_nickname", model.bind_facebook_nickname),
					new SqlParameter("@IsPlatformAccount", model.IsPlatformAccount),
					new SqlParameter("@IsAnonymous", model.IsAnonymous),
					new SqlParameter("@User_id_parent", model.User_id_parent),
					new SqlParameter("@Pay_Password", model.Pay_Password),
					new SqlParameter("@AgentMoney", model.AgentMoney),
					new SqlParameter("@AgentMoney_history", model.AgentMoney_history),
					new SqlParameter("@Count_sonuser", model.Count_sonuser),
					new SqlParameter("@CashAccount_Code", model.CashAccount_Code),
					new SqlParameter("@CashAccount_Name", model.CashAccount_Name),
					new SqlParameter("@CashAccount_Bank", model.CashAccount_Bank),
					new SqlParameter("@bind_weixin_nickname", model.bind_weixin_nickname),
					new SqlParameter("@bind_weixin_token", model.bind_weixin_token),
					new SqlParameter("@bind_weixin_id", model.bind_weixin_id),
					new SqlParameter("@Site_id", model.Site_id),
					new SqlParameter("@UserNumber", model.UserNumber),
					new SqlParameter("@weixin", model.weixin),
					new SqlParameter("@alipay", model.alipay),
					new SqlParameter("@aliwangwang", model.aliwangwang),
					new SqlParameter("@momo", model.momo),
					new SqlParameter("@job", model.job),
					new SqlParameter("@IDNumber", model.IDNumber),
					new SqlParameter("@IDType", model.IDType),
					new SqlParameter("@Money_Order", model.Money_Order),
					new SqlParameter("@Money_Product", model.Money_Product),
					new SqlParameter("@Money_Transport", model.Money_Transport),
					new SqlParameter("@Money_Bill", model.Money_Bill),
					new SqlParameter("@Time_End", model.Time_End),
					new SqlParameter("@IsCheckedEmail", model.IsCheckedEmail),
					new SqlParameter("@IsCheckedMobilePhone", model.IsCheckedMobilePhone),
					new SqlParameter("@RandNum", model.RandNum),
					new SqlParameter("@PickUp_id", model.PickUp_id),
					new SqlParameter("@PickUp_Date", model.PickUp_Date),
					new SqlParameter("@Device_id", model.Device_id),
					new SqlParameter("@Device_system", model.Device_system),
					new SqlParameter("@Money_fanxian", model.Money_fanxian),
					new SqlParameter("@DT_id", model.DT_id),
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
		public void Update(Lebi_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_User] set ");
			strSql.Append("UserName= @UserName,");
			strSql.Append("Password= @Password,");
			strSql.Append("JYpwd= @JYpwd,");
			strSql.Append("Email= @Email,");
			strSql.Append("RealName= @RealName,");
			strSql.Append("lnum= @lnum,");
			strSql.Append("Sex= @Sex,");
			strSql.Append("NickName= @NickName,");
			strSql.Append("Birthday= @Birthday,");
			strSql.Append("pwdwen= @pwdwen,");
			strSql.Append("pwdda= @pwdda,");
			strSql.Append("Point= @Point,");
			strSql.Append("Uavatar= @Uavatar,");
			strSql.Append("City= @City,");
			strSql.Append("Area_id= @Area_id,");
			strSql.Append("Address= @Address,");
			strSql.Append("MobilePhone= @MobilePhone,");
			strSql.Append("Phone= @Phone,");
			strSql.Append("QQ= @QQ,");
			strSql.Append("Fax= @Fax,");
			strSql.Append("Postalcode= @Postalcode,");
			strSql.Append("Msn= @Msn,");
			strSql.Append("Yfmoney= @Yfmoney,");
			strSql.Append("Money= @Money,");
			strSql.Append("Money_xiaofei= @Money_xiaofei,");
			strSql.Append("Count_Login= @Count_Login,");
			strSql.Append("IP_Last= @IP_Last,");
			strSql.Append("IP_This= @IP_This,");
			strSql.Append("Time_This= @Time_This,");
			strSql.Append("Time_Last= @Time_Last,");
			strSql.Append("Time_Reg= @Time_Reg,");
			strSql.Append("Upass= @Upass,");
			strSql.Append("IsOpen= @IsOpen,");
			strSql.Append("Introduce= @Introduce,");
			strSql.Append("UserLevel_id= @UserLevel_id,");
			strSql.Append("Time_lastorder= @Time_lastorder,");
			strSql.Append("User_Address_id= @User_Address_id,");
			strSql.Append("Transport_Price_id= @Transport_Price_id,");
			strSql.Append("Pay_id= @Pay_id,");
			strSql.Append("OnlinePay_id= @OnlinePay_id,");
			strSql.Append("Count_Order= @Count_Order,");
			strSql.Append("Count_Order_OK= @Count_Order_OK,");
			strSql.Append("Language= @Language,");
			strSql.Append("CheckCode= @CheckCode,");
			strSql.Append("Currency_id= @Currency_id,");
			strSql.Append("Currency_Code= @Currency_Code,");
			strSql.Append("Face= @Face,");
			strSql.Append("bind_qq_id= @bind_qq_id,");
			strSql.Append("bind_qq_token= @bind_qq_token,");
			strSql.Append("bind_qq_nickname= @bind_qq_nickname,");
			strSql.Append("bind_weibo_id= @bind_weibo_id,");
			strSql.Append("bind_weibo_token= @bind_weibo_token,");
			strSql.Append("bind_weibo_nickname= @bind_weibo_nickname,");
			strSql.Append("bind_taobao_id= @bind_taobao_id,");
			strSql.Append("bind_taobao_token= @bind_taobao_token,");
			strSql.Append("bind_taobao_nickname= @bind_taobao_nickname,");
			strSql.Append("bind_facebook_id= @bind_facebook_id,");
			strSql.Append("bind_facebook_token= @bind_facebook_token,");
			strSql.Append("bind_facebook_nickname= @bind_facebook_nickname,");
			strSql.Append("IsPlatformAccount= @IsPlatformAccount,");
			strSql.Append("IsAnonymous= @IsAnonymous,");
			strSql.Append("User_id_parent= @User_id_parent,");
			strSql.Append("Pay_Password= @Pay_Password,");
			strSql.Append("AgentMoney= @AgentMoney,");
			strSql.Append("AgentMoney_history= @AgentMoney_history,");
			strSql.Append("Count_sonuser= @Count_sonuser,");
			strSql.Append("CashAccount_Code= @CashAccount_Code,");
			strSql.Append("CashAccount_Name= @CashAccount_Name,");
			strSql.Append("CashAccount_Bank= @CashAccount_Bank,");
			strSql.Append("bind_weixin_nickname= @bind_weixin_nickname,");
			strSql.Append("bind_weixin_token= @bind_weixin_token,");
			strSql.Append("bind_weixin_id= @bind_weixin_id,");
			strSql.Append("Site_id= @Site_id,");
			strSql.Append("UserNumber= @UserNumber,");
			strSql.Append("weixin= @weixin,");
			strSql.Append("alipay= @alipay,");
			strSql.Append("aliwangwang= @aliwangwang,");
			strSql.Append("momo= @momo,");
			strSql.Append("job= @job,");
			strSql.Append("IDNumber= @IDNumber,");
			strSql.Append("IDType= @IDType,");
			strSql.Append("Money_Order= @Money_Order,");
			strSql.Append("Money_Product= @Money_Product,");
			strSql.Append("Money_Transport= @Money_Transport,");
			strSql.Append("Money_Bill= @Money_Bill,");
			strSql.Append("Time_End= @Time_End,");
			strSql.Append("IsCheckedEmail= @IsCheckedEmail,");
			strSql.Append("IsCheckedMobilePhone= @IsCheckedMobilePhone,");
			strSql.Append("RandNum= @RandNum,");
			strSql.Append("PickUp_id= @PickUp_id,");
			strSql.Append("PickUp_Date= @PickUp_Date,");
			strSql.Append("Device_id= @Device_id,");
			strSql.Append("Device_system= @Device_system,");
			strSql.Append("Money_fanxian= @Money_fanxian,");
			strSql.Append("DT_id= @DT_id,");
			strSql.Append("IsDel= @IsDel");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@JYpwd", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@lnum", SqlDbType.Int,4),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@NickName", SqlDbType.NVarChar,100),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@pwdwen", SqlDbType.NVarChar,50),
					new SqlParameter("@pwdda", SqlDbType.NVarChar,50),
					new SqlParameter("@Point", SqlDbType.Decimal,9),
					new SqlParameter("@Uavatar", SqlDbType.NVarChar,50),
					new SqlParameter("@City", SqlDbType.NVarChar,50),
					new SqlParameter("@Area_id", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Postalcode", SqlDbType.NVarChar,20),
					new SqlParameter("@Msn", SqlDbType.NVarChar,100),
					new SqlParameter("@Yfmoney", SqlDbType.Decimal,9),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@Money_xiaofei", SqlDbType.Decimal,9),
					new SqlParameter("@Count_Login", SqlDbType.Int,4),
					new SqlParameter("@IP_Last", SqlDbType.NVarChar,20),
					new SqlParameter("@IP_This", SqlDbType.NVarChar,20),
					new SqlParameter("@Time_This", SqlDbType.DateTime),
					new SqlParameter("@Time_Last", SqlDbType.DateTime),
					new SqlParameter("@Time_Reg", SqlDbType.DateTime),
					new SqlParameter("@Upass", SqlDbType.Int,4),
					new SqlParameter("@IsOpen", SqlDbType.Int,4),
					new SqlParameter("@Introduce", SqlDbType.NVarChar,1000),
					new SqlParameter("@UserLevel_id", SqlDbType.Int,4),
					new SqlParameter("@Time_lastorder", SqlDbType.DateTime),
					new SqlParameter("@User_Address_id", SqlDbType.Int,4),
					new SqlParameter("@Transport_Price_id", SqlDbType.NVarChar,100),
					new SqlParameter("@Pay_id", SqlDbType.Int,4),
					new SqlParameter("@OnlinePay_id", SqlDbType.Int,4),
					new SqlParameter("@Count_Order", SqlDbType.Int,4),
					new SqlParameter("@Count_Order_OK", SqlDbType.Int,4),
					new SqlParameter("@Language", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency_id", SqlDbType.Int,4),
					new SqlParameter("@Currency_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Face", SqlDbType.NVarChar,255),
					new SqlParameter("@bind_qq_id", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_qq_token", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_qq_nickname", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_weibo_id", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_weibo_token", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_weibo_nickname", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_taobao_id", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_taobao_token", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_taobao_nickname", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_facebook_id", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_facebook_token", SqlDbType.NVarChar,250),
					new SqlParameter("@bind_facebook_nickname", SqlDbType.NVarChar,100),
					new SqlParameter("@IsPlatformAccount", SqlDbType.Int,4),
					new SqlParameter("@IsAnonymous", SqlDbType.Int,4),
					new SqlParameter("@User_id_parent", SqlDbType.Int,4),
					new SqlParameter("@Pay_Password", SqlDbType.NVarChar,50),
					new SqlParameter("@AgentMoney", SqlDbType.Decimal,9),
					new SqlParameter("@AgentMoney_history", SqlDbType.Decimal,9),
					new SqlParameter("@Count_sonuser", SqlDbType.Int,4),
					new SqlParameter("@CashAccount_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@CashAccount_Name", SqlDbType.NVarChar,200),
					new SqlParameter("@CashAccount_Bank", SqlDbType.NVarChar,200),
					new SqlParameter("@bind_weixin_nickname", SqlDbType.NVarChar,100),
					new SqlParameter("@bind_weixin_token", SqlDbType.NVarChar,200),
					new SqlParameter("@bind_weixin_id", SqlDbType.NVarChar,100),
					new SqlParameter("@Site_id", SqlDbType.Int,4),
					new SqlParameter("@UserNumber", SqlDbType.NVarChar,100),
					new SqlParameter("@weixin", SqlDbType.NVarChar,100),
					new SqlParameter("@alipay", SqlDbType.NVarChar,100),
					new SqlParameter("@aliwangwang", SqlDbType.NVarChar,100),
					new SqlParameter("@momo", SqlDbType.NVarChar,100),
					new SqlParameter("@job", SqlDbType.NVarChar,200),
					new SqlParameter("@IDNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@IDType", SqlDbType.NVarChar,100),
					new SqlParameter("@Money_Order", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Product", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Transport", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Bill", SqlDbType.Decimal,9),
					new SqlParameter("@Time_End", SqlDbType.DateTime),
					new SqlParameter("@IsCheckedEmail", SqlDbType.Int,4),
					new SqlParameter("@IsCheckedMobilePhone", SqlDbType.Int,4),
					new SqlParameter("@RandNum", SqlDbType.Int,4),
					new SqlParameter("@PickUp_id", SqlDbType.NVarChar,100),
					new SqlParameter("@PickUp_Date", SqlDbType.DateTime),
					new SqlParameter("@Device_id", SqlDbType.NVarChar,100),
					new SqlParameter("@Device_system", SqlDbType.NVarChar,50),
					new SqlParameter("@Money_fanxian", SqlDbType.Decimal,9),
					new SqlParameter("@DT_id", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.JYpwd;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.RealName;
			parameters[6].Value = model.lnum;
			parameters[7].Value = model.Sex;
			parameters[8].Value = model.NickName;
			parameters[9].Value = model.Birthday;
			parameters[10].Value = model.pwdwen;
			parameters[11].Value = model.pwdda;
			parameters[12].Value = model.Point;
			parameters[13].Value = model.Uavatar;
			parameters[14].Value = model.City;
			parameters[15].Value = model.Area_id;
			parameters[16].Value = model.Address;
			parameters[17].Value = model.MobilePhone;
			parameters[18].Value = model.Phone;
			parameters[19].Value = model.QQ;
			parameters[20].Value = model.Fax;
			parameters[21].Value = model.Postalcode;
			parameters[22].Value = model.Msn;
			parameters[23].Value = model.Yfmoney;
			parameters[24].Value = model.Money;
			parameters[25].Value = model.Money_xiaofei;
			parameters[26].Value = model.Count_Login;
			parameters[27].Value = model.IP_Last;
			parameters[28].Value = model.IP_This;
			parameters[29].Value = model.Time_This;
			parameters[30].Value = model.Time_Last;
			parameters[31].Value = model.Time_Reg;
			parameters[32].Value = model.Upass;
			parameters[33].Value = model.IsOpen;
			parameters[34].Value = model.Introduce;
			parameters[35].Value = model.UserLevel_id;
			parameters[36].Value = model.Time_lastorder;
			parameters[37].Value = model.User_Address_id;
			parameters[38].Value = model.Transport_Price_id;
			parameters[39].Value = model.Pay_id;
			parameters[40].Value = model.OnlinePay_id;
			parameters[41].Value = model.Count_Order;
			parameters[42].Value = model.Count_Order_OK;
			parameters[43].Value = model.Language;
			parameters[44].Value = model.CheckCode;
			parameters[45].Value = model.Currency_id;
			parameters[46].Value = model.Currency_Code;
			parameters[47].Value = model.Face;
			parameters[48].Value = model.bind_qq_id;
			parameters[49].Value = model.bind_qq_token;
			parameters[50].Value = model.bind_qq_nickname;
			parameters[51].Value = model.bind_weibo_id;
			parameters[52].Value = model.bind_weibo_token;
			parameters[53].Value = model.bind_weibo_nickname;
			parameters[54].Value = model.bind_taobao_id;
			parameters[55].Value = model.bind_taobao_token;
			parameters[56].Value = model.bind_taobao_nickname;
			parameters[57].Value = model.bind_facebook_id;
			parameters[58].Value = model.bind_facebook_token;
			parameters[59].Value = model.bind_facebook_nickname;
			parameters[60].Value = model.IsPlatformAccount;
			parameters[61].Value = model.IsAnonymous;
			parameters[62].Value = model.User_id_parent;
			parameters[63].Value = model.Pay_Password;
			parameters[64].Value = model.AgentMoney;
			parameters[65].Value = model.AgentMoney_history;
			parameters[66].Value = model.Count_sonuser;
			parameters[67].Value = model.CashAccount_Code;
			parameters[68].Value = model.CashAccount_Name;
			parameters[69].Value = model.CashAccount_Bank;
			parameters[70].Value = model.bind_weixin_nickname;
			parameters[71].Value = model.bind_weixin_token;
			parameters[72].Value = model.bind_weixin_id;
			parameters[73].Value = model.Site_id;
			parameters[74].Value = model.UserNumber;
			parameters[75].Value = model.weixin;
			parameters[76].Value = model.alipay;
			parameters[77].Value = model.aliwangwang;
			parameters[78].Value = model.momo;
			parameters[79].Value = model.job;
			parameters[80].Value = model.IDNumber;
			parameters[81].Value = model.IDType;
			parameters[82].Value = model.Money_Order;
			parameters[83].Value = model.Money_Product;
			parameters[84].Value = model.Money_Transport;
			parameters[85].Value = model.Money_Bill;
			parameters[86].Value = model.Time_End;
			parameters[87].Value = model.IsCheckedEmail;
			parameters[88].Value = model.IsCheckedMobilePhone;
			parameters[89].Value = model.RandNum;
			parameters[90].Value = model.PickUp_id;
			parameters[91].Value = model.PickUp_Date;
			parameters[92].Value = model.Device_id;
			parameters[93].Value = model.Device_system;
			parameters[94].Value = model.Money_fanxian;
			parameters[95].Value = model.DT_id;
			parameters[96].Value = model.IsDel;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User] ");
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
			strSql.Append("delete from [Lebi_User] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_User GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_User model=new Lebi_User();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.JYpwd=ds.Tables[0].Rows[0]["JYpwd"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				if(ds.Tables[0].Rows[0]["lnum"].ToString()!="")
				{
					model.lnum=int.Parse(ds.Tables[0].Rows[0]["lnum"].ToString());
				}
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				model.NickName=ds.Tables[0].Rows[0]["NickName"].ToString();
				if(ds.Tables[0].Rows[0]["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
				}
				model.pwdwen=ds.Tables[0].Rows[0]["pwdwen"].ToString();
				model.pwdda=ds.Tables[0].Rows[0]["pwdda"].ToString();
				if(ds.Tables[0].Rows[0]["Point"].ToString()!="")
				{
					model.Point=decimal.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
				}
				model.Uavatar=ds.Tables[0].Rows[0]["Uavatar"].ToString();
				model.City=ds.Tables[0].Rows[0]["City"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.Postalcode=ds.Tables[0].Rows[0]["Postalcode"].ToString();
				model.Msn=ds.Tables[0].Rows[0]["Msn"].ToString();
				if(ds.Tables[0].Rows[0]["Yfmoney"].ToString()!="")
				{
					model.Yfmoney=decimal.Parse(ds.Tables[0].Rows[0]["Yfmoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_xiaofei"].ToString()!="")
				{
					model.Money_xiaofei=decimal.Parse(ds.Tables[0].Rows[0]["Money_xiaofei"].ToString());
				}
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
				if(ds.Tables[0].Rows[0]["Upass"].ToString()!="")
				{
					model.Upass=int.Parse(ds.Tables[0].Rows[0]["Upass"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsOpen"].ToString()!="")
				{
					model.IsOpen=int.Parse(ds.Tables[0].Rows[0]["IsOpen"].ToString());
				}
				model.Introduce=ds.Tables[0].Rows[0]["Introduce"].ToString();
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_lastorder"].ToString()!="")
				{
					model.Time_lastorder=DateTime.Parse(ds.Tables[0].Rows[0]["Time_lastorder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_Address_id"].ToString()!="")
				{
					model.User_Address_id=int.Parse(ds.Tables[0].Rows[0]["User_Address_id"].ToString());
				}
				model.Transport_Price_id=ds.Tables[0].Rows[0]["Transport_Price_id"].ToString();
				if(ds.Tables[0].Rows[0]["Pay_id"].ToString()!="")
				{
					model.Pay_id=int.Parse(ds.Tables[0].Rows[0]["Pay_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString()!="")
				{
					model.OnlinePay_id=int.Parse(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Order"].ToString()!="")
				{
					model.Count_Order=int.Parse(ds.Tables[0].Rows[0]["Count_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Order_OK"].ToString()!="")
				{
					model.Count_Order_OK=int.Parse(ds.Tables[0].Rows[0]["Count_Order_OK"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.CheckCode=ds.Tables[0].Rows[0]["CheckCode"].ToString();
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Currency_Code=ds.Tables[0].Rows[0]["Currency_Code"].ToString();
				model.Face=ds.Tables[0].Rows[0]["Face"].ToString();
				model.bind_qq_id=ds.Tables[0].Rows[0]["bind_qq_id"].ToString();
				model.bind_qq_token=ds.Tables[0].Rows[0]["bind_qq_token"].ToString();
				model.bind_qq_nickname=ds.Tables[0].Rows[0]["bind_qq_nickname"].ToString();
				model.bind_weibo_id=ds.Tables[0].Rows[0]["bind_weibo_id"].ToString();
				model.bind_weibo_token=ds.Tables[0].Rows[0]["bind_weibo_token"].ToString();
				model.bind_weibo_nickname=ds.Tables[0].Rows[0]["bind_weibo_nickname"].ToString();
				model.bind_taobao_id=ds.Tables[0].Rows[0]["bind_taobao_id"].ToString();
				model.bind_taobao_token=ds.Tables[0].Rows[0]["bind_taobao_token"].ToString();
				model.bind_taobao_nickname=ds.Tables[0].Rows[0]["bind_taobao_nickname"].ToString();
				model.bind_facebook_id=ds.Tables[0].Rows[0]["bind_facebook_id"].ToString();
				model.bind_facebook_token=ds.Tables[0].Rows[0]["bind_facebook_token"].ToString();
				model.bind_facebook_nickname=ds.Tables[0].Rows[0]["bind_facebook_nickname"].ToString();
				if(ds.Tables[0].Rows[0]["IsPlatformAccount"].ToString()!="")
				{
					model.IsPlatformAccount=int.Parse(ds.Tables[0].Rows[0]["IsPlatformAccount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsAnonymous"].ToString()!="")
				{
					model.IsAnonymous=int.Parse(ds.Tables[0].Rows[0]["IsAnonymous"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_parent"].ToString()!="")
				{
					model.User_id_parent=int.Parse(ds.Tables[0].Rows[0]["User_id_parent"].ToString());
				}
				model.Pay_Password=ds.Tables[0].Rows[0]["Pay_Password"].ToString();
				if(ds.Tables[0].Rows[0]["AgentMoney"].ToString()!="")
				{
					model.AgentMoney=decimal.Parse(ds.Tables[0].Rows[0]["AgentMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AgentMoney_history"].ToString()!="")
				{
					model.AgentMoney_history=decimal.Parse(ds.Tables[0].Rows[0]["AgentMoney_history"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_sonuser"].ToString()!="")
				{
					model.Count_sonuser=int.Parse(ds.Tables[0].Rows[0]["Count_sonuser"].ToString());
				}
				model.CashAccount_Code=ds.Tables[0].Rows[0]["CashAccount_Code"].ToString();
				model.CashAccount_Name=ds.Tables[0].Rows[0]["CashAccount_Name"].ToString();
				model.CashAccount_Bank=ds.Tables[0].Rows[0]["CashAccount_Bank"].ToString();
				model.bind_weixin_nickname=ds.Tables[0].Rows[0]["bind_weixin_nickname"].ToString();
				model.bind_weixin_token=ds.Tables[0].Rows[0]["bind_weixin_token"].ToString();
				model.bind_weixin_id=ds.Tables[0].Rows[0]["bind_weixin_id"].ToString();
				if(ds.Tables[0].Rows[0]["Site_id"].ToString()!="")
				{
					model.Site_id=int.Parse(ds.Tables[0].Rows[0]["Site_id"].ToString());
				}
				model.UserNumber=ds.Tables[0].Rows[0]["UserNumber"].ToString();
				model.weixin=ds.Tables[0].Rows[0]["weixin"].ToString();
				model.alipay=ds.Tables[0].Rows[0]["alipay"].ToString();
				model.aliwangwang=ds.Tables[0].Rows[0]["aliwangwang"].ToString();
				model.momo=ds.Tables[0].Rows[0]["momo"].ToString();
				model.job=ds.Tables[0].Rows[0]["job"].ToString();
				model.IDNumber=ds.Tables[0].Rows[0]["IDNumber"].ToString();
				model.IDType=ds.Tables[0].Rows[0]["IDType"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Order"].ToString()!="")
				{
					model.Money_Order=decimal.Parse(ds.Tables[0].Rows[0]["Money_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Product"].ToString()!="")
				{
					model.Money_Product=decimal.Parse(ds.Tables[0].Rows[0]["Money_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Transport"].ToString()!="")
				{
					model.Money_Transport=decimal.Parse(ds.Tables[0].Rows[0]["Money_Transport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Bill"].ToString()!="")
				{
					model.Money_Bill=decimal.Parse(ds.Tables[0].Rows[0]["Money_Bill"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCheckedEmail"].ToString()!="")
				{
					model.IsCheckedEmail=int.Parse(ds.Tables[0].Rows[0]["IsCheckedEmail"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCheckedMobilePhone"].ToString()!="")
				{
					model.IsCheckedMobilePhone=int.Parse(ds.Tables[0].Rows[0]["IsCheckedMobilePhone"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RandNum"].ToString()!="")
				{
					model.RandNum=int.Parse(ds.Tables[0].Rows[0]["RandNum"].ToString());
				}
				model.PickUp_id=ds.Tables[0].Rows[0]["PickUp_id"].ToString();
				if(ds.Tables[0].Rows[0]["PickUp_Date"].ToString()!="")
				{
					model.PickUp_Date=DateTime.Parse(ds.Tables[0].Rows[0]["PickUp_Date"].ToString());
				}
				model.Device_id=ds.Tables[0].Rows[0]["Device_id"].ToString();
				model.Device_system=ds.Tables[0].Rows[0]["Device_system"].ToString();
				if(ds.Tables[0].Rows[0]["Money_fanxian"].ToString()!="")
				{
					model.Money_fanxian=decimal.Parse(ds.Tables[0].Rows[0]["Money_fanxian"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
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
		public Lebi_User GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_User model=new Lebi_User();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.JYpwd=ds.Tables[0].Rows[0]["JYpwd"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				if(ds.Tables[0].Rows[0]["lnum"].ToString()!="")
				{
					model.lnum=int.Parse(ds.Tables[0].Rows[0]["lnum"].ToString());
				}
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				model.NickName=ds.Tables[0].Rows[0]["NickName"].ToString();
				if(ds.Tables[0].Rows[0]["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
				}
				model.pwdwen=ds.Tables[0].Rows[0]["pwdwen"].ToString();
				model.pwdda=ds.Tables[0].Rows[0]["pwdda"].ToString();
				if(ds.Tables[0].Rows[0]["Point"].ToString()!="")
				{
					model.Point=decimal.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
				}
				model.Uavatar=ds.Tables[0].Rows[0]["Uavatar"].ToString();
				model.City=ds.Tables[0].Rows[0]["City"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.Postalcode=ds.Tables[0].Rows[0]["Postalcode"].ToString();
				model.Msn=ds.Tables[0].Rows[0]["Msn"].ToString();
				if(ds.Tables[0].Rows[0]["Yfmoney"].ToString()!="")
				{
					model.Yfmoney=decimal.Parse(ds.Tables[0].Rows[0]["Yfmoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_xiaofei"].ToString()!="")
				{
					model.Money_xiaofei=decimal.Parse(ds.Tables[0].Rows[0]["Money_xiaofei"].ToString());
				}
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
				if(ds.Tables[0].Rows[0]["Upass"].ToString()!="")
				{
					model.Upass=int.Parse(ds.Tables[0].Rows[0]["Upass"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsOpen"].ToString()!="")
				{
					model.IsOpen=int.Parse(ds.Tables[0].Rows[0]["IsOpen"].ToString());
				}
				model.Introduce=ds.Tables[0].Rows[0]["Introduce"].ToString();
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_lastorder"].ToString()!="")
				{
					model.Time_lastorder=DateTime.Parse(ds.Tables[0].Rows[0]["Time_lastorder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_Address_id"].ToString()!="")
				{
					model.User_Address_id=int.Parse(ds.Tables[0].Rows[0]["User_Address_id"].ToString());
				}
				model.Transport_Price_id=ds.Tables[0].Rows[0]["Transport_Price_id"].ToString();
				if(ds.Tables[0].Rows[0]["Pay_id"].ToString()!="")
				{
					model.Pay_id=int.Parse(ds.Tables[0].Rows[0]["Pay_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString()!="")
				{
					model.OnlinePay_id=int.Parse(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Order"].ToString()!="")
				{
					model.Count_Order=int.Parse(ds.Tables[0].Rows[0]["Count_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Order_OK"].ToString()!="")
				{
					model.Count_Order_OK=int.Parse(ds.Tables[0].Rows[0]["Count_Order_OK"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.CheckCode=ds.Tables[0].Rows[0]["CheckCode"].ToString();
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Currency_Code=ds.Tables[0].Rows[0]["Currency_Code"].ToString();
				model.Face=ds.Tables[0].Rows[0]["Face"].ToString();
				model.bind_qq_id=ds.Tables[0].Rows[0]["bind_qq_id"].ToString();
				model.bind_qq_token=ds.Tables[0].Rows[0]["bind_qq_token"].ToString();
				model.bind_qq_nickname=ds.Tables[0].Rows[0]["bind_qq_nickname"].ToString();
				model.bind_weibo_id=ds.Tables[0].Rows[0]["bind_weibo_id"].ToString();
				model.bind_weibo_token=ds.Tables[0].Rows[0]["bind_weibo_token"].ToString();
				model.bind_weibo_nickname=ds.Tables[0].Rows[0]["bind_weibo_nickname"].ToString();
				model.bind_taobao_id=ds.Tables[0].Rows[0]["bind_taobao_id"].ToString();
				model.bind_taobao_token=ds.Tables[0].Rows[0]["bind_taobao_token"].ToString();
				model.bind_taobao_nickname=ds.Tables[0].Rows[0]["bind_taobao_nickname"].ToString();
				model.bind_facebook_id=ds.Tables[0].Rows[0]["bind_facebook_id"].ToString();
				model.bind_facebook_token=ds.Tables[0].Rows[0]["bind_facebook_token"].ToString();
				model.bind_facebook_nickname=ds.Tables[0].Rows[0]["bind_facebook_nickname"].ToString();
				if(ds.Tables[0].Rows[0]["IsPlatformAccount"].ToString()!="")
				{
					model.IsPlatformAccount=int.Parse(ds.Tables[0].Rows[0]["IsPlatformAccount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsAnonymous"].ToString()!="")
				{
					model.IsAnonymous=int.Parse(ds.Tables[0].Rows[0]["IsAnonymous"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_parent"].ToString()!="")
				{
					model.User_id_parent=int.Parse(ds.Tables[0].Rows[0]["User_id_parent"].ToString());
				}
				model.Pay_Password=ds.Tables[0].Rows[0]["Pay_Password"].ToString();
				if(ds.Tables[0].Rows[0]["AgentMoney"].ToString()!="")
				{
					model.AgentMoney=decimal.Parse(ds.Tables[0].Rows[0]["AgentMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AgentMoney_history"].ToString()!="")
				{
					model.AgentMoney_history=decimal.Parse(ds.Tables[0].Rows[0]["AgentMoney_history"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_sonuser"].ToString()!="")
				{
					model.Count_sonuser=int.Parse(ds.Tables[0].Rows[0]["Count_sonuser"].ToString());
				}
				model.CashAccount_Code=ds.Tables[0].Rows[0]["CashAccount_Code"].ToString();
				model.CashAccount_Name=ds.Tables[0].Rows[0]["CashAccount_Name"].ToString();
				model.CashAccount_Bank=ds.Tables[0].Rows[0]["CashAccount_Bank"].ToString();
				model.bind_weixin_nickname=ds.Tables[0].Rows[0]["bind_weixin_nickname"].ToString();
				model.bind_weixin_token=ds.Tables[0].Rows[0]["bind_weixin_token"].ToString();
				model.bind_weixin_id=ds.Tables[0].Rows[0]["bind_weixin_id"].ToString();
				if(ds.Tables[0].Rows[0]["Site_id"].ToString()!="")
				{
					model.Site_id=int.Parse(ds.Tables[0].Rows[0]["Site_id"].ToString());
				}
				model.UserNumber=ds.Tables[0].Rows[0]["UserNumber"].ToString();
				model.weixin=ds.Tables[0].Rows[0]["weixin"].ToString();
				model.alipay=ds.Tables[0].Rows[0]["alipay"].ToString();
				model.aliwangwang=ds.Tables[0].Rows[0]["aliwangwang"].ToString();
				model.momo=ds.Tables[0].Rows[0]["momo"].ToString();
				model.job=ds.Tables[0].Rows[0]["job"].ToString();
				model.IDNumber=ds.Tables[0].Rows[0]["IDNumber"].ToString();
				model.IDType=ds.Tables[0].Rows[0]["IDType"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Order"].ToString()!="")
				{
					model.Money_Order=decimal.Parse(ds.Tables[0].Rows[0]["Money_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Product"].ToString()!="")
				{
					model.Money_Product=decimal.Parse(ds.Tables[0].Rows[0]["Money_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Transport"].ToString()!="")
				{
					model.Money_Transport=decimal.Parse(ds.Tables[0].Rows[0]["Money_Transport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Bill"].ToString()!="")
				{
					model.Money_Bill=decimal.Parse(ds.Tables[0].Rows[0]["Money_Bill"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCheckedEmail"].ToString()!="")
				{
					model.IsCheckedEmail=int.Parse(ds.Tables[0].Rows[0]["IsCheckedEmail"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCheckedMobilePhone"].ToString()!="")
				{
					model.IsCheckedMobilePhone=int.Parse(ds.Tables[0].Rows[0]["IsCheckedMobilePhone"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RandNum"].ToString()!="")
				{
					model.RandNum=int.Parse(ds.Tables[0].Rows[0]["RandNum"].ToString());
				}
				model.PickUp_id=ds.Tables[0].Rows[0]["PickUp_id"].ToString();
				if(ds.Tables[0].Rows[0]["PickUp_Date"].ToString()!="")
				{
					model.PickUp_Date=DateTime.Parse(ds.Tables[0].Rows[0]["PickUp_Date"].ToString());
				}
				model.Device_id=ds.Tables[0].Rows[0]["Device_id"].ToString();
				model.Device_system=ds.Tables[0].Rows[0]["Device_system"].ToString();
				if(ds.Tables[0].Rows[0]["Money_fanxian"].ToString()!="")
				{
					model.Money_fanxian=decimal.Parse(ds.Tables[0].Rows[0]["Money_fanxian"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
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
		public Lebi_User GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_User] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_User model=new Lebi_User();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.JYpwd=ds.Tables[0].Rows[0]["JYpwd"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				if(ds.Tables[0].Rows[0]["lnum"].ToString()!="")
				{
					model.lnum=int.Parse(ds.Tables[0].Rows[0]["lnum"].ToString());
				}
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				model.NickName=ds.Tables[0].Rows[0]["NickName"].ToString();
				if(ds.Tables[0].Rows[0]["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
				}
				model.pwdwen=ds.Tables[0].Rows[0]["pwdwen"].ToString();
				model.pwdda=ds.Tables[0].Rows[0]["pwdda"].ToString();
				if(ds.Tables[0].Rows[0]["Point"].ToString()!="")
				{
					model.Point=decimal.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
				}
				model.Uavatar=ds.Tables[0].Rows[0]["Uavatar"].ToString();
				model.City=ds.Tables[0].Rows[0]["City"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.Postalcode=ds.Tables[0].Rows[0]["Postalcode"].ToString();
				model.Msn=ds.Tables[0].Rows[0]["Msn"].ToString();
				if(ds.Tables[0].Rows[0]["Yfmoney"].ToString()!="")
				{
					model.Yfmoney=decimal.Parse(ds.Tables[0].Rows[0]["Yfmoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_xiaofei"].ToString()!="")
				{
					model.Money_xiaofei=decimal.Parse(ds.Tables[0].Rows[0]["Money_xiaofei"].ToString());
				}
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
				if(ds.Tables[0].Rows[0]["Upass"].ToString()!="")
				{
					model.Upass=int.Parse(ds.Tables[0].Rows[0]["Upass"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsOpen"].ToString()!="")
				{
					model.IsOpen=int.Parse(ds.Tables[0].Rows[0]["IsOpen"].ToString());
				}
				model.Introduce=ds.Tables[0].Rows[0]["Introduce"].ToString();
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_lastorder"].ToString()!="")
				{
					model.Time_lastorder=DateTime.Parse(ds.Tables[0].Rows[0]["Time_lastorder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_Address_id"].ToString()!="")
				{
					model.User_Address_id=int.Parse(ds.Tables[0].Rows[0]["User_Address_id"].ToString());
				}
				model.Transport_Price_id=ds.Tables[0].Rows[0]["Transport_Price_id"].ToString();
				if(ds.Tables[0].Rows[0]["Pay_id"].ToString()!="")
				{
					model.Pay_id=int.Parse(ds.Tables[0].Rows[0]["Pay_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString()!="")
				{
					model.OnlinePay_id=int.Parse(ds.Tables[0].Rows[0]["OnlinePay_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Order"].ToString()!="")
				{
					model.Count_Order=int.Parse(ds.Tables[0].Rows[0]["Count_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Order_OK"].ToString()!="")
				{
					model.Count_Order_OK=int.Parse(ds.Tables[0].Rows[0]["Count_Order_OK"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.CheckCode=ds.Tables[0].Rows[0]["CheckCode"].ToString();
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Currency_Code=ds.Tables[0].Rows[0]["Currency_Code"].ToString();
				model.Face=ds.Tables[0].Rows[0]["Face"].ToString();
				model.bind_qq_id=ds.Tables[0].Rows[0]["bind_qq_id"].ToString();
				model.bind_qq_token=ds.Tables[0].Rows[0]["bind_qq_token"].ToString();
				model.bind_qq_nickname=ds.Tables[0].Rows[0]["bind_qq_nickname"].ToString();
				model.bind_weibo_id=ds.Tables[0].Rows[0]["bind_weibo_id"].ToString();
				model.bind_weibo_token=ds.Tables[0].Rows[0]["bind_weibo_token"].ToString();
				model.bind_weibo_nickname=ds.Tables[0].Rows[0]["bind_weibo_nickname"].ToString();
				model.bind_taobao_id=ds.Tables[0].Rows[0]["bind_taobao_id"].ToString();
				model.bind_taobao_token=ds.Tables[0].Rows[0]["bind_taobao_token"].ToString();
				model.bind_taobao_nickname=ds.Tables[0].Rows[0]["bind_taobao_nickname"].ToString();
				model.bind_facebook_id=ds.Tables[0].Rows[0]["bind_facebook_id"].ToString();
				model.bind_facebook_token=ds.Tables[0].Rows[0]["bind_facebook_token"].ToString();
				model.bind_facebook_nickname=ds.Tables[0].Rows[0]["bind_facebook_nickname"].ToString();
				if(ds.Tables[0].Rows[0]["IsPlatformAccount"].ToString()!="")
				{
					model.IsPlatformAccount=int.Parse(ds.Tables[0].Rows[0]["IsPlatformAccount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsAnonymous"].ToString()!="")
				{
					model.IsAnonymous=int.Parse(ds.Tables[0].Rows[0]["IsAnonymous"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_parent"].ToString()!="")
				{
					model.User_id_parent=int.Parse(ds.Tables[0].Rows[0]["User_id_parent"].ToString());
				}
				model.Pay_Password=ds.Tables[0].Rows[0]["Pay_Password"].ToString();
				if(ds.Tables[0].Rows[0]["AgentMoney"].ToString()!="")
				{
					model.AgentMoney=decimal.Parse(ds.Tables[0].Rows[0]["AgentMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AgentMoney_history"].ToString()!="")
				{
					model.AgentMoney_history=decimal.Parse(ds.Tables[0].Rows[0]["AgentMoney_history"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_sonuser"].ToString()!="")
				{
					model.Count_sonuser=int.Parse(ds.Tables[0].Rows[0]["Count_sonuser"].ToString());
				}
				model.CashAccount_Code=ds.Tables[0].Rows[0]["CashAccount_Code"].ToString();
				model.CashAccount_Name=ds.Tables[0].Rows[0]["CashAccount_Name"].ToString();
				model.CashAccount_Bank=ds.Tables[0].Rows[0]["CashAccount_Bank"].ToString();
				model.bind_weixin_nickname=ds.Tables[0].Rows[0]["bind_weixin_nickname"].ToString();
				model.bind_weixin_token=ds.Tables[0].Rows[0]["bind_weixin_token"].ToString();
				model.bind_weixin_id=ds.Tables[0].Rows[0]["bind_weixin_id"].ToString();
				if(ds.Tables[0].Rows[0]["Site_id"].ToString()!="")
				{
					model.Site_id=int.Parse(ds.Tables[0].Rows[0]["Site_id"].ToString());
				}
				model.UserNumber=ds.Tables[0].Rows[0]["UserNumber"].ToString();
				model.weixin=ds.Tables[0].Rows[0]["weixin"].ToString();
				model.alipay=ds.Tables[0].Rows[0]["alipay"].ToString();
				model.aliwangwang=ds.Tables[0].Rows[0]["aliwangwang"].ToString();
				model.momo=ds.Tables[0].Rows[0]["momo"].ToString();
				model.job=ds.Tables[0].Rows[0]["job"].ToString();
				model.IDNumber=ds.Tables[0].Rows[0]["IDNumber"].ToString();
				model.IDType=ds.Tables[0].Rows[0]["IDType"].ToString();
				if(ds.Tables[0].Rows[0]["Money_Order"].ToString()!="")
				{
					model.Money_Order=decimal.Parse(ds.Tables[0].Rows[0]["Money_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Product"].ToString()!="")
				{
					model.Money_Product=decimal.Parse(ds.Tables[0].Rows[0]["Money_Product"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Transport"].ToString()!="")
				{
					model.Money_Transport=decimal.Parse(ds.Tables[0].Rows[0]["Money_Transport"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Bill"].ToString()!="")
				{
					model.Money_Bill=decimal.Parse(ds.Tables[0].Rows[0]["Money_Bill"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCheckedEmail"].ToString()!="")
				{
					model.IsCheckedEmail=int.Parse(ds.Tables[0].Rows[0]["IsCheckedEmail"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCheckedMobilePhone"].ToString()!="")
				{
					model.IsCheckedMobilePhone=int.Parse(ds.Tables[0].Rows[0]["IsCheckedMobilePhone"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RandNum"].ToString()!="")
				{
					model.RandNum=int.Parse(ds.Tables[0].Rows[0]["RandNum"].ToString());
				}
				model.PickUp_id=ds.Tables[0].Rows[0]["PickUp_id"].ToString();
				if(ds.Tables[0].Rows[0]["PickUp_Date"].ToString()!="")
				{
					model.PickUp_Date=DateTime.Parse(ds.Tables[0].Rows[0]["PickUp_Date"].ToString());
				}
				model.Device_id=ds.Tables[0].Rows[0]["Device_id"].ToString();
				model.Device_system=ds.Tables[0].Rows[0]["Device_system"].ToString();
				if(ds.Tables[0].Rows[0]["Money_fanxian"].ToString()!="")
				{
					model.Money_fanxian=decimal.Parse(ds.Tables[0].Rows[0]["Money_fanxian"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_id"].ToString()!="")
				{
					model.DT_id=int.Parse(ds.Tables[0].Rows[0]["DT_id"].ToString());
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
		public List<Lebi_User> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_User]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_User> list = new List<Lebi_User>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_User> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_User]";
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
			List<Lebi_User> list = new List<Lebi_User>();
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
		public List<Lebi_User> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_User] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_User> list = new List<Lebi_User>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_User> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_User]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_User> list = new List<Lebi_User>();
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
		public Lebi_User BindForm(Lebi_User model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestString("Password");
			if (HttpContext.Current.Request["JYpwd"] != null)
				model.JYpwd=Shop.Tools.RequestTool.RequestString("JYpwd");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestString("RealName");
			if (HttpContext.Current.Request["lnum"] != null)
				model.lnum=Shop.Tools.RequestTool.RequestInt("lnum",0);
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestString("Sex");
			if (HttpContext.Current.Request["NickName"] != null)
				model.NickName=Shop.Tools.RequestTool.RequestString("NickName");
			if (HttpContext.Current.Request["Birthday"] != null)
				model.Birthday=Shop.Tools.RequestTool.RequestTime("Birthday", System.DateTime.Now);
			if (HttpContext.Current.Request["pwdwen"] != null)
				model.pwdwen=Shop.Tools.RequestTool.RequestString("pwdwen");
			if (HttpContext.Current.Request["pwdda"] != null)
				model.pwdda=Shop.Tools.RequestTool.RequestString("pwdda");
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["Uavatar"] != null)
				model.Uavatar=Shop.Tools.RequestTool.RequestString("Uavatar");
			if (HttpContext.Current.Request["City"] != null)
				model.City=Shop.Tools.RequestTool.RequestString("City");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestString("QQ");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestString("Fax");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestString("Postalcode");
			if (HttpContext.Current.Request["Msn"] != null)
				model.Msn=Shop.Tools.RequestTool.RequestString("Msn");
			if (HttpContext.Current.Request["Yfmoney"] != null)
				model.Yfmoney=Shop.Tools.RequestTool.RequestDecimal("Yfmoney",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Money_xiaofei"] != null)
				model.Money_xiaofei=Shop.Tools.RequestTool.RequestDecimal("Money_xiaofei",0);
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
			if (HttpContext.Current.Request["Upass"] != null)
				model.Upass=Shop.Tools.RequestTool.RequestInt("Upass",0);
			if (HttpContext.Current.Request["IsOpen"] != null)
				model.IsOpen=Shop.Tools.RequestTool.RequestInt("IsOpen",0);
			if (HttpContext.Current.Request["Introduce"] != null)
				model.Introduce=Shop.Tools.RequestTool.RequestString("Introduce");
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
			if (HttpContext.Current.Request["Time_lastorder"] != null)
				model.Time_lastorder=Shop.Tools.RequestTool.RequestTime("Time_lastorder", System.DateTime.Now);
			if (HttpContext.Current.Request["User_Address_id"] != null)
				model.User_Address_id=Shop.Tools.RequestTool.RequestInt("User_Address_id",0);
			if (HttpContext.Current.Request["Transport_Price_id"] != null)
				model.Transport_Price_id=Shop.Tools.RequestTool.RequestString("Transport_Price_id");
			if (HttpContext.Current.Request["Pay_id"] != null)
				model.Pay_id=Shop.Tools.RequestTool.RequestInt("Pay_id",0);
			if (HttpContext.Current.Request["OnlinePay_id"] != null)
				model.OnlinePay_id=Shop.Tools.RequestTool.RequestInt("OnlinePay_id",0);
			if (HttpContext.Current.Request["Count_Order"] != null)
				model.Count_Order=Shop.Tools.RequestTool.RequestInt("Count_Order",0);
			if (HttpContext.Current.Request["Count_Order_OK"] != null)
				model.Count_Order_OK=Shop.Tools.RequestTool.RequestInt("Count_Order_OK",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["CheckCode"] != null)
				model.CheckCode=Shop.Tools.RequestTool.RequestString("CheckCode");
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestString("Currency_Code");
			if (HttpContext.Current.Request["Face"] != null)
				model.Face=Shop.Tools.RequestTool.RequestString("Face");
			if (HttpContext.Current.Request["bind_qq_id"] != null)
				model.bind_qq_id=Shop.Tools.RequestTool.RequestString("bind_qq_id");
			if (HttpContext.Current.Request["bind_qq_token"] != null)
				model.bind_qq_token=Shop.Tools.RequestTool.RequestString("bind_qq_token");
			if (HttpContext.Current.Request["bind_qq_nickname"] != null)
				model.bind_qq_nickname=Shop.Tools.RequestTool.RequestString("bind_qq_nickname");
			if (HttpContext.Current.Request["bind_weibo_id"] != null)
				model.bind_weibo_id=Shop.Tools.RequestTool.RequestString("bind_weibo_id");
			if (HttpContext.Current.Request["bind_weibo_token"] != null)
				model.bind_weibo_token=Shop.Tools.RequestTool.RequestString("bind_weibo_token");
			if (HttpContext.Current.Request["bind_weibo_nickname"] != null)
				model.bind_weibo_nickname=Shop.Tools.RequestTool.RequestString("bind_weibo_nickname");
			if (HttpContext.Current.Request["bind_taobao_id"] != null)
				model.bind_taobao_id=Shop.Tools.RequestTool.RequestString("bind_taobao_id");
			if (HttpContext.Current.Request["bind_taobao_token"] != null)
				model.bind_taobao_token=Shop.Tools.RequestTool.RequestString("bind_taobao_token");
			if (HttpContext.Current.Request["bind_taobao_nickname"] != null)
				model.bind_taobao_nickname=Shop.Tools.RequestTool.RequestString("bind_taobao_nickname");
			if (HttpContext.Current.Request["bind_facebook_id"] != null)
				model.bind_facebook_id=Shop.Tools.RequestTool.RequestString("bind_facebook_id");
			if (HttpContext.Current.Request["bind_facebook_token"] != null)
				model.bind_facebook_token=Shop.Tools.RequestTool.RequestString("bind_facebook_token");
			if (HttpContext.Current.Request["bind_facebook_nickname"] != null)
				model.bind_facebook_nickname=Shop.Tools.RequestTool.RequestString("bind_facebook_nickname");
			if (HttpContext.Current.Request["IsPlatformAccount"] != null)
				model.IsPlatformAccount=Shop.Tools.RequestTool.RequestInt("IsPlatformAccount",0);
			if (HttpContext.Current.Request["IsAnonymous"] != null)
				model.IsAnonymous=Shop.Tools.RequestTool.RequestInt("IsAnonymous",0);
			if (HttpContext.Current.Request["User_id_parent"] != null)
				model.User_id_parent=Shop.Tools.RequestTool.RequestInt("User_id_parent",0);
			if (HttpContext.Current.Request["Pay_Password"] != null)
				model.Pay_Password=Shop.Tools.RequestTool.RequestString("Pay_Password");
			if (HttpContext.Current.Request["AgentMoney"] != null)
				model.AgentMoney=Shop.Tools.RequestTool.RequestDecimal("AgentMoney",0);
			if (HttpContext.Current.Request["AgentMoney_history"] != null)
				model.AgentMoney_history=Shop.Tools.RequestTool.RequestDecimal("AgentMoney_history",0);
			if (HttpContext.Current.Request["Count_sonuser"] != null)
				model.Count_sonuser=Shop.Tools.RequestTool.RequestInt("Count_sonuser",0);
			if (HttpContext.Current.Request["CashAccount_Code"] != null)
				model.CashAccount_Code=Shop.Tools.RequestTool.RequestString("CashAccount_Code");
			if (HttpContext.Current.Request["CashAccount_Name"] != null)
				model.CashAccount_Name=Shop.Tools.RequestTool.RequestString("CashAccount_Name");
			if (HttpContext.Current.Request["CashAccount_Bank"] != null)
				model.CashAccount_Bank=Shop.Tools.RequestTool.RequestString("CashAccount_Bank");
			if (HttpContext.Current.Request["bind_weixin_nickname"] != null)
				model.bind_weixin_nickname=Shop.Tools.RequestTool.RequestString("bind_weixin_nickname");
			if (HttpContext.Current.Request["bind_weixin_token"] != null)
				model.bind_weixin_token=Shop.Tools.RequestTool.RequestString("bind_weixin_token");
			if (HttpContext.Current.Request["bind_weixin_id"] != null)
				model.bind_weixin_id=Shop.Tools.RequestTool.RequestString("bind_weixin_id");
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["UserNumber"] != null)
				model.UserNumber=Shop.Tools.RequestTool.RequestString("UserNumber");
			if (HttpContext.Current.Request["weixin"] != null)
				model.weixin=Shop.Tools.RequestTool.RequestString("weixin");
			if (HttpContext.Current.Request["alipay"] != null)
				model.alipay=Shop.Tools.RequestTool.RequestString("alipay");
			if (HttpContext.Current.Request["aliwangwang"] != null)
				model.aliwangwang=Shop.Tools.RequestTool.RequestString("aliwangwang");
			if (HttpContext.Current.Request["momo"] != null)
				model.momo=Shop.Tools.RequestTool.RequestString("momo");
			if (HttpContext.Current.Request["job"] != null)
				model.job=Shop.Tools.RequestTool.RequestString("job");
			if (HttpContext.Current.Request["IDNumber"] != null)
				model.IDNumber=Shop.Tools.RequestTool.RequestString("IDNumber");
			if (HttpContext.Current.Request["IDType"] != null)
				model.IDType=Shop.Tools.RequestTool.RequestString("IDType");
			if (HttpContext.Current.Request["Money_Order"] != null)
				model.Money_Order=Shop.Tools.RequestTool.RequestDecimal("Money_Order",0);
			if (HttpContext.Current.Request["Money_Product"] != null)
				model.Money_Product=Shop.Tools.RequestTool.RequestDecimal("Money_Product",0);
			if (HttpContext.Current.Request["Money_Transport"] != null)
				model.Money_Transport=Shop.Tools.RequestTool.RequestDecimal("Money_Transport",0);
			if (HttpContext.Current.Request["Money_Bill"] != null)
				model.Money_Bill=Shop.Tools.RequestTool.RequestDecimal("Money_Bill",0);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["IsCheckedEmail"] != null)
				model.IsCheckedEmail=Shop.Tools.RequestTool.RequestInt("IsCheckedEmail",0);
			if (HttpContext.Current.Request["IsCheckedMobilePhone"] != null)
				model.IsCheckedMobilePhone=Shop.Tools.RequestTool.RequestInt("IsCheckedMobilePhone",0);
			if (HttpContext.Current.Request["RandNum"] != null)
				model.RandNum=Shop.Tools.RequestTool.RequestInt("RandNum",0);
			if (HttpContext.Current.Request["PickUp_id"] != null)
				model.PickUp_id=Shop.Tools.RequestTool.RequestString("PickUp_id");
			if (HttpContext.Current.Request["PickUp_Date"] != null)
				model.PickUp_Date=Shop.Tools.RequestTool.RequestTime("PickUp_Date", System.DateTime.Now);
			if (HttpContext.Current.Request["Device_id"] != null)
				model.Device_id=Shop.Tools.RequestTool.RequestString("Device_id");
			if (HttpContext.Current.Request["Device_system"] != null)
				model.Device_system=Shop.Tools.RequestTool.RequestString("Device_system");
			if (HttpContext.Current.Request["Money_fanxian"] != null)
				model.Money_fanxian=Shop.Tools.RequestTool.RequestDecimal("Money_fanxian",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_User SafeBindForm(Lebi_User model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestSafeString("Password");
			if (HttpContext.Current.Request["JYpwd"] != null)
				model.JYpwd=Shop.Tools.RequestTool.RequestSafeString("JYpwd");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestSafeString("RealName");
			if (HttpContext.Current.Request["lnum"] != null)
				model.lnum=Shop.Tools.RequestTool.RequestInt("lnum",0);
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestSafeString("Sex");
			if (HttpContext.Current.Request["NickName"] != null)
				model.NickName=Shop.Tools.RequestTool.RequestSafeString("NickName");
			if (HttpContext.Current.Request["Birthday"] != null)
				model.Birthday=Shop.Tools.RequestTool.RequestTime("Birthday", System.DateTime.Now);
			if (HttpContext.Current.Request["pwdwen"] != null)
				model.pwdwen=Shop.Tools.RequestTool.RequestSafeString("pwdwen");
			if (HttpContext.Current.Request["pwdda"] != null)
				model.pwdda=Shop.Tools.RequestTool.RequestSafeString("pwdda");
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["Uavatar"] != null)
				model.Uavatar=Shop.Tools.RequestTool.RequestSafeString("Uavatar");
			if (HttpContext.Current.Request["City"] != null)
				model.City=Shop.Tools.RequestTool.RequestSafeString("City");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestSafeString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestSafeString("QQ");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestSafeString("Fax");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestSafeString("Postalcode");
			if (HttpContext.Current.Request["Msn"] != null)
				model.Msn=Shop.Tools.RequestTool.RequestSafeString("Msn");
			if (HttpContext.Current.Request["Yfmoney"] != null)
				model.Yfmoney=Shop.Tools.RequestTool.RequestDecimal("Yfmoney",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Money_xiaofei"] != null)
				model.Money_xiaofei=Shop.Tools.RequestTool.RequestDecimal("Money_xiaofei",0);
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
			if (HttpContext.Current.Request["Upass"] != null)
				model.Upass=Shop.Tools.RequestTool.RequestInt("Upass",0);
			if (HttpContext.Current.Request["IsOpen"] != null)
				model.IsOpen=Shop.Tools.RequestTool.RequestInt("IsOpen",0);
			if (HttpContext.Current.Request["Introduce"] != null)
				model.Introduce=Shop.Tools.RequestTool.RequestSafeString("Introduce");
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
			if (HttpContext.Current.Request["Time_lastorder"] != null)
				model.Time_lastorder=Shop.Tools.RequestTool.RequestTime("Time_lastorder", System.DateTime.Now);
			if (HttpContext.Current.Request["User_Address_id"] != null)
				model.User_Address_id=Shop.Tools.RequestTool.RequestInt("User_Address_id",0);
			if (HttpContext.Current.Request["Transport_Price_id"] != null)
				model.Transport_Price_id=Shop.Tools.RequestTool.RequestSafeString("Transport_Price_id");
			if (HttpContext.Current.Request["Pay_id"] != null)
				model.Pay_id=Shop.Tools.RequestTool.RequestInt("Pay_id",0);
			if (HttpContext.Current.Request["OnlinePay_id"] != null)
				model.OnlinePay_id=Shop.Tools.RequestTool.RequestInt("OnlinePay_id",0);
			if (HttpContext.Current.Request["Count_Order"] != null)
				model.Count_Order=Shop.Tools.RequestTool.RequestInt("Count_Order",0);
			if (HttpContext.Current.Request["Count_Order_OK"] != null)
				model.Count_Order_OK=Shop.Tools.RequestTool.RequestInt("Count_Order_OK",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["CheckCode"] != null)
				model.CheckCode=Shop.Tools.RequestTool.RequestSafeString("CheckCode");
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestSafeString("Currency_Code");
			if (HttpContext.Current.Request["Face"] != null)
				model.Face=Shop.Tools.RequestTool.RequestSafeString("Face");
			if (HttpContext.Current.Request["bind_qq_id"] != null)
				model.bind_qq_id=Shop.Tools.RequestTool.RequestSafeString("bind_qq_id");
			if (HttpContext.Current.Request["bind_qq_token"] != null)
				model.bind_qq_token=Shop.Tools.RequestTool.RequestSafeString("bind_qq_token");
			if (HttpContext.Current.Request["bind_qq_nickname"] != null)
				model.bind_qq_nickname=Shop.Tools.RequestTool.RequestSafeString("bind_qq_nickname");
			if (HttpContext.Current.Request["bind_weibo_id"] != null)
				model.bind_weibo_id=Shop.Tools.RequestTool.RequestSafeString("bind_weibo_id");
			if (HttpContext.Current.Request["bind_weibo_token"] != null)
				model.bind_weibo_token=Shop.Tools.RequestTool.RequestSafeString("bind_weibo_token");
			if (HttpContext.Current.Request["bind_weibo_nickname"] != null)
				model.bind_weibo_nickname=Shop.Tools.RequestTool.RequestSafeString("bind_weibo_nickname");
			if (HttpContext.Current.Request["bind_taobao_id"] != null)
				model.bind_taobao_id=Shop.Tools.RequestTool.RequestSafeString("bind_taobao_id");
			if (HttpContext.Current.Request["bind_taobao_token"] != null)
				model.bind_taobao_token=Shop.Tools.RequestTool.RequestSafeString("bind_taobao_token");
			if (HttpContext.Current.Request["bind_taobao_nickname"] != null)
				model.bind_taobao_nickname=Shop.Tools.RequestTool.RequestSafeString("bind_taobao_nickname");
			if (HttpContext.Current.Request["bind_facebook_id"] != null)
				model.bind_facebook_id=Shop.Tools.RequestTool.RequestSafeString("bind_facebook_id");
			if (HttpContext.Current.Request["bind_facebook_token"] != null)
				model.bind_facebook_token=Shop.Tools.RequestTool.RequestSafeString("bind_facebook_token");
			if (HttpContext.Current.Request["bind_facebook_nickname"] != null)
				model.bind_facebook_nickname=Shop.Tools.RequestTool.RequestSafeString("bind_facebook_nickname");
			if (HttpContext.Current.Request["IsPlatformAccount"] != null)
				model.IsPlatformAccount=Shop.Tools.RequestTool.RequestInt("IsPlatformAccount",0);
			if (HttpContext.Current.Request["IsAnonymous"] != null)
				model.IsAnonymous=Shop.Tools.RequestTool.RequestInt("IsAnonymous",0);
			if (HttpContext.Current.Request["User_id_parent"] != null)
				model.User_id_parent=Shop.Tools.RequestTool.RequestInt("User_id_parent",0);
			if (HttpContext.Current.Request["Pay_Password"] != null)
				model.Pay_Password=Shop.Tools.RequestTool.RequestSafeString("Pay_Password");
			if (HttpContext.Current.Request["AgentMoney"] != null)
				model.AgentMoney=Shop.Tools.RequestTool.RequestDecimal("AgentMoney",0);
			if (HttpContext.Current.Request["AgentMoney_history"] != null)
				model.AgentMoney_history=Shop.Tools.RequestTool.RequestDecimal("AgentMoney_history",0);
			if (HttpContext.Current.Request["Count_sonuser"] != null)
				model.Count_sonuser=Shop.Tools.RequestTool.RequestInt("Count_sonuser",0);
			if (HttpContext.Current.Request["CashAccount_Code"] != null)
				model.CashAccount_Code=Shop.Tools.RequestTool.RequestSafeString("CashAccount_Code");
			if (HttpContext.Current.Request["CashAccount_Name"] != null)
				model.CashAccount_Name=Shop.Tools.RequestTool.RequestSafeString("CashAccount_Name");
			if (HttpContext.Current.Request["CashAccount_Bank"] != null)
				model.CashAccount_Bank=Shop.Tools.RequestTool.RequestSafeString("CashAccount_Bank");
			if (HttpContext.Current.Request["bind_weixin_nickname"] != null)
				model.bind_weixin_nickname=Shop.Tools.RequestTool.RequestSafeString("bind_weixin_nickname");
			if (HttpContext.Current.Request["bind_weixin_token"] != null)
				model.bind_weixin_token=Shop.Tools.RequestTool.RequestSafeString("bind_weixin_token");
			if (HttpContext.Current.Request["bind_weixin_id"] != null)
				model.bind_weixin_id=Shop.Tools.RequestTool.RequestSafeString("bind_weixin_id");
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["UserNumber"] != null)
				model.UserNumber=Shop.Tools.RequestTool.RequestSafeString("UserNumber");
			if (HttpContext.Current.Request["weixin"] != null)
				model.weixin=Shop.Tools.RequestTool.RequestSafeString("weixin");
			if (HttpContext.Current.Request["alipay"] != null)
				model.alipay=Shop.Tools.RequestTool.RequestSafeString("alipay");
			if (HttpContext.Current.Request["aliwangwang"] != null)
				model.aliwangwang=Shop.Tools.RequestTool.RequestSafeString("aliwangwang");
			if (HttpContext.Current.Request["momo"] != null)
				model.momo=Shop.Tools.RequestTool.RequestSafeString("momo");
			if (HttpContext.Current.Request["job"] != null)
				model.job=Shop.Tools.RequestTool.RequestSafeString("job");
			if (HttpContext.Current.Request["IDNumber"] != null)
				model.IDNumber=Shop.Tools.RequestTool.RequestSafeString("IDNumber");
			if (HttpContext.Current.Request["IDType"] != null)
				model.IDType=Shop.Tools.RequestTool.RequestSafeString("IDType");
			if (HttpContext.Current.Request["Money_Order"] != null)
				model.Money_Order=Shop.Tools.RequestTool.RequestDecimal("Money_Order",0);
			if (HttpContext.Current.Request["Money_Product"] != null)
				model.Money_Product=Shop.Tools.RequestTool.RequestDecimal("Money_Product",0);
			if (HttpContext.Current.Request["Money_Transport"] != null)
				model.Money_Transport=Shop.Tools.RequestTool.RequestDecimal("Money_Transport",0);
			if (HttpContext.Current.Request["Money_Bill"] != null)
				model.Money_Bill=Shop.Tools.RequestTool.RequestDecimal("Money_Bill",0);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["IsCheckedEmail"] != null)
				model.IsCheckedEmail=Shop.Tools.RequestTool.RequestInt("IsCheckedEmail",0);
			if (HttpContext.Current.Request["IsCheckedMobilePhone"] != null)
				model.IsCheckedMobilePhone=Shop.Tools.RequestTool.RequestInt("IsCheckedMobilePhone",0);
			if (HttpContext.Current.Request["RandNum"] != null)
				model.RandNum=Shop.Tools.RequestTool.RequestInt("RandNum",0);
			if (HttpContext.Current.Request["PickUp_id"] != null)
				model.PickUp_id=Shop.Tools.RequestTool.RequestSafeString("PickUp_id");
			if (HttpContext.Current.Request["PickUp_Date"] != null)
				model.PickUp_Date=Shop.Tools.RequestTool.RequestTime("PickUp_Date", System.DateTime.Now);
			if (HttpContext.Current.Request["Device_id"] != null)
				model.Device_id=Shop.Tools.RequestTool.RequestSafeString("Device_id");
			if (HttpContext.Current.Request["Device_system"] != null)
				model.Device_system=Shop.Tools.RequestTool.RequestSafeString("Device_system");
			if (HttpContext.Current.Request["Money_fanxian"] != null)
				model.Money_fanxian=Shop.Tools.RequestTool.RequestDecimal("Money_fanxian",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_User ReaderBind(IDataReader dataReader)
		{
			Lebi_User model=new Lebi_User();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.Password=dataReader["Password"].ToString();
			model.JYpwd=dataReader["JYpwd"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.RealName=dataReader["RealName"].ToString();
			ojb = dataReader["lnum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.lnum=(int)ojb;
			}
			model.Sex=dataReader["Sex"].ToString();
			model.NickName=dataReader["NickName"].ToString();
			ojb = dataReader["Birthday"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Birthday=(DateTime)ojb;
			}
			model.pwdwen=dataReader["pwdwen"].ToString();
			model.pwdda=dataReader["pwdda"].ToString();
			ojb = dataReader["Point"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point=(decimal)ojb;
			}
			model.Uavatar=dataReader["Uavatar"].ToString();
			model.City=dataReader["City"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			model.Address=dataReader["Address"].ToString();
			model.MobilePhone=dataReader["MobilePhone"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			model.QQ=dataReader["QQ"].ToString();
			model.Fax=dataReader["Fax"].ToString();
			model.Postalcode=dataReader["Postalcode"].ToString();
			model.Msn=dataReader["Msn"].ToString();
			ojb = dataReader["Yfmoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Yfmoney=(decimal)ojb;
			}
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Money_xiaofei"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_xiaofei=(decimal)ojb;
			}
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
			ojb = dataReader["Upass"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Upass=(int)ojb;
			}
			ojb = dataReader["IsOpen"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsOpen=(int)ojb;
			}
			model.Introduce=dataReader["Introduce"].ToString();
			ojb = dataReader["UserLevel_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLevel_id=(int)ojb;
			}
			ojb = dataReader["Time_lastorder"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_lastorder=(DateTime)ojb;
			}
			ojb = dataReader["User_Address_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_Address_id=(int)ojb;
			}
			model.Transport_Price_id=dataReader["Transport_Price_id"].ToString();
			ojb = dataReader["Pay_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pay_id=(int)ojb;
			}
			ojb = dataReader["OnlinePay_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OnlinePay_id=(int)ojb;
			}
			ojb = dataReader["Count_Order"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Order=(int)ojb;
			}
			ojb = dataReader["Count_Order_OK"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Order_OK=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			model.CheckCode=dataReader["CheckCode"].ToString();
			ojb = dataReader["Currency_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_id=(int)ojb;
			}
			model.Currency_Code=dataReader["Currency_Code"].ToString();
			model.Face=dataReader["Face"].ToString();
			model.bind_qq_id=dataReader["bind_qq_id"].ToString();
			model.bind_qq_token=dataReader["bind_qq_token"].ToString();
			model.bind_qq_nickname=dataReader["bind_qq_nickname"].ToString();
			model.bind_weibo_id=dataReader["bind_weibo_id"].ToString();
			model.bind_weibo_token=dataReader["bind_weibo_token"].ToString();
			model.bind_weibo_nickname=dataReader["bind_weibo_nickname"].ToString();
			model.bind_taobao_id=dataReader["bind_taobao_id"].ToString();
			model.bind_taobao_token=dataReader["bind_taobao_token"].ToString();
			model.bind_taobao_nickname=dataReader["bind_taobao_nickname"].ToString();
			model.bind_facebook_id=dataReader["bind_facebook_id"].ToString();
			model.bind_facebook_token=dataReader["bind_facebook_token"].ToString();
			model.bind_facebook_nickname=dataReader["bind_facebook_nickname"].ToString();
			ojb = dataReader["IsPlatformAccount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPlatformAccount=(int)ojb;
			}
			ojb = dataReader["IsAnonymous"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsAnonymous=(int)ojb;
			}
			ojb = dataReader["User_id_parent"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id_parent=(int)ojb;
			}
			model.Pay_Password=dataReader["Pay_Password"].ToString();
			ojb = dataReader["AgentMoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AgentMoney=(decimal)ojb;
			}
			ojb = dataReader["AgentMoney_history"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AgentMoney_history=(decimal)ojb;
			}
			ojb = dataReader["Count_sonuser"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_sonuser=(int)ojb;
			}
			model.CashAccount_Code=dataReader["CashAccount_Code"].ToString();
			model.CashAccount_Name=dataReader["CashAccount_Name"].ToString();
			model.CashAccount_Bank=dataReader["CashAccount_Bank"].ToString();
			model.bind_weixin_nickname=dataReader["bind_weixin_nickname"].ToString();
			model.bind_weixin_token=dataReader["bind_weixin_token"].ToString();
			model.bind_weixin_id=dataReader["bind_weixin_id"].ToString();
			ojb = dataReader["Site_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Site_id=(int)ojb;
			}
			model.UserNumber=dataReader["UserNumber"].ToString();
			model.weixin=dataReader["weixin"].ToString();
			model.alipay=dataReader["alipay"].ToString();
			model.aliwangwang=dataReader["aliwangwang"].ToString();
			model.momo=dataReader["momo"].ToString();
			model.job=dataReader["job"].ToString();
			model.IDNumber=dataReader["IDNumber"].ToString();
			model.IDType=dataReader["IDType"].ToString();
			ojb = dataReader["Money_Order"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Order=(decimal)ojb;
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
			ojb = dataReader["Money_Bill"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Bill=(decimal)ojb;
			}
			ojb = dataReader["Time_End"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_End=(DateTime)ojb;
			}
			ojb = dataReader["IsCheckedEmail"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCheckedEmail=(int)ojb;
			}
			ojb = dataReader["IsCheckedMobilePhone"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCheckedMobilePhone=(int)ojb;
			}
			ojb = dataReader["RandNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RandNum=(int)ojb;
			}
			model.PickUp_id=dataReader["PickUp_id"].ToString();
			ojb = dataReader["PickUp_Date"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PickUp_Date=(DateTime)ojb;
			}
			model.Device_id=dataReader["Device_id"].ToString();
			model.Device_system=dataReader["Device_system"].ToString();
			ojb = dataReader["Money_fanxian"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_fanxian=(decimal)ojb;
			}
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
			}
			ojb = dataReader["IsDel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDel=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_User : Lebi_User_interface
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
				strSql.Append("select " + colName + " from [Lebi_User]");
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
			strSql.Append("select  "+colName+" from [Lebi_User]");
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
			strSql.Append("select count(*) from [Lebi_User]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_User]");
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
			strSql.Append("select max(id) from [Lebi_User]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_User](");
			strSql.Append("[UserName],[Password],[JYpwd],[Email],[RealName],[lnum],[Sex],[NickName],[Birthday],[pwdwen],[pwdda],[Point],[Uavatar],[City],[Area_id],[Address],[MobilePhone],[Phone],[QQ],[Fax],[Postalcode],[Msn],[Yfmoney],[Money],[Money_xiaofei],[Count_Login],[IP_Last],[IP_This],[Time_This],[Time_Last],[Time_Reg],[Upass],[IsOpen],[Introduce],[UserLevel_id],[Time_lastorder],[User_Address_id],[Transport_Price_id],[Pay_id],[OnlinePay_id],[Count_Order],[Count_Order_OK],[Language],[CheckCode],[Currency_id],[Currency_Code],[Face],[bind_qq_id],[bind_qq_token],[bind_qq_nickname],[bind_weibo_id],[bind_weibo_token],[bind_weibo_nickname],[bind_taobao_id],[bind_taobao_token],[bind_taobao_nickname],[bind_facebook_id],[bind_facebook_token],[bind_facebook_nickname],[IsPlatformAccount],[IsAnonymous],[User_id_parent],[Pay_Password],[AgentMoney],[AgentMoney_history],[Count_sonuser],[CashAccount_Code],[CashAccount_Name],[CashAccount_Bank],[bind_weixin_nickname],[bind_weixin_token],[bind_weixin_id],[Site_id],[UserNumber],[weixin],[alipay],[aliwangwang],[momo],[job],[IDNumber],[IDType],[Money_Order],[Money_Product],[Money_Transport],[Money_Bill],[Time_End],[IsCheckedEmail],[IsCheckedMobilePhone],[RandNum],[PickUp_id],[PickUp_Date],[Device_id],[Device_system],[Money_fanxian],[DT_id],[IsDel])");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Password,@JYpwd,@Email,@RealName,@lnum,@Sex,@NickName,@Birthday,@pwdwen,@pwdda,@Point,@Uavatar,@City,@Area_id,@Address,@MobilePhone,@Phone,@QQ,@Fax,@Postalcode,@Msn,@Yfmoney,@Money,@Money_xiaofei,@Count_Login,@IP_Last,@IP_This,@Time_This,@Time_Last,@Time_Reg,@Upass,@IsOpen,@Introduce,@UserLevel_id,@Time_lastorder,@User_Address_id,@Transport_Price_id,@Pay_id,@OnlinePay_id,@Count_Order,@Count_Order_OK,@Language,@CheckCode,@Currency_id,@Currency_Code,@Face,@bind_qq_id,@bind_qq_token,@bind_qq_nickname,@bind_weibo_id,@bind_weibo_token,@bind_weibo_nickname,@bind_taobao_id,@bind_taobao_token,@bind_taobao_nickname,@bind_facebook_id,@bind_facebook_token,@bind_facebook_nickname,@IsPlatformAccount,@IsAnonymous,@User_id_parent,@Pay_Password,@AgentMoney,@AgentMoney_history,@Count_sonuser,@CashAccount_Code,@CashAccount_Name,@CashAccount_Bank,@bind_weixin_nickname,@bind_weixin_token,@bind_weixin_id,@Site_id,@UserNumber,@weixin,@alipay,@aliwangwang,@momo,@job,@IDNumber,@IDType,@Money_Order,@Money_Product,@Money_Transport,@Money_Bill,@Time_End,@IsCheckedEmail,@IsCheckedMobilePhone,@RandNum,@PickUp_id,@PickUp_Date,@Device_id,@Device_system,@Money_fanxian,@DT_id,@IsDel)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Password", model.Password),
					new OleDbParameter("@JYpwd", model.JYpwd),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@RealName", model.RealName),
					new OleDbParameter("@lnum", model.lnum),
					new OleDbParameter("@Sex", model.Sex),
					new OleDbParameter("@NickName", model.NickName),
					new OleDbParameter("@Birthday", model.Birthday.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@pwdwen", model.pwdwen),
					new OleDbParameter("@pwdda", model.pwdda),
					new OleDbParameter("@Point", model.Point),
					new OleDbParameter("@Uavatar", model.Uavatar),
					new OleDbParameter("@City", model.City),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@MobilePhone", model.MobilePhone),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@QQ", model.QQ),
					new OleDbParameter("@Fax", model.Fax),
					new OleDbParameter("@Postalcode", model.Postalcode),
					new OleDbParameter("@Msn", model.Msn),
					new OleDbParameter("@Yfmoney", model.Yfmoney),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Money_xiaofei", model.Money_xiaofei),
					new OleDbParameter("@Count_Login", model.Count_Login),
					new OleDbParameter("@IP_Last", model.IP_Last),
					new OleDbParameter("@IP_This", model.IP_This),
					new OleDbParameter("@Time_This", model.Time_This.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Last", model.Time_Last.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Reg", model.Time_Reg.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Upass", model.Upass),
					new OleDbParameter("@IsOpen", model.IsOpen),
					new OleDbParameter("@Introduce", model.Introduce),
					new OleDbParameter("@UserLevel_id", model.UserLevel_id),
					new OleDbParameter("@Time_lastorder", model.Time_lastorder.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@User_Address_id", model.User_Address_id),
					new OleDbParameter("@Transport_Price_id", model.Transport_Price_id),
					new OleDbParameter("@Pay_id", model.Pay_id),
					new OleDbParameter("@OnlinePay_id", model.OnlinePay_id),
					new OleDbParameter("@Count_Order", model.Count_Order),
					new OleDbParameter("@Count_Order_OK", model.Count_Order_OK),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@CheckCode", model.CheckCode),
					new OleDbParameter("@Currency_id", model.Currency_id),
					new OleDbParameter("@Currency_Code", model.Currency_Code),
					new OleDbParameter("@Face", model.Face),
					new OleDbParameter("@bind_qq_id", model.bind_qq_id),
					new OleDbParameter("@bind_qq_token", model.bind_qq_token),
					new OleDbParameter("@bind_qq_nickname", model.bind_qq_nickname),
					new OleDbParameter("@bind_weibo_id", model.bind_weibo_id),
					new OleDbParameter("@bind_weibo_token", model.bind_weibo_token),
					new OleDbParameter("@bind_weibo_nickname", model.bind_weibo_nickname),
					new OleDbParameter("@bind_taobao_id", model.bind_taobao_id),
					new OleDbParameter("@bind_taobao_token", model.bind_taobao_token),
					new OleDbParameter("@bind_taobao_nickname", model.bind_taobao_nickname),
					new OleDbParameter("@bind_facebook_id", model.bind_facebook_id),
					new OleDbParameter("@bind_facebook_token", model.bind_facebook_token),
					new OleDbParameter("@bind_facebook_nickname", model.bind_facebook_nickname),
					new OleDbParameter("@IsPlatformAccount", model.IsPlatformAccount),
					new OleDbParameter("@IsAnonymous", model.IsAnonymous),
					new OleDbParameter("@User_id_parent", model.User_id_parent),
					new OleDbParameter("@Pay_Password", model.Pay_Password),
					new OleDbParameter("@AgentMoney", model.AgentMoney),
					new OleDbParameter("@AgentMoney_history", model.AgentMoney_history),
					new OleDbParameter("@Count_sonuser", model.Count_sonuser),
					new OleDbParameter("@CashAccount_Code", model.CashAccount_Code),
					new OleDbParameter("@CashAccount_Name", model.CashAccount_Name),
					new OleDbParameter("@CashAccount_Bank", model.CashAccount_Bank),
					new OleDbParameter("@bind_weixin_nickname", model.bind_weixin_nickname),
					new OleDbParameter("@bind_weixin_token", model.bind_weixin_token),
					new OleDbParameter("@bind_weixin_id", model.bind_weixin_id),
					new OleDbParameter("@Site_id", model.Site_id),
					new OleDbParameter("@UserNumber", model.UserNumber),
					new OleDbParameter("@weixin", model.weixin),
					new OleDbParameter("@alipay", model.alipay),
					new OleDbParameter("@aliwangwang", model.aliwangwang),
					new OleDbParameter("@momo", model.momo),
					new OleDbParameter("@job", model.job),
					new OleDbParameter("@IDNumber", model.IDNumber),
					new OleDbParameter("@IDType", model.IDType),
					new OleDbParameter("@Money_Order", model.Money_Order),
					new OleDbParameter("@Money_Product", model.Money_Product),
					new OleDbParameter("@Money_Transport", model.Money_Transport),
					new OleDbParameter("@Money_Bill", model.Money_Bill),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@IsCheckedEmail", model.IsCheckedEmail),
					new OleDbParameter("@IsCheckedMobilePhone", model.IsCheckedMobilePhone),
					new OleDbParameter("@RandNum", model.RandNum),
					new OleDbParameter("@PickUp_id", model.PickUp_id),
					new OleDbParameter("@PickUp_Date", model.PickUp_Date.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Device_id", model.Device_id),
					new OleDbParameter("@Device_system", model.Device_system),
					new OleDbParameter("@Money_fanxian", model.Money_fanxian),
					new OleDbParameter("@DT_id", model.DT_id),
					new OleDbParameter("@IsDel", model.IsDel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_User] set ");
			strSql.Append("[UserName]=@UserName,");
			strSql.Append("[Password]=@Password,");
			strSql.Append("[JYpwd]=@JYpwd,");
			strSql.Append("[Email]=@Email,");
			strSql.Append("[RealName]=@RealName,");
			strSql.Append("[lnum]=@lnum,");
			strSql.Append("[Sex]=@Sex,");
			strSql.Append("[NickName]=@NickName,");
			strSql.Append("[Birthday]=@Birthday,");
			strSql.Append("[pwdwen]=@pwdwen,");
			strSql.Append("[pwdda]=@pwdda,");
			strSql.Append("[Point]=@Point,");
			strSql.Append("[Uavatar]=@Uavatar,");
			strSql.Append("[City]=@City,");
			strSql.Append("[Area_id]=@Area_id,");
			strSql.Append("[Address]=@Address,");
			strSql.Append("[MobilePhone]=@MobilePhone,");
			strSql.Append("[Phone]=@Phone,");
			strSql.Append("[QQ]=@QQ,");
			strSql.Append("[Fax]=@Fax,");
			strSql.Append("[Postalcode]=@Postalcode,");
			strSql.Append("[Msn]=@Msn,");
			strSql.Append("[Yfmoney]=@Yfmoney,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[Money_xiaofei]=@Money_xiaofei,");
			strSql.Append("[Count_Login]=@Count_Login,");
			strSql.Append("[IP_Last]=@IP_Last,");
			strSql.Append("[IP_This]=@IP_This,");
			strSql.Append("[Time_This]=@Time_This,");
			strSql.Append("[Time_Last]=@Time_Last,");
			strSql.Append("[Time_Reg]=@Time_Reg,");
			strSql.Append("[Upass]=@Upass,");
			strSql.Append("[IsOpen]=@IsOpen,");
			strSql.Append("[Introduce]=@Introduce,");
			strSql.Append("[UserLevel_id]=@UserLevel_id,");
			strSql.Append("[Time_lastorder]=@Time_lastorder,");
			strSql.Append("[User_Address_id]=@User_Address_id,");
			strSql.Append("[Transport_Price_id]=@Transport_Price_id,");
			strSql.Append("[Pay_id]=@Pay_id,");
			strSql.Append("[OnlinePay_id]=@OnlinePay_id,");
			strSql.Append("[Count_Order]=@Count_Order,");
			strSql.Append("[Count_Order_OK]=@Count_Order_OK,");
			strSql.Append("[Language]=@Language,");
			strSql.Append("[CheckCode]=@CheckCode,");
			strSql.Append("[Currency_id]=@Currency_id,");
			strSql.Append("[Currency_Code]=@Currency_Code,");
			strSql.Append("[Face]=@Face,");
			strSql.Append("[bind_qq_id]=@bind_qq_id,");
			strSql.Append("[bind_qq_token]=@bind_qq_token,");
			strSql.Append("[bind_qq_nickname]=@bind_qq_nickname,");
			strSql.Append("[bind_weibo_id]=@bind_weibo_id,");
			strSql.Append("[bind_weibo_token]=@bind_weibo_token,");
			strSql.Append("[bind_weibo_nickname]=@bind_weibo_nickname,");
			strSql.Append("[bind_taobao_id]=@bind_taobao_id,");
			strSql.Append("[bind_taobao_token]=@bind_taobao_token,");
			strSql.Append("[bind_taobao_nickname]=@bind_taobao_nickname,");
			strSql.Append("[bind_facebook_id]=@bind_facebook_id,");
			strSql.Append("[bind_facebook_token]=@bind_facebook_token,");
			strSql.Append("[bind_facebook_nickname]=@bind_facebook_nickname,");
			strSql.Append("[IsPlatformAccount]=@IsPlatformAccount,");
			strSql.Append("[IsAnonymous]=@IsAnonymous,");
			strSql.Append("[User_id_parent]=@User_id_parent,");
			strSql.Append("[Pay_Password]=@Pay_Password,");
			strSql.Append("[AgentMoney]=@AgentMoney,");
			strSql.Append("[AgentMoney_history]=@AgentMoney_history,");
			strSql.Append("[Count_sonuser]=@Count_sonuser,");
			strSql.Append("[CashAccount_Code]=@CashAccount_Code,");
			strSql.Append("[CashAccount_Name]=@CashAccount_Name,");
			strSql.Append("[CashAccount_Bank]=@CashAccount_Bank,");
			strSql.Append("[bind_weixin_nickname]=@bind_weixin_nickname,");
			strSql.Append("[bind_weixin_token]=@bind_weixin_token,");
			strSql.Append("[bind_weixin_id]=@bind_weixin_id,");
			strSql.Append("[Site_id]=@Site_id,");
			strSql.Append("[UserNumber]=@UserNumber,");
			strSql.Append("[weixin]=@weixin,");
			strSql.Append("[alipay]=@alipay,");
			strSql.Append("[aliwangwang]=@aliwangwang,");
			strSql.Append("[momo]=@momo,");
			strSql.Append("[job]=@job,");
			strSql.Append("[IDNumber]=@IDNumber,");
			strSql.Append("[IDType]=@IDType,");
			strSql.Append("[Money_Order]=@Money_Order,");
			strSql.Append("[Money_Product]=@Money_Product,");
			strSql.Append("[Money_Transport]=@Money_Transport,");
			strSql.Append("[Money_Bill]=@Money_Bill,");
			strSql.Append("[Time_End]=@Time_End,");
			strSql.Append("[IsCheckedEmail]=@IsCheckedEmail,");
			strSql.Append("[IsCheckedMobilePhone]=@IsCheckedMobilePhone,");
			strSql.Append("[RandNum]=@RandNum,");
			strSql.Append("[PickUp_id]=@PickUp_id,");
			strSql.Append("[PickUp_Date]=@PickUp_Date,");
			strSql.Append("[Device_id]=@Device_id,");
			strSql.Append("[Device_system]=@Device_system,");
			strSql.Append("[Money_fanxian]=@Money_fanxian,");
			strSql.Append("[DT_id]=@DT_id,");
			strSql.Append("[IsDel]=@IsDel");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Password", model.Password),
					new OleDbParameter("@JYpwd", model.JYpwd),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@RealName", model.RealName),
					new OleDbParameter("@lnum", model.lnum),
					new OleDbParameter("@Sex", model.Sex),
					new OleDbParameter("@NickName", model.NickName),
					new OleDbParameter("@Birthday", model.Birthday.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@pwdwen", model.pwdwen),
					new OleDbParameter("@pwdda", model.pwdda),
					new OleDbParameter("@Point", model.Point),
					new OleDbParameter("@Uavatar", model.Uavatar),
					new OleDbParameter("@City", model.City),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@MobilePhone", model.MobilePhone),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@QQ", model.QQ),
					new OleDbParameter("@Fax", model.Fax),
					new OleDbParameter("@Postalcode", model.Postalcode),
					new OleDbParameter("@Msn", model.Msn),
					new OleDbParameter("@Yfmoney", model.Yfmoney),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Money_xiaofei", model.Money_xiaofei),
					new OleDbParameter("@Count_Login", model.Count_Login),
					new OleDbParameter("@IP_Last", model.IP_Last),
					new OleDbParameter("@IP_This", model.IP_This),
					new OleDbParameter("@Time_This", model.Time_This.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Last", model.Time_Last.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Reg", model.Time_Reg.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Upass", model.Upass),
					new OleDbParameter("@IsOpen", model.IsOpen),
					new OleDbParameter("@Introduce", model.Introduce),
					new OleDbParameter("@UserLevel_id", model.UserLevel_id),
					new OleDbParameter("@Time_lastorder", model.Time_lastorder.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@User_Address_id", model.User_Address_id),
					new OleDbParameter("@Transport_Price_id", model.Transport_Price_id),
					new OleDbParameter("@Pay_id", model.Pay_id),
					new OleDbParameter("@OnlinePay_id", model.OnlinePay_id),
					new OleDbParameter("@Count_Order", model.Count_Order),
					new OleDbParameter("@Count_Order_OK", model.Count_Order_OK),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@CheckCode", model.CheckCode),
					new OleDbParameter("@Currency_id", model.Currency_id),
					new OleDbParameter("@Currency_Code", model.Currency_Code),
					new OleDbParameter("@Face", model.Face),
					new OleDbParameter("@bind_qq_id", model.bind_qq_id),
					new OleDbParameter("@bind_qq_token", model.bind_qq_token),
					new OleDbParameter("@bind_qq_nickname", model.bind_qq_nickname),
					new OleDbParameter("@bind_weibo_id", model.bind_weibo_id),
					new OleDbParameter("@bind_weibo_token", model.bind_weibo_token),
					new OleDbParameter("@bind_weibo_nickname", model.bind_weibo_nickname),
					new OleDbParameter("@bind_taobao_id", model.bind_taobao_id),
					new OleDbParameter("@bind_taobao_token", model.bind_taobao_token),
					new OleDbParameter("@bind_taobao_nickname", model.bind_taobao_nickname),
					new OleDbParameter("@bind_facebook_id", model.bind_facebook_id),
					new OleDbParameter("@bind_facebook_token", model.bind_facebook_token),
					new OleDbParameter("@bind_facebook_nickname", model.bind_facebook_nickname),
					new OleDbParameter("@IsPlatformAccount", model.IsPlatformAccount),
					new OleDbParameter("@IsAnonymous", model.IsAnonymous),
					new OleDbParameter("@User_id_parent", model.User_id_parent),
					new OleDbParameter("@Pay_Password", model.Pay_Password),
					new OleDbParameter("@AgentMoney", model.AgentMoney),
					new OleDbParameter("@AgentMoney_history", model.AgentMoney_history),
					new OleDbParameter("@Count_sonuser", model.Count_sonuser),
					new OleDbParameter("@CashAccount_Code", model.CashAccount_Code),
					new OleDbParameter("@CashAccount_Name", model.CashAccount_Name),
					new OleDbParameter("@CashAccount_Bank", model.CashAccount_Bank),
					new OleDbParameter("@bind_weixin_nickname", model.bind_weixin_nickname),
					new OleDbParameter("@bind_weixin_token", model.bind_weixin_token),
					new OleDbParameter("@bind_weixin_id", model.bind_weixin_id),
					new OleDbParameter("@Site_id", model.Site_id),
					new OleDbParameter("@UserNumber", model.UserNumber),
					new OleDbParameter("@weixin", model.weixin),
					new OleDbParameter("@alipay", model.alipay),
					new OleDbParameter("@aliwangwang", model.aliwangwang),
					new OleDbParameter("@momo", model.momo),
					new OleDbParameter("@job", model.job),
					new OleDbParameter("@IDNumber", model.IDNumber),
					new OleDbParameter("@IDType", model.IDType),
					new OleDbParameter("@Money_Order", model.Money_Order),
					new OleDbParameter("@Money_Product", model.Money_Product),
					new OleDbParameter("@Money_Transport", model.Money_Transport),
					new OleDbParameter("@Money_Bill", model.Money_Bill),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@IsCheckedEmail", model.IsCheckedEmail),
					new OleDbParameter("@IsCheckedMobilePhone", model.IsCheckedMobilePhone),
					new OleDbParameter("@RandNum", model.RandNum),
					new OleDbParameter("@PickUp_id", model.PickUp_id),
					new OleDbParameter("@PickUp_Date", model.PickUp_Date.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Device_id", model.Device_id),
					new OleDbParameter("@Device_system", model.Device_system),
					new OleDbParameter("@Money_fanxian", model.Money_fanxian),
					new OleDbParameter("@DT_id", model.DT_id),
					new OleDbParameter("@IsDel", model.IsDel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User] ");
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
			strSql.Append("delete from [Lebi_User] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_User GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_User model;
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
		public Lebi_User GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_User model;
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
		public Lebi_User GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_User] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_User model;
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
		public List<Lebi_User> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_User]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_User> list = new List<Lebi_User>();
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
		public List<Lebi_User> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_User]";
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
			List<Lebi_User> list = new List<Lebi_User>();
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
		public List<Lebi_User> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_User] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_User> list = new List<Lebi_User>();
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
		public List<Lebi_User> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_User]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_User> list = new List<Lebi_User>();
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
		public Lebi_User BindForm(Lebi_User model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestString("Password");
			if (HttpContext.Current.Request["JYpwd"] != null)
				model.JYpwd=Shop.Tools.RequestTool.RequestString("JYpwd");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestString("RealName");
			if (HttpContext.Current.Request["lnum"] != null)
				model.lnum=Shop.Tools.RequestTool.RequestInt("lnum",0);
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestString("Sex");
			if (HttpContext.Current.Request["NickName"] != null)
				model.NickName=Shop.Tools.RequestTool.RequestString("NickName");
			if (HttpContext.Current.Request["Birthday"] != null)
				model.Birthday=Shop.Tools.RequestTool.RequestTime("Birthday", System.DateTime.Now);
			if (HttpContext.Current.Request["pwdwen"] != null)
				model.pwdwen=Shop.Tools.RequestTool.RequestString("pwdwen");
			if (HttpContext.Current.Request["pwdda"] != null)
				model.pwdda=Shop.Tools.RequestTool.RequestString("pwdda");
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["Uavatar"] != null)
				model.Uavatar=Shop.Tools.RequestTool.RequestString("Uavatar");
			if (HttpContext.Current.Request["City"] != null)
				model.City=Shop.Tools.RequestTool.RequestString("City");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestString("QQ");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestString("Fax");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestString("Postalcode");
			if (HttpContext.Current.Request["Msn"] != null)
				model.Msn=Shop.Tools.RequestTool.RequestString("Msn");
			if (HttpContext.Current.Request["Yfmoney"] != null)
				model.Yfmoney=Shop.Tools.RequestTool.RequestDecimal("Yfmoney",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Money_xiaofei"] != null)
				model.Money_xiaofei=Shop.Tools.RequestTool.RequestDecimal("Money_xiaofei",0);
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
			if (HttpContext.Current.Request["Upass"] != null)
				model.Upass=Shop.Tools.RequestTool.RequestInt("Upass",0);
			if (HttpContext.Current.Request["IsOpen"] != null)
				model.IsOpen=Shop.Tools.RequestTool.RequestInt("IsOpen",0);
			if (HttpContext.Current.Request["Introduce"] != null)
				model.Introduce=Shop.Tools.RequestTool.RequestString("Introduce");
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
			if (HttpContext.Current.Request["Time_lastorder"] != null)
				model.Time_lastorder=Shop.Tools.RequestTool.RequestTime("Time_lastorder", System.DateTime.Now);
			if (HttpContext.Current.Request["User_Address_id"] != null)
				model.User_Address_id=Shop.Tools.RequestTool.RequestInt("User_Address_id",0);
			if (HttpContext.Current.Request["Transport_Price_id"] != null)
				model.Transport_Price_id=Shop.Tools.RequestTool.RequestString("Transport_Price_id");
			if (HttpContext.Current.Request["Pay_id"] != null)
				model.Pay_id=Shop.Tools.RequestTool.RequestInt("Pay_id",0);
			if (HttpContext.Current.Request["OnlinePay_id"] != null)
				model.OnlinePay_id=Shop.Tools.RequestTool.RequestInt("OnlinePay_id",0);
			if (HttpContext.Current.Request["Count_Order"] != null)
				model.Count_Order=Shop.Tools.RequestTool.RequestInt("Count_Order",0);
			if (HttpContext.Current.Request["Count_Order_OK"] != null)
				model.Count_Order_OK=Shop.Tools.RequestTool.RequestInt("Count_Order_OK",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["CheckCode"] != null)
				model.CheckCode=Shop.Tools.RequestTool.RequestString("CheckCode");
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestString("Currency_Code");
			if (HttpContext.Current.Request["Face"] != null)
				model.Face=Shop.Tools.RequestTool.RequestString("Face");
			if (HttpContext.Current.Request["bind_qq_id"] != null)
				model.bind_qq_id=Shop.Tools.RequestTool.RequestString("bind_qq_id");
			if (HttpContext.Current.Request["bind_qq_token"] != null)
				model.bind_qq_token=Shop.Tools.RequestTool.RequestString("bind_qq_token");
			if (HttpContext.Current.Request["bind_qq_nickname"] != null)
				model.bind_qq_nickname=Shop.Tools.RequestTool.RequestString("bind_qq_nickname");
			if (HttpContext.Current.Request["bind_weibo_id"] != null)
				model.bind_weibo_id=Shop.Tools.RequestTool.RequestString("bind_weibo_id");
			if (HttpContext.Current.Request["bind_weibo_token"] != null)
				model.bind_weibo_token=Shop.Tools.RequestTool.RequestString("bind_weibo_token");
			if (HttpContext.Current.Request["bind_weibo_nickname"] != null)
				model.bind_weibo_nickname=Shop.Tools.RequestTool.RequestString("bind_weibo_nickname");
			if (HttpContext.Current.Request["bind_taobao_id"] != null)
				model.bind_taobao_id=Shop.Tools.RequestTool.RequestString("bind_taobao_id");
			if (HttpContext.Current.Request["bind_taobao_token"] != null)
				model.bind_taobao_token=Shop.Tools.RequestTool.RequestString("bind_taobao_token");
			if (HttpContext.Current.Request["bind_taobao_nickname"] != null)
				model.bind_taobao_nickname=Shop.Tools.RequestTool.RequestString("bind_taobao_nickname");
			if (HttpContext.Current.Request["bind_facebook_id"] != null)
				model.bind_facebook_id=Shop.Tools.RequestTool.RequestString("bind_facebook_id");
			if (HttpContext.Current.Request["bind_facebook_token"] != null)
				model.bind_facebook_token=Shop.Tools.RequestTool.RequestString("bind_facebook_token");
			if (HttpContext.Current.Request["bind_facebook_nickname"] != null)
				model.bind_facebook_nickname=Shop.Tools.RequestTool.RequestString("bind_facebook_nickname");
			if (HttpContext.Current.Request["IsPlatformAccount"] != null)
				model.IsPlatformAccount=Shop.Tools.RequestTool.RequestInt("IsPlatformAccount",0);
			if (HttpContext.Current.Request["IsAnonymous"] != null)
				model.IsAnonymous=Shop.Tools.RequestTool.RequestInt("IsAnonymous",0);
			if (HttpContext.Current.Request["User_id_parent"] != null)
				model.User_id_parent=Shop.Tools.RequestTool.RequestInt("User_id_parent",0);
			if (HttpContext.Current.Request["Pay_Password"] != null)
				model.Pay_Password=Shop.Tools.RequestTool.RequestString("Pay_Password");
			if (HttpContext.Current.Request["AgentMoney"] != null)
				model.AgentMoney=Shop.Tools.RequestTool.RequestDecimal("AgentMoney",0);
			if (HttpContext.Current.Request["AgentMoney_history"] != null)
				model.AgentMoney_history=Shop.Tools.RequestTool.RequestDecimal("AgentMoney_history",0);
			if (HttpContext.Current.Request["Count_sonuser"] != null)
				model.Count_sonuser=Shop.Tools.RequestTool.RequestInt("Count_sonuser",0);
			if (HttpContext.Current.Request["CashAccount_Code"] != null)
				model.CashAccount_Code=Shop.Tools.RequestTool.RequestString("CashAccount_Code");
			if (HttpContext.Current.Request["CashAccount_Name"] != null)
				model.CashAccount_Name=Shop.Tools.RequestTool.RequestString("CashAccount_Name");
			if (HttpContext.Current.Request["CashAccount_Bank"] != null)
				model.CashAccount_Bank=Shop.Tools.RequestTool.RequestString("CashAccount_Bank");
			if (HttpContext.Current.Request["bind_weixin_nickname"] != null)
				model.bind_weixin_nickname=Shop.Tools.RequestTool.RequestString("bind_weixin_nickname");
			if (HttpContext.Current.Request["bind_weixin_token"] != null)
				model.bind_weixin_token=Shop.Tools.RequestTool.RequestString("bind_weixin_token");
			if (HttpContext.Current.Request["bind_weixin_id"] != null)
				model.bind_weixin_id=Shop.Tools.RequestTool.RequestString("bind_weixin_id");
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["UserNumber"] != null)
				model.UserNumber=Shop.Tools.RequestTool.RequestString("UserNumber");
			if (HttpContext.Current.Request["weixin"] != null)
				model.weixin=Shop.Tools.RequestTool.RequestString("weixin");
			if (HttpContext.Current.Request["alipay"] != null)
				model.alipay=Shop.Tools.RequestTool.RequestString("alipay");
			if (HttpContext.Current.Request["aliwangwang"] != null)
				model.aliwangwang=Shop.Tools.RequestTool.RequestString("aliwangwang");
			if (HttpContext.Current.Request["momo"] != null)
				model.momo=Shop.Tools.RequestTool.RequestString("momo");
			if (HttpContext.Current.Request["job"] != null)
				model.job=Shop.Tools.RequestTool.RequestString("job");
			if (HttpContext.Current.Request["IDNumber"] != null)
				model.IDNumber=Shop.Tools.RequestTool.RequestString("IDNumber");
			if (HttpContext.Current.Request["IDType"] != null)
				model.IDType=Shop.Tools.RequestTool.RequestString("IDType");
			if (HttpContext.Current.Request["Money_Order"] != null)
				model.Money_Order=Shop.Tools.RequestTool.RequestDecimal("Money_Order",0);
			if (HttpContext.Current.Request["Money_Product"] != null)
				model.Money_Product=Shop.Tools.RequestTool.RequestDecimal("Money_Product",0);
			if (HttpContext.Current.Request["Money_Transport"] != null)
				model.Money_Transport=Shop.Tools.RequestTool.RequestDecimal("Money_Transport",0);
			if (HttpContext.Current.Request["Money_Bill"] != null)
				model.Money_Bill=Shop.Tools.RequestTool.RequestDecimal("Money_Bill",0);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["IsCheckedEmail"] != null)
				model.IsCheckedEmail=Shop.Tools.RequestTool.RequestInt("IsCheckedEmail",0);
			if (HttpContext.Current.Request["IsCheckedMobilePhone"] != null)
				model.IsCheckedMobilePhone=Shop.Tools.RequestTool.RequestInt("IsCheckedMobilePhone",0);
			if (HttpContext.Current.Request["RandNum"] != null)
				model.RandNum=Shop.Tools.RequestTool.RequestInt("RandNum",0);
			if (HttpContext.Current.Request["PickUp_id"] != null)
				model.PickUp_id=Shop.Tools.RequestTool.RequestString("PickUp_id");
			if (HttpContext.Current.Request["PickUp_Date"] != null)
				model.PickUp_Date=Shop.Tools.RequestTool.RequestTime("PickUp_Date", System.DateTime.Now);
			if (HttpContext.Current.Request["Device_id"] != null)
				model.Device_id=Shop.Tools.RequestTool.RequestString("Device_id");
			if (HttpContext.Current.Request["Device_system"] != null)
				model.Device_system=Shop.Tools.RequestTool.RequestString("Device_system");
			if (HttpContext.Current.Request["Money_fanxian"] != null)
				model.Money_fanxian=Shop.Tools.RequestTool.RequestDecimal("Money_fanxian",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_User SafeBindForm(Lebi_User model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestSafeString("Password");
			if (HttpContext.Current.Request["JYpwd"] != null)
				model.JYpwd=Shop.Tools.RequestTool.RequestSafeString("JYpwd");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestSafeString("RealName");
			if (HttpContext.Current.Request["lnum"] != null)
				model.lnum=Shop.Tools.RequestTool.RequestInt("lnum",0);
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestSafeString("Sex");
			if (HttpContext.Current.Request["NickName"] != null)
				model.NickName=Shop.Tools.RequestTool.RequestSafeString("NickName");
			if (HttpContext.Current.Request["Birthday"] != null)
				model.Birthday=Shop.Tools.RequestTool.RequestTime("Birthday", System.DateTime.Now);
			if (HttpContext.Current.Request["pwdwen"] != null)
				model.pwdwen=Shop.Tools.RequestTool.RequestSafeString("pwdwen");
			if (HttpContext.Current.Request["pwdda"] != null)
				model.pwdda=Shop.Tools.RequestTool.RequestSafeString("pwdda");
			if (HttpContext.Current.Request["Point"] != null)
				model.Point=Shop.Tools.RequestTool.RequestDecimal("Point",0);
			if (HttpContext.Current.Request["Uavatar"] != null)
				model.Uavatar=Shop.Tools.RequestTool.RequestSafeString("Uavatar");
			if (HttpContext.Current.Request["City"] != null)
				model.City=Shop.Tools.RequestTool.RequestSafeString("City");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestSafeString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestSafeString("QQ");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestSafeString("Fax");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestSafeString("Postalcode");
			if (HttpContext.Current.Request["Msn"] != null)
				model.Msn=Shop.Tools.RequestTool.RequestSafeString("Msn");
			if (HttpContext.Current.Request["Yfmoney"] != null)
				model.Yfmoney=Shop.Tools.RequestTool.RequestDecimal("Yfmoney",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Money_xiaofei"] != null)
				model.Money_xiaofei=Shop.Tools.RequestTool.RequestDecimal("Money_xiaofei",0);
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
			if (HttpContext.Current.Request["Upass"] != null)
				model.Upass=Shop.Tools.RequestTool.RequestInt("Upass",0);
			if (HttpContext.Current.Request["IsOpen"] != null)
				model.IsOpen=Shop.Tools.RequestTool.RequestInt("IsOpen",0);
			if (HttpContext.Current.Request["Introduce"] != null)
				model.Introduce=Shop.Tools.RequestTool.RequestSafeString("Introduce");
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
			if (HttpContext.Current.Request["Time_lastorder"] != null)
				model.Time_lastorder=Shop.Tools.RequestTool.RequestTime("Time_lastorder", System.DateTime.Now);
			if (HttpContext.Current.Request["User_Address_id"] != null)
				model.User_Address_id=Shop.Tools.RequestTool.RequestInt("User_Address_id",0);
			if (HttpContext.Current.Request["Transport_Price_id"] != null)
				model.Transport_Price_id=Shop.Tools.RequestTool.RequestSafeString("Transport_Price_id");
			if (HttpContext.Current.Request["Pay_id"] != null)
				model.Pay_id=Shop.Tools.RequestTool.RequestInt("Pay_id",0);
			if (HttpContext.Current.Request["OnlinePay_id"] != null)
				model.OnlinePay_id=Shop.Tools.RequestTool.RequestInt("OnlinePay_id",0);
			if (HttpContext.Current.Request["Count_Order"] != null)
				model.Count_Order=Shop.Tools.RequestTool.RequestInt("Count_Order",0);
			if (HttpContext.Current.Request["Count_Order_OK"] != null)
				model.Count_Order_OK=Shop.Tools.RequestTool.RequestInt("Count_Order_OK",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["CheckCode"] != null)
				model.CheckCode=Shop.Tools.RequestTool.RequestSafeString("CheckCode");
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestSafeString("Currency_Code");
			if (HttpContext.Current.Request["Face"] != null)
				model.Face=Shop.Tools.RequestTool.RequestSafeString("Face");
			if (HttpContext.Current.Request["bind_qq_id"] != null)
				model.bind_qq_id=Shop.Tools.RequestTool.RequestSafeString("bind_qq_id");
			if (HttpContext.Current.Request["bind_qq_token"] != null)
				model.bind_qq_token=Shop.Tools.RequestTool.RequestSafeString("bind_qq_token");
			if (HttpContext.Current.Request["bind_qq_nickname"] != null)
				model.bind_qq_nickname=Shop.Tools.RequestTool.RequestSafeString("bind_qq_nickname");
			if (HttpContext.Current.Request["bind_weibo_id"] != null)
				model.bind_weibo_id=Shop.Tools.RequestTool.RequestSafeString("bind_weibo_id");
			if (HttpContext.Current.Request["bind_weibo_token"] != null)
				model.bind_weibo_token=Shop.Tools.RequestTool.RequestSafeString("bind_weibo_token");
			if (HttpContext.Current.Request["bind_weibo_nickname"] != null)
				model.bind_weibo_nickname=Shop.Tools.RequestTool.RequestSafeString("bind_weibo_nickname");
			if (HttpContext.Current.Request["bind_taobao_id"] != null)
				model.bind_taobao_id=Shop.Tools.RequestTool.RequestSafeString("bind_taobao_id");
			if (HttpContext.Current.Request["bind_taobao_token"] != null)
				model.bind_taobao_token=Shop.Tools.RequestTool.RequestSafeString("bind_taobao_token");
			if (HttpContext.Current.Request["bind_taobao_nickname"] != null)
				model.bind_taobao_nickname=Shop.Tools.RequestTool.RequestSafeString("bind_taobao_nickname");
			if (HttpContext.Current.Request["bind_facebook_id"] != null)
				model.bind_facebook_id=Shop.Tools.RequestTool.RequestSafeString("bind_facebook_id");
			if (HttpContext.Current.Request["bind_facebook_token"] != null)
				model.bind_facebook_token=Shop.Tools.RequestTool.RequestSafeString("bind_facebook_token");
			if (HttpContext.Current.Request["bind_facebook_nickname"] != null)
				model.bind_facebook_nickname=Shop.Tools.RequestTool.RequestSafeString("bind_facebook_nickname");
			if (HttpContext.Current.Request["IsPlatformAccount"] != null)
				model.IsPlatformAccount=Shop.Tools.RequestTool.RequestInt("IsPlatformAccount",0);
			if (HttpContext.Current.Request["IsAnonymous"] != null)
				model.IsAnonymous=Shop.Tools.RequestTool.RequestInt("IsAnonymous",0);
			if (HttpContext.Current.Request["User_id_parent"] != null)
				model.User_id_parent=Shop.Tools.RequestTool.RequestInt("User_id_parent",0);
			if (HttpContext.Current.Request["Pay_Password"] != null)
				model.Pay_Password=Shop.Tools.RequestTool.RequestSafeString("Pay_Password");
			if (HttpContext.Current.Request["AgentMoney"] != null)
				model.AgentMoney=Shop.Tools.RequestTool.RequestDecimal("AgentMoney",0);
			if (HttpContext.Current.Request["AgentMoney_history"] != null)
				model.AgentMoney_history=Shop.Tools.RequestTool.RequestDecimal("AgentMoney_history",0);
			if (HttpContext.Current.Request["Count_sonuser"] != null)
				model.Count_sonuser=Shop.Tools.RequestTool.RequestInt("Count_sonuser",0);
			if (HttpContext.Current.Request["CashAccount_Code"] != null)
				model.CashAccount_Code=Shop.Tools.RequestTool.RequestSafeString("CashAccount_Code");
			if (HttpContext.Current.Request["CashAccount_Name"] != null)
				model.CashAccount_Name=Shop.Tools.RequestTool.RequestSafeString("CashAccount_Name");
			if (HttpContext.Current.Request["CashAccount_Bank"] != null)
				model.CashAccount_Bank=Shop.Tools.RequestTool.RequestSafeString("CashAccount_Bank");
			if (HttpContext.Current.Request["bind_weixin_nickname"] != null)
				model.bind_weixin_nickname=Shop.Tools.RequestTool.RequestSafeString("bind_weixin_nickname");
			if (HttpContext.Current.Request["bind_weixin_token"] != null)
				model.bind_weixin_token=Shop.Tools.RequestTool.RequestSafeString("bind_weixin_token");
			if (HttpContext.Current.Request["bind_weixin_id"] != null)
				model.bind_weixin_id=Shop.Tools.RequestTool.RequestSafeString("bind_weixin_id");
			if (HttpContext.Current.Request["Site_id"] != null)
				model.Site_id=Shop.Tools.RequestTool.RequestInt("Site_id",0);
			if (HttpContext.Current.Request["UserNumber"] != null)
				model.UserNumber=Shop.Tools.RequestTool.RequestSafeString("UserNumber");
			if (HttpContext.Current.Request["weixin"] != null)
				model.weixin=Shop.Tools.RequestTool.RequestSafeString("weixin");
			if (HttpContext.Current.Request["alipay"] != null)
				model.alipay=Shop.Tools.RequestTool.RequestSafeString("alipay");
			if (HttpContext.Current.Request["aliwangwang"] != null)
				model.aliwangwang=Shop.Tools.RequestTool.RequestSafeString("aliwangwang");
			if (HttpContext.Current.Request["momo"] != null)
				model.momo=Shop.Tools.RequestTool.RequestSafeString("momo");
			if (HttpContext.Current.Request["job"] != null)
				model.job=Shop.Tools.RequestTool.RequestSafeString("job");
			if (HttpContext.Current.Request["IDNumber"] != null)
				model.IDNumber=Shop.Tools.RequestTool.RequestSafeString("IDNumber");
			if (HttpContext.Current.Request["IDType"] != null)
				model.IDType=Shop.Tools.RequestTool.RequestSafeString("IDType");
			if (HttpContext.Current.Request["Money_Order"] != null)
				model.Money_Order=Shop.Tools.RequestTool.RequestDecimal("Money_Order",0);
			if (HttpContext.Current.Request["Money_Product"] != null)
				model.Money_Product=Shop.Tools.RequestTool.RequestDecimal("Money_Product",0);
			if (HttpContext.Current.Request["Money_Transport"] != null)
				model.Money_Transport=Shop.Tools.RequestTool.RequestDecimal("Money_Transport",0);
			if (HttpContext.Current.Request["Money_Bill"] != null)
				model.Money_Bill=Shop.Tools.RequestTool.RequestDecimal("Money_Bill",0);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["IsCheckedEmail"] != null)
				model.IsCheckedEmail=Shop.Tools.RequestTool.RequestInt("IsCheckedEmail",0);
			if (HttpContext.Current.Request["IsCheckedMobilePhone"] != null)
				model.IsCheckedMobilePhone=Shop.Tools.RequestTool.RequestInt("IsCheckedMobilePhone",0);
			if (HttpContext.Current.Request["RandNum"] != null)
				model.RandNum=Shop.Tools.RequestTool.RequestInt("RandNum",0);
			if (HttpContext.Current.Request["PickUp_id"] != null)
				model.PickUp_id=Shop.Tools.RequestTool.RequestSafeString("PickUp_id");
			if (HttpContext.Current.Request["PickUp_Date"] != null)
				model.PickUp_Date=Shop.Tools.RequestTool.RequestTime("PickUp_Date", System.DateTime.Now);
			if (HttpContext.Current.Request["Device_id"] != null)
				model.Device_id=Shop.Tools.RequestTool.RequestSafeString("Device_id");
			if (HttpContext.Current.Request["Device_system"] != null)
				model.Device_system=Shop.Tools.RequestTool.RequestSafeString("Device_system");
			if (HttpContext.Current.Request["Money_fanxian"] != null)
				model.Money_fanxian=Shop.Tools.RequestTool.RequestDecimal("Money_fanxian",0);
			if (HttpContext.Current.Request["DT_id"] != null)
				model.DT_id=Shop.Tools.RequestTool.RequestInt("DT_id",0);
			if (HttpContext.Current.Request["IsDel"] != null)
				model.IsDel=Shop.Tools.RequestTool.RequestInt("IsDel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_User ReaderBind(IDataReader dataReader)
		{
			Lebi_User model=new Lebi_User();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.Password=dataReader["Password"].ToString();
			model.JYpwd=dataReader["JYpwd"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.RealName=dataReader["RealName"].ToString();
			ojb = dataReader["lnum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.lnum=(int)ojb;
			}
			model.Sex=dataReader["Sex"].ToString();
			model.NickName=dataReader["NickName"].ToString();
			ojb = dataReader["Birthday"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Birthday=(DateTime)ojb;
			}
			model.pwdwen=dataReader["pwdwen"].ToString();
			model.pwdda=dataReader["pwdda"].ToString();
			ojb = dataReader["Point"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Point=(decimal)ojb;
			}
			model.Uavatar=dataReader["Uavatar"].ToString();
			model.City=dataReader["City"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			model.Address=dataReader["Address"].ToString();
			model.MobilePhone=dataReader["MobilePhone"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			model.QQ=dataReader["QQ"].ToString();
			model.Fax=dataReader["Fax"].ToString();
			model.Postalcode=dataReader["Postalcode"].ToString();
			model.Msn=dataReader["Msn"].ToString();
			ojb = dataReader["Yfmoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Yfmoney=(decimal)ojb;
			}
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Money_xiaofei"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_xiaofei=(decimal)ojb;
			}
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
			ojb = dataReader["Upass"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Upass=(int)ojb;
			}
			ojb = dataReader["IsOpen"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsOpen=(int)ojb;
			}
			model.Introduce=dataReader["Introduce"].ToString();
			ojb = dataReader["UserLevel_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLevel_id=(int)ojb;
			}
			ojb = dataReader["Time_lastorder"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_lastorder=(DateTime)ojb;
			}
			ojb = dataReader["User_Address_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_Address_id=(int)ojb;
			}
			model.Transport_Price_id=dataReader["Transport_Price_id"].ToString();
			ojb = dataReader["Pay_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pay_id=(int)ojb;
			}
			ojb = dataReader["OnlinePay_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OnlinePay_id=(int)ojb;
			}
			ojb = dataReader["Count_Order"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Order=(int)ojb;
			}
			ojb = dataReader["Count_Order_OK"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Order_OK=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			model.CheckCode=dataReader["CheckCode"].ToString();
			ojb = dataReader["Currency_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_id=(int)ojb;
			}
			model.Currency_Code=dataReader["Currency_Code"].ToString();
			model.Face=dataReader["Face"].ToString();
			model.bind_qq_id=dataReader["bind_qq_id"].ToString();
			model.bind_qq_token=dataReader["bind_qq_token"].ToString();
			model.bind_qq_nickname=dataReader["bind_qq_nickname"].ToString();
			model.bind_weibo_id=dataReader["bind_weibo_id"].ToString();
			model.bind_weibo_token=dataReader["bind_weibo_token"].ToString();
			model.bind_weibo_nickname=dataReader["bind_weibo_nickname"].ToString();
			model.bind_taobao_id=dataReader["bind_taobao_id"].ToString();
			model.bind_taobao_token=dataReader["bind_taobao_token"].ToString();
			model.bind_taobao_nickname=dataReader["bind_taobao_nickname"].ToString();
			model.bind_facebook_id=dataReader["bind_facebook_id"].ToString();
			model.bind_facebook_token=dataReader["bind_facebook_token"].ToString();
			model.bind_facebook_nickname=dataReader["bind_facebook_nickname"].ToString();
			ojb = dataReader["IsPlatformAccount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPlatformAccount=(int)ojb;
			}
			ojb = dataReader["IsAnonymous"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsAnonymous=(int)ojb;
			}
			ojb = dataReader["User_id_parent"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id_parent=(int)ojb;
			}
			model.Pay_Password=dataReader["Pay_Password"].ToString();
			ojb = dataReader["AgentMoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AgentMoney=(decimal)ojb;
			}
			ojb = dataReader["AgentMoney_history"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AgentMoney_history=(decimal)ojb;
			}
			ojb = dataReader["Count_sonuser"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_sonuser=(int)ojb;
			}
			model.CashAccount_Code=dataReader["CashAccount_Code"].ToString();
			model.CashAccount_Name=dataReader["CashAccount_Name"].ToString();
			model.CashAccount_Bank=dataReader["CashAccount_Bank"].ToString();
			model.bind_weixin_nickname=dataReader["bind_weixin_nickname"].ToString();
			model.bind_weixin_token=dataReader["bind_weixin_token"].ToString();
			model.bind_weixin_id=dataReader["bind_weixin_id"].ToString();
			ojb = dataReader["Site_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Site_id=(int)ojb;
			}
			model.UserNumber=dataReader["UserNumber"].ToString();
			model.weixin=dataReader["weixin"].ToString();
			model.alipay=dataReader["alipay"].ToString();
			model.aliwangwang=dataReader["aliwangwang"].ToString();
			model.momo=dataReader["momo"].ToString();
			model.job=dataReader["job"].ToString();
			model.IDNumber=dataReader["IDNumber"].ToString();
			model.IDType=dataReader["IDType"].ToString();
			ojb = dataReader["Money_Order"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Order=(decimal)ojb;
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
			ojb = dataReader["Money_Bill"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Bill=(decimal)ojb;
			}
			ojb = dataReader["Time_End"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_End=(DateTime)ojb;
			}
			ojb = dataReader["IsCheckedEmail"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCheckedEmail=(int)ojb;
			}
			ojb = dataReader["IsCheckedMobilePhone"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCheckedMobilePhone=(int)ojb;
			}
			ojb = dataReader["RandNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RandNum=(int)ojb;
			}
			model.PickUp_id=dataReader["PickUp_id"].ToString();
			ojb = dataReader["PickUp_Date"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PickUp_Date=(DateTime)ojb;
			}
			model.Device_id=dataReader["Device_id"].ToString();
			model.Device_system=dataReader["Device_system"].ToString();
			ojb = dataReader["Money_fanxian"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_fanxian=(decimal)ojb;
			}
			ojb = dataReader["DT_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DT_id=(int)ojb;
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

