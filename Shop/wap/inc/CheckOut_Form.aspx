<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.inc.order_form" validateRequest="false"%>
<ul>
    <li><span><%=Tag("商品总额")%>：</span><%=FormatMoney(basket.Money_Product)%></li>
    <%if (money_transport!=0){%>
    <li><span>+ <%=Tag("运费")%>：</span><%=FormatMoney(money_transport)%></li>
    <%} %>
    <%if (money_bill>0){%>
    <li><span>+ <%=Tag("税金")%>：</span><%=FormatMoney(money_bill)%></li>
    <%} %>
     <%if (basket.Money_Property > 0)
       {%>
    <li><span>+ <%=Tag("其它费用")%>：</span><%=FormatMoney(basket.Money_Property)%></li>
    <%} %>
    <%if (basket.Money_Cut > 0){%>
    <li><span>- <%=Tag("优惠")%>：</span><%=FormatMoney(basket.Money_Cut)%></li>
    <%} %>
    <%if (basket.Money_Give > 0){%>
    <li><span>- <%=Tag("返现")%>：</span><%=FormatMoney(basket.Money_Give)%></li>
    <%} %>
    <li id="dixian"><span>- <%=Tag("抵现")%>：</span><span id="show_moneydixian"><%=FormatMoney(0)%></span></li>
</ul>
<span class="clear"></span>
<div class="extra"><%=Tag("应付金额")%>：<span class="ftx04"><b id="show_moneypay"><%=FormatMoney(money_order)%></b></span></div>
<input type="hidden" id="money_order" name="money_order" value="<%=money_order %>" />
<%--var money_dixian=0;//抵现金额
var money_finish=0;//最终应付金额--%>