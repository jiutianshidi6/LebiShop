<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.supplier.product.subproduct_list" validateRequest="false"%>

<%foreach (Shop.Model.Lebi_Product model in models)
    {%>
<tr class="list" ondblclick="Editsonproduct(<%=model.id %>);">
    <td align="center">
        <input type="checkbox" shopkeyid="true" name="sonproductid" value="<%=model.id %>"
            id="<%=model.id %>" />
    </td>
    <td>
        <%if (model.ImageSmall != "")
            {%><img style="height: 30px; width: 30px; vertical-align: middle" src='<%=WebPath + model.ImageSmall %>' /><%}else{%>&nbsp;<%} %>
    </td>
    <td>
        <input type="text" name="Number<%=model.id %>" id="Number<%=model.Number %>" class="input"
            sonproduct="true" value="<%=model.Number %>" style="width: 80px;" />
    </td>
    <td>
        <%=getproperty(model.ProPerty131) %>
    </td>
    <td>
        <a href="javascript:void(0)" title="<%=Tag("点击编辑商品名称")%>" onclick="Product_Name_Edit(<%=model.id %>);">
            <%if (Shop.Bussiness.Language.Content(model.Name, CurrentLanguage.Code) != "") { Response.Write(Shop.Bussiness.Language.Content(model.Name, CurrentLanguage.Code)); } else { Response.Write(Tag("编辑")); }%></a>&nbsp;<%if (pid > 0){%><a target="_blank" href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_Product",model.id.ToString(),"",CurrentLanguage)%>"><img src="<%=PageImage("icon/newWindow.png")%>" /></a><%} %>
    </td>
    <td>
        <input type="text" name="Price_Market<%=model.id %>" id="Price_Market<%=model.id %>" class="input" sonproduct="true" value="<%=model.Price_Market %>" style="width: 80px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
    </td>
    <td>
       <%if (CurrentSupplierGroup.IsSubmit == 0)
         { %>
        <%=model.Price %>
        <%}
         else
         { %>
        <input type="text" name="Price<%=model.id %>" id="Price<%=model.id %>" class="input"
            sonproduct="true" value="<%=model.Price %>" style="width: 80px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
        <%} %>
    </td>
    <td>
        <input type="text" name="Price_Cost<%=model.id %>" id="Price_Cost<%=model.id %>"
            class="input" sonproduct="true" value="<%=model.Price_Cost %>" style="width: 80px;"
            onkeyup="value=value.replace(/[^\d\.]/g,'')" />
    </td>
    <td>
        <input type="text" name="Count_Stock<%=model.id %>" id="Count_Stock<%=model.id %>"
            class="input" sonproduct="true" value="<%=model.Count_Stock %>" style="width: 80px;"
            onkeyup="value=value.replace(/[^\d]/g,'')" />
    </td>
    <td>
       <%if (CurrentSupplierGroup.IsSubmit == 0)
         { %>
        <%=model.Count_Freeze%>
        <%}
         else
         { %>
        <input type="text" name="Count_Freeze<%=model.id %>" id="Count_Freeze<%=model.id %>"
            class="input" sonproduct="true" value="<%=model.Count_Freeze %>" style="width: 80px;"
            onkeyup="value=value.replace(/[^\d]/g,'')" />
        <%} %>
    </td>
    
    <td>
        <%=Shop.Bussiness.EX_Type.TypeName(model.Type_id_ProductStatus,CurrentLanguage.Code)%>
    </td>
    <td>
        <a href="subproduct_edit_all.aspx?id=<%=model.id %>"><%=Tag("编辑")%></a>
    </td>
</tr>
<%} %>

  