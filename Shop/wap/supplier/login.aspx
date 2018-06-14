<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Supplier.Login" validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta content="text/html; charset=UTF-8" http-equiv="content-type" />
    <meta name="author" content="LebiShop" />
    <script type="text/javascript" src="<%=site.AdminJsPath%>/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="<%=site.AdminJsPath%>/messagebox.js"></script>
    <script type="text/javascript" src="<%=site.AdminJsPath%>/jquery-ui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="<%=site.AdminJsPath%>/jqueryuicss/redmond/jquery-ui.css" media="screen" />
    <style type="text/css">
        BODY{width: 100%;background: #3278a8;margin: 0;padding: 0;}
        .both{clear: both;font-size: 0;height: 0;overflow: hidden;visibility: hidden;}
        .main{background: url("<%=site.AdminImagePath%>/login/main.jpg") no-repeat;height: 539px;width: 889px;margin: 100px auto 0 auto;padding: 0;position: relative;}
        .license{position: absolute;right: 480px;top: 190px;height: 38px;text-align: center;}
        .license A{color: #fff;font-size: 14px;text-decoration: none;height: 38px;cursor: pointer;}
        .license A{display: inline-block;background: url(<%=site.AdminImagePath%>/login/boxL.jpg) no-repeat left 50%;text-decoration: none;letter-spacing: 0;color: #2d52a5;}
        .license A SPAN{display: inline-block;background: url(<%=site.AdminImagePath%>/login/boxR.jpg) no-repeat right 50%;padding-bottom: 0px;padding: 0 15px 0 15px;height: 38px;line-height: 38px;letter-spacing: 0;font-weight: bold;}
        .login-form{position: absolute;left: 515px;top: 124px;width: 235px;}
        .login-form ul{list-style-type: none;margin: 0;padding: 0;width: 235px;}
        .login-form ul li{float: left;width: 229px;height: 38px;line-height: 38px;margin: 0 0 20px 0;padding: 0;text-align: left;background: url("<%=site.AdminImagePath%>/login/input-name.jpg") no-repeat;}
        .login-form ul li.last{margin: 0;}
        .login-form ul li label{display: block;font-size: 12px;height: 42px;margin: 0;position: relative;}
        .login-form ul li strong{color: #BCBCBC;cursor: text;left: 8px;font-weight:normal;font-size:18px;height:42px;line-height: 42px;position: absolute;}
        .login-form .input-name{color: #3278a8;font-size: 16px;font-weight: bold;border: 0px;height: 26px;line-height: 26px;margin: 6px 10px;padding: 0;text-align: left;width: 200px;}
        .login-form ul li IMG{height: 25px;margin: 6px 0;vertical-align: middle;}
        .login-form .login-checkbox{width: 229px;margin: 10px 0;padding: 0;color: #000;font-size: 12px;}
        .login-form .login-btn{width: 229px;margin: 0;padding: 0;}
        .login-form .login-btn .submit{border: 0px;width: 125px;height: 45px;line-height: 41px;padding: 0 0 4px 0;text-align: left;background: url("<%=site.AdminImagePath%>/login/submit.jpg") no-repeat;text-align: center;color: #fff;font-size: 14px;font-weight: bold;cursor: pointer;}
        .login-form .mes{width: 229px;margin: 10px 0 0 0;padding: 0;text-align: center;color: #ff0000;font-size: 12px;}
        .login-msg{margin: 10px 0;padding: 0;color: #000;font-size: 12px;}
        .login-msg a{color: #3278A8;font-size: 12px;text-decoration: none;height: 38px;cursor: pointer;}
        .login-msg a:hover{color: #2D52A5;text-decoration:underline;}
        .login-title{color: #FB6300;font-size: 12px;margin:0 0 10px 0;}
        .reg{padding-top:30px;width:100%;height: 38px;text-align: left;}
        .reg a{font-size: 12px;height: 38px;cursor: pointer;}
      
    </style>
    <title><%=Tag("管理登陆")%>-<%=site.title%></title>
</head>
<body>
    <form id="form-field" class="form" novalidate>
    <div class="main">
        <div class="license">
            
        </div>
        <div class="login-form">
            
            <div class="login-title">
                商家登录
            </div>
            <ul>
                <li>
                    <label for="adminUserName"><strong><%=Tag("请输入用户名")%></strong>
                    <input type="text" class="input-name" maxlength="25" name="adminUserName" id="adminUserName"
                        <%if (Shop.Tools.CookieTool.GetCookieString("SupplierUserName") != ""){ %>value="<%=Shop.Tools.CookieTool.GetCookieString("SupplierUserName") %>"
                        <%} %> /></label></li>
                <li id="password" <%if (!LoginError){ %>
                    class="last" <%} %>>
                    <label for="adminPwd"><strong><%=Tag("请输入密码")%></strong>
                    <input type="password" class="input-name" maxlength="25" name="adminPwd" id="adminPwd" /></label></li>
                <li id="code" class="last" <%if (!LoginError){ %>style="display:none"
                    <%}else{ %>style="display:" <%} %>>
                    <label for="txt_yz"><strong><%=Tag("验证码")%></strong> 
                    <input type="text" class="input-name" maxlength="5" name="txt_yz" id="txt_yz" value="" style="width:120px;vertical-align: middle;" /><img class="img_c" style="width: 80px; height: 25px;" title="<%=Tag("点击重新获取验证码")%>" id="img1" src="../code.aspx" onclick="this.src=this.src+'?'"></label>
                </li>
                <div class="both">
                </div>
            </ul>
            <div class="login-checkbox">
                <input type="checkbox" id="saveusername" name="saveusername" value="1" checked /><%=Tag("记住用户名")%>
                
            </div>
            <div class="login-btn">
                <input type="button" value="<%=Tag("登陆")%>" name="submit" onclick="Login();" class="submit" /><input type="hidden" name="url " id="url" value="<%=url%>" />
            </div>
            <div class="reg">
                <a href="<%=URL("P_SupplierRegister","") %>?logintype=<%=logintype %>"><%=Tag("没有账号？点此注册") %></a>
            </div>
            <div class="mes">
                <span id="mes"></span>
            </div>
        </div>
        <div class="both">
        </div>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(document).ready(function () {
        $("#form-field .input-name").each(function () {
            var thisVal = $(this).val();
            if (thisVal != "") {
                $(this).siblings("strong").hide();
            } else {
                $(this).siblings("strong").show();
            }
            $(this).keyup(function () {
                var val = $(this).val();
                $(this).siblings("strong").hide();
            }).blur(function () {
                var val = $(this).val();
                if (val != "") {
                    $(this).siblings("strong").hide();
                } else {
                    $(this).siblings("strong").show();
                }
            })
        });
    });
    $(document).keyup(function (event) {
        if (event.keyCode == 13) {
            Login();
        }
    });
    function Login() {
        var userName = $("#adminUserName").val();
        var userPwd = $("#adminPwd").val();
        var code = $("#txt_yz").val();
        var saveusername = $("#saveusername").val();
        if (userName == "" || userName=="<%=Tag("请输入用户名")%>") {
            $("#mes").html("<%=Tag("请输入用户名")%>");
            return;
        }
        if (userPwd == "" || userPwd == "<%=Tag("请输入密码")%>") {
            $("#mes").html("<%=Tag("请输入密码")%>");
            return;
        }
        <%if (LoginError){ %>
        if (code == "") {
            $("#mes").html("<%=Tag("请输入验证码")%>");
            return;
        }
        <%} %>
        $.ajax({
            type: "POST",
            url: "<%=site.AdminPath%>/ajax/ajax_user.aspx?__Action=User_Login&logintype=<%=logintype %>",
            data: { UserName: userName, UserPWD: userPwd, code: code, saveusername: saveusername },
            beforeSend: function () {
                $("#mes").html("<%=Tag("正在登录")%>……");
            },
            success: function (res) {
                if (res == "OK") {
                    $("#mes").html("<%=Tag("登录成功，请稍后")%>……");
                    location.href = "<%=site.AdminPath%>/";
                }
                else {
                    $("#mes").html(res);
                    $("#password").attr("class","");
                    $("#code").show();
                }
            }
        });
    }
    
</script>

  