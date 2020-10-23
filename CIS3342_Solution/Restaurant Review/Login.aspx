<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Restaurant_Review.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rusty Sport: Log In</title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.1/css/bulma.min.css"/>
    <link rel="stylesheet" href="Style Sheets/Login_Stylesheet.css" />

</head>
<body>
    <div class="bg">
        <form id="loginForm" runat="server">
            <div class="card">
              <header class="card-header">
                <p class="card-header-title is-centered">
                  Please Sign In
                </p>
              </header>
              <div class="card-content">
                <div class="content">
                    <asp:Label ID="lblErrors" runat="server" Text=""></asp:Label>
                  <p><asp:TextBox runat="server" id="username_input" class="input is-rounded is-one-third is-centered" type="text" Placeholder="Username"></asp:TextBox></p>
                  <p><asp:RadioButton id="rbtn_usertypeReviewer" Text="Reviewer" GroupName="usertype" runat="server" /></p>
                  <p><asp:RadioButton id="rbtn_usertypeRepresentative" Text="Representative" GroupName="usertype" runat="server" /></p>
                </div>
              </div>
              <footer class="card-footer">
                <asp:Button ID="btnSubmit_login" class="card-footer-item" runat="server" Text="Login" onclick="btnLogin_Clicked"></asp:Button>
                <asp:Button ID="btnSubmit_createAccount" class="card-footer-item" runat="server" type="submit" Text="Create Account" onclick="btnCreateAccount_Clicked"></asp:Button>
              </footer>
                <footer class="card-footer">
                <a href="Default.aspx" class="card-footer-item">Just Visiting</a>
              </footer>
            </div>
        </form>
    </div>
</body>
</html>
