<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.selectproduct_list_window" validateRequest="false"%>

    <%foreach (Shop.Model.Lebi_Product model in products)
          {
            //Shop.Model.Lebi_Product pro=Shop.Bussiness.B_Lebi_Product.GetModel(model.Product_id);
            //if(pro==null)
            //    pro=new Shop.Model.Lebi_Product();
    %>
    <tr class="list" ondblclick="selectproductone(<%=model.id %>,'<%=model.Number%>');">
        <td>
            <input type="checkbox" name="pids" value="<%=model.id%>" orderp="true" onchange="checkboxchange('pids');">
        </td>
        <td style="text-align:center">
            <a target="_blank" href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_Product",model.id.ToString(),"",CurrentLanguage.Code)%>">
                <img src="<%=Image(model.ImageOriginal,30,30) %>" style="max-width:30px;max-height:30px;"/>
            </a>
        </td>
        <td>
            <%=model.Number %>&nbsp;
        </td>
        <td style="word-wrap: break-word;">
            <%=Lebi.ERP.other.substring(Lang(model.Name),20) %>&nbsp;
        </td>
        <td>
            <%//=Lebi.ERP.other.substring(Shop.Bussiness.EX_Product.ProPertyNameStr(model.ProPerty131,CurrentLanguage.Code),5) %>&nbsp;
            <%=Lebi.ERP.other.substring(model.Code,20) %>&nbsp;
        </td>
        <td>
            <a title="<%=storestock(model.id)%>"><%=Lebi.ERP.Store.ProductStockForAdmin(model)%></a>&nbsp;
        </td>
        <td>
            <%=model.Price %>&nbsp;
        </td>
        <td>
            <%=GetUnitName(model.Units_id) %>&nbsp;
        </td>
    </tr>
    <%} %>
    <tr>
    <td colspan="7">
        <script type="text/javascript">
            $(function () {
                var sids = selectlist_getids();
                sids = ',' + sids + ',';
                var os = document.getElementsByName('pids');
                for (var i = 0; i < os.length; i++) {
                    if (sids.indexOf(',' + os[i].value + ',') > -1)
                        os[i].checked=true;
                    
                }
            });

        </script>
    </td>
    </tr>
    <tr>
    <td colspan="7">
    <%=PageString %>
    </td>
    </tr>

  