<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.inc.product_comment" validateRequest="false"%>
<div class="comments_top">
    <div class="comments_section_1">
        <strong><%=Tag("商品满意度")%><em><%=model.Star_Comment%></em><%=Tag("分")%></strong> <span><%=Tag("共")%>
            <%=model.Count_Comment%>
            <%=Tag("人评分")%></span>
    </div>
    <div class="comments_section_2">
        <h4>
            <%=Tag("商品满意度")%></h4>
        <ul>
            <li><em class="comments_bg stars_s_5"></em><span style="background: #e85864; width: px">
            </span>
                <%=Star5Percent%>%</li>
            <li><em class="comments_bg stars_s_4"></em><span style="background: #e85864; width: px">
            </span>
                <%=Star4Percent%>%</li>
            <li><em class="comments_bg stars_s_3"></em><span style="background: #e85864; width: px">
            </span>
                <%=Star3Percent%>%</li>
            <li><em class="comments_bg stars_s_2"></em><span style="background: #e85864; width: px">
            </span>
                <%=Star2Percent%>%</li>
            <li><em class="comments_bg stars_s_1"></em><span style="background: #e85864; width: px">
            </span>
                <%=Star1Percent%>%</li>
        </ul>
    </div>
    <div class="comments_section_3">
        <h4>
            <strong><%=Tag("该商品怎么样？")%></strong></h4>
        <ul>
            <li><%=Tag("发表评价最高可获得")%><span class="red"><%=SYS.CommentPoint %></span><%=Tag("积分")%></li>
            <li><a href="<%=URL("P_UserCommentWrite",","+model.id) %>" target="_blank" class="btn btn-11">
                <s></s><%=Tag("发表评价")%></a></li>
        </ul>
    </div>
    <div class="clear">
    </div>
</div>
<div class="comments_info">
    <%foreach (Shop.Model.Lebi_Comment m in models)
      {%>
    <script type="text/javascript">
        $(document).ready(function () {
            $("area[rel^='prettyPhoto<%=model.id %>']").prettyPhoto();
            $(".piclist<%=model.id %>:first a[rel^='prettyPhoto<%=model.id %>']").prettyPhoto({ animation_speed: 'fast', slideshow: 10000, hideflash: true });
        })
    </script>
    <dl class="comments_list">
        <dd>
            <div class="c_author">
                <h3 class="c_title">
                    <%=m.User_UserName %></h3>
                <span class="c_stars comments_bg stars_m_<%=m.Star %>"></span><span class="c_date">
                    <%=m.Time_Add %></span>
            </div>
            <div class="c_content">
                <div class="c_text">
                    <%=m.Content.Replace("\r\n", "<br/>")%>
                </div>
                <ul class="piclist<%=model.id %>">
                    <%
                        string[] images = m.ImagesSmall.Split('@');
                        string[] bigs = m.Images.Split('@');
                        for (int i = 0; i < images.Count();i++)
                        {
                            if (images[i] == "")
                                continue;
                    %>
                    <li class="imagespreviewlist">
                        <span class="image"><a href="<%=WebPath+bigs[i] %>" rel="prettyPhoto<%=model.id %>[]" target="_blank"><img src="<%=WebPath+images[i] %>" /></a></span>
                    </li>
                        <%} %>
                </ul>
            </div>
            <%
                List<Shop.Model.Lebi_Comment> modelr = Shop.Bussiness.B_Lebi_Comment.GetList("Parentid = " + m.id + "", "id desc", PageSize, pageindex);
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
<div class="bottom clearfix"><%=PageString%></div>