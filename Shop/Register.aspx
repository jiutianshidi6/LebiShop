<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_Register" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("wangdayu523@163.com_37",1,"CN","P_Register"); %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">


<title><%=ThemePageMeta("P_Register","title")%></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="keywords" content="<%=ThemePageMeta("P_Register","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_Register","description")%>" />
<meta name="CurrenctCurrency" content="<%=CurrentCurrency.Code %>" />
<meta name="CurrenctCurrencyMsige" content="<%=CurrentCurrency.Msige %>" />
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<link rel="shortcut icon" href="/theme/newdefault/images/favicon.ico"/>
<link rel="bookmark" href="/theme/newdefault/images/favicon.ico"/> 
<script type="text/javascript">
    var path = "<%=WebPath %>";
    var sitepath = "/";
    var langpath = "/";
</script>
<script src="/Theme/system/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="/Theme/system/js/jquery-ui.min.js" type="text/javascript"></script>
<script src="/Theme/system/js/main.js" type="text/javascript"></script>
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="/Theme/system/js/my97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script src="/Theme/system/js/msclass.js" type="text/javascript"></script>
<script src="/Theme/system/js/prettyphoto/jquery.prettyphoto.js" type="text/javascript"></script>
<script src="/theme/newdefault/js/<%=CurrentLanguage.Code %>.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/Theme/system/css/system.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/js/jqueryuicss/redmond/jquery-ui.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/js/prettyphoto/css/prettyPhoto.css" />
<link rel="stylesheet" type="text/css" href="/theme/newdefault/css/css.css" />
<link rel="stylesheet" type="text/css" href="/theme/newdefault/css/<%=CurrentLanguage.Code %>.css" />
<link rel="stylesheet" type="text/css" href="/theme/newdefault/css/weiyu.css" />
<script src="/theme/newdefault/js/all-jquery.js" type="text/javascript"></script>
<script type="text/javascript">
    var bForcepc = fGetQuery("dv") == "pc";
    function fBrowserRedirect() {
        var sUserAgent = navigator.userAgent.toLowerCase();
        var bIsIphoneOs = sUserAgent.match(/iphone os/i) == "iphone os";
        var bIsMidp = sUserAgent.match(/midp/i) == "midp";
        var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4";
        var bIsUc = sUserAgent.match(/ucweb/i) == "ucweb";
        var bIsAndroid = sUserAgent.match(/android/i) == "android";
        var bIsCE = sUserAgent.match(/windows ce/i) == "windows ce";
        var bIsWM = sUserAgent.match(/windows mobile/i) == "windows mobile";
        if (bIsIphoneOs || bIsAndroid) {
            var sUrl = location.href;
            if (!bForcepc) {
                window.location.href = "/m/";
            }
        }
        if (bIsMidp || bIsUc7 || bIsUc || bIsCE || bIsWM) {
            var sUrl = location.href;
            if (!bForcepc) {
                window.location.href = "/m/";
            }
        }
    }
    function fGetQuery(name) {//获取参数值
        var sUrl = window.location.search.substr(1);
        var r = sUrl.match(new RegExp("(^|&)" + name + "=([^&]*)(&|$)"));
        return (r == null ? null : unescape(r[2]));
    }
    fBrowserRedirect();
</script>


</head>
<body>

<div class="head">
    <div class="top">
        <div class="center clearfix">
            <ul class="sns">
            	
                <li><a href="https://www.youtube.com/channel/UCuP7zVB_1u94BzaLCcMXYZA?view_as=subscriber" class="youtube" target="_blank"></a></li>
                
                <li><a href="https://plus.google.com/u/0/107335425411617972609/posts/p/pub" class="google" target="_blank"></a></li>
                <li><a href="https://twitter.com/crw_bathrooms" class="twitter" target="_blank"></a></li>
                <li><a href="https://www.facebook.com/profile.php?id=100009518509235&pnref=story" class="facebook" target="_blank"></a></li>
                <span class="userstatus" id="userstatus"><a href="<%=URL("P_Register", "") %>"><%=Tag("免费注册")%></a> ┊ <a href="<%=URL("P_Login", "") %>"><%=Tag("登录")%></a></span>
            </ul>
            <ul>
                <li>

