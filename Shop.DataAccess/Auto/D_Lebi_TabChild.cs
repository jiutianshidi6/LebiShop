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

	public interface Lebi_TabChild_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_TabChild model);
		void Update(Lebi_TabChild model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_TabChild GetModel(int id);
		Lebi_TabChild GetModel(string strWhere);
		Lebi_TabChild GetModel(SQLPara para);
		List<Lebi_TabChild> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_TabChild> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_TabChild> GetList(string strWhere, string strFieldOrder);
		List<Lebi_TabChild> GetList(SQLPara para);
		Lebi_TabChild BindForm(Lebi_TabChild model);
		Lebi_TabChild SafeBindForm(Lebi_TabChild model);
		Lebi_TabChild ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_TabChild。
	/// </summary>
	public class D_Lebi_TabChild
	{
		static Lebi_TabChild_interface _Instance;
		public static Lebi_TabChild_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_TabChild();
		            else
		                _Instance = new sqlserver_Lebi_TabChild();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_TabChild()
		{}
		#region  成员方法
	class sqlserver_Lebi_TabChild : Lebi_TabChild_interface
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
				strSql.Append("select " + colName + " from [Lebi_TabChild]");
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
			strSql.Append("select  "+colName+" from [Lebi_TabChild]");
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
			strSql.Append("select count(1) from [Lebi_TabChild]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_TabChild]");
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
			strSql.Append("select max(id) from [Lebi_TabChild]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_TabChild]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_TabChild model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_TabChild](");
			strSql.Append("tabid,protypeid,sort,num)");
			strSql.Append(" values (");
			strSql.Append("@tabid,@protypeid,@sort,@num)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@tabid", model.tabid),
					new SqlParameter("@protypeid", model.protypeid),
					new SqlParameter("@sort", model.sort),
					new SqlParameter("@num", model.num)};

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
		public void Update(Lebi_TabChild model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_TabChild] set ");
			strSql.Append("tabid= @tabid,");
			strSql.Append("protypeid= @protypeid,");
			strSql.Append("sort= @sort,");
			strSql.Append("num= @num");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@tabid", SqlDbType.Int,4),
					new SqlParameter("@protypeid", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@num", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.tabid;
			parameters[2].Value = model.protypeid;
			parameters[3].Value = model.sort;
			parameters[4].Value = model.num;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_TabChild] ");
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
			strSql.Append("delete from [Lebi_TabChild] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_TabChild] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_TabChild GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_TabChild] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_TabChild model=new Lebi_TabChild();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tabid"].ToString()!="")
				{
					model.tabid=int.Parse(ds.Tables[0].Rows[0]["tabid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["protypeid"].ToString()!="")
				{
					model.protypeid=int.Parse(ds.Tables[0].Rows[0]["protypeid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sort"].ToString()!="")
				{
					model.sort=int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["num"].ToString()!="")
				{
					model.num=int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
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
		public Lebi_TabChild GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_TabChild] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_TabChild model=new Lebi_TabChild();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tabid"].ToString()!="")
				{
					model.tabid=int.Parse(ds.Tables[0].Rows[0]["tabid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["protypeid"].ToString()!="")
				{
					model.protypeid=int.Parse(ds.Tables[0].Rows[0]["protypeid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sort"].ToString()!="")
				{
					model.sort=int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["num"].ToString()!="")
				{
					model.num=int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
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
		public Lebi_TabChild GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_TabChild] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_TabChild model=new Lebi_TabChild();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tabid"].ToString()!="")
				{
					model.tabid=int.Parse(ds.Tables[0].Rows[0]["tabid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["protypeid"].ToString()!="")
				{
					model.protypeid=int.Parse(ds.Tables[0].Rows[0]["protypeid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sort"].ToString()!="")
				{
					model.sort=int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["num"].ToString()!="")
				{
					model.num=int.Parse(ds.Tables[0].Rows[0]["num"].ToString());
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
		public List<Lebi_TabChild> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_TabChild]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_TabChild> list = new List<Lebi_TabChild>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_TabChild> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_TabChild]";
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
			List<Lebi_TabChild> list = new List<Lebi_TabChild>();
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
		public List<Lebi_TabChild> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_TabChild] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_TabChild> list = new List<Lebi_TabChild>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_TabChild> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_TabChild]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_TabChild> list = new List<Lebi_TabChild>();
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
		public Lebi_TabChild BindForm(Lebi_TabChild model)
		{
			if (HttpContext.Current.Request["tabid"] != null)
				model.tabid=Shop.Tools.RequestTool.RequestInt("tabid",0);
			if (HttpContext.Current.Request["protypeid"] != null)
				model.protypeid=Shop.Tools.RequestTool.RequestInt("protypeid",0);
			if (HttpContext.Current.Request["sort"] != null)
				model.sort=Shop.Tools.RequestTool.RequestInt("sort",0);
			if (HttpContext.Current.Request["num"] != null)
				model.num=Shop.Tools.RequestTool.RequestInt("num",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_TabChild SafeBindForm(Lebi_TabChild model)
		{
			if (HttpContext.Current.Request["tabid"] != null)
				model.tabid=Shop.Tools.RequestTool.RequestInt("tabid",0);
			if (HttpContext.Current.Request["protypeid"] != null)
				model.protypeid=Shop.Tools.RequestTool.RequestInt("protypeid",0);
			if (HttpContext.Current.Request["sort"] != null)
				model.sort=Shop.Tools.RequestTool.RequestInt("sort",0);
			if (HttpContext.Current.Request["num"] != null)
				model.num=Shop.Tools.RequestTool.RequestInt("num",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_TabChild ReaderBind(IDataReader dataReader)
		{
			Lebi_TabChild model=new Lebi_TabChild();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["tabid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.tabid=(int)ojb;
			}
			ojb = dataReader["protypeid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.protypeid=(int)ojb;
			}
			ojb = dataReader["sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.sort=(int)ojb;
			}
			ojb = dataReader["num"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.num=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_TabChild : Lebi_TabChild_interface
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
				strSql.Append("select " + colName + " from [Lebi_TabChild]");
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
			strSql.Append("select  "+colName+" from [Lebi_TabChild]");
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
			strSql.Append("select count(*) from [Lebi_TabChild]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_TabChild]");
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
			strSql.Append("select max(id) from [Lebi_TabChild]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_TabChild]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_TabChild model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_TabChild](");
			strSql.Append("[tabid],[protypeid],[sort],[num])");
			strSql.Append(" values (");
			strSql.Append("@tabid,@protypeid,@sort,@num)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@tabid", model.tabid),
					new OleDbParameter("@protypeid", model.protypeid),
					new OleDbParameter("@sort", model.sort),
					new OleDbParameter("@num", model.num)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_TabChild model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_TabChild] set ");
			strSql.Append("[tabid]=@tabid,");
			strSql.Append("[protypeid]=@protypeid,");
			strSql.Append("[sort]=@sort,");
			strSql.Append("[num]=@num");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@tabid", model.tabid),
					new OleDbParameter("@protypeid", model.protypeid),
					new OleDbParameter("@sort", model.sort),
					new OleDbParameter("@num", model.num)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_TabChild] ");
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
			strSql.Append("delete from [Lebi_TabChild] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_TabChild] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_TabChild GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_TabChild] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_TabChild model;
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
		public Lebi_TabChild GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_TabChild] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_TabChild model;
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
		public Lebi_TabChild GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_TabChild] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_TabChild model;
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
		public List<Lebi_TabChild> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_TabChild]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_TabChild> list = new List<Lebi_TabChild>();
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
		public List<Lebi_TabChild> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_TabChild]";
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
			List<Lebi_TabChild> list = new List<Lebi_TabChild>();
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
		public List<Lebi_TabChild> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_TabChild] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_TabChild> list = new List<Lebi_TabChild>();
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
		public List<Lebi_TabChild> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_TabChild]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_TabChild> list = new List<Lebi_TabChild>();
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
		public Lebi_TabChild BindForm(Lebi_TabChild model)
		{
			if (HttpContext.Current.Request["tabid"] != null)
				model.tabid=Shop.Tools.RequestTool.RequestInt("tabid",0);
			if (HttpContext.Current.Request["protypeid"] != null)
				model.protypeid=Shop.Tools.RequestTool.RequestInt("protypeid",0);
			if (HttpContext.Current.Request["sort"] != null)
				model.sort=Shop.Tools.RequestTool.RequestInt("sort",0);
			if (HttpContext.Current.Request["num"] != null)
				model.num=Shop.Tools.RequestTool.RequestInt("num",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_TabChild SafeBindForm(Lebi_TabChild model)
		{
			if (HttpContext.Current.Request["tabid"] != null)
				model.tabid=Shop.Tools.RequestTool.RequestInt("tabid",0);
			if (HttpContext.Current.Request["protypeid"] != null)
				model.protypeid=Shop.Tools.RequestTool.RequestInt("protypeid",0);
			if (HttpContext.Current.Request["sort"] != null)
				model.sort=Shop.Tools.RequestTool.RequestInt("sort",0);
			if (HttpContext.Current.Request["num"] != null)
				model.num=Shop.Tools.RequestTool.RequestInt("num",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_TabChild ReaderBind(IDataReader dataReader)
		{
			Lebi_TabChild model=new Lebi_TabChild();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["tabid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.tabid=(int)ojb;
			}
			ojb = dataReader["protypeid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.protypeid=(int)ojb;
			}
			ojb = dataReader["sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.sort=(int)ojb;
			}
			ojb = dataReader["num"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.num=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

