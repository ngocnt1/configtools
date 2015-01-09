<%@ Page Language="c#" CodeBehind="FriendlyUrlReindexing.aspx.cs" AutoEventWireup="False" Inherits="Di.Plugins.Plugins.FriendlyUrlReindexing" Title="" %>

<%@ Import Namespace="EPiServer" %>
<%@ Import Namespace="EPiServer.Configuration" %>
<%@ Import Namespace="Bonnier.UrlRewriting.PlugIns" %>
<%@ Register TagPrefix="episerver" Assembly="EPiServer" Namespace="EPiServer.Web.WebControls" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js" type="text/javascript"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="/ui/Shell/ClientResources/ShellCore.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script src="/util/javascript/episerverscriptmanager.js" type="text/javascript"></script>
        <script src="/util/javascript/system.js" type="text/javascript"></script>
        <script src="/util/javascript/dialog.js" type="text/javascript"></script>
        <script src="/util/javascript/system.aspx" type="text/javascript"></script>
        <div style="padding: 15px">
            <h3>FriendlyUrl Reindexing</h3>
            <hr />
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="progress">
                        <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 45%">
                            <span class="sr-only">Processing...</span>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnRefresh" />
                    <asp:PostBackTrigger ControlID="btnReindex" />
                    <asp:PostBackTrigger ControlID="btnStop" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="lbWarning" runat="server" Text="" CssClass="alert alert-block alert-error" Visible="false"></asp:Label>
                    <div class="panel panel-default">
                        <div class="panel-heading">Status</div>
                        <div class="panel-body">
                            <table class="table table-bordered">
                                <tr>
                                    <td width="250px">Server Url
                                    </td>
                                    <td>
                                        <asp:Label ID="lblServerUrl" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Status
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStatus" runat="server" CssClass="label label-default"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Indexed pages
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIndexedPages" runat="server" CssClass="label label-default"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Indexed Urls
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIndexedFurls" runat="server" CssClass="label label-default"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Batch status
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="ltlReindexStatus" CssClass="label label-default"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Url status
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltFriendlyUrlStatus"></asp:Literal></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">Settings</div>
                        <div class="panel-body">
                            <table class="table table-bordered">
                                <tr>
                                    <td width="250px">Root
                                    </td>
                                    <td>
                                        <episerver:InputPageReference runat="Server" id="iprPageRoot" DisableCurrentPageOption="true" style="display: inline;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Takes count per request from Solr</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="tbTakesCountFromSolr"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Batch size 
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txbBatchSize"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>From batch index 
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txbFromBatchIndex"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>To batch index 
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txbToBatchIndex"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Stop on exception 
                                    </td>
                                    <td>
                                        <asp:CheckBox runat="server" ID="chbStopOnException"></asp:CheckBox></td>
                                </tr>
                                <tr>
                                    <td>Regeneration type </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlRegenerationType"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnReindex" runat="server" Text="Reindex" CssClass="btn btn-danger" OnClientClick="return confirm('Do you want to run the reindexing now?')" OnClick="btnReindex_Click" />
                                        &nbsp;<asp:Button ID="btnStop" runat="server" Text="Stop" CssClass="btn btn-warning" OnClick="btnStop_Click" OnClientClick="return confirm('Do you want to run the stop now?')" />
                                        &nbsp;<asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-success" OnClick="btnRefresh_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="3000">
                    </asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>

</body>
</html>
