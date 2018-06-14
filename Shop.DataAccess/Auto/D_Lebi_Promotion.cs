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

	public interface Lebi_Promotion_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Promotion model);
		void Update(Lebi_Promotion model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Promotion GetModel(int id);
		Lebi_Promotion GetModel(string strWhere);
		Lebi_Promotion GetModel(SQLPara para);
		List<Lebi_Promotion> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Promotion> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Promotion> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Promotion> GetList(SQLPara para);
		Lebi_Promotion BindForm(Lebi_Promotion model);
		Lebi_Promotion SafeBindForm(Lebi_Promotion model);
		Lebi_Promotion ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Promotion。
	/// </summary>
	public class D_Lebi_Promotion
	{
		static Lebi_Promotion_interface _Instance;
		public static Lebi_Promotion_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Promotion();
		            else
		                _Instance = new sqlserver_Lebi_Promotion();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Promotion()
		{}
		#region  成员方法
	class sqlserver_Lebi_Promotion : Lebi_Promotion_interface
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
				strSql.Append("select " + colName + " from [Lebi_Promotion]");
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
			strSql.Append("select  "+colName+" from [Lebi_Promotion]");
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
			strSql.Append("select count(1) from [Lebi_Promotion]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Promotion]");
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
			strSql.Append("select max(id) from [Lebi_Promotion]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Promotion]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Promotion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Promotion](");
			strSql.Append("Admin_id,Admin_UserName,Remark,Time_Add,Time_Update,Time_Start,Time_End,Sort,Type_id_PromotionStatus,IsSetCase,IsSetRule,Promotion_Type_id,Case801,Case802,Case803,Case806,IsCase801,IsCase802,IsCase803,IsCase804,IsCase805,IsCase806,Rule901,Rule902,Rule903,Rule904,Rule905,Rule906,Rule907,Rule908,Rule909,Rule910,Rule911,IsRule901,IsRule902,IsRule903,IsRule904,IsRule905,IsRule906,IsRule907,IsRule908,IsRule909,IsRule910,IsRule911,Case805,Case804,Rule912,IsRule912)");
			strSql.Append(" values (");
			strSql.Append("@Admin_id,@Admin_UserName,@Remark,@Time_Add,@Time_Update,@Time_Start,@Time_End,@Sort,@Type_id_PromotionStatus,@IsSetCase,@IsSetRule,@Promotion_Type_id,@Case801,@Case802,@Case803,@Case806,@IsCase801,@IsCase802,@IsCase803,@IsCase804,@IsCase805,@IsCase806,@Rule901,@Rule902,@Rule903,@Rule904,@Rule905,@Rule906,@Rule907,@Rule908,@Rule909,@Rule910,@Rule911,@IsRule901,@IsRule902,@IsRule903,@IsRule904,@IsRule905,@IsRule906,@IsRule907,@IsRule908,@IsRule909,@IsRule910,@IsRule911,@Case805,@Case804,@Rule912,@IsRule912)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Admin_id", model.Admin_id),
					new SqlParameter("@Admin_UserName", model.Admin_UserName),
					new SqlParameter("@Remark", model.Remark),
					new SqlParameter("@Time_Add", model.Time_Add),
					new SqlParameter("@Time_Update", model.Time_Update),
					new SqlParameter("@Time_Start", model.Time_Start),
					new SqlParameter("@Time_End", model.Time_End),
					new SqlParameter("@Sort", model.Sort),
					new SqlParameter("@Type_id_PromotionStatus", model.Type_id_PromotionStatus),
					new SqlParameter("@IsSetCase", model.IsSetCase),
					new SqlParameter("@IsSetRule", model.IsSetRule),
					new SqlParameter("@Promotion_Type_id", model.Promotion_Type_id),
					new SqlParameter("@Case801", model.Case801),
					new SqlParameter("@Case802", model.Case802),
					new SqlParameter("@Case803", model.Case803),
					new SqlParameter("@Case806", model.Case806),
					new SqlParameter("@IsCase801", model.IsCase801),
					new SqlParameter("@IsCase802", model.IsCase802),
					new SqlParameter("@IsCase803", model.IsCase803),
					new SqlParameter("@IsCase804", model.IsCase804),
					new SqlParameter("@IsCase805", model.IsCase805),
					new SqlParameter("@IsCase806", model.IsCase806),
					new SqlParameter("@Rule901", model.Rule901),
					new SqlParameter("@Rule902", model.Rule902),
					new SqlParameter("@Rule903", model.Rule903),
					new SqlParameter("@Rule904", model.Rule904),
					new SqlParameter("@Rule905", model.Rule905),
					new SqlParameter("@Rule906", model.Rule906),
					new SqlParameter("@Rule907", model.Rule907),
					new SqlParameter("@Rule908", model.Rule908),
					new SqlParameter("@Rule909", model.Rule909),
					new SqlParameter("@Rule910", model.Rule910),
					new SqlParameter("@Rule911", model.Rule911),
					new SqlParameter("@IsRule901", model.IsRule901),
					new SqlParameter("@IsRule902", model.IsRule902),
					new SqlParameter("@IsRule903", model.IsRule903),
					new SqlParameter("@IsRule904", model.IsRule904),
					new SqlParameter("@IsRule905", model.IsRule905),
					new SqlParameter("@IsRule906", model.IsRule906),
					new SqlParameter("@IsRule907", model.IsRule907),
					new SqlParameter("@IsRule908", model.IsRule908),
					new SqlParameter("@IsRule909", model.IsRule909),
					new SqlParameter("@IsRule910", model.IsRule910),
					new SqlParameter("@IsRule911", model.IsRule911),
					new SqlParameter("@Case805", model.Case805),
					new SqlParameter("@Case804", model.Case804),
					new SqlParameter("@Rule912", model.Rule912),
					new SqlParameter("@IsRule912", model.IsRule912)};

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
		public void Update(Lebi_Promotion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Promotion] set ");
			strSql.Append("Admin_id= @Admin_id,");
			strSql.Append("Admin_UserName= @Admin_UserName,");
			strSql.Append("Remark= @Remark,");
			strSql.Append("Time_Add= @Time_Add,");
			strSql.Append("Time_Update= @Time_Update,");
			strSql.Append("Time_Start= @Time_Start,");
			strSql.Append("Time_End= @Time_End,");
			strSql.Append("Sort= @Sort,");
			strSql.Append("Type_id_PromotionStatus= @Type_id_PromotionStatus,");
			strSql.Append("IsSetCase= @IsSetCase,");
			strSql.Append("IsSetRule= @IsSetRule,");
			strSql.Append("Promotion_Type_id= @Promotion_Type_id,");
			strSql.Append("Case801= @Case801,");
			strSql.Append("Case802= @Case802,");
			strSql.Append("Case803= @Case803,");
			strSql.Append("Case806= @Case806,");
			strSql.Append("IsCase801= @IsCase801,");
			strSql.Append("IsCase802= @IsCase802,");
			strSql.Append("IsCase803= @IsCase803,");
			strSql.Append("IsCase804= @IsCase804,");
			strSql.Append("IsCase805= @IsCase805,");
			strSql.Append("IsCase806= @IsCase806,");
			strSql.Append("Rule901= @Rule901,");
			strSql.Append("Rule902= @Rule902,");
			strSql.Append("Rule903= @Rule903,");
			strSql.Append("Rule904= @Rule904,");
			strSql.Append("Rule905= @Rule905,");
			strSql.Append("Rule906= @Rule906,");
			strSql.Append("Rule907= @Rule907,");
			strSql.Append("Rule908= @Rule908,");
			strSql.Append("Rule909= @Rule909,");
			strSql.Append("Rule910= @Rule910,");
			strSql.Append("Rule911= @Rule911,");
			strSql.Append("IsRule901= @IsRule901,");
			strSql.Append("IsRule902= @IsRule902,");
			strSql.Append("IsRule903= @IsRule903,");
			strSql.Append("IsRule904= @IsRule904,");
			strSql.Append("IsRule905= @IsRule905,");
			strSql.Append("IsRule906= @IsRule906,");
			strSql.Append("IsRule907= @IsRule907,");
			strSql.Append("IsRule908= @IsRule908,");
			strSql.Append("IsRule909= @IsRule909,");
			strSql.Append("IsRule910= @IsRule910,");
			strSql.Append("IsRule911= @IsRule911,");
			strSql.Append("Case805= @Case805,");
			strSql.Append("Case804= @Case804,");
			strSql.Append("Rule912= @Rule912,");
			strSql.Append("IsRule912= @IsRule912");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Admin_id", SqlDbType.Int,4),
					new SqlParameter("@Admin_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@Time_Add", SqlDbType.DateTime),
					new SqlParameter("@Time_Update", SqlDbType.DateTime),
					new SqlParameter("@Time_Start", SqlDbType.DateTime),
					new SqlParameter("@Time_End", SqlDbType.DateTime),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Type_id_PromotionStatus", SqlDbType.Int,4),
					new SqlParameter("@IsSetCase", SqlDbType.Int,4),
					new SqlParameter("@IsSetRule", SqlDbType.Int,4),
					new SqlParameter("@Promotion_Type_id", SqlDbType.Int,4),
					new SqlParameter("@Case801", SqlDbType.Int,4),
					new SqlParameter("@Case802", SqlDbType.Int,4),
					new SqlParameter("@Case803", SqlDbType.Int,4),
					new SqlParameter("@Case806", SqlDbType.Int,4),
					new SqlParameter("@IsCase801", SqlDbType.Int,4),
					new SqlParameter("@IsCase802", SqlDbType.Int,4),
					new SqlParameter("@IsCase803", SqlDbType.Int,4),
					new SqlParameter("@IsCase804", SqlDbType.Int,4),
					new SqlParameter("@IsCase805", SqlDbType.Int,4),
					new SqlParameter("@IsCase806", SqlDbType.Int,4),
					new SqlParameter("@Rule901", SqlDbType.Int,4),
					new SqlParameter("@Rule902", SqlDbType.Int,4),
					new SqlParameter("@Rule903", SqlDbType.Int,4),
					new SqlParameter("@Rule904", SqlDbType.Int,4),
					new SqlParameter("@Rule905", SqlDbType.Int,4),
					new SqlParameter("@Rule906", SqlDbType.Int,4),
					new SqlParameter("@Rule907", SqlDbType.Int,4),
					new SqlParameter("@Rule908", SqlDbType.Int,4),
					new SqlParameter("@Rule909", SqlDbType.NVarChar,500),
					new SqlParameter("@Rule910", SqlDbType.Int,4),
					new SqlParameter("@Rule911", SqlDbType.NVarChar,500),
					new SqlParameter("@IsRule901", SqlDbType.Int,4),
					new SqlParameter("@IsRule902", SqlDbType.Int,4),
					new SqlParameter("@IsRule903", SqlDbType.Int,4),
					new SqlParameter("@IsRule904", SqlDbType.Int,4),
					new SqlParameter("@IsRule905", SqlDbType.Int,4),
					new SqlParameter("@IsRule906", SqlDbType.Int,4),
					new SqlParameter("@IsRule907", SqlDbType.Int,4),
					new SqlParameter("@IsRule908", SqlDbType.Int,4),
					new SqlParameter("@IsRule909", SqlDbType.Int,4),
					new SqlParameter("@IsRule910", SqlDbType.Int,4),
					new SqlParameter("@IsRule911", SqlDbType.Int,4),
					new SqlParameter("@Case805", SqlDbType.NText),
					new SqlParameter("@Case804", SqlDbType.NText),
					new SqlParameter("@Rule912", SqlDbType.Int,4),
					new SqlParameter("@IsRule912", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Admin_id;
			parameters[2].Value = model.Admin_UserName;
			parameters[3].Value = model.Remark;
			parameters[4].Value = model.Time_Add;
			parameters[5].Value = model.Time_Update;
			parameters[6].Value = model.Time_Start;
			parameters[7].Value = model.Time_End;
			parameters[8].Value = model.Sort;
			parameters[9].Value = model.Type_id_PromotionStatus;
			parameters[10].Value = model.IsSetCase;
			parameters[11].Value = model.IsSetRule;
			parameters[12].Value = model.Promotion_Type_id;
			parameters[13].Value = model.Case801;
			parameters[14].Value = model.Case802;
			parameters[15].Value = model.Case803;
			parameters[16].Value = model.Case806;
			parameters[17].Value = model.IsCase801;
			parameters[18].Value = model.IsCase802;
			parameters[19].Value = model.IsCase803;
			parameters[20].Value = model.IsCase804;
			parameters[21].Value = model.IsCase805;
			parameters[22].Value = model.IsCase806;
			parameters[23].Value = model.Rule901;
			parameters[24].Value = model.Rule902;
			parameters[25].Value = model.Rule903;
			parameters[26].Value = model.Rule904;
			parameters[27].Value = model.Rule905;
			parameters[28].Value = model.Rule906;
			parameters[29].Value = model.Rule907;
			parameters[30].Value = model.Rule908;
			parameters[31].Value = model.Rule909;
			parameters[32].Value = model.Rule910;
			parameters[33].Value = model.Rule911;
			parameters[34].Value = model.IsRule901;
			parameters[35].Value = model.IsRule902;
			parameters[36].Value = model.IsRule903;
			parameters[37].Value = model.IsRule904;
			parameters[38].Value = model.IsRule905;
			parameters[39].Value = model.IsRule906;
			parameters[40].Value = model.IsRule907;
			parameters[41].Value = model.IsRule908;
			parameters[42].Value = model.IsRule909;
			parameters[43].Value = model.IsRule910;
			parameters[44].Value = model.IsRule911;
			parameters[45].Value = model.Case805;
			parameters[46].Value = model.Case804;
			parameters[47].Value = model.Rule912;
			parameters[48].Value = model.IsRule912;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Promotion] ");
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
			strSql.Append("delete from [Lebi_Promotion] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Promotion] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Promotion GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Promotion] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Promotion model=new Lebi_Promotion();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
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
				if(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString()!="")
				{
					model.Type_id_PromotionStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSetCase"].ToString()!="")
				{
					model.IsSetCase=int.Parse(ds.Tables[0].Rows[0]["IsSetCase"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSetRule"].ToString()!="")
				{
					model.IsSetRule=int.Parse(ds.Tables[0].Rows[0]["IsSetRule"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Promotion_Type_id"].ToString()!="")
				{
					model.Promotion_Type_id=int.Parse(ds.Tables[0].Rows[0]["Promotion_Type_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case801"].ToString()!="")
				{
					model.Case801=int.Parse(ds.Tables[0].Rows[0]["Case801"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case802"].ToString()!="")
				{
					model.Case802=int.Parse(ds.Tables[0].Rows[0]["Case802"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case803"].ToString()!="")
				{
					model.Case803=int.Parse(ds.Tables[0].Rows[0]["Case803"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case806"].ToString()!="")
				{
					model.Case806=int.Parse(ds.Tables[0].Rows[0]["Case806"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase801"].ToString()!="")
				{
					model.IsCase801=int.Parse(ds.Tables[0].Rows[0]["IsCase801"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase802"].ToString()!="")
				{
					model.IsCase802=int.Parse(ds.Tables[0].Rows[0]["IsCase802"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase803"].ToString()!="")
				{
					model.IsCase803=int.Parse(ds.Tables[0].Rows[0]["IsCase803"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase804"].ToString()!="")
				{
					model.IsCase804=int.Parse(ds.Tables[0].Rows[0]["IsCase804"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase805"].ToString()!="")
				{
					model.IsCase805=int.Parse(ds.Tables[0].Rows[0]["IsCase805"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase806"].ToString()!="")
				{
					model.IsCase806=int.Parse(ds.Tables[0].Rows[0]["IsCase806"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule901"].ToString()!="")
				{
					model.Rule901=int.Parse(ds.Tables[0].Rows[0]["Rule901"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule902"].ToString()!="")
				{
					model.Rule902=int.Parse(ds.Tables[0].Rows[0]["Rule902"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule903"].ToString()!="")
				{
					model.Rule903=int.Parse(ds.Tables[0].Rows[0]["Rule903"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule904"].ToString()!="")
				{
					model.Rule904=int.Parse(ds.Tables[0].Rows[0]["Rule904"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule905"].ToString()!="")
				{
					model.Rule905=int.Parse(ds.Tables[0].Rows[0]["Rule905"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule906"].ToString()!="")
				{
					model.Rule906=int.Parse(ds.Tables[0].Rows[0]["Rule906"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule907"].ToString()!="")
				{
					model.Rule907=int.Parse(ds.Tables[0].Rows[0]["Rule907"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule908"].ToString()!="")
				{
					model.Rule908=int.Parse(ds.Tables[0].Rows[0]["Rule908"].ToString());
				}
				model.Rule909=ds.Tables[0].Rows[0]["Rule909"].ToString();
				if(ds.Tables[0].Rows[0]["Rule910"].ToString()!="")
				{
					model.Rule910=int.Parse(ds.Tables[0].Rows[0]["Rule910"].ToString());
				}
				model.Rule911=ds.Tables[0].Rows[0]["Rule911"].ToString();
				if(ds.Tables[0].Rows[0]["IsRule901"].ToString()!="")
				{
					model.IsRule901=int.Parse(ds.Tables[0].Rows[0]["IsRule901"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule902"].ToString()!="")
				{
					model.IsRule902=int.Parse(ds.Tables[0].Rows[0]["IsRule902"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule903"].ToString()!="")
				{
					model.IsRule903=int.Parse(ds.Tables[0].Rows[0]["IsRule903"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule904"].ToString()!="")
				{
					model.IsRule904=int.Parse(ds.Tables[0].Rows[0]["IsRule904"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule905"].ToString()!="")
				{
					model.IsRule905=int.Parse(ds.Tables[0].Rows[0]["IsRule905"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule906"].ToString()!="")
				{
					model.IsRule906=int.Parse(ds.Tables[0].Rows[0]["IsRule906"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule907"].ToString()!="")
				{
					model.IsRule907=int.Parse(ds.Tables[0].Rows[0]["IsRule907"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule908"].ToString()!="")
				{
					model.IsRule908=int.Parse(ds.Tables[0].Rows[0]["IsRule908"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule909"].ToString()!="")
				{
					model.IsRule909=int.Parse(ds.Tables[0].Rows[0]["IsRule909"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule910"].ToString()!="")
				{
					model.IsRule910=int.Parse(ds.Tables[0].Rows[0]["IsRule910"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule911"].ToString()!="")
				{
					model.IsRule911=int.Parse(ds.Tables[0].Rows[0]["IsRule911"].ToString());
				}
				model.Case805=ds.Tables[0].Rows[0]["Case805"].ToString();
				model.Case804=ds.Tables[0].Rows[0]["Case804"].ToString();
				if(ds.Tables[0].Rows[0]["Rule912"].ToString()!="")
				{
					model.Rule912=int.Parse(ds.Tables[0].Rows[0]["Rule912"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule912"].ToString()!="")
				{
					model.IsRule912=int.Parse(ds.Tables[0].Rows[0]["IsRule912"].ToString());
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
		public Lebi_Promotion GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Promotion] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Promotion model=new Lebi_Promotion();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
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
				if(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString()!="")
				{
					model.Type_id_PromotionStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSetCase"].ToString()!="")
				{
					model.IsSetCase=int.Parse(ds.Tables[0].Rows[0]["IsSetCase"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSetRule"].ToString()!="")
				{
					model.IsSetRule=int.Parse(ds.Tables[0].Rows[0]["IsSetRule"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Promotion_Type_id"].ToString()!="")
				{
					model.Promotion_Type_id=int.Parse(ds.Tables[0].Rows[0]["Promotion_Type_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case801"].ToString()!="")
				{
					model.Case801=int.Parse(ds.Tables[0].Rows[0]["Case801"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case802"].ToString()!="")
				{
					model.Case802=int.Parse(ds.Tables[0].Rows[0]["Case802"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case803"].ToString()!="")
				{
					model.Case803=int.Parse(ds.Tables[0].Rows[0]["Case803"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case806"].ToString()!="")
				{
					model.Case806=int.Parse(ds.Tables[0].Rows[0]["Case806"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase801"].ToString()!="")
				{
					model.IsCase801=int.Parse(ds.Tables[0].Rows[0]["IsCase801"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase802"].ToString()!="")
				{
					model.IsCase802=int.Parse(ds.Tables[0].Rows[0]["IsCase802"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase803"].ToString()!="")
				{
					model.IsCase803=int.Parse(ds.Tables[0].Rows[0]["IsCase803"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase804"].ToString()!="")
				{
					model.IsCase804=int.Parse(ds.Tables[0].Rows[0]["IsCase804"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase805"].ToString()!="")
				{
					model.IsCase805=int.Parse(ds.Tables[0].Rows[0]["IsCase805"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase806"].ToString()!="")
				{
					model.IsCase806=int.Parse(ds.Tables[0].Rows[0]["IsCase806"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule901"].ToString()!="")
				{
					model.Rule901=int.Parse(ds.Tables[0].Rows[0]["Rule901"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule902"].ToString()!="")
				{
					model.Rule902=int.Parse(ds.Tables[0].Rows[0]["Rule902"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule903"].ToString()!="")
				{
					model.Rule903=int.Parse(ds.Tables[0].Rows[0]["Rule903"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule904"].ToString()!="")
				{
					model.Rule904=int.Parse(ds.Tables[0].Rows[0]["Rule904"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule905"].ToString()!="")
				{
					model.Rule905=int.Parse(ds.Tables[0].Rows[0]["Rule905"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule906"].ToString()!="")
				{
					model.Rule906=int.Parse(ds.Tables[0].Rows[0]["Rule906"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule907"].ToString()!="")
				{
					model.Rule907=int.Parse(ds.Tables[0].Rows[0]["Rule907"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule908"].ToString()!="")
				{
					model.Rule908=int.Parse(ds.Tables[0].Rows[0]["Rule908"].ToString());
				}
				model.Rule909=ds.Tables[0].Rows[0]["Rule909"].ToString();
				if(ds.Tables[0].Rows[0]["Rule910"].ToString()!="")
				{
					model.Rule910=int.Parse(ds.Tables[0].Rows[0]["Rule910"].ToString());
				}
				model.Rule911=ds.Tables[0].Rows[0]["Rule911"].ToString();
				if(ds.Tables[0].Rows[0]["IsRule901"].ToString()!="")
				{
					model.IsRule901=int.Parse(ds.Tables[0].Rows[0]["IsRule901"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule902"].ToString()!="")
				{
					model.IsRule902=int.Parse(ds.Tables[0].Rows[0]["IsRule902"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule903"].ToString()!="")
				{
					model.IsRule903=int.Parse(ds.Tables[0].Rows[0]["IsRule903"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule904"].ToString()!="")
				{
					model.IsRule904=int.Parse(ds.Tables[0].Rows[0]["IsRule904"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule905"].ToString()!="")
				{
					model.IsRule905=int.Parse(ds.Tables[0].Rows[0]["IsRule905"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule906"].ToString()!="")
				{
					model.IsRule906=int.Parse(ds.Tables[0].Rows[0]["IsRule906"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule907"].ToString()!="")
				{
					model.IsRule907=int.Parse(ds.Tables[0].Rows[0]["IsRule907"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule908"].ToString()!="")
				{
					model.IsRule908=int.Parse(ds.Tables[0].Rows[0]["IsRule908"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule909"].ToString()!="")
				{
					model.IsRule909=int.Parse(ds.Tables[0].Rows[0]["IsRule909"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule910"].ToString()!="")
				{
					model.IsRule910=int.Parse(ds.Tables[0].Rows[0]["IsRule910"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule911"].ToString()!="")
				{
					model.IsRule911=int.Parse(ds.Tables[0].Rows[0]["IsRule911"].ToString());
				}
				model.Case805=ds.Tables[0].Rows[0]["Case805"].ToString();
				model.Case804=ds.Tables[0].Rows[0]["Case804"].ToString();
				if(ds.Tables[0].Rows[0]["Rule912"].ToString()!="")
				{
					model.Rule912=int.Parse(ds.Tables[0].Rows[0]["Rule912"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule912"].ToString()!="")
				{
					model.IsRule912=int.Parse(ds.Tables[0].Rows[0]["IsRule912"].ToString());
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
		public Lebi_Promotion GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Promotion] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Promotion model=new Lebi_Promotion();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
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
				if(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString()!="")
				{
					model.Type_id_PromotionStatus=int.Parse(ds.Tables[0].Rows[0]["Type_id_PromotionStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSetCase"].ToString()!="")
				{
					model.IsSetCase=int.Parse(ds.Tables[0].Rows[0]["IsSetCase"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSetRule"].ToString()!="")
				{
					model.IsSetRule=int.Parse(ds.Tables[0].Rows[0]["IsSetRule"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Promotion_Type_id"].ToString()!="")
				{
					model.Promotion_Type_id=int.Parse(ds.Tables[0].Rows[0]["Promotion_Type_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case801"].ToString()!="")
				{
					model.Case801=int.Parse(ds.Tables[0].Rows[0]["Case801"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case802"].ToString()!="")
				{
					model.Case802=int.Parse(ds.Tables[0].Rows[0]["Case802"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case803"].ToString()!="")
				{
					model.Case803=int.Parse(ds.Tables[0].Rows[0]["Case803"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Case806"].ToString()!="")
				{
					model.Case806=int.Parse(ds.Tables[0].Rows[0]["Case806"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase801"].ToString()!="")
				{
					model.IsCase801=int.Parse(ds.Tables[0].Rows[0]["IsCase801"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase802"].ToString()!="")
				{
					model.IsCase802=int.Parse(ds.Tables[0].Rows[0]["IsCase802"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase803"].ToString()!="")
				{
					model.IsCase803=int.Parse(ds.Tables[0].Rows[0]["IsCase803"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase804"].ToString()!="")
				{
					model.IsCase804=int.Parse(ds.Tables[0].Rows[0]["IsCase804"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase805"].ToString()!="")
				{
					model.IsCase805=int.Parse(ds.Tables[0].Rows[0]["IsCase805"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCase806"].ToString()!="")
				{
					model.IsCase806=int.Parse(ds.Tables[0].Rows[0]["IsCase806"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule901"].ToString()!="")
				{
					model.Rule901=int.Parse(ds.Tables[0].Rows[0]["Rule901"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule902"].ToString()!="")
				{
					model.Rule902=int.Parse(ds.Tables[0].Rows[0]["Rule902"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule903"].ToString()!="")
				{
					model.Rule903=int.Parse(ds.Tables[0].Rows[0]["Rule903"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule904"].ToString()!="")
				{
					model.Rule904=int.Parse(ds.Tables[0].Rows[0]["Rule904"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule905"].ToString()!="")
				{
					model.Rule905=int.Parse(ds.Tables[0].Rows[0]["Rule905"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule906"].ToString()!="")
				{
					model.Rule906=int.Parse(ds.Tables[0].Rows[0]["Rule906"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule907"].ToString()!="")
				{
					model.Rule907=int.Parse(ds.Tables[0].Rows[0]["Rule907"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule908"].ToString()!="")
				{
					model.Rule908=int.Parse(ds.Tables[0].Rows[0]["Rule908"].ToString());
				}
				model.Rule909=ds.Tables[0].Rows[0]["Rule909"].ToString();
				if(ds.Tables[0].Rows[0]["Rule910"].ToString()!="")
				{
					model.Rule910=int.Parse(ds.Tables[0].Rows[0]["Rule910"].ToString());
				}
				model.Rule911=ds.Tables[0].Rows[0]["Rule911"].ToString();
				if(ds.Tables[0].Rows[0]["IsRule901"].ToString()!="")
				{
					model.IsRule901=int.Parse(ds.Tables[0].Rows[0]["IsRule901"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule902"].ToString()!="")
				{
					model.IsRule902=int.Parse(ds.Tables[0].Rows[0]["IsRule902"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule903"].ToString()!="")
				{
					model.IsRule903=int.Parse(ds.Tables[0].Rows[0]["IsRule903"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule904"].ToString()!="")
				{
					model.IsRule904=int.Parse(ds.Tables[0].Rows[0]["IsRule904"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule905"].ToString()!="")
				{
					model.IsRule905=int.Parse(ds.Tables[0].Rows[0]["IsRule905"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule906"].ToString()!="")
				{
					model.IsRule906=int.Parse(ds.Tables[0].Rows[0]["IsRule906"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule907"].ToString()!="")
				{
					model.IsRule907=int.Parse(ds.Tables[0].Rows[0]["IsRule907"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule908"].ToString()!="")
				{
					model.IsRule908=int.Parse(ds.Tables[0].Rows[0]["IsRule908"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule909"].ToString()!="")
				{
					model.IsRule909=int.Parse(ds.Tables[0].Rows[0]["IsRule909"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule910"].ToString()!="")
				{
					model.IsRule910=int.Parse(ds.Tables[0].Rows[0]["IsRule910"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule911"].ToString()!="")
				{
					model.IsRule911=int.Parse(ds.Tables[0].Rows[0]["IsRule911"].ToString());
				}
				model.Case805=ds.Tables[0].Rows[0]["Case805"].ToString();
				model.Case804=ds.Tables[0].Rows[0]["Case804"].ToString();
				if(ds.Tables[0].Rows[0]["Rule912"].ToString()!="")
				{
					model.Rule912=int.Parse(ds.Tables[0].Rows[0]["Rule912"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRule912"].ToString()!="")
				{
					model.IsRule912=int.Parse(ds.Tables[0].Rows[0]["IsRule912"].ToString());
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
		public List<Lebi_Promotion> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Promotion]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Promotion> list = new List<Lebi_Promotion>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Promotion> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Promotion]";
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
			List<Lebi_Promotion> list = new List<Lebi_Promotion>();
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
		public List<Lebi_Promotion> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Promotion] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Promotion> list = new List<Lebi_Promotion>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Promotion> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Promotion]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Promotion> list = new List<Lebi_Promotion>();
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
		public Lebi_Promotion BindForm(Lebi_Promotion model)
		{
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
			if (HttpContext.Current.Request["Type_id_PromotionStatus"] != null)
				model.Type_id_PromotionStatus=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionStatus",0);
			if (HttpContext.Current.Request["IsSetCase"] != null)
				model.IsSetCase=Shop.Tools.RequestTool.RequestInt("IsSetCase",0);
			if (HttpContext.Current.Request["IsSetRule"] != null)
				model.IsSetRule=Shop.Tools.RequestTool.RequestInt("IsSetRule",0);
			if (HttpContext.Current.Request["Promotion_Type_id"] != null)
				model.Promotion_Type_id=Shop.Tools.RequestTool.RequestInt("Promotion_Type_id",0);
			if (HttpContext.Current.Request["Case801"] != null)
				model.Case801=Shop.Tools.RequestTool.RequestInt("Case801",0);
			if (HttpContext.Current.Request["Case802"] != null)
				model.Case802=Shop.Tools.RequestTool.RequestInt("Case802",0);
			if (HttpContext.Current.Request["Case803"] != null)
				model.Case803=Shop.Tools.RequestTool.RequestInt("Case803",0);
			if (HttpContext.Current.Request["Case806"] != null)
				model.Case806=Shop.Tools.RequestTool.RequestInt("Case806",0);
			if (HttpContext.Current.Request["IsCase801"] != null)
				model.IsCase801=Shop.Tools.RequestTool.RequestInt("IsCase801",0);
			if (HttpContext.Current.Request["IsCase802"] != null)
				model.IsCase802=Shop.Tools.RequestTool.RequestInt("IsCase802",0);
			if (HttpContext.Current.Request["IsCase803"] != null)
				model.IsCase803=Shop.Tools.RequestTool.RequestInt("IsCase803",0);
			if (HttpContext.Current.Request["IsCase804"] != null)
				model.IsCase804=Shop.Tools.RequestTool.RequestInt("IsCase804",0);
			if (HttpContext.Current.Request["IsCase805"] != null)
				model.IsCase805=Shop.Tools.RequestTool.RequestInt("IsCase805",0);
			if (HttpContext.Current.Request["IsCase806"] != null)
				model.IsCase806=Shop.Tools.RequestTool.RequestInt("IsCase806",0);
			if (HttpContext.Current.Request["Rule901"] != null)
				model.Rule901=Shop.Tools.RequestTool.RequestInt("Rule901",0);
			if (HttpContext.Current.Request["Rule902"] != null)
				model.Rule902=Shop.Tools.RequestTool.RequestInt("Rule902",0);
			if (HttpContext.Current.Request["Rule903"] != null)
				model.Rule903=Shop.Tools.RequestTool.RequestInt("Rule903",0);
			if (HttpContext.Current.Request["Rule904"] != null)
				model.Rule904=Shop.Tools.RequestTool.RequestInt("Rule904",0);
			if (HttpContext.Current.Request["Rule905"] != null)
				model.Rule905=Shop.Tools.RequestTool.RequestInt("Rule905",0);
			if (HttpContext.Current.Request["Rule906"] != null)
				model.Rule906=Shop.Tools.RequestTool.RequestInt("Rule906",0);
			if (HttpContext.Current.Request["Rule907"] != null)
				model.Rule907=Shop.Tools.RequestTool.RequestInt("Rule907",0);
			if (HttpContext.Current.Request["Rule908"] != null)
				model.Rule908=Shop.Tools.RequestTool.RequestInt("Rule908",0);
			if (HttpContext.Current.Request["Rule909"] != null)
				model.Rule909=Shop.Tools.RequestTool.RequestString("Rule909");
			if (HttpContext.Current.Request["Rule910"] != null)
				model.Rule910=Shop.Tools.RequestTool.RequestInt("Rule910",0);
			if (HttpContext.Current.Request["Rule911"] != null)
				model.Rule911=Shop.Tools.RequestTool.RequestString("Rule911");
			if (HttpContext.Current.Request["IsRule901"] != null)
				model.IsRule901=Shop.Tools.RequestTool.RequestInt("IsRule901",0);
			if (HttpContext.Current.Request["IsRule902"] != null)
				model.IsRule902=Shop.Tools.RequestTool.RequestInt("IsRule902",0);
			if (HttpContext.Current.Request["IsRule903"] != null)
				model.IsRule903=Shop.Tools.RequestTool.RequestInt("IsRule903",0);
			if (HttpContext.Current.Request["IsRule904"] != null)
				model.IsRule904=Shop.Tools.RequestTool.RequestInt("IsRule904",0);
			if (HttpContext.Current.Request["IsRule905"] != null)
				model.IsRule905=Shop.Tools.RequestTool.RequestInt("IsRule905",0);
			if (HttpContext.Current.Request["IsRule906"] != null)
				model.IsRule906=Shop.Tools.RequestTool.RequestInt("IsRule906",0);
			if (HttpContext.Current.Request["IsRule907"] != null)
				model.IsRule907=Shop.Tools.RequestTool.RequestInt("IsRule907",0);
			if (HttpContext.Current.Request["IsRule908"] != null)
				model.IsRule908=Shop.Tools.RequestTool.RequestInt("IsRule908",0);
			if (HttpContext.Current.Request["IsRule909"] != null)
				model.IsRule909=Shop.Tools.RequestTool.RequestInt("IsRule909",0);
			if (HttpContext.Current.Request["IsRule910"] != null)
				model.IsRule910=Shop.Tools.RequestTool.RequestInt("IsRule910",0);
			if (HttpContext.Current.Request["IsRule911"] != null)
				model.IsRule911=Shop.Tools.RequestTool.RequestInt("IsRule911",0);
			if (HttpContext.Current.Request["Case805"] != null)
				model.Case805=Shop.Tools.RequestTool.RequestString("Case805");
			if (HttpContext.Current.Request["Case804"] != null)
				model.Case804=Shop.Tools.RequestTool.RequestString("Case804");
			if (HttpContext.Current.Request["Rule912"] != null)
				model.Rule912=Shop.Tools.RequestTool.RequestInt("Rule912",0);
			if (HttpContext.Current.Request["IsRule912"] != null)
				model.IsRule912=Shop.Tools.RequestTool.RequestInt("IsRule912",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Promotion SafeBindForm(Lebi_Promotion model)
		{
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
			if (HttpContext.Current.Request["Type_id_PromotionStatus"] != null)
				model.Type_id_PromotionStatus=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionStatus",0);
			if (HttpContext.Current.Request["IsSetCase"] != null)
				model.IsSetCase=Shop.Tools.RequestTool.RequestInt("IsSetCase",0);
			if (HttpContext.Current.Request["IsSetRule"] != null)
				model.IsSetRule=Shop.Tools.RequestTool.RequestInt("IsSetRule",0);
			if (HttpContext.Current.Request["Promotion_Type_id"] != null)
				model.Promotion_Type_id=Shop.Tools.RequestTool.RequestInt("Promotion_Type_id",0);
			if (HttpContext.Current.Request["Case801"] != null)
				model.Case801=Shop.Tools.RequestTool.RequestInt("Case801",0);
			if (HttpContext.Current.Request["Case802"] != null)
				model.Case802=Shop.Tools.RequestTool.RequestInt("Case802",0);
			if (HttpContext.Current.Request["Case803"] != null)
				model.Case803=Shop.Tools.RequestTool.RequestInt("Case803",0);
			if (HttpContext.Current.Request["Case806"] != null)
				model.Case806=Shop.Tools.RequestTool.RequestInt("Case806",0);
			if (HttpContext.Current.Request["IsCase801"] != null)
				model.IsCase801=Shop.Tools.RequestTool.RequestInt("IsCase801",0);
			if (HttpContext.Current.Request["IsCase802"] != null)
				model.IsCase802=Shop.Tools.RequestTool.RequestInt("IsCase802",0);
			if (HttpContext.Current.Request["IsCase803"] != null)
				model.IsCase803=Shop.Tools.RequestTool.RequestInt("IsCase803",0);
			if (HttpContext.Current.Request["IsCase804"] != null)
				model.IsCase804=Shop.Tools.RequestTool.RequestInt("IsCase804",0);
			if (HttpContext.Current.Request["IsCase805"] != null)
				model.IsCase805=Shop.Tools.RequestTool.RequestInt("IsCase805",0);
			if (HttpContext.Current.Request["IsCase806"] != null)
				model.IsCase806=Shop.Tools.RequestTool.RequestInt("IsCase806",0);
			if (HttpContext.Current.Request["Rule901"] != null)
				model.Rule901=Shop.Tools.RequestTool.RequestInt("Rule901",0);
			if (HttpContext.Current.Request["Rule902"] != null)
				model.Rule902=Shop.Tools.RequestTool.RequestInt("Rule902",0);
			if (HttpContext.Current.Request["Rule903"] != null)
				model.Rule903=Shop.Tools.RequestTool.RequestInt("Rule903",0);
			if (HttpContext.Current.Request["Rule904"] != null)
				model.Rule904=Shop.Tools.RequestTool.RequestInt("Rule904",0);
			if (HttpContext.Current.Request["Rule905"] != null)
				model.Rule905=Shop.Tools.RequestTool.RequestInt("Rule905",0);
			if (HttpContext.Current.Request["Rule906"] != null)
				model.Rule906=Shop.Tools.RequestTool.RequestInt("Rule906",0);
			if (HttpContext.Current.Request["Rule907"] != null)
				model.Rule907=Shop.Tools.RequestTool.RequestInt("Rule907",0);
			if (HttpContext.Current.Request["Rule908"] != null)
				model.Rule908=Shop.Tools.RequestTool.RequestInt("Rule908",0);
			if (HttpContext.Current.Request["Rule909"] != null)
				model.Rule909=Shop.Tools.RequestTool.RequestSafeString("Rule909");
			if (HttpContext.Current.Request["Rule910"] != null)
				model.Rule910=Shop.Tools.RequestTool.RequestInt("Rule910",0);
			if (HttpContext.Current.Request["Rule911"] != null)
				model.Rule911=Shop.Tools.RequestTool.RequestSafeString("Rule911");
			if (HttpContext.Current.Request["IsRule901"] != null)
				model.IsRule901=Shop.Tools.RequestTool.RequestInt("IsRule901",0);
			if (HttpContext.Current.Request["IsRule902"] != null)
				model.IsRule902=Shop.Tools.RequestTool.RequestInt("IsRule902",0);
			if (HttpContext.Current.Request["IsRule903"] != null)
				model.IsRule903=Shop.Tools.RequestTool.RequestInt("IsRule903",0);
			if (HttpContext.Current.Request["IsRule904"] != null)
				model.IsRule904=Shop.Tools.RequestTool.RequestInt("IsRule904",0);
			if (HttpContext.Current.Request["IsRule905"] != null)
				model.IsRule905=Shop.Tools.RequestTool.RequestInt("IsRule905",0);
			if (HttpContext.Current.Request["IsRule906"] != null)
				model.IsRule906=Shop.Tools.RequestTool.RequestInt("IsRule906",0);
			if (HttpContext.Current.Request["IsRule907"] != null)
				model.IsRule907=Shop.Tools.RequestTool.RequestInt("IsRule907",0);
			if (HttpContext.Current.Request["IsRule908"] != null)
				model.IsRule908=Shop.Tools.RequestTool.RequestInt("IsRule908",0);
			if (HttpContext.Current.Request["IsRule909"] != null)
				model.IsRule909=Shop.Tools.RequestTool.RequestInt("IsRule909",0);
			if (HttpContext.Current.Request["IsRule910"] != null)
				model.IsRule910=Shop.Tools.RequestTool.RequestInt("IsRule910",0);
			if (HttpContext.Current.Request["IsRule911"] != null)
				model.IsRule911=Shop.Tools.RequestTool.RequestInt("IsRule911",0);
			if (HttpContext.Current.Request["Case805"] != null)
				model.Case805=Shop.Tools.RequestTool.RequestSafeString("Case805");
			if (HttpContext.Current.Request["Case804"] != null)
				model.Case804=Shop.Tools.RequestTool.RequestSafeString("Case804");
			if (HttpContext.Current.Request["Rule912"] != null)
				model.Rule912=Shop.Tools.RequestTool.RequestInt("Rule912",0);
			if (HttpContext.Current.Request["IsRule912"] != null)
				model.IsRule912=Shop.Tools.RequestTool.RequestInt("IsRule912",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Promotion ReaderBind(IDataReader dataReader)
		{
			Lebi_Promotion model=new Lebi_Promotion();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
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
			ojb = dataReader["Type_id_PromotionStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_PromotionStatus=(int)ojb;
			}
			ojb = dataReader["IsSetCase"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSetCase=(int)ojb;
			}
			ojb = dataReader["IsSetRule"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSetRule=(int)ojb;
			}
			ojb = dataReader["Promotion_Type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Promotion_Type_id=(int)ojb;
			}
			ojb = dataReader["Case801"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Case801=(int)ojb;
			}
			ojb = dataReader["Case802"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Case802=(int)ojb;
			}
			ojb = dataReader["Case803"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Case803=(int)ojb;
			}
			ojb = dataReader["Case806"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Case806=(int)ojb;
			}
			ojb = dataReader["IsCase801"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase801=(int)ojb;
			}
			ojb = dataReader["IsCase802"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase802=(int)ojb;
			}
			ojb = dataReader["IsCase803"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase803=(int)ojb;
			}
			ojb = dataReader["IsCase804"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase804=(int)ojb;
			}
			ojb = dataReader["IsCase805"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase805=(int)ojb;
			}
			ojb = dataReader["IsCase806"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase806=(int)ojb;
			}
			ojb = dataReader["Rule901"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule901=(int)ojb;
			}
			ojb = dataReader["Rule902"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule902=(int)ojb;
			}
			ojb = dataReader["Rule903"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule903=(int)ojb;
			}
			ojb = dataReader["Rule904"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule904=(int)ojb;
			}
			ojb = dataReader["Rule905"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule905=(int)ojb;
			}
			ojb = dataReader["Rule906"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule906=(int)ojb;
			}
			ojb = dataReader["Rule907"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule907=(int)ojb;
			}
			ojb = dataReader["Rule908"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule908=(int)ojb;
			}
			model.Rule909=dataReader["Rule909"].ToString();
			ojb = dataReader["Rule910"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule910=(int)ojb;
			}
			model.Rule911=dataReader["Rule911"].ToString();
			ojb = dataReader["IsRule901"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule901=(int)ojb;
			}
			ojb = dataReader["IsRule902"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule902=(int)ojb;
			}
			ojb = dataReader["IsRule903"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule903=(int)ojb;
			}
			ojb = dataReader["IsRule904"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule904=(int)ojb;
			}
			ojb = dataReader["IsRule905"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule905=(int)ojb;
			}
			ojb = dataReader["IsRule906"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule906=(int)ojb;
			}
			ojb = dataReader["IsRule907"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule907=(int)ojb;
			}
			ojb = dataReader["IsRule908"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule908=(int)ojb;
			}
			ojb = dataReader["IsRule909"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule909=(int)ojb;
			}
			ojb = dataReader["IsRule910"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule910=(int)ojb;
			}
			ojb = dataReader["IsRule911"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule911=(int)ojb;
			}
			model.Case805=dataReader["Case805"].ToString();
			model.Case804=dataReader["Case804"].ToString();
			ojb = dataReader["Rule912"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule912=(int)ojb;
			}
			ojb = dataReader["IsRule912"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule912=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Promotion : Lebi_Promotion_interface
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
				strSql.Append("select " + colName + " from [Lebi_Promotion]");
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
			strSql.Append("select  "+colName+" from [Lebi_Promotion]");
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
			strSql.Append("select count(*) from [Lebi_Promotion]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Promotion]");
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
			strSql.Append("select max(id) from [Lebi_Promotion]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Promotion]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Promotion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Promotion](");
			strSql.Append("[Admin_id],[Admin_UserName],[Remark],[Time_Add],[Time_Update],[Time_Start],[Time_End],[Sort],[Type_id_PromotionStatus],[IsSetCase],[IsSetRule],[Promotion_Type_id],[Case801],[Case802],[Case803],[Case806],[IsCase801],[IsCase802],[IsCase803],[IsCase804],[IsCase805],[IsCase806],[Rule901],[Rule902],[Rule903],[Rule904],[Rule905],[Rule906],[Rule907],[Rule908],[Rule909],[Rule910],[Rule911],[IsRule901],[IsRule902],[IsRule903],[IsRule904],[IsRule905],[IsRule906],[IsRule907],[IsRule908],[IsRule909],[IsRule910],[IsRule911],[Case805],[Case804],[Rule912],[IsRule912])");
			strSql.Append(" values (");
			strSql.Append("@Admin_id,@Admin_UserName,@Remark,@Time_Add,@Time_Update,@Time_Start,@Time_End,@Sort,@Type_id_PromotionStatus,@IsSetCase,@IsSetRule,@Promotion_Type_id,@Case801,@Case802,@Case803,@Case806,@IsCase801,@IsCase802,@IsCase803,@IsCase804,@IsCase805,@IsCase806,@Rule901,@Rule902,@Rule903,@Rule904,@Rule905,@Rule906,@Rule907,@Rule908,@Rule909,@Rule910,@Rule911,@IsRule901,@IsRule902,@IsRule903,@IsRule904,@IsRule905,@IsRule906,@IsRule907,@IsRule908,@IsRule909,@IsRule910,@IsRule911,@Case805,@Case804,@Rule912,@IsRule912)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Start", model.Time_Start.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Type_id_PromotionStatus", model.Type_id_PromotionStatus),
					new OleDbParameter("@IsSetCase", model.IsSetCase),
					new OleDbParameter("@IsSetRule", model.IsSetRule),
					new OleDbParameter("@Promotion_Type_id", model.Promotion_Type_id),
					new OleDbParameter("@Case801", model.Case801),
					new OleDbParameter("@Case802", model.Case802),
					new OleDbParameter("@Case803", model.Case803),
					new OleDbParameter("@Case806", model.Case806),
					new OleDbParameter("@IsCase801", model.IsCase801),
					new OleDbParameter("@IsCase802", model.IsCase802),
					new OleDbParameter("@IsCase803", model.IsCase803),
					new OleDbParameter("@IsCase804", model.IsCase804),
					new OleDbParameter("@IsCase805", model.IsCase805),
					new OleDbParameter("@IsCase806", model.IsCase806),
					new OleDbParameter("@Rule901", model.Rule901),
					new OleDbParameter("@Rule902", model.Rule902),
					new OleDbParameter("@Rule903", model.Rule903),
					new OleDbParameter("@Rule904", model.Rule904),
					new OleDbParameter("@Rule905", model.Rule905),
					new OleDbParameter("@Rule906", model.Rule906),
					new OleDbParameter("@Rule907", model.Rule907),
					new OleDbParameter("@Rule908", model.Rule908),
					new OleDbParameter("@Rule909", model.Rule909),
					new OleDbParameter("@Rule910", model.Rule910),
					new OleDbParameter("@Rule911", model.Rule911),
					new OleDbParameter("@IsRule901", model.IsRule901),
					new OleDbParameter("@IsRule902", model.IsRule902),
					new OleDbParameter("@IsRule903", model.IsRule903),
					new OleDbParameter("@IsRule904", model.IsRule904),
					new OleDbParameter("@IsRule905", model.IsRule905),
					new OleDbParameter("@IsRule906", model.IsRule906),
					new OleDbParameter("@IsRule907", model.IsRule907),
					new OleDbParameter("@IsRule908", model.IsRule908),
					new OleDbParameter("@IsRule909", model.IsRule909),
					new OleDbParameter("@IsRule910", model.IsRule910),
					new OleDbParameter("@IsRule911", model.IsRule911),
					new OleDbParameter("@Case805", model.Case805),
					new OleDbParameter("@Case804", model.Case804),
					new OleDbParameter("@Rule912", model.Rule912),
					new OleDbParameter("@IsRule912", model.IsRule912)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Promotion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Promotion] set ");
			strSql.Append("[Admin_id]=@Admin_id,");
			strSql.Append("[Admin_UserName]=@Admin_UserName,");
			strSql.Append("[Remark]=@Remark,");
			strSql.Append("[Time_Add]=@Time_Add,");
			strSql.Append("[Time_Update]=@Time_Update,");
			strSql.Append("[Time_Start]=@Time_Start,");
			strSql.Append("[Time_End]=@Time_End,");
			strSql.Append("[Sort]=@Sort,");
			strSql.Append("[Type_id_PromotionStatus]=@Type_id_PromotionStatus,");
			strSql.Append("[IsSetCase]=@IsSetCase,");
			strSql.Append("[IsSetRule]=@IsSetRule,");
			strSql.Append("[Promotion_Type_id]=@Promotion_Type_id,");
			strSql.Append("[Case801]=@Case801,");
			strSql.Append("[Case802]=@Case802,");
			strSql.Append("[Case803]=@Case803,");
			strSql.Append("[Case806]=@Case806,");
			strSql.Append("[IsCase801]=@IsCase801,");
			strSql.Append("[IsCase802]=@IsCase802,");
			strSql.Append("[IsCase803]=@IsCase803,");
			strSql.Append("[IsCase804]=@IsCase804,");
			strSql.Append("[IsCase805]=@IsCase805,");
			strSql.Append("[IsCase806]=@IsCase806,");
			strSql.Append("[Rule901]=@Rule901,");
			strSql.Append("[Rule902]=@Rule902,");
			strSql.Append("[Rule903]=@Rule903,");
			strSql.Append("[Rule904]=@Rule904,");
			strSql.Append("[Rule905]=@Rule905,");
			strSql.Append("[Rule906]=@Rule906,");
			strSql.Append("[Rule907]=@Rule907,");
			strSql.Append("[Rule908]=@Rule908,");
			strSql.Append("[Rule909]=@Rule909,");
			strSql.Append("[Rule910]=@Rule910,");
			strSql.Append("[Rule911]=@Rule911,");
			strSql.Append("[IsRule901]=@IsRule901,");
			strSql.Append("[IsRule902]=@IsRule902,");
			strSql.Append("[IsRule903]=@IsRule903,");
			strSql.Append("[IsRule904]=@IsRule904,");
			strSql.Append("[IsRule905]=@IsRule905,");
			strSql.Append("[IsRule906]=@IsRule906,");
			strSql.Append("[IsRule907]=@IsRule907,");
			strSql.Append("[IsRule908]=@IsRule908,");
			strSql.Append("[IsRule909]=@IsRule909,");
			strSql.Append("[IsRule910]=@IsRule910,");
			strSql.Append("[IsRule911]=@IsRule911,");
			strSql.Append("[Case805]=@Case805,");
			strSql.Append("[Case804]=@Case804,");
			strSql.Append("[Rule912]=@Rule912,");
			strSql.Append("[IsRule912]=@IsRule912");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@Admin_id", model.Admin_id),
					new OleDbParameter("@Admin_UserName", model.Admin_UserName),
					new OleDbParameter("@Remark", model.Remark),
					new OleDbParameter("@Time_Add", model.Time_Add.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Update", model.Time_Update.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_Start", model.Time_Start.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Time_End", model.Time_End.ToString("yyyy-MM-dd HH:mm:ss")),
					new OleDbParameter("@Sort", model.Sort),
					new OleDbParameter("@Type_id_PromotionStatus", model.Type_id_PromotionStatus),
					new OleDbParameter("@IsSetCase", model.IsSetCase),
					new OleDbParameter("@IsSetRule", model.IsSetRule),
					new OleDbParameter("@Promotion_Type_id", model.Promotion_Type_id),
					new OleDbParameter("@Case801", model.Case801),
					new OleDbParameter("@Case802", model.Case802),
					new OleDbParameter("@Case803", model.Case803),
					new OleDbParameter("@Case806", model.Case806),
					new OleDbParameter("@IsCase801", model.IsCase801),
					new OleDbParameter("@IsCase802", model.IsCase802),
					new OleDbParameter("@IsCase803", model.IsCase803),
					new OleDbParameter("@IsCase804", model.IsCase804),
					new OleDbParameter("@IsCase805", model.IsCase805),
					new OleDbParameter("@IsCase806", model.IsCase806),
					new OleDbParameter("@Rule901", model.Rule901),
					new OleDbParameter("@Rule902", model.Rule902),
					new OleDbParameter("@Rule903", model.Rule903),
					new OleDbParameter("@Rule904", model.Rule904),
					new OleDbParameter("@Rule905", model.Rule905),
					new OleDbParameter("@Rule906", model.Rule906),
					new OleDbParameter("@Rule907", model.Rule907),
					new OleDbParameter("@Rule908", model.Rule908),
					new OleDbParameter("@Rule909", model.Rule909),
					new OleDbParameter("@Rule910", model.Rule910),
					new OleDbParameter("@Rule911", model.Rule911),
					new OleDbParameter("@IsRule901", model.IsRule901),
					new OleDbParameter("@IsRule902", model.IsRule902),
					new OleDbParameter("@IsRule903", model.IsRule903),
					new OleDbParameter("@IsRule904", model.IsRule904),
					new OleDbParameter("@IsRule905", model.IsRule905),
					new OleDbParameter("@IsRule906", model.IsRule906),
					new OleDbParameter("@IsRule907", model.IsRule907),
					new OleDbParameter("@IsRule908", model.IsRule908),
					new OleDbParameter("@IsRule909", model.IsRule909),
					new OleDbParameter("@IsRule910", model.IsRule910),
					new OleDbParameter("@IsRule911", model.IsRule911),
					new OleDbParameter("@Case805", model.Case805),
					new OleDbParameter("@Case804", model.Case804),
					new OleDbParameter("@Rule912", model.Rule912),
					new OleDbParameter("@IsRule912", model.IsRule912)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Promotion] ");
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
			strSql.Append("delete from [Lebi_Promotion] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Promotion] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Promotion GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Promotion] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Promotion model;
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
		public Lebi_Promotion GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Promotion] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Promotion model;
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
		public Lebi_Promotion GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Promotion] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Promotion model;
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
		public List<Lebi_Promotion> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Promotion]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Promotion> list = new List<Lebi_Promotion>();
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
		public List<Lebi_Promotion> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Promotion]";
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
			List<Lebi_Promotion> list = new List<Lebi_Promotion>();
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
		public List<Lebi_Promotion> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Promotion] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Promotion> list = new List<Lebi_Promotion>();
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
		public List<Lebi_Promotion> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Promotion]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Promotion> list = new List<Lebi_Promotion>();
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
		public Lebi_Promotion BindForm(Lebi_Promotion model)
		{
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
			if (HttpContext.Current.Request["Type_id_PromotionStatus"] != null)
				model.Type_id_PromotionStatus=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionStatus",0);
			if (HttpContext.Current.Request["IsSetCase"] != null)
				model.IsSetCase=Shop.Tools.RequestTool.RequestInt("IsSetCase",0);
			if (HttpContext.Current.Request["IsSetRule"] != null)
				model.IsSetRule=Shop.Tools.RequestTool.RequestInt("IsSetRule",0);
			if (HttpContext.Current.Request["Promotion_Type_id"] != null)
				model.Promotion_Type_id=Shop.Tools.RequestTool.RequestInt("Promotion_Type_id",0);
			if (HttpContext.Current.Request["Case801"] != null)
				model.Case801=Shop.Tools.RequestTool.RequestInt("Case801",0);
			if (HttpContext.Current.Request["Case802"] != null)
				model.Case802=Shop.Tools.RequestTool.RequestInt("Case802",0);
			if (HttpContext.Current.Request["Case803"] != null)
				model.Case803=Shop.Tools.RequestTool.RequestInt("Case803",0);
			if (HttpContext.Current.Request["Case806"] != null)
				model.Case806=Shop.Tools.RequestTool.RequestInt("Case806",0);
			if (HttpContext.Current.Request["IsCase801"] != null)
				model.IsCase801=Shop.Tools.RequestTool.RequestInt("IsCase801",0);
			if (HttpContext.Current.Request["IsCase802"] != null)
				model.IsCase802=Shop.Tools.RequestTool.RequestInt("IsCase802",0);
			if (HttpContext.Current.Request["IsCase803"] != null)
				model.IsCase803=Shop.Tools.RequestTool.RequestInt("IsCase803",0);
			if (HttpContext.Current.Request["IsCase804"] != null)
				model.IsCase804=Shop.Tools.RequestTool.RequestInt("IsCase804",0);
			if (HttpContext.Current.Request["IsCase805"] != null)
				model.IsCase805=Shop.Tools.RequestTool.RequestInt("IsCase805",0);
			if (HttpContext.Current.Request["IsCase806"] != null)
				model.IsCase806=Shop.Tools.RequestTool.RequestInt("IsCase806",0);
			if (HttpContext.Current.Request["Rule901"] != null)
				model.Rule901=Shop.Tools.RequestTool.RequestInt("Rule901",0);
			if (HttpContext.Current.Request["Rule902"] != null)
				model.Rule902=Shop.Tools.RequestTool.RequestInt("Rule902",0);
			if (HttpContext.Current.Request["Rule903"] != null)
				model.Rule903=Shop.Tools.RequestTool.RequestInt("Rule903",0);
			if (HttpContext.Current.Request["Rule904"] != null)
				model.Rule904=Shop.Tools.RequestTool.RequestInt("Rule904",0);
			if (HttpContext.Current.Request["Rule905"] != null)
				model.Rule905=Shop.Tools.RequestTool.RequestInt("Rule905",0);
			if (HttpContext.Current.Request["Rule906"] != null)
				model.Rule906=Shop.Tools.RequestTool.RequestInt("Rule906",0);
			if (HttpContext.Current.Request["Rule907"] != null)
				model.Rule907=Shop.Tools.RequestTool.RequestInt("Rule907",0);
			if (HttpContext.Current.Request["Rule908"] != null)
				model.Rule908=Shop.Tools.RequestTool.RequestInt("Rule908",0);
			if (HttpContext.Current.Request["Rule909"] != null)
				model.Rule909=Shop.Tools.RequestTool.RequestString("Rule909");
			if (HttpContext.Current.Request["Rule910"] != null)
				model.Rule910=Shop.Tools.RequestTool.RequestInt("Rule910",0);
			if (HttpContext.Current.Request["Rule911"] != null)
				model.Rule911=Shop.Tools.RequestTool.RequestString("Rule911");
			if (HttpContext.Current.Request["IsRule901"] != null)
				model.IsRule901=Shop.Tools.RequestTool.RequestInt("IsRule901",0);
			if (HttpContext.Current.Request["IsRule902"] != null)
				model.IsRule902=Shop.Tools.RequestTool.RequestInt("IsRule902",0);
			if (HttpContext.Current.Request["IsRule903"] != null)
				model.IsRule903=Shop.Tools.RequestTool.RequestInt("IsRule903",0);
			if (HttpContext.Current.Request["IsRule904"] != null)
				model.IsRule904=Shop.Tools.RequestTool.RequestInt("IsRule904",0);
			if (HttpContext.Current.Request["IsRule905"] != null)
				model.IsRule905=Shop.Tools.RequestTool.RequestInt("IsRule905",0);
			if (HttpContext.Current.Request["IsRule906"] != null)
				model.IsRule906=Shop.Tools.RequestTool.RequestInt("IsRule906",0);
			if (HttpContext.Current.Request["IsRule907"] != null)
				model.IsRule907=Shop.Tools.RequestTool.RequestInt("IsRule907",0);
			if (HttpContext.Current.Request["IsRule908"] != null)
				model.IsRule908=Shop.Tools.RequestTool.RequestInt("IsRule908",0);
			if (HttpContext.Current.Request["IsRule909"] != null)
				model.IsRule909=Shop.Tools.RequestTool.RequestInt("IsRule909",0);
			if (HttpContext.Current.Request["IsRule910"] != null)
				model.IsRule910=Shop.Tools.RequestTool.RequestInt("IsRule910",0);
			if (HttpContext.Current.Request["IsRule911"] != null)
				model.IsRule911=Shop.Tools.RequestTool.RequestInt("IsRule911",0);
			if (HttpContext.Current.Request["Case805"] != null)
				model.Case805=Shop.Tools.RequestTool.RequestString("Case805");
			if (HttpContext.Current.Request["Case804"] != null)
				model.Case804=Shop.Tools.RequestTool.RequestString("Case804");
			if (HttpContext.Current.Request["Rule912"] != null)
				model.Rule912=Shop.Tools.RequestTool.RequestInt("Rule912",0);
			if (HttpContext.Current.Request["IsRule912"] != null)
				model.IsRule912=Shop.Tools.RequestTool.RequestInt("IsRule912",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Promotion SafeBindForm(Lebi_Promotion model)
		{
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
			if (HttpContext.Current.Request["Type_id_PromotionStatus"] != null)
				model.Type_id_PromotionStatus=Shop.Tools.RequestTool.RequestInt("Type_id_PromotionStatus",0);
			if (HttpContext.Current.Request["IsSetCase"] != null)
				model.IsSetCase=Shop.Tools.RequestTool.RequestInt("IsSetCase",0);
			if (HttpContext.Current.Request["IsSetRule"] != null)
				model.IsSetRule=Shop.Tools.RequestTool.RequestInt("IsSetRule",0);
			if (HttpContext.Current.Request["Promotion_Type_id"] != null)
				model.Promotion_Type_id=Shop.Tools.RequestTool.RequestInt("Promotion_Type_id",0);
			if (HttpContext.Current.Request["Case801"] != null)
				model.Case801=Shop.Tools.RequestTool.RequestInt("Case801",0);
			if (HttpContext.Current.Request["Case802"] != null)
				model.Case802=Shop.Tools.RequestTool.RequestInt("Case802",0);
			if (HttpContext.Current.Request["Case803"] != null)
				model.Case803=Shop.Tools.RequestTool.RequestInt("Case803",0);
			if (HttpContext.Current.Request["Case806"] != null)
				model.Case806=Shop.Tools.RequestTool.RequestInt("Case806",0);
			if (HttpContext.Current.Request["IsCase801"] != null)
				model.IsCase801=Shop.Tools.RequestTool.RequestInt("IsCase801",0);
			if (HttpContext.Current.Request["IsCase802"] != null)
				model.IsCase802=Shop.Tools.RequestTool.RequestInt("IsCase802",0);
			if (HttpContext.Current.Request["IsCase803"] != null)
				model.IsCase803=Shop.Tools.RequestTool.RequestInt("IsCase803",0);
			if (HttpContext.Current.Request["IsCase804"] != null)
				model.IsCase804=Shop.Tools.RequestTool.RequestInt("IsCase804",0);
			if (HttpContext.Current.Request["IsCase805"] != null)
				model.IsCase805=Shop.Tools.RequestTool.RequestInt("IsCase805",0);
			if (HttpContext.Current.Request["IsCase806"] != null)
				model.IsCase806=Shop.Tools.RequestTool.RequestInt("IsCase806",0);
			if (HttpContext.Current.Request["Rule901"] != null)
				model.Rule901=Shop.Tools.RequestTool.RequestInt("Rule901",0);
			if (HttpContext.Current.Request["Rule902"] != null)
				model.Rule902=Shop.Tools.RequestTool.RequestInt("Rule902",0);
			if (HttpContext.Current.Request["Rule903"] != null)
				model.Rule903=Shop.Tools.RequestTool.RequestInt("Rule903",0);
			if (HttpContext.Current.Request["Rule904"] != null)
				model.Rule904=Shop.Tools.RequestTool.RequestInt("Rule904",0);
			if (HttpContext.Current.Request["Rule905"] != null)
				model.Rule905=Shop.Tools.RequestTool.RequestInt("Rule905",0);
			if (HttpContext.Current.Request["Rule906"] != null)
				model.Rule906=Shop.Tools.RequestTool.RequestInt("Rule906",0);
			if (HttpContext.Current.Request["Rule907"] != null)
				model.Rule907=Shop.Tools.RequestTool.RequestInt("Rule907",0);
			if (HttpContext.Current.Request["Rule908"] != null)
				model.Rule908=Shop.Tools.RequestTool.RequestInt("Rule908",0);
			if (HttpContext.Current.Request["Rule909"] != null)
				model.Rule909=Shop.Tools.RequestTool.RequestSafeString("Rule909");
			if (HttpContext.Current.Request["Rule910"] != null)
				model.Rule910=Shop.Tools.RequestTool.RequestInt("Rule910",0);
			if (HttpContext.Current.Request["Rule911"] != null)
				model.Rule911=Shop.Tools.RequestTool.RequestSafeString("Rule911");
			if (HttpContext.Current.Request["IsRule901"] != null)
				model.IsRule901=Shop.Tools.RequestTool.RequestInt("IsRule901",0);
			if (HttpContext.Current.Request["IsRule902"] != null)
				model.IsRule902=Shop.Tools.RequestTool.RequestInt("IsRule902",0);
			if (HttpContext.Current.Request["IsRule903"] != null)
				model.IsRule903=Shop.Tools.RequestTool.RequestInt("IsRule903",0);
			if (HttpContext.Current.Request["IsRule904"] != null)
				model.IsRule904=Shop.Tools.RequestTool.RequestInt("IsRule904",0);
			if (HttpContext.Current.Request["IsRule905"] != null)
				model.IsRule905=Shop.Tools.RequestTool.RequestInt("IsRule905",0);
			if (HttpContext.Current.Request["IsRule906"] != null)
				model.IsRule906=Shop.Tools.RequestTool.RequestInt("IsRule906",0);
			if (HttpContext.Current.Request["IsRule907"] != null)
				model.IsRule907=Shop.Tools.RequestTool.RequestInt("IsRule907",0);
			if (HttpContext.Current.Request["IsRule908"] != null)
				model.IsRule908=Shop.Tools.RequestTool.RequestInt("IsRule908",0);
			if (HttpContext.Current.Request["IsRule909"] != null)
				model.IsRule909=Shop.Tools.RequestTool.RequestInt("IsRule909",0);
			if (HttpContext.Current.Request["IsRule910"] != null)
				model.IsRule910=Shop.Tools.RequestTool.RequestInt("IsRule910",0);
			if (HttpContext.Current.Request["IsRule911"] != null)
				model.IsRule911=Shop.Tools.RequestTool.RequestInt("IsRule911",0);
			if (HttpContext.Current.Request["Case805"] != null)
				model.Case805=Shop.Tools.RequestTool.RequestSafeString("Case805");
			if (HttpContext.Current.Request["Case804"] != null)
				model.Case804=Shop.Tools.RequestTool.RequestSafeString("Case804");
			if (HttpContext.Current.Request["Rule912"] != null)
				model.Rule912=Shop.Tools.RequestTool.RequestInt("Rule912",0);
			if (HttpContext.Current.Request["IsRule912"] != null)
				model.IsRule912=Shop.Tools.RequestTool.RequestInt("IsRule912",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Promotion ReaderBind(IDataReader dataReader)
		{
			Lebi_Promotion model=new Lebi_Promotion();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
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
			ojb = dataReader["Type_id_PromotionStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type_id_PromotionStatus=(int)ojb;
			}
			ojb = dataReader["IsSetCase"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSetCase=(int)ojb;
			}
			ojb = dataReader["IsSetRule"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSetRule=(int)ojb;
			}
			ojb = dataReader["Promotion_Type_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Promotion_Type_id=(int)ojb;
			}
			ojb = dataReader["Case801"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Case801=(int)ojb;
			}
			ojb = dataReader["Case802"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Case802=(int)ojb;
			}
			ojb = dataReader["Case803"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Case803=(int)ojb;
			}
			ojb = dataReader["Case806"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Case806=(int)ojb;
			}
			ojb = dataReader["IsCase801"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase801=(int)ojb;
			}
			ojb = dataReader["IsCase802"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase802=(int)ojb;
			}
			ojb = dataReader["IsCase803"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase803=(int)ojb;
			}
			ojb = dataReader["IsCase804"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase804=(int)ojb;
			}
			ojb = dataReader["IsCase805"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase805=(int)ojb;
			}
			ojb = dataReader["IsCase806"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCase806=(int)ojb;
			}
			ojb = dataReader["Rule901"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule901=(int)ojb;
			}
			ojb = dataReader["Rule902"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule902=(int)ojb;
			}
			ojb = dataReader["Rule903"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule903=(int)ojb;
			}
			ojb = dataReader["Rule904"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule904=(int)ojb;
			}
			ojb = dataReader["Rule905"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule905=(int)ojb;
			}
			ojb = dataReader["Rule906"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule906=(int)ojb;
			}
			ojb = dataReader["Rule907"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule907=(int)ojb;
			}
			ojb = dataReader["Rule908"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule908=(int)ojb;
			}
			model.Rule909=dataReader["Rule909"].ToString();
			ojb = dataReader["Rule910"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule910=(int)ojb;
			}
			model.Rule911=dataReader["Rule911"].ToString();
			ojb = dataReader["IsRule901"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule901=(int)ojb;
			}
			ojb = dataReader["IsRule902"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule902=(int)ojb;
			}
			ojb = dataReader["IsRule903"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule903=(int)ojb;
			}
			ojb = dataReader["IsRule904"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule904=(int)ojb;
			}
			ojb = dataReader["IsRule905"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule905=(int)ojb;
			}
			ojb = dataReader["IsRule906"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule906=(int)ojb;
			}
			ojb = dataReader["IsRule907"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule907=(int)ojb;
			}
			ojb = dataReader["IsRule908"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule908=(int)ojb;
			}
			ojb = dataReader["IsRule909"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule909=(int)ojb;
			}
			ojb = dataReader["IsRule910"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule910=(int)ojb;
			}
			ojb = dataReader["IsRule911"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule911=(int)ojb;
			}
			model.Case805=dataReader["Case805"].ToString();
			model.Case804=dataReader["Case804"].ToString();
			ojb = dataReader["Rule912"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Rule912=(int)ojb;
			}
			ojb = dataReader["IsRule912"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRule912=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

