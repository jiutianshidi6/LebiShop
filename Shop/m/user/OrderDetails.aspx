<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserOrderDetails" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserOrderDetails"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserOrderDetails","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserOrderDetails","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserOrderDetails","description")%>" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="format-detection" content="telephone=no" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="apple-mobile-web-app-status-bar-style" content="black" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="twcClient" content="false" id="twcClient" />
<meta name="revisit-after" content="1 days" />
<meta name="CurrenctCurrency" content="<%=CurrentCurrency.Code %>" />
<meta name="CurrenctCurrencyMsige" content="<%=CurrentCurrency.Msige %>" />
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrenctCurrencyLength" content="<%=CurrentCurrency.DecimalLength %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<script src="/Theme/system/wap/js/jquery-3.1.0.min.js" type="text/javascript"></script>
<script src="/Theme/system/wap/js/jquery-ias.min.js"></script>
<%if (CurrentLanguage.IsLazyLoad==1){ %><script src="/Theme/system/wap/js/jquery.lazyload.min.js" type="text/javascript"></script><%} %>
<script src="/Theme/system/wap/js/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
<%if (CurrentLanguage.Code=="CN"){%><script type="text/javascript" src="/Theme/system/wap/js/jquery-ui/datepicker-zh-CN.js"></script><%}%>
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="/Theme/system/wap/js/main.js" type="text/javascript"></script>
<script src="/Theme/system/wap/js/messagebox.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/css/system.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/js/jquery-ui/jquery-ui.min.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/js/jquery-ui/jquery-ui.theme.min.css" />
<link rel="stylesheet" type="text/css" href="/theme/wap/css/css.css" />
<link rel="stylesheet" type="text/css" href="/theme/wap/css/<%=CurrentLanguage.Code %>.css" />

</head>
<body class="default">
    
