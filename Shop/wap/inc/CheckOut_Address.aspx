<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.inc.CheckOut_Address" validateRequest="false"%>
<div style="<%=address.id>0?"": "display:none;" %>" id="address_current">
<div class="dl-table clearfix">
    <dl>
        <dt><%=address.Name%></dt>
        <dd><%=address.MobilePhone +" "+ address.Phone%></dd>
        <dd class="list"><%=Shop.Bussiness.EX_Area.GetAreaName(address.Area_id, 2) + " "+ address.Address%>
            [<a class="click" href="javascript:EditAddress();"><%=Tag("修改")%></a>]
        </dd>
    </dl>
</div>
</div>
<div style="display: none;" id="address_edit">
<div class="dl-table clearfix">
    <% 
        foreach (Shop.Model.Lebi_User_Address model in models)
        {    
    %>
    <dl>
        <dt><label><input type="radio" name="address_id" value="<%=model.id %>" <%=model.id==id?"checked":"" %> /> <%=model.Name %></label></dt>
        <dd><%=model.MobilePhone %> <%=model.Phone%></dd>
        <dd class="list"><%=Shop.Bussiness.EX_Area.GetAreaName(model.Area_id,2)+ model.Address %> <a class="click" href="javascript:AddAddress(<%=model.id %>);"><%=Tag("编辑")%></a></dd>
    </dl>
    <%} %>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0);" onclick="SetAddress();" class="btn btn-7"><s></s><%=Tag("确定")%></a>
            <a href="javascript:void(0);" onclick="AddAddress(99999);" class="btn btn-11"><s></s><%=Tag("新收货人")%></a>
        </dd>
    </dl>
</div>
</div>
<div id="address_add" class="address_add" style="<%if (address.id==0){Response.Write("display:;");}%>">
    <div class="dl-table clearfix">
    <dl>
        <dt style="color:#ff0000"><%=Tag("地址粘贴处")%>：</dt>
        <dd><textarea id="Content" name="Content" cols="80" rows="3" class="textarea" style="height:100px;width: 80%;" onKeyDown="TaobaoAddress();" onKeyUp="TaobaoAddress();"></textarea><br />
        <font color=blue>请在淘宝卖出宝贝-订单详情-物流信息，复制地址粘贴至上框即可填充地址，格式如下：</font><br />
        收货地址：陈生，13600000000，020-88888888，广东省 广州市 番禺区 洛溪新城A座201室 ，510055<br />
        <font color=red>地区需要手动选择</font></dd>
    </dl>
    <dl>
        <dt><span class="red">*</span><%=Tag("姓名")%>：</dt>
        <dd><input type="text" id="Name" name="Name" min="notnull" size="20" value="<%=edit_address.Name %>" class="input" consignee="true" /></dd>
    </dl>
    <dl>
        <dt><span class="red">*</span><%=Tag("手机号码")%>：</dt>
        <dd><input type="text" id="MobilePhone" onkeyup="value=value.replace(/[^\d]/g,'')" maxlength="20" min="notnull" name="MobilePhone" size="20" value="<%=edit_address.MobilePhone %>" class="input" consignee="true" /></dd>
    </dl>
    <dl>
        <dt><%=Tag("电话号码")%>：</dt>
        <dd><input type="text" id="Phone" name="Phone"  size="20" value="<%=edit_address.Phone %>" consignee="true" class="input" /></dd>
    </dl>
    <dl>
        <dt><%=Tag("Email")%>：</dt>
        <dd><input type="text" id="Email" name="Email" min="email" size="20" value="<%=edit_address.Email %>" consignee="true" class="input" /></dd>
    </dl>
    <dl>
        <dt><%=Tag("邮政编码")%>：</dt>
        <dd><input type="text" id="Postalcode" name="Postalcode" size="10" consignee="true" value="<%=edit_address.Postalcode %>" class="input" /></dd>
    </dl>
    <dl>
        <dt><span class="red">*</span><%=Tag("地区")%>：</dt>
        <dd><div id="Area_id_div"></div></dd>
    </dl>
    <dl>
        <dt><span class="red">*</span><%=Tag("详细地址")%>：</dt>
        <dd><input type="text" id="Address" min="notnull" name="Address" consignee="true" value="<%=edit_address.Address %>" class="input" /></dd>
    </dl>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0);" onclick="SaveAddress(<%=edit_id%>);" class="btn btn-7"><s></s><%=Tag("保存")%></a>
        <% if (address.id > 0)
            {%>
        <a href="javascript:void(0);" onclick="AddAddress();" class="btn btn-11"><s></s><%=Tag("收起")%></a>
        <%}
            else
            {%>
        <a href="javascript:void(0);" onclick="javascript:history.back();" class="btn btn-11"><s></s><%=Tag("返回")%></a>
        <%} %>
        </dd>
    </dl>
    </div>
</div>
<script type="text/javascript">
    <%if (edit_id == 0){ %>$("#address_add").hide();GetAreaList(<%=SYS.TopAreaid %>, 0);<%}else{%>GetAreaList(<%=SYS.TopAreaid %>, <%=edit_address.Area_id %>);<%} %>
    LoadPage("<%=WebPath%>/inc/CheckOut_Transport.aspx", "checkout_transport");
    <%if(address.id==0){ %>
    $("#address_add").show();
        HighlightDiv("address_add");
    <%} %>
    function SaveAddress(id) {
        var postData = GetFormJsonData("consignee");
        if (!CheckForm("consignee", "span"))
            return false;
        var Area_id = $("#Area_id").val();
        if (Area_id == 0) {
            CheckNO("Area_id","","span");
            return false;
        }
        var url = path+"/ajax/ajax_order.aspx?__Action=Address_Edit&Area_id=" + Area_id +"&id=" + id;
        RequestAjax(url, postData, function (res) {
             MsgBox(1, "<%=Tag("操作成功")%>", "");
             HighlightDivHide();
             LoadPage("<%=WebPath %>/inc/CheckOut_Address.aspx?id=" + res.id, "checkout_address");
        });
    }
    function SetAddress() {
        var address_id = $("input[name='address_id']:checked").val();
        var postData = { "address_id": address_id };
        var url = path+"/ajax/ajax_order.aspx?__Action=Address_Set";
        RequestAjax(url, postData, function (res) { LoadPage("<%=WebPath %>/inc/CheckOut_Address.aspx?id=" + res.id, "checkout_address");MsgBoxClose();HighlightDivHide();});
    }
    function TaobaoAddress()
    {
        var returntxt = $("#Content").val();
        var address = returntxt.split("，")[3];
        var arr = new Array();
        arr = address.split(' ');
        var i = arr.length-2;
        i = i < 0 ? 0 : i;
        $("#Name").val(returntxt.split("，")[0]);
        $("#MobilePhone").val(returntxt.split("，")[1]);
        $("#Phone").val(returntxt.split("，")[2]);
        $("#Address").val(arr[i]);
        $("#Postalcode").val(returntxt.split("，")[4]);
    }
</script>