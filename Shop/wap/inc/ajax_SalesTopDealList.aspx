

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.Bussiness.PageBase.ShopPage.cs" Inherits="Shop.Bussiness.ShopPage" %>
<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_35",1,"CN","ajax_SalesTopDealList"); %>

<%
string type = Shop.Tools.RequestTool.RequestString("type");
string orderstr = "";
if (type == "todayopen"){
    orderstr = "Time_Add desc,id desc";
}else{
    orderstr = "Count_Views_Show desc,id desc";
}
%>
  <%Table="Lebi_Product";Where="Product_id = 0 and Type_id_ProductStatus = 101";Order=""+orderstr+"";PageSize=36;pageindex=1;RecordCount=B_Lebi_Product.Counts(Where);int home_pro_index=1;
List<Lebi_Product> home_pros = B_Lebi_Product.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Product home_pro in home_pros){%>
  <LI id=dealli_home_<%=home_pro.id%> class=dealli><A class=thmb href="<%=URL("P_Product",home_pro.id) %>"><IMG alt="" src="<%=Image(home_pro.ImageMedium) %>" width=322 height=330></IMG> 
  <SPAN class=tag></SPAN><SPAN class=edge></SPAN><SPAN class=hover></SPAN></A>
  <DIV class=detail>
  <P class=summary><%=home_pro.Number%></P><A class=subject href="<%=URL("P_Product",home_pro.id) %>"><%=Lang(home_pro.Name) %></A> 
  <DIV class=amounts>
  <%if (home_pro.Price < home_pro.Price_Market){  %>
  <P class=percent><%=(int)(home_pro.Price/home_pro.Price_Market*100)%><EM>%</EM><SPAN class=blind>折扣</SPAN></P>
  <%}else{%>
  <P class=tmon_price><%=Lang(CurrentUserLevel.PriceName) %></P>
  <%} %>
  <DIV class=price>
  <P class=prime><SPAN class=blind>市场价</SPAN><EM><%=FormatMoney(home_pro.Price_Market) %></EM></P>
  <P class=sale><SPAN class=blind><%=Lang(CurrentUserLevel.PriceName) %></SPAN><EM><%=FormatMoney(ProductPrice(home_pro)) %></EM></P></DIV></DIV><SPAN class=people><EM></EM></SPAN> </DIV>
  <DIV class=option>
  <DIV class=sico></DIV>
  <DIV class=zzim><A style="CURSOR: pointer" class="btn_zzim" title="收藏" onclick="UserProduct_Edit(<%=home_pro.id%>,141);"><SPAN>收藏</SPAN></A> </DIV></DIV>
  </LI>
  <%home_pro_index++;}%>
<script>
    deallist_child = $('#home_<%=type%>').find('li')
    if (deallist_child.length > 0)
    {
        deallist_child.each(function() {
            $(this).hover(function(){ $(this).addClass('hover'); }, function(){ $(this).removeClass('hover'); });
        });
    }
</script>
