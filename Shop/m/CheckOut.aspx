<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_CheckOut" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_CheckOut"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_CheckOut","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_CheckOut","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_CheckOut","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_CheckOut","title")%></h2>
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
            


<script type="text/javascript">
    var BillFlag=<%=SYS.BillFlag %>;
    <%
    if(basket.Products.Count==0){ %>
    MsgBox(2, "购物车为空，请将您要购买的商品放入购物车", "<%=LanguagePath%>");
    <%
    } %>
</script>
<script src="<%=WebPath %>/theme/system/js/order.js" type="text/javascript"></script>
<div id="checkout">
    <div class="checkout clearfix">
        <div class="mt">
            <h2>收货人信息</h2>
        </div>
        <div class="mc">
            <div id="checkout_address">
            </div>
        </div>
    </div>
    <div class="checkout clearfix">
        <div class="mt">
            <h2>配送方式</h2>
        </div>
        <div class="mc">
            <div id="checkout_transport">
            </div>
        </div>
    </div>
    <div class="checkout clearfix">
        <div class="mt">
            <h2>支付方式</h2>
        </div>
        <div class="mc">
            <div id="checkout_pay">
            </div>
        </div>
    </div>
    <%if (SYS.BillFlag == "1"){ %>
    <div class="checkout clearfix">
        <div class="mt">
            <h2>
                发票信息</h2>
        </div>
        <div class="mc">
            <div id="checkout_bill">
            </div>
        </div>
    </div>
    <%} %>
    <div class="basketlist clearfix">
        <div class="mt"><h2>订单信息</h2></div>
        <div class="mc clearfix">
            <%if (basket.Products.Count > 0)
          {%>
            <dl>
                <dt>订单清单</dt>
                <dd class="table-list">
                <% 
            foreach (Shop.Model.Lebi_User_Product p in basket.Products)
            {
                Shop.Model.Lebi_Product model = GetProduct(p.Product_id);
                %>
                <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <th style="width:50px" valign="top" rowspan="2"><img src="<%=Image(model.ImageOriginal)%>" width="50" height="50" class="picb"></th>
                    <th style="text-align:left" valign="top">
                    <a href="<%=URL("P_Product",model.id) %>"><%=Lang(model.Name) %></a>
                    <em><%if (Shop.Bussiness.EX_Product.ProPertyNameStr(model, CurrentLanguage.Code) !=""){ %><br /><%=Shop.Bussiness.EX_Product.ProPertyNameStr(model, CurrentLanguage.Code)%><%} %>
                    <%if (p.ProPerty134 !=""){ %><br /><%=p.ProPerty134 %><%} %></em>
                    </th>
                    <th style="width:60px" valign="top">
                    <%
                    if(model.Type_id_ProductType==323 && model.Time_Expired > System.DateTime.Now)
                        Response.Write(Tag("积分")+":"+model.Price_Sale);
                    else
                        Response.Write(FormatMoney(p.Product_Price));
                    %>
                    <br /><s><%=FormatMoney(model.Price_Market) %></s>
                    </th>
                </tr>
                <tr>
                    <td colspan="2">数量：<%=p.count %></td>
                </tr>
                </table>
                <%} %>
                </dd>
            </dl>
            <%} %>
            <%if (basket.FreeProducts.Count > 0)
          {%>
            <dl>
                <dt>赠品清单</dt>
                <dd class="table-list">
            <% 
            foreach (Shop.Model.Lebi_User_Product p in basket.FreeProducts)
            {
                Shop.Model.Lebi_Product model = GetProduct(p.Product_id);
            %>
                <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <th style="width:50px" valign="top" rowspan="2"><img src="<%=Image(model.ImageOriginal)%>" width="50" height="50" class="picb"></th>
                    <th style="text-align:left" valign="top">
                    <a href="<%=URL("P_Product",model.id) %>"><%=Lang(model.Name) %></a>
                    <em><%if (Shop.Bussiness.EX_Product.ProPertyNameStr(model, CurrentLanguage.Code) !=""){ %><br /><%=Shop.Bussiness.EX_Product.ProPertyNameStr(model, CurrentLanguage.Code)%><%} %>
                    <%if (p.ProPerty134 !=""){ %><br /><%=p.ProPerty134 %><%} %></em>
                    </th>
                    <th style="width:60px" valign="top">
                    <s><%=FormatMoney(model.Price_Market) %></s>
                    </th>
                </tr>
                <tr>
                    <td colspan="2">数量：<%=p.count %></td>
                </tr>
                </table>
                <%} %>
                </dd>
            </dl>
            <%} %>
            <div class="ordertips">
                <div class="ordertotal">市场价：<span><%=FormatMoney(basket.Money_Market)%></span>
                    <%if(basket.Point_Buy>0){ %>
                    &nbsp;&nbsp;所需积分：<span><%=basket.Point_Buy%></span>
                    <%} %>
                    <%if(basket.Point>0){ %>
                    &nbsp;&nbsp;获得积分：<span><%=basket.Point%></span>
                    <%} %>
                    <%if(basket.Weight>0){ %>
                    &nbsp;&nbsp;总重量：<span><%=basket.Weight%></span> KG
                    <%} %>
                    <%if(basket.Volume>0){ %>
                    &nbsp;&nbsp;体积：<span><%=(basket.Volume/1000000).ToString("0.00")%></span> m&sup3;
                    <%} %>
                </div>
                <%if (basket.PromotionTypes.Count > 0)
                  { %>
                <div class="orderdiscount">
                    优惠促销：
                    <%
                    foreach(BasketShop shop in basket.Shops){ 
                    foreach(Lebi_Promotion_Type pt in shop.PromotionTypes){ %>
                    <br /><%=shop.Shop.id>0?"["+shop.Shop.Company+"]":"" %><%=Lang(pt.Name) %>
                    <%}} %>
                </div>
                <%} %>
            </div>
        </div>
    </div>
    <div class="checkout orderproperty clearfix">
        <div class="mt">
            <h2>订单留言</h2>
        </div>
        <div class="mc">
            <input type="text" id="remark" name="remark" order="true" value="" maxlength="200" class="input" />
        </div>
    </div>
    <div class="otherpay">
        <%if (cards.Count > 0)
          { %>
        <div class="item">
            <input type="text" id="money_card312" value="" style="display:none"/>
            <div class="title"><input type="checkbox" name="usermoneytype" value="1" order="true"/>使用代金券</div>
            <div class="content">
                <div class="table-list">
                    <table cellpadding="0" cellspacing="0" id="card312list">
                    <%foreach (Shop.Model.Lebi_Card c in cards){ %>
                    <tr>
                        <td>
                            <span class="code"><input type="checkbox" value="<%=c.id %>" <%=Shop.Bussiness.Basket.CheckCard(basket, c)?"":"disabled" %> money="<%=c.Money %>" name="pay312" id="pay312_<%=c.id %>" class="check" order="true" rflag="<%=c.IsCanOtherUse %>" onclick="select312(<%=c.id %>);" /></span>
                            <span class="name"><%=cardname(c.CardOrder_id) %> <em><%=c.Code %></em></span>
                            <span class="money"><%=FormatMoney(c.Money) %></span>
                            <br />使用条件：<span class="use"><%=cardinfo(c)%><input type="hidden" name="cardmoney" value="<%=c.Money_Last %>" /></span>
    <br />有效期：<span class="time"><%=c.Time_End.ToString("yyyy-MM-dd")%></span>
</td>
                    </tr>
                    <%} %>
                    </table>
                </div>
            </div>
        </div>
        <%} %>                                                                                                                                    
        <div class="item">
            <input type="text" id="money_card311" value="" style="display:none"/>
            <div class="title"><input type="checkbox" name="usermoneytype" value="2" order="true"/>使用礼品卡</div>
            <div class="content">
                编号：<input type="text" id="moneycardcode" name="moneycardcode" order="true" value="" maxlength="20" size="15" class="input" /> 
                密码：<input type="text" id="moneycardpwd" name="moneycardpwd" order="true" value="" maxlength="20" size="10" class="input" />
                <a href="javascript:void(0)" onclick="checkmoneycard();" class="btn btn-11"><s></s>查询</a>
                <span id="moneycardstatus"></span>
                <div class="moneycardresult" >
                <div class="table-list">
                    <table cellpadding="0" cellspacing="0" id="card311list">
                        <%foreach (Shop.Model.Lebi_Card c in moneycards){ %>
                        <tr>
                            <td>
                                <span class="code"><input type="checkbox" id="pay311_<%=c.id %>" value="<%=c.id %>" money="<%=c.Money_Last %>" order="true" name="pay311" class="check" onclick="select311();" /></span>
                                <span class="name"><%=cardname(c.CardOrder_id) %> <em><%=c.Code %></em></span>
                                <span class="money"><%=FormatMoney(c.Money) %></span>
                                <br/>余额：<span class="money_last"><%=FormatMoney(c.Money_Last) %></span>
                                <br />使用：<span class="use"><span class="show_moneyuse"></span></span>
                                
                                <input type="hidden" name="cardmoney" value="<%=c.Money_Last %>" />
                                
                                <input type="hidden" name="Money_Card311" order="true" value="0" />
                                <br />有效期：<span class="time"><%=c.Time_End.ToString("yyyy-MM-dd")%></span>
                            </td>
                        </tr>
                        <%} %>
                        <tr id="moneycardresult" style="display:none;">
                            <td><span class="code"></span>
                            <span class="name"></span>
                            <span class="money"></span>
                            <br />余额：<span class="money_last"></span>
                            <br />使用：<span class="use">
                                <span class="show_moneyuse"></span>
                                
                                <input type="hidden" name="cardmoney" value="" />
                                
                                <input type="hidden" name="Money_Card311" order="true" value="0" />
                            </span>
                            <br />有效期：<span class="time"></span>
                            </td>
                        </tr>
                    </table>
                    </div>
                </div>
            </div>
        </div>
        <%if (CurrentUser.Money > 0){ %>
        <div class="item">
            <div class="title"><input type="checkbox" value="3" id="payusermoney" name="usermoneytype" onclick="selectusermongy();" order="true"/>使用余额</div>
            <div class="content">
                <table class="cardlist" cellspacing="0" cellpadding="0" id="usermoneyitem">
                    <tr>
                        <td class="usermoney">
                        余额：<%=FormatMoney(CurrentUser.Money) %>&nbsp;&nbsp;使用：<input type="hidden" id="Money_canused" name="Money_canused" value="<%=CurrentUser.Money%>" /><input type="hidden" id="CurrentExchangeRate" name="CurrentExchangeRate" value="<%=CurrentCurrency.ExchangeRate %>" /><span class="show_moneyuse"><%=FormatMoney(0) %></span><input type="hidden" name="Money_UserCut" order="true" value="0" /><br />支付密码：<input type="password" id="Pay_Password" name="Pay_Password" size="20" value="" order="true" class="input" /> <a href="<%=URL("P_UserQuestion","1")%>" target="_blank">忘记密码</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%} %>
    </div>
    <div class="total" id="orderform"></div>
    <%if (ProPerty135.Count > 0){ %>
    <div class="checkout orderproperty clearfix">
    <div class="mt">
        <h2>订单调查</h2>
    </div>
    <div class="mc">
        <table width="100%" cellspacing="0" cellpadding="0">
        <%foreach (Lebi_ProPerty p in ProPerty135){%>
         <tr>
            <th><%=Lang(p.Name) %><input type="hidden" name="Propertyid" value="<%=p.id%>" order="true" /></th>
         </tr>
         <tr>
            <td>
            <%
            List<Lebi_ProPerty> ProPerty135list = B_Lebi_ProPerty.GetList("parentid = "+ p.id +"", "Sort desc");
            if (ProPerty135list.Count > 0){
            foreach (Lebi_ProPerty pl in ProPerty135list)
            {
                %>
                <label><input type="radio" name="Property135<%=p.id%>" value="<%=pl.id%>" order="true" /><%=Lang(pl.Name) %></label>&nbsp;&nbsp;
                <%}}else{ %>
                <input type="text" name="Property135<%=p.id%>" value="" class="input" order="true" />
            <%
            }
            %>
            </td>
        </tr>
        <%
        }
        %>
        </table>
    </div>
    </div>
    <%} %>
    <div class="ordersubmit">
        <a href="<%=URL("P_Basket","") %>" class="btn btn-10"><s></s>
            返回修改</a><a href="javascript:void(0);" onclick="OrderSubmit();" class="btn btn-6"><s></s>立即提交</a>
    </div>
    <div id="overlay" class="overlay"></div>
