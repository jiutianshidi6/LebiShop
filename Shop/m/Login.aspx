<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Login" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_Login"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_Login","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_Login","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Login","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_Login","title")%></h2>
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
    <div class="user">
        <div class="login clearfix">
            <div class="userloginbox">
                <div class="mt clearfix">
                    <h2>会员登录</h2>
                </div>
                <div class="mc clearfix">
                    <div class="dl-table clearfix">
                    <dl>
                        <dt>用户名：</dt>
                        <dd><input name="UserName" id="UserName" shop="true" type="text" size="20" class="input" /></dd>
                    </dl>
                    <dl>
                        <dt>密码：</dt>
                        <dd><input type="password" name="Password" shop="true" id="Password" size="20" class="input" /></dd>
                    </dl>
                    <%if (SYS.Verifycode_UserLogin == "1"){ %>
                    <dl id="code" <%if (LoginError != true){ %>style="display:none"<%}else{ %>style="display:" <%} %>>
                        <dt>验证码：</dt>
                        <dd><input name="verifycode" type="text" id="verifycode" shop="true" size="6" class="input" /><img class="verifycode" id="img1" src="<%=WebPath%>/code.aspx" /><img src="/Theme/system/wap/images/reload.gif" class="refresh" title="点击刷新验证码" onclick="refresh('img1')" /></dd>
                    </dl>
                    <%} %>
                    <dl>
                        <dt></dt>
                        <dd><a href="javascript:void(0)" onclick="submitlogin();" class="btn btn-7"><s></s>登录</a>&nbsp;&nbsp;<a href="<%=URL("P_ForgetPassword","")%>">忘记密码</a></dd>
                    </dl>
                    </div>
                    <div class="msg-error" id="msg-error"><b></b></div>
                    <div class="platform">
                    <%
                        string platform_login = SYS.platform_login;
                        if (DT_id > 0){
                            platform_login = ShopCache.GetBaseConfig_DT(DT_id).platform_login;
                        }
                    %>
                        <%if(platform_login.Contains("qq")){ %>
                        <a href="<%=Shop.Platform.QQ.GetInstance(DT_id).LoginURL(backurl) %>">
                            <img src="<%=Image(Shop.Platform.QQ.GetInstance(DT_id).ImageURL) %>" /></a>
                        <%} %>
                        <%if(platform_login.Contains("weibo")){ %>
                        <a href="<%=Shop.Platform.Weibo.GetInstance(DT_id).LoginURL(backurl) %>">
                            <img src="<%=Image(Shop.Platform.Weibo.GetInstance(DT_id).ImageURL) %>" /></a>
                        <%} %>
                        <%if(platform_login.Contains("taobao")){ %>
                        <a href="<%=Shop.Platform.Taobao.GetInstance(DT_id).LoginURL(backurl) %>">
                            <img src="<%=Image(Shop.Platform.Taobao.GetInstance(DT_id).ImageURL) %>" /></a>
                        <%} %>
                        <%if(platform_login.Contains("facebook")){ %>
                        <a href="<%=Shop.Platform.Facebook.GetInstance(DT_id).LoginURL(backurl) %>">
                            <img src="<%=Image(Shop.Platform.Facebook.GetInstance(DT_id).ImageURL) %>" /></a>
                        <%} %>
                    </div>
                </div>
                <div class="mes">
                    <h2><span>还不是商城会员？</span></h2>
                    <div class="cont">
                        一分钟轻松注册，就可以方便购物！<a href="<%=URL("P_Register", ""+HttpUtility.UrlEncode(backurl)+"," + GetUrlToken(backurl)+ "") %>">免费注册</a></div>
                    <%
                    if (IsWechat()){
                    %>
                    <div class="cont"><a href="<%=WebPath%>/platform/redirect_weixin.aspx?backurl=<%=backurl%>">微信一键登录</a></div>
                    <%
                    }
                    %>
                </div>
            </div>
            <div id="advert">
            <% Advertisement("Login"); %>
            </div>
        </div>
    </div>
</div>
<input type="hidden" name="Device_system" shop="true" id="Device_system" maxlength="50" />
<input type="hidden" name="Device_id" shop="true" id="Device_id" maxlength="50"/>
<script type="text/javascript">
    $(document).keyup(function (event) {
        if (event.keyCode == 13) {
            submitlogin();
        }
    });
    function submitlogin() {
        $("#msg-error").hide();
        var Password = $("#Password").val();
        var UserName = $("#UserName").val();
        var verifycode = $("#verifycode").val();
        if (UserName == "") {
            MsgError("请输入用户名");
            return false;
        }
        if (Password == "") {
            MsgError("请输入密码");
            return false;
        }
        <%if (SYS.Verifycode_UserLogin == "1"){ %>
        <%if (LoginError){ %>
        if (verifycode == "") {
            MsgError("请输入验证码");
            return false;
        }
        <%}%>
        <%}%>
        var postData = GetFormJsonData("shop");
        $.ajax({
            type: "POST",
            url: path+"/ajax/ajax_user.aspx?__Action=User_Login&url=<%=HttpUtility.UrlEncode(backurl) %>&token=<%=token %>&t=" + Math.random(),
            data: postData,
            dataType: 'json',
            success: function (res) {
                if (res.msg == "OK") {
                    MsgBox(1, "登录成功", res.url);
                }
                else {
                    $("#code").show();
                    MsgError(res.msg);
                }
            }
        });
    }
    function wechat(){
        if($("#weixin").is(":hidden")){
            $("#qrcode").html('<img src="'+path+'/ajax/ajax_user.aspx?__Action=GetQrCode&url=<%=HttpUtility.UrlEncode(backurl) %>&token=<%=token %>" style="width:100px;height:100px"/>');  
            $("#weixin").show();
            $("#advert").hide();
            setInterval("wechatlogin()",3000);
        }else{
            $("#weixin").hide();
            $("#advert").show();
        }
    }
    <%if(SYS.platform_login.Contains("weixin")){ %>
    var wflag=0;
    function wechatlogin()
    {
        if(wflag==0){
            wflag=1;
            $.ajax({
                type: "POST",
                url: path+"/ajax/ajax_user.aspx?__Action=wechatlogin&t=" + Math.random(),
                data: '',
                dataType: 'json',
                success: function (res) {
                    if(res.msg=='OK')
                        window.location='<%=backurl %>';
                    else
                        wflag=0;
                }
            });
        }
    }
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