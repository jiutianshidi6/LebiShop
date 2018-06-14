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

	public interface Lebi_Administrator_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Administrator model);
		void Update(Lebi_Administrator model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Administrator GetModel(int id);
		Lebi_Administrator GetModel(string strWhere);
		Lebi_Administrator GetModel(SQLPara para);
		List<Lebi_Administrator> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Administrator> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Administrator> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Administrator> GetList(SQLPara para);
		Lebi_Administrator BindForm(Lebi_Administrator model);
		Lebi_Administrator SafeBindForm(Lebi_Administrator model);
		Lebi_Administrator ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Administrator。
	/// </summary>
	public class D_Lebi_Administrator
	{
		static Lebi_Administrator_interface _Instance;
		public static Lebi_Administrator_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Administrator();
		            else
		                _Instance = new sqlserver_Lebi_Administrator();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Administrator()
		{}
		#region  成员方法
	class sqlserver_Lebi_Administrator : Lebi_Administrator_interface
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
				strSql.Append("select " + colName + " from [Lebi_Administrator]");
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
			strSql.Append("select  "+colName+" from [Lebi_Administrator]");
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
			strSql.Append("select count(1) from [Lebi_Administrator]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Administrator]");
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
			strSql.Append("select max(id) from [Lebi_Administrator]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Administrator]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Administrator model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Administrator](");
			strSql.Append("UserName,Password,IP_Last,IP_This,Time_Add,Time_This,Time_Last,Count_Login,Type_id_AdminStatus,Admin_Group_id,RealName,ModilePhone,Phone,Email,Sex,AdminType,Site_ids,Pro_Type_ids,RandNum,Avatar)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Password,@IP_Last,@IP_This,@Time_Add,@Time_This,@Time_Last,@Count_Login,@Type_id_AdminStatus,@Admin_Group_id,@RealName,@ModilePhone,@Phone,@Email,@Sex,@AdminType,@Site_ids,@Pro_Type_ids,@RandNum,@Avatar)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", model.UserName),
					new SqlParameter("@Password", model.Password),
					new SqlParameter("@IP_Last", model.IP_Last),
					new SqlParameter("@IP_This", model.IP_This),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_This", model.Time_This),
					new SqlParameter("@Time_Last", model.Time_Last),
					new SqlParameter("@Count_Login", model.Count_Login),
					new SqlParameter("@Type_id_AdminStatus", model.Type_id_AdminStatus),
					new SqlParameter("@Admin_Group_id", model.Admin_Group_id),
					new SqlParameter("@RealName", model.RealName),
					new SqlParameter("@ModilePhone", model.ModilePhone),
					new SqlParameter("@Phone", model.Phone),
					new SqlParameter("@Email", model.Email),
					new SqlParameter("@Sex", model.Sex),
					new SqlParameter("@AdminType", model.AdminType),
					new SqlParameter("@Site_ids", model.Site_ids),
					new SqlParameter("@Pro_Type_ids", model.Pro_Type_ids),
					new SqlParameter("@RandNum", model.RandNum),
					new SqlParameter("@Avatar", model.Avatar)};

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
		public void Update(Lebi_Administrator model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Administrator] set ");
			strSql.Append("UserName= @UserName,");
			strSql.Append("Password= @Password,");
			strSql.Append("IP_Last= @IP_Last,");
			strSql.Append("IP_This= @IP_This,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_This= @Time_This,");
			strSql.Append("Time_Last= @Time_Last,");
			strSql.Append("Count_Login= @Count_Login,");
			strSql.Append("Type_id_AdminStatus= @Type_id_AdminStatus,");
			strSql.Append("Admin_Group_id= @Admin_Group_id,");
			strSql.Append("RealName= @RealName,");
			strSql.Append("ModilePhone= @ModilePhone,");
			strSql.Append("Phone= @Phone,");
			strSql.Append("Email= @Email,");
			strSql.Append("Sex= @Sex,");
			strSql.Append("AdminType= @AdminType,");
			strSql.Append("Site_ids= @Site_ids,");
			strSql.Append("Pro_Type_ids= @Pro_Type_ids,");
			strSql.Append("RandNum= @RandNum,");
			strSql.Append("Avatar= @Avatar");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@IP_Last", SqlDbType.NVarChar,50),
					new SqlParameter("@IP_This", SqlDbType.NVarChar,50),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_This", SqlDbType.DateTime),
					new SqlParameter("@Time_Last", SqlDbType.DateTime),
					new SqlParameter("@Count_Login", SqlDbType.Int,4),
					new SqlParameter("@Type_id_AdminStatus", SqlDbType.Int,4),
					new SqlParameter("@Admin_Group_id", SqlDbType.Int,4),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@ModilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@AdminType", SqlDbType.NVarChar,50),
					new SqlParameter("@Site_ids", SqlDbType.NVarChar,200),
					new SqlParameter("@Pro_Type_ids", SqlDbType.NVarChar,200),
					new SqlParameter("@RandNum", SqlDbType.Int,4),
					new SqlParameter("@Avatar", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.IP_Last;
			parameters[4].Value = model.IP_This;
			parameters[5].Value = model.Time_Add;
			parameters[6].Value = model.Time_This;
			parameters[7].Value = model.Time_Last;
			parameters[8].Value = model.Count_Login;
			parameters[9].Value = model.Type_id_AdminStatus;
			parameters[10].Value = model.Admin_Group_id;
			parameters[11].Value = model.RealName;
			parameters[12].Value = model.ModilePhone;
			parameters[13].Value = model.Phone;
			parameters[14].Value = model.Email;
			parameters[15].Value = model.Sex;
			parameters[16].Value = model.AdminType;
			parameters[17].Value = model.Site_ids;
			parameters[18].Value = model.Pro_Type_ids;
			parameters[19].Value = model.RandNum;
			parameters[20].Value = model.Avatar;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Administrator] ");
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
			strSql.Append("delete from [Lebi_Administrator] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Administrator] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Administrator GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Administrator] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Administrator model=new Lebi_Administrator();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.IP_Last=ds.Tables[0].Rows[0]["IP_Last"].ToString();
				model.IP_This=ds.Tables[0].Rows[0]["IP_This"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_This"].ToString()!="")
				{
					model.Time_This=DateTime.Parse(ds.Tables[0].Rows[0]["Time_This"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Last"].ToString()!="")
				{
					model.Time_Last=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Last"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Login"].ToString()!="")
				{
					model.Count_Login=int.Parse(ds.Tables[0].Rows[0]["Count_Login"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AdminStatus"].ToString()!="")
				{
					model.Type_id_AdminStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_AdminStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_Group_id"].ToString()!="")
				{
					model.Admin_Group_id=int.Parse(ds.Tables[0].Rows[0]["Admin_Group_id"].ToString());
				}
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				model.ModilePhone=ds.Tables[0].Rows[0]["ModilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				model.AdminType=ds.Tables[0].Rows[0]["AdminType"].ToString();
				model.Site_ids=ds.Tables[0].Rows[0]["Site_ids"].ToString();
				model.Pro_Type_ids=ds.Tables[0].Rows[0]["Pro_Type_ids"].ToString();
				if(ds.Tables[0].Rows[0]["RandNum"].ToString()!="")
				{
					model.RandNum=int.Parse(ds.Tables[0].Rows[0]["RandNum"].ToString());
				}
				model.Avatar=ds.Tables[0].Rows[0]["Avatar"].ToString();
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
		public Lebi_Administrator GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Administrator] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Administrator model=new Lebi_Administrator();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.IP_Last=ds.Tables[0].Rows[0]["IP_Last"].ToString();
				model.IP_This=ds.Tables[0].Rows[0]["IP_This"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_This"].ToString()!="")
				{
					model.Time_This=DateTime.Parse(ds.Tables[0].Rows[0]["Time_This"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Last"].ToString()!="")
				{
					model.Time_Last=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Last"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Login"].ToString()!="")
				{
					model.Count_Login=int.Parse(ds.Tables[0].Rows[0]["Count_Login"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AdminStatus"].ToString()!="")
				{
					model.Type_id_AdminStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_AdminStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_Group_id"].ToString()!="")
				{
					model.Admin_Group_id=int.Parse(ds.Tables[0].Rows[0]["Admin_Group_id"].ToString());
				}
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				model.ModilePhone=ds.Tables[0].Rows[0]["ModilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				model.AdminType=ds.Tables[0].Rows[0]["AdminType"].ToString();
				model.Site_ids=ds.Tables[0].Rows[0]["Site_ids"].ToString();
				model.Pro_Type_ids=ds.Tables[0].Rows[0]["Pro_Type_ids"].ToString();
				if(ds.Tables[0].Rows[0]["RandNum"].ToString()!="")
				{
					model.RandNum=int.Parse(ds.Tables[0].Rows[0]["RandNum"].ToString());
				}
				model.Avatar=ds.Tables[0].Rows[0]["Avatar"].ToString();
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
		public Lebi_Administrator GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Administrator] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Administrator model=new Lebi_Administrator();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.IP_Last=ds.Tables[0].Rows[0]["IP_Last"].ToString();
				model.IP_This=ds.Tables[0].Rows[0]["IP_This"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_This"].ToString()!="")
				{
					model.Time_This=DateTime.Parse(ds.Tables[0].Rows[0]["Time_This"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Last"].ToString()!="")
				{
					model.Time_Last=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Last"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Count_Login"].ToString()!="")
				{
					model.Count_Login=int.Parse(ds.Tables[0].Rows[0]["Count_Login"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_AdminStatus"].ToString()!="")
				{
					model.Type_id_AdminStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_AdminStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_Group_id"].ToString()!="")
				{
					model.Admin_Group_id=int.Parse(ds.Tables[0].Rows[0]["Admin_Group_id"].ToString());
				}
				model.RealName=ds.Tables[0].Rows[0]["RealName"].ToString();
				model.ModilePhone=ds.Tables[0].Rows[0]["ModilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				model.AdminType=ds.Tables[0].Rows[0]["AdminType"].ToString();
				model.Site_ids=ds.Tables[0].Rows[0]["Site_ids"].ToString();
				model.Pro_Type_ids=ds.Tables[0].Rows[0]["Pro_Type_ids"].ToString();
				if(ds.Tables[0].Rows[0]["RandNum"].ToString()!="")
				{
					model.RandNum=int.Parse(ds.Tables[0].Rows[0]["RandNum"].ToString());
				}
				model.Avatar=ds.Tables[0].Rows[0]["Avatar"].ToString();
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
		public List<Lebi_Administrator> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Administrator]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Administrator> list = new List<Lebi_Administrator>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Administrator> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Administrator]";
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
			List<Lebi_Administrator> list = new List<Lebi_Administrator>();
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
		public List<Lebi_Administrator> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Administrator] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Administrator> list = new List<Lebi_Administrator>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Administrator> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Administrator]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Administrator> list = new List<Lebi_Administrator>();
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
		public Lebi_Administrator BindForm(Lebi_Administrator model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestString("Password");
			if (HttpContext.Current.Request["IP_Last"] != null)
				model.IP_Last=Shop.Tools.RequestTool.RequestString("IP_Last");
			if (HttpContext.Current.Request["IP_This"] != null)
				model.IP_This=Shop.Tools.RequestTool.RequestString("IP_This");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_This"] != null)
				model.Time_This=Shop.Tools.RequestTool.RequestTime("Time_This", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Last"] != null)
				model.Time_Last=Shop.Tools.RequestTool.RequestTime("Time_Last", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Login"] != null)
				model.Count_Login=Shop.Tools.RequestTool.RequestInt("Count_Login",0);
			if (HttpContext.Current.Request["Type_id_AdminStatus"] != null)
				model.Type_id_AdminStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AdminStatus",0);
			if (HttpContext.Current.Request["Admin_Group_id"] != null)
				model.Admin_Group_id=Shop.Tools.RequestTool.RequestInt("Admin_Group_id",0);
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestString("RealName");
			if (HttpContext.Current.Request["ModilePhone"] != null)
				model.ModilePhone=Shop.Tools.RequestTool.RequestString("ModilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestString("Sex");
			if (HttpContext.Current.Request["AdminType"] != null)
				model.AdminType=Shop.Tools.RequestTool.RequestString("AdminType");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestString("Site_ids");
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestString("Pro_Type_ids");
			if (HttpContext.Current.Request["RandNum"] != null)
				model.RandNum=Shop.Tools.RequestTool.RequestInt("RandNum",0);
			if (HttpContext.Current.Request["Avatar"] != null)
				model.Avatar=Shop.Tools.RequestTool.RequestString("Avatar");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Administrator SafeBindForm(Lebi_Administrator model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestSafeString("Password");
			if (HttpContext.Current.Request["IP_Last"] != null)
				model.IP_Last=Shop.Tools.RequestTool.RequestSafeString("IP_Last");
			if (HttpContext.Current.Request["IP_This"] != null)
				model.IP_This=Shop.Tools.RequestTool.RequestSafeString("IP_This");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_This"] != null)
				model.Time_This=Shop.Tools.RequestTool.RequestTime("Time_This", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Last"] != null)
				model.Time_Last=Shop.Tools.RequestTool.RequestTime("Time_Last", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Login"] != null)
				model.Count_Login=Shop.Tools.RequestTool.RequestInt("Count_Login",0);
			if (HttpContext.Current.Request["Type_id_AdminStatus"] != null)
				model.Type_id_AdminStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AdminStatus",0);
			if (HttpContext.Current.Request["Admin_Group_id"] != null)
				model.Admin_Group_id=Shop.Tools.RequestTool.RequestInt("Admin_Group_id",0);
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestSafeString("RealName");
			if (HttpContext.Current.Request["ModilePhone"] != null)
				model.ModilePhone=Shop.Tools.RequestTool.RequestSafeString("ModilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestSafeString("Sex");
			if (HttpContext.Current.Request["AdminType"] != null)
				model.AdminType=Shop.Tools.RequestTool.RequestSafeString("AdminType");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestSafeString("Site_ids");
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestSafeString("Pro_Type_ids");
			if (HttpContext.Current.Request["RandNum"] != null)
				model.RandNum=Shop.Tools.RequestTool.RequestInt("RandNum",0);
			if (HttpContext.Current.Request["Avatar"] != null)
				model.Avatar=Shop.Tools.RequestTool.RequestSafeString("Avatar");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Administrator ReaderBind(IDataReader dataReader)
		{
			Lebi_Administrator model=new Lebi_Administrator();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.Password=dataReader["Password"].ToString();
			model.IP_Last=dataReader["IP_Last"].ToString();
			model.IP_This=dataReader["IP_This"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
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
			ojb = dataReader["Count_Login"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Login=(int)ojb;
			}
			ojb = dataReader["Type_id_AdminStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_AdminStatus=(int)ojb;
			}
			ojb = dataReader["Admin_Group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_Group_id=(int)ojb;
			}
			model.RealName=dataReader["RealName"].ToString();
			model.ModilePhone=dataReader["ModilePhone"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.Sex=dataReader["Sex"].ToString();
			model.AdminType=dataReader["AdminType"].ToString();
			model.Site_ids=dataReader["Site_ids"].ToString();
			model.Pro_Type_ids=dataReader["Pro_Type_ids"].ToString();
			ojb = dataReader["RandNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RandNum=(int)ojb;
			}
			model.Avatar=dataReader["Avatar"].ToString();
			return model;
		}

	}
	class access_Lebi_Administrator : Lebi_Administrator_interface
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
				strSql.Append("select " + colName + " from [Lebi_Administrator]");
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
			strSql.Append("select  "+colName+" from [Lebi_Administrator]");
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
			strSql.Append("select count(*) from [Lebi_Administrator]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Administrator]");
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
			strSql.Append("select max(id) from [Lebi_Administrator]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Administrator]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Administrator model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Administrator](");
			strSql.Append("[UserName],[Password],[IP_Last],[IP_This],[Time_Add],[Time_This],[Time_Last],[Count_Login],[Type_id_AdminStatus],[Admin_Group_id],[RealName],[ModilePhone],[Phone],[Email],[Sex],[AdminType],[Site_ids],[Pro_Type_ids],[RandNum],[Avatar])");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Password,@IP_Last,@IP_This,@Time_Add,@Time_This,@Time_Last,@Count_Login,@Type_id_AdminStatus,@Admin_Group_id,@RealName,@ModilePhone,@Phone,@Email,@Sex,@AdminType,@Site_ids,@Pro_Type_ids,@RandNum,@Avatar)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Password", model.Password),
					new OleDbParameter("@IP_Last", model.IP_Last),
					new OleDbParameter("@IP_This", model.IP_This),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_This", model.Time_This.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Last", model.Time_Last.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Count_Login", model.Count_Login),
					new OleDbParameter("@Type_id_AdminStatus", model.Type_id_AdminStatus),
					new OleDbParameter("@Admin_Group_id", model.Admin_Group_id),
					new OleDbParameter("@RealName", model.RealName),
					new OleDbParameter("@ModilePhone", model.ModilePhone),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@Sex", model.Sex),
					new OleDbParameter("@AdminType", model.AdminType),
					new OleDbParameter("@Site_ids", model.Site_ids),
					new OleDbParameter("@Pro_Type_ids", model.Pro_Type_ids),
					new OleDbParameter("@RandNum", model.RandNum),
					new OleDbParameter("@Avatar", model.Avatar)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Administrator model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Administrator] set ");
			strSql.Append("[UserName]=@UserName,");
			strSql.Append("[Password]=@Password,");
			strSql.Append("[IP_Last]=@IP_Last,");
			strSql.Append("[IP_This]=@IP_This,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_This]=@Time_This,");
			strSql.Append("[Time_Last]=@Time_Last,");
			strSql.Append("[Count_Login]=@Count_Login,");
			strSql.Append("[Type_id_AdminStatus]=@Type_id_AdminStatus,");
			strSql.Append("[Admin_Group_id]=@Admin_Group_id,");
			strSql.Append("[RealName]=@RealName,");
			strSql.Append("[ModilePhone]=@ModilePhone,");
			strSql.Append("[Phone]=@Phone,");
			strSql.Append("[Email]=@Email,");
			strSql.Append("[Sex]=@Sex,");
			strSql.Append("[AdminType]=@AdminType,");
			strSql.Append("[Site_ids]=@Site_ids,");
			strSql.Append("[Pro_Type_ids]=@Pro_Type_ids,");
			strSql.Append("[RandNum]=@RandNum,");
			strSql.Append("[Avatar]=@Avatar");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Password", model.Password),
					new OleDbParameter("@IP_Last", model.IP_Last),
					new OleDbParameter("@IP_This", model.IP_This),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_This", model.Time_This.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Time_Last", model.Time_Last.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@Count_Login", model.Count_Login),
					new OleDbParameter("@Type_id_AdminStatus", model.Type_id_AdminStatus),
					new OleDbParameter("@Admin_Group_id", model.Admin_Group_id),
					new OleDbParameter("@RealName", model.RealName),
					new OleDbParameter("@ModilePhone", model.ModilePhone),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@Sex", model.Sex),
					new OleDbParameter("@AdminType", model.AdminType),
					new OleDbParameter("@Site_ids", model.Site_ids),
					new OleDbParameter("@Pro_Type_ids", model.Pro_Type_ids),
					new OleDbParameter("@RandNum", model.RandNum),
					new OleDbParameter("@Avatar", model.Avatar)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Administrator] ");
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
			strSql.Append("delete from [Lebi_Administrator] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Administrator] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Administrator GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Administrator] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Administrator model;
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
		public Lebi_Administrator GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Administrator] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Administrator model;
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
		public Lebi_Administrator GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Administrator] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Administrator model;
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
		public List<Lebi_Administrator> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Administrator]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Administrator> list = new List<Lebi_Administrator>();
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
		public List<Lebi_Administrator> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Administrator]";
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
			List<Lebi_Administrator> list = new List<Lebi_Administrator>();
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
		public List<Lebi_Administrator> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Administrator] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Administrator> list = new List<Lebi_Administrator>();
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
		public List<Lebi_Administrator> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Administrator]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Administrator> list = new List<Lebi_Administrator>();
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
		public Lebi_Administrator BindForm(Lebi_Administrator model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestString("Password");
			if (HttpContext.Current.Request["IP_Last"] != null)
				model.IP_Last=Shop.Tools.RequestTool.RequestString("IP_Last");
			if (HttpContext.Current.Request["IP_This"] != null)
				model.IP_This=Shop.Tools.RequestTool.RequestString("IP_This");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_This"] != null)
				model.Time_This=Shop.Tools.RequestTool.RequestTime("Time_This", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Last"] != null)
				model.Time_Last=Shop.Tools.RequestTool.RequestTime("Time_Last", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Login"] != null)
				model.Count_Login=Shop.Tools.RequestTool.RequestInt("Count_Login",0);
			if (HttpContext.Current.Request["Type_id_AdminStatus"] != null)
				model.Type_id_AdminStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AdminStatus",0);
			if (HttpContext.Current.Request["Admin_Group_id"] != null)
				model.Admin_Group_id=Shop.Tools.RequestTool.RequestInt("Admin_Group_id",0);
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestString("RealName");
			if (HttpContext.Current.Request["ModilePhone"] != null)
				model.ModilePhone=Shop.Tools.RequestTool.RequestString("ModilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestString("Sex");
			if (HttpContext.Current.Request["AdminType"] != null)
				model.AdminType=Shop.Tools.RequestTool.RequestString("AdminType");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestString("Site_ids");
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestString("Pro_Type_ids");
			if (HttpContext.Current.Request["RandNum"] != null)
				model.RandNum=Shop.Tools.RequestTool.RequestInt("RandNum",0);
			if (HttpContext.Current.Request["Avatar"] != null)
				model.Avatar=Shop.Tools.RequestTool.RequestString("Avatar");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Administrator SafeBindForm(Lebi_Administrator model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestSafeString("Password");
			if (HttpContext.Current.Request["IP_Last"] != null)
				model.IP_Last=Shop.Tools.RequestTool.RequestSafeString("IP_Last");
			if (HttpContext.Current.Request["IP_This"] != null)
				model.IP_This=Shop.Tools.RequestTool.RequestSafeString("IP_This");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_This"] != null)
				model.Time_This=Shop.Tools.RequestTool.RequestTime("Time_This", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Last"] != null)
				model.Time_Last=Shop.Tools.RequestTool.RequestTime("Time_Last", System.DateTime.Now);
			if (HttpContext.Current.Request["Count_Login"] != null)
				model.Count_Login=Shop.Tools.RequestTool.RequestInt("Count_Login",0);
			if (HttpContext.Current.Request["Type_id_AdminStatus"] != null)
				model.Type_id_AdminStatus=Shop.Tools.RequestTool.RequestInt("Type_id_AdminStatus",0);
			if (HttpContext.Current.Request["Admin_Group_id"] != null)
				model.Admin_Group_id=Shop.Tools.RequestTool.RequestInt("Admin_Group_id",0);
			if (HttpContext.Current.Request["RealName"] != null)
				model.RealName=Shop.Tools.RequestTool.RequestSafeString("RealName");
			if (HttpContext.Current.Request["ModilePhone"] != null)
				model.ModilePhone=Shop.Tools.RequestTool.RequestSafeString("ModilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["Sex"] != null)
				model.Sex=Shop.Tools.RequestTool.RequestSafeString("Sex");
			if (HttpContext.Current.Request["AdminType"] != null)
				model.AdminType=Shop.Tools.RequestTool.RequestSafeString("AdminType");
			if (HttpContext.Current.Request["Site_ids"] != null)
				model.Site_ids=Shop.Tools.RequestTool.RequestSafeString("Site_ids");
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestSafeString("Pro_Type_ids");
			if (HttpContext.Current.Request["RandNum"] != null)
				model.RandNum=Shop.Tools.RequestTool.RequestInt("RandNum",0);
			if (HttpContext.Current.Request["Avatar"] != null)
				model.Avatar=Shop.Tools.RequestTool.RequestSafeString("Avatar");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Administrator ReaderBind(IDataReader dataReader)
		{
			Lebi_Administrator model=new Lebi_Administrator();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.Password=dataReader["Password"].ToString();
			model.IP_Last=dataReader["IP_Last"].ToString();
			model.IP_This=dataReader["IP_This"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
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
			ojb = dataReader["Count_Login"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Count_Login=(int)ojb;
			}
			ojb = dataReader["Type_id_AdminStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_AdminStatus=(int)ojb;
			}
			ojb = dataReader["Admin_Group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_Group_id=(int)ojb;
			}
			model.RealName=dataReader["RealName"].ToString();
			model.ModilePhone=dataReader["ModilePhone"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.Sex=dataReader["Sex"].ToString();
			model.AdminType=dataReader["AdminType"].ToString();
			model.Site_ids=dataReader["Site_ids"].ToString();
			model.Pro_Type_ids=dataReader["Pro_Type_ids"].ToString();
			ojb = dataReader["RandNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RandNum=(int)ojb;
			}
			model.Avatar=dataReader["Avatar"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

