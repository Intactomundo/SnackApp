<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_Admin.aspx.cs" Inherits="SnackApp.Pages.Main_Admin" %>

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
                        <li class="active"><a id="nav_users" href="Main_Admin.aspx" runat="server">Users</a></li>
                        <li><a id="nav_items" href="Items_Admin.aspx" runat="server">Items</a></li>
                    </ul>
                </div>
            </nav>
        </div>
        <div>
            <asp:GridView ID="tbl_users" runat="server" OnRowUpdating="tbl_users_RowUpdating" OnRowDeleting="tbl_users_RowDeleting" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="userID" HeaderText="UserID" />
                    <asp:BoundField DataField="user_name" HeaderText="Username"/>
                    <asp:BoundField DataField="email" HeaderText="E-Mail"/>
                    <asp:BoundField DataField="verified" HeaderText="Verified"/>
                    <asp:ButtonField CommandName="Update" HeaderText="Verify User" ShowHeader="true" Text="Verify" />
                    <asp:ButtonField CommandName="Deleting" HeaderText="Delete User" ShowHeader="true" Text="Delete"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/js/materialize.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.sidenav').sidenav();
        });
    </script>
</body >
</html >
