<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.storeConfig.BaseConfig_edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("基本设置") %>-<%=site.title%></title>

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

    <script type="text/javascript">
        function setCount2(entity) {
            var gnum = parseInt(entity.value);
            var sumc = 50;
            if (isNaN(gnum)) { gnum = 1; }
            if (gnum > sumc) {
                entity.value = sumc;
            }
            else if (gnum <= 1) {
                entity.value = 1;
            } else {
                entity.value = gnum;
            }
        }
    </script>
    <style>
        .bottom{height: 0;overflow: hidden;display: none;}
    </style>

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
            <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("保存")%></span></a></li>
            <%}%>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a>
                >
                <%=Tag("基本设置") %></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <table class="table">
        <tbody>
            <%--<tr>
            <th>
                <%=Tag("开启静态")%>：
            </th>
            <td>
                <input type="radio" name="HtmlFlag" value="1" shop="true" <%=model.HtmlFlag=="1"?"checked":"" %> /><%=Tag("开启")%>
                <input type="radio" name="HtmlFlag" value="0" shop="true" <%=model.HtmlFlag=="0"?"checked":"" %> /><%=Tag("关闭")%>
            </td>
        </tr>--%>
            <tr>
                <th>
                    <%=Tag("开启发票")%>：
                </th>
                <td>
                    <label><input type="radio" name="BillFlag" value="1" shop="true" <%=model.BillFlag=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="BillFlag" value="0" shop="true" <%=model.BillFlag=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("匿名购买")%>：
                </th>
                <td>
                    <label><input type="radio" name="IsAnonymousUser" value="1" shop="true" <%=model.IsAnonymousUser=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="IsAnonymousUser" value="0" shop="true" <%=model.IsAnonymousUser=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("购物车提示页")%>：
                </th>
                <td>
                    <label><input type="radio" name="IsBasketAction" value="1" shop="true" <%=model.IsBasketAction=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="IsBasketAction" value="0" shop="true" <%=model.IsBasketAction=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("减少购物车步骤")%>：
                </th>
                <td>
                    <label><input type="radio" name="IsReduceBasketStep" value="1" shop="true" <%=model.IsReduceBasketStep=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="IsReduceBasketStep" value="0" shop="true" <%=model.IsReduceBasketStep=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("0库存自动下架")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="IsNullStockDown" value="1" shop="true" <%=model.IsNullStockDown=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="IsNullStockDown" value="0" shop="true" <%=model.IsNullStockDown=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("允许负库存销售")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="IsNullStockSale" value="1" shop="true" <%=model.IsNullStockSale=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="IsNullStockSale" value="0" shop="true" <%=model.IsNullStockSale=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
             <tr>
                <th>
                    <%=Tag("冻结库存时机")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="ProductStockFreezeTime" value="orderadd" shop="true" <%=model.ProductStockFreezeTime=="orderadd"?"checked":"" %> /><%=Tag("下单")%></label>
                        <label>
                            <input type="radio" name="ProductStockFreezeTime" value="orderconfirm" shop="true" <%=model.ProductStockFreezeTime=="orderconfirm"?"checked":"" %> /><%=Tag("确认订单")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("已付款订单自动确认")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="IsOpenPaidOrderConfirm" value="1" shop="true" <%=model.IsOpenPaidOrderConfirm=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="IsOpenPaidOrderConfirm" value="0" shop="true" <%=model.IsOpenPaidOrderConfirm=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("积分兑换余额")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="IsPointToMoney" value="1" shop="true" <%=model.IsPointToMoney=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="IsPointToMoney" value="0" shop="true" <%=model.IsPointToMoney=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("开启退换货")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="IsClosetuihuo" value="0" shop="true" <%=model.IsClosetuihuo=="0"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="IsClosetuihuo" value="1" shop="true" <%=model.IsClosetuihuo=="1"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("开启供应商收款")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="IsSupplierCash" value="1" shop="true" <%=model.IsSupplierCash=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="IsSupplierCash" value="0" shop="true" <%=model.IsSupplierCash=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("前台多币种展示金额")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="IsMutiCurrencyShow" value="1" shop="true" <%=model.IsMutiCurrencyShow=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="IsMutiCurrencyShow" value="0" shop="true" <%=model.IsMutiCurrencyShow=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("开启会员有效期")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="IsOpenUserEnd" value="1" shop="true" <%=model.IsOpenUserEnd=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="IsOpenUserEnd" value="0" shop="true" <%=model.IsOpenUserEnd=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                            &nbsp;&nbsp;&nbsp;
                            <%=Tag("默认有效期天数")%>：
                            <input onkeyup="value=value.replace(/[^\d\.]/g,'');" type="text" id="DefaultUserEndDays"
                                name="DefaultUserEndDays" value="<%=model.DefaultUserEndDays %>" class="input"
                                style="width: 70px;" shop="true" />
                </td>
            </tr>
            <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_productlimit")){%>
            <tr>
                <th>
                    <%=Tag("商品权限设置")%>：
                </th>
                <td>
                    <label><input type="radio" name="ProductLimitType" value="1" shop="true" <%=model.ProductLimitType=="1"?"checked":"" %> /><%=Tag("选中表示允许")%></label>
                    <label><input type="radio" name="ProductLimitType" value="0" shop="true" <%=model.ProductLimitType=="0"?"checked":"" %> /><%=Tag("选中表示拒绝")%></label>
                </td>
            </tr>
            <%}%>
            <tr>
                <th>
                    <%=Tag("会员注册验证类型")%>：
                </th>
                <td>
                    <label><input type="checkbox" name="UserRegCheckedType" value="mobilephone" shop="true" <%=model.UserRegCheckedType.Contains("mobilephone")?"checked":"" %> /><%=Tag("手机")%></label>
                    <label><input type="checkbox" name="UserRegCheckedType" value="email" shop="true" <%=model.UserRegCheckedType.Contains("email")?"checked":"" %> />Email</label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("同手机号多次注册")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="IsMobilePhoneMutiReg" value="1" shop="true" <%=model.IsMobilePhoneMutiReg=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="IsMobilePhoneMutiReg" value="0" shop="true" <%=model.IsMobilePhoneMutiReg=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                    <em><%=Tag("开启手机短信注册验证时有效")%></em>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("商品编号规则")%>：
                </th>
                <td>
                    <%=Tag("前缀")%>：<input type="text" id="ProductNumberPrefix" name="ProductNumberPrefix" value="<%=model.ProductNumberPrefix %>" class="input" style="width: 70px;" shop="true" />&nbsp;&nbsp;<%=Tag("长度")%>：<input type="text" id="ProductNumberLength" name="ProductNumberLength" value="<%=model.ProductNumberLength %>" class="input" style="width: 70px;" shop="true" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("点击数假象规律")%>：
                </th>
                <td>
                    <input type="radio" name="ClickFlag" value="0" shop="true" <%=model.ClickFlag=="0"?"checked":"" %> />
                    <%=Tag("增加固定数字")%>
                    <input onkeyup="setCount2(this);" type="text" id="ClickNum1" name="ClickNum1" value="<%=model.ClickNum1 %>"
                        class="input" style="width: 70px;" shop="true" />
                    <em>
                        <%=Tag("填写1-50之间的数字")%></em><br />
                    <input type="radio" name="ClickFlag" value="1" shop="true" <%=model.ClickFlag=="1"?"checked":"" %> />
                    <%=Tag("增加随机数字")%>
                    <input onkeyup="setCount2(this);" type="text" id="ClickNum2" name="ClickNum2" class="input"
                        value="<%=model.ClickNum2 %>" style="width: 70px;" shop="true" />
                    <em>
                        <%=Tag("随机生成数字的最大值，最大值设定为50")%></em>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("销售数假象规律")%>：
                </th>
                <td>
                    <input type="radio" name="SalesFlag" value="0" shop="true" <%=model.SalesFlag=="0"?"checked":"" %> />
                    <%=Tag("增加固定数字")%>
                    <input onkeyup="setCount2(this);" type="text" id="SalesNum1" name="SalesNum1" value="<%=model.SalesNum1 %>"
                        class="input" style="width: 70px;" shop="true" />&nbsp;<em><%=Tag("填写1-50之间的数字")%></em><br />
                    <input type="radio" name="SalesFlag" value="1" shop="true" <%=model.SalesFlag=="1"?"checked":"" %> />
                    <%=Tag("增加随机数字")%>
                    <input onkeyup="setCount2(this);" type="text" id="SalesNum2" name="SalesNum2" class="input"
                        value="<%=model.SalesNum2 %>" style="width: 70px;" shop="true" />
                    <em>
                        <%=Tag("随机生成数字的最大值，最大值设定为50")%></em>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("消费税")%>：
                </th>
                <td>
                    <input onkeyup="value=value.replace(/[^\d\.]/g,'');" type="text" id="TaxRate" name="TaxRate" value="<%=model.TaxRate %>" class="input" style="width: 70px;" shop="true" /> %
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("最低提现金额")%>(<%=DefaultCurrency.Msige %>)：
                </th>
                <td>
                    <input onkeyup="value=value.replace(/[^\d\.]/g,'');" type="text" id="TakeMoneyLimit"
                        name="TakeMoneyLimit" value="<%=model.TakeMoneyLimit %>" class="input" style="width: 70px;"
                        shop="true" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("提现手续费")%>：
                </th>
                <td>
                    <input onkeyup="value=value.replace(/[^\d\.]/g,'');" type="text" id="WithdrawalFeeRate"
                        name="WithdrawalFeeRate" value="<%=model.WithdrawalFeeRate %>" class="input" style="width: 70px;"
                        shop="true" /> %
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("商品评分奖励积分")%>：
                </th>
                <td>
                    <input onkeyup="value=value.replace(/[^\d]/g,'');" type="text" id="CommentPoint"
                        name="CommentPoint" value="<%=model.CommentPoint %>" class="input" style="width: 70px;"
                        shop="true" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("订单自动收货")%>：
                </th>
                <td>
                    <input onkeyup="value=value.replace(/[^\d]/g,'');" type="text" id="OrderReceivedDays"
                        name="OrderReceivedDays" value="<%=model.OrderReceivedDays %>" class="input"
                        style="width: 70px;" shop="true" />
                    <em>
                        <%=Tag("天") %></em>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("订单自动完结")%>：
                </th>
                <td>
                    <input onkeyup="value=value.replace(/[^\d]/g,'');" type="text" id="OrderCompleteDays"
                        name="OrderCompleteDays" value="<%=model.OrderCompleteDays %>" class="input"
                        style="width: 70px;" shop="true" />
                    <em>
                        <%=Tag("天") %></em>
                </td>
            </tr>
            
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("文件上传限制")%>：
                </th>
                <td>
                    <input onkeyup="value=value.replace(/[^\d\.]/g,'');" type="text" id="UpLoadLimit"
                        name="UpLoadLimit" value="<%=model.UpLoadLimit %>" class="input" style="width: 70px;"
                        shop="true" />
                    <em>M</em>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("文件上传路径")%>：
                </th>
                <td>
                    <input type="text" id="UpLoadPath" name="UpLoadPath" value="<%=model.UpLoadPath %>"
                        class="input" style="width: 150px;" shop="true" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("文件上传前缀")%>：
                </th>
                <td>
                    <input type="text" id="UpLoadRName" name="UpLoadRName" value="<%=model.UpLoadRName %>"
                        class="input" style="width: 150px;" shop="true" />
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("文件上传命名")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="UpLoadSaveName" value="0" shop="true" <%=model.UpLoadSaveName=="0"?"checked":"" %> /><%=Tag("当前时间")%></label>
                        <label>
                            <input type="radio" name="UpLoadSaveName" value="1" shop="true" <%=model.UpLoadSaveName=="1"?"checked":"" %> /><%=Tag("保持原名")%></label>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("后台使用语言")%>：
                </th>
                <td>
                    <input type="text" id="AdminLanguages" name="AdminLanguages" value="<%=model.AdminLanguages %>"
                        class="input" style="width: 150px;" shop="true" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("非法词过滤")%>：
                </th>
                <td>
                    <textarea id="Filter" cols="80" rows="5" class="textarea" style="height: 60px; width: 550px;"
                        name="Filter" shop="true"><%=model.Filter%></textarea>
                    <div class="tools clear">
                        <ul>
                            <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Filter',100);">
                                <b></b><span>
                                    <%=Tag("展开")%></span></a></li>
                            <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Filter',-100)">
                                <b></b><span>
                                    <%=Tag("收缩")%></span></a></li>
                            <li class="tips"><span><em>
                                <%=Tag("多个词用/隔开")%></em></span></li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("API密码")%>：
                </th>
                <td>
                    <input type="text" id="APIPassWord" name="APIPassWord" value="<%=model.APIPassWord %>"
                        class="input" style="width: 150px;" shop="true" />
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("允许站外AJAX请求")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="IsAllowOutSideAjax" value="0" shop="true" <%=model.IsAllowOutSideAjax=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                        <label>
                            <input type="radio" name="IsAllowOutSideAjax" value="1" shop="true" <%=model.IsAllowOutSideAjax=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("信任IP")%>：
                </th>
                <td>
                    <textarea id="SafeIPs" cols="80" rows="5" class="textarea" style="height: 60px; width: 550px;"
                        name="SafeIPs" shop="true"><%=model.SafeIPs%></textarea>
                     <div class="tools clear">
                        <ul>
                            
                            <li class="tips"><span><em>
                                <%=Tag("多个词用,隔开")%></em></span></li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr>
                <th style="vertical-align:top">
                    <%=Tag("新事件刷新时间")%>：
                </th>
                <td>
                    <input type="text" id="NewEventTimes" name="NewEventTimes" value="<%=model.NewEventTimes %>" class="input" style="width: 70px;" shop="true" onkeyup="value=value.replace(/[^\d\.]/g,'');" /> <em><%=Tag("毫秒")%></em>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("新事件播放声音")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="NewEventPlayAudio" value="1" shop="true" <%=model.NewEventPlayAudio=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="NewEventPlayAudio" value="0" shop="true" <%=model.NewEventPlayAudio=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("网页传输")%>：
                </th>
                <td>
                    <label><input type="radio" name="HTTPServer" value="http" shop="true" <%=model.HTTPServer=="http"?"checked":"" %> /><%=Tag("不加密")%></label>
                    <label><input type="radio" name="HTTPServer" value="https" shop="true" <%=model.HTTPServer=="https"?"checked":"" %> /><%=Tag("加密")%></label>
                </td>
            </tr>
            <tr>
                <th colspan="2" class="head">
                    <%=Tag("退税设置")%>
                </th>
        </tr>
        <tr>
            <th style="vertical-align:top">
                <%=Tag("最低购物总额")%>：
            </th>
            <td>
                <input onkeyup="value=value.replace(/[^\d\.]/g,'');" type="text" id="Refund_MinMoney" name="Refund_MinMoney" value="<%=model.Refund_MinMoney %>" class="input" style="width: 70px;" shop="true" />
            </td>
        </tr>
        <tr>
            <th style="vertical-align:top">
                <%=Tag("增值税率")%>：
            </th>
            <td>
                <input onkeyup="value=value.replace(/[^\d\.]/g,'');" type="text" id="Refund_VAT" name="Refund_VAT" value="<%=model.Refund_VAT %>" class="input" style="width: 70px;" shop="true" /> %
            </td>
        </tr>
        <tr>
            <th style="vertical-align:top">
                <%=Tag("函数率")%>：
            </th>
            <td align="left">
                 <table cellpadding="0" cellspacing="0" style="width:350px" class="stepRtable" align="left" id="stepRtable">
                    <tr>
                        <th style="width:150px;text-align:center;">
                            <%=Tag("购物总额")%> >
                        </th>
                        <th style="width:150px;text-align:center;">
                            <%=Tag("函数率")%>
                        </th>
                        <th style="width:100px;text-align:center;">
                            <%=Tag("操作")%> [<a href="javascript:addstepR();"><%=Tag("增加")%></a>]
                        </th>
                    </tr>
                    <%foreach(Shop.Model.BaseConfigStepR stepR in stepRs){ %>
                    <tr>
                        <td>
                            <input type="text" class="input" shop="true"  name="Refund_Step_S" style="width: 70px;" value="<%=stepR.S %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                        </td>
                        <td>
                            <input type="text" class="input" shop="true"  name="Refund_Step_R" style="width: 70px;" value="<%=stepR.R %>" onkeyup="value=value.replace(/[^.\d]/g,'')" />
                        </td>
                        <td>
                            <a href="javascript:void(0);" onclick="$(this).parent().parent().remove();"><%=Tag("删除")%></a>
                        </td>
                    </tr>
                    <%} %>
                 </table>
            </td>
        </tr>
            <tr>
                <th colspan="2" class="head">
                    <%=Tag("验证码")%>
                </th>
            </tr>
            <tr>
                <th>
                    <%=Tag("会员注册")%>：
                </th>
                <td>
                    <label><input type="radio" name="Verifycode_UserRegister" value="1" shop="true" <%=model.Verifycode_UserRegister=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="Verifycode_UserRegister" value="0" shop="true" <%=model.Verifycode_UserRegister=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("会员登录")%>：
                </th>
                <td>
                    <label><input type="radio" name="Verifycode_UserLogin" value="1" shop="true" <%=model.Verifycode_UserLogin=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="Verifycode_UserLogin" value="0" shop="true" <%=model.Verifycode_UserLogin=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("忘记密码")%>：
                </th>
                <td>
                    <label><input type="radio" name="Verifycode_ForgetPassword" value="1" shop="true" <%=model.Verifycode_ForgetPassword=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="Verifycode_ForgetPassword" value="0" shop="true" <%=model.Verifycode_ForgetPassword=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("商家注册")%>：
                </th>
                <td>
                    <label><input type="radio" name="Verifycode_SupplierRegister" value="1" shop="true" <%=model.Verifycode_SupplierRegister=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="Verifycode_SupplierRegister" value="0" shop="true" <%=model.Verifycode_SupplierRegister=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("商家登录")%>：
                </th>
                <td>
                    <label><input type="radio" name="Verifycode_SupplierLogin" value="1" shop="true" <%=model.Verifycode_SupplierLogin=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="Verifycode_SupplierLogin" value="0" shop="true" <%=model.Verifycode_SupplierLogin=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("管理登陆")%>：
                </th>
                <td>
                    <label><input type="radio" name="Verifycode_AdminLogin" value="1" shop="true" <%=model.Verifycode_AdminLogin=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                    <label><input type="radio" name="Verifycode_AdminLogin" value="0" shop="true" <%=model.Verifycode_AdminLogin=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
            <tr>
                <th colspan="2" class="head">
                    <%=Tag("文章审核")%>
                </th>
            </tr>
            <tr>
                <th>
                    <%=Tag("评论")%>：
                </th>
                <td>
                    <label>
                        <input type="radio" name="CommFlag" value="1" shop="true" <%=model.CommFlag=="1"?"checked":"" %> /><%=Tag("开启")%></label>
                        <label>
                            <input type="radio" name="CommFlag" value="0" shop="true" <%=model.CommFlag=="0"?"checked":"" %> /><%=Tag("关闭")%></label>
                </td>
            </tr>
        </tbody>
    </table>
    <script type="text/javascript">
        function uploadImage(id) {
            $.ajaxFileUpload
        (
	        {
	            url: WebPath + '/ajax/imageuploadone.aspx?path=config',
	            secureuri: false,
	            fileElementId: 'file_' + id,
	            dataType: 'json',
	            success: function (data, status) {

	                if (data.msg != 'OK') {
	                    MsgBox(2, data.error, "");
	                }
	                else {
	                    var imageUrl = data.ImageUrl;
	                    if (imageUrl.length > 0) {
	                        $("#image_" + id + "").html('<img height="30" src=' + WebPath + imageUrl + '>');
	                        $("#" + id + "").val(imageUrl);
	                    }
	                }

	            },
	            error: function (data, status, e) {
	                MsgBox(2, data.msg, "");
	            }
	        }
        )
        }
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url="<%=site.AdminPath %>/ajax/ajax_site.aspx?__Action=BaseConfig_Edit";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "")});
        }
        LanguageTab_EditPage('<%=CurrentLanguage.Code %>'); //加载默认语言
        function addstepR()
        {
            var row='<tr><td><input type="text" class="input"  shop="true"  name="Refund_Step_S" style="width: 70px;" value="" onkeyup="value=value.replace(/[^\\d]/g,\'\')" /></td>';
            row+='<td><input type="text" class="input"  shop="true"  name="Refund_Step_R" style="width: 70px;" value="" onkeyup="value=value.replace(/[^.\\d]/g,\'\')" /></td>';
            row+='<td><a href="javascript:void(0);" onclick="$(this).parent().parent().remove();"><%=Tag("删除")%></a></td></tr>';
            $("#stepRtable").append(row);
        }
    </script>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
    <div class="bottom" id="body_bottom">
        <input type="hidden" id="pwd" runat="server" />
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