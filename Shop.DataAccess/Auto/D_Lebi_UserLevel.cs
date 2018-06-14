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

	public interface Lebi_UserLevel_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_UserLevel model);
		void Update(Lebi_UserLevel model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_UserLevel GetModel(int id);
		Lebi_UserLevel GetModel(string strWhere);
		Lebi_UserLevel GetModel(SQLPara para);
		List<Lebi_UserLevel> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_UserLevel> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_UserLevel> GetList(string strWhere, string strFieldOrder);
		List<Lebi_UserLevel> GetList(SQLPara para);
		Lebi_UserLevel BindForm(Lebi_UserLevel model);
		Lebi_UserLevel SafeBindForm(Lebi_UserLevel model);
		Lebi_UserLevel ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_UserLevel。
	/// </summary>
	public class D_Lebi_UserLevel
	{
		static Lebi_UserLevel_interface _Instance;
		public static Lebi_UserLevel_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_UserLevel();
		            else
		                _Instance = new sqlserver_Lebi_UserLevel();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_UserLevel()
		{}
		#region  成员方法
	class sqlserver_Lebi_UserLevel : Lebi_UserLevel_interface
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
				strSql.Append("select " + colName + " from [Lebi_UserLevel]");
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
			strSql.Append("select  "+colName+" from [Lebi_UserLevel]");
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
			strSql.Append("select count(1) from [Lebi_UserLevel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_UserLevel]");
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
			strSql.Append("select max(id) from [Lebi_UserLevel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_UserLevel]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_UserLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_UserLevel](");
			strSql.Append("Grade,Name,PriceName,Type_id_PriceType,Lpoint,Price,remark,LisDefault,ImageUrl,OrderSubmit,LoginPointCut,LoginPointAdd,Comment,BuyRight,MoneyToPoint,PointToMoney,IsHidePrice,OrderSubmitCount,RegisterType,IsUsedAgent)");
			strSql.Append(" values (");
			strSql.Append("@Grade,@Name,@PriceName,@Type_id_PriceType,@Lpoint,@Price,@remark,@LisDefault,@ImageUrl,@OrderSubmit,@LoginPointCut,@LoginPointAdd,@Comment,@BuyRight,@MoneyToPoint,@PointToMoney,@IsHidePrice,@OrderSubmitCount,@RegisterType,@IsUsedAgent)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Grade", model.Grade),
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@PriceName", model.PriceName),
					new SqlParameter("@Type_id_PriceType", model.Type_id_PriceType),
					new SqlParameter("@Lpoint", model.Lpoint),
					new SqlParameter("@Price", model.Price),
					new SqlParameter("@remark", model.remark),
					new SqlParameter("@LisDefault", model.LisDefault),
					new SqlParameter("@ImageUrl", model.ImageUrl),
					new SqlParameter("@OrderSubmit", model.OrderSubmit),
					new SqlParameter("@LoginPointCut", model.LoginPointCut),
					new SqlParameter("@LoginPointAdd", model.LoginPointAdd),
					new SqlParameter("@Comment", model.Comment),
					new SqlParameter("@BuyRight", model.BuyRight),
					new SqlParameter("@MoneyToPoint", model.MoneyToPoint),
					new SqlParameter("@PointToMoney", model.PointToMoney),
					new SqlParameter("@IsHidePrice", model.IsHidePrice),
					new SqlParameter("@OrderSubmitCount", model.OrderSubmitCount),
					new SqlParameter("@RegisterType", model.RegisterType),
					new SqlParameter("@IsUsedAgent", model.IsUsedAgent)};

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
		public void Update(Lebi_UserLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_UserLevel] set ");
			strSql.Append("Grade= @Grade,");
			strSql.Append("Name= @Name,");
			strSql.Append("PriceName= @PriceName,");
			strSql.Append("Type_id_PriceType= @Type_id_PriceType,");
			strSql.Append("Lpoint= @Lpoint,");
			strSql.Append("Price= @Price,");
			strSql.Append("remark= @remark,");
			strSql.Append("LisDefault= @LisDefault,");
			strSql.Append("ImageUrl= @ImageUrl,");
			strSql.Append("OrderSubmit= @OrderSubmit,");
			strSql.Append("LoginPointCut= @LoginPointCut,");
			strSql.Append("LoginPointAdd= @LoginPointAdd,");
			strSql.Append("Comment= @Comment,");
			strSql.Append("BuyRight= @BuyRight,");
			strSql.Append("MoneyToPoint= @MoneyToPoint,");
			strSql.Append("PointToMoney= @PointToMoney,");
			strSql.Append("IsHidePrice= @IsHidePrice,");
			strSql.Append("OrderSubmitCount= @OrderSubmitCount,");
			strSql.Append("RegisterType= @RegisterType,");
			strSql.Append("IsUsedAgent= @IsUsedAgent");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@PriceName", SqlDbType.NVarChar,500),
					new SqlParameter("@Type_id_PriceType", SqlDbType.VarChar,50),
					new SqlParameter("@Lpoint", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@LisDefault", SqlDbType.Int,4),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@OrderSubmit", SqlDbType.Decimal,9),
					new SqlParameter("@LoginPointCut", SqlDbType.Int,4),
					new SqlParameter("@LoginPointAdd", SqlDbType.Int,4),
					new SqlParameter("@Comment", SqlDbType.Int,4),
					new SqlParameter("@BuyRight", SqlDbType.Int,4),
					new SqlParameter("@MoneyToPoint", SqlDbType.Decimal,9),
					new SqlParameter("@PointToMoney", SqlDbType.NVarChar,500),
					new SqlParameter("@IsHidePrice", SqlDbType.Int,4),
					new SqlParameter("@OrderSubmitCount", SqlDbType.Int,4),
					new SqlParameter("@RegisterType", SqlDbType.Int,4),
					new SqlParameter("@IsUsedAgent", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Grade;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.PriceName;
			parameters[4].Value = model.Type_id_PriceType;
			parameters[5].Value = model.Lpoint;
			parameters[6].Value = model.Price;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.LisDefault;
			parameters[9].Value = model.ImageUrl;
			parameters[10].Value = model.OrderSubmit;
			parameters[11].Value = model.LoginPointCut;
			parameters[12].Value = model.LoginPointAdd;
			parameters[13].Value = model.Comment;
			parameters[14].Value = model.BuyRight;
			parameters[15].Value = model.MoneyToPoint;
			parameters[16].Value = model.PointToMoney;
			parameters[17].Value = model.IsHidePrice;
			parameters[18].Value = model.OrderSubmitCount;
			parameters[19].Value = model.RegisterType;
			parameters[20].Value = model.IsUsedAgent;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_UserLevel] ");
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
			strSql.Append("delete from [Lebi_UserLevel] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_UserLevel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_UserLevel GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_UserLevel] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_UserLevel model=new Lebi_UserLevel();
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
				model.PriceName=ds.Tables[0].Rows[0]["PriceName"].ToString();
				model.Type_id_PriceType=ds.Tables[0].Rows[0]["Type_id_PriceType"].ToString();
				if(ds.Tables[0].Rows[0]["Lpoint"].ToString()!="")
				{
					model.Lpoint=int.Parse(ds.Tables[0].Rows[0]["Lpoint"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
				if(ds.Tables[0].Rows[0]["LisDefault"].ToString()!="")
				{
					model.LisDefault=int.Parse(ds.Tables[0].Rows[0]["LisDefault"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["OrderSubmit"].ToString()!="")
				{
					model.OrderSubmit=decimal.Parse(ds.Tables[0].Rows[0]["OrderSubmit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoginPointCut"].ToString()!="")
				{
					model.LoginPointCut=int.Parse(ds.Tables[0].Rows[0]["LoginPointCut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoginPointAdd"].ToString()!="")
				{
					model.LoginPointAdd=int.Parse(ds.Tables[0].Rows[0]["LoginPointAdd"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Comment"].ToString()!="")
				{
					model.Comment=int.Parse(ds.Tables[0].Rows[0]["Comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BuyRight"].ToString()!="")
				{
					model.BuyRight=int.Parse(ds.Tables[0].Rows[0]["BuyRight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MoneyToPoint"].ToString()!="")
				{
					model.MoneyToPoint=decimal.Parse(ds.Tables[0].Rows[0]["MoneyToPoint"].ToString());
				}
				model.PointToMoney=ds.Tables[0].Rows[0]["PointToMoney"].ToString();
				if(ds.Tables[0].Rows[0]["IsHidePrice"].ToString()!="")
				{
					model.IsHidePrice=int.Parse(ds.Tables[0].Rows[0]["IsHidePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderSubmitCount"].ToString()!="")
				{
					model.OrderSubmitCount=int.Parse(ds.Tables[0].Rows[0]["OrderSubmitCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RegisterType"].ToString()!="")
				{
					model.RegisterType=int.Parse(ds.Tables[0].Rows[0]["RegisterType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString()!="")
				{
					model.IsUsedAgent=int.Parse(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString());
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
		public Lebi_UserLevel GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_UserLevel] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_UserLevel model=new Lebi_UserLevel();
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
				model.PriceName=ds.Tables[0].Rows[0]["PriceName"].ToString();
				model.Type_id_PriceType=ds.Tables[0].Rows[0]["Type_id_PriceType"].ToString();
				if(ds.Tables[0].Rows[0]["Lpoint"].ToString()!="")
				{
					model.Lpoint=int.Parse(ds.Tables[0].Rows[0]["Lpoint"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
				if(ds.Tables[0].Rows[0]["LisDefault"].ToString()!="")
				{
					model.LisDefault=int.Parse(ds.Tables[0].Rows[0]["LisDefault"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["OrderSubmit"].ToString()!="")
				{
					model.OrderSubmit=decimal.Parse(ds.Tables[0].Rows[0]["OrderSubmit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoginPointCut"].ToString()!="")
				{
					model.LoginPointCut=int.Parse(ds.Tables[0].Rows[0]["LoginPointCut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoginPointAdd"].ToString()!="")
				{
					model.LoginPointAdd=int.Parse(ds.Tables[0].Rows[0]["LoginPointAdd"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Comment"].ToString()!="")
				{
					model.Comment=int.Parse(ds.Tables[0].Rows[0]["Comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BuyRight"].ToString()!="")
				{
					model.BuyRight=int.Parse(ds.Tables[0].Rows[0]["BuyRight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MoneyToPoint"].ToString()!="")
				{
					model.MoneyToPoint=decimal.Parse(ds.Tables[0].Rows[0]["MoneyToPoint"].ToString());
				}
				model.PointToMoney=ds.Tables[0].Rows[0]["PointToMoney"].ToString();
				if(ds.Tables[0].Rows[0]["IsHidePrice"].ToString()!="")
				{
					model.IsHidePrice=int.Parse(ds.Tables[0].Rows[0]["IsHidePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderSubmitCount"].ToString()!="")
				{
					model.OrderSubmitCount=int.Parse(ds.Tables[0].Rows[0]["OrderSubmitCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RegisterType"].ToString()!="")
				{
					model.RegisterType=int.Parse(ds.Tables[0].Rows[0]["RegisterType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString()!="")
				{
					model.IsUsedAgent=int.Parse(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString());
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
		public Lebi_UserLevel GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_UserLevel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_UserLevel model=new Lebi_UserLevel();
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
				model.PriceName=ds.Tables[0].Rows[0]["PriceName"].ToString();
				model.Type_id_PriceType=ds.Tables[0].Rows[0]["Type_id_PriceType"].ToString();
				if(ds.Tables[0].Rows[0]["Lpoint"].ToString()!="")
				{
					model.Lpoint=int.Parse(ds.Tables[0].Rows[0]["Lpoint"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
				if(ds.Tables[0].Rows[0]["LisDefault"].ToString()!="")
				{
					model.LisDefault=int.Parse(ds.Tables[0].Rows[0]["LisDefault"].ToString());
				}
				model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["OrderSubmit"].ToString()!="")
				{
					model.OrderSubmit=decimal.Parse(ds.Tables[0].Rows[0]["OrderSubmit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoginPointCut"].ToString()!="")
				{
					model.LoginPointCut=int.Parse(ds.Tables[0].Rows[0]["LoginPointCut"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoginPointAdd"].ToString()!="")
				{
					model.LoginPointAdd=int.Parse(ds.Tables[0].Rows[0]["LoginPointAdd"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Comment"].ToString()!="")
				{
					model.Comment=int.Parse(ds.Tables[0].Rows[0]["Comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BuyRight"].ToString()!="")
				{
					model.BuyRight=int.Parse(ds.Tables[0].Rows[0]["BuyRight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MoneyToPoint"].ToString()!="")
				{
					model.MoneyToPoint=decimal.Parse(ds.Tables[0].Rows[0]["MoneyToPoint"].ToString());
				}
				model.PointToMoney=ds.Tables[0].Rows[0]["PointToMoney"].ToString();
				if(ds.Tables[0].Rows[0]["IsHidePrice"].ToString()!="")
				{
					model.IsHidePrice=int.Parse(ds.Tables[0].Rows[0]["IsHidePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderSubmitCount"].ToString()!="")
				{
					model.OrderSubmitCount=int.Parse(ds.Tables[0].Rows[0]["OrderSubmitCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RegisterType"].ToString()!="")
				{
					model.RegisterType=int.Parse(ds.Tables[0].Rows[0]["RegisterType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString()!="")
				{
					model.IsUsedAgent=int.Parse(ds.Tables[0].Rows[0]["IsUsedAgent"].ToString());
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
		public List<Lebi_UserLevel> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_UserLevel]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_UserLevel> list = new List<Lebi_UserLevel>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_UserLevel> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_UserLevel]";
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
			List<Lebi_UserLevel> list = new List<Lebi_UserLevel>();
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
		public List<Lebi_UserLevel> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_UserLevel] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_UserLevel> list = new List<Lebi_UserLevel>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_UserLevel> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_UserLevel]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_UserLevel> list = new List<Lebi_UserLevel>();
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
		public Lebi_UserLevel BindForm(Lebi_UserLevel model)
		{
			if (HttpContext.Current.Request["Grade"] != null)
				model.Grade=Shop.Tools.RequestTool.RequestInt("Grade",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["PriceName"] != null)
				model.PriceName=Shop.Tools.RequestTool.RequestString("PriceName");
			if (HttpContext.Current.Request["Type_id_PriceType"] != null)
				model.Type_id_PriceType=Shop.Tools.RequestTool.RequestString("Type_id_PriceType");
			if (HttpContext.Current.Request["Lpoint"] != null)
				model.Lpoint=Shop.Tools.RequestTool.RequestInt("Lpoint",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["remark"] != null)
				model.remark=Shop.Tools.RequestTool.RequestString("remark");
			if (HttpContext.Current.Request["LisDefault"] != null)
				model.LisDefault=Shop.Tools.RequestTool.RequestInt("LisDefault",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["OrderSubmit"] != null)
				model.OrderSubmit=Shop.Tools.RequestTool.RequestDecimal("OrderSubmit",0);
			if (HttpContext.Current.Request["LoginPointCut"] != null)
				model.LoginPointCut=Shop.Tools.RequestTool.RequestInt("LoginPointCut",0);
			if (HttpContext.Current.Request["LoginPointAdd"] != null)
				model.LoginPointAdd=Shop.Tools.RequestTool.RequestInt("LoginPointAdd",0);
			if (HttpContext.Current.Request["Comment"] != null)
				model.Comment=Shop.Tools.RequestTool.RequestInt("Comment",0);
			if (HttpContext.Current.Request["BuyRight"] != null)
				model.BuyRight=Shop.Tools.RequestTool.RequestInt("BuyRight",0);
			if (HttpContext.Current.Request["MoneyToPoint"] != null)
				model.MoneyToPoint=Shop.Tools.RequestTool.RequestDecimal("MoneyToPoint",0);
			if (HttpContext.Current.Request["PointToMoney"] != null)
				model.PointToMoney=Shop.Tools.RequestTool.RequestString("PointToMoney");
			if (HttpContext.Current.Request["IsHidePrice"] != null)
				model.IsHidePrice=Shop.Tools.RequestTool.RequestInt("IsHidePrice",0);
			if (HttpContext.Current.Request["OrderSubmitCount"] != null)
				model.OrderSubmitCount=Shop.Tools.RequestTool.RequestInt("OrderSubmitCount",0);
			if (HttpContext.Current.Request["RegisterType"] != null)
				model.RegisterType=Shop.Tools.RequestTool.RequestInt("RegisterType",0);
			if (HttpContext.Current.Request["IsUsedAgent"] != null)
				model.IsUsedAgent=Shop.Tools.RequestTool.RequestInt("IsUsedAgent",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_UserLevel SafeBindForm(Lebi_UserLevel model)
		{
			if (HttpContext.Current.Request["Grade"] != null)
				model.Grade=Shop.Tools.RequestTool.RequestInt("Grade",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["PriceName"] != null)
				model.PriceName=Shop.Tools.RequestTool.RequestSafeString("PriceName");
			if (HttpContext.Current.Request["Type_id_PriceType"] != null)
				model.Type_id_PriceType=Shop.Tools.RequestTool.RequestSafeString("Type_id_PriceType");
			if (HttpContext.Current.Request["Lpoint"] != null)
				model.Lpoint=Shop.Tools.RequestTool.RequestInt("Lpoint",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["remark"] != null)
				model.remark=Shop.Tools.RequestTool.RequestSafeString("remark");
			if (HttpContext.Current.Request["LisDefault"] != null)
				model.LisDefault=Shop.Tools.RequestTool.RequestInt("LisDefault",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["OrderSubmit"] != null)
				model.OrderSubmit=Shop.Tools.RequestTool.RequestDecimal("OrderSubmit",0);
			if (HttpContext.Current.Request["LoginPointCut"] != null)
				model.LoginPointCut=Shop.Tools.RequestTool.RequestInt("LoginPointCut",0);
			if (HttpContext.Current.Request["LoginPointAdd"] != null)
				model.LoginPointAdd=Shop.Tools.RequestTool.RequestInt("LoginPointAdd",0);
			if (HttpContext.Current.Request["Comment"] != null)
				model.Comment=Shop.Tools.RequestTool.RequestInt("Comment",0);
			if (HttpContext.Current.Request["BuyRight"] != null)
				model.BuyRight=Shop.Tools.RequestTool.RequestInt("BuyRight",0);
			if (HttpContext.Current.Request["MoneyToPoint"] != null)
				model.MoneyToPoint=Shop.Tools.RequestTool.RequestDecimal("MoneyToPoint",0);
			if (HttpContext.Current.Request["PointToMoney"] != null)
				model.PointToMoney=Shop.Tools.RequestTool.RequestSafeString("PointToMoney");
			if (HttpContext.Current.Request["IsHidePrice"] != null)
				model.IsHidePrice=Shop.Tools.RequestTool.RequestInt("IsHidePrice",0);
			if (HttpContext.Current.Request["OrderSubmitCount"] != null)
				model.OrderSubmitCount=Shop.Tools.RequestTool.RequestInt("OrderSubmitCount",0);
			if (HttpContext.Current.Request["RegisterType"] != null)
				model.RegisterType=Shop.Tools.RequestTool.RequestInt("RegisterType",0);
			if (HttpContext.Current.Request["IsUsedAgent"] != null)
				model.IsUsedAgent=Shop.Tools.RequestTool.RequestInt("IsUsedAgent",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_UserLevel ReaderBind(IDataReader dataReader)
		{
			Lebi_UserLevel model=new Lebi_UserLevel();
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
			model.PriceName=dataReader["PriceName"].ToString();
			model.Type_id_PriceType=dataReader["Type_id_PriceType"].ToString();
			ojb = dataReader["Lpoint"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Lpoint=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			model.remark=dataReader["remark"].ToString();
			ojb = dataReader["LisDefault"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LisDefault=(int)ojb;
			}
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			ojb = dataReader["OrderSubmit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderSubmit=(decimal)ojb;
			}
			ojb = dataReader["LoginPointCut"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LoginPointCut=(int)ojb;
			}
			ojb = dataReader["LoginPointAdd"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LoginPointAdd=(int)ojb;
			}
			ojb = dataReader["Comment"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Comment=(int)ojb;
			}
			ojb = dataReader["BuyRight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BuyRight=(int)ojb;
			}
			ojb = dataReader["MoneyToPoint"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MoneyToPoint=(decimal)ojb;
			}
			model.PointToMoney=dataReader["PointToMoney"].ToString();
			ojb = dataReader["IsHidePrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsHidePrice=(int)ojb;
			}
			ojb = dataReader["OrderSubmitCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderSubmitCount=(int)ojb;
			}
			ojb = dataReader["RegisterType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RegisterType=(int)ojb;
			}
			ojb = dataReader["IsUsedAgent"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUsedAgent=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_UserLevel : Lebi_UserLevel_interface
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
				strSql.Append("select " + colName + " from [Lebi_UserLevel]");
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
			strSql.Append("select  "+colName+" from [Lebi_UserLevel]");
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
			strSql.Append("select count(*) from [Lebi_UserLevel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_UserLevel]");
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
			strSql.Append("select max(id) from [Lebi_UserLevel]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_UserLevel]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_UserLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_UserLevel](");
			strSql.Append("[Grade],[Name],[PriceName],[Type_id_PriceType],[Lpoint],[Price],[remark],[LisDefault],[ImageUrl],[OrderSubmit],[LoginPointCut],[LoginPointAdd],[Comment],[BuyRight],[MoneyToPoint],[PointToMoney],[IsHidePrice],[OrderSubmitCount],[RegisterType],[IsUsedAgent])");
			strSql.Append(" values (");
			strSql.Append("@Grade,@Name,@PriceName,@Type_id_PriceType,@Lpoint,@Price,@remark,@LisDefault,@ImageUrl,@OrderSubmit,@LoginPointCut,@LoginPointAdd,@Comment,@BuyRight,@MoneyToPoint,@PointToMoney,@IsHidePrice,@OrderSubmitCount,@RegisterType,@IsUsedAgent)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Grade", model.Grade),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@PriceName", model.PriceName),
					new OleDbParameter("@Type_id_PriceType", model.Type_id_PriceType),
					new OleDbParameter("@Lpoint", model.Lpoint),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@remark", model.remark),
					new OleDbParameter("@LisDefault", model.LisDefault),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@OrderSubmit", model.OrderSubmit),
					new OleDbParameter("@LoginPointCut", model.LoginPointCut),
					new OleDbParameter("@LoginPointAdd", model.LoginPointAdd),
					new OleDbParameter("@Comment", model.Comment),
					new OleDbParameter("@BuyRight", model.BuyRight),
					new OleDbParameter("@MoneyToPoint", model.MoneyToPoint),
					new OleDbParameter("@PointToMoney", model.PointToMoney),
					new OleDbParameter("@IsHidePrice", model.IsHidePrice),
					new OleDbParameter("@OrderSubmitCount", model.OrderSubmitCount),
					new OleDbParameter("@RegisterType", model.RegisterType),
					new OleDbParameter("@IsUsedAgent", model.IsUsedAgent)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_UserLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_UserLevel] set ");
			strSql.Append("[Grade]=@Grade,");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[PriceName]=@PriceName,");
			strSql.Append("[Type_id_PriceType]=@Type_id_PriceType,");
			strSql.Append("[Lpoint]=@Lpoint,");
			strSql.Append("[Price]=@Price,");
			strSql.Append("[remark]=@remark,");
			strSql.Append("[LisDefault]=@LisDefault,");
			strSql.Append("[ImageUrl]=@ImageUrl,");
			strSql.Append("[OrderSubmit]=@OrderSubmit,");
			strSql.Append("[LoginPointCut]=@LoginPointCut,");
			strSql.Append("[LoginPointAdd]=@LoginPointAdd,");
			strSql.Append("[Comment]=@Comment,");
			strSql.Append("[BuyRight]=@BuyRight,");
			strSql.Append("[MoneyToPoint]=@MoneyToPoint,");
			strSql.Append("[PointToMoney]=@PointToMoney,");
			strSql.Append("[IsHidePrice]=@IsHidePrice,");
			strSql.Append("[OrderSubmitCount]=@OrderSubmitCount,");
			strSql.Append("[RegisterType]=@RegisterType,");
			strSql.Append("[IsUsedAgent]=@IsUsedAgent");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Grade", model.Grade),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@PriceName", model.PriceName),
					new OleDbParameter("@Type_id_PriceType", model.Type_id_PriceType),
					new OleDbParameter("@Lpoint", model.Lpoint),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@remark", model.remark),
					new OleDbParameter("@LisDefault", model.LisDefault),
					new OleDbParameter("@ImageUrl", model.ImageUrl),
					new OleDbParameter("@OrderSubmit", model.OrderSubmit),
					new OleDbParameter("@LoginPointCut", model.LoginPointCut),
					new OleDbParameter("@LoginPointAdd", model.LoginPointAdd),
					new OleDbParameter("@Comment", model.Comment),
					new OleDbParameter("@BuyRight", model.BuyRight),
					new OleDbParameter("@MoneyToPoint", model.MoneyToPoint),
					new OleDbParameter("@PointToMoney", model.PointToMoney),
					new OleDbParameter("@IsHidePrice", model.IsHidePrice),
					new OleDbParameter("@OrderSubmitCount", model.OrderSubmitCount),
					new OleDbParameter("@RegisterType", model.RegisterType),
					new OleDbParameter("@IsUsedAgent", model.IsUsedAgent)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_UserLevel] ");
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
			strSql.Append("delete from [Lebi_UserLevel] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_UserLevel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_UserLevel GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_UserLevel] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_UserLevel model;
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
		public Lebi_UserLevel GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_UserLevel] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_UserLevel model;
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
		public Lebi_UserLevel GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_UserLevel] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_UserLevel model;
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
		public List<Lebi_UserLevel> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_UserLevel]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_UserLevel> list = new List<Lebi_UserLevel>();
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
		public List<Lebi_UserLevel> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_UserLevel]";
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
			List<Lebi_UserLevel> list = new List<Lebi_UserLevel>();
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
		public List<Lebi_UserLevel> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_UserLevel] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_UserLevel> list = new List<Lebi_UserLevel>();
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
		public List<Lebi_UserLevel> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_UserLevel]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_UserLevel> list = new List<Lebi_UserLevel>();
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
		public Lebi_UserLevel BindForm(Lebi_UserLevel model)
		{
			if (HttpContext.Current.Request["Grade"] != null)
				model.Grade=Shop.Tools.RequestTool.RequestInt("Grade",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["PriceName"] != null)
				model.PriceName=Shop.Tools.RequestTool.RequestString("PriceName");
			if (HttpContext.Current.Request["Type_id_PriceType"] != null)
				model.Type_id_PriceType=Shop.Tools.RequestTool.RequestString("Type_id_PriceType");
			if (HttpContext.Current.Request["Lpoint"] != null)
				model.Lpoint=Shop.Tools.RequestTool.RequestInt("Lpoint",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["remark"] != null)
				model.remark=Shop.Tools.RequestTool.RequestString("remark");
			if (HttpContext.Current.Request["LisDefault"] != null)
				model.LisDefault=Shop.Tools.RequestTool.RequestInt("LisDefault",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestString("ImageUrl");
			if (HttpContext.Current.Request["OrderSubmit"] != null)
				model.OrderSubmit=Shop.Tools.RequestTool.RequestDecimal("OrderSubmit",0);
			if (HttpContext.Current.Request["LoginPointCut"] != null)
				model.LoginPointCut=Shop.Tools.RequestTool.RequestInt("LoginPointCut",0);
			if (HttpContext.Current.Request["LoginPointAdd"] != null)
				model.LoginPointAdd=Shop.Tools.RequestTool.RequestInt("LoginPointAdd",0);
			if (HttpContext.Current.Request["Comment"] != null)
				model.Comment=Shop.Tools.RequestTool.RequestInt("Comment",0);
			if (HttpContext.Current.Request["BuyRight"] != null)
				model.BuyRight=Shop.Tools.RequestTool.RequestInt("BuyRight",0);
			if (HttpContext.Current.Request["MoneyToPoint"] != null)
				model.MoneyToPoint=Shop.Tools.RequestTool.RequestDecimal("MoneyToPoint",0);
			if (HttpContext.Current.Request["PointToMoney"] != null)
				model.PointToMoney=Shop.Tools.RequestTool.RequestString("PointToMoney");
			if (HttpContext.Current.Request["IsHidePrice"] != null)
				model.IsHidePrice=Shop.Tools.RequestTool.RequestInt("IsHidePrice",0);
			if (HttpContext.Current.Request["OrderSubmitCount"] != null)
				model.OrderSubmitCount=Shop.Tools.RequestTool.RequestInt("OrderSubmitCount",0);
			if (HttpContext.Current.Request["RegisterType"] != null)
				model.RegisterType=Shop.Tools.RequestTool.RequestInt("RegisterType",0);
			if (HttpContext.Current.Request["IsUsedAgent"] != null)
				model.IsUsedAgent=Shop.Tools.RequestTool.RequestInt("IsUsedAgent",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_UserLevel SafeBindForm(Lebi_UserLevel model)
		{
			if (HttpContext.Current.Request["Grade"] != null)
				model.Grade=Shop.Tools.RequestTool.RequestInt("Grade",0);
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["PriceName"] != null)
				model.PriceName=Shop.Tools.RequestTool.RequestSafeString("PriceName");
			if (HttpContext.Current.Request["Type_id_PriceType"] != null)
				model.Type_id_PriceType=Shop.Tools.RequestTool.RequestSafeString("Type_id_PriceType");
			if (HttpContext.Current.Request["Lpoint"] != null)
				model.Lpoint=Shop.Tools.RequestTool.RequestInt("Lpoint",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["remark"] != null)
				model.remark=Shop.Tools.RequestTool.RequestSafeString("remark");
			if (HttpContext.Current.Request["LisDefault"] != null)
				model.LisDefault=Shop.Tools.RequestTool.RequestInt("LisDefault",0);
			if (HttpContext.Current.Request["ImageUrl"] != null)
				model.ImageUrl=Shop.Tools.RequestTool.RequestSafeString("ImageUrl");
			if (HttpContext.Current.Request["OrderSubmit"] != null)
				model.OrderSubmit=Shop.Tools.RequestTool.RequestDecimal("OrderSubmit",0);
			if (HttpContext.Current.Request["LoginPointCut"] != null)
				model.LoginPointCut=Shop.Tools.RequestTool.RequestInt("LoginPointCut",0);
			if (HttpContext.Current.Request["LoginPointAdd"] != null)
				model.LoginPointAdd=Shop.Tools.RequestTool.RequestInt("LoginPointAdd",0);
			if (HttpContext.Current.Request["Comment"] != null)
				model.Comment=Shop.Tools.RequestTool.RequestInt("Comment",0);
			if (HttpContext.Current.Request["BuyRight"] != null)
				model.BuyRight=Shop.Tools.RequestTool.RequestInt("BuyRight",0);
			if (HttpContext.Current.Request["MoneyToPoint"] != null)
				model.MoneyToPoint=Shop.Tools.RequestTool.RequestDecimal("MoneyToPoint",0);
			if (HttpContext.Current.Request["PointToMoney"] != null)
				model.PointToMoney=Shop.Tools.RequestTool.RequestSafeString("PointToMoney");
			if (HttpContext.Current.Request["IsHidePrice"] != null)
				model.IsHidePrice=Shop.Tools.RequestTool.RequestInt("IsHidePrice",0);
			if (HttpContext.Current.Request["OrderSubmitCount"] != null)
				model.OrderSubmitCount=Shop.Tools.RequestTool.RequestInt("OrderSubmitCount",0);
			if (HttpContext.Current.Request["RegisterType"] != null)
				model.RegisterType=Shop.Tools.RequestTool.RequestInt("RegisterType",0);
			if (HttpContext.Current.Request["IsUsedAgent"] != null)
				model.IsUsedAgent=Shop.Tools.RequestTool.RequestInt("IsUsedAgent",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_UserLevel ReaderBind(IDataReader dataReader)
		{
			Lebi_UserLevel model=new Lebi_UserLevel();
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
			model.PriceName=dataReader["PriceName"].ToString();
			model.Type_id_PriceType=dataReader["Type_id_PriceType"].ToString();
			ojb = dataReader["Lpoint"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Lpoint=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			model.remark=dataReader["remark"].ToString();
			ojb = dataReader["LisDefault"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LisDefault=(int)ojb;
			}
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			ojb = dataReader["OrderSubmit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderSubmit=(decimal)ojb;
			}
			ojb = dataReader["LoginPointCut"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LoginPointCut=(int)ojb;
			}
			ojb = dataReader["LoginPointAdd"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LoginPointAdd=(int)ojb;
			}
			ojb = dataReader["Comment"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Comment=(int)ojb;
			}
			ojb = dataReader["BuyRight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BuyRight=(int)ojb;
			}
			ojb = dataReader["MoneyToPoint"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MoneyToPoint=(decimal)ojb;
			}
			model.PointToMoney=dataReader["PointToMoney"].ToString();
			ojb = dataReader["IsHidePrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsHidePrice=(int)ojb;
			}
			ojb = dataReader["OrderSubmitCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderSubmitCount=(int)ojb;
			}
			ojb = dataReader["RegisterType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RegisterType=(int)ojb;
			}
			ojb = dataReader["IsUsedAgent"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUsedAgent=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

