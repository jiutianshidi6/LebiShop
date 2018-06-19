<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserReturnDetails" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserReturnDetails"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserReturnDetails","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserReturnDetails","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserReturnDetails","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_UserReturnDetails","title")%></h2>
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
            <strong><span class="ftx14"><%=ReturnStatus(order)%></span></strong>
        </div>
        <div class="right">
            <div class="toolbar">
            </div>
        </div>
    </div>
    <%if(order.IsCompleted==0){ %>
    <div class="mm">
        <%}else{ %>
        <div class="mc">
            <%} %>
            <%foreach (Shop.Model.Lebi_Comment c in comments){%>
            <div>
                <span style="color: #dddddd"><%=c.Time_Add %></span> <%=c.User_UserName%><%=c.Admin_UserName%> : <%=c.Content%>
            </div>
            <%} %>
        </div>
        <%if(order.IsCompleted==0){ %>
        <div class="mc">
            <input type="text" id="comment" style="width:400px" class="input" />
            <a href="javascript:void(0)" onclick="submitcomment(<%=order.id %>);" class="btn btn-11"><s></s>留言</a>
        </div>
        <%} %>
    </div>
    <div id="orderinfo" class="clearfix">
        <div class="mt"><strong>订单信息</strong></div>
        <div class="mc">
            <dl class="fore clearfix">
                <dt>货运信息</dt>
                <%foreach (Shop.Model.Lebi_Transport_Order t_o in transport_orders){%>
                <dd>
                    <ul>
                        <li>快递公司：<%=t_o.Transport_Name %></li>
                        <li>运单号：<%=t_o.Code %></li>
                        <li>状态：<%=TypeName(t_o.Type_id_TransportOrderStatus) %></li>
                    </ul>
                </dd>
                <%foreach (Shop.Model.KuaiDi100.KuaiDi100data d in Shop.Bussiness.EX_Area.GetKuaiDi100(t_o).data){ %>
                <dd>
                    <ul>
                    <li><%=d.time %></li>
                    <li><%=d.context %></li>
                    </ul>
                </dd>
                <%} %>
                <%} %>
            </dl>
            <dl class="fore clearfix">
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
                        <li>配送方式：<%=order.Transport_Name %></li>
                    </ul>
                </dd>
            </dl>
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
                            <td style="width:60px" valign="top"><%=FormatMoney(o_p.Price) %></td>
                        </tr>
                        <tr>
                            <td coslpan="2" style="text-align:left">×<%=o_p.Count%></td>
                        </tr>
                        <%} %>
                        </tbody>
                    </table>
                </dd>
            </dl>
        </div>
        <div class="total">
            <ul>
                <li><span>商品总额：</span><%=FormatMoney(order.Money_Product) %></li>
                <li><span>+ 运费：</span><%=FormatMoney(order.Money_Transport) %></li>
                <li><span>+ 税金：</span><%=FormatMoney(order.Money_Bill) %></li>
            </ul>
            <span class="clear"></span>
            <div class="extra">
                退款金额：<span class="red"><b><%=FormatMoney(order.Money_Give) %></b></span></div>
        </div>
    </div>
</div>
<script type="text/javascript">
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