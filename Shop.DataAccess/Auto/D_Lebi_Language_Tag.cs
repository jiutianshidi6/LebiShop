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

	public interface Lebi_Language_Tag_interface
	{
		string GetValue(string colName, string strWhere);
		string GetValue(string colName, SQLPara para);
		int Counts(string strWhere);
		int Counts(SQLPara para);
		int GetMaxID(string strWhere);
		int GetMaxID(SQLPara para);
		int Add(Lebi_Language_Tag model);
		void Update(Lebi_Language_Tag model);
		void Delete(int id);
		void Delete(string strWhere);
		void Delete(SQLPara para);
		Lebi_Language_Tag GetModel(int id);
		Lebi_Language_Tag GetModel(string strWhere);
		Lebi_Language_Tag GetModel(SQLPara para);
		List<Lebi_Language_Tag> GetList(string strWhere, string strFieldOrder, int PageSize, int page);
		List<Lebi_Language_Tag> GetList(SQLPara para, int PageSize, int page);
		List<Lebi_Language_Tag> GetList(string strWhere, string strFieldOrder);
		List<Lebi_Language_Tag> GetList(SQLPara para);
		Lebi_Language_Tag BindForm(Lebi_Language_Tag model);
		Lebi_Language_Tag SafeBindForm(Lebi_Language_Tag model);
		Lebi_Language_Tag ReaderBind(IDataReader dataReader);
	}

	/// <summary>
	/// 数据访问类D_Lebi_Language_Tag。
	/// </summary>
	public class D_Lebi_Language_Tag
	{
		static Lebi_Language_Tag_interface _Instance;
		public static Lebi_Language_Tag_interface Instance
		{
		   get
		   {
		        if (_Instance == null)
		        {
		            if (BaseUtils.BaseUtilsInstance.DBType == "access")
		                _Instance = new access_Lebi_Language_Tag();
		            else
		                _Instance = new sqlserver_Lebi_Language_Tag();
		        }
		        return _Instance;
		    }
		    set
		    {
		        _Instance = value;
		    }
		}

		public D_Lebi_Language_Tag()
		{}
		#region  成员方法
	class sqlserver_Lebi_Language_Tag : Lebi_Language_Tag_interface
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
				strSql.Append("select " + colName + " from [Lebi_Language_Tag]");
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
			strSql.Append("select  "+colName+" from [Lebi_Language_Tag]");
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
			strSql.Append("select count(1) from [Lebi_Language_Tag]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString())); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Language_Tag]");
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
			strSql.Append("select max(id) from [Lebi_Language_Tag]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString()));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Language_Tag]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( SqlUtils.SqlUtilsInstance.TextExecuteScalar(strSql.ToString(), para.Para)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Language_Tag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Language_Tag](");
			strSql.Append("tag,CN,IsCN,EN,IsEN,ja,Isja,ar,Isar,ca,Isca,cs,Iscs,cy,Iscy,da,Isda,de,Isde,el,Isel,es,Ises,eu,Iseu,fa,Isfa,fi,Isfi,fr,Isfr,gl,Isgl,he,Ishe,hr,Ishr,ru,Isru,sv,Issv,ta,Ista,th,Isth,tr,Istr,uk,Isuk,vi,Isvi,hu,Ishu,id_,Isid_,it,Isit,ka,Iska,ko,Isko,lt,Islt,mk,Ismk,ms,Isms,nl,Isnl,no,Isno,pl,Ispl,pt,Ispt,ro,Isro,tw,tcn,Istcn)");
			strSql.Append(" values (");
			strSql.Append("@tag,@CN,@IsCN,@EN,@IsEN,@ja,@Isja,@ar,@Isar,@ca,@Isca,@cs,@Iscs,@cy,@Iscy,@da,@Isda,@de,@Isde,@el,@Isel,@es,@Ises,@eu,@Iseu,@fa,@Isfa,@fi,@Isfi,@fr,@Isfr,@gl,@Isgl,@he,@Ishe,@hr,@Ishr,@ru,@Isru,@sv,@Issv,@ta,@Ista,@th,@Isth,@tr,@Istr,@uk,@Isuk,@vi,@Isvi,@hu,@Ishu,@id_,@Isid_,@it,@Isit,@ka,@Iska,@ko,@Isko,@lt,@Islt,@mk,@Ismk,@ms,@Isms,@nl,@Isnl,@no,@Isno,@pl,@Ispl,@pt,@Ispt,@ro,@Isro,@tw,@tcn,@Istcn)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@tag", model.tag),
					new SqlParameter("@CN", model.CN),
					new SqlParameter("@IsCN", model.IsCN),
					new SqlParameter("@EN", model.EN),
					new SqlParameter("@IsEN", model.IsEN),
					new SqlParameter("@ja", model.ja),
					new SqlParameter("@Isja", model.Isja),
					new SqlParameter("@ar", model.ar),
					new SqlParameter("@Isar", model.Isar),
					new SqlParameter("@ca", model.ca),
					new SqlParameter("@Isca", model.Isca),
					new SqlParameter("@cs", model.cs),
					new SqlParameter("@Iscs", model.Iscs),
					new SqlParameter("@cy", model.cy),
					new SqlParameter("@Iscy", model.Iscy),
					new SqlParameter("@da", model.da),
					new SqlParameter("@Isda", model.Isda),
					new SqlParameter("@de", model.de),
					new SqlParameter("@Isde", model.Isde),
					new SqlParameter("@el", model.el),
					new SqlParameter("@Isel", model.Isel),
					new SqlParameter("@es", model.es),
					new SqlParameter("@Ises", model.Ises),
					new SqlParameter("@eu", model.eu),
					new SqlParameter("@Iseu", model.Iseu),
					new SqlParameter("@fa", model.fa),
					new SqlParameter("@Isfa", model.Isfa),
					new SqlParameter("@fi", model.fi),
					new SqlParameter("@Isfi", model.Isfi),
					new SqlParameter("@fr", model.fr),
					new SqlParameter("@Isfr", model.Isfr),
					new SqlParameter("@gl", model.gl),
					new SqlParameter("@Isgl", model.Isgl),
					new SqlParameter("@he", model.he),
					new SqlParameter("@Ishe", model.Ishe),
					new SqlParameter("@hr", model.hr),
					new SqlParameter("@Ishr", model.Ishr),
					new SqlParameter("@ru", model.ru),
					new SqlParameter("@Isru", model.Isru),
					new SqlParameter("@sv", model.sv),
					new SqlParameter("@Issv", model.Issv),
					new SqlParameter("@ta", model.ta),
					new SqlParameter("@Ista", model.Ista),
					new SqlParameter("@th", model.th),
					new SqlParameter("@Isth", model.Isth),
					new SqlParameter("@tr", model.tr),
					new SqlParameter("@Istr", model.Istr),
					new SqlParameter("@uk", model.uk),
					new SqlParameter("@Isuk", model.Isuk),
					new SqlParameter("@vi", model.vi),
					new SqlParameter("@Isvi", model.Isvi),
					new SqlParameter("@hu", model.hu),
					new SqlParameter("@Ishu", model.Ishu),
					new SqlParameter("@id_", model.id_),
					new SqlParameter("@Isid_", model.Isid_),
					new SqlParameter("@it", model.it),
					new SqlParameter("@Isit", model.Isit),
					new SqlParameter("@ka", model.ka),
					new SqlParameter("@Iska", model.Iska),
					new SqlParameter("@ko", model.ko),
					new SqlParameter("@Isko", model.Isko),
					new SqlParameter("@lt", model.lt),
					new SqlParameter("@Islt", model.Islt),
					new SqlParameter("@mk", model.mk),
					new SqlParameter("@Ismk", model.Ismk),
					new SqlParameter("@ms", model.ms),
					new SqlParameter("@Isms", model.Isms),
					new SqlParameter("@nl", model.nl),
					new SqlParameter("@Isnl", model.Isnl),
					new SqlParameter("@no", model.no),
					new SqlParameter("@Isno", model.Isno),
					new SqlParameter("@pl", model.pl),
					new SqlParameter("@Ispl", model.Ispl),
					new SqlParameter("@pt", model.pt),
					new SqlParameter("@Ispt", model.Ispt),
					new SqlParameter("@ro", model.ro),
					new SqlParameter("@Isro", model.Isro),
					new SqlParameter("@tw", model.tw),
					new SqlParameter("@tcn", model.tcn),
					new SqlParameter("@Istcn", model.Istcn)};

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
		public void Update(Lebi_Language_Tag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Language_Tag] set ");
			strSql.Append("tag= @tag,");
			strSql.Append("CN= @CN,");
			strSql.Append("IsCN= @IsCN,");
			strSql.Append("EN= @EN,");
			strSql.Append("IsEN= @IsEN,");
			strSql.Append("ja= @ja,");
			strSql.Append("Isja= @Isja,");
			strSql.Append("ar= @ar,");
			strSql.Append("Isar= @Isar,");
			strSql.Append("ca= @ca,");
			strSql.Append("Isca= @Isca,");
			strSql.Append("cs= @cs,");
			strSql.Append("Iscs= @Iscs,");
			strSql.Append("cy= @cy,");
			strSql.Append("Iscy= @Iscy,");
			strSql.Append("da= @da,");
			strSql.Append("Isda= @Isda,");
			strSql.Append("de= @de,");
			strSql.Append("Isde= @Isde,");
			strSql.Append("el= @el,");
			strSql.Append("Isel= @Isel,");
			strSql.Append("es= @es,");
			strSql.Append("Ises= @Ises,");
			strSql.Append("eu= @eu,");
			strSql.Append("Iseu= @Iseu,");
			strSql.Append("fa= @fa,");
			strSql.Append("Isfa= @Isfa,");
			strSql.Append("fi= @fi,");
			strSql.Append("Isfi= @Isfi,");
			strSql.Append("fr= @fr,");
			strSql.Append("Isfr= @Isfr,");
			strSql.Append("gl= @gl,");
			strSql.Append("Isgl= @Isgl,");
			strSql.Append("he= @he,");
			strSql.Append("Ishe= @Ishe,");
			strSql.Append("hr= @hr,");
			strSql.Append("Ishr= @Ishr,");
			strSql.Append("ru= @ru,");
			strSql.Append("Isru= @Isru,");
			strSql.Append("sv= @sv,");
			strSql.Append("Issv= @Issv,");
			strSql.Append("ta= @ta,");
			strSql.Append("Ista= @Ista,");
			strSql.Append("th= @th,");
			strSql.Append("Isth= @Isth,");
			strSql.Append("tr= @tr,");
			strSql.Append("Istr= @Istr,");
			strSql.Append("uk= @uk,");
			strSql.Append("Isuk= @Isuk,");
			strSql.Append("vi= @vi,");
			strSql.Append("Isvi= @Isvi,");
			strSql.Append("hu= @hu,");
			strSql.Append("Ishu= @Ishu,");
			strSql.Append("id_= @id_,");
			strSql.Append("Isid_= @Isid_,");
			strSql.Append("it= @it,");
			strSql.Append("Isit= @Isit,");
			strSql.Append("ka= @ka,");
			strSql.Append("Iska= @Iska,");
			strSql.Append("ko= @ko,");
			strSql.Append("Isko= @Isko,");
			strSql.Append("lt= @lt,");
			strSql.Append("Islt= @Islt,");
			strSql.Append("mk= @mk,");
			strSql.Append("Ismk= @Ismk,");
			strSql.Append("ms= @ms,");
			strSql.Append("Isms= @Isms,");
			strSql.Append("nl= @nl,");
			strSql.Append("Isnl= @Isnl,");
			strSql.Append("no= @no,");
			strSql.Append("Isno= @Isno,");
			strSql.Append("pl= @pl,");
			strSql.Append("Ispl= @Ispl,");
			strSql.Append("pt= @pt,");
			strSql.Append("Ispt= @Ispt,");
			strSql.Append("ro= @ro,");
			strSql.Append("Isro= @Isro,");
			strSql.Append("tw= @tw,");
			strSql.Append("tcn= @tcn,");
			strSql.Append("Istcn= @Istcn");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@tag", SqlDbType.NVarChar,500),
					new SqlParameter("@CN", SqlDbType.NVarChar,500),
					new SqlParameter("@IsCN", SqlDbType.Int,4),
					new SqlParameter("@EN", SqlDbType.NVarChar,500),
					new SqlParameter("@IsEN", SqlDbType.Int,4),
					new SqlParameter("@ja", SqlDbType.NVarChar,500),
					new SqlParameter("@Isja", SqlDbType.Int,4),
					new SqlParameter("@ar", SqlDbType.NVarChar,500),
					new SqlParameter("@Isar", SqlDbType.Int,4),
					new SqlParameter("@ca", SqlDbType.NVarChar,500),
					new SqlParameter("@Isca", SqlDbType.Int,4),
					new SqlParameter("@cs", SqlDbType.NVarChar,500),
					new SqlParameter("@Iscs", SqlDbType.Int,4),
					new SqlParameter("@cy", SqlDbType.NVarChar,500),
					new SqlParameter("@Iscy", SqlDbType.Int,4),
					new SqlParameter("@da", SqlDbType.NVarChar,500),
					new SqlParameter("@Isda", SqlDbType.Int,4),
					new SqlParameter("@de", SqlDbType.NVarChar,500),
					new SqlParameter("@Isde", SqlDbType.Int,4),
					new SqlParameter("@el", SqlDbType.NVarChar,500),
					new SqlParameter("@Isel", SqlDbType.Int,4),
					new SqlParameter("@es", SqlDbType.NVarChar,500),
					new SqlParameter("@Ises", SqlDbType.Int,4),
					new SqlParameter("@eu", SqlDbType.NVarChar,500),
					new SqlParameter("@Iseu", SqlDbType.Int,4),
					new SqlParameter("@fa", SqlDbType.NVarChar,500),
					new SqlParameter("@Isfa", SqlDbType.Int,4),
					new SqlParameter("@fi", SqlDbType.NVarChar,500),
					new SqlParameter("@Isfi", SqlDbType.Int,4),
					new SqlParameter("@fr", SqlDbType.NVarChar,500),
					new SqlParameter("@Isfr", SqlDbType.Int,4),
					new SqlParameter("@gl", SqlDbType.NVarChar,500),
					new SqlParameter("@Isgl", SqlDbType.Int,4),
					new SqlParameter("@he", SqlDbType.NVarChar,500),
					new SqlParameter("@Ishe", SqlDbType.Int,4),
					new SqlParameter("@hr", SqlDbType.NVarChar,500),
					new SqlParameter("@Ishr", SqlDbType.Int,4),
					new SqlParameter("@ru", SqlDbType.NVarChar,500),
					new SqlParameter("@Isru", SqlDbType.Int,4),
					new SqlParameter("@sv", SqlDbType.NVarChar,500),
					new SqlParameter("@Issv", SqlDbType.Int,4),
					new SqlParameter("@ta", SqlDbType.NVarChar,500),
					new SqlParameter("@Ista", SqlDbType.Int,4),
					new SqlParameter("@th", SqlDbType.NVarChar,500),
					new SqlParameter("@Isth", SqlDbType.Int,4),
					new SqlParameter("@tr", SqlDbType.NVarChar,500),
					new SqlParameter("@Istr", SqlDbType.Int,4),
					new SqlParameter("@uk", SqlDbType.NVarChar,500),
					new SqlParameter("@Isuk", SqlDbType.Int,4),
					new SqlParameter("@vi", SqlDbType.NVarChar,500),
					new SqlParameter("@Isvi", SqlDbType.Int,4),
					new SqlParameter("@hu", SqlDbType.NVarChar,500),
					new SqlParameter("@Ishu", SqlDbType.Int,4),
					new SqlParameter("@id_", SqlDbType.NVarChar,500),
					new SqlParameter("@Isid_", SqlDbType.Int,4),
					new SqlParameter("@it", SqlDbType.NVarChar,500),
					new SqlParameter("@Isit", SqlDbType.Int,4),
					new SqlParameter("@ka", SqlDbType.NVarChar,500),
					new SqlParameter("@Iska", SqlDbType.Int,4),
					new SqlParameter("@ko", SqlDbType.NVarChar,500),
					new SqlParameter("@Isko", SqlDbType.Int,4),
					new SqlParameter("@lt", SqlDbType.NVarChar,500),
					new SqlParameter("@Islt", SqlDbType.Int,4),
					new SqlParameter("@mk", SqlDbType.NVarChar,500),
					new SqlParameter("@Ismk", SqlDbType.Int,4),
					new SqlParameter("@ms", SqlDbType.NVarChar,500),
					new SqlParameter("@Isms", SqlDbType.Int,4),
					new SqlParameter("@nl", SqlDbType.NVarChar,500),
					new SqlParameter("@Isnl", SqlDbType.Int,4),
					new SqlParameter("@no", SqlDbType.NVarChar,500),
					new SqlParameter("@Isno", SqlDbType.Int,4),
					new SqlParameter("@pl", SqlDbType.NVarChar,500),
					new SqlParameter("@Ispl", SqlDbType.Int,4),
					new SqlParameter("@pt", SqlDbType.NVarChar,500),
					new SqlParameter("@Ispt", SqlDbType.Int,4),
					new SqlParameter("@ro", SqlDbType.NVarChar,500),
					new SqlParameter("@Isro", SqlDbType.Int,4),
					new SqlParameter("@tw", SqlDbType.NVarChar,500),
					new SqlParameter("@tcn", SqlDbType.NVarChar,500),
					new SqlParameter("@Istcn", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.tag;
			parameters[2].Value = model.CN;
			parameters[3].Value = model.IsCN;
			parameters[4].Value = model.EN;
			parameters[5].Value = model.IsEN;
			parameters[6].Value = model.ja;
			parameters[7].Value = model.Isja;
			parameters[8].Value = model.ar;
			parameters[9].Value = model.Isar;
			parameters[10].Value = model.ca;
			parameters[11].Value = model.Isca;
			parameters[12].Value = model.cs;
			parameters[13].Value = model.Iscs;
			parameters[14].Value = model.cy;
			parameters[15].Value = model.Iscy;
			parameters[16].Value = model.da;
			parameters[17].Value = model.Isda;
			parameters[18].Value = model.de;
			parameters[19].Value = model.Isde;
			parameters[20].Value = model.el;
			parameters[21].Value = model.Isel;
			parameters[22].Value = model.es;
			parameters[23].Value = model.Ises;
			parameters[24].Value = model.eu;
			parameters[25].Value = model.Iseu;
			parameters[26].Value = model.fa;
			parameters[27].Value = model.Isfa;
			parameters[28].Value = model.fi;
			parameters[29].Value = model.Isfi;
			parameters[30].Value = model.fr;
			parameters[31].Value = model.Isfr;
			parameters[32].Value = model.gl;
			parameters[33].Value = model.Isgl;
			parameters[34].Value = model.he;
			parameters[35].Value = model.Ishe;
			parameters[36].Value = model.hr;
			parameters[37].Value = model.Ishr;
			parameters[38].Value = model.ru;
			parameters[39].Value = model.Isru;
			parameters[40].Value = model.sv;
			parameters[41].Value = model.Issv;
			parameters[42].Value = model.ta;
			parameters[43].Value = model.Ista;
			parameters[44].Value = model.th;
			parameters[45].Value = model.Isth;
			parameters[46].Value = model.tr;
			parameters[47].Value = model.Istr;
			parameters[48].Value = model.uk;
			parameters[49].Value = model.Isuk;
			parameters[50].Value = model.vi;
			parameters[51].Value = model.Isvi;
			parameters[52].Value = model.hu;
			parameters[53].Value = model.Ishu;
			parameters[54].Value = model.id_;
			parameters[55].Value = model.Isid_;
			parameters[56].Value = model.it;
			parameters[57].Value = model.Isit;
			parameters[58].Value = model.ka;
			parameters[59].Value = model.Iska;
			parameters[60].Value = model.ko;
			parameters[61].Value = model.Isko;
			parameters[62].Value = model.lt;
			parameters[63].Value = model.Islt;
			parameters[64].Value = model.mk;
			parameters[65].Value = model.Ismk;
			parameters[66].Value = model.ms;
			parameters[67].Value = model.Isms;
			parameters[68].Value = model.nl;
			parameters[69].Value = model.Isnl;
			parameters[70].Value = model.no;
			parameters[71].Value = model.Isno;
			parameters[72].Value = model.pl;
			parameters[73].Value = model.Ispl;
			parameters[74].Value = model.pt;
			parameters[75].Value = model.Ispt;
			parameters[76].Value = model.ro;
			parameters[77].Value = model.Isro;
			parameters[78].Value = model.tw;
			parameters[79].Value = model.tcn;
			parameters[80].Value = model.Istcn;

			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Language_Tag] ");
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
			strSql.Append("delete from [Lebi_Language_Tag] ");
			strSql.Append(" where "+ strWhere +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString());
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Language_Tag] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			SqlUtils.SqlUtilsInstance.TextExecuteNonQuery(strSql.ToString(),para.Para);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Language_Tag GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Language_Tag] ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Lebi_Language_Tag model=new Lebi_Language_Tag();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.tag=ds.Tables[0].Rows[0]["tag"].ToString();
				model.CN=ds.Tables[0].Rows[0]["CN"].ToString();
				if(ds.Tables[0].Rows[0]["IsCN"].ToString()!="")
				{
					model.IsCN=int.Parse(ds.Tables[0].Rows[0]["IsCN"].ToString());
				}
				model.EN=ds.Tables[0].Rows[0]["EN"].ToString();
				if(ds.Tables[0].Rows[0]["IsEN"].ToString()!="")
				{
					model.IsEN=int.Parse(ds.Tables[0].Rows[0]["IsEN"].ToString());
				}
				model.ja=ds.Tables[0].Rows[0]["ja"].ToString();
				if(ds.Tables[0].Rows[0]["Isja"].ToString()!="")
				{
					model.Isja=int.Parse(ds.Tables[0].Rows[0]["Isja"].ToString());
				}
				model.ar=ds.Tables[0].Rows[0]["ar"].ToString();
				if(ds.Tables[0].Rows[0]["Isar"].ToString()!="")
				{
					model.Isar=int.Parse(ds.Tables[0].Rows[0]["Isar"].ToString());
				}
				model.ca=ds.Tables[0].Rows[0]["ca"].ToString();
				if(ds.Tables[0].Rows[0]["Isca"].ToString()!="")
				{
					model.Isca=int.Parse(ds.Tables[0].Rows[0]["Isca"].ToString());
				}
				model.cs=ds.Tables[0].Rows[0]["cs"].ToString();
				if(ds.Tables[0].Rows[0]["Iscs"].ToString()!="")
				{
					model.Iscs=int.Parse(ds.Tables[0].Rows[0]["Iscs"].ToString());
				}
				model.cy=ds.Tables[0].Rows[0]["cy"].ToString();
				if(ds.Tables[0].Rows[0]["Iscy"].ToString()!="")
				{
					model.Iscy=int.Parse(ds.Tables[0].Rows[0]["Iscy"].ToString());
				}
				model.da=ds.Tables[0].Rows[0]["da"].ToString();
				if(ds.Tables[0].Rows[0]["Isda"].ToString()!="")
				{
					model.Isda=int.Parse(ds.Tables[0].Rows[0]["Isda"].ToString());
				}
				model.de=ds.Tables[0].Rows[0]["de"].ToString();
				if(ds.Tables[0].Rows[0]["Isde"].ToString()!="")
				{
					model.Isde=int.Parse(ds.Tables[0].Rows[0]["Isde"].ToString());
				}
				model.el=ds.Tables[0].Rows[0]["el"].ToString();
				if(ds.Tables[0].Rows[0]["Isel"].ToString()!="")
				{
					model.Isel=int.Parse(ds.Tables[0].Rows[0]["Isel"].ToString());
				}
				model.es=ds.Tables[0].Rows[0]["es"].ToString();
				if(ds.Tables[0].Rows[0]["Ises"].ToString()!="")
				{
					model.Ises=int.Parse(ds.Tables[0].Rows[0]["Ises"].ToString());
				}
				model.eu=ds.Tables[0].Rows[0]["eu"].ToString();
				if(ds.Tables[0].Rows[0]["Iseu"].ToString()!="")
				{
					model.Iseu=int.Parse(ds.Tables[0].Rows[0]["Iseu"].ToString());
				}
				model.fa=ds.Tables[0].Rows[0]["fa"].ToString();
				if(ds.Tables[0].Rows[0]["Isfa"].ToString()!="")
				{
					model.Isfa=int.Parse(ds.Tables[0].Rows[0]["Isfa"].ToString());
				}
				model.fi=ds.Tables[0].Rows[0]["fi"].ToString();
				if(ds.Tables[0].Rows[0]["Isfi"].ToString()!="")
				{
					model.Isfi=int.Parse(ds.Tables[0].Rows[0]["Isfi"].ToString());
				}
				model.fr=ds.Tables[0].Rows[0]["fr"].ToString();
				if(ds.Tables[0].Rows[0]["Isfr"].ToString()!="")
				{
					model.Isfr=int.Parse(ds.Tables[0].Rows[0]["Isfr"].ToString());
				}
				model.gl=ds.Tables[0].Rows[0]["gl"].ToString();
				if(ds.Tables[0].Rows[0]["Isgl"].ToString()!="")
				{
					model.Isgl=int.Parse(ds.Tables[0].Rows[0]["Isgl"].ToString());
				}
				model.he=ds.Tables[0].Rows[0]["he"].ToString();
				if(ds.Tables[0].Rows[0]["Ishe"].ToString()!="")
				{
					model.Ishe=int.Parse(ds.Tables[0].Rows[0]["Ishe"].ToString());
				}
				model.hr=ds.Tables[0].Rows[0]["hr"].ToString();
				if(ds.Tables[0].Rows[0]["Ishr"].ToString()!="")
				{
					model.Ishr=int.Parse(ds.Tables[0].Rows[0]["Ishr"].ToString());
				}
				model.ru=ds.Tables[0].Rows[0]["ru"].ToString();
				if(ds.Tables[0].Rows[0]["Isru"].ToString()!="")
				{
					model.Isru=int.Parse(ds.Tables[0].Rows[0]["Isru"].ToString());
				}
				model.sv=ds.Tables[0].Rows[0]["sv"].ToString();
				if(ds.Tables[0].Rows[0]["Issv"].ToString()!="")
				{
					model.Issv=int.Parse(ds.Tables[0].Rows[0]["Issv"].ToString());
				}
				model.ta=ds.Tables[0].Rows[0]["ta"].ToString();
				if(ds.Tables[0].Rows[0]["Ista"].ToString()!="")
				{
					model.Ista=int.Parse(ds.Tables[0].Rows[0]["Ista"].ToString());
				}
				model.th=ds.Tables[0].Rows[0]["th"].ToString();
				if(ds.Tables[0].Rows[0]["Isth"].ToString()!="")
				{
					model.Isth=int.Parse(ds.Tables[0].Rows[0]["Isth"].ToString());
				}
				model.tr=ds.Tables[0].Rows[0]["tr"].ToString();
				if(ds.Tables[0].Rows[0]["Istr"].ToString()!="")
				{
					model.Istr=int.Parse(ds.Tables[0].Rows[0]["Istr"].ToString());
				}
				model.uk=ds.Tables[0].Rows[0]["uk"].ToString();
				if(ds.Tables[0].Rows[0]["Isuk"].ToString()!="")
				{
					model.Isuk=int.Parse(ds.Tables[0].Rows[0]["Isuk"].ToString());
				}
				model.vi=ds.Tables[0].Rows[0]["vi"].ToString();
				if(ds.Tables[0].Rows[0]["Isvi"].ToString()!="")
				{
					model.Isvi=int.Parse(ds.Tables[0].Rows[0]["Isvi"].ToString());
				}
				model.hu=ds.Tables[0].Rows[0]["hu"].ToString();
				if(ds.Tables[0].Rows[0]["Ishu"].ToString()!="")
				{
					model.Ishu=int.Parse(ds.Tables[0].Rows[0]["Ishu"].ToString());
				}
				model.id_=ds.Tables[0].Rows[0]["id_"].ToString();
				if(ds.Tables[0].Rows[0]["Isid_"].ToString()!="")
				{
					model.Isid_=int.Parse(ds.Tables[0].Rows[0]["Isid_"].ToString());
				}
				model.it=ds.Tables[0].Rows[0]["it"].ToString();
				if(ds.Tables[0].Rows[0]["Isit"].ToString()!="")
				{
					model.Isit=int.Parse(ds.Tables[0].Rows[0]["Isit"].ToString());
				}
				model.ka=ds.Tables[0].Rows[0]["ka"].ToString();
				if(ds.Tables[0].Rows[0]["Iska"].ToString()!="")
				{
					model.Iska=int.Parse(ds.Tables[0].Rows[0]["Iska"].ToString());
				}
				model.ko=ds.Tables[0].Rows[0]["ko"].ToString();
				if(ds.Tables[0].Rows[0]["Isko"].ToString()!="")
				{
					model.Isko=int.Parse(ds.Tables[0].Rows[0]["Isko"].ToString());
				}
				model.lt=ds.Tables[0].Rows[0]["lt"].ToString();
				if(ds.Tables[0].Rows[0]["Islt"].ToString()!="")
				{
					model.Islt=int.Parse(ds.Tables[0].Rows[0]["Islt"].ToString());
				}
				model.mk=ds.Tables[0].Rows[0]["mk"].ToString();
				if(ds.Tables[0].Rows[0]["Ismk"].ToString()!="")
				{
					model.Ismk=int.Parse(ds.Tables[0].Rows[0]["Ismk"].ToString());
				}
				model.ms=ds.Tables[0].Rows[0]["ms"].ToString();
				if(ds.Tables[0].Rows[0]["Isms"].ToString()!="")
				{
					model.Isms=int.Parse(ds.Tables[0].Rows[0]["Isms"].ToString());
				}
				model.nl=ds.Tables[0].Rows[0]["nl"].ToString();
				if(ds.Tables[0].Rows[0]["Isnl"].ToString()!="")
				{
					model.Isnl=int.Parse(ds.Tables[0].Rows[0]["Isnl"].ToString());
				}
				model.no=ds.Tables[0].Rows[0]["no"].ToString();
				if(ds.Tables[0].Rows[0]["Isno"].ToString()!="")
				{
					model.Isno=int.Parse(ds.Tables[0].Rows[0]["Isno"].ToString());
				}
				model.pl=ds.Tables[0].Rows[0]["pl"].ToString();
				if(ds.Tables[0].Rows[0]["Ispl"].ToString()!="")
				{
					model.Ispl=int.Parse(ds.Tables[0].Rows[0]["Ispl"].ToString());
				}
				model.pt=ds.Tables[0].Rows[0]["pt"].ToString();
				if(ds.Tables[0].Rows[0]["Ispt"].ToString()!="")
				{
					model.Ispt=int.Parse(ds.Tables[0].Rows[0]["Ispt"].ToString());
				}
				model.ro=ds.Tables[0].Rows[0]["ro"].ToString();
				if(ds.Tables[0].Rows[0]["Isro"].ToString()!="")
				{
					model.Isro=int.Parse(ds.Tables[0].Rows[0]["Isro"].ToString());
				}
				model.tw=ds.Tables[0].Rows[0]["tw"].ToString();
				model.tcn=ds.Tables[0].Rows[0]["tcn"].ToString();
				if(ds.Tables[0].Rows[0]["Istcn"].ToString()!="")
				{
					model.Istcn=int.Parse(ds.Tables[0].Rows[0]["Istcn"].ToString());
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
		public Lebi_Language_Tag GetModel(string strWhere)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Language_Tag] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Language_Tag model=new Lebi_Language_Tag();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.tag=ds.Tables[0].Rows[0]["tag"].ToString();
				model.CN=ds.Tables[0].Rows[0]["CN"].ToString();
				if(ds.Tables[0].Rows[0]["IsCN"].ToString()!="")
				{
					model.IsCN=int.Parse(ds.Tables[0].Rows[0]["IsCN"].ToString());
				}
				model.EN=ds.Tables[0].Rows[0]["EN"].ToString();
				if(ds.Tables[0].Rows[0]["IsEN"].ToString()!="")
				{
					model.IsEN=int.Parse(ds.Tables[0].Rows[0]["IsEN"].ToString());
				}
				model.ja=ds.Tables[0].Rows[0]["ja"].ToString();
				if(ds.Tables[0].Rows[0]["Isja"].ToString()!="")
				{
					model.Isja=int.Parse(ds.Tables[0].Rows[0]["Isja"].ToString());
				}
				model.ar=ds.Tables[0].Rows[0]["ar"].ToString();
				if(ds.Tables[0].Rows[0]["Isar"].ToString()!="")
				{
					model.Isar=int.Parse(ds.Tables[0].Rows[0]["Isar"].ToString());
				}
				model.ca=ds.Tables[0].Rows[0]["ca"].ToString();
				if(ds.Tables[0].Rows[0]["Isca"].ToString()!="")
				{
					model.Isca=int.Parse(ds.Tables[0].Rows[0]["Isca"].ToString());
				}
				model.cs=ds.Tables[0].Rows[0]["cs"].ToString();
				if(ds.Tables[0].Rows[0]["Iscs"].ToString()!="")
				{
					model.Iscs=int.Parse(ds.Tables[0].Rows[0]["Iscs"].ToString());
				}
				model.cy=ds.Tables[0].Rows[0]["cy"].ToString();
				if(ds.Tables[0].Rows[0]["Iscy"].ToString()!="")
				{
					model.Iscy=int.Parse(ds.Tables[0].Rows[0]["Iscy"].ToString());
				}
				model.da=ds.Tables[0].Rows[0]["da"].ToString();
				if(ds.Tables[0].Rows[0]["Isda"].ToString()!="")
				{
					model.Isda=int.Parse(ds.Tables[0].Rows[0]["Isda"].ToString());
				}
				model.de=ds.Tables[0].Rows[0]["de"].ToString();
				if(ds.Tables[0].Rows[0]["Isde"].ToString()!="")
				{
					model.Isde=int.Parse(ds.Tables[0].Rows[0]["Isde"].ToString());
				}
				model.el=ds.Tables[0].Rows[0]["el"].ToString();
				if(ds.Tables[0].Rows[0]["Isel"].ToString()!="")
				{
					model.Isel=int.Parse(ds.Tables[0].Rows[0]["Isel"].ToString());
				}
				model.es=ds.Tables[0].Rows[0]["es"].ToString();
				if(ds.Tables[0].Rows[0]["Ises"].ToString()!="")
				{
					model.Ises=int.Parse(ds.Tables[0].Rows[0]["Ises"].ToString());
				}
				model.eu=ds.Tables[0].Rows[0]["eu"].ToString();
				if(ds.Tables[0].Rows[0]["Iseu"].ToString()!="")
				{
					model.Iseu=int.Parse(ds.Tables[0].Rows[0]["Iseu"].ToString());
				}
				model.fa=ds.Tables[0].Rows[0]["fa"].ToString();
				if(ds.Tables[0].Rows[0]["Isfa"].ToString()!="")
				{
					model.Isfa=int.Parse(ds.Tables[0].Rows[0]["Isfa"].ToString());
				}
				model.fi=ds.Tables[0].Rows[0]["fi"].ToString();
				if(ds.Tables[0].Rows[0]["Isfi"].ToString()!="")
				{
					model.Isfi=int.Parse(ds.Tables[0].Rows[0]["Isfi"].ToString());
				}
				model.fr=ds.Tables[0].Rows[0]["fr"].ToString();
				if(ds.Tables[0].Rows[0]["Isfr"].ToString()!="")
				{
					model.Isfr=int.Parse(ds.Tables[0].Rows[0]["Isfr"].ToString());
				}
				model.gl=ds.Tables[0].Rows[0]["gl"].ToString();
				if(ds.Tables[0].Rows[0]["Isgl"].ToString()!="")
				{
					model.Isgl=int.Parse(ds.Tables[0].Rows[0]["Isgl"].ToString());
				}
				model.he=ds.Tables[0].Rows[0]["he"].ToString();
				if(ds.Tables[0].Rows[0]["Ishe"].ToString()!="")
				{
					model.Ishe=int.Parse(ds.Tables[0].Rows[0]["Ishe"].ToString());
				}
				model.hr=ds.Tables[0].Rows[0]["hr"].ToString();
				if(ds.Tables[0].Rows[0]["Ishr"].ToString()!="")
				{
					model.Ishr=int.Parse(ds.Tables[0].Rows[0]["Ishr"].ToString());
				}
				model.ru=ds.Tables[0].Rows[0]["ru"].ToString();
				if(ds.Tables[0].Rows[0]["Isru"].ToString()!="")
				{
					model.Isru=int.Parse(ds.Tables[0].Rows[0]["Isru"].ToString());
				}
				model.sv=ds.Tables[0].Rows[0]["sv"].ToString();
				if(ds.Tables[0].Rows[0]["Issv"].ToString()!="")
				{
					model.Issv=int.Parse(ds.Tables[0].Rows[0]["Issv"].ToString());
				}
				model.ta=ds.Tables[0].Rows[0]["ta"].ToString();
				if(ds.Tables[0].Rows[0]["Ista"].ToString()!="")
				{
					model.Ista=int.Parse(ds.Tables[0].Rows[0]["Ista"].ToString());
				}
				model.th=ds.Tables[0].Rows[0]["th"].ToString();
				if(ds.Tables[0].Rows[0]["Isth"].ToString()!="")
				{
					model.Isth=int.Parse(ds.Tables[0].Rows[0]["Isth"].ToString());
				}
				model.tr=ds.Tables[0].Rows[0]["tr"].ToString();
				if(ds.Tables[0].Rows[0]["Istr"].ToString()!="")
				{
					model.Istr=int.Parse(ds.Tables[0].Rows[0]["Istr"].ToString());
				}
				model.uk=ds.Tables[0].Rows[0]["uk"].ToString();
				if(ds.Tables[0].Rows[0]["Isuk"].ToString()!="")
				{
					model.Isuk=int.Parse(ds.Tables[0].Rows[0]["Isuk"].ToString());
				}
				model.vi=ds.Tables[0].Rows[0]["vi"].ToString();
				if(ds.Tables[0].Rows[0]["Isvi"].ToString()!="")
				{
					model.Isvi=int.Parse(ds.Tables[0].Rows[0]["Isvi"].ToString());
				}
				model.hu=ds.Tables[0].Rows[0]["hu"].ToString();
				if(ds.Tables[0].Rows[0]["Ishu"].ToString()!="")
				{
					model.Ishu=int.Parse(ds.Tables[0].Rows[0]["Ishu"].ToString());
				}
				model.id_=ds.Tables[0].Rows[0]["id_"].ToString();
				if(ds.Tables[0].Rows[0]["Isid_"].ToString()!="")
				{
					model.Isid_=int.Parse(ds.Tables[0].Rows[0]["Isid_"].ToString());
				}
				model.it=ds.Tables[0].Rows[0]["it"].ToString();
				if(ds.Tables[0].Rows[0]["Isit"].ToString()!="")
				{
					model.Isit=int.Parse(ds.Tables[0].Rows[0]["Isit"].ToString());
				}
				model.ka=ds.Tables[0].Rows[0]["ka"].ToString();
				if(ds.Tables[0].Rows[0]["Iska"].ToString()!="")
				{
					model.Iska=int.Parse(ds.Tables[0].Rows[0]["Iska"].ToString());
				}
				model.ko=ds.Tables[0].Rows[0]["ko"].ToString();
				if(ds.Tables[0].Rows[0]["Isko"].ToString()!="")
				{
					model.Isko=int.Parse(ds.Tables[0].Rows[0]["Isko"].ToString());
				}
				model.lt=ds.Tables[0].Rows[0]["lt"].ToString();
				if(ds.Tables[0].Rows[0]["Islt"].ToString()!="")
				{
					model.Islt=int.Parse(ds.Tables[0].Rows[0]["Islt"].ToString());
				}
				model.mk=ds.Tables[0].Rows[0]["mk"].ToString();
				if(ds.Tables[0].Rows[0]["Ismk"].ToString()!="")
				{
					model.Ismk=int.Parse(ds.Tables[0].Rows[0]["Ismk"].ToString());
				}
				model.ms=ds.Tables[0].Rows[0]["ms"].ToString();
				if(ds.Tables[0].Rows[0]["Isms"].ToString()!="")
				{
					model.Isms=int.Parse(ds.Tables[0].Rows[0]["Isms"].ToString());
				}
				model.nl=ds.Tables[0].Rows[0]["nl"].ToString();
				if(ds.Tables[0].Rows[0]["Isnl"].ToString()!="")
				{
					model.Isnl=int.Parse(ds.Tables[0].Rows[0]["Isnl"].ToString());
				}
				model.no=ds.Tables[0].Rows[0]["no"].ToString();
				if(ds.Tables[0].Rows[0]["Isno"].ToString()!="")
				{
					model.Isno=int.Parse(ds.Tables[0].Rows[0]["Isno"].ToString());
				}
				model.pl=ds.Tables[0].Rows[0]["pl"].ToString();
				if(ds.Tables[0].Rows[0]["Ispl"].ToString()!="")
				{
					model.Ispl=int.Parse(ds.Tables[0].Rows[0]["Ispl"].ToString());
				}
				model.pt=ds.Tables[0].Rows[0]["pt"].ToString();
				if(ds.Tables[0].Rows[0]["Ispt"].ToString()!="")
				{
					model.Ispt=int.Parse(ds.Tables[0].Rows[0]["Ispt"].ToString());
				}
				model.ro=ds.Tables[0].Rows[0]["ro"].ToString();
				if(ds.Tables[0].Rows[0]["Isro"].ToString()!="")
				{
					model.Isro=int.Parse(ds.Tables[0].Rows[0]["Isro"].ToString());
				}
				model.tw=ds.Tables[0].Rows[0]["tw"].ToString();
				model.tcn=ds.Tables[0].Rows[0]["tcn"].ToString();
				if(ds.Tables[0].Rows[0]["Istcn"].ToString()!="")
				{
					model.Istcn=int.Parse(ds.Tables[0].Rows[0]["Istcn"].ToString());
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
		public Lebi_Language_Tag GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Language_Tag] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Language_Tag model=new Lebi_Language_Tag();
			DataSet ds=SqlUtils.SqlUtilsInstance.TextExecuteDataset(strSql.ToString(),para.Para);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.tag=ds.Tables[0].Rows[0]["tag"].ToString();
				model.CN=ds.Tables[0].Rows[0]["CN"].ToString();
				if(ds.Tables[0].Rows[0]["IsCN"].ToString()!="")
				{
					model.IsCN=int.Parse(ds.Tables[0].Rows[0]["IsCN"].ToString());
				}
				model.EN=ds.Tables[0].Rows[0]["EN"].ToString();
				if(ds.Tables[0].Rows[0]["IsEN"].ToString()!="")
				{
					model.IsEN=int.Parse(ds.Tables[0].Rows[0]["IsEN"].ToString());
				}
				model.ja=ds.Tables[0].Rows[0]["ja"].ToString();
				if(ds.Tables[0].Rows[0]["Isja"].ToString()!="")
				{
					model.Isja=int.Parse(ds.Tables[0].Rows[0]["Isja"].ToString());
				}
				model.ar=ds.Tables[0].Rows[0]["ar"].ToString();
				if(ds.Tables[0].Rows[0]["Isar"].ToString()!="")
				{
					model.Isar=int.Parse(ds.Tables[0].Rows[0]["Isar"].ToString());
				}
				model.ca=ds.Tables[0].Rows[0]["ca"].ToString();
				if(ds.Tables[0].Rows[0]["Isca"].ToString()!="")
				{
					model.Isca=int.Parse(ds.Tables[0].Rows[0]["Isca"].ToString());
				}
				model.cs=ds.Tables[0].Rows[0]["cs"].ToString();
				if(ds.Tables[0].Rows[0]["Iscs"].ToString()!="")
				{
					model.Iscs=int.Parse(ds.Tables[0].Rows[0]["Iscs"].ToString());
				}
				model.cy=ds.Tables[0].Rows[0]["cy"].ToString();
				if(ds.Tables[0].Rows[0]["Iscy"].ToString()!="")
				{
					model.Iscy=int.Parse(ds.Tables[0].Rows[0]["Iscy"].ToString());
				}
				model.da=ds.Tables[0].Rows[0]["da"].ToString();
				if(ds.Tables[0].Rows[0]["Isda"].ToString()!="")
				{
					model.Isda=int.Parse(ds.Tables[0].Rows[0]["Isda"].ToString());
				}
				model.de=ds.Tables[0].Rows[0]["de"].ToString();
				if(ds.Tables[0].Rows[0]["Isde"].ToString()!="")
				{
					model.Isde=int.Parse(ds.Tables[0].Rows[0]["Isde"].ToString());
				}
				model.el=ds.Tables[0].Rows[0]["el"].ToString();
				if(ds.Tables[0].Rows[0]["Isel"].ToString()!="")
				{
					model.Isel=int.Parse(ds.Tables[0].Rows[0]["Isel"].ToString());
				}
				model.es=ds.Tables[0].Rows[0]["es"].ToString();
				if(ds.Tables[0].Rows[0]["Ises"].ToString()!="")
				{
					model.Ises=int.Parse(ds.Tables[0].Rows[0]["Ises"].ToString());
				}
				model.eu=ds.Tables[0].Rows[0]["eu"].ToString();
				if(ds.Tables[0].Rows[0]["Iseu"].ToString()!="")
				{
					model.Iseu=int.Parse(ds.Tables[0].Rows[0]["Iseu"].ToString());
				}
				model.fa=ds.Tables[0].Rows[0]["fa"].ToString();
				if(ds.Tables[0].Rows[0]["Isfa"].ToString()!="")
				{
					model.Isfa=int.Parse(ds.Tables[0].Rows[0]["Isfa"].ToString());
				}
				model.fi=ds.Tables[0].Rows[0]["fi"].ToString();
				if(ds.Tables[0].Rows[0]["Isfi"].ToString()!="")
				{
					model.Isfi=int.Parse(ds.Tables[0].Rows[0]["Isfi"].ToString());
				}
				model.fr=ds.Tables[0].Rows[0]["fr"].ToString();
				if(ds.Tables[0].Rows[0]["Isfr"].ToString()!="")
				{
					model.Isfr=int.Parse(ds.Tables[0].Rows[0]["Isfr"].ToString());
				}
				model.gl=ds.Tables[0].Rows[0]["gl"].ToString();
				if(ds.Tables[0].Rows[0]["Isgl"].ToString()!="")
				{
					model.Isgl=int.Parse(ds.Tables[0].Rows[0]["Isgl"].ToString());
				}
				model.he=ds.Tables[0].Rows[0]["he"].ToString();
				if(ds.Tables[0].Rows[0]["Ishe"].ToString()!="")
				{
					model.Ishe=int.Parse(ds.Tables[0].Rows[0]["Ishe"].ToString());
				}
				model.hr=ds.Tables[0].Rows[0]["hr"].ToString();
				if(ds.Tables[0].Rows[0]["Ishr"].ToString()!="")
				{
					model.Ishr=int.Parse(ds.Tables[0].Rows[0]["Ishr"].ToString());
				}
				model.ru=ds.Tables[0].Rows[0]["ru"].ToString();
				if(ds.Tables[0].Rows[0]["Isru"].ToString()!="")
				{
					model.Isru=int.Parse(ds.Tables[0].Rows[0]["Isru"].ToString());
				}
				model.sv=ds.Tables[0].Rows[0]["sv"].ToString();
				if(ds.Tables[0].Rows[0]["Issv"].ToString()!="")
				{
					model.Issv=int.Parse(ds.Tables[0].Rows[0]["Issv"].ToString());
				}
				model.ta=ds.Tables[0].Rows[0]["ta"].ToString();
				if(ds.Tables[0].Rows[0]["Ista"].ToString()!="")
				{
					model.Ista=int.Parse(ds.Tables[0].Rows[0]["Ista"].ToString());
				}
				model.th=ds.Tables[0].Rows[0]["th"].ToString();
				if(ds.Tables[0].Rows[0]["Isth"].ToString()!="")
				{
					model.Isth=int.Parse(ds.Tables[0].Rows[0]["Isth"].ToString());
				}
				model.tr=ds.Tables[0].Rows[0]["tr"].ToString();
				if(ds.Tables[0].Rows[0]["Istr"].ToString()!="")
				{
					model.Istr=int.Parse(ds.Tables[0].Rows[0]["Istr"].ToString());
				}
				model.uk=ds.Tables[0].Rows[0]["uk"].ToString();
				if(ds.Tables[0].Rows[0]["Isuk"].ToString()!="")
				{
					model.Isuk=int.Parse(ds.Tables[0].Rows[0]["Isuk"].ToString());
				}
				model.vi=ds.Tables[0].Rows[0]["vi"].ToString();
				if(ds.Tables[0].Rows[0]["Isvi"].ToString()!="")
				{
					model.Isvi=int.Parse(ds.Tables[0].Rows[0]["Isvi"].ToString());
				}
				model.hu=ds.Tables[0].Rows[0]["hu"].ToString();
				if(ds.Tables[0].Rows[0]["Ishu"].ToString()!="")
				{
					model.Ishu=int.Parse(ds.Tables[0].Rows[0]["Ishu"].ToString());
				}
				model.id_=ds.Tables[0].Rows[0]["id_"].ToString();
				if(ds.Tables[0].Rows[0]["Isid_"].ToString()!="")
				{
					model.Isid_=int.Parse(ds.Tables[0].Rows[0]["Isid_"].ToString());
				}
				model.it=ds.Tables[0].Rows[0]["it"].ToString();
				if(ds.Tables[0].Rows[0]["Isit"].ToString()!="")
				{
					model.Isit=int.Parse(ds.Tables[0].Rows[0]["Isit"].ToString());
				}
				model.ka=ds.Tables[0].Rows[0]["ka"].ToString();
				if(ds.Tables[0].Rows[0]["Iska"].ToString()!="")
				{
					model.Iska=int.Parse(ds.Tables[0].Rows[0]["Iska"].ToString());
				}
				model.ko=ds.Tables[0].Rows[0]["ko"].ToString();
				if(ds.Tables[0].Rows[0]["Isko"].ToString()!="")
				{
					model.Isko=int.Parse(ds.Tables[0].Rows[0]["Isko"].ToString());
				}
				model.lt=ds.Tables[0].Rows[0]["lt"].ToString();
				if(ds.Tables[0].Rows[0]["Islt"].ToString()!="")
				{
					model.Islt=int.Parse(ds.Tables[0].Rows[0]["Islt"].ToString());
				}
				model.mk=ds.Tables[0].Rows[0]["mk"].ToString();
				if(ds.Tables[0].Rows[0]["Ismk"].ToString()!="")
				{
					model.Ismk=int.Parse(ds.Tables[0].Rows[0]["Ismk"].ToString());
				}
				model.ms=ds.Tables[0].Rows[0]["ms"].ToString();
				if(ds.Tables[0].Rows[0]["Isms"].ToString()!="")
				{
					model.Isms=int.Parse(ds.Tables[0].Rows[0]["Isms"].ToString());
				}
				model.nl=ds.Tables[0].Rows[0]["nl"].ToString();
				if(ds.Tables[0].Rows[0]["Isnl"].ToString()!="")
				{
					model.Isnl=int.Parse(ds.Tables[0].Rows[0]["Isnl"].ToString());
				}
				model.no=ds.Tables[0].Rows[0]["no"].ToString();
				if(ds.Tables[0].Rows[0]["Isno"].ToString()!="")
				{
					model.Isno=int.Parse(ds.Tables[0].Rows[0]["Isno"].ToString());
				}
				model.pl=ds.Tables[0].Rows[0]["pl"].ToString();
				if(ds.Tables[0].Rows[0]["Ispl"].ToString()!="")
				{
					model.Ispl=int.Parse(ds.Tables[0].Rows[0]["Ispl"].ToString());
				}
				model.pt=ds.Tables[0].Rows[0]["pt"].ToString();
				if(ds.Tables[0].Rows[0]["Ispt"].ToString()!="")
				{
					model.Ispt=int.Parse(ds.Tables[0].Rows[0]["Ispt"].ToString());
				}
				model.ro=ds.Tables[0].Rows[0]["ro"].ToString();
				if(ds.Tables[0].Rows[0]["Isro"].ToString()!="")
				{
					model.Isro=int.Parse(ds.Tables[0].Rows[0]["Isro"].ToString());
				}
				model.tw=ds.Tables[0].Rows[0]["tw"].ToString();
				model.tcn=ds.Tables[0].Rows[0]["tcn"].ToString();
				if(ds.Tables[0].Rows[0]["Istcn"].ToString()!="")
				{
					model.Istcn=int.Parse(ds.Tables[0].Rows[0]["Istcn"].ToString());
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
		public List<Lebi_Language_Tag> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Language_Tag]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Language_Tag> list = new List<Lebi_Language_Tag>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.StoredProcedureExecuteReader("usp_CommonPagination", strTableName, strFieldKey, strFieldShow, strFieldOrder, strWhere, PageSize, page))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
				return list;
			}
		}
		public List<Lebi_Language_Tag> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Language_Tag]";
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
			List<Lebi_Language_Tag> list = new List<Lebi_Language_Tag>();
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
		public List<Lebi_Language_Tag> GetList(string strWhere,string strFieldOrder)
		{
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Language_Tag] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Language_Tag> list = new List<Lebi_Language_Tag>();
			using (IDataReader dataReader = SqlUtils.SqlUtilsInstance.TextExecuteReader(strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}
		public List<Lebi_Language_Tag> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Language_Tag]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Language_Tag> list = new List<Lebi_Language_Tag>();
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
		public Lebi_Language_Tag BindForm(Lebi_Language_Tag model)
		{
			if (HttpContext.Current.Request["tag"] != null)
				model.tag=Shop.Tools.RequestTool.RequestString("tag");
			if (HttpContext.Current.Request["CN"] != null)
				model.CN=Shop.Tools.RequestTool.RequestString("CN");
			if (HttpContext.Current.Request["IsCN"] != null)
				model.IsCN=Shop.Tools.RequestTool.RequestInt("IsCN",0);
			if (HttpContext.Current.Request["EN"] != null)
				model.EN=Shop.Tools.RequestTool.RequestString("EN");
			if (HttpContext.Current.Request["IsEN"] != null)
				model.IsEN=Shop.Tools.RequestTool.RequestInt("IsEN",0);
			if (HttpContext.Current.Request["ja"] != null)
				model.ja=Shop.Tools.RequestTool.RequestString("ja");
			if (HttpContext.Current.Request["Isja"] != null)
				model.Isja=Shop.Tools.RequestTool.RequestInt("Isja",0);
			if (HttpContext.Current.Request["ar"] != null)
				model.ar=Shop.Tools.RequestTool.RequestString("ar");
			if (HttpContext.Current.Request["Isar"] != null)
				model.Isar=Shop.Tools.RequestTool.RequestInt("Isar",0);
			if (HttpContext.Current.Request["ca"] != null)
				model.ca=Shop.Tools.RequestTool.RequestString("ca");
			if (HttpContext.Current.Request["Isca"] != null)
				model.Isca=Shop.Tools.RequestTool.RequestInt("Isca",0);
			if (HttpContext.Current.Request["cs"] != null)
				model.cs=Shop.Tools.RequestTool.RequestString("cs");
			if (HttpContext.Current.Request["Iscs"] != null)
				model.Iscs=Shop.Tools.RequestTool.RequestInt("Iscs",0);
			if (HttpContext.Current.Request["cy"] != null)
				model.cy=Shop.Tools.RequestTool.RequestString("cy");
			if (HttpContext.Current.Request["Iscy"] != null)
				model.Iscy=Shop.Tools.RequestTool.RequestInt("Iscy",0);
			if (HttpContext.Current.Request["da"] != null)
				model.da=Shop.Tools.RequestTool.RequestString("da");
			if (HttpContext.Current.Request["Isda"] != null)
				model.Isda=Shop.Tools.RequestTool.RequestInt("Isda",0);
			if (HttpContext.Current.Request["de"] != null)
				model.de=Shop.Tools.RequestTool.RequestString("de");
			if (HttpContext.Current.Request["Isde"] != null)
				model.Isde=Shop.Tools.RequestTool.RequestInt("Isde",0);
			if (HttpContext.Current.Request["el"] != null)
				model.el=Shop.Tools.RequestTool.RequestString("el");
			if (HttpContext.Current.Request["Isel"] != null)
				model.Isel=Shop.Tools.RequestTool.RequestInt("Isel",0);
			if (HttpContext.Current.Request["es"] != null)
				model.es=Shop.Tools.RequestTool.RequestString("es");
			if (HttpContext.Current.Request["Ises"] != null)
				model.Ises=Shop.Tools.RequestTool.RequestInt("Ises",0);
			if (HttpContext.Current.Request["eu"] != null)
				model.eu=Shop.Tools.RequestTool.RequestString("eu");
			if (HttpContext.Current.Request["Iseu"] != null)
				model.Iseu=Shop.Tools.RequestTool.RequestInt("Iseu",0);
			if (HttpContext.Current.Request["fa"] != null)
				model.fa=Shop.Tools.RequestTool.RequestString("fa");
			if (HttpContext.Current.Request["Isfa"] != null)
				model.Isfa=Shop.Tools.RequestTool.RequestInt("Isfa",0);
			if (HttpContext.Current.Request["fi"] != null)
				model.fi=Shop.Tools.RequestTool.RequestString("fi");
			if (HttpContext.Current.Request["Isfi"] != null)
				model.Isfi=Shop.Tools.RequestTool.RequestInt("Isfi",0);
			if (HttpContext.Current.Request["fr"] != null)
				model.fr=Shop.Tools.RequestTool.RequestString("fr");
			if (HttpContext.Current.Request["Isfr"] != null)
				model.Isfr=Shop.Tools.RequestTool.RequestInt("Isfr",0);
			if (HttpContext.Current.Request["gl"] != null)
				model.gl=Shop.Tools.RequestTool.RequestString("gl");
			if (HttpContext.Current.Request["Isgl"] != null)
				model.Isgl=Shop.Tools.RequestTool.RequestInt("Isgl",0);
			if (HttpContext.Current.Request["he"] != null)
				model.he=Shop.Tools.RequestTool.RequestString("he");
			if (HttpContext.Current.Request["Ishe"] != null)
				model.Ishe=Shop.Tools.RequestTool.RequestInt("Ishe",0);
			if (HttpContext.Current.Request["hr"] != null)
				model.hr=Shop.Tools.RequestTool.RequestString("hr");
			if (HttpContext.Current.Request["Ishr"] != null)
				model.Ishr=Shop.Tools.RequestTool.RequestInt("Ishr",0);
			if (HttpContext.Current.Request["ru"] != null)
				model.ru=Shop.Tools.RequestTool.RequestString("ru");
			if (HttpContext.Current.Request["Isru"] != null)
				model.Isru=Shop.Tools.RequestTool.RequestInt("Isru",0);
			if (HttpContext.Current.Request["sv"] != null)
				model.sv=Shop.Tools.RequestTool.RequestString("sv");
			if (HttpContext.Current.Request["Issv"] != null)
				model.Issv=Shop.Tools.RequestTool.RequestInt("Issv",0);
			if (HttpContext.Current.Request["ta"] != null)
				model.ta=Shop.Tools.RequestTool.RequestString("ta");
			if (HttpContext.Current.Request["Ista"] != null)
				model.Ista=Shop.Tools.RequestTool.RequestInt("Ista",0);
			if (HttpContext.Current.Request["th"] != null)
				model.th=Shop.Tools.RequestTool.RequestString("th");
			if (HttpContext.Current.Request["Isth"] != null)
				model.Isth=Shop.Tools.RequestTool.RequestInt("Isth",0);
			if (HttpContext.Current.Request["tr"] != null)
				model.tr=Shop.Tools.RequestTool.RequestString("tr");
			if (HttpContext.Current.Request["Istr"] != null)
				model.Istr=Shop.Tools.RequestTool.RequestInt("Istr",0);
			if (HttpContext.Current.Request["uk"] != null)
				model.uk=Shop.Tools.RequestTool.RequestString("uk");
			if (HttpContext.Current.Request["Isuk"] != null)
				model.Isuk=Shop.Tools.RequestTool.RequestInt("Isuk",0);
			if (HttpContext.Current.Request["vi"] != null)
				model.vi=Shop.Tools.RequestTool.RequestString("vi");
			if (HttpContext.Current.Request["Isvi"] != null)
				model.Isvi=Shop.Tools.RequestTool.RequestInt("Isvi",0);
			if (HttpContext.Current.Request["hu"] != null)
				model.hu=Shop.Tools.RequestTool.RequestString("hu");
			if (HttpContext.Current.Request["Ishu"] != null)
				model.Ishu=Shop.Tools.RequestTool.RequestInt("Ishu",0);
			if (HttpContext.Current.Request["id_"] != null)
				model.id_=Shop.Tools.RequestTool.RequestString("id_");
			if (HttpContext.Current.Request["Isid_"] != null)
				model.Isid_=Shop.Tools.RequestTool.RequestInt("Isid_",0);
			if (HttpContext.Current.Request["it"] != null)
				model.it=Shop.Tools.RequestTool.RequestString("it");
			if (HttpContext.Current.Request["Isit"] != null)
				model.Isit=Shop.Tools.RequestTool.RequestInt("Isit",0);
			if (HttpContext.Current.Request["ka"] != null)
				model.ka=Shop.Tools.RequestTool.RequestString("ka");
			if (HttpContext.Current.Request["Iska"] != null)
				model.Iska=Shop.Tools.RequestTool.RequestInt("Iska",0);
			if (HttpContext.Current.Request["ko"] != null)
				model.ko=Shop.Tools.RequestTool.RequestString("ko");
			if (HttpContext.Current.Request["Isko"] != null)
				model.Isko=Shop.Tools.RequestTool.RequestInt("Isko",0);
			if (HttpContext.Current.Request["lt"] != null)
				model.lt=Shop.Tools.RequestTool.RequestString("lt");
			if (HttpContext.Current.Request["Islt"] != null)
				model.Islt=Shop.Tools.RequestTool.RequestInt("Islt",0);
			if (HttpContext.Current.Request["mk"] != null)
				model.mk=Shop.Tools.RequestTool.RequestString("mk");
			if (HttpContext.Current.Request["Ismk"] != null)
				model.Ismk=Shop.Tools.RequestTool.RequestInt("Ismk",0);
			if (HttpContext.Current.Request["ms"] != null)
				model.ms=Shop.Tools.RequestTool.RequestString("ms");
			if (HttpContext.Current.Request["Isms"] != null)
				model.Isms=Shop.Tools.RequestTool.RequestInt("Isms",0);
			if (HttpContext.Current.Request["nl"] != null)
				model.nl=Shop.Tools.RequestTool.RequestString("nl");
			if (HttpContext.Current.Request["Isnl"] != null)
				model.Isnl=Shop.Tools.RequestTool.RequestInt("Isnl",0);
			if (HttpContext.Current.Request["no"] != null)
				model.no=Shop.Tools.RequestTool.RequestString("no");
			if (HttpContext.Current.Request["Isno"] != null)
				model.Isno=Shop.Tools.RequestTool.RequestInt("Isno",0);
			if (HttpContext.Current.Request["pl"] != null)
				model.pl=Shop.Tools.RequestTool.RequestString("pl");
			if (HttpContext.Current.Request["Ispl"] != null)
				model.Ispl=Shop.Tools.RequestTool.RequestInt("Ispl",0);
			if (HttpContext.Current.Request["pt"] != null)
				model.pt=Shop.Tools.RequestTool.RequestString("pt");
			if (HttpContext.Current.Request["Ispt"] != null)
				model.Ispt=Shop.Tools.RequestTool.RequestInt("Ispt",0);
			if (HttpContext.Current.Request["ro"] != null)
				model.ro=Shop.Tools.RequestTool.RequestString("ro");
			if (HttpContext.Current.Request["Isro"] != null)
				model.Isro=Shop.Tools.RequestTool.RequestInt("Isro",0);
			if (HttpContext.Current.Request["tw"] != null)
				model.tw=Shop.Tools.RequestTool.RequestString("tw");
			if (HttpContext.Current.Request["tcn"] != null)
				model.tcn=Shop.Tools.RequestTool.RequestString("tcn");
			if (HttpContext.Current.Request["Istcn"] != null)
				model.Istcn=Shop.Tools.RequestTool.RequestInt("Istcn",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Language_Tag SafeBindForm(Lebi_Language_Tag model)
		{
			if (HttpContext.Current.Request["tag"] != null)
				model.tag=Shop.Tools.RequestTool.RequestSafeString("tag");
			if (HttpContext.Current.Request["CN"] != null)
				model.CN=Shop.Tools.RequestTool.RequestSafeString("CN");
			if (HttpContext.Current.Request["IsCN"] != null)
				model.IsCN=Shop.Tools.RequestTool.RequestInt("IsCN",0);
			if (HttpContext.Current.Request["EN"] != null)
				model.EN=Shop.Tools.RequestTool.RequestSafeString("EN");
			if (HttpContext.Current.Request["IsEN"] != null)
				model.IsEN=Shop.Tools.RequestTool.RequestInt("IsEN",0);
			if (HttpContext.Current.Request["ja"] != null)
				model.ja=Shop.Tools.RequestTool.RequestSafeString("ja");
			if (HttpContext.Current.Request["Isja"] != null)
				model.Isja=Shop.Tools.RequestTool.RequestInt("Isja",0);
			if (HttpContext.Current.Request["ar"] != null)
				model.ar=Shop.Tools.RequestTool.RequestSafeString("ar");
			if (HttpContext.Current.Request["Isar"] != null)
				model.Isar=Shop.Tools.RequestTool.RequestInt("Isar",0);
			if (HttpContext.Current.Request["ca"] != null)
				model.ca=Shop.Tools.RequestTool.RequestSafeString("ca");
			if (HttpContext.Current.Request["Isca"] != null)
				model.Isca=Shop.Tools.RequestTool.RequestInt("Isca",0);
			if (HttpContext.Current.Request["cs"] != null)
				model.cs=Shop.Tools.RequestTool.RequestSafeString("cs");
			if (HttpContext.Current.Request["Iscs"] != null)
				model.Iscs=Shop.Tools.RequestTool.RequestInt("Iscs",0);
			if (HttpContext.Current.Request["cy"] != null)
				model.cy=Shop.Tools.RequestTool.RequestSafeString("cy");
			if (HttpContext.Current.Request["Iscy"] != null)
				model.Iscy=Shop.Tools.RequestTool.RequestInt("Iscy",0);
			if (HttpContext.Current.Request["da"] != null)
				model.da=Shop.Tools.RequestTool.RequestSafeString("da");
			if (HttpContext.Current.Request["Isda"] != null)
				model.Isda=Shop.Tools.RequestTool.RequestInt("Isda",0);
			if (HttpContext.Current.Request["de"] != null)
				model.de=Shop.Tools.RequestTool.RequestSafeString("de");
			if (HttpContext.Current.Request["Isde"] != null)
				model.Isde=Shop.Tools.RequestTool.RequestInt("Isde",0);
			if (HttpContext.Current.Request["el"] != null)
				model.el=Shop.Tools.RequestTool.RequestSafeString("el");
			if (HttpContext.Current.Request["Isel"] != null)
				model.Isel=Shop.Tools.RequestTool.RequestInt("Isel",0);
			if (HttpContext.Current.Request["es"] != null)
				model.es=Shop.Tools.RequestTool.RequestSafeString("es");
			if (HttpContext.Current.Request["Ises"] != null)
				model.Ises=Shop.Tools.RequestTool.RequestInt("Ises",0);
			if (HttpContext.Current.Request["eu"] != null)
				model.eu=Shop.Tools.RequestTool.RequestSafeString("eu");
			if (HttpContext.Current.Request["Iseu"] != null)
				model.Iseu=Shop.Tools.RequestTool.RequestInt("Iseu",0);
			if (HttpContext.Current.Request["fa"] != null)
				model.fa=Shop.Tools.RequestTool.RequestSafeString("fa");
			if (HttpContext.Current.Request["Isfa"] != null)
				model.Isfa=Shop.Tools.RequestTool.RequestInt("Isfa",0);
			if (HttpContext.Current.Request["fi"] != null)
				model.fi=Shop.Tools.RequestTool.RequestSafeString("fi");
			if (HttpContext.Current.Request["Isfi"] != null)
				model.Isfi=Shop.Tools.RequestTool.RequestInt("Isfi",0);
			if (HttpContext.Current.Request["fr"] != null)
				model.fr=Shop.Tools.RequestTool.RequestSafeString("fr");
			if (HttpContext.Current.Request["Isfr"] != null)
				model.Isfr=Shop.Tools.RequestTool.RequestInt("Isfr",0);
			if (HttpContext.Current.Request["gl"] != null)
				model.gl=Shop.Tools.RequestTool.RequestSafeString("gl");
			if (HttpContext.Current.Request["Isgl"] != null)
				model.Isgl=Shop.Tools.RequestTool.RequestInt("Isgl",0);
			if (HttpContext.Current.Request["he"] != null)
				model.he=Shop.Tools.RequestTool.RequestSafeString("he");
			if (HttpContext.Current.Request["Ishe"] != null)
				model.Ishe=Shop.Tools.RequestTool.RequestInt("Ishe",0);
			if (HttpContext.Current.Request["hr"] != null)
				model.hr=Shop.Tools.RequestTool.RequestSafeString("hr");
			if (HttpContext.Current.Request["Ishr"] != null)
				model.Ishr=Shop.Tools.RequestTool.RequestInt("Ishr",0);
			if (HttpContext.Current.Request["ru"] != null)
				model.ru=Shop.Tools.RequestTool.RequestSafeString("ru");
			if (HttpContext.Current.Request["Isru"] != null)
				model.Isru=Shop.Tools.RequestTool.RequestInt("Isru",0);
			if (HttpContext.Current.Request["sv"] != null)
				model.sv=Shop.Tools.RequestTool.RequestSafeString("sv");
			if (HttpContext.Current.Request["Issv"] != null)
				model.Issv=Shop.Tools.RequestTool.RequestInt("Issv",0);
			if (HttpContext.Current.Request["ta"] != null)
				model.ta=Shop.Tools.RequestTool.RequestSafeString("ta");
			if (HttpContext.Current.Request["Ista"] != null)
				model.Ista=Shop.Tools.RequestTool.RequestInt("Ista",0);
			if (HttpContext.Current.Request["th"] != null)
				model.th=Shop.Tools.RequestTool.RequestSafeString("th");
			if (HttpContext.Current.Request["Isth"] != null)
				model.Isth=Shop.Tools.RequestTool.RequestInt("Isth",0);
			if (HttpContext.Current.Request["tr"] != null)
				model.tr=Shop.Tools.RequestTool.RequestSafeString("tr");
			if (HttpContext.Current.Request["Istr"] != null)
				model.Istr=Shop.Tools.RequestTool.RequestInt("Istr",0);
			if (HttpContext.Current.Request["uk"] != null)
				model.uk=Shop.Tools.RequestTool.RequestSafeString("uk");
			if (HttpContext.Current.Request["Isuk"] != null)
				model.Isuk=Shop.Tools.RequestTool.RequestInt("Isuk",0);
			if (HttpContext.Current.Request["vi"] != null)
				model.vi=Shop.Tools.RequestTool.RequestSafeString("vi");
			if (HttpContext.Current.Request["Isvi"] != null)
				model.Isvi=Shop.Tools.RequestTool.RequestInt("Isvi",0);
			if (HttpContext.Current.Request["hu"] != null)
				model.hu=Shop.Tools.RequestTool.RequestSafeString("hu");
			if (HttpContext.Current.Request["Ishu"] != null)
				model.Ishu=Shop.Tools.RequestTool.RequestInt("Ishu",0);
			if (HttpContext.Current.Request["id_"] != null)
				model.id_=Shop.Tools.RequestTool.RequestSafeString("id_");
			if (HttpContext.Current.Request["Isid_"] != null)
				model.Isid_=Shop.Tools.RequestTool.RequestInt("Isid_",0);
			if (HttpContext.Current.Request["it"] != null)
				model.it=Shop.Tools.RequestTool.RequestSafeString("it");
			if (HttpContext.Current.Request["Isit"] != null)
				model.Isit=Shop.Tools.RequestTool.RequestInt("Isit",0);
			if (HttpContext.Current.Request["ka"] != null)
				model.ka=Shop.Tools.RequestTool.RequestSafeString("ka");
			if (HttpContext.Current.Request["Iska"] != null)
				model.Iska=Shop.Tools.RequestTool.RequestInt("Iska",0);
			if (HttpContext.Current.Request["ko"] != null)
				model.ko=Shop.Tools.RequestTool.RequestSafeString("ko");
			if (HttpContext.Current.Request["Isko"] != null)
				model.Isko=Shop.Tools.RequestTool.RequestInt("Isko",0);
			if (HttpContext.Current.Request["lt"] != null)
				model.lt=Shop.Tools.RequestTool.RequestSafeString("lt");
			if (HttpContext.Current.Request["Islt"] != null)
				model.Islt=Shop.Tools.RequestTool.RequestInt("Islt",0);
			if (HttpContext.Current.Request["mk"] != null)
				model.mk=Shop.Tools.RequestTool.RequestSafeString("mk");
			if (HttpContext.Current.Request["Ismk"] != null)
				model.Ismk=Shop.Tools.RequestTool.RequestInt("Ismk",0);
			if (HttpContext.Current.Request["ms"] != null)
				model.ms=Shop.Tools.RequestTool.RequestSafeString("ms");
			if (HttpContext.Current.Request["Isms"] != null)
				model.Isms=Shop.Tools.RequestTool.RequestInt("Isms",0);
			if (HttpContext.Current.Request["nl"] != null)
				model.nl=Shop.Tools.RequestTool.RequestSafeString("nl");
			if (HttpContext.Current.Request["Isnl"] != null)
				model.Isnl=Shop.Tools.RequestTool.RequestInt("Isnl",0);
			if (HttpContext.Current.Request["no"] != null)
				model.no=Shop.Tools.RequestTool.RequestSafeString("no");
			if (HttpContext.Current.Request["Isno"] != null)
				model.Isno=Shop.Tools.RequestTool.RequestInt("Isno",0);
			if (HttpContext.Current.Request["pl"] != null)
				model.pl=Shop.Tools.RequestTool.RequestSafeString("pl");
			if (HttpContext.Current.Request["Ispl"] != null)
				model.Ispl=Shop.Tools.RequestTool.RequestInt("Ispl",0);
			if (HttpContext.Current.Request["pt"] != null)
				model.pt=Shop.Tools.RequestTool.RequestSafeString("pt");
			if (HttpContext.Current.Request["Ispt"] != null)
				model.Ispt=Shop.Tools.RequestTool.RequestInt("Ispt",0);
			if (HttpContext.Current.Request["ro"] != null)
				model.ro=Shop.Tools.RequestTool.RequestSafeString("ro");
			if (HttpContext.Current.Request["Isro"] != null)
				model.Isro=Shop.Tools.RequestTool.RequestInt("Isro",0);
			if (HttpContext.Current.Request["tw"] != null)
				model.tw=Shop.Tools.RequestTool.RequestSafeString("tw");
			if (HttpContext.Current.Request["tcn"] != null)
				model.tcn=Shop.Tools.RequestTool.RequestSafeString("tcn");
			if (HttpContext.Current.Request["Istcn"] != null)
				model.Istcn=Shop.Tools.RequestTool.RequestInt("Istcn",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Language_Tag ReaderBind(IDataReader dataReader)
		{
			Lebi_Language_Tag model=new Lebi_Language_Tag();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.tag=dataReader["tag"].ToString();
			model.CN=dataReader["CN"].ToString();
			ojb = dataReader["IsCN"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCN=(int)ojb;
			}
			model.EN=dataReader["EN"].ToString();
			ojb = dataReader["IsEN"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsEN=(int)ojb;
			}
			model.ja=dataReader["ja"].ToString();
			ojb = dataReader["Isja"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isja=(int)ojb;
			}
			model.ar=dataReader["ar"].ToString();
			ojb = dataReader["Isar"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isar=(int)ojb;
			}
			model.ca=dataReader["ca"].ToString();
			ojb = dataReader["Isca"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isca=(int)ojb;
			}
			model.cs=dataReader["cs"].ToString();
			ojb = dataReader["Iscs"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Iscs=(int)ojb;
			}
			model.cy=dataReader["cy"].ToString();
			ojb = dataReader["Iscy"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Iscy=(int)ojb;
			}
			model.da=dataReader["da"].ToString();
			ojb = dataReader["Isda"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isda=(int)ojb;
			}
			model.de=dataReader["de"].ToString();
			ojb = dataReader["Isde"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isde=(int)ojb;
			}
			model.el=dataReader["el"].ToString();
			ojb = dataReader["Isel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isel=(int)ojb;
			}
			model.es=dataReader["es"].ToString();
			ojb = dataReader["Ises"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ises=(int)ojb;
			}
			model.eu=dataReader["eu"].ToString();
			ojb = dataReader["Iseu"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Iseu=(int)ojb;
			}
			model.fa=dataReader["fa"].ToString();
			ojb = dataReader["Isfa"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isfa=(int)ojb;
			}
			model.fi=dataReader["fi"].ToString();
			ojb = dataReader["Isfi"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isfi=(int)ojb;
			}
			model.fr=dataReader["fr"].ToString();
			ojb = dataReader["Isfr"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isfr=(int)ojb;
			}
			model.gl=dataReader["gl"].ToString();
			ojb = dataReader["Isgl"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isgl=(int)ojb;
			}
			model.he=dataReader["he"].ToString();
			ojb = dataReader["Ishe"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ishe=(int)ojb;
			}
			model.hr=dataReader["hr"].ToString();
			ojb = dataReader["Ishr"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ishr=(int)ojb;
			}
			model.ru=dataReader["ru"].ToString();
			ojb = dataReader["Isru"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isru=(int)ojb;
			}
			model.sv=dataReader["sv"].ToString();
			ojb = dataReader["Issv"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Issv=(int)ojb;
			}
			model.ta=dataReader["ta"].ToString();
			ojb = dataReader["Ista"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ista=(int)ojb;
			}
			model.th=dataReader["th"].ToString();
			ojb = dataReader["Isth"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isth=(int)ojb;
			}
			model.tr=dataReader["tr"].ToString();
			ojb = dataReader["Istr"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Istr=(int)ojb;
			}
			model.uk=dataReader["uk"].ToString();
			ojb = dataReader["Isuk"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isuk=(int)ojb;
			}
			model.vi=dataReader["vi"].ToString();
			ojb = dataReader["Isvi"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isvi=(int)ojb;
			}
			model.hu=dataReader["hu"].ToString();
			ojb = dataReader["Ishu"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ishu=(int)ojb;
			}
			model.id_=dataReader["id_"].ToString();
			ojb = dataReader["Isid_"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isid_=(int)ojb;
			}
			model.it=dataReader["it"].ToString();
			ojb = dataReader["Isit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isit=(int)ojb;
			}
			model.ka=dataReader["ka"].ToString();
			ojb = dataReader["Iska"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Iska=(int)ojb;
			}
			model.ko=dataReader["ko"].ToString();
			ojb = dataReader["Isko"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isko=(int)ojb;
			}
			model.lt=dataReader["lt"].ToString();
			ojb = dataReader["Islt"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Islt=(int)ojb;
			}
			model.mk=dataReader["mk"].ToString();
			ojb = dataReader["Ismk"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ismk=(int)ojb;
			}
			model.ms=dataReader["ms"].ToString();
			ojb = dataReader["Isms"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isms=(int)ojb;
			}
			model.nl=dataReader["nl"].ToString();
			ojb = dataReader["Isnl"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isnl=(int)ojb;
			}
			model.no=dataReader["no"].ToString();
			ojb = dataReader["Isno"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isno=(int)ojb;
			}
			model.pl=dataReader["pl"].ToString();
			ojb = dataReader["Ispl"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ispl=(int)ojb;
			}
			model.pt=dataReader["pt"].ToString();
			ojb = dataReader["Ispt"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ispt=(int)ojb;
			}
			model.ro=dataReader["ro"].ToString();
			ojb = dataReader["Isro"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isro=(int)ojb;
			}
			model.tw=dataReader["tw"].ToString();
			model.tcn=dataReader["tcn"].ToString();
			ojb = dataReader["Istcn"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Istcn=(int)ojb;
			}
			return model;
		}

	}
	class access_Lebi_Language_Tag : Lebi_Language_Tag_interface
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
				strSql.Append("select " + colName + " from [Lebi_Language_Tag]");
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
			strSql.Append("select  "+colName+" from [Lebi_Language_Tag]");
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
			strSql.Append("select count(*) from [Lebi_Language_Tag]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null)); 
		}
		public int Counts(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(*) from [Lebi_Language_Tag]");
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
			strSql.Append("select max(id) from [Lebi_Language_Tag]");
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			return Convert.ToInt32(AccessUtils.Instance.TextExecuteScalar(strSql.ToString(),null));
		}
		public int GetMaxID(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Lebi_Language_Tag]");
			if(para.Where!="")
				strSql.Append(" where "+para.Where);
			return Convert.ToInt32( AccessUtils.Instance.TextExecuteScalar(strSql.ToString(), para.Para_Oledb)); 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Lebi_Language_Tag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Lebi_Language_Tag](");
			strSql.Append("[tag],[CN],[IsCN],[EN],[IsEN],[ja],[Isja],[ar],[Isar],[ca],[Isca],[cs],[Iscs],[cy],[Iscy],[da],[Isda],[de],[Isde],[el],[Isel],[es],[Ises],[eu],[Iseu],[fa],[Isfa],[fi],[Isfi],[fr],[Isfr],[gl],[Isgl],[he],[Ishe],[hr],[Ishr],[ru],[Isru],[sv],[Issv],[ta],[Ista],[th],[Isth],[tr],[Istr],[uk],[Isuk],[vi],[Isvi],[hu],[Ishu],[id_],[Isid_],[it],[Isit],[ka],[Iska],[ko],[Isko],[lt],[Islt],[mk],[Ismk],[ms],[Isms],[nl],[Isnl],[no],[Isno],[pl],[Ispl],[pt],[Ispt],[ro],[Isro],[tw],[tcn],[Istcn])");
			strSql.Append(" values (");
			strSql.Append("@tag,@CN,@IsCN,@EN,@IsEN,@ja,@Isja,@ar,@Isar,@ca,@Isca,@cs,@Iscs,@cy,@Iscy,@da,@Isda,@de,@Isde,@el,@Isel,@es,@Ises,@eu,@Iseu,@fa,@Isfa,@fi,@Isfi,@fr,@Isfr,@gl,@Isgl,@he,@Ishe,@hr,@Ishr,@ru,@Isru,@sv,@Issv,@ta,@Ista,@th,@Isth,@tr,@Istr,@uk,@Isuk,@vi,@Isvi,@hu,@Ishu,@id_,@Isid_,@it,@Isit,@ka,@Iska,@ko,@Isko,@lt,@Islt,@mk,@Ismk,@ms,@Isms,@nl,@Isnl,@no,@Isno,@pl,@Ispl,@pt,@Ispt,@ro,@Isro,@tw,@tcn,@Istcn)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@tag", model.tag),
					new OleDbParameter("@CN", model.CN),
					new OleDbParameter("@IsCN", model.IsCN),
					new OleDbParameter("@EN", model.EN),
					new OleDbParameter("@IsEN", model.IsEN),
					new OleDbParameter("@ja", model.ja),
					new OleDbParameter("@Isja", model.Isja),
					new OleDbParameter("@ar", model.ar),
					new OleDbParameter("@Isar", model.Isar),
					new OleDbParameter("@ca", model.ca),
					new OleDbParameter("@Isca", model.Isca),
					new OleDbParameter("@cs", model.cs),
					new OleDbParameter("@Iscs", model.Iscs),
					new OleDbParameter("@cy", model.cy),
					new OleDbParameter("@Iscy", model.Iscy),
					new OleDbParameter("@da", model.da),
					new OleDbParameter("@Isda", model.Isda),
					new OleDbParameter("@de", model.de),
					new OleDbParameter("@Isde", model.Isde),
					new OleDbParameter("@el", model.el),
					new OleDbParameter("@Isel", model.Isel),
					new OleDbParameter("@es", model.es),
					new OleDbParameter("@Ises", model.Ises),
					new OleDbParameter("@eu", model.eu),
					new OleDbParameter("@Iseu", model.Iseu),
					new OleDbParameter("@fa", model.fa),
					new OleDbParameter("@Isfa", model.Isfa),
					new OleDbParameter("@fi", model.fi),
					new OleDbParameter("@Isfi", model.Isfi),
					new OleDbParameter("@fr", model.fr),
					new OleDbParameter("@Isfr", model.Isfr),
					new OleDbParameter("@gl", model.gl),
					new OleDbParameter("@Isgl", model.Isgl),
					new OleDbParameter("@he", model.he),
					new OleDbParameter("@Ishe", model.Ishe),
					new OleDbParameter("@hr", model.hr),
					new OleDbParameter("@Ishr", model.Ishr),
					new OleDbParameter("@ru", model.ru),
					new OleDbParameter("@Isru", model.Isru),
					new OleDbParameter("@sv", model.sv),
					new OleDbParameter("@Issv", model.Issv),
					new OleDbParameter("@ta", model.ta),
					new OleDbParameter("@Ista", model.Ista),
					new OleDbParameter("@th", model.th),
					new OleDbParameter("@Isth", model.Isth),
					new OleDbParameter("@tr", model.tr),
					new OleDbParameter("@Istr", model.Istr),
					new OleDbParameter("@uk", model.uk),
					new OleDbParameter("@Isuk", model.Isuk),
					new OleDbParameter("@vi", model.vi),
					new OleDbParameter("@Isvi", model.Isvi),
					new OleDbParameter("@hu", model.hu),
					new OleDbParameter("@Ishu", model.Ishu),
					new OleDbParameter("@id_", model.id_),
					new OleDbParameter("@Isid_", model.Isid_),
					new OleDbParameter("@it", model.it),
					new OleDbParameter("@Isit", model.Isit),
					new OleDbParameter("@ka", model.ka),
					new OleDbParameter("@Iska", model.Iska),
					new OleDbParameter("@ko", model.ko),
					new OleDbParameter("@Isko", model.Isko),
					new OleDbParameter("@lt", model.lt),
					new OleDbParameter("@Islt", model.Islt),
					new OleDbParameter("@mk", model.mk),
					new OleDbParameter("@Ismk", model.Ismk),
					new OleDbParameter("@ms", model.ms),
					new OleDbParameter("@Isms", model.Isms),
					new OleDbParameter("@nl", model.nl),
					new OleDbParameter("@Isnl", model.Isnl),
					new OleDbParameter("@no", model.no),
					new OleDbParameter("@Isno", model.Isno),
					new OleDbParameter("@pl", model.pl),
					new OleDbParameter("@Ispl", model.Ispl),
					new OleDbParameter("@pt", model.pt),
					new OleDbParameter("@Ispt", model.Ispt),
					new OleDbParameter("@ro", model.ro),
					new OleDbParameter("@Isro", model.Isro),
					new OleDbParameter("@tw", model.tw),
					new OleDbParameter("@tcn", model.tcn),
					new OleDbParameter("@Istcn", model.Istcn)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
				return 1;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Lebi_Language_Tag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Lebi_Language_Tag] set ");
			strSql.Append("[tag]=@tag,");
			strSql.Append("[CN]=@CN,");
			strSql.Append("[IsCN]=@IsCN,");
			strSql.Append("[EN]=@EN,");
			strSql.Append("[IsEN]=@IsEN,");
			strSql.Append("[ja]=@ja,");
			strSql.Append("[Isja]=@Isja,");
			strSql.Append("[ar]=@ar,");
			strSql.Append("[Isar]=@Isar,");
			strSql.Append("[ca]=@ca,");
			strSql.Append("[Isca]=@Isca,");
			strSql.Append("[cs]=@cs,");
			strSql.Append("[Iscs]=@Iscs,");
			strSql.Append("[cy]=@cy,");
			strSql.Append("[Iscy]=@Iscy,");
			strSql.Append("[da]=@da,");
			strSql.Append("[Isda]=@Isda,");
			strSql.Append("[de]=@de,");
			strSql.Append("[Isde]=@Isde,");
			strSql.Append("[el]=@el,");
			strSql.Append("[Isel]=@Isel,");
			strSql.Append("[es]=@es,");
			strSql.Append("[Ises]=@Ises,");
			strSql.Append("[eu]=@eu,");
			strSql.Append("[Iseu]=@Iseu,");
			strSql.Append("[fa]=@fa,");
			strSql.Append("[Isfa]=@Isfa,");
			strSql.Append("[fi]=@fi,");
			strSql.Append("[Isfi]=@Isfi,");
			strSql.Append("[fr]=@fr,");
			strSql.Append("[Isfr]=@Isfr,");
			strSql.Append("[gl]=@gl,");
			strSql.Append("[Isgl]=@Isgl,");
			strSql.Append("[he]=@he,");
			strSql.Append("[Ishe]=@Ishe,");
			strSql.Append("[hr]=@hr,");
			strSql.Append("[Ishr]=@Ishr,");
			strSql.Append("[ru]=@ru,");
			strSql.Append("[Isru]=@Isru,");
			strSql.Append("[sv]=@sv,");
			strSql.Append("[Issv]=@Issv,");
			strSql.Append("[ta]=@ta,");
			strSql.Append("[Ista]=@Ista,");
			strSql.Append("[th]=@th,");
			strSql.Append("[Isth]=@Isth,");
			strSql.Append("[tr]=@tr,");
			strSql.Append("[Istr]=@Istr,");
			strSql.Append("[uk]=@uk,");
			strSql.Append("[Isuk]=@Isuk,");
			strSql.Append("[vi]=@vi,");
			strSql.Append("[Isvi]=@Isvi,");
			strSql.Append("[hu]=@hu,");
			strSql.Append("[Ishu]=@Ishu,");
			strSql.Append("[id_]=@id_,");
			strSql.Append("[Isid_]=@Isid_,");
			strSql.Append("[it]=@it,");
			strSql.Append("[Isit]=@Isit,");
			strSql.Append("[ka]=@ka,");
			strSql.Append("[Iska]=@Iska,");
			strSql.Append("[ko]=@ko,");
			strSql.Append("[Isko]=@Isko,");
			strSql.Append("[lt]=@lt,");
			strSql.Append("[Islt]=@Islt,");
			strSql.Append("[mk]=@mk,");
			strSql.Append("[Ismk]=@Ismk,");
			strSql.Append("[ms]=@ms,");
			strSql.Append("[Isms]=@Isms,");
			strSql.Append("[nl]=@nl,");
			strSql.Append("[Isnl]=@Isnl,");
			strSql.Append("[no]=@no,");
			strSql.Append("[Isno]=@Isno,");
			strSql.Append("[pl]=@pl,");
			strSql.Append("[Ispl]=@Ispl,");
			strSql.Append("[pt]=@pt,");
			strSql.Append("[Ispt]=@Ispt,");
			strSql.Append("[ro]=@ro,");
			strSql.Append("[Isro]=@Isro,");
			strSql.Append("[tw]=@tw,");
			strSql.Append("[tcn]=@tcn,");
			strSql.Append("[Istcn]=@Istcn");
			strSql.Append(" where id="+model.id);
			OleDbParameter[] parameters = {
					new OleDbParameter("@tag", model.tag),
					new OleDbParameter("@CN", model.CN),
					new OleDbParameter("@IsCN", model.IsCN),
					new OleDbParameter("@EN", model.EN),
					new OleDbParameter("@IsEN", model.IsEN),
					new OleDbParameter("@ja", model.ja),
					new OleDbParameter("@Isja", model.Isja),
					new OleDbParameter("@ar", model.ar),
					new OleDbParameter("@Isar", model.Isar),
					new OleDbParameter("@ca", model.ca),
					new OleDbParameter("@Isca", model.Isca),
					new OleDbParameter("@cs", model.cs),
					new OleDbParameter("@Iscs", model.Iscs),
					new OleDbParameter("@cy", model.cy),
					new OleDbParameter("@Iscy", model.Iscy),
					new OleDbParameter("@da", model.da),
					new OleDbParameter("@Isda", model.Isda),
					new OleDbParameter("@de", model.de),
					new OleDbParameter("@Isde", model.Isde),
					new OleDbParameter("@el", model.el),
					new OleDbParameter("@Isel", model.Isel),
					new OleDbParameter("@es", model.es),
					new OleDbParameter("@Ises", model.Ises),
					new OleDbParameter("@eu", model.eu),
					new OleDbParameter("@Iseu", model.Iseu),
					new OleDbParameter("@fa", model.fa),
					new OleDbParameter("@Isfa", model.Isfa),
					new OleDbParameter("@fi", model.fi),
					new OleDbParameter("@Isfi", model.Isfi),
					new OleDbParameter("@fr", model.fr),
					new OleDbParameter("@Isfr", model.Isfr),
					new OleDbParameter("@gl", model.gl),
					new OleDbParameter("@Isgl", model.Isgl),
					new OleDbParameter("@he", model.he),
					new OleDbParameter("@Ishe", model.Ishe),
					new OleDbParameter("@hr", model.hr),
					new OleDbParameter("@Ishr", model.Ishr),
					new OleDbParameter("@ru", model.ru),
					new OleDbParameter("@Isru", model.Isru),
					new OleDbParameter("@sv", model.sv),
					new OleDbParameter("@Issv", model.Issv),
					new OleDbParameter("@ta", model.ta),
					new OleDbParameter("@Ista", model.Ista),
					new OleDbParameter("@th", model.th),
					new OleDbParameter("@Isth", model.Isth),
					new OleDbParameter("@tr", model.tr),
					new OleDbParameter("@Istr", model.Istr),
					new OleDbParameter("@uk", model.uk),
					new OleDbParameter("@Isuk", model.Isuk),
					new OleDbParameter("@vi", model.vi),
					new OleDbParameter("@Isvi", model.Isvi),
					new OleDbParameter("@hu", model.hu),
					new OleDbParameter("@Ishu", model.Ishu),
					new OleDbParameter("@id_", model.id_),
					new OleDbParameter("@Isid_", model.Isid_),
					new OleDbParameter("@it", model.it),
					new OleDbParameter("@Isit", model.Isit),
					new OleDbParameter("@ka", model.ka),
					new OleDbParameter("@Iska", model.Iska),
					new OleDbParameter("@ko", model.ko),
					new OleDbParameter("@Isko", model.Isko),
					new OleDbParameter("@lt", model.lt),
					new OleDbParameter("@Islt", model.Islt),
					new OleDbParameter("@mk", model.mk),
					new OleDbParameter("@Ismk", model.Ismk),
					new OleDbParameter("@ms", model.ms),
					new OleDbParameter("@Isms", model.Isms),
					new OleDbParameter("@nl", model.nl),
					new OleDbParameter("@Isnl", model.Isnl),
					new OleDbParameter("@no", model.no),
					new OleDbParameter("@Isno", model.Isno),
					new OleDbParameter("@pl", model.pl),
					new OleDbParameter("@Ispl", model.Ispl),
					new OleDbParameter("@pt", model.pt),
					new OleDbParameter("@Ispt", model.Ispt),
					new OleDbParameter("@ro", model.ro),
					new OleDbParameter("@Isro", model.Isro),
					new OleDbParameter("@tw", model.tw),
					new OleDbParameter("@tcn", model.tcn),
					new OleDbParameter("@Istcn", model.Istcn)};

			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Language_Tag] ");
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
			strSql.Append("delete from [Lebi_Language_Tag] ");
			strSql.Append(" where "+ strWhere +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),null);
		}
		public void Delete(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Lebi_Language_Tag] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			AccessUtils.Instance.TextExecuteNonQuery(strSql.ToString(),para.Para_Oledb);
		}


		/// <summary>
		/// 得到一个对象实体 by id
		/// </summary>
		public Lebi_Language_Tag GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Language_Tag] ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", id)};

			Lebi_Language_Tag model;
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
		public Lebi_Language_Tag GetModel(string strWhere)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, "", "");
				return GetModel(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  * from [Lebi_Language_Tag] ");
			strSql.Append(" where "+ strWhere +"");
			Lebi_Language_Tag model;
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
		public Lebi_Language_Tag GetModel(SQLPara para)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select top 1 * from [Lebi_Language_Tag] ");
			if (para.Where != "")
				strSql.Append(" where "+ para.Where +"");
			Lebi_Language_Tag model;
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
		public List<Lebi_Language_Tag> GetList(string strWhere, string strFieldOrder, int PageSize, int page)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para,PageSize,page);
			}
			string strTableName = "[Lebi_Language_Tag]";
			string strFieldKey = "id";
			string strFieldShow = "*";
			List<Lebi_Language_Tag> list = new List<Lebi_Language_Tag>();
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
		public List<Lebi_Language_Tag> GetList(SQLPara para, int PageSize, int page)
		{
			string strTableName = "[Lebi_Language_Tag]";
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
			List<Lebi_Language_Tag> list = new List<Lebi_Language_Tag>();
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
		public List<Lebi_Language_Tag> GetList(string strWhere,string strFieldOrder)
		{
			strWhere=BaseUtils.BaseUtilsInstance.SetWhere(strWhere);
			if (strWhere.IndexOf("lbsql{") > 0)
			{
				SQLPara para = new SQLPara(strWhere, strFieldOrder, "");
				return GetList(para);
			}
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Lebi_Language_Tag] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(strFieldOrder.Trim()!="")
			{
				strSql.Append(" order by "+strFieldOrder);
			}
			List<Lebi_Language_Tag> list = new List<Lebi_Language_Tag>();
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
		public List<Lebi_Language_Tag> GetList(SQLPara para)
		{
			string strTableName = "[Lebi_Language_Tag]";
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select " + para.ShowField + " from " + strTableName + "");
			if (para != null)
				strSql.Append(" where " + para.Where + "");
			if (para.Order != "")
				strSql.Append(" order by " + para.Order + "");
			List<Lebi_Language_Tag> list = new List<Lebi_Language_Tag>();
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
		public Lebi_Language_Tag BindForm(Lebi_Language_Tag model)
		{
			if (HttpContext.Current.Request["tag"] != null)
				model.tag=Shop.Tools.RequestTool.RequestString("tag");
			if (HttpContext.Current.Request["CN"] != null)
				model.CN=Shop.Tools.RequestTool.RequestString("CN");
			if (HttpContext.Current.Request["IsCN"] != null)
				model.IsCN=Shop.Tools.RequestTool.RequestInt("IsCN",0);
			if (HttpContext.Current.Request["EN"] != null)
				model.EN=Shop.Tools.RequestTool.RequestString("EN");
			if (HttpContext.Current.Request["IsEN"] != null)
				model.IsEN=Shop.Tools.RequestTool.RequestInt("IsEN",0);
			if (HttpContext.Current.Request["ja"] != null)
				model.ja=Shop.Tools.RequestTool.RequestString("ja");
			if (HttpContext.Current.Request["Isja"] != null)
				model.Isja=Shop.Tools.RequestTool.RequestInt("Isja",0);
			if (HttpContext.Current.Request["ar"] != null)
				model.ar=Shop.Tools.RequestTool.RequestString("ar");
			if (HttpContext.Current.Request["Isar"] != null)
				model.Isar=Shop.Tools.RequestTool.RequestInt("Isar",0);
			if (HttpContext.Current.Request["ca"] != null)
				model.ca=Shop.Tools.RequestTool.RequestString("ca");
			if (HttpContext.Current.Request["Isca"] != null)
				model.Isca=Shop.Tools.RequestTool.RequestInt("Isca",0);
			if (HttpContext.Current.Request["cs"] != null)
				model.cs=Shop.Tools.RequestTool.RequestString("cs");
			if (HttpContext.Current.Request["Iscs"] != null)
				model.Iscs=Shop.Tools.RequestTool.RequestInt("Iscs",0);
			if (HttpContext.Current.Request["cy"] != null)
				model.cy=Shop.Tools.RequestTool.RequestString("cy");
			if (HttpContext.Current.Request["Iscy"] != null)
				model.Iscy=Shop.Tools.RequestTool.RequestInt("Iscy",0);
			if (HttpContext.Current.Request["da"] != null)
				model.da=Shop.Tools.RequestTool.RequestString("da");
			if (HttpContext.Current.Request["Isda"] != null)
				model.Isda=Shop.Tools.RequestTool.RequestInt("Isda",0);
			if (HttpContext.Current.Request["de"] != null)
				model.de=Shop.Tools.RequestTool.RequestString("de");
			if (HttpContext.Current.Request["Isde"] != null)
				model.Isde=Shop.Tools.RequestTool.RequestInt("Isde",0);
			if (HttpContext.Current.Request["el"] != null)
				model.el=Shop.Tools.RequestTool.RequestString("el");
			if (HttpContext.Current.Request["Isel"] != null)
				model.Isel=Shop.Tools.RequestTool.RequestInt("Isel",0);
			if (HttpContext.Current.Request["es"] != null)
				model.es=Shop.Tools.RequestTool.RequestString("es");
			if (HttpContext.Current.Request["Ises"] != null)
				model.Ises=Shop.Tools.RequestTool.RequestInt("Ises",0);
			if (HttpContext.Current.Request["eu"] != null)
				model.eu=Shop.Tools.RequestTool.RequestString("eu");
			if (HttpContext.Current.Request["Iseu"] != null)
				model.Iseu=Shop.Tools.RequestTool.RequestInt("Iseu",0);
			if (HttpContext.Current.Request["fa"] != null)
				model.fa=Shop.Tools.RequestTool.RequestString("fa");
			if (HttpContext.Current.Request["Isfa"] != null)
				model.Isfa=Shop.Tools.RequestTool.RequestInt("Isfa",0);
			if (HttpContext.Current.Request["fi"] != null)
				model.fi=Shop.Tools.RequestTool.RequestString("fi");
			if (HttpContext.Current.Request["Isfi"] != null)
				model.Isfi=Shop.Tools.RequestTool.RequestInt("Isfi",0);
			if (HttpContext.Current.Request["fr"] != null)
				model.fr=Shop.Tools.RequestTool.RequestString("fr");
			if (HttpContext.Current.Request["Isfr"] != null)
				model.Isfr=Shop.Tools.RequestTool.RequestInt("Isfr",0);
			if (HttpContext.Current.Request["gl"] != null)
				model.gl=Shop.Tools.RequestTool.RequestString("gl");
			if (HttpContext.Current.Request["Isgl"] != null)
				model.Isgl=Shop.Tools.RequestTool.RequestInt("Isgl",0);
			if (HttpContext.Current.Request["he"] != null)
				model.he=Shop.Tools.RequestTool.RequestString("he");
			if (HttpContext.Current.Request["Ishe"] != null)
				model.Ishe=Shop.Tools.RequestTool.RequestInt("Ishe",0);
			if (HttpContext.Current.Request["hr"] != null)
				model.hr=Shop.Tools.RequestTool.RequestString("hr");
			if (HttpContext.Current.Request["Ishr"] != null)
				model.Ishr=Shop.Tools.RequestTool.RequestInt("Ishr",0);
			if (HttpContext.Current.Request["ru"] != null)
				model.ru=Shop.Tools.RequestTool.RequestString("ru");
			if (HttpContext.Current.Request["Isru"] != null)
				model.Isru=Shop.Tools.RequestTool.RequestInt("Isru",0);
			if (HttpContext.Current.Request["sv"] != null)
				model.sv=Shop.Tools.RequestTool.RequestString("sv");
			if (HttpContext.Current.Request["Issv"] != null)
				model.Issv=Shop.Tools.RequestTool.RequestInt("Issv",0);
			if (HttpContext.Current.Request["ta"] != null)
				model.ta=Shop.Tools.RequestTool.RequestString("ta");
			if (HttpContext.Current.Request["Ista"] != null)
				model.Ista=Shop.Tools.RequestTool.RequestInt("Ista",0);
			if (HttpContext.Current.Request["th"] != null)
				model.th=Shop.Tools.RequestTool.RequestString("th");
			if (HttpContext.Current.Request["Isth"] != null)
				model.Isth=Shop.Tools.RequestTool.RequestInt("Isth",0);
			if (HttpContext.Current.Request["tr"] != null)
				model.tr=Shop.Tools.RequestTool.RequestString("tr");
			if (HttpContext.Current.Request["Istr"] != null)
				model.Istr=Shop.Tools.RequestTool.RequestInt("Istr",0);
			if (HttpContext.Current.Request["uk"] != null)
				model.uk=Shop.Tools.RequestTool.RequestString("uk");
			if (HttpContext.Current.Request["Isuk"] != null)
				model.Isuk=Shop.Tools.RequestTool.RequestInt("Isuk",0);
			if (HttpContext.Current.Request["vi"] != null)
				model.vi=Shop.Tools.RequestTool.RequestString("vi");
			if (HttpContext.Current.Request["Isvi"] != null)
				model.Isvi=Shop.Tools.RequestTool.RequestInt("Isvi",0);
			if (HttpContext.Current.Request["hu"] != null)
				model.hu=Shop.Tools.RequestTool.RequestString("hu");
			if (HttpContext.Current.Request["Ishu"] != null)
				model.Ishu=Shop.Tools.RequestTool.RequestInt("Ishu",0);
			if (HttpContext.Current.Request["id_"] != null)
				model.id_=Shop.Tools.RequestTool.RequestString("id_");
			if (HttpContext.Current.Request["Isid_"] != null)
				model.Isid_=Shop.Tools.RequestTool.RequestInt("Isid_",0);
			if (HttpContext.Current.Request["it"] != null)
				model.it=Shop.Tools.RequestTool.RequestString("it");
			if (HttpContext.Current.Request["Isit"] != null)
				model.Isit=Shop.Tools.RequestTool.RequestInt("Isit",0);
			if (HttpContext.Current.Request["ka"] != null)
				model.ka=Shop.Tools.RequestTool.RequestString("ka");
			if (HttpContext.Current.Request["Iska"] != null)
				model.Iska=Shop.Tools.RequestTool.RequestInt("Iska",0);
			if (HttpContext.Current.Request["ko"] != null)
				model.ko=Shop.Tools.RequestTool.RequestString("ko");
			if (HttpContext.Current.Request["Isko"] != null)
				model.Isko=Shop.Tools.RequestTool.RequestInt("Isko",0);
			if (HttpContext.Current.Request["lt"] != null)
				model.lt=Shop.Tools.RequestTool.RequestString("lt");
			if (HttpContext.Current.Request["Islt"] != null)
				model.Islt=Shop.Tools.RequestTool.RequestInt("Islt",0);
			if (HttpContext.Current.Request["mk"] != null)
				model.mk=Shop.Tools.RequestTool.RequestString("mk");
			if (HttpContext.Current.Request["Ismk"] != null)
				model.Ismk=Shop.Tools.RequestTool.RequestInt("Ismk",0);
			if (HttpContext.Current.Request["ms"] != null)
				model.ms=Shop.Tools.RequestTool.RequestString("ms");
			if (HttpContext.Current.Request["Isms"] != null)
				model.Isms=Shop.Tools.RequestTool.RequestInt("Isms",0);
			if (HttpContext.Current.Request["nl"] != null)
				model.nl=Shop.Tools.RequestTool.RequestString("nl");
			if (HttpContext.Current.Request["Isnl"] != null)
				model.Isnl=Shop.Tools.RequestTool.RequestInt("Isnl",0);
			if (HttpContext.Current.Request["no"] != null)
				model.no=Shop.Tools.RequestTool.RequestString("no");
			if (HttpContext.Current.Request["Isno"] != null)
				model.Isno=Shop.Tools.RequestTool.RequestInt("Isno",0);
			if (HttpContext.Current.Request["pl"] != null)
				model.pl=Shop.Tools.RequestTool.RequestString("pl");
			if (HttpContext.Current.Request["Ispl"] != null)
				model.Ispl=Shop.Tools.RequestTool.RequestInt("Ispl",0);
			if (HttpContext.Current.Request["pt"] != null)
				model.pt=Shop.Tools.RequestTool.RequestString("pt");
			if (HttpContext.Current.Request["Ispt"] != null)
				model.Ispt=Shop.Tools.RequestTool.RequestInt("Ispt",0);
			if (HttpContext.Current.Request["ro"] != null)
				model.ro=Shop.Tools.RequestTool.RequestString("ro");
			if (HttpContext.Current.Request["Isro"] != null)
				model.Isro=Shop.Tools.RequestTool.RequestInt("Isro",0);
			if (HttpContext.Current.Request["tw"] != null)
				model.tw=Shop.Tools.RequestTool.RequestString("tw");
			if (HttpContext.Current.Request["tcn"] != null)
				model.tcn=Shop.Tools.RequestTool.RequestString("tcn");
			if (HttpContext.Current.Request["Istcn"] != null)
				model.Istcn=Shop.Tools.RequestTool.RequestInt("Istcn",0);
				return model;
		}
		/// <summary>
		/// 安全方式绑定对象表单
		/// </summary>
		public Lebi_Language_Tag SafeBindForm(Lebi_Language_Tag model)
		{
			if (HttpContext.Current.Request["tag"] != null)
				model.tag=Shop.Tools.RequestTool.RequestSafeString("tag");
			if (HttpContext.Current.Request["CN"] != null)
				model.CN=Shop.Tools.RequestTool.RequestSafeString("CN");
			if (HttpContext.Current.Request["IsCN"] != null)
				model.IsCN=Shop.Tools.RequestTool.RequestInt("IsCN",0);
			if (HttpContext.Current.Request["EN"] != null)
				model.EN=Shop.Tools.RequestTool.RequestSafeString("EN");
			if (HttpContext.Current.Request["IsEN"] != null)
				model.IsEN=Shop.Tools.RequestTool.RequestInt("IsEN",0);
			if (HttpContext.Current.Request["ja"] != null)
				model.ja=Shop.Tools.RequestTool.RequestSafeString("ja");
			if (HttpContext.Current.Request["Isja"] != null)
				model.Isja=Shop.Tools.RequestTool.RequestInt("Isja",0);
			if (HttpContext.Current.Request["ar"] != null)
				model.ar=Shop.Tools.RequestTool.RequestSafeString("ar");
			if (HttpContext.Current.Request["Isar"] != null)
				model.Isar=Shop.Tools.RequestTool.RequestInt("Isar",0);
			if (HttpContext.Current.Request["ca"] != null)
				model.ca=Shop.Tools.RequestTool.RequestSafeString("ca");
			if (HttpContext.Current.Request["Isca"] != null)
				model.Isca=Shop.Tools.RequestTool.RequestInt("Isca",0);
			if (HttpContext.Current.Request["cs"] != null)
				model.cs=Shop.Tools.RequestTool.RequestSafeString("cs");
			if (HttpContext.Current.Request["Iscs"] != null)
				model.Iscs=Shop.Tools.RequestTool.RequestInt("Iscs",0);
			if (HttpContext.Current.Request["cy"] != null)
				model.cy=Shop.Tools.RequestTool.RequestSafeString("cy");
			if (HttpContext.Current.Request["Iscy"] != null)
				model.Iscy=Shop.Tools.RequestTool.RequestInt("Iscy",0);
			if (HttpContext.Current.Request["da"] != null)
				model.da=Shop.Tools.RequestTool.RequestSafeString("da");
			if (HttpContext.Current.Request["Isda"] != null)
				model.Isda=Shop.Tools.RequestTool.RequestInt("Isda",0);
			if (HttpContext.Current.Request["de"] != null)
				model.de=Shop.Tools.RequestTool.RequestSafeString("de");
			if (HttpContext.Current.Request["Isde"] != null)
				model.Isde=Shop.Tools.RequestTool.RequestInt("Isde",0);
			if (HttpContext.Current.Request["el"] != null)
				model.el=Shop.Tools.RequestTool.RequestSafeString("el");
			if (HttpContext.Current.Request["Isel"] != null)
				model.Isel=Shop.Tools.RequestTool.RequestInt("Isel",0);
			if (HttpContext.Current.Request["es"] != null)
				model.es=Shop.Tools.RequestTool.RequestSafeString("es");
			if (HttpContext.Current.Request["Ises"] != null)
				model.Ises=Shop.Tools.RequestTool.RequestInt("Ises",0);
			if (HttpContext.Current.Request["eu"] != null)
				model.eu=Shop.Tools.RequestTool.RequestSafeString("eu");
			if (HttpContext.Current.Request["Iseu"] != null)
				model.Iseu=Shop.Tools.RequestTool.RequestInt("Iseu",0);
			if (HttpContext.Current.Request["fa"] != null)
				model.fa=Shop.Tools.RequestTool.RequestSafeString("fa");
			if (HttpContext.Current.Request["Isfa"] != null)
				model.Isfa=Shop.Tools.RequestTool.RequestInt("Isfa",0);
			if (HttpContext.Current.Request["fi"] != null)
				model.fi=Shop.Tools.RequestTool.RequestSafeString("fi");
			if (HttpContext.Current.Request["Isfi"] != null)
				model.Isfi=Shop.Tools.RequestTool.RequestInt("Isfi",0);
			if (HttpContext.Current.Request["fr"] != null)
				model.fr=Shop.Tools.RequestTool.RequestSafeString("fr");
			if (HttpContext.Current.Request["Isfr"] != null)
				model.Isfr=Shop.Tools.RequestTool.RequestInt("Isfr",0);
			if (HttpContext.Current.Request["gl"] != null)
				model.gl=Shop.Tools.RequestTool.RequestSafeString("gl");
			if (HttpContext.Current.Request["Isgl"] != null)
				model.Isgl=Shop.Tools.RequestTool.RequestInt("Isgl",0);
			if (HttpContext.Current.Request["he"] != null)
				model.he=Shop.Tools.RequestTool.RequestSafeString("he");
			if (HttpContext.Current.Request["Ishe"] != null)
				model.Ishe=Shop.Tools.RequestTool.RequestInt("Ishe",0);
			if (HttpContext.Current.Request["hr"] != null)
				model.hr=Shop.Tools.RequestTool.RequestSafeString("hr");
			if (HttpContext.Current.Request["Ishr"] != null)
				model.Ishr=Shop.Tools.RequestTool.RequestInt("Ishr",0);
			if (HttpContext.Current.Request["ru"] != null)
				model.ru=Shop.Tools.RequestTool.RequestSafeString("ru");
			if (HttpContext.Current.Request["Isru"] != null)
				model.Isru=Shop.Tools.RequestTool.RequestInt("Isru",0);
			if (HttpContext.Current.Request["sv"] != null)
				model.sv=Shop.Tools.RequestTool.RequestSafeString("sv");
			if (HttpContext.Current.Request["Issv"] != null)
				model.Issv=Shop.Tools.RequestTool.RequestInt("Issv",0);
			if (HttpContext.Current.Request["ta"] != null)
				model.ta=Shop.Tools.RequestTool.RequestSafeString("ta");
			if (HttpContext.Current.Request["Ista"] != null)
				model.Ista=Shop.Tools.RequestTool.RequestInt("Ista",0);
			if (HttpContext.Current.Request["th"] != null)
				model.th=Shop.Tools.RequestTool.RequestSafeString("th");
			if (HttpContext.Current.Request["Isth"] != null)
				model.Isth=Shop.Tools.RequestTool.RequestInt("Isth",0);
			if (HttpContext.Current.Request["tr"] != null)
				model.tr=Shop.Tools.RequestTool.RequestSafeString("tr");
			if (HttpContext.Current.Request["Istr"] != null)
				model.Istr=Shop.Tools.RequestTool.RequestInt("Istr",0);
			if (HttpContext.Current.Request["uk"] != null)
				model.uk=Shop.Tools.RequestTool.RequestSafeString("uk");
			if (HttpContext.Current.Request["Isuk"] != null)
				model.Isuk=Shop.Tools.RequestTool.RequestInt("Isuk",0);
			if (HttpContext.Current.Request["vi"] != null)
				model.vi=Shop.Tools.RequestTool.RequestSafeString("vi");
			if (HttpContext.Current.Request["Isvi"] != null)
				model.Isvi=Shop.Tools.RequestTool.RequestInt("Isvi",0);
			if (HttpContext.Current.Request["hu"] != null)
				model.hu=Shop.Tools.RequestTool.RequestSafeString("hu");
			if (HttpContext.Current.Request["Ishu"] != null)
				model.Ishu=Shop.Tools.RequestTool.RequestInt("Ishu",0);
			if (HttpContext.Current.Request["id_"] != null)
				model.id_=Shop.Tools.RequestTool.RequestSafeString("id_");
			if (HttpContext.Current.Request["Isid_"] != null)
				model.Isid_=Shop.Tools.RequestTool.RequestInt("Isid_",0);
			if (HttpContext.Current.Request["it"] != null)
				model.it=Shop.Tools.RequestTool.RequestSafeString("it");
			if (HttpContext.Current.Request["Isit"] != null)
				model.Isit=Shop.Tools.RequestTool.RequestInt("Isit",0);
			if (HttpContext.Current.Request["ka"] != null)
				model.ka=Shop.Tools.RequestTool.RequestSafeString("ka");
			if (HttpContext.Current.Request["Iska"] != null)
				model.Iska=Shop.Tools.RequestTool.RequestInt("Iska",0);
			if (HttpContext.Current.Request["ko"] != null)
				model.ko=Shop.Tools.RequestTool.RequestSafeString("ko");
			if (HttpContext.Current.Request["Isko"] != null)
				model.Isko=Shop.Tools.RequestTool.RequestInt("Isko",0);
			if (HttpContext.Current.Request["lt"] != null)
				model.lt=Shop.Tools.RequestTool.RequestSafeString("lt");
			if (HttpContext.Current.Request["Islt"] != null)
				model.Islt=Shop.Tools.RequestTool.RequestInt("Islt",0);
			if (HttpContext.Current.Request["mk"] != null)
				model.mk=Shop.Tools.RequestTool.RequestSafeString("mk");
			if (HttpContext.Current.Request["Ismk"] != null)
				model.Ismk=Shop.Tools.RequestTool.RequestInt("Ismk",0);
			if (HttpContext.Current.Request["ms"] != null)
				model.ms=Shop.Tools.RequestTool.RequestSafeString("ms");
			if (HttpContext.Current.Request["Isms"] != null)
				model.Isms=Shop.Tools.RequestTool.RequestInt("Isms",0);
			if (HttpContext.Current.Request["nl"] != null)
				model.nl=Shop.Tools.RequestTool.RequestSafeString("nl");
			if (HttpContext.Current.Request["Isnl"] != null)
				model.Isnl=Shop.Tools.RequestTool.RequestInt("Isnl",0);
			if (HttpContext.Current.Request["no"] != null)
				model.no=Shop.Tools.RequestTool.RequestSafeString("no");
			if (HttpContext.Current.Request["Isno"] != null)
				model.Isno=Shop.Tools.RequestTool.RequestInt("Isno",0);
			if (HttpContext.Current.Request["pl"] != null)
				model.pl=Shop.Tools.RequestTool.RequestSafeString("pl");
			if (HttpContext.Current.Request["Ispl"] != null)
				model.Ispl=Shop.Tools.RequestTool.RequestInt("Ispl",0);
			if (HttpContext.Current.Request["pt"] != null)
				model.pt=Shop.Tools.RequestTool.RequestSafeString("pt");
			if (HttpContext.Current.Request["Ispt"] != null)
				model.Ispt=Shop.Tools.RequestTool.RequestInt("Ispt",0);
			if (HttpContext.Current.Request["ro"] != null)
				model.ro=Shop.Tools.RequestTool.RequestSafeString("ro");
			if (HttpContext.Current.Request["Isro"] != null)
				model.Isro=Shop.Tools.RequestTool.RequestInt("Isro",0);
			if (HttpContext.Current.Request["tw"] != null)
				model.tw=Shop.Tools.RequestTool.RequestSafeString("tw");
			if (HttpContext.Current.Request["tcn"] != null)
				model.tcn=Shop.Tools.RequestTool.RequestSafeString("tcn");
			if (HttpContext.Current.Request["Istcn"] != null)
				model.Istcn=Shop.Tools.RequestTool.RequestInt("Istcn",0);
				return model;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Lebi_Language_Tag ReaderBind(IDataReader dataReader)
		{
			Lebi_Language_Tag model=new Lebi_Language_Tag();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.tag=dataReader["tag"].ToString();
			model.CN=dataReader["CN"].ToString();
			ojb = dataReader["IsCN"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsCN=(int)ojb;
			}
			model.EN=dataReader["EN"].ToString();
			ojb = dataReader["IsEN"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsEN=(int)ojb;
			}
			model.ja=dataReader["ja"].ToString();
			ojb = dataReader["Isja"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isja=(int)ojb;
			}
			model.ar=dataReader["ar"].ToString();
			ojb = dataReader["Isar"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isar=(int)ojb;
			}
			model.ca=dataReader["ca"].ToString();
			ojb = dataReader["Isca"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isca=(int)ojb;
			}
			model.cs=dataReader["cs"].ToString();
			ojb = dataReader["Iscs"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Iscs=(int)ojb;
			}
			model.cy=dataReader["cy"].ToString();
			ojb = dataReader["Iscy"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Iscy=(int)ojb;
			}
			model.da=dataReader["da"].ToString();
			ojb = dataReader["Isda"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isda=(int)ojb;
			}
			model.de=dataReader["de"].ToString();
			ojb = dataReader["Isde"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isde=(int)ojb;
			}
			model.el=dataReader["el"].ToString();
			ojb = dataReader["Isel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isel=(int)ojb;
			}
			model.es=dataReader["es"].ToString();
			ojb = dataReader["Ises"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ises=(int)ojb;
			}
			model.eu=dataReader["eu"].ToString();
			ojb = dataReader["Iseu"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Iseu=(int)ojb;
			}
			model.fa=dataReader["fa"].ToString();
			ojb = dataReader["Isfa"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isfa=(int)ojb;
			}
			model.fi=dataReader["fi"].ToString();
			ojb = dataReader["Isfi"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isfi=(int)ojb;
			}
			model.fr=dataReader["fr"].ToString();
			ojb = dataReader["Isfr"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isfr=(int)ojb;
			}
			model.gl=dataReader["gl"].ToString();
			ojb = dataReader["Isgl"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isgl=(int)ojb;
			}
			model.he=dataReader["he"].ToString();
			ojb = dataReader["Ishe"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ishe=(int)ojb;
			}
			model.hr=dataReader["hr"].ToString();
			ojb = dataReader["Ishr"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ishr=(int)ojb;
			}
			model.ru=dataReader["ru"].ToString();
			ojb = dataReader["Isru"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isru=(int)ojb;
			}
			model.sv=dataReader["sv"].ToString();
			ojb = dataReader["Issv"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Issv=(int)ojb;
			}
			model.ta=dataReader["ta"].ToString();
			ojb = dataReader["Ista"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ista=(int)ojb;
			}
			model.th=dataReader["th"].ToString();
			ojb = dataReader["Isth"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isth=(int)ojb;
			}
			model.tr=dataReader["tr"].ToString();
			ojb = dataReader["Istr"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Istr=(int)ojb;
			}
			model.uk=dataReader["uk"].ToString();
			ojb = dataReader["Isuk"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isuk=(int)ojb;
			}
			model.vi=dataReader["vi"].ToString();
			ojb = dataReader["Isvi"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isvi=(int)ojb;
			}
			model.hu=dataReader["hu"].ToString();
			ojb = dataReader["Ishu"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ishu=(int)ojb;
			}
			model.id_=dataReader["id_"].ToString();
			ojb = dataReader["Isid_"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isid_=(int)ojb;
			}
			model.it=dataReader["it"].ToString();
			ojb = dataReader["Isit"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isit=(int)ojb;
			}
			model.ka=dataReader["ka"].ToString();
			ojb = dataReader["Iska"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Iska=(int)ojb;
			}
			model.ko=dataReader["ko"].ToString();
			ojb = dataReader["Isko"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isko=(int)ojb;
			}
			model.lt=dataReader["lt"].ToString();
			ojb = dataReader["Islt"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Islt=(int)ojb;
			}
			model.mk=dataReader["mk"].ToString();
			ojb = dataReader["Ismk"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ismk=(int)ojb;
			}
			model.ms=dataReader["ms"].ToString();
			ojb = dataReader["Isms"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isms=(int)ojb;
			}
			model.nl=dataReader["nl"].ToString();
			ojb = dataReader["Isnl"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isnl=(int)ojb;
			}
			model.no=dataReader["no"].ToString();
			ojb = dataReader["Isno"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isno=(int)ojb;
			}
			model.pl=dataReader["pl"].ToString();
			ojb = dataReader["Ispl"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ispl=(int)ojb;
			}
			model.pt=dataReader["pt"].ToString();
			ojb = dataReader["Ispt"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Ispt=(int)ojb;
			}
			model.ro=dataReader["ro"].ToString();
			ojb = dataReader["Isro"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Isro=(int)ojb;
			}
			model.tw=dataReader["tw"].ToString();
			model.tcn=dataReader["tcn"].ToString();
			ojb = dataReader["Istcn"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Istcn=(int)ojb;
			}
			return model;
		}

	}
		#endregion  成员方法
	}
}

