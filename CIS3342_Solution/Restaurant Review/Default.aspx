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
                <asp:Button ID="btnAddRestaurant" class="button" runat="server" Text="Add Restaurant" onclick="btnAddRestaurant_Clicked"/> 
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

        <!--New Restaurant Modal -->
            <div class="modal" id="restaurantModal" runat="server">
              <div class="modal-background"></div>
                  <div class="modal-card">
                    <header class="modal-card-head">
                      <p class="modal-card-title" id="restaurantModalTitle" runat="server"></p>
                    </header>
                    <section class="modal-card-body">
                        <asp:Label ID="lblReviewHeader" runat="server" Text="Add A New Restaurant"></asp:Label>
                        <br />  
                        <asp:Label ID="lblRestaurantName" runat="server" Text="Restaurant Name"></asp:Label>
                        <p><asp:TextBox runat="server" id="restaurantName_input" class="input is-rounded is-one-third is-centered" type="text"></asp:TextBox></p>
                        <br />
                        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                        <p><asp:TextBox runat="server" id="description_input" class="input is-rounded is-one-third is-centered" type="text"></asp:TextBox></p>
                        <br />
                        <asp:Label ID="lblImage" runat="server" Text="Image URL"></asp:Label>
                        <p><asp:TextBox runat="server" id="image_input" class="input is-rounded is-one-third is-centered" type="text"></asp:TextBox></p>
                        <br /><br />
                        <asp:Label ID="lblFoodQuality" runat="server" Text="Food Quality"></asp:Label>
                        <asp:DropDownList ID="ddlFoodQuality" runat="server">
                            <asp:ListItem  value="1">1</asp:ListItem>
                            <asp:ListItem  value="2">2</asp:ListItem>
                            <asp:ListItem  value="3">3</asp:ListItem>
                            <asp:ListItem  value="4">4</asp:ListItem>
                            <asp:ListItem  value="5">5</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblAtmosphereQuality" runat="server" Text="Atmosphere"></asp:Label>
                        <asp:DropDownList ID="ddlAtmosphereQuality" runat="server">
                            <asp:ListItem  value="1">1</asp:ListItem>
                            <asp:ListItem  value="2">2</asp:ListItem>
                            <asp:ListItem  value="3">3</asp:ListItem>
                            <asp:ListItem  value="4">4</asp:ListItem>
                            <asp:ListItem  value="5">5</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblServiceQuality" runat="server" Text="Service"></asp:Label>
                        <asp:DropDownList ID="ddlServiceQuality" runat="server">
                            <asp:ListItem  value="1">1</asp:ListItem>
                            <asp:ListItem  value="2">2</asp:ListItem>
                            <asp:ListItem  value="3">3</asp:ListItem>
                            <asp:ListItem  value="4">4</asp:ListItem>
                            <asp:ListItem  value="5">5</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblPriceQuality" runat="server" Text="Price (1-cheap, 5-expensive)"></asp:Label>
                        <asp:DropDownList ID="ddlPriceQuality" runat="server">
                            <asp:ListItem  value="1">1</asp:ListItem>
                            <asp:ListItem  value="2">2</asp:ListItem>
                            <asp:ListItem  value="3">3</asp:ListItem>
                            <asp:ListItem  value="4">4</asp:ListItem>
                            <asp:ListItem  value="5">5</asp:ListItem>
                        </asp:DropDownList>
                        <br /><br />
                        <asp:Label ID="lblComments" runat="server" Text="Comments"></asp:Label>
                        <asp:TextBox id="txtComments" runat="server" type="text"></asp:TextBox>
                        <br /><br />
                        <asp:Label ID="lblReviewError" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblReviewSubmitted" class="SuccessSubmitted" runat="server" Text=""></asp:Label>

                    </section>
                    <footer class="modal-card-foot">
                      <asp:Button id="btnReviewSubmit" class="button is-success" onclick="btnReviewSubmit_Clicked" runat="server" Text="Submit"></asp:Button>
                      <asp:Button id="btnReviewCancel" class="button" onclick="btnReviewCancel_Clicked" runat="server" Text="Cancel"></asp:Button>
                    </footer>
                </div>
            </div>

    </body>
</html>