<div class="mhead clearfix">
	<a href="javascript:history.go(-1);" class="a-back"><span>返回</span></a>
	<h2 id="pagename"><%=ThemePageMeta("P_UserOrderDetails","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>
<script>
    var pagetitle = $("#pagename").html();
    if (pagetitle.indexOf(" - ") > -1) {
        $("#pagename").html(pagetitle.split(' - ')[0]);
    }
</script>

    <div class="body">
        <div class="bodymain">
          
    

<div id="orderstate">
    <div class="mt">
        <div class="left">
            <strong><span class="ftx14"><%=Shop.Bussiness.Order.OrderStatus(order, CurrentLanguage.Code) %></span></strong>
        </div>
        <div class="right">
            <div class="toolbar">
                <%if(Shop.Bussiness.Order.CancelOrder(order)){ %><a href="<%=URL("P_UserOrderCancel",order.id) %>" class="btn btn-11"><s></s>取消</a><%} %>
                <%if(order.OnlinePay_id>0 && order.IsPaid!=1 && pay.Code=="OnlinePay" && order.IsInvalid==0){ %><a href="javascript:void(0)" onclick="window.open('<%=URL("P_Pay",order.id)%>');" class="btn btn-7"><s></s>立即付款</a><%} %>
            </div>
        </div>
    </div>
    <%if(order.IsCompleted==0){ %>
        <div class="mm">
    <%}else{ %>
        <div class="mc">
    <%} %>
    <%foreach (Shop.Model.Lebi_Comment m in comments){%>
    <div>
        <span style="color: #dddddd"><%=FormatTime(m.Time_Add) %></span> <%=m.User_UserName%><%=m.Admin_UserName%>：<%=m.Content%>
    </div>
    <%} %>
    </div>
    <%if(order.IsCompleted==0){ %>
    <div class="mc">
        <input type="text" id="comment" style="width:90%" class="input" />
        <a href="javascript:void(0)" onclick="submitcomment(<%=order.id %>);" class="btn btn-11"><s></s>留言</a>
    </div>
    <%} %>
</div>
<%foreach (Shop.Model.Lebi_Transport_Order t in transport_orders){%>
<%if (t != null){ %>
<div id="ordertrack" class="clearfix">
    <div class="mt"><strong>订单追踪</strong></div>
    <div class="mc tabcon">
        <table width="100%" cellspacing="0" cellpadding="0">
            <tbody id="tbody_track">
                <tr>
                    <th style="text-align: left; height: 30px;">
                        <%=t.Transport_Name %> 运单号：<%=t.Code %> 状态：<%=TypeName(t.Type_id_TransportOrderStatus) %>
                        <%if(t.Type_id_TransportOrderStatus!=223 && t.Type_id_TransportOrderStatus!=224){ %>
                        <a href="javascript:void(0)" onclick="Received(<%=order.id%>,<%=t.id %>);" class="btn btn-11"><s></s>确认收货</a>
                        <%} %>
                    </th>
                </tr>
                <%
                    Shop.Model.KuaiDi100 log = Shop.Bussiness.EX_Area.GetKuaiDi100(t);
                    if (log.message == "ok")
                    {
                        foreach (Shop.Model.KuaiDi100.KuaiDi100data d in log.data)
                        { %>
                <tr>
                    <td><%=d.context%> <em><%=d.time%></em></td>
                </tr>
                <%}
                    }
                    else
                    { %>
                    <tr>
                    <td style="text-align:center">
                    <%if(t.HtmlLog.IndexOf("http://")==0){ %>
                    <iframe name="kuaidi100" src="<%=t.HtmlLog %>" width="300" height="200" marginwidth="0" marginheight="0" frameborder="0"></iframe>
                    <%} %>
                    </td></tr>
                    <%} %>
            </tbody>
        </table>
    </div>
</div>
<%} %>
<%} %>
<div id="orderinfo" class="clearfix">
    <div class="mt"><strong>订单信息</strong></div>
    <div class="mc">
        <dl class="fore clearfix">
            <dd>
                <ul>
                    <li>订购时间：<%=FormatTime(order.Time_Add) %></li>
                </ul>
            </dd>
        </dl>
        <dl>
            <dt>收货人信息</dt>
            <dd>
                <ul>
                    <li>收货人：<%=order.T_Name %></li>
                    <li>地址：<%=Shop.Bussiness.EX_Area.GetAreaName(order.T_Area_id)%> <%=order.T_Address %></li>
                    <li>固定电话：<%=order.T_Phone %></li>
                    <li>手机号码：<%=order.T_MobilePhone %></li>
                    <li>电子邮件：<%=order.T_Email %></li>
                </ul>
            </dd>
        </dl>
        <dl>
            <dt>支付及配送方式</dt>
            <dd>
                <ul>
                    <li>支付方式：<%=Lang(order.Pay) %></li>
                    <li class="tips"><%=Lang(pay.Description)%></li>
                    <li>配送方式：<%=order.Transport_Name %></li>
                </ul>
            </dd>
        </dl>
        <%if (SYS.BillFlag == "1"){ %>
        <dl>
            <dt>发票信息</dt>
            <dd>
                <ul>
                    <li>发票类型：<%=Lang(order.BillType_Name) %></li>
                    <%foreach (Shop.Model.Lebi_Bill b in bills){%>
                    <%if(b.Type_id_BillType==151){ %>
                    <li>发票内容：<%=b.Content%></li>
                    <li>发票抬头：<%=b.Title%></li>
                    <%}else{ %>
                    <li>单位名称：<%=b.Company_Name%></li>
                    <li>纳税人识别号：<%=b.Company_Code%></li>
                    <li>注册地址：<%=b.Company_Address%></li>
                    <li>注册电话：<%=b.Company_Phone%></li>
                    <li>开户银行：<%=b.Company_Bank%></li>
                    <li>银行帐户：<%=b.Company_Bank_User%></li>
                    <%} %>
                    <%} %>
                </ul>
            </dd>
        </dl>
       <%} %>
        <dl>
            <dt>订单清单</dt>
            <dd class="p-list">
                <table width="100%" cellspacing="0" cellpadding="0">
                    <tbody>
                        <%foreach (Shop.Model.Lebi_Order_Product o_p in order_products){%>
                        <tr>
                            <td style="width:50px" valign="top" rowspan="2"><a href="<%=URL("P_Product",o_p.Product_id) %>"><img src="<%=Image(o_p.ImageOriginal,50,50) %>" style="width:50px;height:50px;" /></a></td>
                            <td style="text-align:left" valign="top">
                            <%if(o_p.Type_id_OrderProductType==252){Response.Write("["+Tag("赠品")+"]");} %><a href="<%=URL("P_Product",o_p.Product_id) %>"><%=Lang(o_p.Product_Name) %></a><br />
                            <%if (o_p.ProPerty134!=""){ %><%=o_p.ProPerty134%><%} %>
                            <%=Shop.Bussiness.EX_Product.ProPertyNameStr(Shop.Bussiness.EX_Product.GetProduct(o_p.Product_id), CurrentLanguage.Code)%></td>
                            <td style="width:60px" valign="top">
                            <%
                                if(o_p.Type_id_OrderProductType==255)
                                    Response.Write(Tag("积分")+":"+o_p.Point_Buy_one);
                                else if(o_p.Type_id_OrderProductType==252)
                                    Response.Write(FormatMoney(0));
                                else
                                    Response.Write(FormatMoney(o_p.Price));
                            %>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left">×<%=o_p.Count%> <%if ((order.IsShipped == 1||order.IsShipped_All == 1) && o_p.Count_Shipped<o_p.Count){ %><em>(发货数量：<%=o_p.Count_Shipped%>)</em><%} %></td>
                            <td>
                                <%if(order.IsReceived==1 && SYS.IsClosetuihuo=="0"){ %>
                                <a href="<%=URL("P_UserReturnApply",o_p.Order_id)%>">退货</a><br />
                                <%} %>
                                <a href="javascript:void(0);" onclick="AddOftenBuy(<%=o_p.Product_id %>,<%=o_p.Count %>,'<%=o_p.ProPerty134 %>')">常购清单</a>
                            </td>
                        </tr>
                        <%} %>
                    </tbody>
                </table>
            </dd>
        </dl>
    </div>
    <div class="total">
        <ul>
            <li><strong>商品总额：</strong><%=FormatMoney(order.Money_Product) %></li>
            <%if(order.Money_Transport!=0){ %><li><strong>+ 运费：</strong><%=FormatMoney(order.Money_Transport) %></li><%} %>
            <%if(order.Money_Bill>0){ %><li><strong>+ 发票税金：</strong><%=FormatMoney(order.Money_Bill) %></li><%} %>
            <%if(order.Money_Tax>0){ %><li><strong>+ 税金：</strong><%=FormatMoney(order.Money_Tax) %></li><%} %>
            <%if(order.Money_Property>0){ %><li><strong>+ 其它费用：</strong><%=FormatMoney(order.Money_Property) %></li><%} %>
            <%if(order.Money_UseCard311>0 || order.Money_UseCard312>0){ %>
                <li><strong>- 卡券支付：</strong><%=FormatMoney(order.Money_UseCard312+order.Money_UseCard311) %></li>
            <%} %>
            <%if(order.Money_Cut>0){ %><li><strong>- 优惠：</strong><%=FormatMoney(order.Money_Cut) %></li><%} %>
            <%if (order.Money_UserCut > 0){ %><li><strong>- 使用余额：</strong><%=FormatMoney(order.Money_UserCut)%></li><%} %>
        </ul>
        <span class="clear"></span>
        <div class="extra">
            应付金额：<span class="red"><b><%=FormatMoney(order.Money_Pay)%></b></span></div>
    </div>
</div>
<script type="text/javascript">
    function Received(id,tid) {
        if (!confirm("请确认操作？"))
            return false;
        var url = path+"/ajax/ajax_order.aspx?__Action=Received&id=" + id+"&tid="+tid;
        RequestAjax(url, "", function () { MsgBox(1, "操作成功", "?") });
    }
    function submitcomment(order_id) {
        var comment = $("#comment").val();
        if (comment == "") {
            MsgBox(2, "请填写留言内容", "");
            return false;
        }
        var postData = { "comment": comment, "order_id": order_id };
        var url = path+"/ajax/ajax_order.aspx?__Action=OrderComment_Edit";
        RequestAjax(url, postData, function () { MsgBox(1, "操作成功", "?") });
    }
</script>


        </div>
    </div>
  
<%
if(!IsAPP()){
%>
<div id="footnav">
<ul>
<li><a href="<%=URL("P_Index", "")%>"><img src="/Theme/system/wap/images/home.png" alt="首页" /><span>首页</span></a></li>
<li><a href="<%=URL("P_AllProductCategories", "")%>"><img src="/Theme/system/wap/images/category.png" alt="商品分类" /><span>商品分类</span></a></li>
<li><a href="<%=URL("P_Basket", "")%>"><img src="/Theme/system/wap/images/cart.png" alt="购物车" /><span>购物车</span></a></li>
<li><a href="<%=URL("P_UserCenter", "")%>"><img src="/Theme/system/wap/images/user.png" alt="会员中心" /><span>会员中心</span></a></li>
</ul>
</div>
<%}%>

  
</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>