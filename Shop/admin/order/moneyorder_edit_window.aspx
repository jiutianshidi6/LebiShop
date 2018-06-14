<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.order.Order_View" validateRequest="false"%>

    <table class="table">
        <tr>
            <th style="width: 25%">
                <%=Tag("会员账号")%>：
            </th>
            <td>
                <%=model.User_UserName%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("金额")%>：
            </th>
            <td>
                <input type="text" class="input" shop="true" name="money" id="money" value="<%=model.Money_Order%>" onkeyup="value=value.replace(/[^\d\.]/g,'')" style="width: 100px;" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("相关订单")%>：
            </th>
            <td>
                <%
                if(model.Order_id>0)
                {
                Shop.Model.Lebi_Order co=Shop.Bussiness.B_Lebi_Order.GetModel(model.Order_id);
                if(co!=null){%>
                <a href="order_view.aspx?id=<%=co.id%>" target="_blank"><%=co.Code%></a>

                <%    }
                }%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("提交时间")%>：
            </th>
            <td>
                <%=FormatTime(model.Time_Add)%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("支付时间")%>：
            </th>
            <td>
                <%=model.Time_Paid==model.Time_Add?"-":FormatTime(model.Time_Paid)%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("支付方式")%>：
            </th>
            <td>
                <%=Lang(model.Pay)%>
                <%=Lang(model.OnlinePay)%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("备注")%>：
            </th>
            <td>
                <textarea id="Remark_Admin" name="Remark_Admin" shop="true" style="height:60px;width:300px;"><%=model.Remark_Admin%></textarea>
            </td>
        </tr>
        <%if(model.IsPaid==0){%>
        <tr>
            <td colspan="2" class="action">
                <div class="tools tools-m clear">
                    <ul>
                        <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("已支付")%></span></a></li>
                    </ul>

                </div>
                <em>修改状态为已支付后，将在会员资金中生成一条资金记录。</em>
            </td>
        </tr>
        <%}%>
    </table>
    <script type="text/javascript">
    function SaveObj() {
        var postData = GetFormJsonData("shop");
        var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=MoneyOrder_paid&id=<%=model.id %>";
        RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
    }
    </script>

  