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
    <input type="text" name="searchkey" id="searchkey" value="<%=key %>" class="input-query" />
    <input style="border-width:1px;height:30px;padding:0 10px 0 10px" type="button" value="<%=Tag("搜索")%>" onclick="searchproduct();" />
    <input style="border-width:1px;height:30px;padding:0 10px 0 10px" type="button" value="<%=Tag("添加选中")%>" onclick="AddSelected();" />
</div>
<table class="datalist">
    <tr class="title">
        <th style="width: 30px">
            <a href="javascript:void(0);" onclick="$('input[name=\'pids\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));checkboxchange('pids');"><%=Tag("全选")%></a>
        </th>
        <th style="width: 40px">
            <%=Tag("图片")%>
        </th>
        <th style="width: 70px">
            <%=Tag("商品编号")%>
        </th>
        <th style="">
            <%=Tag("商品名称")%>
        </th>
        <th style="width: 120px">
            <%=Tag("规格型号")%>
        </th>
        <th style="width: 50px">
            <%=Tag("库存")%>
        </th>
        <th style="width: 50px">
            <%=Tag("价格")%>
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
    <script src="<%=WebPath%>/plugin/Lebi.ERP/js/tree.js" type="text/javascript"></script>
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
            var url = "<%=site.AdminPath %>/order/selectproductadd_list_window.aspx?page="+pageindex+"&storeid="+storeid+"&typeid="+typeid+"&key="+key+"&showall=<%=showall%>&isparent=<%=isparent%>";
            GetHtml(url,'productlist');
        }
        reloadproducts(1,<%=storeid %>,0,'');
        //向订单添加选中的商品
        function AddSelected()
        {
            if(selectproductmuti==undefined){
                var postData = GetFormJsonData("orderp");
                var orderid=$('#currentOrder_id').val();
                var url = "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=order_product_edit&orderid="+orderid;
                RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
            }
            else{
                selectproductmuti();
            }
        }
        selectlist_clear();
    </script>
    

  