<div class="shoppingcart" id="basketstatus" >
</div>
<script type="text/javascript">    LoadPage(path + '/inc/basketstatus.aspx', 'basketstatus');</script>
</li>
                <li>

<div class="language">
    <ul class="droplanguage">
        <li class="language_li"><a class="noclick"><span>网站语言：</span><s><%if (CurrentLanguage.ImageUrl!=""){%><img src="<%=Image(CurrentLanguage.ImageUrl) %>" /><%}%><%=CurrentLanguage.Name %></s></a><dl
            class="language_li_content">
            <%List<Shop.Model.Lebi_Language> ImvRs=Languages();RecordCount=ImvRs.Count;int ImvR_index=1;
foreach (Shop.Model.Lebi_Language ImvR in ImvRs){%>
            <dd <%if (ImvR_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetLanguage(<%=ImvR.id%>,'<%=ImvR.Code%>','<%=ImvR.Path%>');"><%if (ImvR.ImageUrl!=""){%><img src="<%=Image(ImvR.ImageUrl) %>" /><%}%><%=ImvR.Name%></a></dd>
            <%ImvR_index++;}%>
        </dl>
        </li>
    </ul>
</div>
</li>
                <li>

<%if(SYS.IsMutiCurrencyShow=="0"){ %>
<div class="currency">
    <ul class="dropcurrency">
        <li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl
            class="currency_li_content">
            <%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int atwW_index=1;
List<Lebi_Currency> atwWs = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency atwW in atwWs){%>
            <dd <%if (atwW_index==RecordCount){%>class="last" <%} %>>
                <a href="javascript:SetCurrency(<%=atwW.id%>,'<%=atwW.Code%>',<%=atwW.ExchangeRate%>,'<%=atwW.Msige%>','<%=atwW.DecimalLength%>');"><%=atwW.Code%></a></dd>
            <%atwW_index++;}%>
        </dl>
        </li>
    </ul>
</div>
<%} %>

</li>
            </ul>
        </div>
    </div>
    <script type="text/javascript">        LoadPage(path + '/inc/userstatus.aspx', 'userstatus');</script>
    <div class="head-main">
        <h1 class="logo">
           

<a href="/"><img src="<%=Image(Lang(SYS.Logoimg)) %>" alt="<%=Lang(SYS.Name)%>" title="<%=Lang(SYS.Name)%>" /></a>
</h1>
        <div class="search">
            

<script type="text/javascript">
    $(function () {
        blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int yXXh_index=1;
List<Lebi_Searchkey> yXXhs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey yXXh in yXXhs){%><%=Lang(yXXh.Name)%><%yXXh_index++;}%><%} %>');
        $(".searchform .button").click(function(){
            var typename = $('#searchtype').attr('typename');
            var url = "";
            if (typename=="product")
            {
                var url = "<%=URL("P_Search","[key]") %>";
            }
            if (typename=="shop")
            {
                url = "<%=URL("P_ShopSearch","[key]") %>";
            }
            location.href = url.replace("[key]",escape($("#keyword").val()));
            return false;
        });
        $(".searchform dd a").click(function(){
            $(".searchform dl span").text($(this).text());
            $(".searchform dl span").attr("typename",$(this).attr("typename"));
            $(".searchform dd").hide();
        });
        $(".searchform-type").hover(function () {
            $(".searchform dd").show();
        }, function () {
            $(".searchform dd").hide();
        });
    });		
</script>
<div class="searchform">
<div class="searchform-type">
<dl>
    <dt><span id="searchtype" typename="product">商品</span><em class="ico-jtb"></em></dt>
    <dd>
        <a typename="product" href="javascript:void(0)">商品</a>
        <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_gongyingshang")){ %>
        <a typename="shop" href="javascript:void(0)">店铺</a>
        <%}%>
    </dd>
</dl>
</div>
<input id="keyword" value="" type="text" name="keyword" onfocus="if (this.value != '') {this.value = '';}" />
<input type="button" value="搜索" class="button" />
</div>

            

