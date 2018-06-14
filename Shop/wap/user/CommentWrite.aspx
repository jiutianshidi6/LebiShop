<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserCommentWrite" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",8,"CN","P_UserCommentWrite"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_UserCommentWrite","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_UserCommentWrite","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_UserCommentWrite","description")%>" />
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
	<h2><%=ThemePageMeta("P_UserCommentWrite","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>

    <div class="body">
        <div class="bodymain">
            
    

<script type="text/javascript" src="http://192.168.1.188/Theme/system/wap/js/ajaxfileupload.js"></script>
<div class="nbbox clearfix">
    <div class="user">
        <ul class="tablist">
            <li><a href="<%=URL("P_UserComment","0","")%>"><span>已评价商品</span></a></li>
            <li class="selected"><a href="<%=URL("P_UserComment","1","")%>"><span>待评价商品<em>(<%=Count_Comment(0) %>)</em></span></a></li>
        </ul>
        <div class="dl-table clearfix">
        <dl>
            <dt>商品：</dt>
            <dd><% if (order_product.ImageSmall == ""){ %>&nbsp;<%}else{ %><a href="<%=URL("P_Product",order_product.Product_id) %>" target="_blank"><img style="height: 30px; width: 30px; vertical-align: middle" src="<%=Image(order_product.ImageSmall) %>" /></a><%} %>
                <a href="<%=URL("P_Product",order_product.Product_id) %>" target="_blank"><%=Lang(order_product.Product_Name)%></a></dd>
        </dl>
        <dl>
            <dt>评分：</dt>
            <dd><ul class="comment_star">
                <li>
                    <input type="radio" name="star" value="5" shop="true" checked /><em class="comments_bg stars_5"></em></li>
                <li>
                    <input type="radio" name="star" value="4" shop="true" /><em class="comments_bg stars_4"></em></li>
                <li>
                    <input type="radio" name="star" value="3" shop="true" /><em class="comments_bg stars_3"></em></li>
                <li>
                    <input type="radio" name="star" value="2" shop="true" /><em class="comments_bg stars_2"></em></li>
                <li>
                    <input type="radio" name="star" value="1" shop="true" /><em class="comments_bg stars_1"></em></li>
            </ul></dd>
        </dl>
        <dl>
            <dt>内容：</dt>
            <dd><textarea id="Content" name="Content" cols="80" rows="3" class="textarea" style="height: 150px; width: 80%;" shop="true"></textarea></dd>
        </dl>
        <dl>
            <dt>晒单照片：</dt>
            <dd><ul id="imagestable"></ul>
                <div class="clear"></div>
                <div><input type="file" onchange="uploadImage()" class="input" name="fileimage" id="fileimage"></div>
            </dd>
        </dl>
        <dl class="dl-btn">
            <dt></dt>
            <dd><a href="javascript:void(0)" onclick="submit();" class="btn btn-11"><s></s>发表评价</a><input type="hidden" id="Images" name="Images" value="" shop="true"/><input type="hidden" id="ImagesSmall" name="ImagesSmall" value="" shop="true"/></dd>
        </dl>
        </div>
    </div>
</div>
<script type="text/javascript">
    function submit() {
        var postData = GetFormJsonData("shop");
        var url = path+"/Ajax/Ajax_userin.aspx?__Action=Comment_Write&id=<%=id %>";
        RequestAjax(url, postData, function () { MsgBox(1, "操作成功", "<%=URL("P_UserComment","0","")%>") });
    }
    function uploadImage() {
        $.ajaxFileUpload
        (
	        {
	            url: path + '/ajax/imageupload_comment.aspx',
	            secureuri: false,
	            fileElementId: 'fileimage',
	            dataType: 'json',
	            success: function (data, status) {
	                    if (data.msg != 'OK') {
	                        MsgBox(2, data.msg, "");
	                    }
	                    else {
	                        if (data.ImageSmall.length > 0) {
	                           insertimage(data.ImageUrl,data.ImageSmall);
	                        }
	                    }
	                
	            }
	        }
        )
    }
    function insertimage(image,small)
    {
        var str='<li class="imagespreviewlist" image="'+image+'">';
        str+='<span class="image" ><img src="'+small+'"></span>';
        str+='<span class="image-manage" ><a onclick="deleteimage(\''+image+'\',\''+small+'\');" href="javascript:void(0)">删除</a></span>';
        str+='</li>'
        $('#imagestable').append(str);
        var images=$("#Images").val();
        var smalls=$("#ImagesSmall").val();
        $("#Images").val(images+'@'+image);
        $("#ImagesSmall").val(smalls+'@'+small);
        if($("#imagestable li").length>4)
        {
            $("#fileimage").hide();
        }
    }
    function deleteimage(image,small)
    {
        $("li[image='"+image+"']").remove();
        var images=$("#Images").val();
        var smalls=$("#ImagesSmall").val();
        images=images.replace('@'+image,'');
        smalls=smalls.replace('@'+small,'');
        $("#Images").val(images);
        $("#ImagesSmall").val(smalls);
        if($("#imagestable li").length<5)
        {
            $("#fileimage").show();
        }
    }
</script>



        </div>
      

<div class="mbox clearfix">
    <div class="mt">
        <h2>控制面板</h2>
    </div>
    <div class="mc usermenu clearfix">
        <ul>
            <li><a href="<%=URL("P_UserOrders","")%>"><span>我的订单</span></a></li>
            <%if(SYS.IsClosetuihuo=="0"){ %>
            <li><a href="<%=URL("P_UserReturn","")%>"><span>退货订单</span></a></li>
            <%} %>
            <li><a href="<%=URL("P_UserCard","")%>"><span>我的卡券</span></a></li>
            <li><a href="<%=URL("P_UserPoint","")%>"><span>积分记录</span></a></li>
            <li><a href="<%=URL("P_UserMoney","")%>"><span>资金记录</span></a></li>
            <li><a href="<%=URL("P_UserProfile","")%>"><span>资料管理</span></a></li>
            <li><a href="<%=URL("P_UserAccount","")%>"><span>绑定帐号</span></a></li>
            <li><a href="<%=URL("P_UserChangePassword","")%>"><span>修改密码</span></a></li>
            <li><a href="<%=URL("P_UserQuestion","")%>"><span>安全问题</span></a></li>
            <li><a href="<%=URL("P_UserAddress","")%>"><span>收货地址</span></a></li>
            <li><a href="<%=URL("P_UserBank","")%>"><span>收款账号</span></a></li>
            <li><a href="javascript:LoginOut();"><span>登录注销</span></a></li>
        </ul>
    </div>
</div>
<div class="mbox clearfix">
    <div class="mt">
        <h2>商品关注</h2>
    </div>
    <div class="mc usermenu clearfix">
        <ul>
            <li><a href="<%=URL("P_UserLike","")%>"><span>我的收藏</span></a></li>
            <li><a href="<%=URL("P_UserOftenBuy","")%>"><span>常购清单</span></a></li>
            <li><a href="<%=URL("P_UserComment","")%>"><span>商品评价<em>(<%=Count_Comment(0) %>)</em></span></a></li>
            <li><a href="<%=URL("P_UserAsk","")%>"><span>商品咨询<em>(<%=Count_ProductAsk(0) %>)</em></span></a></li>
        </ul>
    </div>
</div>
<div class="mbox clearfix">
    <div class="mt">
        <h2>站内信</h2>
    </div>
    <div class="mc usermenu clearfix">
        <ul>
            <li><a href="<%=URL("P_UserMessage","0")%>"><span>收件箱<em>(<%=Count_Message(0) %>)</em></span></a></li>
            <li><a href="<%=URL("P_UserMessage","1")%>"><span>发件箱</span></a></li>
            <li><a href="<%=URL("P_UserMessageWrite","")%>"><span>发信息</span></a></li>
        </ul>
    </div>
</div>
<%if (Shop.Bussiness.B_API.Check("plugin_agent")){ %>
<div class="mbox clearfix">
    <div class="mt">
        <h2>推广佣金</h2>
    </div>
    <div class="mc usermenu clearfix">
        <ul>
            <li><a href="<%=URL("P_UserAgent","")%>"><span>基本信息<em></em></span></a></li>
            <li><a href="<%=URL("P_UserAgentMoney","")%>"><span>佣金查询</span></a></li>
        </ul>
    </div>
</div>
<%} %>

    </div>
  
<div id="footer" class="clearfix">
    <div class="copyright">
        <%=Lang(SYS.Copyright) %>
    </div>
    <div class="lang">
        

<div class="language">
<%List<Shop.Model.Lebi_Language> sVQXs=Languages();RecordCount=sVQXs.Count;int sVQX_index=1;
foreach (Shop.Model.Lebi_Language sVQX in sVQXs){%>
<a <%if (sVQX_index==RecordCount){%>class="last"<%} %> href="javascript:SetLanguage(<%=sVQX.id%>,'<%=sVQX.Code%>','<%=sVQX.Path%>');"><img src="<%=Image(sVQX.ImageUrl) %>" title="<%=sVQX.Name%>" /><%=sVQX.Name%></a>
<%sVQX_index++;}%>
</div>

    </div>
    <div class="currency">
        

<div class="currency"><ul class="dropcurrency"><li class="currency_li"><a class="noclick"><span>币种：</span><s><%=CurrentCurrency.Code %></s></a><dl class="currency_li_content">
<%Table="Lebi_Currency";Where="";Order="Sort desc";PageSize=20;pageindex=Rint("page");RecordCount=B_Lebi_Currency.Counts(Where);int dChn_index=1;
List<Lebi_Currency> dChns = B_Lebi_Currency.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Currency dChn in dChns){%>
<dd <%if (dChn_index==RecordCount){%>class="last"<%} %>><a href="javascript:SetCurrency(<%=dChn.id%>,'<%=dChn.Code%>',<%=dChn.ExchangeRate%>,'<%=dChn.Msige%>');"><%=dChn.Code%></a></dd>
<%dChn_index++;}%>
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