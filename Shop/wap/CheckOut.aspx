<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_CheckOut" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_CheckOut"); %>

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
	<h2><%=ThemePageMeta("P_CheckOut","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

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
                    <th style="width:50px" valign="top" rowspan="2"><img src="<%=Image(model.ImageSmall)%>" width="50" height="50" class="picb"></th>
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
                    <th style="width:50px" valign="top" rowspan="2"><img src="<%=Image(model.ImageSmall)%>" width="50" height="50" class="picb"></th>
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
    <div class="otherpay">
        <%if (cards.Count > 0)
          { %>
        <div class="item">
            <input type="text" id="money_card312" value="" style="display:none"/>
            <div class="title"><input type="checkbox" name="usermoneytype" value="1" order="true"/>使用代金券</div>
            <div class="content">
                <div class="table-list" id="card312list">
                    <%foreach (Shop.Model.Lebi_Card c in cards){ %>
                    <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <th style="width:120px;"><input type="checkbox" value="<%=c.id %>" <%=Shop.Bussiness.Basket.CheckCard(basket, c)?"":"disabled" %> money="<%=c.Money %>" name="pay312" id="pay312_<%=c.id %>" class="check" order="true" rflag="<%=c.IsCanOtherUse %>" onclick="select312(<%=c.id %>);"/><%=c.Code %></th>
                        <th style="width:120px;"><%=cardname(c.CardOrder_id) %></th>
                        <th><%=FormatMoney(c.Money) %></th>
                    </tr>
                    <tr>
                        <td colspan="3">使用条件：<%=cardinfo(c)%><input type="hidden" name="cardmoney" value="<%=c.Money_Last %>" /></td>
                    </tr>
                    <tr>
                        <th colspan="3">有效期：<%=c.Time_End.ToString("yyyy-MM-dd")%></th>
                    </tr>
                    </table>
                    <%} %>
                </div>
            </div>
        </div>
        <%} %>                                                                                                                                     <div class="item">
        <input type="text" id="money_card311" value="" style="display:none"/>
        <div class="title"><input type="checkbox" name="usermoneytype" value="2" order="true"/>使用礼品卡</div>
        <div class="content">
            编号：<input type="text" id="moneycardcode" name="moneycardcode" order="true" value="" maxlength="20" size="15" class="input" /> 
            密码：<input type="text" id="moneycardpwd" name="moneycardpwd" order="true" value="" maxlength="20" size="10" class="input" />
            <a href="javascript:void(0)" onclick="checkmoneycard();" class="btn btn-11"><s></s>查询</a>
            <span id="moneycardstatus"></span>
            <div class="moneycardresult" >
            <div class="table-list" id="card311list">
                <%foreach (Shop.Model.Lebi_Card c in moneycards){ %>
                <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <th style="width:120px;"><span class="code"><input type="checkbox" id="pay311_<%=c.id %>" value="<%=c.id %>" money="<%=c.Money_Last %>" order="true" name="pay311" class="check" onclick="select311();"/><%=c.Code %></span></th>
                    <th style="width:120px;"><span class="name"><%=cardname(c.CardOrder_id) %></span></th>
                    <th><span class="money"><%=FormatMoney(c.Money) %></span></th>
                </tr>
                <tr>
                    <td colspan="3">余额：<span class="money_last"><%=FormatMoney(c.Money_Last) %></span></td>
                </tr>
                <tr>
                    <td colspan="3">使用：<span class="use"><span class="show_moneyuse"></span></span>
                    
                    <input type="hidden" name="cardmoney" value="<%=c.Money_Last %>" /> 
                    
                    <input type="hidden" name="Money_Card311" order="true" value="0" />
                     </td>
                </tr>
                <tr>
                    <th colspan="3">有效期：<span class="time"><%=c.Time_End.ToString("yyyy-MM-dd")%></span></th>
                </tr>
                </table>
                <%} %>
            </div>
            <div class="table-list" id="moneycardresult" style="display:none;">
                <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <th style="width:120px;"><span class="code"></span></th>
                    <th style="width:120px;"><span class="name"></span></th>
                    <th><span class="money"></span></th>
                </tr>
                <tr>
                    <td colspan="3">余额：<span class="money_last"></span></td>
                </tr>
                <tr>
                    <td colspan="3">使用：<span class="use"><span class="show_moneyuse"></span></span>
                    
                    <input type="hidden" name="cardmoney" value="" /> 
                    
                    <input type="hidden" name="Money_Card311" order="true" value="0" />
                     </td>
                </tr>
                <tr>
                    <th colspan="3">有效期：<span class="time"></span></th>
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
    $(function () {
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
                    $("#moneycardresult .code").html('<input type="checkbox" value="'+res.id+'" money="'+res.money_lastvalue+'" name="pay311" order="true" class="check" onclick="select311();"/>'+res.code);
                    $("#moneycardresult .money").html(res.money);
                    $("#moneycardresult .money_last").html(res.money_last);
                    $("#moneycardresult .use input[name='cardmoney']").val(res.money_lastvalue);
                    $("#moneycardresult .time").html(res.timeend);
                    }
                }
                else {
                    $("#moneycardstatus").html(res.msg)
                    $("#moneycardresult").hide();
                    return false;
                }
            }
        });
    }
