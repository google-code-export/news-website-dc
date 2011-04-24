<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RandomProfileBox.ascx.cs" Inherits="NewsVn.Web.Modules.RandomProfileBox" %>

<script type="text/javascript">
    $(function () {
        $(".random-profiles .clear:last-child").removeClass("profile-sep");
    });
</script>

<div class="side-part random-profiles portlet">
    <h2>Hồ sơ ngẫu nhiên</h2>
    <asp:Repeater runat="server" ID="rptRandomUserProfile">
        <ItemTemplate>
            <div class='profile-box <%#Eval("layoutPosition") %>'>
		        <asp:Image ID="Image1" ImageUrl='<%#Eval("Avatar") %>' AlternateText='<%#Eval("Nickname") %>' Width="135px" Height="135px" runat="server" />
		        <p>
			        <a href="../profile.aspx">Xem hồ sơ</a><br/>
			        <%#Eval("Name") %><br/>
			        <%#Eval("Gender") %>/<%#Eval("Age") %>
		        </p>
	        </div>
        </ItemTemplate>
    </asp:Repeater>
	<div class="profile-sep clear"></div>
</div>