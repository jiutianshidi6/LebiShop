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

	public interface Lebi_Transport_Price_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Transport_Price model);
		void Update(Lebi_Transport_Price model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Transport_Price GetModel(int id);
		Lebi_Transport_Price GetModel(string strWhere);
		Lebi_Transport_Price GetModel(SQLPara para);
		List<Lebi_Transport_Price> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Transport_Price> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Transport_Price> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Transport_Price> GetList(SQLPara para);
		Lebi_Transport_Price BindForm(Lebi_Transport_Price model);
		Lebi_Transport_Price SafeBindForm(Lebi_Transport_Price model);
		Lebi_Transport_Price ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Transport_Price。
	/// </summary>
	public class D_Lebi_Transport_Price
	{
		static Lebi_Transport_Price_interface _Instance;
		public static Lebi_Transport_Price_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Transport_Price();
		            else
		                _Instance = new sqlserver_Lebi_Transport_Price();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Transport_Price()
		{}
		#region  成员方法
	class sqlserver_Lebi_Transport_Price : Lebi_Transport_Price_interface
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
				strSql.Append("select " + colName + " from [Lebi_Transport_Price]");
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
			strSql.Append("select  "+colName+" from [Lebi_Transport_Price]");
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
			strSql.Append("select count(1) from [Lebi_Transport_Price]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Transport_Price]");
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
			strSql.Append("select max(id) from [Lebi_Transport_Price]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Transport_Price]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Transport_Price model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Transport_Price](");
			strSql.Append("Transport_id,Price,Weight_Start,Weight_Step,Price_Step,IsCanofflinePay,Description,IsOnePrice,Area_id,OrderMoney,Container,Price_OrderMoneyOK,Supplier_id,Sort)");
			strSql.Append(" values (");
			strSql.Append("@Transport_id,@Price,@Weight_Start,@Weight_Step,@Price_Step,@IsCanofflinePay,@Description,@IsOnePrice,@Area_id,@OrderMoney,@Container,@Price_OrderMoneyOK,@Supplier_id,@Sort)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Transport_id", model.Transport_id),
					new SqlParameter("@Price", model.Price),
					new SqlParameter("@Weight_Start", model.Weight_Start),
					new SqlParameter("@Weight_Step", model.Weight_Step),
					new SqlParameter("@Price_Step", model.Price_Step),
					new SqlParameter("@IsCanofflinePay", model.IsCanofflinePay),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@IsOnePrice", model.IsOnePrice),
					new SqlParameter("@Area_id", model.Area_id),
					new SqlParameter("@OrderMoney", model.OrderMoney),
					new SqlParameter("@Container", model.Container),
					new SqlParameter("@Price_OrderMoneyOK", model.Price_OrderMoneyOK),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Sort", model.Sort)};

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
		public void Update(Lebi_Transport_Price model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Transport_Price] set ");
			strSql.Append("Transport_id= @Transport_id,");
			strSql.Append("Price= @Price,");
			strSql.Append("Weight_Start= @Weight_Start,");
			strSql.Append("Weight_Step= @Weight_Step,");
			strSql.Append("Price_Step= @Price_Step,");
			strSql.Append("IsCanofflinePay= @IsCanofflinePay,");
			strSql.Append("Description= @Description,");
			strSql.Append("IsOnePrice= @IsOnePrice,");
			strSql.Append("Area_id= @Area_id,");
			strSql.Append("OrderMoney= @OrderMoney,");
			strSql.Append("Container= @Container,");
			strSql.Append("Price_OrderMoneyOK= @Price_OrderMoneyOK,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Sort= @Sort");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Transport_id", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Weight_Start", SqlDbType.Decimal,9),
					new SqlParameter("@Weight_Step", SqlDbType.Decimal,9),
					new SqlParameter("@Price_Step", SqlDbType.Decimal,9),
					new SqlParameter("@IsCanofflinePay", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,400),
					new SqlParameter("@IsOnePrice", SqlDbType.Int,4),
					new SqlParameter("@Area_id", SqlDbType.Int,4),
					new SqlParameter("@OrderMoney", SqlDbType.Decimal,9),
					new SqlParameter("@Container", SqlDbType.NVarChar,2000),
					new SqlParameter("@Price_OrderMoneyOK", SqlDbType.Decimal,9),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Transport_id;
			parameters[2].Value = model.Price;
			parameters[3].Value = model.Weight_Start;
			parameters[4].Value = model.Weight_Step;
			parameters[5].Value = model.Price_Step;
			parameters[6].Value = model.IsCanofflinePay;
			parameters[7].Value = model.Description;
			parameters[8].Value = model.IsOnePrice;
			parameters[9].Value = model.Area_id;
			parameters[10].Value = model.OrderMoney;
			parameters[11].Value = model.Container;
			parameters[12].Value = model.Price_OrderMoneyOK;
			parameters[13].Value = model.Supplier_id;
			parameters[14].Value = model.Sort;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Transport_Price] ");
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
			strSql.Append("delete from [Lebi_Transport_Price] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Transport_Price] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Transport_Price GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Transport_Price] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Transport_Price model=new Lebi_Transport_Price();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Transport_id"].ToString()!="")
				{
					model.Transport_id=int.Parse(ds.Tables[0].Rows[0]["Transport_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Weight_Start"].ToString()!="")
				{
					model.Weight_Start=decimal.Parse(ds.Tables[0].Rows[0]["Weight_Start"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Weight_Step"].ToString()!="")
				{
					model.Weight_Step=decimal.Parse(ds.Tables[0].Rows[0]["Weight_Step"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Step"].ToString()!="")
				{
					model.Price_Step=decimal.Parse(ds.Tables[0].Rows[0]["Price_Step"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCanofflinePay"].ToString()!="")
				{
					model.IsCanofflinePay=int.Parse(ds.Tables[0].Rows[0]["IsCanofflinePay"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsOnePrice"].ToString()!="")
				{
					model.IsOnePrice=int.Parse(ds.Tables[0].Rows[0]["IsOnePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderMoney"].ToString()!="")
				{
					model.OrderMoney=decimal.Parse(ds.Tables[0].Rows[0]["OrderMoney"].ToString());
				}
				model.Container=ds.Tables[0].Rows[0]["Container"].ToString();
				if(ds.Tables[0].Rows[0]["Price_OrderMoneyOK"].ToString()!="")
				{
					model.Price_OrderMoneyOK=decimal.Parse(ds.Tables[0].Rows[0]["Price_OrderMoneyOK"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
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
		public Lebi_Transport_Price GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Transport_Price] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Transport_Price model=new Lebi_Transport_Price();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Transport_id"].ToString()!="")
				{
					model.Transport_id=int.Parse(ds.Tables[0].Rows[0]["Transport_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Weight_Start"].ToString()!="")
				{
					model.Weight_Start=decimal.Parse(ds.Tables[0].Rows[0]["Weight_Start"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Weight_Step"].ToString()!="")
				{
					model.Weight_Step=decimal.Parse(ds.Tables[0].Rows[0]["Weight_Step"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Step"].ToString()!="")
				{
					model.Price_Step=decimal.Parse(ds.Tables[0].Rows[0]["Price_Step"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCanofflinePay"].ToString()!="")
				{
					model.IsCanofflinePay=int.Parse(ds.Tables[0].Rows[0]["IsCanofflinePay"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsOnePrice"].ToString()!="")
				{
					model.IsOnePrice=int.Parse(ds.Tables[0].Rows[0]["IsOnePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderMoney"].ToString()!="")
				{
					model.OrderMoney=decimal.Parse(ds.Tables[0].Rows[0]["OrderMoney"].ToString());
				}
				model.Container=ds.Tables[0].Rows[0]["Container"].ToString();
				if(ds.Tables[0].Rows[0]["Price_OrderMoneyOK"].ToString()!="")
				{
					model.Price_OrderMoneyOK=decimal.Parse(ds.Tables[0].Rows[0]["Price_OrderMoneyOK"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
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
		public Lebi_Transport_Price GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Transport_Price] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Transport_Price model=new Lebi_Transport_Price();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Transport_id"].ToString()!="")
				{
					model.Transport_id=int.Parse(ds.Tables[0].Rows[0]["Transport_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Weight_Start"].ToString()!="")
				{
					model.Weight_Start=decimal.Parse(ds.Tables[0].Rows[0]["Weight_Start"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Weight_Step"].ToString()!="")
				{
					model.Weight_Step=decimal.Parse(ds.Tables[0].Rows[0]["Weight_Step"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price_Step"].ToString()!="")
				{
					model.Price_Step=decimal.Parse(ds.Tables[0].Rows[0]["Price_Step"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCanofflinePay"].ToString()!="")
				{
					model.IsCanofflinePay=int.Parse(ds.Tables[0].Rows[0]["IsCanofflinePay"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["IsOnePrice"].ToString()!="")
				{
					model.IsOnePrice=int.Parse(ds.Tables[0].Rows[0]["IsOnePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Area_id"].ToString()!="")
				{
					model.Area_id=int.Parse(ds.Tables[0].Rows[0]["Area_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderMoney"].ToString()!="")
				{
					model.OrderMoney=decimal.Parse(ds.Tables[0].Rows[0]["OrderMoney"].ToString());
				}
				model.Container=ds.Tables[0].Rows[0]["Container"].ToString();
				if(ds.Tables[0].Rows[0]["Price_OrderMoneyOK"].ToString()!="")
				{
					model.Price_OrderMoneyOK=decimal.Parse(ds.Tables[0].Rows[0]["Price_OrderMoneyOK"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
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
		public List<Lebi_Transport_Price> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Transport_Price]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Transport_Price> list = new List<Lebi_Transport_Price>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Transport_Price> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Transport_Price]";
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
			List<Lebi_Transport_Price> list = new List<Lebi_Transport_Price>();
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
		public List<Lebi_Transport_Price> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Transport_Price] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Transport_Price> list = new List<Lebi_Transport_Price>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Transport_Price> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Transport_Price]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Transport_Price> list = new List<Lebi_Transport_Price>();
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
		public Lebi_Transport_Price BindForm(Lebi_Transport_Price model)
		{
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Weight_Start"] != null)
				model.Weight_Start=Shop.Tools.RequestTool.RequestDecimal("Weight_Start",0);
			if (HttpContext.Current.Request["Weight_Step"] != null)
				model.Weight_Step=Shop.Tools.RequestTool.RequestDecimal("Weight_Step",0);
			if (HttpContext.Current.Request["Price_Step"] != null)
				model.Price_Step=Shop.Tools.RequestTool.RequestDecimal("Price_Step",0);
			if (HttpContext.Current.Request["IsCanofflinePay"] != null)
				model.IsCanofflinePay=Shop.Tools.RequestTool.RequestInt("IsCanofflinePay",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["IsOnePrice"] != null)
				model.IsOnePrice=Shop.Tools.RequestTool.RequestInt("IsOnePrice",0);
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["OrderMoney"] != null)
				model.OrderMoney=Shop.Tools.RequestTool.RequestDecimal("OrderMoney",0);
			if (HttpContext.Current.Request["Container"] != null)
				model.Container=Shop.Tools.RequestTool.RequestString("Container");
			if (HttpContext.Current.Request["Price_OrderMoneyOK"] != null)
				model.Price_OrderMoneyOK=Shop.Tools.RequestTool.RequestDecimal("Price_OrderMoneyOK",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Transport_Price SafeBindForm(Lebi_Transport_Price model)
		{
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Weight_Start"] != null)
				model.Weight_Start=Shop.Tools.RequestTool.RequestDecimal("Weight_Start",0);
			if (HttpContext.Current.Request["Weight_Step"] != null)
				model.Weight_Step=Shop.Tools.RequestTool.RequestDecimal("Weight_Step",0);
			if (HttpContext.Current.Request["Price_Step"] != null)
				model.Price_Step=Shop.Tools.RequestTool.RequestDecimal("Price_Step",0);
			if (HttpContext.Current.Request["IsCanofflinePay"] != null)
				model.IsCanofflinePay=Shop.Tools.RequestTool.RequestInt("IsCanofflinePay",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["IsOnePrice"] != null)
				model.IsOnePrice=Shop.Tools.RequestTool.RequestInt("IsOnePrice",0);
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["OrderMoney"] != null)
				model.OrderMoney=Shop.Tools.RequestTool.RequestDecimal("OrderMoney",0);
			if (HttpContext.Current.Request["Container"] != null)
				model.Container=Shop.Tools.RequestTool.RequestSafeString("Container");
			if (HttpContext.Current.Request["Price_OrderMoneyOK"] != null)
				model.Price_OrderMoneyOK=Shop.Tools.RequestTool.RequestDecimal("Price_OrderMoneyOK",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Transport_Price ReaderBind(IDataReader dataReader)
		{
			Lebi_Transport_Price model=new Lebi_Transport_Price();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Transport_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Transport_id=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			ojb = dataReader["Weight_Start"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight_Start=(decimal)ojb;
			}
			ojb = dataReader["Weight_Step"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight_Step=(decimal)ojb;
			}
			ojb = dataReader["Price_Step"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Step=(decimal)ojb;
			}
			ojb = dataReader["IsCanofflinePay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCanofflinePay=(int)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["IsOnePrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsOnePrice=(int)ojb;
			}
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			ojb = dataReader["OrderMoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderMoney=(decimal)ojb;
			}
			model.Container=dataReader["Container"].ToString();
			ojb = dataReader["Price_OrderMoneyOK"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_OrderMoneyOK=(decimal)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Transport_Price : Lebi_Transport_Price_interface
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
				strSql.Append("select " + colName + " from [Lebi_Transport_Price]");
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
			strSql.Append("select  "+colName+" from [Lebi_Transport_Price]");
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
			strSql.Append("select count(*) from [Lebi_Transport_Price]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Transport_Price]");
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
			strSql.Append("select max(id) from [Lebi_Transport_Price]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Transport_Price]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Transport_Price model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Transport_Price](");
			strSql.Append("[Transport_id],[Price],[Weight_Start],[Weight_Step],[Price_Step],[IsCanofflinePay],[Description],[IsOnePrice],[Area_id],[OrderMoney],[Container],[Price_OrderMoneyOK],[Supplier_id],[Sort])");
			strSql.Append(" values (");
			strSql.Append("@Transport_id,@Price,@Weight_Start,@Weight_Step,@Price_Step,@IsCanofflinePay,@Description,@IsOnePrice,@Area_id,@OrderMoney,@Container,@Price_OrderMoneyOK,@Supplier_id,@Sort)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Transport_id", model.Transport_id),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Weight_Start", model.Weight_Start),
					new OleDbParameter("@Weight_Step", model.Weight_Step),
					new OleDbParameter("@Price_Step", model.Price_Step),
					new OleDbParameter("@IsCanofflinePay", model.IsCanofflinePay),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@IsOnePrice", model.IsOnePrice),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@OrderMoney", model.OrderMoney),
					new OleDbParameter("@Container", model.Container),
					new OleDbParameter("@Price_OrderMoneyOK", model.Price_OrderMoneyOK),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Sort", model.Sort)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Transport_Price model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Transport_Price] set ");
			strSql.Append("[Transport_id]=@Transport_id,");
			strSql.Append("[Price]=@Price,");
			strSql.Append("[Weight_Start]=@Weight_Start,");
			strSql.Append("[Weight_Step]=@Weight_Step,");
			strSql.Append("[Price_Step]=@Price_Step,");
			strSql.Append("[IsCanofflinePay]=@IsCanofflinePay,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[IsOnePrice]=@IsOnePrice,");
			strSql.Append("[Area_id]=@Area_id,");
			strSql.Append("[OrderMoney]=@OrderMoney,");
			strSql.Append("[Container]=@Container,");
			strSql.Append("[Price_OrderMoneyOK]=@Price_OrderMoneyOK,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Sort]=@Sort");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Transport_id", model.Transport_id),
					new OleDbParameter("@Price", model.Price),
					new OleDbParameter("@Weight_Start", model.Weight_Start),
					new OleDbParameter("@Weight_Step", model.Weight_Step),
					new OleDbParameter("@Price_Step", model.Price_Step),
					new OleDbParameter("@IsCanofflinePay", model.IsCanofflinePay),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@IsOnePrice", model.IsOnePrice),
					new OleDbParameter("@Area_id", model.Area_id),
					new OleDbParameter("@OrderMoney", model.OrderMoney),
					new OleDbParameter("@Container", model.Container),
					new OleDbParameter("@Price_OrderMoneyOK", model.Price_OrderMoneyOK),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Sort", model.Sort)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Transport_Price] ");
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
			strSql.Append("delete from [Lebi_Transport_Price] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Transport_Price] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Transport_Price GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Transport_Price] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Transport_Price model;
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
		public Lebi_Transport_Price GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Transport_Price] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Transport_Price model;
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
		public Lebi_Transport_Price GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Transport_Price] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Transport_Price model;
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
		public List<Lebi_Transport_Price> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Transport_Price]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Transport_Price> list = new List<Lebi_Transport_Price>();
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
		public List<Lebi_Transport_Price> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Transport_Price]";
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
			List<Lebi_Transport_Price> list = new List<Lebi_Transport_Price>();
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
		public List<Lebi_Transport_Price> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Transport_Price] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Transport_Price> list = new List<Lebi_Transport_Price>();
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
		public List<Lebi_Transport_Price> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Transport_Price]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Transport_Price> list = new List<Lebi_Transport_Price>();
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
		public Lebi_Transport_Price BindForm(Lebi_Transport_Price model)
		{
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Weight_Start"] != null)
				model.Weight_Start=Shop.Tools.RequestTool.RequestDecimal("Weight_Start",0);
			if (HttpContext.Current.Request["Weight_Step"] != null)
				model.Weight_Step=Shop.Tools.RequestTool.RequestDecimal("Weight_Step",0);
			if (HttpContext.Current.Request["Price_Step"] != null)
				model.Price_Step=Shop.Tools.RequestTool.RequestDecimal("Price_Step",0);
			if (HttpContext.Current.Request["IsCanofflinePay"] != null)
				model.IsCanofflinePay=Shop.Tools.RequestTool.RequestInt("IsCanofflinePay",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["IsOnePrice"] != null)
				model.IsOnePrice=Shop.Tools.RequestTool.RequestInt("IsOnePrice",0);
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["OrderMoney"] != null)
				model.OrderMoney=Shop.Tools.RequestTool.RequestDecimal("OrderMoney",0);
			if (HttpContext.Current.Request["Container"] != null)
				model.Container=Shop.Tools.RequestTool.RequestString("Container");
			if (HttpContext.Current.Request["Price_OrderMoneyOK"] != null)
				model.Price_OrderMoneyOK=Shop.Tools.RequestTool.RequestDecimal("Price_OrderMoneyOK",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Transport_Price SafeBindForm(Lebi_Transport_Price model)
		{
			if (HttpContext.Current.Request["Transport_id"] != null)
				model.Transport_id=Shop.Tools.RequestTool.RequestInt("Transport_id",0);
			if (HttpContext.Current.Request["Price"] != null)
				model.Price=Shop.Tools.RequestTool.RequestDecimal("Price",0);
			if (HttpContext.Current.Request["Weight_Start"] != null)
				model.Weight_Start=Shop.Tools.RequestTool.RequestDecimal("Weight_Start",0);
			if (HttpContext.Current.Request["Weight_Step"] != null)
				model.Weight_Step=Shop.Tools.RequestTool.RequestDecimal("Weight_Step",0);
			if (HttpContext.Current.Request["Price_Step"] != null)
				model.Price_Step=Shop.Tools.RequestTool.RequestDecimal("Price_Step",0);
			if (HttpContext.Current.Request["IsCanofflinePay"] != null)
				model.IsCanofflinePay=Shop.Tools.RequestTool.RequestInt("IsCanofflinePay",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["IsOnePrice"] != null)
				model.IsOnePrice=Shop.Tools.RequestTool.RequestInt("IsOnePrice",0);
			if (HttpContext.Current.Request["Area_id"] != null)
				model.Area_id=Shop.Tools.RequestTool.RequestInt("Area_id",0);
			if (HttpContext.Current.Request["OrderMoney"] != null)
				model.OrderMoney=Shop.Tools.RequestTool.RequestDecimal("OrderMoney",0);
			if (HttpContext.Current.Request["Container"] != null)
				model.Container=Shop.Tools.RequestTool.RequestSafeString("Container");
			if (HttpContext.Current.Request["Price_OrderMoneyOK"] != null)
				model.Price_OrderMoneyOK=Shop.Tools.RequestTool.RequestDecimal("Price_OrderMoneyOK",0);
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Transport_Price ReaderBind(IDataReader dataReader)
		{
			Lebi_Transport_Price model=new Lebi_Transport_Price();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Transport_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Transport_id=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			ojb = dataReader["Weight_Start"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight_Start=(decimal)ojb;
			}
			ojb = dataReader["Weight_Step"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Weight_Step=(decimal)ojb;
			}
			ojb = dataReader["Price_Step"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_Step=(decimal)ojb;
			}
			ojb = dataReader["IsCanofflinePay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCanofflinePay=(int)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["IsOnePrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsOnePrice=(int)ojb;
			}
			ojb = dataReader["Area_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area_id=(int)ojb;
			}
			ojb = dataReader["OrderMoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderMoney=(decimal)ojb;
			}
			model.Container=dataReader["Container"].ToString();
			ojb = dataReader["Price_OrderMoneyOK"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price_OrderMoneyOK=(decimal)ojb;
			}
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

