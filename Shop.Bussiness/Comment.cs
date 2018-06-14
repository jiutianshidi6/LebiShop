using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text.RegularExpressions;
using System.Linq;
using Shop.Model;
using Shop.Tools;
using Shop.DataAccess;
using System.Web.Script.Serialization;
using System.Collections.Specialized;

namespace Shop.Bussiness
{
    public class Comment
    {
        /// <summary>
        /// 计算指定日期及状态的评论数量
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int GetCount_Comment(string dateFrom, string dateTo, string status)
        {
            int count = 0;
            string where = "";
            if (dateFrom != "" && dateTo != "")
            {
                where = "datediff(d,Time_Add,'" + dateFrom + "')<=0 and datediff(d,Time_Add,'" + dateTo + "')>=0";
            }
            if (status != "")
            {
                if (dateFrom != "" && dateTo != "")
                {
                    where += " and ";
                }
                where += status;
            }
            count = B_Lebi_Comment.Counts(where);
            return count;
        }
        /// <summary>
        /// 检查非法词
        /// </summary>
        /// <param name="strin"></param>
        /// <returns></returns>
        public static bool CheckSafeWord(string strin)
        {
            string cstr = ShopCache.GetBaseConfig().Filter;
            if (cstr == "")
            {
                return true;
            }
            string[] arr = cstr.Split('/');
            foreach (string s in arr)
            {
                if (strin.Contains(s))
                    return false;
            }
            return true;
        }
    }


}

