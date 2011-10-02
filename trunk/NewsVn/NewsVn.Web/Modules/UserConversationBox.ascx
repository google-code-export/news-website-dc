<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserConversationBox.ascx.cs" Inherits="NewsVn.Web.Modules.UserConversationBox" %>

<div class="side-part portlet">
    <h2>Thông tin trao đổi</h2>
    <asp:LoginView ID="lgConversation" runat="server">
        <AnonymousTemplate>
            Vui lòng
            <%--<asp:HyperLink ID="HyperLink1" NavigateUrl='<%= HostName+ "tinh-yeu-gia-dinh/tim-ban/dang-nhap.aspx" %>' Text="đăng nhập" runat="server" />--%>
             <a href='<%=HostName + "tai-khoan/dang-nhap.aspx"%>' >Đăng Nhập</a>
            để xem thông tin
        </AnonymousTemplate>
        <LoggedInTemplate>
            <ul class="imagehead-list">
                <asp:ListView ID="lvConversation" runat="server" EnableModelValidation="True" OnDataBound="lvConversation_DataBound"
                    OnPagePropertiesChanged="lvConversation_PagePropertiesChanged">
                    <LayoutTemplate>
                        <asp:Panel ID="itemPlaceHolder" runat="server" />
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:Image ID="Image1" ImageUrl="<%#Eval("SenderAvatar")%>" Width="50" Height="50"
                                runat="server" AlternateText="<%#Eval("SenderNickName")%>" ToolTip="<%#Eval("SenderNickName")%>" />
                            <span class="inline">
                                <%#Eval("Content")%><i>
                                    <%# Eval("UpdatedOn", "({0:dddd, dd/MM/yyyy, HH:mm})" ) %></i> </span>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </ul>
            <asp:Panel ID="pnPagerConversationContainer" runat="server" CssClass="data-pager" Style="margin-top: 10px;">                
                <asp:DataPager ID="dpConversation" PagedControlID="lvConversation" PageSize="5" QueryStringField="page"
                    runat="server">
                    <Fields>
                        <asp:NumericPagerField ButtonCount="15" ButtonType="Link" PreviousPageText="&laquo;"
                            NextPageText="&raquo;" />
                    </Fields>
                </asp:DataPager>
            </asp:Panel>                
            </ul>
        </LoggedInTemplate>
    </asp:LoginView>    
</div>