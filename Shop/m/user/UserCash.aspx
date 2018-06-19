<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserCash" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserCash"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserCash","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserCash","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserCash","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_UserCash","title")%></h2>
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
            <h2>提现</h2>
        </div>
        <%if(SubmitShow){ %>
        <div class="mc clearfix">
        <div class="dl-table clearfix">
        <dl>
            <dt>收款方式：</dt>
            <dd>
            <label><input type="radio" name="PayType" value="bank" shop="true" onclick="SetType();" checked />银行转账</label>
            <label><input type="radio" name="PayType" value="alipay" shop="true" onclick="SetType();" />支付宝</label>
            </dd>
        </dl>
        <dl>
            <dt>姓名：</dt>
            <dd><input type="text" name="CashAccount_Name" id="CashAccount_Name" size="30" value="" shop="true" min="notnull" class="input" /></dd>
        </dl>
        <dl>
            <dt>账号：</dt>
            <dd><input type="text" name="CashAccount_Code" id="CashAccount_Code" size="30" value="" shop="true" min="notnull" class="input" /></dd>
        </dl>
        <dl id="DIVCashAccount_Bank">
            <dt>银行：</dt>
            <dd><input type="text" name="CashAccount_Bank" id="CashAccount_Bank" size="30" value="" shop="true" min="notnull" class="input" /></dd>
        </dl>
        <dl>
            <dt>提现金额(<%=DefaultCurrency.Msige %>)：</dt>
            <dd><input type="text" name="RMoney" id="RMoney" onkeyup="value=value.replace(/[^\d\.]/g,'');" value="<%=CurrentUser.Money %>" shop="true" min="notnull" class="input" />
            <em>帐户余额((<%=DefaultCurrency.Msige %>)):<%=CurrentUser.Money %> &nbsp;&nbsp;最低提现金额(<%=DefaultCurrency.Msige %>):<%=SYS.TakeMoneyLimit %></em></dd>
        </dl>
        <dl>
            <dt>支付密码：</dt>
            <dd><input name="Pay_Password" id="Pay_Password" size="30" type="password" shop="true" min="notnull" class="input" /> <a href="<%=URL("P_UserQuestion","1")%>" target="_blank">忘记密码</a></dd>
        </dl>
        <%if(SubmitShow){ %>
        <dl class="dl-btn">
            <dt></dt>
            <dd><a href="javascript:void(0)" onclick="submit();" class="btn btn-11"><s></s>提交</a></dd>
        </dl>
        <%}else{ %>
        <dl class="dl-btn">
            <dt></dt>
            <dd>最低提现金额(<%=DefaultCurrency.Msige %>):<%=SYS.TakeMoneyLimit %></dd>
        </dl>
        <%} %>
        </div>
        </div>
        <%}
        if(CashCount>0){ %>
            <table cellpadding="0" cellspacing="0" width="100%" class="tablemenu">
                <tr>
                    <th style="width:130px;">时间</th>
                    <th style="width:100px;">金额/手续费</th>
                    <th style="width:100px;">状态</th>
                    <th>备注</th>
                </tr>
            </table>
            <div class="table-list loadlist">
            <%foreach (Shop.Model.Lebi_Cash o in cashs){%>
            <div class="loadli">
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width:130px;"><%=FormatTime(o.Time_add) %></td>
                <td style="width:100px;"><%=FormatMoney(o.Money) %>/<%=FormatMoney(o.Fee) %></td>
                <td style="width:100px;"><%=TypeName(o.Type_id_CashStatus) %></td>
                <td><%=o.Remark %></td>
            </tr>
            </table>
            </div>
            <%} %>
            <%if (CurrentSite.IsMobile==0){ %>
                <div class="bottom clearfix"><div class="right"><%=PageString%></div></div>
            <%}else{%>
            <div class="loadpage">
                <a data-next="<%=NextPage%>"></a>
            </div>
            <script>
                $(document).ready(function () {
                    var container = document.querySelector('.loadlist');
                    var ias = $.ias({
                        container: ".loadlist",
                        item: ".loadli",
                        pagination: ".loadpage",
                        next: ".loadpage a"
                    });
                    ias.on('render', function (items) {
                        //$(items).css({ opacity: 0 });
                    });
                    ias.on("rendered", function (items) {
                    });
                    ias.extension(new IASSpinnerExtension({ html: "<div class=\"loadinginfo\"><img src=\"{src}\" />&nbsp;加载中</div>" }));
                    ias.extension(new IASTriggerExtension({ text: '加载更多', offset: 100, html: "<div class=\"loadinginfo more\"><p>{text}</p></div>" }));
                    ias.extension(new IASNoneLeftExtension({
                        text: '', html: ""
                    }));
                });
            </script>
            <%}%>
        <%} %>
    </div>
</div>
<script type="text/javascript">
    function submit() {
        var RMoney = $("#RMoney").val();
        if (RMoney == "" || RMoney<=0) {
            CheckNO("RMoney", "金额必须大于0");
            return false;
        }
        var postData = GetFormJsonData("shop");;
        var url = path+"/ajax/ajax_userin.aspx?__Action=TackMoney";
        RequestAjax(url, postData, function (res) { MsgBox(1, "操作成功", "?");$("#CashAccount_Name").val("");$("#CashAccount_Code").val("");$("#CashAccount_Bank").val("");$("#RMoney").val("<%=CurrentUser.Money %>"); });
    }
    function SetType() {
        var Type = $("input[name='PayType']:checked").val();
        if (Type == "alipay") {
            $("#DIVCashAccount_Bank").hide();
            $("#CashAccount_Bank").attr("min", "");
        } else {
            $("#DIVCashAccount_Bank").show();
            $("#CashAccount_Bank").attr("min", "notnull");
        }
    }
    SetType();
    function SetBank(PayType, UserName, Code, Name) {
        if (PayType == "alipay") {
            $("input[name=PayType][value='alipay']").attr("checked", true);
            $("#DIVCashAccount_Bank").hide();
            $("#CashAccount_Bank").attr("min", "");
            $("#CashAccount_Name").val(UserName);
            $("#CashAccount_Code").val(Code);
            $("#CashAccount_Bank").val("");
        } else {
            $("input[name=PayType][value='bank']").attr("checked", true);
            $("#DIVCashAccount_Bank").show();
            $("#CashAccount_Bank").attr("min", "notnull");
            $("#CashAccount_Name").val(UserName);
            $("#CashAccount_Code").val(Code);
            $("#CashAccount_Bank").val(Name);
        }
    }
    SetType();
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