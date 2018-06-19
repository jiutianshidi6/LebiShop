<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.product.subproduct_list" validateRequest="false"%>

<%foreach (Shop.Model.Lebi_Product model in models)
    {%>
<tr class="list" ondblclick="Editsonproduct(<%=model.id %>);">
    <td style="text-align:center">
        <input type="checkbox" shopkeyid="true" name="sonproductid" value="<%=model.id %>" id="<%=model.id %>" />
    </td>
    <%if (mutiadd_property == 0){ %>
    <td>
        <%if (model.ImageOriginal != "")
            {%><a href="<%=Image(model.ImageOriginal,"big") %>" data-lightbox="image-list"><img style="height: 30px; width: 30px; vertical-align: middle" src="<%=Image(model.ImageOriginal,"small") %>" /></a><%}else{%>&nbsp;<%} %>
    </td>
    <%} %>
    <td>
        <input type="text" name="Number<%=model.id %>" id="Number<%=model.Number %>" class="input" sonproduct="true" value="<%=model.Number %>" style="width: 100px;" />
    </td>
    <td>
        <%=getproperty(model.ProPerty131) %>
    </td>
    <%if (mutiadd_property == 0){ %>
    <td>
        <a href="javascript:void(0)" title="<%=Tag("点击编辑商品名称")%>" onclick="Product_Name_Edit(<%=model.id %>);">
            <%if (Shop.Bussiness.Language.Content(model.Name, CurrentLanguage.Code) != "") { Response.Write(Shop.Tools.Utils.GetUnicodeSubString(Shop.Bussiness.Language.Content(model.Name, CurrentLanguage.Code),40, "...")); } else { Response.Write(Tag("编辑")); }%></a>&nbsp;<%if (pid > 0){%><a target="_blank" href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_Product",model.id.ToString(),"",CurrentLanguage.Code)%>"><img src="<%=PageImage("icon/newWindow.png")%>" /></a><%} %>
    </td>
    <%} %>
    <td>
    <%if (mutiadd_property == 1){ %>
    <select name="Operators_Price_Market<%=model.id %>" id="Operators_Price_Market<%=model.id %>" sonproduct="true"><option value="+">+</option><option value="×">×</option><option value=""></option></select>
    <%} %>
        <input type="text" name="Price_Market<%=model.id %>" id="Price_Market<%=model.id %>" class="input" sonproduct="true" value="<%if (model.Price_Market!=0){Response.Write(FormatMoney(model.Price_Market,"Number"));}%>" style="width: 70px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
    </td>
    <td>
    <%if (mutiadd_property == 1){ %>
    <select name="Operators_Price<%=model.id %>" id="Operators_Price<%=model.id %>" sonproduct="true"><option value="+">+</option><option value="×">×</option><option value=""></option></select>
    <%} %>
        <input type="text" name="Price<%=model.id %>" id="Price<%=model.id %>" class="input" sonproduct="true" value="<%if (model.Price!=0){Response.Write(FormatMoney(model.Price,"Number"));}%>" style="width: 70px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
    </td>
    <%if (modelp.Type_id_ProductType == 321||modelp.Type_id_ProductType == 322||modelp.Type_id_ProductType == 323)
      { %>
    <td>
        <input type="text" name="Price_Sale<%=model.id %>" id="Price_Sale<%=model.id %>" class="input" sonproduct="true" value="<%if (model.Price_Sale!=0){Response.Write(FormatMoney(model.Price_Sale,"Number"));}%>" style="width: 70px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
    </td>
    <%} %>
    <%if (Shop.Bussiness.EX_Admin.CheckPower("product_price_cost")){ %>
    <td>
    <%if (mutiadd_property == 1){ %>
    <select name="Operators_Price_Cost<%=model.id %>" id="Operators_Price_Cost<%=model.id %>" sonproduct="true"><option value="+">+</option><option value="×">×</option><option value=""></option></select>
    <%} %>
        <input type="text" name="Price_Cost<%=model.id %>" id="Price_Cost<%=model.id %>" class="input" sonproduct="true" value="<%if (model.Price_Cost!=0){Response.Write(FormatMoney(model.Price_Cost,"Number"));}%>" style="width: 70px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
    </td>
    <%} %>
    <td>
    <%if (mutiadd_property == 1){ %>
    <select name="Operators_Count_Stock<%=model.id %>" id="Operators_Count_Stock<%=model.id %>" sonproduct="true"><option value="+">+</option><option value="×">×</option><option value=""></option></select>
    <%} %>
         <%if (IsEditStock){ %>
         <input type="text" name="Count_Stock<%=model.id %>" id="Count_Stock<%=model.id %>" class="input" sonproduct="true" value="<%=model.Count_Stock %>" style="width: 50px;" onkeyup="value=value.replace(/[^\d]/g,'')" />
        <%}else{ %>
        <%=model.Count_Stock %>
        <%} %>
    </td>
    <%if (mutiadd_property == 0){ %>
    <td>
        <input type="text" name="Count_Freeze<%=model.id %>" id="Count_Freeze<%=model.id %>" class="input" sonproduct="true" value="<%=model.Count_Freeze %>" style="width: 50px;" onkeyup="value=value.replace(/[^\d]/g,'')" />
    </td>
    <td>
        <%=model.Count_Sales %>
    </td>
    <td>
        <input type="text" name="Count_Sales_Show<%=model.id %>" id="Count_Sales_Show<%=model.id %>" class="input" sonproduct="true" value="<%=model.Count_Sales_Show %>" style="width: 50px;" onkeyup="value=value.replace(/[^\d]/g,'')" />
    </td>
    <%} %>
    <td>
        <select name="Type_id_ProductStatus<%=model.id %>" id="Type_id_ProductStatus<%=model.id %>" sonproduct="true">
            <%=Shop.Bussiness.EX_Type.TypeOption("ProductStatus", model.Type_id_ProductStatus, CurrentLanguage)%>
        </select>
    </td>
    <%if (mutiadd_property == 0){ %>
    <td>
        
        <a href="product_edit.aspx?id=<%=model.id %>"><%=Tag("编辑")%></a>
    </td>
    <%} %>
</tr>
<%} %>

  