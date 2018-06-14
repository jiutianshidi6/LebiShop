<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.checkout" validateRequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta content="text/html; charset=UTF-8" http-equiv="content-type" />
<meta name="author" content="LebiShop" />

    <title><%=Tag("收银台")%>-<%=Tag("进销存")%>-<%=site.title%></title>

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

    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script>
    <style>
        .cotitle {
            width: 600px;
            height: 28px;
            background-color: antiquewhite;
            line-height: 28px;
            padding: 0 0 0 10px;
            margin: 5px 0 10px 0;
        }

        .cotable {
            width: 600px;
        }

            .cotable th {
                text-align: right;
            }

            .cotable td {
                padding: 3px 0 3px 10px;
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
            <li class="name">
                <span id="navIgation">
                    <%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <%=Tag("进销存")%>
                    > <%=Tag("收银台")%> > <%=order.Order_id>0?Tag("退货"):Tag("新订单")%>
                </span>
            </li>
        </ul>
    </div>

    </div>
    <%if (PageReturnMsg == ""){%>
        
        
    <%}%>
    <div class="mainbody" id="body_main">
        <div id="body_main_form">
          <%if (PageReturnMsg == ""){%>
            

    <table class="list">
        <tr>
            <td style="width:700px;padding:0 10px 0 0;height:800px;" valign="top">
                <div class="tools tools-m clear" style="margin-bottom:8px;">
                    <span style="color:red;font-size:20;font-weight:bold">
                        <%if(order.Order_id>0){%>
                        退货：<font style="color:#808080;font-size:12;">原单：<a href="order_view.aspx?id=<%=torder.id%>" target="_blank"><%=torder.Code%></a></font>
                        <%}else{%>
                        新单：
                        <%}%>
                        </font>
                        <%if(order.id>0 && order.Order_id==0){%>
                        <ul>
                            <li class="text">
                                <input name="pnumber" id="pnumber" class="input" value="<%=Tag(" 商品编号")%>" onfocus="if (this.value == '<%=Tag("商品编号")%>') this.value = '';" onblur="if (this.value == '') this.value = '<%=Tag("商品编号")%>';"/>
                            </li>
                            <li class="add">
                                <a href="javascript:void(0);" onclick="selectproduct(0);"><b></b><span><%=Tag("添加")%></span></a>

                            </li>
                            <li class="add">
                                <a href="javascript:void(0)" onclick="searchprodutwindow();"><span><%=Tag("查询商品")%></span></a>
                            </li>
                            <li class="del"><a href="javascript:void(0);" onclick="Pro_Del(<%=order.id %>);"><b></b><span><%=Tag("删除")%></span></a></li>
                        </ul>
                        <%}%>
                </div>
                <table class="datalist">
                    <tr class="title">
                        <th style="width: 30px">
                            <a href="javascript:void(0);" onclick="$('input[name=\'proid\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));"><%=Tag("全选")%></a>
                        </th>
                        <th style="width: 50px">
                            <%=Tag("图片")%>
                        </th>
                        <th style="width: 60px">
                            <%=Tag("编号")%>
                        </th>
                        <th style="width: 150px">
                            <%=Tag("名称")%>
                        </th>
                        <th style="width: 70px">
                            <%=Tag("规格")%>
                        </th>
                        <th style="width: 50px">
                            <%=Tag("单位")%>
                        <th style="width: 70px">
                            <%=Tag("库存")%>
                        </th>
                        <th style="width: 70px">
                            <%=Tag("价格")%>
                        </th>
                        <%if(order.Order_id>0){%>
                        <th style="width: 70px">
                            <%=Tag("购买")%>
                        </th>
                        <th style="width: 70px">
                            <%=Tag("已退")%>
                        </th>
                        <%}%>
                        <th style="width: 70px">
                            <%=Tag("数量")%>
                        </th>
                    </tr>
                    <tbody id="orderproductlist"></tbody>
                </table>
            </td>
            <td style="padding:0 0 0 10px;border-left: 1px solid #d4caca;" valign="top">
                <%=Tag("订单编号")%>：<%=order.Code%>

                <%=Tag("生成时间")%>：<%=order.id>0?order.Time_Add.ToString("yyyy-MM-dd HH:mm:ss"):""%>
                <div class="cotitle">
                    <%=Tag("账号信息")%>
                    &nbsp;&nbsp;&nbsp;
                    <input type="button" onclick="searchuserwindow();" value="<%=Tag(" 查询会员")%>" style="width:70px;height:25px" />

                </div>
                <table class="cotable">
                    <tr>
                        <th style="width: 15%">
                            <%=Tag("分组")%>：
                        </th>
                        <td style="width: 35%">
                            <%=Lang(userlevel.Name)%>
                        </td>
                        <th style="width: 15%">

                        </th>
                        <td></td>
                    </tr>
                    <tr>
                        <th style="width: 15%">
                            <%=Tag("公司")%>：
                        </th>
                        <td style="width: 35%">
                            <%=user.NickName%>
                        </td>
                        <th style="width: 15%">
                            <%=Tag("采购人")%>：
                        </th>
                        <td>
                            <%=user.Company_caigou_name%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("负责人姓名")%>：
                        </th>
                        <td>
                            <%=user.RealName%>
                        </td>
                        <th>
                            <%=Tag("采购电话")%>：
                        </th>
                        <td>
                            <%=user.Company_caigou_phone%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("负责人手机")%>：
                        </th>
                        <td>
                            <%=user.MobilePhone%>
                        </td>
                        <th>
                            <%=Tag("采购QQ")%>：
                        </th>
                        <td>
                            <%=user.Company_caigou_qq%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            负责人QQ：
                        </th>
                        <td>
                            <%=user.QQ%>
                        </td>
                        <th>
                            <%=Tag("采购微信")%>：
                        </th>
                        <td>
                            <%=user.Company_caigou_weixin%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("负责人微信")%>：
                        </th>
                        <td>
                            <%=user.weixin%>
                        </td>
                        <th>

                        </th>
                        <td></td>
                    </tr>
                </table>
                <div class="cotitle">
                    <%=Tag("收货信息")%>
                </div>
                <table class="cotable">
                    <%if(IsTuiHuo){%>
                    <tr>
                        <th style="width: 15%">
                            <%=Tag("收货人")%>：
                        </th>
                        <td>
                            <%=fahuo.UserName%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("电话")%>：
                        </th>
                        <td>
                            <%=fahuo.Tel%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("手机")%>：
                        </th>
                        <td>
                            <%=fahuo.Mobile%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("邮编")%>：
                        </th>
                        <td>
                            <%=fahuo.ZipCode%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("城市")%>：
                        </th>
                        <td>
                            <%=fahuo.City%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("地址")%>：
                        </th>
                        <td>
                            <%=fahuo.Address%>
                        </td>
                    </tr>

                    <%}else{%>
                    <tr>
                        <th style="width: 15%">
                            <%=Tag("收货人")%>：
                        </th>
                        <td>
                            <input type="text" shoporder="true" min="notnull" id="T_Name" name="T_Name" class="input"
                                   value="<%=order.T_Name %>" style="width: 300px;" onchange="saveorder();" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("邮箱")%>：
                        </th>
                        <td>
                            <input type="text" shoporder="true" min="notnull" id="T_Email" name="T_Email" class="input"
                                   value="<%=order.T_Email %>" style="width: 300px;" onchange="saveorder();" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("手机")%>：
                        </th>
                        <td>
                            <input type="text" shoporder="true" min="notnull" id="T_MobilePhone" name="T_MobilePhone"
                                   class="input" value="<%=order.T_MobilePhone %>" style="width: 300px;" onchange="saveorder();" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("电话")%>：
                        </th>
                        <td>
                            <input type="text" shoporder="true" min="notnull" id="T_Phone" name="T_Phone" class="input"
                                   value="<%=order.T_Phone %>" style="width: 300px;" onchange="saveorder();" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("邮编")%>：
                        </th>
                        <td>
                            <input type="text" shoporder="true" min="notnull" id="T_Postalcode" name="T_Postalcode"
                                   class="input" value="<%=order.T_Postalcode %>" style="width: 300px;" onchange="saveorder();" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("地区")%>：
                        </th>
                        <td id="Area_id_div"></td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("地址")%>：
                        </th>
                        <td>
                            <input type="text" shoporder="true" min="notnull" id="T_Address" name="T_Address" class="input"
                                   value="<%=order.T_Address %>" style="width: 400px;" onchange="saveorder();" />
                        </td>
                    </tr>
                    <%}%>
                </table>
                <div class="cotitle">
                    <%=Tag("其它信息")%>
                </div>

                <table class="cotable">

                    
                    <tr>
                        <th style="width: 15%">
                            <%=Tag(IsTuiHuo?"退货仓":"发货仓")%>：
                        </th>
                        <td>
                            <select id="store_id" name="store_id" shoporder="true" class="input fromstore" onchange="saveorder();">
                                <%=Lebi.ERP.other.storeoptionsAll(0) %>
                            </select>

                        </td>
                    </tr>
                    
                    <tr>
                        <th>
                            <%=Tag("备注")%>：
                        </th>
                        <td>
                            <textarea name="Remark_Admin" onchange="saveorder();" shoporder="true" style="width:450px;height:80px"><%=order.Remark_Admin%></textarea>

                        </td>
                    </tr>
                </table>
                <div class="cotitle">
                    <%=Tag(IsTuiHuo?"退款":"付款")%>
                </div>
                <table class="cotable">
                    <tr>
                        <th style="width: 15%">
                            <%=Tag("余额")%>：
                        </th>
                        <td>
                            <%=user.Money-user.Money_fanxian%>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <%if(user.id>0 && !IsTuiHuo){%>
                            <a href="javascript:money_add('<%=user.UserName%>',<%=user.id%>)"><%=Tag("充值")%></a>
                            <%}%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("返利余额")%>：
                        </th>
                        <td>
                            <%=user.Money_fanxian%>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <%=Tag("其它费用")%>：
                        </th>
                        <td>
                            <input type="text" value="<%=order.Money_Property%>" onchange="saveorder();" name="Money_Property" shoporder="true" style="width:90px;" onkeyup="value=value.replace(/[^\d\.-]/g,'')" />
                        </td>
                    </tr>
                    <%if(user.Money_fanxian>0){%>
                    <tr>
                        <th>
                            <%=Tag("返利支付")%>：
                        </th>
                        <td>
                            <input type="text" name="Money_fanxianpay" value="<%=order.Money_fanxianpay%>" onchange="saveorder();" shoporder="true" style="width:90px;" onkeyup="value=value.replace(/[^\d\.-]/g,'')" />
                        </td>
                    </tr>
                    <%}%>
                    <tr>
                        <th>
                            <%=Tag(order.Order_id==0?"应付金额":"应退金额")%>：
                        </th>
                        <td>
                            <span style="color:brown;font-size:20;font-weight:bold" id="paymoney"><%=order.Money_Pay%></span>
                        </td>
                    </tr>
                    <tr>
                        <th>

                        </th>
                        <td>
                            <%if(IsTuiHuo){%>
                            <input type="button" onclick="pay('s');" <%=CanPay?"":"disabled=\"disabled\""%> value="生成订单" style="width:70px;height:50px" />

                            <input type="button" onclick="pay('s,p');" <%=CanPay?"":"disabled=\"disabled\""%> value="生成并退款" style="width:70px;height:50px" />

                            <input type="button" onclick="pay('s,p,k');" <%=CanPay?"":"disabled=\"disabled\""%> value="生成退款并收货" style="width:100px;height:50px" />

                            <%}else{%>
                            <input type="button" onclick="pay('s');" <%=CanPay?"":"disabled=\"disabled\""%> value="生成订单" style="width:70px;height:50px" />

                            <input type="button" onclick="pay('s,p');" <%=CanPay?"":"disabled=\"disabled\""%> value="生成并付款" style="width:70px;height:50px" />

                            <input type="button" onclick="pay('s,p,k');" <%=CanPay?"":"disabled=\"disabled\""%> value="生成付款并发货" style="width:100px;height:50px" />
                            <%}%>
                        </td>
                    </tr>

                </table>
                <script type="text/javascript">
                    function SaveObj() {
                        var postData = GetFormJsonData("shop");
                        var T_Area_id=$("#Area_id").val();
                        var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=Order_shouhuo_Edit&id=<%=order.id %>&T_Area_id="+T_Area_id;
                        RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
                    }
                    GetAreaList(0,<%=order.T_Area_id %>);

                </script>
            </td>
        </tr>

    </table>

          <%}else{%>
            <%=PageReturnMsg%>
          <%}%>
        </div>
    </div>
    
    <div class="bottom" id="body_bottom">
        <div style="width:100%;text-align:center;background-color:">

            

            <input type="button" value="挂起此单" style="width:70px;height:30px" onclick="guadan()" />
            <select id="guaid" name="guaid" onchange="window.location='?id='+$('#guaid').val()">
                <option value="0"><%=Tag("请选择")%></option>
                <%foreach(Shop.Model.Lebi_Order o in temporders){%>

                <option value="<%=o.id%>"><%=o.Order_id==0?"新单":"退货"%><%=o.Code%> 收货人：<%=o.T_Name%> 金额：<%=o.Money_Pay%></option>
                <%}%>
            </select>

            <input type="button" value="删除此单" style="width:60px;height:20px" onclick="shanchu()" />
        </div>

    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#PickUp_Date').datepicker();
        });
        function saveorder(){
            if(<%=order.id%>==0)
                return;
            var postData = GetFormJsonData("shoporder");
            var T_Area_id=$('#Area_id').val();
            var url = "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=checkout_order_save&id=<%=order.id%>&T_Area_id="+T_Area_id;
            $.ajax({
                type: 'POST',
                url: url,
                data:postData,
                dataType: 'json',
                success: function (res) {
                    if(res.msg=='OK')
                        $('#paymoney').html(res.pay);
                    else
                        MsgBox(1, res.msg, "");
                }
            });
        }
        function SelectAreaList(topid,objid) {
            $.ajax({
                type: 'POST',
                url: "/ajax/ajax.aspx?__Action=GetAreaList",
                dataType: 'html',
                data: { "topid": topid, "area_id": $("#" + objid).val() },
                success: function (data) {
                    $("#Area_id_div").html(data);
                    setTimeout(function(){
                        saveorder();
                    },2000)

                }
            });
        }
        function guadan()
        {
            window.location="checkout.aspx";
        }
        function shanchu()
        {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;

        var url = "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=checkout_order_del&id=<%=order.id%>";
            RequestAjax(url,'',function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function changetransport()
        {
            var code=$('#Transport_id option:selected').attr('code');
            if(code=='332')
                $('#trPickUp_id').show();
            else
                $('#trPickUp_id').hide();
        }
        changetransport();


    </script>
    <script type="text/javascript">
        //---------------------------------------------------------------------
        //添加商品
        function searchprodutwindow(){

            var title_ = "选择商品";
            var url_ = "<%=site.AdminPath %>/order/selectproductadd_window.aspx?isparent=0";
            var width_ = 950;
            var height_ = 900;
            var modal_ = true;
            var div_='pwindow';
            EditWindow(title_, url_, width_, height_, modal_,div_);
        }
        function search_product(Product_id,number) {

            $('#pwindow').dialog('close');
            $.ajax({
                type: 'POST',
                url: "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=checkout_order_addproduct&orderid=<%=order.id %>",
                data:{'pids':Product_id},
                dataType: 'json',
                success: function (res) {
                    if (res.msg=="OK") {
                        MsgBox(1, "<%=Tag("操作成功")%>", "?");
                    } else if(res.msg=='haveson') {
                        $('#pnumber').val(number);
                        selectproduct();
                    }else{
                        alert(res.msg);
                    }
                }
            });

        }
        //向订单添加选中的商品
        function selectproductmuti()
        {
            //var postData = GetFormJsonData("orderp");
            var orderid=$('#currentOrder_id').val();
            var pids=selectlist_getids();
            postData={'pids':pids};
            var url = "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=checkout_order_addproduct&orderid=<%=order.id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});

        }
        function selectproduct(id){
            var pnumber=$("#pnumber").val();
            var title_ = "<%=Tag("编辑订单商品规格")%>";
            var url_ = "selectproduct_window.aspx?orderid=<%=order.id %>&id=" + id+"&pnumber="+pnumber;
            var width_ = 500;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_, 'selectproduct');
        }
        function Pro_Del(id) {
            if (!confirm("<%=Tag("确认要删除吗？")%>"))
                return false;
            var postData = GetFormJsonData("del");
            var url = "<%=site.AdminPath %>/ajax/ajax_order.aspx?__Action=OrderPro_Del&id=" + id;
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        //-------------------------------------------------------------------

        function searchuserwindow(){

            var title_ = "选择会员";
            var url_ = "<%=site.AdminPath %>/order/selectuser_window.aspx";
            var width_ = 700;
            var height_ = 500;
            var modal_ = true;
            var div_='pwindow';
            EditWindow(title_, url_, width_, height_, modal_,div_);
        }



        function money_add(User_Name,id) {

            var title_ = "<%=Tag("充值")%>";
            var url_ = "usermoney_edit_window.aspx?User_Name=" + User_Name+"&t=191";
            var width_ = 600;
            var height_ = "auto";
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function reloadproducts(){
            var url = "<%=site.AdminPath %>/order/checkout_product_list_window.aspx?id=<%=order.id%>";
            GetHtml(url,'orderproductlist');
        }
        reloadproducts();
        //-------------------------------------------------------------------
        //付款
        function pay(t){

            var postData = GetFormJsonData("shoporder");
            var T_Area_id=$('#Area_id').val();
            var url = "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=checkout_order_pay&id=<%=order.id%>&T_Area_id="+T_Area_id+"&t="+t;
            $.ajax({
                type: 'POST',
                url: url,
                data:postData,
                dataType: 'json',
                success: function (res) {
                    if(res.msg=="OK")
                    {
                        MsgBox(1, "<%=Tag("操作成功")%>", "");
                        window.location="checkout.aspx";
                    }else{
                        MsgBox(2, res.msg, "");
                    }
                }
            });

        }
        //---------------------------------------------------------------------
        function inputmax(id,max)
        {
            <%if(IsTuiHuo){%>
            var val=$('#'+id).val();
                if(val>max)
                    $('#'+id).val(max);
            <%}%>
        }


    </script>

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