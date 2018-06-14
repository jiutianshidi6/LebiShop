

<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Bussiness.ShopPage" %>
<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_30",1,"CN",""); %>

<ul class="image">
    <% 
        foreach (Shop.Model.Lebi_User_Product p in History_Product(10))
        {
            Shop.Model.Lebi_Product productmodel = GetProduct(p.Product_id);
            if (productmodel.id == 0)
                continue;
    %>
    <li>
        <div class="proimg"><p><a href="<%=URL("P_Product",p.Product_id) %>" target="_blank"><img border="0" src="<%=Image(productmodel.ImageOriginal,"small") %>" alt="<%=Lang(productmodel.Name) %>" /></a></p></div>
        <div class="proinfo">
        <div class="proname"><a href="<%=URL("P_Product",p.Product_id) %>" title="<%=Lang(productmodel.Name) %>" target="_blank"><%=Lang(productmodel.Name) %></a></div>
        <div class="proprice"><div class="marketprice"><i>市场价：</i><strong><%=FormatMoney(productmodel.Price_Market) %></strong></div><%if (productmodel.Type_id_ProductType == 321 && System.DateTime.Now < productmodel.Time_Expired){%><div class="buyprice"><i>抢购价：</i><strong><%=FormatMoney(productmodel.Price_Sale) %></strong></div><%} else{ %><div class="buyprice"><i><%=Lang(CurrentUserLevel.PriceName) %>：</i><strong><%=FormatMoney(ProductPrice(productmodel)) %></strong></div><%} %></div></div>
    </li>
    <%        
        }
    %>
</ul>