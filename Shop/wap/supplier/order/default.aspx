<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.supplier.order.Default" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%=Tag("订单管理")%>-<%=site.title%></title>

<link rel="stylesheet" type="text/css" href="<%=site.AdminCssPath %>/css.css" />
<script type="text/javascript" src="<%=site.AdminJsPath %>/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/ajaxfileupload.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/main.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/messagebox.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/Cookies.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/jquery-ui.min.js"></script>
<script type="text/javascript" src="<%=site.WebPath %>/Editor/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="<%=site.WebPath %>/Editor/ckfinder/ckfinder.js"></script>
<script type="text/javascript" src="<%=site.AdminJsPath %>/master.js"></script>
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jqueryuicss/redmond/jquery-ui.css" />
<script type="text/javascript" src="<%=site.AdminJsPath %>/multiselect/js/jquery.multiselect2side.js"></script>
<link rel="stylesheet" href="<%=site.AdminJsPath %>/multiselect/css/jquery.multiselect2side.css" type="text/css" media="screen" />
<script type="text/javascript">
    var AdminPath = "<%=site.AdminPath %>";var WebPath ="<%=site.WebPath %>";var AdminImagePath = "<%=site.AdminImagePath %>";var requestPage = "<%=Shop.Tools.RequestTool.GetRequestUrl().ToLower() %>";var refPage = "<%=Shop.Tools.RequestTool.GetUrlReferrer().ToLower() %>";
    function quit() { if (confirm("<%=Tag("您确定要退出吗？")%>")) return true; else return false; }
    </script>
</head>
<body>
<div id="body_head">
    <div id="logo">
      <span><a href="<%=site.AdminPath %>/ajax/ajax_supplier.aspx?__Action=MenuJump&pid=0"><%=Lang(CurrentSupplier.Name)%></a></span>
    </div>
    <div id="service">
        <div class="layout">
          <span><em><%=Tag("您好！")%></em>[<%=CurrentSupplier.SubName%>|<%=CurrentSupplierUserGroup.Name%>]<%=CurrentSupplierUser.RemarkName%>&nbsp;&nbsp;<a href="<%=site.AdminPath %>/config/password.aspx"><%=Tag("改密")%></a>&nbsp;|&nbsp;<a href="<%=site.AdminPath %>/Logout.aspx" onclick="return quit()"><%=Tag("注销")%></a>&nbsp;|&nbsp;<a href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_ShopIndex",CurrentSupplier.id.ToString(),"",CurrentLanguage.Code) %>" target="_blank"><%=Tag("网站前台")%></a></span>
        </div>
    </div>
    <div class="clearfix">
    </div>
    <div class="navmenu">
        <ul class="menu">
            <%foreach (Shop.Model.Lebi_Supplier_Menu menu in TopMenus)
                { %>
            <li class="<%=CurrentTopMenu.id==menu.id?"current":"" %>"><a href="<%=site.AdminPath %>/Ajax/ajax_supplier.aspx?__Action=MenuJump&pid=<%=menu.id %>"><span><%if (menu.Image != ""){ %><img src="<%=GetImage(site.WebPath + menu.Image) %>" height="15px" /><%} %><%=Tag(menu.Name)%></span></a> </li>
            <%} %>
        </ul>
        <%=lbmenu%>
    </div>