<div class="searchkeyword">
<%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=5;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int QWLH_index=1;
List<Lebi_Searchkey> QWLHs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey QWLH in QWLHs){%>
<%if (QWLH.Type==1){ %><a href="<%=URL("P_Search",""+Lang(QWLH.Name)+"") %>"><%}else{ %><a href="<%=QWLH.URL%>" target="_blank"><%} %><span><%=Lang(QWLH.Name)%></span></a>
<%QWLH_index++;}%>
</div>

        </div>
        <div class="toplink">
            <a href="<%=URL("P_UserCenter","") %>">
                <img src="/theme/newdefault/images/topIco1.png">我的账号</a> <a href="<%=URL("P_Basket","") %>">
                    <img src="/theme/newdefault/images/topIco2.png">购物车</a>
        </div>
    </div>
</div>
  <div class="mainNav">
    <div class="mainNav-con">
      <div class="allnav">
        <h2 class="title">
          <a href="<%=URL("P_AllProductCategories", "")%>">全部商品分类</a><i class="title-icon"></i>
        </h2>
        <div class="allnav-show">
          <ul id="nav">
            <%
                        int ic0=0;
            foreach(Lebi_Pro_Type c0 in EX_Product.ShowTypes(0,CurrentSite.id))
            {
            ic0++;
            if(ic0>10)
            continue;
            %>
            <li id="mainCate-1" class="mainCate">
              <h3>
                <i class="nav-icon">
                  <%if(c0.ImageSmall!=""){ %>
                    <img src="<%=c0.ImageSmall %>" alt="<%=Lang(c0.Name) %>" style="width:18px;height:18px;" /><%} %></i><a href="<%=URL("P_ProductCategory",""+c0.id+"") %>"><%=Lang(c0.Name) %></a>
              </h3>
              <div class="subCate">
                <h4>
                  <a href="<%=URL("P_ProductCategory",""+c0.id+"") %>"><%=Lang(c0.Name) %> >></a>
                </h4>
                <ul>
                  <%
                                    int ic1=0;
                  foreach(Lebi_Pro_Type c1 in EX_Product.ShowTypes(c0.id,CurrentSite.id))
                  {
                  %>
                  <li>
                    <a href="<%=URL("P_ProductCategory",""+c1.id+"") %>"><%=Lang(c1.Name) %></a>
                  </li>
                  <%} %>
                </ul>
                <div class="nav-pic">
                  <img src="/theme/newdefault/images/w-ad.jpg" width="365" height="154" />
                </div>
              </div>
            </li>
            <%} %>
          </ul>
        </div>
      </div>
      
      <div class="other-menu">
        

<%Table="Lebi_Page";Where="Node_id="+Node("HeadMenu").id+" and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=10;pageindex=1;RecordCount=B_Lebi_Page.Counts(Where);int DROW_index=1;
List<Lebi_Page> DROWs = B_Lebi_Page.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Page DROW in DROWs){%>
<a class="menu" href="<%=URL("","",DROW.url)%>"><span><%=DROW.Name%></span></a>
<%DROW_index++;}%>

      </div>
    </div>
  </div>
<script type="text/javascript">
$(document).ready(function(){
$('.allnav').mousemove(function(){
$(this).find('.allnav-show').slideDown("1000");//you can give it a speed
});
$('.allnav').mouseleave(function(){
$(this).find('.allnav-show').slideUp("fast");
});
});
jQuery("#nav").slide({
type:"menu", //效果类型
titCell:".mainCate", // 鼠标触发对象
targetCell:".subCate", // 效果对象，必须被titCell包含
delayTime:0, // 效果时间
triggerTime:0, //鼠标延迟触发时间
defaultPlay:false,//默认执行
returnDefault:true//返回默认
});
$(document).ready(function(){
$('.allnav').mousemove(function(){
$(this).find('.allnav-show').slideDown("1000");//you can give it a speed
});
$('.allnav').mouseleave(function(){
$(this).find('.allnav-show').slideUp("fast");
});
});
</script>

<div class="body clearfix">
  <div class="location"><div class="path"><%=path%></div></div>
  


<script type="text/javascript">
    function OpenMore() {
        var IsOpen = document.getElementById("IsOpen");
        if (IsOpen.checked) { $("#OpenBox").show() } else { $("#OpenBox").hide() }
    }
