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

	public interface Lebi_CardOrder_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_CardOrder model);
		void Update(Lebi_CardOrder model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_CardOrder GetModel(int id);
		Lebi_CardOrder GetModel(string strWhere);
		Lebi_CardOrder GetModel(SQLPara para);
		List<Lebi_CardOrder> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_CardOrder> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_CardOrder> GetList(string strWhere, string strFieldOrder);
		List<Lebi_CardOrder> GetList(SQLPara para);
		Lebi_CardOrder BindForm(Lebi_CardOrder model);
		Lebi_CardOrder SafeBindForm(Lebi_CardOrder model);
		Lebi_CardOrder ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_CardOrder。
	/// </summary>
	public class D_Lebi_CardOrder
	{
		static Lebi_CardOrder_interface _Instance;
		public static Lebi_CardOrder_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_CardOrder();
		            else
		                _Instance = new sqlserver_Lebi_CardOrder();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_CardOrder()
		{}
		#region  成员方法
	class sqlserver_Lebi_CardOrder : Lebi_CardOrder_interface
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
				strSql.Append("select " + colName + " from [Lebi_CardOrder]");
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
			strSql.Append("select  "+colName+" from [Lebi_CardOrder]");
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
			strSql.Append("select count(1) from [Lebi_CardOrder]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_CardOrder]");
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
			strSql.Append("select max(id) from [Lebi_CardOrder]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_CardOrder]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_CardOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_CardOrder](");
			strSql.Append("Name,Money,Pro_Type_ids,Time_Add,Time_Update,Admin_id,IsPayOnce,IsCanOtherUse,IndexCode,NO_Start,NO_End,NO_Now,Time_Begin,Time_End,Length,Type_id_CardType,Money_Buy)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Money,@Pro_Type_ids,@Time_Add,@Time_Update,@Admin_id,@IsPayOnce,@IsCanOtherUse,@IndexCode,@NO_Start,@NO_End,@NO_Now,@Time_Begin,@Time_End,@Length,@Type_id_CardType,@Money_Buy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@Pro_Type_ids", model.Pro_Type_ids),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Update", model.Time_Update),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@IsPayOnce", model.IsPayOnce),
					new SqlParameter("@IsCanOtherUse", model.IsCanOtherUse),
					new SqlParameter("@IndexCode", model.IndexCode),
					new SqlParameter("@NO_Start", model.NO_Start),
					new SqlParameter("@NO_End", model.NO_End),
					new SqlParameter("@NO_Now", model.NO_Now),
					new SqlParameter("@Time_Begin", model.Time_Begin),
					new SqlParameter("@Time_End", model.Time_End),
					new SqlParameter("@Length", model.Length),
					new SqlParameter("@Type_id_CardType", model.Type_id_CardType),
					new SqlParameter("@Money_Buy", model.Money_Buy)};

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
		public void Update(Lebi_CardOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_CardOrder] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("Money= @Money,");
			strSql.Append("Pro_Type_ids= @Pro_Type_ids,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Update= @Time_Update,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("IsPayOnce= @IsPayOnce,");
			strSql.Append("IsCanOtherUse= @IsCanOtherUse,");
			strSql.Append("IndexCode= @IndexCode,");
			strSql.Append("NO_Start= @NO_Start,");
			strSql.Append("NO_End= @NO_End,");
			strSql.Append("NO_Now= @NO_Now,");
			strSql.Append("Time_Begin= @Time_Begin,");
			strSql.Append("Time_End= @Time_End,");
			strSql.Append("Length= @Length,");
			strSql.Append("Type_id_CardType= @Type_id_CardType,");
			strSql.Append("Money_Buy= @Money_Buy");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@Pro_Type_ids", SqlDbType.NVarChar,500),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Update", SqlDbType.DateTime),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@IsPayOnce", SqlDbType.Int,4),
					new SqlParameter("@IsCanOtherUse", SqlDbType.Int,4),
					new SqlParameter("@IndexCode", SqlDbType.NVarChar,50),
					new SqlParameter("@NO_Start", SqlDbType.Int,4),
					new SqlParameter("@NO_End", SqlDbType.Int,4),
					new SqlParameter("@NO_Now", SqlDbType.Int,4),
					new SqlParameter("@Time_Begin", SqlDbType.DateTime),
					new SqlParameter("@Time_End", SqlDbType.DateTime),
					new SqlParameter("@Length", SqlDbType.Int,4),
					new SqlParameter("@Type_id_CardType", SqlDbType.Int,4),
					new SqlParameter("@Money_Buy", SqlDbType.Decimal,9)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Money;
			parameters[3].Value = model.Pro_Type_ids;
			parameters[4].Value = model.Time_Add;
			parameters[5].Value = model.Time_Update;
			parameters[6].Value = model.Admin_id;
			parameters[7].Value = model.IsPayOnce;
			parameters[8].Value = model.IsCanOtherUse;
			parameters[9].Value = model.IndexCode;
			parameters[10].Value = model.NO_Start;
			parameters[11].Value = model.NO_End;
			parameters[12].Value = model.NO_Now;
			parameters[13].Value = model.Time_Begin;
			parameters[14].Value = model.Time_End;
			parameters[15].Value = model.Length;
			parameters[16].Value = model.Type_id_CardType;
			parameters[17].Value = model.Money_Buy;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_CardOrder] ");
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
			strSql.Append("delete from [Lebi_CardOrder] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_CardOrder] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_CardOrder GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_CardOrder] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_CardOrder model=new Lebi_CardOrder();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				model.Pro_Type_ids=ds.Tables[0].Rows[0]["Pro_Type_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPayOnce"].ToString()!="")
				{
					model.IsPayOnce=int.Parse(ds.Tables[0].Rows[0]["IsPayOnce"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString()!="")
				{
					model.IsCanOtherUse=int.Parse(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString());
				}
				model.IndexCode=ds.Tables[0].Rows[0]["IndexCode"].ToString();
				if(ds.Tables[0].Rows[0]["NO_Start"].ToString()!="")
				{
					model.NO_Start=int.Parse(ds.Tables[0].Rows[0]["NO_Start"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NO_End"].ToString()!="")
				{
					model.NO_End=int.Parse(ds.Tables[0].Rows[0]["NO_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NO_Now"].ToString()!="")
				{
					model.NO_Now=int.Parse(ds.Tables[0].Rows[0]["NO_Now"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Begin"].ToString()!="")
				{
					model.Time_Begin=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Begin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Length"].ToString()!="")
				{
					model.Length=int.Parse(ds.Tables[0].Rows[0]["Length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString()!="")
				{
					model.Type_id_CardType=int.Parse(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Buy"].ToString()!="")
				{
					model.Money_Buy=decimal.Parse(ds.Tables[0].Rows[0]["Money_Buy"].ToString());
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
		public Lebi_CardOrder GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_CardOrder] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_CardOrder model=new Lebi_CardOrder();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				model.Pro_Type_ids=ds.Tables[0].Rows[0]["Pro_Type_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPayOnce"].ToString()!="")
				{
					model.IsPayOnce=int.Parse(ds.Tables[0].Rows[0]["IsPayOnce"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString()!="")
				{
					model.IsCanOtherUse=int.Parse(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString());
				}
				model.IndexCode=ds.Tables[0].Rows[0]["IndexCode"].ToString();
				if(ds.Tables[0].Rows[0]["NO_Start"].ToString()!="")
				{
					model.NO_Start=int.Parse(ds.Tables[0].Rows[0]["NO_Start"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NO_End"].ToString()!="")
				{
					model.NO_End=int.Parse(ds.Tables[0].Rows[0]["NO_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NO_Now"].ToString()!="")
				{
					model.NO_Now=int.Parse(ds.Tables[0].Rows[0]["NO_Now"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Begin"].ToString()!="")
				{
					model.Time_Begin=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Begin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Length"].ToString()!="")
				{
					model.Length=int.Parse(ds.Tables[0].Rows[0]["Length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString()!="")
				{
					model.Type_id_CardType=int.Parse(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Buy"].ToString()!="")
				{
					model.Money_Buy=decimal.Parse(ds.Tables[0].Rows[0]["Money_Buy"].ToString());
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
		public Lebi_CardOrder GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_CardOrder] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_CardOrder model=new Lebi_CardOrder();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				model.Pro_Type_ids=ds.Tables[0].Rows[0]["Pro_Type_ids"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPayOnce"].ToString()!="")
				{
					model.IsPayOnce=int.Parse(ds.Tables[0].Rows[0]["IsPayOnce"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString()!="")
				{
					model.IsCanOtherUse=int.Parse(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString());
				}
				model.IndexCode=ds.Tables[0].Rows[0]["IndexCode"].ToString();
				if(ds.Tables[0].Rows[0]["NO_Start"].ToString()!="")
				{
					model.NO_Start=int.Parse(ds.Tables[0].Rows[0]["NO_Start"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NO_End"].ToString()!="")
				{
					model.NO_End=int.Parse(ds.Tables[0].Rows[0]["NO_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NO_Now"].ToString()!="")
				{
					model.NO_Now=int.Parse(ds.Tables[0].Rows[0]["NO_Now"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Begin"].ToString()!="")
				{
					model.Time_Begin=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Begin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Length"].ToString()!="")
				{
					model.Length=int.Parse(ds.Tables[0].Rows[0]["Length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString()!="")
				{
					model.Type_id_CardType=int.Parse(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Buy"].ToString()!="")
				{
					model.Money_Buy=decimal.Parse(ds.Tables[0].Rows[0]["Money_Buy"].ToString());
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
		public List<Lebi_CardOrder> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_CardOrder]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_CardOrder> list = new List<Lebi_CardOrder>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_CardOrder> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_CardOrder]";
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
			List<Lebi_CardOrder> list = new List<Lebi_CardOrder>();
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
		public List<Lebi_CardOrder> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_CardOrder] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_CardOrder> list = new List<Lebi_CardOrder>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_CardOrder> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_CardOrder]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_CardOrder> list = new List<Lebi_CardOrder>();
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
		public Lebi_CardOrder BindForm(Lebi_CardOrder model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestString("Pro_Type_ids");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["IsPayOnce"] != null)
				model.IsPayOnce=Shop.Tools.RequestTool.RequestInt("IsPayOnce",0);
			if (HttpContext.Current.Request["IsCanOtherUse"] != null)
				model.IsCanOtherUse=Shop.Tools.RequestTool.RequestInt("IsCanOtherUse",0);
			if (HttpContext.Current.Request["IndexCode"] != null)
				model.IndexCode=Shop.Tools.RequestTool.RequestString("IndexCode");
			if (HttpContext.Current.Request["NO_Start"] != null)
				model.NO_Start=Shop.Tools.RequestTool.RequestInt("NO_Start",0);
			if (HttpContext.Current.Request["NO_End"] != null)
				model.NO_End=Shop.Tools.RequestTool.RequestInt("NO_End",0);
			if (HttpContext.Current.Request["NO_Now"] != null)
				model.NO_Now=Shop.Tools.RequestTool.RequestInt("NO_Now",0);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["Length"] != null)
				model.Length=Shop.Tools.RequestTool.RequestInt("Length",0);
			if (HttpContext.Current.Request["Type_id_CardType"] != null)
				model.Type_id_CardType=Shop.Tools.RequestTool.RequestInt("Type_id_CardType",0);
			if (HttpContext.Current.Request["Money_Buy"] != null)
				model.Money_Buy=Shop.Tools.RequestTool.RequestDecimal("Money_Buy",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_CardOrder SafeBindForm(Lebi_CardOrder model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestSafeString("Pro_Type_ids");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["IsPayOnce"] != null)
				model.IsPayOnce=Shop.Tools.RequestTool.RequestInt("IsPayOnce",0);
			if (HttpContext.Current.Request["IsCanOtherUse"] != null)
				model.IsCanOtherUse=Shop.Tools.RequestTool.RequestInt("IsCanOtherUse",0);
			if (HttpContext.Current.Request["IndexCode"] != null)
				model.IndexCode=Shop.Tools.RequestTool.RequestSafeString("IndexCode");
			if (HttpContext.Current.Request["NO_Start"] != null)
				model.NO_Start=Shop.Tools.RequestTool.RequestInt("NO_Start",0);
			if (HttpContext.Current.Request["NO_End"] != null)
				model.NO_End=Shop.Tools.RequestTool.RequestInt("NO_End",0);
			if (HttpContext.Current.Request["NO_Now"] != null)
				model.NO_Now=Shop.Tools.RequestTool.RequestInt("NO_Now",0);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["Length"] != null)
				model.Length=Shop.Tools.RequestTool.RequestInt("Length",0);
			if (HttpContext.Current.Request["Type_id_CardType"] != null)
				model.Type_id_CardType=Shop.Tools.RequestTool.RequestInt("Type_id_CardType",0);
			if (HttpContext.Current.Request["Money_Buy"] != null)
				model.Money_Buy=Shop.Tools.RequestTool.RequestDecimal("Money_Buy",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_CardOrder ReaderBind(IDataReader dataReader)
		{
			Lebi_CardOrder model=new Lebi_CardOrder();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			model.Pro_Type_ids=dataReader["Pro_Type_ids"].ToString();
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
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			ojb = dataReader["IsPayOnce"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPayOnce=(int)ojb;
			}
			ojb = dataReader["IsCanOtherUse"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCanOtherUse=(int)ojb;
			}
			model.IndexCode=dataReader["IndexCode"].ToString();
			ojb = dataReader["NO_Start"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NO_Start=(int)ojb;
			}
			ojb = dataReader["NO_End"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NO_End=(int)ojb;
			}
			ojb = dataReader["NO_Now"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NO_Now=(int)ojb;
			}
			ojb = dataReader["Time_Begin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Begin=(DateTime)ojb;
			}
			ojb = dataReader["Time_End"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_End=(DateTime)ojb;
			}
			ojb = dataReader["Length"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Length=(int)ojb;
			}
			ojb = dataReader["Type_id_CardType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_CardType=(int)ojb;
			}
			ojb = dataReader["Money_Buy"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Buy=(decimal)ojb;
			}
			return model;
		}

	}
	class access_Lebi_CardOrder : Lebi_CardOrder_interface
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
				strSql.Append("select " + colName + " from [Lebi_CardOrder]");
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
			strSql.Append("select  "+colName+" from [Lebi_CardOrder]");
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
			strSql.Append("select count(*) from [Lebi_CardOrder]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_CardOrder]");
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
			strSql.Append("select max(id) from [Lebi_CardOrder]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_CardOrder]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_CardOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_CardOrder](");
			strSql.Append("[Name],[Money],[Pro_Type_ids],[Time_Add],[Time_Update],[Admin_id],[IsPayOnce],[IsCanOtherUse],[IndexCode],[NO_Start],[NO_End],[NO_Now],[Time_Begin],[Time_End],[Length],[Type_id_CardType],[Money_Buy])");
			strSql.Append(" values (");
			strSql.Append("@Name,@Money,@Pro_Type_ids,@Time_Add,@Time_Update,@Admin_id,@IsPayOnce,@IsCanOtherUse,@IndexCode,@NO_Start,@NO_End,@NO_Now,@Time_Begin,@Time_End,@Length,@Type_id_CardType,@Money_Buy)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Pro_Type_ids", model.Pro_Type_ids),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@IsPayOnce", model.IsPayOnce),
					new OleDbParameter("@IsCanOtherUse", model.IsCanOtherUse),
					new OleDbParameter("@IndexCode", model.IndexCode),
					new OleDbParameter("@NO_Start", model.NO_Start),
					new OleDbParameter("@NO_End", model.NO_End),
					new OleDbParameter("@NO_Now", model.NO_Now),
					new OleDbParameter("@Time_Begin", model.Time_Begin.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Length", model.Length),
					new OleDbParameter("@Type_id_CardType", model.Type_id_CardType),
					new OleDbParameter("@Money_Buy", model.Money_Buy)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_CardOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_CardOrder] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[Pro_Type_ids]=@Pro_Type_ids,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Update]=@Time_Update,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[IsPayOnce]=@IsPayOnce,");
			strSql.Append("[IsCanOtherUse]=@IsCanOtherUse,");
			strSql.Append("[IndexCode]=@IndexCode,");
			strSql.Append("[NO_Start]=@NO_Start,");
			strSql.Append("[NO_End]=@NO_End,");
			strSql.Append("[NO_Now]=@NO_Now,");
			strSql.Append("[Time_Begin]=@Time_Begin,");
			strSql.Append("[Time_End]=@Time_End,");
			strSql.Append("[Length]=@Length,");
			strSql.Append("[Type_id_CardType]=@Type_id_CardType,");
			strSql.Append("[Money_Buy]=@Money_Buy");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Pro_Type_ids", model.Pro_Type_ids),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@IsPayOnce", model.IsPayOnce),
					new OleDbParameter("@IsCanOtherUse", model.IsCanOtherUse),
					new OleDbParameter("@IndexCode", model.IndexCode),
					new OleDbParameter("@NO_Start", model.NO_Start),
					new OleDbParameter("@NO_End", model.NO_End),
					new OleDbParameter("@NO_Now", model.NO_Now),
					new OleDbParameter("@Time_Begin", model.Time_Begin.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Length", model.Length),
					new OleDbParameter("@Type_id_CardType", model.Type_id_CardType),
					new OleDbParameter("@Money_Buy", model.Money_Buy)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_CardOrder] ");
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
			strSql.Append("delete from [Lebi_CardOrder] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_CardOrder] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_CardOrder GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_CardOrder] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_CardOrder model;
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
		public Lebi_CardOrder GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_CardOrder] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_CardOrder model;
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
		public Lebi_CardOrder GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_CardOrder] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_CardOrder model;
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
		public List<Lebi_CardOrder> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_CardOrder]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_CardOrder> list = new List<Lebi_CardOrder>();
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
		public List<Lebi_CardOrder> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_CardOrder]";
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
			List<Lebi_CardOrder> list = new List<Lebi_CardOrder>();
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
		public List<Lebi_CardOrder> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_CardOrder] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_CardOrder> list = new List<Lebi_CardOrder>();
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
		public List<Lebi_CardOrder> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_CardOrder]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_CardOrder> list = new List<Lebi_CardOrder>();
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
		public Lebi_CardOrder BindForm(Lebi_CardOrder model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestString("Pro_Type_ids");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["IsPayOnce"] != null)
				model.IsPayOnce=Shop.Tools.RequestTool.RequestInt("IsPayOnce",0);
			if (HttpContext.Current.Request["IsCanOtherUse"] != null)
				model.IsCanOtherUse=Shop.Tools.RequestTool.RequestInt("IsCanOtherUse",0);
			if (HttpContext.Current.Request["IndexCode"] != null)
				model.IndexCode=Shop.Tools.RequestTool.RequestString("IndexCode");
			if (HttpContext.Current.Request["NO_Start"] != null)
				model.NO_Start=Shop.Tools.RequestTool.RequestInt("NO_Start",0);
			if (HttpContext.Current.Request["NO_End"] != null)
				model.NO_End=Shop.Tools.RequestTool.RequestInt("NO_End",0);
			if (HttpContext.Current.Request["NO_Now"] != null)
				model.NO_Now=Shop.Tools.RequestTool.RequestInt("NO_Now",0);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["Length"] != null)
				model.Length=Shop.Tools.RequestTool.RequestInt("Length",0);
			if (HttpContext.Current.Request["Type_id_CardType"] != null)
				model.Type_id_CardType=Shop.Tools.RequestTool.RequestInt("Type_id_CardType",0);
			if (HttpContext.Current.Request["Money_Buy"] != null)
				model.Money_Buy=Shop.Tools.RequestTool.RequestDecimal("Money_Buy",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_CardOrder SafeBindForm(Lebi_CardOrder model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestSafeString("Pro_Type_ids");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["IsPayOnce"] != null)
				model.IsPayOnce=Shop.Tools.RequestTool.RequestInt("IsPayOnce",0);
			if (HttpContext.Current.Request["IsCanOtherUse"] != null)
				model.IsCanOtherUse=Shop.Tools.RequestTool.RequestInt("IsCanOtherUse",0);
			if (HttpContext.Current.Request["IndexCode"] != null)
				model.IndexCode=Shop.Tools.RequestTool.RequestSafeString("IndexCode");
			if (HttpContext.Current.Request["NO_Start"] != null)
				model.NO_Start=Shop.Tools.RequestTool.RequestInt("NO_Start",0);
			if (HttpContext.Current.Request["NO_End"] != null)
				model.NO_End=Shop.Tools.RequestTool.RequestInt("NO_End",0);
			if (HttpContext.Current.Request["NO_Now"] != null)
				model.NO_Now=Shop.Tools.RequestTool.RequestInt("NO_Now",0);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["Length"] != null)
				model.Length=Shop.Tools.RequestTool.RequestInt("Length",0);
			if (HttpContext.Current.Request["Type_id_CardType"] != null)
				model.Type_id_CardType=Shop.Tools.RequestTool.RequestInt("Type_id_CardType",0);
			if (HttpContext.Current.Request["Money_Buy"] != null)
				model.Money_Buy=Shop.Tools.RequestTool.RequestDecimal("Money_Buy",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_CardOrder ReaderBind(IDataReader dataReader)
		{
			Lebi_CardOrder model=new Lebi_CardOrder();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			model.Pro_Type_ids=dataReader["Pro_Type_ids"].ToString();
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
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			ojb = dataReader["IsPayOnce"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPayOnce=(int)ojb;
			}
			ojb = dataReader["IsCanOtherUse"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCanOtherUse=(int)ojb;
			}
			model.IndexCode=dataReader["IndexCode"].ToString();
			ojb = dataReader["NO_Start"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NO_Start=(int)ojb;
			}
			ojb = dataReader["NO_End"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NO_End=(int)ojb;
			}
			ojb = dataReader["NO_Now"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NO_Now=(int)ojb;
			}
			ojb = dataReader["Time_Begin"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Begin=(DateTime)ojb;
			}
			ojb = dataReader["Time_End"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_End=(DateTime)ojb;
			}
			ojb = dataReader["Length"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Length=(int)ojb;
			}
			ojb = dataReader["Type_id_CardType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_CardType=(int)ojb;
			}
			ojb = dataReader["Money_Buy"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Buy=(decimal)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

