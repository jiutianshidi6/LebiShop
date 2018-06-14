using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.Text.RegularExpressions;
using System.Linq;
using Shop.Model;
using Shop.Tools;
using Shop.DataAccess;
using System.Web.Script.Serialization;

namespace Shop.Bussiness
{
    public class Point
    {
        public static void AddPoint(Lebi_User user, decimal point, int type, Lebi_Administrator admin, string remark)
        {

            Lebi_User_Point model = new Lebi_User_Point();
            if (admin != null)
            {
                model.Admin_id = admin.id;
                model.Admin_UserName = admin.UserName;
            }

            model.Type_id_PointStatus = 171;
            model.Point = point;
            model.Remark = remark;
            model.Time_Update = DateTime.Now;
            model.User_id = user.id;
            model.User_RealName = user.RealName;
            model.User_UserName = user.UserName;
            B_Lebi_User_Point.Add(model);
            UpdateUserPoint(user);

        }
        /// <summary>
        /// 更新会员积分
        /// </summary>
        /// <param name="user"></param>
        public static void UpdateUserPoint(Lebi_User user)
        {
            string point = B_Lebi_User_Point.GetValue("sum(Point)", "User_id=" + user.id + " and Type_id_PointStatus=171");
            decimal Point = 0;
            Decimal.TryParse(point, out Point);
            Lebi_UserLevel userlev = B_Lebi_UserLevel.GetModel(user.UserLevel_id);
            if (userlev == null)
                userlev = new Lebi_UserLevel();
            List<Lebi_UserLevel> ls = B_Lebi_UserLevel.GetList("Grade > " + userlev.Grade +"", "Grade desc");
            //Lebi_UserLevel newlev=new Lebi_UserLevel();
            if (ls.Count > 0)
            {
                foreach (Lebi_UserLevel l in ls)
                {
                    if (Point >= l.Lpoint)
                    {
                        user.UserLevel_id = l.id;
                        //newlev = l;
                        break;
                    }
                }
            }
            //if (userlev.Grade < newlev.Grade)
            //{
                user.Point = Point;
                B_Lebi_User.Update(user);
            //}
        }
    }
}

