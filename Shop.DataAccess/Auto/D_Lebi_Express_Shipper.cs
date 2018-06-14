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

	public interface Lebi_Express_Shipper_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Express_Shipper model);
		void Update(Lebi_Express_Shipper model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Express_Shipper GetModel(int id);
		Lebi_Express_Shipper GetModel(string strWhere);
		Lebi_Express_Shipper GetModel(SQLPara para);
		List<Lebi_Express_Shipper> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Express_Shipper> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Express_Shipper> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Express_Shipper> GetList(SQLPara para);
		Lebi_Express_Shipper BindForm(Lebi_Express_Shipper model);
		Lebi_Express_Shipper SafeBindForm(Lebi_Express_Shipper model);
		Lebi_Express_Shipper ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Express_Shipper。
	/// </summary>
	public class D_Lebi_Express_Shipper
	{
		static Lebi_Express_Shipper_interface _Instance;
		public static Lebi_Express_Shipper_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Express_Shipper();
		            else
		                _Instance = new sqlserver_Lebi_Express_Shipper();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Express_Shipper()
		{}
		#region  成员方法
	class sqlserver_Lebi_Express_Shipper : Lebi_Express_Shipper_interface
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
				strSql.Append("select " + colName + " from [Lebi_Express_Shipper]");
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
			strSql.Append("select  "+colName+" from [Lebi_Express_Shipper]");
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
			strSql.Append("select count(1) from [Lebi_Express_Shipper]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Express_Shipper]");
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
			strSql.Append("select max(id) from [Lebi_Express_Shipper]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Express_Shipper]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Express_Shipper model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Express_Shipper](");
			strSql.Append("City,SiteName,UserName,Address,ZipCode,Tel,Mobile,Remark,Status,Sort,Supplier_id)");
			strSql.Append(" values (");
			strSql.Append("@City,@SiteName,@UserName,@Address,@ZipCode,@Tel,@Mobile,@Remark,@Status,@Sort,@Supplier_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@City", model.City),
					new SqlParameter("@SiteName", model.SiteName),
					new SqlParameter("@UserName", model.UserName),
					new SqlParameter("@Address", model.Address),
					new SqlParameter("@ZipCode", model.ZipCode),
					new SqlParameter("@Tel", model.Tel),
					new SqlParameter("@Mobile", model.Mobile),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Status", model.Status),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Supplier_id", model.Supplier_id)};

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
		public void Update(Lebi_Express_Shipper model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Express_Shipper] set ");
			strSql.Append("City= @City,");
			strSql.Append("SiteName= @SiteName,");
			strSql.Append("UserName= @UserName,");
			strSql.Append("Address= @Address,");
			strSql.Append("ZipCode= @ZipCode,");
			strSql.Append("Tel= @Tel,");
			strSql.Append("Mobile= @Mobile,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Status= @Status,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Supplier_id= @Supplier_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@City", SqlDbType.NVarChar,50),
					new SqlParameter("@SiteName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@ZipCode", SqlDbType.NVarChar,10),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.City;
			parameters[2].Value = model.SiteName;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.ZipCode;
			parameters[6].Value = model.Tel;
			parameters[7].Value = model.Mobile;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.Sort;
			parameters[11].Value = model.Supplier_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Express_Shipper] ");
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
			strSql.Append("delete from [Lebi_Express_Shipper] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Express_Shipper] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Express_Shipper GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Express_Shipper] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Express_Shipper model=new Lebi_Express_Shipper();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.City=ds.Tables[0].Rows[0]["City"].ToString();
				model.SiteName=ds.Tables[0].Rows[0]["SiteName"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.ZipCode=ds.Tables[0].Rows[0]["ZipCode"].ToString();
				model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
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
		public Lebi_Express_Shipper GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Express_Shipper] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Express_Shipper model=new Lebi_Express_Shipper();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.City=ds.Tables[0].Rows[0]["City"].ToString();
				model.SiteName=ds.Tables[0].Rows[0]["SiteName"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.ZipCode=ds.Tables[0].Rows[0]["ZipCode"].ToString();
				model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
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
		public Lebi_Express_Shipper GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Express_Shipper] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Express_Shipper model=new Lebi_Express_Shipper();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.City=ds.Tables[0].Rows[0]["City"].ToString();
				model.SiteName=ds.Tables[0].Rows[0]["SiteName"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.ZipCode=ds.Tables[0].Rows[0]["ZipCode"].ToString();
				model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
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
		public List<Lebi_Express_Shipper> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Express_Shipper]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Express_Shipper> list = new List<Lebi_Express_Shipper>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Express_Shipper> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Express_Shipper]";
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
			List<Lebi_Express_Shipper> list = new List<Lebi_Express_Shipper>();
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
		public List<Lebi_Express_Shipper> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Express_Shipper] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Express_Shipper> list = new List<Lebi_Express_Shipper>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Express_Shipper> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Express_Shipper]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Express_Shipper> list = new List<Lebi_Express_Shipper>();
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
		public Lebi_Express_Shipper BindForm(Lebi_Express_Shipper model)
		{
			if (HttpContext.Current.Request["City"] != null)
				model.City=Shop.Tools.RequestTool.RequestString("City");
			if (HttpContext.Current.Request["SiteName"] != null)
				model.SiteName=Shop.Tools.RequestTool.RequestString("SiteName");
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["ZipCode"] != null)
				model.ZipCode=Shop.Tools.RequestTool.RequestString("ZipCode");
			if (HttpContext.Current.Request["Tel"] != null)
				model.Tel=Shop.Tools.RequestTool.RequestString("Tel");
			if (HttpContext.Current.Request["Mobile"] != null)
				model.Mobile=Shop.Tools.RequestTool.RequestString("Mobile");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Express_Shipper SafeBindForm(Lebi_Express_Shipper model)
		{
			if (HttpContext.Current.Request["City"] != null)
				model.City=Shop.Tools.RequestTool.RequestSafeString("City");
			if (HttpContext.Current.Request["SiteName"] != null)
				model.SiteName=Shop.Tools.RequestTool.RequestSafeString("SiteName");
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["ZipCode"] != null)
				model.ZipCode=Shop.Tools.RequestTool.RequestSafeString("ZipCode");
			if (HttpContext.Current.Request["Tel"] != null)
				model.Tel=Shop.Tools.RequestTool.RequestSafeString("Tel");
			if (HttpContext.Current.Request["Mobile"] != null)
				model.Mobile=Shop.Tools.RequestTool.RequestSafeString("Mobile");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Express_Shipper ReaderBind(IDataReader dataReader)
		{
			Lebi_Express_Shipper model=new Lebi_Express_Shipper();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.City=dataReader["City"].ToString();
			model.SiteName=dataReader["SiteName"].ToString();
			model.UserName=dataReader["UserName"].ToString();
			model.Address=dataReader["Address"].ToString();
			model.ZipCode=dataReader["ZipCode"].ToString();
			model.Tel=dataReader["Tel"].ToString();
			model.Mobile=dataReader["Mobile"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Express_Shipper : Lebi_Express_Shipper_interface
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
				strSql.Append("select " + colName + " from [Lebi_Express_Shipper]");
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
			strSql.Append("select  "+colName+" from [Lebi_Express_Shipper]");
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
			strSql.Append("select count(*) from [Lebi_Express_Shipper]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Express_Shipper]");
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
			strSql.Append("select max(id) from [Lebi_Express_Shipper]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Express_Shipper]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Express_Shipper model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Express_Shipper](");
			strSql.Append("[City],[SiteName],[UserName],[Address],[ZipCode],[Tel],[Mobile],[Remark],[Status],[Sort],[Supplier_id])");
			strSql.Append(" values (");
			strSql.Append("@City,@SiteName,@UserName,@Address,@ZipCode,@Tel,@Mobile,@Remark,@Status,@Sort,@Supplier_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@City", model.City),
					new OleDbParameter("@SiteName", model.SiteName),
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@ZipCode", model.ZipCode),
					new OleDbParameter("@Tel", model.Tel),
					new OleDbParameter("@Mobile", model.Mobile),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Status", model.Status),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Express_Shipper model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Express_Shipper] set ");
			strSql.Append("[City]=@City,");
			strSql.Append("[SiteName]=@SiteName,");
			strSql.Append("[UserName]=@UserName,");
			strSql.Append("[Address]=@Address,");
			strSql.Append("[ZipCode]=@ZipCode,");
			strSql.Append("[Tel]=@Tel,");
			strSql.Append("[Mobile]=@Mobile,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Status]=@Status,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Supplier_id]=@Supplier_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@City", model.City),
					new OleDbParameter("@SiteName", model.SiteName),
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@ZipCode", model.ZipCode),
					new OleDbParameter("@Tel", model.Tel),
					new OleDbParameter("@Mobile", model.Mobile),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Status", model.Status),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Express_Shipper] ");
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
			strSql.Append("delete from [Lebi_Express_Shipper] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Express_Shipper] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Express_Shipper GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Express_Shipper] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Express_Shipper model;
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
		public Lebi_Express_Shipper GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Express_Shipper] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Express_Shipper model;
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
		public Lebi_Express_Shipper GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Express_Shipper] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Express_Shipper model;
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
		public List<Lebi_Express_Shipper> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Express_Shipper]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Express_Shipper> list = new List<Lebi_Express_Shipper>();
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
		public List<Lebi_Express_Shipper> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Express_Shipper]";
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
			List<Lebi_Express_Shipper> list = new List<Lebi_Express_Shipper>();
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
		public List<Lebi_Express_Shipper> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Express_Shipper] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Express_Shipper> list = new List<Lebi_Express_Shipper>();
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
		public List<Lebi_Express_Shipper> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Express_Shipper]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Express_Shipper> list = new List<Lebi_Express_Shipper>();
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
		public Lebi_Express_Shipper BindForm(Lebi_Express_Shipper model)
		{
			if (HttpContext.Current.Request["City"] != null)
				model.City=Shop.Tools.RequestTool.RequestString("City");
			if (HttpContext.Current.Request["SiteName"] != null)
				model.SiteName=Shop.Tools.RequestTool.RequestString("SiteName");
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["ZipCode"] != null)
				model.ZipCode=Shop.Tools.RequestTool.RequestString("ZipCode");
			if (HttpContext.Current.Request["Tel"] != null)
				model.Tel=Shop.Tools.RequestTool.RequestString("Tel");
			if (HttpContext.Current.Request["Mobile"] != null)
				model.Mobile=Shop.Tools.RequestTool.RequestString("Mobile");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Express_Shipper SafeBindForm(Lebi_Express_Shipper model)
		{
			if (HttpContext.Current.Request["City"] != null)
				model.City=Shop.Tools.RequestTool.RequestSafeString("City");
			if (HttpContext.Current.Request["SiteName"] != null)
				model.SiteName=Shop.Tools.RequestTool.RequestSafeString("SiteName");
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["ZipCode"] != null)
				model.ZipCode=Shop.Tools.RequestTool.RequestSafeString("ZipCode");
			if (HttpContext.Current.Request["Tel"] != null)
				model.Tel=Shop.Tools.RequestTool.RequestSafeString("Tel");
			if (HttpContext.Current.Request["Mobile"] != null)
				model.Mobile=Shop.Tools.RequestTool.RequestSafeString("Mobile");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Express_Shipper ReaderBind(IDataReader dataReader)
		{
			Lebi_Express_Shipper model=new Lebi_Express_Shipper();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.City=dataReader["City"].ToString();
			model.SiteName=dataReader["SiteName"].ToString();
			model.UserName=dataReader["UserName"].ToString();
			model.Address=dataReader["Address"].ToString();
			model.ZipCode=dataReader["ZipCode"].ToString();
			model.Tel=dataReader["Tel"].ToString();
			model.Mobile=dataReader["Mobile"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

