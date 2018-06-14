using System;
namespace Shop.Model
{
	[Serializable]
	public class Lebi_User_Point
	{
		#region Model
		private int _id=0;
		private int _user_id=0;
		private decimal _point=0;
		private DateTime _time_add=DateTime.Now;
		private int _type_id_pointstatus=0;
		private string _admin_username="";
		private DateTime _time_update=DateTime.Now;
		private string _remark="";
		private string _user_username="";
		private string _user_realname="";
		private int _admin_id=0;
		private Lebi_User_Point _model;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int User_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Point
		{
			set{ _point=value;}
			get{return _point;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Time_Add
		{
			set{ _time_add=value;}
			get{return _time_add;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Type_id_PointStatus
		{
			set{ _type_id_pointstatus=value;}
			get{return _type_id_pointstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Admin_UserName
		{
			set{ _admin_username=value;}
			get{return _admin_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Time_Update
		{
			set{ _time_update=value;}
			get{return _time_update;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string User_UserName
		{
			set{ _user_username=value;}
			get{return _user_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string User_RealName
		{
			set{ _user_realname=value;}
			get{return _user_realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Admin_id
		{
			set{ _admin_id=value;}
			get{return _admin_id;}
		}
		#endregion

	}
}

