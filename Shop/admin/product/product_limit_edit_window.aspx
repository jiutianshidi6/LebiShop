<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.product_limit_edit_window" validateRequest="false"%>


<table class="table">
    <tr>
            <th>
                浏览权限：
            </th>
            <td>
                <%=userlevels_checkbox("UserLevel_ids_show","","limit=\"true\"")%>
            </td>
        </tr>
        <tr>
            <th>
                看价权限：
            </th>
            <td>
                <%=userlevels_checkbox("UserLevel_ids_priceshow","","limit=\"true\"")%>
            </td>
        </tr>
        <tr>
            <th>
                购买权限：
            </th>
            <td>
                <%=userlevels_checkbox("UserLevel_ids_buy","","limit=\"true\"")%>
            </td>
        </tr>
        <tr>
        <td colspan="2" class="action">
        <div class="tools tools-m clear">
            <ul>
                <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("提交")%></span></a></li>
            </ul>
        </div>
        </td>
    </tr>
</table>
 
<script type="text/javascript">
    function SaveObj() {
        var ids = GetChkCheckedValues("sonproductid");
        var postData = GetFormJsonData("limit");
        var url = "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=Proudct_limit_batch&ids="+ids;
        RequestAjax(url,postData,function(res){
            MsgBox(3, "<%=Tag("操作成功")%>", "");
        });
    }
    SetCookie('pageSize', '100', 1);
</script>


  