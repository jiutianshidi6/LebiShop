using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Web;
using Shop.DataAccess;
using Shop.Model;
namespace Shop.SQLDataAccess
{

	public interface Lebi_Mail_tpl_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Shop.Model.Lebi_Mail_tpl model);
		void Update(Shop.Model.Lebi_Mail_tpl model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Shop.Model.Lebi_Mail_tpl GetModel(int id);
		Shop.Model.Lebi_Mail_tpl GetModel(string strWhere);
		Shop.Model.Lebi_Mail_tpl GetModel(SQLPara para);
		List<Shop.Model.Lebi_Mail_tpl> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Shop.Model.Lebi_Mail_tpl> GetList(SQLPara para, int PageSize, int page);
		List<Shop.Model.Lebi_Mail_tpl> GetList(string strWhere, string strFieldOrder);
		List<Shop.Model.Lebi_Mail_tpl> GetList(SQLPara para);
		Shop.Model.Lebi_Mail_tpl BindForm(Shop.Model.Lebi_Mail_tpl model);
		Shop.Model.Lebi_Mail_tpl SafeBindForm(Shop.Model.Lebi_Mail_tpl model);
		Shop.Model.Lebi_Mail_tpl ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Mail_tpl。
	/// </summary>
	public class D_Lebi_Mail_tpl
	{
		static Lebi_Mail_tpl_interface _Instance;
		public static Lebi_Mail_tpl_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_D_Lebi_Mail_tpl();
		            else
		                _Instance = new sqlserver_D_Lebi_Mail_tpl();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Mail_tpl()
		{}
		#region  成员方法
	class sqlserver_D_Lebi_Mail_tpl : Lebi_Mail_tpl_interface
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
				strSql.Append("select " + colName + " from [Lebi_Mail_tpl]");
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
			strSql.Append("select  "+colName+" from [Lebi_Mail_tpl]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToString( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}

		/// <summary>
		/// 计算记录条数
		/// </summary>
		public int Counts(string strWhere)
		{
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return Counts(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Mail_tpl]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Mail_tpl]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxID(string strWhere)
		{
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetMaxID(para);
			}
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select max(id) from [Lebi_Mail_tpl]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Mail_tpl]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.Lebi_Mail_tpl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Mail_tpl](");
			strSql.Append("Mail_zc_Title,Mail_zc_Content,Mail_dd_Title,Mail_dd_Content,Mail_ddqrfh_Title,Mail_ddqrfh_content)");
			strSql.Append(" values (");
			strSql.Append("@Mail_zc_Title,@Mail_zc_Content,@Mail_dd_Title,@Mail_dd_Content,@Mail_ddqrfh_Title,@Mail_ddqrfh_content)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Mail_zc_Title", model.Mail_zc_Title),
					new SqlParameter("@Mail_zc_Content", model.Mail_zc_Content),
					new SqlParameter("@Mail_dd_Title", model.Mail_dd_Title),
					new SqlParameter("@Mail_dd_Content", model.Mail_dd_Content),
					new SqlParameter("@Mail_ddqrfh_Title", model.Mail_ddqrfh_Title),
					new SqlParameter("@Mail_ddqrfh_content", model.Mail_ddqrfh_content)};

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
		public void Update(Shop.Model.Lebi_Mail_tpl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Mail_tpl] set ");
			strSql.Append("Mail_zc_Title= @Mail_zc_Title,");
			strSql.Append("Mail_zc_Content= @Mail_zc_Content,");
			strSql.Append("Mail_dd_Title= @Mail_dd_Title,");
			strSql.Append("Mail_dd_Content= @Mail_dd_Content,");
			strSql.Append("Mail_ddqrfh_Title= @Mail_ddqrfh_Title,");
			strSql.Append("Mail_ddqrfh_content= @Mail_ddqrfh_content");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Mail_zc_Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Mail_zc_Content", SqlDbType.NVarChar,2000),
					new SqlParameter("@Mail_dd_Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Mail_dd_Content", SqlDbType.NVarChar,2000),
					new SqlParameter("@Mail_ddqrfh_Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Mail_ddqrfh_content", SqlDbType.NVarChar,2000)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Mail_zc_Title;
			parameters[2].Value = model.Mail_zc_Content;
			parameters[3].Value = model.Mail_dd_Title;
			parameters[4].Value = model.Mail_dd_Content;
			parameters[5].Value = model.Mail_ddqrfh_Title;
			parameters[6].Value = model.Mail_ddqrfh_content;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Mail_tpl] ");
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
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				Delete(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Mail_tpl] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Mail_tpl] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Shop.Model.Lebi_Mail_tpl GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Mail_tpl] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Shop.Model.Lebi_Mail_tpl model=new Shop.Model.Lebi_Mail_tpl();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Mail_zc_Title=ds.Tables[0].Rows[0]["Mail_zc_Title"].ToString();
				model.Mail_zc_Content=ds.Tables[0].Rows[0]["Mail_zc_Content"].ToString();
				model.Mail_dd_Title=ds.Tables[0].Rows[0]["Mail_dd_Title"].ToString();
				model.Mail_dd_Content=ds.Tables[0].Rows[0]["Mail_dd_Content"].ToString();
				model.Mail_ddqrfh_Title=ds.Tables[0].Rows[0]["Mail_ddqrfh_Title"].ToString();
				model.Mail_ddqrfh_content=ds.Tables[0].Rows[0]["Mail_ddqrfh_content"].ToString();
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
		public Shop.Model.Lebi_Mail_tpl GetModel(string strWhere)
		{
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Mail_tpl] ");
			strSql.Append(" where "+ strWhere +"");
			Shop.Model.Lebi_Mail_tpl model=new Shop.Model.Lebi_Mail_tpl();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Mail_zc_Title=ds.Tables[0].Rows[0]["Mail_zc_Title"].ToString();
				model.Mail_zc_Content=ds.Tables[0].Rows[0]["Mail_zc_Content"].ToString();
				model.Mail_dd_Title=ds.Tables[0].Rows[0]["Mail_dd_Title"].ToString();
				model.Mail_dd_Content=ds.Tables[0].Rows[0]["Mail_dd_Content"].ToString();
				model.Mail_ddqrfh_Title=ds.Tables[0].Rows[0]["Mail_ddqrfh_Title"].ToString();
				model.Mail_ddqrfh_content=ds.Tables[0].Rows[0]["Mail_ddqrfh_content"].ToString();
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
		public Shop.Model.Lebi_Mail_tpl GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Mail_tpl] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Shop.Model.Lebi_Mail_tpl model=new Shop.Model.Lebi_Mail_tpl();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Mail_zc_Title=ds.Tables[0].Rows[0]["Mail_zc_Title"].ToString();
				model.Mail_zc_Content=ds.Tables[0].Rows[0]["Mail_zc_Content"].ToString();
				model.Mail_dd_Title=ds.Tables[0].Rows[0]["Mail_dd_Title"].ToString();
				model.Mail_dd_Content=ds.Tables[0].Rows[0]["Mail_dd_Content"].ToString();
				model.Mail_ddqrfh_Title=ds.Tables[0].Rows[0]["Mail_ddqrfh_Title"].ToString();
				model.Mail_ddqrfh_content=ds.Tables[0].Rows[0]["Mail_ddqrfh_content"].ToString();
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
		public List<Shop.Model.Lebi_Mail_tpl> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Mail_tpl]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Shop.Model.Lebi_Mail_tpl> list = new List<Shop.Model.Lebi_Mail_tpl>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Shop.Model.Lebi_Mail_tpl> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Mail_tpl]";
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
			List<Shop.Model.Lebi_Mail_tpl> list = new List<Shop.Model.Lebi_Mail_tpl>();
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
		public List<Shop.Model.Lebi_Mail_tpl> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Mail_tpl] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Shop.Model.Lebi_Mail_tpl> list = new List<Shop.Model.Lebi_Mail_tpl>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Shop.Model.Lebi_Mail_tpl> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Mail_tpl]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Shop.Model.Lebi_Mail_tpl> list = new List<Shop.Model.Lebi_Mail_tpl>();
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
		public Shop.Model.Lebi_Mail_tpl BindForm(Shop.Model.Lebi_Mail_tpl model)
		{
			if (HttpContext.Current.Request["Mail_zc_Title"] != null)
				model.Mail_zc_Title=Shop.Tools.RequestTool.RequestString("Mail_zc_Title");
			if (HttpContext.Current.Request["Mail_zc_Content"] != null)
				model.Mail_zc_Content=Shop.Tools.RequestTool.RequestString("Mail_zc_Content");
			if (HttpContext.Current.Request["Mail_dd_Title"] != null)
				model.Mail_dd_Title=Shop.Tools.RequestTool.RequestString("Mail_dd_Title");
			if (HttpContext.Current.Request["Mail_dd_Content"] != null)
				model.Mail_dd_Content=Shop.Tools.RequestTool.RequestString("Mail_dd_Content");
			if (HttpContext.Current.Request["Mail_ddqrfh_Title"] != null)
				model.Mail_ddqrfh_Title=Shop.Tools.RequestTool.RequestString("Mail_ddqrfh_Title");
			if (HttpContext.Current.Request["Mail_ddqrfh_content"] != null)
				model.Mail_ddqrfh_content=Shop.Tools.RequestTool.RequestString("Mail_ddqrfh_content");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Shop.Model.Lebi_Mail_tpl SafeBindForm(Shop.Model.Lebi_Mail_tpl model)
		{
			if (HttpContext.Current.Request["Mail_zc_Title"] != null)
				model.Mail_zc_Title=Shop.Tools.RequestTool.RequestSafeString("Mail_zc_Title");
			if (HttpContext.Current.Request["Mail_zc_Content"] != null)
				model.Mail_zc_Content=Shop.Tools.RequestTool.RequestSafeString("Mail_zc_Content");
			if (HttpContext.Current.Request["Mail_dd_Title"] != null)
				model.Mail_dd_Title=Shop.Tools.RequestTool.RequestSafeString("Mail_dd_Title");
			if (HttpContext.Current.Request["Mail_dd_Content"] != null)
				model.Mail_dd_Content=Shop.Tools.RequestTool.RequestSafeString("Mail_dd_Content");
			if (HttpContext.Current.Request["Mail_ddqrfh_Title"] != null)
				model.Mail_ddqrfh_Title=Shop.Tools.RequestTool.RequestSafeString("Mail_ddqrfh_Title");
			if (HttpContext.Current.Request["Mail_ddqrfh_content"] != null)
				model.Mail_ddqrfh_content=Shop.Tools.RequestTool.RequestSafeString("Mail_ddqrfh_content");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Shop.Model.Lebi_Mail_tpl ReaderBind(IDataReader dataReader)
		{
			Shop.Model.Lebi_Mail_tpl model=new Shop.Model.Lebi_Mail_tpl();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Mail_zc_Title=dataReader["Mail_zc_Title"].ToString();
			model.Mail_zc_Content=dataReader["Mail_zc_Content"].ToString();
			model.Mail_dd_Title=dataReader["Mail_dd_Title"].ToString();
			model.Mail_dd_Content=dataReader["Mail_dd_Content"].ToString();
			model.Mail_ddqrfh_Title=dataReader["Mail_ddqrfh_Title"].ToString();
			model.Mail_ddqrfh_content=dataReader["Mail_ddqrfh_content"].ToString();
			return model;
		}

	}
	class access_D_Lebi_Mail_tpl : Lebi_Mail_tpl_interface
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
				strSql.Append("select " + colName + " from [Lebi_Mail_tpl]");
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
			strSql.Append("select  "+colName+" from [Lebi_Mail_tpl]");
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
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return Counts(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Mail_tpl]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Mail_tpl]");
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
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetMaxID(para);
			}
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select max(id) from [Lebi_Mail_tpl]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Mail_tpl]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Shop.Model.Lebi_Mail_tpl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Mail_tpl](");
			strSql.Append("[Mail_zc_Title],[Mail_zc_Content],[Mail_dd_Title],[Mail_dd_Content],[Mail_ddqrfh_Title],[Mail_ddqrfh_content])");
			strSql.Append(" values (");
			strSql.Append("@Mail_zc_Title,@Mail_zc_Content,@Mail_dd_Title,@Mail_dd_Content,@Mail_ddqrfh_Title,@Mail_ddqrfh_content)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Mail_zc_Title", model.Mail_zc_Title),
					new OleDbParameter("@Mail_zc_Content", model.Mail_zc_Content),
					new OleDbParameter("@Mail_dd_Title", model.Mail_dd_Title),
					new OleDbParameter("@Mail_dd_Content", model.Mail_dd_Content),
					new OleDbParameter("@Mail_ddqrfh_Title", model.Mail_ddqrfh_Title),
					new OleDbParameter("@Mail_ddqrfh_content", model.Mail_ddqrfh_content)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Shop.Model.Lebi_Mail_tpl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Mail_tpl] set ");
			strSql.Append("[Mail_zc_Title]=@Mail_zc_Title,");
			strSql.Append("[Mail_zc_Content]=@Mail_zc_Content,");
			strSql.Append("[Mail_dd_Title]=@Mail_dd_Title,");
			strSql.Append("[Mail_dd_Content]=@Mail_dd_Content,");
			strSql.Append("[Mail_ddqrfh_Title]=@Mail_ddqrfh_Title,");
			strSql.Append("[Mail_ddqrfh_content]=@Mail_ddqrfh_content");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Mail_zc_Title", model.Mail_zc_Title),
					new OleDbParameter("@Mail_zc_Content", model.Mail_zc_Content),
					new OleDbParameter("@Mail_dd_Title", model.Mail_dd_Title),
					new OleDbParameter("@Mail_dd_Content", model.Mail_dd_Content),
					new OleDbParameter("@Mail_ddqrfh_Title", model.Mail_ddqrfh_Title),
					new OleDbParameter("@Mail_ddqrfh_content", model.Mail_ddqrfh_content)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Mail_tpl] ");
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
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				Delete(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Mail_tpl] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Mail_tpl] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Shop.Model.Lebi_Mail_tpl GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Mail_tpl] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Shop.Model.Lebi_Mail_tpl model;
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
		public Shop.Model.Lebi_Mail_tpl GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Mail_tpl] ");
			strSql.Append(" where "+ strWhere +"");
			Shop.Model.Lebi_Mail_tpl model;
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
		public Shop.Model.Lebi_Mail_tpl GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Mail_tpl] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Shop.Model.Lebi_Mail_tpl model;
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
		public List<Shop.Model.Lebi_Mail_tpl> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Mail_tpl]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Shop.Model.Lebi_Mail_tpl> list = new List<Shop.Model.Lebi_Mail_tpl>();
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
		public List<Shop.Model.Lebi_Mail_tpl> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Mail_tpl]";
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
			List<Shop.Model.Lebi_Mail_tpl> list = new List<Shop.Model.Lebi_Mail_tpl>();
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
		public List<Shop.Model.Lebi_Mail_tpl> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("}") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Mail_tpl] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Shop.Model.Lebi_Mail_tpl> list = new List<Shop.Model.Lebi_Mail_tpl>();
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
		public List<Shop.Model.Lebi_Mail_tpl> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Mail_tpl]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Shop.Model.Lebi_Mail_tpl> list = new List<Shop.Model.Lebi_Mail_tpl>();
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
		public Shop.Model.Lebi_Mail_tpl BindForm(Shop.Model.Lebi_Mail_tpl model)
		{
			if (HttpContext.Current.Request["Mail_zc_Title"] != null)
				model.Mail_zc_Title=Shop.Tools.RequestTool.RequestString("Mail_zc_Title");
			if (HttpContext.Current.Request["Mail_zc_Content"] != null)
				model.Mail_zc_Content=Shop.Tools.RequestTool.RequestString("Mail_zc_Content");
			if (HttpContext.Current.Request["Mail_dd_Title"] != null)
				model.Mail_dd_Title=Shop.Tools.RequestTool.RequestString("Mail_dd_Title");
			if (HttpContext.Current.Request["Mail_dd_Content"] != null)
				model.Mail_dd_Content=Shop.Tools.RequestTool.RequestString("Mail_dd_Content");
			if (HttpContext.Current.Request["Mail_ddqrfh_Title"] != null)
				model.Mail_ddqrfh_Title=Shop.Tools.RequestTool.RequestString("Mail_ddqrfh_Title");
			if (HttpContext.Current.Request["Mail_ddqrfh_content"] != null)
				model.Mail_ddqrfh_content=Shop.Tools.RequestTool.RequestString("Mail_ddqrfh_content");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Shop.Model.Lebi_Mail_tpl SafeBindForm(Shop.Model.Lebi_Mail_tpl model)
		{
			if (HttpContext.Current.Request["Mail_zc_Title"] != null)
				model.Mail_zc_Title=Shop.Tools.RequestTool.RequestSafeString("Mail_zc_Title");
			if (HttpContext.Current.Request["Mail_zc_Content"] != null)
				model.Mail_zc_Content=Shop.Tools.RequestTool.RequestSafeString("Mail_zc_Content");
			if (HttpContext.Current.Request["Mail_dd_Title"] != null)
				model.Mail_dd_Title=Shop.Tools.RequestTool.RequestSafeString("Mail_dd_Title");
			if (HttpContext.Current.Request["Mail_dd_Content"] != null)
				model.Mail_dd_Content=Shop.Tools.RequestTool.RequestSafeString("Mail_dd_Content");
			if (HttpContext.Current.Request["Mail_ddqrfh_Title"] != null)
				model.Mail_ddqrfh_Title=Shop.Tools.RequestTool.RequestSafeString("Mail_ddqrfh_Title");
			if (HttpContext.Current.Request["Mail_ddqrfh_content"] != null)
				model.Mail_ddqrfh_content=Shop.Tools.RequestTool.RequestSafeString("Mail_ddqrfh_content");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Shop.Model.Lebi_Mail_tpl ReaderBind(IDataReader dataReader)
		{
			Shop.Model.Lebi_Mail_tpl model=new Shop.Model.Lebi_Mail_tpl();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Mail_zc_Title=dataReader["Mail_zc_Title"].ToString();
			model.Mail_zc_Content=dataReader["Mail_zc_Content"].ToString();
			model.Mail_dd_Title=dataReader["Mail_dd_Title"].ToString();
			model.Mail_dd_Content=dataReader["Mail_dd_Content"].ToString();
			model.Mail_ddqrfh_Title=dataReader["Mail_ddqrfh_Title"].ToString();
			model.Mail_ddqrfh_content=dataReader["Mail_ddqrfh_content"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

