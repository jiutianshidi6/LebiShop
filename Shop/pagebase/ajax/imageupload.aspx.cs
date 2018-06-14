using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

using System.Text;
using System.Collections.Generic;

using Shop.Bussiness;
using Shop.Model;
using Shop.Tools;
namespace Shop.Ajax
{
    public partial class ImageUpload : PageBase
    {
        public void LoadPage()
        {
            if (!AjaxLoadCheck())
            {
                return;
            }
            string msg = "";
            string name = "";
            HttpFileCollection files = HttpContext.Current.Request.Files;
            BaseConfig conf = ShopCache.GetBaseConfig();

            B_WaterConfig bc = new B_WaterConfig();
            WaterConfig mx = bc.LoadConfig();
            if (files.Count > 0)
            {
                ///'检查文件扩展名字
                HttpPostedFile postedFile = files[0];
                string savepath = GetPath(conf.UpLoadPath);
                string fileName, fileExtension;
                fileName = System.IO.Path.GetFileName(postedFile.FileName);
                fileExtension = System.IO.Path.GetExtension(fileName);
                if (conf.UpLoadSaveName == "" || conf.UpLoadSaveName == null)
                    conf.UpLoadSaveName = "0";
                if (conf.UpLoadSaveName == "0")
                {
                    name = DateTime.Now.ToString("yyMMddssfff") + "_w$h_";
                }
                else
                {
                    name = System.IO.Path.GetFileNameWithoutExtension(fileName) + "_w$h_";
                }
                name = conf.UpLoadRName + name + fileExtension;
                int status = ImageHelper.SaveImage(postedFile, savepath, name);
                if (status != 290)
                {
                    msg = Language.Tag(EX_Type.TypeName(status));
                    Response.Write("{\"msg\":\"" + msg + "\"}");
                    return;
                }
                if (Shop.LebiAPI.Service.Instanse.Check("imageserver") && WebConfig.Instrance.UpLoadURL != "")
                {
                    try
                    {
                        string url = WebConfig.Instrance.UpLoadURL;
                        if (url.Contains("?"))
                            url += "&filename=" + fileName;
                        else
                            url += "?filename=" + fileName;
                        if (WebConfig.Instrance.ImageServerKey != "")
                            url += "&key=" + WebConfig.Instrance.ImageServerKey;
                        string res = HtmlEngine.PostFile(url, ImageHelper.rootpath(savepath + name));
                        //api = jss.Deserialize<LBAPI>(res);
                        ImageHelper.DeleteImage(savepath + name);
                        Response.Write(res);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("{\"msg\":\"" + ex.Message + "\"}");
                    }
                    return;
                }

                string OldImage = savepath + name;
                //string ImageBig = name.Replace("_w$h_", "_" + conf.ImageBigWidth + "$" + conf.ImageBigHeight + "_");
                //string ImageMedium = name.Replace("_w$h_", "_" + conf.ImageMediumWidth + "$" + conf.ImageMediumHeight + "_");
                //string ImageSmall = name.Replace("_w$h_", "_" + conf.ImageSmallWidth + "$" + conf.ImageSmallHeight + "_");
                //string size = conf.ImageBigWidth + "$" + conf.ImageBigHeight + "," + conf.ImageMediumWidth + "$" + conf.ImageMediumHeight + "," + conf.ImageSmallWidth + "$" + conf.ImageSmallHeight;
                string size = "";



                //if (mx.OnAndOff == "1")
                //{
                //    ImageHelper.UPLoad(OldImage, savepath, "temp_" + name, Convert.ToInt32(conf.ImageBigWidth), Convert.ToInt32(conf.ImageBigHeight));
                //    ImageHelper.MakeWater(System.Web.HttpContext.Current.Server.MapPath(savepath) + "temp_" + name, savepath, ImageBig, mx);
                //    ImageHelper.DeleteImage(savepath + "temp_" + name);
                //}
                //else
                //{
                //    ImageHelper.UPLoad(OldImage, savepath, ImageBig, Convert.ToInt32(conf.ImageBigWidth), Convert.ToInt32(conf.ImageBigHeight));
                //}

                //ImageHelper.UPLoad(OldImage, savepath, ImageMedium, Convert.ToInt32(conf.ImageMediumWidth), Convert.ToInt32(conf.ImageMediumHeight));
                //ImageHelper.UPLoad(OldImage, savepath, ImageSmall, Convert.ToInt32(conf.ImageSmallWidth), Convert.ToInt32(conf.ImageSmallHeight));


                ////生成所有规格
                //string where = "id not in (select id from Lebi_ImageSize where (Width=" + conf.ImageBigWidth + " and Height=" + conf.ImageBigHeight + ") or (Width=" + conf.ImageMediumWidth + " and Height=" + conf.ImageMediumHeight + ") or (Width=" + conf.ImageSmallWidth + " and Height=" + conf.ImageSmallHeight + "))";
                //List<Lebi_ImageSize> ss = B_Lebi_ImageSize.GetList(where, "");
                //foreach (Lebi_ImageSize s in ss)
                //{
                //    ImageHelper.UPLoad(OldImage, savepath, name.Replace("_w$h_", "_" + s.Width + "$" + s.Height + "_"), s.Width, s.Height);
                //    size += "," + s.Width + "$" + s.Height;
                //}
                //写入数据库
                Lebi_Image model = new Lebi_Image();
                model.Image = OldImage;
                model.Keyid = 0;
                model.Size = size;
                model.TableName = "Product";
                B_Lebi_Image.Add(model);
                msg = "OK";
                Response.Write("{\"msg\":\"" + msg + "\",\"img\":\"" + OldImage + "\",\"file\":\"" + fileName + "\"}");
                return;

            }
            msg = Language.Tag("没有选择任何文件", "");
            Response.Write("{\"msg\":\"" + msg + "\"}");
        }
        private string GetPath(string path)
        {

            //path = "/Product/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MMdd") + "/";
            //path = ThemeUrl.CheckURL(path);
            //return path;
            return ThemeUrl.CheckURL(path + "/Product/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MMdd") + "/");
        }
    }
}