<%@ Control Language="C#" ClassName="RecentReceivedCommentBox" %>

<div class="side-part portlet">
    <h2>Danh sách bình luận</h2>
    <ul class="imagehead-list">
        <li>
            <asp:HyperLink NavigateUrl="~/profile.aspx" runat="server">
                <asp:Image ImageUrl="~/resources/profiles/no_photo.gif" Width="50" Height="50" runat="server"
                    AlternateText="nickname" ToolTip="nickname" />
            </asp:HyperLink>
            <span class="inline">
                <%--Cut message down to 100 characters, show '...' at the end if message is longer than 100--%>
                Gởi tin nhắn hầm bà lằng, lằnh nhằng, lu xu bu, bát nháo, củ cải, củ hành, ...
                <i><%= string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) %></i>
            </span> 
        </li>
        <li>
            <asp:HyperLink NavigateUrl="~/profile.aspx" runat="server">
                <asp:Image ImageUrl="~/resources/profiles/no_photo.gif" Width="50" Height="50" runat="server"
                    AlternateText="nickname" ToolTip="nickname" />
            </asp:HyperLink>
            <span class="inline">
                Gởi tin nhắn hầm bà lằng, lằnh nhằng, lu xu bu, bát nháo, củ cải, củ hành, ...
                <i><%= string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) %></i>
            </span> 
        </li>
        <li>
            <asp:HyperLink NavigateUrl="~/profile.aspx" runat="server">
                <asp:Image ImageUrl="~/resources/profiles/no_photo.gif" Width="50" Height="50" runat="server"
                    AlternateText="nickname" ToolTip="nickname" />
            </asp:HyperLink>
            <span class="inline">
                Gởi tin nhắn hầm bà lằng, lằnh nhằng, lu xu bu, bát nháo, củ cải, củ hành, ...
                <i><%= string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) %></i>
            </span> 
        </li>
        <li>
            <asp:HyperLink NavigateUrl="~/profile.aspx" runat="server">
                <asp:Image ImageUrl="~/resources/profiles/no_photo.gif" Width="50" Height="50" runat="server"
                    AlternateText="nickname" ToolTip="nickname" />
            </asp:HyperLink>
            <span class="inline">
                Gởi tin nhắn hầm bà lằng, lằnh nhằng, lu xu bu, bát nháo, củ cải, củ hành, ...
                <i><%= string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) %></i>
            </span> 
        </li>
        <li>
            <asp:HyperLink NavigateUrl="~/profile.aspx" runat="server">
                <asp:Image ImageUrl="~/resources/profiles/no_photo.gif" Width="50" Height="50" runat="server"
                    AlternateText="nickname" ToolTip="nickname" />
            </asp:HyperLink>
            <span class="inline">
                Gởi tin nhắn hầm bà lằng, lằnh nhằng, lu xu bu, bát nháo, củ cải, củ hành, ...
                <i><%= string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) %></i>
            </span> 
        </li>
        <li>
            <a class="right" href="../account/guest/receivedcommentlist.aspx">&raquo; Xem thêm</a>
            <div class="clear"></div>
        </li>
    </ul>
</div>