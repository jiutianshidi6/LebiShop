<%@ Page Language="C#" AutoEventWireup="true" Inherits="Lebi.ERP.Bussiness.pagebase.user_edit_window" validateRequest="false"%>

<table class="table">
        <tr>
            <th>
                <%=Tag("会员帐号")%>：
            </th>
            <td>
                <%if (model.id == 0){ %><input name="UserName" id="UserName" value="<%=model.UserName %>" onchange="CheckUserName();" shop="true" type="text" class="input" style="width: 200px;" />
                <%}else{ %>
                <%=model.UserName %>
                <%}%>

                <span id="FormUserName"></span>
            </td>
        </tr>
        <tr>
           
            <th>
                <%=Tag("绑定")%>：
            </th>
            <td> 
                <%
                  if (model.bind_weixin_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_weixin_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_weibo_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_weibo_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_qq_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_qq_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_taobao_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_taobao_image + "\" height=\"24px\" />");
                  }
                  if (model.bind_facebook_id != "")
                  {
                      Response.Write("<img src=\"" + SYS.platform_facebook_image + "\" height=\"24px\" />");
                  }
                %>&nbsp;
            </td>
        </tr>
        <tr  >
            <th>
                姓名：
            </th>
            <td>
                <input name="RealName" value="<%=model.RealName %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>

        <tr>
            <th>
                手机号码：
            </th>
            <td>
                <input name="MobilePhone" value="<%=model.MobilePhone %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                Email：
            </th>
            <td>
                <input name="Email" value="<%=model.Email %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
        </tr>
        <tr>
            <th>
                QQ号码：
            </th>
            <td>
                <input name="QQ" value="<%=model.QQ %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                微信：
            </th>
            <td>
                <input name="weixin" value="<%=model.weixin %>" shop="true" type="text" class="input" style="width: 200px;" />
            </td>
         </tr>
        <tr>
            <th>
                权限：
            </th>
            <td>
                <label><input name="lebierp_UserLimit" value="showprice" shop="true" type="checkbox" <%=model.lebierp_UserLimit.Contains("showprice")?"checked":"" %>/>看价权限</label>
                <label><input name="lebierp_UserLimit" value="usemoney" shop="true" type="checkbox" <%=model.lebierp_UserLimit.Contains("usemoney")?"checked":"" %>/>资金权限</label>
            </td>
         </tr>
        <tr  >
            <th style="vertical-align:top">
                <%=Tag("内部备注")%>：<br>
                <em>≤ <span id="remLen">255</span></em>
            </th>
            <td>
                <textarea name="Introduce" id="Introduce" shop="true" rows="3" cols="60" class="input" onKeyDown="checkMaxInput(this.form)" onKeyUp="checkMaxInput(this.form)" style="height: 55px;width: 400px;"><%=model.Introduce%></textarea>
                <div class="tools clear">
                    <ul>
                        <li class="plus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Introduce',100);"><b></b><span><%=Tag("展开")%></span></a></li>
                        <li class="minus"><a href="javascript:void(0);" onclick="javascript:resizeEditor('Introduce',-100)"><b></b><span><%=Tag("收缩")%></span></a></li>
                    </ul>
                </div>
            </td>
        </tr>
    <tr>
        <td colspan="2" class="action">
            <div class="tools tools-m">
                <ul>
                    <li class="submit"><a href="javascript:void(0);" onclick="SaveObj();"><b></b><span><%=Tag("保存")%></span></a></li>
                </ul>
            </div>
        </td>
    </tr>
    </table>
    <input name="lebierp_User_id_main" id="lebierp_User_id_main" value="<%=Shop.Tools.RequestTool.RequestInt("pid", 0) %>" shop="true" type="hidden"  />
    <script type="text/javascript">
        var maxLen = 255;
        var Introduce = document.getElementById("Introduce");
        function checkMaxInput(form) {
            if (Introduce.value.length > maxLen)
                Introduce.value = Introduce.value.substring(0, maxLen);
            else document.getElementById("remLen").innerHTML = maxLen - Introduce.value.length;
        }
        function SaveObj() {
            var postData = GetFormJsonData("shop");
            var url = "<%=site.AdminPath %>/ajax/ajax_ex.aspx?__Action=User_Edit&id=<%=model.id %>";
            RequestAjax(url,postData,function(){MsgBox(1, "<%=Tag("操作成功")%>", "?")});
        }
        function CheckUserName()
        {
            var UserName=$("#UserName").val();
            var postData={"UserName":UserName};
            var url = "<%=site.AdminPath %>/ajax/ajax_user.aspx?__Action=CheckUserName&id=<%=model.id %>";
            $.ajax({
                type: "POST",
                url: url,
                data: postData,
                dataType: 'json',
                success: function (res) {
                    if(res.msg=="OK")
                        CheckOK("UserName",'');
                    else
                        CheckNO("UserName",'<%=Tag("用户名已经存在") %>');
                }
            });
        }
        function EditPassword(id) {
            var title_ = "<%=Tag("改密")%>";
            var url_ = "userpassword_edit_window.aspx?id="+id;
            var width_ = 500;
            var height_ = 'auto';
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
        function Question(id) {
            var title_ = "<%=Tag("安全问题")%>";
            var url_ = "userquestion_edit_window.aspx?id="+id;
            var width_ = 500;
            var height_ = 'auto';
            var modal_ = true;
            EditWindow(title_, url_, width_, height_, modal_);
        }
    </script>

  