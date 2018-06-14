<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserChangePassword" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_UserChangePassword"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserChangePassword","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserChangePassword","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserChangePassword","description")%>" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="format-detection" content="telephone=no" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="apple-mobile-web-app-status-bar-style" content="black" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="twcClient" content="false" id="twcClient" />
<meta name="revisit-after" content="1 days" />
<meta name="CurrenctCurrency" content="<%=CurrentCurrency.Code %>" />
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<script type="text/javascript">var path = "<%=WebPath %>";var sitepath = "/";var langpath = "/";</script>
<script src="http://192.168.1.188/Theme/system/wap/js/jquery.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/Theme/system/wap/css/system.css" />
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/main.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/messagebox.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/my97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/jquery-ui.min.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/Theme/system/wap/js/jqueryuicss/redmond/jquery-ui.css" />
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/theme/wap/css/css.css" />
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/theme/wap/css/<%=CurrentLanguage.Code %>.css" />

</head>
<body class="default">
    
<div id="header" class="clearfix">
    <div class="logo">

<a href="/"><img src="<%=Image(Lang(SYS.Logoimg)) %>" alt="<%=Lang(SYS.Name)%>" title="<%=Lang(SYS.Name)%>" /></a>
</div>
    <ul class="toplink">
		<li><a href="#search" class="btnSearch"></a></li>
        
        <li><a href="<%=URL("P_Basket", "")%>" class="btnCart"><em id="cart_items"><%=Basket_Product_Count() %></em></a></li>
    </ul>
</div>
<div class="mhead clearfix">
	<a href="javascript:history.go(-1);" class="a-back"><span>返回</span></a>
	<h2><%=ThemePageMeta("P_UserChangePassword","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

    <div class="body">
        <div class="bodymain">
            
    

<div class="nbbox clearfix">
<div class="userbox">
    <div class="mt clearfix">
        <h2>登录密码</h2>
    </div>
    <div class="mc clearfix">
    <div class="dl-table clearfix">
    <dl>
        <dt>原始密码：</dt>
        <dd><input name="Password" id="Password" size="30" type="password" pass="true" min="notnull" class="input" /></dd>
    </dl>
    <dl>
        <dt>新密码：</dt>
        <dd><input name="Password1" id="Password1" size="30" type="password" pass="true" min="notnull" class="input" /></dd>
    </dl>
    <dl>
        <dt>确认密码：</dt>
        <dd><input name="Password2" id="Password2" size="30" type="password" pass="true" min="notnull" class="input" /></dd>
    </dl>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0)" onclick="setpassword();" class="btn btn-11"><s></s>提交</a></dd>
    </dl>
    </div>
    </div>
</div>
</div>
<div class="nbbox clearfix">
<div class="userbox">
    <div class="mt clearfix">
        <h2>支付密码</h2>
    </div>
    <div class="mc clearfix">
    <div class="dl-table clearfix">
    <%if (CurrentUser.Pay_Password != ""){ %>
    <dl>
        <dt>原始密码：</dt>
        <dd><input name="Pay_Password" id="Pay_Password" size="30" type="password" paypass="true" min="notnull" class="input" /> <a href="<%=URL("P_UserQuestion","1")%>">忘记密码</a></dd>
    </dl>
    <%} %>
    <dl>
        <dt>新密码：</dt>
        <dd><input name="Pay_Password1" id="Pay_Password1" size="30" type="password" paypass="true" min="notnull" class="input" /></dd>
    </dl>
    <dl>
        <dt>确认密码：</dt>
        <dd><input name="Pay_Password2" id="Pay_Password2" size="30" type="password" paypass="true" min="notnull" class="input" /></dd>
    </dl>
    <%
    Lebi_User_Answer user_answer = B_Lebi_User_Answer.GetModel("User_id ="+ CurrentUser.id);
    if (user_answer==null){
    %>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="<%=URL("P_UserQuestion","")%>" class="click">请先设置安全问题</a></dd>
    </dl>
    <%}else{ %>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0)" onclick="setpaypassword();" class="btn btn-11"><s></s>提交</a></dd>
    </dl>
    <%} %>
    </div>
    </div>
</div>
</div>
<script type="text/javascript">
    function setpassword() {
        var Password = $("#Password").val();
        var Password1 = $("#Password1").val();
        var Password2 = $("#Password2").val();
        if (Password == "") {
            CheckNO("Password", "请输入原始密码");
            return false;
        }
        if (Password1 == "") {
            CheckNO("Password1", "请输入新密码");
            return false;
        }
        if (!CheckForm("pass", "span"))
            return false;
        if (Password1 != Password2) {
            CheckNO("Password1", "两次输入的密码不一致");
            return false;
        }
        var postData = { "Password": Password, "Password1": Password1, "Password2": Password2 };
        var url = path+"/ajax/Ajax_userin.aspx?__Action=SetPassword";
        RequestAjax(url, postData, function () { MsgBox(1, "操作成功", "?") });
    }
    function setpaypassword() {
        var Pay_Password = $("#Pay_Password").val();
        var Pay_Password1 = $("#Pay_Password1").val();
        var Pay_Password2 = $("#Pay_Password2").val();
        <%if(CurrentUser.Pay_Password!=""){ %>
        if (Pay_Password == "") {
            CheckNO("Pay_Password", "请输入原始密码");
            return false;
        }
        <%} %>
        if (Pay_Password1 == "") {
            CheckNO("Password1", "请输入新密码");
            return false;
        }
        if (!CheckForm("paypass", "span"))
            return false;
        if (Pay_Password1 != Pay_Password2) {
            CheckNO("Pay_Password1", "两次输入的密码不一致");
            return false;
        }
        var postData = { "Pay_Password": Pay_Password, "Pay_Password1": Pay_Password1, "Pay_Password2": Pay_Password2 };
        var url = path+"/ajax/Ajax_userin.aspx?__Action=SetPayPassword";
        RequestAjax(url, postData, function () { MsgBox(1, "操作成功", "?") });
    }