</script>
<div class="nbbox clearfix">
    <div class="user">
        <div class="reg clearfix">
            <div class="mt clearfix">
                <h2>会员注册</h2>
            </div>
            <div class="mc clearfix">
            <div class="dl-table clearfix">
            <dl>
                <dt><font color="red">*</font>登录帐号：</dt>
                <dd><input type="text" name="UserName" shop="true" id="UserName" onchange="Check_username();" style="width: 200px;" maxlength="20" class="input" min="4" maxlength="20" max="20" />
                <span id="FormUserName" class="FormALT">4-20个字符，可以是字母、数字或中文</span>
                </dd>
            </dl>
            <dl>
                <dt><font color="red">*</font>帐号密码：</dt>
                <dd><input type="password" shop="true" name="Password" id="Password" style="width: 200px;" maxlength="16" class="input" min="6" />
                <span id="FormPassword" class="FormALT">密码区分大小写</span>
                </dd>
            </dl>
            <dl>
                <dt><font color="red">*</font>确认密码：</dt>
                <dd><input type="password" name="Password1" shop="true" id="Password1" style="width: 200px;" maxlength="16" class="input" />
                <span id="FormPassword1" class="FormALT">请再次填写密码</span>
                </dd>
            </dl>
            <dl>
                <dt><%if(Checkmobilephone){ %><font color="red">*</font><%} %>手机号码：</dt>
                <dd><input type="text" shop="true" name="MobilePhone" id="MobilePhone" <%if(Checkmobilephone){ %>min="notnull"<%} %> style="width: 200px;" class="input" />
                    <%if(Checkmobilephone){ %>
                    <%if (CurrentSite.IsMobile==0){ %>&nbsp;<%}else{%><br /><%}%>验证码：
                    <input type="text" shop="true" min="notnull" maxlength="6" name="MobilePhone_checkcode" id="MobilePhone_checkcode" style="width: 60px;" class="input" />
                    <input id="btn_phone" type="button" value="获取验证码" style="width: 80px; height:25px" onclick="getcheckcode('phone');" />
                    <span id="msg_phone"></span>
                    <%} %>
                </dd>
            </dl>
            <dl>
                <dt><%if(Checkemail){ %><font color="red">*</font> <%} %>Email地址：</dt>
                <dd><input type="text" name="Email" id="Email" <%if(Checkemail){ %>min="email"<%} %> style="width: 200px;" value="" class="input" shop="true" />
                    <%if(Checkemail){ %>
                    <%if (CurrentSite.IsMobile==0){ %>&nbsp;<%}else{%><br /><%}%>验证码：
                    <input type="text" shop="true" min="notnull" maxlength="6" name="Email_checkcode" id="Email_checkcode" style="width: 60px;" class="input" />
                    <input id="btn_email" type="button" value="获取验证码" style="height:25px" onclick="getcheckcode('email');" />
                    <span id="msg_email"></span>
                    <%} %>
                </dd>
            </dl>
                   
