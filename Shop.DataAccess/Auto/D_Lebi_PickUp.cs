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

	public interface Lebi_PickUp_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_PickUp model);
		void Update(Lebi_PickUp model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_PickUp GetModel(int id);
		Lebi_PickUp GetModel(string strWhere);
		Lebi_PickUp GetModel(SQLPara para);
		List<Lebi_PickUp> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_PickUp> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_PickUp> GetList(string strWhere, string strFieldOrder);
		List<Lebi_PickUp> GetList(SQLPara para);
		Lebi_PickUp BindForm(Lebi_PickUp model);
		Lebi_PickUp SafeBindForm(Lebi_PickUp model);
		Lebi_PickUp ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_PickUp。
	/// </summary>
	public class D_Lebi_PickUp
	{
		static Lebi_PickUp_interface _Instance;
		public static Lebi_PickUp_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_PickUp();
		            else
		                _Instance = new sqlserver_Lebi_PickUp();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_PickUp()
		{}
		#region  成员方法
	class sqlserver_Lebi_PickUp : Lebi_PickUp_interface
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
				strSql.Append("select " + colName + " from [Lebi_PickUp]");
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
			strSql.Append("select  "+colName+" from [Lebi_PickUp]");
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
			strSql.Append("select count(1) from [Lebi_PickUp]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_PickUp]");
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
			strSql.Append("select max(id) from [Lebi_PickUp]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_PickUp]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_PickUp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_PickUp](");
			strSql.Append("Name,Description,IsCanWeekend,NoServiceDays,Sort,Time_add,Address,Language_ids,BeginDays,Supplier_id)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Description,@IsCanWeekend,@NoServiceDays,@Sort,@Time_add,@Address,@Language_ids,@BeginDays,@Supplier_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@IsCanWeekend", model.IsCanWeekend),
					new SqlParameter("@NoServiceDays", model.NoServiceDays),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Time_add", model.Time_add),
					new SqlParameter("@Address", model.Address),
					new SqlParameter("@Language_ids", model.Language_ids),
					new SqlParameter("@BeginDays", model.BeginDays),
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
		public void Update(Lebi_PickUp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_PickUp] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("Description= @Description,");
			strSql.Append("IsCanWeekend= @IsCanWeekend,");
			strSql.Append("NoServiceDays= @NoServiceDays,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Time_add= @Time_add,");
			strSql.Append("Address= @Address,");
			strSql.Append("Language_ids= @Language_ids,");
			strSql.Append("BeginDays= @BeginDays,");
			strSql.Append("Supplier_id= @Supplier_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,1000),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@IsCanWeekend", SqlDbType.Int,4),
					new SqlParameter("@NoServiceDays", SqlDbType.NVarChar,1000),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Time_add", SqlDbType.DateTime),
					new SqlParameter("@Address", SqlDbType.NVarChar,500),
					new SqlParameter("@Language_ids", SqlDbType.NVarChar,500),
					new SqlParameter("@BeginDays", SqlDbType.Int,4),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.IsCanWeekend;
			parameters[4].Value = model.NoServiceDays;
			parameters[5].Value = model.Sort;
			parameters[6].Value = model.Time_add;
			parameters[7].Value = model.Address;
			parameters[8].Value = model.Language_ids;
			parameters[9].Value = model.BeginDays;
			parameters[10].Value = model.Supplier_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_PickUp] ");
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
			strSql.Append("delete from [Lebi_PickUp] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_PickUp] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_PickUp GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_PickUp] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_PickUp model=new Lebi_PickUp();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsCanWeekend"].ToString()!="")
				{
					model.IsCanWeekend=int.Parse(ds.Tables[0].Rows[0]["IsCanWeekend"].ToString());
				}
				model.NoServiceDays=ds.Tables[0].Rows[0]["NoServiceDays"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				if(ds.Tables[0].Rows[0]["BeginDays"].ToString()!="")
				{
					model.BeginDays=int.Parse(ds.Tables[0].Rows[0]["BeginDays"].ToString());
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
		public Lebi_PickUp GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_PickUp] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_PickUp model=new Lebi_PickUp();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsCanWeekend"].ToString()!="")
				{
					model.IsCanWeekend=int.Parse(ds.Tables[0].Rows[0]["IsCanWeekend"].ToString());
				}
				model.NoServiceDays=ds.Tables[0].Rows[0]["NoServiceDays"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				if(ds.Tables[0].Rows[0]["BeginDays"].ToString()!="")
				{
					model.BeginDays=int.Parse(ds.Tables[0].Rows[0]["BeginDays"].ToString());
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
		public Lebi_PickUp GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_PickUp] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_PickUp model=new Lebi_PickUp();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsCanWeekend"].ToString()!="")
				{
					model.IsCanWeekend=int.Parse(ds.Tables[0].Rows[0]["IsCanWeekend"].ToString());
				}
				model.NoServiceDays=ds.Tables[0].Rows[0]["NoServiceDays"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				if(ds.Tables[0].Rows[0]["BeginDays"].ToString()!="")
				{
					model.BeginDays=int.Parse(ds.Tables[0].Rows[0]["BeginDays"].ToString());
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
		public List<Lebi_PickUp> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_PickUp]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_PickUp> list = new List<Lebi_PickUp>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_PickUp> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_PickUp]";
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
			List<Lebi_PickUp> list = new List<Lebi_PickUp>();
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
		public List<Lebi_PickUp> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_PickUp] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_PickUp> list = new List<Lebi_PickUp>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_PickUp> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_PickUp]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_PickUp> list = new List<Lebi_PickUp>();
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
		public Lebi_PickUp BindForm(Lebi_PickUp model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["IsCanWeekend"] != null)
				model.IsCanWeekend=Shop.Tools.RequestTool.RequestInt("IsCanWeekend",0);
			if (HttpContext.Current.Request["NoServiceDays"] != null)
				model.NoServiceDays=Shop.Tools.RequestTool.RequestString("NoServiceDays");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
			if (HttpContext.Current.Request["BeginDays"] != null)
				model.BeginDays=Shop.Tools.RequestTool.RequestInt("BeginDays",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_PickUp SafeBindForm(Lebi_PickUp model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["IsCanWeekend"] != null)
				model.IsCanWeekend=Shop.Tools.RequestTool.RequestInt("IsCanWeekend",0);
			if (HttpContext.Current.Request["NoServiceDays"] != null)
				model.NoServiceDays=Shop.Tools.RequestTool.RequestSafeString("NoServiceDays");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
			if (HttpContext.Current.Request["BeginDays"] != null)
				model.BeginDays=Shop.Tools.RequestTool.RequestInt("BeginDays",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_PickUp ReaderBind(IDataReader dataReader)
		{
			Lebi_PickUp model=new Lebi_PickUp();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["IsCanWeekend"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCanWeekend=(int)ojb;
			}
			model.NoServiceDays=dataReader["NoServiceDays"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			model.Address=dataReader["Address"].ToString();
			model.Language_ids=dataReader["Language_ids"].ToString();
			ojb = dataReader["BeginDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BeginDays=(int)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_PickUp : Lebi_PickUp_interface
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
				strSql.Append("select " + colName + " from [Lebi_PickUp]");
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
			strSql.Append("select  "+colName+" from [Lebi_PickUp]");
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
			strSql.Append("select count(*) from [Lebi_PickUp]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_PickUp]");
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
			strSql.Append("select max(id) from [Lebi_PickUp]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_PickUp]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_PickUp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_PickUp](");
			strSql.Append("[Name],[Description],[IsCanWeekend],[NoServiceDays],[Sort],[Time_add],[Address],[Language_ids],[BeginDays],[Supplier_id])");
			strSql.Append(" values (");
			strSql.Append("@Name,@Description,@IsCanWeekend,@NoServiceDays,@Sort,@Time_add,@Address,@Language_ids,@BeginDays,@Supplier_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@IsCanWeekend", model.IsCanWeekend),
					new OleDbParameter("@NoServiceDays", model.NoServiceDays),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@Language_ids", model.Language_ids),
					new OleDbParameter("@BeginDays", model.BeginDays),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_PickUp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_PickUp] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[IsCanWeekend]=@IsCanWeekend,");
			strSql.Append("[NoServiceDays]=@NoServiceDays,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Time_add]=@Time_add,");
			strSql.Append("[Address]=@Address,");
			strSql.Append("[Language_ids]=@Language_ids,");
			strSql.Append("[BeginDays]=@BeginDays,");
			strSql.Append("[Supplier_id]=@Supplier_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@IsCanWeekend", model.IsCanWeekend),
					new OleDbParameter("@NoServiceDays", model.NoServiceDays),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Address", model.Address),
					new OleDbParameter("@Language_ids", model.Language_ids),
					new OleDbParameter("@BeginDays", model.BeginDays),
					new OleDbParameter("@Supplier_id", model.Supplier_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_PickUp] ");
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
			strSql.Append("delete from [Lebi_PickUp] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_PickUp] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_PickUp GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_PickUp] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_PickUp model;
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
		public Lebi_PickUp GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_PickUp] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_PickUp model;
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
		public Lebi_PickUp GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_PickUp] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_PickUp model;
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
		public List<Lebi_PickUp> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_PickUp]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_PickUp> list = new List<Lebi_PickUp>();
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
		public List<Lebi_PickUp> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_PickUp]";
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
			List<Lebi_PickUp> list = new List<Lebi_PickUp>();
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
		public List<Lebi_PickUp> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_PickUp] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_PickUp> list = new List<Lebi_PickUp>();
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
		public List<Lebi_PickUp> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_PickUp]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_PickUp> list = new List<Lebi_PickUp>();
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
		public Lebi_PickUp BindForm(Lebi_PickUp model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["IsCanWeekend"] != null)
				model.IsCanWeekend=Shop.Tools.RequestTool.RequestInt("IsCanWeekend",0);
			if (HttpContext.Current.Request["NoServiceDays"] != null)
				model.NoServiceDays=Shop.Tools.RequestTool.RequestString("NoServiceDays");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestString("Address");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
			if (HttpContext.Current.Request["BeginDays"] != null)
				model.BeginDays=Shop.Tools.RequestTool.RequestInt("BeginDays",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_PickUp SafeBindForm(Lebi_PickUp model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["IsCanWeekend"] != null)
				model.IsCanWeekend=Shop.Tools.RequestTool.RequestInt("IsCanWeekend",0);
			if (HttpContext.Current.Request["NoServiceDays"] != null)
				model.NoServiceDays=Shop.Tools.RequestTool.RequestSafeString("NoServiceDays");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Address"] != null)
				model.Address=Shop.Tools.RequestTool.RequestSafeString("Address");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
			if (HttpContext.Current.Request["BeginDays"] != null)
				model.BeginDays=Shop.Tools.RequestTool.RequestInt("BeginDays",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_PickUp ReaderBind(IDataReader dataReader)
		{
			Lebi_PickUp model=new Lebi_PickUp();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["IsCanWeekend"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCanWeekend=(int)ojb;
			}
			model.NoServiceDays=dataReader["NoServiceDays"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			model.Address=dataReader["Address"].ToString();
			model.Language_ids=dataReader["Language_ids"].ToString();
			ojb = dataReader["BeginDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BeginDays=(int)ojb;
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

