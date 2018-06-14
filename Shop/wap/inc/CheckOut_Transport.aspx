<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.inc.CheckOut_Transport" validateRequest="false"%>
<div style="<%=havedefault?"": "display:none;" %>" id="transport_show">
<div class="dl-table clearfix">
    <%foreach (Shop.Model.BasketShop shop in Shops)
      {
          if (shop.Shop.id > 0)
          {
              Response.Write("<tr><th><span class=\"shopname\">" + Lang(shop.Shop.Name) + "</span></th></tr>");
          }
          else { 
            if(basket.Shops.Count>1)
                Response.Write("<tr><th><span class=\"shopname\">" + Tag("自营") + "</span></th></tr>");
          }
    %>
    <dl>
        <dt><%=GetTransport(shop.Shop.id).Name%></dt>
        <dd><%=Tag("运费")%>：<%=FormatMoney(GetYunFei(shop))%>
            [<a class="click" href="javascript:Edittransport();"><%=Tag("修改")%></a>]
            <input type="text" name="money_transport" value="<%=GetYunFei(shop)%>" style="display: none" />
        </dd>
    </dl>
    <%} %>
</div>
</div>
<div style="<%=havedefault==false?"": "display:none;" %>" id="transport_edit">
<div class="dl-table clearfix">
    <%foreach (Shop.Model.BasketShop shop in basket.Shops)
      {
          if (shop.Shop.id > 0) {
              Response.Write("<dl><dd class=\"title\"><span class=\"shopname\">" + Lang(shop.Shop.Name) + "</span></dd></dl>");
          }
          else
          {
              if (basket.Shops.Count > 1)
                  Response.Write("<dl><dd class=\"title\"><span class=\"shopname\">" + Tag("自营") + "</span></dd></dl>");
          }
          List<Shop.Model.Lebi_Transport_Price> TPrices = GetTPrices(address.Area_id, shop.Shop.id);
          if (TPrices.Count == 0)
          {
              Response.Write("<dl><dd class=\"title\">" + Tag("不在配送区域，无法送达") + "</dd></dl>");
              Response.End();
          }
          int checkedid = GetRadioCheckedId(TPrices);
          foreach (Shop.Model.Lebi_Transport_Price model in TPrices)
          {
              Shop.Model.Lebi_Transport Tran = Shop.Bussiness.B_Lebi_Transport.GetModel(model.Transport_id);
              if (Transport == null)
                  continue;

    %>
    <dl>
        <dt><label><input type="radio" name="transport_id<%=shop.Shop.id %>" value="<%=model.id %>" order="true" <%=checkedid==model.id?"checked":"" %> /> <%=Tran.Name%></dt>
        <dd><%=Tag("运费")%>：<%=FormatMoney(GetYunFei(model, shop))%></dd></dd>
        <dd class="list"><em><%=Tran.Description%></em></dd>
    </dl>
    <%}
      }%>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0);" onclick="Settransport();" class="btn btn-7"><s></s><%=Tag("确定")%></a></dd>
    </dl>
</div>
</div>
<script type="text/javascript">
    LoadPage("<%=WebPath%>/inc/CheckOut_Pay.aspx?sid=<%=sid %>", "checkout_pay");
    Setmoney(<%=sid %>); //计算总金额
    <%if(havedefault==false){ %>
    HighlightDiv("transport_edit");
    <%} %>
    function Settransport() {
        var transport_id = '';
        var id='';
        <%foreach (Shop.Model.BasketShop shop in basket.Shops)
        {
        %>
        id = $("input[name='transport_id<%=shop.Shop.id %>']:checked").val();
        if(id!=undefined)
            transport_id=transport_id+','+id;
        <%}%>
        
        var postData = { "transport_id": transport_id };
        var url = path+"/ajax/ajax_order.aspx?__Action=transport_Set";
        RequestAjax(url, postData, function (res) { 
            LoadPage("<%=WebPath%>/inc/CheckOut_Transport.aspx?sid=<%=sid %>", "checkout_transport");
            LoadPage("<%=WebPath%>/inc/CheckOut_Pay.aspx?sid=<%=sid %>", "checkout_pay");
            MsgBoxClose("","error");
            HighlightDivHide();
        });
    }
</script>
