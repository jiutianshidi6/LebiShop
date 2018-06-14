<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_SupplierRegister" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_SupplierRegister"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_SupplierRegister","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_SupplierRegister","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_SupplierRegister","description")%>" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="format-detection" content="telephone=no" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="apple-mobile-web-app-status-bar-style" content="black" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="twcClient" content="false" id="twcClient" />
<meta name="revisit-after" content="1 days" />
<meta name="CurrenctCurrency" content="<%=CurrentCurrency.Code %>" />
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<script type="text/javascript">var path = "<%=WebPath %>";var sitepath = "/";var langpath = "/";</script>
<script src="http://192.168.1.188/Theme/system/wap/js/jquery.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/Theme/system/wap/css/system.css" />
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/main.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/messagebox.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/my97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script src="http://192.168.1.188/Theme/system/wap/js/jquery-ui.min.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/Theme/system/wap/js/jqueryuicss/redmond/jquery-ui.css" />
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/theme/wap/css/css.css" />
<link rel="stylesheet" type="text/css" href="http://192.168.1.188/theme/wap/css/<%=CurrentLanguage.Code %>.css" />

    
</head>
<body class="default">
    
<div id="header" class="clearfix">
    <div class="logo">

<a href="/"><img src="<%=Image(Lang(SYS.Logoimg)) %>" alt="<%=Lang(SYS.Name)%>" title="<%=Lang(SYS.Name)%>" /></a>
</div>
    <ul class="toplink">
		<li><a href="#search" class="btnSearch"></a></li>
        
        <li><a href="<%=URL("P_Basket", "")%>" class="btnCart"><em id="cart_items"><%=Basket_Product_Count() %></em></a></li>
    </ul>
