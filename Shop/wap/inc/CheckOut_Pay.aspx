<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.inc.CheckOut_Pay" validateRequest="false"%>
<div id="pay_edit">
<div class="dl-table clearfix">
    <%
    foreach(Shop.Model.Lebi_Pay model in pays ){
    %>
    <dl>
        <dt><label><input type="radio" name="pay_id" value="<%=model.id %>" <%=model.id==CurrentUser.Pay_id?"checked":"" %> order="true" Code="<%=model.Code %>" onclick="Setpay();" /> <%=Lang(model.Name)%></label></dt>
        <dd><em><%=Lang(model.Description)%></em>
            <%if (model.Code == "OnlinePay")
            { %>
            <div id="onlinepay" style="display:none;">
            <div class="dl-table clearfix" id="onlinepaylist">
            <% 
                foreach (Shop.Model.Lebi_OnlinePay onpay in onpays)
                {
                    Shop.Model.Lebi_OnlinePay sononpay = Getpay(onpay);
                    if (sononpay == null)
                        continue;
                %>
                <dl>
                    <dt><label><input type="radio" name="onlinepay_id" value="<%=sononpay.id %>" <%=(sononpay.id==CurrentUser.OnlinePay_id||sononpay.parentid==CurrentUser.OnlinePay_id)?"checked":"" %> order="true" /> <%if (onpay.Logo != ""){ %><img src="<%=onpay.Logo %>" /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%}%><%=Lang(onpay.Name)%>(<%=onpay.Currency_Code %>)</label></dt>
                    <dd><%=Lang(onpay.Description)%><%if (onpay.FeeRate > 0){ %><%=Tag("手续费")%>：<%=onpay.FeeRate%> %<%} %></dd>
                </dl>
                <%} %>
            </div>
            </div>
            <%} %>
        </dd>
    </dl>
    <%} %>
</div>
</div>
<script type="text/javascript">
    Setpay();
</script>