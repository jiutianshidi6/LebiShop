<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.selectproduct_window" validateRequest="false"%>

        <style>
    .headtable{width:100%}
    .headtable tr{border-bottom: 0px solid #ececec;}
    .headtable tr td{border-bottom: 0px solid #ececec;width:33%}
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
<table style="width:100%">
<tr>
<td style="vertical-align:top;width:150px;background-color:#f4f4f4;">
    <table>
    <%=CreateTree(0,0) %>
    </table>
</td>
<td style="vertical-align:top">
<div class="searchbox">
    <input type="text" name="searchkey" id="searchkey" value="<%=key %>" class="input-query" /><input style="border-width:1px;height:30px;padding:0 10px 0 10px" type="button" value="搜索" onclick="searchproduct();searchproductbyptype();" />
</div>
<table class="datalist">
    <tr class="title">
        <th style="width: 50px">
            <%=Tag("图片")%>
        </th>
        <th style="width: 100px">
            <%=Tag("商品编号")%>
        </th>
        <th style="width: 200px">
            <%=Tag("商品名称")%>
        </th>
        <th style="width: 100px">
            <%=Tag("规格型号")%>
        </th>
        <th style="width: 50px">
            <%=Tag("单位")%>
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
       var typeid=0;
        function selectproductone(id,number) {
            search_product(id,number);
        }
        function searchproduct(id)
        {
            if(id!=undefined)
                typeid=id;
            var key=$("#searchkey").val();
            reloadproducts(1,<%=storeid %>,typeid,key); 
        }
        function reloadproducts(pageindex,storeid,typeid,key){
            var url = "<%=site.AdminPath %>/product/selectproduct_list_window.aspx?page="+pageindex+"&storeid="+storeid+"&typeid="+typeid+"&key="+key+"&showall=<%=showall%>";
            GetHtml(url,'productlist');
        }
        reloadproducts(1,<%=storeid %>,0,'');
    </script>
    <script src="<%=WebPath%>/plugin/Lebi.ERP/js/tree.js" type="text/javascript"></script>

  