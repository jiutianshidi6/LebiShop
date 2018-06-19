<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserCommentWrite" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_UserCommentWrite"); %>

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
<meta name="CurrenctCurrencyMsige" content="<%=CurrentCurrency.Msige %>" />
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrenctCurrencyLength" content="<%=CurrentCurrency.DecimalLength %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<script src="/Theme/system/wap/js/jquery-3.1.0.min.js" type="text/javascript"></script>
<script src="/Theme/system/wap/js/jquery-ias.min.js"></script>
<%if (CurrentLanguage.IsLazyLoad==1){ %><script src="/Theme/system/wap/js/jquery.lazyload.min.js" type="text/javascript"></script><%} %>
<script src="/Theme/system/wap/js/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
<%if (CurrentLanguage.Code=="CN"){%><script type="text/javascript" src="/Theme/system/wap/js/jquery-ui/datepicker-zh-CN.js"></script><%}%>
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="/Theme/system/wap/js/main.js" type="text/javascript"></script>
<script src="/Theme/system/wap/js/messagebox.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/css/system.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/js/jquery-ui/jquery-ui.min.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/js/jquery-ui/jquery-ui.theme.min.css" />
<link rel="stylesheet" type="text/css" href="/theme/wap/css/css.css" />
<link rel="stylesheet" type="text/css" href="/theme/wap/css/<%=CurrentLanguage.Code %>.css" />

</head>
<body class="default">
    
<div class="mhead clearfix">
	<a href="javascript:history.go(-1);" class="a-back"><span>返回</span></a>
	<h2 id="pagename"><%=ThemePageMeta("P_UserCommentWrite","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>
<script>
    var pagetitle = $("#pagename").html();
    if (pagetitle.indexOf(" - ") > -1) {
        $("#pagename").html(pagetitle.split(' - ')[0]);
    }
</script>

    <div class="body">
        <div class="bodymain">
          
    

<script type="text/javascript" src="/Theme/system/wap/js/ajaxfileupload.js"></script>
<div class="nbbox clearfix">
    <div class="user">
        <ul class="tablist">
            <li><a href="<%=URL("P_UserComment","0","")%>"><span>已评价商品</span></a></li>
            <li class="selected"><a href="<%=URL("P_UserComment","1","")%>"><span>待评价商品<em>(<%=Count_Comment(0) %>)</em></span></a></li>
        </ul>
        <div class="dl-table clearfix">
        <dl>
            <dt>商品：</dt>
            <dd><% if (order_product.ImageOriginal == ""){ %>&nbsp;<%}else{ %><a href="<%=URL("P_Product",order_product.Product_id) %>" target="_blank"><img style="height: 30px; width: 30px; vertical-align: middle" src="<%=Image(order_product.ImageOriginal,50,50) %>" /></a><%} %>
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
    </div>
  
<%
if(!IsAPP()){
%>
<div id="footnav">
<ul>
<li><a href="<%=URL("P_Index", "")%>"><img src="/Theme/system/wap/images/home.png" alt="首页" /><span>首页</span></a></li>
<li><a href="<%=URL("P_AllProductCategories", "")%>"><img src="/Theme/system/wap/images/category.png" alt="商品分类" /><span>商品分类</span></a></li>
<li><a href="<%=URL("P_Basket", "")%>"><img src="/Theme/system/wap/images/cart.png" alt="购物车" /><span>购物车</span></a></li>
<li><a href="<%=URL("P_UserCenter", "")%>"><img src="/Theme/system/wap/images/user.png" alt="会员中心" /><span>会员中心</span></a></li>
</ul>
</div>
<%}%>

  
</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>