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

	public interface Lebi_Cash_alipay_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Cash_alipay model);
		void Update(Lebi_Cash_alipay model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Cash_alipay GetModel(int id);
		Lebi_Cash_alipay GetModel(string strWhere);
		Lebi_Cash_alipay GetModel(SQLPara para);
		List<Lebi_Cash_alipay> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Cash_alipay> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Cash_alipay> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Cash_alipay> GetList(SQLPara para);
		Lebi_Cash_alipay BindForm(Lebi_Cash_alipay model);
		Lebi_Cash_alipay SafeBindForm(Lebi_Cash_alipay model);
		Lebi_Cash_alipay ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Cash_alipay。
	/// </summary>
	public class D_Lebi_Cash_alipay
	{
		static Lebi_Cash_alipay_interface _Instance;
		public static Lebi_Cash_alipay_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Cash_alipay();
		            else
		                _Instance = new sqlserver_Lebi_Cash_alipay();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Cash_alipay()
		{}
		#region  成员方法
	class sqlserver_Lebi_Cash_alipay : Lebi_Cash_alipay_interface
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
				strSql.Append("select " + colName + " from [Lebi_Cash_alipay]");
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
			strSql.Append("select  "+colName+" from [Lebi_Cash_alipay]");
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
			strSql.Append("select count(1) from [Lebi_Cash_alipay]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Cash_alipay]");
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
			strSql.Append("select max(id) from [Lebi_Cash_alipay]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Cash_alipay]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Cash_alipay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Cash_alipay](");
			strSql.Append("Code,Cash_ids,Time_Add,alipay_user,alipay_username,Money,count,Content,IsPaid,Time_Paid,result_yes,result_no)");
			strSql.Append(" values (");
			strSql.Append("@Code,@Cash_ids,@Time_Add,@alipay_user,@alipay_username,@Money,@count,@Content,@IsPaid,@Time_Paid,@result_yes,@result_no)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@Cash_ids", model.Cash_ids),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@alipay_user", model.alipay_user),
					new SqlParameter("@alipay_username", model.alipay_username),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@count", model.count),
					new SqlParameter("@Content", model.Content),
					new SqlParameter("@IsPaid", model.IsPaid),
					new SqlParameter("@Time_Paid", model.Time_Paid),
					new SqlParameter("@result_yes", model.result_yes),
					new SqlParameter("@result_no", model.result_no)};

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
		public void Update(Lebi_Cash_alipay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Cash_alipay] set ");
			strSql.Append("Code= @Code,");
			strSql.Append("Cash_ids= @Cash_ids,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("alipay_user= @alipay_user,");
			strSql.Append("alipay_username= @alipay_username,");
			strSql.Append("Money= @Money,");
			strSql.Append("count= @count,");
			strSql.Append("Content= @Content,");
			strSql.Append("IsPaid= @IsPaid,");
			strSql.Append("Time_Paid= @Time_Paid,");
			strSql.Append("result_yes= @result_yes,");
			strSql.Append("result_no= @result_no");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Cash_ids", SqlDbType.NText),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@alipay_user", SqlDbType.NVarChar,50),
					new SqlParameter("@alipay_username", SqlDbType.NVarChar,50),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@IsPaid", SqlDbType.Int,4),
					new SqlParameter("@Time_Paid", SqlDbType.DateTime),
					new SqlParameter("@result_yes", SqlDbType.NText),
					new SqlParameter("@result_no", SqlDbType.NText)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Cash_ids;
			parameters[3].Value = model.Time_Add;
			parameters[4].Value = model.alipay_user;
			parameters[5].Value = model.alipay_username;
			parameters[6].Value = model.Money;
			parameters[7].Value = model.count;
			parameters[8].Value = model.Content;
			parameters[9].Value = model.IsPaid;
			parameters[10].Value = model.Time_Paid;
			parameters[11].Value = model.result_yes;
			parameters[12].Value = model.result_no;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Cash_alipay] ");
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
			strSql.Append("delete from [Lebi_Cash_alipay] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Cash_alipay] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Cash_alipay GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Cash_alipay] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Cash_alipay model=new Lebi_Cash_alipay();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Cash_ids=ds.Tables[0].Rows[0]["Cash_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.alipay_user=ds.Tables[0].Rows[0]["alipay_user"].ToString();
				model.alipay_username=ds.Tables[0].Rows[0]["alipay_username"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["count"].ToString()!="")
				{
					model.count=int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["IsPaid"].ToString()!="")
				{
					model.IsPaid=int.Parse(ds.Tables[0].Rows[0]["IsPaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Paid"].ToString()!="")
				{
					model.Time_Paid=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Paid"].ToString());
				}
				model.result_yes=ds.Tables[0].Rows[0]["result_yes"].ToString();
				model.result_no=ds.Tables[0].Rows[0]["result_no"].ToString();
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
		public Lebi_Cash_alipay GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Cash_alipay] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Cash_alipay model=new Lebi_Cash_alipay();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Cash_ids=ds.Tables[0].Rows[0]["Cash_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.alipay_user=ds.Tables[0].Rows[0]["alipay_user"].ToString();
				model.alipay_username=ds.Tables[0].Rows[0]["alipay_username"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["count"].ToString()!="")
				{
					model.count=int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["IsPaid"].ToString()!="")
				{
					model.IsPaid=int.Parse(ds.Tables[0].Rows[0]["IsPaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Paid"].ToString()!="")
				{
					model.Time_Paid=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Paid"].ToString());
				}
				model.result_yes=ds.Tables[0].Rows[0]["result_yes"].ToString();
				model.result_no=ds.Tables[0].Rows[0]["result_no"].ToString();
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
		public Lebi_Cash_alipay GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Cash_alipay] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Cash_alipay model=new Lebi_Cash_alipay();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Cash_ids=ds.Tables[0].Rows[0]["Cash_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				model.alipay_user=ds.Tables[0].Rows[0]["alipay_user"].ToString();
				model.alipay_username=ds.Tables[0].Rows[0]["alipay_username"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["count"].ToString()!="")
				{
					model.count=int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["IsPaid"].ToString()!="")
				{
					model.IsPaid=int.Parse(ds.Tables[0].Rows[0]["IsPaid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Paid"].ToString()!="")
				{
					model.Time_Paid=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Paid"].ToString());
				}
				model.result_yes=ds.Tables[0].Rows[0]["result_yes"].ToString();
				model.result_no=ds.Tables[0].Rows[0]["result_no"].ToString();
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
		public List<Lebi_Cash_alipay> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Cash_alipay]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Cash_alipay> list = new List<Lebi_Cash_alipay>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Cash_alipay> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Cash_alipay]";
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
			List<Lebi_Cash_alipay> list = new List<Lebi_Cash_alipay>();
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
		public List<Lebi_Cash_alipay> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Cash_alipay] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Cash_alipay> list = new List<Lebi_Cash_alipay>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Cash_alipay> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Cash_alipay]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Cash_alipay> list = new List<Lebi_Cash_alipay>();
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
		public Lebi_Cash_alipay BindForm(Lebi_Cash_alipay model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Cash_ids"] != null)
				model.Cash_ids=Shop.Tools.RequestTool.RequestString("Cash_ids");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["alipay_user"] != null)
				model.alipay_user=Shop.Tools.RequestTool.RequestString("alipay_user");
			if (HttpContext.Current.Request["alipay_username"] != null)
				model.alipay_username=Shop.Tools.RequestTool.RequestString("alipay_username");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["count"] != null)
				model.count=Shop.Tools.RequestTool.RequestInt("count",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["result_yes"] != null)
				model.result_yes=Shop.Tools.RequestTool.RequestString("result_yes");
			if (HttpContext.Current.Request["result_no"] != null)
				model.result_no=Shop.Tools.RequestTool.RequestString("result_no");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Cash_alipay SafeBindForm(Lebi_Cash_alipay model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Cash_ids"] != null)
				model.Cash_ids=Shop.Tools.RequestTool.RequestSafeString("Cash_ids");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["alipay_user"] != null)
				model.alipay_user=Shop.Tools.RequestTool.RequestSafeString("alipay_user");
			if (HttpContext.Current.Request["alipay_username"] != null)
				model.alipay_username=Shop.Tools.RequestTool.RequestSafeString("alipay_username");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["count"] != null)
				model.count=Shop.Tools.RequestTool.RequestInt("count",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["result_yes"] != null)
				model.result_yes=Shop.Tools.RequestTool.RequestSafeString("result_yes");
			if (HttpContext.Current.Request["result_no"] != null)
				model.result_no=Shop.Tools.RequestTool.RequestSafeString("result_no");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Cash_alipay ReaderBind(IDataReader dataReader)
		{
			Lebi_Cash_alipay model=new Lebi_Cash_alipay();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Code=dataReader["Code"].ToString();
			model.Cash_ids=dataReader["Cash_ids"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			model.alipay_user=dataReader["alipay_user"].ToString();
			model.alipay_username=dataReader["alipay_username"].ToString();
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.count=(int)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["IsPaid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPaid=(int)ojb;
			}
			ojb = dataReader["Time_Paid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Paid=(DateTime)ojb;
			}
			model.result_yes=dataReader["result_yes"].ToString();
			model.result_no=dataReader["result_no"].ToString();
			return model;
		}

	}
	class access_Lebi_Cash_alipay : Lebi_Cash_alipay_interface
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
				strSql.Append("select " + colName + " from [Lebi_Cash_alipay]");
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
			strSql.Append("select  "+colName+" from [Lebi_Cash_alipay]");
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
			strSql.Append("select count(*) from [Lebi_Cash_alipay]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Cash_alipay]");
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
			strSql.Append("select max(id) from [Lebi_Cash_alipay]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Cash_alipay]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Cash_alipay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Cash_alipay](");
			strSql.Append("[Code],[Cash_ids],[Time_Add],[alipay_user],[alipay_username],[Money],[count],[Content],[IsPaid],[Time_Paid],[result_yes],[result_no])");
			strSql.Append(" values (");
			strSql.Append("@Code,@Cash_ids,@Time_Add,@alipay_user,@alipay_username,@Money,@count,@Content,@IsPaid,@Time_Paid,@result_yes,@result_no)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Cash_ids", model.Cash_ids),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@alipay_user", model.alipay_user),
					new OleDbParameter("@alipay_username", model.alipay_username),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@count", model.count),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@IsPaid", model.IsPaid),
					new OleDbParameter("@Time_Paid", model.Time_Paid.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@result_yes", model.result_yes),
					new OleDbParameter("@result_no", model.result_no)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Cash_alipay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Cash_alipay] set ");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[Cash_ids]=@Cash_ids,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[alipay_user]=@alipay_user,");
			strSql.Append("[alipay_username]=@alipay_username,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[count]=@count,");
			strSql.Append("[Content]=@Content,");
			strSql.Append("[IsPaid]=@IsPaid,");
			strSql.Append("[Time_Paid]=@Time_Paid,");
			strSql.Append("[result_yes]=@result_yes,");
			strSql.Append("[result_no]=@result_no");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Cash_ids", model.Cash_ids),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@alipay_user", model.alipay_user),
					new OleDbParameter("@alipay_username", model.alipay_username),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@count", model.count),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@IsPaid", model.IsPaid),
					new OleDbParameter("@Time_Paid", model.Time_Paid.ToString("yyyy-MM-dd hh:mm:ss")),
					new OleDbParameter("@result_yes", model.result_yes),
					new OleDbParameter("@result_no", model.result_no)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Cash_alipay] ");
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
			strSql.Append("delete from [Lebi_Cash_alipay] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Cash_alipay] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Cash_alipay GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Cash_alipay] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Cash_alipay model;
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
		public Lebi_Cash_alipay GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Cash_alipay] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Cash_alipay model;
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
		public Lebi_Cash_alipay GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Cash_alipay] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Cash_alipay model;
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
		public List<Lebi_Cash_alipay> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Cash_alipay]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Cash_alipay> list = new List<Lebi_Cash_alipay>();
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
		public List<Lebi_Cash_alipay> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Cash_alipay]";
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
			List<Lebi_Cash_alipay> list = new List<Lebi_Cash_alipay>();
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
		public List<Lebi_Cash_alipay> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Cash_alipay] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Cash_alipay> list = new List<Lebi_Cash_alipay>();
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
		public List<Lebi_Cash_alipay> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Cash_alipay]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Cash_alipay> list = new List<Lebi_Cash_alipay>();
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
		public Lebi_Cash_alipay BindForm(Lebi_Cash_alipay model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Cash_ids"] != null)
				model.Cash_ids=Shop.Tools.RequestTool.RequestString("Cash_ids");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["alipay_user"] != null)
				model.alipay_user=Shop.Tools.RequestTool.RequestString("alipay_user");
			if (HttpContext.Current.Request["alipay_username"] != null)
				model.alipay_username=Shop.Tools.RequestTool.RequestString("alipay_username");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["count"] != null)
				model.count=Shop.Tools.RequestTool.RequestInt("count",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["result_yes"] != null)
				model.result_yes=Shop.Tools.RequestTool.RequestString("result_yes");
			if (HttpContext.Current.Request["result_no"] != null)
				model.result_no=Shop.Tools.RequestTool.RequestString("result_no");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Cash_alipay SafeBindForm(Lebi_Cash_alipay model)
		{
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Cash_ids"] != null)
				model.Cash_ids=Shop.Tools.RequestTool.RequestSafeString("Cash_ids");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["alipay_user"] != null)
				model.alipay_user=Shop.Tools.RequestTool.RequestSafeString("alipay_user");
			if (HttpContext.Current.Request["alipay_username"] != null)
				model.alipay_username=Shop.Tools.RequestTool.RequestSafeString("alipay_username");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["count"] != null)
				model.count=Shop.Tools.RequestTool.RequestInt("count",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["IsPaid"] != null)
				model.IsPaid=Shop.Tools.RequestTool.RequestInt("IsPaid",0);
			if (HttpContext.Current.Request["Time_Paid"] != null)
				model.Time_Paid=Shop.Tools.RequestTool.RequestTime("Time_Paid", System.DateTime.Now);
			if (HttpContext.Current.Request["result_yes"] != null)
				model.result_yes=Shop.Tools.RequestTool.RequestSafeString("result_yes");
			if (HttpContext.Current.Request["result_no"] != null)
				model.result_no=Shop.Tools.RequestTool.RequestSafeString("result_no");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Cash_alipay ReaderBind(IDataReader dataReader)
		{
			Lebi_Cash_alipay model=new Lebi_Cash_alipay();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Code=dataReader["Code"].ToString();
			model.Cash_ids=dataReader["Cash_ids"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			model.alipay_user=dataReader["alipay_user"].ToString();
			model.alipay_username=dataReader["alipay_username"].ToString();
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.count=(int)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["IsPaid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPaid=(int)ojb;
			}
			ojb = dataReader["Time_Paid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Paid=(DateTime)ojb;
			}
			model.result_yes=dataReader["result_yes"].ToString();
			model.result_no=dataReader["result_no"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

