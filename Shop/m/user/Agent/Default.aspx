

<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Bussiness.ShopPage" %>
<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserAgent"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserAgent","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserAgent","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserAgent","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_UserAgent","title")%></h2>
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
int CommissionLevel = 3;
string platform_weixin_number = SYS.platform_weixin_number;
if (DT_id > 0){
    platform_weixin_number = ShopCache.GetBaseConfig_DT(DT_id).platform_weixin_number;
    Shop.Model.Lebi_DT currendt = Shop.Bussiness.B_Lebi_DT.GetModel(DT_id);
    if (currendt != null){
        CommissionLevel = currendt.CommissionLevel;
    }
}
%>
<div class="nbbox clearfix">
<div class="userbox">
    <div class="mt">
        <h2><%=Tag("基本信息")%></h2>
    </div>
    <div class="mc clearfix">
    <div class="dl-table clearfix">
    <dl>
        <dt><%=Tag("邀请码")%>：</dt>
        <dd><%=CurrentUser.id %></dd>
    </dl>
    <dl>
        <dt><%=Tag("一级佣金")%>：</dt>
        <dd><%=AgentInfo.Commission1%> %</dd>
    </dl>
    <%if (CommissionLevel >=2){%>
    <dl>
        <dt><%=Tag("二级佣金")%>：</dt>
        <dd><%=AgentInfo.Commission2%> %</dd>
    </dl>
    <%}%>
    <%if (CommissionLevel >=3){%>
    <dl>
        <dt><%=Tag("三级佣金")%>：</dt>
        <dd><%=AgentInfo.Commission3%> %</dd>
    </dl>
    <%}%>
    <dl>
        <dt><%=Tag("我的推广链接")%>：</dt>
        <dd><span  id="myurl">http://<%=SYS.Domain==""?ShopCache.GetMainSite().Domain:SYS.Domain%>/m/?v=<%=CurrentUser.id %></span></dd>
    </dl>
    <%if (platform_weixin_number != ""){%>
    <dl>
        <dt><%=Tag("微信推广二维码")%>：</dt>
        <dd>
            <%Shop.Platform.weixin wx=new Shop.Platform.weixin(DT_id,CurrentSite);%>
            <img src="<%=wx.QrCode(0, CurrentUser)%>" style="width:100px;"/>
        </dd>
    </dl>
    <%}%>
    <dl>
        <dt><%=Tag("今日推广人数")%>：</dt>
        <dd><a href="<%=URL("P_UserAgentList",""+System.DateTime.Now.Date.ToShortDateString()+","+System.DateTime.Now.Date.ToShortDateString()+"")%>"><%=AgentInfo.UserCountday%></a></dd>
    </dl>
    <dl>
        <dt><%=Tag("月推广人数")%>：</dt>
        <dd><a href="<%=URL("P_UserAgentList",""+System.DateTime.Now.Date.AddDays(0 - System.DateTime.Now.Day + 1).ToString("yyyy-MM-dd")+","+System.DateTime.Now.Date.ToShortDateString()+"")%>"><%=AgentInfo.UserCountmonth%></a></dd>
    </dl>
    <dl>
        <dt><%=Tag("总推广人数")%>：</dt>
        <dd><a href="<%=URL("P_UserAgentList","")%>"><%=AgentInfo.UserCount%></a></dd>
    </dl>
    <dl>
        <dt><%=Tag("可提现金额") %>：</dt>
        <dd><%=AgentInfo.Money%></dd>
    </dl>
    </div>
    <script type="text/javascript">
        function copy_() {
            var myurl = $("#myurl").val();
            copy_clip(myurl);
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
</div>
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