<%
if (Shop.LebiAPI.Service.Instanse.Check("plugin_agent")){
if (parentuserid == 0){
%>
            <dl>
                <dt>邀请码：</dt>
                <dd><input type="text" name="parentuserid" id="parentuserid" style="width: 200px;" value="" class="input" shop="true" /></dd>
            </dl>
<%}else{%>
    <input type="hidden" name="parentuserid" id="parentuserid" value="<%=parentuserid%>" shop="true" />
<%}}%>
            <%if (SYS.Verifycode_UserRegister == "1"){ %>
            <%if(Checkmobilephone==false && Checkemail==false){ %>
            <dl>
                <dt><font color="red">*</font>验证码：</dt>
                <dd><input name="verifycode" type="text" shop="true" id="verifycode" shop="true" size="6"
 class="input" /><img class="verifycode" id="img1" src="<%=WebPath%>/code.aspx" /><img src="/Theme/system/images/reload.gif" class="refresh" title="点击刷新验证码" onclick="refresh('img1')" /></dd>
            </dl>
            <%} %>
            <%} %>
            <dl>
                <dt></dt>
                <dd><label><input type="checkbox" name="agree" id="agree" />我已阅读并同意<a href="<%=URL("P_Help","$,agreement")%>" target="_blank">《注册协议》</a></label>
                <label><input type="checkbox" name="IsOpen" id="IsOpen" onclick="OpenMore();" />填写详细资料</label></dd>
            </dl>
            <div id="OpenBox" style="display: none">
            <dl>
                <dt>真实姓名：</dt>
                <dd><input type="text" name="RealName" id="RealName" shop="true" style="width: 200px;" class="input" />
                    <span id="FormRealName" class="FormALT"></span></dd>
            </dl>
            <dl>
                <dt>性别：</dt>
                <dd><label><input type="radio" name="Sex" value="男" checked />男</label>
                    <label><input type="radio" name="Sex" value="女" />女</label></dd>
            </dl>
            <dl>
                <dt>出生日期：</dt>
                <dd><input type="text" name="Birthday" id="Birthday" style="width: 200px;" class="input" shop="true" /></dd>
            </dl>
            <dl>
                <dt>电话号码：</dt>
                <dd><input type="text" name="Phone" id="Phone" style="width: 200px;" class="input" shop="true" />
                    <span id="FormPhone" class="FormALT"></span></dd>
            </dl>
            <dl>
                <dt>传真号码：</dt>
                <dd><input type="text" name="Fax" id="Fax" style="width: 200px;" maxlength="18" class="input" shop="true" /></dd>
            </dl>
            <dl>
                <dt>QQ号码：</dt>
                <dd><input type="text" name="QQ" id="QQ" style="width: 200px;" class="input" shop="true" /></dd>
            </dl>
            </div>
            <dl class="dl-btn">
                <dt></dt>
                <dd><a href="javascript:void(0)" onclick="submit();" class="btn btn-6"><s></s>提交注册</a></dd>
            </dl>
            </div>
            </div>
        </div>
    </div>
</div>
<input type="hidden" name="Device_system" shop="true" id="Device_system" maxlength="50" />
<input type="hidden" name="Device_id" shop="true" id="Device_id" maxlength="50"/>
<script type="text/javascript">
    $(document).keyup(function (event) {
        if (event.keyCode == 13) {
            submit();
        }
    });
    function submit() {
        if (!CheckForm("shop"))
            return false;
        Check_username();
        var Password = $("#Password").val();
        var Password1 = $("#Password1").val();
        if (Password != Password1) {
            CheckNO("Password1", "两次输入的密码不一致");
            return false;
        }
        var flag = $("#agree").is(":checked");
        if (!flag) {
            MsgBox(2, "请阅读并同意注册协议", "");
            return false;
        }
        var postData = GetFormJsonData("shop");
        $.ajax({
            type: "POST",
            url: path + "/ajax/ajax_user.aspx?__Action=User_Reg&url=<%=HttpUtility.UrlEncode(backurl) %>&token=<%=token %>&t=" + Math.random(),
            data: postData,
            dataType: 'json',
            success: function (res) {
                if (res.msg == "OK") {
                    MsgBox(1, "注册成功", res.url);
                }
                else {
                    MsgBox(2, res.msg, "", "", 3000);
                    return false;
                }
            }
        });
    }
    function Check_username() {
        var UserName = $("#UserName").val();
        $.ajax({
            type: 'POST',
            url: path + "/ajax/ajax_user.aspx?__Action=CheckUserName",
            data: { "UserName": UserName },
            dataType: 'json.',
            success: function (data) {
                if (data == "OK") { CheckOK("UserName", "用户名可以注册"); } else { CheckNO("UserName", "用户名已被注册"); return false; }

            }
        });
    }

    var djs_phone = 60;
    var djs_email = 60;
    function getcheckcode(t) {
        var email = '';
        var postData = '';
        var url = '';
        if (t == 'phone') {
            phone = $("#MobilePhone").val();
            postData = { "phone": phone };
            url = path + "/ajax/ajax.aspx?__Action=GetPhoneCheckCode&m=<%=mcode%>";
        } else {
            email = $("#Email").val();
            postData = { "email": email };
            url = path + "/ajax/ajax.aspx?__Action=GetEmailCheckCode&m=<%=mcode%>";
            if (!IsEmail(email)) {
                $("#msg_" + t).html("请填写邮箱");
                return false;
            }
        }
        $.ajax({
            type: "POST",
            url: url + "&t=" + Math.random(),
            data: postData,
            dataType: 'json',
            beforeSend: function () {
                $("#btn_" + t).hide();
                $("#msg_" + t).html("正在发送...");
            },
            success: function (res) {
                if (res.msg == "OK") {
                    if (t == 'phone') {
                        djs_phone = 60;
                        daojishi_phone();
                    } else {
                        djs_email = 60;
                        daojishi_email();
                    }
                    return false;
                }
                else {
                    $("#btn_" + t).show();
                    $("#msg_" + t).html(res.msg);
                    return false;
                }
            }
        });
    }
    function daojishi_email() {
        djs_email = djs_email - 1;
        if (djs_email > 0) {
            $("#msg_email").html(djs_email + "秒后重新发送");
            setTimeout(function () {
                daojishi_email();
            }, 1000);
        }
        else {
            $("#msg_email").html("");
            $("#btn_email").show();
        }
        
    }
    function daojishi_phone() {
        djs_phone = djs_phone - 1;
        if (djs_phone > 0){
            $("#msg_phone").html(djs_phone + "秒后重新发送");
            setTimeout(function () {
                daojishi_phone();
            }, 1000);
        }
        else {
            $("#msg_phone").html("");
            $("#btn_phone").show();
        }
    }
