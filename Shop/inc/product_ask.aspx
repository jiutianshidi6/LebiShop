<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.inc.product_ask" validateRequest="false"%><%LoadPage();%>

<div class="comments_info">
    <%foreach (Shop.Model.Lebi_Comment model in models)
      {%>
    <dl class="comments_list">
        <dd>
            <div class="c_author">
                <h3 class="c_title">
                    <%=model.User_UserName %></h3>
                <span class="c_date">
                    <%=model.Time_Add %></span>
            </div>
            <div class="c_content">
                <div class="c_text">
                    <%=model.Content.Replace("\r\n", "<br/>")%></div>
            </div>
            <%
                List<Shop.Model.Lebi_Comment> modelr = Shop.Bussiness.B_Lebi_Comment.GetList("Parentid = " + model.id + "", "id desc", PageSize, pageindex);
                foreach (Shop.Model.Lebi_Comment modelreply in modelr)
                {
            %>
            <ul class="c_list c_customer">
                <li><strong>
                    <%=Tag("客服回复")%>：</strong><%=modelreply.Content.Replace("\r\n", "<br/>")%><em><%=modelreply.Time_Add%></em></li></ul>
            <%} %>
            <div class="comments_bg arrow">
            </div>
        </dd>
    </dl>
    <%} %>
</div>
<div class="bottom clearfix">
    <%=PageString%></div>

  