<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Items_Admin.aspx.cs" Inherits="SnackApp.Pages.Items_Admin" %>

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
                        <li class="active"><a id="nav_items" href="Items_Admin.aspx" runat="server">Items</a></li>
                    </ul>
                </div>
            </nav>
        </div>
        <div>
            <asp:GridView ID="tbl_items" runat="server" OnRowDeleting="tbl_items_RowDeleting" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="itemID" HeaderText="SnackID" />
                    <asp:ImageField DataImageUrlField="item_path" AlternateText="Item Image" NullDisplayText="No image on file." HeaderText="Snack Image" ReadOnly="true"></asp:ImageField>
                    <asp:BoundField DataField="item_name" HeaderText="Snack" />
                    <asp:ButtonField CommandName="Delete" HeaderText="Delete Snack" ShowHeader="true" Text="Delete" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="fixed-action-btn">
            <a class="btn-floating btn-large red">
                <i class="material-icons">apps</i>
            </a>
            <ul>
                <li><button class="btn-floating green modal-trigger" data-target="modalAdd"><i class="material-icons">add</i></button></li>
                <li><button class="btn-floating yellow darken-1 modal-trigger"  data-target="modalEdit"><i class="material-icons">edit</i></button></li>
                <li><button class="btn-floating blue modal-trigger"  data-targer="modalReport"><i class="material-icons">note</i></button></li>
            </ul>
        </div>
        <div id="modalAdd" class="modal">
            <div class="modal-content">
                <h3>Add new Item</h3>
                <hr />
                <asp:TextBox runat="server" ID="txt_itemName" placeholder="Item Name"></asp:TextBox>
                <div>Item Image</div>
                <asp:FileUpload runat="server" ID="fileUploader" />
                <hr />
                <div class="modal-footer">
                    <a href="#!" class="modal-close waves-effect waves-green btn-flat">Cancel</a>
                    <asp:Button runat="server" ID="btn_addItem" CssClass="modal-close waves-effect waves-green btn-flat" Text="Add Item" OnClick="btn_addItem_Click"/>
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
