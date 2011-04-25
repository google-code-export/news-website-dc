<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.PostsPortlet" %>
<asp:Panel ID="container" CssClass="cate-posts portlet" runat="server">
    
    <script type="text/javascript">
        $(function () {
            var boundary = "#<%= container.ClientID %>";
            $(boundary + " .avatar-thumb-list img").click(function () {
                var matchItem = $(boundary + " .post-item-list.other li." + $(this).attr("class"));
                var activeItem = $(boundary + " .active-post-item");
                var cloneItem = activeItem.clone();

                var activeAvatar = $(boundary + " .post-avatar");
                var cloneAvatar = activeAvatar.clone();

                activeItem.find(".post-comment").text(matchItem.find(".post-comment").text());
                activeItem.find(".post-title").text(matchItem.find(".post-title").text());
                activeItem.find(".post-info").text(matchItem.find(".post-info").text());
                activeItem.find("p").text(matchItem.find(".description").text());
                activeAvatar.attr("src", $(this).attr("src"));
                activeAvatar.attr("alt", $(this).attr("alt"));
                activeAvatar.attr("title", $(this).attr("title"));
                activeAvatar.css({ "display": "none" });
                activeAvatar.fadeIn(500);

                matchItem.find(".post-comment").text(cloneItem.find(".post-comment").text());
                matchItem.find(".post-title").text(cloneItem.find(".post-title").text());
                matchItem.find(".post-info").text(cloneItem.find(".post-info").text());
                matchItem.find(".description").text(cloneItem.find("p").text());
                $(this).attr("src", cloneAvatar.attr("src"));
                $(this).attr("alt", cloneAvatar.attr("alt"));
                $(this).attr("title", cloneAvatar.attr("title"));
            });
            $(boundary + " .post-item-list li:first-child").addClass("head");
        });
    </script>
    <h2>
       <a class="cate-title" href='<%= SeoUrl %>'><%= Title %></a>
       <a class="rss" href="#"></a>
    </h2>
    <asp:Image ID="imgMain"  CssClass="post-avatar left" runat="server" />
    <ul class="avatar-thumb-list right">
        <asp:Repeater runat="server" ID="rptSubAvatar" 
           >
            <ItemTemplate>
                <li>
                    <img id="imgSub" src='<%#Eval("Avatar") %>' alt='<%#Eval("Title") %>' title='<%#Eval("Title") %>' class='item-<%#Container.ItemIndex+2%>' />
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="clear"></div>
    <div class="active-post-item">
        <asp:Repeater runat="server" ID="rptFirstItem" 
            onitemdatabound="rptFirstItem_ItemDataBound">
            <ItemTemplate>
                <% if (NoComments){ %><span class="post-comment"><%# Eval("Comments") %></span><% } %>
                <a href='<%#Eval("SeoUrl") %>' class="post-title"><%#Eval("Title") %></a>        
                <span class="post-info"><%# Eval("CreatedOn", "{0:dddd, dd/MM/yyyy}") %></span>
                <p><%# Eval("Description") %></p>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <ul class="post-item-list other">
        <asp:Repeater ID="rptOtherItems" runat="server" >
            <ItemTemplate>
                <li class='item-<%#Container.ItemIndex+2%>'>
                    <% if (NoComments){ %><span class="post-comment"><%# Eval("Comments") %></span><% } %>
                    <% if (NoComments){ %><div class="wrap"><% } %>
                        <a class="post-title inline" href='<%#Eval("SeoUrl") %>'><%# Eval("Title") %></a> -
                        <span class="post-info">
                            <%# Eval("CreatedOn", "{0:dddd, dd/MM/yyyy}") %>
                        </span>
                    <% if (NoComments){ %></div><% } %>
                    <span class="description"><%# Eval("Description") %></span>
                </li>
            </ItemTemplate>
        </asp:Repeater>        
    </ul>
    <div style="display:none">
        <asp:HiddenField runat="server" ID="hid_Avatar" Value="" />
    </div>
</asp:Panel>