<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SnackApp.Pages.Register" %>

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
    <style>
        .register-container{
            padding: 10em;
            align-items: center;
            margin: 0;
        }
    </style>
    <title>SnackAPP</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
            <div class="row">
                <div class="col s12 m8 l4 offset-m2 offset-l4">
                    <div class="card">
                        <div class="card-action teal lighten-1 white-text">
                            <h3>Register</h3>
                        </div>
                        <div class="card-content">
                            <div class="form-Field">
                                <asp:TextBox runat="server" ID="txt_username" placeholder="Username"></asp:TextBox>
                            </div>
                            <br />
                            <div class="form-Field">
                                <asp:TextBox runat="server" ID="txt_email" placeholder="E-Mail"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="validateEmail"
                                    runat="server" ErrorMessage="Invalid email."
                                    ControlToValidate="txt_email"
                                    ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                            </div>
                            <br />
                            <div class="form-Field">
                                <asp:TextBox runat="server" ID="txt_password" placeholder="Password" type="password"></asp:TextBox>
                            </div>
                            <br />
                            <div class="form-Field">
                                <asp:TextBox runat="server" ID="txt_confirmPassword" placeholder="Confirm Password" type="password"></asp:TextBox>
                            </div>
                            <br />
                            <div class="form-Field">
                                <asp:Button class="btn-large waves-effect waves-dark" style="width:100%;" ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click" />
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0-beta/js/materialize.min.js"></script>
</body>
</html>
