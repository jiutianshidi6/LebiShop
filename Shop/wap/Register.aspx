<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Register" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_Register"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_Register","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_Register","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Register","description")%>" />
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
	<h2><%=ThemePageMeta("P_Register","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

    <div class="body">
        <div class="bodymain">
            


<script type="text/javascript">
    function OpenMore() {
        var IsOpen = document.getElementById("IsOpen");
        if (IsOpen.checked) { $("#OpenBox").show() } else { $("#OpenBox").hide() }
    }
</script>
<div class="nbbox clearfix">
    <div class="user">
        <div class="reg clearfix">
            <div class="mt clearfix">
                <h2>会员注册</h2>
            </div>
            <div class="mc clearfix">
            <div class="dl-table clearfix">
            <dl>
                <dt><font color="red">*</font>登录帐号：</dt>
                <dd><input type="text" name="UserName" shop="true" id="UserName" onchange="Check_username();" style="width: 200px;" maxlength="20" class="input" min="4" maxlength="20" max="20" />
                <span id="FormUserName" class="FormALT">4-20个字符，可以是字母、数字或中文</span>
                </dd>
            </dl>
            <dl>
                <dt><font color="red">*</font>帐号密码：</dt>
                <dd><input type="password" shop="true" name="Password" id="Password" style="width: 200px;" maxlength="16" class="input" min="6" />
                <span id="FormPassword" class="FormALT">密码区分大小写</span>
                </dd>
            </dl>
            <dl>
                <dt><font color="red">*</font>确认密码：</dt>
                <dd><input type="password" name="Password1" shop="true" id="Password1" style="width: 200px;" maxlength="16" class="input" />
                <span id="FormPassword1" class="FormALT">请再次填写密码</span>
                </dd>
            </dl>
            <dl>
                <dt><%if(Checkmobilephone){ %><font color="red">*</font><%} %>手机号码：</dt>
                <dd><input type="text" shop="true" name="MobilePhone" id="MobilePhone" style="width: 200px;" class="input" />
                    <%if(Checkmobilephone){ %>
                    &nbsp;验证码：
                    <input type="text" shop="true" min="notnull" maxlength="6" name="MobilePhone_checkcode" id="MobilePhone_checkcode" class="input" />
                    <input id="btn_phone" type="button" value="获取验证码" style="width: 80px; height:25px" onclick="getcheckcode('phone');" />
                    <span id="msg_phone"></span>
                    <%} %>
                </dd>
            </dl>
            <dl>
                <dt><%if(Checkemail){ %><font color="red">*</font> <%} %>Email地址：</dt>
                <dd><input type="text" name="Email" id="Email" <%if(Checkemail){ %>min="email"<%} %> style="width: 200px;" value="" class="input" shop="true" />
                    <%if(Checkemail){ %>
                    &nbsp;验证码：
                    <input type="text" shop="true" min="notnull" maxlength="6" name="Email_checkcode" id="Email_checkcode" style="width: 60px;" class="input" />
                    <input id="btn_email" type="button" value="获取验证码" style="height:25px" onclick="getcheckcode('email');" />
                    <span id="msg_email"></span>
                    <%} %>
                </dd>
            </dl>
                   
<%
if (Shop.Bussiness.B_API.Check("plugin_agent")){
if (parentuserid == 0){
%>
            <dl>
                <dt>邀请码：</dt>
                <dd><input type="text" name="parentuserid" id="parentuserid" style="width: 200px;" value="" class="input" shop="true" /></dd>
            </dl>
<%}else{%>
    <input type="hidden" name="parentuserid" id="parentuserid" value="<%=parentuserid%>" shop="true" />
<%}}%>
            <%if(Checkmobilephone==false && Checkemail==false){ %>
            <dl>
                <dt><font color="red">*</font>验证码：</dt>
                <dd><input name="verifycode" type="text" shop="true" id="verifycode" shop="true" size="6"
 class="input" /> <img class="img_c" align="absmiddle" style="width: 80px; height: 25px;" title="点击重新获取验证码" id="img1" src="<%=WebPath%>/code.aspx" language="javascript" onclick="this.src=this.src+'?'">
                    <span id="C_user_vcode"></span></dd>
            </dl>
            <%} %>
            <dl>
                <dt></dt>
                <dd><label><input type="checkbox" name="agree" id="agree" />我已阅读并同意<a href="<%=URL("P_Help","$,agreement")%>" target="_blank">《注册协议》</a></label>
                <label><input type="checkbox" name="IsOpen" id="IsOpen" onclick="OpenMore();" />填写详细资料</label></dd>
            </dl>
            <div id="OpenBox" style="display: none">
            <dl>
                <dt>真实姓名：</dt>
                <dd><input type="text" name="RealName" id="RealName" shop="true" style="width: 200px;" class="input" />
                    <span id="FormRealName" class="FormALT"></span></dd>
            </dl>
            <dl>
                <dt>性别：</dt>
                <dd><label><input type="radio" name="Sex" value="男" checked />男</label>
                    <label><input type="radio" name="Sex" value="女" />女</label></dd>
            </dl>
            <dl>
                <dt>出生日期：</dt>
                <dd><input type="text" name="Birthday" id="Birthday" style="width: 200px;" class="input" shop="true" /></dd>
            </dl>
            <dl>
                <dt>电话号码：</dt>
                <dd><input type="text" name="Phone" id="Phone" style="width: 200px;" class="input" shop="true" />
                    <span id="FormPhone" class="FormALT"></span></dd>
            </dl>
            <dl>
                <dt>传真号码：</dt>
                <dd><input type="text" name="Fax" id="Fax" style="width: 200px;" maxlength="18" class="input" shop="true" /></dd>
            </dl>
            <dl>
                <dt>QQ号码：</dt>
                <dd><input type="text" name="QQ" id="QQ" style="width: 200px;" class="input" shop="true" /></dd>
            </dl>
            </div>
            <dl class="dl-btn">
                <dt></dt>
                <dd><a href="javascript:void(0)" onclick="submit();" class="btn btn-6"><s></s>提交注册</a></dd>
            </dl>
            </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(document).keyup(function (event) {
        if (event.keyCode == 13) {
            submit();
        }
    });
    function submit() {
        if (!CheckForm("shop"))
            return false;
        Check_username();
        var Password = $("#Password").val();
        var Password1 = $("#Password1").val();
        if (Password != Password1) {
            CheckNO("Password1", "两次输入的密码不一致");
            return false;
        }
        var flag = $("#agree").is(":checked");
        if (!flag) {
            MsgBox(2, "请阅读并同意注册协议", "");
            return false;
        }
        var postData = GetFormJsonData("shop");
        var url = path + "/ajax/ajax_user.aspx?__Action=User_Reg&url=<%=backurl %>&token=<%=token %>";
        RequestAjax(url, postData, function (res) { MsgBox(1, "注册成功", res.url) });
    }
    function Check_username() {
        var UserName = $("#UserName").val();
        $.ajax({
            type: 'POST',
            url: path + "/ajax/ajax_user.aspx?__Action=CheckUserName",
            data: { "UserName": UserName },
            dataType: 'html',
            success: function (data) {
                if (data == "OK") { CheckOK("UserName", "用户名可以注册"); } else { CheckNO("UserName", "用户名已被注册"); return false; }

            }
        });
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
            url = path + "/ajax/ajax.aspx?__Action=GetPhoneCheckCode";
            if (phone.length != 11) {
                $("#msg_" + t).html("请填写手机号");
                return false;
            }
        } else {
            email = $("#Email").val();
            postData = { "email": email };
            url = path + "/ajax/ajax.aspx?__Action=GetEmailCheckCode";
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
    
<div id="footer" class="clearfix">
    <div class="copyright">
        <%=Lang(SYS.Copyright) %>
    </div>
    <div class="lang">
        

<div class="language">
<%List<Shop.Model.Lebi_Language> npPRs=Languages();RecordCount=npPRs.Count;int npPR_index=1;
foreach (Shop.Model.Lebi_Language npPR in npPRs){%>
<a <%if (npPR_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=npPR.id%>,'<%=npPR.Code%>','<%=npPR.Path%>');"><img src="<%=Image(npPR.ImageUrl) %>" title="<%=npPR.Name%>" /><%=npPR.Name%></a>
<%npPR_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int CExT_index=1;
List<Lebi_Currency> CExTs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency CExT in CExTs){%>
<dd <%if (CExT_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=CExT.id%>,'<%=CExT.Code%>',<%=CExT.ExchangeRate%>,'<%=CExT.Msige%>');"><%=CExT.Code%></a></dd>
<%CExT_index++;}%>
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