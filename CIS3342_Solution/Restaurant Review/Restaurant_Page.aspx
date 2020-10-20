<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Restaurant_Page.aspx.cs" Inherits="Restaurant_Review.Restaurant_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Restaurant View</title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.1/css/bulma.min.css"/>
    <link rel="stylesheet" href="Style Sheets/RestaurantPage_Stylesheet.css" />

</head>
<body>
    <!--Navbar-->
    <nav class="navbar is-danger" role="navigation" aria-label="main navigation">
          <div class="navbar-menu">
              <div class="navbar-brand">
                <a class="navbar-item" href="Default.aspx">
                  <p style ="font-family:'Times New Roman', Times, serif; border-style: solid; padding: 5px;">Rusty Spork</p>
                </a>
                  <p id="username_display" runat="server"></p>
            </div>
            <div class="navbar-end">
              <a class="navbar-item is-centered" onclick="logOut()" href="Login.aspx" runat="server">      
                  Log Out
              </a>
            </div>
          </div>
        </nav>

   <div id="mainSection">
        <div class="card">
            <div class="card-image">
            <figure class="image is-4by3" >
                <img id="restaurantImage" src="" alt="Restaurant" runat="server"/>
            </figure>
            </div>
            <div id="restaurantContent">
                <div class="card-content">
                    <div class="media">
                        <div class="media-content">
                        <p id="title" class="title is-4" runat="server"></p>
                        <p id="rep" class="subtitle is-6" runat="server">Representative: </p>
                    </div>
                </div>
                <div class="content" id="description" runat="server">
                  Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                  Phasellus nec iaculis mauris.
                </div>
              <br />
            </div>
          </div>
        </div>
    </div>

    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvReviews" runat="server" AutoGenerateColumns="False" CellPadding="1" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="ReviewerName" HeaderText="Reviewer" />
                    <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant" />
                    <asp:BoundField DataField="Comments" HeaderText="Comments" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
