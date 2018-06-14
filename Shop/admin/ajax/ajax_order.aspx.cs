using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using Shop.Model;
using Shop.Bussiness;
using Shop.Tools;
using System.Reflection;
using System.Web.Script.Serialization;

namespace Shop.Admin.Ajax
{
    /// <summary>
    /// 订单相关的操作
    /// </summary>
    public partial class Ajax_order : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Shop.Tools.RequestTool.RequestString("__Action");
            Type type = this.GetType();
            MethodInfo methodInfo = type.GetMethod(action);
            if (methodInfo != null)
                methodInfo.Invoke(this, null);
        }
        /// <summary>
        /// 编辑订单
        /// </summary>
        public void Order_Edit()
        {
            if (!EX_Admin.Power("order_edit", "编辑订单"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            Lebi_Order model = B_Lebi_Order.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
            }
            else
            {
                model = B_Lebi_Order.BindForm(model);
                B_Lebi_Order.Update(model);
            }

            Log.Add("编辑订单", "Order", id.ToString(), CurrentAdmin, "");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 编辑订单-收货人
        /// </summary>
        public void Order_shouhuo_Edit()
        {
            if (!EX_Admin.Power("order_edit", "编辑订单"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            Lebi_Order model = B_Lebi_Order.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
            }
            else
            {
                model = B_Lebi_Order.BindForm(model);
                B_Lebi_Order.Update(model);
            }
            Log.Add("编辑收货人", "Order", id.ToString(), CurrentAdmin, "");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 编辑订单-订单状态变更
        /// </summary>
        public void Order_type()
        {
            int id = RequestTool.RequestInt("id", 0);
            int t = RequestTool.RequestInt("t", 2);
            string str = RequestTool.RequestString("model");
            string action = "";
            Lebi_Order model = B_Lebi_Order.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
            }
            else
            {
                if (str == "IsInvalid")
                {
                    if (!EX_Admin.Power("order_status_edit", "订单审核"))
                    {
                        AjaxNoPower();
                        return;
                    }
                    action = "订单审核";
                    if (t == 1)
                    {
                        action += " 无效";
                        Order.Order_Cancal(model);//取消订单
                    }
                    else
                    {
                        action += " 有效";
                        string res = "";
                        Order.Order_Confirm(model, out res);//修改为有效订单
                        if (res != "")
                        {
                            Response.Write("{\"msg\":\"" + res + "\"}");
                            return;
                        }
                    }
                    Log.Add(action, "Order", id.ToString(), CurrentAdmin, model.Code);

                }
                if (str == "IsVerified")
                {
                    if (!EX_Admin.Power("order_status_edit", "订单审核"))
                    {
                        AjaxNoPower();
                        return;
                    }
                    action = "订单审核";
                    if (t == 0)
                    {
                        action += " 未确认";
                        Order.Order_Check_Cancal(model);
                    }
                    else
                    {
                        action += " 已确认";
                        string res = "";
                        Order.Order_Confirm(model, out res);//修改为有效订单
                        if (res != "")
                        {
                            Response.Write("{\"msg\":\"" + res + "\"}");
                            return;
                        }
                    }
                    Log.Add(action, "Order", id.ToString(), CurrentAdmin, "");
                }
                if (str == "IsPaid")
                {

                    if (!EX_Admin.Power("order_status_ispaid", "订单支付"))
                    {
                        AjaxNoPower();
                        return;
                    }
                    action = "订单支付";
                    if (t == 0)
                    {
                        action += " 未支付";
                        Order.Order_Pay_Cancal(model);
                    }
                    else
                    {
                        action += " 已支付";
                        Order.PaySuccess(model);
                    }
                    Log.Add(action, "Order", id.ToString(), CurrentAdmin, "");
                }
                if (str == "IsCompleted")
                {
                    if (model.IsVerified != 1)
                    {
                        Response.Write("{\"msg\":\"未确认订单不能进行此操作\"}");
                        return;
                    }

                    if (!EX_Admin.Power("order_complete", "订单完成"))
                    {
                        AjaxNoPower();
                        return;
                    }
                    action = "订单完成";
                    if (t == 0)
                    {
                        action += " 未完成";
                        Order.Order_Completed_Cancal(model);//完成订单-取消
                    }
                    else
                    {
                        if (model.IsPaid != 1)
                        {
                            Response.Write("{\"msg\":\"未付款订单不能进行此操作\"}");
                            return;
                        }
                        action += " 已完成";
                        Order.Order_Completed(model);//完成订单
                    }
                    Log.Add(action, "Order", id.ToString(), CurrentAdmin, "");
                }
            }
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 删除订单商品
        /// </summary>
        public void OrderPro_Del()
        {
            if (!EX_Admin.Power("order_product_del", "删除订单商品"))
            {
                AjaxNoPower();
                return;
            }
            string ids = RequestTool.RequestString("proid");
            int id = RequestTool.RequestInt("id", 0);
            Lebi_Order model = B_Lebi_Order.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
            }
            if (ids != "")
            {
                //修改冻结库存
                List<Lebi_Order_Product> ps = B_Lebi_Order_Product.GetList("Order_id=" + model.id + " and id in (lbsql{" + ids + "})", "");
                foreach (Lebi_Order_Product p in ps)
                {
                    Lebi_Product pro = B_Lebi_Product.GetModel(p.Product_id);
                    pro.Count_Freeze = pro.Count_Freeze - p.Count;
                    B_Lebi_Product.Update(pro);
                }
                B_Lebi_Order_Product.Delete("Order_id=" + model.id + " and id in (lbsql{" + ids + "})");
                Order.ResetOrder(model);//重新计算订单
            }
            Log.Add("删除订单商品", "Order", model.id.ToString(), CurrentAdmin, ids.ToString());
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 修改订单商品
        /// </summary>
        public void OrderPro_Edit()
        {
            if (!EX_Admin.Power("order_product_edit", "编辑订单商品"))
            {
                AjaxNoPower();
                return;
            }
            string ids = RequestTool.RequestString("Uproid");
            int id = RequestTool.RequestInt("id", 0);
            Lebi_Order model = B_Lebi_Order.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
            }
            List<Lebi_Order_Product> pros = B_Lebi_Order_Product.GetList("id in (lbsql{" + ids + "})", "");
            foreach (Lebi_Order_Product pro in pros)
            {
                Lebi_Order_Product modelp = B_Lebi_Order_Product.GetModel(pro.id);
                pro.Price = RequestTool.RequestDecimal("Price" + pro.id, 0);
                pro.Count = RequestTool.RequestInt("Count" + pro.id, 0);
                if (pro.Price != modelp.Price)
                {
                    Log.Add("编辑订单商品单价[" + modelp.Product_Number + "]", "Order", id.ToString(), CurrentAdmin, modelp.Price + "->" + pro.Price);
                }
                if (pro.Count != modelp.Count)
                {
                    //修改冻结库存
                    Lebi_Product product = B_Lebi_Product.GetModel(pro.Product_id);
                    product.Count_Freeze = product.Count_Freeze - modelp.Count + pro.Count;
                    B_Lebi_Product.Update(product);

                    Log.Add("编辑订单商品数量[" + modelp.Product_Number + "]", "Order", id.ToString(), CurrentAdmin, modelp.Count + "->" + pro.Count);
                }
                pro.Money = pro.Price * pro.Count;
                B_Lebi_Order_Product.Update(pro);
            }
            Log.Add("编辑订单商品", "Order", ids.ToString(), CurrentAdmin, "");
            Order.ResetOrder(model);//重新计算订单

            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 编辑订单金额 
        /// </summary>
        public void Order_Money_Edit()
        {
            if (!EX_Admin.Power("order_price_edit", "编辑订单金额"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            Lebi_Order model = B_Lebi_Order.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
            }
            else
            {
                decimal Money_Bill = RequestTool.RequestDecimal("Money_Bill", 0);
                decimal Money_Product = RequestTool.RequestDecimal("Money_Product", 0);
                decimal Money_Transport = RequestTool.RequestDecimal("Money_Transport", 0);
                decimal Money_Give = RequestTool.RequestDecimal("Money_Give", 0);
                decimal Point = RequestTool.RequestDecimal("Point", 0);
                string action = "";
                string description = "";
                if (model.Money_Product != Money_Product)
                {
                    action = "编辑商品金额";
                    description = model.Money_Product.ToString() + " -> " + Money_Product;
                    Log.Add(action, "Order", model.id.ToString(), CurrentAdmin, description);
                }
                if (model.Money_Transport != Money_Transport)
                {
                    action = "编辑运费";
                    description = model.Money_Transport.ToString() + " -> " + Money_Transport;
                    Log.Add(action, "Order", model.id.ToString(), CurrentAdmin, description);
                }
                if (model.Money_Bill != Money_Bill)
                {
                    action = "编辑税金";
                    description = model.Money_Bill.ToString() + " -> " + Money_Bill;
                    Log.Add(action, "Order", model.id.ToString(), CurrentAdmin, description);
                }
                if (model.Money_Give != Money_Give)
                {
                    action = "编辑返现";
                    description = model.Money_Give.ToString() + " -> " + Money_Give;
                    Log.Add(action, "Order", model.id.ToString(), CurrentAdmin, description);
                }
                if (model.Point != Point)
                {
                    action = "编辑订单积分";
                    description = model.Point.ToString() + " -> " + Point;
                    Log.Add(action, "Order", model.id.ToString(), CurrentAdmin, description);
                }
                model.Money_Product = Money_Product;
                model.Money_Transport = Money_Transport;
                model.Money_Bill = Money_Bill;
                model.Money_Give = Money_Give;
                model.Money_Order = model.Money_Product + model.Money_Transport + model.Money_Bill - model.Money_Transport_Cut - model.Money_Cut;
                if (model.Type_id_OrderType == 212)//退货单
                    model.Money_Pay = 0;
                else
                    model.Money_Pay = model.Money_Order - model.Money_UserCut;
                model.Point = Point;
                B_Lebi_Order.Update(model);
                //更新发票记录
                if (model.Money_Order > 0)
                {
                    Lebi_Bill bill = B_Lebi_Bill.GetModel("Order_id=" + model.id + "");
                    if (bill != null)
                    {
                        if (bill.Money != model.Money_Order)
                        {
                            bill.Money = model.Money_Order;
                            B_Lebi_Bill.Update(bill);
                        }
                    }
                }

            }
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 发货操作
        /// </summary>
        public void Order_fahuo()
        {
            if (!EX_Admin.Power("order_shipping", "订单发货"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            int Transport_id = RequestTool.RequestInt("Transport_id", 0);
            Lebi_Transport tran = B_Lebi_Transport.GetModel(Transport_id);
            Lebi_Order model = B_Lebi_Order.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
                return;
            }
            Lebi_Transport_Order torder = new Lebi_Transport_Order();
            torder.Code = RequestTool.RequestString("Code");
            torder.Money = RequestTool.RequestDecimal("Money");
            torder.Order_id = model.id;

            torder.T_Address = model.T_Address;
            torder.T_Email = model.T_Email;
            torder.T_MobilePhone = model.T_MobilePhone;
            torder.T_Name = model.T_Name;
            torder.T_Phone = model.T_Phone;
            torder.Transport_Code = tran == null ? model.Transport_Code : tran.Code;
            torder.Transport_id = tran == null ? model.Transport_id : tran.id;
            torder.Transport_Name = tran == null ? model.Transport_Name : tran.Name;
            torder.User_id = model.User_id;

            List<TransportProduct> tps = new List<TransportProduct>();
            TransportProduct tp;
            List<Lebi_Order_Product> pros = B_Lebi_Order_Product.GetList("Order_id=" + model.id + "", "");
            int count = 0;
            foreach (Lebi_Order_Product pro in pros)
            {
                count = count + RequestTool.RequestInt("Count" + pro.id, 0);
            }
            if (count == 0)
            {
                Response.Write("{\"msg\":\"" + Tag("发货数量不能为0") + "\"}");
                return;
            }
            bool isfahuo_all = true;
            foreach (Lebi_Order_Product pro in pros)
            {
                count = RequestTool.RequestInt("Count" + pro.id, 0);
                if (count == 0)
                {
                    if (pro.Count > 0)
                        isfahuo_all = false;
                    continue;
                }
                tp = new TransportProduct();
                tp.Count = count;
                tp.ImageBig = pro.ImageBig;
                tp.ImageMedium = pro.ImageMedium;
                tp.ImageOriginal = pro.ImageOriginal;
                tp.ImageSmall = pro.ImageSmall;
                tp.Product_Number = pro.Product_Number;
                tp.Product_id = pro.Product_id;
                tp.Product_Name = pro.Product_Name;
                tps.Add(tp);

                pro.Count_Shipped = pro.Count_Shipped + count;
                if (pro.Count_Shipped < pro.Count)
                    isfahuo_all = false;
                B_Lebi_Order_Product.Update(pro);
                //更新库存
                Lebi_Product product = B_Lebi_Product.GetModel(pro.Product_id);
                EX_Product.ProductStock_Change(product, (0 - count), 302, model.Code, model.id);
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            torder.Admin_id = CurrentAdmin.id;
            torder.AdminName = CurrentAdmin.UserName;
            torder.Product = jss.Serialize(tps);
            torder.Type_id_TransportOrderStatus = 220;//默认状态：在途
            B_Lebi_Transport_Order.Add(torder);
            model.IsShipped = 1;
            model.IsShipped_All = isfahuo_all ? 1 : 0;
            model.Time_Shipped = System.DateTime.Now; ;
            B_Lebi_Order.Update(model);
            Log.Add("订单发货", "Order", id.ToString(), CurrentAdmin, torder.Transport_Name + " " + torder.Code);
            Lebi_User user = B_Lebi_User.GetModel(model.User_id);
            //发送邮件
            if (ShopCache.GetBaseConfig().MailSign.ToLower().Contains("dingdanfahuo"))
            {
                Email.SendEmail_ordershipping(user, model, torder);
            }
            //发送短信
            if (ShopCache.GetBaseConfig().SMS_sendmode.Contains("SMSTPL_ordershipping"))
            {
                SMS.SendSMS_ordershipping(user, model, torder);
            }
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 获取订单备注
        /// </summary>
        public void Order_Memo()
        {
            if (!EX_Admin.Power("order_edit", "编辑订单"))
            {
                AjaxNoPower();
                return;
            }
            string Remark_Admin = "";
            int id = RequestTool.RequestInt("id", 0);
            Lebi_Order model = B_Lebi_Order.GetModel(id);
            if (model != null)
            {
                Remark_Admin = model.Remark_Admin;
                Response.Write(Remark_Admin);
            }
        }
        /// <summary>
        /// 订单留言
        /// </summary>
        public void Comment_Edit()
        {
            if (!EX_Admin.Power("order_comment_edit", "添加订单留言"))
            {
                AjaxNoPower();
                return;
            }
            Lebi_Comment model = new Lebi_Comment();
            model.TableName = "Order";
            model.Keyid = RequestTool.RequestInt("id", 0);
            model.Admin_UserName = CurrentAdmin.UserName;
            model.Admin_id = CurrentAdmin.id;
            model.Content = RequestTool.RequestString("Comment");
            B_Lebi_Comment.Add(model);
            Log.Add("添加订单留言", "Comments", RequestTool.RequestInt("id", 0).ToString(), CurrentAdmin, RequestTool.RequestString("Comment"));
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 订单留言-删除
        /// </summary>
        public void Comment_Del()
        {
            if (!EX_Admin.Power("order_comment_del", "删除订单留言"))
            {
                AjaxNoPower();
                return;
            }
            string ids = RequestTool.RequestString("commid");
            if (ids != "")
                B_Lebi_Comment.Delete("id in (lbsql{" + ids + "})");
            Log.Add("删除订单留言", "Comments", ids.ToString(), CurrentAdmin, "");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 删除快递单打印模板
        /// </summary>
        public void Order_Del()
        {
            if (!EX_Admin.Power("order_del", "删除订单"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("ids");
            if (id == "")
            {
                Response.Write("{\"msg\":\"参数错误\"}");
                return;
            }
            List<Lebi_Order> modellist = B_Lebi_Order.GetList("id in (lbsql{" + id + "})", "");
            foreach (Lebi_Order model in modellist)
            {
                //B_Lebi_Order.Delete("id = " + model.id + "");
                //B_Lebi_Order_Log.Delete("Order_id = " + model.id + "");
                //B_Lebi_Order_Product.Delete("Order_id = " + model.id + "");
                //B_Lebi_Comment.Delete("Keyid = " + model.id + "");
                ////B_Lebi_User_BuyMoney.Delete("Order_id = " + model.id + "");
                Order.OrderDelete(model);
            }
            Log.Add("删除订单", "Order", id.ToString(), CurrentAdmin, "");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 编辑快递单打印模板-FLASH
        /// </summary>
        public void Express_Edit()
        {
            if (!EX_Admin.Power("express_edit", "编辑模板"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            string data = RequestTool.RequestString("data");
            string mobname = RequestTool.RequestString("mobname");
            string mobwidth = RequestTool.RequestString("mobwidth");
            string mobheight = RequestTool.RequestString("mobheight");
            Lebi_Express model = B_Lebi_Express.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
            }
            else
            {
                model.Name = mobname;
                model.Width = mobwidth;
                model.Height = mobheight;
                model.Pos = data;
                B_Lebi_Express.Update(model);
            }
            Log.Add("编辑快递单模板", "Express", id.ToString(), CurrentAdmin, RequestTool.RequestString("mobname"));
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 编辑快递单打印模板
        /// </summary>
        public void Express_Edit_Window()
        {
            bool addflag = false;
            int id = RequestTool.RequestInt("id", 0);
            string Name = RequestTool.RequestString("Name");
            string Width = RequestTool.RequestString("Width");
            string Height = RequestTool.RequestString("Height");
            string Background = RequestTool.RequestString("Background");
            int Status = RequestTool.RequestInt("Status", 0);
            int Sort = RequestTool.RequestInt("Sort", 0);
            int Transport_id = RequestTool.RequestInt("Transport_id", 0);
            Lebi_Express model = B_Lebi_Express.GetModel(id);
            if (model == null)
            {
                addflag = true;
                model = new Lebi_Express();
            }
            model.Name = Name;
            model.Width = Width;
            model.Height = Height;
            model.Background = Background;
            model.Status = Status;
            model.Sort = Sort;
            model.Transport_id = Transport_id;
            if (addflag)
            {
                if (!EX_Admin.Power("express_add", "添加模板"))
                {
                    AjaxNoPower();
                    return;
                }
                B_Lebi_Express.Add(model);
                id = B_Lebi_Express.GetMaxId();
                Log.Add("添加模板", "Express", id.ToString(), CurrentAdmin, RequestTool.RequestString("Name"));
            }
            else
            {
                if (!EX_Admin.Power("express_edit", "编辑模板"))
                {
                    AjaxNoPower();
                    return;
                }
                B_Lebi_Express.Update(model);
                Log.Add("编辑模板", "Express", id.ToString(), CurrentAdmin, RequestTool.RequestString("Name"));
            }
            ImageHelper.LebiImagesUsed(model.Background, "config", id);
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 复制快递单打印模板
        /// </summary>
        public void Express_Copy()
        {
            if (!EX_Admin.Power("express_edit", "编辑模板"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            Lebi_Express model = B_Lebi_Express.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
                return;
            }
            model.Name = "[复制]" + model.Name;
            B_Lebi_Express.Add(model);
            Log.Add("复制模板", "Express", id.ToString(), CurrentAdmin, model.Name);
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 删除快递单打印模板
        /// </summary>
        public void Express_Del()
        {
            if (!EX_Admin.Power("express_del", "删除模板"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("ids");
            Lebi_Express model = B_Lebi_Express.GetModel("id in (lbsql{" + id + "})");
            if (id == "")
            {
                Response.Write("{\"msg\":\"参数错误\"}");
                return;
            }
            Log.Add("删除模板", "Express", id.ToString(), CurrentAdmin, model.Name);
            B_Lebi_Express.Delete("id in (lbsql{" + id + "})");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 批量更新快递单打印模板序号
        /// </summary>
        public void Express_Update()
        {
            if (!EX_Admin.Power("express_edit", "编辑快递单模板"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("Uid");
            List<Lebi_Express> models = B_Lebi_Express.GetList("id in (lbsql{" + id + "})", "");
            foreach (Lebi_Express model in models)
            {
                model.Sort = RequestTool.RequestInt("Sort" + model.id + "", 0);
                B_Lebi_Express.Update(model);
            }
            Log.Add("编辑模板", "Express", id.ToString(), CurrentAdmin, id.ToString());
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 编辑发货人信息
        /// </summary>
        public void Express_Shipper_Edit()
        {
            int id = RequestTool.RequestInt("id", 0);
            bool addflag = false;
            string SiteName = RequestTool.RequestString("SiteName");
            string UserName = RequestTool.RequestString("UserName");
            string Address = RequestTool.RequestString("Address");
            string City = RequestTool.RequestString("City");
            string ZipCode = RequestTool.RequestString("ZipCode");
            string Tel = RequestTool.RequestString("Tel");
            string Mobile = RequestTool.RequestString("Mobile");
            string Remark = RequestTool.RequestString("Remark");
            int Status = RequestTool.RequestInt("Status", 0);
            int Sort = RequestTool.RequestInt("Sort", 0);
            Lebi_Express_Shipper model = B_Lebi_Express_Shipper.GetModel(id);
            if (model == null)
            {
                addflag = true;
                model = new Lebi_Express_Shipper();
            }
            model.SiteName = SiteName;
            model.UserName = UserName;
            model.Address = Address;
            model.City = City;
            model.ZipCode = ZipCode;
            model.Tel = Tel;
            model.Mobile = Mobile;
            model.City = City;
            model.Status = Status;
            model.Sort = Sort;
            model.Remark = Remark;
            if (addflag)
            {
                if (!EX_Admin.Power("express_shipper_add", "添加发货人"))
                {
                    AjaxNoPower();
                    return;
                }
                B_Lebi_Express_Shipper.Add(model);
                id = B_Lebi_Express_Shipper.GetMaxId();
                Log.Add("添加发货人", "Express_Shipper", id.ToString(), CurrentAdmin, SiteName);
            }
            else
            {
                if (!EX_Admin.Power("express_shipper_edit", "编辑发货人"))
                {
                    AjaxNoPower();
                    return;
                }
                B_Lebi_Express_Shipper.Update(model);
                Log.Add("编辑发货人", "Express_Shipper", id.ToString(), CurrentAdmin, SiteName);
            }
            string result = "{\"msg\":\"OK\", \"id\":\"" + id + "\"}";
            Response.Write(result);
        }
        /// <summary>
        /// 批量更新发货人信息
        /// </summary>
        public void Express_Shipper_Update()
        {
            if (!EX_Admin.Power("express_shipper_edit", "编辑发货人"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("Uid");
            List<Lebi_Express_Shipper> models = B_Lebi_Express_Shipper.GetList("id in (lbsql{" + id + "})", "");
            foreach (Lebi_Express_Shipper model in models)
            {
                model.Sort = RequestTool.RequestInt("Sort" + model.id + "", 0);
                B_Lebi_Express_Shipper.Update(model);
            }
            Log.Add("编辑发货人", "Express_Shipper", id.ToString(), CurrentAdmin, id.ToString());
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 删除发货人信息
        /// </summary>
        public void Express_Shipper_Del()
        {
            if (!EX_Admin.Power("express_shipper_del", "删除发货人"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("ids");
            if (id == "")
            {
                Response.Write("{\"msg\":\"参数错误\"}");
                return;
            }
            B_Lebi_Express_Shipper.Delete("id in (lbsql{" + id + "})");
            Log.Add("删除发货人", "Express_Shipper", id.ToString(), CurrentAdmin, "");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 添加订单至快递单打印清单
        /// </summary>
        public void Express_Log_Add()
        {
            if (!EX_Admin.Power("express_log_add", "添加打印清单"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("ids");
            if (id == "")
            {
                Response.Write("{\"msg\":\"请先选择订单\"}");
                return;
            }
            //=====================================
            //这是我添的
            List<Lebi_Order> orders = B_Lebi_Order.GetList("id in (lbsql{" + id + "})", "");
            int Transport_id = orders.FirstOrDefault().Transport_id;
            string Transport_Name = orders.FirstOrDefault().Transport_Name;
            foreach (Lebi_Order order in orders)
            {
                if (Transport_id != order.Transport_id)
                {
                    Response.Write("{\"msg\":\"请选择同一种配送方式的订单\"}");
                    return;
                }
            }
            //=======================================
            Lebi_Express_Log model = new Lebi_Express_Log();
            model.Number = Shop.Bussiness.Order.CreateOrderCode();
            model.Time_Add = DateTime.Now;
            model.Status = 0;
            model.IdList = id;
            model.Transport_id = Transport_id;
            model.Transport_Name = Transport_Name;
            B_Lebi_Express_Log.Add(model);
            int MaxId = B_Lebi_Express_Log.GetMaxId();
            string ids = id;
            string[] idsArr;
            idsArr = ids.Split(new char[1] { ',' });
            foreach (string i in idsArr)
            {
                Lebi_Express_LogList models = B_Lebi_Express_LogList.GetModel("Order_Id = " + int.Parse(i));
                if (models == null)
                {
                    Lebi_Order modelorder = B_Lebi_Order.GetModel(int.Parse(i));
                    models = new Lebi_Express_LogList();
                    models.Express_Log_Id = MaxId;
                    models.Order_Id = int.Parse(i);
                    models.Order_Code = modelorder.Code;
                    models.Status = 0;
                    B_Lebi_Express_LogList.Add(models);
                }
            }
            Log.Add("添加打印清单", "Express_LogList", id.ToString(), CurrentAdmin, Shop.Bussiness.Order.CreateOrderCode());
            string result = "{\"msg\":\"OK\"}";
            Response.Write(result);
        }
        /// <summary>
        /// 删除打印清单信息
        /// </summary>
        public void Express_Log_Del()
        {
            if (!EX_Admin.Power("express_log_del", "删除打印清单"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("ids");
            if (id == "")
            {
                Response.Write("{\"msg\":\"请选择要删除的打印清单\"}");
                return;
            }
            B_Lebi_Express_Log.Delete("id in (lbsql{" + id + "})");
            B_Lebi_Express_LogList.Delete("Express_Log_Id in (lbsql{" + id + "})");
            Log.Add("删除打印清单", "Express_Log", id.ToString(), CurrentAdmin, "");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 删除打印清单信息
        /// </summary>
        public void Express_LogList_Del()
        {
            if (!EX_Admin.Power("express_log_del", "删除打印清单"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("ids");
            if (id == "")
            {
                Response.Write("{\"msg\":\"请选择要删除的打印清单\"}");
                return;
            }
            B_Lebi_Express_LogList.Delete("Id in (lbsql{" + id + "})");
            Log.Add("删除打印清单", "Express_LogList", id.ToString(), CurrentAdmin, "");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 获取打印清单下的ID列表
        /// </summary>
        public void Express_LogList_IdList()
        {
            if (!EX_Admin.Power("express_log_print", "打印打印清单"))
            {
                AjaxNoPower();
                return;
            }
            string idlist = "";
            int id = RequestTool.RequestInt("id", 0);
            if (id == 0)
            {
                Response.Write("{\"msg\":\"请先选择订单清单\"}");
                return;
            }
            List<Lebi_Express_LogList> logs = B_Lebi_Express_LogList.GetList("Status = 0 and Express_Log_Id =" + id + "", "");
            foreach (Lebi_Express_LogList log in logs)
            {
                idlist += "," + log.Order_Id;
            }
            if (idlist == "")
            {
                Response.Write("{\"msg\":\"当前打印清单暂无需要打印的订单\"}");
                return;
            }
            idlist = idlist.Substring(1);
            if (idlist != "")
            {
                Response.Write("{\"msg\":\"OK\",\"id\":\"" + idlist + "\"}");
            }
            else
            {
                Response.Write("{\"msg\":\"没有可打印的订单\"}");
            }
        }
        /// <summary>
        /// 批量更新发货清单已打印
        /// </summary>
        public void Express_Log_Update()
        {
            int id = RequestTool.RequestInt("id", 0);
            string Uid = RequestTool.RequestString("Uid");
            if (Uid == "")
            {
                Response.Write("{\"msg\":\"请选择要操作的打印清单\"}");
                return;
            }
            if (id == 0)
            {
                List<Lebi_Express_Log> models = B_Lebi_Express_Log.GetList("id in (lbsql{" + Uid + "})", "");
                foreach (Lebi_Express_Log model in models)
                {
                    model.Status = RequestTool.RequestInt("Status" + model.id + "", 0);
                    B_Lebi_Express_Log.Update(model);
                    List<Lebi_Express_LogList> modellists = B_Lebi_Express_LogList.GetList("Express_Log_Id = " + model.id + "",

"");
                    foreach (Lebi_Express_LogList modellist in modellists)
                    {
                        modellist.Status = RequestTool.RequestInt("Status" + model.id + "", 0);
                        B_Lebi_Express_LogList.Update(modellist);
                        Lebi_Order modelorder = B_Lebi_Order.GetModel(modellist.Order_Id);
                        modelorder = B_Lebi_Order.BindForm(modelorder);
                        modelorder.IsPrintExpress = RequestTool.RequestInt("Status" + model.id + "", 0);
                        B_Lebi_Order.Update(modelorder);
                    }
                }
            }
            else
            {
                List<Lebi_Express_LogList> modellist = B_Lebi_Express_LogList.GetList("id in (lbsql{" + Uid + "})", "");
                foreach (Lebi_Express_LogList model in modellist)
                {
                    model.Status = RequestTool.RequestInt("Status" + model.id + "", 0);
                    B_Lebi_Express_LogList.Update(model);
                    Lebi_Order modelorder = B_Lebi_Order.GetModel(model.Order_Id);
                    modelorder = B_Lebi_Order.BindForm(modelorder);
                    modelorder.IsPrintExpress = RequestTool.RequestInt("Status" + model.id + "", 0);
                    B_Lebi_Order.Update(modelorder);
                }
            }
            Log.Add("更新快递单清单已打印", "Order", id.ToString(), CurrentAdmin, "");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 更新快递单打印状态
        /// </summary>
        public void Express_Print()
        {
            string id = RequestTool.RequestString("id");
            int Tid = RequestTool.RequestInt("Tid", 0);
            int Eid = RequestTool.RequestInt("Eid", 0);
            if (id == "")
            {
                Response.Write("{\"msg\":\"没有可供打印的快递单\"}");
                return;
            }
            List<Lebi_Express_LogList> modellist = B_Lebi_Express_LogList.GetList("Order_Id in (lbsql{" + id + "})", "");
            foreach (Lebi_Express_LogList model in modellist)
            {
                model.Status = 1;
                B_Lebi_Express_LogList.Update(model);
                Lebi_Order modelorder = B_Lebi_Order.GetModel(model.Order_Id);
                modelorder = B_Lebi_Order.BindForm(modelorder);
                modelorder.IsPrintExpress = 1;
                B_Lebi_Order.Update(modelorder);
            }
            List<Lebi_Express_LogList> log = B_Lebi_Express_LogList.GetList("Status = 0 and Express_Log_Id = " + Eid + "", "");
            if (log.Count == 0)
            {
                List<Lebi_Express_Log> models = B_Lebi_Express_Log.GetList("id = " + Eid + "", "");
                foreach (Lebi_Express_Log model in models)
                {
                    model.Status = 1;
                    B_Lebi_Express_Log.Update(model);
                }
            }
            Log.Add("更新快递单清单已打印", "Express_Log", id.ToString(), CurrentAdmin, "");
            Response.Write("{\"msg\":\"OK\"}");
        }

        /// <summary>
        /// 编辑当发票
        /// </summary>
        public void Bill_Edit()
        {
            if (!EX_Admin.Power("bill_edit", "修改发票"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            Lebi_Bill model = B_Lebi_Bill.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg" + Tag("参数错误") + "\"}");
                return;
            }
            model.BillNo = RequestTool.RequestSafeString("BillNo");
            model.Type_id_BillStatus = RequestTool.RequestInt("Type_id_BillStatus", 0);
            B_Lebi_Bill.Update(model);
            Log.Add("修改发票", "Bill", id.ToString(), CurrentAdmin, "");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 删除发票信息
        /// </summary>
        public void Bill_Del()
        {
            if (!EX_Admin.Power("bill_del", "删除发票"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("id");

            Log.Add("删除发票", "Bill", id, CurrentAdmin);
            B_Lebi_Bill.Delete("id in (lbsql{" + id + "})");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 获取自定义页面链接
        /// </summary>
        public void GetAdminSkin()
        {
            int i = 0;
            int id = RequestTool.RequestInt("id", 0);
            string res = "";
            List<Lebi_AdminSkin> models = B_Lebi_AdminSkin.GetList("Type_id_AdminSkinType = 361", "Sort desc");
            foreach (Lebi_AdminSkin model in models)
            {
                res += "<a href=\"" + site.AdminPath + "/custom/" + model.Code + ".aspx?id=" + id + "\" target=\"_blank\">" + model.Name + "</a>";
                if (i < models.Count) { res += "<br />"; }
                i++;
            }
            Response.Write(res);
        }
        /// <summary>
        /// 删除提现记录
        /// </summary>
        public void Cash_Del()
        {
            if (!EX_Admin.Power("cash_del", "删除提现记录"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("id");

            Log.Add("删除提现记录", "Cash", id, CurrentAdmin);
            B_Lebi_Cash.Delete("id in (lbsql{" + id + "})");
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 编辑提现记录
        /// </summary>
        public void Cash_Edit()
        {
            if (!EX_Admin.Power("cash_edit", "提现管理"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            Lebi_Cash model = B_Lebi_Cash.GetModel(id);
            if (model == null)
            {
                Response.Write("{\"msg" + Tag("参数错误") + "\"}");
                return;
            }
            int t = RequestTool.RequestInt("t", 0);
            model.Type_id_CashStatus = t;
            model.Admin_id = CurrentAdmin.id;
            model.Admin_UserName = CurrentAdmin.UserName;
            //if (t == 402)
            //{
            //    //打款，
            //    if (model.User_id > 0)
            //    {
            //        Lebi_User user = B_Lebi_User.GetModel(model.User_id);
            //        Money.AddMoney(user, 0 - model.Money, 193, CurrentAdmin, "", "");
            //    }
            //}
            model.Time_update = System.DateTime.Now;
            B_Lebi_Cash.Update(model);
            Log.Add("编辑提现记录", "Cash", id.ToString(), CurrentAdmin);
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 批量修改提现记录状态
        /// </summary>
        public void Cash_Update()
        {
            if (!EX_Admin.Power("cash_edit", "提现管理"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("id");
            if (id == "")
            {
                Response.Write("{\"msg\":\"" + Tag("参数错误") + "\"}");
                return;
            }
            List<Lebi_Cash> models = B_Lebi_Cash.GetList("id in (lbsql{" + id + "}) and Type_id_CashStatus != 402", "");
            foreach (Lebi_Cash model in models)
            {
                model.Time_update = System.DateTime.Now;
                model.Type_id_CashStatus = 402;
                B_Lebi_Cash.Update(model);
            }
            Log.Add("编辑提现记录", "Cash", id.ToString(), CurrentAdmin);
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 收货操作-退货单
        /// </summary>
        public void Order_shouhuo()
        {
            if (!EX_Admin.Power("order_shipping_shouhuo", "退货单订单收货"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            Lebi_Transport_Order torder = B_Lebi_Transport_Order.GetModel(id);
            if (torder == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
                return;
            }
            Lebi_Order order = B_Lebi_Order.GetModel(torder.Order_id);
            List<Lebi_Order_Product> opros = B_Lebi_Order_Product.GetList("Order_id=" + order.id + "", "");
            bool receiveall = true;
            foreach (Lebi_Order_Product opro in opros)
            {
                opro.Count_Received = RequestTool.RequestInt("Count" + opro.Product_id, 0);
                if (opro.Count_Received != opro.Count_Shipped)
                {
                    receiveall = false;
                }
                B_Lebi_Order_Product.Update(opro);

            }
            torder.Money = RequestTool.RequestDecimal("Money");
            torder.Time_Received = System.DateTime.Now;
            B_Lebi_Transport_Order.Update(torder);
            if (receiveall)
                order.IsReceived_All = 1;
            order.IsReceived = 1;
            B_Lebi_Order.Update(order);
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 退货单操作-处理退货资金
        /// </summary>
        public void TOrder_Cash()
        {

            if (!EX_Admin.Power("torder_cash", "处理退货资金"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            int type = RequestTool.RequestInt("type", 0);
            //type含义：1退款到提现2退款到用户账户3生成新订单
            Lebi_Order order = B_Lebi_Order.GetModel(id);
            if (order == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
                return;
            }
            if (order.Type_id_OrderType != 212)
            {
                Response.Write("{\"msg\":\"非退货单不能进行此操作\"}");
                return;
            }
            Lebi_User user = B_Lebi_User.GetModel(order.User_id);
            switch (type)
            {
                case 1:

                    Lebi_Cash model = new Lebi_Cash();
                    model.AccountName = user.CashAccount_Name;
                    model.AccountCode = user.CashAccount_Code;
                    model.Bank = user.CashAccount_Bank;
                    model.User_id = user.id;
                    model.User_UserName = user.UserName;
                    model.Money = order.Money_Give;
                    model.Type_id_CashStatus = 401;
                    model.Remark = order.Code + "退款";
                    model.Admin_id = CurrentAdmin.id;
                    model.Admin_UserName = CurrentAdmin.UserName;
                    B_Lebi_Cash.Add(model);
                    order.IsPaid = 1;
                    order.Time_Paid = System.DateTime.Now;
                    break;
                case 2:
                    Money.AddMoney(user, order.Money_Give, 195, null, order.Code + "退款", order.Code + "退款");
                    order.IsPaid = 1;
                    order.Time_Paid = System.DateTime.Now;
                    Shop.Bussiness.Order.PaySuccess_FenPeiHuoKuan(order);//处理货款
                    break;
                case 3:
                    Lebi_Order old = B_Lebi_Order.GetModel(order.Order_id);
                    Lebi_Order neworder = new Lebi_Order();
                    neworder.Type_id_OrderType = 211;
                    neworder.Code = Order.CreateOrderCode();
                    neworder.Money_fromorder = order.Money_Give;
                    neworder.Money_Market = 0 - order.Money_Market;
                    neworder.Money_Order = 0 - order.Money_Order;
                    neworder.Money_Product = 0 - order.Money_Product;
                    //rder.Pay = old.Pay;
                    neworder.T_Address = old.T_Address;
                    neworder.T_Area_id = old.T_Area_id;
                    neworder.T_Email = old.T_Email;
                    neworder.T_MobilePhone = order.T_MobilePhone;
                    neworder.T_Name = old.T_Name;
                    neworder.T_Phone = old.T_Phone;
                    neworder.T_Postalcode = old.T_Postalcode;
                    neworder.Time_Add = System.DateTime.Now;
                    neworder.Transport_Code = old.Transport_Code;
                    neworder.Transport_id = old.Transport_id;
                    neworder.Transport_Name = old.Transport_Name;
                    neworder.Transport_Price_id = old.Transport_Price_id;
                    neworder.User_id = old.User_id;
                    neworder.User_UserName = old.User_UserName;
                    neworder.Weight = order.Weight;
                    neworder.Remark_Admin = order.Remark_Admin;
                    neworder.Order_id = order.id;
                    neworder.Site_id = order.Site_id;
                    B_Lebi_Order.Add(neworder);
                    neworder.id = B_Lebi_Order.GetMaxId();
                    List<Lebi_Order_Product> ops = B_Lebi_Order_Product.GetList("Order_id=" + order.id + "", "");
                    foreach (Lebi_Order_Product op in ops)
                    {
                        op.Count = op.Count_Received;
                        op.Count_Received = 0;
                        op.Count_Return = 0;
                        op.Count_Shipped = 0;
                        op.Discount = 0;
                        op.IsCommented = 0;
                        op.Order_Code = neworder.Code;
                        op.Order_id = neworder.id;
                        op.Time_Add = System.DateTime.Now;
                        B_Lebi_Order_Product.Add(op);
                    }
                    order.IsCreateNewOrder = 1;
                    order.Time_CreateNewOrder = System.DateTime.Now;
                    Shop.Bussiness.Order.Order_Completed(order);
                    
                    Log.Add("生成新订单", "Order", order.id.ToString(), CurrentAdmin);
                    Log.Add("生成新订单", "Order", neworder.id.ToString(), CurrentAdmin);
                    break;
            }
            order.IsCompleted = 1;
            order.Time_Completed = System.DateTime.Now;
            B_Lebi_Order.Update(order);
            //扣除退货积分 by lebi.kingdge 2015-01-16
            Lebi_User_Point modelpoint = new Lebi_User_Point();
            modelpoint.Point = order.Point;
            modelpoint.Type_id_PointStatus = 171;
            modelpoint.Admin_UserName = CurrentAdmin.UserName;
            modelpoint.Admin_id = CurrentAdmin.id;
            modelpoint.Remark = order.Code + Tag("退款");
            modelpoint.Time_Update = DateTime.Now;
            modelpoint.User_id = user.id;
            modelpoint.User_RealName = user.RealName;
            modelpoint.User_UserName = user.UserName;
            B_Lebi_User_Point.Add(modelpoint);
            Point.UpdateUserPoint(user);
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 修改订单商品/修改规格
        /// </summary>
        public void order_product_edit()
        {
            if (!EX_Admin.Power("order_product_edit", "编辑订单商品"))
            {
                AjaxNoPower();
                return;
            }
            int id = RequestTool.RequestInt("id", 0);
            int productid = RequestTool.RequestInt("productid", 0);
            int orderid = RequestTool.RequestInt("orderid", 0);
            Lebi_Order model = B_Lebi_Order.GetModel(orderid);
            if (model == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
                return;
            }
            if (model.IsPaid == 1)
            {
                Response.Write("{\"msg\":\"已付款订单不能进行此操作\"}");
                return;
            }
            if (model.IsVerified == 1)
            {
                Response.Write("{\"msg\":\"已确认订单不能进行此操作\"}");
                return;
            }
            Lebi_Product product = B_Lebi_Product.GetModel(productid);
            if (product == null)
            {
                Response.Write("{\"msg\":\"参数错误\"}");
                return;
            }
            Lebi_Order_Product oproduct = B_Lebi_Order_Product.GetModel(id);
            if (oproduct == null)
            {
                oproduct = new Lebi_Order_Product();
                oproduct.Count = 1;
                oproduct.ImageBig = product.ImageBig;
                oproduct.ImageMedium = product.ImageMedium;
                oproduct.ImageOriginal = product.ImageOriginal;
                oproduct.ImageSmall = product.ImageSmall;
                oproduct.Money = product.Price;
                oproduct.Order_Code = model.Code;
                oproduct.Order_id = model.id;
                oproduct.Price = product.Price;
                oproduct.Product_id = product.id;
                oproduct.Product_Name = product.Name;
                oproduct.Product_Number = product.Number;
                oproduct.Type_id_OrderProductType = 251;
                oproduct.User_id = model.User_id;
                oproduct.Weight = product.Weight;
                oproduct.Supplier_id = model.Supplier_id;
                B_Lebi_Order_Product.Add(oproduct);

            }
            else
            {
                oproduct.Product_id = product.id;
                oproduct.Product_Name = product.Name;
                oproduct.Product_Number = product.Number;
                oproduct.ImageBig = product.ImageBig;
                oproduct.ImageMedium = product.ImageMedium;
                oproduct.ImageOriginal = product.ImageOriginal;
                oproduct.ImageSmall = product.ImageSmall;
                oproduct.Supplier_id = model.Supplier_id;
                B_Lebi_Order_Product.Update(oproduct);
            }
            Order.ResetOrder(model);//重新计算订单
            Log.Add("修改订单商品", "Order", model.id.ToString(), CurrentAdmin);
            Response.Write("{\"msg\":\"OK\"}");
        }
        /// <summary>
        /// 删除订单调查
        /// </summary>
        public void Order_ProPerty_Del()
        {
            if (!EX_Admin.Power("order_property_list", "订单调查"))
            {
                AjaxNoPower();
                return;
            }
            string id = RequestTool.RequestString("id");

            Log.Add("删除订单调查", "Order_ProPerty", id, CurrentAdmin);
            B_Lebi_Order_ProPerty.Delete("id in (lbsql{" + id + "})");
            Response.Write("{\"msg\":\"OK\"}");
        }
    }
}