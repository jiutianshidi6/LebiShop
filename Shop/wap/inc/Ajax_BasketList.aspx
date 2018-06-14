

<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Bussiness.ShopPage" %>
<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_30",1,"CN","BasketList"); %>

<ul class="image">
<% 
    Basket basket = new Basket();
    foreach (Shop.Model.Lebi_User_Product p in basket.Products)
    {
        Shop.Model.Lebi_Product model = GetProduct(p.Product_id);
%>
    <li>
        <div class="proimg"><p><a href="<%=URL("P_Product",model.id) %>" target="_blank"><img border="0" src="<%=Image(model.ImageSmall)%>" alt="<%=Lang(model.Name) %>" /></a></p></div>
        <div class="proinfo">
        <div class="proname"><a href="<%=URL("P_Product",model.id) %>" title="<%=Lang(model.Name) %>" target="_blank"><%=Lang(model.Name) %></a></div>
        <div class="proprice"><div class="qty"><i>数量：</i><span><%=p.count %></span></div><div class="buyprice"><i>价格：</i><span><%=FormatMoney(p.Product_Price) %></span></div></div></div>
    </li>
    <%        
        }
    %>
</ul>