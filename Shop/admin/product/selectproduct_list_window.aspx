<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.selectproduct_list_window" validateRequest="false"%>

    <%foreach (Shop.Model.Lebi_Product model in products)
          {
            //Shop.Model.Lebi_Product pro=Shop.Bussiness.B_Lebi_Product.GetModel(model.Product_id);
            //if(pro==null)
            //    pro=new Shop.Model.Lebi_Product();
    %>
    <tr class="list" ondblclick="selectproductone(<%=model.id %>,'<%=model.Number%>');">
        <td style="text-align:center">
            <a target="_blank" href="<%=Shop.Bussiness.ThemeUrl.GetURL(" P_Product",model.id.ToString(),"",CurrentLanguage.Code)%>">
                <img src="<%=Image(model.ImageOriginal,30,30) %>" style="max-width:30px;max-height:30px;" />
            </a>
        </td>
        <td>
            <%=model.Number %>&nbsp;
        </td>
        <td style="width:400px;word-wrap: break-word;">
            <%=Lebi.ERP.other.substring(Lang(model.Name),20) %>&nbsp;
        </td>
        <td>
            <%=Lebi.ERP.other.substring(Shop.Bussiness.EX_Product.ProPertyNameStr(model.ProPerty131,CurrentLanguage.Code),5) %>&nbsp;
        </td>
        <td>
            <%=GetUnitName(model.Units_id) %>&nbsp;
        </td>
    </tr>
    <%} %>
    <tr>
    <td colspan="7">
    <%=PageString %>
    </td>
    </tr>

  