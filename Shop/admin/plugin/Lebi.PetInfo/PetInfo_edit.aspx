<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PetInfo_edit.aspx.cs" Inherits="Lebi.PetInfo.Admin.PetInfo_Edit"
    MasterPageFile="~/Master/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title><%=Tag("宠物资料")%>-<%=Tag("会员管理")%>-<%=site.title%></title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Path" runat="server">
    <div class="tools">
    <ul>
    <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("保存")%></span></a></li>
    <li class="rotate"><a href="javascript:void(0);" onclick="history.back();"><b></b><span><%=Tag("返回")%></span></a></li>
    <li class="name"><span id="navIgation"><%=Tag("当前位置")%>：<a href="<%=site.AdminPath %>/Ajax/ajax_admin.aspx?__Action=MenuJump&pid=0"><%=Tag("管理首页")%></a> > <a href="<%=site.AdminPath %>/user/default.aspx"><%=Tag("会员管理")%></a> > <%=Tag("宠物资料")%></span></li>
    </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <script type="text/javascript" src="<%=site.AdminJsPath %>/My97DatePicker/WdatePicker.js"></script> 
    <table class="table" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <th>
                <%=Tag("昵称")%>：
            </th>
            <td>
                <input name="NickName" id="NickName" value="<%=model.NickName %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                 <%=Tag("性别")%>：
            </th>
            <td>
                <input type="radio" name="Sex" shop="true" value="0" <%=model.Sex==0?"checked":"" %> /><%=Tag("公")%>
                <input type="radio" name="Sex" shop="true" value="1" <%=model.Sex==1?"checked":"" %> /><%=Tag("母")%>
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("种类")%>：
            </th>
            <td >
                <input name="Breed" value="<%=model.Breed %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("出生日期")%>：
            </th>
            <td >
                <input name="Birthday" value="<%=model.Birthday%>" shop="true" type="text" class="input" style="width: 200px;" onClick="WdatePicker()" />
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("毛色")%>：
            </th>
            <td >
                <select name="Color" shop="true">
                <option value="0">┌ <%=Tag("请选择")%></option>
                <option value="1" <%=model.Color==1?"selected":"" %>><%=Tag("白色")%></option>
                <option value="2" <%=model.Color==2?"selected":"" %>><%=Tag("黑色")%></option>
                <option value="3" <%=model.Color==3?"selected":"" %>><%=Tag("灰色")%></option>
                <option value="4" <%=model.Color==4?"selected":"" %>><%=Tag("杏色")%></option>
                <option value="5" <%=model.Color==5?"selected":"" %>><%=Tag("土豪金")%></option>
                <option value="6" <%=model.Color==6?"selected":"" %>><%=Tag("咖啡色")%></option>
                <option value="7" <%=model.Color==7?"selected":"" %>><%=Tag("酒红色")%></option>
                <option value="8" <%=model.Color==8?"selected":"" %>><%=Tag("花色")%></option>
                </select>
            </td>
            <th>
                <%=Tag("肩高(cm)")%>：
            </th>
            <td >
                <input name="Height" value="<%=model.Height %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("体重(kg)")%>：
            </th>
            <td >
                <input name="Weight" value="<%=model.Weight %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("胸围(cm)")%>：
            </th>
            <td >
                <input name="Bust" value="<%=model.Bust %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("腰围(cm)")%>：
            </th>
            <td >
                <input name="Waistline" value="<%=model.Waistline %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("节育情况")%>：
            </th>
            <td >
                <input type="radio" name="BirthControl" shop="true" value="0" <%=model.BirthControl==0?"checked":"" %> /><%=Tag("未节育")%>
                <input type="radio" name="BirthControl" shop="true" value="1" <%=model.BirthControl==1?"checked":"" %> /><%=Tag("已节育")%>
            </td>
        </tr>
        <tr>
            <th>
                <%=Tag("肥胖度(估算)")%>：
            </th>
            <td>
                <select name="Fat" shop="true">
                <option value="0">┌ <%=Tag("请选择")%></option>
                <option value="1" <%=model.Fat==1?"selected":"" %>><%=Tag("严重肥胖")%></option>
                <option value="2" <%=model.Fat==2?"selected":"" %>><%=Tag("肥胖")%></option>
                <option value="3" <%=model.Fat==3?"selected":"" %>><%=Tag("偏胖")%></option>
                <option value="4" <%=model.Fat==4?"selected":"" %>><%=Tag("适度")%></option>
                <option value="5" <%=model.Fat==5?"selected":"" %>><%=Tag("偏瘦")%></option>
                <option value="6" <%=model.Fat==6?"selected":"" %>><%=Tag("瘦")%></option>
                <option value="7" <%=model.Fat==7?"selected":"" %>><%=Tag("过度瘦弱")%></option>
                </select>
            </td>
            <th>
                <%=Tag("毛发情况")%>：
            </th>
            <td>
                <select name="Hair" shop="true">
                <option value="0">┌ <%=Tag("请选择")%></option>
                <option value="1" <%=model.Hair==1?"selected":"" %>><%=Tag("大面积有结")%></option>
                <option value="2" <%=model.Hair==2?"selected":"" %>><%=Tag("局部有结")%></option>
                <option value="3" <%=model.Hair==3?"selected":"" %>><%=Tag("少量有结")%></option>
                <option value="4" <%=model.Hair==4?"selected":"" %>><%=Tag("无结")%></option>
                </select>
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("狗粮品牌")%>：
            </th>
            <td >
                <input name="FoodBrand" value="<%=model.FoodBrand %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("每日食量(g)")%>：
            </th>
            <td >
                <input name="Appetite" value="<%=model.Appetite %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("喜爱零食")%>：
            </th>
            <td >
                <input name="LikeSnack" value="<%=model.LikeSnack %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("上次洗澡时间")%>：
            </th>
            <td >
                <input name="LastBathTime" value="<%=model.LastBathTime%>" shop="true" type="text" class="input" style="width: 200px;" onClick="WdatePicker()" />
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("上次美容时间")%>：
            </th>
            <td >
                <input name="LastBeautyTime" value="<%=model.LastBeautyTime%>" shop="true" type="text" class="input" style="width: 200px;" onClick="WdatePicker()" />
            </td>
            <th>
                <%=Tag("上次洁齿时间")%>：
            </th>
            <td >
                <input name="LastDentifriceTime" value="<%=model.LastDentifriceTime%>" shop="true" type="text" class="input" style="width: 200px;" onClick="WdatePicker()" />
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("体内驱虫时间")%>：
            </th>
            <td >
                <input name="InWormingTime" value="<%=model.InWormingTime%>" shop="true" type="text" class="input" style="width: 200px;" onClick="WdatePicker()" />
            </td>
            <th>
                <%=Tag("体外驱虫时间")%>：
            </th>
            <td >
                <input name="OutWormingTime" value="<%=model.OutWormingTime%>" shop="true" type="text" class="input" style="width: 200px;" onClick="WdatePicker()" />
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("接种疫苗时间")%>：
            </th>
            <td >
                <input name="VaccinationTime" value="<%=model.VaccinationTime%>" shop="true" type="text" class="input" style="width: 200px;" onClick="WdatePicker()" />
            </td>
            <th>
                <%=Tag("体内驱虫药品")%>：
            </th>
            <td >
                <input name="InWormingDrugs" value="<%=model.InWormingDrugs%>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr  >
            <th>
                <%=Tag("体外驱虫药品")%>：
            </th>
            <td >
                <input name="OutWormingDrugs" value="<%=model.OutWormingDrugs%>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
            <th>
                <%=Tag("疫苗品种种类")%>：
            </th>
            <td >
                <input name="VaccineBrand" value="<%=model.VaccineBrand%>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/plugin/Lebi.PetInfo/ajax.aspx?__Action=PetInfo_Edit&user_id=<%=user_id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "default.aspx")});
        }
    </script>
</asp:Content>