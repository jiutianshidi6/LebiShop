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

	public interface Lebi_ServicePanel_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_ServicePanel model);
		void Update(Lebi_ServicePanel model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_ServicePanel GetModel(int id);
		Lebi_ServicePanel GetModel(string strWhere);
		Lebi_ServicePanel GetModel(SQLPara para);
		List<Lebi_ServicePanel> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_ServicePanel> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_ServicePanel> GetList(string strWhere, string strFieldOrder);
		List<Lebi_ServicePanel> GetList(SQLPara para);
		Lebi_ServicePanel BindForm(Lebi_ServicePanel model);
		Lebi_ServicePanel SafeBindForm(Lebi_ServicePanel model);
		Lebi_ServicePanel ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_ServicePanel。
	/// </summary>
	public class D_Lebi_ServicePanel
	{
		static Lebi_ServicePanel_interface _Instance;
		public static Lebi_ServicePanel_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_ServicePanel();
		            else
		                _Instance = new sqlserver_Lebi_ServicePanel();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_ServicePanel()
		{}
		#region  成员方法
	class sqlserver_Lebi_ServicePanel : Lebi_ServicePanel_interface
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
				strSql.Append("select " + colName + " from [Lebi_ServicePanel]");
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
			strSql.Append("select  "+colName+" from [Lebi_ServicePanel]");
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
			strSql.Append("select count(1) from [Lebi_ServicePanel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_ServicePanel]");
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
			strSql.Append("select max(id) from [Lebi_ServicePanel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_ServicePanel]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_ServicePanel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_ServicePanel](");
			strSql.Append("ServicePanel_Group_id,Name,Face,Sort,Account,ServicePanel_Type_id,Language,Supplier_id,Language_ids)");
			strSql.Append(" values (");
			strSql.Append("@ServicePanel_Group_id,@Name,@Face,@Sort,@Account,@ServicePanel_Type_id,@Language,@Supplier_id,@Language_ids)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ServicePanel_Group_id", model.ServicePanel_Group_id),
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Face", model.Face),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Account", model.Account),
					new SqlParameter("@ServicePanel_Type_id", model.ServicePanel_Type_id),
					new SqlParameter("@Language", model.Language),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Language_ids", model.Language_ids)};

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
		public void Update(Lebi_ServicePanel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_ServicePanel] set ");
			strSql.Append("ServicePanel_Group_id= @ServicePanel_Group_id,");
			strSql.Append("Name= @Name,");
			strSql.Append("Face= @Face,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Account= @Account,");
			strSql.Append("ServicePanel_Type_id= @ServicePanel_Type_id,");
			strSql.Append("Language= @Language,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Language_ids= @Language_ids");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ServicePanel_Group_id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Face", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Account", SqlDbType.NVarChar,50),
					new SqlParameter("@ServicePanel_Type_id", SqlDbType.Int,4),
					new SqlParameter("@Language", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Language_ids", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ServicePanel_Group_id;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Face;
			parameters[4].Value = model.Sort;
			parameters[5].Value = model.Account;
			parameters[6].Value = model.ServicePanel_Type_id;
			parameters[7].Value = model.Language;
			parameters[8].Value = model.Supplier_id;
			parameters[9].Value = model.Language_ids;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_ServicePanel] ");
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
			strSql.Append("delete from [Lebi_ServicePanel] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_ServicePanel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_ServicePanel GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_ServicePanel] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_ServicePanel model=new Lebi_ServicePanel();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ServicePanel_Group_id"].ToString()!="")
				{
					model.ServicePanel_Group_id=int.Parse(ds.Tables[0].Rows[0]["ServicePanel_Group_id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Face"].ToString()!="")
				{
					model.Face=int.Parse(ds.Tables[0].Rows[0]["Face"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.Account=ds.Tables[0].Rows[0]["Account"].ToString();
				if(ds.Tables[0].Rows[0]["ServicePanel_Type_id"].ToString()!="")
				{
					model.ServicePanel_Type_id=int.Parse(ds.Tables[0].Rows[0]["ServicePanel_Type_id"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
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
		public Lebi_ServicePanel GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_ServicePanel] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_ServicePanel model=new Lebi_ServicePanel();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ServicePanel_Group_id"].ToString()!="")
				{
					model.ServicePanel_Group_id=int.Parse(ds.Tables[0].Rows[0]["ServicePanel_Group_id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Face"].ToString()!="")
				{
					model.Face=int.Parse(ds.Tables[0].Rows[0]["Face"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.Account=ds.Tables[0].Rows[0]["Account"].ToString();
				if(ds.Tables[0].Rows[0]["ServicePanel_Type_id"].ToString()!="")
				{
					model.ServicePanel_Type_id=int.Parse(ds.Tables[0].Rows[0]["ServicePanel_Type_id"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
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
		public Lebi_ServicePanel GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_ServicePanel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_ServicePanel model=new Lebi_ServicePanel();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ServicePanel_Group_id"].ToString()!="")
				{
					model.ServicePanel_Group_id=int.Parse(ds.Tables[0].Rows[0]["ServicePanel_Group_id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Face"].ToString()!="")
				{
					model.Face=int.Parse(ds.Tables[0].Rows[0]["Face"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				model.Account=ds.Tables[0].Rows[0]["Account"].ToString();
				if(ds.Tables[0].Rows[0]["ServicePanel_Type_id"].ToString()!="")
				{
					model.ServicePanel_Type_id=int.Parse(ds.Tables[0].Rows[0]["ServicePanel_Type_id"].ToString());
				}
				model.Language=ds.Tables[0].Rows[0]["Language"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
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
		public List<Lebi_ServicePanel> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_ServicePanel]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_ServicePanel> list = new List<Lebi_ServicePanel>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_ServicePanel> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_ServicePanel]";
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
			List<Lebi_ServicePanel> list = new List<Lebi_ServicePanel>();
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
		public List<Lebi_ServicePanel> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_ServicePanel] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_ServicePanel> list = new List<Lebi_ServicePanel>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_ServicePanel> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_ServicePanel]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_ServicePanel> list = new List<Lebi_ServicePanel>();
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
		public Lebi_ServicePanel BindForm(Lebi_ServicePanel model)
		{
			if (HttpContext.Current.Request["ServicePanel_Group_id"] != null)
				model.ServicePanel_Group_id=Shop.Tools.RequestTool.RequestInt("ServicePanel_Group_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Face"] != null)
				model.Face=Shop.Tools.RequestTool.RequestInt("Face",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Account"] != null)
				model.Account=Shop.Tools.RequestTool.RequestString("Account");
			if (HttpContext.Current.Request["ServicePanel_Type_id"] != null)
				model.ServicePanel_Type_id=Shop.Tools.RequestTool.RequestInt("ServicePanel_Type_id",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_ServicePanel SafeBindForm(Lebi_ServicePanel model)
		{
			if (HttpContext.Current.Request["ServicePanel_Group_id"] != null)
				model.ServicePanel_Group_id=Shop.Tools.RequestTool.RequestInt("ServicePanel_Group_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Face"] != null)
				model.Face=Shop.Tools.RequestTool.RequestInt("Face",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Account"] != null)
				model.Account=Shop.Tools.RequestTool.RequestSafeString("Account");
			if (HttpContext.Current.Request["ServicePanel_Type_id"] != null)
				model.ServicePanel_Type_id=Shop.Tools.RequestTool.RequestInt("ServicePanel_Type_id",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_ServicePanel ReaderBind(IDataReader dataReader)
		{
			Lebi_ServicePanel model=new Lebi_ServicePanel();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ServicePanel_Group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ServicePanel_Group_id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Face"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Face=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			model.Account=dataReader["Account"].ToString();
			ojb = dataReader["ServicePanel_Type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ServicePanel_Type_id=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			model.Language_ids=dataReader["Language_ids"].ToString();
			return model;
		}

	}
	class access_Lebi_ServicePanel : Lebi_ServicePanel_interface
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
				strSql.Append("select " + colName + " from [Lebi_ServicePanel]");
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
			strSql.Append("select  "+colName+" from [Lebi_ServicePanel]");
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
			strSql.Append("select count(*) from [Lebi_ServicePanel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_ServicePanel]");
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
			strSql.Append("select max(id) from [Lebi_ServicePanel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_ServicePanel]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_ServicePanel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_ServicePanel](");
			strSql.Append("[ServicePanel_Group_id],[Name],[Face],[Sort],[Account],[ServicePanel_Type_id],[Language],[Supplier_id],[Language_ids])");
			strSql.Append(" values (");
			strSql.Append("@ServicePanel_Group_id,@Name,@Face,@Sort,@Account,@ServicePanel_Type_id,@Language,@Supplier_id,@Language_ids)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ServicePanel_Group_id", model.ServicePanel_Group_id),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Face", model.Face),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Account", model.Account),
					new OleDbParameter("@ServicePanel_Type_id", model.ServicePanel_Type_id),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Language_ids", model.Language_ids)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_ServicePanel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_ServicePanel] set ");
			strSql.Append("[ServicePanel_Group_id]=@ServicePanel_Group_id,");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Face]=@Face,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Account]=@Account,");
			strSql.Append("[ServicePanel_Type_id]=@ServicePanel_Type_id,");
			strSql.Append("[Language]=@Language,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Language_ids]=@Language_ids");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@ServicePanel_Group_id", model.ServicePanel_Group_id),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Face", model.Face),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Account", model.Account),
					new OleDbParameter("@ServicePanel_Type_id", model.ServicePanel_Type_id),
					new OleDbParameter("@Language", model.Language),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Language_ids", model.Language_ids)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_ServicePanel] ");
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
			strSql.Append("delete from [Lebi_ServicePanel] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_ServicePanel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_ServicePanel GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_ServicePanel] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_ServicePanel model;
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
		public Lebi_ServicePanel GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_ServicePanel] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_ServicePanel model;
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
		public Lebi_ServicePanel GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_ServicePanel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_ServicePanel model;
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
		public List<Lebi_ServicePanel> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_ServicePanel]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_ServicePanel> list = new List<Lebi_ServicePanel>();
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
		public List<Lebi_ServicePanel> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_ServicePanel]";
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
			List<Lebi_ServicePanel> list = new List<Lebi_ServicePanel>();
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
		public List<Lebi_ServicePanel> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_ServicePanel] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_ServicePanel> list = new List<Lebi_ServicePanel>();
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
		public List<Lebi_ServicePanel> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_ServicePanel]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_ServicePanel> list = new List<Lebi_ServicePanel>();
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
		public Lebi_ServicePanel BindForm(Lebi_ServicePanel model)
		{
			if (HttpContext.Current.Request["ServicePanel_Group_id"] != null)
				model.ServicePanel_Group_id=Shop.Tools.RequestTool.RequestInt("ServicePanel_Group_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Face"] != null)
				model.Face=Shop.Tools.RequestTool.RequestInt("Face",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Account"] != null)
				model.Account=Shop.Tools.RequestTool.RequestString("Account");
			if (HttpContext.Current.Request["ServicePanel_Type_id"] != null)
				model.ServicePanel_Type_id=Shop.Tools.RequestTool.RequestInt("ServicePanel_Type_id",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestString("Language");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_ServicePanel SafeBindForm(Lebi_ServicePanel model)
		{
			if (HttpContext.Current.Request["ServicePanel_Group_id"] != null)
				model.ServicePanel_Group_id=Shop.Tools.RequestTool.RequestInt("ServicePanel_Group_id",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Face"] != null)
				model.Face=Shop.Tools.RequestTool.RequestInt("Face",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Account"] != null)
				model.Account=Shop.Tools.RequestTool.RequestSafeString("Account");
			if (HttpContext.Current.Request["ServicePanel_Type_id"] != null)
				model.ServicePanel_Type_id=Shop.Tools.RequestTool.RequestInt("ServicePanel_Type_id",0);
			if (HttpContext.Current.Request["Language"] != null)
				model.Language=Shop.Tools.RequestTool.RequestSafeString("Language");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_ServicePanel ReaderBind(IDataReader dataReader)
		{
			Lebi_ServicePanel model=new Lebi_ServicePanel();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ServicePanel_Group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ServicePanel_Group_id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Face"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Face=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			model.Account=dataReader["Account"].ToString();
			ojb = dataReader["ServicePanel_Type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ServicePanel_Type_id=(int)ojb;
			}
			model.Language=dataReader["Language"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			model.Language_ids=dataReader["Language_ids"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

