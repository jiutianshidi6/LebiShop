<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.order.shipping_window" validateRequest="false"%>

<table class="datalist">
    <tr class="title">
        <th>
            <%=Tag("商品名称")%>
        </th>
        <th style="width: 80px">
            <%=Tag("待发数量")%>
        </th>
        <th style="width: 80px">
            <%=Tag("发货数量")%>
        </th>
    </tr>
    <%foreach (Shop.Model.Lebi_Order_Product pro in pros)
      {
          int dafa = pro.Count - pro.Count_Shipped;
          dafa = dafa < 0 ? 0 : dafa;
          %>
    <tr class="list">
        <td >
            <img src="<%=WebPath + pro.ImageSmall %>" style="width: 30px" />
            <%=Shop.Bussiness.Language.Content(pro.Product_Name,CurrentLanguage) %>
        </td>
        <td>
            <%=dafa%>
        </td>
        <td>
            <%if (pro.IsSupplierTransport != 1)
              { 
            if(pro.Type_id_OrderProductType!=256 || (pro.Type_id_OrderProductType==256 && pro.IsStockOK==1 && pro.IsPaid==1)){
            %>
            <input type="hidden" class="input" Shipping="true" name="Count<%=pro.id %>" id="Count<%=pro.id %>"
                value="<%=dafa%>" onkeyup="value=value.replace(/[^\d\.]/g,'')" style="width: 70px;" />
            <%=dafa%>
            <%}
            else
            {
                if(pro.IsStockOK==0)
                Response.Write(Tag("未备货"));
                if(pro.IsPaid==0)
                Response.Write(Tag("未付款"));
            }
            }
              else {
                  Response.Write(Tag("供应商发货"));
              } %>
        </td>
    </tr>
    <%} %>
</table>
<table class="table">
    <tr>
        <th>
            <%=Tag("发货仓库")%><%=DefaultCurrency.Msige %>：
        </th>
        <td>
            <select id="store_id" name="store_id" Shipping="true" class="input fromstore" >
                  <%=Lebi.ERP.other.storeoptionsAll(0) %>
            </select>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="action">
            <div class="tools tools-m">
                <ul>
                    <li class="submit"><a href="javascript:void(0);" onclick="Shipping();"><b></b><span><%=Tag("保存")%></span></a></li>
                </ul>
            </div>
        </td>
    </tr>
</table>
<script type="text/javascript">
    function Shipping() {
        if (!CheckForm("Shipping", "span"))
            return false;
        var postData = GetFormJsonData("Shipping");
        var url = "<%=site.AdminPath %>/ajax/ajax_erp.aspx?__Action=Order_fahuo&id=<%=model.id %>";
        RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
    }
</script>

  