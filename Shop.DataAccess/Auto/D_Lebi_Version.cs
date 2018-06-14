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

	public interface Lebi_Version_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Version model);
		void Update(Lebi_Version model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Version GetModel(int id);
		Lebi_Version GetModel(string strWhere);
		Lebi_Version GetModel(SQLPara para);
		List<Lebi_Version> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Version> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Version> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Version> GetList(SQLPara para);
		Lebi_Version BindForm(Lebi_Version model);
		Lebi_Version SafeBindForm(Lebi_Version model);
		Lebi_Version ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Version。
	/// </summary>
	public class D_Lebi_Version
	{
		static Lebi_Version_interface _Instance;
		public static Lebi_Version_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Version();
		            else
		                _Instance = new sqlserver_Lebi_Version();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Version()
		{}
		#region  成员方法
	class sqlserver_Lebi_Version : Lebi_Version_interface
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
				strSql.Append("select " + colName + " from [Lebi_Version]");
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
			strSql.Append("select  "+colName+" from [Lebi_Version]");
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
			strSql.Append("select count(1) from [Lebi_Version]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Version]");
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
			strSql.Append("select max(id) from [Lebi_Version]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Version]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Version model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Version](");
			strSql.Append("Version,Version_Son,Path_rar,Path,Time_Update,IsUpdate,Content,Version_Check,Description,Size,IsTypeUpdate,IsDBStructUpdate,IsSystemMenuUpdate,IsThemePageUpdate,IsNodeUpdate,IsPageUpdate,IsSystemPageUpdate)");
			strSql.Append(" values (");
			strSql.Append("@Version,@Version_Son,@Path_rar,@Path,@Time_Update,@IsUpdate,@Content,@Version_Check,@Description,@Size,@IsTypeUpdate,@IsDBStructUpdate,@IsSystemMenuUpdate,@IsThemePageUpdate,@IsNodeUpdate,@IsPageUpdate,@IsSystemPageUpdate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Version", model.Version),
					new SqlParameter("@Version_Son", model.Version_Son),
					new SqlParameter("@Path_rar", model.Path_rar),
					new SqlParameter("@Path", model.Path),
					new SqlParameter("@Time_Update", model.Time_Update),
					new SqlParameter("@IsUpdate", model.IsUpdate),
					new SqlParameter("@Content", model.Content),
					new SqlParameter("@Version_Check", model.Version_Check),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@Size", model.Size),
					new SqlParameter("@IsTypeUpdate", model.IsTypeUpdate),
					new SqlParameter("@IsDBStructUpdate", model.IsDBStructUpdate),
					new SqlParameter("@IsSystemMenuUpdate", model.IsSystemMenuUpdate),
					new SqlParameter("@IsThemePageUpdate", model.IsThemePageUpdate),
					new SqlParameter("@IsNodeUpdate", model.IsNodeUpdate),
					new SqlParameter("@IsPageUpdate", model.IsPageUpdate),
					new SqlParameter("@IsSystemPageUpdate", model.IsSystemPageUpdate)};

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
		public void Update(Lebi_Version model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Version] set ");
			strSql.Append("Version= @Version,");
			strSql.Append("Version_Son= @Version_Son,");
			strSql.Append("Path_rar= @Path_rar,");
			strSql.Append("Path= @Path,");
			strSql.Append("Time_Update= @Time_Update,");
			strSql.Append("IsUpdate= @IsUpdate,");
			strSql.Append("Content= @Content,");
			strSql.Append("Version_Check= @Version_Check,");
			strSql.Append("Description= @Description,");
			strSql.Append("Size= @Size,");
			strSql.Append("IsTypeUpdate= @IsTypeUpdate,");
			strSql.Append("IsDBStructUpdate= @IsDBStructUpdate,");
			strSql.Append("IsSystemMenuUpdate= @IsSystemMenuUpdate,");
			strSql.Append("IsThemePageUpdate= @IsThemePageUpdate,");
			strSql.Append("IsNodeUpdate= @IsNodeUpdate,");
			strSql.Append("IsPageUpdate= @IsPageUpdate,");
			strSql.Append("IsSystemPageUpdate= @IsSystemPageUpdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Version", SqlDbType.Int,4),
					new SqlParameter("@Version_Son", SqlDbType.Decimal,9),
					new SqlParameter("@Path_rar", SqlDbType.NVarChar,200),
					new SqlParameter("@Path", SqlDbType.NVarChar,200),
					new SqlParameter("@Time_Update", SqlDbType.DateTime),
					new SqlParameter("@IsUpdate", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Version_Check", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@IsTypeUpdate", SqlDbType.Int,4),
					new SqlParameter("@IsDBStructUpdate", SqlDbType.Int,4),
					new SqlParameter("@IsSystemMenuUpdate", SqlDbType.Int,4),
					new SqlParameter("@IsThemePageUpdate", SqlDbType.Int,4),
					new SqlParameter("@IsNodeUpdate", SqlDbType.Int,4),
					new SqlParameter("@IsPageUpdate", SqlDbType.Int,4),
					new SqlParameter("@IsSystemPageUpdate", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Version;
			parameters[2].Value = model.Version_Son;
			parameters[3].Value = model.Path_rar;
			parameters[4].Value = model.Path;
			parameters[5].Value = model.Time_Update;
			parameters[6].Value = model.IsUpdate;
			parameters[7].Value = model.Content;
			parameters[8].Value = model.Version_Check;
			parameters[9].Value = model.Description;
			parameters[10].Value = model.Size;
			parameters[11].Value = model.IsTypeUpdate;
			parameters[12].Value = model.IsDBStructUpdate;
			parameters[13].Value = model.IsSystemMenuUpdate;
			parameters[14].Value = model.IsThemePageUpdate;
			parameters[15].Value = model.IsNodeUpdate;
			parameters[16].Value = model.IsPageUpdate;
			parameters[17].Value = model.IsSystemPageUpdate;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Version] ");
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
			strSql.Append("delete from [Lebi_Version] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Version] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Version GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Version] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Version model=new Lebi_Version();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Version"].ToString()!="")
				{
					model.Version=int.Parse(ds.Tables[0].Rows[0]["Version"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Version_Son"].ToString()!="")
				{
					model.Version_Son=decimal.Parse(ds.Tables[0].Rows[0]["Version_Son"].ToString());
				}
				model.Path_rar=ds.Tables[0].Rows[0]["Path_rar"].ToString();
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUpdate"].ToString()!="")
				{
					model.IsUpdate=int.Parse(ds.Tables[0].Rows[0]["IsUpdate"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.Version_Check=ds.Tables[0].Rows[0]["Version_Check"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Size=ds.Tables[0].Rows[0]["Size"].ToString();
				if(ds.Tables[0].Rows[0]["IsTypeUpdate"].ToString()!="")
				{
					model.IsTypeUpdate=int.Parse(ds.Tables[0].Rows[0]["IsTypeUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsDBStructUpdate"].ToString()!="")
				{
					model.IsDBStructUpdate=int.Parse(ds.Tables[0].Rows[0]["IsDBStructUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSystemMenuUpdate"].ToString()!="")
				{
					model.IsSystemMenuUpdate=int.Parse(ds.Tables[0].Rows[0]["IsSystemMenuUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsThemePageUpdate"].ToString()!="")
				{
					model.IsThemePageUpdate=int.Parse(ds.Tables[0].Rows[0]["IsThemePageUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsNodeUpdate"].ToString()!="")
				{
					model.IsNodeUpdate=int.Parse(ds.Tables[0].Rows[0]["IsNodeUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPageUpdate"].ToString()!="")
				{
					model.IsPageUpdate=int.Parse(ds.Tables[0].Rows[0]["IsPageUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSystemPageUpdate"].ToString()!="")
				{
					model.IsSystemPageUpdate=int.Parse(ds.Tables[0].Rows[0]["IsSystemPageUpdate"].ToString());
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
		public Lebi_Version GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Version] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Version model=new Lebi_Version();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Version"].ToString()!="")
				{
					model.Version=int.Parse(ds.Tables[0].Rows[0]["Version"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Version_Son"].ToString()!="")
				{
					model.Version_Son=decimal.Parse(ds.Tables[0].Rows[0]["Version_Son"].ToString());
				}
				model.Path_rar=ds.Tables[0].Rows[0]["Path_rar"].ToString();
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUpdate"].ToString()!="")
				{
					model.IsUpdate=int.Parse(ds.Tables[0].Rows[0]["IsUpdate"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.Version_Check=ds.Tables[0].Rows[0]["Version_Check"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Size=ds.Tables[0].Rows[0]["Size"].ToString();
				if(ds.Tables[0].Rows[0]["IsTypeUpdate"].ToString()!="")
				{
					model.IsTypeUpdate=int.Parse(ds.Tables[0].Rows[0]["IsTypeUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsDBStructUpdate"].ToString()!="")
				{
					model.IsDBStructUpdate=int.Parse(ds.Tables[0].Rows[0]["IsDBStructUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSystemMenuUpdate"].ToString()!="")
				{
					model.IsSystemMenuUpdate=int.Parse(ds.Tables[0].Rows[0]["IsSystemMenuUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsThemePageUpdate"].ToString()!="")
				{
					model.IsThemePageUpdate=int.Parse(ds.Tables[0].Rows[0]["IsThemePageUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsNodeUpdate"].ToString()!="")
				{
					model.IsNodeUpdate=int.Parse(ds.Tables[0].Rows[0]["IsNodeUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPageUpdate"].ToString()!="")
				{
					model.IsPageUpdate=int.Parse(ds.Tables[0].Rows[0]["IsPageUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSystemPageUpdate"].ToString()!="")
				{
					model.IsSystemPageUpdate=int.Parse(ds.Tables[0].Rows[0]["IsSystemPageUpdate"].ToString());
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
		public Lebi_Version GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Version] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Version model=new Lebi_Version();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Version"].ToString()!="")
				{
					model.Version=int.Parse(ds.Tables[0].Rows[0]["Version"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Version_Son"].ToString()!="")
				{
					model.Version_Son=decimal.Parse(ds.Tables[0].Rows[0]["Version_Son"].ToString());
				}
				model.Path_rar=ds.Tables[0].Rows[0]["Path_rar"].ToString();
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["Time_Update"].ToString()!="")
				{
					model.Time_Update=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Update"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsUpdate"].ToString()!="")
				{
					model.IsUpdate=int.Parse(ds.Tables[0].Rows[0]["IsUpdate"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.Version_Check=ds.Tables[0].Rows[0]["Version_Check"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Size=ds.Tables[0].Rows[0]["Size"].ToString();
				if(ds.Tables[0].Rows[0]["IsTypeUpdate"].ToString()!="")
				{
					model.IsTypeUpdate=int.Parse(ds.Tables[0].Rows[0]["IsTypeUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsDBStructUpdate"].ToString()!="")
				{
					model.IsDBStructUpdate=int.Parse(ds.Tables[0].Rows[0]["IsDBStructUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSystemMenuUpdate"].ToString()!="")
				{
					model.IsSystemMenuUpdate=int.Parse(ds.Tables[0].Rows[0]["IsSystemMenuUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsThemePageUpdate"].ToString()!="")
				{
					model.IsThemePageUpdate=int.Parse(ds.Tables[0].Rows[0]["IsThemePageUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsNodeUpdate"].ToString()!="")
				{
					model.IsNodeUpdate=int.Parse(ds.Tables[0].Rows[0]["IsNodeUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsPageUpdate"].ToString()!="")
				{
					model.IsPageUpdate=int.Parse(ds.Tables[0].Rows[0]["IsPageUpdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSystemPageUpdate"].ToString()!="")
				{
					model.IsSystemPageUpdate=int.Parse(ds.Tables[0].Rows[0]["IsSystemPageUpdate"].ToString());
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
		public List<Lebi_Version> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Version]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Version> list = new List<Lebi_Version>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Version> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Version]";
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
			List<Lebi_Version> list = new List<Lebi_Version>();
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
		public List<Lebi_Version> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Version] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Version> list = new List<Lebi_Version>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Version> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Version]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Version> list = new List<Lebi_Version>();
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
		public Lebi_Version BindForm(Lebi_Version model)
		{
			if (HttpContext.Current.Request["Version"] != null)
				model.Version=Shop.Tools.RequestTool.RequestInt("Version",0);
			if (HttpContext.Current.Request["Version_Son"] != null)
				model.Version_Son=Shop.Tools.RequestTool.RequestDecimal("Version_Son",0);
			if (HttpContext.Current.Request["Path_rar"] != null)
				model.Path_rar=Shop.Tools.RequestTool.RequestString("Path_rar");
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestString("Path");
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["IsUpdate"] != null)
				model.IsUpdate=Shop.Tools.RequestTool.RequestInt("IsUpdate",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Version_Check"] != null)
				model.Version_Check=Shop.Tools.RequestTool.RequestString("Version_Check");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Size"] != null)
				model.Size=Shop.Tools.RequestTool.RequestString("Size");
			if (HttpContext.Current.Request["IsTypeUpdate"] != null)
				model.IsTypeUpdate=Shop.Tools.RequestTool.RequestInt("IsTypeUpdate",0);
			if (HttpContext.Current.Request["IsDBStructUpdate"] != null)
				model.IsDBStructUpdate=Shop.Tools.RequestTool.RequestInt("IsDBStructUpdate",0);
			if (HttpContext.Current.Request["IsSystemMenuUpdate"] != null)
				model.IsSystemMenuUpdate=Shop.Tools.RequestTool.RequestInt("IsSystemMenuUpdate",0);
			if (HttpContext.Current.Request["IsThemePageUpdate"] != null)
				model.IsThemePageUpdate=Shop.Tools.RequestTool.RequestInt("IsThemePageUpdate",0);
			if (HttpContext.Current.Request["IsNodeUpdate"] != null)
				model.IsNodeUpdate=Shop.Tools.RequestTool.RequestInt("IsNodeUpdate",0);
			if (HttpContext.Current.Request["IsPageUpdate"] != null)
				model.IsPageUpdate=Shop.Tools.RequestTool.RequestInt("IsPageUpdate",0);
			if (HttpContext.Current.Request["IsSystemPageUpdate"] != null)
				model.IsSystemPageUpdate=Shop.Tools.RequestTool.RequestInt("IsSystemPageUpdate",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Version SafeBindForm(Lebi_Version model)
		{
			if (HttpContext.Current.Request["Version"] != null)
				model.Version=Shop.Tools.RequestTool.RequestInt("Version",0);
			if (HttpContext.Current.Request["Version_Son"] != null)
				model.Version_Son=Shop.Tools.RequestTool.RequestDecimal("Version_Son",0);
			if (HttpContext.Current.Request["Path_rar"] != null)
				model.Path_rar=Shop.Tools.RequestTool.RequestSafeString("Path_rar");
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestSafeString("Path");
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["IsUpdate"] != null)
				model.IsUpdate=Shop.Tools.RequestTool.RequestInt("IsUpdate",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Version_Check"] != null)
				model.Version_Check=Shop.Tools.RequestTool.RequestSafeString("Version_Check");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Size"] != null)
				model.Size=Shop.Tools.RequestTool.RequestSafeString("Size");
			if (HttpContext.Current.Request["IsTypeUpdate"] != null)
				model.IsTypeUpdate=Shop.Tools.RequestTool.RequestInt("IsTypeUpdate",0);
			if (HttpContext.Current.Request["IsDBStructUpdate"] != null)
				model.IsDBStructUpdate=Shop.Tools.RequestTool.RequestInt("IsDBStructUpdate",0);
			if (HttpContext.Current.Request["IsSystemMenuUpdate"] != null)
				model.IsSystemMenuUpdate=Shop.Tools.RequestTool.RequestInt("IsSystemMenuUpdate",0);
			if (HttpContext.Current.Request["IsThemePageUpdate"] != null)
				model.IsThemePageUpdate=Shop.Tools.RequestTool.RequestInt("IsThemePageUpdate",0);
			if (HttpContext.Current.Request["IsNodeUpdate"] != null)
				model.IsNodeUpdate=Shop.Tools.RequestTool.RequestInt("IsNodeUpdate",0);
			if (HttpContext.Current.Request["IsPageUpdate"] != null)
				model.IsPageUpdate=Shop.Tools.RequestTool.RequestInt("IsPageUpdate",0);
			if (HttpContext.Current.Request["IsSystemPageUpdate"] != null)
				model.IsSystemPageUpdate=Shop.Tools.RequestTool.RequestInt("IsSystemPageUpdate",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Version ReaderBind(IDataReader dataReader)
		{
			Lebi_Version model=new Lebi_Version();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Version"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Version=(int)ojb;
			}
			ojb = dataReader["Version_Son"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Version_Son=(decimal)ojb;
			}
			model.Path_rar=dataReader["Path_rar"].ToString();
			model.Path=dataReader["Path"].ToString();
			ojb = dataReader["Time_Update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Update=(DateTime)ojb;
			}
			ojb = dataReader["IsUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUpdate=(int)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			model.Version_Check=dataReader["Version_Check"].ToString();
			model.Description=dataReader["Description"].ToString();
			model.Size=dataReader["Size"].ToString();
			ojb = dataReader["IsTypeUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsTypeUpdate=(int)ojb;
			}
			ojb = dataReader["IsDBStructUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDBStructUpdate=(int)ojb;
			}
			ojb = dataReader["IsSystemMenuUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSystemMenuUpdate=(int)ojb;
			}
			ojb = dataReader["IsThemePageUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsThemePageUpdate=(int)ojb;
			}
			ojb = dataReader["IsNodeUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsNodeUpdate=(int)ojb;
			}
			ojb = dataReader["IsPageUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPageUpdate=(int)ojb;
			}
			ojb = dataReader["IsSystemPageUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSystemPageUpdate=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Version : Lebi_Version_interface
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
				strSql.Append("select " + colName + " from [Lebi_Version]");
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
			strSql.Append("select  "+colName+" from [Lebi_Version]");
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
			strSql.Append("select count(*) from [Lebi_Version]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Version]");
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
			strSql.Append("select max(id) from [Lebi_Version]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Version]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Version model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Version](");
			strSql.Append("[Version],[Version_Son],[Path_rar],[Path],[Time_Update],[IsUpdate],[Content],[Version_Check],[Description],[Size],[IsTypeUpdate],[IsDBStructUpdate],[IsSystemMenuUpdate],[IsThemePageUpdate],[IsNodeUpdate],[IsPageUpdate],[IsSystemPageUpdate])");
			strSql.Append(" values (");
			strSql.Append("@Version,@Version_Son,@Path_rar,@Path,@Time_Update,@IsUpdate,@Content,@Version_Check,@Description,@Size,@IsTypeUpdate,@IsDBStructUpdate,@IsSystemMenuUpdate,@IsThemePageUpdate,@IsNodeUpdate,@IsPageUpdate,@IsSystemPageUpdate)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Version", model.Version),
					new OleDbParameter("@Version_Son", model.Version_Son),
					new OleDbParameter("@Path_rar", model.Path_rar),
					new OleDbParameter("@Path", model.Path),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@IsUpdate", model.IsUpdate),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Version_Check", model.Version_Check),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Size", model.Size),
					new OleDbParameter("@IsTypeUpdate", model.IsTypeUpdate),
					new OleDbParameter("@IsDBStructUpdate", model.IsDBStructUpdate),
					new OleDbParameter("@IsSystemMenuUpdate", model.IsSystemMenuUpdate),
					new OleDbParameter("@IsThemePageUpdate", model.IsThemePageUpdate),
					new OleDbParameter("@IsNodeUpdate", model.IsNodeUpdate),
					new OleDbParameter("@IsPageUpdate", model.IsPageUpdate),
					new OleDbParameter("@IsSystemPageUpdate", model.IsSystemPageUpdate)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Version model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Version] set ");
			strSql.Append("[Version]=@Version,");
			strSql.Append("[Version_Son]=@Version_Son,");
			strSql.Append("[Path_rar]=@Path_rar,");
			strSql.Append("[Path]=@Path,");
			strSql.Append("[Time_Update]=@Time_Update,");
			strSql.Append("[IsUpdate]=@IsUpdate,");
			strSql.Append("[Content]=@Content,");
			strSql.Append("[Version_Check]=@Version_Check,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[Size]=@Size,");
			strSql.Append("[IsTypeUpdate]=@IsTypeUpdate,");
			strSql.Append("[IsDBStructUpdate]=@IsDBStructUpdate,");
			strSql.Append("[IsSystemMenuUpdate]=@IsSystemMenuUpdate,");
			strSql.Append("[IsThemePageUpdate]=@IsThemePageUpdate,");
			strSql.Append("[IsNodeUpdate]=@IsNodeUpdate,");
			strSql.Append("[IsPageUpdate]=@IsPageUpdate,");
			strSql.Append("[IsSystemPageUpdate]=@IsSystemPageUpdate");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Version", model.Version),
					new OleDbParameter("@Version_Son", model.Version_Son),
					new OleDbParameter("@Path_rar", model.Path_rar),
					new OleDbParameter("@Path", model.Path),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@IsUpdate", model.IsUpdate),
					new OleDbParameter("@Content", model.Content),
					new OleDbParameter("@Version_Check", model.Version_Check),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Size", model.Size),
					new OleDbParameter("@IsTypeUpdate", model.IsTypeUpdate),
					new OleDbParameter("@IsDBStructUpdate", model.IsDBStructUpdate),
					new OleDbParameter("@IsSystemMenuUpdate", model.IsSystemMenuUpdate),
					new OleDbParameter("@IsThemePageUpdate", model.IsThemePageUpdate),
					new OleDbParameter("@IsNodeUpdate", model.IsNodeUpdate),
					new OleDbParameter("@IsPageUpdate", model.IsPageUpdate),
					new OleDbParameter("@IsSystemPageUpdate", model.IsSystemPageUpdate)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Version] ");
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
			strSql.Append("delete from [Lebi_Version] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Version] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Version GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Version] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Version model;
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
		public Lebi_Version GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Version] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Version model;
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
		public Lebi_Version GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Version] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Version model;
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
		public List<Lebi_Version> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Version]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Version> list = new List<Lebi_Version>();
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
		public List<Lebi_Version> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Version]";
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
			List<Lebi_Version> list = new List<Lebi_Version>();
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
		public List<Lebi_Version> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Version] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Version> list = new List<Lebi_Version>();
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
		public List<Lebi_Version> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Version]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Version> list = new List<Lebi_Version>();
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
		public Lebi_Version BindForm(Lebi_Version model)
		{
			if (HttpContext.Current.Request["Version"] != null)
				model.Version=Shop.Tools.RequestTool.RequestInt("Version",0);
			if (HttpContext.Current.Request["Version_Son"] != null)
				model.Version_Son=Shop.Tools.RequestTool.RequestDecimal("Version_Son",0);
			if (HttpContext.Current.Request["Path_rar"] != null)
				model.Path_rar=Shop.Tools.RequestTool.RequestString("Path_rar");
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestString("Path");
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["IsUpdate"] != null)
				model.IsUpdate=Shop.Tools.RequestTool.RequestInt("IsUpdate",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestString("Content");
			if (HttpContext.Current.Request["Version_Check"] != null)
				model.Version_Check=Shop.Tools.RequestTool.RequestString("Version_Check");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Size"] != null)
				model.Size=Shop.Tools.RequestTool.RequestString("Size");
			if (HttpContext.Current.Request["IsTypeUpdate"] != null)
				model.IsTypeUpdate=Shop.Tools.RequestTool.RequestInt("IsTypeUpdate",0);
			if (HttpContext.Current.Request["IsDBStructUpdate"] != null)
				model.IsDBStructUpdate=Shop.Tools.RequestTool.RequestInt("IsDBStructUpdate",0);
			if (HttpContext.Current.Request["IsSystemMenuUpdate"] != null)
				model.IsSystemMenuUpdate=Shop.Tools.RequestTool.RequestInt("IsSystemMenuUpdate",0);
			if (HttpContext.Current.Request["IsThemePageUpdate"] != null)
				model.IsThemePageUpdate=Shop.Tools.RequestTool.RequestInt("IsThemePageUpdate",0);
			if (HttpContext.Current.Request["IsNodeUpdate"] != null)
				model.IsNodeUpdate=Shop.Tools.RequestTool.RequestInt("IsNodeUpdate",0);
			if (HttpContext.Current.Request["IsPageUpdate"] != null)
				model.IsPageUpdate=Shop.Tools.RequestTool.RequestInt("IsPageUpdate",0);
			if (HttpContext.Current.Request["IsSystemPageUpdate"] != null)
				model.IsSystemPageUpdate=Shop.Tools.RequestTool.RequestInt("IsSystemPageUpdate",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Version SafeBindForm(Lebi_Version model)
		{
			if (HttpContext.Current.Request["Version"] != null)
				model.Version=Shop.Tools.RequestTool.RequestInt("Version",0);
			if (HttpContext.Current.Request["Version_Son"] != null)
				model.Version_Son=Shop.Tools.RequestTool.RequestDecimal("Version_Son",0);
			if (HttpContext.Current.Request["Path_rar"] != null)
				model.Path_rar=Shop.Tools.RequestTool.RequestSafeString("Path_rar");
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestSafeString("Path");
			if (HttpContext.Current.Request["Time_Update"] != null)
				model.Time_Update=Shop.Tools.RequestTool.RequestTime("Time_Update", System.DateTime.Now);
			if (HttpContext.Current.Request["IsUpdate"] != null)
				model.IsUpdate=Shop.Tools.RequestTool.RequestInt("IsUpdate",0);
			if (HttpContext.Current.Request["Content"] != null)
				model.Content=Shop.Tools.RequestTool.RequestSafeString("Content");
			if (HttpContext.Current.Request["Version_Check"] != null)
				model.Version_Check=Shop.Tools.RequestTool.RequestSafeString("Version_Check");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Size"] != null)
				model.Size=Shop.Tools.RequestTool.RequestSafeString("Size");
			if (HttpContext.Current.Request["IsTypeUpdate"] != null)
				model.IsTypeUpdate=Shop.Tools.RequestTool.RequestInt("IsTypeUpdate",0);
			if (HttpContext.Current.Request["IsDBStructUpdate"] != null)
				model.IsDBStructUpdate=Shop.Tools.RequestTool.RequestInt("IsDBStructUpdate",0);
			if (HttpContext.Current.Request["IsSystemMenuUpdate"] != null)
				model.IsSystemMenuUpdate=Shop.Tools.RequestTool.RequestInt("IsSystemMenuUpdate",0);
			if (HttpContext.Current.Request["IsThemePageUpdate"] != null)
				model.IsThemePageUpdate=Shop.Tools.RequestTool.RequestInt("IsThemePageUpdate",0);
			if (HttpContext.Current.Request["IsNodeUpdate"] != null)
				model.IsNodeUpdate=Shop.Tools.RequestTool.RequestInt("IsNodeUpdate",0);
			if (HttpContext.Current.Request["IsPageUpdate"] != null)
				model.IsPageUpdate=Shop.Tools.RequestTool.RequestInt("IsPageUpdate",0);
			if (HttpContext.Current.Request["IsSystemPageUpdate"] != null)
				model.IsSystemPageUpdate=Shop.Tools.RequestTool.RequestInt("IsSystemPageUpdate",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Version ReaderBind(IDataReader dataReader)
		{
			Lebi_Version model=new Lebi_Version();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Version"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Version=(int)ojb;
			}
			ojb = dataReader["Version_Son"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Version_Son=(decimal)ojb;
			}
			model.Path_rar=dataReader["Path_rar"].ToString();
			model.Path=dataReader["Path"].ToString();
			ojb = dataReader["Time_Update"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Update=(DateTime)ojb;
			}
			ojb = dataReader["IsUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUpdate=(int)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			model.Version_Check=dataReader["Version_Check"].ToString();
			model.Description=dataReader["Description"].ToString();
			model.Size=dataReader["Size"].ToString();
			ojb = dataReader["IsTypeUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsTypeUpdate=(int)ojb;
			}
			ojb = dataReader["IsDBStructUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDBStructUpdate=(int)ojb;
			}
			ojb = dataReader["IsSystemMenuUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSystemMenuUpdate=(int)ojb;
			}
			ojb = dataReader["IsThemePageUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsThemePageUpdate=(int)ojb;
			}
			ojb = dataReader["IsNodeUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsNodeUpdate=(int)ojb;
			}
			ojb = dataReader["IsPageUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPageUpdate=(int)ojb;
			}
			ojb = dataReader["IsSystemPageUpdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSystemPageUpdate=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

