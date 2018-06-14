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

	public interface Lebi_Promotion_Type_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Promotion_Type model);
		void Update(Lebi_Promotion_Type model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Promotion_Type GetModel(int id);
		Lebi_Promotion_Type GetModel(string strWhere);
		Lebi_Promotion_Type GetModel(SQLPara para);
		List<Lebi_Promotion_Type> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Promotion_Type> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Promotion_Type> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Promotion_Type> GetList(SQLPara para);
		Lebi_Promotion_Type BindForm(Lebi_Promotion_Type model);
		Lebi_Promotion_Type SafeBindForm(Lebi_Promotion_Type model);
		Lebi_Promotion_Type ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Promotion_Type。
	/// </summary>
	public class D_Lebi_Promotion_Type
	{
		static Lebi_Promotion_Type_interface _Instance;
		public static Lebi_Promotion_Type_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Promotion_Type();
		            else
		                _Instance = new sqlserver_Lebi_Promotion_Type();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Promotion_Type()
		{}
		#region  成员方法
	class sqlserver_Lebi_Promotion_Type : Lebi_Promotion_Type_interface
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
				strSql.Append("select " + colName + " from [Lebi_Promotion_Type]");
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
			strSql.Append("select  "+colName+" from [Lebi_Promotion_Type]");
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
			strSql.Append("select count(1) from [Lebi_Promotion_Type]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Promotion_Type]");
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
			strSql.Append("select max(id) from [Lebi_Promotion_Type]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Promotion_Type]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Promotion_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Promotion_Type](");
			strSql.Append("Name,Admin_id,Admin_UserName,Remark,Time_Add,Time_Update,Time_Start,Time_End,Sort,IsRefuseOther,Type_id_PromotionStatus,UserLevel_ids,Content,Supplier_id,Type_id_PromotionType)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Admin_id,@Admin_UserName,@Remark,@Time_Add,@Time_Update,@Time_Start,@Time_End,@Sort,@IsRefuseOther,@Type_id_PromotionStatus,@UserLevel_ids,@Content,@Supplier_id,@Type_id_PromotionType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@Admin_UserName", model.Admin_UserName),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Update", model.Time_Update),
					new SqlParameter("@Time_Start", model.Time_Start),
					new SqlParameter("@Time_End", model.Time_End),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@IsRefuseOther", model.IsRefuseOther),
					new SqlParameter("@Type_id_PromotionStatus", model.Type_id_PromotionStatus),
					new SqlParameter("@UserLevel_ids", model.UserLevel_ids),
					new SqlParameter("@Content", model.Content),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Type_id_PromotionType", model.Type_id_PromotionType)};

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
		public void Update(Lebi_Promotion_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Promotion_Type] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("Admin_UserName= @Admin_UserName,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Update= @Time_Update,");
			strSql.Append("Time_Start= @Time_Start,");
			strSql.Append("Time_End= @Time_End,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("IsRefuseOther= @IsRefuseOther,");
			strSql.Append("Type_id_PromotionStatus= @Type_id_PromotionStatus,");
			strSql.Append("UserLevel_ids= @UserLevel_ids,");
			strSql.Append("Content= @Content,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Type_id_PromotionType= @Type_id_PromotionType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,1000),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@Admin_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Update", SqlDbType.DateTime),
					new SqlParameter("@Time_Start", SqlDbType.DateTime),
					new SqlParameter("@Time_End", SqlDbType.DateTime),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@IsRefuseOther", SqlDbType.Int,4),
					new SqlParameter("@Type_id_PromotionStatus", SqlDbType.Int,4),
					new SqlParameter("@UserLevel_ids", SqlDbType.NVarChar,100),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Type_id_PromotionType", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Admin_id;
			parameters[3].Value = model.Admin_UserName;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.Time_Add;
			parameters[6].Value = model.Time_Update;
			parameters[7].Value = model.Time_Start;
			parameters[8].Value = model.Time_End;
			parameters[9].Value = model.Sort;
			parameters[10].Value = model.IsRefuseOther;
			parameters[11].Value = model.Type_id_PromotionStatus;
			parameters[12].Value = model.UserLevel_ids;
			parameters[13].Value = model.Content;
			parameters[14].Value = model.Supplier_id;
			parameters[15].Value = model.Type_id_PromotionType;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Promotion_Type] ");
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
			strSql.Append("delete from [Lebi_Promotion_Type] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Promotion_Type] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Promotion_Type GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Promotion_Type] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Promotion_Type model=new Lebi_Promotion_Type();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Start"].ToString()!="")
				{
					model.Time_Start=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Start"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRefuseOther"].ToString()!="")
				{
					model.IsRefuseOther=int.Parse(ds.Tables[0].Rows[0]["IsRefuseOther"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString()!="")
				{
					model.Type_id_PromotionStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString());
				}
				model.UserLevel_ids=ds.Tables[0].Rows[0]["UserLevel_ids"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_PromotionType"].ToString()!="")
				{
					model.Type_id_PromotionType=int.Parse(ds.Tables[0].Rows[0]["Type_id_PromotionType"].ToString());
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
		public Lebi_Promotion_Type GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Promotion_Type] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Promotion_Type model=new Lebi_Promotion_Type();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Start"].ToString()!="")
				{
					model.Time_Start=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Start"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRefuseOther"].ToString()!="")
				{
					model.IsRefuseOther=int.Parse(ds.Tables[0].Rows[0]["IsRefuseOther"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString()!="")
				{
					model.Type_id_PromotionStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString());
				}
				model.UserLevel_ids=ds.Tables[0].Rows[0]["UserLevel_ids"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_PromotionType"].ToString()!="")
				{
					model.Type_id_PromotionType=int.Parse(ds.Tables[0].Rows[0]["Type_id_PromotionType"].ToString());
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
		public Lebi_Promotion_Type GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Promotion_Type] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Promotion_Type model=new Lebi_Promotion_Type();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Start"].ToString()!="")
				{
					model.Time_Start=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Start"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRefuseOther"].ToString()!="")
				{
					model.IsRefuseOther=int.Parse(ds.Tables[0].Rows[0]["IsRefuseOther"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString()!="")
				{
					model.Type_id_PromotionStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString());
				}
				model.UserLevel_ids=ds.Tables[0].Rows[0]["UserLevel_ids"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_PromotionType"].ToString()!="")
				{
					model.Type_id_PromotionType=int.Parse(ds.Tables[0].Rows[0]["Type_id_PromotionType"].ToString());
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
		public List<Lebi_Promotion_Type> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Promotion_Type]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Promotion_Type> list = new List<Lebi_Promotion_Type>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Promotion_Type> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Promotion_Type]";
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
			List<Lebi_Promotion_Type> list = new List<Lebi_Promotion_Type>();
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
		public List<Lebi_Promotion_Type> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Promotion_Type] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Promotion_Type> list = new List<Lebi_Promotion_Type>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Promotion_Type> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Promotion_Type]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Promotion_Type> list = new List<Lebi_Promotion_Type>();
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
		public Lebi_Promotion_Type BindForm(Lebi_Promotion_Type model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Start"] != null)
				model.Time_Start=Shop.Tools.RequestTool.RequestTime("Time_Start", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsRefuseOther"] != null)
				model.IsRefuseOther=Shop.Tools.RequestTool.RequestInt("IsRefuseOther",0);
			if (HttpContext.Current.Request["Type_id_PromotionStatus"] != null)
				model.Type_id_PromotionStatus=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionStatus",0);
			if (HttpContext.Current.Request["UserLevel_ids"] != null)
				model.UserLevel_ids=Shop.Tools.RequestTool.RequestString("UserLevel_ids");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Type_id_PromotionType"] != null)
				model.Type_id_PromotionType=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionType",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Promotion_Type SafeBindForm(Lebi_Promotion_Type model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Start"] != null)
				model.Time_Start=Shop.Tools.RequestTool.RequestTime("Time_Start", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsRefuseOther"] != null)
				model.IsRefuseOther=Shop.Tools.RequestTool.RequestInt("IsRefuseOther",0);
			if (HttpContext.Current.Request["Type_id_PromotionStatus"] != null)
				model.Type_id_PromotionStatus=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionStatus",0);
			if (HttpContext.Current.Request["UserLevel_ids"] != null)
				model.UserLevel_ids=Shop.Tools.RequestTool.RequestSafeString("UserLevel_ids");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Type_id_PromotionType"] != null)
				model.Type_id_PromotionType=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionType",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Promotion_Type ReaderBind(IDataReader dataReader)
		{
			Lebi_Promotion_Type model=new Lebi_Promotion_Type();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Update=(DateTime)ojb;
			}
			ojb = dataReader["Time_Start"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Start=(DateTime)ojb;
			}
			ojb = dataReader["Time_End"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_End=(DateTime)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["IsRefuseOther"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRefuseOther=(int)ojb;
			}
			ojb = dataReader["Type_id_PromotionStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_PromotionStatus=(int)ojb;
			}
			model.UserLevel_ids=dataReader["UserLevel_ids"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["Type_id_PromotionType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_PromotionType=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Promotion_Type : Lebi_Promotion_Type_interface
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
				strSql.Append("select " + colName + " from [Lebi_Promotion_Type]");
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
			strSql.Append("select  "+colName+" from [Lebi_Promotion_Type]");
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
			strSql.Append("select count(*) from [Lebi_Promotion_Type]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Promotion_Type]");
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
			strSql.Append("select max(id) from [Lebi_Promotion_Type]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Promotion_Type]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Promotion_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Promotion_Type](");
			strSql.Append("[Name],[Admin_id],[Admin_UserName],[Remark],[Time_Add],[Time_Update],[Time_Start],[Time_End],[Sort],[IsRefuseOther],[Type_id_PromotionStatus],[UserLevel_ids],[Content],[Supplier_id],[Type_id_PromotionType])");
			strSql.Append(" values (");
			strSql.Append("@Name,@Admin_id,@Admin_UserName,@Remark,@Time_Add,@Time_Update,@Time_Start,@Time_End,@Sort,@IsRefuseOther,@Type_id_PromotionStatus,@UserLevel_ids,@Content,@Supplier_id,@Type_id_PromotionType)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Start", model.Time_Start.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@IsRefuseOther", model.IsRefuseOther),
					new OleDbParameter("@Type_id_PromotionStatus", model.Type_id_PromotionStatus),
					new OleDbParameter("@UserLevel_ids", model.UserLevel_ids),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Type_id_PromotionType", model.Type_id_PromotionType)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Promotion_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Promotion_Type] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[Admin_UserName]=@Admin_UserName,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Update]=@Time_Update,");
			strSql.Append("[Time_Start]=@Time_Start,");
			strSql.Append("[Time_End]=@Time_End,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[IsRefuseOther]=@IsRefuseOther,");
			strSql.Append("[Type_id_PromotionStatus]=@Type_id_PromotionStatus,");
			strSql.Append("[UserLevel_ids]=@UserLevel_ids,");
			strSql.Append("[Content]=@Content,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Type_id_PromotionType]=@Type_id_PromotionType");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Start", model.Time_Start.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@IsRefuseOther", model.IsRefuseOther),
					new OleDbParameter("@Type_id_PromotionStatus", model.Type_id_PromotionStatus),
					new OleDbParameter("@UserLevel_ids", model.UserLevel_ids),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Type_id_PromotionType", model.Type_id_PromotionType)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Promotion_Type] ");
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
			strSql.Append("delete from [Lebi_Promotion_Type] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Promotion_Type] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Promotion_Type GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Promotion_Type] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Promotion_Type model;
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
		public Lebi_Promotion_Type GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Promotion_Type] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Promotion_Type model;
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
		public Lebi_Promotion_Type GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Promotion_Type] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Promotion_Type model;
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
		public List<Lebi_Promotion_Type> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Promotion_Type]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Promotion_Type> list = new List<Lebi_Promotion_Type>();
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
		public List<Lebi_Promotion_Type> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Promotion_Type]";
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
			List<Lebi_Promotion_Type> list = new List<Lebi_Promotion_Type>();
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
		public List<Lebi_Promotion_Type> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Promotion_Type] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Promotion_Type> list = new List<Lebi_Promotion_Type>();
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
		public List<Lebi_Promotion_Type> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Promotion_Type]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Promotion_Type> list = new List<Lebi_Promotion_Type>();
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
		public Lebi_Promotion_Type BindForm(Lebi_Promotion_Type model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Start"] != null)
				model.Time_Start=Shop.Tools.RequestTool.RequestTime("Time_Start", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsRefuseOther"] != null)
				model.IsRefuseOther=Shop.Tools.RequestTool.RequestInt("IsRefuseOther",0);
			if (HttpContext.Current.Request["Type_id_PromotionStatus"] != null)
				model.Type_id_PromotionStatus=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionStatus",0);
			if (HttpContext.Current.Request["UserLevel_ids"] != null)
				model.UserLevel_ids=Shop.Tools.RequestTool.RequestString("UserLevel_ids");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Type_id_PromotionType"] != null)
				model.Type_id_PromotionType=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionType",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Promotion_Type SafeBindForm(Lebi_Promotion_Type model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Start"] != null)
				model.Time_Start=Shop.Tools.RequestTool.RequestTime("Time_Start", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["IsRefuseOther"] != null)
				model.IsRefuseOther=Shop.Tools.RequestTool.RequestInt("IsRefuseOther",0);
			if (HttpContext.Current.Request["Type_id_PromotionStatus"] != null)
				model.Type_id_PromotionStatus=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionStatus",0);
			if (HttpContext.Current.Request["UserLevel_ids"] != null)
				model.UserLevel_ids=Shop.Tools.RequestTool.RequestSafeString("UserLevel_ids");
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Type_id_PromotionType"] != null)
				model.Type_id_PromotionType=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionType",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Promotion_Type ReaderBind(IDataReader dataReader)
		{
			Lebi_Promotion_Type model=new Lebi_Promotion_Type();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Update=(DateTime)ojb;
			}
			ojb = dataReader["Time_Start"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Start=(DateTime)ojb;
			}
			ojb = dataReader["Time_End"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_End=(DateTime)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["IsRefuseOther"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRefuseOther=(int)ojb;
			}
			ojb = dataReader["Type_id_PromotionStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_PromotionStatus=(int)ojb;
			}
			model.UserLevel_ids=dataReader["UserLevel_ids"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["Type_id_PromotionType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_PromotionType=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