</div>
<div class="mhead clearfix">
	<a href="javascript:history.go(-1);" class="a-back"><span>返回</span></a>
	<h2><%=ThemePageMeta("P_SupplierRegister","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

    <div class="body">
        <div class="bodymain">
            


<script type="text/javascript" src="http://192.168.1.188/Theme/system/wap/js/ajaxfileupload.js"></script>
<div class="nbbox clearfix">
    <div class="user">
        <div class="reg clearfix">
            <div class="mt clearfix">
                <h2>
                    商家注册</h2>
            </div>
            <%if(supplier.Type_id_SupplierStatus==443){ %>
             <div class="mc">
                您的商家账号已停用
             </div>
            <%}else{ %>
            <div class="mc">
                <table cellpadding="0" cellspacing="0" id="usertable">
                     <tr>
                        <th>
                            当前状态：
                        </th>
                        <td>
                            <%=status %>
                        </td>
                    </tr>
                    <%if(CurrentUser.id==0 || CurrentUser.IsAnonymous == 1){ %>
                    <tr>
                        <th>
                            <font color="red">*</font>商城帐号：
                        </th>
                        <td>
                            <input type="text" name="UserName" shop="true" id="UserName" onchange="Check_username();"
                                style="width: 200px;" maxlength="20" class="input" min="4" maxlength="20" max="20" /><span id="FormUserName" class="FormALT">您已注册的商城账号</span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>帐号密码：
                        </th>
                        <td>
                            <input type="password" shop="true" name="Password" id="Password" style="width: 200px;"
                                maxlength="16" class="input" min="6" /><span id="FormPassword" class="FormALT">商城账号密码</span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>验证码：
                        </th>
                        <td>
                            <input name="loginverifycode" type="text" shop="true" id="loginverifycode" shop="true" size="6"
                                class="input" />
                            <img class="img_c" align="absmiddle" style="width: 80px; height: 25px;" title="点击重新获取验证码"
                                id="img2" src="<%=WebPath%>/code.aspx" language="javascript" onclick="this.src=this.src+'?'">
                            <span id="Span1"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            
                        </th>
                        <td>
                            <a href="javascript:void(0)" onclick="submitlogin();" class="btn btn-6"><s></s>登录</a>
                        </td>
                    </tr>
                     <tr>
                        <th>
                           
                        </th>
                        <td>
                            还不是商城会员？ <a href="<%=URL("P_Register", ""+HttpUtility.UrlEncode(Shop.Tools.RequestTool.GetRequestUrlNonDomain())+"," + GetUrlToken(Shop.Tools.RequestTool.GetRequestUrlNonDomain())+ "") %>">免费注册</a>
                        </td>
                    </tr>
                    <%}else{ %>
                    <tr>
                        <th>
                            <font color="red">*</font>商城帐号：
                        </th>
                        <td>
                            <%=CurrentUser.UserName %>
                        </td>
                    </tr>
                    <%} %>
                </table>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            <font color="red">*</font>申请类型：
                        </th>
                        <td>
                            <select id="Supplier_Group_id" name="Supplier_Group_id" shop="true" onchange="selectverified();">
                                <%=GroupOption(0) %>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>店铺名称：
                        </th>
                        <td>
                            <input type="text" name="Name" id="Name" style="width: 200px;" value="<%=Lang(supplier.Name) %>" maxlength="100" min="4" max="100" class="input" shop="true" />
                        </td>
                    </tr>
                    
                    <tr>
                        <th>
                            <font color="red">*</font>店铺简称：
                        </th>
                        <td>
                            <input type="text" name="SubName" id="SubName" style="width: 200px;" value="<%=supplier.SubName %>" min="notnull" maxlength="6"
                                class="input" shop="true" /><span id="FormSubName" class="FormALT">审核通过后将不能修改</span>
                        </td>
                    </tr>
                     <tr>
                        <th>
                            <font color="red">*</font>公司名称：
                        </th>
                        <td>
                            <input type="text" name="Company" id="Company" style="width: 200px;" value="<%=supplier.Company %>" min="4" max="100"
                                class="input" shop="true" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>联系人：
                        </th>
                        <td>
                            <input type="text" name="RealName" id="RealName" shop="true" style="width: 200px;" min="notnull" maxlength="100" value="<%=supplier.RealName %>" class="input" />
                        </td>
                    </tr>
                    
                    <tr>
                        <th>
                            <font color="red">*</font>手机号码：
                        </th>
                        <td>
                            <input type="text" shop="true" name="MobilePhone" id="MobilePhone" style="width: 200px;" onkeyup="value=value.replace(/[^\d]/g,'')" min="notnull" maxlength="11" value="<%=supplier.MobilePhone %>" class="input" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            电话号码：
                        </th>
                        <td>
                            <input type="text" name="Phone" id="Phone" style="width: 200px;" class="input" shop="true" value="<%=supplier.Phone %>" />
                            <span id="FormPhone" class="FormALT"></span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            QQ号码：
                        </th>
                        <td>
                            <input type="text" name="QQ" id="QQ" style="width: 200px;" class="input" shop="true" onkeyup="value=value.replace(/[^\d]/g,'')" value="<%=supplier.QQ %>"/>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>EMAIL：
                        </th>
                        <td>
                            <input type="text" name="Email" id="Email" style="width: 200px;" class="input" shop="true" min="email" maxlength="100" value="<%=supplier.Email %>"/>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>邮编：
                        </th>
                        <td>
                            <input type="text" name="Postalcode" id="Postalcode" style="width: 200px;" class="input" shop="true" min="notnull" maxlength="100" value="<%=supplier.Postalcode %>"/>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>地区：
                        </th>
                        <td id="Area_id_div">
                            
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <font color="red">*</font>地址：
                        </th>
                        <td>
                            <input type="text" name="Address" id="Address" style="width: 200px;" class="input" shop="true" min="notnull" maxlength="100" value="<%=supplier.Address %>"/>
                        </td>
                    </tr>
                    <%foreach (Shop.Model.Lebi_Supplier_Verified model in verifieds)
                    {
                        string img=GetVerifiedImage(model.id);
                    %>
                    <tr class="verified" vid="<%=model.id %>" style="display:none;">
                        <th>
                            <font color="red">*</font><%=Lang(model.Name)%>：
                        </th>
                        <td>
                            <div id="image_Image<%=model.id %>">
                               <%if(img!=""){ %>
                               <img height="60" src="<%=Image(img) %>">
                               <%} %>
                            </div>
                            <input type="hidden" shop="true" id="Image<%=model.id %>" name="Image<%=model.id %>" class="input" style="width: 200px;" value="<%=img %>" />
                            <input id="file_Image<%=model.id %>" name="file_Image<%=model.id %>" type="file" class="input" onchange="uploadImage('Image<%=model.id %>')" />
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <th>
                            <font color="red">*</font>验证码：
                        </th>
                        <td>
                            <input name="verifycode" type="text" shop="true" id="verifycode" min="notnull" shop="true" size="6"
                                class="input" />
                            <img class="img_c" align="absmiddle" style="width: 80px; height: 25px;" title="点击重新获取验证码"
                                id="img1" src="<%=WebPath%>/code.aspx" language="javascript" onclick="this.src=this.src+'?'">
                            <span id="Formverifycode"></span>
                        </td>
                    </tr>
                </table>
            </div>
            <table cellpadding="0" cellspacing="0" align="center">
                <tbody>
                    <tr>
                        <th>
                            &nbsp;
                        </th>
                        <td height="50">
                            <a href="javascript:void(0)" onclick="submit();" class="btn btn-6"><s></s>提交注册</a>
                        </td>
                    </tr>
                </tbody>
            </table>
            <%} %>
        </div>
    </div>
</div>
<div id="overlay" class="overlay"></div>
<script type="text/javascript">
    GetAreaList(<%=SYS.TopAreaid %>, <%=supplier.Area_id %>); //加载地区下拉框
    function HighlightDiv(objid) {
        $("#overlay").show();
        $("#" + objid).addClass("lightbox");
    }
    function HighlightDivHide() {
        $("#overlay").hide();
    }
    function submit() {
        
        if (!CheckForm("shop"))
            return false;
        var Area_id = $("#Area_id").val();
        if (Area_id == 0) {
            CheckNO('Area_id','','span');
            return false;
        }
        var postData = GetFormJsonData("shop");
        var url = "<%=site.AdminPath%>/ajax/ajax_user.aspx?__Action=User_Reg&Area_id="+Area_id+"&url=<%=backurl %>";
        RequestAjax(url, postData, function (res) { MsgBox(1, "注册成功", '<%=backurl %>') });
    }
    function selectverified()
    {
         var vid=$("#Supplier_Group_id").find("option:selected").attr('vids');
         vid=','+vid+',';
         $(".verified").each(function(i){
            if(vid.indexOf(','+$(this).attr('vid')+',')>-1)
                $(this).show();
            else
                $(this).hide();
         });
    }
    function uploadImage(id) {
        $.ajaxFileUpload
        (
	        {
	            url: path + '/ajax/imageuploadone.aspx?path=verified',
	            secureuri: false,
	            fileElementId: 'file_' + id,
	            dataType: 'json',
	            success: function (data, status) {
	                if (data.msg != 'OK') {
	                        MsgBox(2, data.msg, "");
	                    }
	                    else {
	                        var imageUrl = data.ImageUrl;
	                        if (imageUrl.length > 0) {
	                            $("#image_" + id + "").html('<img height="60" src=' + path + imageUrl + '>');
	                            $("#" + id + "").val(imageUrl);
	                        }
	                    }
	            },
	            error: function (data, status, e) {
	                MsgBox(2, data.error, "");
	            }
	        }
        )
    }
    selectverified();
    <%if(CurrentUser.id==0 || CurrentUser.IsAnonymous == 1){ %>
    function submitlogin() {
        var Password = $("#Password").val();
        var UserName = $("#UserName").val();
        var verifycode = $("#loginverifycode").val();
        if (UserName == "") {
            CheckNO("UserName", "请输入用户名");
            return false;
        }
        if (Password == "") {
            CheckNO("Password", "请输入密码");
            return false;
        }
        if (verifycode == "") {
            CheckNO("loginverifycode", "请输入验证码");
            return false;
        }
        var postData = { "Password": Password, 'UserName': UserName, 'verifycode': verifycode };
        var url = path + "/ajax/ajax_user.aspx?__Action=User_Login&url=<%=backurl %>";
        RequestAjax(url, postData, function (res) { MsgBox(1, "登录成功", '?') });
    }
    HighlightDiv('usertable');
    <%} %>
</script>



        </div>
        <div class="search">
	        <a name="search"></a>
	        

<script type="text/javascript">
$(function () {
    blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int xlUe_index=1;
List<Lebi_Searchkey> xlUes = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey xlUe in xlUes){%><%=Lang(xlUe.Name)%><%xlUe_index++;}%><%} %>');
    $("#keyword").click(function () {
        $("#keyword").val();
        $("#keywords").show();
    })
    $("#keywords").hover(function () {
        $("#keywords").show();
    }, function () {
        $("#keywords").hide();
    });
})
</script>
<div id="searchform">
<div class="searchform">
<input id="keyword" value="" type="text" name="keyword" onkeydown="if(event.keyCode==13){search();}" />
<input type="button" value="搜索" class="button" onclick="search();" />
<script type="text/javascript">
    function search() {
        var url = "<%=URL("P_Search","[key]") %>";
        location.href = url.replace("[key]",escape($("#keyword").val()));
    }
