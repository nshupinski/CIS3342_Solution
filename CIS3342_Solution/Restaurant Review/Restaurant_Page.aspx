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
                  <a id="btnMyReviews" runat="server" href="MyReviews.aspx" style="visibility: hidden"> My Reviews</a>
                  <a id="btnMyRestaurants" runat="server" href="MyRestaurants.aspx" style="visibility: hidden"> My Restaurants</a>
            </div>
            <div class="navbar-end">
              <a class="navbar-item is-centered" onclick="logOut()" href="Login.aspx" runat="server">      
                  Log Out
              </a>
            </div>
          </div>
        </nav>

    <form id="form1" runat="server">
        <div id="mainSection">
            <div class="card">
                <div class="card-image">
                    <asp:Button ID="btnClaimRestaurant" class="button is-primary" runat="server" Text="Claim As Restaurant Representative" onclick="btnClaimRestaurant_Clicked" Visible="false"/> 
                <figure class="image is-4by3">
                    <img id="restaurantImage" src="" alt="Restaurant" runat="server"/>
                </figure>
                </div>
                <div id="restaurantContent">
                    <div class="card-content">
                        <div class="media">
                            <div class="media-content">
                            <p id="title" class="title is-4" runat="server"></p>
                            <p id="rep" class="subtitle is-6" runat="server">Representative: </p>
                            <br />
                            <p id="foodRating" runat="server">Food: </p>
                            <br />
                            <p id="serviceRating" runat="server">Service: </p>
                            <br />
                            <p id="atmosphereRating" runat="server">Atmosphere: </p>
                            <br />
                            <p id="priceRating" runat="server">Price (1-Cheap 5-Expensive): </p>
                            <br />
                        </div>
                    </div>
                    <div class="content" id="description" runat="server">
                    </div>
                    <br />
                </div>
                </div>
            </div>
        </div>

        <div id="buttonSection">
            <asp:Button ID="viewRestaurant" class="button" runat="server" Text="Make A Reservation" onclick="btnReservation_Clicked"/> 
            <br />
            <asp:Button ID="btnMakeReview" class="button" runat="server" Text="Write A Review" onclick="btnMakeReview_Clicked" Style="visibility: hidden;"/> 
        </div>

        <asp:GridView ID="gvReviews" runat="server" AutoGenerateColumns="False" CellPadding="100" HorizontalAlign="Center" BackColor="#333333" ForeColor="White">
            <Columns>
                <asp:BoundField DataField="ReviewerName" HeaderText="Reviewer" >
                <HeaderStyle ForeColor="#CCCCCC" />
                </asp:BoundField>
                <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant" >
                <HeaderStyle ForeColor="#CCCCCC" />
                </asp:BoundField>
                <asp:BoundField DataField="Comments" HeaderText="Comments" >
                <HeaderStyle ForeColor="#CCCCCC" />
                </asp:BoundField>
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
                        <asp:ListItem  value="01">1 </asp:ListItem>
                        <asp:ListItem  value="02">2 </asp:ListItem>
                        <asp:ListItem  value="03">3 </asp:ListItem>
                        <asp:ListItem  value="04">4 </asp:ListItem>
                        <asp:ListItem  value="05">5 </asp:ListItem>
                        <asp:ListItem  value="06">6 </asp:ListItem>
                        <asp:ListItem  value="07">7 </asp:ListItem>
                        <asp:ListItem  value="08">8 </asp:ListItem>
                        <asp:ListItem  value="09">9 </asp:ListItem>
                        <asp:ListItem  value="10">10 </asp:ListItem>
                        <asp:ListItem  value="11">11 </asp:ListItem>
                        <asp:ListItem  value="12">12 </asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlDateDay" class="modalSpreadOut" runat="server">
                        <asp:ListItem  value="01">1 </asp:ListItem>
                        <asp:ListItem  value="02">2 </asp:ListItem>
                        <asp:ListItem  value="03">3 </asp:ListItem>
                        <asp:ListItem  value="04">4 </asp:ListItem>
                        <asp:ListItem  value="05">5 </asp:ListItem>
                        <asp:ListItem  value="06">6 </asp:ListItem>
                        <asp:ListItem  value="07">7 </asp:ListItem>
                        <asp:ListItem  value="08">8 </asp:ListItem>
                        <asp:ListItem  value="09">9 </asp:ListItem>
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
                    <asp:TextBox id="txtTimeHour" class="modalSpreadOut" runat="server" type="text"></asp:TextBox>
                    <asp:Label ID="lblTimeDivider" runat="server" Text=":"></asp:Label>
                    <asp:TextBox id="txtTimeMinute" runat="server" type="text"></asp:TextBox>
                    <asp:DropDownList ID="amORpm" runat="server">
                        <asp:ListItem  value="am">AM</asp:ListItem>
                        <asp:ListItem  value="pm">PM</asp:ListItem>
                    </asp:DropDownList>
                    <br /><br />
                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number"></asp:Label>
                    <asp:TextBox id="txtPhoneNumber" runat="server" type="text"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblNumPeople" runat="server" Text="Party Size"></asp:Label>
                    <asp:DropDownList ID="numPeople" runat="server">
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
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lblReservationError" runat="server" Text=""></asp:Label>
                    <br /><br />
                    <asp:Label ID="lblReservationSubmitted" class="SuccessSubmitted" runat="server" Text=""></asp:Label>
                </section>
                <footer class="modal-card-foot">
                    <asp:Button id="btnSubmitReservation" class="button is-success" onclick="btnModalSubmit_Clicked" runat="server" Text="Submit"></asp:Button>
                    <asp:Button id="btnCancelReservation" class="button" onclick="btnModalCancel_Clicked" runat="server" Text="Cancel"></asp:Button>
                </footer>
            </div>
        </div>

        <!--Review Modal -->
        <div class="modal" id="reviewModal" runat="server">
            <div class="modal-background"></div>
                <div class="modal-card">
                <header class="modal-card-head">
                    <p class="modal-card-title" id="reviewModalTitle" runat="server"></p>
                </header>
                <section class="modal-card-body">
                    <asp:Label ID="lblReviewHeader" runat="server" Text="Write A Review"></asp:Label>
                    <br />                      
                    <br />
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

        <!--Modal Claimed-->
        <div class="modal" id="modalClaimed" runat="server" visible="false">
            <div class="modal-background"></div>
                <div class="modal-card">
                <section class="modal-card-body">
                    <asp:Label ID="lblClaimedRestaurant" class="SuccessSubmitted" runat="server" Text="You have claimed this restaurant to represent!"></asp:Label>
                </section>
                <footer class="modal-card-foot">
                    <asp:Button id="btnClose" class="button is-success" onclick="btnClose_Clicked" runat="server" Text="Close"></asp:Button>
                </footer>
            </div>
            </div>

    </form>
</body>
</html>
