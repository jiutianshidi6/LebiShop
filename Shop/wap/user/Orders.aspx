<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserOrders" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_UserOrders"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserOrders","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserOrders","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserOrders","description")%>" />
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
	<h2><%=ThemePageMeta("P_UserOrders","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

    <div class="body">
        <div class="bodymain">
            
    

<div class="nbbox clearfix">
<div class="user">
    <ul class="tablist">
        <li <%if (status == ""){Response.Write("class=\"selected\"");} %>><a href="?status="><span>全部订单</span></a></li>
        <li <%if (status == "1"){Response.Write("class=\"selected\"");} %>><a href="?status=1"><span>等待付款</span></a></li>
        <li <%if (status == "2"){Response.Write("class=\"selected\"");} %>><a href="?status=2"><span>等待收货</span></a></li>
        <li <%if (status == "3"){Response.Write("class=\"selected\"");} %>><a href="?status=3"><span>已收货</span></a></li>
        <li <%if (status == "4"){Response.Write("class=\"selected\"");} %>><a href="?status=4"><span>已完成</span></a></li>
        <li <%if (status == "5"){Response.Write("class=\"selected\"");} %>><a href="?status=5"><span>已取消</span></a></li>
    </ul>
    <div class="searchbox clearfix">
        <select id="status">
            <option value="">┌ 状态</option>
            <option value="1" <%if (status == "1"){Response.Write("class=\"selected\"");} %>>等待付款</option>
            <option value="2" <%if (status == "2"){Response.Write("class=\"selected\"");} %>>等待收货</option>
            <option value="3" <%if (status == "3"){Response.Write("class=\"selected\"");} %>>已收货</option>
            <option value="4" <%if (status == "4"){Response.Write("class=\"selected\"");} %>>已完成</option>
            <option value="5" <%if (status == "5"){Response.Write("class=\"selected\"");} %>>已取消</option>
        </select>
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" onClick="WdatePicker({lang:'<%=CurrentLanguage.Code %>'})" /> - <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" onClick="WdatePicker({lang:'<%=CurrentLanguage.Code %>'})" />
        <input type="text" id="key" name="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" />
        <a href="javascript:void(0)" onclick="search_();" class="btn btn-12"><s></s>查询</a>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" class="tablelist box">
        <tr>
            <th style="width:120px;">订单编号</th>
            <th style="width:80px;">收货人</th>
            <th>配送方式/运单号</th>
            <th style="width:80px;">订单金额</th>
            <th style="width:120px;">时间</th>
            <th style="width:80px;">状态</th>
            <th style="width:80px;">操作</th>
        </tr>
        <%foreach (Shop.Model.Lebi_Order o in orders){%>
            <%
            string TransportMes = "";
            List<Shop.Model.Lebi_Transport_Order> transport_orders = Shop.Bussiness.B_Lebi_Transport_Order.GetList("Order_id = "+ o.id +"", "id desc");
            foreach (Shop.Model.Lebi_Transport_Order t in transport_orders){
            if (t != null){
                TransportMes += t.Transport_Name +" "+ t.Code +" ";
            }}%>
        <tr>
            <td><a href="<%=URL("P_UserOrderDetails",o.id,"")%>" target="_blank"><%=o.Code %></a></td>
            <td><%=o.T_Name %></td>
            <td onclick="copy_clip('<%=TransportMes %>');">
                <%=TransportMes %>
            </td>
            <td><%=FormatMoney(o.Money_Order) %></td>
            <td><%=FormatTime(o.Time_Add) %></td>
            <td><%=OrderStatus(o) %></td>
            <td>
                <a href="<%=URL("P_UserOrderDetails",o.id)%>" target="_blank">查看</a><%if(o.IsVerified==0 && o.IsPaid==0 && o.IsInvalid==0){ %>
                <br /><a href="javascript:void(0);" onclick="cancel(<%=o.id %>);">取消</a><%} %>
                <%if(o.IsReceived==1 && SYS.IsClosetuihuo=="0"){ %>
                <br /><a href="<%=URL("P_UserReturnApply",o.id)%>" target="_blank">退货</a>
                <%} %>
            </td>
        </tr>
        <%} %>
    </table>
    <div class="bottom clearfix"><div class="right"><%=PageString%></div></div>
</div>
</div>
<script type="text/javascript">
    function search_() {
        var key = $("#key").val();
        var dateFrom = $("#dateFrom").val();
        var dateTo = $("#dateTo").val();
        var status = $("#status").val();
        window.location = "?key=" + escape(key) + "&dateFrom=" + dateFrom + "&dateTo=" + dateTo + "&status=" + status;
    }
    function cancel(id) {
        var postData = GetFormJsonData("shop");
        var url =path+"/ajax/Ajax_userin.aspx?__Action=Order_Status&type=invalid&id=" + id;
        RequestAjax(url, postData, function () { MsgBox(1, "操作成功", "?") });
    }
    function copy_clip(txt) {
        if (window.clipboardData) {
            window.clipboardData.clearData();
            window.clipboardData.setData("Text", txt);
        } else if (navigator.userAgent.indexOf("Opera") != -1) {
            window.location = txt;
        } else if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            } catch (e) {
                alert("您的firefox安全限制限制您进行剪贴板操作，请在新窗口的地址栏里输入'about:config'然后找到'signed.applets.codebase_principal_support'设置为true'");
                return false;
            }
            var clip = Components.classes["@mozilla.org/widget/clipboard;1"].createInstance(Components.interfaces.nsIClipboard);
            if (!clip)
                return;
            var trans = Components.classes["@mozilla.org/widget/transferable;1"].createInstance(Components.interfaces.nsITransferable);
            if (!trans)
                return;
            trans.addDataFlavor('text/unicode');
            var str = new Object();
            var len = new Object();
            var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
            var copytext = txt;
            str.data = copytext;
            trans.setTransferData("text/unicode", str, copytext.length * 2);
            var clipid = Components.interfaces.nsIClipboard;
            if (!clip)
                return false;
            clip.setData(trans, null, clipid.kGlobalClipboard);
        }
        alert("<%=Tag("已复制内容到剪贴板！")%>");
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
<%List<Shop.Model.Lebi_Language> zAuqs=Languages();RecordCount=zAuqs.Count;int zAuq_index=1;
foreach (Shop.Model.Lebi_Language zAuq in zAuqs){%>
<a <%if (zAuq_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=zAuq.id%>,'<%=zAuq.Code%>','<%=zAuq.Path%>');"><img src="<%=Image(zAuq.ImageUrl) %>" title="<%=zAuq.Name%>" /><%=zAuq.Name%></a>
<%zAuq_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int nRpQ_index=1;
List<Lebi_Currency> nRpQs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency nRpQ in nRpQs){%>
<dd <%if (nRpQ_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=nRpQ.id%>,'<%=nRpQ.Code%>',<%=nRpQ.ExchangeRate%>,'<%=nRpQ.Msige%>');"><%=nRpQ.Code%></a></dd>
<%nRpQ_index++;}%>
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