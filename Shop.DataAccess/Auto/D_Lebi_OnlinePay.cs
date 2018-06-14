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

	public interface Lebi_OnlinePay_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_OnlinePay model);
		void Update(Lebi_OnlinePay model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_OnlinePay GetModel(int id);
		Lebi_OnlinePay GetModel(string strWhere);
		Lebi_OnlinePay GetModel(SQLPara para);
		List<Lebi_OnlinePay> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_OnlinePay> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_OnlinePay> GetList(string strWhere, string strFieldOrder);
		List<Lebi_OnlinePay> GetList(SQLPara para);
		Lebi_OnlinePay BindForm(Lebi_OnlinePay model);
		Lebi_OnlinePay SafeBindForm(Lebi_OnlinePay model);
		Lebi_OnlinePay ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_OnlinePay。
	/// </summary>
	public class D_Lebi_OnlinePay
	{
		static Lebi_OnlinePay_interface _Instance;
		public static Lebi_OnlinePay_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_OnlinePay();
		            else
		                _Instance = new sqlserver_Lebi_OnlinePay();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_OnlinePay()
		{}
		#region  成员方法
	class sqlserver_Lebi_OnlinePay : Lebi_OnlinePay_interface
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
				strSql.Append("select " + colName + " from [Lebi_OnlinePay]");
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
			strSql.Append("select  "+colName+" from [Lebi_OnlinePay]");
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
			strSql.Append("select count(1) from [Lebi_OnlinePay]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_OnlinePay]");
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
			strSql.Append("select max(id) from [Lebi_OnlinePay]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_OnlinePay]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_OnlinePay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_OnlinePay](");
			strSql.Append("TypeName,UserName,UserKey,Url,ExchangeRate,IsUsed,Description,Language_ids,Email,Logo,Code,Name,Sort,Currency_id,Currency_Code,Currency_Name,showtype,Supplier_id,parentid,FeeRate,terminal,UserRealName,Remark,Appid,Appkey)");
			strSql.Append(" values (");
			strSql.Append("@TypeName,@UserName,@UserKey,@Url,@ExchangeRate,@IsUsed,@Description,@Language_ids,@Email,@Logo,@Code,@Name,@Sort,@Currency_id,@Currency_Code,@Currency_Name,@showtype,@Supplier_id,@parentid,@FeeRate,@terminal,@UserRealName,@Remark,@Appid,@Appkey)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TypeName", model.TypeName),
					new SqlParameter("@UserName", model.UserName),
					new SqlParameter("@UserKey", model.UserKey),
					new SqlParameter("@Url", model.Url),
					new SqlParameter("@ExchangeRate", model.ExchangeRate),
					new SqlParameter("@IsUsed", model.IsUsed),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@Language_ids", model.Language_ids),
					new SqlParameter("@Email", model.Email),
					new SqlParameter("@Logo", model.Logo),
					new SqlParameter("@Code", model.Code),
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Currency_id", model.Currency_id),
					new SqlParameter("@Currency_Code", model.Currency_Code),
					new SqlParameter("@Currency_Name", model.Currency_Name),
					new SqlParameter("@showtype", model.showtype),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@parentid", model.parentid),
					new SqlParameter("@FeeRate", model.FeeRate),
					new SqlParameter("@terminal", model.terminal),
					new SqlParameter("@UserRealName", model.UserRealName),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Appid", model.Appid),
					new SqlParameter("@Appkey", model.Appkey)};

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
		public void Update(Lebi_OnlinePay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_OnlinePay] set ");
			strSql.Append("TypeName= @TypeName,");
			strSql.Append("UserName= @UserName,");
			strSql.Append("UserKey= @UserKey,");
			strSql.Append("Url= @Url,");
			strSql.Append("ExchangeRate= @ExchangeRate,");
			strSql.Append("IsUsed= @IsUsed,");
			strSql.Append("Description= @Description,");
			strSql.Append("Language_ids= @Language_ids,");
			strSql.Append("Email= @Email,");
			strSql.Append("Logo= @Logo,");
			strSql.Append("Code= @Code,");
			strSql.Append("Name= @Name,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Currency_id= @Currency_id,");
			strSql.Append("Currency_Code= @Currency_Code,");
			strSql.Append("Currency_Name= @Currency_Name,");
			strSql.Append("showtype= @showtype,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("parentid= @parentid,");
			strSql.Append("FeeRate= @FeeRate,");
			strSql.Append("terminal= @terminal,");
			strSql.Append("UserRealName= @UserRealName,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Appid= @Appid,");
			strSql.Append("Appkey= @Appkey");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,200),
					new SqlParameter("@UserName", SqlDbType.NVarChar,200),
					new SqlParameter("@UserKey", SqlDbType.NVarChar,200),
					new SqlParameter("@Url", SqlDbType.NVarChar,200),
					new SqlParameter("@ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@IsUsed", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@Language_ids", SqlDbType.NVarChar,200),
					new SqlParameter("@Email", SqlDbType.NVarChar,255),
					new SqlParameter("@Logo", SqlDbType.NVarChar,200),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,500),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Currency_id", SqlDbType.Int,4),
					new SqlParameter("@Currency_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@showtype", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@FeeRate", SqlDbType.Decimal,9),
					new SqlParameter("@terminal", SqlDbType.NVarChar,50),
					new SqlParameter("@UserRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@Appid", SqlDbType.NVarChar,50),
					new SqlParameter("@Appkey", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.TypeName;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.UserKey;
			parameters[4].Value = model.Url;
			parameters[5].Value = model.ExchangeRate;
			parameters[6].Value = model.IsUsed;
			parameters[7].Value = model.Description;
			parameters[8].Value = model.Language_ids;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.Logo;
			parameters[11].Value = model.Code;
			parameters[12].Value = model.Name;
			parameters[13].Value = model.Sort;
			parameters[14].Value = model.Currency_id;
			parameters[15].Value = model.Currency_Code;
			parameters[16].Value = model.Currency_Name;
			parameters[17].Value = model.showtype;
			parameters[18].Value = model.Supplier_id;
			parameters[19].Value = model.parentid;
			parameters[20].Value = model.FeeRate;
			parameters[21].Value = model.terminal;
			parameters[22].Value = model.UserRealName;
			parameters[23].Value = model.Remark;
			parameters[24].Value = model.Appid;
			parameters[25].Value = model.Appkey;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_OnlinePay] ");
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
			strSql.Append("delete from [Lebi_OnlinePay] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_OnlinePay] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_OnlinePay GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_OnlinePay] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_OnlinePay model=new Lebi_OnlinePay();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.TypeName=ds.Tables[0].Rows[0]["TypeName"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.UserKey=ds.Tables[0].Rows[0]["UserKey"].ToString();
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				if(ds.Tables[0].Rows[0]["ExchangeRate"].ToString()!="")
				{
					model.ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["ExchangeRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUsed"].ToString()!="")
				{
					model.IsUsed=int.Parse(ds.Tables[0].Rows[0]["IsUsed"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Logo=ds.Tables[0].Rows[0]["Logo"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Currency_Code=ds.Tables[0].Rows[0]["Currency_Code"].ToString();
				model.Currency_Name=ds.Tables[0].Rows[0]["Currency_Name"].ToString();
				model.showtype=ds.Tables[0].Rows[0]["showtype"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FeeRate"].ToString()!="")
				{
					model.FeeRate=decimal.Parse(ds.Tables[0].Rows[0]["FeeRate"].ToString());
				}
				model.terminal=ds.Tables[0].Rows[0]["terminal"].ToString();
				model.UserRealName=ds.Tables[0].Rows[0]["UserRealName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				model.Appid=ds.Tables[0].Rows[0]["Appid"].ToString();
				model.Appkey=ds.Tables[0].Rows[0]["Appkey"].ToString();
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
		public Lebi_OnlinePay GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_OnlinePay] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_OnlinePay model=new Lebi_OnlinePay();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.TypeName=ds.Tables[0].Rows[0]["TypeName"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.UserKey=ds.Tables[0].Rows[0]["UserKey"].ToString();
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				if(ds.Tables[0].Rows[0]["ExchangeRate"].ToString()!="")
				{
					model.ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["ExchangeRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUsed"].ToString()!="")
				{
					model.IsUsed=int.Parse(ds.Tables[0].Rows[0]["IsUsed"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Logo=ds.Tables[0].Rows[0]["Logo"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Currency_Code=ds.Tables[0].Rows[0]["Currency_Code"].ToString();
				model.Currency_Name=ds.Tables[0].Rows[0]["Currency_Name"].ToString();
				model.showtype=ds.Tables[0].Rows[0]["showtype"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FeeRate"].ToString()!="")
				{
					model.FeeRate=decimal.Parse(ds.Tables[0].Rows[0]["FeeRate"].ToString());
				}
				model.terminal=ds.Tables[0].Rows[0]["terminal"].ToString();
				model.UserRealName=ds.Tables[0].Rows[0]["UserRealName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				model.Appid=ds.Tables[0].Rows[0]["Appid"].ToString();
				model.Appkey=ds.Tables[0].Rows[0]["Appkey"].ToString();
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
		public Lebi_OnlinePay GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_OnlinePay] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_OnlinePay model=new Lebi_OnlinePay();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.TypeName=ds.Tables[0].Rows[0]["TypeName"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.UserKey=ds.Tables[0].Rows[0]["UserKey"].ToString();
				model.Url=ds.Tables[0].Rows[0]["Url"].ToString();
				if(ds.Tables[0].Rows[0]["ExchangeRate"].ToString()!="")
				{
					model.ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["ExchangeRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUsed"].ToString()!="")
				{
					model.IsUsed=int.Parse(ds.Tables[0].Rows[0]["IsUsed"].ToString());
				}
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Language_ids=ds.Tables[0].Rows[0]["Language_ids"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Logo=ds.Tables[0].Rows[0]["Logo"].ToString();
				model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Currency_id"].ToString()!="")
				{
					model.Currency_id=int.Parse(ds.Tables[0].Rows[0]["Currency_id"].ToString());
				}
				model.Currency_Code=ds.Tables[0].Rows[0]["Currency_Code"].ToString();
				model.Currency_Name=ds.Tables[0].Rows[0]["Currency_Name"].ToString();
				model.showtype=ds.Tables[0].Rows[0]["showtype"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parentid"].ToString()!="")
				{
					model.parentid=int.Parse(ds.Tables[0].Rows[0]["parentid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FeeRate"].ToString()!="")
				{
					model.FeeRate=decimal.Parse(ds.Tables[0].Rows[0]["FeeRate"].ToString());
				}
				model.terminal=ds.Tables[0].Rows[0]["terminal"].ToString();
				model.UserRealName=ds.Tables[0].Rows[0]["UserRealName"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				model.Appid=ds.Tables[0].Rows[0]["Appid"].ToString();
				model.Appkey=ds.Tables[0].Rows[0]["Appkey"].ToString();
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
		public List<Lebi_OnlinePay> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_OnlinePay]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_OnlinePay> list = new List<Lebi_OnlinePay>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_OnlinePay> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_OnlinePay]";
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
			List<Lebi_OnlinePay> list = new List<Lebi_OnlinePay>();
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
		public List<Lebi_OnlinePay> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_OnlinePay] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_OnlinePay> list = new List<Lebi_OnlinePay>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_OnlinePay> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_OnlinePay]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_OnlinePay> list = new List<Lebi_OnlinePay>();
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
		public Lebi_OnlinePay BindForm(Lebi_OnlinePay model)
		{
			if (HttpContext.Current.Request["TypeName"] != null)
				model.TypeName=Shop.Tools.RequestTool.RequestString("TypeName");
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["UserKey"] != null)
				model.UserKey=Shop.Tools.RequestTool.RequestString("UserKey");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestString("Url");
			if (HttpContext.Current.Request["ExchangeRate"] != null)
				model.ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("ExchangeRate",0);
			if (HttpContext.Current.Request["IsUsed"] != null)
				model.IsUsed=Shop.Tools.RequestTool.RequestInt("IsUsed",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestString("Logo");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestString("Currency_Code");
			if (HttpContext.Current.Request["Currency_Name"] != null)
				model.Currency_Name=Shop.Tools.RequestTool.RequestString("Currency_Name");
			if (HttpContext.Current.Request["showtype"] != null)
				model.showtype=Shop.Tools.RequestTool.RequestString("showtype");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["FeeRate"] != null)
				model.FeeRate=Shop.Tools.RequestTool.RequestDecimal("FeeRate",0);
			if (HttpContext.Current.Request["terminal"] != null)
				model.terminal=Shop.Tools.RequestTool.RequestString("terminal");
			if (HttpContext.Current.Request["UserRealName"] != null)
				model.UserRealName=Shop.Tools.RequestTool.RequestString("UserRealName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Appid"] != null)
				model.Appid=Shop.Tools.RequestTool.RequestString("Appid");
			if (HttpContext.Current.Request["Appkey"] != null)
				model.Appkey=Shop.Tools.RequestTool.RequestString("Appkey");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_OnlinePay SafeBindForm(Lebi_OnlinePay model)
		{
			if (HttpContext.Current.Request["TypeName"] != null)
				model.TypeName=Shop.Tools.RequestTool.RequestSafeString("TypeName");
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["UserKey"] != null)
				model.UserKey=Shop.Tools.RequestTool.RequestSafeString("UserKey");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestSafeString("Url");
			if (HttpContext.Current.Request["ExchangeRate"] != null)
				model.ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("ExchangeRate",0);
			if (HttpContext.Current.Request["IsUsed"] != null)
				model.IsUsed=Shop.Tools.RequestTool.RequestInt("IsUsed",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestSafeString("Logo");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestSafeString("Currency_Code");
			if (HttpContext.Current.Request["Currency_Name"] != null)
				model.Currency_Name=Shop.Tools.RequestTool.RequestSafeString("Currency_Name");
			if (HttpContext.Current.Request["showtype"] != null)
				model.showtype=Shop.Tools.RequestTool.RequestSafeString("showtype");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["FeeRate"] != null)
				model.FeeRate=Shop.Tools.RequestTool.RequestDecimal("FeeRate",0);
			if (HttpContext.Current.Request["terminal"] != null)
				model.terminal=Shop.Tools.RequestTool.RequestSafeString("terminal");
			if (HttpContext.Current.Request["UserRealName"] != null)
				model.UserRealName=Shop.Tools.RequestTool.RequestSafeString("UserRealName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Appid"] != null)
				model.Appid=Shop.Tools.RequestTool.RequestSafeString("Appid");
			if (HttpContext.Current.Request["Appkey"] != null)
				model.Appkey=Shop.Tools.RequestTool.RequestSafeString("Appkey");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_OnlinePay ReaderBind(IDataReader dataReader)
		{
			Lebi_OnlinePay model=new Lebi_OnlinePay();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.TypeName=dataReader["TypeName"].ToString();
			model.UserName=dataReader["UserName"].ToString();
			model.UserKey=dataReader["UserKey"].ToString();
			model.Url=dataReader["Url"].ToString();
			ojb = dataReader["ExchangeRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ExchangeRate=(decimal)ojb;
			}
			ojb = dataReader["IsUsed"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUsed=(int)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			model.Language_ids=dataReader["Language_ids"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.Logo=dataReader["Logo"].ToString();
			model.Code=dataReader["Code"].ToString();
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Currency_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_id=(int)ojb;
			}
			model.Currency_Code=dataReader["Currency_Code"].ToString();
			model.Currency_Name=dataReader["Currency_Name"].ToString();
			model.showtype=dataReader["showtype"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentid=(int)ojb;
			}
			ojb = dataReader["FeeRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FeeRate=(decimal)ojb;
			}
			model.terminal=dataReader["terminal"].ToString();
			model.UserRealName=dataReader["UserRealName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			model.Appid=dataReader["Appid"].ToString();
			model.Appkey=dataReader["Appkey"].ToString();
			return model;
		}

	}
	class access_Lebi_OnlinePay : Lebi_OnlinePay_interface
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
				strSql.Append("select " + colName + " from [Lebi_OnlinePay]");
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
			strSql.Append("select  "+colName+" from [Lebi_OnlinePay]");
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
			strSql.Append("select count(*) from [Lebi_OnlinePay]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_OnlinePay]");
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
			strSql.Append("select max(id) from [Lebi_OnlinePay]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_OnlinePay]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_OnlinePay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_OnlinePay](");
			strSql.Append("[TypeName],[UserName],[UserKey],[Url],[ExchangeRate],[IsUsed],[Description],[Language_ids],[Email],[Logo],[Code],[Name],[Sort],[Currency_id],[Currency_Code],[Currency_Name],[showtype],[Supplier_id],[parentid],[FeeRate],[terminal],[UserRealName],[Remark],[Appid],[Appkey])");
			strSql.Append(" values (");
			strSql.Append("@TypeName,@UserName,@UserKey,@Url,@ExchangeRate,@IsUsed,@Description,@Language_ids,@Email,@Logo,@Code,@Name,@Sort,@Currency_id,@Currency_Code,@Currency_Name,@showtype,@Supplier_id,@parentid,@FeeRate,@terminal,@UserRealName,@Remark,@Appid,@Appkey)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@TypeName", model.TypeName),
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@UserKey", model.UserKey),
					new OleDbParameter("@Url", model.Url),
					new OleDbParameter("@ExchangeRate", model.ExchangeRate),
					new OleDbParameter("@IsUsed", model.IsUsed),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Language_ids", model.Language_ids),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@Logo", model.Logo),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Currency_id", model.Currency_id),
					new OleDbParameter("@Currency_Code", model.Currency_Code),
					new OleDbParameter("@Currency_Name", model.Currency_Name),
					new OleDbParameter("@showtype", model.showtype),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@parentid", model.parentid),
					new OleDbParameter("@FeeRate", model.FeeRate),
					new OleDbParameter("@terminal", model.terminal),
					new OleDbParameter("@UserRealName", model.UserRealName),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Appid", model.Appid),
					new OleDbParameter("@Appkey", model.Appkey)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_OnlinePay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_OnlinePay] set ");
			strSql.Append("[TypeName]=@TypeName,");
			strSql.Append("[UserName]=@UserName,");
			strSql.Append("[UserKey]=@UserKey,");
			strSql.Append("[Url]=@Url,");
			strSql.Append("[ExchangeRate]=@ExchangeRate,");
			strSql.Append("[IsUsed]=@IsUsed,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[Language_ids]=@Language_ids,");
			strSql.Append("[Email]=@Email,");
			strSql.Append("[Logo]=@Logo,");
			strSql.Append("[Code]=@Code,");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Currency_id]=@Currency_id,");
			strSql.Append("[Currency_Code]=@Currency_Code,");
			strSql.Append("[Currency_Name]=@Currency_Name,");
			strSql.Append("[showtype]=@showtype,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[parentid]=@parentid,");
			strSql.Append("[FeeRate]=@FeeRate,");
			strSql.Append("[terminal]=@terminal,");
			strSql.Append("[UserRealName]=@UserRealName,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Appid]=@Appid,");
			strSql.Append("[Appkey]=@Appkey");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@TypeName", model.TypeName),
					new OleDbParameter("@UserName", model.UserName),
					new OleDbParameter("@UserKey", model.UserKey),
					new OleDbParameter("@Url", model.Url),
					new OleDbParameter("@ExchangeRate", model.ExchangeRate),
					new OleDbParameter("@IsUsed", model.IsUsed),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Language_ids", model.Language_ids),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@Logo", model.Logo),
					new OleDbParameter("@Code", model.Code),
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Currency_id", model.Currency_id),
					new OleDbParameter("@Currency_Code", model.Currency_Code),
					new OleDbParameter("@Currency_Name", model.Currency_Name),
					new OleDbParameter("@showtype", model.showtype),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@parentid", model.parentid),
					new OleDbParameter("@FeeRate", model.FeeRate),
					new OleDbParameter("@terminal", model.terminal),
					new OleDbParameter("@UserRealName", model.UserRealName),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Appid", model.Appid),
					new OleDbParameter("@Appkey", model.Appkey)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_OnlinePay] ");
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
			strSql.Append("delete from [Lebi_OnlinePay] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_OnlinePay] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_OnlinePay GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_OnlinePay] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_OnlinePay model;
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
		public Lebi_OnlinePay GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_OnlinePay] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_OnlinePay model;
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
		public Lebi_OnlinePay GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_OnlinePay] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_OnlinePay model;
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
		public List<Lebi_OnlinePay> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_OnlinePay]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_OnlinePay> list = new List<Lebi_OnlinePay>();
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
		public List<Lebi_OnlinePay> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_OnlinePay]";
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
			List<Lebi_OnlinePay> list = new List<Lebi_OnlinePay>();
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
		public List<Lebi_OnlinePay> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_OnlinePay] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_OnlinePay> list = new List<Lebi_OnlinePay>();
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
		public List<Lebi_OnlinePay> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_OnlinePay]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_OnlinePay> list = new List<Lebi_OnlinePay>();
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
		public Lebi_OnlinePay BindForm(Lebi_OnlinePay model)
		{
			if (HttpContext.Current.Request["TypeName"] != null)
				model.TypeName=Shop.Tools.RequestTool.RequestString("TypeName");
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestString("UserName");
			if (HttpContext.Current.Request["UserKey"] != null)
				model.UserKey=Shop.Tools.RequestTool.RequestString("UserKey");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestString("Url");
			if (HttpContext.Current.Request["ExchangeRate"] != null)
				model.ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("ExchangeRate",0);
			if (HttpContext.Current.Request["IsUsed"] != null)
				model.IsUsed=Shop.Tools.RequestTool.RequestInt("IsUsed",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestString("Language_ids");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestString("Logo");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestString("Code");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestString("Currency_Code");
			if (HttpContext.Current.Request["Currency_Name"] != null)
				model.Currency_Name=Shop.Tools.RequestTool.RequestString("Currency_Name");
			if (HttpContext.Current.Request["showtype"] != null)
				model.showtype=Shop.Tools.RequestTool.RequestString("showtype");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["FeeRate"] != null)
				model.FeeRate=Shop.Tools.RequestTool.RequestDecimal("FeeRate",0);
			if (HttpContext.Current.Request["terminal"] != null)
				model.terminal=Shop.Tools.RequestTool.RequestString("terminal");
			if (HttpContext.Current.Request["UserRealName"] != null)
				model.UserRealName=Shop.Tools.RequestTool.RequestString("UserRealName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestString("Remark");
			if (HttpContext.Current.Request["Appid"] != null)
				model.Appid=Shop.Tools.RequestTool.RequestString("Appid");
			if (HttpContext.Current.Request["Appkey"] != null)
				model.Appkey=Shop.Tools.RequestTool.RequestString("Appkey");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_OnlinePay SafeBindForm(Lebi_OnlinePay model)
		{
			if (HttpContext.Current.Request["TypeName"] != null)
				model.TypeName=Shop.Tools.RequestTool.RequestSafeString("TypeName");
			if (HttpContext.Current.Request["UserName"] != null)
				model.UserName=Shop.Tools.RequestTool.RequestSafeString("UserName");
			if (HttpContext.Current.Request["UserKey"] != null)
				model.UserKey=Shop.Tools.RequestTool.RequestSafeString("UserKey");
			if (HttpContext.Current.Request["Url"] != null)
				model.Url=Shop.Tools.RequestTool.RequestSafeString("Url");
			if (HttpContext.Current.Request["ExchangeRate"] != null)
				model.ExchangeRate=Shop.Tools.RequestTool.RequestDecimal("ExchangeRate",0);
			if (HttpContext.Current.Request["IsUsed"] != null)
				model.IsUsed=Shop.Tools.RequestTool.RequestInt("IsUsed",0);
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Language_ids"] != null)
				model.Language_ids=Shop.Tools.RequestTool.RequestSafeString("Language_ids");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["Logo"] != null)
				model.Logo=Shop.Tools.RequestTool.RequestSafeString("Logo");
			if (HttpContext.Current.Request["Code"] != null)
				model.Code=Shop.Tools.RequestTool.RequestSafeString("Code");
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Currency_id"] != null)
				model.Currency_id=Shop.Tools.RequestTool.RequestInt("Currency_id",0);
			if (HttpContext.Current.Request["Currency_Code"] != null)
				model.Currency_Code=Shop.Tools.RequestTool.RequestSafeString("Currency_Code");
			if (HttpContext.Current.Request["Currency_Name"] != null)
				model.Currency_Name=Shop.Tools.RequestTool.RequestSafeString("Currency_Name");
			if (HttpContext.Current.Request["showtype"] != null)
				model.showtype=Shop.Tools.RequestTool.RequestSafeString("showtype");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["parentid"] != null)
				model.parentid=Shop.Tools.RequestTool.RequestInt("parentid",0);
			if (HttpContext.Current.Request["FeeRate"] != null)
				model.FeeRate=Shop.Tools.RequestTool.RequestDecimal("FeeRate",0);
			if (HttpContext.Current.Request["terminal"] != null)
				model.terminal=Shop.Tools.RequestTool.RequestSafeString("terminal");
			if (HttpContext.Current.Request["UserRealName"] != null)
				model.UserRealName=Shop.Tools.RequestTool.RequestSafeString("UserRealName");
			if (HttpContext.Current.Request["Remark"] != null)
				model.Remark=Shop.Tools.RequestTool.RequestSafeString("Remark");
			if (HttpContext.Current.Request["Appid"] != null)
				model.Appid=Shop.Tools.RequestTool.RequestSafeString("Appid");
			if (HttpContext.Current.Request["Appkey"] != null)
				model.Appkey=Shop.Tools.RequestTool.RequestSafeString("Appkey");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_OnlinePay ReaderBind(IDataReader dataReader)
		{
			Lebi_OnlinePay model=new Lebi_OnlinePay();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.TypeName=dataReader["TypeName"].ToString();
			model.UserName=dataReader["UserName"].ToString();
			model.UserKey=dataReader["UserKey"].ToString();
			model.Url=dataReader["Url"].ToString();
			ojb = dataReader["ExchangeRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ExchangeRate=(decimal)ojb;
			}
			ojb = dataReader["IsUsed"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUsed=(int)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			model.Language_ids=dataReader["Language_ids"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.Logo=dataReader["Logo"].ToString();
			model.Code=dataReader["Code"].ToString();
			model.Name=dataReader["Name"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Currency_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Currency_id=(int)ojb;
			}
			model.Currency_Code=dataReader["Currency_Code"].ToString();
			model.Currency_Name=dataReader["Currency_Name"].ToString();
			model.showtype=dataReader["showtype"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			ojb = dataReader["parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.parentid=(int)ojb;
			}
			ojb = dataReader["FeeRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FeeRate=(decimal)ojb;
			}
			model.terminal=dataReader["terminal"].ToString();
			model.UserRealName=dataReader["UserRealName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			model.Appid=dataReader["Appid"].ToString();
			model.Appkey=dataReader["Appkey"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

