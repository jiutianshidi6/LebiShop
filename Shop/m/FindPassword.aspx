<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_FindPassword" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_FindPassword"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_FindPassword","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_FindPassword","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_FindPassword","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_FindPassword","title")%></h2>
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
        <h2>找回密码</h2>
    </div>
    <div class="mc clearfix">
    <div class="dl-table clearfix">
    <%if (type == 1){ %>
    <%int i=1;foreach (Shop.Model.Lebi_User_Answer model in user_answers){%>
    <dl>
        <dt>问题：</dt>
        <dd><input type="hidden" name="Question_id<%=i %>" id="Question_id<%=i %>" value="<%=model.User_Question_id%>" shop="true" />
		<%=QuestionName(model.User_Question_id) %></dd>
    </dl>
    <dl>
        <dt>答案：</dt>
        <dd><input type="text" id="Answer<%=i %>" name="Answer<%=i %>" size="30" class="input" value="" min="notnull" shop="true" /></dd>
    </dl>
    <%i++;} %>
    <%} %>
    <dl>
        <dt>新密码：</dt>
        <dd><input name="PWD" id="PWD" shop="true" type="password" size="30" class="input" />
        <span id="FormPWD"></span></dd>
    </dl>
    <dl>
        <dt>确认密码：</dt>
        <dd><input name="RPWD" id="RPWD" shop="true" type="password" size="30" class="input" />
        <span id="FormRPWD"></span></dd>
    </dl>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0)" onclick="submit();" class="btn btn-11"><s></s>提交</a>
        <input name="id" id="id" shop="true" type="hidden" value="<%=Rint("id") %>" />
        <input name="email" id="email" shop="true" type="hidden" value="<%=Rstring("id") %>" />
        <input name="checkcode" id="checkcode" shop="true" type="hidden" value="<%=Rstring("v") %>" /></dd>
    </dl>
    <dl class="dl-msg">
        <dt></dt>
        <dd><div id="msg"></div></dd>
    </dl>
    </div>
    </div>
</div>
</div>
<script type="text/javascript">
    function submit() {
        var PWD = $("#PWD").val();
        var RPWD = $("#RPWD").val();
        <%if (type == 1){ %>
        var Answer1 = $("#Answer1").val();
        var Answer2 = $("#Answer2").val();
        if (Answer1 == "") {
            CheckNO("Answer1", "请回答答案");
            return false;
        }
        if (Answer2 == "") {
            CheckNO("Answer2", "请回答答案");
            return false;
        }
        <%} %>
        if (PWD == "") {
            CheckNO("PWD", "密码不能为空");
            return false;
        }
        if (PWD != RPWD) {
            CheckNO("RPWD", "两次输入的密码不一致");
            return false;
        }
        var postData = GetFormJsonData("shop");
        var url = path+"/ajax/ajax_user.aspx?__Action=User_resetpwd&v=<%=v%>&type=<%=type %>";
        RequestAjax(url, postData, function () { MsgBox(1, "密码修改成功，请登录", "<%=URL("P_Login","")%>") });
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