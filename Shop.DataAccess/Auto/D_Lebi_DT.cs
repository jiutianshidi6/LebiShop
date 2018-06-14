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

	public interface Lebi_DT_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_DT model);
		void Update(Lebi_DT model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_DT GetModel(int id);
		Lebi_DT GetModel(string strWhere);
		Lebi_DT GetModel(SQLPara para);
		List<Lebi_DT> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_DT> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_DT> GetList(string strWhere, string strFieldOrder);
		List<Lebi_DT> GetList(SQLPara para);
		Lebi_DT BindForm(Lebi_DT model);
		Lebi_DT SafeBindForm(Lebi_DT model);
		Lebi_DT ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_DT。
	/// </summary>
	public class D_Lebi_DT
	{
		static Lebi_DT_interface _Instance;
		public static Lebi_DT_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_DT();
		            else
		                _Instance = new sqlserver_Lebi_DT();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_DT()
		{}
		#region  成员方法
	class sqlserver_Lebi_DT : Lebi_DT_interface
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
				strSql.Append("select " + colName + " from [Lebi_DT]");
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
			strSql.Append("select  "+colName+" from [Lebi_DT]");
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
			strSql.Append("select count(1) from [Lebi_DT]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_DT]");
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
			strSql.Append("select max(id) from [Lebi_DT]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_DT]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_DT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_DT](");
			strSql.Append("User_id,UserName,Email,RealName,Logo,MobilePhone,Phone,Area_id,Address,QQ,Postalcode,Msn,Count_Login,IP_Last,IP_This,Time_This,Time_Last,Time_Reg,Group_id,Status,Language,Remark,Money,UserLevel_id,Site_Name,Site_Title,Site_Keywords,Site_Description,Site_QQ,Site_Phone,Site_Email,Site_Copyright,Site_Logoimg,Product_ids,Domain,CommissionLevel)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@UserName,@Email,@RealName,@Logo,@MobilePhone,@Phone,@Area_id,@Address,@QQ,@Postalcode,@Msn,@Count_Login,@IP_Last,@IP_This,@Time_This,@Time_Last,@Time_Reg,@Group_id,@Status,@Language,@Remark,@Money,@UserLevel_id,@Site_Name,@Site_Title,@Site_Keywords,@Site_Description,@Site_QQ,@Site_Phone,@Site_Email,@Site_Copyright,@Site_Logoimg,@Product_ids,@Domain,@CommissionLevel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@UserName", model.UserName),
					new SqlParameter("@Email", model.Email),
					new SqlParameter("@RealName", model.RealName),
					new SqlParameter("@Logo", model.Logo),
					new SqlParameter("@MobilePhone", model.MobilePhone),
					new SqlParameter("@Phone", model.Phone),
					new SqlParameter("@Area_id", model.Area_id),
					new SqlParameter("@Address", model.Address),
					new SqlParameter("@QQ", model.QQ),
					new SqlParameter("@Postalcode", model.Postalcode),
					new SqlParameter("@Msn", model.Msn),
					new SqlParameter("@Count_Login", model.Count_Login),
					new SqlParameter("@IP_Last", model.IP_Last),
					new SqlParameter("@IP_This", model.IP_This),
					new SqlParameter("@Time_This", model.Time_This),
					new SqlParameter("@Time_Last", model.Time_Last),
					new SqlParameter("@Time_Reg", model.Time_Reg),
					new SqlParameter("@Group_id", model.Group_id),
					new SqlParameter("@Status", model.Status),
					new SqlParameter("@Language", model.Language),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@UserLevel_id", model.UserLevel_id),
					new SqlParameter("@Site_Name", model.Site_Name),
					new SqlParameter("@Site_Title", model.Site_Title),
					new SqlParameter("@Site_Keywords", model.Site_Keywords),
					new SqlParameter("@Site_Description", model.Site_Description),
					new SqlParameter("@Site_QQ", model.Site_QQ),
					new SqlParameter("@Site_Phone", model.Site_Phone),
					new SqlParameter("@Site_Email", model.Site_Email),
					new SqlParameter("@Site_Copyright", model.Site_Copyright),
					new SqlParameter("@Site_Logoimg", model.Site_Logoimg),
					new SqlParameter("@Product_ids", model.Product_ids),
					new SqlParameter("@Domain", model.Domain),
					new SqlParameter("@CommissionLevel", model.CommissionLevel)};

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
		public void Update(Lebi_DT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_DT] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("UserName= @UserName,");
			strSql.Append("Email= @Email,");
			strSql.Append("RealName= @RealName,");
			strSql.Append("Logo= @Logo,");
			strSql.Append("MobilePhone= @MobilePhone,");
			strSql.Append("Phone= @Phone,");
			strSql.Append("Area_id= @Area_id,");
			strSql.Append("Address= @Address,");
			strSql.Append("QQ= @QQ,");
			strSql.Append("Postalcode= @Postalcode,");
			strSql.Append("Msn= @Msn,");
			strSql.Append("Count_Login= @Count_Login,");
			strSql.Append("IP_Last= @IP_Last,");
			strSql.Append("IP_This= @IP_This,");
			strSql.Append("Time_This= @Time_This,");
			strSql.Append("Time_Last= @Time_Last,");
			strSql.Append("Time_Reg= @Time_Reg,");
			strSql.Append("Group_id= @Group_id,");
			strSql.Append("Status= @Status,");
			strSql.Append("Language= @Language,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Money= @Money,");
			strSql.Append("UserLevel_id= @UserLevel_id,");
			strSql.Append("Site_Name= @Site_Name,");
			strSql.Append("Site_Title= @Site_Title,");
			strSql.Append("Site_Keywords= @Site_Keywords,");
			strSql.Append("Site_Description= @Site_Description,");
			strSql.Append("Site_QQ= @Site_QQ,");
			strSql.Append("Site_Phone= @Site_Phone,");
			strSql.Append("Site_Email= @Site_Email,");
			strSql.Append("Site_Copyright= @Site_Copyright,");
			strSql.Append("Site_Logoimg= @Site_Logoimg,");
			strSql.Append("Product_ids= @Product_ids,");
			strSql.Append("Domain= @Domain,");
			strSql.Append("CommissionLevel= @CommissionLevel");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Logo", SqlDbType.NVarChar,50),
					new SqlParameter("@MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Area_id", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@Postalcode", SqlDbType.NVarChar,20),
					new SqlParameter("@Msn", SqlDbType.NVarChar,100),
					new SqlParameter("@Count_Login", SqlDbType.Int,4),
					new SqlParameter("@IP_Last", SqlDbType.NVarChar,20),
					new SqlParameter("@IP_This", SqlDbType.NVarChar,20),
					new SqlParameter("@Time_This", SqlDbType.DateTime),
					new SqlParameter("@Time_Last", SqlDbType.DateTime),
					new SqlParameter("@Time_Reg", SqlDbType.DateTime),
					new SqlParameter("@Group_id", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Language", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,255),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@UserLevel_id", SqlDbType.Int,4),
					new SqlParameter("@Site_Name", SqlDbType.NVarChar,2000),
					new SqlParameter("@Site_Title", SqlDbType.NVarChar,2000),
					new SqlParameter("@Site_Keywords", SqlDbType.NVarChar,2000),
					new SqlParameter("@Site_Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@Site_QQ", SqlDbType.NVarChar,2000),
					new SqlParameter("@Site_Phone", SqlDbType.NVarChar,2000),
					new SqlParameter("@Site_Email", SqlDbType.NVarChar,2000),
					new SqlParameter("@Site_Copyright", SqlDbType.NVarChar,2000),
					new SqlParameter("@Site_Logoimg", SqlDbType.NVarChar,2000),
					new SqlParameter("@Product_ids", SqlDbType.NText),
					new SqlParameter("@Domain", SqlDbType.NVarChar,100),
					new SqlParameter("@CommissionLevel", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Email;
			parameters[4].Value = model.RealName;
			parameters[5].Value = model.Logo;
			parameters[6].Value = model.MobilePhone;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.Area_id;
			parameters[9].Value = model.Address;
			parameters[10].Value = model.QQ;
			parameters[11].Value = model.Postalcode;
			parameters[12].Value = model.Msn;
			parameters[13].Value = model.Count_Login;
			parameters[14].Value = model.IP_Last;
			parameters[15].Value = model.IP_This;
			parameters[16].Value = model.Time_This;
			parameters[17].Value = model.Time_Last;
			parameters[18].Value = model.Time_Reg;
			parameters[19].Value = model.Group_id;
			parameters[20].Value = model.Status;
			parameters[21].Value = model.Language;
			parameters[22].Value = model.Remark;
			parameters[23].Value = model.Money;
			parameters[24].Value = model.UserLevel_id;
			parameters[25].Value = model.Site_Name;
			parameters[26].Value = model.Site_Title;
			parameters[27].Value = model.Site_Keywords;
			parameters[28].Value = model.Site_Description;
			parameters[29].Value = model.Site_QQ;
			parameters[30].Value = model.Site_Phone;
			parameters[31].Value = model.Site_Email;
			parameters[32].Value = model.Site_Copyright;
			parameters[33].Value = model.Site_Logoimg;
			parameters[34].Value = model.Product_ids;
			parameters[35].Value = model.Domain;
			parameters[36].Value = model.CommissionLevel;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT] ");
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
			strSql.Append("delete from [Lebi_DT] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_DT GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_DT model=new Lebi_DT();
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
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				model.Logo=ds.Tables[0].Rows[0]["Logo"].ToString();
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
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
				if(ds.Tables[0].Rows[0]["Group_id"].ToString()!="")
				{
					model.Group_id=int.Parse(ds.Tables[0].Rows[0]["Group_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
				}
				model.Site_Name=ds.Tables[0].Rows[0]["Site_Name"].ToString();
				model.Site_Title=ds.Tables[0].Rows[0]["Site_Title"].ToString();
				model.Site_Keywords=ds.Tables[0].Rows[0]["Site_Keywords"].ToString();
				model.Site_Description=ds.Tables[0].Rows[0]["Site_Description"].ToString();
				model.Site_QQ=ds.Tables[0].Rows[0]["Site_QQ"].ToString();
				model.Site_Phone=ds.Tables[0].Rows[0]["Site_Phone"].ToString();
				model.Site_Email=ds.Tables[0].Rows[0]["Site_Email"].ToString();
				model.Site_Copyright=ds.Tables[0].Rows[0]["Site_Copyright"].ToString();
				model.Site_Logoimg=ds.Tables[0].Rows[0]["Site_Logoimg"].ToString();
				model.Product_ids=ds.Tables[0].Rows[0]["Product_ids"].ToString();
				model.Domain=ds.Tables[0].Rows[0]["Domain"].ToString();
				if(ds.Tables[0].Rows[0]["CommissionLevel"].ToString()!="")
				{
					model.CommissionLevel=int.Parse(ds.Tables[0].Rows[0]["CommissionLevel"].ToString());
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
		public Lebi_DT GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_DT model=new Lebi_DT();
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
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				model.Logo=ds.Tables[0].Rows[0]["Logo"].ToString();
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
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
				if(ds.Tables[0].Rows[0]["Group_id"].ToString()!="")
				{
					model.Group_id=int.Parse(ds.Tables[0].Rows[0]["Group_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
				}
				model.Site_Name=ds.Tables[0].Rows[0]["Site_Name"].ToString();
				model.Site_Title=ds.Tables[0].Rows[0]["Site_Title"].ToString();
				model.Site_Keywords=ds.Tables[0].Rows[0]["Site_Keywords"].ToString();
				model.Site_Description=ds.Tables[0].Rows[0]["Site_Description"].ToString();
				model.Site_QQ=ds.Tables[0].Rows[0]["Site_QQ"].ToString();
				model.Site_Phone=ds.Tables[0].Rows[0]["Site_Phone"].ToString();
				model.Site_Email=ds.Tables[0].Rows[0]["Site_Email"].ToString();
				model.Site_Copyright=ds.Tables[0].Rows[0]["Site_Copyright"].ToString();
				model.Site_Logoimg=ds.Tables[0].Rows[0]["Site_Logoimg"].ToString();
				model.Product_ids=ds.Tables[0].Rows[0]["Product_ids"].ToString();
				model.Domain=ds.Tables[0].Rows[0]["Domain"].ToString();
				if(ds.Tables[0].Rows[0]["CommissionLevel"].ToString()!="")
				{
					model.CommissionLevel=int.Parse(ds.Tables[0].Rows[0]["CommissionLevel"].ToString());
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
		public Lebi_DT GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_DT] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_DT model=new Lebi_DT();
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
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				model.Logo=ds.Tables[0].Rows[0]["Logo"].ToString();
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
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
				if(ds.Tables[0].Rows[0]["Group_id"].ToString()!="")
				{
					model.Group_id=int.Parse(ds.Tables[0].Rows[0]["Group_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
				}
				model.Site_Name=ds.Tables[0].Rows[0]["Site_Name"].ToString();
				model.Site_Title=ds.Tables[0].Rows[0]["Site_Title"].ToString();
				model.Site_Keywords=ds.Tables[0].Rows[0]["Site_Keywords"].ToString();
				model.Site_Description=ds.Tables[0].Rows[0]["Site_Description"].ToString();
				model.Site_QQ=ds.Tables[0].Rows[0]["Site_QQ"].ToString();
				model.Site_Phone=ds.Tables[0].Rows[0]["Site_Phone"].ToString();
				model.Site_Email=ds.Tables[0].Rows[0]["Site_Email"].ToString();
				model.Site_Copyright=ds.Tables[0].Rows[0]["Site_Copyright"].ToString();
				model.Site_Logoimg=ds.Tables[0].Rows[0]["Site_Logoimg"].ToString();
				model.Product_ids=ds.Tables[0].Rows[0]["Product_ids"].ToString();
				model.Domain=ds.Tables[0].Rows[0]["Domain"].ToString();
				if(ds.Tables[0].Rows[0]["CommissionLevel"].ToString()!="")
				{
					model.CommissionLevel=int.Parse(ds.Tables[0].Rows[0]["CommissionLevel"].ToString());
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
		public List<Lebi_DT> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_DT]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_DT> list = new List<Lebi_DT>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_DT> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_DT]";
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
			List<Lebi_DT> list = new List<Lebi_DT>();
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
		public List<Lebi_DT> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_DT] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_DT> list = new List<Lebi_DT>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_DT> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_DT]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_DT> list = new List<Lebi_DT>();
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
		public Lebi_DT BindForm(Lebi_DT model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestString("RealName");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestString("Logo");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestString("QQ");
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
			if (HttpContext.Current.Request["Group_id"] != null)
				model.Group_id=Shop.Tools.RequestTool.RequestInt("Group_id",0);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
			if (HttpContext.Current.Request["Site_Name"] != null)
				model.Site_Name=Shop.Tools.RequestTool.RequestString("Site_Name");
			if (HttpContext.Current.Request["Site_Title"] != null)
				model.Site_Title=Shop.Tools.RequestTool.RequestString("Site_Title");
			if (HttpContext.Current.Request["Site_Keywords"] != null)
				model.Site_Keywords=Shop.Tools.RequestTool.RequestString("Site_Keywords");
			if (HttpContext.Current.Request["Site_Description"] != null)
				model.Site_Description=Shop.Tools.RequestTool.RequestString("Site_Description");
			if (HttpContext.Current.Request["Site_QQ"] != null)
				model.Site_QQ=Shop.Tools.RequestTool.RequestString("Site_QQ");
			if (HttpContext.Current.Request["Site_Phone"] != null)
				model.Site_Phone=Shop.Tools.RequestTool.RequestString("Site_Phone");
			if (HttpContext.Current.Request["Site_Email"] != null)
				model.Site_Email=Shop.Tools.RequestTool.RequestString("Site_Email");
			if (HttpContext.Current.Request["Site_Copyright"] != null)
				model.Site_Copyright=Shop.Tools.RequestTool.RequestString("Site_Copyright");
			if (HttpContext.Current.Request["Site_Logoimg"] != null)
				model.Site_Logoimg=Shop.Tools.RequestTool.RequestString("Site_Logoimg");
			if (HttpContext.Current.Request["Product_ids"] != null)
				model.Product_ids=Shop.Tools.RequestTool.RequestString("Product_ids");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestString("Domain");
			if (HttpContext.Current.Request["CommissionLevel"] != null)
				model.CommissionLevel=Shop.Tools.RequestTool.RequestInt("CommissionLevel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_DT SafeBindForm(Lebi_DT model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestSafeString("RealName");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestSafeString("Logo");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestSafeString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestSafeString("QQ");
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
			if (HttpContext.Current.Request["Group_id"] != null)
				model.Group_id=Shop.Tools.RequestTool.RequestInt("Group_id",0);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
			if (HttpContext.Current.Request["Site_Name"] != null)
				model.Site_Name=Shop.Tools.RequestTool.RequestSafeString("Site_Name");
			if (HttpContext.Current.Request["Site_Title"] != null)
				model.Site_Title=Shop.Tools.RequestTool.RequestSafeString("Site_Title");
			if (HttpContext.Current.Request["Site_Keywords"] != null)
				model.Site_Keywords=Shop.Tools.RequestTool.RequestSafeString("Site_Keywords");
			if (HttpContext.Current.Request["Site_Description"] != null)
				model.Site_Description=Shop.Tools.RequestTool.RequestSafeString("Site_Description");
			if (HttpContext.Current.Request["Site_QQ"] != null)
				model.Site_QQ=Shop.Tools.RequestTool.RequestSafeString("Site_QQ");
			if (HttpContext.Current.Request["Site_Phone"] != null)
				model.Site_Phone=Shop.Tools.RequestTool.RequestSafeString("Site_Phone");
			if (HttpContext.Current.Request["Site_Email"] != null)
				model.Site_Email=Shop.Tools.RequestTool.RequestSafeString("Site_Email");
			if (HttpContext.Current.Request["Site_Copyright"] != null)
				model.Site_Copyright=Shop.Tools.RequestTool.RequestSafeString("Site_Copyright");
			if (HttpContext.Current.Request["Site_Logoimg"] != null)
				model.Site_Logoimg=Shop.Tools.RequestTool.RequestSafeString("Site_Logoimg");
			if (HttpContext.Current.Request["Product_ids"] != null)
				model.Product_ids=Shop.Tools.RequestTool.RequestSafeString("Product_ids");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestSafeString("Domain");
			if (HttpContext.Current.Request["CommissionLevel"] != null)
				model.CommissionLevel=Shop.Tools.RequestTool.RequestInt("CommissionLevel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_DT ReaderBind(IDataReader dataReader)
		{
			Lebi_DT model=new Lebi_DT();
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
			model.UserName=dataReader["UserName"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.RealName=dataReader["RealName"].ToString();
			model.Logo=dataReader["Logo"].ToString();
			model.MobilePhone=dataReader["MobilePhone"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			model.Address=dataReader["Address"].ToString();
			model.QQ=dataReader["QQ"].ToString();
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
			ojb = dataReader["Group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Group_id=(int)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["UserLevel_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLevel_id=(int)ojb;
			}
			model.Site_Name=dataReader["Site_Name"].ToString();
			model.Site_Title=dataReader["Site_Title"].ToString();
			model.Site_Keywords=dataReader["Site_Keywords"].ToString();
			model.Site_Description=dataReader["Site_Description"].ToString();
			model.Site_QQ=dataReader["Site_QQ"].ToString();
			model.Site_Phone=dataReader["Site_Phone"].ToString();
			model.Site_Email=dataReader["Site_Email"].ToString();
			model.Site_Copyright=dataReader["Site_Copyright"].ToString();
			model.Site_Logoimg=dataReader["Site_Logoimg"].ToString();
			model.Product_ids=dataReader["Product_ids"].ToString();
			model.Domain=dataReader["Domain"].ToString();
			ojb = dataReader["CommissionLevel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CommissionLevel=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_DT : Lebi_DT_interface
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
				strSql.Append("select " + colName + " from [Lebi_DT]");
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
			strSql.Append("select  "+colName+" from [Lebi_DT]");
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
			strSql.Append("select count(*) from [Lebi_DT]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_DT]");
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
			strSql.Append("select max(id) from [Lebi_DT]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_DT]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_DT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_DT](");
			strSql.Append("[User_id],[UserName],[Email],[RealName],[Logo],[MobilePhone],[Phone],[Area_id],[Address],[QQ],[Postalcode],[Msn],[Count_Login],[IP_Last],[IP_This],[Time_This],[Time_Last],[Time_Reg],[Group_id],[Status],[Language],[Remark],[Money],[UserLevel_id],[Site_Name],[Site_Title],[Site_Keywords],[Site_Description],[Site_QQ],[Site_Phone],[Site_Email],[Site_Copyright],[Site_Logoimg],[Product_ids],[Domain],[CommissionLevel])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@UserName,@Email,@RealName,@Logo,@MobilePhone,@Phone,@Area_id,@Address,@QQ,@Postalcode,@Msn,@Count_Login,@IP_Last,@IP_This,@Time_This,@Time_Last,@Time_Reg,@Group_id,@Status,@Language,@Remark,@Money,@UserLevel_id,@Site_Name,@Site_Title,@Site_Keywords,@Site_Description,@Site_QQ,@Site_Phone,@Site_Email,@Site_Copyright,@Site_Logoimg,@Product_ids,@Domain,@CommissionLevel)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@RealName", model.RealName),
					new OleDbParameter("@Logo", model.Logo),
					new OleDbParameter("@MobilePhone", model.MobilePhone),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@QQ", model.QQ),
					new OleDbParameter("@Postalcode", model.Postalcode),
					new OleDbParameter("@Msn", model.Msn),
					new OleDbParameter("@Count_Login", model.Count_Login),
					new OleDbParameter("@IP_Last", model.IP_Last),
					new OleDbParameter("@IP_This", model.IP_This),
					new OleDbParameter("@Time_This", model.Time_This.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Last", model.Time_Last.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Reg", model.Time_Reg.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Group_id", model.Group_id),
					new OleDbParameter("@Status", model.Status),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@UserLevel_id", model.UserLevel_id),
					new OleDbParameter("@Site_Name", model.Site_Name),
					new OleDbParameter("@Site_Title", model.Site_Title),
					new OleDbParameter("@Site_Keywords", model.Site_Keywords),
					new OleDbParameter("@Site_Description", model.Site_Description),
					new OleDbParameter("@Site_QQ", model.Site_QQ),
					new OleDbParameter("@Site_Phone", model.Site_Phone),
					new OleDbParameter("@Site_Email", model.Site_Email),
					new OleDbParameter("@Site_Copyright", model.Site_Copyright),
					new OleDbParameter("@Site_Logoimg", model.Site_Logoimg),
					new OleDbParameter("@Product_ids", model.Product_ids),
					new OleDbParameter("@Domain", model.Domain),
					new OleDbParameter("@CommissionLevel", model.CommissionLevel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_DT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_DT] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[UserName]=@UserName,");
			strSql.Append("[Email]=@Email,");
			strSql.Append("[RealName]=@RealName,");
			strSql.Append("[Logo]=@Logo,");
			strSql.Append("[MobilePhone]=@MobilePhone,");
			strSql.Append("[Phone]=@Phone,");
			strSql.Append("[Area_id]=@Area_id,");
			strSql.Append("[Address]=@Address,");
			strSql.Append("[QQ]=@QQ,");
			strSql.Append("[Postalcode]=@Postalcode,");
			strSql.Append("[Msn]=@Msn,");
			strSql.Append("[Count_Login]=@Count_Login,");
			strSql.Append("[IP_Last]=@IP_Last,");
			strSql.Append("[IP_This]=@IP_This,");
			strSql.Append("[Time_This]=@Time_This,");
			strSql.Append("[Time_Last]=@Time_Last,");
			strSql.Append("[Time_Reg]=@Time_Reg,");
			strSql.Append("[Group_id]=@Group_id,");
			strSql.Append("[Status]=@Status,");
			strSql.Append("[Language]=@Language,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[UserLevel_id]=@UserLevel_id,");
			strSql.Append("[Site_Name]=@Site_Name,");
			strSql.Append("[Site_Title]=@Site_Title,");
			strSql.Append("[Site_Keywords]=@Site_Keywords,");
			strSql.Append("[Site_Description]=@Site_Description,");
			strSql.Append("[Site_QQ]=@Site_QQ,");
			strSql.Append("[Site_Phone]=@Site_Phone,");
			strSql.Append("[Site_Email]=@Site_Email,");
			strSql.Append("[Site_Copyright]=@Site_Copyright,");
			strSql.Append("[Site_Logoimg]=@Site_Logoimg,");
			strSql.Append("[Product_ids]=@Product_ids,");
			strSql.Append("[Domain]=@Domain,");
			strSql.Append("[CommissionLevel]=@CommissionLevel");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@RealName", model.RealName),
					new OleDbParameter("@Logo", model.Logo),
					new OleDbParameter("@MobilePhone", model.MobilePhone),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@QQ", model.QQ),
					new OleDbParameter("@Postalcode", model.Postalcode),
					new OleDbParameter("@Msn", model.Msn),
					new OleDbParameter("@Count_Login", model.Count_Login),
					new OleDbParameter("@IP_Last", model.IP_Last),
					new OleDbParameter("@IP_This", model.IP_This),
					new OleDbParameter("@Time_This", model.Time_This.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Last", model.Time_Last.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Reg", model.Time_Reg.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Group_id", model.Group_id),
					new OleDbParameter("@Status", model.Status),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@UserLevel_id", model.UserLevel_id),
					new OleDbParameter("@Site_Name", model.Site_Name),
					new OleDbParameter("@Site_Title", model.Site_Title),
					new OleDbParameter("@Site_Keywords", model.Site_Keywords),
					new OleDbParameter("@Site_Description", model.Site_Description),
					new OleDbParameter("@Site_QQ", model.Site_QQ),
					new OleDbParameter("@Site_Phone", model.Site_Phone),
					new OleDbParameter("@Site_Email", model.Site_Email),
					new OleDbParameter("@Site_Copyright", model.Site_Copyright),
					new OleDbParameter("@Site_Logoimg", model.Site_Logoimg),
					new OleDbParameter("@Product_ids", model.Product_ids),
					new OleDbParameter("@Domain", model.Domain),
					new OleDbParameter("@CommissionLevel", model.CommissionLevel)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT] ");
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
			strSql.Append("delete from [Lebi_DT] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_DT] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_DT GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_DT model;
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
		public Lebi_DT GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_DT] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_DT model;
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
		public Lebi_DT GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_DT] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_DT model;
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
		public List<Lebi_DT> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_DT]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_DT> list = new List<Lebi_DT>();
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
		public List<Lebi_DT> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_DT]";
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
			List<Lebi_DT> list = new List<Lebi_DT>();
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
		public List<Lebi_DT> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_DT] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_DT> list = new List<Lebi_DT>();
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
		public List<Lebi_DT> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_DT]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_DT> list = new List<Lebi_DT>();
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
		public Lebi_DT BindForm(Lebi_DT model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestString("RealName");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestString("Logo");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestString("QQ");
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
			if (HttpContext.Current.Request["Group_id"] != null)
				model.Group_id=Shop.Tools.RequestTool.RequestInt("Group_id",0);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
			if (HttpContext.Current.Request["Site_Name"] != null)
				model.Site_Name=Shop.Tools.RequestTool.RequestString("Site_Name");
			if (HttpContext.Current.Request["Site_Title"] != null)
				model.Site_Title=Shop.Tools.RequestTool.RequestString("Site_Title");
			if (HttpContext.Current.Request["Site_Keywords"] != null)
				model.Site_Keywords=Shop.Tools.RequestTool.RequestString("Site_Keywords");
			if (HttpContext.Current.Request["Site_Description"] != null)
				model.Site_Description=Shop.Tools.RequestTool.RequestString("Site_Description");
			if (HttpContext.Current.Request["Site_QQ"] != null)
				model.Site_QQ=Shop.Tools.RequestTool.RequestString("Site_QQ");
			if (HttpContext.Current.Request["Site_Phone"] != null)
				model.Site_Phone=Shop.Tools.RequestTool.RequestString("Site_Phone");
			if (HttpContext.Current.Request["Site_Email"] != null)
				model.Site_Email=Shop.Tools.RequestTool.RequestString("Site_Email");
			if (HttpContext.Current.Request["Site_Copyright"] != null)
				model.Site_Copyright=Shop.Tools.RequestTool.RequestString("Site_Copyright");
			if (HttpContext.Current.Request["Site_Logoimg"] != null)
				model.Site_Logoimg=Shop.Tools.RequestTool.RequestString("Site_Logoimg");
			if (HttpContext.Current.Request["Product_ids"] != null)
				model.Product_ids=Shop.Tools.RequestTool.RequestString("Product_ids");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestString("Domain");
			if (HttpContext.Current.Request["CommissionLevel"] != null)
				model.CommissionLevel=Shop.Tools.RequestTool.RequestInt("CommissionLevel",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_DT SafeBindForm(Lebi_DT model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestSafeString("RealName");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestSafeString("Logo");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestSafeString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestSafeString("QQ");
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
			if (HttpContext.Current.Request["Group_id"] != null)
				model.Group_id=Shop.Tools.RequestTool.RequestInt("Group_id",0);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
			if (HttpContext.Current.Request["Site_Name"] != null)
				model.Site_Name=Shop.Tools.RequestTool.RequestSafeString("Site_Name");
			if (HttpContext.Current.Request["Site_Title"] != null)
				model.Site_Title=Shop.Tools.RequestTool.RequestSafeString("Site_Title");
			if (HttpContext.Current.Request["Site_Keywords"] != null)
				model.Site_Keywords=Shop.Tools.RequestTool.RequestSafeString("Site_Keywords");
			if (HttpContext.Current.Request["Site_Description"] != null)
				model.Site_Description=Shop.Tools.RequestTool.RequestSafeString("Site_Description");
			if (HttpContext.Current.Request["Site_QQ"] != null)
				model.Site_QQ=Shop.Tools.RequestTool.RequestSafeString("Site_QQ");
			if (HttpContext.Current.Request["Site_Phone"] != null)
				model.Site_Phone=Shop.Tools.RequestTool.RequestSafeString("Site_Phone");
			if (HttpContext.Current.Request["Site_Email"] != null)
				model.Site_Email=Shop.Tools.RequestTool.RequestSafeString("Site_Email");
			if (HttpContext.Current.Request["Site_Copyright"] != null)
				model.Site_Copyright=Shop.Tools.RequestTool.RequestSafeString("Site_Copyright");
			if (HttpContext.Current.Request["Site_Logoimg"] != null)
				model.Site_Logoimg=Shop.Tools.RequestTool.RequestSafeString("Site_Logoimg");
			if (HttpContext.Current.Request["Product_ids"] != null)
				model.Product_ids=Shop.Tools.RequestTool.RequestSafeString("Product_ids");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestSafeString("Domain");
			if (HttpContext.Current.Request["CommissionLevel"] != null)
				model.CommissionLevel=Shop.Tools.RequestTool.RequestInt("CommissionLevel",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_DT ReaderBind(IDataReader dataReader)
		{
			Lebi_DT model=new Lebi_DT();
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
			model.UserName=dataReader["UserName"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.RealName=dataReader["RealName"].ToString();
			model.Logo=dataReader["Logo"].ToString();
			model.MobilePhone=dataReader["MobilePhone"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			model.Address=dataReader["Address"].ToString();
			model.QQ=dataReader["QQ"].ToString();
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
			ojb = dataReader["Group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Group_id=(int)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["UserLevel_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLevel_id=(int)ojb;
			}
			model.Site_Name=dataReader["Site_Name"].ToString();
			model.Site_Title=dataReader["Site_Title"].ToString();
			model.Site_Keywords=dataReader["Site_Keywords"].ToString();
			model.Site_Description=dataReader["Site_Description"].ToString();
			model.Site_QQ=dataReader["Site_QQ"].ToString();
			model.Site_Phone=dataReader["Site_Phone"].ToString();
			model.Site_Email=dataReader["Site_Email"].ToString();
			model.Site_Copyright=dataReader["Site_Copyright"].ToString();
			model.Site_Logoimg=dataReader["Site_Logoimg"].ToString();
			model.Product_ids=dataReader["Product_ids"].ToString();
			model.Domain=dataReader["Domain"].ToString();
			ojb = dataReader["CommissionLevel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CommissionLevel=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