</script>
</div>
<div id="keywords">
    <div class="mbox clearfix">
    <div class="searchkeyword">
    <div class="mt">
        <h2>热搜排行</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int ahev_index=1;
List<Lebi_Searchkey> ahevs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey ahev in ahevs){%>
        <li><%if (ahev.Type==1){ %><a href="<%=URL("P_Search",""+Lang(ahev.Name)+"") %>"><%}else{ %><a href="<%=ahev.URL%>"><%} %><%=Lang(ahev.Name)%></a></li>
        <%ahev_index++;}%>
    </ul>
    </div>
    </div>
    </div>
    <div class="mbox clearfix">
    <div class="searchbrand">
    <div class="mt">
        <h2>品牌推荐</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Brand";Where="IsRecommend=1";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int iEFC_index=1;
List<Lebi_Brand> iEFCs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand iEFC in iEFCs){%>
        <li><a href="<%=URL("P_Brand",iEFC.id)%>" title="<%=Lang(iEFC.Name) %>"><%=Lang(iEFC.Name) %></a></li>
        <%iEFC_index++;}%>
    </ul>
    </div>
    </div>
    </div>
</div>
</div>

        </div>
        <div class="footmenu">
	        

<div class="nbbox clearfix">
<div class="quickmenu">
<div class="mc clearfix">
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_Index", "")%>">首页</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_Basket", "")%>">购物车 (<em><%=Basket_Product_Count() %></em>)</a></h3><s></s></span></div>
   <%if(CurrentUser.id>0){ %>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserCenter", "")%>">会员中心</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserOrders", "")%>">我的订单</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserCard", "")%>">我的卡券</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserLike", "")%>">我的收藏</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserOftenBuy", "")%>">常购清单</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserComment", "")%>">商品评价 (<em><%=Count_Comment(0) %></em>)</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserAsk", "")%>">商品咨询 (<em><%=Count_ProductAsk(0) %></em>)</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserMessage","0")%>">站内信 (<em><%=Count_Message(0) %></em>)</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserProfile", "")%>">资料管理</a></h3><s></s></span></div>
   <%if (Shop.Bussiness.B_API.Check("plugin_agent")){ %>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserAgent","")%>">推广佣金</a></h3><s></s></span></div>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_UserAgentMoney","")%>">佣金查询</a></h3><s></s></span></div>
   <%} %>
   <%}else{ %>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("P_Login", "")%>">会员登录</a></h3><s></s></span></div>
   <%} %>
	<%Table="Lebi_Page";Where="Node_id="+Node("FootMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int geDk_index=1;
List<Lebi_Page> geDks = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page geDk in geDks){%>
   <div class="item"><span class="itemname"><h3><a href="<%=URL("","",geDk.url)%>"><%=geDk.Name%></a></h3><s></s></span></div>
	<%geDk_index++;}%>
    <div class="item last"><span class="itemname"><h3><a href="">完整网站</a></h3><s></s></span></div>
