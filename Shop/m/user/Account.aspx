<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserAccount" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserAccount"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserAccount","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserAccount","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserAccount","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_UserAccount","title")%></h2>
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
          
    

<div class="nbbox clearfix">
<div class="userbox">
    <div class="mt clearfix">
        <h2>帐号绑定</h2>
    </div>
    <div class="mc platform clearfix">
    <div class="dl-table clearfix">
    <%if(SYS.platform_login.Contains("qq")){ %>
    <dl>
        <dt><img src="<%=Shop.Platform.QQ.Instance.ImageURL %>" /></dt>
        <dd><%if(CurrentUser.bind_qq_id=="") {%>
            <a href="<%=Shop.Platform.QQ.Instance.LoginURL(backurl) %>" >绑定</a>
            <%}else{ %>
            <a href="javascript:void(0);" onclick="cancalbind('qq');" >取消绑定</a>
            <%} %></dd>
    </dl>
    <%} %>
    <%if(SYS.platform_login.Contains("weibo")){ %>
    <dl>
        <dt><img src="<%=Shop.Platform.Weibo.Instance.ImageURL %>" /></dt>
        <dd><%if(CurrentUser.bind_weibo_id=="") {%>
            <a href="<%=Shop.Platform.Weibo.Instance.LoginURL(backurl) %>" >绑定</a>
            <%}else{ %>
            <a href="javascript:void(0);" onclick="cancalbind('weibo');" >取消绑定</a>
            <%} %></dd>
    </dl>
    <%} %>
    <%if(SYS.platform_login.Contains("taobao")){ %>
    <dl>
        <dt><img src="<%=Shop.Platform.Taobao.Instance.ImageURL %>" /></dt>
        <dd><%if(CurrentUser.bind_taobao_id=="") {%>
            <a href="<%=Shop.Platform.Taobao.Instance.LoginURL(backurl) %>" >绑定</a>
            <%}else{ %>
            <a href="javascript:void(0);" onclick="cancalbind('taobao');" >取消绑定</a>
            <%} %></dd>
    </dl>
    <%} %>
    <%if(SYS.platform_login.Contains("facebook")){ %>
    <dl>
        <dt><img src="<%=Shop.Platform.Facebook.Instance.ImageURL %>" /></dt>
        <dd><%if(CurrentUser.bind_facebook_id=="") {%>
            <a href="<%=Shop.Platform.Facebook.Instance.LoginURL(backurl) %>" >绑定</a>
            <%}else{ %>
            <a href="javascript:void(0);" onclick="cancalbind('facebook');" >取消绑定</a>
            <%} %></dd>
    </dl>
    <%} %>
    <%if(SYS.platform_login.Contains("weixin")){ %>
    <dl>
        <dt><img src="<%=Shop.Platform.weixin.Instance.ImageURL %>" /></dt>
        <dd><%if(CurrentUser.bind_weixin_id=="") {%>
            使用微信“扫一扫”功能扫描此二维码绑定
            <br/>
            <img src="<%=WebPath %>/ajax/ajax_user.aspx?__Action=GetQrCode&url=<%=backurl %>" style="width:200px;height:200px"/>
            <%}else{ %>
            <a href="javascript:void(0);" onclick="cancalbind('weixin');" >取消绑定</a>
            <%} %></dd>
    </dl>
    <%} %>
    </div>
    </div>
</div>
</div>
<div class="nbbox clearfix">
<div class="userbox">
    <div class="mt clearfix">
        <h2>账号合并</h2>
    </div>
    <div class="mc clearfix">
    <div class="dl-table clearfix">
    <dl>
        <dt>用户名：</dt>
        <dd><input name="UserName" id="UserName" size="30" type="text" shop="true" min="notnull" class="input" /></dd>
    </dl>
    <dl>
        <dt>密码：</dt>
        <dd><input name="Password" id="Password" size="30" type="password" shop="true" min="notnull" class="input" /></dd>
    </dl>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0)" onclick="userloginsubmit();" class="btn btn-11"><s></s>提交</a></dd>
    </dl>
    </div>
    </div>
</div>
</div>
<script type="text/javascript">
    function cancalbind(t) {
        if (!confirm("确认操作吗？"))
            return false;
        var postData = {"t": t};
        var url = path+"/ajax/Ajax_userin.aspx?__Action=Cancalbind";
        RequestAjax(url, postData, function () { MsgBox(1, "操作成功", "?") });
    }
    function userloginsubmit() {
        var postData = GetFormJsonData("shop");
        var url = path + "/ajax/ajax_userin.aspx?__Action=User_Bind";
        RequestAjax(url, postData, function (res) { MsgBox(1, "操作成功", "?") });
    }
    <%if(SYS.platform_login.Contains("weixin") && CurrentUser.bind_weixin_id==""){ %>
    var wflag=0;
    function wechatbind()
    {
        if(wflag==0){
            wflag=1;
            $.ajax({
                type: "POST",
                url: path+"/ajax/ajax_user.aspx?__Action=wechatbind",
                data: '',
                dataType: 'json',
                success: function (res) {
                    if(res.msg=='OK')
                       MsgBox(1, "操作成功", "?");
                    else
                        wflag=0;
                }
            });
        }
    }
    setInterval("wechatbind()",3000);
    <%} %>
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