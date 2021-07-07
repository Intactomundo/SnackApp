<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegVerification.aspx.cs" Inherits="SnackApp.Pages.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SnackAPP Verification</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <!--Import Google Icon Font-->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/css/materialize.min.css" />
    <style>
        .centered{
            margin: auto;
            width: 100%;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav>
                <div class="nav-wrapper">
                    <a id="logo" runat="server" href="Login.aspx" class="brand-logo center">SnackAPP</a>
                </div>
            </nav>
        </div>
        <div class="centered">
            <h3>Verification</h3>
            <div>
                You have successfully registered yourself.
                Access to the Website will be provided by an Admin withing one bussiness day.
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
