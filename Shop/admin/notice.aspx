<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.notice" validateRequest="false"%>

<script type="text/javascript" language="javascript" src="<%=site.AdminJsPath %>/jquery-1.7.2.min.js"></script>
<script type="text/javascript" language="javascript" src="<%=site.AdminJsPath %>/msclass.js"></script>
<div id="GetNotice"></div>
<script type="text/jscript">
    function GetNotice() {
        var url = "<%=site.AdminPath %>/ajax/ajax_service.aspx?__Action=GetNotice";
        $.ajax({
            type: "POST",
            url: url,
            data: '',
            success: function (res) {
                $("#GetNotice").html(res);
            }
        });
    }
    $(function () {
        GetNotice();
    });
</script>

  