<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.statis.supplierorder_product" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("订单报表")%>-<%=site.title%></title>

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
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
     > <a href="<%=site.AdminPath %>/statis/supplierorder.aspx"><%=Tag("订单报表")%></a>
     > <%=Tag("按供应商")%>
     </span></li>
    </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <div class="proBox clear">
    <ul class="btns clear">
        <li class="submit" onclick="submit();"><%=Tag("提交")%></li>
        <li class="add" onclick="exportorder();"><%=Tag("导出")%></li>
    </ul>
    <div class="iTabHead">
        <table class="table">
        <tr>
            <th>
                <%=Tag("关键词")%>：
            </th>
            <td>
                <input type="text" id="key" name="key" class="input-query" value="<%=key %>" />
            </td>
        </tr>
         <tr>
            <th>
                <%=Tag("单号")%>：
            </th>
            <td>
                <input type="text" id="orderkey" name="orderkey" class="input-query" value="<%=orderkey %>" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("订购日期")%>：
            </th>
            <td>
                <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom%>" readonly /> - <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo%>" readonly />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("支付状态")%>：
            </th>
            <td>
                <select name="IsPay" id="IsPay">
                    <option value="-1">┌<%=Tag("全部")%></option>
                    <option value="0" <%=IsPay == 0?"selected":"" %>><%=Tag("未支付")%></option>
                    <option value="1" <%=IsPay == 1?"selected":"" %>><%=Tag("已支付")%></option>
                </select>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("支付方式")%>：
            </th>
            <td>
                <select name="Pay_id" id="Pay_id">
                    <option value="0">┌<%=Tag("全部")%></option>
                    <%foreach (Shop.Model.Lebi_Pay pay in pays){%>
                    <option value="<%=pay.id %>" <%=Pay_id == pay.id?"selected":"" %>><%=Shop.Bussiness.Language.Content(pay.Name, CurrentLanguage.Code)%></option>
                    <%} %>
                </select>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("配送方式")%>：
            </th>
            <td>
                <select name="Transport_id" id="Transport_id">
                    <option value="0">┌<%=Tag("全部")%></option>
                    <%foreach (Shop.Model.Lebi_Transport transport in transports)
                      {%>
                    <option value="<%=transport.id %>" <%=Transport_id == transport.id?"selected":"" %>><%=transport.Name%></option>
                    <%} %>
                </select>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("供应商")%>：
            </th>
            <td>
                <select name="supplier_id" id="supplier_id">
                    <option value="">┌<%=Tag("全部")%></option>
                    <option value="0">┌<%=Tag("商城")%></option>
                    <%foreach (Shop.Model.Lebi_Supplier sup in suppliers){%>
                    <option value="<%=sup.id %>" <%=supplier_id == sup.id.ToString()?"selected":"" %>><%=sup.SubName%></option>
                    <%} %>
                </select>
            </td>
        </tr>
    </table>
    </div>
    </div>
        <table class="datalist">
            <tr class="title">
                <th><%=Tag("序号")%></th>
                <th><%=Tag("供应商")%></th>
                <th><%=Tag("配送点")%></th>
                <th><%=Tag("单号")%></th>
                <th><%=Tag("订购日期")%></th>
                <th><%=Tag("支付状态")%></th>
                <th><%=Tag("支付方式")%></th>
                <th><%=Tag("配送方式")%></th>
                <th><%=Tag("商品名称")%></th>
                <th><%=Tag("条形码")%></th>
                <th><%=Tag("商品条码")%></th>
                <th><%=Tag("单位")%></th>
                <th><%=Tag("数量")%></th>
                <th><%=Tag("金额")%></th>
            </tr>
            <%
            int i=0;
            foreach(Shop.Model.Lebi_Order_Product pro in pros){
            Shop.Model.Lebi_Order order =Shop.Bussiness.Order.GetOrder(pro.Order_id);
            i++; %>
            <tr class="list">
                <td><%=i%></td>
                <td><%=GetSupplier(order.Supplier_id).SubName%></td>
                <td><%=GetDelivery(order.Supplier_Delivery_id).Name%></td>
                <td><%=order.Code%></td>
                <td><%=order.Time_Add%></td>
                <td><%=order.IsPaid==1?Tag("已支付"):Tag("未支付")%></td>
                <td><%=Lang(order.Pay)%>
                    <%=Lang(order.OnlinePay)%>
                </td>
                <td><%=order.Transport_Name%></td>
                <td>
                <%=Lang(pro.Product_Name) %> 
                </td>
                <td>
                <%=pro.Product_Number %>
                </td>
                <td>
                <%=Shop.Bussiness.EX_Product.GetProduct(pro.Product_id).Code %>
                </td>
                <td>
                <%=Lang(Shop.Bussiness.EX_Product.ProductUnit(Shop.Bussiness.EX_Product.GetProduct(pro.Product_id).Units_id))%>
                </td>
                <td>
                <%=pro.Count %>
                </td>
                <td><%=FormatMoney(pro.Price * pro.Count)%></td>
            </tr>
            <%} %>
        </table> 

    <script type="text/javascript">
        function submit() {
            var key = $("#key").val();
            var orderkey = $("#orderkey").val();
            var dateFrom = $("#dateFrom").val();
            var dateTo = $("#dateTo").val();
            var IsPay = $("#IsPay").val();
            var Pay_id = $("#Pay_id").val();
            var Transport_id = $("#Transport_id").val();
            var supplier_id = $("#supplier_id").val();
            if (dateFrom == "" || dateTo == "") {
                MsgBox(1, "<%=Tag("请选择订购日期")%>", "")
            }
            window.location = "?key=" + escape(key) + "&orderkey=" + escape(orderkey) + "&dateFrom=" + dateFrom + "&dateTo=" + dateTo + "&IsPay=" + IsPay + "&Pay_id=" + Pay_id + "&Transport_id=" + Transport_id + "&supplier_id=" + supplier_id;
        }
        function exportorder()
        {
            window.location="../ajax/export.aspx?__Action=SupplierOrder_product_Export&where=<%=where %>";
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