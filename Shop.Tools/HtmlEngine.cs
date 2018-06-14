using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
namespace Shop.Tools
{
    public class HtmlEngine
    {

        public HtmlEngine()
        {


        }

        #region Static Instance
        private static HtmlEngine _Instance;
        public static HtmlEngine Instance
        {
            get
            {
                if (_Instance == null)
                {

                    _Instance = new HtmlEngine();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        #endregion
        /// <summary>
        /// 读取网页内容生成文件
        /// </summary>
        /// <param name="executePath"></param>
        /// <param name="cachePath"></param>
        /// <param name="cacheFileName"></param>
        public void CreatHtml(string WebUrl, string CreatPath)
        {
            string FileName = "";
            string FilePath = "";
            try
            {
                CreatPath = GetFullPath(CreatPath);
                FileName = GetFileName(CreatPath);
                FilePath = GetPath(CreatPath);
                HttpResponse response = HttpContext.Current.Response;
                HttpRequest request = HttpContext.Current.Request;
                string cachePhysicsPath = HttpContext.Current.Server.MapPath(@"~/" + FilePath);
                string content = "";
                if (!Directory.Exists(cachePhysicsPath))
                {
                    Directory.CreateDirectory(cachePhysicsPath);
                }
                string cachePhysicsFileName = HttpContext.Current.Server.MapPath(string.Format("~/{0}/{1}", FilePath, FileName));
                if (System.IO.File.Exists(cachePhysicsFileName))
                {

                    System.IO.File.Delete(cachePhysicsFileName);
                }
                //调用Main_Execute,并且获取其输出 
                StringWriter sw = new StringWriter();

                //HttpContext.Current.Server.Execute(executePath, sw);
                //content = sw.ToString();

                //string url = "http://" + HttpContext.Current.Request.Url.Authority + WebUrl;
                string url = WebUrl;
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] b = wc.DownloadData(url);
                content = System.Text.Encoding.GetEncoding("utf-8").GetString(b);

                WriteFile(cachePhysicsFileName, content);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// 读取一个url
        /// </summary>
        /// <param name="WebUrl"></param>
        /// <param name="CreatPath"></param>
        public static string CetHtml(string WebUrl)
        {
            string content = "";
            try
            {
                HttpResponse response = HttpContext.Current.Response;
                HttpRequest request = HttpContext.Current.Request;

                //调用Main_Execute,并且获取其输出 
                StringWriter sw = new StringWriter();

                //HttpContext.Current.Server.Execute(executePath, sw);
                //content = sw.ToString();

                //string url = "http://" + HttpContext.Current.Request.Url.Authority + WebUrl;
                string url = WebUrl;
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] b = wc.DownloadData(url);
                content = System.Text.Encoding.GetEncoding("utf-8").GetString(b);


            }
            catch (Exception ex)
            {

                //throw ex;
                return "error";
            }
            return content;

        }
        public void WriteFile(string cachePhysicsFileName, string content, string encode = "utf-8")
        {
            //写进文件 
            lock (this)
            {
                try
                {

                    using (FileStream fs = new FileStream(cachePhysicsFileName, FileMode.Create, FileAccess.Write, FileShare.Write))
                    {
                        if (encode == "unicode")
                        {
                            using (StreamWriter streamwriter = new StreamWriter(fs, Encoding.Unicode))
                            {
                                streamwriter.Write(content);
                            }
                        }
                        else if (encode == "utf-8")
                        {
                            using (StreamWriter streamwriter = new StreamWriter(fs, Encoding.UTF8))
                            {
                                streamwriter.Write(content);
                            }
                        }
                        else
                        {
                            using (StreamWriter streamwriter = new StreamWriter(fs, Encoding.Default))
                            {
                                streamwriter.Write(content);
                            }
                        }
                    }

                }
                finally
                {

                }
            }
        }
        public void CreateFile(string FileName, string content, string encode = "utf-8")
        {
            try
            {
                string path = FileName.Substring(0, FileName.LastIndexOf("/"));
                if (HttpContext.Current == null)
                    path = System.AppDomain.CurrentDomain.BaseDirectory + path;
                else
                    path = HttpContext.Current.Server.MapPath(@"~/" + path);

                if (!System.IO.Directory.Exists(path))   //如果路径不存在，则创建
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
            catch { }
            if (HttpContext.Current == null)
                FileName = HttpContext.Current.Server.MapPath(@"~/" + FileName);
            else
                FileName = HttpContext.Current.Server.MapPath(@"~/" + FileName);
            try
            {
                if (System.IO.File.Exists(FileName))
                {
                    System.IO.File.Delete(FileName);
                }
                FileStream aFile = new FileStream(FileName, FileMode.OpenOrCreate);
                //Encoding;
                StreamWriter sw = new StreamWriter(aFile, Encoding.UTF8);
                if (encode == "ascii")
                {
                    sw = new StreamWriter(aFile, Encoding.ASCII);
                }

                sw.Write(content);
                sw.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }
        }
        #region 路径处理
        /// <summary>
        /// 在一个包含文件名的URL字符串中获取路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetPath(string path)
        {
            string str = "";
            int index = path.LastIndexOf("/");
            if (index != -1)
            {
                str = path.Substring(0, index + 1);
            }
            else
            {
                str = path;
            }
            return str;
        }
        /// <summary>
        /// 在一个包含文件名的URL字符串中获取文件名
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private string GetFileName(string path)
        {
            return path.Replace(GetPath(path), "");
        }
        /// <summary>
        /// 测试并获取完整的文件路径信息，
        /// 主要针对拼合路径中含有“//”的情况
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetFullPath(string path)
        {
            if (path != "/")
            {
                Regex r = new Regex(@"//*/", RegexOptions.Singleline);//目的：防止类似“///”“////”“//////”的情况
                path = r.Replace(path, "/");
                //去掉最后一个"/"
                if (path.LastIndexOf("/") == path.Length - 1)
                {
                    path = path.Remove(path.Length - 1);
                }
            }
            return path;
        }

        #endregion

        #region 读取文件

        public static string ReadTxt(string FileName)
        {
            string str = "";
            if (HttpContext.Current == null)
                FileName = System.Web.HttpRuntime.AppDomainAppPath + FileName;
            else
                FileName = HttpContext.Current.Server.MapPath(@"~/" + FileName);
            if (File.Exists(FileName))
            {
                //FileStream fs = new FileStream(FileName, FileMode.Open);
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(fs);
                str = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
            else
            {
                str = "";
            }
            return str;
        }
        #endregion
        #region get方式提交数据

        public static string Get(string WebUrl)
        {
            string content = "";
            //HttpResponse response = HttpContext.Current.Response;
            //HttpRequest request = HttpContext.Current.Request;
            StringWriter sw = new StringWriter();
            string url = WebUrl;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] b = wc.DownloadData(url);
            content = System.Text.Encoding.GetEncoding("utf-8").GetString(b);
            return content;

        }
        public static void DownLoadFile(string WebUrl, string path, string filename)
        {
            StringWriter sw = new StringWriter();
            string url = WebUrl;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
            System.Net.WebClient wc = new System.Net.WebClient();
            path = AppDomain.CurrentDomain.BaseDirectory + path;
            // string Path = ServerPath + "/download/" + System.DateTime.Now.ToString("yyyy") + "/";
            if (!Directory.Exists(path))   //如果路径不存在，则创建
            {
                Directory.CreateDirectory(path);
            }
            if (File.Exists(path + filename))
            {
                File.Delete(path + filename);
            }
            wc.DownloadFile(WebUrl, path + filename);
        }
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受  
            return true;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="WebUrl"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string PostFile(string WebUrl, string file)
        {
            string content = "";
            try
            {
                string url = WebUrl;
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] b = wc.UploadFile(WebUrl, file);
                content = System.Text.Encoding.GetEncoding("utf-8").GetString(b);


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return content;

        }
        #endregion

        #region post方式提交数据

        public static string Post(string WebUrl, System.Collections.Specialized.NameValueCollection nv)
        {
            string content = "";
            if (nv == null)
                nv = new System.Collections.Specialized.NameValueCollection();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(WebUrl);
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.lebi.cn");
                request.Timeout = 1000 * 15;
                //HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                //if (myResponse.StatusDescription.ToString().ToUpper() == "OK")
                //{
                    StringWriter sw = new StringWriter();
                    string url = WebUrl;
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] b = wc.UploadValues(WebUrl, "POST", nv);
                    content = System.Text.Encoding.GetEncoding("utf-8").GetString(b);
                //}

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


            return content;

        }
        public static string Post(string WebUrl)
        {
            return Post(WebUrl, null);
        }
        #endregion


    }
}