</script>


</div>

<div class="footer">
    <%=Lang(SYS.FootHtml) %>
    <div class="copyright f11 footer_logos">
        <div class="footer_logos-list">
            <%Table="Lebi_FriendLink";Where="IsShow=1 and ','+Language_ids+',' like '%," + CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=7;pageindex=1;RecordCount=B_Lebi_FriendLink.Counts(Where);int XGgX_index=1;
List<Lebi_FriendLink> XGgXs = B_Lebi_FriendLink.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_FriendLink XGgX in XGgXs){%>
            
                <% if (XGgX.Logo != "" && XGgX.IsPic == 1){ %><a href="<%=XGgX.Url%>" target="_blank"><img src="<%=Image(XGgX.Logo) %>" alt="<%=XGgX.Name%>" /></a><%}else{%><a href="<%=XGgX.Url%>" target="_blank"><%=XGgX.Name%></a><%} %>     
           
            <%XGgX_index++;}%>
         </div>
    </div>
</div>
<div class="copyright">
    

<%if (servicepannel.Status == "1"){%>
<%if (servicepannel.Style == "1"){%>
<script type="text/javascript" src="/Theme/system/js/ServicePanel.js"></script>
<div id="divStayTopLeft" onmouseout="Showservicepannel(event);" style="z-index:9998;width: 170px; position:absolute; right:0">
<layer id="divStayTopLeft">
<div id="divOnline" style="display:none;">
<div class="servicepannel">
<div class="menutop"><img src="/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=servicepannel.Theme%>_1.gif" alt="" /></div>
<div class="menucenter"><div style="background:url(/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=servicepannel.Theme%>_2.gif) repeat-y">
<%Table="Lebi_ServicePanel_Group";Where="Supplier_id = 0 and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel_Group.Counts(Where);int group_index=1;
List<Lebi_ServicePanel_Group> groups = B_Lebi_ServicePanel_Group.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel_Group group in groups){%>
<ul class="group clearfix">
<h2><%=group.Name%></h2>
<ul class="group-user clearfix">
<%Table="Lebi_ServicePanel";Where="Supplier_id = 0 and ServicePanel_Group_id = "+group.id+" and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel.Counts(Where);int user_index=1;
List<Lebi_ServicePanel> users = B_Lebi_ServicePanel.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel user in users){%>
<%
    string url = GetServicePanelType(user.ServicePanel_Type_id).Url;
    url = url.Replace("{@uid}",user.Account);
    url = url.Replace("{@uname}",user.Name);
%>
<li><a target="blank" href="<%=url%>"><img src="<%if (GetServicePanelType(user.ServicePanel_Type_id).IsOnline == 1){
    Response.Write(GetServicePanelType(user.ServicePanel_Type_id).Code.Replace("{@uid}",user.Account));
}else{
    Response.Write(Image(GetServicePanelType(user.ServicePanel_Type_id).Face));
}%>" border="0" align="absmiddle" />&nbsp;<%=user.Name%></a></li>
<%user_index++;}%>
</ul>
</li></ul>
<%group_index++;}%>
</div></div>
<div class="menufoot" style="background:url(/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=servicepannel.Theme%>_3.gif) top no-repeat"><img src="/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/<%=servicepannel.Theme%>_3.gif" /></div>
</div>
</div></layer>
<div id="divMenu" onmouseover="servicepannelOver();"><img src="/Theme/system/images/<%=CurrentLanguage.Code %>/ServicePanel/menu_<%=servicepannel.Theme%>.gif" style="right:0;border:none;cursor:pointer;width:26px;height:136px;position: absolute;" /></div>
</div>
<%} else{%>
<div class="servicepannel-fix clearfix">
<ul class="group">
<%Table="Lebi_ServicePanel_Group";Where="Supplier_id = 0 and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel_Group.Counts(Where);int group_index=1;
List<Lebi_ServicePanel_Group> groups = B_Lebi_ServicePanel_Group.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel_Group group in groups){%>
<li>
<h2><%=group.Name%></h2>
<ul class="group-user">
<%Table="Lebi_ServicePanel";Where="Supplier_id = 0 and ServicePanel_Group_id = "+group.id+" and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel.Counts(Where);int user_index=1;
List<Lebi_ServicePanel> users = B_Lebi_ServicePanel.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel user in users){%>
<%
    string url = GetServicePanelType(user.ServicePanel_Type_id).Url;
    url = url.Replace("{@uid}",user.Account);
    url = url.Replace("{@uname}",user.Name);
%>
<li><a target="blank" href="<%=url%>"><img src="<%if (GetServicePanelType(user.ServicePanel_Type_id).IsOnline == 1){
    Response.Write(GetServicePanelType(user.ServicePanel_Type_id).Code.Replace("{@uid}",user.Account));
}else{
    Response.Write(Image(GetServicePanelType(user.ServicePanel_Type_id).Face));
}%>" border="0" align="absmiddle" />&nbsp;<%=user.Name%></a></li>
<%user_index++;}%>
</ul>
</li>
<%group_index++;}%>
</ul></div>
<%}}%>

    <%=Lang(SYS.Copyright) %>
    <%=GetCNZZ() %>
