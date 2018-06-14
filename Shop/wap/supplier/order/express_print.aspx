<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Supplier.Order.Express_Print" validateRequest="false"%>

<html>
<head>
<title><%=model.Name %>-<%=Tag("单据打印")%>-<%=site.title%></title>
<META name="author" content="56770 Eshop">
<link rel="stylesheet" type="text/css" href="<%=site.AdminCssPath %>/css.css">
<script type="text/javascript" language="javascript" src="<%=site.AdminJsPath %>/jquery-1.7.2.min.js"></script>
<script type="text/javascript" language="javascript" src="<%=site.AdminJsPath %>/messagebox.js"></script>
<script type="text/javascript" language="javascript" src="<%=site.AdminJsPath %>/main.js"></script>
<script type="text/javascript" language="javascript" src="<%=site.AdminJsPath %>/jquery-ui.min.js"></script>
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jqueryuicss/redmond/jquery-ui.css" />
<style>body{background:#fff;margin:0;padding:0;font-size:12px;text-align:left;overflow:scroll}input{font-size:12px}.box{margin:0;POSITION: relative;width:<%=model.Width %>px;height:<%=model.Height %>px;background:url(<%=WebPath + model.Background %>) no-repeat;overflow:hidden}</style>
<style media=print>.box{POSITION: relative;width:<%=model.Width %>px;height:<%=model.Height %>px;background:none;overflow:hidden}.print-btn{display:none;}</style>
<script type="text/javascript">
        var AdminPath = "<%=site.AdminPath %>/";
        var WebPath = "<%=site.WebPath %>";
        var requestPage = "<%=Shop.Tools.RequestTool.GetRequestUrl().ToLower() %>";
</script>
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

  