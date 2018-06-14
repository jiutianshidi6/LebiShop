<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.inc.userstatus" validateRequest="false"%>
<%if (CurrentUser.id > 0 && CurrentUser.IsAnonymous==0)
  {%>
<a href="<%=URL("P_UserCenter","") %>" title="<%=Tag("会员中心")%>">
<%if (CurrentUser.Face.Trim() != "")
  { %>
  <img src="<%=CurrentUser.Face %>" height="20"  />
<%} %>
    <%if (CurrentUser.NickName != "") { Response.Write(CurrentUser.NickName); } else { Response.Write(CurrentUser.UserName); } %></a> ┊ <a href="<%=URL("P_UserMessage","0")%>" title="<%=Tag("收件箱")%>"><span><%=Tag("站内信")%>(<%=Count_Message(0) %>)</span></a> ┊ <a href="<%=URL("P_UserAsk","")%>"><%=Tag("商品咨询")%><span>(<%=Count_ProductAsk(0) %>)</span></a> ┊ <a href="javascript:LoginOut();"><%=Tag("退出登录")%></a>
<%}
  else
  { %>
<a href="<%=URL("P_Login", "") %>" class="top-user-login"><i></i>登录</a>
<span class="topbar-bt-sign"><a class="topbar-link" target="_blank" href="<%=URL("P_Register", "") %>">注册</a></span>
<%} %>