</div>




<link rel="stylesheet" type="text/css" href="/Theme/system/js/sidebar/base.css" />
<script type="text/javascript" src="/Theme/system/js/sidebar/sidebar.js"></script>
<div class="mui-mbar-tabs">
	<div class="quick_link_mian">
		<div class="quick_links_panel">
			<div id="quick_links" class="quick_links">
				<li>
					<a href="javascript:void(0);" class="ico_account"><i class="i_ico_account"></i></a>
					<div class="ibar_login_box status_login">
						<div class="avatar_box">
							<p class="avatar_imgbox">
                                <%if(CurrentUser.Face.Trim()!=""){ %>
                                <img src="<%=CurrentUser.Face %>" />
                                <%}else{ %>
                                <img src="/Theme/system/js/sidebar/no-img_mid_.jpg" />
                                <%} %>
                            </p>
							<ul class="user_info">
								<li><%=Tag("用户名") %>：<%=Shop.Bussiness.EX_User.LoginStatus()?CurrentUser.UserName:Tag("未登录") %></li>
								<li><%=Tag("级别") %>：<%=Lang(CurrentUserLevel.Name) %></li>
							</ul>
						</div>
						<div class="login_btnbox">
                            <%if(Shop.Bussiness.EX_User.LoginStatus()){ %>
							<a href="<%=URL("P_UserOrders","") %>" class="login_order"><%=Tag("我的订单") %></a>
							<a href="<%=URL("P_UserLike","")%>" class="login_favorite"><%=Tag("我的收藏") %></a>
                            <%}else{ %>
                            <a href="<%=URL("P_Login","") %>" class="login_order"><%=Tag("登录") %></a>
							<a href="<%=URL("P_Register","")%>" class="login_favorite"><%=Tag("注册") %></a>
                            <%} %>
						</div>
						<i class="icon_arrow_white"></i>
					</div>
				</li>
				<li id="shopCart">
					<a href="<%=URL("P_Basket", "") %>" class="ico_basket" ><i class="i_ico_basket"></i><div class="span"><%=Tag("购物车") %></div><span class="cart_num"><%=Basket_Product_Count() %></span></a>
				</li>
				<li>
					<a class="ico_history"><i class="i_ico_history"></i></a>
					<div class="mp_tooltip"><%=Tag("我的足迹") %><i class="icon_arrow_right_black"></i></div>
				</li>
				<li>
					<a href="<%=URL("P_UserLike", "") %>" class="ico_like"><i class="i_ico_like"></i></a>
					<div class="mp_tooltip"><%=Tag("我的收藏") %><i class="icon_arrow_right_black"></i></div>
				</li>
			</div>
			<div class="quick_toggle">
				<li>
					<a href="<%=URL("P_Help","") %>" class="ico_service"><i class="i_ico_service"></i></a>
					<div class="mp_service" style="display:none;">
                        <div class="servicepannel">
                        <%Table="Lebi_ServicePanel_Group";Where="Supplier_id = 0 and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel_Group.Counts(Where);int siderbargroup_index=1;
