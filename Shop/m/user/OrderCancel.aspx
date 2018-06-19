<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserOrderCancel" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserOrderCancel"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserOrderCancel","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserOrderCancel","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserOrderCancel","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_UserOrderCancel","title")%></h2>
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
        <div class="mc clearfix">
            <div class="dl-table clearfix">
                <dl>
                    <dt>取消原因：</dt>
                    <dd>
                        <select id="Content" name="Content" onchange="SelectOption();" shop="true">
                            <option value="option1">现在不想购买</option>
                            <option value="option2">商品价格较贵</option>
                            <option value="option3">价格波动</option>
                            <option value="option4">商品缺货</option>
                            <option value="option5">重复下单</option>
                            <option value="option6">添加或删除商品</option>
                            <option value="option7">收货人信息有误</option>
                            <option value="option8">发票信息有误</option>
                            <option value="option9">无法支付订单</option>
                            <option value="option10">其他原因</option>
                        </select>
                    </dd>
                </dl>
                <dl id="DIVRemark" style="display:none">
                    <dt>补充说明：</dt>
                    <dd>
                        <textarea class="textarea" style="width: 100%; height: 50px;" id="Remark" name="Remark" min="notnull" shop="true">现在不想购买</textarea>
                        <span id="Formsay"></span>
                    </dd>
                </dl>
                <dl class="dl-btn">
                    <dt></dt>
                    <dd><a href="javascript:void(0)" onclick="submit();" class="btn btn-12"><s></s>提交</a></dd>
                </dl>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" >
    function SelectOption() {
        var Content = $("#Content").val();
        if (Content == "option10") {
            $("#DIVRemark").show();
            $("#Remark").html("");
        } else {
            $("#DIVRemark").hide();
            switch (Content) {
                case "option1":
                    $("#Remark").html("现在不想购买");
                    break;
                case "option2":
                    $("#Remark").html("商品价格较贵");
                    break;
                case "option3":
                    $("#Remark").html("价格波动");
                    break;
                case "option4":
                    $("#Remark").html("商品缺货");
                    break;
                case "option5":
                    $("#Remark").html("重复下单");
                    break;
                case "option6":
                    $("#Remark").html("添加或删除商品");
                    break;
                case "option7":
                    $("#Remark").html("收货人信息有误");
                    break;
                case "option8":
                    $("#Remark").html("发票信息有误");
                    break;
                case "option9":
                    $("#Remark").html("无法支付订单");
                    break;
            }
        }
    }
    function submit() {
        if (!CheckForm("shop", "span"))
            return false;
        var postData = GetFormJsonData("shop");
        var url = path + "/ajax/Ajax_order.aspx?__Action=OrderCancal&id=<%=order.id %>";
        RequestAjax(url, postData, function () { MsgBox(1, "操作成功", "<%=URL("P_UserOrderDetails",order.id,"")%>") });
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