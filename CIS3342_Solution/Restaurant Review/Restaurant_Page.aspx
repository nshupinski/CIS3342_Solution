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

            <div id="buttonSection">
               <asp:Button ID="viewRestaurant" class="button" runat="server" Text="Make A Reservation" onclick="btnReservation_Clicked"/> 
            </div>

            <asp:GridView ID="gvReviews" runat="server" AutoGenerateColumns="False" CellPadding="1" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="ReviewerName" HeaderText="Reviewer" />
                    <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant" />
                    <asp:BoundField DataField="Comments" HeaderText="Comments" />
                </Columns>
            </asp:GridView>

            <!--Reservation Modal -->
            <div class="modal" id="reservationModal" runat="server">
              <div class="modal-background"></div>
                  <div class="modal-card">
                    <header class="modal-card-head">
                      <p class="modal-card-title" id="modalTitle" runat="server">Modal title</p>
                    </header>
                    <section class="modal-card-body">
                        <asp:Label ID="lblReservationName" runat="server" Text="Reservation Name"></asp:Label>
                        <p><asp:TextBox runat="server" id="reservationName_input" class="input is-rounded is-one-third is-centered" type="text"></asp:TextBox></p>
                        <br />
                        <asp:Label ID="lblMonth" runat="server" Text="Month"></asp:Label>
                        <asp:Label ID="lblDay" class="modalSpreadOut" runat="server" Text="Day"></asp:Label>
                        <asp:Label ID="lblTime" class="modalSpreadOut" runat="server" Text="Time (ex. 7:15)"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlDateMonth" runat="server">
                            <asp:ListItem  value="1">1 </asp:ListItem>
                            <asp:ListItem  value="2">2 </asp:ListItem>
                            <asp:ListItem  value="3">3 </asp:ListItem>
                            <asp:ListItem  value="4">4 </asp:ListItem>
                            <asp:ListItem  value="5">5 </asp:ListItem>
                            <asp:ListItem  value="6">6 </asp:ListItem>
                            <asp:ListItem  value="7">7 </asp:ListItem>
                            <asp:ListItem  value="8">8 </asp:ListItem>
                            <asp:ListItem  value="9">9 </asp:ListItem>
                            <asp:ListItem  value="10">10 </asp:ListItem>
                            <asp:ListItem  value="11">11 </asp:ListItem>
                            <asp:ListItem  value="12">12 </asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlDateDay" class="modalSpreadOut" runat="server">
                            <asp:ListItem  value="1">1 </asp:ListItem>
                            <asp:ListItem  value="2">2 </asp:ListItem>
                            <asp:ListItem  value="3">3 </asp:ListItem>
                            <asp:ListItem  value="4">4 </asp:ListItem>
                            <asp:ListItem  value="5">5 </asp:ListItem>
                            <asp:ListItem  value="6">6 </asp:ListItem>
                            <asp:ListItem  value="7">7 </asp:ListItem>
                            <asp:ListItem  value="8">8 </asp:ListItem>
                            <asp:ListItem  value="9">9 </asp:ListItem>
                            <asp:ListItem  value="10">10 </asp:ListItem>
                            <asp:ListItem  value="11">11 </asp:ListItem>
                            <asp:ListItem  value="12">12 </asp:ListItem>
                            <asp:ListItem  value="13">13 </asp:ListItem>
                            <asp:ListItem  value="14">14 </asp:ListItem>
                            <asp:ListItem  value="15">15 </asp:ListItem>
                            <asp:ListItem  value="16">16 </asp:ListItem>
                            <asp:ListItem  value="17">17 </asp:ListItem>
                            <asp:ListItem  value="18">18 </asp:ListItem>
                            <asp:ListItem  value="19">19 </asp:ListItem>
                            <asp:ListItem  value="20">20 </asp:ListItem>
                            <asp:ListItem  value="21">21 </asp:ListItem>
                            <asp:ListItem  value="22">22 </asp:ListItem>
                            <asp:ListItem  value="23">23 </asp:ListItem>
                            <asp:ListItem  value="24">24 </asp:ListItem>
                            <asp:ListItem  value="25">25 </asp:ListItem>
                            <asp:ListItem  value="26">26 </asp:ListItem>
                            <asp:ListItem  value="27">27 </asp:ListItem>
                            <asp:ListItem  value="28">28 </asp:ListItem>
                            <asp:ListItem  value="29">29 </asp:ListItem>
                            <asp:ListItem  value="30">30 </asp:ListItem>
                            <asp:ListItem  value="31">31 </asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox id="txtTime" class="modalSpreadOut" runat="server" type="text"></asp:TextBox>
                        <asp:DropDownList ID="amORpm" runat="server">
                            <asp:ListItem  value="am">AM</asp:ListItem>
                            <asp:ListItem  value="pm">PM</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblReservationError" runat="server" Text=""></asp:Label>
                    </section>
                    <footer class="modal-card-foot">
                      <asp:Button class="button is-success" onclick="btnModalSubmit_Clicked" runat="server" Text="Submit"></asp:Button>
                      <asp:Button class="button" onclick="btnModalCancel_Clicked" runat="server" Text="Cancel"></asp:Button>
                    </footer>
                </div>
            </div>

        </div>
    </form>

            

</body>
</html>
