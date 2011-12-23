<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailedAdPostItem.ascx.cs" Inherits="NewsVn.Web.Modules.DetailedAdPostItem" %>

<div class="portlet detailed-post">
    <h1><%=AdsTitle %></h1>
    <div class="info-bar head">
        <div class="left">
            <span class="post-info">
                <%= string.Format("{0:dddd, dd/MM/yyyy}", CreatedOn)%> |
                 Khu vực: <b><%=NewsVn.Web.Utils.clsCommon.getLocationName(Location)%></b> 
                | Liên hệ:<b> <%=CreateBy%></b>
            </span>
        </div>
        <div class="right">
            <a href="#" title="Chia sẽ trên Facebook">
                <asp:Image ID="Image1" ImageUrl="~/images/icons/facebook.png" runat="server" />
            </a>
            <a href="#" title="Chia sẽ trên Twitter">
                <asp:Image ID="Image2" ImageUrl="~/images/icons/twitter.png" runat="server" />
            </a>
        </div>
        <div class="clear"></div>
    </div>
    <div class="content">
   <table width="100%">
    <tr>
    <td style="vertical-align:top">
    <p >
            <%=AdsContent %>
        </p>
    </td>
    
    <td style="vertical-align:top">
    <img src='<%=Avatar %>' alt='<%=AdsTitle %>' width="120px" height="120px" style="overflow:hidden; margin: 10px 10px 10px 5px; border:2px solid #ffb4ae" />
    </td>
    </tr>
   </table>
    </div>
    <div class="info-bar tail">
        <div class="left">
            <span class="post-info">
                <%= string.Format("{0:dddd, dd/MM/yyyy}", CreatedOn)%> |
                 Khu vực: <b><%=NewsVn.Web.Utils.clsCommon.getLocationName(Location)%></b> 
                | Liên hệ:<b> <%=CreateBy%></b>
            </span>
        </div>
        <div class="right">
            <a href="#" title="Chia sẽ trên Facebook">
                <asp:Image ID="Image3" ImageUrl="~/images/icons/facebook.png" runat="server" />
            </a>
            <a href="#" title="Chia sẽ trên Twitter">
                <asp:Image ID="Image4" ImageUrl="~/images/icons/twitter.png" runat="server" />
            </a>
        </div>
        <div class="clear"></div>
    </div>
</div>