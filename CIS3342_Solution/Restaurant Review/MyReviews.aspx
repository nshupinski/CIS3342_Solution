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
            <asp:GridView ID="gvMyReviews" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvMyReviews_RowCancelingEdit" OnRowEditing="gvMyReviews_RowEditing" OnRowUpdating="gvMyReviews_RowUpdating" OnRowDeleting="gvMyReviews_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Review_Id" HeaderText="Review ID" ReadOnly="True" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant" ReadOnly="True" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FoodQuality" HeaderText="Food Rating" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Service" HeaderText="Service Rating" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Atmosphere" HeaderText="Atmosphere Rating" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PriceRating" HeaderText="Price Rating" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Comments" HeaderText="Comments" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Button" HeaderText="Edit Review" ShowEditButton="True" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" HeaderText="Delete Review" ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
