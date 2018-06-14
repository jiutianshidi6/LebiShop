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

	public interface Lebi_Comment_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Comment model);
		void Update(Lebi_Comment model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Comment GetModel(int id);
		Lebi_Comment GetModel(string strWhere);
		Lebi_Comment GetModel(SQLPara para);
		List<Lebi_Comment> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Comment> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Comment> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Comment> GetList(SQLPara para);
		Lebi_Comment BindForm(Lebi_Comment model);
		Lebi_Comment SafeBindForm(Lebi_Comment model);
		Lebi_Comment ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Comment。
	/// </summary>
	public class D_Lebi_Comment
	{
		static Lebi_Comment_interface _Instance;
		public static Lebi_Comment_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Comment();
		            else
		                _Instance = new sqlserver_Lebi_Comment();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Comment()
		{}
		#region  成员方法
	class sqlserver_Lebi_Comment : Lebi_Comment_interface
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
				strSql.Append("select " + colName + " from [Lebi_Comment]");
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
			strSql.Append("select  "+colName+" from [Lebi_Comment]");
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
			strSql.Append("select count(1) from [Lebi_Comment]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Comment]");
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
			strSql.Append("select max(id) from [Lebi_Comment]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Comment]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Comment](");
			strSql.Append("User_id,Admin_id,TableName,Keyid,Content,Time_Add,Star,Status,User_UserName,Admin_UserName,Language_Code,Parentid,ImagesSmall,Images,Supplier_id,Supplier_SubName,Product_id,IsRead)");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Admin_id,@TableName,@Keyid,@Content,@Time_Add,@Star,@Status,@User_UserName,@Admin_UserName,@Language_Code,@Parentid,@ImagesSmall,@Images,@Supplier_id,@Supplier_SubName,@Product_id,@IsRead)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@User_id", model.User_id),
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@TableName", model.TableName),
					new SqlParameter("@Keyid", model.Keyid),
					new SqlParameter("@Content", model.Content),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Star", model.Star),
					new SqlParameter("@Status", model.Status),
					new SqlParameter("@User_UserName", model.User_UserName),
					new SqlParameter("@Admin_UserName", model.Admin_UserName),
					new SqlParameter("@Language_Code", model.Language_Code),
					new SqlParameter("@Parentid", model.Parentid),
					new SqlParameter("@ImagesSmall", model.ImagesSmall),
					new SqlParameter("@Images", model.Images),
					new SqlParameter("@Supplier_id", model.Supplier_id),
					new SqlParameter("@Supplier_SubName", model.Supplier_SubName),
					new SqlParameter("@Product_id", model.Product_id),
					new SqlParameter("@IsRead", model.IsRead)};

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
		public void Update(Lebi_Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Comment] set ");
			strSql.Append("User_id= @User_id,");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("TableName= @TableName,");
			strSql.Append("Keyid= @Keyid,");
			strSql.Append("Content= @Content,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Star= @Star,");
			strSql.Append("Status= @Status,");
			strSql.Append("User_UserName= @User_UserName,");
			strSql.Append("Admin_UserName= @Admin_UserName,");
			strSql.Append("Language_Code= @Language_Code,");
			strSql.Append("Parentid= @Parentid,");
			strSql.Append("ImagesSmall= @ImagesSmall,");
			strSql.Append("Images= @Images,");
			strSql.Append("Supplier_id= @Supplier_id,");
			strSql.Append("Supplier_SubName= @Supplier_SubName,");
			strSql.Append("Product_id= @Product_id,");
			strSql.Append("IsRead= @IsRead");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@User_id", SqlDbType.Int,4),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@Keyid", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,4000),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Star", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@User_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Admin_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Language_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Parentid", SqlDbType.Int,4),
					new SqlParameter("@ImagesSmall", SqlDbType.NVarChar,1000),
					new SqlParameter("@Images", SqlDbType.NVarChar,1000),
					new SqlParameter("@Supplier_id", SqlDbType.Int,4),
					new SqlParameter("@Supplier_SubName", SqlDbType.NVarChar,100),
					new SqlParameter("@Product_id", SqlDbType.Int,4),
					new SqlParameter("@IsRead", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.User_id;
			parameters[2].Value = model.Admin_id;
			parameters[3].Value = model.TableName;
			parameters[4].Value = model.Keyid;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.Time_Add;
			parameters[7].Value = model.Star;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.User_UserName;
			parameters[10].Value = model.Admin_UserName;
			parameters[11].Value = model.Language_Code;
			parameters[12].Value = model.Parentid;
			parameters[13].Value = model.ImagesSmall;
			parameters[14].Value = model.Images;
			parameters[15].Value = model.Supplier_id;
			parameters[16].Value = model.Supplier_SubName;
			parameters[17].Value = model.Product_id;
			parameters[18].Value = model.IsRead;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Comment] ");
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
			strSql.Append("delete from [Lebi_Comment] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Comment] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Comment GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Comment] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Comment model=new Lebi_Comment();
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
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.TableName=ds.Tables[0].Rows[0]["TableName"].ToString();
				if(ds.Tables[0].Rows[0]["Keyid"].ToString()!="")
				{
					model.Keyid=int.Parse(ds.Tables[0].Rows[0]["Keyid"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Star"].ToString()!="")
				{
					model.Star=int.Parse(ds.Tables[0].Rows[0]["Star"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Language_Code=ds.Tables[0].Rows[0]["Language_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				model.ImagesSmall=ds.Tables[0].Rows[0]["ImagesSmall"].ToString();
				model.Images=ds.Tables[0].Rows[0]["Images"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
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
		public Lebi_Comment GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Comment] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Comment model=new Lebi_Comment();
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
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.TableName=ds.Tables[0].Rows[0]["TableName"].ToString();
				if(ds.Tables[0].Rows[0]["Keyid"].ToString()!="")
				{
					model.Keyid=int.Parse(ds.Tables[0].Rows[0]["Keyid"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Star"].ToString()!="")
				{
					model.Star=int.Parse(ds.Tables[0].Rows[0]["Star"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Language_Code=ds.Tables[0].Rows[0]["Language_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				model.ImagesSmall=ds.Tables[0].Rows[0]["ImagesSmall"].ToString();
				model.Images=ds.Tables[0].Rows[0]["Images"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
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
		public Lebi_Comment GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Comment] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Comment model=new Lebi_Comment();
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
				if(ds.Tables[0].Rows[0]["Admin_id"].ToString()!="")
				{
					model.Admin_id=int.Parse(ds.Tables[0].Rows[0]["Admin_id"].ToString());
				}
				model.TableName=ds.Tables[0].Rows[0]["TableName"].ToString();
				if(ds.Tables[0].Rows[0]["Keyid"].ToString()!="")
				{
					model.Keyid=int.Parse(ds.Tables[0].Rows[0]["Keyid"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Add"].ToString()!="")
				{
					model.Time_Add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Star"].ToString()!="")
				{
					model.Star=int.Parse(ds.Tables[0].Rows[0]["Star"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				model.User_UserName=ds.Tables[0].Rows[0]["User_UserName"].ToString();
				model.Admin_UserName=ds.Tables[0].Rows[0]["Admin_UserName"].ToString();
				model.Language_Code=ds.Tables[0].Rows[0]["Language_Code"].ToString();
				if(ds.Tables[0].Rows[0]["Parentid"].ToString()!="")
				{
					model.Parentid=int.Parse(ds.Tables[0].Rows[0]["Parentid"].ToString());
				}
				model.ImagesSmall=ds.Tables[0].Rows[0]["ImagesSmall"].ToString();
				model.Images=ds.Tables[0].Rows[0]["Images"].ToString();
				if(ds.Tables[0].Rows[0]["Supplier_id"].ToString()!="")
				{
					model.Supplier_id=int.Parse(ds.Tables[0].Rows[0]["Supplier_id"].ToString());
				}
				model.Supplier_SubName=ds.Tables[0].Rows[0]["Supplier_SubName"].ToString();
				if(ds.Tables[0].Rows[0]["Product_id"].ToString()!="")
				{
					model.Product_id=int.Parse(ds.Tables[0].Rows[0]["Product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
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
		public List<Lebi_Comment> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Comment]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Comment> list = new List<Lebi_Comment>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Comment> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Comment]";
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
			List<Lebi_Comment> list = new List<Lebi_Comment>();
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
		public List<Lebi_Comment> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Comment] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Comment> list = new List<Lebi_Comment>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Comment> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Comment]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Comment> list = new List<Lebi_Comment>();
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
		public Lebi_Comment BindForm(Lebi_Comment model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestInt("Keyid",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Star"] != null)
				model.Star=Shop.Tools.RequestTool.RequestInt("Star",0);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Language_Code"] != null)
				model.Language_Code=Shop.Tools.RequestTool.RequestString("Language_Code");
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["ImagesSmall"] != null)
				model.ImagesSmall=Shop.Tools.RequestTool.RequestString("ImagesSmall");
			if (HttpContext.Current.Request["Images"] != null)
				model.Images=Shop.Tools.RequestTool.RequestString("Images");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestString("Supplier_SubName");
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["IsRead"] != null)
				model.IsRead=Shop.Tools.RequestTool.RequestInt("IsRead",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Comment SafeBindForm(Lebi_Comment model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestSafeString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestInt("Keyid",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Star"] != null)
				model.Star=Shop.Tools.RequestTool.RequestInt("Star",0);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Language_Code"] != null)
				model.Language_Code=Shop.Tools.RequestTool.RequestSafeString("Language_Code");
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["ImagesSmall"] != null)
				model.ImagesSmall=Shop.Tools.RequestTool.RequestSafeString("ImagesSmall");
			if (HttpContext.Current.Request["Images"] != null)
				model.Images=Shop.Tools.RequestTool.RequestSafeString("Images");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestSafeString("Supplier_SubName");
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["IsRead"] != null)
				model.IsRead=Shop.Tools.RequestTool.RequestInt("IsRead",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Comment ReaderBind(IDataReader dataReader)
		{
			Lebi_Comment model=new Lebi_Comment();
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
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.TableName=dataReader["TableName"].ToString();
			ojb = dataReader["Keyid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Keyid=(int)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Star"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Star=(int)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.Language_Code=dataReader["Language_Code"].ToString();
			ojb = dataReader["Parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Parentid=(int)ojb;
			}
			model.ImagesSmall=dataReader["ImagesSmall"].ToString();
			model.Images=dataReader["Images"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			model.Supplier_SubName=dataReader["Supplier_SubName"].ToString();
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["IsRead"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRead=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Comment : Lebi_Comment_interface
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
				strSql.Append("select " + colName + " from [Lebi_Comment]");
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
			strSql.Append("select  "+colName+" from [Lebi_Comment]");
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
			strSql.Append("select count(*) from [Lebi_Comment]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Comment]");
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
			strSql.Append("select max(id) from [Lebi_Comment]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Comment]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Comment](");
			strSql.Append("[User_id],[Admin_id],[TableName],[Keyid],[Content],[Time_Add],[Star],[Status],[User_UserName],[Admin_UserName],[Language_Code],[Parentid],[ImagesSmall],[Images],[Supplier_id],[Supplier_SubName],[Product_id],[IsRead])");
			strSql.Append(" values (");
			strSql.Append("@User_id,@Admin_id,@TableName,@Keyid,@Content,@Time_Add,@Star,@Status,@User_UserName,@Admin_UserName,@Language_Code,@Parentid,@ImagesSmall,@Images,@Supplier_id,@Supplier_SubName,@Product_id,@IsRead)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@TableName", model.TableName),
					new OleDbParameter("@Keyid", model.Keyid),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Star", model.Star),
					new OleDbParameter("@Status", model.Status),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Language_Code", model.Language_Code),
					new OleDbParameter("@Parentid", model.Parentid),
					new OleDbParameter("@ImagesSmall", model.ImagesSmall),
					new OleDbParameter("@Images", model.Images),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Supplier_SubName", model.Supplier_SubName),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@IsRead", model.IsRead)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Comment] set ");
			strSql.Append("[User_id]=@User_id,");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[TableName]=@TableName,");
			strSql.Append("[Keyid]=@Keyid,");
			strSql.Append("[Content]=@Content,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Star]=@Star,");
			strSql.Append("[Status]=@Status,");
			strSql.Append("[User_UserName]=@User_UserName,");
			strSql.Append("[Admin_UserName]=@Admin_UserName,");
			strSql.Append("[Language_Code]=@Language_Code,");
			strSql.Append("[Parentid]=@Parentid,");
			strSql.Append("[ImagesSmall]=@ImagesSmall,");
			strSql.Append("[Images]=@Images,");
			strSql.Append("[Supplier_id]=@Supplier_id,");
			strSql.Append("[Supplier_SubName]=@Supplier_SubName,");
			strSql.Append("[Product_id]=@Product_id,");
			strSql.Append("[IsRead]=@IsRead");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@User_id", model.User_id),
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@TableName", model.TableName),
					new OleDbParameter("@Keyid", model.Keyid),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Star", model.Star),
					new OleDbParameter("@Status", model.Status),
					new OleDbParameter("@User_UserName", model.User_UserName),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Language_Code", model.Language_Code),
					new OleDbParameter("@Parentid", model.Parentid),
					new OleDbParameter("@ImagesSmall", model.ImagesSmall),
					new OleDbParameter("@Images", model.Images),
					new OleDbParameter("@Supplier_id", model.Supplier_id),
					new OleDbParameter("@Supplier_SubName", model.Supplier_SubName),
					new OleDbParameter("@Product_id", model.Product_id),
					new OleDbParameter("@IsRead", model.IsRead)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Comment] ");
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
			strSql.Append("delete from [Lebi_Comment] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Comment] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Comment GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Comment] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Comment model;
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
		public Lebi_Comment GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Comment] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Comment model;
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
		public Lebi_Comment GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Comment] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Comment model;
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
		public List<Lebi_Comment> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Comment]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Comment> list = new List<Lebi_Comment>();
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
		public List<Lebi_Comment> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Comment]";
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
			List<Lebi_Comment> list = new List<Lebi_Comment>();
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
		public List<Lebi_Comment> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Comment] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Comment> list = new List<Lebi_Comment>();
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
		public List<Lebi_Comment> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Comment]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Comment> list = new List<Lebi_Comment>();
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
		public Lebi_Comment BindForm(Lebi_Comment model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestInt("Keyid",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Star"] != null)
				model.Star=Shop.Tools.RequestTool.RequestInt("Star",0);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestString("User_UserName");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestString("Admin_UserName");
			if (HttpContext.Current.Request["Language_Code"] != null)
				model.Language_Code=Shop.Tools.RequestTool.RequestString("Language_Code");
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["ImagesSmall"] != null)
				model.ImagesSmall=Shop.Tools.RequestTool.RequestString("ImagesSmall");
			if (HttpContext.Current.Request["Images"] != null)
				model.Images=Shop.Tools.RequestTool.RequestString("Images");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestString("Supplier_SubName");
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["IsRead"] != null)
				model.IsRead=Shop.Tools.RequestTool.RequestInt("IsRead",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Comment SafeBindForm(Lebi_Comment model)
		{
			if (HttpContext.Current.Request["User_id"] != null)
				model.User_id=Shop.Tools.RequestTool.RequestInt("User_id",0);
			if (HttpContext.Current.Request["Admin_id"] != null)
				model.Admin_id=Shop.Tools.RequestTool.RequestInt("Admin_id",0);
			if (HttpContext.Current.Request["TableName"] != null)
				model.TableName=Shop.Tools.RequestTool.RequestSafeString("TableName");
			if (HttpContext.Current.Request["Keyid"] != null)
				model.Keyid=Shop.Tools.RequestTool.RequestInt("Keyid",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Time_Add"] != null)
				model.Time_Add=Shop.Tools.RequestTool.RequestTime("Time_Add", System.DateTime.Now);
			if (HttpContext.Current.Request["Star"] != null)
				model.Star=Shop.Tools.RequestTool.RequestInt("Star",0);
			if (HttpContext.Current.Request["Status"] != null)
				model.Status=Shop.Tools.RequestTool.RequestInt("Status",0);
			if (HttpContext.Current.Request["User_UserName"] != null)
				model.User_UserName=Shop.Tools.RequestTool.RequestSafeString("User_UserName");
			if (HttpContext.Current.Request["Admin_UserName"] != null)
				model.Admin_UserName=Shop.Tools.RequestTool.RequestSafeString("Admin_UserName");
			if (HttpContext.Current.Request["Language_Code"] != null)
				model.Language_Code=Shop.Tools.RequestTool.RequestSafeString("Language_Code");
			if (HttpContext.Current.Request["Parentid"] != null)
				model.Parentid=Shop.Tools.RequestTool.RequestInt("Parentid",0);
			if (HttpContext.Current.Request["ImagesSmall"] != null)
				model.ImagesSmall=Shop.Tools.RequestTool.RequestSafeString("ImagesSmall");
			if (HttpContext.Current.Request["Images"] != null)
				model.Images=Shop.Tools.RequestTool.RequestSafeString("Images");
			if (HttpContext.Current.Request["Supplier_id"] != null)
				model.Supplier_id=Shop.Tools.RequestTool.RequestInt("Supplier_id",0);
			if (HttpContext.Current.Request["Supplier_SubName"] != null)
				model.Supplier_SubName=Shop.Tools.RequestTool.RequestSafeString("Supplier_SubName");
			if (HttpContext.Current.Request["Product_id"] != null)
				model.Product_id=Shop.Tools.RequestTool.RequestInt("Product_id",0);
			if (HttpContext.Current.Request["IsRead"] != null)
				model.IsRead=Shop.Tools.RequestTool.RequestInt("IsRead",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Comment ReaderBind(IDataReader dataReader)
		{
			Lebi_Comment model=new Lebi_Comment();
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
			ojb = dataReader["Admin_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Admin_id=(int)ojb;
			}
			model.TableName=dataReader["TableName"].ToString();
			ojb = dataReader["Keyid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Keyid=(int)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Time_Add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Add=(DateTime)ojb;
			}
			ojb = dataReader["Star"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Star=(int)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			model.User_UserName=dataReader["User_UserName"].ToString();
			model.Admin_UserName=dataReader["Admin_UserName"].ToString();
			model.Language_Code=dataReader["Language_Code"].ToString();
			ojb = dataReader["Parentid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Parentid=(int)ojb;
			}
			model.ImagesSmall=dataReader["ImagesSmall"].ToString();
			model.Images=dataReader["Images"].ToString();
			ojb = dataReader["Supplier_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Supplier_id=(int)ojb;
			}
			model.Supplier_SubName=dataReader["Supplier_SubName"].ToString();
			ojb = dataReader["Product_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Product_id=(int)ojb;
			}
			ojb = dataReader["IsRead"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRead=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

