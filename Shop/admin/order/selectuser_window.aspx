<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.selectuser_window" validateRequest="false"%>

        <style>
    .headtable{width:100%}
    .headtable tr{border-bottom: 0px solid #ececec;}
    .headtable tr td{border-bottom: 0px solid #ececec;}
    .datalist .list td {
        border-bottom: 1px solid #ececec;
        color: #808080;
        line-height: 150%;
        padding: 5px 10px;
        text-align: left;

    }
        </style>
<table style="width:100%">
<tr>
<td style="vertical-align:top;width:150px;background-color:#f4f4f4;">
    <table>
    <%=CreateTree() %>
    </table>
</td>
<td style="vertical-align:top">
<div class="searchbox">
    <input type="text" name="searchkey" id="searchkey" value="<%=key %>" class="input-query" />
    <input style="border-width:1px;height:30px;padding:0 10px 0 10px"  type="button" value="搜索" onclick="searchproduct(<%=userlevelid%>);" />
</div>
<table class="datalist">
    <tr class="title">
        <th style="">
            <%=Tag("账号")%>
        </th>
        <th style="">
            <%=Tag("公司")%>
        </th>
        <th style="width: 100px">
            <%=Tag("姓名")%>
        </th>
        <th style="width: 100px">
            <%=Tag("分组")%>
        </th>
        <th style="width: 80px">
           

        </th>
       
    </tr>
    <tbody id="productlist">
    </tbody>
</table>
<div>
</div>
</td>
</tr>
</table>
    <script type="text/javascript">
        var userlevelid=<%=userlevelid %>;
        function selectproductone(id,number) {
            search_product(id,number);
        }
        function searchproduct(id)
        {
            if(id!=undefined)
                userlevelid=id;
            var key=$("#searchkey").val();
            reloadproducts(1,key,userlevelid); 
        }
        function reloadproducts(pageindex,key,userlevelid){
            var url = "<%=site.AdminPath %>/order/selectuser_list_window.aspx?page="+pageindex+"&key="+key+"&userlevelid="+userlevelid+"&productid=<%=product.id%>";
            GetHtml(url,'productlist');
        }
       
        reloadproducts(1,'',<%=userlevelid%>);

        function UserAddOrder(userid)
        {
            if (!confirm("<%=Tag("确认操作吗？")%>"))
             return false;
            var postData = { "userid": userid };
        var url = "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=checkout_orde_Add";
            RequestAjax(url,postData,function(res){MsgBox(1, "<%=Tag("操作成功")%>", "<%=site.AdminPath %>/order/checkout.aspx?id="+res.id)});
        }
    </script>
    <script src="<%=site.AdminJsPath %>/tree.js" type="text/javascript"></script>

  