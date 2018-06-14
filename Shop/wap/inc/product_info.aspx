<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.inc.product_info" validateRequest="false"%>
<script type="text/JavaScript">
    $(document).ready(function () {
        $(".time_expired").each(function () {
            var endDate = $(this).attr("endDate");
            var productId = $(this).attr("Product");
            var _countdown = new CountDown();
            _countdown.init({
                id: 'time_expired_' + productId,
                time_Dom: $("#time_expired_" + productId),
                day_Dom: $("#dayEnd_" + productId),
                hour_Dom: $("#hourEnd_" + productId),
                min_Dom: $("#minEnd_" + productId),
                sec_Dom: $("#secEnd_" + productId),
                endTime: endDate
            });
        });
    });
</script>
<div class="productname">
    <span>
        <%=Lang(product.Name) %></span></div>
<div class="productinfo clearfix">
    <dl>
        <dt>
            <%=Tag("商品编号")%>：</dt>
        <dd>
            <%=product.Number %></dd>
    </dl>
    <%if (product.Type_id_ProductType == 320)
      { %>
    <dl>
        <dt>
            <%=Tag("市场价")%>：</dt>
        <dd>
            <span class="marketprice">
                <%=FormatMoney(product.Price_Market) %></span></dd>
    </dl>
    <dl>
        <dt>
            <%=Lang(CurrentUserLevel.PriceName) %>：</dt>
        <dd>
            <span class="buyprice">
                <%=FormatMoney(ProductPrice(product)) %>&nbsp;&nbsp;<em><%=Tag("节省")%>：<%=FormatMoney(product.Price_Market-ProductPrice(product)) %></em></span></dd>
    </dl>
    <%} %>
    <%if (product.Type_id_ProductType == 321 || product.Type_id_ProductType == 322)
      { %>
    <dl>
        <dt>
            <%=Tag("市场价")%>：</dt>
        <dd>
            <span class="marketprice">
                <%=FormatMoney(product.Price_Market) %></span></dd>
    </dl>
    <dl>
        <dt>
            <%if (product.Type_id_ProductType == 321)
              { %><%=Tag("抢购价")%><%}
              else if (product.Type_id_ProductType == 322)
              { %><%=Tag("团购价")%><%} %>：</dt>
        <dd>
            <span class="buyprice">
                <%=FormatMoney(product.Price_Sale)%>&nbsp;&nbsp;<em><%=Discount(product.Price_Market, product.Price_Sale)%>%
                    <%=Tag("折")%></em></span></dd>
    </dl>
    <%if (product.Type_id_ProductType == 322)
      {%>
    <dl>
        <dt>
            <%=Tag("已参团")%>：</dt>
        <dd>
            <%=product.Count_Sales_Show%></dd>
    </dl>
    <%} %>
    <%if (product.Count_Limit > 0)
      { %>
    <dl>
        <dt>
            <%=Tag("每人限购")%>：</dt>
        <dd>
            <%=product.Count_Limit%>
            <span class="unit">
                <%=Shop.Bussiness.EX_Product.ProductUnit(product,CurrentLanguage)%></span></dd>
    </dl>
    <%} %>
    <%if (System.DateTime.Now < product.Time_Start)
      { %>
    <dl>
        <dt>
            <%=Tag("开始")%>：</dt>
        <dd>
            <%=product.Time_Start%></dd>
    </dl>
    <%} %>
    <dl>
        <dt>
            <%if (System.DateTime.Now < product.Time_Start)
              { %><%=Tag("倒计时")%><%}
              else
              { %><%=Tag("剩余")%><%} %>：</dt>
        <dd>
            <div class="time_expired" enddate="<%if (System.DateTime.Now < product.Time_Start){ %><%=DateFormat(product.Time_Start)%><%}else{ %><%=DateFormat(product.Time_Expired)%><%} %>"
                product="<%=product.id %>" id="time_expired_<%=product.id %>">
                <span><span id="dayEnd_<%=product.id %>">0</span><em><%=Tag("天")%></em><span id="hourEnd_<%=product.id %>">0</span><em><%=Tag("小时")%></em><span
                    id="minEnd_<%=product.id %>">0</span><em><%=Tag("分钟")%></em><span id="secEnd_<%=product.id %>">0</span><em><%=Tag("秒")%></em></span></div>
        </dd>
    </dl>
    <%}%>
    <%if (product.Type_id_ProductType == 323)
      {%>
    <dl>
        <dt>
            <%=Tag("销售价")%>：</dt>
        <dd>
            <span class="marketprice">
                <%=FormatMoney(ProductPrice(product)) %></span></dd>
    </dl>
    <dl>
        <dt>
            <%=Tag("兑换积分")%>：</dt>
        <dd>
            <span class="buyprice">
                <%=product.Price_Sale%></span></dd>
    </dl>
    <%} %>
    <%if (product.Brand_id > 0)
      { %>
    <dl>
        <dt>
            <%=Tag("商品品牌")%>：</dt>
        <dd>
            <a href="<%=URL("P_Brand",product.Brand_id) %>" target="_blank">
                <%=Shop.Bussiness.EX_Product.ProductBrand(product,CurrentLanguage)%></a></dd>
    </dl>
    <%} %>
    <%foreach (Shop.Model.KeyValue kv in ProPertys)
      { %>
    <%if (kv.V != "")
      { %>
    <dl>
        <dt>
            <%=kv.K %>：</dt>
        <dd>
            <%=kv.V %></dd>
    </dl>
    <%} %>
    <%} %>
    <%if (supplier.IsSupplierTransport == 1)
      { %>
    <dl>
        <dt>
            <%=Tag("服务商家")%>：</dt>
        <dd>
            <a href="<%=URL("P_ShopIndex",product.Supplier_id) %>" class="color">
                <%=Lang(Shop.Bussiness.EX_Supplier.GetUser(product.Supplier_id).Name)%></a></dd>
    </dl>
    <%} %>
