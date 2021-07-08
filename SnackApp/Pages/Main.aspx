<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SnackApp.Pages.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <!--Import Google Icon Font-->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/css/materialize.min.css" />
    <title>SnackAPP</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav>
                <div class="nav-wrapper">
                    <a id="logo" runat="server" href="Main.aspx" class="brand-logo center">SnackAPP</a>
                    <ul id="nav-mobile" class="right hide-on-med-and-down">
                        <li class="active"><a id="nav_home" href="Main.aspx" runat="server">Home</a></li>
                        <li><a id="ddl_language_selector" runat="server" class="dropdown-trigger" href="#!" data-target="ddl_language">Language</a></li>
                    </ul>
                </div>
            </nav>
        </div>
        <div>
            <asp:GridView ID="tbl_itemsConsumed" runat="server" OnRowUpdating="tbl_itemsConsumed_RowUpdating" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="user_itemsID" HeaderText="Snack Number"/>
                    <asp:ImageField DataImageUrlField="item_path" AlternateText="Snack Image" 
                        NullDisplayText="No image of this item in the Database." ReadOnly="true" HeaderText="Snack"></asp:ImageField>
                    <asp:BoundField DataField="numberOfItems" HeaderText="Number of Snack Consumed"/>
                    <asp:ButtonField CommandName="Update" HeaderText="Add 1 Item Consumed" ShowHeader="true" Text='<i class="material-icons">add</i>'/>
                </Columns>
            </asp:GridView>
        </div>
        <ul id="ddl_language" class="dropdown-content">
            <li>
                <button class="waves-effect waves-light btn" id="btn_languageEnglish" runat="server" onserverclick="btn_languageEnglish_ServerClick">English</button>
                <button class="waves-effect waves-light btn" id="btn_languageGêrman" runat="server" onserverclick="btn_languageGêrman_ServerClick">Deutsch</button>
                <button class="waves-effect waves-light btn" id="btn_languageFrench" runat="server" onserverclick="btn_languageFrench_ServerClick">Français</button>
            </li>
        </ul>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/js/materialize.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.sidenav').sidenav();
            $(".dropdown-trigger").dropdown();
        });
    </script>
</body>
</html>
