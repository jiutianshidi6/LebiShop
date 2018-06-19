<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.product.product_batch_edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("批量修改")%>-<%=site.title%></title>

<script src="<%=site.AdminJsPath %>/jquery-3.1.0.min.js"></script>
<script src="<%=site.AdminJsPath %>/jquery-migrate-1.2.1.js"></script>
<script src="<%=site.AdminJsPath %>/Cookies.js"></script>
<script src="<%=site.AdminJsPath %>/main.js"></script>
<script src="<%=site.AdminJsPath %>/messagebox.js"></script>
<script src="<%=site.AdminJsPath %>/master.js"></script>
<script src="<%=site.AdminJsPath %>/jquery-ui/jquery-ui.min.js"></script>
<%if (CurrentLanguage.Code=="CN"){%><script src="<%=site.AdminJsPath %>/jquery-ui/datepicker-zh-CN.js"></script><%}%>
<link rel="stylesheet" type="text/css" href="<%=site.AdminCssPath %>/css.css" />
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jquery-ui/jquery-ui.min.css" />
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/jquery-ui/jquery-ui.theme.min.css" />
<link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/lightbox/lightbox.min.css" />
<%if (Shop.LebiAPI.Service.Instanse.Check("managelicenese")){%>
<style>#body_head #logo {width:112px;height:62px;background:url(<%=site.AdminImagePath %>/2015/logo_oem.gif) center 20px #0669c5 no-repeat;float:left;}</style>
<%}%>
<script>
    var AdminPath = "<%=site.AdminPath %>";var WebPath ="<%=site.WebPath %>";var AdminImagePath = "<%=site.AdminImagePath %>";var requestPage = "<%=Shop.Tools.RequestTool.GetRequestUrl().ToLower() %>";var refPage = "<%=Shop.Tools.RequestTool.GetUrlReferrer().ToLower() %>";
    function quit() { if (confirm("<%=Tag("您确定要退出吗？")%>")) return true; else return false; }
</script>

</head>
<body>
<div id="body_head">
  <div class="admintop">
    <div id="logo">
        <a href="<%=site.AdminPath %>/ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"></a>
        <%=LicenseString %>
    </div>
    <%=Version %>
    <div class="admininfo">
        <div id="NewEvent">
            <span><%=Tag("未确认")%></span><em><a href="<%=site.AdminPath %>/order/default.aspx?t=211&type=1"><span id="NewEvent_Order_IsVerified"><%=SYS.NewEvent_Order_IsVerified%></span></a></em>
            <span><%=Tag("已支付")%></span><em><a href="<%=site.AdminPath %>/order/default.aspx?t=211&type=4"><span id="NewEvent_Order_IsPaid"><%=SYS.NewEvent_Order_IsPaid%></span></a></em>
            <span><%=Tag("未发货")%></span><em class="noborder"><a href="<%=site.AdminPath %>/order/default.aspx?t=211&type=5"><span id="NewEvent_Order_IsShipped"><%=SYS.NewEvent_Order_IsShipped%></span></a></em>
        </div>
    </div>
    <%if (Tips()!=""){ %><div id="tips"><%=Tips() %></div><%} %>
    <div id="service">
        <div class="layout">
          <div class="adminface" onmousehover="">
            <img src="<%=CurrentAdmin.Avatar%>" alt="[<%=Lang(CurrentAdminGroup.Name)%>]<%=CurrentAdmin.UserName%>" />
          </div>
          <div class="adminfacepop">
              <a href="javascript:AdminPWD(0);"><%=Tag("改密")%></a>
              <a href="<%=site.AdminPath %>/Logout.aspx" onclick="return quit()"><%=Tag("注销")%></a>
              <a href="<%=site.WebPath %>/" target="_blank"><%=Tag("网站前台")%></a>
          </div>
        </div>
    </div>
    <div class="clearfix">
    </div>
    <div class="navmenu">
        <ul id="shopmenu" class="menu">
            <%foreach (Shop.Model.Lebi_Menu menu in TopMenus)
                { %>
            <li class="<%=CurrentTopMenu.id==menu.id?"current":"" %>"><a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=<%=menu.id %>"><span><img src="<%if (menu.Image != ""){ %><%=GetImage(site.WebPath + menu.Image) %><%}else{%><%=site.AdminImagePath%>/icon/plugin.png<%} %>" /><%=Tag(menu.Name)%></span></a> </li>
            <%} %>
        </ul>
        <ul class="menu">
            <li class="menuline"></li>
            <li><a href="javascript:void(0);" onclick="updateadmin();"><span><img src="<%=site.AdminImagePath%>/icon/reh.png" /><%=Tag("系统刷新")%></span></a></li>
            <li><a href="javascript:void(0);" onclick="UpdateCache(0);"><span><img src="<%=site.AdminImagePath%>/icon/cache.png" /><%=Tag("更新缓存")%></span></a></li>
            <li><a href="javascript:void(0);" onclick="UpdateCache(1);"><span><img src="<%=site.AdminImagePath%>/icon/data.png" /><%=Tag("数据同步")%></span></a></li>
            <li><a href="<%=site.AdminPath%>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><span><img src="<%=site.AdminImagePath%>/icon/dasktop.png" /><%=Tag("桌面") %></span></a></li>
            <li><a href="<%=site.WebPath %>/" target="_blank"><span><img src="<%=site.AdminImagePath%>/icon/web.png" /><%=Tag("网站前台")%></span></a></li>
            <li><a href="javascript:void(0);" onclick="Copyright();"><span><img src="<%=site.AdminImagePath%>/icon/about.png" /><%=Tag("关于") %></span></a></li>
        </ul>
        
    </div>
  </div>
