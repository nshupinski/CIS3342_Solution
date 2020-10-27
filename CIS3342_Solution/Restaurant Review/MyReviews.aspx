<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyReviews.aspx.cs" Inherits="Restaurant_Review.MyReviews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Reviews</title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.1/css/bulma.min.css"/>
    <link rel="stylesheet" href="Style Sheets/MyReviews_Stylesheet.css" />

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
                  <a id="btnMyReviews" runat="server" href="MyReviews.aspx" style="visibility: hidden"> My Reviews</a>
            </div>
            <div class="navbar-end">
              <a class="navbar-item is-centered" onclick="logOut()" href="Login.aspx" runat="server">      
                  Log Out
              </a>
            </div>
          </div>
        </nav>

    <form id="form1" runat="server">
        <div class="gvBackground">
            <asp:GridView ID="gvMyReviews" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant" />
                    <asp:BoundField DataField="FoodQuality" HeaderText="Food Rating" />
                    <asp:BoundField DataField="Service" HeaderText="Service Rating" />
                    <asp:BoundField DataField="Atmosphere" HeaderText="Atmosphere Rating" />
                    <asp:BoundField DataField="PriceRating" HeaderText="Price Rating" />
                    <asp:BoundField DataField="Comments" HeaderText="Comments" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
