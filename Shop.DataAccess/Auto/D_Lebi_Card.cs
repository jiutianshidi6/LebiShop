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

	public interface Lebi_Card_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Card model);
		void Update(Lebi_Card model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Card GetModel(int id);
		Lebi_Card GetModel(string strWhere);
		Lebi_Card GetModel(SQLPara para);
		List<Lebi_Card> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Card> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Card> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Card> GetList(SQLPara para);
		Lebi_Card BindForm(Lebi_Card model);
		Lebi_Card SafeBindForm(Lebi_Card model);
		Lebi_Card ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Card。
	/// </summary>
	public class D_Lebi_Card
	{
		static Lebi_Card_interface _Instance;
		public static Lebi_Card_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Card();
		            else
		                _Instance = new sqlserver_Lebi_Card();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Card()
		{}
		#region  成员方法
	class sqlserver_Lebi_Card : Lebi_Card_interface
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
				strSql.Append("select " + colName + " from [Lebi_Card]");
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
			strSql.Append("select  "+colName+" from [Lebi_Card]");
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
			strSql.Append("select count(1) from [Lebi_Card]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Card]");
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
			strSql.Append("select max(id) from [Lebi_Card]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Card]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Card model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Card](");
			strSql.Append("Type_id_CardType,Money,Money_Last,Money_Used,Pro_Type_ids,Code,number,Password,Time_Add,Time_Begin,Time_End,User_id,User_UserName,IsPayOnce,IsCanOtherUse,Type_id_CardStatus,Remark,CardOrder_id,Money_Buy,IndexCode,Order_id,Order_Code)");
			strSql.Append(" values (");
			strSql.Append("@Type_id_CardType,@Money,@Money_Last,@Money_Used,@Pro_Type_ids,@Code,@number,@Password,@Time_Add,@Time_Begin,@Time_End,@User_id,@User_UserName,@IsPayOnce,@IsCanOtherUse,@Type_id_CardStatus,@Remark,@CardOrder_id,@Money_Buy,@IndexCode,@Order_id,@Order_Code)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Type_id_CardType", model.Type_id_CardType),
					new SqlParameter("@Money", model.Money),
					new SqlParameter("@Money_Last", model.Money_Last),
					new SqlParameter("@Money_Used", model.Money_Used),
					new SqlParameter("@Pro_Type_ids", model.Pro_Type_ids),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@number", model.number),
					new SqlParameter("@Password", model.Password),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Begin", model.Time_Begin),
					new SqlParameter("@Time_End", model.Time_End),
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@User_UserName", model.User_UserName),
					new SqlParameter("@IsPayOnce", model.IsPayOnce),
					new SqlParameter("@IsCanOtherUse", model.IsCanOtherUse),
					new SqlParameter("@Type_id_CardStatus", model.Type_id_CardStatus),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@CardOrder_id", model.CardOrder_id),
					new SqlParameter("@Money_Buy", model.Money_Buy),
					new SqlParameter("@IndexCode", model.IndexCode),
					new SqlParameter("@Order_id", model.Order_id),
					new SqlParameter("@Order_Code", model.Order_Code)};

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
		public void Update(Lebi_Card model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Card] set ");
			strSql.Append("Type_id_CardType= @Type_id_CardType,");
			strSql.Append("Money= @Money,");
			strSql.Append("Money_Last= @Money_Last,");
			strSql.Append("Money_Used= @Money_Used,");
			strSql.Append("Pro_Type_ids= @Pro_Type_ids,");
			strSql.Append("Code= @Code,");
			strSql.Append("number= @number,");
			strSql.Append("Password= @Password,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Begin= @Time_Begin,");
			strSql.Append("Time_End= @Time_End,");
			strSql.Append("User_id= @User_id,");
			strSql.Append("User_UserName= @User_UserName,");
			strSql.Append("IsPayOnce= @IsPayOnce,");
			strSql.Append("IsCanOtherUse= @IsCanOtherUse,");
			strSql.Append("Type_id_CardStatus= @Type_id_CardStatus,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("CardOrder_id= @CardOrder_id,");
			strSql.Append("Money_Buy= @Money_Buy,");
			strSql.Append("IndexCode= @IndexCode,");
			strSql.Append("Order_id= @Order_id,");
			strSql.Append("Order_Code= @Order_Code");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Type_id_CardType", SqlDbType.Int,4),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Last", SqlDbType.Decimal,9),
					new SqlParameter("@Money_Used", SqlDbType.Decimal,9),
					new SqlParameter("@Pro_Type_ids", SqlDbType.NVarChar,500),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@number", SqlDbType.Int,4),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Begin", SqlDbType.DateTime),
					new SqlParameter("@Time_End", SqlDbType.DateTime),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@IsPayOnce", SqlDbType.Int,4),
					new SqlParameter("@IsCanOtherUse", SqlDbType.Int,4),
					new SqlParameter("@Type_id_CardStatus", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,250),
					new SqlParameter("@CardOrder_id", SqlDbType.Int,4),
					new SqlParameter("@Money_Buy", SqlDbType.Decimal,9),
					new SqlParameter("@IndexCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Order_id", SqlDbType.NVarChar,100),
					new SqlParameter("@Order_Code", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Type_id_CardType;
			parameters[2].Value = model.Money;
			parameters[3].Value = model.Money_Last;
			parameters[4].Value = model.Money_Used;
			parameters[5].Value = model.Pro_Type_ids;
			parameters[6].Value = model.Code;
			parameters[7].Value = model.number;
			parameters[8].Value = model.Password;
			parameters[9].Value = model.Time_Add;
			parameters[10].Value = model.Time_Begin;
			parameters[11].Value = model.Time_End;
			parameters[12].Value = model.User_id;
			parameters[13].Value = model.User_UserName;
			parameters[14].Value = model.IsPayOnce;
			parameters[15].Value = model.IsCanOtherUse;
			parameters[16].Value = model.Type_id_CardStatus;
			parameters[17].Value = model.Remark;
			parameters[18].Value = model.CardOrder_id;
			parameters[19].Value = model.Money_Buy;
			parameters[20].Value = model.IndexCode;
			parameters[21].Value = model.Order_id;
			parameters[22].Value = model.Order_Code;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Card] ");
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
			strSql.Append("delete from [Lebi_Card] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Card] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Card GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Card] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Card model=new Lebi_Card();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString()!="")
				{
					model.Type_id_CardType=int.Parse(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Last"].ToString()!="")
				{
					model.Money_Last=decimal.Parse(ds.Tables[0].Rows[0]["Money_Last"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Used"].ToString()!="")
				{
					model.Money_Used=decimal.Parse(ds.Tables[0].Rows[0]["Money_Used"].ToString());
				}
				model.Pro_Type_ids=ds.Tables[0].Rows[0]["Pro_Type_ids"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["number"].ToString()!="")
				{
					model.number=int.Parse(ds.Tables[0].Rows[0]["number"].ToString());
				}
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Begin"].ToString()!="")
				{
					model.Time_Begin=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Begin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["IsPayOnce"].ToString()!="")
				{
					model.IsPayOnce=int.Parse(ds.Tables[0].Rows[0]["IsPayOnce"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString()!="")
				{
					model.IsCanOtherUse=int.Parse(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CardStatus"].ToString()!="")
				{
					model.Type_id_CardStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_CardStatus"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["CardOrder_id"].ToString()!="")
				{
					model.CardOrder_id=int.Parse(ds.Tables[0].Rows[0]["CardOrder_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Buy"].ToString()!="")
				{
					model.Money_Buy=decimal.Parse(ds.Tables[0].Rows[0]["Money_Buy"].ToString());
				}
				model.IndexCode=ds.Tables[0].Rows[0]["IndexCode"].ToString();
				model.Order_id=ds.Tables[0].Rows[0]["Order_id"].ToString();
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
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
		public Lebi_Card GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Card] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Card model=new Lebi_Card();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString()!="")
				{
					model.Type_id_CardType=int.Parse(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Last"].ToString()!="")
				{
					model.Money_Last=decimal.Parse(ds.Tables[0].Rows[0]["Money_Last"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Used"].ToString()!="")
				{
					model.Money_Used=decimal.Parse(ds.Tables[0].Rows[0]["Money_Used"].ToString());
				}
				model.Pro_Type_ids=ds.Tables[0].Rows[0]["Pro_Type_ids"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["number"].ToString()!="")
				{
					model.number=int.Parse(ds.Tables[0].Rows[0]["number"].ToString());
				}
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Begin"].ToString()!="")
				{
					model.Time_Begin=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Begin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["IsPayOnce"].ToString()!="")
				{
					model.IsPayOnce=int.Parse(ds.Tables[0].Rows[0]["IsPayOnce"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString()!="")
				{
					model.IsCanOtherUse=int.Parse(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CardStatus"].ToString()!="")
				{
					model.Type_id_CardStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_CardStatus"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["CardOrder_id"].ToString()!="")
				{
					model.CardOrder_id=int.Parse(ds.Tables[0].Rows[0]["CardOrder_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Buy"].ToString()!="")
				{
					model.Money_Buy=decimal.Parse(ds.Tables[0].Rows[0]["Money_Buy"].ToString());
				}
				model.IndexCode=ds.Tables[0].Rows[0]["IndexCode"].ToString();
				model.Order_id=ds.Tables[0].Rows[0]["Order_id"].ToString();
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
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
		public Lebi_Card GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Card] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Card model=new Lebi_Card();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString()!="")
				{
					model.Type_id_CardType=int.Parse(ds.Tables[0].Rows[0]["Type_id_CardType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Last"].ToString()!="")
				{
					model.Money_Last=decimal.Parse(ds.Tables[0].Rows[0]["Money_Last"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Used"].ToString()!="")
				{
					model.Money_Used=decimal.Parse(ds.Tables[0].Rows[0]["Money_Used"].ToString());
				}
				model.Pro_Type_ids=ds.Tables[0].Rows[0]["Pro_Type_ids"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				if(ds.Tables[0].Rows[0]["number"].ToString()!="")
				{
					model.number=int.Parse(ds.Tables[0].Rows[0]["number"].ToString());
				}
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Begin"].ToString()!="")
				{
					model.Time_Begin=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Begin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_End"].ToString()!="")
				{
					model.Time_End=DateTime.Parse(ds.Tables[0].Rows[0]["Time_End"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				if(ds.Tables[0].Rows[0]["IsPayOnce"].ToString()!="")
				{
					model.IsPayOnce=int.Parse(ds.Tables[0].Rows[0]["IsPayOnce"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString()!="")
				{
					model.IsCanOtherUse=int.Parse(ds.Tables[0].Rows[0]["IsCanOtherUse"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_CardStatus"].ToString()!="")
				{
					model.Type_id_CardStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_CardStatus"].ToString());
				}
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				if(ds.Tables[0].Rows[0]["CardOrder_id"].ToString()!="")
				{
					model.CardOrder_id=int.Parse(ds.Tables[0].Rows[0]["CardOrder_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money_Buy"].ToString()!="")
				{
					model.Money_Buy=decimal.Parse(ds.Tables[0].Rows[0]["Money_Buy"].ToString());
				}
				model.IndexCode=ds.Tables[0].Rows[0]["IndexCode"].ToString();
				model.Order_id=ds.Tables[0].Rows[0]["Order_id"].ToString();
				model.Order_Code=ds.Tables[0].Rows[0]["Order_Code"].ToString();
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
		public List<Lebi_Card> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Card]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Card> list = new List<Lebi_Card>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Card> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Card]";
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
			List<Lebi_Card> list = new List<Lebi_Card>();
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
		public List<Lebi_Card> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Card] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Card> list = new List<Lebi_Card>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Card> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Card]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Card> list = new List<Lebi_Card>();
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
		public Lebi_Card BindForm(Lebi_Card model)
		{
			if (HttpContext.Current.Request["Type_id_CardType"] != null)
				model.Type_id_CardType=Shop.Tools.RequestTool.RequestInt("Type_id_CardType",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Money_Last"] != null)
				model.Money_Last=Shop.Tools.RequestTool.RequestDecimal("Money_Last",0);
			if (HttpContext.Current.Request["Money_Used"] != null)
				model.Money_Used=Shop.Tools.RequestTool.RequestDecimal("Money_Used",0);
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestString("Pro_Type_ids");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["number"] != null)
				model.number=Shop.Tools.RequestTool.RequestInt("number",0);
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestString("Password");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["IsPayOnce"] != null)
				model.IsPayOnce=Shop.Tools.RequestTool.RequestInt("IsPayOnce",0);
			if (HttpContext.Current.Request["IsCanOtherUse"] != null)
				model.IsCanOtherUse=Shop.Tools.RequestTool.RequestInt("IsCanOtherUse",0);
			if (HttpContext.Current.Request["Type_id_CardStatus"] != null)
				model.Type_id_CardStatus=Shop.Tools.RequestTool.RequestInt("Type_id_CardStatus",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
			if (HttpContext.Current.Request["Money_Buy"] != null)
				model.Money_Buy=Shop.Tools.RequestTool.RequestDecimal("Money_Buy",0);
			if (HttpContext.Current.Request["IndexCode"] != null)
				model.IndexCode=Shop.Tools.RequestTool.RequestString("IndexCode");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestString("Order_id");
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Card SafeBindForm(Lebi_Card model)
		{
			if (HttpContext.Current.Request["Type_id_CardType"] != null)
				model.Type_id_CardType=Shop.Tools.RequestTool.RequestInt("Type_id_CardType",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Money_Last"] != null)
				model.Money_Last=Shop.Tools.RequestTool.RequestDecimal("Money_Last",0);
			if (HttpContext.Current.Request["Money_Used"] != null)
				model.Money_Used=Shop.Tools.RequestTool.RequestDecimal("Money_Used",0);
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestSafeString("Pro_Type_ids");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["number"] != null)
				model.number=Shop.Tools.RequestTool.RequestInt("number",0);
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestSafeString("Password");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["IsPayOnce"] != null)
				model.IsPayOnce=Shop.Tools.RequestTool.RequestInt("IsPayOnce",0);
			if (HttpContext.Current.Request["IsCanOtherUse"] != null)
				model.IsCanOtherUse=Shop.Tools.RequestTool.RequestInt("IsCanOtherUse",0);
			if (HttpContext.Current.Request["Type_id_CardStatus"] != null)
				model.Type_id_CardStatus=Shop.Tools.RequestTool.RequestInt("Type_id_CardStatus",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
			if (HttpContext.Current.Request["Money_Buy"] != null)
				model.Money_Buy=Shop.Tools.RequestTool.RequestDecimal("Money_Buy",0);
			if (HttpContext.Current.Request["IndexCode"] != null)
				model.IndexCode=Shop.Tools.RequestTool.RequestSafeString("IndexCode");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestSafeString("Order_id");
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Card ReaderBind(IDataReader dataReader)
		{
			Lebi_Card model=new Lebi_Card();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Type_id_CardType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_CardType=(int)ojb;
			}
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Money_Last"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Last=(decimal)ojb;
			}
			ojb = dataReader["Money_Used"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Used=(decimal)ojb;
			}
			model.Pro_Type_ids=dataReader["Pro_Type_ids"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["number"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.number=(int)ojb;
			}
			model.Password=dataReader["Password"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
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
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
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
			ojb = dataReader["Type_id_CardStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_CardStatus=(int)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["CardOrder_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CardOrder_id=(int)ojb;
			}
			ojb = dataReader["Money_Buy"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Buy=(decimal)ojb;
			}
			model.IndexCode=dataReader["IndexCode"].ToString();
			model.Order_id=dataReader["Order_id"].ToString();
			model.Order_Code=dataReader["Order_Code"].ToString();
			return model;
		}

	}
	class access_Lebi_Card : Lebi_Card_interface
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
				strSql.Append("select " + colName + " from [Lebi_Card]");
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
			strSql.Append("select  "+colName+" from [Lebi_Card]");
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
			strSql.Append("select count(*) from [Lebi_Card]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Card]");
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
			strSql.Append("select max(id) from [Lebi_Card]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Card]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Card model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Card](");
			strSql.Append("[Type_id_CardType],[Money],[Money_Last],[Money_Used],[Pro_Type_ids],[Code],[number],[Password],[Time_Add],[Time_Begin],[Time_End],[User_id],[User_UserName],[IsPayOnce],[IsCanOtherUse],[Type_id_CardStatus],[Remark],[CardOrder_id],[Money_Buy],[IndexCode],[Order_id],[Order_Code])");
			strSql.Append(" values (");
			strSql.Append("@Type_id_CardType,@Money,@Money_Last,@Money_Used,@Pro_Type_ids,@Code,@number,@Password,@Time_Add,@Time_Begin,@Time_End,@User_id,@User_UserName,@IsPayOnce,@IsCanOtherUse,@Type_id_CardStatus,@Remark,@CardOrder_id,@Money_Buy,@IndexCode,@Order_id,@Order_Code)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Type_id_CardType", model.Type_id_CardType),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Money_Last", model.Money_Last),
					new OleDbParameter("@Money_Used", model.Money_Used),
					new OleDbParameter("@Pro_Type_ids", model.Pro_Type_ids),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@number", model.number),
					new OleDbParameter("@Password", model.Password),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Begin", model.Time_Begin.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@IsPayOnce", model.IsPayOnce),
					new OleDbParameter("@IsCanOtherUse", model.IsCanOtherUse),
					new OleDbParameter("@Type_id_CardStatus", model.Type_id_CardStatus),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@CardOrder_id", model.CardOrder_id),
					new OleDbParameter("@Money_Buy", model.Money_Buy),
					new OleDbParameter("@IndexCode", model.IndexCode),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Card model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Card] set ");
			strSql.Append("[Type_id_CardType]=@Type_id_CardType,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[Money_Last]=@Money_Last,");
			strSql.Append("[Money_Used]=@Money_Used,");
			strSql.Append("[Pro_Type_ids]=@Pro_Type_ids,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[number]=@number,");
			strSql.Append("[Password]=@Password,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Begin]=@Time_Begin,");
			strSql.Append("[Time_End]=@Time_End,");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[User_UserName]=@User_UserName,");
			strSql.Append("[IsPayOnce]=@IsPayOnce,");
			strSql.Append("[IsCanOtherUse]=@IsCanOtherUse,");
			strSql.Append("[Type_id_CardStatus]=@Type_id_CardStatus,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[CardOrder_id]=@CardOrder_id,");
			strSql.Append("[Money_Buy]=@Money_Buy,");
			strSql.Append("[IndexCode]=@IndexCode,");
			strSql.Append("[Order_id]=@Order_id,");
			strSql.Append("[Order_Code]=@Order_Code");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Type_id_CardType", model.Type_id_CardType),
					new OleDbParameter("@Money", model.Money),
					new OleDbParameter("@Money_Last", model.Money_Last),
					new OleDbParameter("@Money_Used", model.Money_Used),
					new OleDbParameter("@Pro_Type_ids", model.Pro_Type_ids),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@number", model.number),
					new OleDbParameter("@Password", model.Password),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Begin", model.Time_Begin.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@IsPayOnce", model.IsPayOnce),
					new OleDbParameter("@IsCanOtherUse", model.IsCanOtherUse),
					new OleDbParameter("@Type_id_CardStatus", model.Type_id_CardStatus),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@CardOrder_id", model.CardOrder_id),
					new OleDbParameter("@Money_Buy", model.Money_Buy),
					new OleDbParameter("@IndexCode", model.IndexCode),
					new OleDbParameter("@Order_id", model.Order_id),
					new OleDbParameter("@Order_Code", model.Order_Code)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Card] ");
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
			strSql.Append("delete from [Lebi_Card] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Card] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Card GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Card] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Card model;
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
		public Lebi_Card GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Card] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Card model;
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
		public Lebi_Card GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Card] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Card model;
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
		public List<Lebi_Card> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Card]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Card> list = new List<Lebi_Card>();
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
		public List<Lebi_Card> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Card]";
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
			List<Lebi_Card> list = new List<Lebi_Card>();
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
		public List<Lebi_Card> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Card] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Card> list = new List<Lebi_Card>();
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
		public List<Lebi_Card> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Card]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Card> list = new List<Lebi_Card>();
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
		public Lebi_Card BindForm(Lebi_Card model)
		{
			if (HttpContext.Current.Request["Type_id_CardType"] != null)
				model.Type_id_CardType=Shop.Tools.RequestTool.RequestInt("Type_id_CardType",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Money_Last"] != null)
				model.Money_Last=Shop.Tools.RequestTool.RequestDecimal("Money_Last",0);
			if (HttpContext.Current.Request["Money_Used"] != null)
				model.Money_Used=Shop.Tools.RequestTool.RequestDecimal("Money_Used",0);
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestString("Pro_Type_ids");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["number"] != null)
				model.number=Shop.Tools.RequestTool.RequestInt("number",0);
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestString("Password");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["IsPayOnce"] != null)
				model.IsPayOnce=Shop.Tools.RequestTool.RequestInt("IsPayOnce",0);
			if (HttpContext.Current.Request["IsCanOtherUse"] != null)
				model.IsCanOtherUse=Shop.Tools.RequestTool.RequestInt("IsCanOtherUse",0);
			if (HttpContext.Current.Request["Type_id_CardStatus"] != null)
				model.Type_id_CardStatus=Shop.Tools.RequestTool.RequestInt("Type_id_CardStatus",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
			if (HttpContext.Current.Request["Money_Buy"] != null)
				model.Money_Buy=Shop.Tools.RequestTool.RequestDecimal("Money_Buy",0);
			if (HttpContext.Current.Request["IndexCode"] != null)
				model.IndexCode=Shop.Tools.RequestTool.RequestString("IndexCode");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestString("Order_id");
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestString("Order_Code");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Card SafeBindForm(Lebi_Card model)
		{
			if (HttpContext.Current.Request["Type_id_CardType"] != null)
				model.Type_id_CardType=Shop.Tools.RequestTool.RequestInt("Type_id_CardType",0);
			if (HttpContext.Current.Request["Money"] != null)
				model.Money=Shop.Tools.RequestTool.RequestDecimal("Money",0);
			if (HttpContext.Current.Request["Money_Last"] != null)
				model.Money_Last=Shop.Tools.RequestTool.RequestDecimal("Money_Last",0);
			if (HttpContext.Current.Request["Money_Used"] != null)
				model.Money_Used=Shop.Tools.RequestTool.RequestDecimal("Money_Used",0);
			if (HttpContext.Current.Request["Pro_Type_ids"] != null)
				model.Pro_Type_ids=Shop.Tools.RequestTool.RequestSafeString("Pro_Type_ids");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["number"] != null)
				model.number=Shop.Tools.RequestTool.RequestInt("number",0);
			if (HttpContext.Current.Request["Password"] != null)
				model.Password=Shop.Tools.RequestTool.RequestSafeString("Password");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Begin"] != null)
				model.Time_Begin=Shop.Tools.RequestTool.RequestTime("Time_Begin", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_End"] != null)
				model.Time_End=Shop.Tools.RequestTool.RequestTime("Time_End", System.DateTime.Now);
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["IsPayOnce"] != null)
				model.IsPayOnce=Shop.Tools.RequestTool.RequestInt("IsPayOnce",0);
			if (HttpContext.Current.Request["IsCanOtherUse"] != null)
				model.IsCanOtherUse=Shop.Tools.RequestTool.RequestInt("IsCanOtherUse",0);
			if (HttpContext.Current.Request["Type_id_CardStatus"] != null)
				model.Type_id_CardStatus=Shop.Tools.RequestTool.RequestInt("Type_id_CardStatus",0);
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["CardOrder_id"] != null)
				model.CardOrder_id=Shop.Tools.RequestTool.RequestInt("CardOrder_id",0);
			if (HttpContext.Current.Request["Money_Buy"] != null)
				model.Money_Buy=Shop.Tools.RequestTool.RequestDecimal("Money_Buy",0);
			if (HttpContext.Current.Request["IndexCode"] != null)
				model.IndexCode=Shop.Tools.RequestTool.RequestSafeString("IndexCode");
			if (HttpContext.Current.Request["Order_id"] != null)
				model.Order_id=Shop.Tools.RequestTool.RequestSafeString("Order_id");
			if (HttpContext.Current.Request["Order_Code"] != null)
				model.Order_Code=Shop.Tools.RequestTool.RequestSafeString("Order_Code");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Card ReaderBind(IDataReader dataReader)
		{
			Lebi_Card model=new Lebi_Card();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Type_id_CardType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_CardType=(int)ojb;
			}
			ojb = dataReader["Money"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money=(decimal)ojb;
			}
			ojb = dataReader["Money_Last"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Last=(decimal)ojb;
			}
			ojb = dataReader["Money_Used"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Used=(decimal)ojb;
			}
			model.Pro_Type_ids=dataReader["Pro_Type_ids"].ToString();
			model.Code=dataReader["Code"].ToString();
			ojb = dataReader["number"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.number=(int)ojb;
			}
			model.Password=dataReader["Password"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
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
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
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
			ojb = dataReader["Type_id_CardStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_CardStatus=(int)ojb;
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["CardOrder_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CardOrder_id=(int)ojb;
			}
			ojb = dataReader["Money_Buy"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Money_Buy=(decimal)ojb;
			}
			model.IndexCode=dataReader["IndexCode"].ToString();
			model.Order_id=dataReader["Order_id"].ToString();
			model.Order_Code=dataReader["Order_Code"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

