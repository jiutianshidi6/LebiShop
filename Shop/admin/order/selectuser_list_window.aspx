<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.selectuser_list_window" validateRequest="false"%>

    <%foreach (Shop.Model.Lebi_User model in users)
          {
             
    %>
<tr class="list" >
        
        <td>
            <%=model.UserName %>&nbsp;
        </td>
    <td >
            <%=model.NickName %>&nbsp;
        </td>
        <td >
            <%=model.RealName %>&nbsp;
        </td>
        <td>
            <%=GetlevelName(model.UserLevel_id) %>&nbsp;
        </td>
        <td>
            <a href="javascript:void(0);" onclick="UserAddOrder(<%=model.id%>);"><%=Tag("添加订单")%><a/>
        </td>
       
    </tr>
    <%} %>
    <tr>
    <td colspan="7">
    <%=PageString %>
    </td>
    </tr>

  