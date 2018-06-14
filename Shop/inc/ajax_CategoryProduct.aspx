

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.Bussiness.PageBase.ShopPage.cs" Inherits="Shop.Bussiness.ShopPage" %>
<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_35",1,"CN","ajax_CategoryProduct"); %>

<%
int id = Shop.Tools.RequestTool.RequestInt("id",0);
%>
<script>function open_areadeal(id){
    $.ajaxSetup ({
        // Disable caching of AJAX responses
        cache: false
    });
    var url = "/inc/ajax_CategoryProduct.aspx?id=" + id;
    $("#my_area_best").load(url);
}
$(function(){
    $('#my_area_best').slides({
        container: '#lst_deal',
        pagination: true,
        generateNextPrev: false,
        next: 'next',
        prev: 'prev',
        generatePagination: false,
        paginationClass: 'uio_page_location',
        currentClass: 'on',
        fadeSpeed: 0,
        slideSpeed: 0
    });
    var $lst_deal = $('#lst_deal');
    $('#lst_ul').attr("style", "width: 969px;position: absolute; top: 0px; left: 969px; z-index: 0; display: block; ");
    $('#lst_deal').attr("style", "overflow:hidden");
    $lst_deal.find('.slides_control').attr("style", "position: relative; width: 100%; height: 960px; left: -969px;");
    $('#lst_ul_1').attr("style", "width: 969px;position: absolute; top: 0px; left: 969px; z-index: 0; display: none; ");
    $('#lst_ul_2').attr("style", "width: 969px;position: absolute; top: 0px; left: 969px; z-index: 0; display: none; ");
    $('#lst_ul_3').attr("style", "width: 969px;position: absolute; top: 0px; left: 969px; z-index: 0; display: none; ");
    $('#lst_ul_4').attr("style", "width: 969px;position: absolute; top: 0px; left: 969px; z-index: 0; display: none; ");
});

</script>
<div id="my_area_best">
<div class="my_area_best wrap_deal_lst">
    <h2 class="title">人气商品</h2>
    <ul class="menu">
      <%Table="Lebi_Pro_Type";Where="Parentid = 0 and IsShow = 1";Order="Sort desc";PageSize=12;pageindex=1;RecordCount=B_Lebi_Pro_Type.Counts(Where);int jEIb_index=1;
List<Lebi_Pro_Type> jEIbs = B_Lebi_Pro_Type.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Pro_Type jEIb in jEIbs){%>
      <LI class=area<%=jEIb_index%>><A<%if (jEIb.id == id){%> class=selected<%} %> href="javascript:open_areadeal(<%=jEIb.id%>)"><STRONG class=area_name><%=Lang(jEIb.Name)%></STRONG></A> </LI>
      <%jEIb_index++;}%>
    </ul>
    
    <DIV id=lst_deal style="OVERFLOW: hidden">
    <%Table="Lebi_Product";Where="Product_id = 0 and Type_id_ProductStatus = 101 and Pro_Type_id in (" + Categoryid(id) +")";Order="Count_Views desc,id desc";PageSize=30;pageindex=1;RecordCount=B_Lebi_Product.Counts(Where);int area_pro_index=1;
List<Lebi_Product> area_pros = B_Lebi_Product.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Product area_pro in area_pros){%>
    <%if (area_pro_index == 1){ %>
    <UL id="lst_ul" class="lst column3_v1">
    <%}else if (area_pro_index % 7 == 0){ %>
    <UL id="lst_ul_<%=area_pro_index/6%>" class="lst column3 column3_v1">
    <%} %>
        <LI id=dealli_homearea_<%=area_pro.id%> class=dealli><A class=thmb href="<%=URL("P_Product",area_pro.id) %>"><IMG alt="" src="<%=Image(area_pro.ImageMedium) %>" width=304 height=311></IMG><%if (area_pro_index <= 3){ %><SPAN class=best_top><SPAN>TOP</SPAN><EM><%=area_pro_index%></EM></SPAN><%} %></A> 
        <DIV class=detail>
        <P class=summary><%=area_pro.Number%></P><A class=subject href="<%=URL("P_Product",area_pro.id) %>"><%=Lang(area_pro.Name) %></A> 
        <DIV class=amounts>
        <%if (area_pro.Price < area_pro.Price_Market){  %>
        <P class=percent><%=(int)(area_pro.Price/area_pro.Price_Market*100)%><EM>%</EM><SPAN class=blind>折扣</SPAN></P>
        <%}else{%>
        <P class=tmon_price><%=Lang(CurrentUserLevel.PriceName) %></P>
        <%} %>
        <DIV class=price>
        <P class=prime><SPAN class=blind>市场价</SPAN><EM><%=FormatMoney(area_pro.Price_Market) %></EM></P>
        <P class=sale><SPAN class=blind><%=Lang(CurrentUserLevel.PriceName) %></SPAN><EM><%=FormatMoney(ProductPrice(area_pro)) %></EM></P></DIV></DIV><SPAN class=people><EM></EM></SPAN> </DIV>
        <DIV class=option>
        <DIV class=sico></DIV>
        <DIV class=zzim><A style="CURSOR: pointer" class="btn_zzim" title="收藏" onclick="UserProduct_Edit(<%=area_pro.id%>,141);"><SPAN>收藏</SPAN></A> </DIV></DIV>
        </LI>
        <%if (area_pro_index % 6 == 0 || area_pro_index == RecordCount){ %></UL><%} %>
    <%area_pro_index++;}%>
    </DIV>
    
    <div class="uio_page_location">
        <a href="javascript:void(0);" class="prev">上一页</a>
        <ul>
            <li><a href="javascript:void(0);">1</a></li>
        <li><a href="javascript:void(0);">1</a></li>
        <li><a href="javascript:void(0);">1</a></li>
        <li><a href="javascript:void(0);">1</a></li>
        <li><a href="javascript:void(0);">1</a></li>
        </ul>
        <a href="javascript:void(0);" class="next">下一页</a>
    </div>
    <div class="btn_area_more"><A href="<%=URL("P_ProductCategory",id)%>">更多<span class="bu"></span></a></div>
    <div class="bg_btm_line"></div>
</div>
</div>