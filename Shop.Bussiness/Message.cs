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
    public class Message
    {
        /// <summary>
        /// 计算指定日期及状态的信息数量
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int GetCount_Message(string dateFrom, string dateTo, string status)
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
            count = B_Lebi_Message.Counts(where);
            return count;
        }

        public static Lebi_Message_Type Message_Type(int type_id)
        {
            Lebi_Message_Type type = B_Lebi_Message_Type.GetModel(type_id);
            if (type == null)
                type = new Lebi_Message_Type();
            return type;
        }
        public static string Message_TypeOption(string type_id, string lang)
        {
            List<Lebi_Message_Type> models = B_Lebi_Message_Type.GetList("", "Sort desc");
            string str = "";
            foreach (Lebi_Message_Type model in models)
            {
                string sel = "";
                if (type_id == "" + model.id + "")
                    sel = "selected";
                str += "<option value=\"" + model.id + "\" " + sel + ">" + Shop.Bussiness.Language.Content(model.Name, lang) + "</option>";
            }
            return str;
        }
        public static string Message_TypeOption(int typeclass,string type_id, string lang)
        {
            List<Lebi_Message_Type> models = B_Lebi_Message_Type.GetList("Type_id_MessageTypeClass="+typeclass+"", "Sort desc");
            string str = "";
            foreach (Lebi_Message_Type model in models)
            {
                string sel = "";
                if (type_id == "" + model.id + "")
                    sel = "selected";
                str += "<option value=\"" + model.id + "\" " + sel + ">" + Shop.Bussiness.Language.Content(model.Name, lang) + "</option>";
            }
            return str;
        }
    }


}