</div>
<div class="choosesp clearfix">
    <%=Get_guige(product)%>
    <% if (product.Type_id_ProductStatus == 101 && ProductStock(product) > 0)
       { %>
    <dl class="clearfix">
        <dt>
            <%=Tag("购买数量")%>：</dt>
        <dd>
            <input type="text" name="pro_num" id="pro_num" value="1" class="input" size="5" <%if ((product.Type_id_ProductType == 321 || product.Type_id_ProductType == 322) && (System.DateTime.Now < product.Time_Expired) && product.Count_Limit > 0)
            { %> onchange="checkinputtop('pro_num',<%=product.Count_Limit %>)" <%} %> />
            <span class="unit">
                <%=Shop.Bussiness.EX_Product.ProductUnit(product,CurrentLanguage)%></span> <em>
                    <%=Tag("库存")%>：<%=ProductStock(product) %><%=Shop.Bussiness.EX_Product.ProductUnit(product,CurrentLanguage)%></em></dd>
    </dl>
    <%} %>
</div>
<div class="productbutton clearfix">
    <%if ((product.Type_id_ProductType == 321 || product.Type_id_ProductType == 322 || product.Type_id_ProductType == 323) && System.DateTime.Now < product.Time_Start)
      { %>
    <strong>
        <%=Tag("尚未开始")%></strong>
    <%}
      else if ((product.Type_id_ProductType == 321 || product.Type_id_ProductType == 322 || product.Type_id_ProductType == 323) && System.DateTime.Now > product.Time_Expired)
      { %>
    <strong>
        <%=Tag("已结束")%></strong>
    <%}
      else
      { %>
    <% if (product.Type_id_ProductStatus == 100 || product.Type_id_ProductStatus == 103)
       { %>
    <div class="nosale">
        <span>
            <%=Tag("该商品已经下架")%></span></div>
    <%}
       else if (ProductStock(product) < 1)
       { %>
    <div class="nosale">
        <span>
            <%=Tag("该商品已经售罄")%></span></div>
    <%}
       else
       { %>
    <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=product.id %>,142,$('#pro_num').val(),'','Property134');" class="btn btn-buy"><s></s><%=Tag("加入购物车")%></a> <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=product.id %>,142,$('#pro_num').val(),'quickbuy','Property134');" class="btn btn-quickbuy"><s></s><%=Tag("立刻购买")%></a> <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=product.id%>,141);" class="btn btn-fav"><s></s><%=Tag("收藏")%></a> 
    <%} %>
    <%} %>
    <%if (Shop.Bussiness.ShopCache.GetBaseConfig().MailSign.ToLower().Contains("sendfriend")){ %>
    <p><a href="<%=URL("P_SendFriend",product.id) %>" class="a-email"><%=Tag("邮件分享")%></a></p>
    <%} %>
</div>
