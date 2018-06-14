using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using Shop.Model;
using Shop.Tools;
using System.Web;
using Shop.DataAccess;
using System.Web.Script.Serialization;

namespace Shop.Bussiness
{
    /// <summary>
    /// 操作记录
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="content"></param>
        /// <param name="tablename"></param>
        /// <param name="keyid"></param>
        public static void Add(string content, string tablename, string keyid, Lebi_User user, Lebi_Administrator admin, Lebi_Supplier supplier, string description)
        {
            Lebi_Log log = new Lebi_Log();
            if (admin != null)
            {
                log.Admin_id = admin.id;
                log.AdminName = admin.UserName;
            }
            if (user != null)
            {
                log.User_id = user.id;
                log.UserName = user.UserName;
            }
            if (supplier != null)
            {
                log.Supplier_id = supplier.id;
                log.Supplier_SubName = supplier.SubName;
            }
            if (keyid.Length > 500)
                keyid = keyid.Substring(0, 500);
            log.Content = content;
            log.Keyid = keyid;
            log.TableName = tablename;
            if (RequestTool.GetRequestUrlNonDomain().Length > 400)
            {
                log.URL = RequestTool.GetRequestUrlNonDomain().Substring(0, 400);
            }
            else
            {
                log.URL = RequestTool.GetRequestUrlNonDomain();
            }
            if (RequestTool.GetUrlReferrerNonDomain().Length > 400)
            {
                log.RefererURL = RequestTool.GetUrlReferrerNonDomain().Substring(0, 400);
            }
            else
            {
                log.RefererURL = RequestTool.GetUrlReferrerNonDomain();
            }
            if (description.Length > 500)
            {
                log.Description = description.Substring(0, 500);
            }
            else
            {
                log.Description = description;
            }
            log.IP_Add = RequestTool.GetClientIP();
            B_Lebi_Log.Add(log);
        }
        public static void Add(string content)
        {
            Add(content, "", "");
        }
        public static void Add(string content, string description)
        {
            Add(content, "", "", description);
        }
        public static void Add(string content, string tablename, string keyid)
        {
            Add(content, tablename, keyid, null, null, null, "");
        }
        public static void Add(string content, string tablename, string keyid, string description)
        {
            Lebi_User user = EX_User.CurrentUser();
            Lebi_Administrator admin = EX_Admin.CurrentAdmin();
            Add(content, tablename, keyid, null, null, null, description);
        }
        public static void Add(string content, string tablename, string keyid, Lebi_User user)
        {
            Add(content, tablename, keyid, user, null, null, "");
        }
        public static void Add(string content, string tablename, string keyid, Lebi_User user, string description)
        {
            Add(content, tablename, keyid, user, null, null, description);
        }
        public static void Add(string content, string tablename, string keyid, Lebi_Administrator admin)
        {
            Add(content, tablename, keyid, null, admin, null, "");
        }
        public static void Add(string content, string tablename, string keyid, Lebi_Administrator admin, string description)
        {
            Add(content, tablename, keyid, null, admin, null, description);
        }
        public static void Add(string content, string tablename, string keyid, Lebi_Supplier supplier)
        {
            Add(content, tablename, keyid, null, null, supplier, "");
        }
        public static void Add(string content, string tablename, string keyid, Lebi_Supplier supplier, string description)
        {
            Add(content, tablename, keyid, null, null, supplier, description);
        }
    }
    /// <summary>
    /// 系统日志
    /// </summary>
    public class SystemLog
    {
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="content"></param>
        /// <param name="tablename"></param>
        /// <param name="keyid"></param>
        public static void Add(string content, Lebi_User user, Lebi_Administrator admin, Lebi_Supplier supplier)
        {
            string res = "time:" + System.DateTime.Now + "\r\n";
            res += "url:" + RequestTool.GetRequestUrlNonDomain() + "\r\n";
            res += "refererurl:" + RequestTool.GetUrlReferrerNonDomain() + "\r\n";
            if (user != null)
            {
                res += "userid:" + user.id + "\r\n";
            }
            if (admin != null)
            {
                res += "adinid:" + admin.id + "\r\n";
            }
            if (supplier != null)
            {
                res += "supplierid:" + supplier.id + "\r\n";
            }
            res +="content:"+ content + "\r\n\r\n";
            string Path = "/systemlog/" + System.DateTime.Now.Year + "/";
            string PhysicsPath = HttpRuntime.AppDomainAppPath + Path;
            
            if (!Directory.Exists(PhysicsPath))
            {
                Directory.CreateDirectory(PhysicsPath);
            }
            string PhysicsFileName = PhysicsPath + System.DateTime.Now.ToString("MMdd") + ".txt";
            if (System.IO.File.Exists(PhysicsFileName))
            {
                FileStream fs3 = new FileStream(PhysicsFileName, FileMode.Append);
                StreamWriter sw3 = new StreamWriter(fs3, System.Text.Encoding.GetEncoding("utf-8"));
                //sw3.WriteLine(""+labeltop.Text.ToString()+"\r\n"+labelmessage.Text.ToString()+"\r\n");
                StringBuilder sb3 = new StringBuilder();
                sb3.Append(res);
                sw3.Write(sb3.ToString());
                sw3.Close();
                fs3.Close();
            }
            else
            {
                HtmlEngine.Instance.WriteFile(PhysicsFileName, res);
            }
        }
        public static void Add(string content)
        {
            Add(content, null, null, null);
        }
        public static void Add(string content, Lebi_User user)
        {
            Add(content, user, null, null);
        }
        public static void Add(string content, Lebi_Administrator admin)
        {
            Add(content, null, admin, null);
        }
        public static void Add(string content, Lebi_Supplier supplier)
        {
            Add(content, null, null, supplier);
        }


    }
}

