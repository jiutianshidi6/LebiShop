<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserCenter" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserCenter"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserCenter","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserCenter","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserCenter","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_UserCenter","title")%></h2>
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
          
    

<%
Shop.Bussiness.Agent.Model AgentInfo = Shop.Bussiness.Agent.Info(CurrentUser);
int OrderUnPaid = Shop.Bussiness.Order.GetCount_Order("","","User_id = "+ CurrentUser.id +" and Type_id_OrderType = 211 and IsPaid = 0 and IsInvalid=0");
int OrderUnReceived = Shop.Bussiness.Order.GetCount_Order("","","User_id = "+ CurrentUser.id +" and Type_id_OrderType = 211 and IsShipped = 1 and IsReceived = 0");
int OrderReceived = Shop.Bussiness.Order.GetCount_Order("","","User_id = "+ CurrentUser.id +" and Type_id_OrderType = 211 and IsReceived = 1");
%>
<div class="usercenter clearfix">
<div class="info">
<div class="hattar"><a href="<%=URL("P_UserMessage","0")%>"><span class="hat"></span></a></div>
<h2><%=CurrentUser.NickName %></h2>
<ul>
<li>余额：<%=FormatMoney(CurrentUser.Money) %></li>
<li>积分：<%=CurrentUser.Point %></li>
<li><%=Lang(CurrentUserLevel.Name) %></li>
</ul>
</div>
<div class="ordermenu">
<a href="<%=URL("P_UserOrders","")%>?status=1"><span class="d_1">等待付款<%if(OrderUnPaid>0){%><em>(<%=OrderUnPaid %>)</em><%} %></span></a>
<a href="<%=URL("P_UserOrders","")%>?status=2"><span class="d_2">等待收货<%if(OrderUnReceived>0){%><em>(<%=OrderUnReceived %>)</em><%} %></span></a>
<a href="<%=URL("P_UserOrders","")%>?status=3"><span class="d_3">已收货<%if(OrderReceived>0){%><em>(<%=OrderReceived %>)</em><%} %></span></a>
<a href="<%=URL("P_UserComment","1","")%>"><span class="d_4">待评价<%if(Count_Comment(0)>0){%><em>(<%=Count_Comment(0) %>)</em><%} %></span></a>
</div>
<div class="agent">
<ul>
<li><a href="<%=URL("P_UserAgent","")%>"><em><%=CurrentUser.id %></em><p><%=Tag("邀请码")%></p></a></li>
<li><a href="<%=URL("P_UserAgentList",""+System.DateTime.Now.Date.ToShortDateString()+","+System.DateTime.Now.Date.ToShortDateString()+"")%>"><em><%=AgentInfo.UserCountday%></em><p><%=Tag("日推广人数")%></p></a></li>
<li><a href="<%=URL("P_UserAgentList",""+System.DateTime.Now.Date.AddDays(0 - System.DateTime.Now.Day + 1).ToString("yyyy-MM-dd")+","+System.DateTime.Now.Date.ToShortDateString()+"")%>"><em><%=AgentInfo.UserCountmonth%></em><p><%=Tag("月推广人数")%></p></a></li>
<li><a href="<%=URL("P_UserAgentList","")%>"><em><%=AgentInfo.UserCount%></em><p><%=Tag("总推广人数")%></p></a></li>
</ul>
</div>
<div class="othermenu">
<a href="<%=URL("P_UserOrders","")%>"> <span class="d_1">我的订单</span></a>
<%if(SYS.IsClosetuihuo=="0"){ %>
<a href="<%=URL("P_UserReturn","")%>"> <span class="d_2">退货订单</span></a>
<%}%>
<a href="<%=URL("P_UserOftenBuy","")%>"> <span class="d_3">常购清单</span></a>
<a href="<%=URL("P_UserLike","")%>"> <span class="d_4">我的收藏</span></a>
<a href="<%=URL("P_UserBank","")%>"> <span class="d_5">收款账号</span></a>
<a href="<%=URL("P_UserMoney","")%>"> <span class="d_6">资金记录</span></a>
<a href="<%=URL("P_UserPoint","")%>"> <span class="d_7">积分记录</span></a>
<a href="<%=URL("P_UserAgentMoney","")%>"> <span class="d_8">佣金查询</span></a>
<a href="<%=URL("P_UserCard","")%>"> <span class="d_9">我的卡券</span></a>
<a href="<%=URL("P_UserAsk","")%>"> <span class="d_10">商品咨询</span></a>
<a href="<%=URL("P_UserAccount","")%>"> <span class="d_11">绑定帐号</span></a>
<a href="<%=URL("P_UserQuestion","")%>"> <span class="d_12">安全问题</span></a>
<a href="<%=URL("P_UserAddress","")%>"> <span class="d_15">收货地址</span></a>
<a href="<%=URL("P_UserProfile","")%>"> <span class="d_14">资料管理</span></a>
<a href="<%=URL("P_UserChangePassword","")%>"> <span class="d_13">修改密码</span></a>
</div>
<a href="javascript:LoginOut();"><div class="loginout">登录注销</div></a>
</div>


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