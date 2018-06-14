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

	public interface Lebi_ProPerty_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_ProPerty model);
		void Update(Lebi_ProPerty model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_ProPerty GetModel(int id);
		Lebi_ProPerty GetModel(string strWhere);
		Lebi_ProPerty GetModel(SQLPara para);
		List<Lebi_ProPerty> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_ProPerty> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_ProPerty> GetList(string strWhere, string strFieldOrder);
		List<Lebi_ProPerty> GetList(SQLPara para);
		Lebi_ProPerty BindForm(Lebi_ProPerty model);
		Lebi_ProPerty SafeBindForm(Lebi_ProPerty model);
		Lebi_ProPerty ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_ProPerty。
	/// </summary>
	public class D_Lebi_ProPerty
	{
		static Lebi_ProPerty_interface _Instance;
		public static Lebi_ProPerty_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_ProPerty();
		            else
		                _Instance = new sqlserver_Lebi_ProPerty();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_ProPerty()
		{}
		#region  成员方法
	class sqlserver_Lebi_ProPerty : Lebi_ProPerty_interface
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
				strSql.Append("select " + colName + " from [Lebi_ProPerty]");
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
			strSql.Append("select  "+colName+" from [Lebi_ProPerty]");
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
			strSql.Append("select count(1) from [Lebi_ProPerty]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_ProPerty]");
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
			strSql.Append("select max(id) from [Lebi_ProPerty]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_ProPerty]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_ProPerty model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_ProPerty](");
			strSql.Append("Name,parentid,Sort,Type_id_ProPertyType,ImageUrl,Code,parentSort,taobaoid,Price,Tag,Remark,Supplier_id)");
			strSql.Append(" values (");
			strSql.Append("@Name,@parentid,@Sort,@Type_id_ProPertyType,@ImageUrl,@Code,@parentSort,@taobaoid,@Price,@Tag,@Remark,@Supplier_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@parentid", model.parentid),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Type_id_ProPertyType", model.Type_id_ProPertyType),
					new SqlParameter("@ImageUrl", model.ImageUrl),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@parentSort", model.parentSort),
					new SqlParameter("@taobaoid", model.taobaoid),
					new SqlParameter("@Price", model.Price),
					new SqlParameter("@Tag", model.Tag),
					new SqlParameter("@Remark", model.Remark),
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
		public void Update(Lebi_ProPerty model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_ProPerty] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("parentid= @parentid,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Type_id_ProPertyType= @Type_id_ProPertyType,");
			strSql.Append("ImageUrl= @ImageUrl,");
			strSql.Append("Code= @Code,");
			strSql.Append("parentSort= @parentSort,");
			strSql.Append("taobaoid= @taobaoid,");
			strSql.Append("Price= @Price,");
			strSql.Append("Tag= @Tag,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Supplier_id= @Supplier_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Type_id_ProPertyType", SqlDbType.Int,4),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@parentSort", SqlDbType.Int,4),
					new SqlParameter("@taobaoid", SqlDbType.NVarChar,50),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Tag", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.parentid;
			parameters[3].Value = model.Sort;
			parameters[4].Value = model.Type_id_ProPertyType;
			parameters[5].Value = model.ImageUrl;
			parameters[6].Value = model.Code;
			parameters[7].Value = model.parentSort;
			parameters[8].Value = model.taobaoid;
			parameters[9].Value = model.Price;
			parameters[10].Value = model.Tag;
			parameters[11].Value = model.Remark;
			parameters[12].Value = model.Supplier_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_ProPerty] ");
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
			strSql.Append("delete from [Lebi_ProPerty] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_ProPerty] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_ProPerty GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_ProPerty] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_ProPerty model=new Lebi_ProPerty();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_ProPertyType"].ToString()!="")
				{
					model.Type_id_ProPertyType=int.Parse(ds.Tables[0].Rows[0]["Type_id_ProPertyType"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["parentSort"].ToString()!="")
				{
					model.parentSort=int.Parse(ds.Tables[0].Rows[0]["parentSort"].ToString());
				}
				model.taobaoid=ds.Tables[0].Rows[0]["taobaoid"].ToString();
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.Tag=ds.Tables[0].Rows[0]["Tag"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
		public Lebi_ProPerty GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_ProPerty] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_ProPerty model=new Lebi_ProPerty();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_ProPertyType"].ToString()!="")
				{
					model.Type_id_ProPertyType=int.Parse(ds.Tables[0].Rows[0]["Type_id_ProPertyType"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["parentSort"].ToString()!="")
				{
					model.parentSort=int.Parse(ds.Tables[0].Rows[0]["parentSort"].ToString());
				}
				model.taobaoid=ds.Tables[0].Rows[0]["taobaoid"].ToString();
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.Tag=ds.Tables[0].Rows[0]["Tag"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
		public Lebi_ProPerty GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_ProPerty] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_ProPerty model=new Lebi_ProPerty();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_ProPertyType"].ToString()!="")
				{
					model.Type_id_ProPertyType=int.Parse(ds.Tables[0].Rows[0]["Type_id_ProPertyType"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["parentSort"].ToString()!="")
				{
					model.parentSort=int.Parse(ds.Tables[0].Rows[0]["parentSort"].ToString());
				}
				model.taobaoid=ds.Tables[0].Rows[0]["taobaoid"].ToString();
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.Tag=ds.Tables[0].Rows[0]["Tag"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
		public List<Lebi_ProPerty> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_ProPerty]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_ProPerty> list = new List<Lebi_ProPerty>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_ProPerty> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_ProPerty]";
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
			List<Lebi_ProPerty> list = new List<Lebi_ProPerty>();
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
		public List<Lebi_ProPerty> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_ProPerty] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_ProPerty> list = new List<Lebi_ProPerty>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_ProPerty> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_ProPerty]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_ProPerty> list = new List<Lebi_ProPerty>();
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
		public Lebi_ProPerty BindForm(Lebi_ProPerty model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Type_id_ProPertyType"] != null)
				model.Type_id_ProPertyType=Shop.Tools.RequestTool.RequestInt("Type_id_ProPertyType",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["parentSort"] != null)
				model.parentSort=Shop.Tools.RequestTool.RequestInt("parentSort",0);
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestString("taobaoid");
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Tag"] != null)
				model.Tag=Shop.Tools.RequestTool.RequestString("Tag");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_ProPerty SafeBindForm(Lebi_ProPerty model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Type_id_ProPertyType"] != null)
				model.Type_id_ProPertyType=Shop.Tools.RequestTool.RequestInt("Type_id_ProPertyType",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["parentSort"] != null)
				model.parentSort=Shop.Tools.RequestTool.RequestInt("parentSort",0);
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestSafeString("taobaoid");
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Tag"] != null)
				model.Tag=Shop.Tools.RequestTool.RequestSafeString("Tag");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_ProPerty ReaderBind(IDataReader dataReader)
		{
			Lebi_ProPerty model=new Lebi_ProPerty();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentid=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Type_id_ProPertyType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_ProPertyType=(int)ojb;
			}
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["parentSort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentSort=(int)ojb;
			}
			model.taobaoid=dataReader["taobaoid"].ToString();
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			model.Tag=dataReader["Tag"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_ProPerty : Lebi_ProPerty_interface
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
				strSql.Append("select " + colName + " from [Lebi_ProPerty]");
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
			strSql.Append("select  "+colName+" from [Lebi_ProPerty]");
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
			strSql.Append("select count(*) from [Lebi_ProPerty]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_ProPerty]");
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
			strSql.Append("select max(id) from [Lebi_ProPerty]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_ProPerty]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_ProPerty model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_ProPerty](");
			strSql.Append("[Name],[parentid],[Sort],[Type_id_ProPertyType],[ImageUrl],[Code],[parentSort],[taobaoid],[Price],[Tag],[Remark],[Supplier_id])");
			strSql.Append(" values (");
			strSql.Append("@Name,@parentid,@Sort,@Type_id_ProPertyType,@ImageUrl,@Code,@parentSort,@taobaoid,@Price,@Tag,@Remark,@Supplier_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@parentid", model.parentid),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Type_id_ProPertyType", model.Type_id_ProPertyType),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@parentSort", model.parentSort),
					new OleDbParameter("@taobaoid", model.taobaoid),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Tag", model.Tag),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_ProPerty model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_ProPerty] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[parentid]=@parentid,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Type_id_ProPertyType]=@Type_id_ProPertyType,");
			strSql.Append("[ImageUrl]=@ImageUrl,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[parentSort]=@parentSort,");
			strSql.Append("[taobaoid]=@taobaoid,");
			strSql.Append("[Price]=@Price,");
			strSql.Append("[Tag]=@Tag,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Supplier_id]=@Supplier_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@parentid", model.parentid),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Type_id_ProPertyType", model.Type_id_ProPertyType),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@parentSort", model.parentSort),
					new OleDbParameter("@taobaoid", model.taobaoid),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Tag", model.Tag),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_ProPerty] ");
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
			strSql.Append("delete from [Lebi_ProPerty] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_ProPerty] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_ProPerty GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_ProPerty] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_ProPerty model;
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
		public Lebi_ProPerty GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_ProPerty] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_ProPerty model;
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
		public Lebi_ProPerty GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_ProPerty] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_ProPerty model;
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
		public List<Lebi_ProPerty> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_ProPerty]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_ProPerty> list = new List<Lebi_ProPerty>();
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
		public List<Lebi_ProPerty> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_ProPerty]";
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
			List<Lebi_ProPerty> list = new List<Lebi_ProPerty>();
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
		public List<Lebi_ProPerty> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_ProPerty] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_ProPerty> list = new List<Lebi_ProPerty>();
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
		public List<Lebi_ProPerty> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_ProPerty]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_ProPerty> list = new List<Lebi_ProPerty>();
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
		public Lebi_ProPerty BindForm(Lebi_ProPerty model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Type_id_ProPertyType"] != null)
				model.Type_id_ProPertyType=Shop.Tools.RequestTool.RequestInt("Type_id_ProPertyType",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["parentSort"] != null)
				model.parentSort=Shop.Tools.RequestTool.RequestInt("parentSort",0);
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestString("taobaoid");
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Tag"] != null)
				model.Tag=Shop.Tools.RequestTool.RequestString("Tag");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_ProPerty SafeBindForm(Lebi_ProPerty model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Type_id_ProPertyType"] != null)
				model.Type_id_ProPertyType=Shop.Tools.RequestTool.RequestInt("Type_id_ProPertyType",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["parentSort"] != null)
				model.parentSort=Shop.Tools.RequestTool.RequestInt("parentSort",0);
			if (HttpContext.Current.Request["taobaoid"] != null)
				model.taobaoid=Shop.Tools.RequestTool.RequestSafeString("taobaoid");
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Tag"] != null)
				model.Tag=Shop.Tools.RequestTool.RequestSafeString("Tag");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_ProPerty ReaderBind(IDataReader dataReader)
		{
			Lebi_ProPerty model=new Lebi_ProPerty();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentid=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Type_id_ProPertyType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_ProPertyType=(int)ojb;
			}
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["parentSort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentSort=(int)ojb;
			}
			model.taobaoid=dataReader["taobaoid"].ToString();
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			model.Tag=dataReader["Tag"].ToString();
			model.Remark=dataReader["Remark"].ToString();
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

