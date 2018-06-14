<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.customxs" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title>销售报表-<%=site.title%></title>

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
        $(document).ready(function(){$("li.menu ul").hide();$("li.menu").bind("mouseover",function(){$(this).find("ul").slideDown("fast")});$("li.menu ul").bind("mouseleave",function(){$(this).slideUp("fast")})});
        function roadstock(id)
        {
            $.ajax({
                type: 'POST',
                url: "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=productRoadStock&id="+id,
                data: '',
                dataType: 'html',
                success: function(res){
                    //document.write(res);
                    $('#rs'+id).html(res);
                }
            });
        }
    </script>
    <link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath %>/prettyphoto/css/prettyPhoto.css" />
    <script language="javascript" type="text/javascript" src="<%=site.AdminJsPath %>/prettyphoto/jquery.prettyphoto.js"></script>
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=site.AdminJsPath %>/multiselect/js/jquery.multiselect2side.js"></script>
    <link rel="stylesheet" href="<%=site.AdminJsPath %>/multiselect/css/jquery.multiselect2side.css" type="text/css" media="screen" />
    <style>
        .headtable {
            width: 100%;
        }

            .headtable tr {
                border-bottom: 0px solid #ececec;
            }

                .headtable tr td {
                    border-bottom: 0px solid #ececec;
                    width: 33%;
                }

        .datalist .list td {
            border-bottom: 1px solid #ececec;
            color: #808080;
            line-height: 150%;
            padding: 5px 10px;
            text-align: left;
            white-space: normal;
            word-break: normal;
            word-wrap: break-word;
        }
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

            <li class="add"><a href="javascript:void(0);" onclick="daochu();"><b></b><span><%=Tag("导出")%></span></a></li>
            <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/product/"><%=Tag("销售报表")%></a></span></li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            

    <div class="searchbox">
        品牌：
        <select name="brand" id="brand">
           <option value="0">全部</option>
            <%=pinpailist(brand)%>
        </select>
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" style="width:150px" />
        -
        <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" style="width:150px" />

        <input name="key" type="text" id="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_(<%=Pro_Type_id%>);}" /><input type="button" id="btnSou" class="btn-query" onclick="search_(<%=Pro_Type_id%>);" align="absmiddle" />
        <%if(ptype.id>0){%>
        当前分类：<%=Lang(ptype.Name)%>
        <%}%>

        <div style="margin-top:5px;">

        </div>
        <div id="data">
            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                <tr>
                    <td style="width:150px;vertical-align:top">
                        <table style="background: #f4f4f4" width="100%">
                            <%=Lebi.ERP.other.CreateTree(0,0,CurrentLanguage.Code) %>
                        </table>
                    </td>
                    <td style="vertical-align:top">
                        <table class="datalist">
                            <tr class="title">

                                <th style="width: 150px">
                                    <%=Tag("会员")%>
                                </th>
                                <th style="width: 150px">
                                    客户名称
                                </th>
                                <th style="width: 80px">
                                    <%=Tag("金额")%>
                                </th>
                                <th style="width: 80px">
                                    <%=Tag("数量")%>
                                </th>
                                <th>
                                    <%=Tag("操作")%>
                                </th>
                            </tr>
                            <%
                            int total_Count = 0;
                            decimal total_Money = 0;
                            foreach (Shop.Model.Lebi_User user in users)
                            {
                            total_Count += user.Count_Order;
                            total_Money += user.Money;
                            %>
                            <tr class="list">
                                <td>
                                    <%=user.UserName%>
                                </td>
                                <td>
                                    <%=user.NickName%>
                                </td>
                                <td>
                                    <%=user.Money%>
                                </td>
                                <td>
                                    <%=user.Count_Order%>
                                </td>

                                <td>
                                    <a href="javascript:void(0)" onclick="show(<%=user.id%>)">明细</a>

                                </td>
                            </tr>
                            <tr class="list" id="son<%=user.id%>" style="display:none">
                                <td></td>
                                <td colspan="3">
                                    <table>
                                        <tr>
                                            <td>单号</td>
                                            <td>商品编号</td>
                                            <td>商品名称</td>
                                            <td>时间</td>
                                            <td>金额</td>
                                            <td>数量</td>
                                        </tr>
                                        <%
                                        foreach (var p in getproducts(user.id))
                                        {
                                        //decimal m=0;
                                        //int count=procount(order.id,out m);
                                        %>
                                        <tr>
                                            <td><%=p.Order_Code%></td>
                                            <td><%=p.Product_Number%></td>
                                            <td><%=Lang(p.Product_Name)%></td>
                                            <td><%=p.Time_Add%></td>
                                            <td><%=p.Money%></td>
                                            <td><%=p.Count%></td>
                                        </tr>
                                        <%}%>
                                    </table>
                                </td>

                            </tr>
                            <%} %>
                            <tr class="list">
                                <td colspan="2" style="text-align:right;font-weight:bold">合计：</td>
                                <td style="font-weight:bold"><%=total_Money%></td>
                                <td style="font-weight:bold"><%=total_Count%></td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <script type="text/javascript">

            function search_(id) {
                var key = $("#key").val();
                var brand = $("#brand").val();
                var dateFrom=$('#dateFrom').val();
                var dateTo=$('#dateTo').val();
                window.location = "?key=" + escape(key) + "&brand="+brand+'&Pro_Type_id='+id+'&dateFrom='+dateFrom+'&dateTo='+dateTo;
            }
            function daochu()
            {
                var key = $("#key").val();
                var brand = $("#brand").val();
                var dateFrom=$('#dateFrom').val();
                var dateTo=$('#dateTo').val();
                window.location = "../ajax/ajax_ex.aspx?__Action=export_productsale&key=" + escape(key) + "&brand="+brand+'&Pro_Type_id=<%=Pro_Type_id%>&dateFrom='+dateFrom+'&dateTo='+dateTo;
               
            }
            function show(id)
            {
                if($('#son'+id).is(":hidden"))
                {
                    $('#son'+id).show()
                }else{
                    $('#son'+id).hide()
                }
            }


            function searchproduct(id)
            {

                search_(id);
            }

        </script>
        <script src="<%=WebPath%>/plugin/Lebi.ERP/js/tree.js" type="text/javascript"></script>

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