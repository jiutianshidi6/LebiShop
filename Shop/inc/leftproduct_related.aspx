<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.inc.product_related" validateRequest="false"%>
<%@ Import Namespace="Lebi.ERP" %>
<%
PLebi_User CurrentSonUser=Lebi.ERP.User.GetCurrentSonUser();
if(!CurrentSonUser.lebierp_UserLimit.Contains("showprice"))
CurrentUserLevel.IsHidePrice=1;
if(!CurrentSonUser.lebierp_UserLimit.Contains("usemoney"))
CurrentUserLevel.BuyRight=0;
LoadPage();
%>


<ul class="image">
    <% 
        foreach (Shop.Model.Lebi_Product productmodel in products)
        {
            
    %>
    <li>
        <div class="image">
            <p><a href="<%=URL("P_Product",productmodel.id) %>"><img src="<%=Image(productmodel.ImageOriginal,"medium") %>" alt="<%=Lang(productmodel.Name) %>" title="<%=Lang(productmodel.Name) %>" /></a></p>
        </div>
        <div class="name">
            <a href="<%=URL("P_Product",productmodel.id) %>" title="<%=Lang(productmodel.Name) %>"><%=Lang(productmodel.Name) %></a>
        </div>
        <%if (CurrentUser.id > 0 && CurrentUser.IsAnonymous==0)
        {%>
        <div class="">
             <%=Lang(CurrentUserLevel.PriceName) %>：<%=FormatMoney(ProductPrice(productmodel)) %>
        </div>
        <%}else{%>
        <div class="">
            <%=Tag("会员批发价")%>：
            <span style="color:red;">
                <%=Tag("登录可见") %></span>
        </div>
        <%}%>
    </li>
    <%        
        }
    %>
</ul>


  