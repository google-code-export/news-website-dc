<%@ Control Language="C#" ClassName="ProfileMessageBox" %>

<script type="text/javascript">
    $(function () {
        $("#message_box").dialog({
            autoOpen: false,
            resizable: false,
            modal: true,
            width: 650
        });
    });

    function checkValidation() {
        return $("#message_box").validationEngine('validate');
    }
</script>

<div id="#message_box" title="Gởi tin nhắn đến: Ham hố lãng tử">
    <ul class="ui-form ui-widget">
        <li style="border-bottom:1px dotted #333;">
            Vui lòng nhập <b>Tiếng Việt Unicode có dấu</b>
        </li><li></li>
        <li>
            <asp:Label AssociatedControlID="txtTitle" Text="Tiêu đề:" Width="100" runat="server" />
            <asp:TextBox ID="txtTitle" Width="534" CssClass="validate[required]" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtContent" Text="Nội dung nhắn:" Width="100" runat="server" />
            <asp:TextBox ID="txtContent" Width="534" CssClass="validate[required]" runat="server"
                TextMode="MultiLine" Rows="8" MaxLength="300" />
        </li>
        <li class="commands">            
            <asp:LinkButton ID="btnSendMessage" Text="Gởi đi" CssClass="button-send right" runat="server"
                OnClientClick="return checkValidation();" style="margin:0" />
            <div class="clear"></div>
        </li>
    </ul>
</div>