List<Lebi_ServicePanel_Group> siderbargroups = B_Lebi_ServicePanel_Group.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel_Group siderbargroup in siderbargroups){%>
                            <ul class="group clearfix"><li>
                            <h2><%=siderbargroup.Name%></h2>
                            <ul class="group-user clearfix">
                            <%Table="Lebi_ServicePanel";Where="Supplier_id = 0 and ServicePanel_Group_id = "+siderbargroup.id+" and ','+Language_ids+',' like '%,"+ CurrentLanguage.id + ",%'";Order="Sort desc,id desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_ServicePanel.Counts(Where);int buser_index=1;
List<Lebi_ServicePanel> busers = B_Lebi_ServicePanel.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ServicePanel buser in busers){%>
                            <%
                                string url = GetServicePanelType(buser.ServicePanel_Type_id).Url;
                                url = url.Replace("{@uid}",buser.Account);
                                url = url.Replace("{@uname}",buser.Name);
                            %>
                            <li><a target="blank" href="<%=url%>"><img src="<%if (GetServicePanelType(buser.ServicePanel_Type_id).IsOnline == 1){
                                Response.Write(GetServicePanelType(buser.ServicePanel_Type_id).Code.Replace("{@uid}",buser.Account));
                            }else{
                                Response.Write(Image(GetServicePanelType(buser.ServicePanel_Type_id).Face));
                            }%>" border="0" align="absmiddle" />&nbsp;<%=buser.Name%></a></li>
                            <%buser_index++;}%>
                            </ul>
                            </li></ul>
                            <%siderbargroup_index++;}%>
                        </div>
                        <i class="icon_arrow_white"></i>

                    </div>
				</li>
				<li id="mp_qrcode">
					<a href="#none" class="ico_qrcode"><i class="i_ico_qrcode"></i></a>
					<div class="mp_qrcode" style="display:none;"><img src="<%=SYS.platform_weixin_image_qrcode%>" width="150" height="150" /><i class="icon_arrow_white"></i></div>
				</li>
				<li><a href="#top" class="return_top"><i class="top"></i></a></li>
			</div>
		</div>
		<div id="quick_links_pop" class="quick_links_pop hide"></div>
	</div>
</div>

<script type="text/javascript" src="/Theme/system/js/sidebar/parabola.js"></script>
<script type="text/javascript">
    $(".quick_links_panel li").mouseenter(function () {
        $(this).children(".mp_tooltip").animate({ left: -92, queue: true });
        $(this).children(".mp_tooltip").css("visibility", "visible");
        $(this).children(".ibar_login_box").css("display", "block");
    });
    $(".quick_links_panel li").mouseleave(function () {
        $(this).children(".mp_tooltip").css("visibility", "hidden");
        $(this).children(".mp_tooltip").animate({ left: -121, queue: true });
        $(this).children(".ibar_login_box").css("display", "none");
    });
    $(".quick_toggle li:first").mouseover(function () {
        $(".mp_service").show();
    });
    $(".quick_toggle li:first").mouseleave(function () {
        $(".mp_service").hide();
    });
    $(".quick_toggle li#mp_qrcode").mouseover(function () {
        $(".mp_qrcode").show();
    });
    $(".quick_toggle li#mp_qrcode").mouseleave(function () {
        $(".mp_qrcode").hide();
    });
</script>

</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>