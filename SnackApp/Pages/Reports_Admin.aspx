<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports_Admin.aspx.cs" Inherits="SnackApp.Pages.Reports_Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SnackAPP Admin</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <!--Import Google Icon Font-->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/css/materialize.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav>
                <div class="nav-wrapper">
                    <a id="logo" runat="server" href="Main.aspx" class="brand-logo center">SnackAPP</a>
                    <ul id="nav-mobile" class="right hide-on-med-and-down">
                        <li><a id="nav_users" href="Main_Admin.aspx" runat="server">Users</a></li>
                        <li><a id="nav_items" href="Items_Admin.aspx" runat="server">Items</a></li>
                        <li class="active"><a id="A1" href="Reports_Admin.aspx" runat="server">Reports</a></li>
                    </ul>
                </div>
            </nav>
        </div>
        <div>
            <asp:GridView ID="tbl_reports" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="user_name" HeaderText="Username" />
                    <asp:BoundField DataField="item_name" HeaderText="Snack" />
                    <asp:BoundField DataField="numberOfItems" HeaderText="Number of Snack Consumed" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="fixed-action-btn">
            <a class="btn-floating btn-large red">
                <i class="material-icons">apps</i>
            </a>
            <ul>
                <li>
                    <button class="btn-floating green modal-trigger" data-target="modalReportSingleUser"><i class="material-icons">person</i></button></li>
                <li>
                    <button class="btn-floating yellow darken-1 modal-trigger" data-target="modalReportAllUsers"><i class="material-icons">group</i></button></li>
            </ul>
        </div>
        <div id="modalReportSingleUser" class="modal">
            <div class="modal-content">
                <div>
                    <h3>Single User Report</h3>
                    <hr />
                    <div>
                        User for the Report
                    </div>
                    <asp:TextBox runat="server" ID="txt_username" placeholder="Username"></asp:TextBox>
                    <div class="row">
                        <div class="col s12">
                            Type of Output File
                        </div>
                        <div class="col s6">
                            <label>
                                <input runat="server" name="rd_groupOutputType" id="rd_singleReportUser_outputTypePDF" type="radio" />
                                <span>PDF File</span>
                            </label>
                        </div>
                        <div class="col s6">
                            <label>
                                <input runat="server" name="rd_groupOutputType" id="rd_singleReportUser_outputTypeTXT" type="radio" />
                                <span>Text File</span>
                            </label>
                        </div>
                    </div>
                    <hr />
                    <div class="modal-footer">
                        <a href="#!" class="modal-close waves-effect waves-green btn-flat">Cancel</a>
                        <asp:Button runat="server" ID="btn_createSingleUserReport" CssClass="modal-close waves-green btn-flat" Text="Create Report" OnClick="btn_createSingleUserReport_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div id="modalReportAllUsers" class="modal">
            <div class="modal-content">
                <div>
                    <h3>Total User Report</h3>
                    <hr />
                    <div class="row">
                        <div class="col s12">
                            Type of Output File
                        </div>
                        <div class="col s6">
                            <label>
                                <input runat="server" name="rd_groupOutputType" id="rd_totalUserReport_outputTypePDF" type="radio" />
                                <span>PDF File</span>
                            </label>
                        </div>
                        <div class="col s6">
                            <label>
                                <input runat="server" name="rd_groupOutputType" id="rd_totalUserReport_outputTypeTXT" type="radio" />
                                <span>Text File</span>
                            </label>
                        </div>
                    </div>
                    <hr />
                    <div class="modal-footer">
                        <a href="#!" class="modal-close waves-effect waves-green btn-flat">Cancel</a>
                        <asp:Button runat="server" ID="btn_createTotalUserReport" CssClass="modal-close waves-green btn-flat" Text="Create Report" OnClick="btn_createTotalUserReport_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/js/materialize.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.sidenav').sidenav();
            $('.fixed-action-btn').floatingActionButton();
            $('.modal').modal();
        });
    </script>
</body>
</html>
