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

	public interface Lebi_Supplier_UserGroup_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Supplier_UserGroup model);
		void Update(Lebi_Supplier_UserGroup model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Supplier_UserGroup GetModel(int id);
		Lebi_Supplier_UserGroup GetModel(string strWhere);
		Lebi_Supplier_UserGroup GetModel(SQLPara para);
		List<Lebi_Supplier_UserGroup> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Supplier_UserGroup> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Supplier_UserGroup> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Supplier_UserGroup> GetList(SQLPara para);
		Lebi_Supplier_UserGroup BindForm(Lebi_Supplier_UserGroup model);
		Lebi_Supplier_UserGroup SafeBindForm(Lebi_Supplier_UserGroup model);
		Lebi_Supplier_UserGroup ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Supplier_UserGroup。
	/// </summary>
	public class D_Lebi_Supplier_UserGroup
	{
		static Lebi_Supplier_UserGroup_interface _Instance;
		public static Lebi_Supplier_UserGroup_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Supplier_UserGroup();
		            else
		                _Instance = new sqlserver_Lebi_Supplier_UserGroup();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Supplier_UserGroup()
		{}
		#region  成员方法
	class sqlserver_Lebi_Supplier_UserGroup : Lebi_Supplier_UserGroup_interface
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
				strSql.Append("select " + colName + " from [Lebi_Supplier_UserGroup]");
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
			strSql.Append("select  "+colName+" from [Lebi_Supplier_UserGroup]");
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
			strSql.Append("select count(1) from [Lebi_Supplier_UserGroup]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_UserGroup]");
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
			strSql.Append("select max(id) from [Lebi_Supplier_UserGroup]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_UserGroup]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier_UserGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier_UserGroup](");
			strSql.Append("Name,IsShow,Sort,Supplier_id,Description,Menu_ids,Menu_ids_index,Limit_ids,Limit_Codes,Time_Add,User_id_Add,User_id_Edit,Time_Edit)");
			strSql.Append(" values (");
			strSql.Append("@Name,@IsShow,@Sort,@Supplier_id,@Description,@Menu_ids,@Menu_ids_index,@Limit_ids,@Limit_Codes,@Time_Add,@User_id_Add,@User_id_Edit,@Time_Edit)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@IsShow", model.IsShow),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@Menu_ids", model.Menu_ids),
					new SqlParameter("@Menu_ids_index", model.Menu_ids_index),
					new SqlParameter("@Limit_ids", model.Limit_ids),
					new SqlParameter("@Limit_Codes", model.Limit_Codes),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@User_id_Add", model.User_id_Add),
					new SqlParameter("@User_id_Edit", model.User_id_Edit),
					new SqlParameter("@Time_Edit", model.Time_Edit)};

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
		public void Update(Lebi_Supplier_UserGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier_UserGroup] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("IsShow= @IsShow,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Description= @Description,");
			strSql.Append("Menu_ids= @Menu_ids,");
			strSql.Append("Menu_ids_index= @Menu_ids_index,");
			strSql.Append("Limit_ids= @Limit_ids,");
			strSql.Append("Limit_Codes= @Limit_Codes,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("User_id_Add= @User_id_Add,");
			strSql.Append("User_id_Edit= @User_id_Edit,");
			strSql.Append("Time_Edit= @Time_Edit");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@Menu_ids", SqlDbType.NVarChar,1000),
					new SqlParameter("@Menu_ids_index", SqlDbType.NVarChar,1000),
					new SqlParameter("@Limit_ids", SqlDbType.NVarChar,1000),
					new SqlParameter("@Limit_Codes", SqlDbType.NVarChar,1000),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@User_id_Add", SqlDbType.Int,4),
					new SqlParameter("@User_id_Edit", SqlDbType.Int,4),
					new SqlParameter("@Time_Edit", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.IsShow;
			parameters[3].Value = model.Sort;
			parameters[4].Value = model.Supplier_id;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.Menu_ids;
			parameters[7].Value = model.Menu_ids_index;
			parameters[8].Value = model.Limit_ids;
			parameters[9].Value = model.Limit_Codes;
			parameters[10].Value = model.Time_Add;
			parameters[11].Value = model.User_id_Add;
			parameters[12].Value = model.User_id_Edit;
			parameters[13].Value = model.Time_Edit;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_UserGroup] ");
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
			strSql.Append("delete from [Lebi_Supplier_UserGroup] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_UserGroup] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier_UserGroup GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_UserGroup] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Supplier_UserGroup model=new Lebi_Supplier_UserGroup();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Menu_ids=ds.Tables[0].Rows[0]["Menu_ids"].ToString();
				model.Menu_ids_index=ds.Tables[0].Rows[0]["Menu_ids_index"].ToString();
				model.Limit_ids=ds.Tables[0].Rows[0]["Limit_ids"].ToString();
				model.Limit_Codes=ds.Tables[0].Rows[0]["Limit_Codes"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_Add"].ToString()!="")
				{
					model.User_id_Add=int.Parse(ds.Tables[0].Rows[0]["User_id_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_Edit"].ToString()!="")
				{
					model.User_id_Edit=int.Parse(ds.Tables[0].Rows[0]["User_id_Edit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Edit"].ToString()!="")
				{
					model.Time_Edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Edit"].ToString());
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
		public Lebi_Supplier_UserGroup GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_UserGroup] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier_UserGroup model=new Lebi_Supplier_UserGroup();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Menu_ids=ds.Tables[0].Rows[0]["Menu_ids"].ToString();
				model.Menu_ids_index=ds.Tables[0].Rows[0]["Menu_ids_index"].ToString();
				model.Limit_ids=ds.Tables[0].Rows[0]["Limit_ids"].ToString();
				model.Limit_Codes=ds.Tables[0].Rows[0]["Limit_Codes"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_Add"].ToString()!="")
				{
					model.User_id_Add=int.Parse(ds.Tables[0].Rows[0]["User_id_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_Edit"].ToString()!="")
				{
					model.User_id_Edit=int.Parse(ds.Tables[0].Rows[0]["User_id_Edit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Edit"].ToString()!="")
				{
					model.Time_Edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Edit"].ToString());
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
		public Lebi_Supplier_UserGroup GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier_UserGroup] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier_UserGroup model=new Lebi_Supplier_UserGroup();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Menu_ids=ds.Tables[0].Rows[0]["Menu_ids"].ToString();
				model.Menu_ids_index=ds.Tables[0].Rows[0]["Menu_ids_index"].ToString();
				model.Limit_ids=ds.Tables[0].Rows[0]["Limit_ids"].ToString();
				model.Limit_Codes=ds.Tables[0].Rows[0]["Limit_Codes"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_Add"].ToString()!="")
				{
					model.User_id_Add=int.Parse(ds.Tables[0].Rows[0]["User_id_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id_Edit"].ToString()!="")
				{
					model.User_id_Edit=int.Parse(ds.Tables[0].Rows[0]["User_id_Edit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Edit"].ToString()!="")
				{
					model.Time_Edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Edit"].ToString());
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
		public List<Lebi_Supplier_UserGroup> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier_UserGroup]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier_UserGroup> list = new List<Lebi_Supplier_UserGroup>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Supplier_UserGroup> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier_UserGroup]";
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
			List<Lebi_Supplier_UserGroup> list = new List<Lebi_Supplier_UserGroup>();
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
		public List<Lebi_Supplier_UserGroup> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier_UserGroup] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier_UserGroup> list = new List<Lebi_Supplier_UserGroup>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Supplier_UserGroup> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier_UserGroup]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_UserGroup> list = new List<Lebi_Supplier_UserGroup>();
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
		public Lebi_Supplier_UserGroup BindForm(Lebi_Supplier_UserGroup model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Menu_ids"] != null)
				model.Menu_ids=Shop.Tools.RequestTool.RequestString("Menu_ids");
			if (HttpContext.Current.Request["Menu_ids_index"] != null)
				model.Menu_ids_index=Shop.Tools.RequestTool.RequestString("Menu_ids_index");
			if (HttpContext.Current.Request["Limit_ids"] != null)
				model.Limit_ids=Shop.Tools.RequestTool.RequestString("Limit_ids");
			if (HttpContext.Current.Request["Limit_Codes"] != null)
				model.Limit_Codes=Shop.Tools.RequestTool.RequestString("Limit_Codes");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id_Add"] != null)
				model.User_id_Add=Shop.Tools.RequestTool.RequestInt("User_id_Add",0);
			if (HttpContext.Current.Request["User_id_Edit"] != null)
				model.User_id_Edit=Shop.Tools.RequestTool.RequestInt("User_id_Edit",0);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier_UserGroup SafeBindForm(Lebi_Supplier_UserGroup model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Menu_ids"] != null)
				model.Menu_ids=Shop.Tools.RequestTool.RequestSafeString("Menu_ids");
			if (HttpContext.Current.Request["Menu_ids_index"] != null)
				model.Menu_ids_index=Shop.Tools.RequestTool.RequestSafeString("Menu_ids_index");
			if (HttpContext.Current.Request["Limit_ids"] != null)
				model.Limit_ids=Shop.Tools.RequestTool.RequestSafeString("Limit_ids");
			if (HttpContext.Current.Request["Limit_Codes"] != null)
				model.Limit_Codes=Shop.Tools.RequestTool.RequestSafeString("Limit_Codes");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id_Add"] != null)
				model.User_id_Add=Shop.Tools.RequestTool.RequestInt("User_id_Add",0);
			if (HttpContext.Current.Request["User_id_Edit"] != null)
				model.User_id_Edit=Shop.Tools.RequestTool.RequestInt("User_id_Edit",0);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier_UserGroup ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier_UserGroup model=new Lebi_Supplier_UserGroup();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(int)ojb;
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
			model.Description=dataReader["Description"].ToString();
			model.Menu_ids=dataReader["Menu_ids"].ToString();
			model.Menu_ids_index=dataReader["Menu_ids_index"].ToString();
			model.Limit_ids=dataReader["Limit_ids"].ToString();
			model.Limit_Codes=dataReader["Limit_Codes"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["User_id_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id_Add=(int)ojb;
			}
			ojb = dataReader["User_id_Edit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id_Edit=(int)ojb;
			}
			ojb = dataReader["Time_Edit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Edit=(DateTime)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Supplier_UserGroup : Lebi_Supplier_UserGroup_interface
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
				strSql.Append("select " + colName + " from [Lebi_Supplier_UserGroup]");
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
			strSql.Append("select  "+colName+" from [Lebi_Supplier_UserGroup]");
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
			strSql.Append("select count(*) from [Lebi_Supplier_UserGroup]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Supplier_UserGroup]");
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
			strSql.Append("select max(id) from [Lebi_Supplier_UserGroup]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_UserGroup]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier_UserGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier_UserGroup](");
			strSql.Append("[Name],[IsShow],[Sort],[Supplier_id],[Description],[Menu_ids],[Menu_ids_index],[Limit_ids],[Limit_Codes],[Time_Add],[User_id_Add],[User_id_Edit],[Time_Edit])");
			strSql.Append(" values (");
			strSql.Append("@Name,@IsShow,@Sort,@Supplier_id,@Description,@Menu_ids,@Menu_ids_index,@Limit_ids,@Limit_Codes,@Time_Add,@User_id_Add,@User_id_Edit,@Time_Edit)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@IsShow", model.IsShow),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Menu_ids", model.Menu_ids),
					new OleDbParameter("@Menu_ids_index", model.Menu_ids_index),
					new OleDbParameter("@Limit_ids", model.Limit_ids),
					new OleDbParameter("@Limit_Codes", model.Limit_Codes),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@User_id_Add", model.User_id_Add),
					new OleDbParameter("@User_id_Edit", model.User_id_Edit),
					new OleDbParameter("@Time_Edit", model.Time_Edit.ToString("yyyy-MM-dd hh:mm:ss"))};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Supplier_UserGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier_UserGroup] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[IsShow]=@IsShow,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[Menu_ids]=@Menu_ids,");
			strSql.Append("[Menu_ids_index]=@Menu_ids_index,");
			strSql.Append("[Limit_ids]=@Limit_ids,");
			strSql.Append("[Limit_Codes]=@Limit_Codes,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[User_id_Add]=@User_id_Add,");
			strSql.Append("[User_id_Edit]=@User_id_Edit,");
			strSql.Append("[Time_Edit]=@Time_Edit");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@IsShow", model.IsShow),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Menu_ids", model.Menu_ids),
					new OleDbParameter("@Menu_ids_index", model.Menu_ids_index),
					new OleDbParameter("@Limit_ids", model.Limit_ids),
					new OleDbParameter("@Limit_Codes", model.Limit_Codes),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@User_id_Add", model.User_id_Add),
					new OleDbParameter("@User_id_Edit", model.User_id_Edit),
					new OleDbParameter("@Time_Edit", model.Time_Edit.ToString("yyyy-MM-dd hh:mm:ss"))};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_UserGroup] ");
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
			strSql.Append("delete from [Lebi_Supplier_UserGroup] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_UserGroup] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier_UserGroup GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_UserGroup] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Supplier_UserGroup model;
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
		public Lebi_Supplier_UserGroup GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_UserGroup] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier_UserGroup model;
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
		public Lebi_Supplier_UserGroup GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier_UserGroup] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier_UserGroup model;
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
		public List<Lebi_Supplier_UserGroup> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier_UserGroup]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier_UserGroup> list = new List<Lebi_Supplier_UserGroup>();
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
		public List<Lebi_Supplier_UserGroup> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier_UserGroup]";
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
			List<Lebi_Supplier_UserGroup> list = new List<Lebi_Supplier_UserGroup>();
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
		public List<Lebi_Supplier_UserGroup> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier_UserGroup] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier_UserGroup> list = new List<Lebi_Supplier_UserGroup>();
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
		public List<Lebi_Supplier_UserGroup> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier_UserGroup]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_UserGroup> list = new List<Lebi_Supplier_UserGroup>();
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
		public Lebi_Supplier_UserGroup BindForm(Lebi_Supplier_UserGroup model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Menu_ids"] != null)
				model.Menu_ids=Shop.Tools.RequestTool.RequestString("Menu_ids");
			if (HttpContext.Current.Request["Menu_ids_index"] != null)
				model.Menu_ids_index=Shop.Tools.RequestTool.RequestString("Menu_ids_index");
			if (HttpContext.Current.Request["Limit_ids"] != null)
				model.Limit_ids=Shop.Tools.RequestTool.RequestString("Limit_ids");
			if (HttpContext.Current.Request["Limit_Codes"] != null)
				model.Limit_Codes=Shop.Tools.RequestTool.RequestString("Limit_Codes");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id_Add"] != null)
				model.User_id_Add=Shop.Tools.RequestTool.RequestInt("User_id_Add",0);
			if (HttpContext.Current.Request["User_id_Edit"] != null)
				model.User_id_Edit=Shop.Tools.RequestTool.RequestInt("User_id_Edit",0);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier_UserGroup SafeBindForm(Lebi_Supplier_UserGroup model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Menu_ids"] != null)
				model.Menu_ids=Shop.Tools.RequestTool.RequestSafeString("Menu_ids");
			if (HttpContext.Current.Request["Menu_ids_index"] != null)
				model.Menu_ids_index=Shop.Tools.RequestTool.RequestSafeString("Menu_ids_index");
			if (HttpContext.Current.Request["Limit_ids"] != null)
				model.Limit_ids=Shop.Tools.RequestTool.RequestSafeString("Limit_ids");
			if (HttpContext.Current.Request["Limit_Codes"] != null)
				model.Limit_Codes=Shop.Tools.RequestTool.RequestSafeString("Limit_Codes");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id_Add"] != null)
				model.User_id_Add=Shop.Tools.RequestTool.RequestInt("User_id_Add",0);
			if (HttpContext.Current.Request["User_id_Edit"] != null)
				model.User_id_Edit=Shop.Tools.RequestTool.RequestInt("User_id_Edit",0);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier_UserGroup ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier_UserGroup model=new Lebi_Supplier_UserGroup();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(int)ojb;
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
			model.Description=dataReader["Description"].ToString();
			model.Menu_ids=dataReader["Menu_ids"].ToString();
			model.Menu_ids_index=dataReader["Menu_ids_index"].ToString();
			model.Limit_ids=dataReader["Limit_ids"].ToString();
			model.Limit_Codes=dataReader["Limit_Codes"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["User_id_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id_Add=(int)ojb;
			}
			ojb = dataReader["User_id_Edit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id_Edit=(int)ojb;
			}
			ojb = dataReader["Time_Edit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Edit=(DateTime)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

