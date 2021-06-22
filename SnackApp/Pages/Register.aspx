<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SnackApp.Pages.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Register</h1>
            <hr />
            <asp:TextBox runat="server" ID="txt_username" placeholder="Username"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="txt_email" placeholder="E-Mail"></asp:TextBox>
            <asp:RegularExpressionValidator ID="validateEmail"
                runat="server" ErrorMessage="Invalid email."
                ControlToValidate="txt_email"
                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
            <br />
            <asp:TextBox runat="server" ID="txt_password" placeholder="Password"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="txt_confirmPassword" placeholder="Confirm Password"></asp:TextBox>
            <br />
            <asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click" />
        </div>
    </form>
</body>
</html>
