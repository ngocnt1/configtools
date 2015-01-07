<%@ Page Language="c#" CodeBehind="FriendlyUrlPlugin.aspx.cs" AutoEventWireup="False" Inherits="Di.Plugins.Plugins.FriendlyUrlPlugin" Title="Friendly Find" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/2.3.0/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 15px">
            <h3>FriendlyUrl Finding</h3>
            <hr />
            <asp:Label ID="lbWarning" runat="server" Text="" CssClass="alert alert-block alert-error" Visible="false"></asp:Label>
            <h4>Domain Url
            </h4>
             <asp:TextBox ID="txtDomain" runat="server"  Width="733px" Text="http://di-www.niteco.se"></asp:TextBox>
            <h4>IDs
            </h4>

            <asp:TextBox ID="txtDIs" runat="server" Height="343px" TextMode="MultiLine" Width="733px"></asp:TextBox>
            <p />
            <asp:Button ID="btnGenLinks" runat="server" Text="Generate" CssClass="btn btn-success" OnClick="btnGenLinks_Click" />
            <p>
                <asp:TextBox ID="txtResult" runat="server" Height="343px" TextMode="MultiLine" Width="733px" ReadOnly="true"></asp:TextBox>
            </p>



        </div>
    </form>

</body>
</html>