</div>
<div id="body_content">
<div id="sidebar">
    <div class="menubar ">
        <%if (desk == 1)
            { 
        %>
        <h2><span><img src="<%=site.AdminImagePath %>/minus.gif" id="img1" /> <%=Tag("快捷菜单")%></span></h2>
        <ul class="clear">
            <%foreach (Shop.Model.Lebi_Supplier_Menu menu in GetIndexMenus()){ %><li><a href="<%=MenuUrl(menu.URL,1) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
        </ul>
        <% }else{ %>
        <%foreach (Shop.Model.Lebi_Supplier_Menu pmenu in GetMenus(CurrentTopMenu.id)){ %>
        <h2><span><img mid="<%=pmenu.id %>" src="<%=site.AdminImagePath %>/<%=MenuShow(pmenu.id)==true?"minus":"plus" %>.gif" id="imgStatis" /> <%=Tag(pmenu.Name)%></span></h2>
        <ul class="clear" <%=MenuShow(pmenu.id)==true?"":"style=\"display:none;\"" %>>
            <%foreach (Shop.Model.Lebi_Supplier_Menu menu in GetMenus(pmenu.id)){ %><li><a href="<%=MenuUrl(menu.URL,0) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
        </ul>
        <%} } %>
    </div>
</div>
<div id="sideplus">
    <a onclick="switchSysBar()"><span class="navPoint" id="switchPoint" title="<%=Tag("关闭/打开左栏")%>"><img src="<%=site.AdminImagePath%>/vertical/left.png" alt="<%=Tag("关闭/打开左栏")%>" /></span></a>
</div>
<div id="sidecontent" class="clear">
    <div class="mainbody_path" id="body_path">
      
    <div class="tools">
        <ul>
            <li class="print"><a href="javascript:void(0);" onclick="Express_Log_Add();"><b></b>
                <span>
                    <%=Tag("添加至快递单")%></span></a></li>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                >
                <%=Tag("订单管理")%>
                > <a href="<%=site.AdminPath %>/order/default.aspx?t=<%=t %>">
                    <%=Shop.Bussiness.EX_Type.TypeName(t) %></a></span> </li>
        </ul>
    </div>

    </div>
      
      
    <div class="mainbody_top">
        <ul class="tablist">
            <li <%if (type==""){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=">
                <span>
                    <%=Tag("全部订单")%></span></a></li>
           
            <%if (t == 213)
              {%>
            <li <%if (type=="3"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=3">
                <span>
                    <%=Tag("未支付")%></span></a></li>
            <li <%if (type=="4"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=4">
                <span>
                    <%=Tag("已支付")%></span></a></li>
            <li <%if (type=="5"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=5">
                <span>
                    <%=Tag("未发货")%></span></a></li>
            <li <%if (type=="6"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=6">
                <span>
                    <%=Tag("已发货")%></span></a></li>
            <li <%if (type=="8"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=8">
                <span>
                    <%=Tag("未收货")%></span></a></li>
            <li <%if (type=="9"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=9">
                <span>
                    <%=Tag("已收货")%></span></a></li>
            <%} %>
            <li <%if (type=="10"){Response.Write("class=\"selected\"");} %>><a href="?t=<%=t%>&dateFrom=<%=dateFrom %>&dateTo=<%=dateTo %>&key=<%=HttpUtility.UrlEncode(key) %>&type=10">
                <span>
                    <%=Tag("已完成")%></span></a></li>
        </ul>
    </div>

    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script>
    <div class="searchbox">
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" onclick="WdatePicker()" />
        -
        <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" onclick="WdatePicker()" />
        <input type="text" id="key" name="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" /><input type="button" id="btnSou" class="btn-query" onclick="search_();" />
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" border="0" class="datalist">
        <tr class="title">
            <th style="width: 40px" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'id\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));">
                    <%=Tag("全选")%></a>
            </th>
            <th width="60px">
                <%=Tag("操作")%>
            </th>
            <th width="110px">
                <%=Tag("订单编号")%>
            </th>
            <th width="100px">
                <%=Tag("会员")%>
            </th>
            <th width="100px">
                <%=Tag("购买人")%>
            </th>
            <th width="80px">
                <%=Tag("金额")%>
            </th>
            <th width="80px">
                <%=Tag("运费")%>
            </th>
            <th>
                <%=Tag("订单状态")%>
            </th>
            <th width="120px">
                <%=Tag("支付方式")%>
            </th>
            <th width="120px">
                <%=Tag("配送方式")%>
            </th>
            <th width="130px">
                <%=Tag("订购日期")%>
            </th>
        </tr>
        <%int Mark = 0;foreach (Shop.Model.Lebi_Order model in models){
        if (model.Mark !=0){
        Mark=model.Mark;
        }else{
        Mark=0;
        }
        %>
        <tr class="list" ondblclick="Edit(<%=model.id %>);">
            <td align="center">
                <input type="checkbox" name="id" value="<%=model.id %>" del="true" />
            </td>
            <td>
                <a target="_blank" href="<%=model.Type_id_OrderType==212?"torder_view":"order_view" %>.aspx?id=<%=model.id %>">
                    <img src="<%=PageImage("icon/newWindow.png")%>" /></a> <a target="_blank" href="Print_Shipping.aspx?id=<%=model.id %>">
                        <img src="<%=PageImage("icon/Print.png")%>" /></a> <span <%if (model.Remark_Admin !=""){ %>onmouseover="GetOrderMemoTips('<%=model.id %>');"
                            onmouseout="RemoveTips('Tips_200',true);" style="cursor: pointer;" <%} %>>
                            <img src="<%=PageImage("mark/"+Mark+".png")%>" /></span>
            </td>
            <td>
                <a target="_blank" href="<%=model.Type_id_OrderType==212?"torder_view":"order_view" %>.aspx?id=<%=model.id %>">
                    <%=model.Code %></a>
            </td>
            <td>
                <%=model.User_UserName %>
            </td>
            <td>
                <%=model.T_Name %>
            </td>
            <td>
                <%=FormatMoney(model.Money_Order) %>
            </td>
            <td>
                <%=FormatMoney(model.Money_Transport) %>
            </td>
            <td>
                <%=Tag(Shop.Bussiness.Order.OrderStatus(model)) %>
            </td>
            <td>
                <%=Shop.Bussiness.Language.Content(model.Pay, CurrentLanguage.Code)%>&nbsp;
            </td>
            <td>
                <%=model.Transport_Name%>&nbsp;
            </td>
            <td>
                <%=FormatTime(model.Time_Add) %>
            </td>
        </tr>
        <%} %>
    </table>
    <script type="text/javascript">
        function search_() {
            var mark = GetRadioCheckedValues("mark");
            var key = $("#key").val();
            var dateFrom = $("#dateFrom").val();
            var dateTo = $("#dateTo").val();
            window.location = "?t=<%=t%>&type=<%=type%>&mark="+ mark +"&key=" + escape(key) + "&dateFrom=" + dateFrom + "&dateTo=" + dateTo;
        }
        function Edit(id) {
            window.open("order_view.aspx?id=" + id);
        }
        function Del(id) {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = { "id": id };
            var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=Order_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Express_Log_Add() {
            var ids = GetChkCheckedValues("id");
            var postData = { "ids": ids };
            var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=Express_Log_Add";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "Express_Log.aspx")});
        }
        function GetOrderMemoTips(id) {
            $.ajax({
                type: "POST",
                url: "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=Order_Memo",
                data: { "id": id },
                beforeSend: function () {
                    AddTips('', 'Tips_200', 'mouse', '200', null);
                },
                success: function (res) {
                    AddTips('<div class=\"dvTips_outer\"><div class=\"dvTips_inner\"><div class=\"dvTips_bg\"></div><div class=\"dvTips_content\">'+res+'</div></div></div></div>', 'Tips_200', 'mouse', '200', null);
                }
            });
        }
    </script>

        </div>
    </div>
    
    <div class="bottom" id="body_bottom">
        <%=PageString%>
    </div>

</div>
</div>
<div id="body_foot">
    <div class="foot">
      <div class="copy" id="lebicopy">
            <asp:Label ID="LBLicense" runat="server"></asp:Label>
        </div>
        <div class="lang">
            <ul class="droplang">
                <li class="lang_li"><a class="noclick">
                    <%int langi = 0;
                      if (CurrentLanguage.Name == "")
                        {%><%=Tag("语言选择")%><%}else{%><%=CurrentLanguage.Name%><%} %></a>
                    <dl class="lang_li_content">
                        <%foreach (Shop.Model.Lebi_Language_Code langc in langs)
                          {
                              langi++; if (langi== langs.Count)
                              {%>
                        <dd class="last"><%}
                              else
                              {%><dd><%} %>
                        <a href="javascript:SetLanguage('<%=langc.Code %>','<%=langc.Name %>');"><%=langc.Name %></a></dd>
                              <%} %>
                    </dl>
                </li>
            </ul>
        </div>
    </div>
</div>
<script type="text/javascript">
    function Copyright() {
        var title_ = "<%=Tag("关于")%>";
        var url_ = "<%=site.AdminPath %>/Config/Copyright_window.aspx";
        var width_ = 500;
        var height_ = 310;
        var modal_ = true;
        EditWindow(title_, url_, width_, height_, modal_);
    }
</script>
</body>
</html>