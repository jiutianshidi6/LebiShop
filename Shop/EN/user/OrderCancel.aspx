<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_UserOrderCancel" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("wangdayu523@163.com_37",1,"EN","P_UserOrderCancel"); %>


    

<div class="window">
    <div class="dl-table clearfix">
    <dl>
        <dt>Reason for cancellation：</dt>
        <dd><select id="Content" name="Content" onchange="SelectOption();" shop="true">
        <option value="option1">Do not want to buy</option> 
        <option value="option2">Goods more expensive</option> 
        <option value="option3">Price Fluctuation</option> 
        <option value="option4">Goods Sold</option> 
        <option value="option5">Duplicate orders</option> 
        <option value="option6">Add or remove items</option> 
        <option value="option7">Consignee information is incorrect</option> 
        <option value="option8">Invoice information is incorrect</option> 
        <option value="option9">Can not pay for an order</option> 
        <option value="option10">Other reasons</option> 
        </select></dd>
    </dl>
    <dl id="DIVRemark" style="display:none">
        <dt>Supplement：</dt>
        <dd><textarea class="textarea" style="width: 100%; height: 50px;" id="Remark" name="Remark" min="notnull" shop="true">Do not want to buy</textarea>
        <span id="Formsay"></span></dd>
    </dl>
    <dl class="dl-btn">
        <dt></dt>
        <dd><a href="javascript:void(0)" onclick="submit();" class="btn btn-12"><s></s>Submit</a></dd>
    </dl>
    </div>
</div>
<script type="text/javascript" >
    function SelectOption() {
        var Content = $("#Content").val();
        if (Content == "option10") {
            $("#DIVRemark").show();
            $("#Remark").html("");
        } else {
            $("#DIVRemark").hide();
            switch (Content) {
                case "option1":
                    $("#Remark").html("Do not want to buy");
                    break;
                case "option2":
                    $("#Remark").html("Goods more expensive");
                    break;
                case "option3":
                    $("#Remark").html("Price Fluctuation");
                    break;
                case "option4":
                    $("#Remark").html("Goods Sold");
                    break;
                case "option5":
                    $("#Remark").html("Duplicate orders");
                    break;
                case "option6":
                    $("#Remark").html("Add or remove items");
                    break;
                case "option7":
                    $("#Remark").html("Consignee information is incorrect");
                    break;
                case "option8":
                    $("#Remark").html("Invoice information is incorrect");
                    break;
                case "option9":
                    $("#Remark").html("Can not pay for an order");
                    break;
            }
        }
    }
    function submit() {
        if (!CheckForm("shop", "span"))
            return false;
        var postData = GetFormJsonData("shop");
        var url = path + "/ajax/Ajax_order.aspx?__Action=OrderCancal&id=<%=order.id %>";
        RequestAjax(url, postData, function () { MsgBox(1, "Operation Successful", "?") });
    }
</script>

<div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>