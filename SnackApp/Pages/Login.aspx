<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SnackApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SnackAPP Login</title>
    <style>
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Login</h1>
        <hr />
        <div class="grid-container">
            <asp:TextBox runat="server" ID="txt_username" placeholder="Username"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="txt_password" placeholder="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click"/>
            <br />
            <div>
                Not registered? <a href="Register.aspx">Create an account</a>
            </div>
        </div>
    </form>
</body>
</html>
