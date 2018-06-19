<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserProfile" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserProfile"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserProfile","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserProfile","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserProfile","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_UserProfile","title")%></h2>
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
    <div class="mt">
        <h2>资料管理</h2>
    </div>
    <div class="mc clearfix">
    <div class="dl-table clearfix">
    <dl>
        <dt>登录帐号：</dt>
        <dd><%=CurrentUser.UserName %>&nbsp;<em>此项不可修改</em></dd>
    </dl>
    <dl>
        <dt>真实姓名：</dt>
        <dd><input type="text" name="RealName" id="RealName" size="30" value="<%=CurrentUser.RealName %>" class="input" shop="true" /></dd>
    </dl>
    <dl>
        <dt>昵称：</dt>
        <dd><input type="text" name="NickName" id="NickName" size="30" value="<%=CurrentUser.NickName %>" class="input" shop="true" /></dd>
    </dl>
    <dl>
        <dt>出生日期：</dt>
        <dd><input type="text" name="Birthday" size="30" value="<%=FormatDate(CurrentUser.Birthday) %>" id="Birthday" class="input" shop="true" /></dd>
    </dl>
    <dl>
        <dt>性别：</dt>
        <dd><lable><input type="radio" name="Sex" value="男" class="input" shop="true" <%=CurrentUser.Sex=="男"?"checked":"" %>/><%=Tag("男") %></lable>
        <lable><input type="radio" name="Sex" value="女" class="input" shop="true" <%=CurrentUser.Sex=="女"?"checked":"" %>/><%=Tag("女") %></lable></dd>
    </dl>
    <dl>
        <dt>手机号码：</dt>
        <dd><input type="text" name="MobilePhone" id="MobilePhone" size="30" value="<%=CurrentUser.MobilePhone %>" class="input" shop="true" />
            <%if(Checkmobilephone){ %>
            &nbsp;验证码：
            <input type="text" shop="true" min="notnull" maxlength="6" name="MobilePhone_checkcode" id="MobilePhone_checkcode" style="width: 60px;" class="input" />
            <input id="btn_phone" type="button" value="获取验证码" style="width: 80px; height:25px" onclick="getcheckcode('phone');" />
            <span id="msg_phone"></span>
            <%} %>
        </dd>
    </dl>
    <dl>
        <dt>电话号码：</dt>
        <dd><input type="text" name="Phone" size="30" id="Phone" value="<%=CurrentUser.Phone %>" class="input" shop="true" /></dd>
    </dl>
    <dl>
        <dt>传真号码：</dt>
        <dd><input type="text" name="fax" id="fax" size="30" value="<%=CurrentUser.Fax %>" class="input" shop="true" /></dd>
    </dl>
    <dl>
        <dt>Email地址：</dt>
        <dd><input type="text" name="Email" id="Email" size="30" value="<%=CurrentUser.Email %>" class="input" shop="true" />
            <%if(Checkemail){ %>
            &nbsp;验证码：
            <input type="text" shop="true" min="notnull" maxlength="6" name="Email_checkcode" id="Email_checkcode" style="width: 60px;" class="input" />
            <input id="btn_email" type="button" value="获取验证码" style="height:25px" onclick="getcheckcode('email');" />
            <span id="msg_email"></span>
            <%} %>
        </dd>
    </dl>
    <dl>
        <dt>QQ号码：</dt>
        <dd><input type="text" name="QQ" id="QQ" size="30" value="<%=CurrentUser.QQ %>" class="input" shop="true" /></dd>
    </dl>
    <dl>
        <dt>邮编：</dt>
        <dd><input type="text" name="Postalcode" id="Postalcode" size="30" value="<%=CurrentUser.Postalcode %>" class="input" shop="true" /></dd>
    </dl>
    <dl>
        <dt>地址：</dt>
        <dd><input type="text" name="Address" id="Address" size="30" value="<%=CurrentUser.Address %>" class="input" shop="true" /></dd>
    </dl>
    <dl>
        <dt>地区：</dt>
        <dd><div id="Area_id_div"></div></dd>
    </dl>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0)" onclick="update();" class="btn btn-11"><s></s>提交</a></dd>
    </dl>
    </div>
    </div>
</div>
</div>
<script type="text/javascript">
    $(document).ready(function ($) { 
        $("#Birthday").datepicker({dateFormat:"yy-mm-dd"});
    });
    GetAreaList(<%=SYS.TopAreaid %>, <%=CurrentUser.Area_id %>); //加载地区下拉框
    function update() {
        var postData = GetFormJsonData("shop");
        var Area_id = $("#Area_id").val();
        var url = path+"/ajax/Ajax_userin.aspx?__Action=User_Info&Area_id="+Area_id;
        RequestAjax(url, postData, function () { MsgBox(1, "操作成功", "") });
    }
    var djs_phone = 60;
    var djs_email = 60;
    function getcheckcode(t) {
        var email = '';
        var postData = '';
        var url = '';
        if (t == 'phone') {
            phone = $("#MobilePhone").val();
            postData = { "phone": phone };
            url = path + "/ajax/ajax.aspx?__Action=GetPhoneCheckCode&m=<%=mcode%>";
        } else {
            email = $("#Email").val();
            postData = { "email": email };
            url = path + "/ajax/ajax.aspx?__Action=GetEmailCheckCode&m=<%=mcode%>";
            if (!IsEmail(email)) {
                $("#msg_" + t).html("请填写邮箱");
                return false;
            }
        }
        $.ajax({
            type: "POST",
            url: url,
            data: postData,
            dataType: 'json',
            beforeSend: function () {
                $("#btn_" + t).hide();
                $("#msg_" + t).html("正在发送...");
            },
            success: function (res) {
                if (res.msg == "OK") {
                    if (t == 'phone') {
                        djs_phone = 60;
                        daojishi_phone();
                        setInterval(daojishi_phone, 1000);
                    } else {
                        djs_email = 60;
                        daojishi_email();
                        setInterval(daojishi_email, 1000);
                    }
                    return false;
                }
                else {
                    $("#btn_" + t).show();
                    $("#msg_" + t).html(res.msg);
                    return false;
                }
            }
        });
    }
    function daojishi_email() {
        djs_email = djs_email - 1;
        if (djs_email > 0)
            $("#msg_email").html(djs_email + "秒后重新发送");
        else {
            $("#msg_email").html("");
            $("#btn_email").show();
        }
    }
    function daojishi_phone() {
        djs_phone = djs_phone - 1;
        if (djs_phone > 0)
            $("#msg_phone").html(djs_phone + "秒后重新发送");
        else {
            $("#msg_phone").html("");
            $("#btn_phone").show();
        }
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