<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.supplier.product.product_Edit_part" validateRequest="false"%>

<%
    foreach (Shop.Model.Lebi_ProPerty pro in pros)
    {
%>
<tr>
    <th>
        <%=Shop.Bussiness.Language.Content(pro.Name, CurrentLanguage.Code)%>：
    </th>
    <td>
        <%=GetproList(pro) %>
    </td>
</tr>
<%
    }
%>

  