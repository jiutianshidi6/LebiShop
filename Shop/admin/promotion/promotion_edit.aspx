<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.promotion.Promotion_Edit" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>
        <%if (model.id != 0)
          { %>
        <%=Tag("编辑促销")%>
        <%}
          else
          { %><%=Tag("添加促销")%>
        <%}%>-<%=Tag("优惠促销")%>-<%=site.title%></title>


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

    <script type="text/javascript" src="<%=site.AdminJsPath %>/ajaxfileupload.js"></script>
    <script type="text/javascript" src="<%=site.AdminJsPath %>/multiselect/js/jquery.multiselect2side.js"></script>
    <link rel="stylesheet" href="<%=site.AdminJsPath %>/multiselect/css/jquery.multiselect2side.css" type="text/css" media="screen" />

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
            <li class="rotate"><a href="javascript:void(0);" onclick="history.back();">
                <b></b><span><%=Tag("返回")%></span></a></li>
            <li class="name"><span id="navIgation">
                <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> >
                <%=Tag("营销")%>
                > <a href="<%=site.AdminPath %>/Promotion/default.aspx"> <%=Tag("优惠促销")%></a> 
                > <%=Lang(pt.Name)%>
                > <%=model.id ==0?Tag("添加规则"):Tag("编辑规则")%>
                </span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            
    <table
        class="datatitle">
        <tr>
            <td>
                <%=Tag("基本信息")%>
            </td>
        </tr>
    </table>
    <div class="proBox clear">
        <ul class="btns clear">
            <li class="add" onclick="SaveObj(0);">
                <%=Tag("保存")%></li>
            
        </ul>
        <table class="table">
            <tr style="width:230px;">
                <th style="vertical-align:top">
                    <%=Tag("内部备注")%>：
                </th>
                <td>
                    <input type="text" name="Remark" id="Remark" shop="true" class="input" style="width: 550px;" value="<%=model.Remark%>">
                    
                </td>
            </tr>
            <tr>
                <th>
                    <%=Tag("优先级")%>：
                </th>
                <td>
                    <input type="text" id="Sort" name="Sort" style="width: 70px" shop="true" class="input"
                        value="<%=model.Sort %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                </td>
            </tr>
            
        </table>
    </div>
    <%if (model.id > 0)
      { %>
    <table
        class="datatitle">
        <tr>
            <td>
                <%=Tag("触发条件")%>
            </td>
        </tr>
    </table>
     <div class="proBox clear">
        <ul class="btns clear">
            <li class="add" onclick="SaveObj();">
                <%=Tag("保存")%></li>
            
        </ul>
        <table class="datalist" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr class="list">
                <td style="width:30px;"> <input type="checkbox" value="1" id="IsCase801" name="IsCase801" shop="true" <%=setChecked(model.IsCase801) %> /></td>
                <td style="width:200px;text-align:left;">
                    <%=Tag("订单金额大于")%>：
                </td>
                <td>
                    <input type="text" id="Case801" name="Case801" style="width: 70px" shop="true" class="input"
                        value="<%=FormatMoney(model.Case801,"Number") %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                </td>
            </tr>
            <tr class="list">
                <td> <input type="checkbox" value="1" id="IsCase802" name="IsCase802" shop="true" <%=setChecked(model.IsCase802) %> /></td>
                <td style="text-align:left;">
                    <%=Tag("订单商品数量大于")%>：
                </td>
                <td>
                    <input type="text" id="Case802" name="Case802" style="width: 70px" shop="true" class="input"
                        value="<%=model.Case802 %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                </td>
            </tr>
            
            

            <tr class="list">
                <td valign="top"> <input type="checkbox" onclick="SetStatus();" value="1" id="IsCase804" name="IsCase804" shop="true" <%=setChecked(model.IsCase804) %>/></td>
                <td valign="top" style="text-align:left;">
                    <%=Tag("限制分类")%>(<%=Tag("指定商品")%>)：
                </td>
                <td>
                    <select name="Case804" id="Case804" shop="true" multiple="multiple" size="8">
                        <option value="0" <%=model.Case804=="0"?"selected":"" %>><%=Tag("全部") %></option>
                        <%=Shop.Bussiness.EX_Product.TypeOption(0, model.Case804, 0, CurrentLanguage.Code)%>
                    </select>
                </td>
            </tr>
            <tr class="list">
                <td valign="top"> <input type="checkbox" onclick="SetStatus();" value="1" id="IsCase805" name="IsCase805" shop="true" <%=setChecked(model.IsCase805) %>/></td>
                <td valign="top" style="text-align:left;">
                    <%=Tag("限制商品")%>(<%=Tag("指定商品")%>)：
                </td>
                <td>
                    <textarea name="Case805" id="Case805" shop="true" rows="3" cols="60" class="textarea" onkeydown="checkMaxInput(this.form)" onkeyup="checkMaxInput(this.form)" style="height: 60px; width: 550px;"><%=model.Case805%></textarea>
                    <div class="tools clear">
                        <ul>
                            <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Case805',100);"><b></b><span><%=Tag("展开")%></span></a></li>
                            <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Case805',-100)"><b></b><span><%=Tag("收缩")%></span></a></li>
                        <li class="tips"><span><em><%=Tag("使用,分隔商品编号")%></em></span></li>
                        </ul>
                    </div>
                </td>
            </tr>
            <tr class="list">
                <td> <input type="checkbox" value="1" id="IsCase803" name="IsCase803" shop="true" <%=setChecked(model.IsCase803) %> /></td>
                <td style="text-align:left;">
                    <%=Tag("指定商品单品重复购买大于")%>N：
                </td>
                <td>
                    <input type="text" id="Case803" name="Case803" style="width: 70px" shop="true" class="input"
                        value="<%=model.Case803 %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                </td>
            </tr>
            <tr class="list">
                <td> <input type="checkbox" value="1" id="IsCase806" name="IsCase806" shop="true" <%=setChecked(model.IsCase806) %> /></td>
                <td style="text-align:left;">
                    <%=Tag("指定商品购买数量大于")%>N：
                </td>
                <td>
                    <input type="text" id="Case806" name="Case806" style="width: 70px" shop="true" class="input"
                        value="<%=model.Case806 %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                </td>
            </tr>
        </table>
    </div>
    <%}
        if (model.IsSetCase == 1)
        { %>
    <table
        class="datatitle">
        <tr>
            <td>
                <%=Tag("促销方式")%>
            </td>
        </tr>
    </table>
     <div class="proBox clear">
        <ul class="btns clear">
            <li class="add" onclick="SaveObj();">
                <%=Tag("保存")%></li>
            
        </ul>
        <table class="datalist" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr class="list">
                <td style="width:30px;"> <input type="checkbox" IsRule="true" id="IsRule901" value="1" name="IsRule901" shop="true" <%=setChecked(model.IsRule901) %>/></td>
                <td style="width:200px;text-align:left;">
                    <%=Tag("定额运费")%>(<%=Tag("自营") %>)：
                </td>
                <td>
                    <input type="text" id="Rule901" name="Rule901" style="width: 70px" shop="true" class="input"
                        value="<%=FormatMoney(model.Rule901,"Number") %>" onkeyup="value=value.replace(/[^\d]/g,'')" /> 
                </td>
            </tr>
            <tr class="list">
                <td><input type="checkbox" value="1" IsRule="true" id="IsRule902" name="IsRule902" shop="true" <%=setChecked(model.IsRule902) %>/></td>
                <td style="text-align:left;">
                    <%=Tag("打折")%>：
                </td>
                <td>
                    <input type="text" id="Rule902" name="Rule902" style="width: 70px" shop="true" class="input"
                        value="<%=model.Rule902 %>" onkeyup="value=value.replace(/[^\d]/g,'')" /> %
                </td>
            </tr>
            <tr class="list">
                <td><input type="checkbox" value="1" IsRule="true" id="IsRule903" name="IsRule903" shop="true" <%=setChecked(model.IsRule903) %>/></td>
                <td style="text-align:left;">
                    <%=Tag("打折")%>(<%=Tag("指定商品")%>)：
                </td>
                <td>
                    <input type="text" id="Rule903" name="Rule903" style="width: 70px" shop="true" class="input"
                        value="<%=model.Rule903 %>" onkeyup="value=value.replace(/[^\d]/g,'')" /> %
                </td>
            </tr>
            <tr class="list">
                <td><input type="checkbox" value="1" IsRule="true" id="IsRule912" name="IsRule912" shop="true" <%=setChecked(model.IsRule903) %>/></td>
                <td style="text-align:left;">
                    <%=Tag("打折")%>(<%=Tag("第N个指定商品")%>)：
                </td>
                <td>
                    <input type="text" id="Rule912" name="Rule912" style="width: 70px" shop="true" class="input"
                        value="<%=model.Rule912 %>" onkeyup="value=value.replace(/[^\d]/g,'')" /> %
                </td>
            </tr>
            <tr class="list">
                <td><input type="checkbox" value="1" IsRule="true" id="IsRule904" name="IsRule904" shop="true" <%=setChecked(model.IsRule904) %>/></td>
                <td style="text-align:left;">
                    <%=Tag("减免现金")%>：
                </td>
                <td>
                    <input type="text" id="Rule904" name="Rule904" style="width: 70px" shop="true" class="input"
                        value="<%=FormatMoney(model.Rule904,"Number") %>" onkeyup="value=value.replace(/[^\d]/g,'')" />(<%=DefaultCurrency.Msige%>)
                </td>
            </tr>
            <tr class="list">
                <td><input type="checkbox" value="1" IsRule="true" id="IsRule905" name="IsRule905" shop="true" <%=setChecked(model.IsRule905) %>/></td>
                <td style="text-align:left;">
                    <%=Tag("返还现金")%>：
                </td>
                <td>
                    <input type="text" id="Rule905" name="Rule905" style="width: 70px" shop="true" class="input"
                        value="<%=FormatMoney(model.Rule905,"Number") %>" onkeyup="value=value.replace(/[^\d]/g,'')" />(<%=DefaultCurrency.Msige%>)
                </td>
            </tr>
            <tr class="list">
                <td><input type="checkbox" value="1" IsRule="true" id="IsRule906" name="IsRule906" shop="true" <%=setChecked(model.IsRule906) %>/> </td>
                <td style="text-align:left;">
                   <%=Tag("送积分")%>：
                </td>
                <td>
                    <input type="text" id="Rule906" name="Rule906" style="width: 70px" shop="true" class="input"
                        value="<%=model.Rule906 %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                </td>
            </tr>
            <tr class="list">
                <td><input type="checkbox" value="1" IsRule="true" id="IsRule907" name="IsRule907" shop="true" <%=setChecked(model.IsRule907) %>/></td>
                <td style="text-align:left;">
                    <%=Tag("翻倍积分")%>：
                </td>
                <td>
                    <input type="text" id="Rule907" name="Rule907" style="width: 70px" shop="true" class="input"
                        value="<%=model.Rule907 %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                </td>
            </tr>
            
            <tr class="list">
                <td><input type="checkbox" value="1" IsRule="true" id="IsRule908" name="IsRule908" shop="true" <%=setChecked(model.IsRule908) %> /> </td>
                <td style="text-align:left;">
                   <%=Tag("翻倍积分")%>(<%=Tag("指定商品")%>)：
                </td>
                <td>
                    <input type="text" id="Rule908" name="Rule908" style="width: 70px" shop="true" class="input"
                        value="<%=model.Rule908 %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                </td>
            </tr>
            
            
            <tr class="list">
                <td><input type="checkbox" value="1" IsRule="true" id="IsRule910" name="IsRule910" shop="true" <%=setChecked(model.IsRule910) %>/> </td>
                <td style="text-align:left;">
                   <%=Tag("赠送商品")%>(<%=Tag("指定商品")%>)：
                </td>
                <td>
                    <input type="text" id="Rule910" name="Rule910" style="width: 70px" shop="true" class="input"
                        value="<%=model.Rule910 %>" onkeyup="value=value.replace(/[^\d]/g,'')" />
                    (<%=Tag("数量")%>)
                </td>
            </tr>
            
        </table>
    </div>
    <%} %>
    <script type="text/javascript">
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_sale.aspx?__Action=Promotion_Edit&tid=<%=pt.id %>&id=<%=model.id %>";
            <%if(model.IsSetCase==0){ %>
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", '?id='+res.id)});
            <%}else{ %>
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", '')});
            <%} %>
        }
        function SetStatus()
        {
            if(($("#IsCase804").attr("checked")==true || $("#IsCase804").attr("checked")=='checked') || ($("#IsCase805").attr("checked")==true || $("#IsCase805").attr("checked")=='checked') )
            {
               $("#IsCase803").attr("disabled",false);
               $("#Case803").attr("disabled",false);
               $("#IsCase806").attr("disabled",false);
               $("#Case806").attr("disabled",false);
               $("#IsRule903").attr("disabled",false);
               $("#Rule903").attr("disabled",false);
               $("#IsRule908").attr("disabled",false);
               $("#Rule908").attr("disabled",false);
               $("#IsRule910").attr("disabled",false);
               $("#Rule910").attr("disabled",false);
               $("#IsRule912").attr("disabled",false);
               $("#Rule912").attr("disabled",false);
            }
            else{
               $("#IsCase803").attr("checked",false);
               $("#IsCase803").attr("disabled","disabled");
               $("#Case803").attr("disabled","disabled");
               $("#IsCase806").attr("checked",false);
               $("#IsCase806").attr("disabled","disabled");
               $("#Case806").attr("disabled","disabled");
               $("#IsRule903").attr("checked",false);
               $("#IsRule903").attr("disabled","disabled");
               $("#Rule903").attr("disabled","disabled");
               $("#IsRule908").attr("checked",false);
               $("#IsRule908").attr("disabled","disabled");
               $("#Rule908").attr("disabled","disabled");
               $("#IsRule910").attr("checked",false);
               $("#IsRule910").attr("disabled","disabled");
               $("#Rule910").attr("disabled","disabled");
               $("#IsRule912").attr("checked",false);
               $("#IsRule912").attr("disabled","disabled");
               $("#Rule912").attr("disabled","disabled");
            }
        }
        $().ready(function () {
        $('#Case804').multiselect2side({
            selectedPosition: 'right',
            moveOptions: false,
            //search: "<img src='img/search.gif' align=\"absmiddle\" /> ",
            labelsx: '',
            labeldx: '',
            autoSort: false,
            autoSortAvailable: false
        });
        SetStatus();
        });
        
       $('[IsRule]').each(function (i) {
           $(this).click(function () {
               if($(this).attr("checked")==true || $(this).attr("checked")=='checked')
               {
                   var cname=$(this).attr("name");
                   $('[IsRule]').each(function (j) {
                       if($(this).attr("name")!=cname){
                           $(this).attr("checked",false);
                       }
                   });
               }
           });
        });
        

    </script>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
<div class="bottom" id="body_bottom"></div>

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