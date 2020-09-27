<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Bookstore._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.0/css/bulma.min.css"/>
    <link rel="stylesheet" href="css/bookstore_stylesheet.css"/>

    <title>Bookstore</title>

</head>
<body>

    <!--Hero-->
    <section class="hero is-primary">
        <div class="hero-body">
        <div class="container">
            <h1 class="title">
            Welcome To Dr. Jenkin's Backyard Bookstore Vista 
            </h1>
            <h2 class="subtitle">
            ...Where Books Are!
            </h2>
        </div>
        </div>
    </section>

    <!--Navbar-->
    <nav class="navbar" role="navigation" aria-label="main navigation">
          <div id="navbarBasicExample" class="navbar-menu">
            <div class="navbar-start">
              <a class="navbar-item is-centered">
                Book Search
              </a>

              <a class="navbar-item is-centered">
                Management Report
              </a>
            </div>
          </div>
        </nav>


    <form id="bookForm" runat="server">
        <div class="infoSection">

            <div class="columns">
                <div class="column">
                    <!--Student ID-->
                    <asp:Label ID="lblID" runat="server" Text="Student ID"></asp:Label>
                    <asp:TextBox id="txtID" runat="server" class="input is-rounded" type="text" Placeholder="Student ID"></asp:TextBox>
            
                    <!--Name-->
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox id="txtName" runat="server" class="input is-rounded" type="text" Placeholder="Name"></asp:TextBox>
                </div>
                <div class="column">
                    <!--Address-->
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox id="txtAddress" runat="server" class="input is-rounded" type="text" Placeholder="Address"></asp:TextBox>

                    <!--Phone Number-->
                    <asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label>
                    <asp:TextBox id="txtPhone" runat="server" class="input is-rounded" type="text" Placeholder="Phone number"></asp:TextBox>
                </div>
            </div>

            <!--Campus-->
            <asp:Label class="campusList" runat="server" Text="Campus"></asp:Label><br />
            <asp:DropDownList  class="campusList" name="campusList" runat="server">
                <asp:ListItem  value="main">Main </asp:ListItem>
                <asp:ListItem  value="TUCC">TUCC </asp:ListItem>
                <asp:ListItem  value="ambler">Ambler </asp:ListItem>
                <asp:ListItem  value="tokyo">Tokyo </asp:ListItem>
                <asp:ListItem  value="rome">Rome </asp:ListItem>
            </asp:DropDownList>

        </div>
        <asp:GridView ID="gvOrderBooks" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
    </form>
</body>
</html>