</div>
<div id="body_content">
<div id="sidebar">
    <div class="menubar ">
        <%if (desk == 1)
            { 
        %>
        <h2><span><img src="<%=site.AdminImagePath %>/2015/minus.png" id="img1" /> <%=Tag("快捷菜单")%></span></h2>
        <ul class="clear">
            <%foreach (Shop.Model.Lebi_Menu menu in GetIndexMenus()){ %><li><a href="<%=MenuUrl(menu.URL,1) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
        </ul>
        <% }else{ %>
        <%foreach (Shop.Model.Lebi_Menu pmenu in GetMenus(CurrentTopMenu.id)){ %>
        <h2><span><img mid="<%=pmenu.id %>" src="<%=site.AdminImagePath %>/2015/<%=MenuShow(pmenu.id)==true?"minus":"plus" %>.png" id="imgStatis" /> <%=Tag(pmenu.Name)%></span></h2>
        <ul class="clear" <%=MenuShow(pmenu.id)==true?"":"style=\"display:none;\"" %>>
            <%foreach (Shop.Model.Lebi_Menu menu in GetMenus(pmenu.Code)){ %><li><a href="<%=MenuUrl(menu.URL,0) %>"><span><%=Tag(menu.Name)%></span></a></li><%}%>
        </ul>
        <%} } %>
    </div>
</div>
<div id="sideplus">
    <a href="javascript:void()" onclick="switchSysBar()"><span class="navPoint" id="switchPoint" title="<%=Tag("关闭/打开左栏")%>"><img src="<%=site.AdminImagePath%>/2015/left.png" alt="<%=Tag("关闭/打开左栏")%>" /></span></a>
</div>
<div id="sidecontent" class="clear">
    <div class="mainbody_path" id="body_path">
      
    <div class="tools">
    <ul>
    <%if (PageReturnMsg == ""){%>
    <li class="submit"><a href="javascript:void(0);" onclick="Update();"><b></b><span><%=Tag("保存")%></span></a></li>
    <li class="up"><a href="javascript:void(0);" onclick="Product_Status_Edit_muti(1);"><b></b><span><%=Tag("上架")%></span></a></li>
    <li class="down"><a href="javascript:void(0);" onclick="Product_Status_Edit_muti(0);"><b></b><span><%=Tag("下架")%></span></a></li>
    <%}%>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/product/product_batch_edit.aspx"><%=Tag("批量修改")%></a></span></li>
    </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <% LicenseWord(); %>
    <div class="searchbox">
        <select id="lang">
            <option value="">┌<%=Tag("语言")%></option>
            <%=Shop.Bussiness.Language.LanguageOption(lang) %>
        </select>
        <select name="status" id="status">
            <option value="0">┌<%=Tag("状态")%></option>
            <%=Shop.Bussiness.EX_Type.TypeOption("ProductStatus", status, CurrentLanguage)%>
        </select>
        <select id="Type_id_ProductType" name="Type_id_ProductType">
            <option value="320">┌<%=Tag("商品类型")%></option>
            <%=Shop.Bussiness.EX_Type.TypeOption("ProductType", Type_id_ProductType, CurrentLanguage)%>
        </select>
        <select id="Pro_Type_id" name="Pro_Type_id">
            <option value="">┌<%=Tag("全部类别")%></option>
            <%=Shop.Bussiness.EX_Product.TypeOption(0,Pro_Type_id,0,CurrentLanguage.Code)%>
        </select>
        <select id="brand" name="brand">
            <option value="0">┌<%=Tag("商品品牌")%></option>
            <%=Shop.Bussiness.EX_Product.BrandOption(brand, CurrentLanguage.Code)%>
        </select>
        <select id="tag" name="tag">
            <option value="0">┌<%=Tag("商品标签")%></option>
            <%=Shop.Bussiness.EX_Product.Pro_TagOption(tag, CurrentLanguage.Code)%>
        </select>
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" /> - <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" />
        &nbsp;<input name="key" type="text" id="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" /><input type="button" id="btnSou" class="btn-query" onclick="search_();" align="absmiddle" />
    </div>
    <table id="list" class="datalist">
        <tr class="title">
            <th width="40" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'sonproductid\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));"><%=Tag("全选")%></a>
            </th>
            <th width="40">
                <%=Tag("图片")%>
            </th>
            <th width="80">
                <%=Tag("编号")%>
            </th>
            <th width="*">
                <%=Tag("商品名称")%>
            </th>
            <th width="80">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "Price_MarketDesc"){Response.Write("Price_MarketAsc");}else{Response.Write("Price_MarketDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("市场价")%><%if (OrderBy == "Price_MarketDesc") { Response.Write("↓"); } else if (OrderBy == "Price_MarketAsc") { Response.Write("↑"); }%></a>
            </th>
            <th width="80">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "PriceDesc"){Response.Write("PriceAsc");}else{Response.Write("PriceDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("销售价")%><%if (OrderBy == "PriceDesc") { Response.Write("↓"); } else if (OrderBy == "PriceAsc") { Response.Write("↑"); }%></a>
            </th>
            <%if (Shop.Bussiness.EX_Admin.CheckPower("product_price_cost")){ %>
            <th width="80">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "Price_CostDesc"){Response.Write("Price_CostAsc");}else{Response.Write("Price_CostDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("成本价")%><%if (OrderBy == "Price_CostDesc") { Response.Write("↓"); } else if (OrderBy == "Price_CostAsc") { Response.Write("↑"); }%></a>
            </th>
            <%} %>
            <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_product_price")){ %>
                <%foreach(Shop.Model.Lebi_UserLevel ul in userlevels){ %>
                <th width="60">
                    <%=Lang(ul.Name) %>
                </th>
                <%} %>
            <%}%>
            <%if (!IsEditStock){ %>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "CountDesc"){Response.Write("CountAsc");}else{Response.Write("CountDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("库存")%><%if (OrderBy == "CountDesc") { Response.Write("↓"); } else if (OrderBy == "CountAsc") { Response.Write("↑"); }%></a>
            </th>
            <%}%>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "FreezeDesc"){Response.Write("FreezeAsc");}else{Response.Write("FreezeDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("冻结库存")%><%if (OrderBy == "FreezeDesc") { Response.Write("↓"); } else if (OrderBy == "FreezeAsc") { Response.Write("↑"); }%></a>
            </th>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "SalesDesc"){Response.Write("SalesAsc");}else{Response.Write("SalesDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("显示销量")%><%if (OrderBy == "SalesDesc") { Response.Write("↓"); } else if (OrderBy == "SalesAsc") { Response.Write("↑"); }%></a>
            </th>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "ViewsDesc"){Response.Write("ViewsAsc");}else{Response.Write("ViewsDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("浏览量")%><%if(OrderBy == "ViewsDesc"){Response.Write("↓");}else if (OrderBy == "ViewsAsc"){Response.Write("↑");}%></a>
            </th>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "SortDesc"){Response.Write("SortAsc");}else{Response.Write("SortDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("排序")%><%if(OrderBy == "SortDesc"){Response.Write("↓");}else if (OrderBy == "SortAsc"){Response.Write("↑");}%></a>
            </th>
            <th width="60">
                <a href="javascript:void(0);" onclick="OrderBy('?OrderBy=<%if(OrderBy == "StatusDesc"){Response.Write("StatusAsc");}else{Response.Write("StatusDesc");}%>');" title="<%=Tag("点击排序")%>"><%=Tag("状态")%><%if (OrderBy == "StatusDesc") { Response.Write("↓"); } else if (OrderBy == "StatusAsc") { Response.Write("↑"); }%></a>
            </th>
        </tr>
        <%foreach (Shop.Model.Lebi_Product model in models)
          {
          List<Shop.Model.ProductUserLevelPrice> ulps=Shop.Bussiness.EX_Product.UserLevelPrice(model.UserLevelPrice);
          %>
            <tr class="list" ondblclick="Edit(<%=model.id %>,0);">
                <td style="text-align:center">
                    <input type="checkbox" ShopKeyID="true" name="sonproductid" id="<%=model.id %>" value="<%=model.id %>" />
                    <input type="hidden" name="IDS" shop="true" value="<%=model.id %>" />
                </td>
                <td>
                    <a href="<%=Image(model.ImageOriginal,"big") %>" data-lightbox="image<%=model.id %>"><img style="height: 30px;width: 30px;vertical-align:middle" src="<%=Image(model.ImageOriginal,50,50) %>" /></a>
                </td>
                <td>
                    <input type="text" name="Number<%=model.id %>" id="Number<%=model.id %>" class="input" shop="true" value="<%=model.Number%>" style="width: 80px;" />
                </td>
                <td>
                    <%int i = 0; foreach (Shop.Model.Lebi_Language_Code batchlang in Shop.Bussiness.Language.Languages())
                      {%><input type="<%if (lang == batchlang.Code){%>text<%}else{ %>hidden<%} %>" name="Name<%=model.id %><%=batchlang.Code %>" id="Name<%=batchlang.Code %><%=model.id %>" class="input" shop="true" value="<%=Shop.Bussiness.Language.Content(model.Name, batchlang.Code)%>" style="width: 250px;" /><%i = i+1;
                      } %>&nbsp;<a href="javascript:void(0)" title="<%=Tag("点击编辑商品名称")%>" onclick="Product_Name_Edit(<%=model.id %>);"><img
                    src="<%=PageImage("icon/toolsEdit.png")%>" /></a>&nbsp;<a target="_blank" href="<%=Shop.Bussiness.ThemeUrl.GetURL("P_Product",model.id.ToString(),"",CurrentLanguage.Code)%>"><img src="<%=PageImage("icon/newWindow.png")%>" /></a>
                
                </td>
                <td>
                    <input type="text" name="Price_Market<%=model.id %>" id="Price_Market<%=model.id %>" class="input"
            shop="true" value="<%=FormatMoney(model.Price_Market,"Number") %>" style="width: 70px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
                </td>
                <td>
                    <input type="text" name="Price<%=model.id %>" id="Price<%=model.id %>" class="input"
            shop="true" value="<%=FormatMoney(model.Price,"Number") %>" style="width: 80px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
                </td>
                <%if (Shop.Bussiness.EX_Admin.CheckPower("product_price_cost")){ %>
                <td>
                    <input type="text" name="Price_Cost<%=model.id %>" id="Price_Cost<%=model.id %>" class="input"
            shop="true" value="<%=FormatMoney(model.Price_Cost,"Number") %>" style="width: 80px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
                </td>
                <%} %>
                <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_product_price")){ %>
                    <%foreach(Shop.Model.Lebi_UserLevel ul in userlevels){ %>
                    <td>
                        <input type="text" name="UserLevelPrice<%=model.id %>_<%=ul.id %>" id="UserLevelPrice<%=model.id %>_<%=ul.id %>" class="input"
                shop="true" value="<%=FormatMoney(GetUserLevelPrice(ulps,ul.id),"Number") %>" style="width: 80px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
                    </td>
                    <%} %>
                <%} %>
                <%if (!IsEditStock){ %>
                <td>
                    <%if (CountSon(model.id) == 0)
                      { %>
                    <input type="text" name="Count_Stock<%=model.id %>" id="Count_Stock<%=model.id %>" class="input"
            shop="true" value="<%=model.Count_Stock %>" style="width: 80px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
                    <%}else{ %>
                    <input type="hidden" name="Count_Stock<%=model.id %>" id="Count_Stock<%=model.id %>" shop="true" value="<%=model.Count_Stock %>" /><%=model.Count_Stock %>
                    <%} %>
                </td>
                <%}%>
                <td>
                    <input type="text" name="Count_Freeze<%=model.id %>" id="Count_Freeze<%=model.id %>" class="input"
            shop="true" value="<%=model.Count_Freeze %>" style="width: 60px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
                </td>
                <td>
                    <input type="text" name="Count_Sales_Show<%=model.id %>" id="Count_Sales_Show<%=model.id %>" class="input"
            shop="true" value="<%=model.Count_Sales_Show %>" style="width: 60px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
                </td>
                <td>
                    <input type="text" name="Count_Views_Show<%=model.id %>" id="Count_Views_Show<%=model.id %>" class="input"
            shop="true" value="<%=model.Count_Views_Show %>" style="width: 60px;" onkeyup="value=value.replace(/[^\d\.]/g,'')" />
                </td>
                <td>
                    <input type="text" name="Sort<%=model.id %>" id="Sort<%=model.id %>" class="input"
            shop="true" value="<%=model.Sort %>" style="width: 60px;" onkeyup="value=value.replace(/[^\d]/g,'')" />
                </td>
                <td>
                    <select name="ProductStatus<%=model.id %>" id="ProductStatus<%=model.id %>" shop="true">
                        <%=Shop.Bussiness.EX_Type.TypeOption("ProductStatus", model.Type_id_ProductStatus, CurrentLanguage)%>
                    </select>
                </td>
            </tr>
        <%} %>
    </table>
    <script type="text/javascript">
        function search_() {
            var lang = $("#lang").val();
            var key = $("#key").val();
            var brand = $("#brand").val();
            var Pro_Type_id = $("#Pro_Type_id").val();
            var tag = $("#tag").val();
            var dateFrom = $("#dateFrom").val();
            var dateTo = $("#dateTo").val();
            var status = $("#status").val();
            var Type_id_ProductType = $("#Type_id_ProductType").val();
            window.location = "?key=" + escape(key) + "&brand=" + brand + "&tag=" + tag + "&Pro_Type_id=" + Pro_Type_id + "&dateFrom=" + dateFrom + "&dateTo=" + dateTo + "&status=" + status + "&lang=" + lang +"&Type_id_ProductType=" + Type_id_ProductType + "&OrderBy=<%=OrderBy%>";
        }
        function Update() {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Product_Batch_Update";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Product_Name_Edit(id) {
            var lang = $("#lang").val();
            var title_ = "<%=Tag("编辑商品名称")%>";
            var url_ = "product_name_edit_window.aspx?removelang=" + lang +"&id=" + id;
            var width_ = 560;
            var height_ = 200;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function OrderBy(url) {
            MsgBox(4, "<%=Tag("正在排序，请稍后")%> ……", url);
        }
        function Product_Status_Edit_muti(status) {
            var postData = GetFormJsonData("ShopKeyID");
            var url = "<%=site.AdminPath %>/ajax/ajax_product.aspx?__Action=Product_Status_Edit_muti&status=" + status;
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function Product_Sales(number) {
            var title_ = "<%=Tag("销量")%>"; 
            var height_ = 300;
            var url_ = "product_sales_window.aspx?number=" + number;
            var width_ = 650;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Product_Freeze(number) {
            var title_ = "<%=Tag("冻结库存")%>"; 
            var height_ = 300;
            var url_ = "product_freeze_window.aspx?number=" + number;
            var width_ = 560;
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
    </script>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
<div class="bottom" id="body_bottom">
    <%=PageString%>
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
                          if (CurrentAdminLanguage.Name == "")
                            {%><%=Tag("语言选择")%><%}else{%><%=CurrentAdminLanguage.Name%><%} %></a>
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
</div>
</div>
<div id="sound"></div>
<script src="<%=site.AdminJsPath %>/lightbox/lightbox.min.js"></script>
<script>
    function Copyright() {
        var title_ = "<%=Tag("关于")%>";
        var url_ = "<%=site.AdminPath %>/Config/Copyright_window.aspx";
        var width_ = 500;
        var height_ = 'auto';
        var modal_ = true;
        EditWindow(title_, url_, width_, height_, modal_);
    }
    function UpdateCache(type) {
        var postData = ""; 
        if (type == 0){
            postData = {'datatype':'languagetag,producttype,config,themepage'};
        }else{
            postData = {'datatype':'dbbody,lebitype,lebimenu,lebipage'};
        }
        var url = "<%=site.AdminPath %>/ajax/ajax_db.aspx?__Action=CacheReset";
        RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "")});
    }
    function updateadmin(){
        var url="<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=UpdateAdmin";
        RequestAjax(url,"",function(res){RequestAjax("<%=site.AdminPath %>/ajax/ajax_db.aspx?__Action=CacheReset","{'datatype':'dbbody'}",function(){MsgBox(1, "<%=Tag("操作成功")%>", "")});});
    }
    function NewEvent(){
        GetNewEvent();
        setTimeout(function(){NewEvent();},<%=SYS.NewEventTimes%>);
    }
    function PlayAudio(){
        <%if (config.NewEventPlayAudio=="1"){%>
        $('#sound').html('<audio autoplay="autoplay"><source src="<%=site.AdminImagePath %>/msg.mp3" type="audio/mpeg"><source src="<%=site.AdminImagePath %>/msg.wav" type="audio/wav"></audio>');
        <%}%>
    }
    setTimeout(function(){NewEvent();},<%=LeftNewEventTimes%>);
</script>
</body>
</html>