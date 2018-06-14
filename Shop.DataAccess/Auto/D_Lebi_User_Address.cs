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

	public interface Lebi_User_Address_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_User_Address model);
		void Update(Lebi_User_Address model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_User_Address GetModel(int id);
		Lebi_User_Address GetModel(string strWhere);
		Lebi_User_Address GetModel(SQLPara para);
		List<Lebi_User_Address> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_User_Address> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_User_Address> GetList(string strWhere, string strFieldOrder);
		List<Lebi_User_Address> GetList(SQLPara para);
		Lebi_User_Address BindForm(Lebi_User_Address model);
		Lebi_User_Address SafeBindForm(Lebi_User_Address model);
		Lebi_User_Address ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_User_Address。
	/// </summary>
	public class D_Lebi_User_Address
	{
		static Lebi_User_Address_interface _Instance;
		public static Lebi_User_Address_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_User_Address();
		            else
		                _Instance = new sqlserver_Lebi_User_Address();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_User_Address()
		{}
		#region  成员方法
	class sqlserver_Lebi_User_Address : Lebi_User_Address_interface
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
				strSql.Append("select " + colName + " from [Lebi_User_Address]");
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
			strSql.Append("select  "+colName+" from [Lebi_User_Address]");
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
			strSql.Append("select count(1) from [Lebi_User_Address]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User_Address]");
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
			strSql.Append("select max(id) from [Lebi_User_Address]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User_Address]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_User_Address model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_User_Address](");
			strSql.Append("User_id,Name,Email,MobilePhone,Phone,Area_id,Address,Say,Postalcode)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Name,@Email,@MobilePhone,@Phone,@Area_id,@Address,@Say,@Postalcode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Email", model.Email),
					new SqlParameter("@MobilePhone", model.MobilePhone),
					new SqlParameter("@Phone", model.Phone),
					new SqlParameter("@Area_id", model.Area_id),
					new SqlParameter("@Address", model.Address),
					new SqlParameter("@Say", model.Say),
					new SqlParameter("@Postalcode", model.Postalcode)};

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
		public void Update(Lebi_User_Address model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_User_Address] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("Name= @Name,");
			strSql.Append("Email= @Email,");
			strSql.Append("MobilePhone= @MobilePhone,");
			strSql.Append("Phone= @Phone,");
			strSql.Append("Area_id= @Area_id,");
			strSql.Append("Address= @Address,");
			strSql.Append("Say= @Say,");
			strSql.Append("Postalcode= @Postalcode");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,255),
					new SqlParameter("@MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Area_id", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@Say", SqlDbType.NVarChar,200),
					new SqlParameter("@Postalcode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Email;
			parameters[4].Value = model.MobilePhone;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.Area_id;
			parameters[7].Value = model.Address;
			parameters[8].Value = model.Say;
			parameters[9].Value = model.Postalcode;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Address] ");
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
			strSql.Append("delete from [Lebi_User_Address] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Address] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_User_Address GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Address] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_User_Address model=new Lebi_User_Address();
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
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.Say=ds.Tables[0].Rows[0]["Say"].ToString();
				model.Postalcode=ds.Tables[0].Rows[0]["Postalcode"].ToString();
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
		public Lebi_User_Address GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Address] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_User_Address model=new Lebi_User_Address();
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
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.Say=ds.Tables[0].Rows[0]["Say"].ToString();
				model.Postalcode=ds.Tables[0].Rows[0]["Postalcode"].ToString();
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
		public Lebi_User_Address GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_User_Address] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_User_Address model=new Lebi_User_Address();
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
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.MobilePhone=ds.Tables[0].Rows[0]["MobilePhone"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.Say=ds.Tables[0].Rows[0]["Say"].ToString();
				model.Postalcode=ds.Tables[0].Rows[0]["Postalcode"].ToString();
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
		public List<Lebi_User_Address> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_User_Address]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_User_Address> list = new List<Lebi_User_Address>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_User_Address> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_User_Address]";
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
			List<Lebi_User_Address> list = new List<Lebi_User_Address>();
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
		public List<Lebi_User_Address> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_User_Address] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_User_Address> list = new List<Lebi_User_Address>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_User_Address> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_User_Address]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_User_Address> list = new List<Lebi_User_Address>();
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
		public Lebi_User_Address BindForm(Lebi_User_Address model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["Say"] != null)
				model.Say=Shop.Tools.RequestTool.RequestString("Say");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestString("Postalcode");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_User_Address SafeBindForm(Lebi_User_Address model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestSafeString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["Say"] != null)
				model.Say=Shop.Tools.RequestTool.RequestSafeString("Say");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestSafeString("Postalcode");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_User_Address ReaderBind(IDataReader dataReader)
		{
			Lebi_User_Address model=new Lebi_User_Address();
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
			model.Name=dataReader["Name"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.MobilePhone=dataReader["MobilePhone"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			model.Address=dataReader["Address"].ToString();
			model.Say=dataReader["Say"].ToString();
			model.Postalcode=dataReader["Postalcode"].ToString();
			return model;
		}

	}
	class access_Lebi_User_Address : Lebi_User_Address_interface
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
				strSql.Append("select " + colName + " from [Lebi_User_Address]");
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
			strSql.Append("select  "+colName+" from [Lebi_User_Address]");
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
			strSql.Append("select count(*) from [Lebi_User_Address]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_User_Address]");
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
			strSql.Append("select max(id) from [Lebi_User_Address]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User_Address]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_User_Address model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_User_Address](");
			strSql.Append("[User_id],[Name],[Email],[MobilePhone],[Phone],[Area_id],[Address],[Say],[Postalcode])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Name,@Email,@MobilePhone,@Phone,@Area_id,@Address,@Say,@Postalcode)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@MobilePhone", model.MobilePhone),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@Say", model.Say),
					new OleDbParameter("@Postalcode", model.Postalcode)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_User_Address model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_User_Address] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Email]=@Email,");
			strSql.Append("[MobilePhone]=@MobilePhone,");
			strSql.Append("[Phone]=@Phone,");
			strSql.Append("[Area_id]=@Area_id,");
			strSql.Append("[Address]=@Address,");
			strSql.Append("[Say]=@Say,");
			strSql.Append("[Postalcode]=@Postalcode");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@MobilePhone", model.MobilePhone),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@Say", model.Say),
					new OleDbParameter("@Postalcode", model.Postalcode)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Address] ");
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
			strSql.Append("delete from [Lebi_User_Address] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Address] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_User_Address GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Address] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_User_Address model;
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
		public Lebi_User_Address GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Address] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_User_Address model;
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
		public Lebi_User_Address GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_User_Address] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_User_Address model;
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
		public List<Lebi_User_Address> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_User_Address]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_User_Address> list = new List<Lebi_User_Address>();
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
		public List<Lebi_User_Address> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_User_Address]";
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
			List<Lebi_User_Address> list = new List<Lebi_User_Address>();
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
		public List<Lebi_User_Address> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_User_Address] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_User_Address> list = new List<Lebi_User_Address>();
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
		public List<Lebi_User_Address> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_User_Address]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_User_Address> list = new List<Lebi_User_Address>();
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
		public Lebi_User_Address BindForm(Lebi_User_Address model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["Say"] != null)
				model.Say=Shop.Tools.RequestTool.RequestString("Say");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestString("Postalcode");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_User_Address SafeBindForm(Lebi_User_Address model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["MobilePhone"] != null)
				model.MobilePhone=Shop.Tools.RequestTool.RequestSafeString("MobilePhone");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["Say"] != null)
				model.Say=Shop.Tools.RequestTool.RequestSafeString("Say");
			if (HttpContext.Current.Request["Postalcode"] != null)
				model.Postalcode=Shop.Tools.RequestTool.RequestSafeString("Postalcode");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_User_Address ReaderBind(IDataReader dataReader)
		{
			Lebi_User_Address model=new Lebi_User_Address();
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
			model.Name=dataReader["Name"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.MobilePhone=dataReader["MobilePhone"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			model.Address=dataReader["Address"].ToString();
			model.Say=dataReader["Say"].ToString();
			model.Postalcode=dataReader["Postalcode"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

