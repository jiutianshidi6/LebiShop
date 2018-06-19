<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Pay" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_Pay"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_Pay","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_Pay","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Pay","description")%>" />
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
	<h2 id="pagename"><%=ThemePageMeta("P_Pay","title")%></h2>
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
            


<div id="pay">
    <div class="nbbox clearfix">
        <div class="userbox">
            <div class="mt clearfix">
                <h2>
                    在线付款</h2>
            </div>
            <div class="mc clearfix">
                <div class="dl-table clearfix">
                    <dl>
                        <dt>订单号码：</dt>
                        <dd>
                            <%=order.Code %></dd>
                    </dl>
                    
                    <dl>
                        <dt>应付金额：</dt>
                        <dd>
                            <span class="price">
                                <%=FormatMoney((order.Money_Pay),order.Currency_id)%></span></dd>
                    </dl>
                    <dl>
                        <dt>支付方式：</dt>
                        <dd>
                            <%
                            bool weixinqrcode=false;
                            int onlinepay_id = 0;
                            foreach(Shop.Model.Lebi_OnlinePay opm in onlinepays){ 
                            
                            Shop.Model.Lebi_OnlinePay op=Getpay(opm);
                            onlinepay_id = op.id;
                            if(op==null)
                                continue;
                            if(op.Code=="weixinpay")
                                weixinqrcode=true;
                            %>
                            <input type="radio" name="onlinepay_id" money="<%=FormatMoneyValue((order.Money_Pay*(1+(op.FeeRate/100))),op.Currency_Code)%>" value="<%=onlinepay_id %>" <%=op.id==order.OnlinePay_id?"checked":"" %> url="<%=op.Url %>" paytype="<%=op.Code %>" order="true" onclick="changepaytype();" />
                            <%=Lang(op.Name)%>(<%=op.Currency_Code %>:<%=FormatMoney((order.Money_Pay*(1+(op.FeeRate/100))),op.Currency_id)%>
                            <%if (op.FeeRate > 0){ %>&nbsp;&nbsp;<%=Tag("手续费")%>：<%=op.FeeRate%> %<%} %>) &nbsp;&nbsp;
                            <div id="show<%=op.Code %>" style="display:none;padding:10px 0 0 0;">
                                <%if(op.Code=="authroize"){%>
                                <img alt="Visa Checkout" class="v-button" role="button" src="https://sandbox.secure.checkout.visa.com/wallet-services-web/xo/button.png" />
                                <%}%>
                            </div>
                            <br>
                            <%}%></dd>
                    </dl>
                    <dl class="dl-btn">
                        <dt></dt>
                        <dd>
                            <%
                            string mes = "";
                            foreach(Shop.Model.Lebi_Order_Product op in order_products){ 
                                Lebi_Product pro = EX_Product.GetProduct(op.Product_id);
                                if (pro == null || pro.Type_id_ProductStatus != 101){
                                    mes += Lang(op.Product_Name) + " " + Tag("该商品已经下架") +"<br/>";
                                }
                            }
                            if (mes == ""){
                            %>
                            <a id="nowpay" href="javascript:void(0)" onclick="pay();" class="btn btn-7"><s></s>立即付款</a>
                            <%}else{%>
                            <%=mes %>
                            <%} %>
                        </dd>
                    </dl>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function pay() {
        var obj = $("input[name='onlinepay_id']:checked");
        var url = obj.attr("url");
        if (url == undefined) {
            alert('<%=Tag("请选择付款方式！") %>');
            return false;
        }
        var id = obj.val();
        window.location = path + url + "?order_id=<%=order_id %>&opid=" + id;
    }
    var ischeck=false;
    var Isweixin = <%=Isweixin.ToString().ToLower()%>;
    var weixinqrcode = <%=weixinqrcode.ToString().ToLower()%>;
    var pagefrom = "<%=pagefrom%>";
    function changepaytype(){
        var obj = $("input[name='onlinepay_id']:checked");
        var paytype=obj.attr('paytype');
        if(paytype=='weixinpay'){
            <%if(!Isweixin){ %>
                var img='<img src="'+path+'/inc/qrcode.aspx?txt=<%=weixinpay.NativePay.GetPayUrl(order.id.ToString()) %>" style="width:220px;"/>';
                $('#show'+paytype).html(img+'<br/>请使用微信“扫一扫”功能，扫描以上二维码完成支付。');
                $('#show'+paytype).show();
                $('#nowpay').hide();
            <%}%>
            if(ischeck==false){
                ischeck=true;
                setInterval("checkorderpaid()",3000);
            }
        }
        else if(paytype=='authroize'){
            visamoney=obj.attr('money');
            $('#show'+paytype).show();
            $('#nowpay').hide();
        }
        else{
            $('#showweixinpay').hide();
            $('#nowpay').show();
        }
    }
    function checkorderpaid(){
        $.ajax({
		    type : 'POST',
		    url : path + "/ajax/ajax.aspx?__Action=IsOrderPaid&id=<%=order_id %>",
		    data : '',
		    dataType : 'json',
		    success : function(data) {
			   if(data.msg=="OK"){
                    window.location = '<%=URL("P_UserOrderDetails",order_id)%>';
               }
		    }
	    });
    }
    changepaytype();
    if (Isweixin && weixinqrcode){

    }else{
        if (pagefrom == "cashier"){
            $("#pay").hide();MsgBox(1, "正在提交……", pay());
        }
    }
</script>

 <%if(IsPayShow("authroize")){%>
<script type="text/javascript">
    var visamoney=0;
    function onVisaCheckoutReady(){
        V.init({
            apikey: "<%=GetPay("authroize").UserKey%>",
            paymentRequest:{
            currencyCode: "USD",
            total: visamoney
            }
        });
        V.on("payment.success", function(payment)
        {
            console.log(JSON.stringify(payment));
            //{"encKey":"...",
            //"encPaymentData":"...",
            //"callid":"...",
            //"paymentRequest":{
            //    "apikey":"...",
            //    "paymentRequest":{
            //        "currencyCode":"USD",
            //        "total":"10.00"},
            //        "parentUrl":"http://....html"
            //}}
            $.ajax({
                type : 'POST',
                url : path + "onlinepay/authroizeVisa/default.aspx",
                data : {'order_id':<%=order.id%>,'datakey':payment.encKey,'datavalue':payment.encPaymentData,'callid':payment.callid},
                dataType : 'json',
                success : function(res) {
                    console.log(JSON.stringify(res));
                    if(res.status=="error"){
                        alert(res.msg);
                    }else{
                        window.location = '<%=URL("P_UserOrderDetails",order_id)%>';
                    }
                }
            });

        });
        V.on("payment.cancel", function(payment)
        {
            console.log(JSON.stringify(payment));
        });
        V.on("payment.error", function(payment, error)
        {
            console.log(JSON.stringify(payment));
            console.log(JSON.stringify(error));
            //alert('<%=Tag("付款失败")%>');
        });
    }
</script>
<script type="text/javascript" src="https://assets.secure.checkout.visa.com/checkout-widget/resources/js/integration/v1/sdk.js"></script>
<%}%>



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