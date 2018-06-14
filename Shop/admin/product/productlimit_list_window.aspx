<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.product.productlimit_list_window" validateRequest="false"%>

    <%foreach (Shop.Model.Lebi_Product model in products)
          {
            Shop.Model.Lebi_Product_Limit limit=GetLimitInfo(model.id);
           
    %>
    <tr class="list" ondblclick="selectproductone(<%=model.id %>,'<%=model.Number%>');">
        <td style="text-align:center">
            <img src="<%=Image(model.ImageOriginal,30,30) %>" style="max-width:30px;max-height:30px;"/>
        </td>
        <td>
            <%=model.Number %>&nbsp;
        </td>
        <td style="word-wrap: break-word;">
            <%=Lebi.ERP.other.substring(Lang(model.Name),20) %>&nbsp;
        </td>
        <td>
            <%=GetUnitName(model.Units_id) %>&nbsp;
        </td>
        <td>
            <input type="checkbox" name="IsShow<%=model.id%>"  cname="IsShow" value="1" limit="true" <%=limit.IsShow==1?"checked":""%> />
        </td>
        <td>
            <input type="checkbox" name="IsPriceShow<%=model.id%>" cname="IsPriceShow" value="1" limit="true" <%=limit.IsPriceShow==1?"checked":""%> />
        </td>
        <td>
            <input type="checkbox" name="IsBuy<%=model.id%>" cname="IsBuy" value="1" limit="true" <%=limit.IsBuy==1?"checked":""%> />
            <input type="hidden" name="limitproductid" value="<%=model.id%>" limit="true" />
        </td>
    </tr>
    <%} %>
    <tr>
    <td colspan="7">
    <%=PageString %>
    </td>
    </tr>

  