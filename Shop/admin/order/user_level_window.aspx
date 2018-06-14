<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.user_level_window" validateRequest="false"%>
<table style="background: #f4f4f4;width:100%">
    <tr class="list">
        <td>
            <input type="text" name="searchuserkey" id="searchuserkey" value="<%=userkey %>" style="width:80px;" class="input-query" /><input type="button" id="btnSou" class="btn-query" onclick="loaduser($('#searchuserkey').val());" /><input type="button" id="cancel" value="<%=Tag("取消")%>" class="btn-cancel" onclick="loaduser(' ');" />
        </td>
    </tr>
    <%if(userkey==""){%>
    <%=Lebi.ERP.other.CreateTree_User(CurrentLanguage.Code) %>
    <%}else{
    foreach(Shop.Model.Lebi_User m in models){
    %>
    <tr class="list">
       <td>&nbsp;&nbsp;<img src="<%=img%>" style="cursor: pointer; text-align: center; vertical-align:middle" />
           <a href="javascript:searchuser(<%=m.id%>,'<%=userkey%>')"><%=m.NickName%></a></td>
    </tr>
    <%}}%>
</table>
