<%@ Page Language="c#" CodeBehind="SolrReindexing.aspx.cs" AutoEventWireup="False" Inherits="Di.Plugins.Plugins.SolrReindexing" Title="SolrCore Reindexing" %>

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
            <h3>SolrCore Reindexing</h3>
            <hr />
            <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnOptimizeIndex" />
                    <asp:AsyncPostBackTrigger ControlID="btnReIndex" />
                    <asp:AsyncPostBackTrigger ControlID="btnStopAction" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="lbWarning" runat="server" Text="" CssClass="alert alert-block alert-error" Visible="false"></asp:Label>
                    <div class="epi-contentContainer epi-padding">
                        <div class="epi-contentArea">
                            <p class="EP-systemInfo">
                                Administrate the SolrCore index
                            </p>
                        </div>

                        <div class="epi-formArea">
                            <asp:Panel runat="server" ID="panelStatus" CssClass="panel panel-default">
                                <div class="panel-heading">Status</div>
                                <div class="panel-body">
                                    <table class="table table-bordered">
                                        <tr>
                                            <td width="200px">Index server
                                            </td>
                                            <td>
                                                <asp:Label ID="lblServerUrl" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Indices (total/pages)
                                            </td>
                                            <td>
                                                <asp:Label ID="lblIndicesCount" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Status
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="ltlWorkingStatus"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Batch status
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltAdditionalWorkingStatus"></asp:Literal></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:Panel ID="pnlProgress" runat="server" CssClass="progress" Width="400">
                                                    <%--<div class="progress-bar progress-bar-striped" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%">--%>
                                                    <div class="progress-bar progress-bar-striped progress-bar-success active" role="progressbar" aria-valuenow="<%=ProcessedPercentage %>" aria-valuemin="0" aria-valuemax="100" style='<%= "color:white;width: "+ProcessedPercentage+"%"%>'>
                                                        <%: ProcessedPercentage+"%" %>
                                                    </div>
                                                    <%--</div>--%>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="epi-buttonDefault">
                                        <asp:PlaceHolder ID="phBtnEnable" runat="server">
                                            <asp:Button runat="server" ID="btnEnable" Text="Enable" OnClick="BtnEnable_Click" />
                                        </asp:PlaceHolder>

                                        <asp:PlaceHolder ID="phBtnDisable" runat="server">
                                            <asp:Button runat="server" ID="btnDisable" Text="Disable" OnClick="BtnDisable_Click" />
                                        </asp:PlaceHolder>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                        <asp:Panel runat="server" ID="panelSettings" CssClass="panel panel-default">
                            <div class="panel-heading">Settings</div>
                            <div class="panel-body">
                                <div>
                                    <table class="table table-bordered">
                                        <tr>
                                            <td width="200px">Indexing root
                                            </td>
                                            <td>
                                                <episerver:inputpagereference runat="Server" id="iprPageRoot" DisableCurrentPageOption="true" style="display: inline;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Catalogs
                                            </td>
                                            <td>
                                                <asp:CheckBoxList runat="server" ID="cblCatalogs" RepeatLayout="UnorderedList" CssClass="list-unstyled" />
                                                <br />
                                                <button type="button" onclick="$('input[name*=cblCatalogs]').attr('checked', false);">Uncheck All</button><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Takes count per request from Solr
                                            </td>
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
                                            <td>Commit after each batch
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chbCommitAfterEachBatch"></asp:CheckBox></td>
                                        </tr>
                                        <tr>
                                            <td>Stop on exception
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chbStopOnException"></asp:CheckBox></td>
                                        </tr>

                                    </table>

                                </div>
                            </div>
                        </asp:Panel>
                        <div>
                            <asp:Button runat="server" ID="btnReIndex" OnClick="BtnReIndex_Click" Text="Reindex" OnClientClick="return confirm('Are you sure that you want to reindex all data?')" />
                            <asp:Button runat="server" ID="btnClearIndex" OnClick="BtnClearIndex_Click" Text="Clear index" OnClientClick="return confirm('Are you sure that you want to clear all indexed data?')" />
                            <asp:Button runat="server" ID="btnOptimizeIndex" OnClick="BtnOptimizeIndex_Click" Text="Optimize index" />
                            <asp:Button runat="server" ID="btnCommitIndex" OnClick="BtnCommitIndex_Click" Text="Commit index" />
                            <asp:Button runat="server" ID="btnStopAction" OnClick="BtnStopAction_Click" Text="Stop" />
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
