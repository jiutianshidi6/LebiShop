<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.customxs_ex" validateRequest="false"%>


    <table class="datalist">
        <tr class="title">

            <th style="width: 150px">
                会员
            </th>
            <th style="width: 150px">
                客户名称
            </th>
            <th style="width: 80px">
                金额
            </th>
            <th style="width: 80px">
                数量
            </th>
           
        </tr>
        <%
        int total_Count = 0;
        decimal total_Money = 0;
        foreach (Shop.Model.Lebi_User user in users)
        {
        total_Count += user.Count_Order;
        total_Money += user.Money;
        %>
        <tr class="list">
            <td>
                <%=user.UserName%>
            </td>
            <td>
                <%=user.NickName%>
            </td>
            <td>
                <%=user.Money%>
            </td>
            <td>
                <%=user.Count_Order%>
            </td>
        </tr>
        <tr class="list" id="son<%=user.id%>">
            <td></td>
            <td colspan="3">
                <table>
                    <tr>
                        <td>单号</td>
                        <td>商品编号</td>
                        <td>商品名称</td>
                        <td>时间</td>
                        <td>金额</td>
                        <td>数量</td>
                    </tr>
                    <%foreach (var p in getproducts(user.id))
                    {
                    //decimal m=0;
                    //int count=procount(order.id,out m);
                    %>
                    <tr>
                        <td><%=p.Order_Code%></td>
                        <td><%=p.Product_Number%></td>
                        <td><%=Shop.Bussiness.Language.Content(p.Product_Name,"CN")%></td>
                        <td><%=p.Time_Add%></td>
                        <td><%=p.Money%></td>
                        <td><%=p.Count%></td>
                    </tr>
                    <%}%>
                </table>
            </td>

        </tr>
        <%} %>
        <tr class="list">
            <td colspan="2" style="text-align:right;font-weight:bold">合计：</td>
            <td style="font-weight:bold"><%=total_Money%></td>
            <td style="font-weight:bold"><%=total_Count%></td>
        </tr>
    </table>


  