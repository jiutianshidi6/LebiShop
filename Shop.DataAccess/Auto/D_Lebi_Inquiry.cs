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

	public interface Lebi_Inquiry_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Inquiry model);
		void Update(Lebi_Inquiry model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Inquiry GetModel(int id);
		Lebi_Inquiry GetModel(string strWhere);
		Lebi_Inquiry GetModel(SQLPara para);
		List<Lebi_Inquiry> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Inquiry> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Inquiry> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Inquiry> GetList(SQLPara para);
		Lebi_Inquiry BindForm(Lebi_Inquiry model);
		Lebi_Inquiry SafeBindForm(Lebi_Inquiry model);
		Lebi_Inquiry ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Inquiry。
	/// </summary>
	public class D_Lebi_Inquiry
	{
		static Lebi_Inquiry_interface _Instance;
		public static Lebi_Inquiry_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Inquiry();
		            else
		                _Instance = new sqlserver_Lebi_Inquiry();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Inquiry()
		{}
		#region  成员方法
	class sqlserver_Lebi_Inquiry : Lebi_Inquiry_interface
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
				strSql.Append("select " + colName + " from [Lebi_Inquiry]");
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
			strSql.Append("select  "+colName+" from [Lebi_Inquiry]");
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
			strSql.Append("select count(1) from [Lebi_Inquiry]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Inquiry]");
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
			strSql.Append("select max(id) from [Lebi_Inquiry]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Inquiry]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Inquiry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Inquiry](");
			strSql.Append("UserName,Email,Subject,Content,Type_id_InquiryStatus,Time_Add,Time_Update,Language,Phone)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Email,@Subject,@Content,@Type_id_InquiryStatus,@Time_Add,@Time_Update,@Language,@Phone)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", model.UserName),
					new SqlParameter("@Email", model.Email),
					new SqlParameter("@Subject", model.Subject),
					new SqlParameter("@Content", model.Content),
					new SqlParameter("@Type_id_InquiryStatus", model.Type_id_InquiryStatus),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Update", model.Time_Update),
					new SqlParameter("@Language", model.Language),
					new SqlParameter("@Phone", model.Phone)};

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
		public void Update(Lebi_Inquiry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Inquiry] set ");
			strSql.Append("UserName= @UserName,");
			strSql.Append("Email= @Email,");
			strSql.Append("Subject= @Subject,");
			strSql.Append("Content= @Content,");
			strSql.Append("Type_id_InquiryStatus= @Type_id_InquiryStatus,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Update= @Time_Update,");
			strSql.Append("Language= @Language,");
			strSql.Append("Phone= @Phone");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Email", SqlDbType.NVarChar,255),
					new SqlParameter("@Subject", SqlDbType.NVarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Type_id_InquiryStatus", SqlDbType.Int,4),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Update", SqlDbType.DateTime),
					new SqlParameter("@Language", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Email;
			parameters[3].Value = model.Subject;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.Type_id_InquiryStatus;
			parameters[6].Value = model.Time_Add;
			parameters[7].Value = model.Time_Update;
			parameters[8].Value = model.Language;
			parameters[9].Value = model.Phone;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Inquiry] ");
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
			strSql.Append("delete from [Lebi_Inquiry] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Inquiry] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Inquiry GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Inquiry] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Inquiry model=new Lebi_Inquiry();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Subject=ds.Tables[0].Rows[0]["Subject"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_InquiryStatus"].ToString()!="")
				{
					model.Type_id_InquiryStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_InquiryStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
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
		public Lebi_Inquiry GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Inquiry] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Inquiry model=new Lebi_Inquiry();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Subject=ds.Tables[0].Rows[0]["Subject"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_InquiryStatus"].ToString()!="")
				{
					model.Type_id_InquiryStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_InquiryStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
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
		public Lebi_Inquiry GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Inquiry] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Inquiry model=new Lebi_Inquiry();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Subject=ds.Tables[0].Rows[0]["Subject"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Type_id_InquiryStatus"].ToString()!="")
				{
					model.Type_id_InquiryStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_InquiryStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
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
		public List<Lebi_Inquiry> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Inquiry]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Inquiry> list = new List<Lebi_Inquiry>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Inquiry> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Inquiry]";
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
			List<Lebi_Inquiry> list = new List<Lebi_Inquiry>();
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
		public List<Lebi_Inquiry> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Inquiry] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Inquiry> list = new List<Lebi_Inquiry>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Inquiry> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Inquiry]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Inquiry> list = new List<Lebi_Inquiry>();
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
		public Lebi_Inquiry BindForm(Lebi_Inquiry model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["Subject"] != null)
				model.Subject=Shop.Tools.RequestTool.RequestString("Subject");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Type_id_InquiryStatus"] != null)
				model.Type_id_InquiryStatus=Shop.Tools.RequestTool.RequestInt("Type_id_InquiryStatus",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Inquiry SafeBindForm(Lebi_Inquiry model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["Subject"] != null)
				model.Subject=Shop.Tools.RequestTool.RequestSafeString("Subject");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Type_id_InquiryStatus"] != null)
				model.Type_id_InquiryStatus=Shop.Tools.RequestTool.RequestInt("Type_id_InquiryStatus",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Inquiry ReaderBind(IDataReader dataReader)
		{
			Lebi_Inquiry model=new Lebi_Inquiry();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.Subject=dataReader["Subject"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Type_id_InquiryStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_InquiryStatus=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Update=(DateTime)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			return model;
		}

	}
	class access_Lebi_Inquiry : Lebi_Inquiry_interface
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
				strSql.Append("select " + colName + " from [Lebi_Inquiry]");
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
			strSql.Append("select  "+colName+" from [Lebi_Inquiry]");
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
			strSql.Append("select count(*) from [Lebi_Inquiry]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Inquiry]");
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
			strSql.Append("select max(id) from [Lebi_Inquiry]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Inquiry]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Inquiry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Inquiry](");
			strSql.Append("[UserName],[Email],[Subject],[Content],[Type_id_InquiryStatus],[Time_Add],[Time_Update],[Language],[Phone])");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Email,@Subject,@Content,@Type_id_InquiryStatus,@Time_Add,@Time_Update,@Language,@Phone)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@Subject", model.Subject),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Type_id_InquiryStatus", model.Type_id_InquiryStatus),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Phone", model.Phone)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Inquiry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Inquiry] set ");
			strSql.Append("[UserName]=@UserName,");
			strSql.Append("[Email]=@Email,");
			strSql.Append("[Subject]=@Subject,");
			strSql.Append("[Content]=@Content,");
			strSql.Append("[Type_id_InquiryStatus]=@Type_id_InquiryStatus,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Update]=@Time_Update,");
			strSql.Append("[Language]=@Language,");
			strSql.Append("[Phone]=@Phone");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@Subject", model.Subject),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Type_id_InquiryStatus", model.Type_id_InquiryStatus),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Phone", model.Phone)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Inquiry] ");
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
			strSql.Append("delete from [Lebi_Inquiry] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Inquiry] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Inquiry GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Inquiry] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Inquiry model;
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
		public Lebi_Inquiry GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Inquiry] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Inquiry model;
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
		public Lebi_Inquiry GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Inquiry] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Inquiry model;
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
		public List<Lebi_Inquiry> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Inquiry]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Inquiry> list = new List<Lebi_Inquiry>();
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
		public List<Lebi_Inquiry> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Inquiry]";
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
			List<Lebi_Inquiry> list = new List<Lebi_Inquiry>();
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
		public List<Lebi_Inquiry> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Inquiry] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Inquiry> list = new List<Lebi_Inquiry>();
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
		public List<Lebi_Inquiry> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Inquiry]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Inquiry> list = new List<Lebi_Inquiry>();
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
		public Lebi_Inquiry BindForm(Lebi_Inquiry model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["Subject"] != null)
				model.Subject=Shop.Tools.RequestTool.RequestString("Subject");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Type_id_InquiryStatus"] != null)
				model.Type_id_InquiryStatus=Shop.Tools.RequestTool.RequestInt("Type_id_InquiryStatus",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Inquiry SafeBindForm(Lebi_Inquiry model)
		{
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["Subject"] != null)
				model.Subject=Shop.Tools.RequestTool.RequestSafeString("Subject");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Type_id_InquiryStatus"] != null)
				model.Type_id_InquiryStatus=Shop.Tools.RequestTool.RequestInt("Type_id_InquiryStatus",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Inquiry ReaderBind(IDataReader dataReader)
		{
			Lebi_Inquiry model=new Lebi_Inquiry();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.Subject=dataReader["Subject"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Type_id_InquiryStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_InquiryStatus=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Update=(DateTime)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

