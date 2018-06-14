<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.supplier.product.Class" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%=Tag("商品分类")%>-<%=site.title%></title>

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
            <li class="add"><a href="javascript:void(0);" onclick="Edit(0,0);"><b></b><span>
                <%=Tag("添加")%></span></a></li>
           
            <li class="del"><a href="javascript:void(0);" onclick="Del(0)"><b></b><span>
                <%=Tag("删除")%></span></a></li>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                >
                <%=Tag("商品分类")%></span></li>
        </ul>
    </div>

    </div>
      
      
    <div class="mainbody" id="body_main">
        <div id="body_main_form" style="min-width:1200px;width:100%">
          
    

    <table cellspacing="0" border="0" style="width: 100%; border-collapse: collapse;"
        class="datalist">
        <tr class="title">
            <th style="width: 40px" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'id\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));">
                    <%=Tag("全选")%></a>
            </th>
            <th style="width: 40px">
                <%=Tag("ID")%>
            </th>
            <th style="width: 200px">
                <%=Tag("分类名称")%>
            </th>
            <th style="width: 80px">
                <%=Tag("商品数量")%>
            </th>
            <th style="width: 80px">
                <%=Tag("分类排序")%>
            </th>
            <th>
                <%=Tag("操作")%>
            </th>
        </tr>
        <tr class="list">
            <td align="center">&nbsp;</td>
            <td>0</td>
            <td><%=Tag("未分组")%></td>
            <td><a href="javascript:void(0);" onclick="SearchProduct(0);"><%=TypeProductCount(CurrentSupplier.id,0)%></a></td>
            <td>0</td>
            <td></td>
        </tr>
        <%foreach (Shop.Model.Lebi_Supplier_ProductType t in PTypes)
          { %>
        <tr class="list" ondblclick="Edit(0,<%=t.id %>)" name="tr<%=t.parentid %>" id="tr<%=t.id %>">
            <td align="center">
                <input type="checkbox" value="<%=t.id %>" name="id" del="del" />
            </td>
            <td>
                <%=t.id %>
            </td>
            <td>
                
                <% 
                    if (t.ImageUrl != "")
                    {
                        Response.Write("<img src=\"" + t.ImageUrl + "\" height=\"16\" />&nbsp;");
                    }
                    Response.Write(Lang(t.Name));
                %>
            </td>
            <td>
                <a href="javascript:void(0);" onclick="SearchProduct(<%=t.id %>);"><%=TypeProductCount(CurrentSupplier.id,t.id)%></a>
            </td>
            <td>
                <%=t.Sort %>
            </td>
            <td>
            <a href="javascript:Edit(<%=t.id %>,0)"><%=Tag("添加子类")%></a> 
            |  <a href="javascript:Edit(0,<%=t.id %>)"><%=Tag("编辑") %></a> 

            </td>
        </tr>
        <%foreach (Shop.Model.Lebi_Supplier_ProductType st in GeteList(t.id))
          { %>
        <tr class="list" name="tr<%=t.parentid %>" id="tr<%=t.id %>">
            <td align="center">
                <input type="checkbox" value="<%=st.id %>" name="id" del="del" />
            </td>
            <td>
                <%=st.id%>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <% 
                    if (st.ImageUrl != "")
                    {
                        Response.Write("<img src=\"" + st.ImageUrl + "\" height=\"16\" />&nbsp;");
                    }
                    Response.Write(Lang(st.Name));
                %>
            </td>
            <td>
                <a href="javascript:void(0);" onclick="SearchProduct(<%=st.id %>);"><%=TypeProductCount(CurrentSupplier.id,st.id)%></a>
            </td>
            <td>
                <%=st.Sort %>
            </td>
            <td>
                <a href="javascript:Edit(0,<%=st.id %>)"><%=Tag("编辑") %></a> 
            </td>
        </tr>
        <%} %>
        <%} %>
    </table>
    <script type="text/javascript">
        function Del(id) {
            if (confirm("<%=Tag("确认要删除吗？")%>")){
            var postData;
            if (id == 0)
                id = GetChkCheckedValues("id");
            postData = { "id": id };
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Type_Del";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "");if ((id + "a").indexOf(",") == -1){$("#tr" + id + "").remove();}else {var arr = id.split(',');for (var i in arr) {$("#tr" + arr[i] + "").remove();}}});}
        }
        function Edit(pid, id) {
            var title_ = "<%=Tag("编辑分类")%>";
            if (id == 0) title_ = "<%=Tag("添加分类")%>";
            var url_ = "class_edit_window.aspx?pid=" + pid + "&id=" + id;
            var width_ = 600;
            var height_ = 500;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function SearchProduct(id)
        {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_search.aspx?__Action=ProductSearch&Supplier_ProductType_ids="+id;
            $.ajax({
                type: "POST",
                url: url,
                data: postData,
                dataType: 'json',
                success: function (res) {
                    window.location.href="default.aspx?"+ res.url;
                }
            });
        }
</script>

        </div>
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