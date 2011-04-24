<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserConversationBox.ascx.cs" Inherits="NewsVn.Web.Modules.UserConversationBox" %>

<div class="side-part portlet">
    <h2>Thông tin trao đổi</h2>
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            Vui lòng
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/account/form/login.aspx" Text="đăng nhập" runat="server" />
            để xem thông tin
        </AnonymousTemplate>
        <LoggedInTemplate>
            <ul class="imagehead-list">
                <li>
                    <asp:Image ID="Image1" ImageUrl="~/resources/profiles/no_photo.gif" Width="50" Height="50" runat="server"
                        AlternateText="nickname" ToolTip="nickname" />
                    <span class="inline">
                        <%--Cut message down to 100 characters, show '...' at the end if message is longer than 100--%>
                        Gởi tin nhắn hầm bà lằng, lằnh nhằng, lu xu bu, bát nháo, củ cải, củ hành, ...
                        <i><%= string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) %></i>
                    </span> 
                </li>
                <li>
                    <asp:Image ID="Image2" ImageUrl="~/resources/profiles/no_photo.gif" Width="50" Height="50" runat="server"
                        AlternateText="nickname" ToolTip="nickname" />
                    <span class="inline">
                        Gởi tin nhắn hầm bà lằng, lằnh nhằng, lu xu bu, bát nháo, củ cải, củ hành, ...
                        <i><%= string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) %></i>
                    </span> 
                </li>
                <li>
                    <asp:Image ID="Image3" ImageUrl="~/resources/profiles/no_photo.gif" Width="50" Height="50" runat="server"
                        AlternateText="nickname" ToolTip="nickname" />
                    <span class="inline">
                        Gởi tin nhắn hầm bà lằng, lằnh nhằng, lu xu bu, bát nháo, củ cải, củ hành, ...
                        <i><%= string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) %></i>
                    </span> 
                </li>
                <li>
                    <asp:Image ID="Image4" ImageUrl="~/resources/profiles/no_photo.gif" Width="50" Height="50" runat="server"
                        AlternateText="nickname" ToolTip="nickname" />
                    <span class="inline">
                        Gởi tin nhắn hầm bà lằng, lằnh nhằng, lu xu bu, bát nháo, củ cải, củ hành, ...
                        <i><%= string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) %></i>
                    </span> 
                </li>
                <li>
                    <asp:Image ID="Image5" ImageUrl="~/resources/profiles/no_photo.gif" Width="50" Height="50" runat="server"
                        AlternateText="nickname" ToolTip="nickname" />
                    <span class="inline">
                        Gởi tin nhắn hầm bà lằng, lằnh nhằng, lu xu bu, bát nháo, củ cải, củ hành, ...
                        <i><%= string.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now) %></i>
                    </span> 
                </li>
                <li>
                    <a class="right" href="#">&raquo; Xem thêm</a>
                    <div class="clear"></div>
                </li>
            </ul>
        </LoggedInTemplate>
    </asp:LoginView>    
</div>