</div>
<script type="text/javascript">
    $(function (){  
        LoadPage("<%=WebPath%>/inc/CheckOut_Address.aspx", "checkout_address");
        if (BillFlag == 1)
            LoadPage("<%=WebPath %>/inc/CheckOut_Bill.aspx", "checkout_bill");
    });
    function OrderSubmit() {
        if (!confirm("确认提交吗？"))
            return false;
        //$("#overlay").show();
        var postData = GetFormJsonData("order");
        var url = path+"/ajax/ajax_order.aspx?__Action=order_save";
        RequestAjax(url, postData, function (res) { MsgBox(1, "正在提交……", "<%=URL("P_Cashier","")%>?order_id=" + res.id +"") });
    }
    $(function () {
        $(".otherpay .item .title").each(function (i) {
            $(this).click(function () {
                var che = $(this).children("input");
                var t=che.val();
                if (che.is(":checked")) {
                    $(this).next().show();
                } else {
                    $(this).next().hide();
                    if(t==1){
                        $("input[type='checkbox'][name='pay312']").attr("checked",false);
                        select312();
                    }
                    if(t==2){
                        $("input[type='checkbox'][name='pay311']").attr("checked",false);
                        select311();
                    }
                    if(t==3){
                        selectusermongy();
                    }
                }
            });
        });
    });
    function select312(id) {
         SetMoneyCardAndUserMoney();
         if(id!=undefined)
         {
            var flag=$("#pay312_"+id).attr('rflag');
            var check=$("#pay312_"+id).is(":checked");
            if(flag==1)
            {
                $("input[type='checkbox'][name='pay312'][rflag='0']").attr("checked",false);
            }else{
                $("input[type='checkbox'][name='pay312']").attr("checked",false);
                if(check)
                    $("#pay312_"+id).attr("checked",true);
            }
         }
    }
    function select311() {
        SetMoneyCardAndUserMoney();
    }
    function selectusermongy() {
        SetMoneyCardAndUserMoney();
    }
    function checkmoneycard()
    {
        var moneycardcode=$("#moneycardcode").val();
        var moneycardpwd=$("#moneycardpwd").val();
        var postdata={"moneycardcode":moneycardcode,"moneycardpwd":moneycardpwd};
        var url=path+"/ajax/ajax_order.aspx?__Action=MoneyCardCheack";
        $.ajax({
            type: "POST",
            url: url,
            data: postdata,
            dataType: 'json',
            success: function (res) {
                if (res.msg == "OK") {
                    if ($("#pay311_"+res.id)[0] == undefined){
                    $("#moneycardstatus").html('')
                    $("#moneycardresult").show();
                    $("#moneycardresult .code").html('<input type="checkbox" value="'+res.id+'" money="'+res.money_lastvalue+'" name="pay311" order="true" class="check" onclick="select311();"/>');
                    $("#moneycardresult .name").html(res.name +'<em>'+ res.code +'</em>');
                    $("#moneycardresult .money").html(res.money);
                    $("#moneycardresult .money_last").html(res.money_last);
                    $("#moneycardresult .use input[name='cardmoney']").val(res.money_lastvalue);
                    $("#moneycardresult .time").html(res.timeend);
                    }
                }
                else {
                    //$("#moneycardstatus").html(res.msg)
                    MsgBox(2, res.msg, "");
                    $("#moneycardresult").hide();
                    return false;
                }
            }
        });
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