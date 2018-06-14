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

	public interface Lebi_User_Product_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_User_Product model);
		void Update(Lebi_User_Product model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_User_Product GetModel(int id);
		Lebi_User_Product GetModel(string strWhere);
		Lebi_User_Product GetModel(SQLPara para);
		List<Lebi_User_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_User_Product> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_User_Product> GetList(string strWhere, string strFieldOrder);
		List<Lebi_User_Product> GetList(SQLPara para);
		Lebi_User_Product BindForm(Lebi_User_Product model);
		Lebi_User_Product SafeBindForm(Lebi_User_Product model);
		Lebi_User_Product ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_User_Product。
	/// </summary>
	public class D_Lebi_User_Product
	{
		static Lebi_User_Product_interface _Instance;
		public static Lebi_User_Product_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_User_Product();
		            else
		                _Instance = new sqlserver_Lebi_User_Product();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_User_Product()
		{}
		#region  成员方法
	class sqlserver_Lebi_User_Product : Lebi_User_Product_interface
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
				strSql.Append("select " + colName + " from [Lebi_User_Product]");
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
			strSql.Append("select  "+colName+" from [Lebi_User_Product]");
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
			strSql.Append("select count(1) from [Lebi_User_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User_Product]");
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
			strSql.Append("select max(id) from [Lebi_User_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User_Product]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_User_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_User_Product](");
			strSql.Append("User_id,Product_id,Time_Add,Type_id_UserProductType,count,ImageOriginal,ImageBig,ImageMedium,ImageSmall,Product_Number,Pro_Type_id,Discount,Pointagain,Product_Point,Product_Price,ProPerty134,WarnDays,Time_addemail,ProPerty_Price)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Product_id,@Time_Add,@Type_id_UserProductType,@count,@ImageOriginal,@ImageBig,@ImageMedium,@ImageSmall,@Product_Number,@Pro_Type_id,@Discount,@Pointagain,@Product_Point,@Product_Price,@ProPerty134,@WarnDays,@Time_addemail,@ProPerty_Price)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@Product_id", model.Product_id),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Type_id_UserProductType", model.Type_id_UserProductType),
					new SqlParameter("@count", model.count),
					new SqlParameter("@ImageOriginal", model.ImageOriginal),
					new SqlParameter("@ImageBig", model.ImageBig),
					new SqlParameter("@ImageMedium", model.ImageMedium),
					new SqlParameter("@ImageSmall", model.ImageSmall),
					new SqlParameter("@Product_Number", model.Product_Number),
					new SqlParameter("@Pro_Type_id", model.Pro_Type_id),
					new SqlParameter("@Discount", model.Discount),
					new SqlParameter("@Pointagain", model.Pointagain),
					new SqlParameter("@Product_Point", model.Product_Point),
					new SqlParameter("@Product_Price", model.Product_Price),
					new SqlParameter("@ProPerty134", model.ProPerty134),
					new SqlParameter("@WarnDays", model.WarnDays),
					new SqlParameter("@Time_addemail", model.Time_addemail),
					new SqlParameter("@ProPerty_Price", model.ProPerty_Price)};

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
		public void Update(Lebi_User_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_User_Product] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("Product_id= @Product_id,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Type_id_UserProductType= @Type_id_UserProductType,");
			strSql.Append("count= @count,");
			strSql.Append("ImageOriginal= @ImageOriginal,");
			strSql.Append("ImageBig= @ImageBig,");
			strSql.Append("ImageMedium= @ImageMedium,");
			strSql.Append("ImageSmall= @ImageSmall,");
			strSql.Append("Product_Number= @Product_Number,");
			strSql.Append("Pro_Type_id= @Pro_Type_id,");
			strSql.Append("Discount= @Discount,");
			strSql.Append("Pointagain= @Pointagain,");
			strSql.Append("Product_Point= @Product_Point,");
			strSql.Append("Product_Price= @Product_Price,");
			strSql.Append("ProPerty134= @ProPerty134,");
			strSql.Append("WarnDays= @WarnDays,");
			strSql.Append("Time_addemail= @Time_addemail,");
			strSql.Append("ProPerty_Price= @ProPerty_Price");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@Product_id", SqlDbType.Int,4),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Type_id_UserProductType", SqlDbType.Int,4),
					new SqlParameter("@count", SqlDbType.Int,4),
					new SqlParameter("@ImageOriginal", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageBig", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageMedium", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageSmall", SqlDbType.NVarChar,200),
					new SqlParameter("@Product_Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Pro_Type_id", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Int,4),
					new SqlParameter("@Pointagain", SqlDbType.Int,4),
					new SqlParameter("@Product_Point", SqlDbType.Decimal,9),
					new SqlParameter("@Product_Price", SqlDbType.Decimal,9),
					new SqlParameter("@ProPerty134", SqlDbType.NVarChar,2000),
					new SqlParameter("@WarnDays", SqlDbType.Int,4),
					new SqlParameter("@Time_addemail", SqlDbType.DateTime),
					new SqlParameter("@ProPerty_Price", SqlDbType.Decimal,9)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.Product_id;
			parameters[3].Value = model.Time_Add;
			parameters[4].Value = model.Type_id_UserProductType;
			parameters[5].Value = model.count;
			parameters[6].Value = model.ImageOriginal;
			parameters[7].Value = model.ImageBig;
			parameters[8].Value = model.ImageMedium;
			parameters[9].Value = model.ImageSmall;
			parameters[10].Value = model.Product_Number;
			parameters[11].Value = model.Pro_Type_id;
			parameters[12].Value = model.Discount;
			parameters[13].Value = model.Pointagain;
			parameters[14].Value = model.Product_Point;
			parameters[15].Value = model.Product_Price;
			parameters[16].Value = model.ProPerty134;
			parameters[17].Value = model.WarnDays;
			parameters[18].Value = model.Time_addemail;
			parameters[19].Value = model.ProPerty_Price;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Product] ");
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
			strSql.Append("delete from [Lebi_User_Product] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_User_Product GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Product] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_User_Product model=new Lebi_User_Product();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_UserProductType"].ToString()!="")
				{
					model.Type_id_UserProductType=int.Parse(ds.Tables[0].Rows[0]["Type_id_UserProductType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["count"].ToString()!="")
				{
					model.count=int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
				}
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.Product_Number=ds.Tables[0].Rows[0]["Product_Number"].ToString();
				if(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString()!="")
				{
					model.Pro_Type_id=int.Parse(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Discount"].ToString()!="")
				{
					model.Discount=int.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pointagain"].ToString()!="")
				{
					model.Pointagain=int.Parse(ds.Tables[0].Rows[0]["Pointagain"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_Point"].ToString()!="")
				{
					model.Product_Point=decimal.Parse(ds.Tables[0].Rows[0]["Product_Point"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_Price"].ToString()!="")
				{
					model.Product_Price=decimal.Parse(ds.Tables[0].Rows[0]["Product_Price"].ToString());
				}
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				if(ds.Tables[0].Rows[0]["WarnDays"].ToString()!="")
				{
					model.WarnDays=int.Parse(ds.Tables[0].Rows[0]["WarnDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_addemail"].ToString()!="")
				{
					model.Time_addemail=DateTime.Parse(ds.Tables[0].Rows[0]["Time_addemail"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString()!="")
				{
					model.ProPerty_Price=decimal.Parse(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString());
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
		public Lebi_User_Product GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Product] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_User_Product model=new Lebi_User_Product();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_UserProductType"].ToString()!="")
				{
					model.Type_id_UserProductType=int.Parse(ds.Tables[0].Rows[0]["Type_id_UserProductType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["count"].ToString()!="")
				{
					model.count=int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
				}
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.Product_Number=ds.Tables[0].Rows[0]["Product_Number"].ToString();
				if(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString()!="")
				{
					model.Pro_Type_id=int.Parse(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Discount"].ToString()!="")
				{
					model.Discount=int.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pointagain"].ToString()!="")
				{
					model.Pointagain=int.Parse(ds.Tables[0].Rows[0]["Pointagain"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_Point"].ToString()!="")
				{
					model.Product_Point=decimal.Parse(ds.Tables[0].Rows[0]["Product_Point"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_Price"].ToString()!="")
				{
					model.Product_Price=decimal.Parse(ds.Tables[0].Rows[0]["Product_Price"].ToString());
				}
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				if(ds.Tables[0].Rows[0]["WarnDays"].ToString()!="")
				{
					model.WarnDays=int.Parse(ds.Tables[0].Rows[0]["WarnDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_addemail"].ToString()!="")
				{
					model.Time_addemail=DateTime.Parse(ds.Tables[0].Rows[0]["Time_addemail"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString()!="")
				{
					model.ProPerty_Price=decimal.Parse(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString());
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
		public Lebi_User_Product GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_User_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_User_Product model=new Lebi_User_Product();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["User_id"].ToString()!="")
				{
					model.User_id=int.Parse(ds.Tables[0].Rows[0]["User_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type_id_UserProductType"].ToString()!="")
				{
					model.Type_id_UserProductType=int.Parse(ds.Tables[0].Rows[0]["Type_id_UserProductType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["count"].ToString()!="")
				{
					model.count=int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
				}
				model.ImageOriginal=ds.Tables[0].Rows[0]["ImageOriginal"].ToString();
				model.ImageBig=ds.Tables[0].Rows[0]["ImageBig"].ToString();
				model.ImageMedium=ds.Tables[0].Rows[0]["ImageMedium"].ToString();
				model.ImageSmall=ds.Tables[0].Rows[0]["ImageSmall"].ToString();
				model.Product_Number=ds.Tables[0].Rows[0]["Product_Number"].ToString();
				if(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString()!="")
				{
					model.Pro_Type_id=int.Parse(ds.Tables[0].Rows[0]["Pro_Type_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Discount"].ToString()!="")
				{
					model.Discount=int.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pointagain"].ToString()!="")
				{
					model.Pointagain=int.Parse(ds.Tables[0].Rows[0]["Pointagain"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_Point"].ToString()!="")
				{
					model.Product_Point=decimal.Parse(ds.Tables[0].Rows[0]["Product_Point"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_Price"].ToString()!="")
				{
					model.Product_Price=decimal.Parse(ds.Tables[0].Rows[0]["Product_Price"].ToString());
				}
				model.ProPerty134=ds.Tables[0].Rows[0]["ProPerty134"].ToString();
				if(ds.Tables[0].Rows[0]["WarnDays"].ToString()!="")
				{
					model.WarnDays=int.Parse(ds.Tables[0].Rows[0]["WarnDays"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_addemail"].ToString()!="")
				{
					model.Time_addemail=DateTime.Parse(ds.Tables[0].Rows[0]["Time_addemail"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString()!="")
				{
					model.ProPerty_Price=decimal.Parse(ds.Tables[0].Rows[0]["ProPerty_Price"].ToString());
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
		public List<Lebi_User_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_User_Product]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_User_Product> list = new List<Lebi_User_Product>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_User_Product> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_User_Product]";
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
			List<Lebi_User_Product> list = new List<Lebi_User_Product>();
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
		public List<Lebi_User_Product> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_User_Product] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_User_Product> list = new List<Lebi_User_Product>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_User_Product> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_User_Product]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_User_Product> list = new List<Lebi_User_Product>();
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
		public Lebi_User_Product BindForm(Lebi_User_Product model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_UserProductType"] != null)
				model.Type_id_UserProductType=Shop.Tools.RequestTool.RequestInt("Type_id_UserProductType",0);
			if (HttpContext.Current.Request["count"] != null)
				model.count=Shop.Tools.RequestTool.RequestInt("count",0);
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestString("ImageOriginal");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestString("ImageBig");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestString("ImageMedium");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestString("Product_Number");
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestInt("Pro_Type_id",0);
			if (HttpContext.Current.Request["Discount"] != null)
				model.Discount=Shop.Tools.RequestTool.RequestInt("Discount",0);
			if (HttpContext.Current.Request["Pointagain"] != null)
				model.Pointagain=Shop.Tools.RequestTool.RequestInt("Pointagain",0);
			if (HttpContext.Current.Request["Product_Point"] != null)
				model.Product_Point=Shop.Tools.RequestTool.RequestDecimal("Product_Point",0);
			if (HttpContext.Current.Request["Product_Price"] != null)
				model.Product_Price=Shop.Tools.RequestTool.RequestDecimal("Product_Price",0);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestString("ProPerty134");
			if (HttpContext.Current.Request["WarnDays"] != null)
				model.WarnDays=Shop.Tools.RequestTool.RequestInt("WarnDays",0);
			if (HttpContext.Current.Request["Time_addemail"] != null)
				model.Time_addemail=Shop.Tools.RequestTool.RequestTime("Time_addemail", System.DateTime.Now);
			if (HttpContext.Current.Request["ProPerty_Price"] != null)
				model.ProPerty_Price=Shop.Tools.RequestTool.RequestDecimal("ProPerty_Price",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_User_Product SafeBindForm(Lebi_User_Product model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_UserProductType"] != null)
				model.Type_id_UserProductType=Shop.Tools.RequestTool.RequestInt("Type_id_UserProductType",0);
			if (HttpContext.Current.Request["count"] != null)
				model.count=Shop.Tools.RequestTool.RequestInt("count",0);
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestSafeString("ImageOriginal");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestSafeString("ImageBig");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestSafeString("ImageMedium");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestSafeString("Product_Number");
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestInt("Pro_Type_id",0);
			if (HttpContext.Current.Request["Discount"] != null)
				model.Discount=Shop.Tools.RequestTool.RequestInt("Discount",0);
			if (HttpContext.Current.Request["Pointagain"] != null)
				model.Pointagain=Shop.Tools.RequestTool.RequestInt("Pointagain",0);
			if (HttpContext.Current.Request["Product_Point"] != null)
				model.Product_Point=Shop.Tools.RequestTool.RequestDecimal("Product_Point",0);
			if (HttpContext.Current.Request["Product_Price"] != null)
				model.Product_Price=Shop.Tools.RequestTool.RequestDecimal("Product_Price",0);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestSafeString("ProPerty134");
			if (HttpContext.Current.Request["WarnDays"] != null)
				model.WarnDays=Shop.Tools.RequestTool.RequestInt("WarnDays",0);
			if (HttpContext.Current.Request["Time_addemail"] != null)
				model.Time_addemail=Shop.Tools.RequestTool.RequestTime("Time_addemail", System.DateTime.Now);
			if (HttpContext.Current.Request["ProPerty_Price"] != null)
				model.ProPerty_Price=Shop.Tools.RequestTool.RequestDecimal("ProPerty_Price",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_User_Product ReaderBind(IDataReader dataReader)
		{
			Lebi_User_Product model=new Lebi_User_Product();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Type_id_UserProductType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_UserProductType=(int)ojb;
			}
			ojb = dataReader["count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.count=(int)ojb;
			}
			model.ImageOriginal=dataReader["ImageOriginal"].ToString();
			model.ImageBig=dataReader["ImageBig"].ToString();
			model.ImageMedium=dataReader["ImageMedium"].ToString();
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.Product_Number=dataReader["Product_Number"].ToString();
			ojb = dataReader["Pro_Type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pro_Type_id=(int)ojb;
			}
			ojb = dataReader["Discount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Discount=(int)ojb;
			}
			ojb = dataReader["Pointagain"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pointagain=(int)ojb;
			}
			ojb = dataReader["Product_Point"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_Point=(decimal)ojb;
			}
			ojb = dataReader["Product_Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_Price=(decimal)ojb;
			}
			model.ProPerty134=dataReader["ProPerty134"].ToString();
			ojb = dataReader["WarnDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.WarnDays=(int)ojb;
			}
			ojb = dataReader["Time_addemail"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_addemail=(DateTime)ojb;
			}
			ojb = dataReader["ProPerty_Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProPerty_Price=(decimal)ojb;
			}
			return model;
		}

	}
	class access_Lebi_User_Product : Lebi_User_Product_interface
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
				strSql.Append("select " + colName + " from [Lebi_User_Product]");
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
			strSql.Append("select  "+colName+" from [Lebi_User_Product]");
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
			strSql.Append("select count(*) from [Lebi_User_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_User_Product]");
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
			strSql.Append("select max(id) from [Lebi_User_Product]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_User_Product]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_User_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_User_Product](");
			strSql.Append("[User_id],[Product_id],[Time_Add],[Type_id_UserProductType],[count],[ImageOriginal],[ImageBig],[ImageMedium],[ImageSmall],[Product_Number],[Pro_Type_id],[Discount],[Pointagain],[Product_Point],[Product_Price],[ProPerty134],[WarnDays],[Time_addemail],[ProPerty_Price])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Product_id,@Time_Add,@Type_id_UserProductType,@count,@ImageOriginal,@ImageBig,@ImageMedium,@ImageSmall,@Product_Number,@Pro_Type_id,@Discount,@Pointagain,@Product_Point,@Product_Price,@ProPerty134,@WarnDays,@Time_addemail,@ProPerty_Price)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Type_id_UserProductType", model.Type_id_UserProductType),
					new OleDbParameter("@count", model.count),
					new OleDbParameter("@ImageOriginal", model.ImageOriginal),
					new OleDbParameter("@ImageBig", model.ImageBig),
					new OleDbParameter("@ImageMedium", model.ImageMedium),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@Product_Number", model.Product_Number),
					new OleDbParameter("@Pro_Type_id", model.Pro_Type_id),
					new OleDbParameter("@Discount", model.Discount),
					new OleDbParameter("@Pointagain", model.Pointagain),
					new OleDbParameter("@Product_Point", model.Product_Point),
					new OleDbParameter("@Product_Price", model.Product_Price),
					new OleDbParameter("@ProPerty134", model.ProPerty134),
					new OleDbParameter("@WarnDays", model.WarnDays),
					new OleDbParameter("@Time_addemail", model.Time_addemail.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@ProPerty_Price", model.ProPerty_Price)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_User_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_User_Product] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[Product_id]=@Product_id,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Type_id_UserProductType]=@Type_id_UserProductType,");
			strSql.Append("[count]=@count,");
			strSql.Append("[ImageOriginal]=@ImageOriginal,");
			strSql.Append("[ImageBig]=@ImageBig,");
			strSql.Append("[ImageMedium]=@ImageMedium,");
			strSql.Append("[ImageSmall]=@ImageSmall,");
			strSql.Append("[Product_Number]=@Product_Number,");
			strSql.Append("[Pro_Type_id]=@Pro_Type_id,");
			strSql.Append("[Discount]=@Discount,");
			strSql.Append("[Pointagain]=@Pointagain,");
			strSql.Append("[Product_Point]=@Product_Point,");
			strSql.Append("[Product_Price]=@Product_Price,");
			strSql.Append("[ProPerty134]=@ProPerty134,");
			strSql.Append("[WarnDays]=@WarnDays,");
			strSql.Append("[Time_addemail]=@Time_addemail,");
			strSql.Append("[ProPerty_Price]=@ProPerty_Price");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Type_id_UserProductType", model.Type_id_UserProductType),
					new OleDbParameter("@count", model.count),
					new OleDbParameter("@ImageOriginal", model.ImageOriginal),
					new OleDbParameter("@ImageBig", model.ImageBig),
					new OleDbParameter("@ImageMedium", model.ImageMedium),
					new OleDbParameter("@ImageSmall", model.ImageSmall),
					new OleDbParameter("@Product_Number", model.Product_Number),
					new OleDbParameter("@Pro_Type_id", model.Pro_Type_id),
					new OleDbParameter("@Discount", model.Discount),
					new OleDbParameter("@Pointagain", model.Pointagain),
					new OleDbParameter("@Product_Point", model.Product_Point),
					new OleDbParameter("@Product_Price", model.Product_Price),
					new OleDbParameter("@ProPerty134", model.ProPerty134),
					new OleDbParameter("@WarnDays", model.WarnDays),
					new OleDbParameter("@Time_addemail", model.Time_addemail.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@ProPerty_Price", model.ProPerty_Price)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Product] ");
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
			strSql.Append("delete from [Lebi_User_Product] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_User_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_User_Product GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Product] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_User_Product model;
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
		public Lebi_User_Product GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_User_Product] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_User_Product model;
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
		public Lebi_User_Product GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_User_Product] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_User_Product model;
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
		public List<Lebi_User_Product> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_User_Product]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_User_Product> list = new List<Lebi_User_Product>();
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
		public List<Lebi_User_Product> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_User_Product]";
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
			List<Lebi_User_Product> list = new List<Lebi_User_Product>();
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
		public List<Lebi_User_Product> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_User_Product] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_User_Product> list = new List<Lebi_User_Product>();
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
		public List<Lebi_User_Product> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_User_Product]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_User_Product> list = new List<Lebi_User_Product>();
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
		public Lebi_User_Product BindForm(Lebi_User_Product model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_UserProductType"] != null)
				model.Type_id_UserProductType=Shop.Tools.RequestTool.RequestInt("Type_id_UserProductType",0);
			if (HttpContext.Current.Request["count"] != null)
				model.count=Shop.Tools.RequestTool.RequestInt("count",0);
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestString("ImageOriginal");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestString("ImageBig");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestString("ImageMedium");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestString("ImageSmall");
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestString("Product_Number");
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestInt("Pro_Type_id",0);
			if (HttpContext.Current.Request["Discount"] != null)
				model.Discount=Shop.Tools.RequestTool.RequestInt("Discount",0);
			if (HttpContext.Current.Request["Pointagain"] != null)
				model.Pointagain=Shop.Tools.RequestTool.RequestInt("Pointagain",0);
			if (HttpContext.Current.Request["Product_Point"] != null)
				model.Product_Point=Shop.Tools.RequestTool.RequestDecimal("Product_Point",0);
			if (HttpContext.Current.Request["Product_Price"] != null)
				model.Product_Price=Shop.Tools.RequestTool.RequestDecimal("Product_Price",0);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestString("ProPerty134");
			if (HttpContext.Current.Request["WarnDays"] != null)
				model.WarnDays=Shop.Tools.RequestTool.RequestInt("WarnDays",0);
			if (HttpContext.Current.Request["Time_addemail"] != null)
				model.Time_addemail=Shop.Tools.RequestTool.RequestTime("Time_addemail", System.DateTime.Now);
			if (HttpContext.Current.Request["ProPerty_Price"] != null)
				model.ProPerty_Price=Shop.Tools.RequestTool.RequestDecimal("ProPerty_Price",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_User_Product SafeBindForm(Lebi_User_Product model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Type_id_UserProductType"] != null)
				model.Type_id_UserProductType=Shop.Tools.RequestTool.RequestInt("Type_id_UserProductType",0);
			if (HttpContext.Current.Request["count"] != null)
				model.count=Shop.Tools.RequestTool.RequestInt("count",0);
			if (HttpContext.Current.Request["ImageOriginal"] != null)
				model.ImageOriginal=Shop.Tools.RequestTool.RequestSafeString("ImageOriginal");
			if (HttpContext.Current.Request["ImageBig"] != null)
				model.ImageBig=Shop.Tools.RequestTool.RequestSafeString("ImageBig");
			if (HttpContext.Current.Request["ImageMedium"] != null)
				model.ImageMedium=Shop.Tools.RequestTool.RequestSafeString("ImageMedium");
			if (HttpContext.Current.Request["ImageSmall"] != null)
				model.ImageSmall=Shop.Tools.RequestTool.RequestSafeString("ImageSmall");
			if (HttpContext.Current.Request["Product_Number"] != null)
				model.Product_Number=Shop.Tools.RequestTool.RequestSafeString("Product_Number");
			if (HttpContext.Current.Request["Pro_Type_id"] != null)
				model.Pro_Type_id=Shop.Tools.RequestTool.RequestInt("Pro_Type_id",0);
			if (HttpContext.Current.Request["Discount"] != null)
				model.Discount=Shop.Tools.RequestTool.RequestInt("Discount",0);
			if (HttpContext.Current.Request["Pointagain"] != null)
				model.Pointagain=Shop.Tools.RequestTool.RequestInt("Pointagain",0);
			if (HttpContext.Current.Request["Product_Point"] != null)
				model.Product_Point=Shop.Tools.RequestTool.RequestDecimal("Product_Point",0);
			if (HttpContext.Current.Request["Product_Price"] != null)
				model.Product_Price=Shop.Tools.RequestTool.RequestDecimal("Product_Price",0);
			if (HttpContext.Current.Request["ProPerty134"] != null)
				model.ProPerty134=Shop.Tools.RequestTool.RequestSafeString("ProPerty134");
			if (HttpContext.Current.Request["WarnDays"] != null)
				model.WarnDays=Shop.Tools.RequestTool.RequestInt("WarnDays",0);
			if (HttpContext.Current.Request["Time_addemail"] != null)
				model.Time_addemail=Shop.Tools.RequestTool.RequestTime("Time_addemail", System.DateTime.Now);
			if (HttpContext.Current.Request["ProPerty_Price"] != null)
				model.ProPerty_Price=Shop.Tools.RequestTool.RequestDecimal("ProPerty_Price",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_User_Product ReaderBind(IDataReader dataReader)
		{
			Lebi_User_Product model=new Lebi_User_Product();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["User_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.User_id=(int)ojb;
			}
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Type_id_UserProductType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_UserProductType=(int)ojb;
			}
			ojb = dataReader["count"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.count=(int)ojb;
			}
			model.ImageOriginal=dataReader["ImageOriginal"].ToString();
			model.ImageBig=dataReader["ImageBig"].ToString();
			model.ImageMedium=dataReader["ImageMedium"].ToString();
			model.ImageSmall=dataReader["ImageSmall"].ToString();
			model.Product_Number=dataReader["Product_Number"].ToString();
			ojb = dataReader["Pro_Type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pro_Type_id=(int)ojb;
			}
			ojb = dataReader["Discount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Discount=(int)ojb;
			}
			ojb = dataReader["Pointagain"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Pointagain=(int)ojb;
			}
			ojb = dataReader["Product_Point"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_Point=(decimal)ojb;
			}
			ojb = dataReader["Product_Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_Price=(decimal)ojb;
			}
			model.ProPerty134=dataReader["ProPerty134"].ToString();
			ojb = dataReader["WarnDays"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.WarnDays=(int)ojb;
			}
			ojb = dataReader["Time_addemail"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_addemail=(DateTime)ojb;
			}
			ojb = dataReader["ProPerty_Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProPerty_Price=(decimal)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

