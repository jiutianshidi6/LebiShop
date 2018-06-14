<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Lebi.PetInfo.Admin.Default"
    MasterPageFile="~/Master/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title><%=Tag("会员管理")%>-<%=site.title%></title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Path" runat="server">
    <div class="tools">
    <ul>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <%=Tag("会员列表")%></span></li>
    </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script> 
    <div class="searchbox">
        <select name="datetype" id="datetype">
            <option value="">┌ <%=Tag("日期类型")%></option>
            <option value="1" <%=datetype=="1"?"selected":"" %>>┌ <%=Tag("上次洗澡时间")%></option>
            <option value="2" <%=datetype=="2"?"selected":"" %>>┌ <%=Tag("上次美容时间")%></option>
            <option value="3" <%=datetype=="3"?"selected":"" %>>┌ <%=Tag("上次洁齿时间")%></option>
            <option value="4" <%=datetype=="4"?"selected":"" %>>┌ <%=Tag("体内驱虫时间")%></option>
            <option value="5" <%=datetype=="5"?"selected":"" %>>┌ <%=Tag("体外驱虫时间")%></option>
            <option value="6" <%=datetype=="6"?"selected":"" %>>┌ <%=Tag("接种疫苗时间")%></option>
            <option value="7" <%=datetype=="7"?"selected":"" %>>┌ <%=Tag("出生日期")%></option>
        </select>
        <input type="text" name="dateFrom" id="dateFrom" size="12" class="input-calendar" value="<%=dateFrom %>" onClick="WdatePicker()" /> - <input type="text" name="dateTo" id="dateTo" size="12" class="input-calendar" value="<%=dateTo %>" onClick="WdatePicker()" />
        <input name="key" type="text" id="key" class="input-query" value="<%=key %>" onkeydown="if(event.keyCode==13){search_();}" /><input type="button" id="btnSou" class="btn-query" onclick="search_();" align="absmiddle" /> 
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" border="0" class="datalist">
        <tr class="title">
            <th style="width: 40px" class="selectAll">
                <a href="javascript:void(0);" onclick="$('input[name=\'sid\']').attr('checked',!$(this).attr('checked'));$(this).attr('checked',!$(this).attr('checked'));"><%=Tag("全选")%></a>
            </th>
            <th style="width: 100px"><%=Tag("会员帐号")%></th>
            <th style="width: 100px"><%=Tag("姓名")%></th>
            <th style="width: 100px"><%=Tag("手机号码")%></th>
            <th style="width: 100px"><%=Tag("宠物昵称")%></th>
            <th style="width: 60px"><%=Tag("性别")%></th>
            <th style="width: 100px"><%=Tag("种类")%></th>
            <th style="width: 130px"><%=Tag("上次洗澡时间")%></th>
            <th style="width: 130px"><%=Tag("上次美容时间")%></th>
            <th><%=Tag("操作")%></th>
        </tr>
        <%foreach (Shop.Model.Lebi_User model in models)
          {%>
        <tr class="list" ondblclick="Edit(<%=model.id %>);">
            <td align="center">
                <input type="checkbox" name="sid" value="<%=model.id %>" />
            </td>
            <td title="<%=Tag("昵称")%>：<%=model.NickName %>">
                <%=model.UserName %>
            </td>
            <td>
                <%=model.RealName %>&nbsp;
            </td>
            <td><%=model.MobilePhone%>&nbsp;
            </td>
            <td>
                <%=Lebi.PetInfo.Bussiness.EX_PetInfo.GetPetInfo(model.id).NickName%>&nbsp;
            </td>
            <td>
                <%=Lebi.PetInfo.Bussiness.EX_PetInfo.GetPetInfo(model.id).Sex==0?Tag("公"):Tag("母")%>&nbsp;
            </td>
            <td>
                <%=Lebi.PetInfo.Bussiness.EX_PetInfo.GetPetInfo(model.id).Breed%>&nbsp;
            </td>
            <td>
                <%=Lebi.PetInfo.Bussiness.EX_PetInfo.GetPetInfo(model.id).LastBathTime%>
            </td>
            <td>
                <%=Lebi.PetInfo.Bussiness.EX_PetInfo.GetPetInfo(model.id).LastBeautyTime%>
            </td>
            <td>
                <a href="javascript:void(0)" onclick="Edit(<%=model.id %>);"><%=Tag("编辑")%></a> 
                | <a href="PetInfo_edit.aspx?user_id=<%=model.id %>"><%=Tag("宠物资料")%></a>
            </td>
        </tr>
        <%} %>
    </table>
    <script type="text/javascript">
        function search_(scurl) {
            var key = $("#key").val();
            var datetype = $("#datetype").val();
            var dateFrom = $("#dateFrom").val();
            var dateTo = $("#dateTo").val();
            window.location = "?key=" + escape(key) + "&datetype="+datetype+"&dateFrom="+dateFrom+"&dateTo="+dateTo;
        }
        function OrderBy(url) {
            MsgBox(4, "<%=Tag("正在排序，请稍后")%> ……", url+"&<%=su.URL %>");
        }
        function Edit(id) {
            window.location = "<%=site.AdminPath %>/user/user_edit.aspx?id=" + id;
        }
    </script>
</asp:Content>
<asp:Content ID="Bottom" ContentPlaceHolderID="Bottom" runat="server">
<div class="bottom" id="body_bottom">
    <%=PageString%>
</div>
</asp:Content>