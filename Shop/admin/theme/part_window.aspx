<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Admin.theme.part_window" validateRequest="false"%>

<%
string folder = "page";
string Path_Skin = "";
if (ispage==1){
    folder = "page";
}else if (ispage==0){
    folder = "block";
    Path_Skin = "inc/";
}else if (ispage==2){
    folder = "layout";
    Path_Skin = "layout/";
}
%>
    <ul class="tablist">
        <li id="li-web" class="selected"><a href="javascript:void(0);" onclick="getpartlist('<%=folder %>');$('#li-web').attr('class','selected');$('#li-wap').attr('class','');"><span>WEB</span></a></li>
        <li id="li-wap"><a href="javascript:void(0);" onclick="getpartlist('wap/<%=folder %>');$('#li-web').attr('class','');$('#li-wap').attr('class','selected');"><span>WAP</span></a></li>
    </ul>
    <table class="datalist">
        <tr class="title">
            <th style="width: 250px;">
                <%=Tag("名称")%>
            </th>
            <th style="width: 200px;">
                <%=Tag("说明")%>
            </th>
            <th style="width: 200px;">
                <%=Tag("限制")%>
            </th>
            <th style="width: 130px;">
                <%=Tag("更新时间")%>
            </th>
            <th>
                <%=Tag("操作")%>
            </th>
        </tr>
        <tbody id="partlist"></tbody>
    </table>
    <script type="text/javascript">
        function Load(name) {
            window.location = "?file=" + name;
        }
        function LoadSystemPage(filename) {
            var url = "<%=site.AdminPath %>/ajax/ajax_theme.aspx?__Action=GetSkinContent&filename=" + filename;
            if (filename.substring(0,4)=="wap/"){filename=filename.replace("wap/","");}
            if (filename.substring(0,6)=="block/"){filename=filename.replace("block/","inc/");}
            if (filename.substring(0,5)=="page/"){filename=filename.replace("page/","");}
            LoadHtml(url, "", function (res) { $("#SkinContent").val(res); $("#Path_Skin").val(filename); $("#partdiv").dialog('close'); });
        }
        function LoadHtml(url, jsondata, callback) {
            $.ajax({
                type: "POST",
                url: url,
                data: jsondata,
                dataType: 'html',
                success: function (res) {
                    callback(res);
                    return false;
                }
            });
        }
        function getpartlist(folder) {
            $.ajax({
                type: "POST",
                url: "part_window_list.aspx?folder="+ folder,
                data: '',
                success: function (res) {
                    $("#div_error").dialog('close');
                    $("#partlist").html(res);
                }
            });
        }
        $(function () {
            getpartlist("<%=folder %>");
        });
    </script>

  