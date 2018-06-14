<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.checkout_product_list_window" validateRequest="false"%>

    <%foreach (Shop.Model.Lebi_Order_Product model in products)
          {
            Shop.Model.Lebi_Product pro=Shop.Bussiness.B_Lebi_Product.GetModel(model.Product_id);
            if(pro==null)
                pro=new Shop.Model.Lebi_Product();
    %>
    <tr class="list">
        <td>
            <input type="checkbox" name="proid" value="<%=model.id%>" del="true">
        </td>
        <td style="text-align:center">
            <a target="_blank" href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_Product",pro.id.ToString(),"",CurrentLanguage.Code)%>"><img src="<%=Image(model.ImageOriginal,50,50) %>" style="max-width:30px;max-height:30px;" /></a>
</td>
        <td>
            <%=pro.Number %>&nbsp;
        </td>
        <td style="word-wrap: break-word;">
            <a target="_blank" href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_Product",pro.id.ToString(),"",CurrentLanguage.Code)%>"> [<%=Shop.Bussiness.EX_Type.TypeName(pro.Type_id_ProductType,CurrentLanguage.Code) %>]<%=Sub(Lang(pro.Name),15) %></a>&nbsp;
</td>
        <td>
            <% 
            string gg=Shop.Bussiness.EX_Product.ProPertyNameStr(pro.ProPerty131,CurrentLanguage.Code);
            Response.Write(gg.Length > 5 ? (gg.Substring(0,5)+".."):gg);
            %>&nbsp;
        </td>
        
        <td>
            <%=GetUnitName(pro.Units_id) %>&nbsp;
        </td>
        <td>
            <%=Lebi.ERP.Store.ProductStockForAdmin(pro)%>&nbsp;
        </td>
        <td>
            <%=GetPrice(model,pro).ToString("0.00") %>&nbsp;
        </td>
        <%if(IsTuiHuo){%>
        <td>
            <%=model.Count_Received%>&nbsp;
        </td>
        <td>
            <%=model.Count_Return %>&nbsp;
        </td>
        <%}%>
        <td>
            <input type="text" value="<%=model.Count%>" onchange="saveorder();inputmax('opcount<%=model.id%>', <%=model.Count_Received-model.Count_Return%>)" name="opcount" id="opcount<%=model.id%>" shoporder="true" style="width:60px;" onkeyup="value=value.replace(/[^\d\.]/g, '')"/>
        </td>
    </tr>
    <%} %>


  