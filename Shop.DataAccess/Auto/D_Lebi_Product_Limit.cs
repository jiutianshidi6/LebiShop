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

	public interface Lebi_Product_Limit_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Product_Limit model);
		void Update(Lebi_Product_Limit model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Product_Limit GetModel(int id);
		Lebi_Product_Limit GetModel(string strWhere);
		Lebi_Product_Limit GetModel(SQLPara para);
		List<Lebi_Product_Limit> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Product_Limit> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Product_Limit> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Product_Limit> GetList(SQLPara para);
		Lebi_Product_Limit BindForm(Lebi_Product_Limit model);
		Lebi_Product_Limit SafeBindForm(Lebi_Product_Limit model);
		Lebi_Product_Limit ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Product_Limit。
	/// </summary>
	public class D_Lebi_Product_Limit
	{
		static Lebi_Product_Limit_interface _Instance;
		public static Lebi_Product_Limit_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Product_Limit();
		            else
		                _Instance = new sqlserver_Lebi_Product_Limit();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Product_Limit()
		{}
		#region  成员方法
	class sqlserver_Lebi_Product_Limit : Lebi_Product_Limit_interface
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
				strSql.Append("select " + colName + " from [Lebi_Product_Limit]");
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
			strSql.Append("select  "+colName+" from [Lebi_Product_Limit]");
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
			strSql.Append("select count(1) from [Lebi_Product_Limit]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Product_Limit]");
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
			strSql.Append("select max(id) from [Lebi_Product_Limit]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Product_Limit]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Product_Limit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Product_Limit](");
			strSql.Append("Product_id,User_id,IsShow,IsPriceShow,IsBuy,UserLevel_id)");
			strSql.Append(" values (");
			strSql.Append("@Product_id,@User_id,@IsShow,@IsPriceShow,@IsBuy,@UserLevel_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Product_id", model.Product_id),
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@IsShow", model.IsShow),
					new SqlParameter("@IsPriceShow", model.IsPriceShow),
					new SqlParameter("@IsBuy", model.IsBuy),
					new SqlParameter("@UserLevel_id", model.UserLevel_id)};

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
		public void Update(Lebi_Product_Limit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Product_Limit] set ");
			strSql.Append("Product_id= @Product_id,");
			strSql.Append("User_id= @User_id,");
			strSql.Append("IsShow= @IsShow,");
			strSql.Append("IsPriceShow= @IsPriceShow,");
			strSql.Append("IsBuy= @IsBuy,");
			strSql.Append("UserLevel_id= @UserLevel_id");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Product_id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@IsPriceShow", SqlDbType.Int,4),
					new SqlParameter("@IsBuy", SqlDbType.Int,4),
					new SqlParameter("@UserLevel_id", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Product_id;
			parameters[2].Value = model.User_id;
			parameters[3].Value = model.IsShow;
			parameters[4].Value = model.IsPriceShow;
			parameters[5].Value = model.IsBuy;
			parameters[6].Value = model.UserLevel_id;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product_Limit] ");
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
			strSql.Append("delete from [Lebi_Product_Limit] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product_Limit] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Product_Limit GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product_Limit] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Product_Limit model=new Lebi_Product_Limit();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPriceShow"].ToString()!="")
				{
					model.IsPriceShow=int.Parse(ds.Tables[0].Rows[0]["IsPriceShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsBuy"].ToString()!="")
				{
					model.IsBuy=int.Parse(ds.Tables[0].Rows[0]["IsBuy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
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
		public Lebi_Product_Limit GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product_Limit] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Product_Limit model=new Lebi_Product_Limit();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPriceShow"].ToString()!="")
				{
					model.IsPriceShow=int.Parse(ds.Tables[0].Rows[0]["IsPriceShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsBuy"].ToString()!="")
				{
					model.IsBuy=int.Parse(ds.Tables[0].Rows[0]["IsBuy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
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
		public Lebi_Product_Limit GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Product_Limit] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Product_Limit model=new Lebi_Product_Limit();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPriceShow"].ToString()!="")
				{
					model.IsPriceShow=int.Parse(ds.Tables[0].Rows[0]["IsPriceShow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsBuy"].ToString()!="")
				{
					model.IsBuy=int.Parse(ds.Tables[0].Rows[0]["IsBuy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLevel_id"].ToString()!="")
				{
					model.UserLevel_id=int.Parse(ds.Tables[0].Rows[0]["UserLevel_id"].ToString());
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
		public List<Lebi_Product_Limit> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Product_Limit]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Product_Limit> list = new List<Lebi_Product_Limit>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Product_Limit> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Product_Limit]";
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
			List<Lebi_Product_Limit> list = new List<Lebi_Product_Limit>();
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
		public List<Lebi_Product_Limit> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Product_Limit] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Product_Limit> list = new List<Lebi_Product_Limit>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Product_Limit> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Product_Limit]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Product_Limit> list = new List<Lebi_Product_Limit>();
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
		public Lebi_Product_Limit BindForm(Lebi_Product_Limit model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["IsPriceShow"] != null)
				model.IsPriceShow=Shop.Tools.RequestTool.RequestInt("IsPriceShow",0);
			if (HttpContext.Current.Request["IsBuy"] != null)
				model.IsBuy=Shop.Tools.RequestTool.RequestInt("IsBuy",0);
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Product_Limit SafeBindForm(Lebi_Product_Limit model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["IsPriceShow"] != null)
				model.IsPriceShow=Shop.Tools.RequestTool.RequestInt("IsPriceShow",0);
			if (HttpContext.Current.Request["IsBuy"] != null)
				model.IsBuy=Shop.Tools.RequestTool.RequestInt("IsBuy",0);
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Product_Limit ReaderBind(IDataReader dataReader)
		{
			Lebi_Product_Limit model=new Lebi_Product_Limit();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(int)ojb;
			}
			ojb = dataReader["IsPriceShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPriceShow=(int)ojb;
			}
			ojb = dataReader["IsBuy"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsBuy=(int)ojb;
			}
			ojb = dataReader["UserLevel_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLevel_id=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Product_Limit : Lebi_Product_Limit_interface
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
				strSql.Append("select " + colName + " from [Lebi_Product_Limit]");
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
			strSql.Append("select  "+colName+" from [Lebi_Product_Limit]");
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
			strSql.Append("select count(*) from [Lebi_Product_Limit]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Product_Limit]");
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
			strSql.Append("select max(id) from [Lebi_Product_Limit]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Product_Limit]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Product_Limit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Product_Limit](");
			strSql.Append("[Product_id],[User_id],[IsShow],[IsPriceShow],[IsBuy],[UserLevel_id])");
			strSql.Append(" values (");
			strSql.Append("@Product_id,@User_id,@IsShow,@IsPriceShow,@IsBuy,@UserLevel_id)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@IsShow", model.IsShow),
					new OleDbParameter("@IsPriceShow", model.IsPriceShow),
					new OleDbParameter("@IsBuy", model.IsBuy),
					new OleDbParameter("@UserLevel_id", model.UserLevel_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Product_Limit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Product_Limit] set ");
			strSql.Append("[Product_id]=@Product_id,");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[IsShow]=@IsShow,");
			strSql.Append("[IsPriceShow]=@IsPriceShow,");
			strSql.Append("[IsBuy]=@IsBuy,");
			strSql.Append("[UserLevel_id]=@UserLevel_id");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@IsShow", model.IsShow),
					new OleDbParameter("@IsPriceShow", model.IsPriceShow),
					new OleDbParameter("@IsBuy", model.IsBuy),
					new OleDbParameter("@UserLevel_id", model.UserLevel_id)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product_Limit] ");
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
			strSql.Append("delete from [Lebi_Product_Limit] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Product_Limit] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Product_Limit GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product_Limit] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Product_Limit model;
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
		public Lebi_Product_Limit GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Product_Limit] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Product_Limit model;
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
		public Lebi_Product_Limit GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Product_Limit] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Product_Limit model;
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
		public List<Lebi_Product_Limit> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Product_Limit]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Product_Limit> list = new List<Lebi_Product_Limit>();
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
		public List<Lebi_Product_Limit> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Product_Limit]";
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
			List<Lebi_Product_Limit> list = new List<Lebi_Product_Limit>();
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
		public List<Lebi_Product_Limit> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Product_Limit] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Product_Limit> list = new List<Lebi_Product_Limit>();
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
		public List<Lebi_Product_Limit> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Product_Limit]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Product_Limit> list = new List<Lebi_Product_Limit>();
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
		public Lebi_Product_Limit BindForm(Lebi_Product_Limit model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["IsPriceShow"] != null)
				model.IsPriceShow=Shop.Tools.RequestTool.RequestInt("IsPriceShow",0);
			if (HttpContext.Current.Request["IsBuy"] != null)
				model.IsBuy=Shop.Tools.RequestTool.RequestInt("IsBuy",0);
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Product_Limit SafeBindForm(Lebi_Product_Limit model)
		{
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["IsPriceShow"] != null)
				model.IsPriceShow=Shop.Tools.RequestTool.RequestInt("IsPriceShow",0);
			if (HttpContext.Current.Request["IsBuy"] != null)
				model.IsBuy=Shop.Tools.RequestTool.RequestInt("IsBuy",0);
			if (HttpContext.Current.Request["UserLevel_id"] != null)
				model.UserLevel_id=Shop.Tools.RequestTool.RequestInt("UserLevel_id",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Product_Limit ReaderBind(IDataReader dataReader)
		{
			Lebi_Product_Limit model=new Lebi_Product_Limit();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(int)ojb;
			}
			ojb = dataReader["IsPriceShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPriceShow=(int)ojb;
			}
			ojb = dataReader["IsBuy"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsBuy=(int)ojb;
			}
			ojb = dataReader["UserLevel_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLevel_id=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

