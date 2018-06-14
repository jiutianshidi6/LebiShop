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

	public interface Lebi_Supplier_Group_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Supplier_Group model);
		void Update(Lebi_Supplier_Group model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Supplier_Group GetModel(int id);
		Lebi_Supplier_Group GetModel(string strWhere);
		Lebi_Supplier_Group GetModel(SQLPara para);
		List<Lebi_Supplier_Group> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Supplier_Group> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Supplier_Group> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Supplier_Group> GetList(SQLPara para);
		Lebi_Supplier_Group BindForm(Lebi_Supplier_Group model);
		Lebi_Supplier_Group SafeBindForm(Lebi_Supplier_Group model);
		Lebi_Supplier_Group ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Supplier_Group。
	/// </summary>
	public class D_Lebi_Supplier_Group
	{
		static Lebi_Supplier_Group_interface _Instance;
		public static Lebi_Supplier_Group_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Supplier_Group();
		            else
		                _Instance = new sqlserver_Lebi_Supplier_Group();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Supplier_Group()
		{}
		#region  成员方法
	class sqlserver_Lebi_Supplier_Group : Lebi_Supplier_Group_interface
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
				strSql.Append("select " + colName + " from [Lebi_Supplier_Group]");
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
			strSql.Append("select  "+colName+" from [Lebi_Supplier_Group]");
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
			strSql.Append("select count(1) from [Lebi_Supplier_Group]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_Group]");
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
			strSql.Append("select max(id) from [Lebi_Supplier_Group]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_Group]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier_Group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier_Group](");
			strSql.Append("Grade,Name,MarginPrice,ServicePrice,ServiceDays,Remark,Sort,IsSubmit,Menu_ids,Menu_ids_index,BillingDays,Verified_ids,IsShow,type,ProductTop,UserTop,UserLow,Days_checkuserlow,Supplier_Skin_ids)");
			strSql.Append(" values (");
			strSql.Append("@Grade,@Name,@MarginPrice,@ServicePrice,@ServiceDays,@Remark,@Sort,@IsSubmit,@Menu_ids,@Menu_ids_index,@BillingDays,@Verified_ids,@IsShow,@type,@ProductTop,@UserTop,@UserLow,@Days_checkuserlow,@Supplier_Skin_ids)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Grade", model.Grade),
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@MarginPrice", model.MarginPrice),
					new SqlParameter("@ServicePrice", model.ServicePrice),
					new SqlParameter("@ServiceDays", model.ServiceDays),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@IsSubmit", model.IsSubmit),
					new SqlParameter("@Menu_ids", model.Menu_ids),
					new SqlParameter("@Menu_ids_index", model.Menu_ids_index),
					new SqlParameter("@BillingDays", model.BillingDays),
					new SqlParameter("@Verified_ids", model.Verified_ids),
					new SqlParameter("@IsShow", model.IsShow),
					new SqlParameter("@type", model.type),
					new SqlParameter("@ProductTop", model.ProductTop),
					new SqlParameter("@UserTop", model.UserTop),
					new SqlParameter("@UserLow", model.UserLow),
					new SqlParameter("@Days_checkuserlow", model.Days_checkuserlow),
					new SqlParameter("@Supplier_Skin_ids", model.Supplier_Skin_ids)};

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
		public void Update(Lebi_Supplier_Group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier_Group] set ");
			strSql.Append("Grade= @Grade,");
			strSql.Append("Name= @Name,");
			strSql.Append("MarginPrice= @MarginPrice,");
			strSql.Append("ServicePrice= @ServicePrice,");
			strSql.Append("ServiceDays= @ServiceDays,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("IsSubmit= @IsSubmit,");
			strSql.Append("Menu_ids= @Menu_ids,");
			strSql.Append("Menu_ids_index= @Menu_ids_index,");
			strSql.Append("BillingDays= @BillingDays,");
			strSql.Append("Verified_ids= @Verified_ids,");
			strSql.Append("IsShow= @IsShow,");
			strSql.Append("type= @type,");
			strSql.Append("ProductTop= @ProductTop,");
			strSql.Append("UserTop= @UserTop,");
			strSql.Append("UserLow= @UserLow,");
			strSql.Append("Days_checkuserlow= @Days_checkuserlow,");
			strSql.Append("Supplier_Skin_ids= @Supplier_Skin_ids");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@MarginPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ServicePrice", SqlDbType.Decimal,9),
					new SqlParameter("@ServiceDays", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,255),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@IsSubmit", SqlDbType.Int,4),
					new SqlParameter("@Menu_ids", SqlDbType.NVarChar,2000),
					new SqlParameter("@Menu_ids_index", SqlDbType.NVarChar,2000),
					new SqlParameter("@BillingDays", SqlDbType.Int,4),
					new SqlParameter("@Verified_ids", SqlDbType.NVarChar,100),
					new SqlParameter("@IsShow", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductTop", SqlDbType.Int,4),
					new SqlParameter("@UserTop", SqlDbType.Int,4),
					new SqlParameter("@UserLow", SqlDbType.Int,4),
					new SqlParameter("@Days_checkuserlow", SqlDbType.Int,4),
					new SqlParameter("@Supplier_Skin_ids", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Grade;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.MarginPrice;
			parameters[4].Value = model.ServicePrice;
			parameters[5].Value = model.ServiceDays;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.Sort;
			parameters[8].Value = model.IsSubmit;
			parameters[9].Value = model.Menu_ids;
			parameters[10].Value = model.Menu_ids_index;
			parameters[11].Value = model.BillingDays;
			parameters[12].Value = model.Verified_ids;
			parameters[13].Value = model.IsShow;
			parameters[14].Value = model.type;
			parameters[15].Value = model.ProductTop;
			parameters[16].Value = model.UserTop;
			parameters[17].Value = model.UserLow;
			parameters[18].Value = model.Days_checkuserlow;
			parameters[19].Value = model.Supplier_Skin_ids;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Group] ");
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
			strSql.Append("delete from [Lebi_Supplier_Group] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Group] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier_Group GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Group] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Supplier_Group model=new Lebi_Supplier_Group();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Grade"].ToString()!="")
				{
					model.Grade=int.Parse(ds.Tables[0].Rows[0]["Grade"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["MarginPrice"].ToString()!="")
				{
					model.MarginPrice=decimal.Parse(ds.Tables[0].Rows[0]["MarginPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ServicePrice"].ToString()!="")
				{
					model.ServicePrice=decimal.Parse(ds.Tables[0].Rows[0]["ServicePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ServiceDays"].ToString()!="")
				{
					model.ServiceDays=int.Parse(ds.Tables[0].Rows[0]["ServiceDays"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSubmit"].ToString()!="")
				{
					model.IsSubmit=int.Parse(ds.Tables[0].Rows[0]["IsSubmit"].ToString());
				}
				model.Menu_ids=ds.Tables[0].Rows[0]["Menu_ids"].ToString();
				model.Menu_ids_index=ds.Tables[0].Rows[0]["Menu_ids_index"].ToString();
				if(ds.Tables[0].Rows[0]["BillingDays"].ToString()!="")
				{
					model.BillingDays=int.Parse(ds.Tables[0].Rows[0]["BillingDays"].ToString());
				}
				model.Verified_ids=ds.Tables[0].Rows[0]["Verified_ids"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				if(ds.Tables[0].Rows[0]["ProductTop"].ToString()!="")
				{
					model.ProductTop=int.Parse(ds.Tables[0].Rows[0]["ProductTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserTop"].ToString()!="")
				{
					model.UserTop=int.Parse(ds.Tables[0].Rows[0]["UserTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLow"].ToString()!="")
				{
					model.UserLow=int.Parse(ds.Tables[0].Rows[0]["UserLow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString()!="")
				{
					model.Days_checkuserlow=int.Parse(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString());
				}
				model.Supplier_Skin_ids=ds.Tables[0].Rows[0]["Supplier_Skin_ids"].ToString();
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
		public Lebi_Supplier_Group GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Group] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier_Group model=new Lebi_Supplier_Group();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Grade"].ToString()!="")
				{
					model.Grade=int.Parse(ds.Tables[0].Rows[0]["Grade"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["MarginPrice"].ToString()!="")
				{
					model.MarginPrice=decimal.Parse(ds.Tables[0].Rows[0]["MarginPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ServicePrice"].ToString()!="")
				{
					model.ServicePrice=decimal.Parse(ds.Tables[0].Rows[0]["ServicePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ServiceDays"].ToString()!="")
				{
					model.ServiceDays=int.Parse(ds.Tables[0].Rows[0]["ServiceDays"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSubmit"].ToString()!="")
				{
					model.IsSubmit=int.Parse(ds.Tables[0].Rows[0]["IsSubmit"].ToString());
				}
				model.Menu_ids=ds.Tables[0].Rows[0]["Menu_ids"].ToString();
				model.Menu_ids_index=ds.Tables[0].Rows[0]["Menu_ids_index"].ToString();
				if(ds.Tables[0].Rows[0]["BillingDays"].ToString()!="")
				{
					model.BillingDays=int.Parse(ds.Tables[0].Rows[0]["BillingDays"].ToString());
				}
				model.Verified_ids=ds.Tables[0].Rows[0]["Verified_ids"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				if(ds.Tables[0].Rows[0]["ProductTop"].ToString()!="")
				{
					model.ProductTop=int.Parse(ds.Tables[0].Rows[0]["ProductTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserTop"].ToString()!="")
				{
					model.UserTop=int.Parse(ds.Tables[0].Rows[0]["UserTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLow"].ToString()!="")
				{
					model.UserLow=int.Parse(ds.Tables[0].Rows[0]["UserLow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString()!="")
				{
					model.Days_checkuserlow=int.Parse(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString());
				}
				model.Supplier_Skin_ids=ds.Tables[0].Rows[0]["Supplier_Skin_ids"].ToString();
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
		public Lebi_Supplier_Group GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier_Group] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier_Group model=new Lebi_Supplier_Group();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Grade"].ToString()!="")
				{
					model.Grade=int.Parse(ds.Tables[0].Rows[0]["Grade"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["MarginPrice"].ToString()!="")
				{
					model.MarginPrice=decimal.Parse(ds.Tables[0].Rows[0]["MarginPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ServicePrice"].ToString()!="")
				{
					model.ServicePrice=decimal.Parse(ds.Tables[0].Rows[0]["ServicePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ServiceDays"].ToString()!="")
				{
					model.ServiceDays=int.Parse(ds.Tables[0].Rows[0]["ServiceDays"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSubmit"].ToString()!="")
				{
					model.IsSubmit=int.Parse(ds.Tables[0].Rows[0]["IsSubmit"].ToString());
				}
				model.Menu_ids=ds.Tables[0].Rows[0]["Menu_ids"].ToString();
				model.Menu_ids_index=ds.Tables[0].Rows[0]["Menu_ids_index"].ToString();
				if(ds.Tables[0].Rows[0]["BillingDays"].ToString()!="")
				{
					model.BillingDays=int.Parse(ds.Tables[0].Rows[0]["BillingDays"].ToString());
				}
				model.Verified_ids=ds.Tables[0].Rows[0]["Verified_ids"].ToString();
				if(ds.Tables[0].Rows[0]["IsShow"].ToString()!="")
				{
					model.IsShow=int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
				}
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				if(ds.Tables[0].Rows[0]["ProductTop"].ToString()!="")
				{
					model.ProductTop=int.Parse(ds.Tables[0].Rows[0]["ProductTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserTop"].ToString()!="")
				{
					model.UserTop=int.Parse(ds.Tables[0].Rows[0]["UserTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserLow"].ToString()!="")
				{
					model.UserLow=int.Parse(ds.Tables[0].Rows[0]["UserLow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString()!="")
				{
					model.Days_checkuserlow=int.Parse(ds.Tables[0].Rows[0]["Days_checkuserlow"].ToString());
				}
				model.Supplier_Skin_ids=ds.Tables[0].Rows[0]["Supplier_Skin_ids"].ToString();
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
		public List<Lebi_Supplier_Group> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier_Group]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier_Group> list = new List<Lebi_Supplier_Group>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Supplier_Group> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier_Group]";
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
			List<Lebi_Supplier_Group> list = new List<Lebi_Supplier_Group>();
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
		public List<Lebi_Supplier_Group> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier_Group] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier_Group> list = new List<Lebi_Supplier_Group>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Supplier_Group> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier_Group]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_Group> list = new List<Lebi_Supplier_Group>();
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
		public Lebi_Supplier_Group BindForm(Lebi_Supplier_Group model)
		{
			if (HttpContext.Current.Request["Grade"] != null)
				model.Grade=Shop.Tools.RequestTool.RequestInt("Grade",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["MarginPrice"] != null)
				model.MarginPrice=Shop.Tools.RequestTool.RequestDecimal("MarginPrice",0);
			if (HttpContext.Current.Request["ServicePrice"] != null)
				model.ServicePrice=Shop.Tools.RequestTool.RequestDecimal("ServicePrice",0);
			if (HttpContext.Current.Request["ServiceDays"] != null)
				model.ServiceDays=Shop.Tools.RequestTool.RequestInt("ServiceDays",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsSubmit"] != null)
				model.IsSubmit=Shop.Tools.RequestTool.RequestInt("IsSubmit",0);
			if (HttpContext.Current.Request["Menu_ids"] != null)
				model.Menu_ids=Shop.Tools.RequestTool.RequestString("Menu_ids");
			if (HttpContext.Current.Request["Menu_ids_index"] != null)
				model.Menu_ids_index=Shop.Tools.RequestTool.RequestString("Menu_ids_index");
			if (HttpContext.Current.Request["BillingDays"] != null)
				model.BillingDays=Shop.Tools.RequestTool.RequestInt("BillingDays",0);
			if (HttpContext.Current.Request["Verified_ids"] != null)
				model.Verified_ids=Shop.Tools.RequestTool.RequestString("Verified_ids");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestString("type");
			if (HttpContext.Current.Request["ProductTop"] != null)
				model.ProductTop=Shop.Tools.RequestTool.RequestInt("ProductTop",0);
			if (HttpContext.Current.Request["UserTop"] != null)
				model.UserTop=Shop.Tools.RequestTool.RequestInt("UserTop",0);
			if (HttpContext.Current.Request["UserLow"] != null)
				model.UserLow=Shop.Tools.RequestTool.RequestInt("UserLow",0);
			if (HttpContext.Current.Request["Days_checkuserlow"] != null)
				model.Days_checkuserlow=Shop.Tools.RequestTool.RequestInt("Days_checkuserlow",0);
			if (HttpContext.Current.Request["Supplier_Skin_ids"] != null)
				model.Supplier_Skin_ids=Shop.Tools.RequestTool.RequestString("Supplier_Skin_ids");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier_Group SafeBindForm(Lebi_Supplier_Group model)
		{
			if (HttpContext.Current.Request["Grade"] != null)
				model.Grade=Shop.Tools.RequestTool.RequestInt("Grade",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["MarginPrice"] != null)
				model.MarginPrice=Shop.Tools.RequestTool.RequestDecimal("MarginPrice",0);
			if (HttpContext.Current.Request["ServicePrice"] != null)
				model.ServicePrice=Shop.Tools.RequestTool.RequestDecimal("ServicePrice",0);
			if (HttpContext.Current.Request["ServiceDays"] != null)
				model.ServiceDays=Shop.Tools.RequestTool.RequestInt("ServiceDays",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsSubmit"] != null)
				model.IsSubmit=Shop.Tools.RequestTool.RequestInt("IsSubmit",0);
			if (HttpContext.Current.Request["Menu_ids"] != null)
				model.Menu_ids=Shop.Tools.RequestTool.RequestSafeString("Menu_ids");
			if (HttpContext.Current.Request["Menu_ids_index"] != null)
				model.Menu_ids_index=Shop.Tools.RequestTool.RequestSafeString("Menu_ids_index");
			if (HttpContext.Current.Request["BillingDays"] != null)
				model.BillingDays=Shop.Tools.RequestTool.RequestInt("BillingDays",0);
			if (HttpContext.Current.Request["Verified_ids"] != null)
				model.Verified_ids=Shop.Tools.RequestTool.RequestSafeString("Verified_ids");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestSafeString("type");
			if (HttpContext.Current.Request["ProductTop"] != null)
				model.ProductTop=Shop.Tools.RequestTool.RequestInt("ProductTop",0);
			if (HttpContext.Current.Request["UserTop"] != null)
				model.UserTop=Shop.Tools.RequestTool.RequestInt("UserTop",0);
			if (HttpContext.Current.Request["UserLow"] != null)
				model.UserLow=Shop.Tools.RequestTool.RequestInt("UserLow",0);
			if (HttpContext.Current.Request["Days_checkuserlow"] != null)
				model.Days_checkuserlow=Shop.Tools.RequestTool.RequestInt("Days_checkuserlow",0);
			if (HttpContext.Current.Request["Supplier_Skin_ids"] != null)
				model.Supplier_Skin_ids=Shop.Tools.RequestTool.RequestSafeString("Supplier_Skin_ids");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier_Group ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier_Group model=new Lebi_Supplier_Group();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Grade"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Grade=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["MarginPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MarginPrice=(decimal)ojb;
			}
			ojb = dataReader["ServicePrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ServicePrice=(decimal)ojb;
			}
			ojb = dataReader["ServiceDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ServiceDays=(int)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["IsSubmit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSubmit=(int)ojb;
			}
			model.Menu_ids=dataReader["Menu_ids"].ToString();
			model.Menu_ids_index=dataReader["Menu_ids_index"].ToString();
			ojb = dataReader["BillingDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BillingDays=(int)ojb;
			}
			model.Verified_ids=dataReader["Verified_ids"].ToString();
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(int)ojb;
			}
			model.type=dataReader["type"].ToString();
			ojb = dataReader["ProductTop"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductTop=(int)ojb;
			}
			ojb = dataReader["UserTop"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserTop=(int)ojb;
			}
			ojb = dataReader["UserLow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLow=(int)ojb;
			}
			ojb = dataReader["Days_checkuserlow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Days_checkuserlow=(int)ojb;
			}
			model.Supplier_Skin_ids=dataReader["Supplier_Skin_ids"].ToString();
			return model;
		}

	}
	class access_Lebi_Supplier_Group : Lebi_Supplier_Group_interface
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
				strSql.Append("select " + colName + " from [Lebi_Supplier_Group]");
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
			strSql.Append("select  "+colName+" from [Lebi_Supplier_Group]");
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
			strSql.Append("select count(*) from [Lebi_Supplier_Group]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Supplier_Group]");
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
			strSql.Append("select max(id) from [Lebi_Supplier_Group]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Supplier_Group]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Supplier_Group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Supplier_Group](");
			strSql.Append("[Grade],[Name],[MarginPrice],[ServicePrice],[ServiceDays],[Remark],[Sort],[IsSubmit],[Menu_ids],[Menu_ids_index],[BillingDays],[Verified_ids],[IsShow],[type],[ProductTop],[UserTop],[UserLow],[Days_checkuserlow],[Supplier_Skin_ids])");
			strSql.Append(" values (");
			strSql.Append("@Grade,@Name,@MarginPrice,@ServicePrice,@ServiceDays,@Remark,@Sort,@IsSubmit,@Menu_ids,@Menu_ids_index,@BillingDays,@Verified_ids,@IsShow,@type,@ProductTop,@UserTop,@UserLow,@Days_checkuserlow,@Supplier_Skin_ids)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Grade", model.Grade),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@MarginPrice", model.MarginPrice),
					new OleDbParameter("@ServicePrice", model.ServicePrice),
					new OleDbParameter("@ServiceDays", model.ServiceDays),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@IsSubmit", model.IsSubmit),
					new OleDbParameter("@Menu_ids", model.Menu_ids),
					new OleDbParameter("@Menu_ids_index", model.Menu_ids_index),
					new OleDbParameter("@BillingDays", model.BillingDays),
					new OleDbParameter("@Verified_ids", model.Verified_ids),
					new OleDbParameter("@IsShow", model.IsShow),
					new OleDbParameter("@type", model.type),
					new OleDbParameter("@ProductTop", model.ProductTop),
					new OleDbParameter("@UserTop", model.UserTop),
					new OleDbParameter("@UserLow", model.UserLow),
					new OleDbParameter("@Days_checkuserlow", model.Days_checkuserlow),
					new OleDbParameter("@Supplier_Skin_ids", model.Supplier_Skin_ids)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Supplier_Group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Supplier_Group] set ");
			strSql.Append("[Grade]=@Grade,");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[MarginPrice]=@MarginPrice,");
			strSql.Append("[ServicePrice]=@ServicePrice,");
			strSql.Append("[ServiceDays]=@ServiceDays,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[IsSubmit]=@IsSubmit,");
			strSql.Append("[Menu_ids]=@Menu_ids,");
			strSql.Append("[Menu_ids_index]=@Menu_ids_index,");
			strSql.Append("[BillingDays]=@BillingDays,");
			strSql.Append("[Verified_ids]=@Verified_ids,");
			strSql.Append("[IsShow]=@IsShow,");
			strSql.Append("[type]=@type,");
			strSql.Append("[ProductTop]=@ProductTop,");
			strSql.Append("[UserTop]=@UserTop,");
			strSql.Append("[UserLow]=@UserLow,");
			strSql.Append("[Days_checkuserlow]=@Days_checkuserlow,");
			strSql.Append("[Supplier_Skin_ids]=@Supplier_Skin_ids");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Grade", model.Grade),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@MarginPrice", model.MarginPrice),
					new OleDbParameter("@ServicePrice", model.ServicePrice),
					new OleDbParameter("@ServiceDays", model.ServiceDays),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@IsSubmit", model.IsSubmit),
					new OleDbParameter("@Menu_ids", model.Menu_ids),
					new OleDbParameter("@Menu_ids_index", model.Menu_ids_index),
					new OleDbParameter("@BillingDays", model.BillingDays),
					new OleDbParameter("@Verified_ids", model.Verified_ids),
					new OleDbParameter("@IsShow", model.IsShow),
					new OleDbParameter("@type", model.type),
					new OleDbParameter("@ProductTop", model.ProductTop),
					new OleDbParameter("@UserTop", model.UserTop),
					new OleDbParameter("@UserLow", model.UserLow),
					new OleDbParameter("@Days_checkuserlow", model.Days_checkuserlow),
					new OleDbParameter("@Supplier_Skin_ids", model.Supplier_Skin_ids)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Group] ");
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
			strSql.Append("delete from [Lebi_Supplier_Group] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Supplier_Group] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Supplier_Group GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Group] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Supplier_Group model;
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
		public Lebi_Supplier_Group GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Supplier_Group] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Supplier_Group model;
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
		public Lebi_Supplier_Group GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Supplier_Group] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Supplier_Group model;
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
		public List<Lebi_Supplier_Group> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Supplier_Group]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Supplier_Group> list = new List<Lebi_Supplier_Group>();
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
		public List<Lebi_Supplier_Group> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Supplier_Group]";
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
			List<Lebi_Supplier_Group> list = new List<Lebi_Supplier_Group>();
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
		public List<Lebi_Supplier_Group> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Supplier_Group] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Supplier_Group> list = new List<Lebi_Supplier_Group>();
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
		public List<Lebi_Supplier_Group> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Supplier_Group]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Supplier_Group> list = new List<Lebi_Supplier_Group>();
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
		public Lebi_Supplier_Group BindForm(Lebi_Supplier_Group model)
		{
			if (HttpContext.Current.Request["Grade"] != null)
				model.Grade=Shop.Tools.RequestTool.RequestInt("Grade",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["MarginPrice"] != null)
				model.MarginPrice=Shop.Tools.RequestTool.RequestDecimal("MarginPrice",0);
			if (HttpContext.Current.Request["ServicePrice"] != null)
				model.ServicePrice=Shop.Tools.RequestTool.RequestDecimal("ServicePrice",0);
			if (HttpContext.Current.Request["ServiceDays"] != null)
				model.ServiceDays=Shop.Tools.RequestTool.RequestInt("ServiceDays",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsSubmit"] != null)
				model.IsSubmit=Shop.Tools.RequestTool.RequestInt("IsSubmit",0);
			if (HttpContext.Current.Request["Menu_ids"] != null)
				model.Menu_ids=Shop.Tools.RequestTool.RequestString("Menu_ids");
			if (HttpContext.Current.Request["Menu_ids_index"] != null)
				model.Menu_ids_index=Shop.Tools.RequestTool.RequestString("Menu_ids_index");
			if (HttpContext.Current.Request["BillingDays"] != null)
				model.BillingDays=Shop.Tools.RequestTool.RequestInt("BillingDays",0);
			if (HttpContext.Current.Request["Verified_ids"] != null)
				model.Verified_ids=Shop.Tools.RequestTool.RequestString("Verified_ids");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestString("type");
			if (HttpContext.Current.Request["ProductTop"] != null)
				model.ProductTop=Shop.Tools.RequestTool.RequestInt("ProductTop",0);
			if (HttpContext.Current.Request["UserTop"] != null)
				model.UserTop=Shop.Tools.RequestTool.RequestInt("UserTop",0);
			if (HttpContext.Current.Request["UserLow"] != null)
				model.UserLow=Shop.Tools.RequestTool.RequestInt("UserLow",0);
			if (HttpContext.Current.Request["Days_checkuserlow"] != null)
				model.Days_checkuserlow=Shop.Tools.RequestTool.RequestInt("Days_checkuserlow",0);
			if (HttpContext.Current.Request["Supplier_Skin_ids"] != null)
				model.Supplier_Skin_ids=Shop.Tools.RequestTool.RequestString("Supplier_Skin_ids");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Supplier_Group SafeBindForm(Lebi_Supplier_Group model)
		{
			if (HttpContext.Current.Request["Grade"] != null)
				model.Grade=Shop.Tools.RequestTool.RequestInt("Grade",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["MarginPrice"] != null)
				model.MarginPrice=Shop.Tools.RequestTool.RequestDecimal("MarginPrice",0);
			if (HttpContext.Current.Request["ServicePrice"] != null)
				model.ServicePrice=Shop.Tools.RequestTool.RequestDecimal("ServicePrice",0);
			if (HttpContext.Current.Request["ServiceDays"] != null)
				model.ServiceDays=Shop.Tools.RequestTool.RequestInt("ServiceDays",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsSubmit"] != null)
				model.IsSubmit=Shop.Tools.RequestTool.RequestInt("IsSubmit",0);
			if (HttpContext.Current.Request["Menu_ids"] != null)
				model.Menu_ids=Shop.Tools.RequestTool.RequestSafeString("Menu_ids");
			if (HttpContext.Current.Request["Menu_ids_index"] != null)
				model.Menu_ids_index=Shop.Tools.RequestTool.RequestSafeString("Menu_ids_index");
			if (HttpContext.Current.Request["BillingDays"] != null)
				model.BillingDays=Shop.Tools.RequestTool.RequestInt("BillingDays",0);
			if (HttpContext.Current.Request["Verified_ids"] != null)
				model.Verified_ids=Shop.Tools.RequestTool.RequestSafeString("Verified_ids");
			if (HttpContext.Current.Request["IsShow"] != null)
				model.IsShow=Shop.Tools.RequestTool.RequestInt("IsShow",0);
			if (HttpContext.Current.Request["type"] != null)
				model.type=Shop.Tools.RequestTool.RequestSafeString("type");
			if (HttpContext.Current.Request["ProductTop"] != null)
				model.ProductTop=Shop.Tools.RequestTool.RequestInt("ProductTop",0);
			if (HttpContext.Current.Request["UserTop"] != null)
				model.UserTop=Shop.Tools.RequestTool.RequestInt("UserTop",0);
			if (HttpContext.Current.Request["UserLow"] != null)
				model.UserLow=Shop.Tools.RequestTool.RequestInt("UserLow",0);
			if (HttpContext.Current.Request["Days_checkuserlow"] != null)
				model.Days_checkuserlow=Shop.Tools.RequestTool.RequestInt("Days_checkuserlow",0);
			if (HttpContext.Current.Request["Supplier_Skin_ids"] != null)
				model.Supplier_Skin_ids=Shop.Tools.RequestTool.RequestSafeString("Supplier_Skin_ids");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Supplier_Group ReaderBind(IDataReader dataReader)
		{
			Lebi_Supplier_Group model=new Lebi_Supplier_Group();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Grade"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Grade=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["MarginPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MarginPrice=(decimal)ojb;
			}
			ojb = dataReader["ServicePrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ServicePrice=(decimal)ojb;
			}
			ojb = dataReader["ServiceDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ServiceDays=(int)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["IsSubmit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSubmit=(int)ojb;
			}
			model.Menu_ids=dataReader["Menu_ids"].ToString();
			model.Menu_ids_index=dataReader["Menu_ids_index"].ToString();
			ojb = dataReader["BillingDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BillingDays=(int)ojb;
			}
			model.Verified_ids=dataReader["Verified_ids"].ToString();
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(int)ojb;
			}
			model.type=dataReader["type"].ToString();
			ojb = dataReader["ProductTop"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductTop=(int)ojb;
			}
			ojb = dataReader["UserTop"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserTop=(int)ojb;
			}
			ojb = dataReader["UserLow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserLow=(int)ojb;
			}
			ojb = dataReader["Days_checkuserlow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Days_checkuserlow=(int)ojb;
			}
			model.Supplier_Skin_ids=dataReader["Supplier_Skin_ids"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

