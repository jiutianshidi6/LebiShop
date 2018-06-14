<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.order.Express_Print" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=model.Name %>-<%=Tag("单据打印")%>-<%=site.title%></title>

<script src="<%=site.AdminJsPath %>/jquery-3.1.0.min.js"></script>
<script src="<%=site.AdminJsPath %>/jquery-migrate-1.2.1.js"></script>
<script src="<%=site.AdminJsPath %>/Cookies.js"></script>
<script src="<%=site.AdminJsPath %>/main.js"></script>
<script src="<%=site.AdminJsPath %>/messagebox.js"></script>
<script src="<%=site.AdminJsPath %>/jquery-ui/jquery-ui.min.js"></script>
<%if (CurrentLanguage.Code=="CN"){%><script src="<%=site.AdminJsPath %>/jquery-ui/datepicker-zh-CN.js"></script><%}%>
<link rel="stylesheet" type="text/css" href="<%=site.AdminCssPath %>/css.css" />
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jquery-ui/jquery-ui.min.css" />
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jquery-ui/jquery-ui.theme.min.css" />
<script>
  var AdminPath = "<%=site.AdminPath %>";var WebPath ="<%=site.WebPath %>";var AdminImagePath = "<%=site.AdminImagePath %>";var requestPage = "<%=Shop.Tools.RequestTool.GetRequestUrl().ToLower() %>";var refPage = "<%=Shop.Tools.RequestTool.GetUrlReferrer().ToLower() %>";
</script>

<style>body{background:#fff;margin:0;padding:0;font-size:12px;text-align:left;overflow:scroll}input{font-size:12px}.box{margin:0;POSITION: relative;width:<%=model.Width %>px;height:<%=model.Height %>px;background:url(<%=WebPath + model.Background %>) no-repeat;overflow:hidden}</style>
<style media=print>.box{POSITION: relative;width:<%=model.Width %>px;height:<%=model.Height %>px;background:none;overflow:hidden}.print-btn{display:none;}</style>

</head>
<body>

<div class="print-btn">
    <div class="tools">
        <ul>
            <li class="print"><a href="javascript:void(0);" onclick="Print('<%=id %>',<%=Tid %>,<%=Eid %>);"><b></b><span><%=Tag("打印")%></span></a></li>
            <li class="close"><a href="javascript:void(0);" onclick="window.close();"><b></b><span><%=Tag("关闭")%></span></a></li>
        </ul>
    </div>
</div>
<% PrintTable(); %>
<script type="text/javascript">
function Print(id, Tid, Eid) {
    var postData = "";
    var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=Express_Print&id="+id+"&Tid="+Tid+"&Eid="+Eid;
    RequestAjax(url, postData, function () { $("#div_error").dialog('close'); setTimeout(function () { window.print(); }, 1000); });
}
</script>

</body>
</html>