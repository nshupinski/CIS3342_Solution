<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Restaurant_Review.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Rusty Spork</title>

        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.1/css/bulma.min.css"/>
        <link rel="stylesheet" href="Style Sheets/Home Stylesheet.css" />

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


        <div class="bg">
            <div class="MainSection">
                <div class="imageHeader">
                     <p id="title">Rusty Spork</p>
                    <img src="images/cleanHeaderPic.jpg" />
                </div>
            </div>


            <form id="form1" runat="server">
                <div class="gvBackground">
                    <asp:GridView ID="gvRestaurants" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BorderColor="Black" BorderStyle="Outset" BorderWidth="0.25em" CellPadding="3" OnSelectedIndexChanged="gvRestaurants_SelectedIndexChanged">
                        <Columns>
                            <asp:ImageField DataImageUrlField="Image" HeaderText="Image">
                                <ControlStyle Height="100px" Width="150px" />
                            </asp:ImageField>
                            <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="Description" >
                            <ControlStyle Width="2px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Category" HeaderText="Category" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:Button ID="viewRestaurant" runat="server" Text="View" onclick="restaurantView_Clicked"/>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </form>
        </div>

    </body>
</html>
