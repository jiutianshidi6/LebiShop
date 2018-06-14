<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.store_shipping_window" validateRequest="false"%>

    <table class="datalist">
        <tr class="title">
            <th>
                <%=Tag("产品")%>
            </th>
            <th style="width: 80px">
                <%=Tag("发货数量")%>
            </th>
            <th style="width: 80px">
                <%=Tag("当前库存")%>
            </th>
        </tr>
        <%foreach (Shop.Model.TransportProduct tp in tps)
        { %>
        <tr class="list">
            <td>
                <img src="<%=WebPath + tp.ImageSmall %>" style="width: 30px" />
                <%=tp.Product_Number %>,
                <%=Shop.Bussiness.Language.Content(tp.Product_Name, CurrentLanguage)%>
            </td>
            <td>
                <%=tp.Count%>
            </td>
            <td><%=Lebi.ERP.other.GetStoreCount(torder.LebiERP_store_id, tp.Product_id) %></td>
        </tr>
        <%} %>
    </table>
    <table class="table">
        <tr>
            <th style="width: 15%">
                <%=Tag("发货仓")%>：
            </th>
            <td>
                <%=torder.LebiERP_store_Name%>
            </td>
        </tr>
        <tr>
            <th style="width: 15%">
                <%=Tag("配送方式")%>：
            </th>
            <td>
                <select Shipping="true" name="Transport_id" id="Transport_id" disabled>
                    <%=Shop.Bussiness.EX_Area.TransportOption(torder.Transport_id) %>
                </select>
                
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("货运单号")%>：
            </th>
            <td>
                <%=torder.Code %>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("实际运费")%><%=DefaultCurrency.Msige %>：
            </th>
            <td>
                <%=torder.Money %>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("收/发货人")%>：
            </th>
            <td>
                <%=torder.T_Name %>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("电话")%>：
            </th>
            <td>
                <%=torder.T_Phone %>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("手机")%>：
            </th>
            <td>
                <%=torder.T_MobilePhone %>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("EMAIL")%>：
            </th>
            <td>
                <%=torder.T_Email %>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("地址")%>：
            </th>
            <td>
                <%=torder.T_Address %>
            </td>
        </tr>
        
    </table>
    <script type="text/javascript">
    function Shipping() {
        var postData = GetFormJsonData("Shipping");
        var url = "<%=site.AdminPath %>/ajax/ajax_erp.aspx?__Action=store_fahuo&id=<%=torder.id %>";
        RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "")});
    }
    </script>

  