</script>



        </div>
        <div class="search">
	        <a name="search"></a>
	        

<script type="text/javascript">
$(function () {
    blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int IgSI_index=1;
List<Lebi_Searchkey> IgSIs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey IgSI in IgSIs){%><%=Lang(IgSI.Name)%><%IgSI_index++;}%><%} %>');
    $("#keyword").click(function () {
        $("#keyword").val();
        $("#keywords").show();
    })
    $("#keywords").hover(function () {
        $("#keywords").show();
    }, function () {
        $("#keywords").hide();
    });
})
</script>
<div id="searchform">
<div class="searchform">
<input id="keyword" value="" type="text" name="keyword" onkeydown="if(event.keyCode==13){search();}" />
<input type="button" value="搜索" class="button" onclick="search();" />
<script type="text/javascript">
    function search() {
        var url = "<%=URL("P_Search","[key]") %>";
        location.href = url.replace("[key]",escape($("#keyword").val()));
    }
</script>
</div>
<div id="keywords">
    <div class="mbox clearfix">
    <div class="searchkeyword">
    <div class="mt">
        <h2>热搜排行</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int qUTV_index=1;
List<Lebi_Searchkey> qUTVs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey qUTV in qUTVs){%>
        <li><%if (qUTV.Type==1){ %><a href="<%=URL("P_Search",""+Lang(qUTV.Name)+"") %>"><%}else{ %><a href="<%=qUTV.URL%>"><%} %><%=Lang(qUTV.Name)%></a></li>
        <%qUTV_index++;}%>
    </ul>
    </div>
    </div>
    </div>
    <div class="mbox clearfix">
    <div class="searchbrand">
    <div class="mt">
        <h2>品牌推荐</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Brand";Where="IsRecommend=1";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int vvpN_index=1;
List<Lebi_Brand> vvpNs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand vvpN in vvpNs){%>
        <li><a href="<%=URL("P_Brand",vvpN.id)%>" title="<%=Lang(vvpN.Name) %>"><%=Lang(vvpN.Name) %></a></li>
        <%vvpN_index++;}%>
    </ul>
    </div>
    </div>
    </div>
</div>
</div>

        </div>
        <div class="footmenu">
	        

<div class="nbbox clearfix">
<div class="quickmenu">
<div class="mc clearfix">
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_Index", "")%>">首页</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_Basket", "")%>">购物车 (<em><%=Basket_Product_Count() %></em>)</a></h3><s></s></span></div>
   <%if(CurrentUser.id>0){ %>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserCenter", "")%>">会员中心</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserOrders", "")%>">我的订单</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserCard", "")%>">我的卡券</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserLike", "")%>">我的收藏</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserOftenBuy", "")%>">常购清单</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserComment", "")%>">商品评价 (<em><%=Count_Comment(0) %></em>)</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserAsk", "")%>">商品咨询 (<em><%=Count_ProductAsk(0) %></em>)</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserMessage","0")%>">站内信 (<em><%=Count_Message(0) %></em>)</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserProfile", "")%>">资料管理</a></h3><s></s></span></div>
   <%if (Shop.Bussiness.B_API.Check("plugin_agent")){ %>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserAgent","")%>">推广佣金</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserAgentMoney","")%>">佣金查询</a></h3><s></s></span></div>
   <%} %>
   <%}else{ %>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_Login", "")%>">会员登录</a></h3><s></s></span></div>
   <%} %>
	<%Table="Lebi_Page";Where="Node_id="+Node("FootMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int lmtk_index=1;
List<Lebi_Page> lmtks = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page lmtk in lmtks){%>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("","",lmtk.url)%>"><%=lmtk.Name%></a></h3><s></s></span></div>
	<%lmtk_index++;}%>
    <div class="item last"><span class="itemname"><h3><a href="">完整网站</a></h3><s></s></span></div>
</div>
</div>
</div>

        </div>
    </div>
    
<div id="footer" class="clearfix">
    <div class="copyright">
        <%=Lang(SYS.Copyright) %>
    </div>
    <div class="lang">
        

<div class="language">
<%List<Shop.Model.Lebi_Language> PVvzs=Languages();RecordCount=PVvzs.Count;int PVvz_index=1;
foreach (Shop.Model.Lebi_Language PVvz in PVvzs){%>
<a <%if (PVvz_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=PVvz.id%>,'<%=PVvz.Code%>','<%=PVvz.Path%>');"><img src="<%=Image(PVvz.ImageUrl) %>" title="<%=PVvz.Name%>" /><%=PVvz.Name%></a>
<%PVvz_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int AXmu_index=1;
List<Lebi_Currency> AXmus = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency AXmu in AXmus){%>
<dd <%if (AXmu_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=AXmu.id%>,'<%=AXmu.Code%>',<%=AXmu.ExchangeRate%>,'<%=AXmu.Msige%>');"><%=AXmu.Code%></a></dd>
<%AXmu_index++;}%>
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