</script>


        </div>
      

<div class="mbox clearfix">
    <div class="mt">
        <h2>控制面板</h2>
    </div>
    <div class="mc usermenu clearfix">
        <ul>
            <li><a href="<%=URL("P_UserOrders","")%>"><span>我的订单</span></a></li>
            <%if(SYS.IsClosetuihuo=="0"){ %>
            <li><a href="<%=URL("P_UserReturn","")%>"><span>退货订单</span></a></li>
            <%} %>
            <li><a href="<%=URL("P_UserCard","")%>"><span>我的卡券</span></a></li>
            <li><a href="<%=URL("P_UserPoint","")%>"><span>积分记录</span></a></li>
            <li><a href="<%=URL("P_UserMoney","")%>"><span>资金记录</span></a></li>
            <li><a href="<%=URL("P_UserProfile","")%>"><span>资料管理</span></a></li>
            <li><a href="<%=URL("P_UserAccount","")%>"><span>绑定帐号</span></a></li>
            <li><a href="<%=URL("P_UserChangePassword","")%>"><span>修改密码</span></a></li>
            <li><a href="<%=URL("P_UserQuestion","")%>"><span>安全问题</span></a></li>
            <li><a href="<%=URL("P_UserAddress","")%>"><span>收货地址</span></a></li>
            <li><a href="<%=URL("P_UserBank","")%>"><span>收款账号</span></a></li>
            <li><a href="javascript:LoginOut();"><span>登录注销</span></a></li>
        </ul>
    </div>
</div>
<div class="mbox clearfix">
    <div class="mt">
        <h2>商品关注</h2>
    </div>
    <div class="mc usermenu clearfix">
        <ul>
            <li><a href="<%=URL("P_UserLike","")%>"><span>我的收藏</span></a></li>
            <li><a href="<%=URL("P_UserOftenBuy","")%>"><span>常购清单</span></a></li>
            <li><a href="<%=URL("P_UserComment","")%>"><span>商品评价<em>(<%=Count_Comment(0) %>)</em></span></a></li>
            <li><a href="<%=URL("P_UserAsk","")%>"><span>商品咨询<em>(<%=Count_ProductAsk(0) %>)</em></span></a></li>
        </ul>
    </div>
</div>
<div class="mbox clearfix">
    <div class="mt">
        <h2>站内信</h2>
    </div>
    <div class="mc usermenu clearfix">
        <ul>
            <li><a href="<%=URL("P_UserMessage","0")%>"><span>收件箱<em>(<%=Count_Message(0) %>)</em></span></a></li>
            <li><a href="<%=URL("P_UserMessage","1")%>"><span>发件箱</span></a></li>
            <li><a href="<%=URL("P_UserMessageWrite","")%>"><span>发信息</span></a></li>
        </ul>
    </div>
</div>
<%if (Shop.Bussiness.B_API.Check("plugin_agent")){ %>
<div class="mbox clearfix">
    <div class="mt">
        <h2>推广佣金</h2>
    </div>
    <div class="mc usermenu clearfix">
        <ul>
            <li><a href="<%=URL("P_UserAgent","")%>"><span>基本信息<em></em></span></a></li>
            <li><a href="<%=URL("P_UserAgentMoney","")%>"><span>佣金查询</span></a></li>
        </ul>
    </div>
</div>
<%} %>

    </div>
  
<div id="footer" class="clearfix">
    <div class="copyright">
        <%=Lang(SYS.Copyright) %>
    </div>
    <div class="lang">
        

<div class="language">
<%List<Shop.Model.Lebi_Language> TbFSs=Languages();RecordCount=TbFSs.Count;int TbFS_index=1;
foreach (Shop.Model.Lebi_Language TbFS in TbFSs){%>
<a <%if (TbFS_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=TbFS.id%>,'<%=TbFS.Code%>','<%=TbFS.Path%>');"><img src="<%=Image(TbFS.ImageUrl) %>" title="<%=TbFS.Name%>" /><%=TbFS.Name%></a>
<%TbFS_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int kqBm_index=1;
List<Lebi_Currency> kqBms = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency kqBm in kqBms){%>
<dd <%if (kqBm_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=kqBm.id%>,'<%=kqBm.Code%>',<%=kqBm.ExchangeRate%>,'<%=kqBm.Msige%>');"><%=kqBm.Code%></a></dd>
<%kqBm_index++;}%>
</dl></li></ul></div>

    </div>
    
<div id="footnav">
<ul>
<li><a href="<%=URL("P_Index", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/home.png" alt="首页" /><span>首页</span></a></li>
<li><a href="<%=URL("P_ProductCommentIndex", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/message.png" alt="晒单" /><span>晒单</span></a></li>
<li><a href="<%=URL("P_Basket", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/cart.png" alt="购物车" /><span>购物车</span></a></li>
<li><a href="<%=URL("P_UserCenter", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/user.png" alt="会员中心" /><span>会员中心</span></a></li>
</ul>
</div>

</div>


  
</body>
</html>