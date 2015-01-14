<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DagensNyheter.Plugins.RemoveSlaskContent.PagesRemovingTool" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remove Old Sections</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <link href="http://getbootstrap.com/assets/css/docs.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="http://bootstrap-growl.remabledesigns.com/js/bootstrap-growl.min.js"></script>
    <style>
        .tile:after {
            content: "Tool" !important;
        }
    </style>
</head>
<body>

    <div class="bs-example tile">



        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h3>Old articles clean up

            </h3>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <label class="label">
                        <img src="/Images/478.gif" /></label><label class="label label-primary">
                            Processing ...</label>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block" UpdateMode="Always">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnRefresh" />
                    <asp:PostBackTrigger ControlID="btnDelete" />
                    <asp:PostBackTrigger ControlID="btnCancel" />
                </Triggers>
                <ContentTemplate>
                    <script>
                        var msg_delete = '<asp:Literal ID="ltJustDeleted" runat="server" />';
                        if (msg_delete && msg_delete != '') {
                            $.growl({
                                icon: "fa fa-paw",
                                title: " Deleted: ",
                                type: 'pink',
                                message: msg_delete
                            });
                        }

                    </script>
                    <asp:Panel ID="msgPane" runat="server" CssClass="bs-callout bs-callout-warning" Visible="false">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4>
                            <asp:Literal ID="ltMsgTile" runat="server"></asp:Literal></h4>
                        <p>
                            <asp:Literal ID="ltMsgContent" runat="server"></asp:Literal>
                        </p>
                    </asp:Panel>
                    <!-- Button trigger modal -->
                    <div class="form-group">
                        <asp:Button ID="btnLoad" runat="server" Text="Collect data" CssClass="btn btn-primary btn-sm" OnClick="btnLoad_Click" OnClientClick="$(this).hide()" />
                    </div>

                    <asp:Panel ID="pnl" runat="server">
                        <%-- <asp:TreeView ID="tv" runat="server" ShowLines="True">
                </asp:TreeView>--%>

                        <table class="table" style="width: auto">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Item Type</th>
                                    <th>Remaining</th>
                                </tr>
                            </thead>
                            <tbody>                              
                                <tr>
                                    <td>2</td>
                                    <td>Articles</td>
                                    <td>
                                        <asp:Label ID="lbRemainingArticles" runat="server" Text="--" Font-Bold="true"></asp:Label></td>
                                </tr>                              
                            </tbody>
                        </table>
                    </asp:Panel>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="3000">
                    </asp:Timer>

                    <%--  <div class="form-group" style="width: 600px;">
                <div class="input-group">
                   
                    <div class="input-group-addon" >--%>
                    <p>
                        <asp:Label ID="lbSpeed" runat="server" Text=""></asp:Label>
                    </p>
                    <asp:Panel ID="pnlProgress" runat="server" CssClass="progress" Width="400">
                        <%--<div class="progress-bar progress-bar-striped" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%">--%>
                        <div class="progress-bar progress-bar-striped progress-bar-success active" role="progressbar" aria-valuenow="<%=ProcessedPercentage %>" aria-valuemin="0" aria-valuemax="100" style='<%= "color:white;width: "+ProcessedPercentage+"%"%>'>
                            <%: ProcessedPercentage+"%" %>
                        </div>
                        <%--</div>--%>
                    </asp:Panel>
                    <%--</div>
                </div>
            </div>--%>
                    <asp:Panel ID="pnlMaxNumber" runat="server" class="form-group">
                        <label for="txtMaxItemToDelete">Max number of items to delete</label>
                        <asp:TextBox ID="txtMaxItemToDelete" runat="server" CssClass="form-control" Text="100" Style="width: 200px"></asp:TextBox>
                    </asp:Panel>
                    <asp:LinkButton ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" OnClick="btnDelete_Click" OnClientClick="if( confirm('Do you want to delete the selected items and their contents?')){$(this).hide();return true;}else{return false;}" />
                    <asp:Button ID="btnCancel" runat="server" Text="Stop" CssClass="btn btn-warning btn-sm" OnClick="btnCancel_Click" OnClientClick="return confirm('Do you want to cancel the progress ?')" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <%-- <asp:PlaceHolder ID="PlaceHolderRefreshScript" runat="server" Visible="false">
                <script>
                    function refresh() {
                        __doPostBack('btnRefresh', '');
                    }
                    window.setTimeout('refresh()', 2000);
                </script>
            </asp:PlaceHolder>--%>
        </form>
    </div>
</body>
</html>
