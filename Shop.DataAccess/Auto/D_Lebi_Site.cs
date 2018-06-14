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

	public interface Lebi_Site_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Site model);
		void Update(Lebi_Site model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Site GetModel(int id);
		Lebi_Site GetModel(string strWhere);
		Lebi_Site GetModel(SQLPara para);
		List<Lebi_Site> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Site> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Site> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Site> GetList(SQLPara para);
		Lebi_Site BindForm(Lebi_Site model);
		Lebi_Site SafeBindForm(Lebi_Site model);
		Lebi_Site ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Site。
	/// </summary>
	public class D_Lebi_Site
	{
		static Lebi_Site_interface _Instance;
		public static Lebi_Site_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Site();
		            else
		                _Instance = new sqlserver_Lebi_Site();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Site()
		{}
		#region  成员方法
	class sqlserver_Lebi_Site : Lebi_Site_interface
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
				strSql.Append("select " + colName + " from [Lebi_Site]");
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
			strSql.Append("select  "+colName+" from [Lebi_Site]");
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
			strSql.Append("select count(1) from [Lebi_Site]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Site]");
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
			strSql.Append("select max(id) from [Lebi_Site]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Site]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Site model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Site](");
			strSql.Append("Name,SubName,Title,Keywords,Description,Logoimg,Phone,Fax,Email,QQ,Copyright,ServiceP,Domain,Sort,Time_add,Time_Edit,Path,IsMobile,FootHtml,platform_weixin_number,platform_weixin_id,platform_weixin_secret,platform_weixin_image_qrcode,platform_weixin_custemtoken,platform_weixin_subscribe_automsg)");
			strSql.Append(" values (");
			strSql.Append("@Name,@SubName,@Title,@Keywords,@Description,@Logoimg,@Phone,@Fax,@Email,@QQ,@Copyright,@ServiceP,@Domain,@Sort,@Time_add,@Time_Edit,@Path,@IsMobile,@FootHtml,@platform_weixin_number,@platform_weixin_id,@platform_weixin_secret,@platform_weixin_image_qrcode,@platform_weixin_custemtoken,@platform_weixin_subscribe_automsg)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", model.Name),
					new SqlParameter("@SubName", model.SubName),
					new SqlParameter("@Title", model.Title),
					new SqlParameter("@Keywords", model.Keywords),
					new SqlParameter("@Description", model.Description),
					new SqlParameter("@Logoimg", model.Logoimg),
					new SqlParameter("@Phone", model.Phone),
					new SqlParameter("@Fax", model.Fax),
					new SqlParameter("@Email", model.Email),
					new SqlParameter("@QQ", model.QQ),
					new SqlParameter("@Copyright", model.Copyright),
					new SqlParameter("@ServiceP", model.ServiceP),
					new SqlParameter("@Domain", model.Domain),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Time_add", model.Time_add),
					new SqlParameter("@Time_Edit", model.Time_Edit),
					new SqlParameter("@Path", model.Path),
					new SqlParameter("@IsMobile", model.IsMobile),
					new SqlParameter("@FootHtml", model.FootHtml),
					new SqlParameter("@platform_weixin_number", model.platform_weixin_number),
					new SqlParameter("@platform_weixin_id", model.platform_weixin_id),
					new SqlParameter("@platform_weixin_secret", model.platform_weixin_secret),
					new SqlParameter("@platform_weixin_image_qrcode", model.platform_weixin_image_qrcode),
					new SqlParameter("@platform_weixin_custemtoken", model.platform_weixin_custemtoken),
					new SqlParameter("@platform_weixin_subscribe_automsg", model.platform_weixin_subscribe_automsg)};

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
		public void Update(Lebi_Site model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Site] set ");
			strSql.Append("Name= @Name,");
			strSql.Append("SubName= @SubName,");
			strSql.Append("Title= @Title,");
			strSql.Append("Keywords= @Keywords,");
			strSql.Append("Description= @Description,");
			strSql.Append("Logoimg= @Logoimg,");
			strSql.Append("Phone= @Phone,");
			strSql.Append("Fax= @Fax,");
			strSql.Append("Email= @Email,");
			strSql.Append("QQ= @QQ,");
			strSql.Append("Copyright= @Copyright,");
			strSql.Append("ServiceP= @ServiceP,");
			strSql.Append("Domain= @Domain,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Time_add= @Time_add,");
			strSql.Append("Time_Edit= @Time_Edit,");
			strSql.Append("Path= @Path,");
			strSql.Append("IsMobile= @IsMobile,");
			strSql.Append("FootHtml= @FootHtml,");
			strSql.Append("platform_weixin_number= @platform_weixin_number,");
			strSql.Append("platform_weixin_id= @platform_weixin_id,");
			strSql.Append("platform_weixin_secret= @platform_weixin_secret,");
			strSql.Append("platform_weixin_image_qrcode= @platform_weixin_image_qrcode,");
			strSql.Append("platform_weixin_custemtoken= @platform_weixin_custemtoken,");
			strSql.Append("platform_weixin_subscribe_automsg= @platform_weixin_subscribe_automsg");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,4000),
					new SqlParameter("@SubName", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,4000),
					new SqlParameter("@Keywords", SqlDbType.NVarChar,4000),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@Logoimg", SqlDbType.NVarChar,2000),
					new SqlParameter("@Phone", SqlDbType.NVarChar,2000),
					new SqlParameter("@Fax", SqlDbType.NVarChar,2000),
					new SqlParameter("@Email", SqlDbType.NVarChar,2000),
					new SqlParameter("@QQ", SqlDbType.NVarChar,2000),
					new SqlParameter("@Copyright", SqlDbType.NText),
					new SqlParameter("@ServiceP", SqlDbType.NText),
					new SqlParameter("@Domain", SqlDbType.NVarChar,100),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Time_add", SqlDbType.DateTime),
					new SqlParameter("@Time_Edit", SqlDbType.DateTime),
					new SqlParameter("@Path", SqlDbType.NVarChar,50),
					new SqlParameter("@IsMobile", SqlDbType.Int,4),
					new SqlParameter("@FootHtml", SqlDbType.NText),
					new SqlParameter("@platform_weixin_number", SqlDbType.NVarChar,50),
					new SqlParameter("@platform_weixin_id", SqlDbType.NVarChar,200),
					new SqlParameter("@platform_weixin_secret", SqlDbType.NVarChar,200),
					new SqlParameter("@platform_weixin_image_qrcode", SqlDbType.NVarChar,200),
					new SqlParameter("@platform_weixin_custemtoken", SqlDbType.NVarChar,200),
					new SqlParameter("@platform_weixin_subscribe_automsg", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.SubName;
			parameters[3].Value = model.Title;
			parameters[4].Value = model.Keywords;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.Logoimg;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.Fax;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.QQ;
			parameters[11].Value = model.Copyright;
			parameters[12].Value = model.ServiceP;
			parameters[13].Value = model.Domain;
			parameters[14].Value = model.Sort;
			parameters[15].Value = model.Time_add;
			parameters[16].Value = model.Time_Edit;
			parameters[17].Value = model.Path;
			parameters[18].Value = model.IsMobile;
			parameters[19].Value = model.FootHtml;
			parameters[20].Value = model.platform_weixin_number;
			parameters[21].Value = model.platform_weixin_id;
			parameters[22].Value = model.platform_weixin_secret;
			parameters[23].Value = model.platform_weixin_image_qrcode;
			parameters[24].Value = model.platform_weixin_custemtoken;
			parameters[25].Value = model.platform_weixin_subscribe_automsg;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Site] ");
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
			strSql.Append("delete from [Lebi_Site] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Site] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Site GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Site] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Site model=new Lebi_Site();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.SubName=ds.Tables[0].Rows[0]["SubName"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Keywords=ds.Tables[0].Rows[0]["Keywords"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Logoimg=ds.Tables[0].Rows[0]["Logoimg"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.Copyright=ds.Tables[0].Rows[0]["Copyright"].ToString();
				model.ServiceP=ds.Tables[0].Rows[0]["ServiceP"].ToString();
				model.Domain=ds.Tables[0].Rows[0]["Domain"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Edit"].ToString()!="")
				{
					model.Time_Edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Edit"].ToString());
				}
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["IsMobile"].ToString()!="")
				{
					model.IsMobile=int.Parse(ds.Tables[0].Rows[0]["IsMobile"].ToString());
				}
				model.FootHtml=ds.Tables[0].Rows[0]["FootHtml"].ToString();
				model.platform_weixin_number=ds.Tables[0].Rows[0]["platform_weixin_number"].ToString();
				model.platform_weixin_id=ds.Tables[0].Rows[0]["platform_weixin_id"].ToString();
				model.platform_weixin_secret=ds.Tables[0].Rows[0]["platform_weixin_secret"].ToString();
				model.platform_weixin_image_qrcode=ds.Tables[0].Rows[0]["platform_weixin_image_qrcode"].ToString();
				model.platform_weixin_custemtoken=ds.Tables[0].Rows[0]["platform_weixin_custemtoken"].ToString();
				model.platform_weixin_subscribe_automsg=ds.Tables[0].Rows[0]["platform_weixin_subscribe_automsg"].ToString();
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
		public Lebi_Site GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Site] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Site model=new Lebi_Site();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.SubName=ds.Tables[0].Rows[0]["SubName"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Keywords=ds.Tables[0].Rows[0]["Keywords"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Logoimg=ds.Tables[0].Rows[0]["Logoimg"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.Copyright=ds.Tables[0].Rows[0]["Copyright"].ToString();
				model.ServiceP=ds.Tables[0].Rows[0]["ServiceP"].ToString();
				model.Domain=ds.Tables[0].Rows[0]["Domain"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Edit"].ToString()!="")
				{
					model.Time_Edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Edit"].ToString());
				}
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["IsMobile"].ToString()!="")
				{
					model.IsMobile=int.Parse(ds.Tables[0].Rows[0]["IsMobile"].ToString());
				}
				model.FootHtml=ds.Tables[0].Rows[0]["FootHtml"].ToString();
				model.platform_weixin_number=ds.Tables[0].Rows[0]["platform_weixin_number"].ToString();
				model.platform_weixin_id=ds.Tables[0].Rows[0]["platform_weixin_id"].ToString();
				model.platform_weixin_secret=ds.Tables[0].Rows[0]["platform_weixin_secret"].ToString();
				model.platform_weixin_image_qrcode=ds.Tables[0].Rows[0]["platform_weixin_image_qrcode"].ToString();
				model.platform_weixin_custemtoken=ds.Tables[0].Rows[0]["platform_weixin_custemtoken"].ToString();
				model.platform_weixin_subscribe_automsg=ds.Tables[0].Rows[0]["platform_weixin_subscribe_automsg"].ToString();
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
		public Lebi_Site GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Site] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Site model=new Lebi_Site();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.SubName=ds.Tables[0].Rows[0]["SubName"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Keywords=ds.Tables[0].Rows[0]["Keywords"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				model.Logoimg=ds.Tables[0].Rows[0]["Logoimg"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				model.Copyright=ds.Tables[0].Rows[0]["Copyright"].ToString();
				model.ServiceP=ds.Tables[0].Rows[0]["ServiceP"].ToString();
				model.Domain=ds.Tables[0].Rows[0]["Domain"].ToString();
				if(ds.Tables[0].Rows[0]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_add"].ToString()!="")
				{
					model.Time_add=DateTime.Parse(ds.Tables[0].Rows[0]["Time_add"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Time_Edit"].ToString()!="")
				{
					model.Time_Edit=DateTime.Parse(ds.Tables[0].Rows[0]["Time_Edit"].ToString());
				}
				model.Path=ds.Tables[0].Rows[0]["Path"].ToString();
				if(ds.Tables[0].Rows[0]["IsMobile"].ToString()!="")
				{
					model.IsMobile=int.Parse(ds.Tables[0].Rows[0]["IsMobile"].ToString());
				}
				model.FootHtml=ds.Tables[0].Rows[0]["FootHtml"].ToString();
				model.platform_weixin_number=ds.Tables[0].Rows[0]["platform_weixin_number"].ToString();
				model.platform_weixin_id=ds.Tables[0].Rows[0]["platform_weixin_id"].ToString();
				model.platform_weixin_secret=ds.Tables[0].Rows[0]["platform_weixin_secret"].ToString();
				model.platform_weixin_image_qrcode=ds.Tables[0].Rows[0]["platform_weixin_image_qrcode"].ToString();
				model.platform_weixin_custemtoken=ds.Tables[0].Rows[0]["platform_weixin_custemtoken"].ToString();
				model.platform_weixin_subscribe_automsg=ds.Tables[0].Rows[0]["platform_weixin_subscribe_automsg"].ToString();
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
		public List<Lebi_Site> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Site]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Site> list = new List<Lebi_Site>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Site> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Site]";
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
			List<Lebi_Site> list = new List<Lebi_Site>();
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
		public List<Lebi_Site> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Site] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Site> list = new List<Lebi_Site>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Site> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Site]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Site> list = new List<Lebi_Site>();
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
		public Lebi_Site BindForm(Lebi_Site model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestString("SubName");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["Keywords"] != null)
				model.Keywords=Shop.Tools.RequestTool.RequestString("Keywords");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Logoimg"] != null)
				model.Logoimg=Shop.Tools.RequestTool.RequestString("Logoimg");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestString("Fax");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestString("QQ");
			if (HttpContext.Current.Request["Copyright"] != null)
				model.Copyright=Shop.Tools.RequestTool.RequestString("Copyright");
			if (HttpContext.Current.Request["ServiceP"] != null)
				model.ServiceP=Shop.Tools.RequestTool.RequestString("ServiceP");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestString("Domain");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestString("Path");
			if (HttpContext.Current.Request["IsMobile"] != null)
				model.IsMobile=Shop.Tools.RequestTool.RequestInt("IsMobile",0);
			if (HttpContext.Current.Request["FootHtml"] != null)
				model.FootHtml=Shop.Tools.RequestTool.RequestString("FootHtml");
			if (HttpContext.Current.Request["platform_weixin_number"] != null)
				model.platform_weixin_number=Shop.Tools.RequestTool.RequestString("platform_weixin_number");
			if (HttpContext.Current.Request["platform_weixin_id"] != null)
				model.platform_weixin_id=Shop.Tools.RequestTool.RequestString("platform_weixin_id");
			if (HttpContext.Current.Request["platform_weixin_secret"] != null)
				model.platform_weixin_secret=Shop.Tools.RequestTool.RequestString("platform_weixin_secret");
			if (HttpContext.Current.Request["platform_weixin_image_qrcode"] != null)
				model.platform_weixin_image_qrcode=Shop.Tools.RequestTool.RequestString("platform_weixin_image_qrcode");
			if (HttpContext.Current.Request["platform_weixin_custemtoken"] != null)
				model.platform_weixin_custemtoken=Shop.Tools.RequestTool.RequestString("platform_weixin_custemtoken");
			if (HttpContext.Current.Request["platform_weixin_subscribe_automsg"] != null)
				model.platform_weixin_subscribe_automsg=Shop.Tools.RequestTool.RequestString("platform_weixin_subscribe_automsg");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Site SafeBindForm(Lebi_Site model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestSafeString("SubName");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["Keywords"] != null)
				model.Keywords=Shop.Tools.RequestTool.RequestSafeString("Keywords");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Logoimg"] != null)
				model.Logoimg=Shop.Tools.RequestTool.RequestSafeString("Logoimg");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestSafeString("Fax");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestSafeString("QQ");
			if (HttpContext.Current.Request["Copyright"] != null)
				model.Copyright=Shop.Tools.RequestTool.RequestSafeString("Copyright");
			if (HttpContext.Current.Request["ServiceP"] != null)
				model.ServiceP=Shop.Tools.RequestTool.RequestSafeString("ServiceP");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestSafeString("Domain");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestSafeString("Path");
			if (HttpContext.Current.Request["IsMobile"] != null)
				model.IsMobile=Shop.Tools.RequestTool.RequestInt("IsMobile",0);
			if (HttpContext.Current.Request["FootHtml"] != null)
				model.FootHtml=Shop.Tools.RequestTool.RequestSafeString("FootHtml");
			if (HttpContext.Current.Request["platform_weixin_number"] != null)
				model.platform_weixin_number=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_number");
			if (HttpContext.Current.Request["platform_weixin_id"] != null)
				model.platform_weixin_id=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_id");
			if (HttpContext.Current.Request["platform_weixin_secret"] != null)
				model.platform_weixin_secret=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_secret");
			if (HttpContext.Current.Request["platform_weixin_image_qrcode"] != null)
				model.platform_weixin_image_qrcode=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_image_qrcode");
			if (HttpContext.Current.Request["platform_weixin_custemtoken"] != null)
				model.platform_weixin_custemtoken=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_custemtoken");
			if (HttpContext.Current.Request["platform_weixin_subscribe_automsg"] != null)
				model.platform_weixin_subscribe_automsg=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_subscribe_automsg");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Site ReaderBind(IDataReader dataReader)
		{
			Lebi_Site model=new Lebi_Site();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.SubName=dataReader["SubName"].ToString();
			model.Title=dataReader["Title"].ToString();
			model.Keywords=dataReader["Keywords"].ToString();
			model.Description=dataReader["Description"].ToString();
			model.Logoimg=dataReader["Logoimg"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			model.Fax=dataReader["Fax"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.QQ=dataReader["QQ"].ToString();
			model.Copyright=dataReader["Copyright"].ToString();
			model.ServiceP=dataReader["ServiceP"].ToString();
			model.Domain=dataReader["Domain"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Edit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Edit=(DateTime)ojb;
			}
			model.Path=dataReader["Path"].ToString();
			ojb = dataReader["IsMobile"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsMobile=(int)ojb;
			}
			model.FootHtml=dataReader["FootHtml"].ToString();
			model.platform_weixin_number=dataReader["platform_weixin_number"].ToString();
			model.platform_weixin_id=dataReader["platform_weixin_id"].ToString();
			model.platform_weixin_secret=dataReader["platform_weixin_secret"].ToString();
			model.platform_weixin_image_qrcode=dataReader["platform_weixin_image_qrcode"].ToString();
			model.platform_weixin_custemtoken=dataReader["platform_weixin_custemtoken"].ToString();
			model.platform_weixin_subscribe_automsg=dataReader["platform_weixin_subscribe_automsg"].ToString();
			return model;
		}

	}
	class access_Lebi_Site : Lebi_Site_interface
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
				strSql.Append("select " + colName + " from [Lebi_Site]");
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
			strSql.Append("select  "+colName+" from [Lebi_Site]");
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
			strSql.Append("select count(*) from [Lebi_Site]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Site]");
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
			strSql.Append("select max(id) from [Lebi_Site]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Site]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Site model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Site](");
			strSql.Append("[Name],[SubName],[Title],[Keywords],[Description],[Logoimg],[Phone],[Fax],[Email],[QQ],[Copyright],[ServiceP],[Domain],[Sort],[Time_add],[Time_Edit],[Path],[IsMobile],[FootHtml],[platform_weixin_number],[platform_weixin_id],[platform_weixin_secret],[platform_weixin_image_qrcode],[platform_weixin_custemtoken],[platform_weixin_subscribe_automsg])");
			strSql.Append(" values (");
			strSql.Append("@Name,@SubName,@Title,@Keywords,@Description,@Logoimg,@Phone,@Fax,@Email,@QQ,@Copyright,@ServiceP,@Domain,@Sort,@Time_add,@Time_Edit,@Path,@IsMobile,@FootHtml,@platform_weixin_number,@platform_weixin_id,@platform_weixin_secret,@platform_weixin_image_qrcode,@platform_weixin_custemtoken,@platform_weixin_subscribe_automsg)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@SubName", model.SubName),
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@Keywords", model.Keywords),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Logoimg", model.Logoimg),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@Fax", model.Fax),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@QQ", model.QQ),
					new OleDbParameter("@Copyright", model.Copyright),
					new OleDbParameter("@ServiceP", model.ServiceP),
					new OleDbParameter("@Domain", model.Domain),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Edit", model.Time_Edit.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Path", model.Path),
					new OleDbParameter("@IsMobile", model.IsMobile),
					new OleDbParameter("@FootHtml", model.FootHtml),
					new OleDbParameter("@platform_weixin_number", model.platform_weixin_number),
					new OleDbParameter("@platform_weixin_id", model.platform_weixin_id),
					new OleDbParameter("@platform_weixin_secret", model.platform_weixin_secret),
					new OleDbParameter("@platform_weixin_image_qrcode", model.platform_weixin_image_qrcode),
					new OleDbParameter("@platform_weixin_custemtoken", model.platform_weixin_custemtoken),
					new OleDbParameter("@platform_weixin_subscribe_automsg", model.platform_weixin_subscribe_automsg)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Site model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Site] set ");
			strSql.Append("[Name]=@Name,");
			strSql.Append("[SubName]=@SubName,");
			strSql.Append("[Title]=@Title,");
			strSql.Append("[Keywords]=@Keywords,");
			strSql.Append("[Description]=@Description,");
			strSql.Append("[Logoimg]=@Logoimg,");
			strSql.Append("[Phone]=@Phone,");
			strSql.Append("[Fax]=@Fax,");
			strSql.Append("[Email]=@Email,");
			strSql.Append("[QQ]=@QQ,");
			strSql.Append("[Copyright]=@Copyright,");
			strSql.Append("[ServiceP]=@ServiceP,");
			strSql.Append("[Domain]=@Domain,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Time_add]=@Time_add,");
			strSql.Append("[Time_Edit]=@Time_Edit,");
			strSql.Append("[Path]=@Path,");
			strSql.Append("[IsMobile]=@IsMobile,");
			strSql.Append("[FootHtml]=@FootHtml,");
			strSql.Append("[platform_weixin_number]=@platform_weixin_number,");
			strSql.Append("[platform_weixin_id]=@platform_weixin_id,");
			strSql.Append("[platform_weixin_secret]=@platform_weixin_secret,");
			strSql.Append("[platform_weixin_image_qrcode]=@platform_weixin_image_qrcode,");
			strSql.Append("[platform_weixin_custemtoken]=@platform_weixin_custemtoken,");
			strSql.Append("[platform_weixin_subscribe_automsg]=@platform_weixin_subscribe_automsg");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", model.Name),
					new OleDbParameter("@SubName", model.SubName),
					new OleDbParameter("@Title", model.Title),
					new OleDbParameter("@Keywords", model.Keywords),
					new OleDbParameter("@Description", model.Description),
					new OleDbParameter("@Logoimg", model.Logoimg),
					new OleDbParameter("@Phone", model.Phone),
					new OleDbParameter("@Fax", model.Fax),
					new OleDbParameter("@Email", model.Email),
					new OleDbParameter("@QQ", model.QQ),
					new OleDbParameter("@Copyright", model.Copyright),
					new OleDbParameter("@ServiceP", model.ServiceP),
					new OleDbParameter("@Domain", model.Domain),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Time_add", model.Time_add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Edit", model.Time_Edit.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Path", model.Path),
					new OleDbParameter("@IsMobile", model.IsMobile),
					new OleDbParameter("@FootHtml", model.FootHtml),
					new OleDbParameter("@platform_weixin_number", model.platform_weixin_number),
					new OleDbParameter("@platform_weixin_id", model.platform_weixin_id),
					new OleDbParameter("@platform_weixin_secret", model.platform_weixin_secret),
					new OleDbParameter("@platform_weixin_image_qrcode", model.platform_weixin_image_qrcode),
					new OleDbParameter("@platform_weixin_custemtoken", model.platform_weixin_custemtoken),
					new OleDbParameter("@platform_weixin_subscribe_automsg", model.platform_weixin_subscribe_automsg)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Site] ");
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
			strSql.Append("delete from [Lebi_Site] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Site] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Site GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Site] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Site model;
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
		public Lebi_Site GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Site] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Site model;
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
		public Lebi_Site GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Site] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Site model;
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
		public List<Lebi_Site> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Site]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Site> list = new List<Lebi_Site>();
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
		public List<Lebi_Site> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Site]";
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
			List<Lebi_Site> list = new List<Lebi_Site>();
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
		public List<Lebi_Site> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Site] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Site> list = new List<Lebi_Site>();
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
		public List<Lebi_Site> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Site]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Site> list = new List<Lebi_Site>();
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
		public Lebi_Site BindForm(Lebi_Site model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestString("Name");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestString("SubName");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestString("Title");
			if (HttpContext.Current.Request["Keywords"] != null)
				model.Keywords=Shop.Tools.RequestTool.RequestString("Keywords");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestString("Description");
			if (HttpContext.Current.Request["Logoimg"] != null)
				model.Logoimg=Shop.Tools.RequestTool.RequestString("Logoimg");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestString("Phone");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestString("Fax");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestString("Email");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestString("QQ");
			if (HttpContext.Current.Request["Copyright"] != null)
				model.Copyright=Shop.Tools.RequestTool.RequestString("Copyright");
			if (HttpContext.Current.Request["ServiceP"] != null)
				model.ServiceP=Shop.Tools.RequestTool.RequestString("ServiceP");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestString("Domain");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestString("Path");
			if (HttpContext.Current.Request["IsMobile"] != null)
				model.IsMobile=Shop.Tools.RequestTool.RequestInt("IsMobile",0);
			if (HttpContext.Current.Request["FootHtml"] != null)
				model.FootHtml=Shop.Tools.RequestTool.RequestString("FootHtml");
			if (HttpContext.Current.Request["platform_weixin_number"] != null)
				model.platform_weixin_number=Shop.Tools.RequestTool.RequestString("platform_weixin_number");
			if (HttpContext.Current.Request["platform_weixin_id"] != null)
				model.platform_weixin_id=Shop.Tools.RequestTool.RequestString("platform_weixin_id");
			if (HttpContext.Current.Request["platform_weixin_secret"] != null)
				model.platform_weixin_secret=Shop.Tools.RequestTool.RequestString("platform_weixin_secret");
			if (HttpContext.Current.Request["platform_weixin_image_qrcode"] != null)
				model.platform_weixin_image_qrcode=Shop.Tools.RequestTool.RequestString("platform_weixin_image_qrcode");
			if (HttpContext.Current.Request["platform_weixin_custemtoken"] != null)
				model.platform_weixin_custemtoken=Shop.Tools.RequestTool.RequestString("platform_weixin_custemtoken");
			if (HttpContext.Current.Request["platform_weixin_subscribe_automsg"] != null)
				model.platform_weixin_subscribe_automsg=Shop.Tools.RequestTool.RequestString("platform_weixin_subscribe_automsg");
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Site SafeBindForm(Lebi_Site model)
		{
			if (HttpContext.Current.Request["Name"] != null)
				model.Name=Shop.Tools.RequestTool.RequestSafeString("Name");
			if (HttpContext.Current.Request["SubName"] != null)
				model.SubName=Shop.Tools.RequestTool.RequestSafeString("SubName");
			if (HttpContext.Current.Request["Title"] != null)
				model.Title=Shop.Tools.RequestTool.RequestSafeString("Title");
			if (HttpContext.Current.Request["Keywords"] != null)
				model.Keywords=Shop.Tools.RequestTool.RequestSafeString("Keywords");
			if (HttpContext.Current.Request["Description"] != null)
				model.Description=Shop.Tools.RequestTool.RequestSafeString("Description");
			if (HttpContext.Current.Request["Logoimg"] != null)
				model.Logoimg=Shop.Tools.RequestTool.RequestSafeString("Logoimg");
			if (HttpContext.Current.Request["Phone"] != null)
				model.Phone=Shop.Tools.RequestTool.RequestSafeString("Phone");
			if (HttpContext.Current.Request["Fax"] != null)
				model.Fax=Shop.Tools.RequestTool.RequestSafeString("Fax");
			if (HttpContext.Current.Request["Email"] != null)
				model.Email=Shop.Tools.RequestTool.RequestSafeString("Email");
			if (HttpContext.Current.Request["QQ"] != null)
				model.QQ=Shop.Tools.RequestTool.RequestSafeString("QQ");
			if (HttpContext.Current.Request["Copyright"] != null)
				model.Copyright=Shop.Tools.RequestTool.RequestSafeString("Copyright");
			if (HttpContext.Current.Request["ServiceP"] != null)
				model.ServiceP=Shop.Tools.RequestTool.RequestSafeString("ServiceP");
			if (HttpContext.Current.Request["Domain"] != null)
				model.Domain=Shop.Tools.RequestTool.RequestSafeString("Domain");
			if (HttpContext.Current.Request["Sort"] != null)
				model.Sort=Shop.Tools.RequestTool.RequestInt("Sort",0);
			if (HttpContext.Current.Request["Time_add"] != null)
				model.Time_add=Shop.Tools.RequestTool.RequestTime("Time_add", System.DateTime.Now);
			if (HttpContext.Current.Request["Time_Edit"] != null)
				model.Time_Edit=Shop.Tools.RequestTool.RequestTime("Time_Edit", System.DateTime.Now);
			if (HttpContext.Current.Request["Path"] != null)
				model.Path=Shop.Tools.RequestTool.RequestSafeString("Path");
			if (HttpContext.Current.Request["IsMobile"] != null)
				model.IsMobile=Shop.Tools.RequestTool.RequestInt("IsMobile",0);
			if (HttpContext.Current.Request["FootHtml"] != null)
				model.FootHtml=Shop.Tools.RequestTool.RequestSafeString("FootHtml");
			if (HttpContext.Current.Request["platform_weixin_number"] != null)
				model.platform_weixin_number=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_number");
			if (HttpContext.Current.Request["platform_weixin_id"] != null)
				model.platform_weixin_id=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_id");
			if (HttpContext.Current.Request["platform_weixin_secret"] != null)
				model.platform_weixin_secret=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_secret");
			if (HttpContext.Current.Request["platform_weixin_image_qrcode"] != null)
				model.platform_weixin_image_qrcode=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_image_qrcode");
			if (HttpContext.Current.Request["platform_weixin_custemtoken"] != null)
				model.platform_weixin_custemtoken=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_custemtoken");
			if (HttpContext.Current.Request["platform_weixin_subscribe_automsg"] != null)
				model.platform_weixin_subscribe_automsg=Shop.Tools.RequestTool.RequestSafeString("platform_weixin_subscribe_automsg");
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Site ReaderBind(IDataReader dataReader)
		{
			Lebi_Site model=new Lebi_Site();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Name=dataReader["Name"].ToString();
			model.SubName=dataReader["SubName"].ToString();
			model.Title=dataReader["Title"].ToString();
			model.Keywords=dataReader["Keywords"].ToString();
			model.Description=dataReader["Description"].ToString();
			model.Logoimg=dataReader["Logoimg"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			model.Fax=dataReader["Fax"].ToString();
			model.Email=dataReader["Email"].ToString();
			model.QQ=dataReader["QQ"].ToString();
			model.Copyright=dataReader["Copyright"].ToString();
			model.ServiceP=dataReader["ServiceP"].ToString();
			model.Domain=dataReader["Domain"].ToString();
			ojb = dataReader["Sort"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sort=(int)ojb;
			}
			ojb = dataReader["Time_add"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_add=(DateTime)ojb;
			}
			ojb = dataReader["Time_Edit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time_Edit=(DateTime)ojb;
			}
			model.Path=dataReader["Path"].ToString();
			ojb = dataReader["IsMobile"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsMobile=(int)ojb;
			}
			model.FootHtml=dataReader["FootHtml"].ToString();
			model.platform_weixin_number=dataReader["platform_weixin_number"].ToString();
			model.platform_weixin_id=dataReader["platform_weixin_id"].ToString();
			model.platform_weixin_secret=dataReader["platform_weixin_secret"].ToString();
			model.platform_weixin_image_qrcode=dataReader["platform_weixin_image_qrcode"].ToString();
			model.platform_weixin_custemtoken=dataReader["platform_weixin_custemtoken"].ToString();
			model.platform_weixin_subscribe_automsg=dataReader["platform_weixin_subscribe_automsg"].ToString();
			return model;
		}

	}
		#endregion  成员方法
	}
}