</div>
</div>
</div>

        </div>
    </div>
    
<div id="footer" class="clearfix">
    <div class="copyright">
        <%=Lang(SYS.Copyright) %>
    </div>
    <div class="lang">
        

<div class="language">
<%List<Shop.Model.Lebi_Language> ccfjs=Languages();RecordCount=ccfjs.Count;int ccfj_index=1;
foreach (Shop.Model.Lebi_Language ccfj in ccfjs){%>
<a <%if (ccfj_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=ccfj.id%>,'<%=ccfj.Code%>','<%=ccfj.Path%>');"><img src="<%=Image(ccfj.ImageUrl) %>" title="<%=ccfj.Name%>" /><%=ccfj.Name%></a>
<%ccfj_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int uwjr_index=1;
List<Lebi_Currency> uwjrs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency uwjr in uwjrs){%>
<dd <%if (uwjr_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=uwjr.id%>,'<%=uwjr.Code%>',<%=uwjr.ExchangeRate%>,'<%=uwjr.Msige%>');"><%=uwjr.Code%></a></dd>
<%uwjr_index++;}%>
</dl></li></ul></div>

    </div>
    
<div id="footnav">
<ul>
<li><a href="<%=URL("P_Index", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/home.png" alt="首页" /><span>首页</span></a></li>
<li><a href="<%=URL("P_ProductCommentIndex", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/message.png" alt="晒单" /><span>晒单</span></a></li>
<li><a href="<%=URL("P_Basket", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/cart.png" alt="购物车" /><span>购物车</span></a></li>
<li><a href="<%=URL("P_UserCenter", "")%>"><img src="http://192.168.1.188/Theme/system/wap/images/user.png" alt="会员中心" /><span>会员中心</span></a></li>
</ul>
</div>

</div>


    
</body>
</html>